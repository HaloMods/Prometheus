using System;
using Microsoft.DirectX;
using Microsoft.DirectX.DirectSound;

namespace Interfaces.Sound
{
  public static class MdxSound
  {
    private static Device device;

    /// <summary>
    /// Gets or sets the DirectX sound device.
    /// </summary>
    public static Device Device
    {
      get
      { return device; }
      set
      { device = value; }
    }
  }
}
