using System;
using System.Collections.Generic;
using Microsoft.DirectX;
using Microsoft.DirectX.Direct3D;
using Interfaces.Rendering.Instancing;
using Interfaces.Rendering;

namespace Games.Halo.Tags.Classes
{
  public partial class shader_transparent_water : IInstanceable
  {
    private bitmap baseMapTag = null;
    private bitmap reflectionMapTag = null;
    private bitmap rippleMapsTag = null;

    private Effect effect = null;
    private EffectHandle technique = null;
    private EffectHandle lightmapHandle = null;
    private EffectHandle worldHandle = null;
    private EffectHandle wvpHandle = null;
    private EffectHandle cameraHandle = null;
    private EffectHandle[] animations = null;

    private List<Matrix> rippleTransforms = new List<Matrix>();
    private InstanceCollection instances = null;

    public override void DoPostProcess()
    {
      // always call the base function for DoPostProcess()
      base.DoPostProcess();

      //load texture references
      baseMapTag = Open<bitmap>(shaderTransparentWaterValues.BaseMap.Value);
      reflectionMapTag = Open<bitmap>(shaderTransparentWaterValues.ReflectionMap.Value);
      rippleMapsTag = Open<bitmap>(shaderTransparentWaterValues.RippleMaps.Value);

      //initialize texture transforms
      for (int i = 0; i < rippleTransforms.Count; i++)
      {
        float u_offset = shaderTransparentWaterValues.Ripples[i].MapOffset.I;
        float v_offset = shaderTransparentWaterValues.Ripples[i].MapOffset.K;

        Matrix tmp = new Matrix();
        tmp = Matrix.Identity;
        tmp.M31 = u_offset;
        tmp.M32 = v_offset;
        tmp.Scale(
          shaderTransparentWaterValues.RippleScale.Value,
          shaderTransparentWaterValues.RippleScale.Value,
          0);
        rippleTransforms.Add(tmp);
      }

      // initialize effects
      if (MdxRender.Device.DeviceCaps.PixelShaderVersion.Major >= 2)
      {
        string shaderErrors = null;
        effect = Effect.FromStream(MdxRender.Device, System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("Games.Halo.Resources.Shaders.shader_transparent_water.fx"), null, null, ShaderFlags.None, null, out shaderErrors);
        if (!String.IsNullOrEmpty(shaderErrors))
          LogError("Failed to initialize shader_transparent_water effect: {0}", shaderErrors);

        lightmapHandle = effect.GetParameter(null, "LightMap");
        worldHandle = effect.GetParameter(null, "world");
        wvpHandle = effect.GetParameter(null, "worldViewProjection");
        cameraHandle = effect.GetParameter(null, "cameraPosition");
        animations = new EffectHandle[4];
        for (int i = 0; i < 4; i++)
          animations[i] = effect.GetParameter(null, "animation" + i.ToString());

        effect.SetValue(effect.GetParameter(null, "alphaModulatesReflection"), (shaderTransparentWaterValues.Flags.Value & 0x1) != 0);
        effect.SetValue(effect.GetParameter(null, "colorModulatesBackground"), (shaderTransparentWaterValues.Flags.Value & 0x2) != 0);

        effect.SetValue(effect.GetParameter(null, "rippleCount"), shaderTransparentWaterValues.Ripples.Count);
        effect.SetValue(effect.GetParameter(null, "rippleScale"), shaderTransparentWaterValues.RippleScale.Value);
        effect.SetValue(effect.GetParameter(null, "rippleAngle"), shaderTransparentWaterValues.RippleAnimationAngle.Value);

        if (shaderTransparentWaterValues.Ripples.Count > 0)
        {
          effect.SetValue(effect.GetParameter(null, "factor0"), shaderTransparentWaterValues.Ripples[0].ContributionFactor.Value);
          effect.SetValue(effect.GetParameter(null, "repeat0"), (float)shaderTransparentWaterValues.Ripples[0].MapRepeats.Value);
          effect.SetValue(effect.GetParameter(null, "angle0"), shaderTransparentWaterValues.Ripples[0].AnimationAngle.Value);
          effect.SetValue(effect.GetParameter(null, "offset0"), new Vector4(shaderTransparentWaterValues.Ripples[0].MapOffset.I, shaderTransparentWaterValues.Ripples[0].MapOffset.K, 0.0f, 0.0f));
          if (shaderTransparentWaterValues.Ripples.Count > 1)
          {
            effect.SetValue(effect.GetParameter(null, "factor1"), shaderTransparentWaterValues.Ripples[1].ContributionFactor.Value);
            effect.SetValue(effect.GetParameter(null, "repeat1"), (float)shaderTransparentWaterValues.Ripples[1].MapRepeats.Value);
            effect.SetValue(effect.GetParameter(null, "angle1"), shaderTransparentWaterValues.Ripples[1].AnimationAngle.Value);
            effect.SetValue(effect.GetParameter(null, "offset1"), new Vector4(shaderTransparentWaterValues.Ripples[1].MapOffset.I, shaderTransparentWaterValues.Ripples[1].MapOffset.K, 0.0f, 0.0f));
            if (shaderTransparentWaterValues.Ripples.Count > 2)
            {
              effect.SetValue(effect.GetParameter(null, "factor2"), shaderTransparentWaterValues.Ripples[2].ContributionFactor.Value);
              effect.SetValue(effect.GetParameter(null, "repeat2"), (float)shaderTransparentWaterValues.Ripples[2].MapRepeats.Value);
              effect.SetValue(effect.GetParameter(null, "angle2"), shaderTransparentWaterValues.Ripples[2].AnimationAngle.Value);
              effect.SetValue(effect.GetParameter(null, "offset2"), new Vector4(shaderTransparentWaterValues.Ripples[2].MapOffset.I, shaderTransparentWaterValues.Ripples[2].MapOffset.K, 0.0f, 0.0f));
              if (shaderTransparentWaterValues.Ripples.Count > 3)
              {
                effect.SetValue(effect.GetParameter(null, "factor3"), shaderTransparentWaterValues.Ripples[3].ContributionFactor.Value);
                effect.SetValue(effect.GetParameter(null, "repeat3"), (float)shaderTransparentWaterValues.Ripples[3].MapRepeats.Value);
                effect.SetValue(effect.GetParameter(null, "angle3"), shaderTransparentWaterValues.Ripples[3].AnimationAngle.Value);
                effect.SetValue(effect.GetParameter(null, "offset3"), new Vector4(shaderTransparentWaterValues.Ripples[3].MapOffset.I, shaderTransparentWaterValues.Ripples[3].MapOffset.K, 0.0f, 0.0f));
              }
            }
          }
        }

        effect.SetValue(effect.GetParameter(null, "perpendicularBrightness"), shaderTransparentWaterValues.ViewPerpendicularBrightness.Value);
        effect.SetValue(effect.GetParameter(null, "parallelBrightness"), shaderTransparentWaterValues.ViewParallelBrightness.Value);
        effect.SetValue(effect.GetParameter(null, "perpendicularColor"), new Vector4(shaderTransparentWaterValues.ViewPerpendicularTintColor.R, shaderTransparentWaterValues.ViewPerpendicularTintColor.G, shaderTransparentWaterValues.ViewPerpendicularTintColor.B, 1.0f));
        effect.SetValue(effect.GetParameter(null, "parallelColor"), new Vector4(shaderTransparentWaterValues.ViewParallelTintColor.R, shaderTransparentWaterValues.ViewParallelTintColor.G, shaderTransparentWaterValues.ViewParallelTintColor.B, 1.0f));

        if (baseMapTag == null)
          effect.SetValue(effect.GetParameter(null, "BaseMap"), default2d[Additive]);
        else
          effect.SetValue(effect.GetParameter(null, "BaseMap"), baseMapTag[0]);

        if (reflectionMapTag == null)
          effect.SetValue(effect.GetParameter(null, "EnvironmentMap"), defaultCube[SignedAdditive]);
        else
          effect.SetValue(effect.GetParameter(null, "EnvironmentMap"), reflectionMapTag[0]);

        if (rippleMapsTag == null)
        {
          effect.SetValue(effect.GetParameter(null, "RippleMap0"), default2d[Vector]);
          effect.SetValue(effect.GetParameter(null, "RippleMap1"), default2d[Vector]);
          effect.SetValue(effect.GetParameter(null, "RippleMap2"), default2d[Vector]);
          effect.SetValue(effect.GetParameter(null, "RippleMap3"), default2d[Vector]);
        }
        else
        {
          if (shaderTransparentWaterValues.Ripples.Count > 0)
          {
            effect.SetValue(effect.GetParameter(null, "RippleMap0"), rippleMapsTag[shaderTransparentWaterValues.Ripples[0].MapIndex.Value]);
            if (shaderTransparentWaterValues.Ripples.Count > 1)
            {
              effect.SetValue(effect.GetParameter(null, "RippleMap1"), rippleMapsTag[shaderTransparentWaterValues.Ripples[1].MapIndex.Value]);
              if (shaderTransparentWaterValues.Ripples.Count > 2)
              {
                effect.SetValue(effect.GetParameter(null, "RippleMap2"), rippleMapsTag[shaderTransparentWaterValues.Ripples[2].MapIndex.Value]);
                if (shaderTransparentWaterValues.Ripples.Count > 3)
                  effect.SetValue(effect.GetParameter(null, "RippleMap3"), rippleMapsTag[shaderTransparentWaterValues.Ripples[3].MapIndex.Value]);
                else
                  effect.SetValue(effect.GetParameter(null, "RippleMap3"), default2d[Vector]);
              }
              else
                effect.SetValue(effect.GetParameter(null, "RippleMap2"), default2d[Vector]);
            }
            else
              effect.SetValue(effect.GetParameter(null, "RippleMap1"), default2d[Vector]);
          }
          else
            effect.SetValue(effect.GetParameter(null, "RippleMap0"), default2d[Vector]);
        }

        effect.Technique = technique = effect.GetTechnique("Water");
      }
    }

    public override void Dispose()
    {
      base.Dispose();

      if (effect != null)
        effect.Dispose();

      Release(baseMapTag);
      Release(reflectionMapTag);
      Release(rippleMapsTag);
    }

    public override bool Transparent
    {
      get
      { return true; }
    }

    public override int BeginApply()
    {
      base.BeginApply();

      if (technique == null)
        return 0;
      else
      {
        effect.SetValue(cameraHandle, new Vector4(MdxRender.Camera.Position.X, MdxRender.Camera.Position.Y, MdxRender.Camera.Position.Z, 1.0f));
        effect.SetValue(worldHandle, MdxRender.Device.Transform.World);
        effect.SetValue(wvpHandle, MdxRender.Device.Transform.World * MdxRender.Device.Transform.View * MdxRender.Device.Transform.Projection);
        for (int i = 0; i < shaderTransparentWaterValues.Ripples.Count; i++)
        {
          float frequency = shaderTransparentWaterValues.RippleAnimationVelocity.Value * shaderTransparentWaterValues.Ripples[i].AnimationVelocity.Value;
          if (frequency == 0.0f)
            frequency = shaderTransparentWaterValues.Ripples[i].AnimationVelocity.Value;
          effect.SetValue(animations[i], Animate(6, 1.0f / frequency, 0.0f));
        }

        if (lightmap == null)
          effect.SetValue(lightmapHandle, default2d[Multiplicative]);
        else
          effect.SetValue(lightmapHandle, lightmap);
        effect.CommitChanges();

        return effect.Begin(FX.DoNotSaveState);
      }
    }

    public override void SetPass(int pass)
    {
      base.SetPass(pass);

      if (technique != null)
        SetPassShaders(pass);
    }

    private void SetPassShaders(int pass)
    {
      if (pass == 0)
      {
        MdxRender.Device.RenderState.AlphaTestEnable = false;
        MdxRender.Device.RenderState.CullMode = Cull.None;

        MdxRender.Device.RenderState.AlphaBlendEnable = true;
        MdxRender.Device.RenderState.SourceBlend = Blend.SourceColor;
        MdxRender.Device.RenderState.DestinationBlend = Blend.One;
        MdxRender.Device.RenderState.BlendOperation = BlendOperation.Add;
      }
      else
        effect.EndPass();
      effect.BeginPass(pass);
    }

    public override void EndApply()
    {
      base.EndApply();
      if (technique != null)
      {
        effect.EndPass();
        effect.End();
      }
    }

    /// <summary>
    /// Gets an Instance that can preview this shader.
    /// </summary>
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

    public override void OnDeviceReset()
    {
      base.OnDeviceReset();
      effect.OnResetDevice();
    }

    public override void OnDeviceLost()
    {
      base.OnDeviceLost();
      effect.OnLostDevice();
    }
  }
}
