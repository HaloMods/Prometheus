using System;
using System.Collections.Generic;
using System.Text;
using Interfaces.Options;
using System.Xml;
using System.IO;

namespace Interfaces.Settings
{
  /// <summary>
  /// A class which merges the two option systems we have to use the same files.
  /// </summary>
  /// <remarks>The new system favors MonoxideC's Settings system. If that system is removed, the options system will no longer work correctly because it is Mono's system which initializes this one.</remarks>
  public static class OptionsMerger
  {
    static XmlDocument userSettings = new XmlDocument(), systemSettings = new XmlDocument();
    static string UserSettingsFilename, SystemSettingsFilename;
    static bool initialized = false;

    #region Static System Handlers
    public static Options.SettingsList LoadStatic()
    {
      if (!initialized)
        Initialize(SettingsManager.UserSettingsFilename, SettingsManager.SystemSettingsFilename);

      SettingsList list = new SettingsList();

      // We need to find the root (main) node.
      XmlNode mainNode = null;
      foreach (XmlNode mainNodeTemp in userSettings.ChildNodes)
      {
        if (mainNodeTemp.Name.ToLower() == "settings")
          mainNode = mainNodeTemp;
      }

      // The main node could not be found.
      if (mainNode == null)
        return list;

      foreach (XmlNode xmlGroup in mainNode.ChildNodes)
      {
        if (xmlGroup.Name.ToLower() == "group")
        {
          string group = "";
          foreach (XmlAttribute attr in xmlGroup.Attributes)
            if (attr.Name == "name")
              group = attr.Value;
          foreach (XmlNode xmlSetting in xmlGroup.ChildNodes)
          {
            if (xmlSetting.Name.ToLower() == "setting")
            {
              string name = "";
              foreach (XmlAttribute attr in xmlSetting.Attributes)
                if (attr.Name == "name")
                  name = attr.Value;
              Setting setting = new Setting(group, name);
              setting.Data = xmlSetting.InnerText;
              list.Add(setting);
            }
          }
        }
      }

      return list;
    }
    /// <summary>
    /// This method is called by the static options sytem when it wants to save it's settings.
    /// </summary>
    /// <param name="a"></param>
    /// <returns></returns>
    public static bool SaveStatic()
    {
      if (!initialized)
        Initialize(SettingsManager.UserSettingsFilename, SettingsManager.SystemSettingsFilename);

      SettingsList list = Options.OptionManager.UserOptions.Settings;

      // We need to find the root (main) node.
      XmlNode mainNode = null;
      foreach (XmlNode mainNodeTemp in userSettings.ChildNodes)
      {
        if (mainNodeTemp.Name.ToLower() == "settings")
          mainNode = mainNodeTemp;
      }

      // If we couldn't find one, create one.
      if (mainNode == null)
      {
        mainNode = userSettings.CreateNode(XmlNodeType.Element, "settings","");
        userSettings.AppendChild(mainNode);
      }

      // Cycle through the list of settings to save them to the XmlDocument
      for (int x = 0; x < list.Count; x++)
      {
        XmlNode group = GetOrCreateNode(userSettings, mainNode, "group", list[x].Group);
        XmlNode setting = GetOrCreateNode(userSettings, group, "setting", list[x].Name);
        setting.InnerText = Convert.ToString(list[x].Data) ;
      }

      Save();

      return true;
    }


    #endregion

    #region Instance System Handlers
    public static void Initialize(string userSettingsFilename, string systemSettingsFilename)
    {
      SystemSettingsFilename = systemSettingsFilename;
      UserSettingsFilename = userSettingsFilename;

      // Open and load the specified settings files.
      if (!File.Exists(systemSettingsFilename))
        CreateBaseDocument().Save(systemSettingsFilename);
      systemSettings.Load(systemSettingsFilename);

      if (!File.Exists(userSettingsFilename))
        CreateBaseDocument().Save(userSettingsFilename);
      userSettings.Load(userSettingsFilename);
    }
    private static XmlDocument CreateBaseDocument()
    {
      XmlDocument doc = new XmlDocument();
      XmlNode node = doc.CreateNode(XmlNodeType.XmlDeclaration, "", "");
      doc.AppendChild(node);
      XmlElement rootNode = doc.CreateElement("settings");
      doc.AppendChild(rootNode);
      return doc;
    }
    public static XmlNode LocateOrCreateNode(TypeReflectionCacheItem item, IPersistable instance, out bool created)
    {
      XmlDocument doc = systemSettings;
      if (item.PersistanceInformation.File == OptionsFile.User)
        doc = userSettings;

      string categoryName = item.PersistanceInformation.Category;
      string instanceName = instance.InstanceName;
      string valueName = item.PersistanceInformation.Name;

      XmlNode settingsNode = doc.SelectSingleNode("//settings");
      XmlNode categoryNode = GetOrCreateNode(doc, settingsNode, "category", categoryName);
      XmlNode instanceNode = GetOrCreateNode(doc, categoryNode, "instance", instanceName);
      XmlNode valueNode = GetOrCreateNode(doc, instanceNode, "value", valueName, out created);

      if (created)
        SetNodeValue(valueNode, item.PersistanceInformation.DefaultValue.ToString(),
          item.PersistanceInformation.Encrypted);

      return valueNode;
    }
    /// <summary>
    /// Locates the specified node and returns a reference to it.
    /// If the node does not exist in the document, it will be created.
    /// This is a factored method that is only intended to be used internally on three node types.
    /// </summary>
    public static XmlNode GetOrCreateNode(XmlDocument doc, XmlNode parentNode, string nodeType, string nodeName)
    {
      bool created;
      return GetOrCreateNode(doc, parentNode, nodeType, nodeName, out created);
    }
    public static XmlNode GetOrCreateNode(XmlDocument doc, XmlNode parentNode, string nodeType, string nodeName, out bool created)
    {
      created = false;
      string xpath = String.Format("{0}[@name='{1}']", nodeType, nodeName);
      XmlNode node = parentNode.SelectSingleNode(xpath);
      if (node == null)
      {
        node = doc.CreateNode(XmlNodeType.Element, nodeType, "");
        XmlAttribute nameAttr = doc.CreateAttribute("name");
        nameAttr.Value = nodeName;
        node.Attributes.Append(nameAttr);
        parentNode.AppendChild(node);
        created = true;
      }
      return node;
    }
    public static void SetNodeValue(XmlNode node, string value, bool encrypt)
    {
      if (encrypt) value = EncryptString(value);
      node.InnerText = value;
    }
    public static string EncryptString(string s)
    {
      return Encryption.Encrypt(s, "PROM1ETHE2US", "1ACBK", "SHA1", 2, "@1B2c3D4e5F6g7H8", 256);
    }
    public static string DecryptString(string s)
    {
      return Encryption.Decrypt(s, "PROM1ETHE2US", "1ACBK", "SHA1", 2, "@1B2c3D4e5F6g7H8", 256);
    }
    /// <summary>
    /// Loads the static options from the XML file and returns the SettingsList.
    /// </summary>
    /// <returns></returns>
    public static Settings.PersistableOption LoadInstance()
    {
      return null;
    }
    public static void SaveInstance(IPersistable persistableObject)
    {
      
    }
    #endregion

    /// <summary>
    /// Performs a complete save of both instance-based and static-based settings.
    /// </summary>
    /// <returns>True if the operation was successful.</returns>
    public static bool Save()
    {
      userSettings.Save(UserSettingsFilename);
      systemSettings.Save(SystemSettingsFilename);
      return true;
    }
  }
}
