using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Interfaces.Rendering.Primitives;

using Microsoft.DirectX;

namespace Interfaces.Rendering.Interfaces
{
  public interface IMaterial
  {
    // Halo1 stuff
    int DistantLightCount { get; set; }
    RealColor DistantLight1Color { get; set; }
    Vector3 DistantLight1Direction { get; set; }
    RealColor DistantLight2Color { get; set; }
    Vector3 DistantLight2Direction { get; set; }
    RealColor AmbientLight { get; set; }
    RealColor ReflectionTint { get; set; }
    RealColor ShadowColor { get; set; }
    Vector3 ShadowVector { get; set; }
  }
}
