using System;
using System.Text.RegularExpressions;
using Nini.Config;

namespace Interfaces.Options
{
  public class Setting
  {
    private string group;
    private string name;
    private object data;

    public string Group
    {
      get { return group; }
    }
    public string Name
    {
      get { return name; }
    }
    public object Data
    {
      get
      {
        if (data is string)
        {
          if ((string)data == "False") return false;
          if ((string)data == "True") return true;
          if (IsInteger((string)data))
          {
            return (Convert.ToInt32((string)data));
          }
          if (IsFloat((string)data))
          {
            return (Convert.ToSingle((string)data));
          }
        }
        return data;
      }
      set
      {
        data = value;
        if (Updated != null) Updated(this, new EventArgs());
      }
    }

    protected bool IsInteger(string value)
    {
      Regex notNumberPattern = new Regex("[^0-9.-]");
      String validIntegerPattern = "^([-]|[0-9])[0-9]*$";
      Regex objNumberPattern = new Regex(validIntegerPattern);
      return !notNumberPattern.IsMatch(value) && objNumberPattern.IsMatch(value);
    }

    protected bool IsFloat(string value)
    {
      Regex notNumberPattern = new Regex("[^0-9.-]");
      String validRealPattern = "^([-]|[.]|[-.]|[0-9])[0-9]*[.]*[0-9]+$";
      Regex objNumberPattern = new Regex(validRealPattern);
      return !notNumberPattern.IsMatch(value) && objNumberPattern.IsMatch(value);
    }

    public event EventHandler Updated;

    public Setting(string group, string name)
    {
      this.group = group;
      this.name = name;
    }
  }
}
