using System;
using Microsoft.DirectX;
using Microsoft.DirectX.Direct3D;
using Interfaces.Rendering.Interfaces;
using Interfaces.Rendering.Instancing;
using System.ComponentModel;
using System.Diagnostics;
using D3D = Microsoft.DirectX.Direct3D;
using System.Drawing;
using Interfaces.Rendering.Utilties;
using Interfaces.DebugConsole;
using System.Collections.Generic;

//We have to have a reference to the windows control so we can resize properly
using System.Windows.Forms;

namespace Interfaces.Rendering
{
  /// <summary>
  /// Contains the DirectX render device.
  /// </summary>
  public class MdxRender
  {
    private static Device device = null;
    private static ICamera camera = null;
    private static FPSCounter fps;
    private static bool drawingTransparent = false;
    [Console("dual_rendering", "setting this to false disables separate render cycles for transparent and opaque geometry.")]
    private static bool dualRender = true;

    [Console("render_debug", "if this field is set to true, debug constructs will be rendered onscreen.")]
#if DEBUG
    private static bool renderDebug = false; 
#else
    private static bool renderDebug = false;
#endif

    //private static DeviceType deviceType = DeviceType.Hardware;

    //Debug Variables (remove later)
    public static bool bLockVis = false;

    /// <summary>
    /// Gets or sets the static rendering device.
    /// </summary>
    public static Device Device
    {
      get
      { return device; }
      set
      { device = value; }
    }
    public static ICamera Camera
    {
      get
      { return camera; }
      set
      { camera = value; }
    }

    public static FPSCounter FrameTimer
    {
      get
      { return fps; }
      set
      { fps = value; }
    }

    public static bool DrawingTransparent
    {
      get
      { return drawingTransparent; }
      set
      { drawingTransparent = value; }
    }

    public static bool DualRendering
    {
      get
      { return dualRender; }
    }

    public static bool RenderDebug
    {
      get
      { return renderDebug; }
    }

    /// <summary>
    /// Uses the diffuse color exclusively in rendering.
    /// </summary>
    public static void ConfigureForDiffuseColor()
    {
      MdxRender.Device.RenderState.AlphaBlendEnable = false;
      MdxRender.Device.TextureState[0].ColorArgument1 = TextureArgument.Diffuse;
      MdxRender.Device.TextureState[0].ColorOperation = TextureOperation.SelectArg1;
      MdxRender.Device.TextureState[1].ColorOperation = TextureOperation.Disable;
    }
    public static void DisableBlend()
    {
      MdxRender.Device.VertexFormat = CustomVertex.PositionTextured.Format;
      for (int i = 0; i < 4; i++)
      {
        MdxRender.Device.TextureState[i].AlphaArgument0 = TextureArgument.Current;
        MdxRender.Device.TextureState[i].AlphaArgument1 = TextureArgument.TextureColor;
        MdxRender.Device.TextureState[i].AlphaArgument2 = TextureArgument.Current;
        MdxRender.Device.TextureState[i].AlphaOperation = TextureOperation.SelectArg1;

        MdxRender.Device.TextureState[i].ColorArgument0 = TextureArgument.Current;
        MdxRender.Device.TextureState[i].ColorArgument1 = TextureArgument.TextureColor;
        MdxRender.Device.TextureState[i].ColorArgument2 = TextureArgument.Current;
        MdxRender.Device.TextureState[i].ColorOperation = TextureOperation.SelectArg1;

        MdxRender.Device.TextureState[i].TextureCoordinateIndex = 0;
      }
      MdxRender.Device.TextureState[1].ColorOperation = TextureOperation.Disable;
      MdxRender.Device.TextureState[2].ColorOperation = TextureOperation.Disable;
      MdxRender.Device.TextureState[3].ColorOperation = TextureOperation.Disable;
    }

    /// <summary>
    /// Transforms a 2D screen-space vector into a 3D world-space vector set (origin and direction).
    /// </summary>
    public static void CalculatePickRayWorld(int screenX, int screenY, out Vector3 direction, out Vector3 origin)
    {
      Vector3 screenVector = new Vector3();
      Viewport viewport = MdxRender.Device.Viewport;
      Matrix projection = MdxRender.Device.Transform.Projection;
      float zoomX = projection.M11;
      float zoomY = projection.M22;

      //Determine projection space vector
      screenVector.X = (((2.0f * screenX) / viewport.Width) - 1) / zoomX;
      screenVector.Y = -(((2.0f * screenY) / viewport.Height) - 1) / zoomY;
      screenVector.Z = 1.0f;

      //transform vector into world coords
      Matrix view = new Matrix();
      view = MdxRender.Device.Transform.View;
      view.Invert();

      // Transform the screen space pick ray into 3D space
      direction.X = (screenVector.X * view.M11 + screenVector.Y * view.M21 - screenVector.Z * view.M31);
      direction.Y = (screenVector.X * view.M12 + screenVector.Y * view.M22 - screenVector.Z * view.M32);
      direction.Z = (screenVector.X * view.M13 + screenVector.Y * view.M23 - screenVector.Z * view.M33);
      direction.Normalize();

      origin.X = view.M41;
      origin.Y = view.M42;
      origin.Z = view.M43;

      // calculates the origin as intersection with near frustum
      origin += direction * viewport.MinZ;

      //Trace.WriteLine("World Space PickRay:  origin = ( "+ Origin.X.ToString() + ", " + Origin.Y.ToString() + ", " + Origin.Z.ToString() +" )  direction = ( "+
      //  Direction.X.ToString() + ", " + Direction.Y.ToString() + ", " + Direction.Z.ToString() + " )");
    }

    /// <summary>
    /// Draws a big ass, ugly line on the screen.
    /// </summary>
    /// <param name="a">where to start</param>
    /// <param name="b">where to end</param>
    /// <param name="color">the color of the line</param>
    public static void DrawDebugLine(Vector3 a, Vector3 b, Color color)
    {
      if (renderDebug)
      {
        using (Line line = new Line(device))
        {
          Matrix transform = device.Transform.World * device.Transform.View * device.Transform.Projection;

          line.Begin();
          line.DrawTransform(new Vector3[] { a, b }, transform, color);
          line.End();
        }
      }
    }
    public static void DrawDebugLine(List<Vector3[]> lines, Color color)
    {
      if (renderDebug)
      {
        using (Line line = new Line(device))
        {
          Matrix transform = device.Transform.World * device.Transform.View * device.Transform.Projection;
          line.Begin();
          for (int x=0;x<lines.Count;x++)
          {
            if (lines[x] != null)
              line.DrawTransform(lines[x], transform, color);
            else
              break;
          }
          line.End();
        }
      }
    }
    public static void DrawDebugLine(CustomVertex.PositionColored[] lines, int count)
    {
      if (renderDebug)
      {
        try
        {
          Device.VertexFormat = CustomVertex.PositionColored.Format;
          Device.VertexShader = null; Device.PixelShader = null;
          Device.Transform.World = Matrix.Identity;

          Device.DrawUserPrimitives(PrimitiveType.LineList, count, lines);
        }
        catch
        {
        }
      }
    }
    public static void DrawPoints(Microsoft.DirectX.Direct3D.CustomVertex.PositionColored[] points, int count)
    {
      renderDebug = true;
      if (renderDebug)
      {
        try
        {
          Device.VertexFormat = CustomVertex.PositionColored.Format;
          Device.VertexShader = null; Device.PixelShader = null;
          Device.Transform.World = Matrix.Identity;
          
          Device.DrawUserPrimitives(PrimitiveType.PointList, count, points);
        }
        catch (InvalidCallException)
        {
          Output.Write(OutputTypes.Error, "Invalid call.");
        }
      }
    }
  }
}