using System;
using System.Collections.Generic;
using Microsoft.DirectX;
using Microsoft.DirectX.Direct3D;
using Interfaces.Rendering;
using Interfaces.Rendering.Instancing;

namespace Games.Halo.Tags.Classes
{
  public partial class shader_transparent_chicago_extended : IInstanceable
  {
    private bool fogWasEnabled = false;
    private bitmap[] maps = null;
    private InstanceCollection instances = null;

    public override void SetPass(int pass)
    {
      base.SetPass(pass);

      switch (pass)
      {
        case 0:
          bool inverseColor = false, inverseAlpha = false;
          MdxRender.Device.PixelShader = null;
          MdxRender.Device.VertexShader = null;
          MdxRender.Device.TextureState[0].AlphaOperation = TextureOperation.SelectArg1;
          MdxRender.Device.TextureState[0].ColorOperation = TextureOperation.SelectArg1;

          SetFramebufferFunction(shaderTransparentChicagoExtendedValues.FramebufferBlendFunction.Value);
          MdxRender.Device.RenderState.AlphaBlendEnable = true;
          MdxRender.Device.VertexShader = null;
          MdxRender.Device.PixelShader = null;
          MdxRender.Device.RenderState.CullMode = shaderTransparentChicagoExtendedValues.Flags.GetFlag(3) ? Cull.None : Cull.CounterClockwise;
          
          MdxRender.Device.RenderState.ReferenceAlpha = 0x80;
          MdxRender.Device.RenderState.AlphaFunction = Compare.GreaterEqual;
          if (shaderTransparentChicagoExtendedValues.Flags.GetFlag(1)) // alpha tested
            MdxRender.Device.RenderState.AlphaTestEnable = true;
          else
            MdxRender.Device.RenderState.AlphaTestEnable = false;

          List<ShaderTransparentChicagoMapBlock> stages = null;
          if (MdxRender.Device.DeviceCaps.MaxSimultaneousTextures >= 4)
            stages = shaderTransparentChicagoExtendedValues._4StageMaps;
          else
            stages = shaderTransparentChicagoExtendedValues._2StageMaps;

          for (int i = 0; i < stages.Count; i++)
          {
            // texture
            if (maps[i] == null)
              MdxRender.Device.SetTexture(i, default2d[Additive]);
            else
              MdxRender.Device.SetTexture(i, maps[i][0]);

            // texture operations
            if (i > 0)
            {
              MdxRender.Device.TextureState[i].AlphaOperation = GetColorFunction(stages[i - 1].AlphaFunction.Value, out inverseAlpha);
              MdxRender.Device.TextureState[i].ColorOperation = GetColorFunction(stages[i - 1].ColorFunction.Value, out inverseColor);
            }

            // texture arguments
            if (stages[i].Flags.GetFlag(2)) // alpha replicate
              MdxRender.Device.TextureState[i].ColorArgument1 = TextureArgument.TextureColor | TextureArgument.AlphaReplicate;
            else
              MdxRender.Device.TextureState[i].ColorArgument1 = TextureArgument.TextureColor;
            MdxRender.Device.TextureState[i].ColorArgument2 = TextureArgument.Current;
            MdxRender.Device.TextureState[i].AlphaArgument1 = TextureArgument.TextureColor;
            MdxRender.Device.TextureState[i].AlphaArgument2 = TextureArgument.Current;

            // invert texture arguments
            if (inverseAlpha)
            {
              MdxRender.Device.TextureState[i].AlphaArgument0 = MdxRender.Device.TextureState[i].AlphaArgument2;
              MdxRender.Device.TextureState[i].AlphaArgument2 = MdxRender.Device.TextureState[i].AlphaArgument1;
              MdxRender.Device.TextureState[i].AlphaArgument1 = MdxRender.Device.TextureState[i].AlphaArgument0;
            }
            if (inverseColor)
            {
              MdxRender.Device.TextureState[i].ColorArgument0 = MdxRender.Device.TextureState[i].ColorArgument2;
              MdxRender.Device.TextureState[i].ColorArgument2 = MdxRender.Device.TextureState[i].ColorArgument1;
              MdxRender.Device.TextureState[i].ColorArgument1 = MdxRender.Device.TextureState[i].ColorArgument0;
            }

            // sampling filters
            if (stages[i].Flags.GetFlag(1)) // unfiltered
            {
              MdxRender.Device.SamplerState[i].MinFilter = TextureFilter.None;
              MdxRender.Device.SamplerState[i].MagFilter = TextureFilter.None;
              MdxRender.Device.SamplerState[i].MipFilter = TextureFilter.None;
            }
            else
            {
              MdxRender.Device.SamplerState[i].MinFilter = TextureFilter.Linear;
              MdxRender.Device.SamplerState[i].MagFilter = TextureFilter.Linear;
              MdxRender.Device.SamplerState[i].MipFilter = TextureFilter.Linear;
            }
            if (stages[i].Flags.GetFlag(3)) // u-clamped
              MdxRender.Device.SamplerState[i].AddressU = TextureAddress.Clamp;
            else
              MdxRender.Device.SamplerState[i].AddressU = TextureAddress.Wrap;
            if (stages[i].Flags.GetFlag(4)) // v-clamped
              MdxRender.Device.SamplerState[i].AddressV = TextureAddress.Clamp;
            else
              MdxRender.Device.SamplerState[i].AddressV = TextureAddress.Wrap;

            // texture transforms
            Matrix transform = Matrix.Identity;
            transform.M31 /* u offset */ = stages[i].Map3.Value + Animate(stages[i].unnamed6.Value, stages[i].unnamed7.Value, stages[i].unnamed8.Value) * stages[i].unnamed9.Value;
            transform.M32 /* v offset */ = stages[i].Map4.Value + Animate(stages[i].unnamed11.Value, stages[i].unnamed12.Value, stages[i].unnamed13.Value) * stages[i].unnamed14.Value;
            transform = Matrix.Scaling(stages[i].Map.Value, stages[i].Map2.Value, 1.0f) * transform;
            MdxRender.Device.SetTransform((TransformType)((int)TransformType.Texture0 + i), transform);
            MdxRender.Device.TextureState[i].TextureTransform = TextureTransform.Count2;
            if (i == 0)
            {
              if (shaderTransparentChicagoExtendedValues.Flags.GetFlag(4)) // first map is in screenspace
                MdxRender.Device.TextureState[i].TextureCoordinateIndex = (int)TextureCoordinateIndex.CameraSpacePosition;
              else if (shaderTransparentChicagoExtendedValues.FirstMapType.Value != 0) // meaning, the first map is a cube map
              {
                MdxRender.Device.TextureState[i].TextureCoordinateIndex = (int)TextureCoordinateIndex.CameraSpaceReflectionVector;
                MdxRender.Device.TextureState[i].TextureTransform = TextureTransform.Count3;
              }
              else
                MdxRender.Device.TextureState[i].TextureCoordinateIndex = 0;
            }
            else
              MdxRender.Device.TextureState[i].TextureCoordinateIndex = 0;
            MdxRender.Device.TextureState[i].ResultArgument = TextureArgument.Current;
          }

          MdxRender.Device.TextureState[stages.Count].ColorOperation = TextureOperation.Disable;
          MdxRender.Device.TextureState[stages.Count].AlphaOperation = TextureOperation.Disable;
          break;
      }
    }

    public override int BeginApply()
    {
      base.BeginApply();
      fogWasEnabled = MdxRender.Device.RenderState.FogEnable;
      MdxRender.Device.RenderState.FogEnable = false;
      return 1;
    }

    public override void EndApply()
    {
      base.EndApply();
      MdxRender.Device.RenderState.FogEnable = fogWasEnabled;
    }

    public override void DoPostProcess()
    {
      base.DoPostProcess();

      List<ShaderTransparentChicagoMapBlock> stages = null;
      if (MdxRender.Device.DeviceCaps.MaxSimultaneousTextures >= 4)
        stages = shaderTransparentChicagoExtendedValues._4StageMaps;
      else
        stages = shaderTransparentChicagoExtendedValues._2StageMaps;
      maps = new bitmap[stages.Count];
      for (int i = 0; i < stages.Count; i++)
        maps[i] = Open<bitmap>(stages[i].Map5.Value);
    }

    public override void Dispose()
    {
      base.Dispose();

      if (maps != null)
        for (int i = 0; i < maps.Length; i++)
          Release(maps[i]);
    }

    public override bool Transparent
    {
      get
      { return true; }
    }

    protected void SetFramebufferFunction(short function)
    {
      switch (function)
      {
        case 0: // alpha blend
          MdxRender.Device.RenderState.BlendOperation = BlendOperation.Add;
          MdxRender.Device.RenderState.SourceBlend = Blend.SourceAlpha;
          MdxRender.Device.RenderState.DestinationBlend = Blend.InvSourceAlpha;
          break;
        case 1: // multiply
          MdxRender.Device.RenderState.BlendOperation = BlendOperation.Add;
          MdxRender.Device.RenderState.SourceBlend = Blend.SourceColor;
          MdxRender.Device.RenderState.DestinationBlend = Blend.DestinationColor;
          break;
        case 2: // double multiply
          MdxRender.Device.RenderState.BlendOperation = BlendOperation.Add;
          MdxRender.Device.RenderState.SourceBlend = Blend.SourceColor;
          MdxRender.Device.RenderState.DestinationBlend = Blend.DestinationColor;
          break;
        case 3: // add
          MdxRender.Device.RenderState.BlendOperation = BlendOperation.Add;
          MdxRender.Device.RenderState.SourceBlend = Blend.One;
          MdxRender.Device.RenderState.DestinationBlend = Blend.One;
          break;
        case 4: // subtract
          MdxRender.Device.RenderState.BlendOperation = BlendOperation.Subtract;
          MdxRender.Device.RenderState.SourceBlend = Blend.One;
          MdxRender.Device.RenderState.DestinationBlend = Blend.One;
          break;
        case 5: // component min
          MdxRender.Device.RenderState.BlendOperation = BlendOperation.Min;
          MdxRender.Device.RenderState.SourceBlend = Blend.One;
          MdxRender.Device.RenderState.DestinationBlend = Blend.One;
          break;
        case 6: // component max
          MdxRender.Device.RenderState.BlendOperation = BlendOperation.Max;
          MdxRender.Device.RenderState.SourceBlend = Blend.One;
          MdxRender.Device.RenderState.DestinationBlend = Blend.One;
          break;
        case 7: // alpha-multiply add
          MdxRender.Device.RenderState.BlendOperation = BlendOperation.Add;
          MdxRender.Device.RenderState.SourceBlend = Blend.SourceAlpha;
          MdxRender.Device.RenderState.DestinationBlend = Blend.DestinationAlpha;
          break;
      }
    }

    protected TextureOperation GetColorFunction(short function, out bool inverse)
    {
      inverse = false;
      switch (function)
      {
        case 0: // current
          return TextureOperation.SelectArg2;
        case 1: // next map
          return TextureOperation.SelectArg1;
        case 2: // multiply
          return TextureOperation.Modulate;
        case 3: // double multiply
          return TextureOperation.Modulate2X;
        case 4: // add
          return TextureOperation.Add;
        case 5: // add signed current
          return TextureOperation.AddSigned;
        case 6: // add signed next map
          inverse = true;
          return TextureOperation.AddSigned;
        case 7: // subtract current
          return TextureOperation.Subtract;
        case 8: // subtract next map
          inverse = true;
          return TextureOperation.Subtract;
        case 9: // blend current alpha
          return TextureOperation.BlendCurrentAlpha;
        case 10: // blend current alpha inverse
          inverse = true;
          return TextureOperation.BlendCurrentAlpha;
        case 11: // blend next map alpha
          return TextureOperation.BlendTextureAlpha;
        case 12: // blend next map alpha inverse
          inverse = true;
          return TextureOperation.BlendTextureAlpha;
        default:
          throw new HaloException("Invalid shader_transparent_chicago_extended framebuffer function {0}.", function);
      }
    }

    public Instance Instance
    {
      get
      {
        if (instances == null)
        {
          instances = new InstanceCollection();
          ShaderPreviewInstance tpi;
          tpi = new ShaderPreviewInstance(this);
          instances.Add(tpi);
        }

        InstanceCollection newInstance = new InstanceCollection();
        foreach (Instance current in instances)
          newInstance.Add(current);
        return newInstance;
      }
    }
  }
}
