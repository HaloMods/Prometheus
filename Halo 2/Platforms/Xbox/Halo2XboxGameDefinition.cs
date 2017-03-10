using System;
using System.IO;
using System.Reflection;
using System.Text;
using Interfaces.Games;
using Interfaces.Pool;
using Interfaces.Project;
using Interfaces.Settings;
using Games.Halo2.Tags;

namespace Games.Halo2.Platforms.Xbox
{
  public partial class Halo2XboxGameDefinition : GameDefinition, IPersistable
  {
    private static string mapFilePath = null;
    private static TypeTable typeTable = new Halo2TypeTable();

    public Halo2XboxGameDefinition()
      : base(Assembly.GetExecutingAssembly())
    { fieldControlTable = null; }

    public override string Name
    {
      get { return "Halo 2"; }
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
      { return typeof(Games.Halo2.Tags.Fields.Block).Namespace; }
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
      { return Encoding.ASCII.GetBytes("H2XB"); }
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

    //private void OpenGlobalTagLibrary()
    //{
    //  // Make sure that the library isn't already open.
    //  // TODO: Need to add the "Status" property to ILibrary.
    //  //if (globalTagLibrary != null)
    //  //  if (globalTagLibrary.Status == ArchiveStatus.Open)
    //  //    return;

    //  //globalTagLibrary = new TagArchive(GetGlobalTagLibraryPath(), Archive.ArchiveMode.Open);
    //}

    public override IMapFile CreateMapFileObject()
    {
      return new Halo2XboxMap();
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
      { return "Games.Halo2.Resources"; }
    }

    public override string TagXmlNamespace
    {
      get
      { return "Games.Halo2.Tags.Xml"; }
    }

    public override ProjectTemplate[] ProjectTemplates
    {
      get
      {
        return new ProjectTemplate[] {

        };
      }
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
      if (BitConverter.ToInt32(header, 4) != 0x8)
        return false;
      if (BitConverter.ToInt32(header, 2044) != 0x666f6f74)
        return false;

      return true;
    }

    /// <summary>
    /// The game's platform.
    /// </summary>
    public override Platform Platform
    {
      get { return Platform.Xbox; }
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
