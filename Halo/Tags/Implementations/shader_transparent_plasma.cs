using System;
using System.Collections.Generic;
using Microsoft.DirectX;
using Microsoft.DirectX.Direct3D;
using Interfaces.Rendering.Instancing;
using Interfaces.Rendering;
using Interfaces;

namespace Games.Halo.Tags.Classes
{
  public partial class shader_transparent_plasma : IInstanceable
  {
    private bitmap primaryNoiseMapTag = null;
    private bitmap secondaryNoiseMapTag = null;

    private Effect effect = null;
    private EffectHandle technique = null;
    private EffectHandle pIHandle = null;
    private EffectHandle pJHandle = null;
    private EffectHandle pKHandle = null;
    private EffectHandle sIHandle = null;
    private EffectHandle sJHandle = null;
    private EffectHandle sKHandle = null;
    private EffectHandle wvpHandle = null;
    private EffectHandle worldHandle = null;
    private EffectHandle cameraHandle = null;
    private EffectHandle offsetHandle = null;
    private EffectHandle intensityHandle = null;

    private InstanceCollection instances = null;

    public override void DoPostProcess()
    {
      base.DoPostProcess();

      primaryNoiseMapTag = Open<bitmap>(shaderTransparentPlasmaValues.PrimaryNoiseMap.Value);
      secondaryNoiseMapTag = Open<bitmap>(shaderTransparentPlasmaValues.SecondaryNoiseMap.Value);

      if (MdxRender.Device.DeviceCaps.PixelShaderVersion.Major >= 2)
      {
        string shaderErrors = null;
        effect = Effect.FromStream(MdxRender.Device, System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("Games.Halo.Resources.Shaders.shader_transparent_plasma.fx"), null, null, ShaderFlags.None, null, out shaderErrors);
        if (!String.IsNullOrEmpty(shaderErrors))
          LogError("Failed to initialize shader_transparent_plasma effect: {0}", shaderErrors);

        wvpHandle = effect.GetParameter(null, "worldViewProjection");
        worldHandle = effect.GetParameter(null, "world");
        cameraHandle = effect.GetParameter(null, "cameraPosition");

        pIHandle = effect.GetParameter(null, "primaryI");
        pJHandle = effect.GetParameter(null, "primaryJ");
        pKHandle = effect.GetParameter(null, "primaryK");
        sIHandle = effect.GetParameter(null, "secondaryI");
        sJHandle = effect.GetParameter(null, "secondaryJ");
        sKHandle = effect.GetParameter(null, "secondaryK");
        offsetHandle = effect.GetParameter(null, "offset");
        intensityHandle = effect.GetParameter(null, "intensity");

        effect.SetValue(effect.GetParameter(null, "perpendicularBrightness"), shaderTransparentPlasmaValues.PerpendicularBrightness.Value);
        effect.SetValue(effect.GetParameter(null, "parallelBrightness"), shaderTransparentPlasmaValues.ParallelBrightness.Value);
        effect.SetValue(effect.GetParameter(null, "perpendicularColor"), new Vector4(shaderTransparentPlasmaValues.PerpendicularTintColor.R, shaderTransparentPlasmaValues.PerpendicularTintColor.G, shaderTransparentPlasmaValues.PerpendicularTintColor.B, 1.0f));
        effect.SetValue(effect.GetParameter(null, "parallelColor"), new Vector4(shaderTransparentPlasmaValues.ParallelTintColor.R, shaderTransparentPlasmaValues.ParallelTintColor.G, shaderTransparentPlasmaValues.ParallelTintColor.B, 1.0f));

        effect.SetValue(effect.GetParameter(null, "primaryScale"), shaderTransparentPlasmaValues.PrimaryNoiseMapScale.Value);
        effect.SetValue(effect.GetParameter(null, "secondaryScale"), shaderTransparentPlasmaValues.SecondaryNoiseMapScale.Value);

        if (primaryNoiseMapTag == null)
          effect.SetValue(effect.GetParameter(null, "PrimaryMap"), default3d[Additive]);
        else
          effect.SetValue(effect.GetParameter(null, "PrimaryMap"), primaryNoiseMapTag[0]);

        if (secondaryNoiseMapTag == null)
          effect.SetValue(effect.GetParameter(null, "SecondaryMap"), default3d[Multiplicative]);
        else
          effect.SetValue(effect.GetParameter(null, "SecondaryMap"), secondaryNoiseMapTag[0]);

        effect.Technique = technique = effect.GetTechnique("Plasma");
      }
    }

    public override void Dispose()
    {
      base.Dispose();

      if (effect != null)
        effect.Dispose();

      Release(primaryNoiseMapTag);
      Release(secondaryNoiseMapTag);
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
        effect.SetValue(wvpHandle, MdxRender.Device.Transform.World * MdxRender.Device.Transform.View * MdxRender.Device.Transform.Projection);
        effect.SetValue(worldHandle, MdxRender.Device.Transform.World);

        effect.SetValue(offsetHandle, shaderTransparentPlasmaValues.OffsetAmount.Value);
        effect.SetValue(intensityHandle, 1.0f);

        if(shaderTransparentPlasmaValues.PrimaryAnimationDirection.I == 0.0f)
          effect.SetValue(pIHandle, 0.0f);
        else
          effect.SetValue(pIHandle, PMath.Sawtooth(shaderTransparentPlasmaValues.PrimaryAnimationPeriod.Value / shaderTransparentPlasmaValues.PrimaryAnimationDirection.I, 1.0f));
        if (shaderTransparentPlasmaValues.PrimaryAnimationDirection.J == 0.0f)
          effect.SetValue(pJHandle, 0.0f);
        else
          effect.SetValue(pJHandle, PMath.Sawtooth(shaderTransparentPlasmaValues.PrimaryAnimationPeriod.Value / shaderTransparentPlasmaValues.PrimaryAnimationDirection.J, 1.0f));
        if (shaderTransparentPlasmaValues.PrimaryAnimationDirection.K == 0.0f)
          effect.SetValue(pKHandle, 0.0f);
        else
          effect.SetValue(pKHandle, PMath.Sawtooth(shaderTransparentPlasmaValues.PrimaryAnimationPeriod.Value / shaderTransparentPlasmaValues.PrimaryAnimationDirection.K, 1.0f));

        if (shaderTransparentPlasmaValues.SecondaryAnimationDirection.I == 0.0f)
          effect.SetValue(sIHandle, 0.0f);
        else
          effect.SetValue(sIHandle, PMath.Sawtooth(shaderTransparentPlasmaValues.SecondaryAnimationPeriod.Value / shaderTransparentPlasmaValues.SecondaryAnimationDirection.I, 1.0f));
        if (shaderTransparentPlasmaValues.SecondaryAnimationDirection.J == 0.0f)
          effect.SetValue(sJHandle, 0.0f);
        else
          effect.SetValue(sJHandle, PMath.Sawtooth(shaderTransparentPlasmaValues.SecondaryAnimationPeriod.Value / shaderTransparentPlasmaValues.SecondaryAnimationDirection.J, 1.0f));
        if (shaderTransparentPlasmaValues.SecondaryAnimationDirection.K == 0.0f)
          effect.SetValue(sKHandle, 0.0f);
        else
          effect.SetValue(sKHandle, PMath.Sawtooth(shaderTransparentPlasmaValues.SecondaryAnimationPeriod.Value / shaderTransparentPlasmaValues.SecondaryAnimationDirection.K, 1.0f));

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
        MdxRender.Device.RenderState.CullMode = Cull.CounterClockwise;

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
