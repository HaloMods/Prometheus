using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Windows.Forms;
using System.Xml;
using Core.ArchiveFileSystem;
using Core.Libraries;
using Interfaces.Pool;
using Interfaces.Project;
using Interfaces.Scripting;
using Interfaces.Scripting.EngineDefinition;
using Type=System.Type;
using Interfaces.Rendering;

namespace Interfaces.Games
{
  /// <summary>
  /// Provides a base for implementing support for a BLAM Engine based game within Prometheus.
  /// This class is abstract.
  /// </summary>
  public abstract class GameDefinition
  {
    protected ILibrary globalTagLibrary = null;
    protected Assembly assembly = null;
    protected Dictionary<string, Type> fieldControlTable = null;

    protected GameDefinition(Assembly assembly)
    { this.assembly = assembly; }

    /// <summary>
    /// The game's platform.
    /// </summary>
    public abstract Platform Platform
    { get; }
    
    /// <summary>
    /// The name of the game that is being supported.
    /// </summary>
    public abstract string Name
    { get; }

    /// <summary>
    /// Returns a string containing the path in which the game's mapfiles are located.
    /// This is a user-definable option.
    /// </summary>
    public abstract string MapFilePath
    { get; }

    /// <summary>
    /// Returns the path in which assets used in conjunction with and created for this
    /// particular game will be stored.
    /// Standard convention is "Platform\Game".
    /// </summary>
    public string HomePath
    {
      get { return EnumReader.GetText(Platform) + "\\" + Name; }
    }

    /// <summary>
    /// Gets the path identifier used by tags in this game.
    /// Example: Halo 2 for xbox is "halo2xbox", while Halo 1 for PC is "halo1pc".
    /// </summary>
    public string GameID
    {
      get { return GetGameID(Name, Platform); }
    }

    /// <summary>
    /// Returns a GameID string for the given game name/platform.
    /// </summary>
    public static string GetGameID(string name, Platform platform)
    {
      return (name + EnumReader.GetText(platform)).Replace(" ", "").ToLower();
    }

    /// <summary>
    /// Returns a verbose name for the game.
    /// Ex: Halo 2 for the Xbox.
    /// </summary>
    public string LongName
    {
      get { return Name + " for the " + EnumReader.GetText(Platform); }
    }

    /// <summary>
    /// Gets the namespace where class generator field types are defined.
    /// </summary>
    /// <remarks>
    /// This should expose a static field.
    /// </remarks>
    public abstract string FieldTypeNamespace { get; }

    /// <summary>
    /// Gets the namespace where resources are defined.
    /// </summary>
    /// <remarks>
    /// This should expose a static field.
    /// </remarks>
    public abstract string ResourceNamespace { get; }

    /// <summary>
    /// Gets the namespace where tag definition XML files are defined.
    /// </summary>
    /// <remarks>
    /// This should expose a static field.
    /// </remarks>
    public abstract string TagXmlNamespace { get; }

    /// <summary>
    /// Gets the default name of the globals tag (or null, if it does not exist for this game).
    /// </summary>
    public abstract string GlobalsTagName { get; }

    /// <summary>
    /// The four byte code that will be used in the header of the game's tag files.
    /// Ex: 'H1PC' would represent 'Halo 1 for the PC'
    /// </summary>
    /// <remarks>
    /// This should expose a static field.
    /// </remarks>
    public abstract byte[] TagIdentifier { get; }

    /// <summary>
    /// Returns a reference to the global tag library that contains all of the
    /// game's stock tags.
    /// </summary>
    public abstract ILibrary GlobalTagLibrary { get; }

    /// <summary>
    /// Returns a reference to the object that will be used to define a script engine.
    /// </summary>
    public abstract ScriptEngineDefinition ScriptEngineDefinition { get; }

  	/// <summary>
  	/// Returns a reference to the script processor (de/compiler) for this game.
  	/// </summary>
		public abstract IScriptProcessor ScriptProcessor { get; }
    
    /// <summary>
    /// Returns a reference to an object that can wrap around this game's cache file.
    /// </summary>
    public abstract IMapFile CreateMapFileObject();

    /// <summary>
    /// Returns a reference to a table containing all tag types for this game.
    /// </summary>
    /// <remarks>
    /// This should expose a static field.
    /// </remarks>
    public abstract TypeTable TypeTable { get; }

    /// <summary>
    /// A table containing a list of all field controls and their corresponding string identifier.
    /// </summary>
    public Dictionary<string, Type> FieldControlTable
    {
      get { return fieldControlTable; }
    }
    
    /// <summary>
    /// Gets a ProjectTemplate object describing the tags that this game platform requires to run.
    /// </summary>
    public abstract ProjectTemplate[] ProjectTemplates { get; }
    
    /// <summary>
    /// Returns true or false to indicate if the specified tag belongs to this game and is valid.
    /// </summary>
    /// <remarks>
    /// This should expose a static method.
    /// </remarks>
    public virtual bool TagIsValid(Tag tag)
    {
      if (tag == null)
        return false;

      if (tag.GameID == GameID)
        return true;
      else
        return false;
    }

    /// <summary>
    /// Returns true or false to indicate if the specified map belongs to this game and is valid.
    /// </summary>
    /// <remarks>
    /// This should expose a static method.
    /// </remarks>
    public abstract bool MapIsValid(Stream map);

    /// <summary>
    /// Returns a list of the map files that are included with this game.
    /// </summary>
    public abstract MapFileDefinition[] Maps { get; }

    /// <summary>
    /// Returns the file path of the global tag library, creating it if it does not already exist.
    /// </summary>
    protected string GetGlobalTagLibraryPath()
    {
      string path = Application.StartupPath + '\\' + HomePath;
      if (!Directory.Exists(path))
        Directory.CreateDirectory(path);
      path += "\\" + GameID + ".pta";

      if (!File.Exists(path))
      {
        // Extract the default PTA from the assembly.
        string ptaPath = ResourceNamespace + '.' + GameID + ".pta";
        Stream ptaFile = assembly.GetManifestResourceStream(ptaPath);
        if (ptaFile == null)
          throw new ResourceNotFoundException(ptaPath);
        else
        {
          byte[] bin = new byte[ptaFile.Length];
          ptaFile.Read(bin, 0, (int)ptaFile.Length);
          ptaFile.Close();
          FileStream fs = new FileStream(path, FileMode.Create);
          fs.Write(bin, 0, bin.Length);
          fs.Close();
        }
      }
      return path;
    }

    /// <summary>
    /// Returns a bitmask indicating which standard maps exist and are valid.
    /// </summary>
    public ulong GetAvailableMapsBitmask()
    {
      // Searched through all maps in the MapFileList, and determines which ones exist and are valid.
      ulong bitmask = 0x0;

      int mapNumber = 0;
      foreach (MapFileDefinition map in Maps)
      {
        if (File.Exists(MapFilePath + "\\" + map.Filename))
        {
          // TODO: Verify that the map belongs to this game (via MapIsValid). 
          // TODO: Verify that the checksum and filesize match.
          bitmask |= ((ulong)1 << mapNumber);
        }
        mapNumber++;
      }
      return bitmask;
    }

    public XmlDocument GetTagDefinitionDocument(string tagType)
    {
      // TODO: Look into a base GameDefinition class.
      string resourceName = TypeTable.LocateEntryByFourCC(tagType).FullName;
      StreamReader reader = new StreamReader(
        assembly.GetManifestResourceStream(TagXmlNamespace + '.' + resourceName + ".xml"));
      XmlDocument doc = new XmlDocument();
      doc.LoadXml(reader.ReadToEnd());
      return doc;
    }

    protected void OpenGlobalTagLibrary()
    {
      // Make sure that the library isn't already open.
      // TODO: Need to add the "Status" property to ILibrary.
      //if (globalTagLibrary != null)
      //  if (globalTagLibrary.Status == ArchiveStatus.Open)
      //    return;

      try
      {
        string archivePath = GetGlobalTagLibraryPath();
        if (String.IsNullOrEmpty(archivePath))
          Output.Write(OutputTypes.Warning, "Could not open Global Tag Archive for " + GameID);
        else
        {
          try
          {
            globalTagLibrary = new TagArchive(GetGlobalTagLibraryPath(), Archive.ArchiveMode.Open);
          }
          catch (EndOfStreamException)
          {
            Output.Write(OutputTypes.Error, "Unable to load tag library \"" + GetGlobalTagLibraryPath() + "\".");
          }
        }

      }
      catch (ResourceNotFoundException ex)
      {
        Output.Write(OutputTypes.Error, "Failed to open PTA for {0}: {1}", Name, ex.Message);
      }
    }

    public override string ToString()
    {
      return Name;
    }

    /// <summary>
    /// Returns the ProjectTemplate with the specified name.
    /// Returns null if the template is not found.
    /// </summary>
    public ProjectTemplate GetProjectTemplate(string name)
    {
      foreach (ProjectTemplate template in ProjectTemplates)
        if (template.Name == name)
          return template;
      return null;
    }

    /// <summary>
    /// Gets a SceneType that represents the scene that would be created if tag was rendered.
    /// </summary>
    /// <param name="tag">tag to get the scene type of</param>
    /// <returns>a SceneType enum representing the scene type of tag</returns>
    public virtual SceneType GetSceneType(Tag tag)
    {
      return SceneType.Other;
    }
  }

  /// <summary>
  /// Represents an exception in which a resource could not be located in the assembly.
  /// </summary>
  public class ResourceNotFoundException : Exception
  {
    private string resourcePath;

    /// <summary>
    /// The path of the resource that could not be found in the assembly.
    /// </summary>
    public string ResourcePath
    {
      get { return resourcePath; }
    }

    public ResourceNotFoundException(string resourcePath)
      : base("Could not locate resource '" + resourcePath + "'")
    {
      this.resourcePath = resourcePath;
    }
  }

  public enum Platform
  {
    PC,
    Xbox
  }
}