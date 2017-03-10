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

namespace Games.Halo.Platforms.Xbox
{
  public partial class HaloXboxGameDefinition : GameDefinition, IPersistable
  {
    private static string mapFilePath = null;
    private static TypeTable typeTable = new HaloTypeTable();

    public HaloXboxGameDefinition()
      : base(Assembly.GetExecutingAssembly())
    { fieldControlTable = HaloFieldControlTable.Instance; }

    public override string Name
    {
      get { return "Halo"; }
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
      { return Encoding.ASCII.GetBytes("H1XB"); }
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
      return new HaloXboxMapFile();
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

      if (type == typeof(model))
        return SceneType.Model;

      if (type == typeof(scenario_structure_bsp))
        return SceneType.SBSP;

      if (type == typeof(bitmap))
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

      if (type == typeof(effect))
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
          new TemplateTag("bitmap", "Default White", @"ui\shell\bitmaps\default white"),
          new TemplateTag("unicode_string_list", "Multiplayer Game Text", "ui\\multiplayer_game_text"),
          new TemplateTag("ui_widget_collection", "User Interface", @"ui\shell\multiplayer"))
        };
      }
    }

    /// <summary>
    /// The game's platform.
    /// </summary>
    public override Platform Platform
    {
      get { return Platform.Xbox; }
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
      if (BitConverter.ToInt32(header, 4) != 0x5)
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
}
