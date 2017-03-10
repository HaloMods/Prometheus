using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;

namespace Interfaces.Settings
{
  /// <summary>
  /// Stores the neccessary reflection information for a type to prevent multiple lookups.
  /// </summary>
  public class TypeReflectionCache
  {
    private Type type;
    private List<TypeReflectionCacheItem> properties = new List<TypeReflectionCacheItem>();

    public Type Type
    {
      get { return type; }
    }

    public List<TypeReflectionCacheItem> Properties
    {
      get { return properties; }
    }

    /// <summary>
    /// Create a TypeReflectionCache object from the specified IPersistable instance.
    /// </summary>
    public TypeReflectionCache(IPersistable instance)
    {
      type = instance.GetType();
      EventInfo[] events = type.GetEvents();
      foreach (PropertyInfo pi in type.GetProperties())
      {
        List<PropertyInfo> cachedProperties = new List<PropertyInfo>();

        object[] attributes = pi.GetCustomAttributes(typeof(PersistableOption), true);
        if (attributes.Length > 0)
        {
          // This is a persistable option.
          PersistableOption optAtt = attributes[0] as PersistableOption;

          // Add this property to the cache list.
          TypeReflectionCacheItem item = new TypeReflectionCacheItem();
          item.PropertyInfo = pi;
          item.PersistanceInformation = optAtt;

          // Link up any events tagged with with UpdateHandler attribute.
          foreach (EventInfo info in events)
          {
            if (info.EventHandlerType == typeof(EventHandler))
            {
              // Check to see if the event is tagged as an OptionUpdateNotifier.
              object[] eventAttributes = info.GetCustomAttributes(typeof(OptionUpdateNotifier), true);
              if (eventAttributes.Length > 0)
              {
                // If has the proper attribute - if the name matches, we have a linked event.
                OptionUpdateNotifier updateAtt = eventAttributes[0] as OptionUpdateNotifier;
                if (updateAtt.LinkedOptionName == optAtt.Name)
                {
                  // A linked event was found.
                  item.EventInfo = info;
                }
              }
            }
          }

          // Add the cache item to the properties list.
          properties.Add(item);
        }
      }
    }
  }

  public class TypeReflectionCacheItem
  {
    public PersistableOption PersistanceInformation;
    public PropertyInfo PropertyInfo;
    public EventInfo EventInfo;
  }
}