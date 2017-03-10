using System;
using System.Drawing;
using Microsoft.DirectX.Direct3D;
using Interfaces.Rendering.Interfaces;

namespace Interfaces.Rendering.Instancing.DynamicObjects
{
  /// <summary>
  /// Acts as a link between a dynamic object's color permutation list and the rendering instance used to draw it.
  /// </summary>
  public class DynamicObjectColorProvider
  {
    private int[] permutations = null;
    private float[] interpolators = null;
    private DynamicColorRetrievalMethod method = null;

    private static Random random = new Random();

    public DynamicObjectColorProvider(IDynamicObject entity)
    {
      int colorSourceCount = entity.ColorSourceCount;
      if (colorSourceCount == 0)
        return;
      permutations = new int[colorSourceCount];
      interpolators = new float[colorSourceCount];
      for (int source = 0; source < colorSourceCount; source++)
      {
        permutations[source] = entity.GetColorPermutation(source);
        interpolators[source] = (float)random.NextDouble();
      }
      method = new DynamicColorRetrievalMethod(entity.GetColor);
    }

    public ColorValue GetCurrentColor(int source)
    {
      try
      {
        if (method == null || source < 0)
          return ColorValue.FromColor(Color.White);
        else
          return method(source, permutations[source], interpolators[source]);
      }
      catch
      {
        return ColorValue.FromColor(Color.White);
      }
    }
  }
}
