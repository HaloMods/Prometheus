using System;
using System.Collections.Generic;
using System.Drawing;
using System.Reflection;
using Interfaces.DebugConsole;
using Microsoft.DirectX.Direct3D;
using DI = Microsoft.DirectX.DirectInput;
using Font = System.Drawing.Font;
using DXFont = Microsoft.DirectX.Direct3D.Font;
using Interfaces;
using Core.Input;
using Microsoft.DirectX;
using Core.Rendering;

namespace Core.DebugConsole
{
  public class DebugConsole
  {
    private int index = 0;
    private bool rendering = false;
    private string command = String.Empty;
    private DXFont font = null;
    private Device device = null;
    private List<string> history = new List<string>();

    [Console("console_history", "the maximum number of entries stored in console history.")]
    private static int maxHistory = 30;
    private static List<FieldInvocation> fields = new List<FieldInvocation>();
    private static List<MethodInvocation> methods = new List<MethodInvocation>();

    private const string Prompt = "prometheus> ";
    private const string Cursor = "•";

    public DebugConsole(Device device)
    {
      this.device = device;
      font = new DXFont(device, new Font("Verdana", 10, FontStyle.Bold));
    }

    public virtual void Render()
    {
      if (!Prometheus.Instance.MdxInputAquired)
        return;

      DI.KeyboardState ks = null;
      //try
      //{
        ks = MdxInput.Keyboard.GetCurrentKeyboardState();
      //}
      //catch (DirectXException) // most likely not acquired
      //{
      //  return;
      //}

      if (ks[DI.Key.Grave])
      {
        if (rendering)
        {
          command = String.Empty;
          rendering = false;
        }
        else
          rendering = true;

        while (MdxInput.Keyboard.GetPressedKeys().Length > 0)
          /* hack: probably shouldn't be doing this */;
      }

      if (rendering)
      {
        if (ks[DI.Key.BackSpace])
          if (command.Length > 0)
            command = command.Remove(command.Length - 1);
        command += GetKeyString(ks, MdxInput.Keyboard.GetPressedKeys());

        string drawString = Prompt + command;
        if ((Environment.TickCount & 0x200) == 0)
          drawString += Cursor;
        font.DrawText(null, drawString, 16, device.Viewport.Height - 28, Color.HotPink);

        if (ks[DI.Key.Return])
        {
          history.Add(command);
          if (history.Count > maxHistory)
            history.RemoveAt(0);
          Execute();
          index = history.Count;
          command = String.Empty;
          rendering = false;
        }

        if (ks[DI.Key.Up])
        {
          if (index > 0)
            index--;
          if(index < history.Count)
            command = history[index];
        }

        if (ks[DI.Key.Down])
        {
          if (index < history.Count - 1)
            index++;
          if (index < history.Count)
            command = history[index];
        }

        while ((MdxInput.Keyboard.GetPressedKeys().Length > 0 && !ks[DI.Key.LeftShift] && !ks[DI.Key.RightShift]) || (MdxInput.Keyboard.GetPressedKeys().Length > 1 && (ks[DI.Key.LeftShift] || ks[DI.Key.RightShift])))
          /* hack: probably shouldn't be doing this */;
      }

      RenderCore.EnableCameraInput = !rendering;
    }

    protected virtual void Execute()
    {
      string[] token = command.Split(' ');
      if (token.Length == 0)
        return;

      if (token[0] == "set")
      {
        if (token.Length == 3)
        {
          foreach (FieldInvocation field in fields)
          {
            if(field.Name == token[1])
            {
              field.Value = token[2];
              Output.Write(OutputTypes.Developer, "Field {0} set to {1} of type {2}.", field.Name, field.Value, field.Value.GetType().Name);
              return;
            }
          }
          Output.Write(OutputTypes.Developer, "Field was not found.");
        }
        else
          Output.Write(OutputTypes.Developer, "Usage: set field_name value");
        return;
      }

      if (token[0] == "get")
      {
        if (token.Length == 2)
        {
          foreach (FieldInvocation field in fields)
          {
            if (field.Name == token[1])
            {
              Output.Write(OutputTypes.Developer, "Field {0} has the value {1} of type {2}.", field.Name, field.Value, field.Value.GetType().Name);
              return;
            }
          }
          Output.Write(OutputTypes.Developer, "Field was not found.");
        }
        else
          Output.Write(OutputTypes.Developer, "Usage: get field_name");
        return;
      }

      if (token[0] == "help")
      {
        Output.Write(OutputTypes.Developer, "Available functions:");
        Output.Write(OutputTypes.Developer, "    help; returns this handy list of functions");
        Output.Write(OutputTypes.Developer, "    get field_name; returns the value of the given field");
        Output.Write(OutputTypes.Developer, "    set field_name value; modifies the value of the given field");
        foreach (MethodInvocation helpMethod in methods)
          Output.Write(OutputTypes.Developer, "    " + helpMethod.Name + ' ' + helpMethod.Usage + "; " + helpMethod.Description);
        Output.Write(OutputTypes.Developer, "Available fields for 'get' and 'set':");
        foreach (FieldInvocation helpField in fields)
          Output.Write(OutputTypes.Developer, "    " + helpField.Name + " (" + helpField.TypeName + "); " + helpField.Description);
        return;
      }

      foreach (MethodInvocation method in methods)
      {
        if (method.Name == token[0])
        {
          if (token.Length - 1 == method.ParameterCount)
          {
            object[] arguments = new object[method.ParameterCount];
            for(int i = 0; i < method.ParameterCount; i++)
              arguments[i] = token[i + 1];
            if (method.Void)
              method.Invoke(arguments);
            else
              Output.Write(OutputTypes.Developer, Convert.ToString(method.Invoke(arguments)));
          }
          else
            Output.Write(OutputTypes.Developer, "Usage: " + method.Name + ' ' + method.Usage);
          return;
        }
      }

      Output.Write(OutputTypes.Developer, "The requested function was not found.");
    }

    public bool CaptureKeyboard
    {
      get
      { return rendering; }
    }

    private static string GetKeyString(DI.KeyboardState ks, DI.Key[] keys)
    {
      char c = '×';
      string final = String.Empty;
      foreach (DI.Key k in keys)
      {
        // Specialty list
        if (k == DI.Key.D0)
        {
          if (ks[DI.Key.LeftShift] || ks[DI.Key.RightShift])
            final += ")";
          else
            final += "0";
          continue;
        }
        if (k == DI.Key.D1)
        {
          if (ks[DI.Key.LeftShift] || ks[DI.Key.RightShift])
            final += "!";
          else
            final += "1";
          continue;
        }
        if (k == DI.Key.D2)
        {
          if (ks[DI.Key.LeftShift] || ks[DI.Key.RightShift])
            final += "@";
          else
            final += "2";
          continue;
        }
        if (k == DI.Key.D3)
        {
          if (ks[DI.Key.LeftShift] || ks[DI.Key.RightShift])
            final += "#";
          else
            final += "3";
          continue;
        }
        if (k == DI.Key.D4)
        {
          if (ks[DI.Key.LeftShift] || ks[DI.Key.RightShift])
            final += "$";
          else
            final += "4";
          continue;
        }
        if (k == DI.Key.D5)
        {
          if (ks[DI.Key.LeftShift] || ks[DI.Key.RightShift])
            final += "%";
          else
            final += "5";
          continue;
        }
        if (k == DI.Key.D6)
        {
          if (ks[DI.Key.LeftShift] || ks[DI.Key.RightShift])
            final += "^";
          else
            final += "6";
          continue;
        }
        if (k == DI.Key.D7)
        {
          if (ks[DI.Key.LeftShift] || ks[DI.Key.RightShift])
            final += "&";
          else
            final += "7";
          continue;
        }
        if (k == DI.Key.D8)
        {
          if (ks[DI.Key.LeftShift] || ks[DI.Key.RightShift])
            final += "*";
          else
            final += "8";
          continue;
        }
        if (k == DI.Key.D9)
        {
          if (ks[DI.Key.LeftShift] || ks[DI.Key.RightShift])
            final += "(";
          else
            final += "9";
          continue;
        }
        if (k == DI.Key.Minus)
        {
          if (ks[DI.Key.LeftShift] || ks[DI.Key.RightShift])
            final += "_";
          else
            final += "-";
          continue;
        }
        if (k == DI.Key.Space)
        {
          final += " ";
          continue;
        }
        if (k == DI.Key.BackSlash)
        {
          if (ks[DI.Key.LeftShift] || ks[DI.Key.RightShift])
            final += "|";
          else
            final += "\\";
          continue;
        }
        if (k == DI.Key.Slash)
        {
          if (ks[DI.Key.LeftShift] || ks[DI.Key.RightShift])
            final += "?";
          else
            final += "/";
          continue;
        }
        if (k == DI.Key.Apostrophe)
        {
          if (ks[DI.Key.LeftShift] || ks[DI.Key.RightShift])
            final += "\"";
          else
            final += "'";
          continue;
        }
        if (k == DI.Key.Comma)
        {
          if (ks[DI.Key.LeftShift] || ks[DI.Key.RightShift])
            final += "<";
          else
            final += ",";
          continue;
        }
        if (k == DI.Key.Period)
        {
          if (ks[DI.Key.LeftShift] || ks[DI.Key.RightShift])
            final += ">";
          else
            final += ".";
          continue;
        }
        
        // Letters
        if (Enum.GetName(typeof(DI.Key), k).Length == 1)
        {
          c = Enum.GetName(typeof(DI.Key), k)[0];
          if (ks[DI.Key.LeftShift] || ks[DI.Key.RightShift])
            final += new string(c, 1).ToUpper();
          else
            final += new string(c, 1).ToLower();
        }
      }

      return final;
    }

    public static void RegisterAssembly(Assembly assembly)
    {
      Type[] types = assembly.GetTypes();
      foreach (Type t in types)
      {
        FieldInfo[] fieldInfos = t.GetFields(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static);
        foreach (FieldInfo field in fieldInfos)
        {
          object[] attributes = field.GetCustomAttributes(typeof(ConsoleAttribute), false);
          for (int i = 0; i < attributes.Length; i++)
          {
            if (attributes[i] is ConsoleAttribute)
            {
              ConsoleAttribute attribute = attributes[i] as ConsoleAttribute;
              bool containsField = false;
              foreach (FieldInvocation fieldCheck in fields)
              {
                if (fieldCheck.Name == attribute.InvocationName)
                {
                  containsField = true;
                  break;
                }
              }
              if (!containsField)
                fields.Add(new FieldInvocation(attribute.InvocationName, attribute.Description, field));
            }
          }
        }

        MethodInfo[] methodInfos = t.GetMethods(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static);
        foreach (MethodInfo method in methodInfos)
        {
          object[] attributes = method.GetCustomAttributes(typeof(ConsoleAttribute), false);
          for (int i = 0; i < attributes.Length; i++)
          {
            if (attributes[i] is ConsoleAttribute)
            {
              ConsoleAttribute attribute = attributes[i] as ConsoleAttribute;
              bool containsMethod = false;
              foreach (MethodInvocation methodCheck in methods)
              {
                if (methodCheck.Name == attribute.InvocationName)
                {
                  containsMethod = true;
                  break;
                }
              }
              if (!containsMethod)
                methods.Add(new MethodInvocation(attribute.InvocationName, attribute.Description, attribute.Usage, method));
            }
          }
        }
      }
    }

    static DebugConsole()
    {
      Assembly entry = Assembly.GetEntryAssembly();
      Assembly executing = Assembly.GetExecutingAssembly();

      RegisterAssembly(executing);
      if (executing.FullName != entry.FullName)
        RegisterAssembly(entry);
    }

    public void OnResetDevice()
    {
      font.OnResetDevice();
    }

    public void OnLostDevice()
    {
      font.OnLostDevice();
    }

  }
}
