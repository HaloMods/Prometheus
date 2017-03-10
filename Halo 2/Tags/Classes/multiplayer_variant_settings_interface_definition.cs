// ----------------------------------------------------------------------
// Prometheus Tag Library - Halo2
// Tag definition for 'multiplayer_variant_settings_interface_definition'
// Generated on 1/1/2008 at 7:09 PM by The Swamp Fox
// ----------------------------------------------------------------------
namespace Games.Halo2.Tags.Classes {
  using System.IO;
  using System.Diagnostics;
  using System.Collections.Generic;
  using Interfaces;
  using Interfaces.Factory;
  using Games.Halo2.Tags.Fields;
  
  public partial class multiplayer_variant_settings_interface_definition : Interfaces.Pool.Tag {
    private CreateNewVariantStructBlockBlock multiplayerVariantSettingsInterfaceDefinitionValues = new CreateNewVariantStructBlockBlock();
    public virtual CreateNewVariantStructBlockBlock MultiplayerVariantSettingsInterfaceDefinitionValues {
      get {
        return multiplayerVariantSettingsInterfaceDefinitionValues;
      }
    }
    public override string[] TagReferenceList {
      get {
UniqueStringCollection references = new UniqueStringCollection();
references.AddRange(MultiplayerVariantSettingsInterfaceDefinitionValues.TagReferenceList);
return references.ToArray();
      }
    }
    public override string FileExtension {
      get {
return "multiplayer_variant_settings_interface_definition";
      }
    }
    #region Read/Write Methods
    public override int Load(byte[] metadata) {
      System.IO.BinaryReader reader = new System.IO.BinaryReader(new System.IO.MemoryStream(metadata));
Read(reader);
int position = (int)reader.BaseStream.Position;
ReadChildData(reader);
reader.Close();
      return position;
    }
    public override void Read(BinaryReader reader) {
multiplayerVariantSettingsInterfaceDefinitionValues.Read(reader);
    }
    public override void ReadChildData(BinaryReader reader) {
multiplayerVariantSettingsInterfaceDefinitionValues.ReadChildData(reader);
    }
    public override byte[] Save() {
BinaryWriter writer = new BinaryWriter(new MemoryStream());
Write(writer);
WriteChildData(writer);
return (writer.BaseStream as MemoryStream).ToArray();
    }
    public override void Write(BinaryWriter writer) {
multiplayerVariantSettingsInterfaceDefinitionValues.Write(writer);
    }
    public override void WriteChildData(BinaryWriter writer) {
multiplayerVariantSettingsInterfaceDefinitionValues.WriteChildData(writer);
    }
    #endregion
    public class CreateNewVariantStructBlockBlock : IBlock {
      private TagReference _unnamed0 = new TagReference();
      private TagReference _unnamed1 = new TagReference();
      private TagReference _unnamed2 = new TagReference();
      private Block _gameEngineSettings = new Block();
      private TagReference _defaultVariantStrings = new TagReference();
      private Block _defaultVariants = new Block();
      private StringId _unnamed3 = new StringId();
      private Enum _unnamed4;
      private Block _settings = new Block();
      private CharInteger _unnamed5 = new CharInteger();
      private Pad _unnamed6;
      private StringId _unnamed7 = new StringId();
      private Enum _unnamed8;
      private Block _settings2 = new Block();
      private CharInteger _unnamed9 = new CharInteger();
      private Pad _unnamed10;
      private StringId _unnamed11 = new StringId();
      private Enum _unnamed12;
      private Block _settings3 = new Block();
      private CharInteger _unnamed13 = new CharInteger();
      private Pad _unnamed14;
      private StringId _unnamed15 = new StringId();
      private Enum _unnamed16;
      private Block _settings4 = new Block();
      private CharInteger _unnamed17 = new CharInteger();
      private Pad _unnamed18;
      private StringId _unnamed19 = new StringId();
      private Enum _unnamed20;
      private Block _settings5 = new Block();
      private CharInteger _unnamed21 = new CharInteger();
      private Pad _unnamed22;
      private StringId _unnamed23 = new StringId();
      private Enum _unnamed24;
      private Block _settings6 = new Block();
      private CharInteger _unnamed25 = new CharInteger();
      private Pad _unnamed26;
      private StringId _unnamed27 = new StringId();
      private Enum _unnamed28;
      private Block _settings7 = new Block();
      private CharInteger _unnamed29 = new CharInteger();
      private Pad _unnamed30;
      private StringId _unnamed31 = new StringId();
      private Enum _unnamed32;
      private Block _settings8 = new Block();
      private CharInteger _unnamed33 = new CharInteger();
      private Pad _unnamed34;
      private StringId _unnamed35 = new StringId();
      private Enum _unnamed36;
      private Block _settings9 = new Block();
      private CharInteger _unnamed37 = new CharInteger();
      private Pad _unnamed38;
      private StringId _unnamed39 = new StringId();
      private Enum _unnamed40;
      private Block _settings10 = new Block();
      private CharInteger _unnamed41 = new CharInteger();
      private Pad _unnamed42;
      private StringId _unnamed43 = new StringId();
      private Enum _unnamed44;
      private Block _settings11 = new Block();
      private CharInteger _unnamed45 = new CharInteger();
      private Pad _unnamed46;
      private StringId _unnamed47 = new StringId();
      private Enum _unnamed48;
      private Block _settings12 = new Block();
      private CharInteger _unnamed49 = new CharInteger();
      private Pad _unnamed50;
      private StringId _unnamed51 = new StringId();
      private Enum _unnamed52;
      private Block _settings13 = new Block();
      private CharInteger _unnamed53 = new CharInteger();
      private Pad _unnamed54;
      private StringId _unnamed55 = new StringId();
      private Enum _unnamed56;
      private Block _settings14 = new Block();
      private CharInteger _unnamed57 = new CharInteger();
      private Pad _unnamed58;
      private StringId _unnamed59 = new StringId();
      private Enum _unnamed60;
      private Block _settings15 = new Block();
      private CharInteger _unnamed61 = new CharInteger();
      private Pad _unnamed62;
      private StringId _unnamed63 = new StringId();
      private Enum _unnamed64;
      private Block _settings16 = new Block();
      private CharInteger _unnamed65 = new CharInteger();
      private Pad _unnamed66;
      public BlockCollection<VariantSettingEditReferenceBlockBlock> _gameEngineSettingsList = new BlockCollection<VariantSettingEditReferenceBlockBlock>();
      public BlockCollection<GDefaultVariantsBlockBlock> _defaultVariantsList = new BlockCollection<GDefaultVariantsBlockBlock>();
      public BlockCollection<GDefaultVariantSettingsBlockBlock> _settingsList = new BlockCollection<GDefaultVariantSettingsBlockBlock>();
      public BlockCollection<GDefaultVariantSettingsBlockBlock> _settings2List = new BlockCollection<GDefaultVariantSettingsBlockBlock>();
      public BlockCollection<GDefaultVariantSettingsBlockBlock> _settings3List = new BlockCollection<GDefaultVariantSettingsBlockBlock>();
      public BlockCollection<GDefaultVariantSettingsBlockBlock> _settings4List = new BlockCollection<GDefaultVariantSettingsBlockBlock>();
      public BlockCollection<GDefaultVariantSettingsBlockBlock> _settings5List = new BlockCollection<GDefaultVariantSettingsBlockBlock>();
      public BlockCollection<GDefaultVariantSettingsBlockBlock> _settings6List = new BlockCollection<GDefaultVariantSettingsBlockBlock>();
      public BlockCollection<GDefaultVariantSettingsBlockBlock> _settings7List = new BlockCollection<GDefaultVariantSettingsBlockBlock>();
      public BlockCollection<GDefaultVariantSettingsBlockBlock> _settings8List = new BlockCollection<GDefaultVariantSettingsBlockBlock>();
      public BlockCollection<GDefaultVariantSettingsBlockBlock> _settings9List = new BlockCollection<GDefaultVariantSettingsBlockBlock>();
      public BlockCollection<GDefaultVariantSettingsBlockBlock> _settings10List = new BlockCollection<GDefaultVariantSettingsBlockBlock>();
      public BlockCollection<GDefaultVariantSettingsBlockBlock> _settings11List = new BlockCollection<GDefaultVariantSettingsBlockBlock>();
      public BlockCollection<GDefaultVariantSettingsBlockBlock> _settings12List = new BlockCollection<GDefaultVariantSettingsBlockBlock>();
      public BlockCollection<GDefaultVariantSettingsBlockBlock> _settings13List = new BlockCollection<GDefaultVariantSettingsBlockBlock>();
      public BlockCollection<GDefaultVariantSettingsBlockBlock> _settings14List = new BlockCollection<GDefaultVariantSettingsBlockBlock>();
      public BlockCollection<GDefaultVariantSettingsBlockBlock> _settings15List = new BlockCollection<GDefaultVariantSettingsBlockBlock>();
      public BlockCollection<GDefaultVariantSettingsBlockBlock> _settings16List = new BlockCollection<GDefaultVariantSettingsBlockBlock>();
public event System.EventHandler BlockNameChanged;
      public CreateNewVariantStructBlockBlock() {
        this._unnamed4 = new Enum(4);
        this._unnamed6 = new Pad(3);
        this._unnamed8 = new Enum(4);
        this._unnamed10 = new Pad(3);
        this._unnamed12 = new Enum(4);
        this._unnamed14 = new Pad(3);
        this._unnamed16 = new Enum(4);
        this._unnamed18 = new Pad(3);
        this._unnamed20 = new Enum(4);
        this._unnamed22 = new Pad(3);
        this._unnamed24 = new Enum(4);
        this._unnamed26 = new Pad(3);
        this._unnamed28 = new Enum(4);
        this._unnamed30 = new Pad(3);
        this._unnamed32 = new Enum(4);
        this._unnamed34 = new Pad(3);
        this._unnamed36 = new Enum(4);
        this._unnamed38 = new Pad(3);
        this._unnamed40 = new Enum(4);
        this._unnamed42 = new Pad(3);
        this._unnamed44 = new Enum(4);
        this._unnamed46 = new Pad(3);
        this._unnamed48 = new Enum(4);
        this._unnamed50 = new Pad(3);
        this._unnamed52 = new Enum(4);
        this._unnamed54 = new Pad(3);
        this._unnamed56 = new Enum(4);
        this._unnamed58 = new Pad(3);
        this._unnamed60 = new Enum(4);
        this._unnamed62 = new Pad(3);
        this._unnamed64 = new Enum(4);
        this._unnamed66 = new Pad(3);
      }
      public BlockCollection<VariantSettingEditReferenceBlockBlock> GameEngineSettings {
        get {
          return this._gameEngineSettingsList;
        }
      }
      public BlockCollection<GDefaultVariantsBlockBlock> DefaultVariants {
        get {
          return this._defaultVariantsList;
        }
      }
      public BlockCollection<GDefaultVariantSettingsBlockBlock> Settings {
        get {
          return this._settingsList;
        }
      }
      public BlockCollection<GDefaultVariantSettingsBlockBlock> Settings2 {
        get {
          return this._settings2List;
        }
      }
      public BlockCollection<GDefaultVariantSettingsBlockBlock> Settings3 {
        get {
          return this._settings3List;
        }
      }
      public BlockCollection<GDefaultVariantSettingsBlockBlock> Settings4 {
        get {
          return this._settings4List;
        }
      }
      public BlockCollection<GDefaultVariantSettingsBlockBlock> Settings5 {
        get {
          return this._settings5List;
        }
      }
      public BlockCollection<GDefaultVariantSettingsBlockBlock> Settings6 {
        get {
          return this._settings6List;
        }
      }
      public BlockCollection<GDefaultVariantSettingsBlockBlock> Settings7 {
        get {
          return this._settings7List;
        }
      }
      public BlockCollection<GDefaultVariantSettingsBlockBlock> Settings8 {
        get {
          return this._settings8List;
        }
      }
      public BlockCollection<GDefaultVariantSettingsBlockBlock> Settings9 {
        get {
          return this._settings9List;
        }
      }
      public BlockCollection<GDefaultVariantSettingsBlockBlock> Settings10 {
        get {
          return this._settings10List;
        }
      }
      public BlockCollection<GDefaultVariantSettingsBlockBlock> Settings11 {
        get {
          return this._settings11List;
        }
      }
      public BlockCollection<GDefaultVariantSettingsBlockBlock> Settings12 {
        get {
          return this._settings12List;
        }
      }
      public BlockCollection<GDefaultVariantSettingsBlockBlock> Settings13 {
        get {
          return this._settings13List;
        }
      }
      public BlockCollection<GDefaultVariantSettingsBlockBlock> Settings14 {
        get {
          return this._settings14List;
        }
      }
      public BlockCollection<GDefaultVariantSettingsBlockBlock> Settings15 {
        get {
          return this._settings15List;
        }
      }
      public BlockCollection<GDefaultVariantSettingsBlockBlock> Settings16 {
        get {
          return this._settings16List;
        }
      }
      public virtual string[] TagReferenceList {
        get {
UniqueStringCollection references = new UniqueStringCollection();
references.Add(_unnamed0.Value);
references.Add(_unnamed1.Value);
references.Add(_unnamed2.Value);
references.Add(_defaultVariantStrings.Value);
for (int x=0; x<GameEngineSettings.BlockCount; x++)
{
  IBlock block = GameEngineSettings.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<DefaultVariants.BlockCount; x++)
{
  IBlock block = DefaultVariants.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<Settings.BlockCount; x++)
{
  IBlock block = Settings.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<Settings2.BlockCount; x++)
{
  IBlock block = Settings2.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<Settings3.BlockCount; x++)
{
  IBlock block = Settings3.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<Settings4.BlockCount; x++)
{
  IBlock block = Settings4.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<Settings5.BlockCount; x++)
{
  IBlock block = Settings5.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<Settings6.BlockCount; x++)
{
  IBlock block = Settings6.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<Settings7.BlockCount; x++)
{
  IBlock block = Settings7.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<Settings8.BlockCount; x++)
{
  IBlock block = Settings8.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<Settings9.BlockCount; x++)
{
  IBlock block = Settings9.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<Settings10.BlockCount; x++)
{
  IBlock block = Settings10.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<Settings11.BlockCount; x++)
{
  IBlock block = Settings11.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<Settings12.BlockCount; x++)
{
  IBlock block = Settings12.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<Settings13.BlockCount; x++)
{
  IBlock block = Settings13.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<Settings14.BlockCount; x++)
{
  IBlock block = Settings14.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<Settings15.BlockCount; x++)
{
  IBlock block = Settings15.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<Settings16.BlockCount; x++)
{
  IBlock block = Settings16.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
return references.ToArray();
        }
      }
      public virtual string BlockName {
        get {
return "";
        }
      }
      public TagReference unnamed0 {
        get {
          return this._unnamed0;
        }
        set {
          this._unnamed0 = value;
        }
      }
      public TagReference unnamed1 {
        get {
          return this._unnamed1;
        }
        set {
          this._unnamed1 = value;
        }
      }
      public TagReference unnamed2 {
        get {
          return this._unnamed2;
        }
        set {
          this._unnamed2 = value;
        }
      }
      public TagReference DefaultVariantStrings {
        get {
          return this._defaultVariantStrings;
        }
        set {
          this._defaultVariantStrings = value;
        }
      }
      public StringId unnamed3 {
        get {
          return this._unnamed3;
        }
        set {
          this._unnamed3 = value;
        }
      }
      public Enum unnamed4 {
        get {
          return this._unnamed4;
        }
        set {
          this._unnamed4 = value;
        }
      }
      public CharInteger unnamed5 {
        get {
          return this._unnamed5;
        }
        set {
          this._unnamed5 = value;
        }
      }
      public StringId unnamed7 {
        get {
          return this._unnamed7;
        }
        set {
          this._unnamed7 = value;
        }
      }
      public Enum unnamed8 {
        get {
          return this._unnamed8;
        }
        set {
          this._unnamed8 = value;
        }
      }
      public CharInteger unnamed9 {
        get {
          return this._unnamed9;
        }
        set {
          this._unnamed9 = value;
        }
      }
      public StringId unnamed11 {
        get {
          return this._unnamed11;
        }
        set {
          this._unnamed11 = value;
        }
      }
      public Enum unnamed12 {
        get {
          return this._unnamed12;
        }
        set {
          this._unnamed12 = value;
        }
      }
      public CharInteger unnamed13 {
        get {
          return this._unnamed13;
        }
        set {
          this._unnamed13 = value;
        }
      }
      public StringId unnamed15 {
        get {
          return this._unnamed15;
        }
        set {
          this._unnamed15 = value;
        }
      }
      public Enum unnamed16 {
        get {
          return this._unnamed16;
        }
        set {
          this._unnamed16 = value;
        }
      }
      public CharInteger unnamed17 {
        get {
          return this._unnamed17;
        }
        set {
          this._unnamed17 = value;
        }
      }
      public StringId unnamed19 {
        get {
          return this._unnamed19;
        }
        set {
          this._unnamed19 = value;
        }
      }
      public Enum unnamed20 {
        get {
          return this._unnamed20;
        }
        set {
          this._unnamed20 = value;
        }
      }
      public CharInteger unnamed21 {
        get {
          return this._unnamed21;
        }
        set {
          this._unnamed21 = value;
        }
      }
      public StringId unnamed23 {
        get {
          return this._unnamed23;
        }
        set {
          this._unnamed23 = value;
        }
      }
      public Enum unnamed24 {
        get {
          return this._unnamed24;
        }
        set {
          this._unnamed24 = value;
        }
      }
      public CharInteger unnamed25 {
        get {
          return this._unnamed25;
        }
        set {
          this._unnamed25 = value;
        }
      }
      public StringId unnamed27 {
        get {
          return this._unnamed27;
        }
        set {
          this._unnamed27 = value;
        }
      }
      public Enum unnamed28 {
        get {
          return this._unnamed28;
        }
        set {
          this._unnamed28 = value;
        }
      }
      public CharInteger unnamed29 {
        get {
          return this._unnamed29;
        }
        set {
          this._unnamed29 = value;
        }
      }
      public StringId unnamed31 {
        get {
          return this._unnamed31;
        }
        set {
          this._unnamed31 = value;
        }
      }
      public Enum unnamed32 {
        get {
          return this._unnamed32;
        }
        set {
          this._unnamed32 = value;
        }
      }
      public CharInteger unnamed33 {
        get {
          return this._unnamed33;
        }
        set {
          this._unnamed33 = value;
        }
      }
      public StringId unnamed35 {
        get {
          return this._unnamed35;
        }
        set {
          this._unnamed35 = value;
        }
      }
      public Enum unnamed36 {
        get {
          return this._unnamed36;
        }
        set {
          this._unnamed36 = value;
        }
      }
      public CharInteger unnamed37 {
        get {
          return this._unnamed37;
        }
        set {
          this._unnamed37 = value;
        }
      }
      public StringId unnamed39 {
        get {
          return this._unnamed39;
        }
        set {
          this._unnamed39 = value;
        }
      }
      public Enum unnamed40 {
        get {
          return this._unnamed40;
        }
        set {
          this._unnamed40 = value;
        }
      }
      public CharInteger unnamed41 {
        get {
          return this._unnamed41;
        }
        set {
          this._unnamed41 = value;
        }
      }
      public StringId unnamed43 {
        get {
          return this._unnamed43;
        }
        set {
          this._unnamed43 = value;
        }
      }
      public Enum unnamed44 {
        get {
          return this._unnamed44;
        }
        set {
          this._unnamed44 = value;
        }
      }
      public CharInteger unnamed45 {
        get {
          return this._unnamed45;
        }
        set {
          this._unnamed45 = value;
        }
      }
      public StringId unnamed47 {
        get {
          return this._unnamed47;
        }
        set {
          this._unnamed47 = value;
        }
      }
      public Enum unnamed48 {
        get {
          return this._unnamed48;
        }
        set {
          this._unnamed48 = value;
        }
      }
      public CharInteger unnamed49 {
        get {
          return this._unnamed49;
        }
        set {
          this._unnamed49 = value;
        }
      }
      public StringId unnamed51 {
        get {
          return this._unnamed51;
        }
        set {
          this._unnamed51 = value;
        }
      }
      public Enum unnamed52 {
        get {
          return this._unnamed52;
        }
        set {
          this._unnamed52 = value;
        }
      }
      public CharInteger unnamed53 {
        get {
          return this._unnamed53;
        }
        set {
          this._unnamed53 = value;
        }
      }
      public StringId unnamed55 {
        get {
          return this._unnamed55;
        }
        set {
          this._unnamed55 = value;
        }
      }
      public Enum unnamed56 {
        get {
          return this._unnamed56;
        }
        set {
          this._unnamed56 = value;
        }
      }
      public CharInteger unnamed57 {
        get {
          return this._unnamed57;
        }
        set {
          this._unnamed57 = value;
        }
      }
      public StringId unnamed59 {
        get {
          return this._unnamed59;
        }
        set {
          this._unnamed59 = value;
        }
      }
      public Enum unnamed60 {
        get {
          return this._unnamed60;
        }
        set {
          this._unnamed60 = value;
        }
      }
      public CharInteger unnamed61 {
        get {
          return this._unnamed61;
        }
        set {
          this._unnamed61 = value;
        }
      }
      public StringId unnamed63 {
        get {
          return this._unnamed63;
        }
        set {
          this._unnamed63 = value;
        }
      }
      public Enum unnamed64 {
        get {
          return this._unnamed64;
        }
        set {
          this._unnamed64 = value;
        }
      }
      public CharInteger unnamed65 {
        get {
          return this._unnamed65;
        }
        set {
          this._unnamed65 = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _unnamed0.Read(reader);
        _unnamed1.Read(reader);
        _unnamed2.Read(reader);
        _gameEngineSettings.Read(reader);
        _defaultVariantStrings.Read(reader);
        _defaultVariants.Read(reader);
        _unnamed3.Read(reader);
        _unnamed4.Read(reader);
        _settings.Read(reader);
        _unnamed5.Read(reader);
        _unnamed6.Read(reader);
        _unnamed7.Read(reader);
        _unnamed8.Read(reader);
        _settings2.Read(reader);
        _unnamed9.Read(reader);
        _unnamed10.Read(reader);
        _unnamed11.Read(reader);
        _unnamed12.Read(reader);
        _settings3.Read(reader);
        _unnamed13.Read(reader);
        _unnamed14.Read(reader);
        _unnamed15.Read(reader);
        _unnamed16.Read(reader);
        _settings4.Read(reader);
        _unnamed17.Read(reader);
        _unnamed18.Read(reader);
        _unnamed19.Read(reader);
        _unnamed20.Read(reader);
        _settings5.Read(reader);
        _unnamed21.Read(reader);
        _unnamed22.Read(reader);
        _unnamed23.Read(reader);
        _unnamed24.Read(reader);
        _settings6.Read(reader);
        _unnamed25.Read(reader);
        _unnamed26.Read(reader);
        _unnamed27.Read(reader);
        _unnamed28.Read(reader);
        _settings7.Read(reader);
        _unnamed29.Read(reader);
        _unnamed30.Read(reader);
        _unnamed31.Read(reader);
        _unnamed32.Read(reader);
        _settings8.Read(reader);
        _unnamed33.Read(reader);
        _unnamed34.Read(reader);
        _unnamed35.Read(reader);
        _unnamed36.Read(reader);
        _settings9.Read(reader);
        _unnamed37.Read(reader);
        _unnamed38.Read(reader);
        _unnamed39.Read(reader);
        _unnamed40.Read(reader);
        _settings10.Read(reader);
        _unnamed41.Read(reader);
        _unnamed42.Read(reader);
        _unnamed43.Read(reader);
        _unnamed44.Read(reader);
        _settings11.Read(reader);
        _unnamed45.Read(reader);
        _unnamed46.Read(reader);
        _unnamed47.Read(reader);
        _unnamed48.Read(reader);
        _settings12.Read(reader);
        _unnamed49.Read(reader);
        _unnamed50.Read(reader);
        _unnamed51.Read(reader);
        _unnamed52.Read(reader);
        _settings13.Read(reader);
        _unnamed53.Read(reader);
        _unnamed54.Read(reader);
        _unnamed55.Read(reader);
        _unnamed56.Read(reader);
        _settings14.Read(reader);
        _unnamed57.Read(reader);
        _unnamed58.Read(reader);
        _unnamed59.Read(reader);
        _unnamed60.Read(reader);
        _settings15.Read(reader);
        _unnamed61.Read(reader);
        _unnamed62.Read(reader);
        _unnamed63.Read(reader);
        _unnamed64.Read(reader);
        _settings16.Read(reader);
        _unnamed65.Read(reader);
        _unnamed66.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        int x = 0;
        _unnamed0.ReadString(reader);
        _unnamed1.ReadString(reader);
        _unnamed2.ReadString(reader);
        for (x = 0; (x < _gameEngineSettings.Count); x = (x + 1)) {
          GameEngineSettings.Add(new VariantSettingEditReferenceBlockBlock());
          GameEngineSettings[x].Read(reader);
        }
        for (x = 0; (x < _gameEngineSettings.Count); x = (x + 1)) {
          GameEngineSettings[x].ReadChildData(reader);
        }
        _defaultVariantStrings.ReadString(reader);
        for (x = 0; (x < _defaultVariants.Count); x = (x + 1)) {
          DefaultVariants.Add(new GDefaultVariantsBlockBlock());
          DefaultVariants[x].Read(reader);
        }
        for (x = 0; (x < _defaultVariants.Count); x = (x + 1)) {
          DefaultVariants[x].ReadChildData(reader);
        }
        _unnamed3.ReadString(reader);
        for (x = 0; (x < _settings.Count); x = (x + 1)) {
          Settings.Add(new GDefaultVariantSettingsBlockBlock());
          Settings[x].Read(reader);
        }
        for (x = 0; (x < _settings.Count); x = (x + 1)) {
          Settings[x].ReadChildData(reader);
        }
        _unnamed7.ReadString(reader);
        for (x = 0; (x < _settings2.Count); x = (x + 1)) {
          Settings2.Add(new GDefaultVariantSettingsBlockBlock());
          Settings2[x].Read(reader);
        }
        for (x = 0; (x < _settings2.Count); x = (x + 1)) {
          Settings2[x].ReadChildData(reader);
        }
        _unnamed11.ReadString(reader);
        for (x = 0; (x < _settings3.Count); x = (x + 1)) {
          Settings3.Add(new GDefaultVariantSettingsBlockBlock());
          Settings3[x].Read(reader);
        }
        for (x = 0; (x < _settings3.Count); x = (x + 1)) {
          Settings3[x].ReadChildData(reader);
        }
        _unnamed15.ReadString(reader);
        for (x = 0; (x < _settings4.Count); x = (x + 1)) {
          Settings4.Add(new GDefaultVariantSettingsBlockBlock());
          Settings4[x].Read(reader);
        }
        for (x = 0; (x < _settings4.Count); x = (x + 1)) {
          Settings4[x].ReadChildData(reader);
        }
        _unnamed19.ReadString(reader);
        for (x = 0; (x < _settings5.Count); x = (x + 1)) {
          Settings5.Add(new GDefaultVariantSettingsBlockBlock());
          Settings5[x].Read(reader);
        }
        for (x = 0; (x < _settings5.Count); x = (x + 1)) {
          Settings5[x].ReadChildData(reader);
        }
        _unnamed23.ReadString(reader);
        for (x = 0; (x < _settings6.Count); x = (x + 1)) {
          Settings6.Add(new GDefaultVariantSettingsBlockBlock());
          Settings6[x].Read(reader);
        }
        for (x = 0; (x < _settings6.Count); x = (x + 1)) {
          Settings6[x].ReadChildData(reader);
        }
        _unnamed27.ReadString(reader);
        for (x = 0; (x < _settings7.Count); x = (x + 1)) {
          Settings7.Add(new GDefaultVariantSettingsBlockBlock());
          Settings7[x].Read(reader);
        }
        for (x = 0; (x < _settings7.Count); x = (x + 1)) {
          Settings7[x].ReadChildData(reader);
        }
        _unnamed31.ReadString(reader);
        for (x = 0; (x < _settings8.Count); x = (x + 1)) {
          Settings8.Add(new GDefaultVariantSettingsBlockBlock());
          Settings8[x].Read(reader);
        }
        for (x = 0; (x < _settings8.Count); x = (x + 1)) {
          Settings8[x].ReadChildData(reader);
        }
        _unnamed35.ReadString(reader);
        for (x = 0; (x < _settings9.Count); x = (x + 1)) {
          Settings9.Add(new GDefaultVariantSettingsBlockBlock());
          Settings9[x].Read(reader);
        }
        for (x = 0; (x < _settings9.Count); x = (x + 1)) {
          Settings9[x].ReadChildData(reader);
        }
        _unnamed39.ReadString(reader);
        for (x = 0; (x < _settings10.Count); x = (x + 1)) {
          Settings10.Add(new GDefaultVariantSettingsBlockBlock());
          Settings10[x].Read(reader);
        }
        for (x = 0; (x < _settings10.Count); x = (x + 1)) {
          Settings10[x].ReadChildData(reader);
        }
        _unnamed43.ReadString(reader);
        for (x = 0; (x < _settings11.Count); x = (x + 1)) {
          Settings11.Add(new GDefaultVariantSettingsBlockBlock());
          Settings11[x].Read(reader);
        }
        for (x = 0; (x < _settings11.Count); x = (x + 1)) {
          Settings11[x].ReadChildData(reader);
        }
        _unnamed47.ReadString(reader);
        for (x = 0; (x < _settings12.Count); x = (x + 1)) {
          Settings12.Add(new GDefaultVariantSettingsBlockBlock());
          Settings12[x].Read(reader);
        }
        for (x = 0; (x < _settings12.Count); x = (x + 1)) {
          Settings12[x].ReadChildData(reader);
        }
        _unnamed51.ReadString(reader);
        for (x = 0; (x < _settings13.Count); x = (x + 1)) {
          Settings13.Add(new GDefaultVariantSettingsBlockBlock());
          Settings13[x].Read(reader);
        }
        for (x = 0; (x < _settings13.Count); x = (x + 1)) {
          Settings13[x].ReadChildData(reader);
        }
        _unnamed55.ReadString(reader);
        for (x = 0; (x < _settings14.Count); x = (x + 1)) {
          Settings14.Add(new GDefaultVariantSettingsBlockBlock());
          Settings14[x].Read(reader);
        }
        for (x = 0; (x < _settings14.Count); x = (x + 1)) {
          Settings14[x].ReadChildData(reader);
        }
        _unnamed59.ReadString(reader);
        for (x = 0; (x < _settings15.Count); x = (x + 1)) {
          Settings15.Add(new GDefaultVariantSettingsBlockBlock());
          Settings15[x].Read(reader);
        }
        for (x = 0; (x < _settings15.Count); x = (x + 1)) {
          Settings15[x].ReadChildData(reader);
        }
        _unnamed63.ReadString(reader);
        for (x = 0; (x < _settings16.Count); x = (x + 1)) {
          Settings16.Add(new GDefaultVariantSettingsBlockBlock());
          Settings16[x].Read(reader);
        }
        for (x = 0; (x < _settings16.Count); x = (x + 1)) {
          Settings16[x].ReadChildData(reader);
        }
      }
      public virtual void Write(BinaryWriter bw) {
        _unnamed0.Write(bw);
        _unnamed1.Write(bw);
        _unnamed2.Write(bw);
_gameEngineSettings.Count = GameEngineSettings.Count;
        _gameEngineSettings.Write(bw);
        _defaultVariantStrings.Write(bw);
_defaultVariants.Count = DefaultVariants.Count;
        _defaultVariants.Write(bw);
        _unnamed3.Write(bw);
        _unnamed4.Write(bw);
_settings.Count = Settings.Count;
        _settings.Write(bw);
        _unnamed5.Write(bw);
        _unnamed6.Write(bw);
        _unnamed7.Write(bw);
        _unnamed8.Write(bw);
_settings2.Count = Settings2.Count;
        _settings2.Write(bw);
        _unnamed9.Write(bw);
        _unnamed10.Write(bw);
        _unnamed11.Write(bw);
        _unnamed12.Write(bw);
_settings3.Count = Settings3.Count;
        _settings3.Write(bw);
        _unnamed13.Write(bw);
        _unnamed14.Write(bw);
        _unnamed15.Write(bw);
        _unnamed16.Write(bw);
_settings4.Count = Settings4.Count;
        _settings4.Write(bw);
        _unnamed17.Write(bw);
        _unnamed18.Write(bw);
        _unnamed19.Write(bw);
        _unnamed20.Write(bw);
_settings5.Count = Settings5.Count;
        _settings5.Write(bw);
        _unnamed21.Write(bw);
        _unnamed22.Write(bw);
        _unnamed23.Write(bw);
        _unnamed24.Write(bw);
_settings6.Count = Settings6.Count;
        _settings6.Write(bw);
        _unnamed25.Write(bw);
        _unnamed26.Write(bw);
        _unnamed27.Write(bw);
        _unnamed28.Write(bw);
_settings7.Count = Settings7.Count;
        _settings7.Write(bw);
        _unnamed29.Write(bw);
        _unnamed30.Write(bw);
        _unnamed31.Write(bw);
        _unnamed32.Write(bw);
_settings8.Count = Settings8.Count;
        _settings8.Write(bw);
        _unnamed33.Write(bw);
        _unnamed34.Write(bw);
        _unnamed35.Write(bw);
        _unnamed36.Write(bw);
_settings9.Count = Settings9.Count;
        _settings9.Write(bw);
        _unnamed37.Write(bw);
        _unnamed38.Write(bw);
        _unnamed39.Write(bw);
        _unnamed40.Write(bw);
_settings10.Count = Settings10.Count;
        _settings10.Write(bw);
        _unnamed41.Write(bw);
        _unnamed42.Write(bw);
        _unnamed43.Write(bw);
        _unnamed44.Write(bw);
_settings11.Count = Settings11.Count;
        _settings11.Write(bw);
        _unnamed45.Write(bw);
        _unnamed46.Write(bw);
        _unnamed47.Write(bw);
        _unnamed48.Write(bw);
_settings12.Count = Settings12.Count;
        _settings12.Write(bw);
        _unnamed49.Write(bw);
        _unnamed50.Write(bw);
        _unnamed51.Write(bw);
        _unnamed52.Write(bw);
_settings13.Count = Settings13.Count;
        _settings13.Write(bw);
        _unnamed53.Write(bw);
        _unnamed54.Write(bw);
        _unnamed55.Write(bw);
        _unnamed56.Write(bw);
_settings14.Count = Settings14.Count;
        _settings14.Write(bw);
        _unnamed57.Write(bw);
        _unnamed58.Write(bw);
        _unnamed59.Write(bw);
        _unnamed60.Write(bw);
_settings15.Count = Settings15.Count;
        _settings15.Write(bw);
        _unnamed61.Write(bw);
        _unnamed62.Write(bw);
        _unnamed63.Write(bw);
        _unnamed64.Write(bw);
_settings16.Count = Settings16.Count;
        _settings16.Write(bw);
        _unnamed65.Write(bw);
        _unnamed66.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
        int x = 0;
        _unnamed0.WriteString(writer);
        _unnamed1.WriteString(writer);
        _unnamed2.WriteString(writer);
        for (x = 0; (x < _gameEngineSettings.Count); x = (x + 1)) {
          GameEngineSettings[x].Write(writer);
        }
        for (x = 0; (x < _gameEngineSettings.Count); x = (x + 1)) {
          GameEngineSettings[x].WriteChildData(writer);
        }
        _defaultVariantStrings.WriteString(writer);
        for (x = 0; (x < _defaultVariants.Count); x = (x + 1)) {
          DefaultVariants[x].Write(writer);
        }
        for (x = 0; (x < _defaultVariants.Count); x = (x + 1)) {
          DefaultVariants[x].WriteChildData(writer);
        }
        _unnamed3.WriteString(writer);
        for (x = 0; (x < _settings.Count); x = (x + 1)) {
          Settings[x].Write(writer);
        }
        for (x = 0; (x < _settings.Count); x = (x + 1)) {
          Settings[x].WriteChildData(writer);
        }
        _unnamed7.WriteString(writer);
        for (x = 0; (x < _settings2.Count); x = (x + 1)) {
          Settings2[x].Write(writer);
        }
        for (x = 0; (x < _settings2.Count); x = (x + 1)) {
          Settings2[x].WriteChildData(writer);
        }
        _unnamed11.WriteString(writer);
        for (x = 0; (x < _settings3.Count); x = (x + 1)) {
          Settings3[x].Write(writer);
        }
        for (x = 0; (x < _settings3.Count); x = (x + 1)) {
          Settings3[x].WriteChildData(writer);
        }
        _unnamed15.WriteString(writer);
        for (x = 0; (x < _settings4.Count); x = (x + 1)) {
          Settings4[x].Write(writer);
        }
        for (x = 0; (x < _settings4.Count); x = (x + 1)) {
          Settings4[x].WriteChildData(writer);
        }
        _unnamed19.WriteString(writer);
        for (x = 0; (x < _settings5.Count); x = (x + 1)) {
          Settings5[x].Write(writer);
        }
        for (x = 0; (x < _settings5.Count); x = (x + 1)) {
          Settings5[x].WriteChildData(writer);
        }
        _unnamed23.WriteString(writer);
        for (x = 0; (x < _settings6.Count); x = (x + 1)) {
          Settings6[x].Write(writer);
        }
        for (x = 0; (x < _settings6.Count); x = (x + 1)) {
          Settings6[x].WriteChildData(writer);
        }
        _unnamed27.WriteString(writer);
        for (x = 0; (x < _settings7.Count); x = (x + 1)) {
          Settings7[x].Write(writer);
        }
        for (x = 0; (x < _settings7.Count); x = (x + 1)) {
          Settings7[x].WriteChildData(writer);
        }
        _unnamed31.WriteString(writer);
        for (x = 0; (x < _settings8.Count); x = (x + 1)) {
          Settings8[x].Write(writer);
        }
        for (x = 0; (x < _settings8.Count); x = (x + 1)) {
          Settings8[x].WriteChildData(writer);
        }
        _unnamed35.WriteString(writer);
        for (x = 0; (x < _settings9.Count); x = (x + 1)) {
          Settings9[x].Write(writer);
        }
        for (x = 0; (x < _settings9.Count); x = (x + 1)) {
          Settings9[x].WriteChildData(writer);
        }
        _unnamed39.WriteString(writer);
        for (x = 0; (x < _settings10.Count); x = (x + 1)) {
          Settings10[x].Write(writer);
        }
        for (x = 0; (x < _settings10.Count); x = (x + 1)) {
          Settings10[x].WriteChildData(writer);
        }
        _unnamed43.WriteString(writer);
        for (x = 0; (x < _settings11.Count); x = (x + 1)) {
          Settings11[x].Write(writer);
        }
        for (x = 0; (x < _settings11.Count); x = (x + 1)) {
          Settings11[x].WriteChildData(writer);
        }
        _unnamed47.WriteString(writer);
        for (x = 0; (x < _settings12.Count); x = (x + 1)) {
          Settings12[x].Write(writer);
        }
        for (x = 0; (x < _settings12.Count); x = (x + 1)) {
          Settings12[x].WriteChildData(writer);
        }
        _unnamed51.WriteString(writer);
        for (x = 0; (x < _settings13.Count); x = (x + 1)) {
          Settings13[x].Write(writer);
        }
        for (x = 0; (x < _settings13.Count); x = (x + 1)) {
          Settings13[x].WriteChildData(writer);
        }
        _unnamed55.WriteString(writer);
        for (x = 0; (x < _settings14.Count); x = (x + 1)) {
          Settings14[x].Write(writer);
        }
        for (x = 0; (x < _settings14.Count); x = (x + 1)) {
          Settings14[x].WriteChildData(writer);
        }
        _unnamed59.WriteString(writer);
        for (x = 0; (x < _settings15.Count); x = (x + 1)) {
          Settings15[x].Write(writer);
        }
        for (x = 0; (x < _settings15.Count); x = (x + 1)) {
          Settings15[x].WriteChildData(writer);
        }
        _unnamed63.WriteString(writer);
        for (x = 0; (x < _settings16.Count); x = (x + 1)) {
          Settings16[x].Write(writer);
        }
        for (x = 0; (x < _settings16.Count); x = (x + 1)) {
          Settings16[x].WriteChildData(writer);
        }
      }
    }
    public class VariantSettingEditReferenceBlockBlock : IBlock {
      private Enum _settingCategory;
      private Pad _unnamed0;
      private Block _options = new Block();
      private Block _unnamed1 = new Block();
      public BlockCollection<TextValuePairBlockBlock> _optionsList = new BlockCollection<TextValuePairBlockBlock>();
      public BlockCollection<NullBlockBlock> _unnamed1List = new BlockCollection<NullBlockBlock>();
public event System.EventHandler BlockNameChanged;
      public VariantSettingEditReferenceBlockBlock() {
if (this._settingCategory is System.ComponentModel.INotifyPropertyChanged)
  (this._settingCategory as System.ComponentModel.INotifyPropertyChanged).PropertyChanged +=
  (System.ComponentModel.PropertyChangedEventHandler)delegate
  { if (BlockNameChanged != null) BlockNameChanged(this, new System.EventArgs()); };
        this._settingCategory = new Enum(4);
        this._unnamed0 = new Pad(4);
      }
      public BlockCollection<TextValuePairBlockBlock> Options {
        get {
          return this._optionsList;
        }
      }
      public BlockCollection<NullBlockBlock> Unnamed1 {
        get {
          return this._unnamed1List;
        }
      }
      public virtual string[] TagReferenceList {
        get {
UniqueStringCollection references = new UniqueStringCollection();
for (int x=0; x<Options.BlockCount; x++)
{
  IBlock block = Options.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<Unnamed1.BlockCount; x++)
{
  IBlock block = Unnamed1.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
return references.ToArray();
        }
      }
      public virtual string BlockName {
        get {
return _settingCategory.ToString();
        }
      }
      public Enum SettingCategory {
        get {
          return this._settingCategory;
        }
        set {
          this._settingCategory = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _settingCategory.Read(reader);
        _unnamed0.Read(reader);
        _options.Read(reader);
        _unnamed1.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        int x = 0;
        for (x = 0; (x < _options.Count); x = (x + 1)) {
          Options.Add(new TextValuePairBlockBlock());
          Options[x].Read(reader);
        }
        for (x = 0; (x < _options.Count); x = (x + 1)) {
          Options[x].ReadChildData(reader);
        }
        for (x = 0; (x < _unnamed1.Count); x = (x + 1)) {
          Unnamed1.Add(new NullBlockBlock());
          Unnamed1[x].Read(reader);
        }
        for (x = 0; (x < _unnamed1.Count); x = (x + 1)) {
          Unnamed1[x].ReadChildData(reader);
        }
      }
      public virtual void Write(BinaryWriter bw) {
        _settingCategory.Write(bw);
        _unnamed0.Write(bw);
_options.Count = Options.Count;
        _options.Write(bw);
_unnamed1.Count = Unnamed1.Count;
        _unnamed1.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
        int x = 0;
        for (x = 0; (x < _options.Count); x = (x + 1)) {
          Options[x].Write(writer);
        }
        for (x = 0; (x < _options.Count); x = (x + 1)) {
          Options[x].WriteChildData(writer);
        }
        for (x = 0; (x < _unnamed1.Count); x = (x + 1)) {
          Unnamed1[x].Write(writer);
        }
        for (x = 0; (x < _unnamed1.Count); x = (x + 1)) {
          Unnamed1[x].WriteChildData(writer);
        }
      }
    }
    public class TextValuePairBlockBlock : IBlock {
      private TagReference _valuePairs = new TagReference();
public event System.EventHandler BlockNameChanged;
      public TextValuePairBlockBlock() {
if (this._valuePairs is System.ComponentModel.INotifyPropertyChanged)
  (this._valuePairs as System.ComponentModel.INotifyPropertyChanged).PropertyChanged +=
  (System.ComponentModel.PropertyChangedEventHandler)delegate
  { if (BlockNameChanged != null) BlockNameChanged(this, new System.EventArgs()); };
      }
      public virtual string[] TagReferenceList {
        get {
UniqueStringCollection references = new UniqueStringCollection();
references.Add(_valuePairs.Value);
return references.ToArray();
        }
      }
      public virtual string BlockName {
        get {
return _valuePairs.ToString();
        }
      }
      public TagReference ValuePairs {
        get {
          return this._valuePairs;
        }
        set {
          this._valuePairs = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _valuePairs.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        _valuePairs.ReadString(reader);
      }
      public virtual void Write(BinaryWriter bw) {
        _valuePairs.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
        _valuePairs.WriteString(writer);
      }
    }
    public class NullBlockBlock : IBlock {
public event System.EventHandler BlockNameChanged;
      public NullBlockBlock() {
      }
      public virtual string[] TagReferenceList {
        get {
UniqueStringCollection references = new UniqueStringCollection();
return references.ToArray();
        }
      }
      public virtual string BlockName {
        get {
return "";
        }
      }
      public virtual void Read(BinaryReader reader) {
      }
      public virtual void ReadChildData(BinaryReader reader) {
      }
      public virtual void Write(BinaryWriter bw) {
      }
      public virtual void WriteChildData(BinaryWriter writer) {
      }
    }
    public class GDefaultVariantsBlockBlock : IBlock {
      private StringId _variantName = new StringId();
      private Enum _variantType;
      private Block _settings = new Block();
      private CharInteger _descriptionIndex = new CharInteger();
      private Pad _unnamed0;
      public BlockCollection<GDefaultVariantSettingsBlockBlock> _settingsList = new BlockCollection<GDefaultVariantSettingsBlockBlock>();
public event System.EventHandler BlockNameChanged;
      public GDefaultVariantsBlockBlock() {
if (this._variantName is System.ComponentModel.INotifyPropertyChanged)
  (this._variantName as System.ComponentModel.INotifyPropertyChanged).PropertyChanged +=
  (System.ComponentModel.PropertyChangedEventHandler)delegate
  { if (BlockNameChanged != null) BlockNameChanged(this, new System.EventArgs()); };
        this._variantType = new Enum(4);
        this._unnamed0 = new Pad(3);
      }
      public BlockCollection<GDefaultVariantSettingsBlockBlock> Settings {
        get {
          return this._settingsList;
        }
      }
      public virtual string[] TagReferenceList {
        get {
UniqueStringCollection references = new UniqueStringCollection();
for (int x=0; x<Settings.BlockCount; x++)
{
  IBlock block = Settings.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
return references.ToArray();
        }
      }
      public virtual string BlockName {
        get {
return _variantName.ToString();
        }
      }
      public StringId VariantName {
        get {
          return this._variantName;
        }
        set {
          this._variantName = value;
        }
      }
      public Enum VariantType {
        get {
          return this._variantType;
        }
        set {
          this._variantType = value;
        }
      }
      public CharInteger DescriptionIndex {
        get {
          return this._descriptionIndex;
        }
        set {
          this._descriptionIndex = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _variantName.Read(reader);
        _variantType.Read(reader);
        _settings.Read(reader);
        _descriptionIndex.Read(reader);
        _unnamed0.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        int x = 0;
        _variantName.ReadString(reader);
        for (x = 0; (x < _settings.Count); x = (x + 1)) {
          Settings.Add(new GDefaultVariantSettingsBlockBlock());
          Settings[x].Read(reader);
        }
        for (x = 0; (x < _settings.Count); x = (x + 1)) {
          Settings[x].ReadChildData(reader);
        }
      }
      public virtual void Write(BinaryWriter bw) {
        _variantName.Write(bw);
        _variantType.Write(bw);
_settings.Count = Settings.Count;
        _settings.Write(bw);
        _descriptionIndex.Write(bw);
        _unnamed0.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
        int x = 0;
        _variantName.WriteString(writer);
        for (x = 0; (x < _settings.Count); x = (x + 1)) {
          Settings[x].Write(writer);
        }
        for (x = 0; (x < _settings.Count); x = (x + 1)) {
          Settings[x].WriteChildData(writer);
        }
      }
    }
    public class GDefaultVariantSettingsBlockBlock : IBlock {
      private Enum _settingCategory;
      private LongInteger _value = new LongInteger();
public event System.EventHandler BlockNameChanged;
      public GDefaultVariantSettingsBlockBlock() {
if (this._settingCategory is System.ComponentModel.INotifyPropertyChanged)
  (this._settingCategory as System.ComponentModel.INotifyPropertyChanged).PropertyChanged +=
  (System.ComponentModel.PropertyChangedEventHandler)delegate
  { if (BlockNameChanged != null) BlockNameChanged(this, new System.EventArgs()); };
        this._settingCategory = new Enum(4);
      }
      public virtual string[] TagReferenceList {
        get {
UniqueStringCollection references = new UniqueStringCollection();
return references.ToArray();
        }
      }
      public virtual string BlockName {
        get {
return _settingCategory.ToString();
        }
      }
      public Enum SettingCategory {
        get {
          return this._settingCategory;
        }
        set {
          this._settingCategory = value;
        }
      }
      public LongInteger Value {
        get {
          return this._value;
        }
        set {
          this._value = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _settingCategory.Read(reader);
        _value.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
      }
      public virtual void Write(BinaryWriter bw) {
        _settingCategory.Write(bw);
        _value.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
      }
    }
  }
}
