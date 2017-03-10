using System;

namespace Interfaces.Rendering.Interfaces
{
  public interface IRenderStateModifier
  {
    /// <summary>
    /// Called before the scene is drawn to modify the render state.
    /// </summary>
    void ModifyStateBeforeScene();

    /// <summary>
    /// Called after the scene is drawn to either further modify the state or to return it to its previous state.
    /// </summary>
    void ModifyStateAfterScene();
  }
}
