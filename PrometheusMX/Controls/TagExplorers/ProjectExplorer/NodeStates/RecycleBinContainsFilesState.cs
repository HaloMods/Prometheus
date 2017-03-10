using System;
using System.Collections.Generic;
using System.Text;
using Interfaces.Libraries;
using System.Drawing;

namespace Prometheus.Controls.TagExplorers.Project
{
  class RecycleBinContainsFilesState : NodeState
  {
    private RecycleBin recycleBin;

    public RecycleBinContainsFilesState(RecycleBin recycleBin,
      string name, Bitmap expandedIcon, Bitmap collapsedIcon, Color foregroundColor,
      Color backgroundColor)
        : base(name, expandedIcon, collapsedIcon, foregroundColor, backgroundColor)
    {
      this.recycleBin = recycleBin;
      this.recycleBin.StateChanged += new EventHandler(recycleBin_StateChanged);
    }

    void recycleBin_StateChanged(object sender, EventArgs e)
    {
      bool state = DetermineState(null);
      UpdateSubscribers("recyclebin", state);
    }

    protected override bool DetermineState(NodeInfo info)
    {
      return recycleBin.ContainsFiles();
    }
  }
}
