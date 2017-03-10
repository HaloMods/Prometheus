using System;
using System.Collections.Generic;
using Microsoft.DirectX;

namespace Interfaces.Rendering.Instancing
{
  /// <summary>
  /// Compares two Instance objects based on their distance away from the global viewer, as well as the transparency state.
  /// </summary>
  public class ViewerDistanceComparer : IComparer<Instance>
  {
    public int Compare(Instance x, Instance y)
    {
      if (x.Transparent ^ y.Transparent)
      {
        if (x.Transparent)
          return 1;
        else
          return -1;
      }
      else
      {
        Vector3 centroidX = x.Centroid;
        Vector3 centroidY = y.Centroid;
        float distanceX = MdxRender.Camera.GetObjectDistance(centroidX.X, centroidX.Y, centroidX.Z);
        float distanceY = MdxRender.Camera.GetObjectDistance(centroidY.X, centroidY.Y, centroidY.Z);

        if (distanceX < distanceY)
          return 1;
        else if (distanceX > distanceY)
          return -1;
        else
          return 0;
      }
    }
  }
}
