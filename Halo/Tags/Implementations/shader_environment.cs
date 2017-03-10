using System;
using Microsoft.DirectX;
using Microsoft.DirectX.Direct3D;
using Interfaces.Rendering;
using Interfaces.Rendering.Instancing;

namespace Games.Halo.Tags.Classes
{
  public partial class shader_environment : IInstanceable 
  {
    private bitmap baseMapTag = null;
    private bitmap primaryDetailMapTag = null;
    private bitmap secondaryDetailMapTag = null;
    private bitmap microDetailMapTag = null;
    private bitmap bumpMapTag = null;
    private bitmap environmentMapTag = null;
    private bitmap glowMapTag = null;

    private Matrix primaryDetailMapTransform = new Matrix();
    private Matrix secondaryDetailMapTransform = new Matrix();
    private Matrix microDetailMapTransform = new Matrix();

    private Effect effect = null;
    private EffectHandle technique = null;
    private EffectHandle lightmapHandle = null;
    private EffectHandle worldHandle = null;
    private EffectHandle wvpHandle = null;
    private EffectHandle cameraHandle = null;
    private EffectHandle uValueHandle = null;
    private EffectHandle vValueHandle = null;
    private EffectHandle primaryValueHandle = null;
    private EffectHandle secondaryValueHandle = null;
    private EffectHandle plasmaValueHandle = null;
    private EffectHandle fogStartHandle = null;
    private EffectHandle fogEndHandle = null;
    private EffectHandle fogDensityHandle = null;
    private EffectHandle ambientColorHandle = null;
    private InstanceCollection instances;

    public override void DoPostProcess()
    {
      // always call the base function for DoPostProcess()
      base.DoPostProcess();

      //load texture references
      baseMapTag = Open<bitmap>(shaderEnvironmentValues.BaseMap.Value);
      primaryDetailMapTag = Open<bitmap>(shaderEnvironmentValues.PrimaryDetailMap.Value);
      secondaryDetailMapTag = Open<bitmap>(shaderEnvironmentValues.SecondaryDetailMap.Value);
      microDetailMapTag = Open<bitmap>(shaderEnvironmentValues.MicroDetailMap.Value);
      bumpMapTag = Open<bitmap>(shaderEnvironmentValues.BumpMap.Value);
      environmentMapTag = Open<bitmap>(shaderEnvironmentValues.ReflectionCubeMap.Value);
      glowMapTag = Open<bitmap>(shaderEnvironmentValues.Map.Value);

      //initialize texture transforms
      primaryDetailMapTransform.Scale(
        shaderEnvironmentValues.PrimaryDetailMapScale.Value,
        shaderEnvironmentValues.PrimaryDetailMapScale.Value,
        1);

      secondaryDetailMapTransform.Scale(
        shaderEnvironmentValues.SecondaryDetailMapScale.Value,
        shaderEnvironmentValues.SecondaryDetailMapScale.Value,
        1);

      microDetailMapTransform.Scale(
        shaderEnvironmentValues.MicroDetailMapScale.Value,
        shaderEnvironmentValues.MicroDetailMapScale.Value,
        1);

      // load the environment shader and set our values
      if (MdxRender.Device.DeviceCaps.PixelShaderVersion.Major >= 2)
      {
        string shaderErrors = null;
        effect = Effect.FromStream(MdxRender.Device, System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("Games.Halo.Resources.Shaders.shader_environment.fx"), null, null, ShaderFlags.None, null, out shaderErrors);
        if (!String.IsNullOrEmpty(shaderErrors))
          LogError("Failed to initialize shader_environment effect: {0}", shaderErrors);
        lightmapHandle = effect.GetParameter(null, "LightMap");
        worldHandle = effect.GetParameter(null, "world");
        wvpHandle = effect.GetParameter(null, "worldViewProjection");
        cameraHandle = effect.GetParameter(null, "cameraPosition");
        primaryValueHandle = effect.GetParameter(null, "primaryAnimationValue");
        secondaryValueHandle = effect.GetParameter(null, "secondaryAnimationValue");
        plasmaValueHandle = effect.GetParameter(null, "plasmaAnimationValue");
        uValueHandle = effect.GetParameter(null, "uAnimationValue");
        vValueHandle = effect.GetParameter(null, "vAnimationValue");
        fogStartHandle = effect.GetParameter(null, "fogStart");
        fogEndHandle = effect.GetParameter(null, "fogEnd");
        fogDensityHandle = effect.GetParameter(null, "fogDensity");
        ambientColorHandle = effect.GetParameter(null, "ambientColor");

        if (environmentMapTag == null || (shaderEnvironmentValues.ParallelBrightness.Value == 0.0f && shaderEnvironmentValues.PerpendicularBrightness.Value == 0.0f))
        {
          switch (shaderEnvironmentValues.Type.Value)
          {
            case 0: // normal
              switch (shaderEnvironmentValues.DetailMapFunction.Value)
              {
                case 0: // double multiply
                  switch (shaderEnvironmentValues.MicroDetailMapFunction.Value)
                  {
                    case 0: // double multiply
                      effect.Technique = technique = effect.GetTechnique("NormalDMDMDetailBlend");
                      SetDetail(SignedAdditive, SignedAdditive);
                      break;
                    case 1: // multiply
                      effect.Technique = technique = effect.GetTechnique("NormalDMMDetailBlend");
                      SetDetail(SignedAdditive, Multiplicative);
                      break;
                    case 2: // biased add
                      effect.Technique = technique = effect.GetTechnique("NormalDMADetailBlend");
                      SetDetail(SignedAdditive, SignedAdditive);
                      break;
                  }
                  break;
                case 1: // multiply
                  switch (shaderEnvironmentValues.MicroDetailMapFunction.Value)
                  {
                    case 0: // double multiply
                      effect.Technique = technique = effect.GetTechnique("NormalMDMDetailBlend");
                      SetDetail(Multiplicative, SignedAdditive);
                      break;
                    case 1: // multiply
                      effect.Technique = technique = effect.GetTechnique("NormalMMDetailBlend");
                      SetDetail(Multiplicative, SignedAdditive);
                      break;
                    case 2: // biased add
                      effect.Technique = technique = effect.GetTechnique("NormalMADetailBlend");
                      SetDetail(Multiplicative, SignedAdditive);
                      break;
                  }
                  break;
                case 2: // biased add
                  switch (shaderEnvironmentValues.MicroDetailMapFunction.Value)
                  {
                    case 0: // double multiply
                      effect.Technique = technique = effect.GetTechnique("NormalADMDetailBlend");
                      SetDetail(SignedAdditive, SignedAdditive);
                      break;
                    case 1: // multiply
                      effect.Technique = technique = effect.GetTechnique("NormalAMDetailBlend");
                      SetDetail(SignedAdditive, Multiplicative);
                      break;
                    case 2: // biased add
                      effect.Technique = technique = effect.GetTechnique("NormalAADetailBlend");
                      SetDetail(SignedAdditive, SignedAdditive);
                      break;
                  }
                  break;
              }
              break;
            case 1: // normal
              switch (shaderEnvironmentValues.DetailMapFunction.Value)
              {
                case 0: // double multiply
                  switch (shaderEnvironmentValues.MicroDetailMapFunction.Value)
                  {
                    case 0: // double multiply
                      effect.Technique = technique = effect.GetTechnique("BlendedDMDMDetailBlend");
                      SetDetail(SignedAdditive, SignedAdditive);
                      break;
                    case 1: // multiply
                      effect.Technique = technique = effect.GetTechnique("BlendedDMMDetailBlend");
                      SetDetail(SignedAdditive, Multiplicative);
                      break;
                    case 2: // biased add
                      effect.Technique = technique = effect.GetTechnique("BlendedDMADetailBlend");
                      SetDetail(SignedAdditive, SignedAdditive);
                      break;
                  }
                  break;
                case 1: // multiply
                  switch (shaderEnvironmentValues.MicroDetailMapFunction.Value)
                  {
                    case 0: // double multiply
                      effect.Technique = technique = effect.GetTechnique("BlendedMDMDetailBlend");
                      SetDetail(Multiplicative, SignedAdditive);
                      break;
                    case 1: // multiply
                      effect.Technique = technique = effect.GetTechnique("BlendedMMDetailBlend");
                      SetDetail(Multiplicative, Multiplicative);
                      break;
                    case 2: // biased add
                      effect.Technique = technique = effect.GetTechnique("BlendedMADetailBlend");
                      SetDetail(Multiplicative, SignedAdditive);
                      break;
                  }
                  break;
                case 2: // biased add
                  switch (shaderEnvironmentValues.MicroDetailMapFunction.Value)
                  {
                    case 0: // double multiply
                      effect.Technique = technique = effect.GetTechnique("BlendedADMDetailBlend");
                      SetDetail(SignedAdditive, SignedAdditive);
                      break;
                    case 1: // multiply
                      effect.Technique = technique = effect.GetTechnique("BlendedAMDetailBlend");
                      SetDetail(SignedAdditive, Multiplicative);
                      break;
                    case 2: // biased add
                      effect.Technique = technique = effect.GetTechnique("BlendedAADetailBlend");
                      SetDetail(SignedAdditive, SignedAdditive);
                      break;
                  }
                  break;
              }
              break;
          }
        }
        else
        {
          switch (shaderEnvironmentValues.Type2.Value)
          {
            case 0:
              switch (shaderEnvironmentValues.MicroDetailMapFunction.Value)
              {
                case 0: // double multiply
                  effect.Technique = technique = effect.GetTechnique("BumpedEnvironmentMapDM");
                  SetDetail(SignedAdditive, SignedAdditive);
                  break;
                case 1: // multiply
                  effect.Technique = technique = effect.GetTechnique("BumpedEnvironmentMapM");
                  SetDetail(SignedAdditive, Multiplicative);
                  break;
                case 2: // biased add
                  effect.Technique = technique = effect.GetTechnique("BumpedEnvironmentMapA");
                  SetDetail(SignedAdditive, SignedAdditive);
                  break;
              }
              break;
            case 1:
              switch (shaderEnvironmentValues.MicroDetailMapFunction.Value)
              {
                case 0: // double multiply
                  effect.Technique = technique = effect.GetTechnique("FlatEnvironmentMapDM");
                  SetDetail(SignedAdditive, SignedAdditive);
                  break;
                case 1: // multiply
                  effect.Technique = technique = effect.GetTechnique("FlatEnvironmentMapM");
                  SetDetail(SignedAdditive, Multiplicative);
                  break;
                case 2: // biased add
                  effect.Technique = technique = effect.GetTechnique("FlatEnvironmentMapA");
                  SetDetail(SignedAdditive, SignedAdditive);
                  break;
              }
              break;
          }
        }

        effect.SetValue(effect.GetParameter(null, "bumpScale"), shaderEnvironmentValues.BumpMapScale.Value);
        effect.SetValue(effect.GetParameter(null, "detailAScale"), shaderEnvironmentValues.PrimaryDetailMapScale.Value);
        effect.SetValue(effect.GetParameter(null, "detailBScale"), shaderEnvironmentValues.SecondaryDetailMapScale.Value);
        effect.SetValue(effect.GetParameter(null, "microDetailScale"), shaderEnvironmentValues.MicroDetailMapScale.Value);
        effect.SetValue(effect.GetParameter(null, "glowScale"), shaderEnvironmentValues.MapScale.Value);

        effect.SetValue(effect.GetParameter(null, "parallelShininess"), shaderEnvironmentValues.ParallelBrightness.Value);
        effect.SetValue(effect.GetParameter(null, "perpendicularShininess"), shaderEnvironmentValues.PerpendicularBrightness.Value);

        effect.SetValue(effect.GetParameter(null, "primaryAnimationColor"), new Vector4(shaderEnvironmentValues.PrimaryOnColor.R, shaderEnvironmentValues.PrimaryOnColor.G, shaderEnvironmentValues.PrimaryOnColor.B, 0.0f));
        effect.SetValue(effect.GetParameter(null, "secondaryAnimationColor"), new Vector4(shaderEnvironmentValues.SecondaryOnColor.R, shaderEnvironmentValues.SecondaryOnColor.G, shaderEnvironmentValues.SecondaryOnColor.B, 0.0f));
        effect.SetValue(effect.GetParameter(null, "plasmaAnimationColor"), new Vector4(shaderEnvironmentValues.PlasmaOnColor.R, shaderEnvironmentValues.PlasmaOnColor.G, shaderEnvironmentValues.PlasmaOnColor.B, 0.0f));

        effect.SetValue(effect.GetParameter(null, "VectorNormalization"), vectorNormalization[0]);

        if (baseMapTag == null)
          effect.SetValue(effect.GetParameter(null, "BaseMap"), default2d[Additive]);
        else
          effect.SetValue(effect.GetParameter(null, "BaseMap"), baseMapTag[0]);

        if (environmentMapTag == null)
          effect.SetValue(effect.GetParameter(null, "EnvironmentMap"), defaultCube[SignedAdditive]);
        else
          effect.SetValue(effect.GetParameter(null, "EnvironmentMap"), environmentMapTag[0]);

        if (bumpMapTag == null)
          effect.SetValue(effect.GetParameter(null, "BumpMap"), default2d[Vector]);
        else
          effect.SetValue(effect.GetParameter(null, "BumpMap"), bumpMapTag[0]);

        if (glowMapTag == null)
          effect.SetValue(effect.GetParameter(null, "GlowMap"), default2d[Additive]);
        else
          effect.SetValue(effect.GetParameter(null, "GlowMap"), glowMapTag[0]);
      }
      

      //effect = Effect.FromStream(); (use an effect pool?)

      //todo: choose which effect file or technique 
      //      to use based on lightmap presence, hardware, etc
      //effect.Technique = "LitBaseTexture";

      //this.technique = effect.Technique; //cache technique handle
    }

    private void SetDetail(int defaultIndex, int defaultMIndex)
    {
      if (primaryDetailMapTag == null)
        effect.SetValue(effect.GetParameter(null, "DetailMapA"), default2d[defaultIndex]);
      else
        effect.SetValue(effect.GetParameter(null, "DetailMapA"), primaryDetailMapTag[0]);

      if (secondaryDetailMapTag == null)
        effect.SetValue(effect.GetParameter(null, "DetailMapB"), default2d[defaultIndex]);
      else
        effect.SetValue(effect.GetParameter(null, "DetailMapB"), secondaryDetailMapTag[0]);

      if (microDetailMapTag == null)
        effect.SetValue(effect.GetParameter(null, "MicroDetailMap"), default2d[defaultMIndex]);
      else
        effect.SetValue(effect.GetParameter(null, "MicroDetailMap"), microDetailMapTag[0]);
    }

    public override void Dispose()
    {
      // should always do this too
      base.Dispose();

      if (effect != null)
        effect.Dispose();

      // release all references to bitmap tags
      Release(baseMapTag);
      Release(primaryDetailMapTag);
      Release(secondaryDetailMapTag);
      Release(microDetailMapTag);
      Release(bumpMapTag);
      Release(environmentMapTag);
      Release(glowMapTag);
    }

    public override int BeginApply()
    {
      //update texture transforms (animations)
      base.BeginApply();

      if (technique == null)
        return 1;
      else
      {
        effect.SetValue(cameraHandle, new Vector4(MdxRender.Camera.Position.X, MdxRender.Camera.Position.Y, MdxRender.Camera.Position.Z, 1.0f));
        effect.SetValue(worldHandle, MdxRender.Device.Transform.World);
        effect.SetValue(wvpHandle, MdxRender.Device.Transform.World * MdxRender.Device.Transform.View * MdxRender.Device.Transform.Projection);
        effect.SetValue(plasmaValueHandle, Animate(shaderEnvironmentValues.PlasmaAnimationFunction.Value, shaderEnvironmentValues.PlasmaAnimationPeriod.Value, shaderEnvironmentValues.PlasmaAnimationPhase.Value));
        effect.SetValue(primaryValueHandle, Animate(shaderEnvironmentValues.PrimaryAnimationFunction.Value, shaderEnvironmentValues.PrimaryAnimationPeriod.Value, shaderEnvironmentValues.PrimaryAnimationPhase.Value));
        effect.SetValue(secondaryValueHandle, Animate(shaderEnvironmentValues.SecondaryAnimationFunction.Value, shaderEnvironmentValues.SecondaryAnimationPeriod.Value, shaderEnvironmentValues.SecondaryAnimationPhase.Value));
        effect.SetValue(uValueHandle, Animate(shaderEnvironmentValues.unnamed11.Value, shaderEnvironmentValues.unnamed13.Value, shaderEnvironmentValues.unnamed14.Value));
        effect.SetValue(vValueHandle, Animate(shaderEnvironmentValues.unnamed15.Value, shaderEnvironmentValues.unnamed17.Value, shaderEnvironmentValues.unnamed18.Value));
        effect.SetValue(fogStartHandle, MdxRender.Device.RenderState.FogStart);
        effect.SetValue(fogEndHandle, MdxRender.Device.RenderState.FogEnd);
        effect.SetValue(fogDensityHandle, MdxRender.Device.RenderState.FogDensity);
        effect.SetValue(ambientColorHandle, ColorValue.FromColor(MdxRender.Device.Material.Diffuse));

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

      if (technique == null)
        SetPassFixedFunction(pass);
      else
        SetPassShaders(pass);
    }

    protected virtual void SetPassShaders(int pass)
    {
      if (pass == 0)
      {
        MdxRender.Device.RenderState.AlphaBlendEnable = false;
        if ((shaderEnvironmentValues.Flags.Value & 0x1) == 0)
          MdxRender.Device.RenderState.AlphaTestEnable = false;
        else
        {
          MdxRender.Device.RenderState.AlphaTestEnable = true;
          MdxRender.Device.RenderState.ReferenceAlpha = 0x80;
          MdxRender.Device.RenderState.AlphaFunction = Compare.GreaterEqual;
        }
        MdxRender.Device.RenderState.CullMode = Cull.CounterClockwise;
      }
      //SetPassFixedFunction(pass);
      else
        effect.EndPass();
      effect.BeginPass(pass);
    }

    protected virtual void SetPassFixedFunction(int pass)
    {
      switch (pass)
      {
        case 0:
          MdxRender.Device.RenderState.AlphaBlendEnable = false;
          MdxRender.Device.RenderState.ColorWriteEnable = ColorWriteEnable.RedGreenBlue;
          //if ((this.ShaderValues.Flags.Value & 0x1) == 0)
          MdxRender.Device.RenderState.AlphaTestEnable = false;
          //else
          //  MdxRender.Device.RenderState.AlphaTestEnable = true;

          MdxRender.Device.RenderState.SourceBlend = Blend.DestinationColor;
          MdxRender.Device.RenderState.DestinationBlend = Blend.Zero;
          MdxRender.Device.RenderState.CullMode = Cull.CounterClockwise;

          int st = 0;

          //basemap (Stage 2)
          if (baseMapTag != null)
          {
            //  MdxRender.Device.SetTexture(st, default2d[0]);
            //else
            MdxRender.Device.SetTexture(st, baseMapTag[0]);

            MdxRender.Device.TextureState[st].TextureCoordinateIndex = 0;
            MdxRender.Device.TextureState[st].TextureTransform = TextureTransform.Disable;
            MdxRender.Device.TextureState[st].ColorArgument1 = TextureArgument.TextureColor;
            MdxRender.Device.TextureState[st].ColorOperation = TextureOperation.SelectArg1;
            MdxRender.Device.TextureState[st].AlphaArgument1 = TextureArgument.TextureColor;
            MdxRender.Device.TextureState[st].AlphaOperation = TextureOperation.SelectArg1;
            st++;
          }


          //detail1 (Stage 3)
          if (primaryDetailMapTag != null)
          {
            //MdxRender.Device.SetTexture(st, default2d[0]);
            //else
            MdxRender.Device.SetTexture(st, primaryDetailMapTag[0]);

            MdxRender.Device.TextureState[st].TextureCoordinateIndex = 0;
            MdxRender.Device.SetTransform((TransformType)(0x10 + st), primaryDetailMapTransform);
            MdxRender.Device.TextureState[st].TextureTransform = TextureTransform.Count2;
            MdxRender.Device.TextureState[st].ColorArgument1 = TextureArgument.TextureColor;
            MdxRender.Device.TextureState[st].ColorArgument2 = TextureArgument.Current;
            MdxRender.Device.TextureState[st].ColorOperation = TextureOperation.BlendCurrentAlpha;
            MdxRender.Device.TextureState[st].AlphaArgument1 = TextureArgument.Current;
            MdxRender.Device.TextureState[st].AlphaOperation = TextureOperation.SelectArg1;
            st++;
          }

          //detail2 (Stage 4)
          if (this.secondaryDetailMapTag != null)
          {
            //  MdxRender.Device.SetTexture(st, default2d[0]);
            //else
            MdxRender.Device.SetTexture(st, secondaryDetailMapTag[0]);

            MdxRender.Device.TextureState[st].TextureCoordinateIndex = 0;
            MdxRender.Device.SetTransform((TransformType)(0x10 + st), secondaryDetailMapTransform);
            MdxRender.Device.TextureState[st].TextureTransform = TextureTransform.Count2;
            MdxRender.Device.TextureState[st].ColorArgument1 = TextureArgument.Current;
            MdxRender.Device.TextureState[st].ColorArgument2 = TextureArgument.TextureColor;
            MdxRender.Device.TextureState[st].ColorOperation = TextureOperation.BlendCurrentAlpha;
            MdxRender.Device.TextureState[st].AlphaArgument1 = TextureArgument.Current;
            MdxRender.Device.TextureState[st].AlphaOperation = TextureOperation.SelectArg1;
            st++;
          }

          //micro detail (Stage 5)
          if (microDetailMapTag != null)
          {
            //  MdxRender.Device.SetTexture(st, default2d[0]);
            //else
            MdxRender.Device.SetTexture(st, microDetailMapTag[0]);

            MdxRender.Device.TextureState[st].TextureCoordinateIndex = 0;
            MdxRender.Device.SetTransform((TransformType)(0x10 + st), microDetailMapTransform);
            MdxRender.Device.TextureState[st].TextureTransform = TextureTransform.Count2;
            MdxRender.Device.TextureState[st].ColorArgument1 = TextureArgument.TextureColor;
            MdxRender.Device.TextureState[st].ColorArgument2 = TextureArgument.Current;
            MdxRender.Device.TextureState[st].ColorOperation = TextureOperation.AddSigned;
            MdxRender.Device.TextureState[st].AlphaArgument1 = TextureArgument.Current;
            MdxRender.Device.TextureState[st].AlphaOperation = TextureOperation.SelectArg1;
            st++;
          }

          //lightmap
          if (this.Lightmap != null)
          //if (false)//(lightmapTexture != null) && (lightmapSubIndex >= 0))
          {
            MdxRender.Device.SetTexture(st, this.Lightmap);
            MdxRender.Device.TextureState[st].TextureCoordinateIndex = 1;
            MdxRender.Device.TextureState[st].TextureTransform = TextureTransform.Disable;
            MdxRender.Device.TextureState[st].ColorArgument1 = TextureArgument.TextureColor;
            MdxRender.Device.TextureState[st].ColorArgument2 = TextureArgument.Current;
            MdxRender.Device.TextureState[st].ColorOperation = TextureOperation.Modulate;
            MdxRender.Device.TextureState[st].AlphaArgument1 = TextureArgument.Current;
            MdxRender.Device.TextureState[st].AlphaOperation = TextureOperation.SelectArg1;
            st++;
          }

          //base again
          if (st > 1)
          {
            MdxRender.Device.SetTexture(st, baseMapTag[0]);
            MdxRender.Device.TextureState[st].TextureCoordinateIndex = 0;
            MdxRender.Device.TextureState[st].TextureTransform = TextureTransform.Disable;
            MdxRender.Device.TextureState[st].ColorArgument1 = TextureArgument.TextureColor;
            MdxRender.Device.TextureState[st].ColorArgument2 = TextureArgument.Current;
            MdxRender.Device.TextureState[st].ColorOperation = TextureOperation.Modulate2X;
            MdxRender.Device.TextureState[st].AlphaArgument1 = TextureArgument.TextureColor;
            MdxRender.Device.TextureState[st].AlphaOperation = TextureOperation.SelectArg1;
            st++;
          }

          //disable the last stage
          if (st < 6)
          {
            MdxRender.Device.TextureState[st].ColorOperation = TextureOperation.Disable;
            MdxRender.Device.TextureState[st].AlphaOperation = TextureOperation.Disable;
          }
          break;
      }
    }

    private void PerformSimpleBaseTexture(int pass)
    {
    }

    private void PerformHaloPCEmulation(int pass)
    {
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
    /// Used for preview
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
