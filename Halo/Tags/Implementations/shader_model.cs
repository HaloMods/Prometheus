using System;
using System.Drawing;
using Microsoft.DirectX;
using Microsoft.DirectX.Direct3D;
using Interfaces.Rendering;
using Interfaces.Rendering.Instancing;
using Interfaces.Rendering.Interfaces;

namespace Games.Halo.Tags.Classes
{
  public partial class shader_model : IDynamicShader, IInstanceable
  {
    private bitmap baseMapTag = null;
    private bitmap multipurposeMapTag = null;
    private bitmap detailMapTag = null;
    private bitmap reflectionCubeMapTag = null;

    private Effect effect = null;
    private EffectHandle technique = null;
    private EffectHandle lightmapHandle = null;
    private EffectHandle worldHandle = null;
    private EffectHandle wvpHandle = null;
    private EffectHandle cameraHandle = null;
    private EffectHandle illuminationValueHandle = null;
    private EffectHandle changeColorValueHandle = null;
    private EffectHandle fogStartHandle = null;
    private EffectHandle fogEndHandle = null;
    private EffectHandle fogDensityHandle = null;
    private EffectHandle ambientColorHandle = null;

    //_animationFunction
    //_animationPeriod
    //_detailFunction
    //_detailMask

    private Matrix detailMapTransform = new Matrix();
    private InstanceCollection instances;

    public override void DoPostProcess()
    {
      // always call the base function for DoPostProcess()
      base.DoPostProcess();

      //load texture references
      baseMapTag = Open<bitmap>(shaderModelValues.BaseMap.Value);
      multipurposeMapTag = Open<bitmap>(shaderModelValues.MultipurposeMap.Value);
      detailMapTag = Open<bitmap>(shaderModelValues.DetailMap.Value);
      reflectionCubeMapTag = Open<bitmap>(shaderModelValues.ReflectionCubeMap.Value);

      //initialize texture transforms
      detailMapTransform.Scale(
        shaderModelValues.DetailMapScale.Value,
        shaderModelValues.DetailMapScale.Value,
        1);

      // initialize effects
      if (MdxRender.Device.DeviceCaps.PixelShaderVersion.Major >= 2)
      {
        string shaderErrors = null;
        effect = Effect.FromStream(MdxRender.Device, System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("Games.Halo.Resources.Shaders.shader_model.fx"), null, null, ShaderFlags.None, null, out shaderErrors);
        if (!String.IsNullOrEmpty(shaderErrors))
          LogError("Failed to initialize shader_model effect: {0}", shaderErrors);
        
        lightmapHandle = effect.GetParameter(null, "LightMap");
        worldHandle = effect.GetParameter(null, "world");
        wvpHandle = effect.GetParameter(null, "worldViewProjection");
        cameraHandle = effect.GetParameter(null, "cameraPosition");
        fogStartHandle = effect.GetParameter(null, "fogStart");
        fogEndHandle = effect.GetParameter(null, "fogEnd");
        fogDensityHandle = effect.GetParameter(null, "fogDensity");
        ambientColorHandle = effect.GetParameter(null, "ambientColor");
        illuminationValueHandle = effect.GetParameter(null, "selfIlluminationValue");
        changeColorValueHandle = effect.GetParameter(null, "changeColor");
        effect.SetValue(changeColorValueHandle, new Vector4(1.0f, 1.0f, 1.0f, 1.0f));

        effect.SetValue(effect.GetParameter(null, "detailAfterReflection"), (shaderModelValues.Flags.Value & 0x1) != 0);
        effect.SetValue(effect.GetParameter(null, "detailFunction"), shaderModelValues.DetailFunction.Value);

        effect.SetValue(effect.GetParameter(null, "parallelBrightness"), shaderModelValues.ParallelBrightness.Value);
        effect.SetValue(effect.GetParameter(null, "perpendicularBrightness"), shaderModelValues.PerpendicularBrightness.Value);

        effect.SetValue(effect.GetParameter(null, "detailScale"), shaderModelValues.DetailMapScale.Value);
        effect.SetValue(effect.GetParameter(null, "detailVScale"), shaderModelValues.DetailMap2.Value);
        effect.SetValue(effect.GetParameter(null, "uScale"), shaderModelValues.Map.Value);
        effect.SetValue(effect.GetParameter(null, "vScale"), shaderModelValues.Map2.Value);

        effect.SetValue(effect.GetParameter(null, "selfIlluminationLower"), new Vector4(shaderModelValues.AnimationColorLowerBound.R, shaderModelValues.AnimationColorLowerBound.G, shaderModelValues.AnimationColorLowerBound.B, 1.0f));
        effect.SetValue(effect.GetParameter(null, "selfIlluminationUpper"), new Vector4(shaderModelValues.AnimationColorUpperBound.R, shaderModelValues.AnimationColorUpperBound.G, shaderModelValues.AnimationColorUpperBound.B, 1.0f));

        if (baseMapTag == null)
          effect.SetValue(effect.GetParameter(null, "BaseMap"), default2d[Additive]);
        else
          effect.SetValue(effect.GetParameter(null, "BaseMap"), baseMapTag[0]);

        if (reflectionCubeMapTag == null)
          effect.SetValue(effect.GetParameter(null, "EnvironmentMap"), defaultCube[SignedAdditive]);
        else
          effect.SetValue(effect.GetParameter(null, "EnvironmentMap"), reflectionCubeMapTag[0]);

        if (detailMapTag == null)
          effect.SetValue(effect.GetParameter(null, "DetailMap"), default2d[SignedAdditive]);
        else
          effect.SetValue(effect.GetParameter(null, "DetailMap"), detailMapTag[0]);

        if (multipurposeMapTag == null)
          effect.SetValue(effect.GetParameter(null, "MultipurposeMap"), default2d[Additive]);
        else
          effect.SetValue(effect.GetParameter(null, "MultipurposeMap"), multipurposeMapTag[0]);

        switch (shaderModelValues.DetailMask.Value)
        {
          case 0:
            effect.Technique = technique = effect.GetTechnique("ModelNoDetailMask");
            break;
          case 1:
            effect.Technique = technique = effect.GetTechnique("ModelIReflectionDetailMask");
            break;
          case 2:
            effect.Technique = technique = effect.GetTechnique("ModelReflectionDetailMask");
            break;
          case 3:
            effect.Technique = technique = effect.GetTechnique("ModelIIllumDetailMask");
            break;
          case 4:
            effect.Technique = technique = effect.GetTechnique("ModelIllumDetailMask");
            break;
          case 5:
            effect.Technique = technique = effect.GetTechnique("ModelIChangeColorDetailMask");
            break;
          case 6:
            effect.Technique = technique = effect.GetTechnique("ModelChangeColorDetailMask");
            break;
          case 7:
            effect.Technique = technique = effect.GetTechnique("ModelIAuxiliaryDetailMask");
            break;
          case 8:
            effect.Technique = technique = effect.GetTechnique("ModelAuxiliaryDetailMask");
            break;
        }
      }
    }

    public override void Dispose()
    {
      base.Dispose();

      if (effect != null)
        effect.Dispose();

      Release(baseMapTag);
      Release(multipurposeMapTag);
      Release(detailMapTag);
      Release(reflectionCubeMapTag);
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
        effect.SetValue(illuminationValueHandle, Animate(shaderModelValues.AnimationFunction.Value, shaderModelValues.AnimationPeriod.Value, 0.0f));
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

    private void SetPassShaders(int pass)
    {
      if (pass == 0)
      {
        MdxRender.Device.RenderState.AlphaBlendEnable = false;
        if ((shaderModelValues.Flags.Value & 0x4) != 0)
        {
          MdxRender.Device.RenderState.AlphaTestEnable = false;
          MdxRender.Device.RenderState.SourceBlend = Blend.DestinationColor;
          MdxRender.Device.RenderState.DestinationBlend = Blend.Zero;
        }
        else
        {
          MdxRender.Device.RenderState.AlphaTestEnable = true;
          MdxRender.Device.RenderState.ReferenceAlpha = 0x80;
          MdxRender.Device.RenderState.AlphaFunction = Compare.GreaterEqual;
          MdxRender.Device.RenderState.SourceBlend = Blend.SourceAlpha;
          MdxRender.Device.RenderState.DestinationBlend = Blend.InvSourceAlpha;
        }

        MdxRender.Device.RenderState.CullMode = (shaderModelValues.Flags.Value & 0x2) == 0 ? Cull.CounterClockwise : Cull.None;
      }
      else
        effect.EndPass();
      effect.BeginPass(pass);
    }

    private void SetPassFixedFunction(int pass)
    {
      switch (pass)
      {
        case 0:
          MdxRender.Device.RenderState.SourceBlend = Blend.SourceAlpha;
          MdxRender.Device.RenderState.DestinationBlend = Blend.InvSourceAlpha;
          MdxRender.Device.RenderState.AlphaBlendEnable = true;

          int flags = this.shaderModelValues.Flags.Value;

          //not alpha tested
          if ((flags & 0x4) == 0)
            MdxRender.Device.RenderState.AlphaTestEnable = true;
          else
            MdxRender.Device.RenderState.AlphaTestEnable = false;

          //two-sided
          if ((flags & 0x2) == 0)
            MdxRender.Device.RenderState.CullMode = Cull.CounterClockwise;
          else
          {
            MdxRender.Device.RenderState.CullMode = Cull.None;
            MdxRender.Device.RenderState.AlphaTestEnable = true;
          }

          //transparency
          if (baseMapTag != null)
          {
            MdxRender.Device.SetTexture(0, baseMapTag[0]);

            //alpha blend lit material
            MdxRender.Device.TextureState[0].AlphaArgument1 = TextureArgument.TextureColor;
            MdxRender.Device.TextureState[0].AlphaOperation = TextureOperation.SelectArg1;
            MdxRender.Device.TextureState[0].ColorArgument1 = TextureArgument.TextureColor;
            MdxRender.Device.TextureState[0].ColorArgument2 = TextureArgument.Diffuse;
            MdxRender.Device.TextureState[0].ColorOperation = TextureOperation.Modulate2X;//.ModulateInvAlphaAddColor;
            MdxRender.Device.TextureState[0].TextureTransform = TextureTransform.Disable;
          }

          if (detailMapTag != null)
          {
            MdxRender.Device.SetTexture(1, detailMapTag[0]);
            MdxRender.Device.TextureState[1].AlphaArgument1 = TextureArgument.TextureColor;
            MdxRender.Device.TextureState[1].AlphaOperation = TextureOperation.SelectArg1;
            MdxRender.Device.TextureState[1].ColorArgument1 = TextureArgument.Current;
            MdxRender.Device.TextureState[1].ColorArgument2 = TextureArgument.TextureColor;
            MdxRender.Device.TextureState[1].TextureCoordinateIndex = 0;
            MdxRender.Device.TextureState[1].TextureTransform = TextureTransform.Count2;
            MdxRender.Device.Transform.Texture1 = detailMapTransform;

            SetDetailBlendFunction(this.shaderModelValues.DetailFunction.Value, 1);
          }
          else
          {
            MdxRender.Device.TextureState[1].ColorOperation = TextureOperation.Disable;
            MdxRender.Device.TextureState[1].AlphaOperation = TextureOperation.Disable;
            MdxRender.Device.TextureState[1].TextureTransform = TextureTransform.Disable;
          }

          for (int i = 2; i < 6; i++)
          {
            MdxRender.Device.TextureState[i].AlphaOperation = TextureOperation.Disable;
            MdxRender.Device.TextureState[i].ColorOperation = TextureOperation.Disable;
            MdxRender.Device.TextureState[i].TextureTransform = TextureTransform.Disable;
          }
          break;
      }
      //DebugFixedFunctionShader();
    }

    public override void EndApply()
    {
      base.EndApply();
      if (technique != null)
      {
        effect.EndPass();
        effect.End();
        effect.SetValue(changeColorValueHandle, new Vector4(1.0f, 1.0f, 1.0f, 1.0f));
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

    public int DynamicColorSource
    {
      get
      { return shaderModelValues.ChangeColorSource.Value - 1; }
    }

    public ColorValue DynamicColor
    {
      set
      {
        if (effect != null)
        {
          effect.SetValue(changeColorValueHandle, new Vector4(value.Red, value.Green, value.Blue, value.Alpha));
          effect.CommitChanges();
        }
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
