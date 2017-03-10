using System.ComponentModel;
using System.Timers;
using Microsoft.DirectX;

namespace Interfaces.Rendering.Wrappers
{
  public class BindingTransform
  {
    private InstanceState internalState = new InstanceState();
    private IAngle3D linkedRotation;
    private IPoint3D linkedPosition;
    public Matrix matrix = new Matrix();

    #region Properties
    public float X
    {
      get { return internalState.X; }
    }

    public float Y
    {
      get { return internalState.Y; }
    }

    public float Z
    {
      get { return internalState.Z; }
    }

    public float Roll
    {
      get { return internalState.Roll; }
    }

    public float Pitch
    {
      get { return internalState.Pitch; }
    }

    public float Yaw
    {
      get { return internalState.Yaw; }
    }
    #endregion

    public BindingTransform() : this(null, null) { ; }

    public BindingTransform(IAngle3D linkedRotation, IPoint3D linkedPosition)
    {
      this.linkedRotation = linkedRotation;
      this.linkedPosition = linkedPosition;
      
      if (linkedRotation != null)
        SetRotation(linkedRotation.Roll, linkedRotation.Pitch, linkedRotation.Yaw, false);
      if (linkedPosition != null)
        SetTranslation(linkedPosition.X, linkedPosition.Y, linkedPosition.Z, false);

      if (linkedPosition is INotifyPropertyChanged)
        (linkedPosition as INotifyPropertyChanged).PropertyChanged +=
          new PropertyChangedEventHandler(linkedPosition_PropertyChanged);

      if (linkedRotation is INotifyPropertyChanged)
        (linkedRotation as INotifyPropertyChanged).PropertyChanged +=
          new PropertyChangedEventHandler(linkedRotation_PropertyChanged);

      if (linkedRotation != null || linkedPosition != null)
        internalState.Update += new EmptyHandler(internalState_Update);

      UpdateTransform();
    }

    private void linkedRotation_PropertyChanged(object sender, PropertyChangedEventArgs e)
    {
      if (!ignoreUpdates)
        SetRotation(linkedRotation.Roll, linkedRotation.Pitch, linkedRotation.Yaw, false);
    }

    private void linkedPosition_PropertyChanged(object sender, PropertyChangedEventArgs e)
    {
      if (!ignoreUpdates)
        SetTranslation(linkedPosition.X, linkedPosition.Y, linkedPosition.Z, false);
    }

    private bool ignoreUpdates = false;
    void internalState_Update()
    {
      ignoreUpdates = true;
      if (linkedRotation != null)
      {
        linkedRotation.Pitch = internalState.Pitch;
        linkedRotation.Roll = internalState.Roll;
        linkedRotation.Yaw = internalState.Yaw;
      }
      if (linkedPosition != null)
      {
        linkedPosition.X = internalState.X;
        linkedPosition.Y = internalState.Y;
        linkedPosition.Z = internalState.Z;
      }
      ignoreUpdates = false;
    }

    /// <summary>
    /// Called during initialization and when the gui changes rotation fields.
    /// </summary>
    public void SetRotation(float roll, float pitch, float yaw)
    {
      SetRotation(roll, pitch, yaw, true);
    }

    /// <summary>
    /// Called during initialization and when the gui changes rotation fields.
    /// </summary>
    private void SetRotation(float roll, float pitch, float yaw, bool internalStateSync)
    {
      internalState.SetOrientation(roll, pitch, yaw, internalStateSync);
      UpdateTransform();
    }

    /// <summary>
    /// Called during initialization and when the gui changes translate fields.
    /// </summary>
    public void SetTranslation(float x, float y, float z)
    {
      SetRotation(x, y, z, true);
    }

    /// <summary>
    /// Called during initialization and when the gui changes translate fields.
    /// </summary>
    private void SetTranslation(float x, float y, float z, bool internalStateSync)
    {
      internalState.SetTranslation(x, y, z, internalStateSync);
      UpdateTransform();
    }

    /// <summary>
    /// Increments/decrements the rotation.  Called when item is moved with
    /// the mouse in the render window.
    /// </summary>
    public void IncrementRotation(float droll, float dpitch, float dyaw)
    {
      internalState.SetOrientation(internalState.Roll - droll,
                                   internalState.Pitch + dpitch, internalState.Yaw + dyaw, true);
      UpdateTransform();
    }

    /// <summary>
    /// Increments/decrements the translation.  Called when item is moved with
    /// the mouse in the render window.
    /// </summary>
    public void IncrementTranslation(Vector3 delta)
    {
      internalState.SetTranslation(internalState.X + delta.X,
                             internalState.Y + delta.Y, internalState.Z + delta.Z, true);
      UpdateTransform();
    }

    /// <summary>
    /// Called to update the transformation matrix following any adjustment
    /// to the rotation or translation.
    /// </summary>
    public void UpdateTransform()
    {
      Matrix rot1 = Matrix.Identity;
      Matrix rot2 = Matrix.Identity;
      Matrix rot3 = Matrix.Identity;
      Matrix trans = new Matrix();

      matrix = Matrix.Identity;
      if (internalState != null)
      {
        //The order of these rotations determines if Prom matches the Game Engine
        rot1.RotateX(internalState.Pitch);
        rot2.RotateY(-internalState.Roll); //TODO: figure out if actual game rotation is negative
        rot3.RotateZ(internalState.Yaw); //perfect
        matrix.Multiply(rot3);
        matrix.Multiply(rot2);
        matrix.Multiply(rot1);
        trans.Translate(internalState.X, internalState.Y, internalState.Z);
        matrix.Multiply(trans);
      }
    }

    /// <summary>
    /// Retrieve rotation information for the TagEditor gui or whatever reason.
    /// </summary>
    public void GetRotation(out float roll, out float pitch, out float yaw)
    {
      roll = internalState.Roll;
      pitch = internalState.Pitch;
      yaw = internalState.Yaw;
    }

    /// <summary>
    /// Retrieve translation information for the TagEditor gui or whatever reason.
    /// </summary>
    public void GetTranslation(out Vector3 translation)
    {
      translation.X = internalState.X;
      translation.Y = internalState.Y;
      translation.Z = internalState.Z;
    }
  }

  public interface IPoint3D
  {
    float X { get; set; }
    float Y { get; set; }
    float Z { get; set; }
  }

  public interface IAngle3D
  {
    float Pitch { get; set; }
    float Roll { get; set; }
    float Yaw { get; set; }
  }

  public delegate void EmptyHandler();
  public class InstanceState
  {
    private float pitch, roll, yaw;
    private float x, y, z;
    private Timer timer;
    public bool SyncEnabled = true;

    public event EmptyHandler Update;

    public InstanceState()
    {
      timer = new Timer(250);
      timer.Elapsed += new ElapsedEventHandler(timer_Elapsed);
    }

    void timer_Elapsed(object sender, ElapsedEventArgs e)
    {
      if (Update != null)
        Update();
    }

    private void ResetTimer()
    {
      if (SyncEnabled)
      {
        timer.Stop();
        timer.Start();
        timer.AutoReset = false;
      }
    }

    public void SetOrientation(float pitch, float roll, float yaw, bool sync)
    {
      SetPitch(pitch, false);
      SetRoll(roll, false);
      SetYaw(yaw, sync);
    }

    public void SetTranslation(float x, float y, float z, bool sync)
    {
      SetX(x, false);
      SetY(y, false);
      SetZ(z, sync);
    }

    public float Pitch
    {
      get { return pitch; }
    }
    public void SetPitch(float value, bool sync)
    {
      pitch = value;
      if (sync) ResetTimer();
    }

    public float Roll
    {
      get { return roll; }
    }
    public void SetRoll(float value, bool sync)
    {
      roll = value;
      if (sync) ResetTimer();
    }

    public float Yaw
    {
      get { return yaw; }
    }
    public void SetYaw(float value, bool sync)
    {
      yaw = value;
      if (sync) ResetTimer();
    }

    public float X
    {
      get { return x; }
    }
    public void SetX(float value, bool sync)
    {
      x = value;
      if (sync) ResetTimer();
    }

    public float Y
    {
      get { return y; }
    }
    public void SetY(float value, bool sync)
    {
      y = value;
      if (sync) ResetTimer();
    }

    public float Z
    {
      get { return z; }
    }
    public void SetZ(float value, bool sync)
    {
      z = value;
      if (sync) ResetTimer();
    }
  }
}