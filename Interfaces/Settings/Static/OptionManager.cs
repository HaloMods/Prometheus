using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Win32;
using Nini.Config;

namespace Interfaces.Options
{
  public delegate void OptionUpdatedHandler(OptionType type);

  public class OptionManager
  {
    static private SettingsInterface userOptions = new SettingsInterface();

    static private float cameraSensitivity;
    static private bool cameraZPitching;
    static private float cameraSpeed;
    static private string cameraStopStyle;
    static private float cameraNearPlane;
    static private float cameraFarPlane;

    static private string haloCEMapsDirectory;
    static private string haloCEBitmapsCache;
    static private string haloCESoundsCache;
    static private string haloCEInterfaceCache;

    static private string haloPCMapsDirectory;
    static private string haloPCBitmapsCache;
    static private string haloPCSoundsCache;

    static private string haloXboxMapsDirectory;
    static private string halo2XboxMapsDirectory;

    public static event OptionUpdatedHandler OptionUpdated;

    internal static SettingsInterface UserOptions
    {
      get { return userOptions; }
    }

    #region Camera
    static public float CameraSensitivity
    {
      get { return cameraSensitivity; }
      set
      {
        cameraSensitivity = value;

        if (OptionUpdated != null)
          OptionUpdated(OptionType.CameraSensitivity);
      }
    }

    static public bool CameraZPitching
    {
      get { return cameraZPitching; }
      set
      {
        cameraZPitching = value;
        if (OptionUpdated != null)
          OptionUpdated(OptionType.CameraZPitching);
      }
    }

    static public float CameraSpeed
    {
      get { return cameraSpeed; }
      set
      {
        cameraSpeed = value;
        if (OptionUpdated != null)
          OptionUpdated(OptionType.CameraSpeed);
      }
    }

    static public string CameraStopStyle
    {
      get { return cameraStopStyle; }
      set
      {
        cameraStopStyle = value;
        if (OptionUpdated != null)
          OptionUpdated(OptionType.CameraStopStyle);
      }
    }

    static public float CameraNearPlane
    {
      get { return cameraNearPlane; }
      set
      {
        cameraNearPlane = value;
        if (OptionUpdated != null)
          OptionUpdated(OptionType.CameraNearPlane);
      }
    }

    static public float CameraFarPlane
    {
      get { return cameraFarPlane; }
      set
      {
        cameraFarPlane = value;
        if (OptionUpdated != null)
          OptionUpdated(OptionType.CameraFarPlane);
      }
    }
    #endregion

    #region HaloCE
    static public string HaloCEMapsDirectory
    {
      get { return haloCEMapsDirectory; }
      set { haloCEMapsDirectory = value; }
    }

    static public string HaloCEBitmapsCache
    {
      get { return haloCEBitmapsCache; }
      set { haloCEBitmapsCache = value; }
    }

    static public string HaloCESoundsCache
    {
      get { return haloCESoundsCache; }
      set { haloCESoundsCache = value; }
    }

    static public string HaloCEInterfaceCache
    {
      get { return haloCEInterfaceCache; }
      set { haloCEInterfaceCache = value; }
    }
    #endregion

    #region HaloPC
    static public string HaloPCMapsDirectory
    {
      get { return haloPCMapsDirectory; }
      set { haloPCMapsDirectory = value; }
    }
    static public string HaloPCBitmapsCache
    {
      get { return haloPCBitmapsCache; }
      set { haloPCBitmapsCache = value; }
    }
    static public string HaloPCSoundsCache
    {
      get { return haloPCSoundsCache; }
      set { haloPCSoundsCache = value; }
    }
    #endregion

    #region Xbox
    static public string HaloXboxMapsDirectory
    {
      get { return haloXboxMapsDirectory; }
      set { haloXboxMapsDirectory = value; }
    }
    static public string Halo2XboxMapsDirectory
    {
      get { return halo2XboxMapsDirectory; }
      set { halo2XboxMapsDirectory = value; }
    }
    #endregion

    /// <summary>
    /// 
    /// </summary>
    /// <param name="coreIniPath">prometheus.ini</param>
    /// <param name="userIniPath">user.ini</param>
    public static void LoadProfile(string iniPath)
    {
      string hpc_maps = "";
      string hce_maps = "";
      #region Detect Registry Install Paths
      RegistryKey rk;
      //Set default values for system options
      rk = Registry.LocalMachine.OpenSubKey("SOFTWARE\\Microsoft\\Microsoft Games\\Halo", false);
      if (rk != null)
      {
        string PcInstallPath = (String)rk.GetValue("EXE Path");
        rk.Close();
        hpc_maps = PcInstallPath + @"\maps\";
      }

      rk = Registry.LocalMachine.OpenSubKey("SOFTWARE\\Microsoft\\Microsoft Games\\Halo CE", false);
      if (rk != null)
      {
        string CeInstallPath = (String)rk.GetValue("EXE Path");
        rk.Close();
        hce_maps = CeInstallPath + @"\maps\";
      }
      #endregion

      userOptions.Filename = iniPath;

      CameraSensitivity = (int)userOptions["Camera", "CameraSensitivity", 5];
      CameraZPitching = (bool)userOptions["Camera", "CameraZ-Pitching", true];
      CameraSpeed = (int)userOptions["Camera", "CameraSpeed", 70];
      //TODO: implement stop style
      //      cameraStopStyle = (string)userOptions["Camera", "CameraStopStyle", "BounceBack"];
      cameraNearPlane = 0.2f;// (float)userOptions["Camera", "NearPlane", 0.2f];
      cameraFarPlane = 100000.0f;// (float)userOptions["Camera", "FarPlane", 100000.0f];
      /*
       * switch (cameraStopStyle.ToLower())
      {
        case "instant":
          break;
        case "glide":
          break;
        default:
          break;
      }
       * */

      haloPCMapsDirectory = (string)userOptions["Map Directories", "Halo PC", hpc_maps];
      haloCEMapsDirectory = (string)userOptions["Map Directories", "Halo CE", hce_maps];
      haloXboxMapsDirectory = (string)userOptions["Map Directories", "Halo Xbox", ""];
      halo2XboxMapsDirectory = (string)userOptions["Map Directories", "Halo2 Xbox", ""];
    }
    public static void SaveProfile(string iniPath)
    {
      userOptions.Filename = iniPath;
      userOptions["Camera", "CameraSensitivity"] = cameraSensitivity;
      userOptions["Camera", "CameraZ-Pitching"] = cameraZPitching;
      userOptions["Camera", "CameraSpeed"] = cameraSpeed;
      //      userOptions["Camera", "CameraStopStyle"] = cameraStopStyle;
      userOptions["Camera", "NearPlane"] = cameraNearPlane;
      userOptions["Camera", "FarPlane"] = cameraFarPlane;

      userOptions["Paths", "HaloPC_MapsPath"] = haloPCMapsDirectory;
      userOptions["Paths", "HaloCE_MapsPath"] = haloCEMapsDirectory;
      userOptions["Paths", "XHalo1_MapsPath"] = haloXboxMapsDirectory;
      userOptions["Paths", "XHalo2_MapsPath"] = halo2XboxMapsDirectory;
    }
  }
}
