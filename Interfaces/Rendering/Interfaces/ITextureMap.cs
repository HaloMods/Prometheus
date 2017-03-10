using System;

namespace Interfaces.Rendering.Interfaces
{
  public interface ITextureMap
  {
    void SaveToRaw(string path, int ix);
    void SaveToTag(string taglocation);
    void SetPixel(float U, float V, float[] Colour, int radius);
    System.Drawing.Bitmap SaveToBitmap();
  }
}
