using System;
using Interfaces.Rendering.Interfaces;
using Microsoft.DirectX;
using Interfaces.Rendering.Primitives;

namespace Interfaces.Rendering.Instancing
{
  /// <summary>
  /// Represents a submesh instance of an object with a render model.
  /// </summary>
  public class PartInstance : Instance
  {
    protected IShader shader = null;

    public override void Render()
    {
      if (shader == null)
        return;
      if (entity != null && (MdxRender.DrawingTransparent == shader.Transparent || !MdxRender.DualRendering))
      {
        bool zEnable = MdxRender.Device.RenderState.ZBufferWriteEnable;
        if (shader.Transparent)
          MdxRender.Device.RenderState.ZBufferWriteEnable = false;
        entity.Render();
        if (shader.Transparent)
          MdxRender.Device.RenderState.ZBufferWriteEnable = zEnable;
      }
    }

    public virtual IShader Shader
    {
      get
      { return shader; }
    }

    public PartInstance(IRenderable entity, IShader shader, Vector3 centroid, BoundingBox boundingBox)
      : base(entity, centroid, boundingBox)
    {
      this.shader = shader;
      stationary = true;
    }
  }
}
