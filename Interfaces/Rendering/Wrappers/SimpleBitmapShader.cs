using System;
using Interfaces.Rendering.Interfaces;
using Microsoft.DirectX.Direct3D;

namespace Interfaces.Rendering.Wrappers
{
  class SimpleBitmapShader : IShader
  {
    private Texture texture;

    public Texture BaseTexture
    {
      get { return texture; }
      set { texture = value; }
    }
    public SimpleBitmapShader(Texture tex)
    {
      this.texture = tex;
    }
    public int BeginApply()
    {
      MdxRender.Device.RenderState.CullMode = Cull.None;
      MdxRender.Device.RenderState.AlphaBlendEnable = false;
      MdxRender.Device.RenderState.FogEnable = false;
      return 1;
    }

    public void SetPass(int pass)
    {
      if (pass == 0)
      {
        MdxRender.Device.SetTexture(0, this.texture);
        MdxRender.Device.TextureState[0].ColorArgument1 = TextureArgument.TextureColor;
        MdxRender.Device.TextureState[0].ColorOperation = TextureOperation.SelectArg1;
        MdxRender.Device.TextureState[0].AlphaOperation = TextureOperation.Disable;
        MdxRender.Device.TextureState[0].TextureTransform = TextureTransform.Disable;
        MdxRender.Device.TextureState[1].ColorOperation = TextureOperation.Disable;
        MdxRender.Device.TextureState[0].TextureCoordinateIndex = 0;
      }
      else
      {
        throw new InvalidCallException();
      }
    }

    public virtual bool Transparent
    {
      get
      { return false; }
    }

    public void EndApply()
    {
      MdxRender.Device.RenderState.CullMode = Cull.CounterClockwise;
    }

    /// <summary>
    /// Not used in this implementation.
    /// </summary>
    public Texture Lightmap
    {
      get { return null; }
      set { }
    }
  }
}
