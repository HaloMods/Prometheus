using System;
using System.Text;
using Interfaces.Games;
using Interfaces.Pool;

namespace Prometheus.Controls
{
  public static class UIHelpers
  {
    /// <summary>
    /// Returns a standardized tooltip to represent a TagPath.
    /// </summary>
    public static string GetTagPathToolTip(TagPath path)
    {
      return GetTagPathToolTip(path, false);
    }

    /// <summary>
    /// Returns a standardized tooltip to represent a TagPath.
    /// </summary>
    public static string GetTagPathToolTip(TagPath path, bool abridged)
    {
      StringBuilder sb = new StringBuilder();
      if (path.Location == TagLocation.Archive)
      {
        sb.Append("<img src=\"global::Prometheus.Properties.Resources.joystick16\"/>");
        if (!abridged)
          if (!String.IsNullOrEmpty(path.Game))
          {
            GameDefinition gd = Core.Prometheus.Instance.GetGameDefinitionByGameID(path.Game);
            if (gd != null)
              sb.Append(" <b>" + gd.LongName + "</b>");
          }
      }
      else if (path.Location == TagLocation.Project)
      {
        sb.Append("<img src=\"global::Prometheus.Properties.Resources.application16\"/>");
        if (!abridged)
          if (Core.Prometheus.Instance.ProjectManager.ProjectLoaded)
            sb.Append(" <b>" + Core.Prometheus.Instance.ProjectManager.Project.MapName + "</b>");
      }
      else
        sb.Append("<i>Unknown Location</i>");


      if (!abridged)
        sb.Append("<br/>");
      else
        sb.Append(" ");
      sb.Append(path.ToPath(PathFormat.Relative));
      return sb.ToString();
    }
  }
}