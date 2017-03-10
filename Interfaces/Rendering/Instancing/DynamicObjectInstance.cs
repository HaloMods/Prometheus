using System;
using System.Drawing;
using Microsoft.DirectX;
using Microsoft.DirectX.Direct3D;
using Interfaces.Rendering.Primitives;
using Interfaces.Rendering.Interfaces;
using Interfaces.Rendering.Instancing.DynamicObjects;

namespace Interfaces.Rendering.Instancing
{
  /// <summary>
  /// Represents an instance of a renderable object that has dynamic properties.
  /// </summary>
  public class DynamicObjectInstance : ObjectInstance
  {
    private IDynamicObject dynamicEntity = null;
    private DynamicObjectColorProvider colorProvider = null;

    /// <summary>
    /// Gets a dynamic color defined by a function in the dynamic object contained by this instance.
    /// </summary>
    /// <param name="source">color source to retrieve from</param>
    public ColorValue GetDynamicColor(int source)
    {
      if (source < 0)
        return ColorValue.FromColor(Color.White);
      else
        return colorProvider.GetCurrentColor(source);
    }

    public override void Render()
    {
      if (!base.Render(false))
        return;
      base.BeginOcclusionQuery();

      // this is not ideal, but it gets the job done... hehe...
      dynamicEntity.PixelFillCount = pixelFillCount;
      InstanceCollection dynamicPartInstances = dynamicEntity.DynamicInstances;
      foreach (Instance dynamicPart in dynamicPartInstances)
      {
        if (dynamicPart is PartInstance) // which they all should be, ideally
        {
          PartInstance finalInstance = dynamicPart as PartInstance;
          if (finalInstance.Shader is IDynamicShader) // this will not always be the case
          {
            IDynamicShader shader = finalInstance.Shader as IDynamicShader;
            shader.DynamicColor = GetDynamicColor(shader.DynamicColorSource);
          }
          finalInstance.Render();
        }
        else // but we define a fallback, just in case
          dynamicPart.Render();
      }

      base.EndOcclusionQuery();
    }

    public DynamicObjectInstance(IDynamicObject dynamicEntity, Vector3 centroid, BoundingBox boundingBox)
      : base(dynamicEntity, centroid, boundingBox)
    {
      this.dynamicEntity = dynamicEntity;
      colorProvider = new DynamicObjectColorProvider(this.dynamicEntity);
    }
  }
}
