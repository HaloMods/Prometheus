using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading;

namespace Interfaces
{
  public static class Output
  {
    private static List<IOutputListener> listeners = new List<IOutputListener>();
    private static OutputTypes outputLevel = OutputTypes.User;
    private static object sync = new object();
    
    public static OutputTypes OutputLevel
    {
      get { return outputLevel; }
      set { outputLevel = value; }
    }
    
    public static void AddListener(IOutputListener listener)
    {
      lock (sync)
      {
        listeners.Add(listener);
      }
    }
    
    public static void Write(OutputTypes outputTypes, string text, string additionalInformation)
    {
      Write(outputTypes, additionalInformation, text, new object[0]);
    }
    public static void Write(OutputTypes outputTypes, string text, params object[] parameters)
    {
      Write(outputTypes, String.Empty, text, parameters);
    }
    private static void Write(OutputTypes outputTypes, string additionalInformation, string text, params object[] parameters)
    {
      if ((outputTypes & outputLevel) > 0)
      {
        string outputText = String.Format(text, parameters);
        foreach (IOutputListener listener in listeners)
          listener.Write(outputText, additionalInformation, outputTypes);
      }
    }
  }
  
  public interface IOutputListener
  {
    string Name { get; }
    void Write(string text, string additionalInformation, OutputTypes outputTypes);
  }
  
  public class LogFileListener : IOutputListener
  {
    private string name;
    private string filename;

    public string Name
    {
      get { return name; }
    }

    public LogFileListener(string name, string filename)
    {
      this.name = name;
      this.filename = filename;

      string headerText = "Prometheus Log File Opened: " + DateTime.Now.ToLongDateString() +  "\r\n";
      string seperatorText = new String('-', headerText.Length) + "\r\n";
      string fullHeader = seperatorText + headerText + seperatorText;
      File.AppendAllText(filename, fullHeader);
    }

    public void Write(string text, string additionalInformation, OutputTypes outputTypes)
    {
      string output = String.Format("[{0}] {1} : {2}\r\n",
        EnumReader.GetText(outputTypes), DateTime.Now.ToLongTimeString(), text);
      File.AppendAllText(filename, output);
    }
  }

  [FlagsAttribute]
  public enum OutputTypes
  {
    None = 0,
    Information = 1,
    Warning = 1 << 1,
    Error = 1 << 2,
    User = Information | Warning | Error,
    Debug = 1 << 3,
    Developer = User | Debug
  }
}
