using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Prometheus.Controls
{
  partial class BlockContainer
  {
    protected void InitializeControls()
    {
      // TODO: Add the container panels, and the controls.
      //controlPanel = new Panel();
      //controlPanel.BackColor = Color.Transparent;
      //Controls.Add(controlPanel);

      // Add the More Info link control.
      /*moreInfoLink = new LinkLabel();
      moreInfoLink.Name = "moreInfoLink";
      moreInfoLink.AutoSize = true;
      moreInfoLink.LinkColor = Color.Gray;
      moreInfoLink.BackColor = Color.Transparent;
      moreInfoLink.TextAlign = ContentAlignment.MiddleLeft;
      MoreInfoText = String.Empty;
      Controls.Add(moreInfoLink);
      moreInfoLink.Click += new EventHandler(moreInfoLink_Click);
      moreInfoLink.BringToFront();

      // Add the Expand/Collapse btnCollapse.
      btnCollapse.Name = "btnCollapse";
      btnCollapse.Toggled = false;
      btnCollapse.Image = Prometheus.Properties.Resources.CollapseTitle;
      btnCollapse.ToggledImage = Prometheus.Properties.Resources.ExpandTitle;
      btnCollapse.Size = new Size(11, 11);
      Controls.Add(btnCollapse);*/
    }
  }
}