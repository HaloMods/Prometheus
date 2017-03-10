using System;
using Microsoft.DirectX;

namespace Interfaces
{
  public static class SimpleContainers
  {
    public struct Vector3D
    {
      public float X, Y, Z;

      public Vector3D(Vector3 input)
      {
        X = input.X;
        Y = input.Y;
        Z = input.Z;
      }

      public Vector3 Vector3
      {
        get
        { return new Vector3(X, Y, Z); }
      }
    }
  }
}
