using System;
using System.IO;
using System.Reflection;
using System.Text;
using Games.Halo.Platforms.PC;
using Games.Halo.Tags;
using Games.Halo.Tags.Fields;
using Interfaces.Games;
using Interfaces.Pool;
using Interfaces.Project;
using Interfaces.Settings;
using Interfaces.Rendering;
using Games.Halo.Tags.Classes;

namespace Games.Halo.Platforms.CE
{
  public partial class HaloCEGameDefinition : GameDefinition, IPersistable
  {
    private static string mapFilePath = null;
    private static TypeTable typeTable = new HaloTypeTable();

    public HaloCEGameDefinition()
      : base(Assembly.GetExecutingAssembly())
    { fieldControlTable = HaloFieldControlTable.Instance; }

    public override string Name
    {
      get { return "Halo CE"; }
    }

		/// <summary>
		/// Returns a string containing the path in which the game's mapfiles are located.
		/// This is a user-definable option.
		/// </summary>
		[PersistableOption("MapsFolder", "Paths", "", OptionsFile.System)]
		public string MapsFolder
		{
			get { return mapFilePath; }
			set { mapFilePath = value; }
		}

		public override string MapFilePath
		{
			get { return MapsFolder; }
		}
    public static string FieldTypeNamespaceStatic
    {
      get
      {
        // why do this, one may ask? to be obfuscation safe, of course
        // Games.Halo.Tags.Fields.Block is just an arbitrary type; any type in that namespace can be used
        return typeof(Block).Namespace;
      }
    }

    public override string FieldTypeNamespace
    {
      get
      { return FieldTypeNamespaceStatic; }
    }

    public override string GlobalsTagName
    {
      get
      { return "globals\\globals.globals"; }
    }

    public static byte[] TagIdentifierStatic
    {
      get
      { return Encoding.ASCII.GetBytes("H1CE"); }
    }

    public override byte[] TagIdentifier
    {
      get { return TagIdentifierStatic; }
    }

    public override ILibrary GlobalTagLibrary
    {
      get
      {
        if (globalTagLibrary == null)
          OpenGlobalTagLibrary();
        return globalTagLibrary;
      }
    }

    public override IMapFile CreateMapFileObject()
    {
      return new HaloCEMapFile();
    }

    public TypeTable TypeTableStatic
    {
      get { return typeTable; }
    }

    public override TypeTable TypeTable
    {
      get { return TypeTableStatic; }
    }

    public override string ResourceNamespace
    {
      get
      { return "Games.Halo.Resources"; }
    }

    public override string TagXmlNamespace
    {
      get
      { return "Games.Halo.Tags.Xml"; }
    }

    public override SceneType GetSceneType(Tag tag)
    {
      Type type = tag.GetType();

      if (type == typeof(scenario))
        return SceneType.Scenario;

      if (type == typeof(scenery) ||
          type == typeof(biped) ||
          type == typeof(vehicle) ||
          type == typeof(weapon) ||
          type == typeof(equipment) ||
          type == typeof(projectile) ||
          type == typeof(item_collection))
        return SceneType.Object;

      if (type == typeof(model) ||
          type == typeof(gbxmodel))
        return SceneType.Model;

      if(type == typeof(scenario_structure_bsp))
        return SceneType.SBSP;

      if(type == typeof(bitmap))
        return SceneType.Bitmap;

      if (type == typeof(shader) ||
          type == typeof(shader_environment) ||
          type == typeof(shader_model) ||
          type == typeof(shader_transparent_chicago) ||
          type == typeof(shader_transparent_chicago_extended) ||
          type == typeof(shader_transparent_generic) ||
          type == typeof(shader_transparent_glass) ||
          type == typeof(shader_transparent_meter) ||
          type == typeof(shader_transparent_plasma) ||
          type == typeof(shader_transparent_water))
        return SceneType.Shader;

      if(type == typeof(effect))
        return SceneType.Effect;

      return SceneType.Other;
    }

    public override ProjectTemplate[] ProjectTemplates
    {
      get
      {
        return new ProjectTemplate[] {
          new ProjectTemplate("MP",
          new TemplateTag("scenario", "Scenario"),
          new TemplateTag("globals", "Globals", "globals\\globals"),
          new TemplateTag("tag_collection", "Basic Interface", @"ui\ui_tags_loaded_all_scenario_types"),
          new TemplateTag("bitmap", "Loading Background", @"ui\shell\bitmaps\background"),
          new TemplateTag("unicode_string_list", "Loading Text", @"ui\shell\strings\loading"),
          new TemplateTag("unicode_string_list", "Multiplayer Map List", @"ui\shell\main_menu\mp_map_list"),
          new TemplateTag("bitmap", "Lag Icon", @"ui\bitmaps\trouble_brewing"),
          new TemplateTag("sound", "Cursor UI Sound", @"sound\sfx\ui\cursor"),
          new TemplateTag("sound", "Forward UI Sound", @"sound\sfx\ui\forward"),
          new TemplateTag("sound", "Backward UI Sound", @"sound\sfx\ui\back"),
          new TemplateTag("tag_collection", "Multiplayer Interface", @"ui\ui_tags_loaded_multiplayer_scenario_type"))
        };
      }
    }

    /// <summary>
    /// The game's platform.
    /// </summary>
    public override Platform Platform
    {
      get { return Interfaces.Games.Platform.PC; }
    }

    public override bool MapIsValid(Stream map)
    {
      byte[] header = new byte[2048];
      long pos = map.Position;
      map.Position = 0;
      map.Read(header, 0, 2048);
      map.Position = pos;

      if (BitConverter.ToInt32(header, 0) != 0x68656164)
        return false;
      if (BitConverter.ToInt32(header, 4) != 0x609)
        return false;
      if (BitConverter.ToInt32(header, 2044) != 0x666f6f74)
        return false;

      return true;
    }

		#region IPersistable Members

		public string InstanceName
		{
			get { return GameID; }
		}

		public void Load()
		{
			SettingsManager.Instance.LoadInstance(this);
		}

		public void Save()
		{
			SettingsManager.Instance.SaveInstance(this);
		}

		#endregion
  }
  /*public partial class HaloCEGameDefinition : GameDefinition
  {
    private TypeTable typeTable = new HaloTypeTable();
    
    // todo: finish this project template list
    private ProjectTemplate[] projectTemplates = new ProjectTemplate[] {
          new ProjectTemplate("Halo CE Multiplayer",
          new TemplateTag("scenario", "Scenario"),
          new TemplateTag("globals", "Globals", "globals\\globals"),
          new TemplateTag("tag_collection", "All Scenario Types", @"ui\ui_tags_loaded_all_scenario_types"),
          new TemplateTag("bitmap", "Background", @"ui\shell\bitmaps\background"),
          new TemplateTag("unicode_string_list", "Loading", @"ui\shell\strings\loading"),
          new TemplateTag("unicode_string_list", "MP Map List", @"ui\shell\main_menu\mp_map_list"),
          new TemplateTag("bitmap", "Disconnect Icon", @"ui\bitmaps\trouble_brewing"),
          new TemplateTag("sound", "Cursor", @"sound\sfx\ui\cursor"),
          new TemplateTag("sound", "Forward", @"sound\sfx\ui\forward"),
          new TemplateTag("sound", "Back", @"sound\sfx\ui\back"),
          new TemplateTag("tag_collection", "Multiplayer Scenario Types", @"ui\ui_tags_loaded_multiplayer_scenario_type"))
        };

    private Dictionary<string, Type> fieldControlTable = new Dictionary<string, Type>();

    public string Name
    {
      get { return "Halo CE"; }
    }

    /// <summary>
    /// Returns a string containing the path in which the game's mapfiles are located.
    /// This is a user-definable option.
    /// </summary>
    public string MapFilePath
    {
      get { throw new NotImplementedException(); }
    }

    public string HomePath
    {
      get { return "PC\\Halo"; }
    }

    public string GameID
    {
      get { return "halo1ce"; }
    }

    public string FieldTypeNamespace
    {
      get
      {
        // why do this, one may ask? to be obfuscation safe, of course
        // Games.Halo.Tags.Fields.Block is just an arbitrary type; any type in that namespace can be used
        return typeof(Tags.Fields.Block).Namespace;
      }
    }

    public string GlobalsTagName
    {
      get
      { return "globals\\globals.globals"; }
    }

    public byte[] TagIdentifier
    {
      get { return TagID; }
    }

    public static byte[] TagID
    {
      get { return new byte[] { Convert.ToByte('H'), Convert.ToByte('1'), Convert.ToByte('C'), Convert.ToByte('E') }; }
    }

    public ILibrary GlobalTagLibrary
    {
      // todo: need to implement this - Go MonoxideC!
      get { return null; }
    }

    public IScriptCompiler ScriptCompiler
    {
      // todo: need to implement this
      get { return null; }
    }

    public IScriptDecompiler ScriptDecompiler
    {
      // todo: need to implement this
      get { return null; }
    }

    public IMapCompiler MapCompiler
    {
      // todo: need to implement this
      get { return null; }
    }

    public IMapFile MapFile
    {
      get { return new Maps.HaloCEMapFile(); }
    }

    public TypeTable TypeTable
    {
      get { return typeTable; }
    }

    /// <summary>
    /// A table containing a list of all field controls and their corresponding string identifier.
    /// </summary>
    public Dictionary<string, Type> FieldControlTable
    {
      get { return fieldControlTable; }
    }

    public ProjectTemplate[] ProjectTemplates
    {
      get { return projectTemplates; }
    }

    /// <summary>
    /// Returns a bitmask indicating which standard maps exist and are valid.
    /// </summary>
    public ulong GetAvailableMapsBitmask()
    {
      return 0x0;
    }

    public XmlDocument GetTagDefinitionDocument(string tagType)
    {
      throw new NotImplementedException();
    }

    public bool TagIsValid(Tag tag)
    {
      if (tag == null)
        return false;

      if (tag.GameID == GameID)
        return true;
      else
        return false;
    }

    public bool MapIsValid(Stream map)
    {
      byte[] header = new byte[2048];
      long pos = map.Position;
      map.Position = 0;
      map.Read(header, 0, 2048);
      map.Position = pos;

      if (BitConverter.ToInt32(header, 0) != 0x68656164)
        return false;
      if (BitConverter.ToInt32(header, 4) != 0x261)
        return false;
      if (BitConverter.ToInt32(header, 2044) != 0x666f6f74)
        return false;

      return true;
    }

    /// <summary>
    /// Returns a list of the map files that are included with this game.
    /// </summary>
    public MapFileDefinition[] Maps
    {
      get { throw new NotImplementedException(); }
    }
  }*/
}
