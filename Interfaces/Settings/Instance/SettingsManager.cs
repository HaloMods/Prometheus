using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using System.Xml;

namespace Interfaces.Settings
{
  public class SettingsManager
  {
    public static readonly string SystemSettingsFilename = Application.StartupPath + "\\prometheus.settings";
    public static readonly string UserSettingsFilename = Application.StartupPath + "\\user.settings";
    private static SettingsManager instance = null;
    private List<IPersistable> instances = new List<IPersistable>();
    private Dictionary<Type, TypeReflectionCache> typeCache = new Dictionary<Type, TypeReflectionCache>();

    //private XmlDocument systemSettings = new XmlDocument();
    //private string systemSettingsFilename;
    //private XmlDocument userSettings = new XmlDocument();
    //private string userSettingsFilename;

    private bool batchInProgress = false;

    public static SettingsManager Instance
    {
      get
      {
        if (instance == null)
          instance = new SettingsManager(SystemSettingsFilename,
          UserSettingsFilename);
        return instance;
      }
    }
    
    private SettingsManager(string systemSettingsFilename, string userSettingsFilename)
    {
      OptionsMerger.Initialize(userSettingsFilename, systemSettingsFilename);
    }

    /// <summary>
    /// Registers an instance with the SettingsManager, linking up any auto-update events.
    /// </summary>
    protected void RegisterInstance(IPersistable instance)
    {
      Type t = instance.GetType();

      // Retreive the type's cache, or create one if it does not already exist.
      if (!typeCache.ContainsKey(t))
        typeCache.Add(t, new TypeReflectionCache(instance));
      
      TypeReflectionCache cache = typeCache[t];
      
      // Hook up any existing auto-update event handlers for this instance.
      foreach (TypeReflectionCacheItem item in cache.Properties)
      {
        if (item.EventInfo != null)
          item.EventInfo.AddEventHandler(instance, new EventHandler(UpdateHandler));

      }
    }

    /// <summary>
    /// Loads the specified instance from the options file(s).
    /// </summary>
    public void LoadInstance(IPersistable persistableObject)
    {
      Type t = persistableObject.GetType();
      if (!typeCache.ContainsKey(t))
        RegisterInstance(persistableObject);

      TypeReflectionCache cache = typeCache[t];
      foreach (TypeReflectionCacheItem item in cache.Properties)
      {
        bool created;
        XmlNode valueNode = LocateOrCreateNode(item, persistableObject, out created);
        string value = valueNode.InnerText;
        if (item.PersistanceInformation.Encrypted)
          value = OptionsMerger.DecryptString(value);

        Type propertyType = item.PropertyInfo.PropertyType;
        if (propertyType == typeof(string))
          item.PropertyInfo.SetValue(persistableObject, value, null);
        else if (propertyType == typeof(Single))
          item.PropertyInfo.SetValue(persistableObject, Convert.ToSingle(value), null);
        else if (propertyType == typeof(int))
          item.PropertyInfo.SetValue(persistableObject, Convert.ToInt32(value), null);
        else if (propertyType == typeof(bool))
          item.PropertyInfo.SetValue(persistableObject, Convert.ToBoolean(value), null);
        else
          throw new Exception("An unknown type was encountered while loading named instance '" +
            persistableObject.InstanceName + "' - " + propertyType);

        if (created)
          SaveInstance(persistableObject);
      }
    }
    
    /// <summary>
    /// Saves the specified instance the the options file(s).
    /// </summary>
    public void SaveInstance(IPersistable persistableObject)
    {
      Type t = persistableObject.GetType();
      if (!typeCache.ContainsKey(t))
        RegisterInstance(persistableObject);

      TypeReflectionCache cache = typeCache[t];
      foreach (TypeReflectionCacheItem item in cache.Properties)
      {
        bool created;
        XmlNode valueNode = OptionsMerger.LocateOrCreateNode(item, persistableObject, out created);
        object newValue = item.PropertyInfo.GetValue(persistableObject, null);
        OptionsMerger.SetNodeValue(valueNode, newValue.ToString(), item.PersistanceInformation.Encrypted);
      }

      // Don't save the files to disk if we are currently in batch update mode.
      if (!batchInProgress)
        SaveFiles();
    }

    /// <summary>
    /// Begins a batch update of settings.  The files will not be saved to disk
    /// until EndBatch() is called.
    /// </summary>
    public void BeginBatch()
    {
      batchInProgress = true;
    }

    /// <summary>
    /// Ends a batch update of settings and saves the settings files to disk.
    /// </summary>
    public void EndBatch()
    {
      batchInProgress = false;
      SaveFiles();
    }

    /// <summary>
    /// Saves all instances that have been registered with the SettingsManager.
    /// </summary>
    public void SaveAll()
    {
      BeginBatch();
      foreach (IPersistable instance in instances)
      {
        SaveInstance(instance);
      }
      EndBatch();
    }

    /// <summary>
    /// Writes the XML documents to disk.
    /// </summary>
    private void SaveFiles()
    {
      OptionsMerger.Save();
    }

    /// <summary>
    /// Locates the XML node that contains persistance information for the specified item.
    /// If the node is not found, it will be created.
    /// </summary>
    private static XmlNode LocateOrCreateNode(TypeReflectionCacheItem item, IPersistable instance, out bool created)
    {
      return OptionsMerger.LocateOrCreateNode(item, instance, out created);
    }

    /// <summary>
    /// Handles automatic updates.
    /// </summary>
    private void UpdateHandler(object sender, EventArgs e)
    {
      if (sender is IPersistable)
        SaveInstance(sender as IPersistable);
    }
  }
}