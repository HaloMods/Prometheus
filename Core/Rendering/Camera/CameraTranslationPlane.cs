using Interfaces.Options;

namespace Core.Rendering.Camera
{
  public class CameraTranslationPlane
  {
    #region Private Fields
    private float m_drive = 0;
    private float m_speed = 0;
    private float m_preCoastSpeed = 0;
    private float m_equilibrium = 0;
    #endregion

    #region Public Properties
    public float Drive
    {
      get { return m_drive; }
      set { m_drive = value; }
    }

    public float Speed
    {
      get { return m_speed; }
    }
    #endregion

    #region Options
    private float maximumSpeedOMultiplier = 0.8f;
    private float m_maximumSpeed
    {
      get { return Settings.Instance.CameraSpeed * maximumSpeedOMultiplier; }
    }
    private float glidingAccelerationOMultiplier = -3f;
    private float bouncebackAccelerationOMultiplier = -8.0f;
    private float m_coastingAcceleration
    {
      get {
        return
          OCameraStopStyle == CameraStopStyle.Glide
            ? Settings.Instance.CameraSpeed * glidingAccelerationOMultiplier
            : Settings.Instance.CameraSpeed * bouncebackAccelerationOMultiplier;
      }
    }
    private float driveAccelerationOMultiplier = 0.8f;
    private float m_driveAcceleration
    {
      get { return Settings.Instance.CameraSpeed * driveAccelerationOMultiplier; }
    }

    [Option("CameraStopStyle", "Camera", CameraStopStyle.BounceBack)]
    private static int OCameraStopStyleField;
    private static CameraStopStyle OCameraStopStyle
    {
      get { return (CameraStopStyle)OCameraStopStyleField; }
    }

    #endregion

    #region Constant Factors
    private /*const */float accelerationReverseFactor = 7;
    private /*const */float bouncebackSpeedLimitFactor = 0.05f;
    private /*const */float bouncebackAccelerationFactor = 0.01f;
    #endregion

    #region Constructors
    public CameraTranslationPlane() {}
    
    public CameraTranslationPlane(float driveMultiplier)
    {
      driveAccelerationOMultiplier *= driveMultiplier;
    }
    #endregion

    #region Methods
    public void Update(float dt)
    {
      if (m_drive != 0)
      {
        m_preCoastSpeed = 0;
        float accelerationFactor = 1;
        if (m_speed < 0 && m_drive > 0)
          accelerationFactor = accelerationReverseFactor;
        else if (m_speed > 0 && m_drive < 0)
          accelerationFactor = accelerationReverseFactor;

        m_speed += m_drive * accelerationFactor * m_driveAcceleration * dt;
        if (m_speed > m_maximumSpeed)
          m_speed = m_maximumSpeed;
        else if (m_speed < -m_maximumSpeed)
          m_speed = -m_maximumSpeed;
      }
      else
      {
        if (m_speed == 0)
          return;

        float accelerationFactor = 1;
        
        switch (OCameraStopStyle)
        {
          case CameraStopStyle.BounceBack:
            if (m_preCoastSpeed == 0) // is it first tick after the user stops the drive force?
            {
              m_preCoastSpeed = m_speed; // take note of our speed here
              m_equilibrium = m_preCoastSpeed * -bouncebackSpeedLimitFactor;
              accelerationFactor = bouncebackAccelerationFactor;
            }
            else if (m_speed == m_equilibrium)
              m_equilibrium = 0;
            if (m_equilibrium == 0)
              accelerationFactor = bouncebackAccelerationFactor;
            break;
          case CameraStopStyle.Instant:
            m_speed = 0;
            return;
        }

        if (m_speed > m_equilibrium)
        {
          m_speed += m_coastingAcceleration * accelerationFactor * dt;
          if (m_speed < m_equilibrium)
            m_speed = m_equilibrium;
        }
        else if (m_speed < m_equilibrium)
        {
          m_speed += -m_coastingAcceleration * accelerationFactor * dt;
          if (m_speed > m_equilibrium)
            m_speed = m_equilibrium;
        }
      }
    }
    #endregion
  }
}
