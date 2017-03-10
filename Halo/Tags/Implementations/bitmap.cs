using System;
using System.IO;
using System.Reflection;
using Interfaces;
using Interfaces.Textures;
using Interfaces.Rendering;
using Microsoft.DirectX.Direct3D;
using Interfaces.Rendering.Instancing;

namespace Games.Halo.Tags.Classes
{
  public partial class bitmap : IInstanceable
  {
    private BaseTexture[] textures = null;

    private static int[] palette = null;
    private const short PalettizedBit = 0x4;
    private const short SwizzledBit = 0x8;
    private InstanceCollection instances;

    /// <summary>
    /// Gets a BaseTexture object representing a texture in this bitmap.
    /// </summary>
    /// <param name="index">which texture to retrieve</param>
    /// <returns>a BaseTexture reference</returns>
    public BaseTexture this[int index]
    {
      get
      { return textures[index]; }
    }

    /// <summary>
    /// This post process creates DirectX texture objects.
    /// </summary>
    public override void DoPostProcess()
    {
      // do the base post processing
      base.DoPostProcess();

      // init variables
      int count = bitmapValues.Bitmaps.Count;
      textures = new BaseTexture[count];
      ResourceType type = ParseType(bitmapValues.Type.Value);
      DirectDrawSurfaceHeader ddsHeader = new DirectDrawSurfaceHeader();

      // create size array
      int position = 0;
      int[] sizes = new int[count];
      for (int i = 0; i < count - 1; i++)
      {
        sizes[i] = bitmapValues.Bitmaps[i + 1].PixelsOffset.Value - position;
        position += sizes[i];
      }
      sizes[count - 1] = bitmapValues.ProcessedPixelData.Binary.Length - position;

      // create textures
      for (int i = 0; i < count; i++)
      {
        short displayMipCount = bitmapValues.Bitmaps[i].MipmapCount.Value;
        if(type == ResourceType.Textures)
          displayMipCount = (short)Math.Max(1, displayMipCount - 2); // HACK: this prevents blackness taking over when we retreat from textures
        Format format = ParseFormat(bitmapValues.Bitmaps[i].Format.Value);
        BinaryWriter memWriter = ddsHeader.CreateMemoryStream(format == Format.P8 ? Format.A8R8G8B8 : format, bitmapValues.Bitmaps[i].Width.Value, bitmapValues.Bitmaps[i].Height.Value, bitmapValues.Bitmaps[i].Depth.Value, displayMipCount, type == ResourceType.CubeTexture);
        int bitsPerPixel = format == Format.P8 ? 8 : ddsHeader.BitCount;
        byte[] raw = new byte[sizes[i]];

        Array.Copy(bitmapValues.ProcessedPixelData.Binary, bitmapValues.Bitmaps[i].PixelsOffset.Value, raw, 0, sizes[i]);
        if (type == ResourceType.CubeTexture)
          raw = ReorderCubeTexture(raw, bitmapValues.Bitmaps[i].Width.Value, bitmapValues.Bitmaps[i].Height.Value, bitmapValues.Bitmaps[i].MipmapCount.Value, bitsPerPixel);

        if ((bitmapValues.Bitmaps[i].Flags.Value & SwizzledBit) != 0)
          raw = Swizzler.Swizzle(raw, bitmapValues.Bitmaps[i].Width.Value, bitmapValues.Bitmaps[i].Height.Value, bitmapValues.Bitmaps[i].Depth.Value, bitsPerPixel, /* i seem to remember this being right */ (bitmapValues.Bitmaps[i].Flags.Value & PalettizedBit) != 0);

        if ((bitmapValues.Bitmaps[i].Flags.Value & PalettizedBit) != 0)
          raw = DePalettize(raw, ref bitsPerPixel);

        memWriter.Write(raw);
        memWriter.Write(new byte[Compression.Pad(sizes[i], 0x80)]);
        memWriter.BaseStream.Position = 0;
        if (type == ResourceType.Textures)
          textures[i] = TextureLoader.FromStream(MdxRender.Device, memWriter.BaseStream);
        else if (type == ResourceType.CubeTexture)
          textures[i] = TextureLoader.FromCubeStream(MdxRender.Device, memWriter.BaseStream);
        else if (type == ResourceType.VolumeTexture)
          textures[i] = TextureLoader.FromVolumeStream(MdxRender.Device, memWriter.BaseStream);
        else
          throw new HaloException("Unsupported texture type: {0}.", type);
        // DEBUG:
        //TextureLoader.Save(System.Windows.Forms.Application.StartupPath + "\\texture dump\\" + Path.GetFileNameWithoutExtension(Name) + '[' + i.ToString() + "].dds", ImageFileFormat.Dds, textures[i]);
      }
    }

    private byte[] ReorderCubeTexture(byte[] raw, short width, short height, short mipMapCount, int bitsPerPixel)
    {
      int cubeAntiPadLength = 0;
      if (bitsPerPixel == 16 || bitsPerPixel == 32)
        cubeAntiPadLength = 4; // HACK: this fixes the cube map load scramble

      byte[] cubeRemap = new byte[raw.Length + cubeAntiPadLength * 6];
      int faceSize = 0;
      int[] mipPixelSizes = new int[mipMapCount + 1];
      for (short m = 0; m <= mipMapCount; m++)
      {
        int mipPixelLength = (width / (short)Math.Pow(2, m) <= 0) ? 1 : width / (short)Math.Pow(2, m);
        mipPixelLength *= (height / (short)Math.Pow(2, m) <= 0) ? 1 : height / (short)Math.Pow(2, m);
        //mipPixelLength *= ((short)bitmaps.GetValue(b, 3) / (short)Math.Pow(2, m) <= 0) ? 1 : (short)bitmaps.GetValue(b, 3) / (short)Math.Pow(2, m);
        mipPixelLength *= bitsPerPixel;
        mipPixelLength /= 8;
        mipPixelLength = Math.Max(mipPixelLength, 4);
        mipPixelSizes[m] = mipPixelLength;
        faceSize += mipPixelLength;
      }
      short ddsFace = 0;
      for (short face = 0; face < 6; face++)
      {
        for (short m = 0; m <= mipMapCount; m++)
        {
          int priorXboxMipLength = 0;
          for (short mipLevel = 0; mipLevel < m; mipLevel++)
            priorXboxMipLength += mipPixelSizes[mipLevel];
          int priorPCMipLength = mipPixelSizes[m] * face;
          for (short mipLevel = 0; mipLevel < m; mipLevel++)
            priorPCMipLength += mipPixelSizes[mipLevel] * 6;
          Array.Copy(raw, priorPCMipLength, cubeRemap, ddsFace * faceSize + priorXboxMipLength - cubeAntiPadLength * ddsFace, mipPixelSizes[m]);
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
      return cubeRemap;
    }

    public override void Dispose()
    {
      base.Dispose();

      if (textures != null)
      {
        for (int i = 0; i < textures.Length; i++)
          if (textures[i] != null)
            textures[i].Dispose();
      }
    }

    /// <summary>
    /// Converts a palettized normal map into a standard X8R8G8B8 normal map.
    /// </summary>
    /// <remarks>i could make a much faster, unsafe version of this method if need be</remarks>
    protected static byte[] DePalettize(byte[] raw, ref int bitsPerPixel)
    {
      if (bitsPerPixel != sizeof(byte) * 8)
        throw new HaloException("Cannot depalettize a bitmap with a bits per pixel value of {0} (it must be {1}).", bitsPerPixel, sizeof(byte) * 8);
      else
        bitsPerPixel = sizeof(int) * 8;

      int length = raw.Length;
      byte[] dpRaw = new byte[length * sizeof(int)];
      for (int i = 0; i < length; i++)
        Array.Copy(BitConverter.GetBytes(palette[raw[i * sizeof(byte)]]), 0, dpRaw, i * sizeof(int), sizeof(int));

      return dpRaw;
    }

    /// <summary>
    /// Removes Halo's annoying padding between cube faces.
    /// </summary>
    protected static byte[] UnpadCubeTexture(byte[] raw, int width, int height, int mipMapCount, int bitsPerPixel)
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
      int rawPosition = 0;
      byte[] buffer = new byte[trueSize * 6];
      for (int i = 0; i < 6; i++)
      {
        Array.Copy(raw, rawPosition, buffer, bufPosition, trueSize);
        rawPosition += trueSize + padSize;
        bufPosition += trueSize;
      }

      return buffer;
    }

    /// <summary>
    /// Returns the DirectX format of the given subtexture.
    /// </summary>
    public Format GetFormat(int subtexture)
    { return ParseFormat(bitmapValues.Bitmaps[subtexture].Format.Value); }

    /// <summary>
    /// Parses the format field in a Halo bitmap.
    /// </summary>
    /// <param name="haloType">halo format</param>
    /// <returns>DirectX format for generic texture loader</returns>
    protected static Format ParseFormat(short haloType)
    {
      switch (haloType)
      {
        case 0x0:
          return Format.A8;
        case 0x1:
          return Format.L8;
        case 0x2:
          return Format.A4L4;
        case 0x3:
          return Format.A8L8;
        case 0x6:
          return Format.R5G6B5;
        case 0x8:
          return Format.A1R5G5B5;
        case 0x9:
          return Format.A4R4G4B4;
        case 0xA:
          return Format.X8R8G8B8;
        case 0xB:
          return Format.A8R8G8B8;
        case 0xE:
          return Format.Dxt1;
        case 0xF:
          return Format.Dxt3;
        case 0x10:
          return Format.Dxt4;
        case 0x11:		
          return Format.P8;
        default:
          throw new ArgumentException("Tried to parse an invalid bitmap format of 0x" + Convert.ToString(haloType, 16) + '.', "haloType");
      }
    }

    /// <summary>
    /// Parses the type field in a Halo bitmap tag.
    /// </summary>
    /// <param name="haloType">bitmap type field</param>
    /// <returns>DirectX ResourceType value representing the bitmap type</returns>
    protected static ResourceType ParseType(short haloType)
    {
      switch (haloType)
      {
        case 0x0:
        case 0x3:
        case 0x4:
          return ResourceType.Textures;
        case 0x1:
          return ResourceType.VolumeTexture;
        case 0x2:
          return ResourceType.CubeTexture;
        default:
          throw new ArgumentException("Tried to parse an invalid bitmap type of 0x" + Convert.ToString(haloType, 16) + '.', "haloType");
      }
    }

    /// <summary>
    /// Initializes bitmap - loads the texture palette.
    /// </summary>
    static bitmap()
    {
      BinaryReader pReader = new BinaryReader(Assembly.GetExecutingAssembly().GetManifestResourceStream("Games.Halo.Resources.texture_palette.bin"));
      palette = new int[(int)pReader.BaseStream.Length / sizeof(int)];

      for (int i = 0; i < palette.Length; i++)
        palette[i] = pReader.ReadInt32();

      pReader.Close();
    }

    /// <summary>
    /// Used for preview
    /// </summary>
    public Instance Instance
    {
      get
      {
        if (instances == null)
        {
          instances = new InstanceCollection();
          //Create the texture preview object
          TexturePreviewInstance tpi;

          if (textures.Length > 0)
          {
            tpi = new TexturePreviewInstance(textures[0]);
            instances.Add(tpi);
          }
        }

        InstanceCollection newInstance = new InstanceCollection();
        foreach (Instance current in instances)
          newInstance.Add(current);
        return newInstance;
      }
    }
  }
  public enum BitmapFormats
  {
    A8 = 0, L8, A4L4, A8L8, R5G6B5 = 0x6, A1R5G5B5 = 0x8, A4R4G4B4, X8R8G8B8, A8R8G8B8, Dxt1 = 0xe, Dxt3, Dxt4, P8
  }
}
