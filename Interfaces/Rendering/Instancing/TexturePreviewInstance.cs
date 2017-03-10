using System;
using System.Drawing;
using Microsoft.DirectX;
using Microsoft.DirectX.Direct3D;
using Interfaces.Rendering.Wrappers;
using Interfaces.Rendering.Interfaces;
using Interfaces.Rendering.Primitives;

namespace Interfaces.Rendering.Instancing
{
  public class TexturePreviewInstance : Instance
  {
    public TexturePreviewInstance(BaseTexture texture)
      : base(null, Vector3.Empty, BoundingBox.WorldUnitOrigin)
    {
      if (texture is Texture)
      {
        Create2DTexturedBillboard((Texture)texture);
      }
      else
      {
        throw new NotImplementedException();
      }
    }
    private void Create2DTexturedBillboard(Texture tex)
    {
      SurfaceDescription sd = tex.GetLevelDescription(0);

      SimpleBitmapShader shader = new SimpleBitmapShader(tex);
      entity = new ScreenBillboard(new Point(100, 100), sd.Width, sd.Height, shader);
    }
    public override void Render()
    {
      entity.Render();
    }
  }
}