using System;
using System.Collections;
using System.Text;
using System.IO;
using Interfaces;
using Interfaces.IO;
using Games.Halo.Compiler.XPE;
using Interfaces.Pool;
using Games.Halo.Platforms.Shared;
using Interfaces.Textures;

namespace Games.Halo.Compiler
{
  /// <summary>
  /// Represents a file consisting of metadata and optionally a header.
  /// </summary>
  public class Tag
  {
    private Xpe xpe;
    private int offset;
    private Array values;
    private EndianReader er;
    private int typeCounter = 0;
    private bool hasSpecialData = false;
    private string name = null;
    private object reservedTypeData = null;
    private static ByteOrder readOrder = ByteOrder.LittleEndian;
    private static ByteOrder writeOrder = ByteOrder.LittleEndian;

    public class DataContainer
    {
      public int variable;
      public byte[] data;

      public DataContainer(int var, byte[] dat)
      {
        variable = var;
        data = dat;
      }
    }

    public Tag(string iname, string directory, TagLibrary lib)
    {
      name = iname;
      er = new EndianReader(new FileStream(name, FileMode.Open, FileAccess.Read, FileShare.Read), readOrder);
      ReadFromTagFile(directory, Path.GetFileName(name), lib);
      er.Close();
    }

    public Tag(string iname, ILibrary fileLib, TagLibrary lib)
    {
      name = iname;
      TagFile tf = new TagFile(new MemoryStream(fileLib.ReadFile(name)));
      xpe = lib.CXPE[tf.Type];
      er = new EndianReader(new MemoryStream(tf.GetBinary(tf.HeadRevision)), readOrder);
      ReadFromTagStream(fileLib, lib);
      er.Close();
    }

    public Tag(EndianReader inEr, string iname, string type, uint magic, TagLibrary lib)
    {
      er = inEr;
      name = iname;
      ReadFromMapFile(type, name, lib, magic);
    }

    public bool HasSharedData
    {
      get
      { return hasSpecialData; }
      set
      { hasSpecialData = value; }
    }

    public object this[string name]
    {
      get
      {
        Xpe.Field[] children = xpe.Children;
        for (int x = 0; x < children.Length; x++)
          if (children[x].Name == name)
            return values.GetValue(x);
        return null;
      }
      set
      {
        Xpe.Field[] children = xpe.Children;
        for (int x = 0; x < children.Length; x++)
        {
          if (children[x].Name == name)
          {
            values.SetValue(value, x);
            return;
          }
        }
      }
    }

    public void Write(string filename, TagLibrary lib)
    {
      EndianWriter ew = new EndianWriter(new FileStream(filename, FileMode.Create, FileAccess.Write, FileShare.None), writeOrder);

      typeCounter = 0;
      ew.Position = 0;
      WriteHeader(ew);
      int privateOffset = ew.Position;
      uint absoluteEnd = (uint)xpe.HeaderLength + (uint)privateOffset;
      Xpe.Field[] children = xpe.Children;
      ew.Length += xpe.HeaderLength;
      for (int x = 0; x < children.Length; x++)
        RecursiveWriteFile(ew, children[x], values, -1, x, lib, privateOffset, ref absoluteEnd);
      ew.Close(); ew = null;
    }

    public MemoryStream GetStream(TagLibrary lib, bool writeHeader)
    {
      EndianWriter ew = new EndianWriter(new MemoryStream(), writeOrder);

      typeCounter = 0;
      ew.Position = 0;
      if(writeHeader)
        WriteHeader(ew);
      int privateOffset = ew.Position;
      uint absoluteEnd = (uint)xpe.HeaderLength + (uint)privateOffset;
      Xpe.Field[] children = xpe.Children;
      ew.Length += xpe.HeaderLength;
      for (int x = 0; x < children.Length; x++)
        RecursiveWriteFile(ew, children[x], values, -1, x, lib, privateOffset, ref absoluteEnd);

      return ew.BaseStream as MemoryStream;
    }

    private void WriteHeader(EndianWriter ew)
    {
      for (sbyte x = 0; x < 9; x++)
        ew.Write(0);
      ew.WriteFourCC(xpe.FourCC);
      ew.Write(0);
      ew.Write(64);
      ew.Write(0);
      ew.Write(0);
      ew.Write(xpe.Version);
      ew.Write((short)255);
      ew.Write(0x626c616d); // 'blam'
    }

    public void Write(EndianWriter ew, uint memory, TagLibrary lib, int[] aux)
    {
      typeCounter = 0;
      int privateOffset = ew.Position;
      uint absoluteEnd = (uint)xpe.HeaderLength + (uint)privateOffset;
      Xpe.Field[] children = xpe.Children;
      ew.Length += xpe.HeaderLength;
      for (int x = 0; x < children.Length; x++)
        RecursiveWriteMap(ew, children[x], values, -1, x, lib, privateOffset, ref absoluteEnd, aux, memory);
    }

    public void Write(EndianWriter ew, TagLibrary lib, ArrayList pointers, ArrayList destinations, int[] aux)
    {
      typeCounter = 0;
      int privateOffset = ew.Position;
      uint absoluteEnd = (uint)xpe.HeaderLength + (uint)privateOffset;
      Xpe.Field[] children = xpe.Children;
      ew.Length += xpe.HeaderLength;
      for (int x = 0; x < children.Length; x++)
        RecursiveWriteMap(ew, children[x], values, -1, x, lib, privateOffset, ref absoluteEnd, aux, pointers, destinations);
    }

    private void ReadFromTagStream(ILibrary fileLib, TagLibrary lib)
    {
      // Read all dependencies for the tag; ignore other fields
      int absoluteEnd = xpe.HeaderLength + offset;
      Xpe.Field[] fields = xpe.Children;
      values = Array.CreateInstance(typeof(object), xpe.Children.Length);
      for (int x = 0; x < fields.Length; x++)
        values.SetValue(RecursiveReadStream(fields[x], lib, fileLib, offset, ref absoluteEnd), x);
    }

    private void ReadFromTagFile(string directory, string filename, TagLibrary lib)
    {
      // Set the offset to the length of the header, 64
      offset = 0x40;
      // Read in from the header the type of tag that this is
      er.Position = 0x24;
      string type = er.ReadFourCC();
      xpe = lib.CXPE[type];
      // Read in from the header this tag's version, to check with the internal directory
      er.Position = 0x38;
      short version = er.ReadInt16();
      if (version != xpe.Version)
        throw new Exception("Tag version read was not the version expected.\nFile: " + filename + "\nVersion Expected: " + Convert.ToString(xpe.Version, 10) + "\nVersion Read: " + Convert.ToString(version, 10));

      // Read all dependencies for the tag; ignore other fields
      int absoluteEnd = offset + xpe.HeaderLength;
      Xpe.Field[] fields = xpe.Children;
      values = Array.CreateInstance(typeof(object), xpe.Children.Length);
      for (int x = 0; x < fields.Length; x++)
        values.SetValue(RecursiveReadFile(fields[x], lib, directory, offset, ref absoluteEnd), x);
    }

    private void ReadFromMapFile(string type, string name, TagLibrary lib, uint magic)
    {
      // Set the offset to the offset of the tag
      offset = er.Position;
      xpe = lib.CXPE[type];

      // Prepare for a model data influx
      if (type == "mode" || type == "mod2")
        reservedTypeData = new ArrayList();

      // Read all dependencies for the tag; ignore other fields
      int absoluteEnd = offset + xpe.HeaderLength;
      Xpe.Field[] fields = xpe.Children;
      values = Array.CreateInstance(typeof(object), xpe.Children.Length);
      for (int x = 0; x < fields.Length; x++)
        values.SetValue(RecursiveReadMap(fields[x], lib, offset, magic), x);

      // Take care of any unfinished raw data business
      switch (type)
      {
        case "sbsp":
          if (lib.MapFormat == MapFormat.Xbox) // we have decompressing to do
          {
            Array lightmaps = values.GetValue(24) as Array;
            for (int j = 0; j < lightmaps.GetLength(0); j++)
            {
              Array materials = lightmaps.GetValue(j, 3) as Array;
              for (int k = 0; k < materials.GetLength(0); k++)
              {
                int vertexCount = (int)materials.GetValue(k, xpe.FieldByName("structure lightmaps").FieldByName("structure materials")["vertex buffer"]);
                int lightmapVertexCount = (int)materials.GetValue(k, xpe.FieldByName("structure lightmaps").FieldByName("structure materials")["lightmap buffer"]);
                DataContainer data = materials.GetValue(k, xpe.FieldByName("structure lightmaps").FieldByName("structure materials")["compressed vertices"]) as DataContainer;
                DataContainer resultData = materials.GetValue(k, xpe.FieldByName("structure lightmaps").FieldByName("structure materials")["uncompressed vertices"]) as DataContainer;
                BinaryReader memReader = new BinaryReader(new MemoryStream(data.data, false));
                BinaryWriter memWriter = new BinaryWriter(new MemoryStream());
                for (int i = 0; i < vertexCount; i++)
                {
                  memWriter.Write(memReader.ReadSingle()); // x
                  memWriter.Write(memReader.ReadSingle()); // y
                  memWriter.Write(memReader.ReadSingle()); // z
                  Array normal = Compression.Decompress111110(memReader.ReadUInt32());
                  memWriter.Write((float)normal.GetValue(0));
                  memWriter.Write((float)normal.GetValue(1));
                  memWriter.Write((float)normal.GetValue(2));
                  Array binormal = Compression.Decompress111110(memReader.ReadUInt32());
                  memWriter.Write((float)binormal.GetValue(0));
                  memWriter.Write((float)binormal.GetValue(1));
                  memWriter.Write((float)binormal.GetValue(2));
                  Array tangent = Compression.Decompress111110(memReader.ReadUInt32());
                  memWriter.Write((float)tangent.GetValue(0));
                  memWriter.Write((float)tangent.GetValue(1));
                  memWriter.Write((float)tangent.GetValue(2));
                  memWriter.Write(memReader.ReadSingle()); // u
                  memWriter.Write(memReader.ReadSingle()); // v
                }
                for (int i = 0; i < lightmapVertexCount; i++)
                {
                  Array normal = Compression.Decompress111110(memReader.ReadUInt32());
                  memWriter.Write((float)normal.GetValue(0));
                  memWriter.Write((float)normal.GetValue(1));
                  memWriter.Write((float)normal.GetValue(2));
                  memWriter.Write(Compression.DecompressHalf16(memReader.ReadUInt16())); // u
                  memWriter.Write(Compression.DecompressHalf16(memReader.ReadUInt16())); // v
                }
                resultData.data = (memWriter.BaseStream as MemoryStream).ToArray();
              }
            }
          }
          else // we have compression to do
          {
            Array lightmaps = values.GetValue(24) as Array;
            for(int j = 0; j < lightmaps.GetLength(0); j++)
            {
              Array materials = lightmaps.GetValue(j, 3) as Array;
              for(int k = 0; k < materials.GetLength(0); k++)
              {
                int vertexCount = (int)materials.GetValue(k, xpe.FieldByName("structure lightmaps").FieldByName("structure materials")["vertex buffer"]);
                int lightmapVertexCount = (int)materials.GetValue(k, xpe.FieldByName("structure lightmaps").FieldByName("structure materials")["lightmap buffer"]);
                DataContainer data = materials.GetValue(k, xpe.FieldByName("structure lightmaps").FieldByName("structure materials")["uncompressed vertices"]) as DataContainer;
                DataContainer resultData = materials.GetValue(k, xpe.FieldByName("structure lightmaps").FieldByName("structure materials")["compressed vertices"]) as DataContainer;
                BinaryReader memReader = new BinaryReader(new MemoryStream(data.data, false));
                BinaryWriter memWriter = new BinaryWriter(new MemoryStream());
                for (int i = 0; i < vertexCount; i++)
                {
                  memWriter.Write(memReader.ReadSingle()); // x
                  memWriter.Write(memReader.ReadSingle()); // y
                  memWriter.Write(memReader.ReadSingle()); // z
                  Array normal = Array.CreateInstance(typeof(float), 3);
                  normal.SetValue(memReader.ReadSingle(), 0);
                  normal.SetValue(memReader.ReadSingle(), 1);
                  normal.SetValue(memReader.ReadSingle(), 2);
                  memWriter.Write(Compression.Compress111110(normal));
                  Array binormal = Array.CreateInstance(typeof(float), 3);
                  binormal.SetValue(memReader.ReadSingle(), 0);
                  binormal.SetValue(memReader.ReadSingle(), 1);
                  binormal.SetValue(memReader.ReadSingle(), 2);
                  memWriter.Write(Compression.Compress111110(binormal));
                  Array tangent = Array.CreateInstance(typeof(float), 3);
                  tangent.SetValue(memReader.ReadSingle(), 0);
                  tangent.SetValue(memReader.ReadSingle(), 1);
                  tangent.SetValue(memReader.ReadSingle(), 2);
                  memWriter.Write(Compression.Compress111110(tangent));
                  memWriter.Write(memReader.ReadSingle()); // u
                  memWriter.Write(memReader.ReadSingle()); // v
                }
                for (int i = 0; i < lightmapVertexCount; i++)
                {
                  Array normal = Array.CreateInstance(typeof(float), 3);
                  normal.SetValue(memReader.ReadSingle(), 0);
                  normal.SetValue(memReader.ReadSingle(), 1);
                  normal.SetValue(memReader.ReadSingle(), 2);
                  memWriter.Write(Compression.Compress111110(normal));
                  memWriter.Write(Compression.CompressHalf16(memReader.ReadSingle())); // u
                  memWriter.Write(Compression.CompressHalf16(memReader.ReadSingle())); // v
                }
                resultData.data = (memWriter.BaseStream as MemoryStream).ToArray();
              }
            }
          }
          return;
        case "bitm":
          Array bitmaps = this["bitmaps"] as Array;
          int bmc = bitmaps.GetLength(0);
          int[] pixelOffsets = new int[bmc];
          int cumulativeSize = 0;

          if (lib.MapFormat == MapFormat.PC)
          {
            lib.Bitmaps.Position = typeCounter;
            MemoryStream pixelDataStream = new MemoryStream();
            for (int b = 0; b < bmc; b++)
            {
              pixelOffsets[b] = cumulativeSize;
              int loopSize = CalculateBitmapSize((short)bitmaps.GetValue(b, 1), (short)bitmaps.GetValue(b, 2), (short)bitmaps.GetValue(b, 3), (short)bitmaps.GetValue(b, 4), (short)bitmaps.GetValue(b, 5), (short)bitmaps.GetValue(b, 8));
              pixelDataStream.Write(lib.Bitmaps.ReadBytes(loopSize /*Convert.ToInt32(reservedTypeData)*/), 0, loopSize);
              cumulativeSize += loopSize;
            }
            byte[] pixelData = pixelDataStream.ToArray();
            values.SetValue(pixelData, xpe.IndexByName("processed pixel data"));
            typeCounter = 0;
            reservedTypeData = null;
          }
          else
          {
            er.Position = typeCounter;
            MemoryStream pixelDataStream = new MemoryStream();
            for(int b = 0; b < bmc; b++)
            {
              pixelOffsets[b] = cumulativeSize;
              int loopSize = CalculateBitmapSize((short)bitmaps.GetValue(b, 1), (short)bitmaps.GetValue(b, 2), (short)bitmaps.GetValue(b, 3), (short)bitmaps.GetValue(b, 4), (short)bitmaps.GetValue(b, 5), (short)bitmaps.GetValue(b, 8));
              int cubeMapSize = 6 * Compression.Round(CalculateBitmapSize((short)bitmaps.GetValue(b, 1), (short)bitmaps.GetValue(b, 2), (short)bitmaps.GetValue(b, 3), 0, (short)bitmaps.GetValue(b, 5), (short)bitmaps.GetValue(b, 8)), 0x80);
              if (lib.MapFormat == MapFormat.Xbox && (short)bitmaps.GetValue(b, 4) == 2)
                pixelDataStream.Write(UnpadCubeTexture(er.ReadBytes(/*Convert.ToInt32(reservedTypeData)*/cubeMapSize), 0, (short)bitmaps.GetValue(b, 1), (short)bitmaps.GetValue(b, 2), (short)bitmaps.GetValue(b, 8), BitmapPixel.BitmapBpp((short)bitmaps.GetValue(b, 5))), 0, loopSize);
              else
                pixelDataStream.Write(er.ReadBytes(loopSize /*Convert.ToInt32(reservedTypeData)*/), 0, loopSize);
              cumulativeSize += loopSize;
              if(lib.MapFormat == MapFormat.Xbox)
                er.Position = Compression.Round(er.Position, 0x200);
            }
            byte[] pixelData = pixelDataStream.ToArray();
            values.SetValue(pixelData, xpe.IndexByName("processed pixel data"));
            typeCounter = 0;
            reservedTypeData = null;
          }

          Array swizzleData = this["processed pixel data"] as Array;
          for (int b = 0; b < bmc; b++)
          {
            bitmaps.SetValue(pixelOffsets[b], b, 10);
            byte tflags = (byte)(short)bitmaps.GetValue(b, 6);
            short tformat = (short)bitmaps.GetValue(b, 5);
            if ((tformat > 13 && tformat < 17) || tformat == 9)
              continue;
            if ((tflags & 8) > 0)
            {
              int mipPixelOffset = pixelOffsets[b];
              for (short face = 0; face < ((short)bitmaps.GetValue(b, 4) == 2 ? 6 : 1); face++)
              {
                for (short m = 0; m <= (short)bitmaps.GetValue(b, 8); m++)
                {
                  swizzleData = Swizzler.Swizzle(swizzleData as byte[], mipPixelOffset, (short)bitmaps.GetValue(b, 1) / (short)Math.Pow(2, m), (short)bitmaps.GetValue(b, 2) / (short)Math.Pow(2, m), (short)bitmaps.GetValue(b, 3) / (short)Math.Pow(2, m), BitmapPixel.BitmapBpp(tformat), true) as Array;
                  int mipPixelLength = ((short)bitmaps.GetValue(b, 1) / (short)Math.Pow(2, m) <= 0) ? 1 : (short)bitmaps.GetValue(b, 1) / (short)Math.Pow(2, m);
                  mipPixelLength *= ((short)bitmaps.GetValue(b, 2) / (short)Math.Pow(2, m) <= 0) ? 1 : (short)bitmaps.GetValue(b, 2) / (short)Math.Pow(2, m);
                  mipPixelLength *= ((short)bitmaps.GetValue(b, 3) / (short)Math.Pow(2, m) <= 0) ? 1 : (short)bitmaps.GetValue(b, 3) / (short)Math.Pow(2, m);
                  mipPixelLength *= BitmapPixel.BitmapBpp(tformat);
                  mipPixelLength /= 8;
                  mipPixelOffset += mipPixelLength;
                }
              }
              bitmaps.SetValue((short)(tflags & ~0x8), b, 6);
            }
          }

          if (lib.MapFormat == MapFormat.Xbox) // xbox arranges cube faces differently than other formats (face 1 and all mipmaps, face 2 and all mipmaps, etc); we need to standardize it
          {
            Array cubeRemap = Array.CreateInstance(typeof(byte), swizzleData.GetLength(0));
            bool copyBack = false;
            for (int b = 0; b < bmc; b++)
            {
              if ((short)bitmaps.GetValue(b, 4) == 2)
              {
                int mipPixelOffset = pixelOffsets[b];
                int faceSize = 0;
                short tformat = (short)bitmaps.GetValue(b, 5);
                int[] mipPixelSizes = new int[(short)bitmaps.GetValue(b, 8) + 1];
                for (short m = 0; m <= (short)bitmaps.GetValue(b, 8); m++)
                {
                  int mipPixelLength = ((short)bitmaps.GetValue(b, 1) / (short)Math.Pow(2, m) <= 0) ? 1 : (short)bitmaps.GetValue(b, 1) / (short)Math.Pow(2, m);
                  mipPixelLength *= ((short)bitmaps.GetValue(b, 2) / (short)Math.Pow(2, m) <= 0) ? 1 : (short)bitmaps.GetValue(b, 2) / (short)Math.Pow(2, m);
                  mipPixelLength *= ((short)bitmaps.GetValue(b, 3) / (short)Math.Pow(2, m) <= 0) ? 1 : (short)bitmaps.GetValue(b, 3) / (short)Math.Pow(2, m);
                  mipPixelLength *= BitmapPixel.BitmapBpp(tformat);
                  mipPixelLength /= 8;
                  mipPixelLength = Math.Max(mipPixelLength, 4);
                  mipPixelSizes[m] = mipPixelLength;
                  faceSize += mipPixelLength;
                }
                short ddsFace = 0;
                for (short face = 0; face < 6; face++)
                {
                  for (short m = 0; m <= (short)bitmaps.GetValue(b, 8); m++)
                  {
                    int priorXboxMipLength = 0;
                    for (short mipLevel = 0; mipLevel < m; mipLevel++)
                      priorXboxMipLength += mipPixelSizes[mipLevel];
                    int priorPCMipLength = mipPixelSizes[m] * ddsFace;
                    for (short mipLevel = 0; mipLevel < m; mipLevel++)
                      priorPCMipLength += mipPixelSizes[mipLevel] * 6;
                    Array.Copy(swizzleData, face * faceSize + priorXboxMipLength + mipPixelOffset, cubeRemap, priorPCMipLength + mipPixelOffset, mipPixelSizes[m]);
                  }
                  if (ddsFace == 0)
                    ddsFace = 2;
                  else if (ddsFace == 2)
                    ddsFace = 1;
                  else if (ddsFace == 1)
                    ddsFace = 3;
                  else
                    ddsFace++;
                }
                copyBack = true;
              }
            }

            if (copyBack)
              swizzleData = cubeRemap;
          }

          this["processed pixel data"] = swizzleData;

          /*if (this.name == @"effects\particles\lens flare\bitmaps\flares_generic")
          {
            ByteOrder wo = writeOrder;
            writeOrder = ByteOrder.BigEndian;
            Write(System.Windows.Forms.Application.StartupPath + "\\flares_generic.bitmap", lib);
            writeOrder = wo;
          }

          if (this.name == @"levels\a10\bitmaps\cube map pillar controls")
          {
            ByteOrder wo = writeOrder;
            writeOrder = ByteOrder.BigEndian;
            Write(System.Windows.Forms.Application.StartupPath + "\\cube map pillar controls.bitmap", lib);
            writeOrder = wo;
          }

          if (this.name == @"levels\b30\bitmaps\cube map forerunner interiors")
          {
            ByteOrder wo = writeOrder;
            writeOrder = ByteOrder.BigEndian;
            Write(System.Windows.Forms.Application.StartupPath + "\\cube map forerunner interiors.bitmap", lib);
            writeOrder = wo;
          }

          if (this.name == @"rasterizer\default 3d")
          {
            ByteOrder wo = writeOrder;
            writeOrder = ByteOrder.BigEndian;
            Write(System.Windows.Forms.Application.StartupPath + "\\default 3d.bitmap", lib);
            writeOrder = wo;
          }

          if (this.name == @"rasterizer\distance attenuation")
          {
            ByteOrder wo = writeOrder;
            writeOrder = ByteOrder.BigEndian;
            Write(System.Windows.Forms.Application.StartupPath + "\\distance attenuation.bitmap", lib);
            writeOrder = wo;
          }

          if (this.name == @"rasterizer\vector normalization")
          {
            ByteOrder wo = writeOrder;
            writeOrder = ByteOrder.BigEndian;
            Write(System.Windows.Forms.Application.StartupPath + "\\vector normalization.bitmap", lib);
            writeOrder = wo;
          }

          if (this.name == @"vehicles\banshee\bitmaps\cubemap banshee")
          {
            ByteOrder wo = writeOrder;
            writeOrder = ByteOrder.BigEndian;
            Write(System.Windows.Forms.Application.StartupPath + "\\cubemap banshee.bitmap", lib);
            writeOrder = wo;
          }*/
          return;
        case "mode":
        case "mod2":
          ArrayList modelData = reservedTypeData as ArrayList;
          Array geometries = values.GetValue(xpe.IndexByName("geometries")) as Array;
          Xpe.Field geometry = xpe.FieldByName("geometries");
          Xpe.Field part = geometry.FieldByName("parts");
          int partsIndex = geometry["parts"];
          int compressedIndex = part["compressed vertices"];
          int uncompressedIndex = part["uncompressed vertices"];
          int trianglesIndex = part["triangles"];
          int geometryCount = geometries.GetLength(0);
          int passCount = 0;

          for (int u = 0; u < geometryCount; u++)
          {
            Array parts = geometries.GetValue(u, partsIndex) as Array;
            int partCount = parts.GetLength(0);

            for (int v = 0; v < partCount; v++)
            {
              //parts.SetValue(modelData[(passCount * 2) + 1], v, uncompressedIndex);

              //parts.SetValue(Array.CreateInstance(typeof(object), 0, 9), v, uncompressedIndex);
              Array tagVertexData = modelData[(passCount * 2) + 1] as Array;
              int vertCount = tagVertexData.GetLength(0);
              Array compressedData = Array.CreateInstance(typeof(object), vertCount, 9);
              Array uncompressedData = Array.CreateInstance(typeof(object), vertCount, 9);
              for (int vertex = 0; vertex < vertCount; vertex++)
              {
                // position
                compressedData.SetValue(tagVertexData.GetValue(vertex, 0), vertex, 0);
                uncompressedData.SetValue(tagVertexData.GetValue(vertex, 0), vertex, 0);
                // tangent frame
                compressedData.SetValue(Compression.Compress111110(tagVertexData.GetValue(vertex, 1) as Array), vertex, 1);
                compressedData.SetValue(Compression.Compress111110(tagVertexData.GetValue(vertex, 2) as Array), vertex, 2);
                compressedData.SetValue(Compression.Compress111110(tagVertexData.GetValue(vertex, 3) as Array), vertex, 3);
                uncompressedData.SetValue(tagVertexData.GetValue(vertex, 1), vertex, 1);
                uncompressedData.SetValue(tagVertexData.GetValue(vertex, 2), vertex, 2);
                uncompressedData.SetValue(tagVertexData.GetValue(vertex, 3), vertex, 3);
                // texture coordinates
                compressedData.SetValue(Compression.CompressHalf16((float)tagVertexData.GetValue(vertex, 4)), vertex, 4);
                compressedData.SetValue(Compression.CompressHalf16((float)tagVertexData.GetValue(vertex, 5)), vertex, 5);
                Array uncompTextureCoords = Array.CreateInstance(typeof(object), 2);
                uncompTextureCoords.SetValue((float)tagVertexData.GetValue(vertex, 4), 0);
                uncompTextureCoords.SetValue((float)tagVertexData.GetValue(vertex, 5), 1);
                uncompressedData.SetValue(uncompTextureCoords, vertex, 4);
                // node indices
                compressedData.SetValue((byte)ToUnsignedByReference((short)tagVertexData.GetValue(vertex, 6) * 3), vertex, 6);
                compressedData.SetValue((byte)ToUnsignedByReference((short)tagVertexData.GetValue(vertex, 7) * 3), vertex, 7);
                uncompressedData.SetValue((short)tagVertexData.GetValue(vertex, 6), vertex, 5);
                uncompressedData.SetValue((short)tagVertexData.GetValue(vertex, 7), vertex, 6);
                // node weights
                compressedData.SetValue(Compression.CompressHalf16((float)tagVertexData.GetValue(vertex, 8)), vertex, 8);
                uncompressedData.SetValue((float)tagVertexData.GetValue(vertex, 8), vertex, 7);
                uncompressedData.SetValue((float)tagVertexData.GetValue(vertex, 9), vertex, 8);
              }

              parts.SetValue(compressedData, v, compressedIndex);
              parts.SetValue(uncompressedData, v, uncompressedIndex);
              parts.SetValue(modelData[(passCount++) * 2], v, trianglesIndex);
            }
          }
          reservedTypeData = null;
          return;
        default:
          return;
      }
    }

    private byte[] UnpadCubeTexture(byte[] raw, Array bitmaps)
    {
      MemoryStream memory = new MemoryStream();
      BinaryReader reader = new BinaryReader(new MemoryStream(raw));
      int cumulativeSize = 0;

      for (int b = 0; b < bitmaps.GetLength(0); b++)
      {
        if ((short)bitmaps.GetValue(b, 4) == 2)
        {
          reader.BaseStream.Position = cumulativeSize;
          int faceSize = 0;
          short tformat = (short)bitmaps.GetValue(b, 5);
          for (short m = 0; m <= (short)bitmaps.GetValue(b, 8); m++)
          {
            int mipPixelLength = ((short)bitmaps.GetValue(b, 1) / (short)Math.Pow(2, m) <= 0) ? 1 : (short)bitmaps.GetValue(b, 1) / (short)Math.Pow(2, m);
            mipPixelLength *= ((short)bitmaps.GetValue(b, 2) / (short)Math.Pow(2, m) <= 0) ? 1 : (short)bitmaps.GetValue(b, 2) / (short)Math.Pow(2, m);
            mipPixelLength *= ((short)bitmaps.GetValue(b, 3) / (short)Math.Pow(2, m) <= 0) ? 1 : (short)bitmaps.GetValue(b, 3) / (short)Math.Pow(2, m);
            mipPixelLength *= BitmapPixel.BitmapBpp(tformat);
            mipPixelLength /= 8;
            faceSize += mipPixelLength;
          }
          int cubeMapSize = Compression.Round(faceSize, 0x80) * 6;
          int trueCubeMapSize = faceSize * 6;
          memory.Write(UnpadCubeTexture(reader.ReadBytes(cubeMapSize), 0, (short)bitmaps.GetValue(b, 1), (short)bitmaps.GetValue(b, 2), (short)bitmaps.GetValue(b, 8), BitmapPixel.BitmapBpp(tformat)), 0, trueCubeMapSize);
          cumulativeSize += cubeMapSize;
        }
      }

      return memory.ToArray();
    }

    private object RecursiveReadMap(Xpe.Field field, TagLibrary lib, int absolute, uint magic)
    {
      switch (field.Type)
      {
        case Xpe.FieldType.TagReference:
          er.Position = absolute + field.Offset + 12;
          uint id = er.ReadUInt32();
          if (id == 0xffffffff)
            return -1;
          else
            return lib.IndexByID(id);

        case Xpe.FieldType.Block:
          Xpe.Field[] children = field.Children;
          er.Position = absolute + field.Offset;
          int count = er.ReadInt32();
          if (count == 0)
            return Array.CreateInstance(typeof(object), 0, children.Length);
          uint pOffset = er.ReadUInt32() - magic;
          Array values = Array.CreateInstance(typeof(object), count, children.Length);
          for (int x = 0; x < count; x++)
            for (int y = 0; y < children.Length; y++)
              values.SetValue(RecursiveReadMap(children[y], lib, (int)(pOffset + (x * field.Size)), magic), x, y);
          return values;

        case Xpe.FieldType.BitmapDataBlock:
          if (typeCounter == 0)
          {
            typeCounter = er.ReadInt32();
            reservedTypeData = er.ReadInt32();
            return 0;
          }
          else
          {
            int ret = er.ReadInt32() - typeCounter;
            reservedTypeData = (int)reservedTypeData + FeintRound(er.ReadInt32(), 0x80);
            return ret;
          }

        case Xpe.FieldType.BspVertexDataHeader:
          er.Position = absolute + field.Offset + 4;
          int val = er.ReadInt32(); // this is the count
          return val;

        case Xpe.FieldType.BspUncompressedVertexBlock:
          if (lib.MapFormat != MapFormat.Xbox)
          {
            er.Position = absolute + field.Offset;
            int byteCount = er.ReadInt32();
            er.Position += 4;
            int dword = er.ReadInt32(); // TODO: Figure out what this value is for
            er.Position = (int)(er.ReadUInt32() - magic);
            return new DataContainer(dword, er.ReadBytes(byteCount));
          }
          else
          {
            er.Position = absolute + field.Offset + 8;
            return new DataContainer(er.ReadInt32(), new byte[0]);
          }

        case Xpe.FieldType.BspCompressedVertexBlock:
          if (lib.MapFormat == MapFormat.Xbox)
          {
            er.Position = absolute + field.Offset;
            int byteCount = er.ReadInt32();
            er.Position += 4;
            int dword = er.ReadInt32(); // TODO: Figure out what this value is for
            er.Position = (int)(er.ReadUInt32() - magic);
            return new DataContainer(dword, er.ReadBytes(byteCount));
          }
          else
          {
            er.Position = absolute + field.Offset + 8;
            return new DataContainer(er.ReadInt32(), new byte[0]);
          }

        case Xpe.FieldType.Prestructure:
        case Xpe.FieldType.ScriptData:
          er.Position = absolute + field.Offset;
          int psbyteCount = er.ReadInt32();
          if (psbyteCount == 0)
            return new byte[0];
          er.Position += 8;
          uint bOffset = er.ReadUInt32() - magic;
          er.Position = (int)bOffset;
          return er.ReadBytes(psbyteCount);

        case Xpe.FieldType.ModelIndexBlock:
          ArrayList indexList = reservedTypeData as ArrayList;
          er.Position = absolute + field.Offset;
          int triCount = er.ReadInt32();
          if (triCount == 0)
            return new byte[0];
          uint triOffset = (uint)((long)er.ReadUInt32() - (lib.MapFormat == MapFormat.Xbox ? (long)magic : -(long)(lib.ModelIndexOffset + lib.ModelVertexOffset)));
          triCount += 2;
          er.Position = (int)triOffset + triCount * 2;
          if (er.ReadUInt16() == 0xffff)
            triCount += 3;
          else if (er.ReadUInt16() == 0xffff)
            triCount += 3;
          else if (er.ReadUInt16() == 0xffff)
            triCount += 3;
          er.Position = (int)triOffset;
          byte[] tris = er.ReadBytes(triCount * 2);
          Array triangles = Array.CreateInstance(typeof(short), triCount / 3, 3);
          for (int x = 0; x < triCount / 3; x++)
          {
            triangles.SetValue(BitConverter.ToInt16(tris, x * 6), x, 0);
            triangles.SetValue(BitConverter.ToInt16(tris, x * 6 + 2), x, 1);
            triangles.SetValue(BitConverter.ToInt16(tris, x * 6 + 4), x, 2);
          }
          indexList.Add(triangles);
          return new byte[0];

        case Xpe.FieldType.ModelVertexBlock:
          ArrayList vertexList = reservedTypeData as ArrayList;
          er.Position = absolute + field.Offset;
          int vertCount = er.ReadInt32();
          if (vertCount == 0)
            return new byte[0];
          er.Position = absolute + field.Offset + 12; // hack alert lolz
          uint vertOffset = (uint)((long)er.ReadUInt32() - (lib.MapFormat == MapFormat.Xbox ? (long)magic : -(long)lib.ModelVertexOffset));
          if (lib.MapFormat == MapFormat.Xbox)
          {
            er.Position = (int)vertOffset + 4;
            vertOffset = (uint)(er.ReadInt32() - magic);
          }
          er.Position = (int)vertOffset;
          byte[] verts = er.ReadBytes(vertCount * (lib.MapFormat == MapFormat.Xbox ? 32 : 68));
          Array vertices = Array.CreateInstance(typeof(object), vertCount, 10);
          if (lib.MapFormat == MapFormat.Xbox)
          {
            for (int x = 0; x < vertCount; x++)
            {
              Array vPos = Array.CreateInstance(typeof(float), 3);
              vPos.SetValue(BitConverter.ToSingle(verts, x * 32), 0);
              vPos.SetValue(BitConverter.ToSingle(verts, x * 32 + 4), 1);
              vPos.SetValue(BitConverter.ToSingle(verts, x * 32 + 8), 2);
              vertices.SetValue(vPos, x, 0);
              vertices.SetValue(Compression.Decompress111110(BitConverter.ToUInt32(verts, x * 32 + 12)), x, 1);
              vertices.SetValue(Compression.Decompress111110(BitConverter.ToUInt32(verts, x * 32 + 16)), x, 2);
              vertices.SetValue(Compression.Decompress111110(BitConverter.ToUInt32(verts, x * 32 + 20)), x, 3);
              vertices.SetValue(Compression.DecompressHalf16(BitConverter.ToUInt16(verts, x * 32 + 24)), x, 4);
              vertices.SetValue(Compression.DecompressHalf16(BitConverter.ToUInt16(verts, x * 32 + 26)), x, 5);
              vertices.SetValue((short)(verts[x * 32 + 28] / 3), x, 6);
              vertices.SetValue((short)(verts[x * 32 + 29] / 3), x, 7);
              vertices.SetValue(Compression.DecompressHalf16(BitConverter.ToUInt16(verts, x * 32 + 30)), x, 8);
              vertices.SetValue(1.0f - Compression.DecompressHalf16(BitConverter.ToUInt16(verts, x * 32 + 30)), x, 9);
            }
          }
          else
          {
            for (int x = 0; x < vertCount; x++)
            {
              // Position
              Array vPos = Array.CreateInstance(typeof(float), 3);
              vPos.SetValue(BitConverter.ToSingle(verts, x * 68), 0);
              vPos.SetValue(BitConverter.ToSingle(verts, x * 68 + 4), 1);
              vPos.SetValue(BitConverter.ToSingle(verts, x * 68 + 8), 2);
              vertices.SetValue(vPos, x, 0);
              // Normal
              Array vNormal = Array.CreateInstance(typeof(float), 3);
              vNormal.SetValue(BitConverter.ToSingle(verts, x * 68 + 12), 0);
              vNormal.SetValue(BitConverter.ToSingle(verts, x * 68 + 16), 1);
              vNormal.SetValue(BitConverter.ToSingle(verts, x * 68 + 20), 2);
              vertices.SetValue(/*Compression.Compress111110(*/vNormal/*)*/, x, 1);
              // BiNormal
              vNormal = Array.CreateInstance(typeof(float), 3);
              vNormal.SetValue(BitConverter.ToSingle(verts, x * 68 + 24), 0);
              vNormal.SetValue(BitConverter.ToSingle(verts, x * 68 + 28), 1);
              vNormal.SetValue(BitConverter.ToSingle(verts, x * 68 + 32), 2);
              vertices.SetValue(/*Compression.Compress111110(*/vNormal/*)*/, x, 2);
              // Tangent
              vNormal = Array.CreateInstance(typeof(float), 3);
              vNormal.SetValue(BitConverter.ToSingle(verts, x * 68 + 36), 0);
              vNormal.SetValue(BitConverter.ToSingle(verts, x * 68 + 40), 1);
              vNormal.SetValue(BitConverter.ToSingle(verts, x * 68 + 44), 2);
              vertices.SetValue(/*Compression.Compress111110(*/vNormal/*)*/, x, 3);
              // Texcoords
              vertices.SetValue(/*Compression.CompressHalf16(*/BitConverter.ToSingle(verts, x * 68 + 48)/*)*/, x, 4);
              vertices.SetValue(/*Compression.CompressHalf16(*/BitConverter.ToSingle(verts, x * 68 + 52)/*)*/, x, 5);
              // Node indices
              vertices.SetValue(BitConverter.ToInt16(verts, x * 68 + 56), x, 6);
              vertices.SetValue(BitConverter.ToInt16(verts, x * 68 + 58), x, 7);
              // Node weight
              vertices.SetValue(BitConverter.ToSingle(verts, x * 68 + 60), x, 8);
              vertices.SetValue(BitConverter.ToSingle(verts, x * 68 + 64), x, 9);
            }
          }
          vertexList.Add(vertices);
          return new byte[0];

        case Xpe.FieldType.BitmapPixelData: // This needs to be taken care of AFTER we go through the bitmap blocks
          return new byte[0];

        case Xpe.FieldType.SoundDataBlock:
          er.Position = absolute + field.Offset;
          int dataLen = er.ReadInt32();
          if (dataLen == 0)
            return new byte[0];
          er.Position += 4;
          int dOffset = er.ReadInt32();
          if (lib.MapFormat == MapFormat.PC)
          {
            lib.Sounds.Position = dOffset;
            return lib.Sounds.ReadBytes(dataLen);
          }
          else
          {
            er.Position = dOffset;
            return er.ReadBytes(dataLen);
          }

        case Xpe.FieldType.Char:
        case Xpe.FieldType.CharFlags:
          er.Position = absolute + field.Offset;
          return er.ReadByte();

        case Xpe.FieldType.DWordFlags:
        case Xpe.FieldType.Int1:
          er.Position = absolute + field.Offset;
          return er.ReadInt32();

        case Xpe.FieldType.WordFlags:
        case Xpe.FieldType.Enum:
        case Xpe.FieldType.Short1:
          er.Position = absolute + field.Offset;
          return er.ReadInt16();

        case Xpe.FieldType.Float1:
          er.Position = absolute + field.Offset;
          return er.ReadSingle();

        case Xpe.FieldType.Float2:
          er.Position = absolute + field.Offset;
          return new float[] { er.ReadSingle(), er.ReadSingle() };

        case Xpe.FieldType.Float3:
          er.Position = absolute + field.Offset;
          return new float[] { er.ReadSingle(), er.ReadSingle(), er.ReadSingle() };

        case Xpe.FieldType.Float4:
          er.Position = absolute + field.Offset;
          return new float[] { er.ReadSingle(), er.ReadSingle(), er.ReadSingle(), er.ReadSingle() };

        case Xpe.FieldType.Int2:
          er.Position = absolute + field.Offset;
          return new int[] { er.ReadInt32(), er.ReadInt32() };

        case Xpe.FieldType.Int3:
          er.Position = absolute + field.Offset;
          return new int[] { er.ReadInt32(), er.ReadInt32(), er.ReadInt32() };

        case Xpe.FieldType.Int4:
          er.Position = absolute + field.Offset;
          return new int[] { er.ReadInt32(), er.ReadInt32(), er.ReadInt32(), er.ReadInt32() };

        case Xpe.FieldType.Short2:
          er.Position = absolute + field.Offset;
          return new short[] { er.ReadInt16(), er.ReadInt16() };

        case Xpe.FieldType.Short3:
          er.Position = absolute + field.Offset;
          return new short[] { er.ReadInt16(), er.ReadInt16(), er.ReadInt16() };

        case Xpe.FieldType.Short4:
          er.Position = absolute + field.Offset;
          return new short[] { er.ReadInt16(), er.ReadInt16(), er.ReadInt16(), er.ReadInt16() };

        case Xpe.FieldType.String:
          er.Position = absolute + field.Offset;
          return er.ReadString(32);

        case Xpe.FieldType.Padding:
          er.Position = absolute + field.Offset;
          return er.ReadBytes(field.Size);

        default:
          return null;
      }
    }

    private object RecursiveReadStream(Xpe.Field field, TagLibrary lib, ILibrary fileLib, int absolute, ref int absoluteLastEnd)
    {
      switch (field.Type)
      {
        case Xpe.FieldType.TagReference:
          er.Position = absolute + field.Offset;
          string type = er.ReadFourCC();
          er.Position += 4;
          int strLen = er.ReadInt32();
          if (strLen == 0)
            return -1;
          er.Position = absoluteLastEnd;
          string name = er.ReadString(strLen);
          absoluteLastEnd += strLen + 1;
          return lib.GetDependencyTag(name, type, fileLib);

        case Xpe.FieldType.Block:
          er.Position = absolute + field.Offset;
          int count = er.ReadInt32();
          int prevEnd = absoluteLastEnd;
          absoluteLastEnd += count * field.Size;
          Xpe.Field[] children = field.Children;
          Array values = Array.CreateInstance(typeof(object), count, children.Length);
          for (int x = 0; x < count; x++)
            for (int y = 0; y < children.Length; y++)
              values.SetValue(RecursiveReadStream(children[y], lib, fileLib, prevEnd + (x * field.Size), ref absoluteLastEnd), x, y);
          return values;

        case Xpe.FieldType.BitmapPixelData:
        case Xpe.FieldType.ModelIndexBlock:
        case Xpe.FieldType.ModelVertexBlock:
        case Xpe.FieldType.Prestructure:
        case Xpe.FieldType.ScriptData:
        case Xpe.FieldType.SoundDataBlock:
          er.Position = absolute + field.Offset;
          int byteCount = er.ReadInt32();
          er.Position = absoluteLastEnd;
          absoluteLastEnd += byteCount;
          return er.ReadBytes(byteCount);

        case Xpe.FieldType.BspCompressedVertexBlock:
        case Xpe.FieldType.BspUncompressedVertexBlock:
          er.Position = absolute + field.Offset;
          int dbyteCount = er.ReadInt32();
          er.Position += 4;
          int dword = er.ReadInt32(); // TODO: Figure out what this value is for
          er.Position = absoluteLastEnd;
          absoluteLastEnd += dbyteCount;
          return new DataContainer(dword, er.ReadBytes(dbyteCount));

        case Xpe.FieldType.BitmapDataBlock:
          return er.ReadInt32();

        case Xpe.FieldType.Char:
        case Xpe.FieldType.CharFlags:
          er.Position = absolute + field.Offset;
          return er.ReadByte();

        case Xpe.FieldType.DWordFlags:
        case Xpe.FieldType.Int1:
          er.Position = absolute + field.Offset;
          return er.ReadInt32();

        case Xpe.FieldType.WordFlags:
        case Xpe.FieldType.Enum:
        case Xpe.FieldType.Short1:
          er.Position = absolute + field.Offset;
          return er.ReadInt16();

        case Xpe.FieldType.Float1:
          er.Position = absolute + field.Offset;
          return er.ReadSingle();

        case Xpe.FieldType.Float2:
          er.Position = absolute + field.Offset;
          return new float[] { er.ReadSingle(), er.ReadSingle() };

        case Xpe.FieldType.Float3:
          er.Position = absolute + field.Offset;
          return new float[] { er.ReadSingle(), er.ReadSingle(), er.ReadSingle() };

        case Xpe.FieldType.Float4:
          er.Position = absolute + field.Offset;
          return new float[] { er.ReadSingle(), er.ReadSingle(), er.ReadSingle(), er.ReadSingle() };

        case Xpe.FieldType.Int2:
          er.Position = absolute + field.Offset;
          return new int[] { er.ReadInt32(), er.ReadInt32() };

        case Xpe.FieldType.Int3:
          er.Position = absolute + field.Offset;
          return new int[] { er.ReadInt32(), er.ReadInt32(), er.ReadInt32() };

        case Xpe.FieldType.Int4:
          er.Position = absolute + field.Offset;
          return new int[] { er.ReadInt32(), er.ReadInt32(), er.ReadInt32(), er.ReadInt32() };

        case Xpe.FieldType.Short2:
          er.Position = absolute + field.Offset;
          return new short[] { er.ReadInt16(), er.ReadInt16() };

        case Xpe.FieldType.Short3:
          er.Position = absolute + field.Offset;
          return new short[] { er.ReadInt16(), er.ReadInt16(), er.ReadInt16() };

        case Xpe.FieldType.Short4:
          er.Position = absolute + field.Offset;
          return new short[] { er.ReadInt16(), er.ReadInt16(), er.ReadInt16(), er.ReadInt16() };

        case Xpe.FieldType.String:
          er.Position = absolute + field.Offset;
          return er.ReadString(32);

        case Xpe.FieldType.Padding:
          er.Position = absolute + field.Offset;
          return er.ReadBytes(field.Size);

        default:
          return null;
      }
    }

    private object RecursiveReadFile(Xpe.Field field, TagLibrary lib, string directory, int absolute, ref int absoluteLastEnd)
    {
      switch (field.Type)
      {
        case Xpe.FieldType.TagReference:
          er.Position = absolute + field.Offset;
          string type = er.ReadFourCC();
          er.Position += 4;
          int strLen = er.ReadInt32();
          if (strLen == 0)
            return -1;
          er.Position = absoluteLastEnd;
          string name = er.ReadString(strLen);
          absoluteLastEnd += strLen + 1;
          return lib.GetDependencyTag(name, type, directory);

        case Xpe.FieldType.Block:
          er.Position = absolute + field.Offset;
          int count = er.ReadInt32();
          int prevEnd = absoluteLastEnd;
          absoluteLastEnd += count * field.Size;
          Xpe.Field[] children = field.Children;
          Array values = Array.CreateInstance(typeof(object), count, children.Length);
          for (int x = 0; x < count; x++)
            for (int y = 0; y < children.Length; y++)
              values.SetValue(RecursiveReadFile(children[y], lib, directory, prevEnd + (x * field.Size), ref absoluteLastEnd), x, y);
          return values;

        case Xpe.FieldType.BitmapPixelData:
        case Xpe.FieldType.ModelIndexBlock:
        case Xpe.FieldType.ModelVertexBlock:
        case Xpe.FieldType.Prestructure:
        case Xpe.FieldType.ScriptData:
        case Xpe.FieldType.SoundDataBlock:
          er.Position = absolute + field.Offset;
          int byteCount = er.ReadInt32();
          er.Position = absoluteLastEnd;
          absoluteLastEnd += byteCount;
          return er.ReadBytes(byteCount);

        case Xpe.FieldType.BspCompressedVertexBlock:
        case Xpe.FieldType.BspUncompressedVertexBlock:
          er.Position = absolute + field.Offset;
          int dbyteCount = er.ReadInt32();
          er.Position += 4;
          int dword = er.ReadInt32(); // TODO: Figure out what this value is for
          er.Position = absoluteLastEnd;
          absoluteLastEnd += dbyteCount;
          return new DataContainer(dword, er.ReadBytes(dbyteCount));

        case Xpe.FieldType.BitmapDataBlock:
          return er.ReadInt32();

        case Xpe.FieldType.Char:
        case Xpe.FieldType.CharFlags:
          er.Position = absolute + field.Offset;
          return er.ReadByte();

        case Xpe.FieldType.DWordFlags:
        case Xpe.FieldType.Int1:
          er.Position = absolute + field.Offset;
          return er.ReadInt32();

        case Xpe.FieldType.WordFlags:
        case Xpe.FieldType.Enum:
        case Xpe.FieldType.Short1:
          er.Position = absolute + field.Offset;
          return er.ReadInt16();

        case Xpe.FieldType.Float1:
          er.Position = absolute + field.Offset;
          return er.ReadSingle();

        case Xpe.FieldType.Float2:
          er.Position = absolute + field.Offset;
          return new float[] { er.ReadSingle(), er.ReadSingle() };

        case Xpe.FieldType.Float3:
          er.Position = absolute + field.Offset;
          return new float[] { er.ReadSingle(), er.ReadSingle(), er.ReadSingle() };

        case Xpe.FieldType.Float4:
          er.Position = absolute + field.Offset;
          return new float[] { er.ReadSingle(), er.ReadSingle(), er.ReadSingle(), er.ReadSingle() };

        case Xpe.FieldType.Int2:
          er.Position = absolute + field.Offset;
          return new int[] { er.ReadInt32(), er.ReadInt32() };

        case Xpe.FieldType.Int3:
          er.Position = absolute + field.Offset;
          return new int[] { er.ReadInt32(), er.ReadInt32(), er.ReadInt32() };

        case Xpe.FieldType.Int4:
          er.Position = absolute + field.Offset;
          return new int[] { er.ReadInt32(), er.ReadInt32(), er.ReadInt32(), er.ReadInt32() };

        case Xpe.FieldType.Short2:
          er.Position = absolute + field.Offset;
          return new short[] { er.ReadInt16(), er.ReadInt16() };

        case Xpe.FieldType.Short3:
          er.Position = absolute + field.Offset;
          return new short[] { er.ReadInt16(), er.ReadInt16(), er.ReadInt16() };

        case Xpe.FieldType.Short4:
          er.Position = absolute + field.Offset;
          return new short[] { er.ReadInt16(), er.ReadInt16(), er.ReadInt16(), er.ReadInt16() };

        case Xpe.FieldType.String:
          er.Position = absolute + field.Offset;
          return er.ReadString(32);

        case Xpe.FieldType.Padding:
          er.Position = absolute + field.Offset;
          return er.ReadBytes(field.Size);

        default:
          return null;
      }
    }

    private void RecursiveWriteFile(EndianWriter ew, Xpe.Field field, Array vset, int ycount, int index, TagLibrary lib, int absolute, ref uint absoluteEnd)
    {
      ew.Position = absolute + field.Offset;
      object value = null;
      if (ycount < 0)
        value = vset.GetValue(index);
      else
        value = vset.GetValue(ycount, index);
      Array array = value as Array;

      switch (field.Type)
      {
        case Xpe.FieldType.BitmapDataBlock:
          ew.Write(Convert.ToInt32(value));
          ew.Write(0);
          break;
        case Xpe.FieldType.Prestructure:
        case Xpe.FieldType.ScriptData:
        case Xpe.FieldType.SoundDataBlock:
        case Xpe.FieldType.BitmapPixelData:
          int pDataLen = array.GetLength(0);
          ew.Write(pDataLen);
          ew.Write(0);
          ew.Write(0);
          ew.Write(0);
          ew.Write(0);
          ew.Position = (int)absoluteEnd;
          absoluteEnd += (uint)pDataLen;
          for (int x = 0; x < pDataLen; x++)
            ew.Write((byte)array.GetValue(x));
          break;
        case Xpe.FieldType.Block:
          Array nvset = value as Array;
          int count = nvset.GetLength(0);
          if (field.Name == "predicted resources" || field.Name == "PREDICTED RESOURCES")
            count = 0; // lol fuck these things
          if (count == 0)
          {
            ew.Write(0);
            ew.Write(0);
            ew.Write(0);
            break;
          }
          ew.Write(count);
          ew.Write(0);
          ew.Write(0);
          int nAbsolute = (int)absoluteEnd;
          absoluteEnd += (uint)(field.Size * count);
          ew.Length += field.Size * count;
          int cCount = field.Children.Length;
          for (int x = 0; x < count; x++)
            for (int y = 0; y < cCount; y++)
              RecursiveWriteFile(ew, field.Children[y], nvset, x, y, lib, nAbsolute + (x * field.Size), ref absoluteEnd);
          break;
        case Xpe.FieldType.BspCompressedVertexBlock:
          DataContainer dc = value as DataContainer;
          int dpDataLen = dc.data.GetLength(0);
          ew.Write(dpDataLen);
          ew.Write(0);
          ew.Write(dc.variable);
          ew.Write(0);
          ew.Write(0);
          ew.Position = (int)absoluteEnd;
          absoluteEnd += (uint)dpDataLen;
          for (int x = 0; x < dpDataLen; x++)
            ew.Write(dc.data[x]);
          break;
        case Xpe.FieldType.BspUncompressedVertexBlock:
          DataContainer udc = value as DataContainer;
          int udpDataLen = udc.data.GetLength(0);
          ew.Write(udpDataLen);
          ew.Write(0);
          ew.Write(udc.variable);
          ew.Write(0);
          ew.Write(0);
          ew.Position = (int)absoluteEnd;
          absoluteEnd += (uint)udpDataLen;
          for (int x = 0; x < udpDataLen; x++)
            ew.Write(udc.data[x]);
          break;
        case Xpe.FieldType.BspVertexDataHeader:
          ew.Write(0);
          ew.Write(Convert.ToInt32(value));
          ew.Write(0);
          ew.Write(0);
          ew.Write(0);
          break;
        case Xpe.FieldType.Char:
        case Xpe.FieldType.CharFlags:
          ew.Write(Convert.ToByte(value));
          break;
        case Xpe.FieldType.Float1:
          ew.Write(Convert.ToSingle(value));
          break;
        case Xpe.FieldType.Float2:
          ew.Write(Convert.ToSingle(array.GetValue(0)));
          ew.Write(Convert.ToSingle(array.GetValue(1)));
          break;
        case Xpe.FieldType.Float3:
          if (value is Array)
          {
            ew.Write(Convert.ToSingle(array.GetValue(0)));
            ew.Write(Convert.ToSingle(array.GetValue(1)));
            ew.Write(Convert.ToSingle(array.GetValue(2)));
          }
          else
          {
            ew.Write(0);
            ew.Write(0);
            ew.Write(0);
          }
          break;
        case Xpe.FieldType.Float4:
          ew.Write(Convert.ToSingle(array.GetValue(0)));
          ew.Write(Convert.ToSingle(array.GetValue(1)));
          ew.Write(Convert.ToSingle(array.GetValue(2)));
          ew.Write(Convert.ToSingle(array.GetValue(3)));
          break;
        case Xpe.FieldType.DWordFlags:
        case Xpe.FieldType.Int1:
          if (value is int)
            ew.Write(Convert.ToInt32(value));
          else if (value is uint)
            ew.Write(Convert.ToUInt32(value));
          else if (value is short)
            ew.Write((int)Convert.ToInt16(value));
          else if (value is ushort)
            ew.Write((uint)Convert.ToUInt16(value));
          else
            throw new Exception("Unknown object type given for Int1/DWordFlags.");
          break;
        case Xpe.FieldType.Int2:
          ew.Write(Convert.ToInt32(array.GetValue(0)));
          ew.Write(Convert.ToInt32(array.GetValue(1)));
          break;
        case Xpe.FieldType.Int3:
          ew.Write(Convert.ToInt32(array.GetValue(0)));
          ew.Write(Convert.ToInt32(array.GetValue(1)));
          ew.Write(Convert.ToInt32(array.GetValue(2)));
          break;
        case Xpe.FieldType.Int4:
          ew.Write(Convert.ToInt32(array.GetValue(0)));
          ew.Write(Convert.ToInt32(array.GetValue(1)));
          ew.Write(Convert.ToInt32(array.GetValue(2)));
          ew.Write(Convert.ToInt32(array.GetValue(3)));
          break;
        case Xpe.FieldType.ModelIndexBlock:
        case Xpe.FieldType.ModelVertexBlock:
          ew.Write(0);
          ew.Write(0);
          ew.Write(0);
          ew.Write(0);
          break;
        case Xpe.FieldType.Padding:
          int padLen = array.GetLength(0);
          for (int x = 0; x < padLen; x++)
            ew.Write(Convert.ToByte(array.GetValue(x)));
          break;
        case Xpe.FieldType.SelfReference:
          ew.Write(lib.IDByTag(this));
          break;
        case Xpe.FieldType.Enum:
        case Xpe.FieldType.WordFlags:
        case Xpe.FieldType.Short1:
          if (value is short)
            ew.Write(Convert.ToInt16(value));
          else if (value is ushort)
            ew.Write(Convert.ToUInt16(value));
          else
            throw new Exception("Invalid type claims to be a short integer.");
          break;
        case Xpe.FieldType.Short2:
          ew.Write(Convert.ToInt16(array.GetValue(0)));
          ew.Write(Convert.ToInt16(array.GetValue(1)));
          break;
        case Xpe.FieldType.Short3:
          ew.Write(Convert.ToInt16(array.GetValue(0)));
          ew.Write(Convert.ToInt16(array.GetValue(1)));
          ew.Write(Convert.ToInt16(array.GetValue(2)));
          break;
        case Xpe.FieldType.Short4:
          ew.Write(Convert.ToInt16(array.GetValue(0)));
          ew.Write(Convert.ToInt16(array.GetValue(1)));
          ew.Write(Convert.ToInt16(array.GetValue(2)));
          ew.Write(Convert.ToInt16(array.GetValue(3)));
          break;
        case Xpe.FieldType.String:
          ew.Write(Convert.ToString(value), false);
          break;
        case Xpe.FieldType.TagReference:
          int tag = Convert.ToInt32(value);
          if (tag < 0)
          {
            /*if (field.Arguments[0] == "mod2")
              ew.WriteFourCC("mode");
            else*/
              ew.WriteFourCC(field.Arguments[0]);
            ew.Write(0);
            ew.Write(0);
            ew.Write(-1);
          }
          else
          {
            string tType = lib.GetClass(tag);
            string tName = lib.GetName(tag);
            /*if (tType == "mod2")
              ew.WriteFourCC("mode");
            else*/
              ew.WriteFourCC(tType);
            ew.Write(0);
            int increment = tName.TrimEnd(new char[] { '\0' }).Length;
            ew.Write(increment);
            ew.Write(-1);
            ew.Position = (int)absoluteEnd;
            absoluteEnd += (uint)(increment + 1);
            ew.Write(tName, true);
          }
          break;
      }
      ew.Flush();
    }

    private void RecursiveWriteMap(EndianWriter ew, Xpe.Field field, Array vset, int ycount, int index, TagLibrary lib, int absolute, ref uint absoluteEnd, int[] aux, uint memory)
    {
      ew.Position = absolute + field.Offset;
      object value = null;
      if (ycount < 0)
        value = vset.GetValue(index);
      else
        value = vset.GetValue(ycount, index);
      Array array = value as Array;

      switch (field.Type)
      {
        case Xpe.FieldType.BitmapDataBlock:
          ew.Write(Convert.ToInt32(value) + aux[0]);
          if (lib.MapFormat == MapFormat.Xbox)
          {
            if((short)vset.GetValue(ycount, 4) == 2)
              ew.Write(Compression.Round(CalculateBitmapSize((short)vset.GetValue(ycount, 1), (short)vset.GetValue(ycount, 2), (short)vset.GetValue(ycount, 3), 0, (short)vset.GetValue(ycount, 5), (short)vset.GetValue(ycount, 8)), 0x80) * 6);
            else
              ew.Write(Compression.Round(CalculateBitmapSize((short)vset.GetValue(ycount, 1), (short)vset.GetValue(ycount, 2), (short)vset.GetValue(ycount, 3), (short)vset.GetValue(ycount, 4), (short)vset.GetValue(ycount, 5), (short)vset.GetValue(ycount, 8)), 0x80));
          }
          else
            ew.Write(CalculateBitmapSize((short)vset.GetValue(ycount, 1), (short)vset.GetValue(ycount, 2), (short)vset.GetValue(ycount, 3), (short)vset.GetValue(ycount, 4), (short)vset.GetValue(ycount, 5), (short)vset.GetValue(ycount, 8), true));
          break;
        case Xpe.FieldType.BitmapPixelData:
          ew.Write(0);
          ew.Write(0);
          //if(field.Name == "compressed color plate data")
          //	ew.Write(0x6c); // TODO: find out what the hell this is
          //else
          ew.Write(0);
          ew.Write(0);
          ew.Write(0);
          break;
        case Xpe.FieldType.Block:
          Array nvset = value as Array;
          int count = nvset.GetLength(0);
          if (count == 0)
          {
            ew.Write(0);
            ew.Write(0);
            ew.Write(0);
            break;
          }
          ew.Write(count);
          ew.Write(absoluteEnd + memory);
          ew.Write(0);
          int nAbsolute = (int)absoluteEnd;
          absoluteEnd += (uint)Compression.Round(field.Size * count, 4);
          ew.Length += Compression.Round(field.Size * count, 4);
          int cCount = field.Children.Length;
          for (int x = 0; x < count; x++)
            for (int y = 0; y < cCount; y++)
              RecursiveWriteMap(ew, field.Children[y], nvset, x, y, lib, nAbsolute + (x * field.Size), ref absoluteEnd, aux, memory);
          break;
        case Xpe.FieldType.BspCompressedVertexBlock:
          if (lib.MapFormat == MapFormat.Xbox)
          {
            ew.Write(aux[typeCounter * 6 + 1]);
            ew.Write(0);
            ew.Write((value as DataContainer).variable);
            ew.Write((uint)aux[2 + ((typeCounter++) * 6)] + memory);
            ew.Write(0);
          }
          else
          {
            ew.Write(0);
            ew.Write(0);
            ew.Write((value as DataContainer).variable);
            ew.Write(0);
            ew.Write(0);
          }
          break;
        case Xpe.FieldType.BspUncompressedVertexBlock:
          if (lib.MapFormat == MapFormat.Xbox)
          {
            ew.Write(0);
            ew.Write(0);
            ew.Write((value as DataContainer).variable);
            ew.Write(0);
            ew.Write(0);
          }
          else
          {
            /*ew.Write(aux[typeCounter * 6 + 1]);
            ew.Write(0);
            ew.Write((value as DataContainer).variable);
            ew.Write((uint)aux[2 + ((typeCounter++) * 6)] + memory);
            ew.Write(0);*/
            int ucvCount = array.GetLength(0);
            ew.Write(ucvCount);
            ew.Write(0);
            ew.Write((value as DataContainer).variable);
            ew.Write(absoluteEnd + memory);
            ew.Write(0);
            ew.Position = (int)absoluteEnd;
            absoluteEnd += (uint)Compression.Round(ucvCount, 4);
            for (int x = 0; x < ucvCount; x++)
              ew.Write(Convert.ToByte(array.GetValue(x)));
            typeCounter++;
          }
          break;
        case Xpe.FieldType.BspVertexDataHeader:
          if (field.Name == "vertex buffer")
            ew.Write(1);
          else if (field.Name == "lightmap buffer")
            ew.Write(3);
          if (field.Name == "vertex buffer")
            ew.Write(aux[typeCounter * 6]);
          else if (field.Name == "lightmap buffer")
            ew.Write(aux[typeCounter * 6 + 3]);
          ew.Write(0);
          ew.Write(0);
          if (field.Name == "vertex buffer")
            ew.Write(aux[typeCounter * 6 + 4]);
          else if (field.Name == "lightmap buffer")
            ew.Write(aux[typeCounter * 6 + 5]);
          break;
        case Xpe.FieldType.Char:
        case Xpe.FieldType.CharFlags:
          ew.Write(Convert.ToByte(value));
          break;
        case Xpe.FieldType.Float1:
          ew.Write(Convert.ToSingle(value));
          break;
        case Xpe.FieldType.Float2:
          ew.Write(Convert.ToSingle(array.GetValue(0)));
          ew.Write(Convert.ToSingle(array.GetValue(1)));
          break;
        case Xpe.FieldType.Float3:
          ew.Write(Convert.ToSingle(array.GetValue(0)));
          ew.Write(Convert.ToSingle(array.GetValue(1)));
          ew.Write(Convert.ToSingle(array.GetValue(2)));
          break;
        case Xpe.FieldType.Float4:
          ew.Write(Convert.ToSingle(array.GetValue(0)));
          ew.Write(Convert.ToSingle(array.GetValue(1)));
          ew.Write(Convert.ToSingle(array.GetValue(2)));
          ew.Write(Convert.ToSingle(array.GetValue(3)));
          break;
        case Xpe.FieldType.DWordFlags:
        case Xpe.FieldType.Int1:
          if (value is int)
            ew.Write(Convert.ToInt32(value));
          else if (value is uint)
            ew.Write(Convert.ToUInt32(value));
          else
            throw new Exception("Unknown object type given for Int1/DWordFlags.");
          break;
        case Xpe.FieldType.Int2:
          ew.Write(Convert.ToInt32(array.GetValue(0)));
          ew.Write(Convert.ToInt32(array.GetValue(1)));
          break;
        case Xpe.FieldType.Int3:
          ew.Write(Convert.ToInt32(array.GetValue(0)));
          ew.Write(Convert.ToInt32(array.GetValue(1)));
          ew.Write(Convert.ToInt32(array.GetValue(2)));
          break;
        case Xpe.FieldType.Int4:
          ew.Write(Convert.ToInt32(array.GetValue(0)));
          ew.Write(Convert.ToInt32(array.GetValue(1)));
          ew.Write(Convert.ToInt32(array.GetValue(2)));
          ew.Write(Convert.ToInt32(array.GetValue(3)));
          break;
        case Xpe.FieldType.ModelIndexBlock:
          ew.Write(aux[typeCounter * 5]);
          ew.Write(aux[1 + (typeCounter * 5)]);
          ew.Write(aux[4 + (typeCounter * 5)]);
          if (lib.MapFormat == MapFormat.Xbox)
            ew.Write(5); // TODO: Figure out what the hell this value is
          else
            ew.Write(4);
          break;
        case Xpe.FieldType.ModelVertexBlock:
          ew.Write(aux[2 + typeCounter * 5]);
          ew.Write(0);
          ew.Write(0);
          ew.Write(aux[3 + ((typeCounter++) * 5)]);
          break;
        case Xpe.FieldType.Padding:
          if (field.Name == "shader type index")
            array = ShaderIndices.GetIndex(xpe.FourCC, lib.MapFormat);
          if (array == null)
            for (int x = 0; x < field.Size; x++)
              ew.Write((byte)0);
          else
          {
            int padLen = array.GetLength(0);
            if (padLen == 0)
              for (int x = 0; x < field.Size; x++)
                ew.Write((byte)0);
            else
            {
              for (int x = 0; x < padLen; x++)
                ew.Write(Convert.ToByte(array.GetValue(x)));
            }
          }
          break;
        case Xpe.FieldType.Prestructure:
          int psCount = array.GetLength(0);
          ew.Write(psCount);
          ew.Write(0);
          ew.Write(0);
          ew.Write(absoluteEnd + memory);
          ew.Write(0);
          ew.Position = (int)absoluteEnd;
          absoluteEnd += (uint)Compression.Round(psCount, 4);
          for (int x = 0; x < psCount; x++)
            ew.Write(Convert.ToByte(array.GetValue(x)));
          break;
        case Xpe.FieldType.ScriptData:
          int hscCount = array.GetLength(0);
          ew.Write(hscCount);
          ew.Write(0);
          ew.Write(0);
          ew.Write(absoluteEnd + memory);
          ew.Write(0);
          ew.Position = (int)absoluteEnd;
          absoluteEnd += (uint)Compression.Round(hscCount, 4);
          for (int x = 0; x < hscCount; x++)
            ew.Write(Convert.ToByte(array.GetValue(x)));
          break;
        case Xpe.FieldType.SelfReference:
          ew.Write(lib.IDByTag(this));
          break;
        case Xpe.FieldType.Enum:
        case Xpe.FieldType.WordFlags:
        case Xpe.FieldType.Short1:
          ew.Write(Convert.ToInt16(value));
          break;
        case Xpe.FieldType.Short2:
          ew.Write(Convert.ToInt16(array.GetValue(0)));
          ew.Write(Convert.ToInt16(array.GetValue(1)));
          break;
        case Xpe.FieldType.Short3:
          ew.Write(Convert.ToInt16(array.GetValue(0)));
          ew.Write(Convert.ToInt16(array.GetValue(1)));
          ew.Write(Convert.ToInt16(array.GetValue(2)));
          break;
        case Xpe.FieldType.Short4:
          ew.Write(Convert.ToInt16(array.GetValue(0)));
          ew.Write(Convert.ToInt16(array.GetValue(1)));
          ew.Write(Convert.ToInt16(array.GetValue(2)));
          ew.Write(Convert.ToInt16(array.GetValue(3)));
          break;
        case Xpe.FieldType.SoundDataBlock:
          ew.Write(aux[typeCounter * 2]);
          if (hasSpecialData)
            ew.Write(1);
          else
            ew.Write(0);
          ew.Write(aux[1 + ((typeCounter++) * 2)]);
          ew.Write(0);
          ew.Write(0);
          break;
        case Xpe.FieldType.String:
          ew.Write(Convert.ToString(value), false);
          break;
        case Xpe.FieldType.TagReference:
          int tag = Convert.ToInt32(value);
          if (tag < 0)
          {
            /*if (field.Arguments[0] == "mod2")
              ew.WriteFourCC("mode");
            else*/
              ew.WriteFourCC(field.Arguments[0]);
            ew.Write(0);
            ew.Write(0);
            ew.Write(-1);
          }
          else
          {
            string tType = lib.GetClass(tag);
            /*if (tType == "mod2")
              ew.WriteFourCC("mode");
            else*/
              ew.WriteFourCC(tType);
            ew.Write(lib.StringOffsets[tag]);
            ew.Write(0);
            ew.Write(lib.GetID(tag));
          }
          break;
      }
      ew.Flush();
    }

    private void RecursiveWriteMap(EndianWriter ew, Xpe.Field field, Array vset, int ycount, int index, TagLibrary lib, int absolute, ref uint absoluteEnd, int[] aux, ArrayList pointers, ArrayList destinations)
    {
      ew.Position = absolute + field.Offset;
      object value = null;
      if (ycount < 0)
        value = vset.GetValue(index);
      else
        value = vset.GetValue(ycount, index);
      Array array = value as Array;

      switch (field.Type)
      {
        case Xpe.FieldType.BitmapDataBlock:
          ew.Write(Convert.ToInt32(value) + aux[0]);
          if(lib.MapFormat == MapFormat.Xbox)
            ew.Write(Compression.Round(CalculateBitmapSize((short)vset.GetValue(ycount, 1), (short)vset.GetValue(ycount, 2), (short)vset.GetValue(ycount, 3), (short)vset.GetValue(ycount, 4), (short)vset.GetValue(ycount, 5), (short)vset.GetValue(ycount, 8)), 0x80));
          else
            ew.Write(CalculateBitmapSize((short)vset.GetValue(ycount, 1), (short)vset.GetValue(ycount, 2), (short)vset.GetValue(ycount, 3), (short)vset.GetValue(ycount, 4), (short)vset.GetValue(ycount, 5), (short)vset.GetValue(ycount, 8)));
          break;
        case Xpe.FieldType.BitmapPixelData:
          ew.Write(0);
          ew.Write(0);
          //if(field.Name == "compressed color plate data")
          //	ew.Write(0x6c); // TODO: find out what the hell this is
          //else
          ew.Write(0);
          ew.Write(0);
          ew.Write(0);
          break;
        case Xpe.FieldType.Block:
          Array nvset = value as Array;
          int count = nvset.GetLength(0);
          if (count == 0)
          {
            ew.Write(0);
            ew.Write(0);
            ew.Write(0);
            break;
          }
          ew.Write(count);
          pointers.Add(ew.Position);
          ew.Write(0);
          ew.Write(0);
          destinations.Add(absoluteEnd);
          int nAbsolute = (int)absoluteEnd;
          absoluteEnd += (uint)Compression.Round(field.Size * count, 4);
          ew.Length += Compression.Round(field.Size * count, 4);
          int cCount = field.Children.Length;
          for (int x = 0; x < count; x++)
            for (int y = 0; y < cCount; y++)
              RecursiveWriteMap(ew, field.Children[y], nvset, x, y, lib, nAbsolute + (x * field.Size), ref absoluteEnd, aux, pointers, destinations);
          break;
        case Xpe.FieldType.BspCompressedVertexBlock:
          if (lib.MapFormat == MapFormat.Xbox)
          {
            ew.Write(aux[typeCounter * 6 + 1]);
            ew.Write(0);
            ew.Write((value as DataContainer).variable);
            pointers.Add(ew.Position);
            destinations.Add((uint)aux[2 + ((typeCounter++) * 6)]);
            ew.Write(0);
            ew.Write(0);
          }
          else
          {
            ew.Write(0);
            ew.Write(0);
            ew.Write((value as DataContainer).variable);
            ew.Write(0);
            ew.Write(0);
          }
          break;
        case Xpe.FieldType.BspUncompressedVertexBlock:
          if (lib.MapFormat == MapFormat.Xbox)
          {
            ew.Write(0);
            ew.Write(0);
            ew.Write((value as DataContainer).variable);
            ew.Write(0);
            ew.Write(0);
          }
          else
          {
            /*ew.Write(aux[typeCounter * 6 + 1]);
            ew.Write(0);
            ew.Write((value as DataContainer).variable);
            ew.Write((uint)aux[2 + ((typeCounter++) * 6)] + memory);
            ew.Write(0);*/
            int ucvCount = (value as DataContainer).data.Length;
            ew.Write(ucvCount);
            ew.Write(0);
            ew.Write((value as DataContainer).variable);
            pointers.Add(ew.Position);
            destinations.Add(absoluteEnd);
            ew.Write(0); // offset
            ew.Write(0);
            ew.Position = (int)absoluteEnd;
            absoluteEnd += (uint)Compression.Round(ucvCount, 4);
            for (int x = 0; x < ucvCount; x++)
              ew.Write((value as DataContainer).data[x]);
            typeCounter++;
          }
          break;
        case Xpe.FieldType.BspVertexDataHeader: /* constant, count, 0, 0, offset */
          if (lib.MapFormat == MapFormat.Xbox)
          {
            if (field.Name == "vertex buffer")
              ew.Write(1);
            else if (field.Name == "lightmap buffer")
              ew.Write(3);
          }
          else
            ew.Write(0); // halo pc doesn't use this constant for whatever reason
          if (field.Name == "vertex buffer")
            ew.Write(aux[typeCounter * 6]);
          else if (field.Name == "lightmap buffer")
            ew.Write(aux[typeCounter * 6 + 3]);
          ew.Write(0);
          ew.Write(0);
          if (lib.MapFormat == MapFormat.Xbox) // nor does halo pc use these pointers
          {
            if (field.Name == "vertex buffer")
            {
              pointers.Add(ew.Position);
              destinations.Add((uint)aux[4 + (typeCounter * 6)]);
            }
            else if (field.Name == "lightmap buffer")
            {
              pointers.Add(ew.Position);
              destinations.Add((uint)aux[5 + (typeCounter * 6)]);
            }
          }
          ew.Write(0);
          break;
        case Xpe.FieldType.Char:
        case Xpe.FieldType.CharFlags:
          ew.Write(Convert.ToByte(value));
          break;
        case Xpe.FieldType.Float1:
          ew.Write(Convert.ToSingle(value));
          break;
        case Xpe.FieldType.Float2:
          ew.Write(Convert.ToSingle(array.GetValue(0)));
          ew.Write(Convert.ToSingle(array.GetValue(1)));
          break;
        case Xpe.FieldType.Float3:
          ew.Write(Convert.ToSingle(array.GetValue(0)));
          ew.Write(Convert.ToSingle(array.GetValue(1)));
          ew.Write(Convert.ToSingle(array.GetValue(2)));
          break;
        case Xpe.FieldType.Float4:
          ew.Write(Convert.ToSingle(array.GetValue(0)));
          ew.Write(Convert.ToSingle(array.GetValue(1)));
          ew.Write(Convert.ToSingle(array.GetValue(2)));
          ew.Write(Convert.ToSingle(array.GetValue(3)));
          break;
        case Xpe.FieldType.DWordFlags:
        case Xpe.FieldType.Int1:
          if (value is int)
            ew.Write(Convert.ToInt32(value));
          else if (value is uint)
            ew.Write(Convert.ToUInt32(value));
          else
            throw new Exception("Unknown object type given for Int1/DWordFlags.");
          break;
        case Xpe.FieldType.Int2:
          ew.Write(Convert.ToInt32(array.GetValue(0)));
          ew.Write(Convert.ToInt32(array.GetValue(1)));
          break;
        case Xpe.FieldType.Int3:
          ew.Write(Convert.ToInt32(array.GetValue(0)));
          ew.Write(Convert.ToInt32(array.GetValue(1)));
          ew.Write(Convert.ToInt32(array.GetValue(2)));
          break;
        case Xpe.FieldType.Int4:
          ew.Write(Convert.ToInt32(array.GetValue(0)));
          ew.Write(Convert.ToInt32(array.GetValue(1)));
          ew.Write(Convert.ToInt32(array.GetValue(2)));
          ew.Write(Convert.ToInt32(array.GetValue(3)));
          break;
        case Xpe.FieldType.ModelIndexBlock:
          ew.Write(aux[typeCounter * 5]);
          ew.Write(aux[1 + (typeCounter * 5)]);
          ew.Write(aux[4 + (typeCounter * 5)]);
          ew.Write(5); // TODO: Figure out what the hell this value is
          break;
        case Xpe.FieldType.ModelVertexBlock:
          ew.Write(aux[2 + typeCounter * 5]);
          ew.Write(0);
          ew.Write(0);
          ew.Write(aux[3 + ((typeCounter++) * 5)]);
          break;
        case Xpe.FieldType.Padding:
          int padLen = array.GetLength(0);
          for (int x = 0; x < padLen; x++)
            ew.Write(Convert.ToByte(array.GetValue(x)));
          break;
        case Xpe.FieldType.Prestructure:
          int psCount = array.GetLength(0);
          ew.Write(psCount);
          ew.Write(0);
          ew.Write(0);
          pointers.Add(ew.Position);
          destinations.Add(absoluteEnd);
          ew.Write(0);
          ew.Write(0);
          ew.Position = (int)absoluteEnd;
          absoluteEnd += (uint)Compression.Round(psCount, 4);
          for (int x = 0; x < psCount; x++)
            ew.Write(Convert.ToByte(array.GetValue(x)));
          break;
        case Xpe.FieldType.ScriptData:
          int hscCount = array.GetLength(0);
          ew.Write(hscCount);
          ew.Write(0);
          ew.Write(0);
          pointers.Add(ew.Position);
          destinations.Add(absoluteEnd);
          ew.Write(0);
          ew.Write(0);
          ew.Position = (int)absoluteEnd;
          absoluteEnd += (uint)Compression.Round(hscCount, 4);
          for (int x = 0; x < hscCount; x++)
            ew.Write(Convert.ToByte(array.GetValue(x)));
          break;
        case Xpe.FieldType.SelfReference:
          ew.Write(lib.IDByTag(this));
          break;
        case Xpe.FieldType.Enum:
        case Xpe.FieldType.WordFlags:
        case Xpe.FieldType.Short1:
          ew.Write(Convert.ToInt16(value));
          break;
        case Xpe.FieldType.Short2:
          ew.Write(Convert.ToInt16(array.GetValue(0)));
          ew.Write(Convert.ToInt16(array.GetValue(1)));
          break;
        case Xpe.FieldType.Short3:
          ew.Write(Convert.ToInt16(array.GetValue(0)));
          ew.Write(Convert.ToInt16(array.GetValue(1)));
          ew.Write(Convert.ToInt16(array.GetValue(2)));
          break;
        case Xpe.FieldType.Short4:
          ew.Write(Convert.ToInt16(array.GetValue(0)));
          ew.Write(Convert.ToInt16(array.GetValue(1)));
          ew.Write(Convert.ToInt16(array.GetValue(2)));
          ew.Write(Convert.ToInt16(array.GetValue(3)));
          break;
        case Xpe.FieldType.SoundDataBlock:
          ew.Write(aux[typeCounter * 2]);
          ew.Write(0);
          ew.Write(aux[1 + ((typeCounter++) * 2)]);
          ew.Write(0);
          ew.Write(0);
          break;
        case Xpe.FieldType.String:
          ew.Write(Convert.ToString(value), false);
          break;
        case Xpe.FieldType.TagReference:
          int tag = Convert.ToInt32(value);
          if (tag < 0)
          {
            if (field.Arguments[0] == "mod2")
              ew.WriteFourCC("mode");
            else
              ew.WriteFourCC(field.Arguments[0]);
            ew.Write(0);
            ew.Write(0);
            ew.Write(-1);
          }
          else
          {
            string tType = lib.GetClass(tag);
            if (tType == "mod2")
              ew.WriteFourCC("mode");
            else
              ew.WriteFourCC(tType);
            ew.Write(lib.StringOffsets[tag]);
            ew.Write(0);
            ew.Write(lib.GetID(tag));
          }
          break;
      }
      ew.Flush();
    }

    private static int CalculateBitmapSize(short dimensiona, short dimensionb, short dimensionc, short type, short format, short mipMapCount)
    {
      return CalculateBitmapSize(dimensiona, dimensionb, dimensionc, type, format, mipMapCount, false);
    }

    private static int CalculateBitmapSize(short dimensiona, short dimensionb, short dimensionc, short type, short format, short mipMapCount, bool useHaloPCDirectPadding)
    {
      int scalar = dimensiona * dimensionb * (type == 1 ? dimensionc : (short)1);

      for (short x = 1; x <= mipMapCount; x++)
        scalar += Math.Max(Math.Max((dimensiona / (short)Math.Pow(2.0, (double)x)), 1) * Math.Max((dimensionb / (short)Math.Pow(2.0, (double)x)), 1) * (type == 1 ? Math.Max((dimensionc / (short)Math.Pow(2.0, (double)x)), 1) : (short)1) * BitmapPixel.BitmapBpp(format) / 8, useHaloPCDirectPadding ? 16 : 4) * 8 / BitmapPixel.BitmapBpp(format);

      switch (format)
      {
        case 0:
        case 1:
        case 2:
          return FeintRound(scalar, 0x80) * (type == 2 ? 6 : 1);
        case 3:
          return FeintRound(scalar * 2, 0x80) * (type == 2 ? 6 : 1);
        case 4:
        case 5:
          throw new Exception("Invalid bitmap format.");
        case 6:
          return FeintRound(scalar * 2, 0x80) * (type == 2 ? 6 : 1);
        case 7:
          throw new Exception("Invalid bitmap format.");
        case 8:
        case 9:
          return FeintRound(scalar * 2, 0x80) * (type == 2 ? 6 : 1);
        case 10:
        case 11:
          return FeintRound(scalar * 4, 0x80) * (type == 2 ? 6 : 1);
        case 12:
        case 13:
          throw new Exception("Invalid bitmap format.");
        case 14:
          return FeintRound(scalar / 2, 0x80) * (type == 2 ? 6 : 1);
        case 15:
        case 16:
        case 17:
          return FeintRound(scalar, 0x80) * (type == 2 ? 6 : 1);
        default:
          throw new Exception("Unknown bitmap format.");
      }
    }

    private static int FeintRound(int val, int page)
    {
      return val;
    }

    public Xpe Xpe
    {
      get { return xpe; }
    }

    public static unsafe uint ToUnsignedByReference(int value)
    {
      return *(uint*)(&value);
    }

    public static unsafe ushort ToUnsignedByReference(short value)
    {
      return *(ushort*)(&value);
    }

    public static unsafe sbyte ToSignedByReference(byte value)
    {
      return *(sbyte*)(&value);
    }

    public static unsafe int ToSignedByReference(uint value)
    {
      return *(int*)(&value);
    }

    private static byte[] UnpadCubeTexture(byte[] raw, int offset, int width, int height, int mipMapCount, int bitsPerPixel)
    {
      int trueSize = width * height * bitsPerPixel / 8;
      int mipSize = trueSize;
      for (int i = 0; i < mipMapCount; i++)
      {
        mipSize /= 4;
        if (mipSize < 4)
          mipSize = 4;
        trueSize += mipSize;
      }

      int padSize = raw.Length / 6 - trueSize;
      if (padSize < 0)
        throw new HaloException("Weird cube texture found. Pad size was negative: {0}.\nMip levels: {1}\nBits per pixel: {2}\n", padSize, mipMapCount, bitsPerPixel);

      int bufPosition = 0;
      int rawPosition = offset;
      byte[] buffer = new byte[trueSize * 6];
      for (int i = 0; i < 6; i++)
      {
        Array.Copy(raw, rawPosition, buffer, bufPosition, trueSize);
        rawPosition += trueSize + padSize;
        bufPosition += trueSize;
      }

      return buffer;
    }
  }
}
