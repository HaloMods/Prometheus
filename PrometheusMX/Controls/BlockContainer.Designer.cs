using System;
namespace Prometheus.Controls
{
  partial class BlockContainer
  {
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary> 
    /// Clean up any resources being used.
    /// </summary>
    protected override void Dispose(bool disposing)
    {
      if (disposing)
      {
        GC.SuppressFinalize(this); // Standard Dispose/Finalize pattern.

        // Dispose our components.
        if (components != null)
          components.Dispose();

        // Unsubscribe to the theme event.
        //if (renderer != null)
//          renderer.ColorTableChanged -= renderer_ColorTableChanged;

        base.Dispose(disposing);
      }
    }

    #region Component Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify 
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
      bool layoutWasSuspended = LayoutSuspended;

      //this.SuspendLayout();
      // 
      // BlockContainer
      // 
      this.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      if (!layoutWasSuspended)
        this.ResumeLayout(false);

    }

    #endregion
  }
}
