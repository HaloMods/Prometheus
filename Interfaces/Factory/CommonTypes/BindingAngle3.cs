using System;

namespace Interfaces.Factory.CommonTypes
{
  public class BindingAngle3
  {
    private float pitch;
    private float roll;
    private float yaw;

    public event EventHandler RotationChanged;

    public float Pitch
    {
      get { return pitch; }
      set
      {
        pitch = value;
      }
    }
    public float Roll
    {
      get { return roll; }
      set 
      {
        roll = value;
      }
    }
    public float Yaw
    {
      get { return yaw; }
      set
      {
        yaw = value;
      }
    }
    public void NotifyGui()
    {
      if (RotationChanged != null) RotationChanged(this, new EventArgs());
    }
  }
}