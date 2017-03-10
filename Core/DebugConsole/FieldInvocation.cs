using System;
using System.Reflection;
using Interfaces;

namespace Core.DebugConsole
{
  internal class FieldInvocation
  {
    private string name = null;
    private string description = null;
    private FieldInfo field = null;

    public FieldInvocation(string name, string description, FieldInfo info)
    {
      this.name = name;
      this.description = description;
      field = info;
    }

    public string Name
    {
      get
      { return name; }
    }

    public string Description
    {
      get
      { return description; }
    }

    public string TypeName
    {
      get
      { return field.FieldType.Name; }
    }

    public object Value
    {
      get
      { return field.GetValue(null); }
      set
      {
        if (field.FieldType == typeof(float))
          field.SetValue(null, Convert.ToSingle(value));
        else if (field.FieldType == typeof(double))
          field.SetValue(null, Convert.ToDouble(value));
        else if (field.FieldType == typeof(sbyte))
          field.SetValue(null, Convert.ToSByte(value));
        else if (field.FieldType == typeof(short))
          field.SetValue(null, Convert.ToInt16(value));
        else if (field.FieldType == typeof(int))
          field.SetValue(null, Convert.ToInt32(value));
        else if (field.FieldType == typeof(long))
          field.SetValue(null, Convert.ToInt64(value));
        else if (field.FieldType == typeof(byte))
          field.SetValue(null, Convert.ToByte(value));
        else if (field.FieldType == typeof(ushort))
          field.SetValue(null, Convert.ToUInt16(value));
        else if (field.FieldType == typeof(uint))
          field.SetValue(null, Convert.ToUInt32(value));
        else if (field.FieldType == typeof(ulong))
          field.SetValue(null, Convert.ToUInt64(value));
        else if (field.FieldType == typeof(string))
          field.SetValue(null, Convert.ToString(value));
        else if (field.FieldType == typeof(bool))
          field.SetValue(null, Convert.ToBoolean(value));
        else
          Output.Write(OutputTypes.Error, "Cannot cast a value of type {0} to type {1}.", value.GetType().FullName, field.FieldType.FullName);
      }
    }
  }
}
