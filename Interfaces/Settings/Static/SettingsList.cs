using System;
using System.Collections;
using System.Text;
using Nini.Config;

namespace Interfaces.Options
{
  public class SettingsList : CollectionBase
  {
    public Setting this[int index]
    {
      get { if (List[index] != null) return List[index] as Setting; else return null; }

    }
    public Setting FindSetting(string groupName, string valueName)
    {
      foreach (Setting setting in List)
      {
        if (setting.Group.ToLower() == groupName.ToLower())
        {
          if (setting.Name.ToLower() == valueName.ToLower())
          {
            return setting;
          }
        }
      }
      return null;
    }

    public void Add(Setting setting)
    {
      List.Add(setting);
      setting.Updated += new EventHandler(setting_Updated);
    }

    public void Remove(string groupName, string valueName)
    {
      Setting setting = FindSetting(groupName, valueName);
      if (setting != null)
      {
        List.Remove(setting);
      }
    }

    public event EventHandler Dirty;

    private void setting_Updated(object sender, EventArgs e)
    {
      if (Dirty != null) Dirty(this, new EventArgs());
    }
  }
}
