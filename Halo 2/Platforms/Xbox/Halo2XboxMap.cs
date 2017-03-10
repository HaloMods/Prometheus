using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using Games.Halo2.Compiler.Classes;
using Games.Halo2.Compiler.Data;
using Games.Halo2.Platforms.Shared;
using Games.Halo2.Tags;
using Interfaces;
using Interfaces.Games;
using Interfaces.Policies;
using Interfaces.Pool;
using Tag = Games.Halo2.Compiler.Data.Tag;

namespace Games.Halo2.Platforms.Xbox
{
  public class Halo2XboxMap : IMapFile, IDisposable
  {
    #region constants
    private const int HeadSignature = 0x68656164;
    private const int FootSignature = 0x666f6f74;

    private const int StructureBsp = 0x73627370; // 'sbsp'
    private const int StructureLightmap = 0x6c746d70; // 'ltmp'
    private const int Sound = 0x736e6421; // 'snd!'
    private const int RenderModel = 0x6d6f6465; // 'mode'
    private const int Animation = 0x6a6d6164; // 'jmad'
    private const int WeatherSystem = 0x77656174; // 'weat'
    private const int ParticleModel = 0x5052544d; // 'PRTM'
    private const int Decorators = 0x44454352; // 'DECR'
    private const int Bitmap = 0x6269746d;// 'bitm'

    private const int CoconutsType = 0x75676821; // 'ugh!'
    private const string CoconutsName = "i've got a lovely bunch of coconuts";
    private const string ExtraTagDataAttachmentName = "Halo2_ExtraTagData";

    private const int IdentifierIncrement = 0x10001;

    private const string MainMenu = "mainmenu.map";
    private const string Shared = "shared.map";
    private const string SinglePlayerShared = "single_player_shared.map";
    #endregion
    #region structures
    [StructLayout(LayoutKind.Sequential)]
    private unsafe struct MapHeader
    {
      public const int NameLength = 0x20;
      public const int BuildStringLength = 0x20;

      public int HeadSignature;
      public int Format;
      public int EndOfFile;
      private fixed byte a[0x4];
      public int IndexOffset;
      public int IndexLength;
      public int IndexAndMetaLength;
      public int AllExceptRawLength;
      private fixed byte b[0x100];
      public fixed byte BuildString[BuildStringLength];
      public int CacheType;
      private int obsoleteHash;
      private fixed byte c[0x10];
      public int CrazyDataOffset;
      public int CrazyDataSize;
      public int StringIdPaddedOffset;
      public int StringIdCount;
      public int StringIdTableSize;
      public int StringIdIndexOffset;
      public int StringIdTableOffset;
      private fixed byte d[0x24];
      public fixed byte Name[NameLength];
      private fixed byte e[0x108];
      public int NameTableCount;
      public int NameTableOffset;
      public int NameTableSize;
      public int NameIndexOffset;
      public int Checksum;
      private fixed byte f[0x528];
      public int FootSignature;
    }

    [StructLayout(LayoutKind.Sequential)]
    private struct IndexHeader
    {
      public int MagicConstant;
      public int TagTypeCount;
      public int SecondaryConstant;
      public int ScenarioIdentifier;
      public int GlobalsIdentifier;
      private int obsoleteHash;
      public int TagCount;
      public int TagSignature;
    }

    [StructLayout(LayoutKind.Sequential)]
    private struct IndexElement
    {
      public int Type;
      public int Identifier;
      public int Offset;
      public int Size;
    }
    #endregion
    #region classes
    private class Bsp
    {
      public int LocationInScenario;
      public int BspHeaderOffset;
      public int BspOffset;
      public int LightmapOffset;
      public int BspSize;
      public int LightmapSize;
      public int Magic;
      public int BspID;
      public int LightmapID;
    }
    #endregion
    #region enumerations
    [Flags]
    private enum MapData
    {
      StringIds = StringIdPadded | StringIdIndex | StringIdTable,
      StringIdPadded = 0x1,
      StringIdIndex = 0x2,
      StringIdTable = 0x4,

      Names = NameTable | NameIndex,
      NameTable = 0x8,
      NameIndex = 0x10,

      UnicodeStrings = UnicodeLanguage0Table | UnicodeLanguage0Index | UnicodeLanguage1Table | UnicodeLanguage1Index | UnicodeLanguage2Table | UnicodeLanguage2Index | UnicodeLanguage3Table | UnicodeLanguage3Index | UnicodeLanguage4Table | UnicodeLanguage4Index | UnicodeLanguage5Table | UnicodeLanguage5Index | UnicodeLanguage6Table | UnicodeLanguage6Index | UnicodeLanguage7Table | UnicodeLanguage7Index | UnicodeLanguage8Table | UnicodeLanguage8Index,
      UnicodeLanguage0Index = 0x20,
      UnicodeLanguage0Table = 0x40,
      UnicodeLanguage1Index = 0x80,
      UnicodeLanguage1Table = 0x100,
      UnicodeLanguage2Index = 0x200,
      UnicodeLanguage2Table = 0x400,
      UnicodeLanguage3Index = 0x800,
      UnicodeLanguage3Table = 0x1000,
      UnicodeLanguage4Index = 0x2000,
      UnicodeLanguage4Table = 0x4000,
      UnicodeLanguage5Index = 0x8000,
      UnicodeLanguage5Table = 0x10000,
      UnicodeLanguage6Index = 0x20000,
      UnicodeLanguage6Table = 0x40000,
      UnicodeLanguage7Index = 0x80000,
      UnicodeLanguage7Table = 0x100000,
      UnicodeLanguage8Index = 0x200000,
      UnicodeLanguage8Table = 0x400000,

      CrazyData = 0x800000,

      Index = 0x1000000,

      BspMetadata = 0x2000000,
    }
    #endregion

    #region declarations
    private MapHeader header;
    private IndexHeader index;
    private List<IndexElement> tags;

    private List<string> strings;
    private List<string> names;
    private Dictionary<int, string> dictionary;
    private Dictionary<string, int> inverseDictionary;

    private int magic;
    private Bsp[] bsps;

    private Globals globals;
    private Coconuts coconuts;

    private int soundStart = -1;
    private int modelStart = -1;
    private int bspRawStart = -1;
    private int weatherStart = -1;
    private int decoratorStart = -1;
    private int particleModelStart = -1;
    private int coconutsModelStart = -1;
    private int animationStart = -1;
    private int bspMetaStart = -1;
    private int stringPaddedStart = -1;
    private int stringIndexStart = -1;
    private int stringTableStart = -1;
    private int nameTableStart = -1;
    private int nameIndexStart = -1;
    private int unicodeStart = -1;
    private int crazyStart = -1;
    private int bitmapStart = -1;

    private string filename;
    private FileStream map;
    private BinaryReader reader;
    private BinaryWriter writer;
    private SharedMaps shared;
    private bool valid = false;

    private TypeTable typeTable = new Halo2TypeTable();
    #endregion

    private Tag LoadTag(string path)
    {
      int index = LocateTagByID(inverseDictionary[path]);
      Tag tag = new Tag(tags[index].Type);
      Bsp bsp = null;
      string[] stringArray = strings.ToArray();

      switch (tags[index].Type)
      {
        case StructureBsp:
          bsp = GetBsp(tags[index].Identifier);
          map.Position = bsp.BspOffset;
          tag.ReadData(reader, shared, bsp.Magic - bsp.BspHeaderOffset, dictionary, stringArray, coconuts, globals, path);
          break;

        case StructureLightmap:
          bsp = GetBsp(tags[index].Identifier);
          map.Position = bsp.LightmapOffset;
          tag.ReadData(reader, shared, bsp.Magic - bsp.BspHeaderOffset, dictionary, stringArray, coconuts, globals, path);
          break;

        default:
          map.Position = unchecked(tags[index].Offset - magic);
          tag.ReadData(reader, shared, magic, dictionary, stringArray, coconuts, globals, path);
          break;
      }

      return tag;
    }

    public void Decompile(ILibrary library)
    {
      for (int i = 0; i < index.TagCount - 1; i++)
      {
        string qualifiedName = dictionary[tags[i].Identifier];
        if (!library.FileExists(qualifiedName))
          library.AddFile(qualifiedName, GetTag(qualifiedName));
      }
    }

    private Bsp GetBsp(int id)
    {
      if (id == -1)
        return null;

      for (int i = 0; i < bsps.Length; i++)
        if (bsps[i].BspID == id || bsps[i].LightmapID == id)
          return bsps[i];

      return null;
    }

    private int LocateTagByID(int id)
    {
      for (int i = 0; i < tags.Count; i++)
        if (tags[i].Identifier == id)
          return i;
      return -1;
    }

    private byte[] GenerateStringIndex(IList<string> strings)
    {
      using (MemoryStream stream = new MemoryStream(strings.Count * sizeof(int)))
      {
        BinaryWriter indexWriter = new BinaryWriter(stream);

        int currentOffset = 0;
        for (int i = 0; i < strings.Count; i++)
        {
          indexWriter.Write(currentOffset);
          currentOffset += strings[i].Length + 1;
        }

        return stream.ToArray();
      }
    }

    private byte[] GenerateStringTablePadded(IList<string> strings)
    {
      using (MemoryStream stream = new MemoryStream())
      {
        BinaryWriter tableWriter = new BinaryWriter(stream);

        for (int i = 0; i < strings.Count; i++)
        {
          tableWriter.Write(Encoding.ASCII.GetBytes(strings[i]));
          for (int j = strings[i].Length; j < AlignmentConstants.StringAlignment; j++)
            tableWriter.Write((byte)0);
        }

        return stream.ToArray();
      }
    }

    private byte[] GenerateStringTable(IList<string> strings)
    {
      using (MemoryStream stream = new MemoryStream())
      {
        BinaryWriter tableWriter = new BinaryWriter(stream);

        for (int i = 0; i < strings.Count; i++)
        {
          tableWriter.Write(Encoding.ASCII.GetBytes(strings[i]));
          tableWriter.Write((byte)0);
        }

        return stream.ToArray();
      }
    }

    private void FlushIndex(int modOffset)
    {
      map.Position = header.IndexOffset + modOffset;
      writer.Write(Reinterpret.Object<IndexHeader>(index));

      map.Position += index.TagTypeCount * 12;
      for (int i = 0; i < index.TagCount; i++)
        writer.Write(Reinterpret.Object<IndexElement>(tags[i]));
    }

    private void FlushIndex()
    {
      FlushIndex(0);
    }

    private void FlushHeader()
    {
      map.Position = 0;
      writer.Write(Reinterpret.Object<MapHeader>(header));
    }

    private void CalculateHeaderChecksum()
    {
      int checksum = 0;
      int fileLength = (int)map.Length;

      map.Position = Marshal.SizeOf(typeof(MapHeader));
      for (int i = (int)map.Position; i < fileLength; i += 4)
        checksum ^= reader.ReadInt32();

      header.Checksum = checksum;
    }

    private void AlignMap(int lastTagOffset)
    {
      header.EndOfFile = lastTagOffset + tags[index.TagCount - 1].Size;
      header.EndOfFile = Alignment.Align(header.EndOfFile, AlignmentConstants.FileAlignment);
      map.SetLength(header.EndOfFile);
    }

    private void AlignMap()
    {
      AlignMap(unchecked(tags[index.TagCount - 1].Offset - magic));
    }

    public void Dispose()
    {
      if (map != null)
      {
        map.Close();
        map.Dispose();
      }
      if (shared != null)
        shared.Dispose();
    }

    public bool Valid
    {
      get
      { return valid; }
    }

    public unsafe string Name
    {
      get
      {
        fixed (MapHeader* fixedHeader = &header)
          return UnsafeMemory.CopyBufferToString(fixedHeader->Name, MapHeader.NameLength);
      }
    }

    public TypeTable TypeTable
    {
      get { return typeTable; }
    }

    public void Load(string file)
    {
      filename = file;
      string directory = Path.GetDirectoryName(file) + '\\';

      #region open maps
      shared = new SharedMaps(new FileStream(directory + MainMenu, FileMode.Open, FileAccess.Read, FileShare.ReadWrite), new FileStream(directory + Shared, FileMode.Open, FileAccess.Read, FileShare.ReadWrite), new FileStream(directory + SinglePlayerShared, FileMode.Open, FileAccess.Read, FileShare.ReadWrite));

      map = new FileStream(file, FileMode.Open, FileAccess.ReadWrite, FileShare.Read);
      reader = new BinaryReader(map);
      writer = new BinaryWriter(map);
      #endregion

      #region header and index
      header = Reinterpret.Memory<MapHeader>(reader.ReadBytes(Marshal.SizeOf(typeof(MapHeader))));
      map.Position = header.IndexOffset;
      index = Reinterpret.Memory<IndexHeader>(reader.ReadBytes(Marshal.SizeOf(typeof(IndexHeader))));
      magic = (index.MagicConstant - header.IndexOffset - Marshal.SizeOf(typeof(IndexHeader))) + (header.AllExceptRawLength - header.IndexAndMetaLength - header.IndexLength);

      // each "TagType" is three dwords
      map.Position += 12 * index.TagTypeCount;

      tags = new List<IndexElement>(index.TagCount);
      for (int i = 0; i < index.TagCount; i++)
        tags.Add(Reinterpret.Memory<IndexElement>(reader.ReadBytes(Marshal.SizeOf(typeof(IndexElement)))));
      #endregion

      #region bsps
      int bspCount = 0;
      int bspOffset = 0;

      if (header.HeadSignature == HeadSignature)
      {
        map.Position = 528 + unchecked(tags[LocateTagByID(index.ScenarioIdentifier)].Offset - magic);
        bspCount = reader.ReadInt32();
        bspOffset = unchecked(reader.ReadInt32() - magic);

        bsps = new Bsp[bspCount];
        for (int i = 0; i < bspCount; i++)
        {
          bsps[i] = new Bsp();
          map.Position = bsps[i].LocationInScenario = bspOffset + 68 * i;

          bsps[i].BspHeaderOffset = reader.ReadInt32();
          int totalBspSize = reader.ReadInt32();
          bsps[i].Magic = reader.ReadInt32();

          map.Position += 8;
          bsps[i].BspID = reader.ReadInt32();
          map.Position += 4;
          bsps[i].LightmapID = reader.ReadInt32();

          /*
           * HEADER FORMAT
           * total size
           * pointer to bsp location
           * pointer to lightmap location
           * 'sbsp'
           */

          map.Position = bsps[i].BspHeaderOffset;
          int inHeaderBspSize = reader.ReadInt32();
          int inHeaderBspOffset = reader.ReadInt32();
          int lightmapOffset = reader.ReadInt32();
          bsps[i].BspOffset = (inHeaderBspOffset - bsps[i].Magic) + bsps[i].BspHeaderOffset;

          if (bsps[i].LightmapID == -1)
            bsps[i].BspSize = inHeaderBspSize;
          else
          {
            bsps[i].LightmapOffset = unchecked(lightmapOffset - bsps[i].Magic) + bsps[i].BspHeaderOffset;
            bsps[i].BspSize = bsps[i].LightmapOffset - bsps[i].BspOffset;
            bsps[i].LightmapSize = totalBspSize - bsps[i].BspSize;
          }
        }
      }
      #endregion

      #region strings
      strings = new List<string>(header.StringIdCount);
      map.Position = header.StringIdTableOffset;
      for (int i = 0; i < header.StringIdCount; i++)
      {
        strings.Add(String.Empty);
        while (true)
        {
          byte character = reader.ReadByte();
          if (character == 0)
            break;
          else
            strings[i] += Convert.ToChar(character);
        }
      }
      string[] stringArray = strings.ToArray();
      #endregion

      #region names
      map.Position = header.NameTableOffset;
      names = new List<string>(header.NameTableCount);
      dictionary = new Dictionary<int, string>(header.NameTableCount);
      inverseDictionary = new Dictionary<string, int>(header.NameTableCount);

      for (int i = 0; i < header.NameTableCount; i++)
      {
        names.Add(String.Empty);
        while (true)
        {
          byte character = reader.ReadByte();
          if (character == 0)
            break;
          else
            names[i] += Convert.ToChar(character);
        }

        string dictionaryName = names[i] + '.' + Singleton<ClassManager>.Instance.GetClassByID(tags[i].Type).Name;
        dictionary.Add(tags[i].Identifier, dictionaryName);
        inverseDictionary.Add(dictionaryName, tags[i].Identifier);
      }
      #endregion

      #region globals and coconuts
      if (header.HeadSignature == HeadSignature)
      {
        map.Position = unchecked(tags[LocateTagByID(index.GlobalsIdentifier)].Offset - magic);
        globals = new Globals(reader);

        map.Position = unchecked(tags[index.TagCount - 1].Offset - magic);
        coconuts = new Coconuts(reader, shared, magic, stringArray);
      }
      #endregion

      #region composition
      if (header.HeadSignature == HeadSignature)
      {
        for (int i = 0; i < index.TagCount; i++)
        {
          int result;

          switch (tags[i].Type)
          {
            case Animation:
              map.Position = unchecked(tags[i].Offset - magic);
              result = Tag.GetFirstInternalResourceOffset(reader, Animation, magic);
              if (result != -1)
                if (result < animationStart || animationStart == -1)
                  animationStart = result;
              break;

            case Decorators:
              map.Position = unchecked(tags[i].Offset - magic);
              result = Tag.GetFirstInternalResourceOffset(reader, Decorators, magic);
              if (result != -1)
                if (result < decoratorStart || decoratorStart == -1)
                  decoratorStart = result;
              break;

            case ParticleModel:
              map.Position = unchecked(tags[i].Offset - magic);
              result = Tag.GetFirstInternalResourceOffset(reader, ParticleModel, magic);
              if (result != -1)
                if (result < particleModelStart || particleModelStart == -1)
                  particleModelStart = result;
              break;

            case WeatherSystem:
              map.Position = unchecked(tags[i].Offset - magic);
              result = Tag.GetFirstInternalResourceOffset(reader, WeatherSystem, magic);
              if (result != -1)
                if (result < weatherStart || weatherStart == -1)
                  weatherStart = result;
              break;

            case RenderModel:
              map.Position = unchecked(tags[i].Offset - magic);
              result = Tag.GetFirstInternalResourceOffset(reader, RenderModel, magic);
              if (result != -1)
                if (result < modelStart || modelStart == -1)
                  modelStart = result;
              break;
          }
        }

        // this is (should be anyways) constant
        soundStart = Marshal.SizeOf(typeof(MapHeader));

        // this is a calculated value
        bitmapStart = header.CrazyDataOffset + header.CrazyDataSize;

        for (int i = 0; i < bspCount; i++)
        {
          Bsp bsp = bsps[i];
          if (bsp.BspOffset < bspMetaStart || bspMetaStart == -1)
            bspMetaStart = bsp.BspHeaderOffset;
          else if (bsp.LightmapOffset < bspMetaStart || bspMetaStart == -1)
            bspMetaStart = bsp.BspHeaderOffset;

          int result;

          if (bsp.BspID != -1)
          {
            reader.BaseStream.Position = bsp.BspOffset;
            result = Tag.GetFirstInternalResourceOffset(reader, StructureBsp, bsp.Magic - bsp.BspHeaderOffset);
            if (result != -1)
              if (result < bspRawStart || bspRawStart == -1 && result != -1)
                bspRawStart = result;
          }

          if (bsp.LightmapID != -1)
          {
            reader.BaseStream.Position = bsp.LightmapOffset;
            result = Tag.GetFirstInternalResourceOffset(reader, StructureLightmap, bsp.Magic - bsp.BspHeaderOffset);
            if (result != -1)
              if (result < bspRawStart || bspRawStart == -1)
                bspRawStart = result;
          }
        }

        foreach (Coconuts.ExtraInfo extraInfo in coconuts.ExtraInfos)
        {
          if (extraInfo.ResourceBlock.RawSize > 0)
          {
            uint encoded = Conversion.ToUInt(extraInfo.ResourceBlock.RawOffset);
            if ((encoded & 0xc0000000) == 0)
            {
              if (extraInfo.ResourceBlock.RawOffset < coconutsModelStart || coconutsModelStart == -1)
                coconutsModelStart = extraInfo.ResourceBlock.RawOffset;
            }
          }
        }

        if (bspMetaStart < 0)
          bspMetaStart = header.StringIdPaddedOffset;
        if (animationStart < 0)
          animationStart = bspMetaStart;
        if (coconutsModelStart < 0)
          coconutsModelStart = animationStart;
        if (particleModelStart < 0)
          particleModelStart = coconutsModelStart;
        if (decoratorStart < 0)
          decoratorStart = particleModelStart;
        if (weatherStart < 0)
          weatherStart = decoratorStart;
        if (bspRawStart < 0)
          bspRawStart = weatherStart;
        if (modelStart < 0)
          modelStart = bspRawStart;

        // these are all duplicates
        stringPaddedStart = header.StringIdPaddedOffset;
        stringIndexStart = header.StringIdIndexOffset;
        stringTableStart = header.StringIdTableOffset;
        nameTableStart = header.NameTableOffset;
        nameIndexStart = header.NameIndexOffset;
        crazyStart = header.CrazyDataOffset;

        // this can be calculated a multitude of ways
        unicodeStart = header.NameIndexOffset + header.NameTableCount * sizeof(int);
      }
      #endregion

      valid = true;
    }

    public void RegisterTag(ILibrary library, string tagName)
    {
      throw new Exception("The method or operation is not implemented.");
    }

    public void CompileCache(Stream output, ILibrary library)
    {
      throw new Exception("The method or operation is not implemented.");
    }

    public string Filename
    {
      get { return filename; }
    }

    public string[] GetTagList()
    {
      string[] formattedNames = new string[names.Count];
      dictionary.Values.CopyTo(formattedNames, 0);
      return formattedNames;
    }

    public byte[] GetTag(string path)
    {
      Tag tag = LoadTag(path);
      TagFile tf = new TagFile(tag.GetTagData(), "Bungie", "Obtained from Halo 2 Xbox.", typeTable.LocateEntryByTypecode(tag.Type).FourCC, "????", "????", Halo2XboxGameDefinition.TagIdentifierStatic);
      tf.AddAttachment(ExtraTagDataAttachmentName);
      tf.AddAttachmentRevision(ExtraTagDataAttachmentName, tag.GetExtraData(), 1.0f, CompressionStyle.GZip);
      return tf.ToBytes();
    }

    public byte[] CalculateChecksum()
    {
      // Determine the size of the index.
      int indexSize = Marshal.SizeOf(typeof(IndexHeader)) + (Marshal.SizeOf(typeof(IndexElement)) * tags.Count);
      byte[] indexData = new byte[indexSize];

      // Read the index into memory.
      map.Position = header.IndexOffset;
      map.Read(indexData, 0, indexSize);

      // Generate a hash of the index.
      MD5 md5 = new MD5CryptoServiceProvider();
      return md5.ComputeHash(indexData);
    }

    public int EoF
    {
      get { return header.EndOfFile; }
    }
  }
}
