using System;

namespace Core.Project
{
  /// <summary>
  /// Provides versioning information,
  /// </summary>
  public class ProjectVersion
  {
    private int minorRevision;
    private int majorRevision;
    private VersionDesignation designation;

    /// <summary>
    /// Gets the minor revision number.
    /// </summary>
    public int MinorRevision
    {
      get { return minorRevision; }
    }

    /// <summary>
    /// Gets the major revision number.
    /// </summary>
    public int MajorRevision
    {
      get { return majorRevision; }
    }

    /// <summary>
    /// Gets or sets the designation (alpha, beta, release)
    /// </summary>
    public VersionDesignation Designation
    {
      get { return designation; }
      set { designation = value; }
    }

    public ProjectVersion() : this("") { ; }

    public ProjectVersion(string text)
    {
      string[] parts = text.Split('.');
      if (parts.Length == 2)
      {
        try
        {
          this.minorRevision = Convert.ToInt32(parts[0]);
          this.majorRevision = Convert.ToInt32(parts[1].Substring(0, parts[1].Length - 1));
          if (parts[1].Substring(parts[1].Length - 1, 1) == "a")
          {
            this.designation = VersionDesignation.Alpha;
          }
          else if (parts[1].Substring(parts[1].Length - 1, 1) == "b")
          {
            this.designation = VersionDesignation.Beta;
          }
          else
          {
            this.designation = VersionDesignation.Release;
          }
        }
        catch (Exception ex)
        {
          throw new Exception("Could not parse version string '" + text + "'", ex);
        }
      }
      else
      {
        minorRevision = 0;
        majorRevision = 0;
        designation = VersionDesignation.Alpha;
      }
    }

    /// <summary>
    /// Incremements to the next major revision.
    /// </summary>
    public void IncremenMajorRevision()
    {
      this.majorRevision++;
    }

    /// <summary>
    /// Incremements to the next minor revision.
    /// </summary>
    public void IncremenMinorRevision()
    {
      this.minorRevision++;
    }

    /// <summary>
    /// Manually sets the version.
    /// </summary>
    public void SetVersion(int major, int minor, VersionDesignation designation)
    {
      this.majorRevision = major;
      this.minorRevision = minor;
      this.designation = designation;
    }

    public override string ToString()
    {
      string s = this.majorRevision.ToString() + "." + this.minorRevision.ToString();
      if (designation == VersionDesignation.Alpha) s += "a";
      else if (designation == VersionDesignation.Beta) s += "b";
      return s;
    }
  }
}
