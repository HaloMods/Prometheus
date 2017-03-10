using System;
using Microsoft.DirectX;
using Microsoft.DirectX.Direct3D;
using Interfaces.Rendering.Interfaces;
using Interfaces.Rendering.Wrappers;
using Interfaces.Rendering.Selection;
using Interfaces.Rendering.Primitives;

namespace Interfaces.Rendering.Instancing
{
  public class StateModifierInstance : Instance
  {
    /// <summary>
    /// Exposes a method that is used to draw the instance.
    /// </summary>
    public override void Render()
    {
      if (update)
        Update();
      if(entity != null)
        entity.Render();
    }

    public StateModifierInstance(IRenderable entity, Vector3 centroid, BoundingBox boundingBox, IRenderStateModifier modifier)
      : base(entity, centroid, boundingBox)
    { this.modifier = modifier; }

    public void PerformSelectionTest()
    {
      //iterate through entity to find selection
    }

    public void PerformObjectMove()
    {
    }
  }
}
