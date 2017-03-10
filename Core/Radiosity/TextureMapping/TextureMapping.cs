using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;

using AForge.Imaging.Filters;
using Interfaces.Rendering.Interfaces;
using Microsoft.DirectX;
using Microsoft.DirectX.Direct3D;

namespace Core.Radiosity.TextureMapping
{
  /// <summary>
  /// Class to describe a texture in a scene. Special case textures
  /// are stored as floating point bitmaps, such things are lightmaps.
  /// </summary>
  public class TextureMap : ITextureMap
  {
    #region Members
    private double[, ,] m_shadowBitmap;
    //private int Height, Width;
    public int Width { get; set; }
    public int Height { get; set; }
    #endregion

    #region Constructor
    /// <summary>
    /// Constructs a texture.
    /// </summary>
    /// <param name="width">Maximum x offset.</param>
    /// <param name="height">Maximum y offset.</param>
    public TextureMap(BaseTexture texture)
    {
      SurfaceDescription _info = ((Texture)texture).GetSurfaceLevel(0).Description;
      this.Width = (int)(_info.Width * Interfaces.Rendering.Radiosity.RadiosityHelper.LightmapScale);
      this.Height = (int)(_info.Height * Interfaces.Rendering.Radiosity.RadiosityHelper.LightmapScale);
      this.m_shadowBitmap = new double[Width, Height, 3];
    }
    #endregion

    #region Save to raw
    /// <summary>
    /// Saves the current texture to a bitmap image.
    /// </summary>
    /// <param name="path">Path to save to.</param>
    /// <param name="index">Index of lightmap.</param>
    public void SaveToRaw(string path, int index)
    {
      Bitmap _target = this.Filter(new LinearToneMapper(), false);
      try
      {
        _target.Save(string.Format("{0}lightmap_{1}.bmp", path, index));
        //bmp.Save(string.Format("{0}lightmap_{1}.bmp", path, index));
      }
      catch
      {
        Interfaces.Output.Write(Interfaces.OutputTypes.Developer, "Failed to save radiosity bitmap #" + index);
      }
    }
    #endregion

    public Stream SaveToStream()
    {
      MemoryStream ms = new MemoryStream();

      return ms;
    }

    /// <summary>
    /// Saves the texture to a halo engine bitmap tag. Adds another texture
    /// tile to the current bitmap tag.
    /// </summary>
    /// <param name="taglocation">Location tag should be saved to.</param>
    public void SaveToTag(string taglocation)
    {
      // TODO: savetotag.
    }

    public void SaveHDR(string path)
    {
      ToFile(m_shadowBitmap, path);
    }
    public void LoadHDR(string path)
    {
      m_shadowBitmap = TextureMap.FromFile(path);
    }

    /*public static void SaveHDR(float[, ,] hdr, string path)
    {
      FileStream fs = new FileStream(path, FileMode.Create, FileAccess.Write);
      BinaryWriter bw = new BinaryWriter(fs);

      int width = hdr.GetLength(0);
      int height = hdr.GetLength(1);
      int depth = hdr.GetLength(2);

      bw.Write(width);
      bw.Write(height);
      bw.Write(depth);

      for (int x = 0; x < width; x++)
        for (int y = 0; y < height; y++)
          for (int z = 0; z < depth; z++)
            bw.Write(hdr[x, y, z]);

      bw.Close();
    }
    public static float[, ,] LoadHDR(string path)
    {
      FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read);
      BinaryReader br = new BinaryReader(fs);

      int width = br.ReadInt32();
      int height = br.ReadInt32();
      int depth = br.ReadInt32();

      float[, ,] hdr = new float[width, height, depth];

      for (int x = 0; x < width; x++)
        for (int y = 0; y < height; y++)
          for (int z = 0; z < depth; z++)
            hdr[x, y, z] = br.ReadSingle();

      br.Close();
    }*/
    public static void ToFile(double[, ,] hdr, string path)
    {
      FileStream fs = new FileStream(path, FileMode.Create, FileAccess.Write);
      BinaryWriter bw = new BinaryWriter(fs);

      int width = hdr.GetLength(0);
      int height = hdr.GetLength(1);
      int depth = hdr.GetLength(2);

      bw.Write(width);
      bw.Write(height);
      bw.Write(depth);

      for (int x = 0; x < width; x++)
        for (int y = 0; y < height; y++)
          for (int z = 0; z < depth; z++)
            bw.Write(hdr[x, y, z]);

      bw.Close();
    }
    public static double[, ,] FromFile(string path)
    {
      FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read);
      BinaryReader br = new BinaryReader(fs);

      int width = br.ReadInt32();
      int height = br.ReadInt32();
      int depth = br.ReadInt32();

      double[, ,] hdr = new double[width, height, depth];

      for (int x = 0; x < width; x++)
        for (int y = 0; y < height; y++)
          for (int z = 0; z < depth; z++)
            hdr[x, y, z] = br.ReadDouble();

      br.Close();

      return hdr;
    }

    /// <summary>
    /// Sets a pixel to a particular colour.
    /// </summary>
    /// <param name="U">U offset</param>
    /// <param name="V">V offset</param>
    /// <param name="Colour">High dynamic range colour value.</param>
    public void AddToPixel(float u, float v, float[] colour, int radius)
    {
      int x = Convert.ToInt32(Math.Round(Math.Abs(u)*(this.Width - 1), 0));
      int y = Convert.ToInt32(Math.Round(Math.Abs(v)*(this.Height - 1), 0));

      this.m_shadowBitmap[x, y, 0] += colour[0];
      this.m_shadowBitmap[x, y, 1] += colour[1];
      this.m_shadowBitmap[x, y, 2] += colour[2];

      // TODO: draw a circle of curtain radius.
      // http://www.brackeen.com/home/vga/shapes.html#11
      return;    
    }

    public void SetPixel(float u, float v, float[] colour, int radius)
    {
      int x = (int)Math.Round(u * (this.Width - 1));
      int y = (int)Math.Round(v * (this.Height - 1));

      m_shadowBitmap[x, y, 0] = colour[0];
      m_shadowBitmap[x, y, 1] = colour[1];
      m_shadowBitmap[x, y, 2] = colour[2];

      return;
    }
    public void SetPixel(float u, float v, float[] colour)
    {
      int x = (int)Math.Round(u * (this.Width - 1));
      int y = (int)Math.Round(v * (this.Height - 1));

      m_shadowBitmap[x, y, 0] = colour[0];
      m_shadowBitmap[x, y, 1] = colour[1];
      m_shadowBitmap[x, y, 2] = colour[2];

      return;
    }
    public void SetPixel(float u, float v, Interfaces.Rendering.Primitives.RealColor color)
    {
      int x = (int)Math.Round(u * (this.Width - 1));
      int y = (int)Math.Round(v * (this.Height - 1));

      m_shadowBitmap[x, y, 0] = color[0];
      m_shadowBitmap[x, y, 1] = color[1];
      m_shadowBitmap[x, y, 2] = color[2];

      return;
    }
    public void SetPixel(int x, int y, Interfaces.Rendering.Primitives.RealColor color)
    {
      m_shadowBitmap[x, y, 0] = color[0];
      m_shadowBitmap[x, y, 1] = color[1];
      m_shadowBitmap[x, y, 2] = color[2];

      return;
    }

    #region Filter image
    /// <summary>
    /// Filters the image using a tone map operator.
    /// Uses a Gaussian filter to anti-alias the image.
    /// </summary>
    /// <returns>Filtered bitmap.</returns>
    public Bitmap Filter(IToneMapOperator _operator, bool blur) 
    {
      Bitmap _image = null;
      if (_operator != null)
      {
        _image = _operator.CreateImage(this.m_shadowBitmap, this.Width, this.Height);
      }
      else
        throw new ArgumentNullException("_operator", "Cannot filter the texture map without a tone mapping operator!");

      if (blur)
      {
        GaussianBlur _blurFilter = new GaussianBlur();
        return _blurFilter.Apply(_image);
      }
      return _image;
    }
    #endregion

    public Bitmap SaveToBitmap()
    {
      return Filter(new LinearToneMapper(), false);
    }
  }

  /// <summary>
  /// Provides traits and maps for a texture map collection.
  /// This class cannot be inherited.
  /// </summary>
  public sealed class TextureMapCollection : ITextureMapCollection, IEnumerable<ITextureMap>
  {
    #region Members
    private List<ITextureMap> m_textureMaps;
    private int m_radius;
    #endregion

    #region Properties
    /// <summary>
    /// Gets or sets the radius of the number of pixels set by the
    /// photon colliding with the texture.
    /// </summary>
    public int Radius
    {
      get { return this.m_radius; }
      set { this.m_radius = value; }
    }

    /// <summary>
    /// Number of textures in currnet collection.
    /// </summary>
    public int Count
    {
      get { return this.m_textureMaps.Count; }
    }
    #endregion

    #region Constructor
    /// <summary>
    /// Instantiate a new class.
    /// </summary>
    public TextureMapCollection()
    {
      this.m_textureMaps = new List<ITextureMap>();
      this.m_radius = 1;
    }
    #endregion

    #region Indexer
    /// <summary>
    /// Access a texturemap within the collection.
    /// </summary>
    /// <param name="index">Array index.</param>
    /// <returns>Texturemap associated with index.</returns>
    public ITextureMap this[int index]
    {
      get { return this.m_textureMaps[index]; }
      set { this.m_textureMaps[index] = value; }
    }
    #endregion

    #region Add Texture
    /// <summary>
    /// Adds a texture to the collection.
    /// </summary>
    /// <param name="texture"></param>
    public void AddTexture(ITextureMap texture)
    {
      this.m_textureMaps.Add(texture);
    }
    #endregion

    #region Save all to raw
    /// <summary>
    /// Saves all the textures to raw files.
    /// </summary>
    /// <param name="path">Path to save to.</param>
    public void SaveAllRaw(string path)
    {
      // Create the lightmap folder if it doesn't exist and get
      // the full path to save the textures to.
      string _finalLocation = this.CreateLightMapFolder(path);
      for (int _textureIndex = 0; _textureIndex < this.m_textureMaps.Count; _textureIndex++)
      {
        this.m_textureMaps[_textureIndex].SaveToRaw(_finalLocation, _textureIndex);
      }
    }
    #endregion

    #region Save all to tag
    /// <summary>
    /// Saves the current collection as a tag.
    /// Each collection entry creates a new tile in the tag.
    /// </summary>
    /// <param name="taglocation">Location of tag to save to.</param>
    public void SaveAllTag(string taglocation)
    {
      for (int i = 0; i < this.m_textureMaps.Count; i++)
        this.m_textureMaps[i].SaveToTag(taglocation);
    }
    #endregion

    /// <summary>
    /// Regenerates the UVs for a given BSP.
    /// </summary>
    /// <returns></returns>
    public static List<IBsp> RegenerateUV()
    {
      List<IBsp> _alteredModels = Prometheus.Instance.ActiveBspList;

      foreach (IBsp _bsp in _alteredModels)
      {
        //UVAtlas.Create();
      }

      return _alteredModels;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="basepath"></param>
    /// <returns></returns>
    private string CreateLightMapFolder(string basepath)
    {
      string _location = string.Format(@"{0}LightMaps\", basepath);
      if (!Directory.Exists(_location))
      {
        Directory.CreateDirectory(_location);
      }

      return _location;
    }

    /// <summary>
    /// Clears all previously created lightmaps.
    /// </summary>
    public void Clear()
    {
      m_textureMaps.Clear();
    }

    #region IEnumerable<ITextureMap> Members

    public IEnumerator<ITextureMap> GetEnumerator()
    {
      foreach (ITextureMap tex in m_textureMaps)
        yield return tex;
    }

    #endregion

    #region IEnumerable Members

    System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
    {
      throw new NotImplementedException();
    }

    #endregion
  }
}