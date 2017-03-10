using System;
using System.Drawing;
using Interfaces.Pool;
using Interfaces.Rendering;
using Interfaces.Rendering.Instancing;
using Interfaces.Rendering.Interfaces;
using Interfaces.Rendering.Wrappers;
using Interfaces.DebugConsole;
using Microsoft.DirectX;
using Microsoft.DirectX.Direct3D;
using Interfaces.Rendering.Primitives;

namespace Games.Halo.Tags.Classes
{
  public partial class lens_flare : IRenderable, IInstanceable
  {
    private bitmap bitmaps = null;
    private Sprite sprite = null;

    public override void DoPostProcess()
    {
      base.DoPostProcess();
      sprite = new Sprite(MdxRender.Device);
      bitmaps = Open<bitmap>(lensFlareValues.Bitmap.Value);
    }

    public override void Dispose()
    {
      base.Dispose();
      Release(bitmaps);
    }

    public void Render()
    {
      sprite.Begin(SpriteFlags.None);
      MdxRender.Device.RenderState.AlphaBlendEnable = true;
      MdxRender.Device.RenderState.AlphaTestEnable = false;
      MdxRender.Device.RenderState.ZBufferWriteEnable = false;
      MdxRender.Device.RenderState.BlendOperation = BlendOperation.Add;
      MdxRender.Device.RenderState.SourceBlend = Blend.SourceColor;
      MdxRender.Device.RenderState.DestinationBlend = Blend.One;

      for (int i = 0; i < lensFlareValues.Reflections.Count; i++)
      {
        Texture texture = bitmaps[lensFlareValues.Reflections[i].BitmapIndex.Value] as Texture;
        if (texture == null)
          continue;
        int color = new ColorValue(lensFlareValues.Reflections[i].TintColor.R, lensFlareValues.Reflections[i].TintColor.G, lensFlareValues.Reflections[i].TintColor.B, lensFlareValues.Reflections[i].TintColor.A).ToArgb();

        Vector3 position = Vector3.Project(new Vector3(0.0f, 0.0f, 0.0f), MdxRender.Device.Viewport, MdxRender.Device.Transform.Projection, MdxRender.Camera.GetViewMatrix(), MdxRender.Device.Transform.World);
        sprite.Draw(texture, new Vector3((float)(bitmaps.BitmapValues.Bitmaps[lensFlareValues.Reflections[i].BitmapIndex.Value].Width.Value / 2), (float)(bitmaps.BitmapValues.Bitmaps[lensFlareValues.Reflections[i].BitmapIndex.Value].Height.Value / 2), 0.0f), new Vector3(position.X, position.Y, 0.0f), color);
      }
      
      sprite.End();
    }

    #region Unused IRenderable Methods
    public bool IntersectRayAABB(Vector3 origin, Vector3 direction)
    {
      throw new Exception("The method or operation is not implemented.");
    }

    public Intersection IntersectRay(Vector3 origin, Vector3 direction)
    {
      throw new Exception("The method or operation is not implemented.");
    }

    public int PixelFillCount
    {
      get
      {
        return 1;
      }
      set
      {
        
      }
    }

    public bool IntersectCamera(ICamera camera)
    {
      throw new Exception("The method or operation is not implemented.");
    }

    public bool IntersectPlaneAABB(IPlane plane)
    {
      throw new Exception("The method or operation is not implemented.");
    }
    #endregion

    public Instance Instance
    {
      get
      { return new ObjectInstance(this, Vector3.Empty, BoundingBox.WorldUnitOrigin); }
    }
  }
}
