using System;
using Microsoft.DirectX;
using Microsoft.DirectX.DirectInput;

namespace Core.Input
{
  public static class MdxInput
  {
    private static Device keyboard;
    private static Device mouse;

    /// <summary>
    /// Gets or sets the DirectInput keyboard device.
    /// </summary>
    public static Device Keyboard
    {
      get
      { return keyboard; }
      set
      { keyboard = value; }
    }

    /// <summary>
    /// Gets or sets the DirectInput mouse device.
    /// </summary>
    public static Device Mouse
    {
      get
      { return mouse; }
      set
      { mouse = value; }
    }
  }
}
