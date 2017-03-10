using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Games.Halo.Tags.Classes;
using Games.Halo.Compiler;
using Games.Halo.Tags.Fields;
using Interfaces.Rendering.Radiosity;
using Interfaces.Rendering.Primitives;
using Microsoft.DirectX;

namespace System
{
  public static class Extensions
  {
    public static RadiosityMaterial ToMaterial(this scenario_structure_bsp.StructureBspMaterialBlock block)
    {
      return new RadiosityMaterial
      {
        AmbientLight = new RealColor(block.AmbientColor),
        DistantLight1Color = new RealColor(block.DistantLight0Color),
        DistantLight1Direction = block.DistantLight0Direction.ToVector(),
        DistantLight2Color = new RealColor(block.DistantLight1Color),
        DistantLight2Direction = block.DistantLight1Direction.ToVector(),
        DistantLightCount = block.DistantLightCount,
        ReflectionTint = new RealColor(block.ReflectionTint),
        ShadowColor = new RealColor(block.ShadowColor),
        ShadowVector = block.ShadowVector.ToVector()
      };
    }
    public static Vector3 ToVector(this RealVector3D vector)
    {
      return new Vector3(vector.I, vector.J, vector.K);
    }
    public static Vector2 ToVector(this RealVector2D vector)
    {
      return new Vector2(vector.I, vector.K);
    }
  }
}
