using System;
using System.IO;
using System.Text;
using Nini.Config;

namespace Interfaces.Options
{
  /// <summary>
  /// Provides access to settings that are stored in a file.
  /// </summary>
  public class SettingsInterface
  {
    private SettingsList settings;
    private string filename;

    internal SettingsList Settings
    {
      get { return settings; }
    }

    /// <summary>
    /// The file to be used for configuration data.
    /// </summary>
    public string Filename
    {
      get { return filename; }
      set
      {
        try
        {
          string folder = Path.GetDirectoryName(value);
          if (!Directory.Exists(folder)) Directory.CreateDirectory(folder);
          if (!File.Exists(value)) File.Create(value).Close();
        }
        catch
        {
          throw new Exception("Error creating INI file or folder: " + value);
        }
        filename = value;
        Load();
      }
    }

    public object this[string groupName, string valueName, object defaultValue]
    {
      get
      {
        Setting s = settings.FindSetting(groupName, valueName);
        if (s != null) return s.Data;

        // The setting doesn't exist - create it, add it to the list, and return it
        s = new Setting(groupName, valueName);
        settings.Add(s);
        s.Data = defaultValue;
        return s.Data;
      }
    }

    public object this[string groupName, string valueName]
    {
      set
      {
        Setting s = settings.FindSetting(groupName, valueName);
        if (s != null)
        {
          s.Data = value;
        }
        else
        {
          // The setting doesn't exist - create it and add it to the list.
          s = new Setting(groupName, valueName);
          settings.Add(s);
          s.Data = value;
        }
      }
    }

    // Added to allow you to delete a value from the INI file (thus resetting to default)
    public object this[bool delete, string groupName, string valueName]
    {
      set
      {
        Setting s = settings.FindSetting(groupName, valueName);

        // If we've found it, delete it.
        if (s != null && delete == true)
        {
          settings.Remove(groupName, valueName);
        }
      }
    }

    public SettingsInterface()
    {
      settings = new SettingsList();
      settings.Dirty += new EventHandler(Settings_Dirty);
    }

    private void Settings_Dirty(object sender, EventArgs e)
    {
      Save();
    }

    public void Save()
    {
      /*IConfigSource source = new IniConfigSource(filename);

      foreach (Setting setting in settings)
      {
        IConfig config;
        if (source.Configs[setting.Group] == null)
        {
          config = source.AddConfig(setting.Group);
        }
        else
        {
          config = source.Configs[setting.Group];
        }
        config.Set(setting.Name, setting.Data);
      }
      source.Save();*/
      Interfaces.Settings.OptionsMerger.SaveStatic();
    }

    public void Load()
    {
      /*IConfigSource source = new IniConfigSource(filename);
      foreach (IConfig config in source.Configs)
      {
        string[] keys = config.GetKeys();
        for (int x = 0; x < keys.Length; x++)
        {
          Setting setting = new Setting(config.Name, keys[x]);
          setting.Data = config.GetString(keys[x]);
          settings.Add(setting);
        }
      }*/
      settings = Interfaces.Settings.OptionsMerger.LoadStatic();
      settings.Dirty += new EventHandler(Settings_Dirty);
    }
    // Added to allow you to delete a value from the INI file (thus resetting to default)
    public void Delete(string groupName, string valueName)
    {
      Setting s = settings.FindSetting(groupName, valueName);

      // If we've found it, delete it.
      if (s != null)
      {
        settings.Remove(groupName, valueName);
      }
    }
  }
}
