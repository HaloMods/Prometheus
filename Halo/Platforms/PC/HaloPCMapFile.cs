using System;
using System.Collections;
using System.IO;
using System.Text;
using System.Security.Cryptography;
using Games.Halo.Tags;
using Games.Halo.Tags.Classes;
using Interfaces.Games;
using Interfaces.Pool;
using Interfaces.IO;
using Interfaces.Options;
using Games.Halo.Compiler;
using Games.Halo.Compiler.XPE;
using Games.Halo.Platforms.Shared;
using Interfaces.Scripting;
using Tag = Games.Halo.Compiler.Tag;
using Interfaces;
using System.Reflection;

namespace Games.Halo.Platforms.PC
{
  public class HaloPCMapFile : IMapFile
  {
    private string filename = null;
    private TypeTable typeTable = new HaloTypeTable();

    private int eof;
    private uint magic;
    private int count;
    private uint indexMagic;
    private int indexOffset;
    private int modelIndexCount;
    private uint modelIndexOffset;
    private int modelVertexCount;
    private uint modelVertexOffset;
    private uint scenarioIdentifier;
    private short headerSize = 40;
    private string name;
    private string tagDirectory;
    private string[] names;
    private IndexItem[] index;
    private TagLibrary tags;
    private EndianReader sounds;
    private EndianReader bitmaps;
    private PackCacheIndex soundPCI;
    private PackCacheIndex bitmapPCI;

    [Option("Bitmaps Cache", "Halo PC Shared Files", "bitmaps.map")]
    private static string pcBitmapsFile = "bitmaps.map";
    [Option("Sounds Cache", "Halo PC Shared Files", "sounds.map")]
    private static string pcSoundsFile = "sounds.map";

    public void Decompile(ILibrary library)
    {
      LoadTag(null);
      for (int x = 0; x < count; x++)
      {
        if (tags[x] == null)
          continue;
        if (!library.FileExists(names[x] + '.' + tags[x].Xpe.Extension))
        {
          MemoryStream stream = tags[x].GetStream(tags, false);
          TagFile tf = new TagFile(stream.ToArray(), "Bungie", "Obtained from Halo PC.", tags[x].Xpe.FourCC, tags[x].Xpe.ParentFourCC, tags[x].Xpe.GrandparentFourCC, HaloPCGameDefinition.TagIdentifierStatic);
          library.AddFile(names[x] + '.' + tags[x].Xpe.Extension, tf.ToBytes());
        }
      }
    }

    /// <summary>
    /// A list of file extensions that map to the fourcc of each tag type.
    /// </summary>
    public TypeTable TypeTable
    {
      get { return typeTable; }
    }

    public string Filename
    {
      get { return filename; }
    }

		/*
  	private string[] m_cachedTagList;

    public string[] GetTagList()
    {
			if (m_cachedTagList == null)
			{
				m_cachedTagList = new string[count];
				for (int i = 0; i < count; i++)
					m_cachedTagList[i] = String.Format("{0}.{1}", names[i], tags.CXPE[index[i].type].Extension);
			}
			return m_cachedTagList;
    }
		*/

		public string[] GetTagList()
		{
			string[] tagList = new string[count];
				for (int i = 0; i < count; i++)
					tagList[i] = String.Format("{0}.{1}", names[i], tags.CXPE[index[i].type].Extension);
			return tagList;
		}

    /// <summary>
    /// Exports a tag from the map.
    /// </summary>
    /// <param name="path">The tag to extract, including extension.</param>
    public byte[] GetTag(string path)
    {
      Tag tag = LoadTag(path);
      TagFile tf = new TagFile(tag.GetStream(tags, false).ToArray(), "Bungie", "Obtained from Halo PC.", tag.Xpe.FourCC, tag.Xpe.ParentFourCC, tag.Xpe.GrandparentFourCC, HaloPCGameDefinition.TagIdentifierStatic);

			#region Scripting

			if (false && /* out of action */ tf.Type == "scnr")
			{
				ScenarioBase scnr = new scenario();
				scnr.Load(tf.GetBinary(tf.HeadRevision));

				if (scnr.GetScripts().Length > 0 || scnr.GetScriptGlobals().Length > 0)
				{
					IScriptProcessor processor = HaloPCScriptEngine.Processor;
					string scripts = processor.DecompileForMapScenario(new MapScenarioScriptingAssembly(scnr, this));

					#region Debug Script Output

					Directory.CreateDirectory(@"debug script output\");
					File.WriteAllText(@"debug script output\" + Path.GetFileNameWithoutExtension(filename) + ".psl", scripts);

					#endregion
					
					tf.AddAttachment("scripts.psl");
					tf.AddAttachmentRevision("scripts.psl", Encoding.ASCII.GetBytes(scripts), 1.0f, CompressionStyle.GZip);
					
					scnr.ClearScripting();

					tf.SetHeadBinary(scnr.Save());
				}
			}

			#endregion

			return tf.ToBytes();
    }

    /// <summary>
    /// Calculates the map's checksum by performing an MD5 hash of the tag index.
    /// </summary>
    /// <returns>A byte array representing an MD5 hash.</returns>
    public byte[] CalculateChecksum()
    {
      // Determine the size of the index.
      int indexSize = headerSize + (24 * tags.Count);
      byte[] indexData = new byte[indexSize];

      using (Stream file = new FileStream(filename, FileMode.Open))
      {
        // Read the index into memory.
        file.Position = indexOffset;
        file.Read(indexData, 0, indexSize);
        file.Close();

        // Generate a hash of the index.
        MD5 md5 = new MD5CryptoServiceProvider();
        return md5.ComputeHash(indexData);
      }
    }

    public void Load(string filename)
    {
      // load the bitmaps file
      string bitmapsFile = pcBitmapsFile;
      if (bitmapsFile == "bitmaps.map")
        bitmapsFile = Path.GetDirectoryName(filename) + '\\' + bitmapsFile;
      bitmaps = new EndianReader(new FileStream(bitmapsFile, FileMode.Open, FileAccess.Read, FileShare.ReadWrite), ByteOrder.LittleEndian);

      // load the sounds file
      string soundsFile = pcSoundsFile;
      if (soundsFile == "sounds.map")
        soundsFile = Path.GetDirectoryName(filename) + '\\' + soundsFile;
      sounds = new EndianReader(new FileStream(soundsFile, FileMode.Open, FileAccess.Read, FileShare.ReadWrite), ByteOrder.LittleEndian);

      // open the file
      this.filename = filename;
      EndianReader er = new EndianReader(new FileStream(filename, FileMode.Open, FileAccess.Read, FileShare.ReadWrite), ByteOrder.LittleEndian);

      er.Position = 0x8;
      eof = er.ReadInt32();
      er.Position = 0x10;
      indexOffset = er.ReadInt32();
      er.Position = indexOffset;
      indexMagic = er.ReadUInt32();
      scenarioIdentifier = er.ReadUInt32();
      er.Position += 4;
      count = er.ReadInt32();
      modelVertexCount = er.ReadInt32();
      modelVertexOffset = er.ReadUInt32();
      modelIndexCount = er.ReadInt32();
      modelIndexOffset = er.ReadUInt32();
      magic = (uint)(indexMagic - headerSize - indexOffset);
      tags = new TagLibrary(new Cxpe(Assembly.GetExecutingAssembly().GetManifestResourceStream("Games.Halo.Resources.halo.cxpe")));
      tags.MapFormat = MapFormat.PC;
      tags.ModelIndexOffset = (int)modelIndexOffset;
      tags.ModelVertexOffset = (int)modelVertexOffset;
      tags.Bitmaps = bitmaps;
      tags.Sounds = sounds;

      er.Position = indexOffset + headerSize;
      index = new IndexItem[count];
      names = new string[count];
      for (int x = 0; x < count; x++)
      {
        index[x] = new IndexItem();
        index[x].Read(er, magic);
      }

      for (int x = 0; x < count; x++)
      {
        er.Position = (int)index[x].stringOffset;
        names[x] = er.ReadString().Trim('\0');
        
        // HACK: Icefields for HaloPC has two tags that contain an extra consecutive slash in the index.
        // Get rid of that problem, as well as any other tags that may contain the same error.
        names[x] = names[x].Replace("\\\\", "\\");
        
        tags.AddTag(names[x], index[x].type, index[x].identifier, null);
      }

      er.Close();
      LoadTag(names[0] + '.' + tags.CXPE[index[0].type].Extension);
    }

    private Tag LoadTag(string name)
    {
      EndianReader er = new EndianReader(new FileStream(filename, FileMode.Open, FileAccess.Read, FileShare.ReadWrite), ByteOrder.LittleEndian);
      string extension = null;
      if(!String.IsNullOrEmpty(name))
      {
        extension = Path.GetExtension(name).Trim('.');
        name = name.Substring(0, name.Length - (extension.Length+1));
      }

      int bspIndex = 0;
      for (int x = 0; x < count; x++)
      {
        uint bspMagic = 0;
        int bspOffset = 0;
        if (index[x].type == "sbsp")
        {
          Array scenarioStructureBsps = tags[0]["structure bsps"] as Array;
          er.Position = bspOffset = (int)(scenarioStructureBsps.GetValue(bspIndex, 0 /* this is bsp offset */));
          bspMagic = (uint)(int)(scenarioStructureBsps.GetValue(bspIndex++, 2 /* this is bsp magic */));
          er.Position = (int)(er.ReadUInt32() - bspMagic) + bspOffset;
        }
        else
          er.Position = (int)index[x].metaOffset;
        if (((name == names[x] && tags.CXPE[index[x].type].Extension == extension) || String.IsNullOrEmpty(name)) && tags[x] == null)
        {
					Tag tag;
          if (index[x].type == "sbsp")
            tag = new Tag(er, names[x], index[x].type, (uint)(bspMagic - bspOffset), tags);
          else
            tag = new Tag(er, names[x], index[x].type, magic, tags);
          tags[x] = tag;
        }
        if (name == names[x] && tags.CXPE[index[x].type].Extension == extension)
        {
          er.Close();
          return tags[x];
        }
      }

      er.Close();
      return null;
    }

    public int EoF
    {
      get
      { return eof; }
    }

    public void RegisterTag(ILibrary library, string tagName)
    {
      if (tags == null)
      {
        tags = new TagLibrary(new Cxpe(Assembly.GetExecutingAssembly().GetManifestResourceStream("Games.Halo.Resources.halo.cxpe")));
        tags.MapFormat = MapFormat.PC;
        Stream soundStream = Assembly.GetExecutingAssembly().GetManifestResourceStream("Games.Halo.Resources.halopc_sounds.pci");
        Stream bitmapStream = Assembly.GetExecutingAssembly().GetManifestResourceStream("Games.Halo.Resources.halopc_bitmaps.pci");
        soundPCI = new PackCacheIndex(new BinaryReader(soundStream));
        bitmapPCI = new PackCacheIndex(new BinaryReader(bitmapStream));
      }
      if (name == null)
      {
        name = tagName.Remove(tagName.LastIndexOf('.'));
        name = name.Substring(tagName.LastIndexOf('\\') + 1);
      }
      if (tagName.Substring(tagName.LastIndexOf('.') + 1) == "globals") // HACK: this should be part of the project definition. not part of the compiler code.
        tags.GetDependencyTag(tagName.Remove(tagName.LastIndexOf('.')), tags.CXPE.GetFourCCFromExtension(tagName.Substring(tagName.LastIndexOf('.') + 1)), library, "globals\\globals", false);
      else
        tags.GetDependencyTag(tagName.Remove(tagName.LastIndexOf('.')), tags.CXPE.GetFourCCFromExtension(tagName.Substring(tagName.LastIndexOf('.') + 1)), library);
    }

    public void CompileCache(Stream output, ILibrary library)
    {
      #region Prepare scenario tag and load scenario_structure_bsp tags into memory.
      Tag tagScenario = null;
      for (int i = 0; i < tags.Count; i++)
      {
        if (tags.GetClass(i) == "scnr")
        {
          tagScenario = tags[i];
          break;
        }
      }
      if (tagScenario == null)
        throw new HaloException("No scenario was registered. Cannot compile cache.");

      MapUsage usage;
      short mapUsage = (short)tagScenario["type"];
      switch (mapUsage)
      {
        case 0:
          usage = MapUsage.Campaign;
          break;
        case 1:
          usage = MapUsage.Multiplayer;
          break;
        case 2:
          usage = MapUsage.UI;
          break;
        default:
          throw new HaloException("The scenario map type flag is invalid.");
      }

      string[] sbsps = tags.StructureBsps;
      Array scenarioBspBlock = tagScenario["structure bsps"] as Array;
      for (int x = 0; x < sbsps.Length; x++)
      {
        int bspTagIndex = tags.GetDependencyTag(sbsps[x], "sbsp", library, sbsps[x], true);
        scenarioBspBlock.SetValue(bspTagIndex, x, 4 /* this is the bsp tag reference */);
      }
      #endregion

      #region Attach streams to buffers and create a Predictor.
      count = tags.Count;
      Cxpe structs = tags.CXPE;
      EndianWriter header = new EndianWriter(new MemoryStream(), ByteOrder.LittleEndian); // holds the map header, dumbass
      EndianWriter bspBuffer = new EndianWriter(new MemoryStream(), ByteOrder.LittleEndian); // holds bsp header, vertices, triangles, and meta
      EndianWriter indexBuffer = new EndianWriter(new MemoryStream(), ByteOrder.LittleEndian); // holds the map object index and filenames
      EndianWriter modelVertexBuffer = new EndianWriter(new MemoryStream(), ByteOrder.LittleEndian); // holds model vertices
      EndianWriter modelIndexBuffer = new EndianWriter(new MemoryStream(), ByteOrder.LittleEndian); // holds model indices
      EndianWriter metaBuffer = new EndianWriter(new MemoryStream(), ByteOrder.LittleEndian); // holds tag metadata
      EndianWriter local = new EndianWriter(output, ByteOrder.LittleEndian); // Map is outputted through this stream
      Predictor predictor = new Predictor(tags);
      #endregion

      #region Prepare the model vertex and index buffers, cull compressed model vertices.
      ArrayList vertexOffsets = new ArrayList();
      ArrayList indexOffsets = new ArrayList();
      ArrayList vertexCounts = new ArrayList();
      ArrayList indexCounts = new ArrayList();
      for (int x = count - 1; x >= 0; x--) // all model data is flipped backwards in halo pc
      {
        Xpe mode = structs["mode"];
        Xpe mod2 = structs["mod2"];
        Xpe pcModel = null;
        if (tags.GetClass(x) == "mod2" || tags.GetClass(x) == "mode")
        {
          if (tags.GetClass(x) == "mod2")
            pcModel = mod2;
          else
            pcModel = mode;

          Array geometry = tags[x]["geometries"] as Array;
          int geometries = geometry.GetLength(0);
          for (int y = geometries - 1; y >= 0; y--)
          {
            Array part = geometry.GetValue(y, pcModel.FieldByName("geometries")["parts"]) as Array;
            int parts = part.GetLength(0);
            for (int z = parts - 1; z >= 0; z--)
            {
              // These will speed this method up by quite a bit, and make it much more readable
              Xpe.Field cPart = pcModel.FieldByName("geometries").FieldByName("parts");
              Xpe.Field cVertex = cPart.FieldByName("uncompressed vertices");
              Xpe.Field cFace = cPart.FieldByName("triangles");

              // Write the compressed vertices to the vertex buffer, or if they do not exist, compress the uncompressed vertices and use them instead
              Array vertex = part.GetValue(z, cPart["uncompressed vertices"]) as Array;
              bool uncompressed = false;
              int verts = vertex.GetLength(0);
              if (!(uncompressed = (verts != 0)))
              {
                cVertex = cPart.FieldByName("compressed vertices");
                vertex = part.GetValue(z, cPart["compressed vertices"]) as Array;
                verts = vertex.GetLength(0);
              }
              vertexCounts.Add(verts);
              modelVertexBuffer.Position = modelVertexBuffer.Length = Compression.Round(modelVertexBuffer.Length, 4);
              vertexOffsets.Add((uint)modelVertexBuffer.Length);
              for (int i = 0; i < verts; i++)
              {
                modelVertexBuffer.Write((float)(vertex.GetValue(i, cVertex["position"]) as Array).GetValue(0));
                modelVertexBuffer.Write((float)(vertex.GetValue(i, cVertex["position"]) as Array).GetValue(1));
                modelVertexBuffer.Write((float)(vertex.GetValue(i, cVertex["position"]) as Array).GetValue(2));
                //if (uncompressed)
                {
                  modelVertexBuffer.Write((float)(vertex.GetValue(i, cVertex["normal"]) as Array).GetValue(0));
                  modelVertexBuffer.Write((float)(vertex.GetValue(i, cVertex["normal"]) as Array).GetValue(1));
                  modelVertexBuffer.Write((float)(vertex.GetValue(i, cVertex["normal"]) as Array).GetValue(2));
                  modelVertexBuffer.Write((float)(vertex.GetValue(i, cVertex["binormal"]) as Array).GetValue(0));
                  modelVertexBuffer.Write((float)(vertex.GetValue(i, cVertex["binormal"]) as Array).GetValue(1));
                  modelVertexBuffer.Write((float)(vertex.GetValue(i, cVertex["binormal"]) as Array).GetValue(2));
                  modelVertexBuffer.Write((float)(vertex.GetValue(i, cVertex["tangent"]) as Array).GetValue(0));
                  modelVertexBuffer.Write((float)(vertex.GetValue(i, cVertex["tangent"]) as Array).GetValue(1));
                  modelVertexBuffer.Write((float)(vertex.GetValue(i, cVertex["tangent"]) as Array).GetValue(2));
                  modelVertexBuffer.Write((float)(vertex.GetValue(i, cVertex["texture coords"]) as Array).GetValue(0));
                  modelVertexBuffer.Write((float)(vertex.GetValue(i, cVertex["texture coords"]) as Array).GetValue(1));
                  modelVertexBuffer.Write((short)vertex.GetValue(i, cVertex["node0 index"]));
                  modelVertexBuffer.Write((short)vertex.GetValue(i, cVertex["node1 index"]));
                  modelVertexBuffer.Write((float)vertex.GetValue(i, cVertex["node0 weight"]));
                  modelVertexBuffer.Write((float)vertex.GetValue(i, cVertex["node1 weight"]));
                }
                /*else // this code was removed due to dual compression in tags. saves us some time here.
                {
                  modelVertexBuffer.Write((int)(vertex.GetValue(i, cVertex["normal[11.11.10-bit]"])));
                  modelVertexBuffer.Write((int)(vertex.GetValue(i, cVertex["binormal[11.11.10-bit]"])));
                  modelVertexBuffer.Write((int)(vertex.GetValue(i, cVertex["tangent[11.11.10-bit]"])));
                  modelVertexBuffer.Write((short)(vertex.GetValue(i, cVertex["texture coordinate u[16-bit]"])));
                  modelVertexBuffer.Write((short)(vertex.GetValue(i, cVertex["texture coordinate v[16-bit]"])));
                  modelVertexBuffer.Write((byte)(vertex.GetValue(i, cVertex["node0 index(x3)"])));
                  modelVertexBuffer.Write((byte)(vertex.GetValue(i, cVertex["node1 index(x3)"])));
                  modelVertexBuffer.Write((short)(vertex.GetValue(i, cVertex["node0 weight[16-bit]"])));
                }*/
              }

              // Write indices to index buffer
              Array triangle = part.GetValue(z, cPart["triangles"]) as Array;
              int triangles = triangle.GetLength(0);
              modelIndexBuffer.Position = modelIndexBuffer.Length = Compression.Round(modelIndexBuffer.Length, 4);
              indexOffsets.Add((uint)modelIndexBuffer.Length);
              short difference = 2;
              for (int i = 0; i < triangles; i++)
              {
                short a = (short)triangle.GetValue(i, cFace["vertex0 index"]);
                short b = (short)triangle.GetValue(i, cFace["vertex1 index"]);
                short c = (short)triangle.GetValue(i, cFace["vertex2 index"]);
                if (i == triangles - 1)
                {
                  if (a == -1)
                    difference += 3;
                  else if (b == -1)
                    difference += 2;
                  else if (c == -1)
                    difference += 1;
                }
                modelIndexBuffer.Write(a);
                modelIndexBuffer.Write(b);
                modelIndexBuffer.Write(c);
              }
              indexCounts.Add((int)(triangles * 3 - difference));

              // Cull these structures from the tag
              // TODO: create better way to cull model data that doesn't permanently scar the tags
              part.SetValue(Array.CreateInstance(typeof(object), 0, cPart.FieldByName("uncompressed vertices").Children.Length), z, cPart["uncompressed vertices"]);
              part.SetValue(Array.CreateInstance(typeof(object), 0, cPart.FieldByName("compressed vertices").Children.Length), z, cPart["compressed vertices"]);
              part.SetValue(Array.CreateInstance(typeof(object), 0, cFace.Children.Length), z, cPart["triangles"]);
            }
          }
        }

        // This 'converts' all xbox 'mode' tags into pc 'mod2' tags (it should be noted that this scars the CXPE)
        Xpe.Field geometryEdit = mode.FieldByName("geometries");
        Xpe.Field geometryParts = geometryEdit.FieldByName("parts");
        geometryParts.PadEnd(28);
      }

      // reverse the order of these items, because in the future we will not be processing tags backwards-like
      vertexCounts.Reverse();
      vertexOffsets.Reverse();
      indexCounts.Reverse();
      indexOffsets.Reverse();
      #endregion

      #region Prepare the index.
      indexBuffer.Write((uint)IndexMagic.PC);
      indexBuffer.Write(tags.GetID(0));
      indexBuffer.Write(0);
      indexBuffer.Write(count);
      indexBuffer.Position = 36;
      indexBuffer.Write(0x74616773); // 'tags'
      indexBuffer.Position = indexBuffer.Length += count * 32;
      uint[] stringOffsets = new uint[count];
      for (int x = 0; x < count; x++)
      {
        stringOffsets[x] = (uint)indexBuffer.Position;
        indexBuffer.Write(tags.GetName(x), true);
      }
      indexBuffer.Position = indexBuffer.Length = Compression.Round(indexBuffer.Length, 4/*32*/); // halo pc does not require this much padding
      
      // in halo pc, we align the index to 0x04 using dashes
      int modelIndexBufferPadBytes = Compression.Pad(modelIndexBuffer.Position = modelIndexBuffer.Length, 4);
      for (int i = 0; i < modelIndexBufferPadBytes; i++)
        modelIndexBuffer.Write((byte)0x2d);
      modelIndexBuffer.Position = modelIndexBuffer.Length; // = Compression.Round(modelIndexBuffer.Length, 16); // in halo pc, these paddings are not used
      modelVertexBuffer.Position = modelVertexBuffer.Length; // = Compression.Round(modelVertexBuffer.Length, 32);
      #endregion

      #region Calculate "magic" memory offsets.
      // 'memory' is a handy little value that we can add to any post-model offset to simulate "magic", no matter what we do anywhere else now
      uint mIndexMagic = (uint)IndexMagic.PC;
      int mHeaderLength = (int)headerSize;
      int vertexDataLength = modelVertexBuffer.Position = modelVertexBuffer.Length;
      uint totalVertexBufferLength = (uint)(modelVertexBuffer.Length);
      uint totalIndexBufferLength = (uint)modelIndexBuffer.Length;
      uint magicIndexLength = (uint)(/*Compression.Round(*/indexBuffer.Length/*, 0x20)*/ - mHeaderLength);
      uint memory = (uint)(mIndexMagic + magicIndexLength /*+ totalVertexBufferLength + totalIndexBufferLength*/);
      uint stringMemory = (uint)(mIndexMagic - mHeaderLength);
      //uint modelIndexMemory = (uint)(mIndexMagic + magicIndexLength + totalVertexBufferLength);
      //uint modelVertexMemory = (uint)(mIndexMagic + magicIndexLength);
      #endregion

      #region Create the model pointer buffers and update the tag strings.
      // These will write the model pointer buffers
      // except, no they won't, because halo pc doesn't use model pointer buffers
      /*for (int x = 0; x < vertexOffsets.Count; x++)
      {
        indirectVertexOffsets.Add((uint)(modelIndirectVertexBuffer.Position + modelVertexPointerMemory));
        vertexOffsets[x] = (uint)vertexOffsets[x] + modelVertexMemory;
        modelIndirectVertexBuffer.Write((uint)0xcacacaca);
        modelIndirectVertexBuffer.Write((uint)vertexOffsets[x]);
        modelIndirectVertexBuffer.Write((uint)0xcacacaca);
      }
      for (int x = 0; x < indexOffsets.Count; x++)
      {
        indirectIndexOffsets.Add((uint)(modelIndirectIndexBuffer.Position + modelIndexPointerMemory));
        indexOffsets[x] = (uint)indexOffsets[x] + modelIndexMemory;
        modelIndirectIndexBuffer.Write((uint)0xcacacaca);
        modelIndirectIndexBuffer.Write((uint)indexOffsets[x]);
        modelIndirectIndexBuffer.Write((uint)0xcacacaca);
      }*/
      // We need to add our memory offset to the string offsets now
      for (int x = 0; x < count; x++)
        stringOffsets[x] += stringMemory;
      // This will set the tag string offsets to the tag library, so they can be written to tag references
      tags.StringOffsets = stringOffsets;
      #endregion

      #region Buffer bsp tags, then calculate bsp magic and size. Only look at the code here if you want a headache for the next two hours.
      int previousLength = 0;
      Xpe sbsp = structs["sbsp"];
      ArrayList bspSize = new ArrayList();
      ArrayList bspOffset = new ArrayList();
      ArrayList bspPointers = new ArrayList();
      ArrayList bspMetaOffset = new ArrayList();
      ArrayList bspMaterialList = new ArrayList();
      /*ArrayList vertexIndirects = new ArrayList();
      ArrayList vertexIndirectOffsets = new ArrayList();
      ArrayList lightmapIndirects = new ArrayList();
      ArrayList lightmapIndirectOffsets = new ArrayList();*/ // no indirect buffers in halo pc
      for (int x = 0; x < count; x++)
      {
        if (tags.GetClass(x) == "sbsp")
        {
          ArrayList cPointerList = new ArrayList();
          ArrayList cDestinationList = new ArrayList();
          /*ArrayList vertexIndirect = new ArrayList();
          ArrayList vertexIndirectOffset = new ArrayList();
          ArrayList lightmapIndirect = new ArrayList();
          ArrayList lightmapIndirectOffset = new ArrayList();*/ // no indirect buffers in halo pc
          bspBuffer.Position = bspBuffer.Length = Compression.Round(bspBuffer.Length, 0x800);
          bspOffset.Add((uint)bspBuffer.Position);

          // Create the bsp header
          int bspMaterialCount = 0;
          Array bspLightmaps = tags[x]["structure lightmaps"] as Array;
          int lmCount = bspLightmaps.GetLength(0);
          Xpe.Field cLightmap = sbsp.FieldByName("structure lightmaps");

          for (int y = 0; y < lmCount; y++)
          {
            Array bspMaterials = bspLightmaps.GetValue(y, cLightmap["structure materials"]) as Array;
            int matCount = bspMaterials.GetLength(0);
            bspMaterialCount += matCount;
          }

          // Write obviously unfinished bsp header (... except, not as unfinished as it looks)
          bspBuffer.Write(0);
          bspBuffer.Write(0);
          bspBuffer.Write(0);
          bspBuffer.Write(0);
          bspBuffer.Write(0);
          bspBuffer.Write(0x73627370); // 'sbsp'
          int[] bspAuxInfo = new int[bspMaterialCount * 6];
          /*for (int y = 0; y < bspMaterialCount; y++) // halo pc has no indirect pointers
          {
            bspAuxInfo[(bspMaterialCount - y - 1) * 6 + 4] = bspBuffer.Position;
            bspBuffer.Write((uint)0xcacacaca);
            vertexIndirect.Add(bspBuffer.Position);
            bspBuffer.Write(0);
            bspBuffer.Write((uint)0xcacacaca);
          }
          for (int y = 0; y < bspMaterialCount; y++)
          {
            bspAuxInfo[(bspMaterialCount - y - 1) * 6 + 5] = bspBuffer.Position;
            bspBuffer.Write((uint)0xcacacaca);
            lightmapIndirect.Add(bspBuffer.Position);
            bspBuffer.Write(0);
            bspBuffer.Write((uint)0xcacacaca);
          }*/
          bspMaterialList.Add(bspMaterialCount);
          bspMaterialCount = 0;

          // Write bsp vertices (... except not really)
          for (int y = 0; y < lmCount; y++)
          {
            Array bspMaterials = bspLightmaps.GetValue(y, cLightmap["structure materials"]) as Array;
            int matCount = bspMaterials.GetLength(0);
            Xpe.Field cMaterial = cLightmap.FieldByName("structure materials");
            bool noLightmap = (short)bspLightmaps.GetValue(y, cLightmap["bitmap"]) < 0;

            for (int z = 0; z < matCount; z++)
            {
              Tag.DataContainer cvdc = bspMaterials.GetValue(z, cMaterial["compressed vertices"]) as Tag.DataContainer;
              Tag.DataContainer uvdc = bspMaterials.GetValue(z, cMaterial["uncompressed vertices"]) as Tag.DataContainer;
              Array bspUncompressedVertices = uvdc.data;
              //if (bspCompressedVertices.GetLength(0) == 0)
              //  bspCompressedVertices = CompressBspVertices(uvdc.data, !noLightmap);
              int vertexDataLen = bspUncompressedVertices.GetLength(0);
              if (noLightmap)
              {
                bspAuxInfo[bspMaterialCount * 6] = vertexDataLen / 56;
                bspAuxInfo[bspMaterialCount * 6 + 3] = 0;
              }
              else
              {
                bspAuxInfo[bspMaterialCount * 6] = vertexDataLen / 76;
                bspAuxInfo[bspMaterialCount * 6 + 3] = bspAuxInfo[bspMaterialCount * 6];
              }
              bspAuxInfo[bspMaterialCount * 6 + 1] = vertexDataLen;

              bspMaterialCount++;
              /*int vertexPadLen = Compression.Pad(bspBuffer.Length, 32);
              for (int pb = 0; pb < vertexPadLen; pb++)
                bspBuffer.Write((byte)0xca);
              vertexIndirectOffset.Add((uint)bspBuffer.Position);
              lightmapIndirectOffset.Add((uint)(bspBuffer.Position + (bspAuxInfo[bspMaterialCount * 6] * 32)));
              bspAuxInfo[(bspMaterialCount++) * 6 + 2] = bspBuffer.Position;
              for (int i = 0; i < vertexDataLen; i++)
                bspBuffer.Write((byte)bspCompressedVertices.GetValue(i));*/ // bsp vertices in halo pc are standard data, without special treatment

              // Cull this data from the bsp block
              // TODO: Create a better way to do this without scarring tags
              /*bspMaterials.SetValue(new Tag.DataContainer(cvdc.variable, new byte[0]), z, cMaterial["compressed vertices"]);
              bspMaterials.SetValue(new Tag.DataContainer(uvdc.variable, new byte[0]), z, cMaterial["uncompressed vertices"]);*/
              // the vertex data is not culled in halo pc; it is used directly from the tag
            }
          }

          bspMetaOffset.Add((uint)bspBuffer.Position);
          predictor.GeneratePRs(tags[x]);
          tags[x].Write(bspBuffer, tags, cPointerList, cDestinationList, bspAuxInfo);
          bspPointers.Add(new PointerList(cPointerList, cDestinationList));
          bspBuffer.Length = Compression.Round(bspBuffer.Length, 0x800);
          bspSize.Add(bspBuffer.Length - previousLength);
          bspBuffer.Position = previousLength = bspBuffer.Length;
        }
      }
      int sbspCount = 0;
      ArrayList bspMagic = new ArrayList();
      for (int x = 0; x < count; x++)
        if (tags.GetClass(x) == "sbsp")
          bspMagic.Add((uint)((uint)BspMagic.PC - (int)bspSize[sbspCount++]));
      #endregion

      #region Update all bsp related pointers with newly acquired bsp memory offset information.
      // Get an array of bsp data from the scenario
      Xpe scnr = structs["scnr"];
      Tag scenario = tags[0];
      Array bspBlockData = scenario["structure bsps"] as Array;
      Xpe.Field bspBlockField = scnr.FieldByName("structure bsps");
      for (int x = 0; x < sbspCount; x++)
      {
        // Fix pointers
        int bspMatListX = (int)bspMaterialList[x];
        uint bspMagicX = (uint)((uint)bspMagic[x] - (uint)bspOffset[x]);
        PointerList pl = (PointerList)bspPointers[x];
        for (int y = 0; y < pl.Count; y++)
        {
          bspBuffer.Position = (int)pl.Locations[y];
          bspBuffer.Write(bspMagicX + (uint)pl.Destinations[y]);
        }

        // Write header
        bspBuffer.Position = (int)(uint)bspOffset[x];
        bspBuffer.Write(bspMagicX + (uint)bspMetaOffset[x]);
        bspBuffer.Write(0);
        bspBuffer.Write(0);
        bspBuffer.Write(0);
        bspBuffer.Write(0); // damn, how easy is that?

        // Write to memory the scenario bsp data
        bspBlockData.SetValue((uint)bspOffset[x] + 0x800, x, bspBlockField["bsp offset"]);
        bspBlockData.SetValue(bspSize[x], x, bspBlockField["bsp size"]);
        bspBlockData.SetValue(bspMagicX + (uint)bspOffset[x], x, bspBlockField["bsp magic"]);
      }
      // That was relatively painless... Right?
      #endregion

      #region Start building the data table and metadata buffer.
      // Note: at this point, anything to do with bsp should be done
      int currentModelIndex = 0;
      local.Length = Compression.Round(0x800 + bspBuffer.Length, 0x200);
      uint[] metaOffsets = new uint[count];

      for (int x = 0; x < count; x++)
      {
        Xpe bitm = structs["bitm"];
        Xpe snd = structs["snd!"];
        Xpe mode = structs["mode"];
        Xpe mod2 = structs["mod2"];

        if (tags.GetClass(x) == "sbsp")
        {
          metaOffsets[x] = 0;
          continue;
        }

        metaBuffer.Position = metaBuffer.Length = Compression.Round(metaBuffer.Length, 4);
        metaOffsets[x] = (uint)metaBuffer.Position;
        if (tags.GetClass(x) == "bitm")
        {
          Array pixelData = tags[x]["processed pixel data"] as Array;
          int pixelLength = pixelData.GetLength(0);
          //local.Position = local.Length = Compression.Round(local.Length, 0x200);
          int myPixelOffset = 0;
          bool bInternal = false;
          try
          {
            myPixelOffset = bitmapPCI.GetOffset(tags.GetName(x), pixelData as byte[]);
            tags[x].HasSharedData = true;
          }
          catch (ObjectNotInPackCacheException ex)
          {
            Output.Write(OutputTypes.Debug, ex.Message + " Attempting to write internally...");
            local.Position = local.Length = Compression.Round(local.Length, 0x4);
            myPixelOffset = local.Position;
            local.Write(pixelData as byte[]);
            bInternal = true;
            tags[x].HasSharedData = false;
          }
          int[] pixelOffset = new int[1] { myPixelOffset };

          // Swizzle the texture if necessary
          /*Array bitmaps = tags[x]["bitmaps"] as Array; // halo pc does not use swizzling in this sense
          int bmc = bitmaps.GetLength(0);
          for (int b = 0; b < bmc; b++)
          {
            byte tflags = (byte)(short)bitmaps.GetValue(b, 6);
            if ((tflags & 8) > 0)
              continue;
            short tformat = (short)bitmaps.GetValue(b, 5);
            if ((tformat > 13 && tformat < 17) || tformat == 9)
              continue;
            int sptOffset = (int)bitmaps.GetValue(b, 10);
            pixelData = Swizzler.Swizzle(pixelData as byte[], sptOffset, (short)bitmaps.GetValue(b, 1), (short)bitmaps.GetValue(b, 2), (short)bitmaps.GetValue(b, 3), BitmapPixel.BitmapBpp(tformat), false) as Array;
            bitmaps.SetValue((short)(tflags | 0x88), b, 6); // TODO: Figure out what a lot of these are...
            bitmaps.SetValue(new byte[4] { 0xff, 0xff, 0xff, 0xff }, b, 12);
            bitmaps.SetValue(new byte[8] { 0x00, 0x00, 0x00, 0x00, 0x40, 0x00, 0x27, 0x02 }, b, 13);
          }*/

          // set the internal/external flag
          Array bitmaps = tags[x]["bitmaps"] as Array;
          int bmc = bitmaps.GetLength(0);
          for (int currentBitmapBlock = 0; currentBitmapBlock < bmc; currentBitmapBlock++)
          {
            short tflags = (short)bitmaps.GetValue(currentBitmapBlock, 6);
            if (bInternal)
              bitmaps.SetValue(tflags & ~0x100, currentBitmapBlock, 6);
            else
              bitmaps.SetValue(tflags | 0x100, currentBitmapBlock, 6);
          }

          /*for (int d = 0; d < pixelLength; d++)
            local.Write((byte)pixelData.GetValue(d));*/ // we already wrote this, if necessary
          tags[x].Write(metaBuffer, memory, tags, pixelOffset);
        }
        else if (tags.GetClass(x) == "snd!")
        {
          Array pitchRanges = tags[x]["pitch ranges#pitch ranges allow multiple samples to represent the same sound at different pitches"] as Array;
          int pitchRangeCount = pitchRanges.GetLength(0);
          Xpe.Field pitchRange = snd.FieldByName("pitch ranges#pitch ranges allow multiple samples to represent the same sound at different pitches");
          int totalPermutationCount = 0;

          for (int u = 0; u < pitchRangeCount; u++)
          {
            Array permutations = pitchRanges.GetValue(u, pitchRange["permutations#permutations represent equivalent variations of this sound."]) as Array;
            totalPermutationCount += permutations.GetLength(0);
          }

          int[] soundAux = new int[totalPermutationCount * 2];
          totalPermutationCount = 0;

          MemoryStream ms = new MemoryStream();
          int soundDataOffset = 0;
          for (int u = 0; u < pitchRangeCount; u++)
          {
            Array permutations = pitchRanges.GetValue(u, pitchRange["permutations#permutations represent equivalent variations of this sound."]) as Array;
            int permutationCount = permutations.GetLength(0);
            Xpe.Field permutation = pitchRange.FieldByName("permutations#permutations represent equivalent variations of this sound.");

            for (int v = 0; v < permutationCount; v++)
            {
              //local.Position = local.Length = Compression.Round(local.Length, 0x200);

              Array samples = permutations.GetValue(v, permutation["samples#sampled sound data"]) as Array;
              int byteCount = samples.GetLength(0);
              soundAux[totalPermutationCount++] = byteCount;
              soundAux[totalPermutationCount++] = soundDataOffset;
              soundDataOffset += byteCount;
              ms.Write(samples as byte[], 0, byteCount);
            }
          }

          int mySoundOffset = 0;
          try
          {
            mySoundOffset = soundPCI.GetOffset(tags.GetName(x), ms.ToArray());
            tags[x].HasSharedData = true;
          }
          catch (ObjectNotInPackCacheException ex)
          {
            Output.Write(OutputTypes.Debug, ex.Message + " Attempting to write internally...");
            local.Position = local.Length = Compression.Round(local.Length, 0x4);
            mySoundOffset = local.Position;
            local.Write(ms.ToArray());
            tags[x].HasSharedData = false;
          }

          for (int u = 1; u < soundAux.Length; u += 2)
            soundAux[u] += mySoundOffset;
          ms.Close();

          tags[x].Write(metaBuffer, memory, tags, soundAux);
        }
        else if (tags.GetClass(x) == "mode" || tags.GetClass(x) == "mod2")
        {
          Xpe mXpe = null;
          if (tags.GetClass(x) == "mode")
            mXpe = mode;
          else
            mXpe = mod2;

          Array geometries = tags[x]["geometries"] as Array;
          int geometryCount = geometries.GetLength(0);
          Xpe.Field geometry = mXpe.FieldByName("geometries");
          int totalPartCount = 0;

          for (int u = 0; u < geometryCount; u++)
          {
            Array parts = geometries.GetValue(u, geometry["parts"]) as Array;
            totalPartCount += parts.GetLength(0);
          }

          int[] modelAux = new int[totalPartCount * 5];
          totalPartCount = 0;

          for (int u = 0; u < geometryCount; u++)
          {
            Array parts = geometries.GetValue(u, geometry["parts"]) as Array;
            int partCount = parts.GetLength(0);
            Xpe.Field part = geometry.FieldByName("parts");

            for (int v = 0; v < partCount; v++)
            {
              modelAux[totalPartCount++] = (int)indexCounts[currentModelIndex];
              modelAux[totalPartCount++] = Tag.ToSignedByReference((uint)indexOffsets[currentModelIndex]);
              modelAux[totalPartCount++] = (int)vertexCounts[currentModelIndex];
              modelAux[totalPartCount++] = Tag.ToSignedByReference((uint)vertexOffsets[currentModelIndex]);
              modelAux[totalPartCount++] = Tag.ToSignedByReference((uint)indexOffsets[currentModelIndex++]);
            }
          }

          tags[x].Write(metaBuffer, memory, tags, modelAux);
        }
        else
        {
          predictor.GeneratePRs(tags[x]);
          tags[x].Write(metaBuffer, memory, tags, null);
        }
      }
      #endregion

      #region Finish the object index.
      indexBuffer.Position = 16;
      indexBuffer.Write(vertexOffsets.Count);
      indexBuffer.Write((uint)(local.Length));
      indexBuffer.Write(indexOffsets.Count);
      indexBuffer.Write((uint)(totalVertexBufferLength));
      indexBuffer.Write((int)(totalIndexBufferLength + totalVertexBufferLength));

      indexBuffer.Position = (int)headerSize;
      for (int x = 0; x < count; x++)
      {
        Xpe tagXpe = tags[x].Xpe;
        if (tagXpe.FourCC == "mode")
          indexBuffer.WriteFourCC("mod2");
        else
          indexBuffer.WriteFourCC(tagXpe.FourCC);
        indexBuffer.WriteFourCC(tagXpe.ParentFourCC);
        indexBuffer.WriteFourCC(tagXpe.GrandparentFourCC);
        indexBuffer.Write(tags.GetID(x));
        indexBuffer.Write(stringOffsets[x]);
        if (tagXpe.FourCC == "sbsp")
          indexBuffer.Write(0);
        else
          indexBuffer.Write((uint)(metaOffsets[x] + memory));
        indexBuffer.Write(0);
        indexBuffer.Write(0);
      }
      #endregion

      #region Write the map header.
      header.Length = 0x800;
      header.Position = 0;
      header.Write(0x68656164); // 'head'
      header.Write((int)MapFormat.PC);
      header.Write(local.Length + indexBuffer.Length + modelVertexBuffer.Length + modelIndexBuffer.Length + metaBuffer.Length);
      header.Write(0);
      header.Write(local.Length + modelVertexBuffer.Length + modelIndexBuffer.Length);
      header.Write(indexBuffer.Length /*+ modelVertexBuffer.Length + modelIndexBuffer.Length*/ + metaBuffer.Length);
      header.Write(0);
      header.Write(0);
      header.Write(name, false);
      header.Position = 0x40;
      header.Write(MapBuildVersion.PC, false);
      header.Position = 0x60;
      header.Write((int)usage);
      for (int x = 0; x < 486; x++)
        header.Write(0);
      header.Write(0x666f6f74); // 'foot'
      #endregion

      #region Assemble map file from buffers.
      local.Position = 0;
      local.Write((header.BaseStream as MemoryStream).ToArray());
      header.Close();
      local.Write((bspBuffer.BaseStream as MemoryStream).ToArray());
      bspBuffer.Close();
      local.Position = local.Length;
      local.Write((modelVertexBuffer.BaseStream as MemoryStream).ToArray());
      modelVertexBuffer.Close();
      local.Write((modelIndexBuffer.BaseStream as MemoryStream).ToArray());
      modelIndexBuffer.Close();
      local.Write((indexBuffer.BaseStream as MemoryStream).ToArray());
      indexBuffer.Close();
      local.Write((metaBuffer.BaseStream as MemoryStream).ToArray());
      metaBuffer.Close();
      GC.Collect();
      #endregion
    }
  }
}
