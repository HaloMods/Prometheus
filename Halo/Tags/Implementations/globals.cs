using System;
using System.Collections.Generic;
using System.Text;

namespace Games.Halo.Tags.Classes
{
  public partial class globals
  {
    private hud_globals hudGlobals = null;

    /// <summary>
    /// Gets the globals value set.
    /// </summary>
    public GlobalsBlock Values
    {
      get
      { return globalsValues; }
    }

    public string[] HudWaypointNames
    {
      get
      {
        string[] waypoints = new string[hudGlobals.HudGlobalsValues.WaypointArrows.Count];
        for (int i = 0; i < hudGlobals.HudGlobalsValues.WaypointArrows.Count; i++)
          waypoints[i] = hudGlobals.HudGlobalsValues.WaypointArrows[i].Name.Value;
        return waypoints;
      }
    }

    public override void DoPostProcess()
    {
      base.DoPostProcess();

      if (globalsValues.InterfaceBitmaps.Count == 0)
        LogError("Failed to load hud globals; INTERFACE BITMAPS block had invalid element count of zero.");
      else
        hudGlobals = Open<hud_globals>(globalsValues.InterfaceBitmaps[0].HudGlobals.Value);
    }

    public override void Dispose()
    {
      base.Dispose();

      Release(hudGlobals);
    }
  }
}
