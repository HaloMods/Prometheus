using System.Collections.Specialized;

namespace Interfaces
{
  public class UniqueStringCollection : StringCollection
  {
    public new void Add(string value)
    {
      if (value != null)
        if (value != "")
          if (!Contains(value)) base.Add(value);
    }
    public new void AddRange(string[] values)
    {
      foreach (string value in values)
      {
        Add(value);
      }
    }
    public string[] ToArray()
    {
      string[] values = new string[Count];
      CopyTo(values, 0);
      return values;
    }
  }
}
