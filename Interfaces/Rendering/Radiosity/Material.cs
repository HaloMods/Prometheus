using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Interfaces.Rendering.Interfaces;

namespace Interfaces.Rendering.Radiosity
{
  public class RadiosityMaterial : IMaterial
  {
    #region IMaterial Members
    public int Index;
    public int DistantLightCount
    {
      get;
      set;
    }

    public global::Interfaces.Rendering.Primitives.RealColor DistantLight1Color
    {
      get;
      set;
    }

    public Microsoft.DirectX.Vector3 DistantLight1Direction
    {
      get;
      set;
    }

    public global::Interfaces.Rendering.Primitives.RealColor DistantLight2Color
    {
      get;
      set;
    }

    public Microsoft.DirectX.Vector3 DistantLight2Direction
    {
      get;
      set;
    }

    public global::Interfaces.Rendering.Primitives.RealColor AmbientLight
    {
      get;
      set; 
      }
    

    public global::Interfaces.Rendering.Primitives.RealColor ReflectionTint
    {
      get;
      set;
    }

    public global::Interfaces.Rendering.Primitives.RealColor ShadowColor
    {
      get;
      set;
    }

    public Microsoft.DirectX.Vector3 ShadowVector
    {
      get;
      set;
    }

    #endregion
  }
}
