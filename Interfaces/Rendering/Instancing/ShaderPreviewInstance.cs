using System;
using System.Drawing;
using Microsoft.DirectX;
using Interfaces.Rendering.Interfaces;
using Interfaces.Rendering.Wrappers;
using Interfaces.Rendering.Primitives;

namespace Interfaces.Rendering.Instancing
{
  public class ShaderPreviewInstance : Instance
  {
    public ShaderPreviewInstance(IShader shader)
      : base(null, Vector3.Empty, BoundingBox.WorldUnitOrigin)
    {
      entity = new ScreenBillboard(new Point(100, 100), 512, 512, shader);
    }
    public override void Render()
    {
      entity.Render();
    }
  }
}
