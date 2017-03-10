using System;
using System.Reflection;
using Interfaces;

namespace Core.DebugConsole
{
  internal class MethodInvocation
  {
    private string name = null;
    private string description = null;
    private string usage = null;
    private MethodInfo method = null;

    public MethodInvocation(string name, string description, string usage, MethodInfo info)
    {
      this.name = name;
      this.description = description;
      this.usage = usage;
      method = info;
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

    public string Usage
    {
      get
      { return usage; }
    }

    public int ParameterCount
    {
      get
      { return method.GetParameters().Length; }
    }

    public bool Void
    {
      get
      { return method.ReturnType == typeof(void); }
    }

    public object Invoke(params object[] arguments)
    {
      ParameterInfo[] parameters = method.GetParameters();
      for (int i = 0; i < arguments.Length; i++)
      {
        if (parameters[i].ParameterType == typeof(float))
          arguments[i] = Convert.ToSingle(arguments[i]);
        else if (parameters[i].ParameterType == typeof(double))
          arguments[i] = Convert.ToDouble(arguments[i]);
        else if (parameters[i].ParameterType == typeof(sbyte))
          arguments[i] = Convert.ToSByte(arguments[i]);
        else if (parameters[i].ParameterType == typeof(short))
          arguments[i] = Convert.ToInt16(arguments[i]);
        else if (parameters[i].ParameterType == typeof(int))
          arguments[i] = Convert.ToInt32(arguments[i]);
        else if (parameters[i].ParameterType == typeof(long))
          arguments[i] = Convert.ToInt64(arguments[i]);
        else if (parameters[i].ParameterType == typeof(byte))
          arguments[i] = Convert.ToByte(arguments[i]);
        else if (parameters[i].ParameterType == typeof(ushort))
          arguments[i] = Convert.ToUInt16(arguments[i]);
        else if (parameters[i].ParameterType == typeof(uint))
          arguments[i] = Convert.ToUInt32(arguments[i]);
        else if (parameters[i].ParameterType == typeof(ulong))
          arguments[i] = Convert.ToUInt64(arguments[i]);
        else if (parameters[i].ParameterType == typeof(string))
          arguments[i] = Convert.ToString(arguments[i]);
        else if (parameters[i].ParameterType == typeof(bool))
          arguments[i] = Convert.ToBoolean(arguments[i]);
        else
          Output.Write(OutputTypes.Error, "Cannot cast a value of type {0} to type {1}.", arguments[i].GetType().FullName, parameters[i].ParameterType.FullName);
      }

      return method.Invoke(null, arguments);
    }
  }
}
