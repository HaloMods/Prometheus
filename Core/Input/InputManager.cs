using System;
using System.Windows.Forms;
using Microsoft.DirectX;
using Microsoft.DirectX.DirectInput;
using System.Diagnostics;

namespace Core.Input
{
  /// <summary>
  /// Summary description for InputManager.
  /// </summary>
  public class InputManager
  {
    KeyboardState keyState = null;
    MouseState mouseState;
    private bool bLeftMouseBtn = false;
    private bool bMiddleMouseBtn = false;
    private bool m_bRightMouseBtn = false;

    /// <summary>
    /// This class is responsible for checking the keyboard state each frame and mapping the
    /// inputs to "state variables", such as "CameraForward".  Since the state is encapsulated
    /// inside of this class, we plan on allowing the user to map the keys to the functions they want.
    /// </summary>
    public InputManager()
    {
    }

    #region Camera Keys
    public bool CameraForward
    {
      get
      {
        if (keyState == null)
          return false;
        return (keyState[Key.W]);
      }
    }
    public bool CameraRight
    {
      get
      {
        if (keyState == null)
          return false;
        return (keyState[Key.D]);
      }
    }
    public bool CameraBack
    {
      get
      {
        if (keyState == null)
          return false;
        return (keyState[Key.S]);
      }
    }
    public bool CameraLeft
    {
      get
      {
        if (keyState == null)
          return false;
        return (keyState[Key.A]);
      }
    }
    public bool CameraUp
    {
      get
      {
        if (keyState == null)
          return false;
        return (keyState[Key.R]);
      }
    }
    public bool CameraDown
    {
      get
      {
        if (keyState == null)
          return false;
        return (keyState[Key.F]);
      }
    }
    public bool CameraSpinLeft
    {
      get
      {
        if (keyState == null)
          return false;
        return (keyState[Key.Q]);
      }
    }
    public bool CameraSpinRight
    {
      get
      {
        if (keyState == null)
          return false;
        return (keyState[Key.E]);
      }
    }
    public bool CameraSpeedIncrease
    {
      get
      {
        if (keyState == null)
          return false;
        return (keyState[Key.Space]);
      }
    }
    public bool CameraSpeedDecrease
    {
      get
      {
        if (keyState == null)
          return false;
        return (keyState[Key.LeftShift]);
      }
    }
    #endregion

    public bool IncreaseGamma
    {
      get
      {
        if (keyState == null)
          return false;
        return (keyState[Key.NumPadPlus]);
      }
    }
    public bool DecreaseGamma
    {
      get
      {
        if (keyState == null)
          return false;
        return (keyState[Key.NumPadMinus]);
      }
    }

    #region Edit Keys
    public bool StartSelectionBox
    {
      get
      {
        if (keyState == null)
          return false;
        return (keyState[Key.Z]);
      }
    }
    public bool EditVerticalPlacement
    {
      get
      {
        if (keyState == null)
          return false; 
        return (keyState[Key.LeftControl]);
      }
    }

    public bool ApplyLightmapPaint
    {
      get
      {
        if (keyState == null)
          return false;
        return (keyState[Key.P] && bLeftMouseBtn);
      }
    }
    #endregion

    public int MouseX
    {
      get
      { return (mouseState.X); }
    }
    public int MouseY
    {
      get
      { return (mouseState.Y); }
    }
    public int MouseZ
    {
      get
      { return (mouseState.Z); }
    }
    public bool CameraActive
    {
      get
      {
        return (bLeftMouseBtn && !ApplyLightmapPaint);
      }
    }
    public bool EditActive
    {
      get { return (bLeftMouseBtn); }
    }

    public void Update()
    {
      if (Prometheus.Instance.MdxInputAquired)
      {
        keyState = MdxInput.Keyboard.GetCurrentKeyboardState();
        mouseState = MdxInput.Mouse.CurrentMouseState;

        //get state of mouse buttons
        byte[] buttons = mouseState.GetMouseButtons();
        bLeftMouseBtn = (buttons[0] == 128);
        m_bRightMouseBtn = (buttons[1] == 128);
        bMiddleMouseBtn = (buttons[2] == 128);
        //Trace.WriteLine("left button = " + m_bLeftMouseBtn.ToString());
      }
    }
  }
}
