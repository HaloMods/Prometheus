using System;
using System.Reflection;

namespace Interfaces
{
  /// <summary>
  /// Aids in obtaining text values to represent values within an enum.
  /// </summary>
  public class EnumReader
  {
    /// <summary>
    /// Returns a string representing the specified enum value.
    /// </summary>
    public static string GetText(Enum @enum)
    {
      Type type = @enum.GetType();
      MemberInfo[] info = type.GetMember(@enum.ToString());
      if (info != null && info.Length > 0)
      {
        object[] attrs = info[0].GetCustomAttributes(typeof(EnumTextAttribute), false);
        if (attrs != null && attrs.Length > 0)
          return ((EnumTextAttribute)attrs[0]).Text;
      }
      // No EnumTextAtrribute was found - return the default name.
      return @enum.ToString("G");
    }

    /// <summary>
    /// Returns an enum of the specified type based on the supplied string.
    /// </summary>
    public static T Parse<T>(string value)
    {
      return (T)Enum.Parse(typeof(T), value);
    }
  }

  /// <summary>
  /// Associates a Text value with an Attribute.
  /// </summary>
  public class EnumTextAttribute : Attribute
  {
    private string text;
    public string Text
    {
      get { return text; }
      set { text = value; }
    }

    public EnumTextAttribute(string text)
    {
      Text = text;
    }
  }
}
