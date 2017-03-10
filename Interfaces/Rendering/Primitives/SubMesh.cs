using System;
using System.Collections.Generic;
using System.Text;

namespace Interfaces.Rendering.Primitives
{
  /// <summary>
  /// Represents a single subset of a mesh, usually dividing models into shader regions.
  /// </summary>
  public class SubMesh
  {
    private ushort index = 0;
    private ushort count = 0;
    private short shader = 0;

    public SubMesh(ushort index, ushort count, short shaderIndex)
    {
      this.index = index;
      this.count = count;
      this.shader = shaderIndex;
    }

    public ushort Index
    {
      get
      { return index; }
      set
      { index = value; }
    }

    public ushort Count
    {
      get
      { return count; }
      set
      { count = value; }
    }

    public short ShaderIndex
    {
      get
      { return shader; }
      set
      { shader = value; }
    }
  }
}
