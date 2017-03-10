using System;
using System.Collections.Generic;
using Microsoft.DirectX;
using Microsoft.DirectX.Direct3D;
using Interfaces.Rendering.Instancing;
using Interfaces.Rendering;
using System.Drawing;

namespace Games.Halo.Tags.Classes
{
  public partial class shader_transparent_glass : IInstanceable
  {
    private bitmap tintMapTag = null;
    private bitmap reflectionMapTag = null;
    private bitmap bumpMapTag = null;
    private bitmap diffuseMapTag = null;
    private bitmap detailMapTag = null;
    private bitmap specularMapTag = null;

    private Effect effect = null;
    private EffectHandle technique = null;
    private EffectHandle lightmapHandle = null;
    private EffectHandle worldHandle = null;
    private EffectHandle wvpHandle = null;
    private EffectHandle cameraHandle = null;
    private EffectHandle fogStartHandle = null;
    private EffectHandle fogEndHandle = null;
    private EffectHandle fogDensityHandle = null;

    private InstanceCollection instances = null;

    public override void DoPostProcess()
    {
      base.DoPostProcess();

      tintMapTag = Open<bitmap>(shaderTransparentGlassValues.BackgroundTintMap.Value);
      reflectionMapTag = Open<bitmap>(shaderTransparentGlassValues.ReflectionMap.Value);
      bumpMapTag = Open<bitmap>(shaderTransparentGlassValues.BumpMap.Value);
      diffuseMapTag = Open<bitmap>(shaderTransparentGlassValues.DiffuseMap.Value);
      detailMapTag = Open<bitmap>(shaderTransparentGlassValues.DiffuseDetailMap.Value);
      specularMapTag = Open<bitmap>(shaderTransparentGlassValues.SpecularMap.Value);

      if (MdxRender.Device.DeviceCaps.PixelShaderVersion.Major >= 2)
      {
        string shaderErrors = null;
        effect = Effect.FromStream(MdxRender.Device, System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("Games.Halo.Resources.Shaders.shader_transparent_glass.fx"), null, null, ShaderFlags.None, null, out shaderErrors);
        if (!String.IsNullOrEmpty(shaderErrors))
          LogError("Failed to initialize shader_transparent_glass effect: {0}", shaderErrors);

        lightmapHandle = effect.GetParameter(null, "LightMap");
        worldHandle = effect.GetParameter(null, "world");
        wvpHandle = effect.GetParameter(null, "worldViewProjection");
        cameraHandle = effect.GetParameter(null, "cameraPosition");
        fogStartHandle = effect.GetParameter(null, "fogStart");
        fogEndHandle = effect.GetParameter(null, "fogEnd");
        fogDensityHandle = effect.GetParameter(null, "fogDensity");

        effect.SetValue(effect.GetParameter(null, "perpendicularBrightness"), shaderTransparentGlassValues.PerpendicularBrightness.Value);
        effect.SetValue(effect.GetParameter(null, "parallelBrightness"), shaderTransparentGlassValues.ParallelBrightness.Value);
        effect.SetValue(effect.GetParameter(null, "perpendicularColor"), new ColorValue(shaderTransparentGlassValues.PerpendicularTintColor.R, shaderTransparentGlassValues.PerpendicularTintColor.G, shaderTransparentGlassValues.PerpendicularTintColor.B, 1.0f));
        effect.SetValue(effect.GetParameter(null, "parallelColor"), new ColorValue(shaderTransparentGlassValues.ParallelTintColor.R, shaderTransparentGlassValues.ParallelTintColor.G, shaderTransparentGlassValues.ParallelTintColor.B, 1.0f));
        if (shaderTransparentGlassValues.BackgroundTintColor.R == 0.0f && shaderTransparentGlassValues.BackgroundTintColor.G == 0.0f && shaderTransparentGlassValues.BackgroundTintColor.B == 0.0f)
          effect.SetValue(effect.GetParameter(null, "backgroundTintColor"), new ColorValue(1.0f, 1.0f, 1.0f, 1.0f));
        else
          effect.SetValue(effect.GetParameter(null, "backgroundTintColor"), new ColorValue(shaderTransparentGlassValues.BackgroundTintColor.R, shaderTransparentGlassValues.BackgroundTintColor.G, shaderTransparentGlassValues.BackgroundTintColor.B, 1.0f));

        effect.SetValue(effect.GetParameter(null, "diffuseScale"), shaderTransparentGlassValues.DiffuseMapScale.Value);
        effect.SetValue(effect.GetParameter(null, "bumpScale"), shaderTransparentGlassValues.BumpMapScale.Value);
        effect.SetValue(effect.GetParameter(null, "tintScale"), shaderTransparentGlassValues.BackgroundTintMapScale.Value);
        effect.SetValue(effect.GetParameter(null, "detailScale"), shaderTransparentGlassValues.DiffuseDetailMapScale.Value);
        effect.SetValue(effect.GetParameter(null, "specularScale"), shaderTransparentGlassValues.SpecularMapScale.Value);

        if (diffuseMapTag == null)
          effect.SetValue(effect.GetParameter(null, "DiffuseMap"), default2d[Additive]);
        else
          effect.SetValue(effect.GetParameter(null, "DiffuseMap"), diffuseMapTag[0]);

        if (bumpMapTag == null)
          effect.SetValue(effect.GetParameter(null, "BumpMap"), default2d[Vector]);
        else
          effect.SetValue(effect.GetParameter(null, "BumpMap"), bumpMapTag[0]);

        if (tintMapTag == null)
          effect.SetValue(effect.GetParameter(null, "TintMap"), default2d[Multiplicative]);
        else
          effect.SetValue(effect.GetParameter(null, "TintMap"), tintMapTag[0]);

        if (detailMapTag == null)
          effect.SetValue(effect.GetParameter(null, "DetailMap"), default2d[SignedAdditive]);
        else
          effect.SetValue(effect.GetParameter(null, "DetailMap"), detailMapTag[0]);

        if (reflectionMapTag == null)
          effect.SetValue(effect.GetParameter(null, "EnvironmentMap"), defaultCube[SignedAdditive]);
        else
          effect.SetValue(effect.GetParameter(null, "EnvironmentMap"), reflectionMapTag[0]);

        if (specularMapTag == null)
          effect.SetValue(effect.GetParameter(null, "SpecularMap"), defaultCube[Additive]);
        else
          effect.SetValue(effect.GetParameter(null, "SpecularMap"), specularMapTag[0]);

        if (shaderTransparentGlassValues.ReflectionType.Value == 1)
        {
          if (specularMapTag == null)
            effect.Technique = technique = effect.GetTechnique("FlatGlass");
          else if (diffuseMapTag == null && reflectionMapTag == null)
            effect.Technique = technique = effect.GetTechnique("FlatGlassSpecular");
          else
            effect.Technique = technique = effect.GetTechnique("FlatGlassTwoPass");
        }
        else
        {
          if (specularMapTag == null)
            effect.Technique = technique = effect.GetTechnique("BumpedGlass");
          else if (diffuseMapTag == null && reflectionMapTag == null)
            effect.Technique = technique = effect.GetTechnique("BumpedGlassSpecular");
          else
            effect.Technique = technique = effect.GetTechnique("BumpedGlassTwoPass");
        }
      }
    }

    public override void Dispose()
    {
      base.Dispose();

      if (effect != null)
        effect.Dispose();

      Release(tintMapTag);
      Release(reflectionMapTag);
      Release(bumpMapTag);
      Release(diffuseMapTag);
      Release(detailMapTag);
      Release(specularMapTag);
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
        effect.SetValue(fogStartHandle, MdxRender.Device.RenderState.FogStart);
        effect.SetValue(fogEndHandle, MdxRender.Device.RenderState.FogEnd);
        effect.SetValue(fogDensityHandle, MdxRender.Device.RenderState.FogDensity);

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
        MdxRender.Device.RenderState.AlphaTestEnable = (shaderTransparentGlassValues.Flags.Value & 0x1) != 0;
        MdxRender.Device.RenderState.ReferenceAlpha = 0x80;
        MdxRender.Device.RenderState.AlphaFunction = Compare.GreaterEqual;
        MdxRender.Device.RenderState.CullMode = (shaderTransparentGlassValues.Flags.Value & 0x4) == 0 ? Cull.CounterClockwise : Cull.None;

        MdxRender.Device.RenderState.AlphaBlendEnable = true;
        MdxRender.Device.RenderState.SourceBlend = Blend.SourceColor;
        MdxRender.Device.RenderState.DestinationBlend = Blend.BlendFactor;
        MdxRender.Device.RenderState.BlendOperation = BlendOperation.Add;
        MdxRender.Device.RenderState.BlendFactorColor = new ColorValue(shaderTransparentGlassValues.BackgroundTintColor.R, shaderTransparentGlassValues.BackgroundTintColor.G, shaderTransparentGlassValues.BackgroundTintColor.B, 1.0f).ToArgb();
      }
      else if (pass == 1)
      {
        effect.EndPass();
        MdxRender.Device.RenderState.SourceBlend = Blend.SourceColor;
        MdxRender.Device.RenderState.DestinationBlend = Blend.InvSourceColor;
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
