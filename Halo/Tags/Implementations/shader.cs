using System;
using System.Collections.Generic;
using System.Text;
using Interfaces;
using Microsoft.DirectX;
using Microsoft.DirectX.Direct3D;
using Interfaces.Rendering;
using Interfaces.Rendering.Interfaces;

namespace Games.Halo.Tags.Classes
{
  public partial class shader : IShader
  {
    /// <summary>
    /// Represents a shader texture stage setup.
    /// </summary>
    protected class Stage
    {
      private Matrix textureTransform;
      private int stageIndex;
      private bitmap bitmapTag;

      //todo: figure out how to deal with enabled/disabled texture scaling, animation
      public Stage(bitmap bmpTag, int stage)
      {
        bitmapTag = bmpTag;
        stageIndex = stage;
      }

      public float Scale
      {
        set
        {
          textureTransform = Matrix.Identity;
          textureTransform.Scale(value, value, 0);
        }
      }

      public void ConfigureDevice()
      {
        //do device setup here
        MdxRender.Device.SetTexture(stageIndex, null);
        MdxRender.Device.TextureState[stageIndex].TextureCoordinateIndex = 0;

        if (textureTransform == Matrix.Zero || textureTransform == Matrix.Identity)
        {
          MdxRender.Device.TextureState[stageIndex].TextureTransform = TextureTransform.Disable;
        }
        else
        {
          MdxRender.Device.TextureState[stageIndex].TextureTransform = TextureTransform.Count2;
          //update texture transform (animation)
        }
      }
    } // Stage

    // default texture indices
    protected const int Additive = 0;
    protected const int Multiplicative = 1;
    protected const int SignedAdditive = 2;
    protected const int Vector = 3;

    // default textures
    protected bitmap default2d = null;
    protected bitmap default3d = null;
    protected bitmap defaultCube = null;
    protected bitmap vectorNormalization = null;

    // texture cache
    protected Texture lightmap = null;

    // Grenadiac: we should probably make this tag apply some annoying, very visible color pattern to alert users of an invalid shader.
    public virtual int BeginApply()
    {
      return 0;
    }

    public virtual void SetPass(int pass)
    {
      
    }

    public virtual void EndApply()
    {
      
    }

    public Texture Lightmap
    {
      get
      { return lightmap; }
      set
      { lightmap = value; }
    }

    public override void DoPostProcess()
    {
      // always do this
      base.DoPostProcess();

      // load up the default textures
      globals globals = Globals as globals;
      default2d = Open<bitmap>(globals.Values.RasterizerData[0].Default2D.Value);
      default3d = Open<bitmap>(globals.Values.RasterizerData[0].Default3D.Value);
      defaultCube = Open<bitmap>(globals.Values.RasterizerData[0].DefaultCubeMap.Value);
      vectorNormalization = Open<bitmap>(globals.Values.RasterizerData[0].VectorNormalization.Value);
    }

    public override void Dispose()
    {
      // la da da da dum
      base.Dispose();

      // release default textures
      Release(default2d);
      Release(default3d);
      Release(defaultCube);
      Release(vectorNormalization);
    }

    /// <summary>
    /// Returns a modifier scalar value that is the result of an intrinsic animation function.
    /// </summary>
    /// <param name="functionToken">animation function to use</param>
    /// <param name="period">period in seconds</param>
    /// <param name="phase">phase shift in seconds</param>
    /// <returns>coordinate modifier</returns>
    protected static float Animate(short functionToken, float period, float phase)
    {
      PMath.Phase = phase;
      switch (functionToken)
      {
        case 0x0: // one
          return PMath.One();
        case 0x1: // zero
          return PMath.Zero();
        case 0x2: // cosine
        case 0x3:
          return Math.Abs(PMath.Cosine(period * 2.0f, 1.0f));
        //case 0x3: // cosine (variable period)
        //  return Math.Abs(PMath.Cosine(Math.Abs(PMath.Cosine(period, 2.0f)) * 2.0f, 1.0f));
        case 0x4: // diagonal wave
        case 0x5:
          return PMath.Triangle(period, 1.0f);
        //case 0x5: // diagonal wave (variable period)
        //  return PMath.Triangle(PMath.Cosine(period, 2.0f), 1.0f);
        case 0x6: // slide
        case 0x7:
          return PMath.Sawtooth(period, 1.0f);
        //case 0x7: // slide (variable period)
        //  return PMath.Sawtooth(PMath.Cosine(period, 2.0f), 1.0f);
        case 0x8: // noise
          return PMath.Noise(1.0f);
        case 0x9: // jitter
          return PMath.Jitter(1.0f);
        case 0xa: // wander
          return PMath.Wander(period, 1.0f);
        case 0xb: // spark
          return PMath.Spark(1.0f);
        default:
          throw new ArgumentException(functionToken.ToString() + " is not a valid Halo shader animation function token.", "functionToken");
      }
    }

    public virtual bool Transparent
    {
      get
      { return false; }
    }

    protected static void SetDetailBlendFunction(int Operation, int TextureStage)
    {
      switch (Operation)
      {
        case 0:
          MdxRender.Device.TextureState[TextureStage].ColorOperation = TextureOperation.Modulate2X;
          break;
        case 1:
          MdxRender.Device.TextureState[TextureStage].ColorOperation = TextureOperation.Modulate;
          break;
        case 2:
          MdxRender.Device.TextureState[TextureStage].ColorOperation = TextureOperation.AddSigned2X;
          break;
        default:
          MdxRender.Device.TextureState[TextureStage].ColorOperation = TextureOperation.Disable;
          break;
      }
    }

    protected void SetFramebufferBlendFunction(int BlendMode)
    {
      switch (BlendMode)
      {
        case 0:
          //alpha blend
          MdxRender.Device.RenderState.BlendOperation = BlendOperation.Add;
          MdxRender.Device.RenderState.SourceBlend = Blend.SourceAlpha;
          MdxRender.Device.RenderState.DestinationBlend = Blend.InvSourceAlpha;
          break;
        case 1:
          //multiply
          //MdxRender.Device.RenderState.SourceBlend = Blend.SourceAlpha;
          //MdxRender.Device.RenderState.SourceBlend = Blend.InvSourceAlpha;
          break;
        case 2:
          //double multiply
          //MdxRender.Device.RenderState.SourceBlend = Blend.SourceAlpha;
          //MdxRender.Device.RenderState.SourceBlend = Blend.InvSourceAlpha;
          break;
        case 3:
          //add
          MdxRender.Device.RenderState.BlendOperation = BlendOperation.Add;
          MdxRender.Device.RenderState.SourceBlend = Blend.One;
          MdxRender.Device.RenderState.DestinationBlend = Blend.One;
          break;
      }
    }

    protected void SetTextureTransform(int Stage, Matrix transform)
    {
      if (transform.M44 == -1)
      {
        MdxRender.Device.TextureState[Stage].TextureTransform = TextureTransform.Disable;
      }
      else
      {
        //enable uv transform (2d)
        MdxRender.Device.TextureState[Stage].TextureTransform = TextureTransform.Count2;

        switch (Stage)
        {
          case 0:
            MdxRender.Device.Transform.Texture0 = transform;
            break;
          case 1:
            MdxRender.Device.Transform.Texture1 = transform;
            break;
          case 2:
            MdxRender.Device.Transform.Texture2 = transform;
            break;
          case 3:
            MdxRender.Device.Transform.Texture3 = transform;
            break;
        }
      }
    }

    public void SetColorOperation(int TextureStage, int Operation, bool bAlphaReplicate)
    {
      MdxRender.Device.TextureState[TextureStage].ColorArgument1 = TextureArgument.TextureColor;
      if (bAlphaReplicate)
        MdxRender.Device.TextureState[TextureStage].ColorArgument1 |= TextureArgument.AlphaReplicate;

      if (TextureStage == 0)
        MdxRender.Device.TextureState[TextureStage].ColorArgument2 = TextureArgument.TextureColor;
      else
        MdxRender.Device.TextureState[TextureStage].ColorArgument2 = TextureArgument.Current;

      switch (Operation)
      {
        case 0:
          //current
          MdxRender.Device.TextureState[TextureStage].ColorOperation = TextureOperation.SelectArg1;
          break;
        case 1:
          //next_map
          MdxRender.Device.TextureState[TextureStage].ColorOperation = TextureOperation.SelectArg2;
          break;
        case 2:
          //multiply
          MdxRender.Device.TextureState[TextureStage].ColorOperation = TextureOperation.Modulate;
          break;
        case 3:
          //double_multiply
          MdxRender.Device.TextureState[TextureStage].ColorOperation = TextureOperation.Modulate2X;
          break;
        case 4:
          //add
          MdxRender.Device.TextureState[TextureStage].ColorOperation = TextureOperation.Add;
          break;

        //after this, i dunno wtf they are doing
        case 5:
          //add_signed_current
          MdxRender.Device.TextureState[TextureStage].ColorOperation = TextureOperation.AddSigned;
          break;
        case 6:
          //add_signed_next_map
          MdxRender.Device.TextureState[TextureStage].ColorOperation = TextureOperation.AddSigned;
          break;
        case 7:
          //subtract_current
          MdxRender.Device.TextureState[TextureStage].ColorOperation = TextureOperation.Subtract;
          break;
        case 8:
          //subtract_current_next_map
          MdxRender.Device.TextureState[TextureStage].ColorOperation = TextureOperation.Subtract;
          break;
        case 9:
          //blend_current_alpha
          MdxRender.Device.TextureState[TextureStage].ColorOperation = TextureOperation.ModulateAlphaAddColor;
          break;
        case 10:
          //blend_current_alpha_inverse
          MdxRender.Device.TextureState[TextureStage].ColorOperation = TextureOperation.ModulateInvAlphaAddColor;
          break;
        case 11:
          //blend_next_map_alpha
          MdxRender.Device.TextureState[TextureStage].ColorOperation = TextureOperation.ModulateAlphaAddColor;
          break;
        case 12:
          //blend_next_map_alpha_inverse
          MdxRender.Device.TextureState[TextureStage].ColorOperation = TextureOperation.ModulateInvAlphaAddColor;
          break;
      }
    }
    public void SetAlphaOperation(int TextureStage, int Operation, bool bAlphaReplicate)
    {
      MdxRender.Device.TextureState[TextureStage].AlphaArgument1 = TextureArgument.TextureColor;
      if (bAlphaReplicate)
        MdxRender.Device.TextureState[TextureStage].AlphaArgument1 |= TextureArgument.AlphaReplicate;

      if (TextureStage == 0)
        MdxRender.Device.TextureState[TextureStage].AlphaArgument2 = TextureArgument.TextureColor;
      else
        MdxRender.Device.TextureState[TextureStage].AlphaArgument2 = TextureArgument.Current;

      switch (Operation)
      {
        case 0:
          //current
          MdxRender.Device.TextureState[TextureStage].AlphaOperation = TextureOperation.SelectArg1;
          break;
        case 1:
          //next_map
          MdxRender.Device.TextureState[TextureStage].AlphaOperation = TextureOperation.SelectArg2;
          break;
        case 2:
          //multiply
          MdxRender.Device.TextureState[TextureStage].AlphaOperation = TextureOperation.Modulate;
          break;
        case 3:
          //double_multiply
          MdxRender.Device.TextureState[TextureStage].AlphaOperation = TextureOperation.Modulate2X;
          break;
        case 4:
          //add
          MdxRender.Device.TextureState[TextureStage].AlphaOperation = TextureOperation.Add;
          break;
        case 5:
          //add_signed_current
          MdxRender.Device.TextureState[TextureStage].AlphaOperation = TextureOperation.AddSigned;
          break;
        case 6:
          //add_signed_next_map
          MdxRender.Device.TextureState[TextureStage].AlphaOperation = TextureOperation.AddSigned;
          break;
        case 7:
          //subtract_current
          MdxRender.Device.TextureState[TextureStage].AlphaOperation = TextureOperation.Subtract;
          break;
        case 8:
          //subtract_current_next_map
          MdxRender.Device.TextureState[TextureStage].AlphaOperation = TextureOperation.Subtract;
          break;
        case 9:
          //blend_current_alpha
          MdxRender.Device.TextureState[TextureStage].AlphaOperation = TextureOperation.ModulateAlphaAddColor;
          break;
        case 10:
          //blend_current_alpha_inverse
          MdxRender.Device.TextureState[TextureStage].AlphaOperation = TextureOperation.ModulateInvAlphaAddColor;
          break;
        case 11:
          //blend_next_map_alpha
          MdxRender.Device.TextureState[TextureStage].AlphaOperation = TextureOperation.ModulateAlphaAddColor;
          break;
        case 12:
          //blend_next_map_alpha_inverse
          MdxRender.Device.TextureState[TextureStage].AlphaOperation = TextureOperation.ModulateInvAlphaAddColor;
          break;
      }
    }
  }
}
