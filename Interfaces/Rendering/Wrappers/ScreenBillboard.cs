using System;
using System.Drawing;
using Microsoft.DirectX;
using Microsoft.DirectX.Direct3D;
using Interfaces.Rendering.Interfaces;

namespace Interfaces.Rendering.Wrappers
{
  /// <summary>
  /// This class draws a 2D shaded rectangle in screen coordinate space.
  /// Used for bitmap and shader preview.
  /// </summary>
  class ScreenBillboard : IRenderable, IDisposable
  {
    IShader billboardShader;
    CustomVertex.TransformedTextured[] verts;

    public ScreenBillboard(Point pos, int sizeX, int sizeY, IShader shader)
    {
      billboardShader = shader;
      verts = new CustomVertex.TransformedTextured[6];
      verts[2] = new CustomVertex.TransformedTextured(pos.X, pos.Y, 0.0f, 1.0f, 0, 0);
      verts[1] = new CustomVertex.TransformedTextured(pos.X, pos.Y + sizeY, 0.0f, 1.0f, 0, 1);
      verts[0] = new CustomVertex.TransformedTextured(pos.X + sizeX, pos.Y, 0.0f, 1.0f, 1, 0);
      
      verts[3] = new CustomVertex.TransformedTextured(pos.X + sizeX, pos.Y + sizeY, 0.0f, 1.0f, 1, 1);
      verts[4] = new CustomVertex.TransformedTextured(pos.X, pos.Y + sizeY, 0.0f, 1.0f, 0, 1);
      verts[5] = new CustomVertex.TransformedTextured(pos.X + sizeX, pos.Y, 0.0f, 1.0f, 1, 0);
    }

    public void Render()
    {
      //MdxRender.Device.VertexFormat = CustomVertex.TransformedTextured.Format;
      MdxRender.Device.VertexFormat = CustomVertex.TransformedTextured.Format;
      int passCount = billboardShader.BeginApply();
      for (int i = 0; i < passCount; i++)
      {
        billboardShader.SetPass(i);
        MdxRender.Device.DrawUserPrimitives(PrimitiveType.TriangleList, 2, verts);
      }
      billboardShader.EndApply();
    }

    /// <summary>
    /// Gets or sets the billboard shader.
    /// </summary>
    public IShader BillboardShader
    {
      get
      { return billboardShader; }
      set
      { billboardShader = value; }
    }

    public void Dispose()
    {
      //count--;
      //if (mesh != null)
      //  mesh.Dispose();
      //mesh = null;
    }

    public bool IntersectRayAABB(Vector3 origin, Vector3 direction)
    {
      return (false);
    }

    public Intersection IntersectRay(Vector3 origin, Vector3 direction)
    {
      return null;
    }

    public int PixelFillCount
    {
      get { return 0; }
      set {}
    }

    public bool IntersectCamera(ICamera camera)
    {
      return (false);
    }

    public bool IntersectPlaneAABB(IPlane plane)
    {
      return (false);
    }

  }
}
