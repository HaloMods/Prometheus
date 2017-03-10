using System.Drawing;
using Microsoft.DirectX;
using Microsoft.DirectX.Direct3D;
using System;

namespace Core.Rendering
{
  /// <summary> 
  /// Static utility class for invoking static utility functions 
  /// </summary> 
  public class ScreenCapture : IDisposable
  {
    public static void SaveImage(Device device, string fileName, ImageFileFormat format)
    {
      using (Surface backbuffer = device.GetBackBuffer(0, 0, BackBufferType.Mono))
      {
        SurfaceLoader.Save(fileName, format, backbuffer);
      }
    }

    public static Bitmap GetBackBuffer(Device device)
    {
      using (ScreenCapture capture = new ScreenCapture())
        return capture.SaveToBitmap(device);
    }

    private Surface bufferSurface;

    public Bitmap SaveToBitmap(Device device)
    {
      using (Surface backbuffer = device.GetBackBuffer(0, 0, BackBufferType.Mono))
      {
        if (bufferSurface == null)
          CreateBufferSurface(device, backbuffer.Description);
        device.GetRenderTargetData(backbuffer, bufferSurface);
      }
      using (GraphicsStream gStr = SurfaceLoader.SaveToStream(ImageFileFormat.Bmp, bufferSurface))
        return (Bitmap)Bitmap.FromStream(gStr);
    }

    private void CreateBufferSurface(Device device, SurfaceDescription desc)
    {
      bufferSurface = device.CreateOffscreenPlainSurface(desc.Width, desc.Height, desc.Format, Microsoft.DirectX.Direct3D.Pool.SystemMemory);
    }

    public void Dispose()
    {
      if (bufferSurface != null)
      {
        bufferSurface.Dispose();
        bufferSurface = null;
      }
    }
  }
}