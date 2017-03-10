using System;
using Microsoft.DirectX;

namespace Interfaces.Rendering.Primitives
{
  public class NodeTransform
  {
    private Matrix absolute = Matrix.Identity;
    private Matrix relative = Matrix.Identity;
    private Vector3 finalNode = Vector3.Empty;

    public Matrix Absolute
    {
      get
      { return absolute; }
      set
      { absolute = value; }
    }

    public Matrix Relative
    {
      get
      { return relative; }
      set
      { relative = value; }
    }

    public Vector3 FinalNode
    {
      get
      { return finalNode; }
      set
      { finalNode = value; }
    }
  }
}
