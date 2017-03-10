//
// Radiosity.save.cs
// 
// Author: James Dickson   james.dickson@gmail.com
// 
// Company: Prometheus Project
// 
// Version: 0.1
//

using System;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

using Core.Libraries;

namespace Core.Radiosity
{
  [Serializable()]
  public sealed partial class RadiosityRenderer
  {
    #region Properties
    /// <summary>
    /// Gets or sets the maximum number of photons per light.
    /// </summary>
    public int MaxPhotons
    {
      get { return m_maxPhotons; }
      set
      {
        if (value < 1)
          throw new RadiosityException("maxp <= 0");
        else
          m_maxPhotons = value;
      }
    }

    /// <summary>
    /// Gets or sets the maximum number of bounces per light.
    /// </summary>
    public int MaxBounces
    {
      get { return this.m_maxBounces; }
      set
      {
        if (value < 1)
          throw new RadiosityException("maxb <= 0");
        else
          this.m_maxBounces = value;
      }
    }

    /// <summary>
    /// Sets the save progress option.
    /// </summary>
    public bool Save
    {
      set { this.m_saveProgress = value; }
    }

    /// <summary>
    /// Gets or sets the photon collision radius.
    /// </summary>
    public int PhotonRadius
    {
      get { return m_textures.Radius; }
      set { m_textures.Radius = value; }
    }
    #endregion

    /// <summary>
    /// Saves light information from lightIndex to end. Assumes other lights
    /// have been fully processed.
    /// </summary>
    /// <param name="lightIndex">Light to save from.</param>
    private void SaveProgress(int lightIndex)
    {
      //TODO
    }

    /// <summary>
    /// Loads a saved lightmap solution.
    /// </summary>
    private void LoadProgress()
    {
      //TODO
    }

    /// <summary>
    /// Saves the generated lightmaps to files.
    /// </summary>
    public void SaveAll()
    {
      SetOperation("Saving data...");
      if (Prometheus.Instance.ProjectManager.ProjectFolder != null)
      {
        DiskFileLibrary _folder = Prometheus.Instance.ProjectManager.ProjectFolder as DiskFileLibrary;

        //TODO: Serailise current state to XML file.

        m_textures.SaveAllRaw(_folder.RootPath);
      }
      else
      {
        throw new RadiosityException("Cannot run radiosity without a project loaded.");
      }
    }
  }
}