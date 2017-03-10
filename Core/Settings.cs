using System;
using System.Collections.Generic;
using System.Text;
using Interfaces.Settings;
using System.ComponentModel;
using Interfaces.DebugConsole;

namespace Core
{
  public class Settings : IPersistable, INotifyPropertyChanged
  {
    [Console("camera_speed", "sets the camera to the specified speed.", "<float>")]
    private static float cameraSpeed;
    private static float cameraSensitivity;
    private static bool cameraZPitching;
    //private static string cameraStopStyle;
    private static float cameraNearPlane;
    private static float cameraFarPlane;

    [PersistableOption("CameraSpeed", "Rendering", 10f, OptionsFile.System)]
    public float CameraSpeed
    {
      get { return cameraSpeed; }
      set
      { 
        cameraSpeed = value;
        OnPropertyChanged("CameraSpeed");
      }
    }

    [PersistableOption("CameraSensitivity", "Rendering", 5, OptionsFile.System)]
    public float CameraSensitivity
    {
      get { return cameraSensitivity; }
      set
      {
        cameraSensitivity = value;
        OnPropertyChanged("CameraSensitivity");
      }
    }

    [PersistableOption("CameraZPitching", "Rendering", true, OptionsFile.System)]
    public bool CameraZPitching
    {
      get { return cameraZPitching; }
      set
      {
        cameraZPitching = value;
        OnPropertyChanged("CameraZPitching");
      }
    }

    //[PersistableOption("CameraStopStyle", "Rendering", "", OptionsFile.System)]
    //public int CameraStopStyle
    //{
    //  get { return cameraStopStyle; }
    //  set
    //  {
    //    cameraStopStyle = value;
    //    OnPropertyChanged("CameraStopStyle");
    //  }
    //}

    [PersistableOption("CameraNearPlane", "Rendering", 0.2f, OptionsFile.System)]
    public float CameraNearPlane
    {
      get { return cameraNearPlane; }
      set
      {
        cameraNearPlane = value;
        OnPropertyChanged("CameraNearPlane");
      }
    }

    [PersistableOption("CameraFarPlane", "Rendering", 100000f, OptionsFile.System)]
    public float CameraFarPlane
    {
      get { return cameraFarPlane; }
      set
      {
        cameraFarPlane = value;
        OnPropertyChanged("CameraFarPlane");
      }
    }

    public event PropertyChangedEventHandler PropertyChanged;

    /// <summary>
    /// Triggers the PropertyChanged event.
    /// </summary>
    public virtual void OnPropertyChanged(string propertyName)
    {
      if (PropertyChanged != null)
        PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
      
      // Save the instance.
      Save();
    }

    /// <summary>
    /// This class's static singleton instance.
    /// </summary>
    public static readonly Settings Instance = new Settings();

    private Settings()
    {
      Load();
    }

    public string InstanceName
    {
      get { return "CoreSettings"; }
    }

    public void Load()
    {
      SettingsManager.Instance.LoadInstance(this);
    }

    public void Save()
    {
      SettingsManager.Instance.SaveInstance(this);
    }
  }
}