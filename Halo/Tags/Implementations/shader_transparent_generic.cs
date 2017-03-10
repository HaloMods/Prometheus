using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Text;
using Microsoft.DirectX;
using Microsoft.DirectX.Direct3D;
using Interfaces;
using Interfaces.DebugConsole;
using Interfaces.Rendering;
using Interfaces.Rendering.Instancing;
using Interfaces.Textures;
using Games.Halo.Tags.Fields;

namespace Games.Halo.Tags.Classes
{
  public partial class shader_transparent_generic : IInstanceable
  {
    private int updateTick = Random.Next(UpdateTicks);
    private bool fogWasEnabled = false;
    private Size targetSize = new Size();
    private bitmap[] maps = null;
    private Texture target = null;
    private Sampler[] samplers = null;
    private InstanceCollection instances = null;

    private Effect effect = null;
    private EffectHandle technique = null;
    private EffectHandle worldHandle = null;
    private EffectHandle wvpHandle = null;
    private EffectHandle cameraHandle = null;
    private EffectHandle fogStartHandle = null;
    private EffectHandle fogEndHandle = null;
    private EffectHandle fogDensityHandle = null;
    private EffectHandle colorValuesHandle = null;
    private EffectHandle[] mapOffsetHandles = null;

    [Console("halo_generic_stage_count", "this is the maximum number of stages that will draw in shader_transparent_generic tags.")]
    private static int MaxStageCount = 7;
    [Console("halo_generic_raster_resolution_factor", "this is the INVERSE of the rasterizer resolution multiplier for shader_transparent_generic tags. must be a power of two.")]
    private static int RasterResolutionFactor = 4;
    [Console("halo_generic_raster_resolution_max", "this is the absolute maximum resolution for shader_transparent_generic tags. must be a power of two.")]
    private static int MaxRasterResolution = 32;
    [Console("halo_generic_raster_time", "shader_transparent_generic tags will only update once every this many milliseconds.")]
    private static int UpdateTicks = 200;
    [Console("halo_generic_alpha_replicate", "shader_transparent_generic tags will render their alpha channels instead of red/green/blue.")]
    private static bool AlphaReplicate = false;

    public override void SetPass(int pass)
    {
      base.SetPass(pass);

      switch (pass)
      {
        case 0:
          MdxRender.Device.RenderState.AlphaTestEnable = shaderTransparentGenericValues.Flags.GetFlag(1);
          MdxRender.Device.RenderState.ReferenceAlpha = 0x80;
          MdxRender.Device.RenderState.AlphaFunction = Compare.GreaterEqual;
          MdxRender.Device.RenderState.CullMode = shaderTransparentGenericValues.Flags.GetFlag(3) ? Cull.None : Cull.CounterClockwise;

          MdxRender.Device.RenderState.AlphaBlendEnable = true;
          SetFramebufferFunction(shaderTransparentGenericValues.FramebufferBlendFunction.Value);

          if (technique == null)
          {
            MdxRender.Device.VertexShader = null;
            MdxRender.Device.PixelShader = null;

            if (Environment.TickCount - updateTick > UpdateTicks)
            {
              Rasterize();
              updateTick = Environment.TickCount;
            }

            MdxRender.Device.SetTexture(0, target);
            MdxRender.Device.TextureState[0].AlphaArgument1 = TextureArgument.TextureColor;
            MdxRender.Device.TextureState[0].ColorArgument1 = TextureArgument.TextureColor;
            MdxRender.Device.TextureState[0].AlphaOperation = TextureOperation.SelectArg1;
            MdxRender.Device.TextureState[0].ColorOperation = TextureOperation.SelectArg1;
            MdxRender.Device.TextureState[0].ResultArgument = TextureArgument.Current;
            MdxRender.Device.TextureState[0].TextureCoordinateIndex = 0;
            MdxRender.Device.TextureState[0].TextureTransform = TextureTransform.Disable;
            MdxRender.Device.TextureState[1].ColorOperation = TextureOperation.Disable;

            if (AlphaReplicate)
              MdxRender.Device.TextureState[0].ColorArgument1 |= TextureArgument.AlphaReplicate;

            MdxRender.Device.SamplerState[0].MinFilter = TextureFilter.Linear;
            MdxRender.Device.SamplerState[0].MagFilter = TextureFilter.Linear;
            MdxRender.Device.SamplerState[0].MipFilter = TextureFilter.Linear;
          }
          else
            effect.BeginPass(pass);
          break;
      }
    }

    public override int BeginApply()
    {
      base.BeginApply();
      if (technique == null)
      {
        fogWasEnabled = MdxRender.Device.RenderState.FogEnable;
        MdxRender.Device.RenderState.FogEnable = false;
        return 1;
      }
      else
      {
        effect.SetValue(cameraHandle, new Vector4(MdxRender.Camera.Position.X, MdxRender.Camera.Position.Y, MdxRender.Camera.Position.Z, 1.0f));
        effect.SetValue(worldHandle, MdxRender.Device.Transform.World);
        effect.SetValue(wvpHandle, MdxRender.Device.Transform.World * MdxRender.Device.Transform.View * MdxRender.Device.Transform.Projection);
        effect.SetValue(fogStartHandle, MdxRender.Device.RenderState.FogStart);
        effect.SetValue(fogEndHandle, MdxRender.Device.RenderState.FogEnd);
        effect.SetValue(fogDensityHandle, MdxRender.Device.RenderState.FogDensity);

        float[] colorValues = new float[7];
        for (int i = 0; i < shaderTransparentGenericValues.Stages.Count; i++)
          colorValues[i] = Animate(shaderTransparentGenericValues.Stages[i].Color0AnimationFunction.Value, shaderTransparentGenericValues.Stages[i].Color0AnimationPeriod.Value, 0.0f);
        effect.SetValue(colorValuesHandle, colorValues);

        for (int i = 0; i < shaderTransparentGenericValues.Maps.Count; i++)
          effect.SetValue(mapOffsetHandles[i], new Vector4(shaderTransparentGenericValues.Maps[i].Map3.Value + Animate(shaderTransparentGenericValues.Maps[i].unnamed3.Value, shaderTransparentGenericValues.Maps[i].unnamed4.Value, shaderTransparentGenericValues.Maps[i].unnamed5.Value) * shaderTransparentGenericValues.Maps[i].unnamed6.Value, shaderTransparentGenericValues.Maps[i].Map4.Value + Animate(shaderTransparentGenericValues.Maps[i].unnamed8.Value, shaderTransparentGenericValues.Maps[i].unnamed9.Value, shaderTransparentGenericValues.Maps[i].unnamed10.Value) * shaderTransparentGenericValues.Maps[i].unnamed11.Value, 1.0f, 1.0f));

        effect.CommitChanges();
        return effect.Begin(FX.DoNotSaveState);
      }
    }

    public override void EndApply()
    {
      base.EndApply();
      if (technique == null)
        MdxRender.Device.RenderState.FogEnable = fogWasEnabled;
      else
      {
        effect.EndPass();
        effect.End();
      }
    }

    public override void DoPostProcess()
    {
      base.DoPostProcess();

      if (MdxRender.Device.DeviceCaps.PixelShaderVersion.Major >= 2)
      {
        string shaderErrors = null;
        effect = Effect.FromString(MdxRender.Device, GenerateEffect(), null, null, ShaderFlags.None, null, out shaderErrors);
        if (!String.IsNullOrEmpty(shaderErrors))
        {
          Output.Write(OutputTypes.Debug, "Failed to initialize shader_transparent_generic effect: " + shaderErrors);
          goto SoftwareInitialization;
        }

        worldHandle = effect.GetParameter(null, "world");
        wvpHandle = effect.GetParameter(null, "worldViewProjection");
        cameraHandle = effect.GetParameter(null, "cameraPosition");
        fogStartHandle = effect.GetParameter(null, "fogStart");
        fogEndHandle = effect.GetParameter(null, "fogEnd");
        fogDensityHandle = effect.GetParameter(null, "fogDensity");
        mapOffsetHandles = new EffectHandle[shaderTransparentGenericValues.Maps.Count];
        for (int j = 0; j < shaderTransparentGenericValues.Maps.Count; j++)
          mapOffsetHandles[j] = effect.GetParameter(null, "map" + j.ToString() + "Offset");
        colorValuesHandle = effect.GetParameter(null, "colorValues");

        maps = new bitmap[shaderTransparentGenericValues.Maps.Count];
        for (int j = 0; j < shaderTransparentGenericValues.Maps.Count; j++)
        {
          maps[j] = Open<bitmap>(shaderTransparentGenericValues.Maps[j].Map5.Value);
          if (maps[j] == null)
            effect.SetValue(effect.GetParameter(null, "Map" + j.ToString()), default2d[Additive]);
          else
            effect.SetValue(effect.GetParameter(null, "Map" + j.ToString()), maps[j][0]);
          effect.SetValue(effect.GetParameter(null, "map" + j.ToString() + "Scale"), new Vector4(shaderTransparentGenericValues.Maps[j].Map.Value, shaderTransparentGenericValues.Maps[j].Map2.Value, 0.0f, 0.0f));
        }

        ColorValue[] constant0Low = new ColorValue[7];
        ColorValue[] constant0High = new ColorValue[7];
        ColorValue[] constant1 = new ColorValue[7];
        for (int j = 0; j < shaderTransparentGenericValues.Stages.Count; j++)
        {
          constant0Low[j] = new ColorValue(shaderTransparentGenericValues.Stages[j].Color0AnimationLowerBound.R, shaderTransparentGenericValues.Stages[j].Color0AnimationLowerBound.G, shaderTransparentGenericValues.Stages[j].Color0AnimationLowerBound.B, shaderTransparentGenericValues.Stages[j].Color0AnimationLowerBound.A);
          constant0High[j] = new ColorValue(shaderTransparentGenericValues.Stages[j].Color0AnimationUpperBound.R, shaderTransparentGenericValues.Stages[j].Color0AnimationUpperBound.G, shaderTransparentGenericValues.Stages[j].Color0AnimationUpperBound.B, shaderTransparentGenericValues.Stages[j].Color0AnimationUpperBound.A);
          constant1[j] = new ColorValue(shaderTransparentGenericValues.Stages[j].Color1.R, shaderTransparentGenericValues.Stages[j].Color1.G, shaderTransparentGenericValues.Stages[j].Color1.B, shaderTransparentGenericValues.Stages[j].Color1.A);
        }
        effect.SetValue(effect.GetParameter(null, "constantColor0Low"), constant0Low);
        effect.SetValue(effect.GetParameter(null, "constantColor0High"), constant0High);
        effect.SetValue(effect.GetParameter(null, "constantColor1"), constant1);

        effect.Technique = technique = effect.GetTechnique("GenericTransparent");
        return;
      }

    SoftwareInitialization:
      int width = 0, height = 0;
      maps = new bitmap[shaderTransparentGenericValues.Maps.Count];
      samplers = new Sampler[shaderTransparentGenericValues.Maps.Count];
      for (int i = 0; i < maps.Length; i++)
      {
        maps[i] = Open<bitmap>(shaderTransparentGenericValues.Maps[i].Map5.Value);
        if (maps[i] == null)
          continue;
        if (maps[i].BitmapValues.Bitmaps[0].Width.Value > width)
          width = maps[i].BitmapValues.Bitmaps[0].Width.Value;
        if (maps[i].BitmapValues.Bitmaps[0].Height.Value > height)
          height = maps[i].BitmapValues.Bitmaps[0].Height.Value;
        if (maps[i][0] != null)
          samplers[i] = new Sampler(maps[i][0] as Texture, maps[i].GetFormat(0), maps[i].BitmapValues.Bitmaps[0].Width.Value, maps[i].BitmapValues.Bitmaps[0].Height.Value);
      }

      width /= RasterResolutionFactor;
      height /= RasterResolutionFactor;
      if (width < 1)
        width = 1;
      if (height < 1)
        height = 1;
      if (width > MaxRasterResolution)
        width = MaxRasterResolution;
      if (height > MaxRasterResolution)
        height = MaxRasterResolution;

      targetSize = new Size(width, height);
      target = new Texture(MdxRender.Device, width, height, 1, Usage.None, Format.A8R8G8B8, Pool.Managed);
    }

    public override void Dispose()
    {
      base.Dispose();

      if (effect != null)
        effect.Dispose();

      if (target != null)
        target.Dispose();

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

    protected virtual void Rasterize()
    {
      List<ShaderTransparentGenericStageBlock> stages = shaderTransparentGenericValues.Stages;

      GraphicsStream pixelData = target.LockRectangle(0, LockFlags.None);
      pixelData.Position = 0;
      for (int y = 0; y < targetSize.Height; y++)
      {
        for (int x = 0; x < targetSize.Width; x++)
        {
          // this is a pixel shader emulation. crazy.
          float u = (float)x / (float)targetSize.Width, v = (float)y / (float)targetSize.Height;
          Vector4 scratch0 = Vector4.Empty, scratch1 = Vector4.Empty;
          Vector4 vertex0 = Vectorize(1.0f), vertex1 = Vectorize(1.0f);
          Vector4 map0 = Sample(0, u, v), map1 = Sample(1, u, v), map2 = Sample(2, u, v), map3 = Sample(3, u, v);

          for (int i = 0; i < stages.Count && i < MaxStageCount; i++)
          {
            Vector4 constant0 = Vector4.Lerp(Vectorize(stages[i].Color0AnimationLowerBound), Vectorize(stages[i].Color0AnimationUpperBound), Animate(stages[i].Color0AnimationFunction.Value, stages[i].Color0AnimationPeriod.Value, 0.0f));
            Vector4 constant1 = Vectorize(stages[i].Color1);

            float alphaInputA = InputMapping(InputSource(stages[i].InputA2.Value, map0.W, map1.W, map2.W, map3.W, vertex0.W, vertex1.W, scratch0.W, scratch1.W, constant0.W, constant1.W, map0.Z, map1.Z, map2.Z, map3.Z, vertex0.Z, vertex1.Z, scratch0.Z, scratch1.Z, constant0.Z, constant1.Z), stages[i].InputAMapping2.Value);
            float alphaInputB = InputMapping(InputSource(stages[i].InputB2.Value, map0.W, map1.W, map2.W, map3.W, vertex0.W, vertex1.W, scratch0.W, scratch1.W, constant0.W, constant1.W, map0.Z, map1.Z, map2.Z, map3.Z, vertex0.Z, vertex1.Z, scratch0.Z, scratch1.Z, constant0.Z, constant1.Z), stages[i].InputBMapping2.Value);
            float alphaInputC = InputMapping(InputSource(stages[i].InputC2.Value, map0.W, map1.W, map2.W, map3.W, vertex0.W, vertex1.W, scratch0.W, scratch1.W, constant0.W, constant1.W, map0.Z, map1.Z, map2.Z, map3.Z, vertex0.Z, vertex1.Z, scratch0.Z, scratch1.Z, constant0.Z, constant1.Z), stages[i].InputCMapping2.Value);
            float alphaInputD = InputMapping(InputSource(stages[i].InputD2.Value, map0.W, map1.W, map2.W, map3.W, vertex0.W, vertex1.W, scratch0.W, scratch1.W, constant0.W, constant1.W, map0.Z, map1.Z, map2.Z, map3.Z, vertex0.Z, vertex1.Z, scratch0.Z, scratch1.Z, constant0.Z, constant1.Z), stages[i].InputDMapping2.Value);

            float alphaOutputAB = alphaInputA * alphaInputB;
            float alphaOutputCD = alphaInputC * alphaInputD;
            float alphaOutputABCD = 0;

            if (stages[i].Flags.GetFlag(2)) // alpha mux
              alphaOutputABCD = (scratch0.W > 0.5f) ? alphaOutputAB : alphaOutputCD;
            else
              alphaOutputABCD = alphaOutputAB + alphaOutputCD;

            alphaOutputAB = OutputMapping(alphaOutputAB, stages[i].OutputMapping2.Value);
            alphaOutputCD = OutputMapping(alphaOutputCD, stages[i].OutputMapping2.Value);
            //alphaOutputABCD = OutputMapping(alphaOutputABCD, stages[i].OutputMapping2.Value);
            OutputDestination(alphaOutputAB, stages[i].OutputAB2.Value, false, ref scratch0, ref scratch1, ref vertex0, ref vertex1, ref map0, ref map1, ref map2, ref map3);
            OutputDestination(alphaOutputCD, stages[i].OutputCD2.Value, false, ref scratch0, ref scratch1, ref vertex0, ref vertex1, ref map0, ref map1, ref map2, ref map3);
            OutputDestination(alphaOutputABCD, stages[i].OutputABCDMuxsum2.Value, false, ref scratch0, ref scratch1, ref vertex0, ref vertex1, ref map0, ref map1, ref map2, ref map3);

            if (stages[i].Flags.GetFlag(3)) // a-out controls color0 animation
              constant0 = Vector4.Lerp(Vectorize(stages[i].Color0AnimationLowerBound), Vectorize(stages[i].Color0AnimationUpperBound), alphaOutputABCD);

            Vector4 colorInputA = InputMapping(InputSource(stages[i].InputA.Value, map0, map1, map2, map3, vertex0, vertex1, scratch0, scratch1, constant0, constant1, Vectorize(map0.W), Vectorize(map1.W), Vectorize(map2.W), Vectorize(map3.W), Vectorize(vertex0.W), Vectorize(vertex1.W), Vectorize(scratch0.W), Vectorize(scratch1.W), Vectorize(constant0.W), Vectorize(constant1.W)), stages[i].InputAMapping.Value);
            Vector4 colorInputB = InputMapping(InputSource(stages[i].InputB.Value, map0, map1, map2, map3, vertex0, vertex1, scratch0, scratch1, constant0, constant1, Vectorize(map0.W), Vectorize(map1.W), Vectorize(map2.W), Vectorize(map3.W), Vectorize(vertex0.W), Vectorize(vertex1.W), Vectorize(scratch0.W), Vectorize(scratch1.W), Vectorize(constant0.W), Vectorize(constant1.W)), stages[i].InputBMapping.Value);
            Vector4 colorInputC = InputMapping(InputSource(stages[i].InputC.Value, map0, map1, map2, map3, vertex0, vertex1, scratch0, scratch1, constant0, constant1, Vectorize(map0.W), Vectorize(map1.W), Vectorize(map2.W), Vectorize(map3.W), Vectorize(vertex0.W), Vectorize(vertex1.W), Vectorize(scratch0.W), Vectorize(scratch1.W), Vectorize(constant0.W), Vectorize(constant1.W)), stages[i].InputCMapping.Value);
            Vector4 colorInputD = InputMapping(InputSource(stages[i].InputD.Value, map0, map1, map2, map3, vertex0, vertex1, scratch0, scratch1, constant0, constant1, Vectorize(map0.W), Vectorize(map1.W), Vectorize(map2.W), Vectorize(map3.W), Vectorize(vertex0.W), Vectorize(vertex1.W), Vectorize(scratch0.W), Vectorize(scratch1.W), Vectorize(constant0.W), Vectorize(constant1.W)), stages[i].InputDMapping.Value);

            Vector4 colorOutputAB = OutputFunction(colorInputA, colorInputB, stages[i].OutputABFunction.Value);
            Vector4 colorOutputCD = OutputFunction(colorInputC, colorInputD, stages[i].OutputCDFunction.Value);
            Vector4 colorOutputABCD = Vector4.Empty;

            if (stages[i].Flags.GetFlag(1)) // color mux
              colorOutputABCD = (scratch0.W > 0.5f) ? colorOutputAB : colorOutputCD;
            else
              colorOutputABCD = colorOutputAB + colorOutputCD;

            colorOutputAB = OutputMapping(colorOutputAB, stages[i].OutputMapping.Value);
            colorOutputCD = OutputMapping(colorOutputCD, stages[i].OutputMapping.Value);
            //colorOutputABCD = OutputMapping(colorOutputABCD, stages[i].OutputMapping.Value);

            OutputDestination(colorOutputAB, stages[i].OutputAB.Value, ref scratch0, ref scratch1, ref vertex0, ref vertex1, ref map0, ref map1, ref map2, ref map3);
            OutputDestination(colorOutputCD, stages[i].OutputCD.Value, ref scratch0, ref scratch1, ref vertex0, ref vertex1, ref map0, ref map1, ref map2, ref map3);
            OutputDestination(colorOutputABCD, stages[i].OutputABCDMuxsum.Value, ref scratch0, ref scratch1, ref vertex0, ref vertex1, ref map0, ref map1, ref map2, ref map3);
          }

          // and this is the part that fakes drawing to a texture. awesome.
          pixelData.Write(BitConverter.GetBytes(new ColorValue(scratch0.X, scratch0.Y, scratch0.Z, scratch0.W).ToArgb()), 0, sizeof(int));
        }
      }
      target.UnlockRectangle(0);
    }

    protected void OutputDestination(Vector4 value, short operation, ref Vector4 scratch0, ref Vector4 scratch1, ref Vector4 vertex0, ref Vector4 vertex1, ref Vector4 map0, ref Vector4 map1, ref Vector4 map2, ref Vector4 map3)
    {
      if (operation == 1) // scratch color 0
        SetXYZ(value, ref scratch0);
      else if (operation == 2) // scratch color 1
        SetXYZ(value, ref scratch1);
      else if (operation == 3) // vertex color 0
        SetXYZ(value, ref vertex0);
      else if (operation == 4) // vertex color 1
        SetXYZ(value, ref vertex1);
      else if (operation == 5) // map color 0
        SetXYZ(value, ref map0);
      else if (operation == 6) // map color 1
        SetXYZ(value, ref map1);
      else if (operation == 7) // map color 2
        SetXYZ(value, ref map2);
      else if (operation == 8) // map color 3
        SetXYZ(value, ref map3);
    }

    private void SetXYZ(Vector4 source, ref Vector4 destination)
    {
      destination.X = source.X;
      destination.Y = source.Y;
      destination.Z = source.Z;
    }

    protected void OutputDestination(float value, short operation, bool multiply, ref Vector4 scratch0, ref Vector4 scratch1, ref Vector4 vertex0, ref Vector4 vertex1, ref Vector4 map0, ref Vector4 map1, ref Vector4 map2, ref Vector4 map3)
    {
      if (multiply)
      {
        if (operation == 1) // scratch color 0
          scratch0.W *= value;
        else if (operation == 2) // scratch color 1
          scratch1.W *= value;
        else if (operation == 3) // vertex color 0
          vertex0.W *= value;
        else if (operation == 4) // vertex color 1
          vertex1.W *= value;
        else if (operation == 5) // map color 0
          map0.W *= value;
        else if (operation == 6) // map color 1
          map1.W *= value;
        else if (operation == 7) // map color 2
          map2.W *= value;
        else if (operation == 8) // map color 3
          map3.W *= value;
      }
      else
      {
        if (operation == 1) // scratch color 0
          scratch0.W = value;
        else if (operation == 2) // scratch color 1
          scratch1.W = value;
        else if (operation == 3) // vertex color 0
          vertex0.W = value;
        else if (operation == 4) // vertex color 1
          vertex1.W = value;
        else if (operation == 5) // map color 0
          map0.W = value;
        else if (operation == 6) // map color 1
          map1.W = value;
        else if (operation == 7) // map color 2
          map2.W = value;
        else if (operation == 8) // map color 3
          map3.W = value;
      }
    }

    protected Vector4 Vectorize(float value)
    { return new Vector4(value, value, value, value); }

    protected Vector4 Vectorize(RealARGBColor value)
    { return new Vector4(value.R, value.G, value.B, value.A); }

    protected float InputMapping(float value, short operation)
    {
      if (operation == 0) // clamp(x)
        value = Saturate(value);
      else if (operation == 1) // 1 - clamp(x)
        value = 1.0f - Saturate(value);
      else if (operation == 2) // 2 * clamp(x) - 1
        value = 2.0f * Saturate(value) - 1.0f;
      else if (operation == 3) // 1 - 2 * clamp(x)
        value = 1.0f - 2.0f * Saturate(value);
      else if (operation == 4) // clamp(x) - 1/2
        value = Saturate(value) - 0.5f;
      else if (operation == 5) // 1/2 - clamp(x)
        value = 0.5f - Saturate(value);
      else if (operation == 7) // -x
        value = -value;
      return value;
    }

    protected Vector4 InputMapping(Vector4 value, short operation)
    {
      if (operation == 0) // clamp(x)
        value = Saturate(value);
      else if (operation == 1) // 1 - clamp(x)
        value = Vectorize(1.0f) - Saturate(value);
      else if (operation == 2) // 2 * clamp(x) - 1
        value = 2.0f * Saturate(value) - Vectorize(1.0f);
      else if (operation == 3) // 1 - 2 * clamp(x)
        value = Vectorize(1.0f) - (2.0f * Saturate(value));
      else if (operation == 4) // clamp(x) - 1/2
        value = Saturate(value) - Vectorize(0.5f);
      else if (operation == 5) // 1/2 - clamp(x)
        value = Vectorize(0.5f) - Saturate(value);
      else if (operation == 7) // -x
        value = -value;
      return value;
    }

    protected Vector4 OutputMapping(Vector4 value, short operation)
    {
      if (operation == 1) // scale by 1/2
        value = value * 0.5f;
      else if (operation == 2) // scale by 2
        value = value * 2.0f;
      else if (operation == 3) // scale by 4
        value = value * 4.0f;
      else if (operation == 4) // bias by -1/2
        value = value - Vectorize(0.5f);
      else if (operation == 5) // expand normal
        value = Vector4.Normalize(value);
      return value;
    }

    protected float OutputMapping(float value, short operation)
    {
      if (operation == 1) // scale by 1/2
        value = value * 0.5f;
      else if (operation == 2) // scale by 2
        value = value * 2.0f;
      else if (operation == 3) // scale by 4
        value = value * 4.0f;
      else if (operation == 4) // bias by -1/2
        value = value - 0.5f;
      return value;
    }

    protected Vector4 OutputFunction(Vector4 left, Vector4 right, short operation)
    {
      Vector4 output = new Vector4();
      if (operation == 0) // multiply
        output = new Vector4(left.X * right.X, left.Y * right.Y, left.Z * right.Z, left.W * right.W);
      else if (operation == 1) // dot product
        output = Vectorize(Vector4.Dot(left, right));
      return output;
    }

    protected Vector4 Saturate(Vector4 value)
    {
      if (value.X > 1.0f)
        value.X = 1.0f;
      else if (value.X < 0.0f)
        value.X = 0.0f;
      if (value.Y > 1.0f)
        value.Y = 1.0f;
      else if (value.Y < 0.0f)
        value.Y = 0.0f;
      if (value.Z > 1.0f)
        value.Z = 1.0f;
      else if (value.Z < 0.0f)
        value.Z = 0.0f;
      if (value.W > 1.0f)
        value.W = 1.0f;
      else if (value.W < 0.0f)
        value.W = 0.0f;
      return value;
    }

    protected float Saturate(float value)
    {
      if (value > 1.0f)
        value = 1.0f;
      else if (value < 0.0f)
        value = 0.0f;
      return value;
    }

    protected Vector4 InputSource(short source, Vector4 mapX0, Vector4 mapX1, Vector4 mapX2, Vector4 mapX3, Vector4 vertexX0, Vector4 vertexX1, Vector4 scratchX0, Vector4 scratchX1, Vector4 constantX0, Vector4 constantX1, Vector4 mapY0, Vector4 mapY1, Vector4 mapY2, Vector4 mapY3, Vector4 vertexY0, Vector4 vertexY1, Vector4 scratchY0, Vector4 scratchY1, Vector4 constantY0, Vector4 constantY1)
    {Vector4 output = Vector4.Empty;
      if (source == 1) // one
        output = new Vector4(1.0f, 1.0f, 1.0f, 1.0f);
      else if (source == 2) // one half
        output = new Vector4(0.5f, 0.5f, 0.5f, 0.5f);
      else if (source == 3) // negative one
        output = new Vector4(-1.0f, -1.0f, -1.0f, -1.0f);
      else if (source == 4) // negative one half
        output = new Vector4(-0.5f, -0.5f, -0.5f, -0.5f);
      else if (source == 5) // map x 0
        output = mapX0;
      else if (source == 6) // map x 1
        output = mapX1;
      else if (source == 7) // map x 2
        output = mapX2;
      else if (source == 8) // map x 3
        output = mapX3;
      else if (source == 9) // vertex x 0
        output = vertexX0;
      else if (source == 10) // vertex x 1
        output = vertexX1;
      else if (source == 11) // scratch x 0
        output = scratchX0;
      else if (source == 12) // scratch x 1
        output = scratchX1;
      else if (source == 13) // constant x 0
        output = constantX0;
      else if (source == 14) // constant x 1
        output = constantX1;
      else if (source == 15) // map y 0
        output = mapY0;
      else if (source == 16) // map y 1
        output = mapY1;
      else if (source == 17) // map y 2
        output = mapY2;
      else if (source == 18) // map y 3
        output = mapY3;
      else if (source == 19) // vertex y 0
        output = vertexY0;
      else if (source == 20) // vertex y 1
        output = vertexY1;
      else if (source == 21) // scratch y 0
        output = scratchY0;
      else if (source == 22) // scratch y 1
        output = scratchY1;
      else if (source == 23) // constant y 0
        output = constantY0;
      else if (source == 24) // constant y 1
        output = constantY1;
      return output;
    }

    protected float InputSource(short source, float mapX0, float mapX1, float mapX2, float mapX3, float vertexX0, float vertexX1, float scratchX0, float scratchX1, float constantX0, float constantX1, float mapY0, float mapY1, float mapY2, float mapY3, float vertexY0, float vertexY1, float scratchY0, float scratchY1, float constantY0, float constantY1)
    {
      float output = 0.0f;
      if (source == 1) // one
        output = 1.0f;
      else if (source == 2) // one half
        output = 0.5f;
      else if (source == 3) // negative one
        output = -1.0f;
      else if (source == 4) // negative one half
        output = -0.5f;
      else if (source == 5) // map x 0
        output = mapX0;
      else if (source == 6) // map x 1
        output = mapX1;
      else if (source == 7) // map x 2
        output = mapX2;
      else if (source == 8) // map x 3
        output = mapX3;
      else if (source == 9) // vertex x 0
        output = vertexX0;
      else if (source == 10) // vertex x 1
        output = vertexX1;
      else if (source == 11) // scratch x 0
        output = scratchX0;
      else if (source == 12) // scratch x 1
        output = scratchX1;
      else if (source == 13) // constant x 0
        output = constantX0;
      else if (source == 14) // constant x 1
        output = constantX1;
      else if (source == 15) // map y 0
        output = mapY0;
      else if (source == 16) // map y 1
        output = mapY1;
      else if (source == 17) // map y 2
        output = mapY2;
      else if (source == 18) // map y 3
        output = mapY3;
      else if (source == 19) // vertex y 0
        output = vertexY0;
      else if (source == 20) // vertex y 1
        output = vertexY1;
      else if (source == 21) // scratch y 0
        output = scratchY0;
      else if (source == 22) // scratch y 1
        output = scratchY1;
      else if (source == 23) // constant y 0
        output = constantY0;
      else if (source == 24) // constant y 1
        output = constantY1;
      return output;
    }

    protected Vector4 Sample(int map, float u, float v)
    {
      if (map >= shaderTransparentGenericValues.Maps.Count)
        return Vector4.Empty;
      if (samplers[map] == null)
        return Vector4.Empty;
      Color color = samplers[map].Sample(
        u + shaderTransparentGenericValues.Maps[map].Map3.Value +
        Animate(shaderTransparentGenericValues.Maps[map].unnamed3.Value, shaderTransparentGenericValues.Maps[map].unnamed4.Value, shaderTransparentGenericValues.Maps[map].unnamed5.Value) * shaderTransparentGenericValues.Maps[map].unnamed6.Value,
        v + shaderTransparentGenericValues.Maps[map].Map4.Value +
        Animate(shaderTransparentGenericValues.Maps[map].unnamed8.Value, shaderTransparentGenericValues.Maps[map].unnamed9.Value, shaderTransparentGenericValues.Maps[map].unnamed10.Value) * shaderTransparentGenericValues.Maps[map].unnamed11.Value);
      ColorValue value = ColorValue.FromColor(color);
      return new Vector4(value.Red, value.Green, value.Blue, value.Alpha);
    }

    protected virtual string GenerateEffect()
    {
      Assembly executing = Assembly.GetExecutingAssembly();
      StringBuilder output = new StringBuilder();
      List<ShaderTransparentGenericStageBlock> stages = shaderTransparentGenericValues.Stages;

      for (int i = 0; i < shaderTransparentGenericValues.Maps.Count; i++)
        if (shaderTransparentGenericValues.Maps[i].Flags.GetFlag(1))
          output.AppendFormat("#define UNFILTERED_{0}\n", i);

      StreamReader reader = new StreamReader(executing.GetManifestResourceStream("Games.Halo.Resources.Shaders.shader_transparent_generic.generic_a.fx"));
      output.Append(reader.ReadToEnd());
      reader.Close();

      if (stages.Count == 0)
      {
        output.Append("\t// shader has no stages; creating one.\n");
        output.Append(CodeLine("scratch_0 = map_0"));
      }
      else
      {
        for (int i = 0; i < stages.Count; i++)
        {
          output.AppendFormat("\t// stage {0}\n", i);

          output.AppendFormat(CodeLine("constant_0 = lerp(constantColor0Low[{0}], constantColor0High[{0}], colorValues[{0}])"), i);
          output.AppendFormat(CodeLine("constant_1 = constantColor1[{0}]"), i);

          output.AppendFormat(CodeLine("alphaInputA = {0}"), InputMappingString(AlphaInputSourceString(stages[i].InputA2.Value), stages[i].InputAMapping2.Value));
          output.AppendFormat(CodeLine("alphaInputB = {0}"), InputMappingString(AlphaInputSourceString(stages[i].InputB2.Value), stages[i].InputBMapping2.Value));
          output.AppendFormat(CodeLine("alphaInputC = {0}"), InputMappingString(AlphaInputSourceString(stages[i].InputC2.Value), stages[i].InputCMapping2.Value));
          output.AppendFormat(CodeLine("alphaInputD = {0}"), InputMappingString(AlphaInputSourceString(stages[i].InputD2.Value), stages[i].InputDMapping2.Value));
          output.Append(CodeLine("alphaOutputAB = alphaInputA * alphaInputB"));
          output.Append(CodeLine("alphaOutputCD = alphaInputC * alphaInputD"));
          if (stages[i].Flags.GetFlag(2)) // alpha mux
            output.Append(CodeLine("alphaOutputABCD = (scratch_0.a > 0.5f) ? alphaOutputAB : alphaOutputCD"));
          else
            output.Append(CodeLine("alphaOutputABCD = alphaOutputAB + alphaOutputCD"));
          if (stages[i].OutputAB2.Value != 0)
            output.AppendFormat(CodeLine("{0}.a = alphaOutputAB"), OutputDestinationString(stages[i].OutputAB2.Value));
          if (stages[i].OutputCD2.Value != 0)
            output.AppendFormat(CodeLine("{0}.a = alphaOutputCD"), OutputDestinationString(stages[i].OutputCD2.Value));
          if (stages[i].OutputABCDMuxsum2.Value != 0)
            output.AppendFormat(CodeLine("{0}.a = alphaOutputABCD"), OutputDestinationString(stages[i].OutputABCDMuxsum2.Value));

          if (stages[i].Flags.GetFlag(3)) // a-out controls color0 animation
            output.AppendFormat(CodeLine("constant_0 = lerp(constantColor0Low[{0}], constantColor0High[{0}], alphaOutputABCD)"), i);

          output.AppendFormat(CodeLine("colorInputA = {0}"), InputMappingString(ColorInputSourceString(stages[i].InputA.Value), stages[i].InputAMapping.Value));
          output.AppendFormat(CodeLine("colorInputB = {0}"), InputMappingString(ColorInputSourceString(stages[i].InputB.Value), stages[i].InputBMapping.Value));
          output.AppendFormat(CodeLine("colorInputC = {0}"), InputMappingString(ColorInputSourceString(stages[i].InputC.Value), stages[i].InputCMapping.Value));
          output.AppendFormat(CodeLine("colorInputD = {0}"), InputMappingString(ColorInputSourceString(stages[i].InputD.Value), stages[i].InputDMapping.Value));
          output.Append(CodeLine("colorOutputAB = " + OutputFunctionString("colorInputA", "colorInputB", stages[i].OutputABFunction.Value)));
          output.Append(CodeLine("colorOutputCD = " + OutputFunctionString("colorInputC", "colorInputD", stages[i].OutputCDFunction.Value)));
          if (stages[i].Flags.GetFlag(1)) // color mux
            output.Append(CodeLine("colorOutputABCD = (scratch_0.a > 0.5f) ? colorOutputAB : colorOutputCD"));
          else
            output.Append(CodeLine("colorOutputABCD = colorOutputAB + colorOutputCD"));
          if (stages[i].OutputAB.Value != 0)
            output.AppendFormat(CodeLine("{0}.rgb = colorOutputAB.rgb"), OutputDestinationString(stages[i].OutputAB.Value));
          if (stages[i].OutputCD.Value != 0)
            output.AppendFormat(CodeLine("{0}.rgb = colorOutputCD.rgb"), OutputDestinationString(stages[i].OutputCD.Value));
          if (stages[i].OutputABCDMuxsum.Value != 0)
            output.AppendFormat(CodeLine("{0}.rgb = colorOutputABCD.rgb"), OutputDestinationString(stages[i].OutputABCDMuxsum.Value));

          output.Append('\n');
        }
      }

      reader = new StreamReader(executing.GetManifestResourceStream("Games.Halo.Resources.Shaders.shader_transparent_generic.generic_b.fx"));
      output.Append(reader.ReadToEnd());
      reader.Close();

      return output.ToString();
    }

    protected string OutputDestinationString(short destination)
    {
      if (destination == 1) // scratch color 0
        return "scratch_0";
      else if (destination == 2) // scratch color 1
        return "scratch_1";
      else if (destination == 3) // vertex color 0
        return "vertex_0";
      else if (destination == 4) // vertex color 1
        return "vertex_1";
      else if (destination == 5) // map color 0
        return "map_0";
      else if (destination == 6) // map color 1
        return "map_1";
      else if (destination == 7) // map color 2
        return "map_2";
      else if (destination == 8) // map color 3
        return "map_3";
      else
        throw new HaloException("Could not map output destination field.");
    }

    protected string OutputFunctionString(string a, string b, short function)
    {
      if (function == 0) // multiply
        return a + " * " + b;
      else if (function == 1) // dot product
        return "dot(" + a + ", " + b + ")";
      else
        throw new HaloException("Failed to map an output function in a generic shader.");
    }

    protected string InputMappingString(string input, short mapping)
    {
      if (mapping == 0) // clamp(x)
	      return "saturate(" + input + ")";
      else if (mapping == 1) // 1 - clamp(x)
        return "1.0f - saturate(" + input + ")";
      else if (mapping == 2) // 2 * clamp(x) - 1
        return "2.0f * saturate(" + input + ") - 1.0f";
      else if (mapping == 3) // 1 - 2 * clamp(x)
        return "1.0f - 2.0f * saturate(" + input + ")";
      else if (mapping == 4) // clamp(x) - 1/2
	      return "saturate(" + input + ") - 0.5f";
      else if (mapping == 5) // 1/2 - clamp(x)
	      return "0.5f - saturate(" + input + ")";
      else if (mapping == 6) // x
	      return input;
      else if (mapping == 7) // -x
        return "-" + input;
      else
        throw new HaloException("Failed to map an input function in a generic shader.");
    }

    protected string AlphaInputSourceString(short source)
    {
      if (source == 0) // zero
        return "0.0f";
      else if (source == 1) // one
        return "1.0f";
      else if (source == 2) // one half
        return "0.5f";
      else if (source == 3) // negative one
        return "-1.0f";
      else if (source == 4) // negative one half
        return "-0.5f";
      else if (source == 5) // map alpha 0
        return "map_0.a";
      else if (source == 6) // map alpha 1
        return "map_1.a";
      else if (source == 7) // map alpha 2
        return "map_2.a";
      else if (source == 8) // map alpha 3
        return "map_3.a";
      else if (source == 9) // vertex alpha 0
        return "vertex_0.a";
      else if (source == 10) // vertex alpha 1
        return "vertex_1.a";
      else if (source == 11) // scratch alpha 0
        return "scratch_0.a";
      else if (source == 12) // scratch alpha 1
        return "scratch_1.a";
      else if (source == 13) // constant alpha 0
        return "constant_0.a";
      else if (source == 14) // constant alpha 1
        return "constant_1.a";
      else if (source == 15) // map blue 0
        return "map_0.b";
      else if (source == 16) // map blue 1
        return "map_1.b";
      else if (source == 17) // map blue 2
        return "map_2.b";
      else if (source == 18) // map blue 3
        return "map_3.b";
      else if (source == 19) // vertex blue 0
        return "vertex_0.b";
      else if (source == 20) // vertex blue 1
        return "vertex_1.b";
      else if (source == 21) // scratch blue 0
        return "scratch_0.b";
      else if (source == 22) // scratch blue 1
        return "scratch_1.b";
      else if (source == 23) // constant blue 0
        return "constant_0.b";
      else if (source == 24) // constant blue 1
        return "constant_1.b";
      else
        throw new HaloException("Could not generate alpha input argument.");
    }

    protected string ColorInputSourceString(short source)
    {
      if (source == 0) // zero
        return "0.0f";
      else if (source == 1) // one
        return "1.0f";
      else if (source == 2) // one half
        return "0.5f";
      else if (source == 3) // negative one
        return "-1.0f";
      else if (source == 4) // negative one half
        return "-0.5f";
      else if (source == 5) // map 0
        return "map_0";
      else if (source == 6) // map 1
        return "map_1";
      else if (source == 7) // map 2
        return "map_2";
      else if (source == 8) // map 3
        return "map_3";
      else if (source == 9) // vertex 0
        return "vertex_0";
      else if (source == 10) // vertex 1
        return "vertex_1";
      else if (source == 11) // scratch 0
        return "scratch_0";
      else if (source == 12) // scratch 1
        return "scratch_1";
      else if (source == 13) // constant 0
        return "constant_0";
      else if (source == 14) // constant 1
        return "constant_1";
      else if (source == 15) // map alpha 0
        return "map_0.a";
      else if (source == 16) // map alpha 1
        return "map_1.a";
      else if (source == 17) // map alpha 2
        return "map_2.a";
      else if (source == 18) // map alpha 3
        return "map_3.a";
      else if (source == 19) // vertex alpha 0
        return "vertex_0.a";
      else if (source == 20) // vertex alpha 1
        return "vertex_1.a";
      else if (source == 21) // scratch alpha 0
        return "scratch_0.a";
      else if (source == 22) // scratch alpha 1
        return "scratch_1.a";
      else if (source == 23) // constant alpha 0
        return "constant_0.a";
      else if (source == 24) // constant alpha 1
        return "constant_1.a";
      else
        throw new HaloException("Could not generate color input argument.");
    }

    protected static string CodeLine(string input)
    { return "\t" + input + ";\n"; }

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
