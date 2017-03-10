using System;
using System.Drawing;
using System.Windows.Forms;
using Interfaces.Factory;
using DevComponents.DotNetBar.Controls;
using DevComponents.DotNetBar;

namespace Interfaces.TagEditor
{
  /// <summary>
  /// Provides a base for creating a tag editor control that represents a field.
  /// </summary>
  public partial class FieldControl : FieldControlBase
  {

    #region Properties

    /// <summary>
    /// Gets or sets the title text that will be displayed on the control.
    /// </summary>
    public override string Title
    {
      get { return lblTitle.Text; }
      set
      {
        lblTitle.Text = value;
        title = value; // Set text for 'title' string inherited from FieldControlBase.
      }
    }

    /// <summary>
    /// Sets if the lock icon is displayed or not.
    /// </summary>
    public override bool ShowLock
    {
      set
      {
        base.ShowLock = value;

        imgbLockStatus.Visible = showLock;
      }
    }

    #endregion

    public FieldControl()
    {
      InitializeComponent();
      SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint | ControlStyles.DoubleBuffer, true);

#if DEBUG
      LockReason = "[loaded from XML]";
      errorText = "Kaaaaaaaaboom.";
      ReadOnly = false;
      Dirty = false;
      ShowLock = false;
      Error = ErrorLevel.None;
#endif
    }

    #region Methods

    #region Field State Methods

    #region Lock

    protected override void SetLock()
    {
      panelContainer.Enabled = !locked;

      if (locked)
      {
        imgbLockStatus.Image = global::Interfaces.Properties.Resources.lock_open16;
        stFieldControl.SetSuperTooltip(imgbLockStatus, new SuperTooltipInfo(
          "Unlock " + title,
          String.Empty,
          "Unlock <b>" + title + "</b> so that it may be edited.<br /><br />Note that unlocking and modifying fields is intended for <i>advanced users only.</i> Any uncertainty about a field's functionality means that it <b>should not</b> be unlocked."
          + ((!String.IsNullOrEmpty(lockReason)) ? "<br /><br /><b>Reason for Lock</b><br />" + lockReason : String.Empty), null, null, eTooltipColor.Red));
      }
      else
      {
        imgbLockStatus.Image = global::Interfaces.Properties.Resources.lock16;
        stFieldControl.SetSuperTooltip(imgbLockStatus, new SuperTooltipInfo(
          "Lock " + title,
          String.Empty,
          "Lock <b>" + title + "</b> so that it may not be edited.", null, null, eTooltipColor.Green));
      }

      SetColor();
    }

    #endregion

    #region Dirty

    protected override void SetDirty()
    {
      if (Convert.ToBoolean(error)) return;

      if (showLock) imgbLockStatus.Visible = !dirty; // Dirty status has priority over Lock status; if a user has modified a locked field, they have to save or revert before they can re-lock it.
      imgbRevertChanges.Visible = dirty;

      if (dirty)
      {
        stFieldControl.SetSuperTooltip(imgbRevertChanges, new SuperTooltipInfo(
          "Revert to Original Value",
          String.Empty,
          "Revert <font color=\"DarkBlue\"><b>" + title + "</b></font> to its original value.<br /><br />This will reset all changes made to the field back to their original values when the tag was loaded or last saved."
          + ((Tag != null) ? "<br /><br /><b>Original Value</b><br />" + this.ToString(true, true) : String.Empty) + ((locked) ? "<br /><br />Note that you will be able to lock this field again once it has been reverted or the tag has been saved." : String.Empty), null, null, eTooltipColor.Blue));
      }

      SetColor();
    }

    #endregion

    #region Error

    protected override void SetError()
    {
      if (readOnly) return;

      if (showLock) imgbLockStatus.Visible = !Convert.ToBoolean(error); // Error status has priority over Lock status; the error must be resolved before the field can be re-locked.
      if (dirty) imgbRevertChanges.Visible = !Convert.ToBoolean(error); // Error status has priority over Dirty status; the error button doubles as a revert button (clear button when there is nothing to revert to).
      imgbError.Visible = Convert.ToBoolean(error);

      if (Error == ErrorLevel.Warning)
      {
        imgbError.Image = global::Interfaces.Properties.Resources.warning16;

        stFieldControl.SetSuperTooltip(imgbError, new SuperTooltipInfo(
          "<img src=\"global::Games.Halo.Properties.Resources.warning16\" /><span padding=\"0,0,2,0\">&nbsp;<font color=\"darkgoldenrod\"><b>Warning</b></font></span>",
          String.Empty,
          "Potentially incorrect data has been entered.<br /><br />Click this button to resolve the error by " + ((dirty) ? "reverting to the original value." : " clearing the value.")
          + "<br /><br />Action is not required, but is recommended. Note that any anomalous behavior in-game may be a direct result of improper values in this field."
          + ((!String.IsNullOrEmpty(errorText)) ? "<br /><br /><font color=\"darkgoldenrod\"><b>Reported Concern</b></font><br />" + errorText : String.Empty), null, null, eTooltipColor.Yellow));
      }
      else if(Error == ErrorLevel.Error)
      {
        imgbError.Image = global::Interfaces.Properties.Resources.error16;

        stFieldControl.SetSuperTooltip(imgbError, new SuperTooltipInfo(
          "<img src=\"global::Games.Halo.Properties.Resources.error16\" /><span padding=\"0,0,2,0\">&nbsp;<font color=\"darkred\"><b>Error</b></font></span>",
          String.Empty,
          "An error has occurred with data entry that prevents project compilation.<br /><br />Click this button to resolve the error by " + ((dirty) ? "reverting to the original value." : " clearing the value.")
          + "<br /><br />While tags can be saved with errors, all errors must be resolved prior to successful project compilation."
          + ((!String.IsNullOrEmpty(errorText)) ? "<br /><br /><font color=\"darkred\"><b>Reported Error</b></font><br />" + errorText : String.Empty), null, null, eTooltipColor.Red));
      }

      SetColor();
    }

    #endregion

    private void SetColor()
    {
      if (imgbError.Visible && Convert.ToBoolean(error))
        lblTitle.ForeColor = Color.DarkRed;
      else if (imgbRevertChanges.Visible && dirty)
        lblTitle.ForeColor = Color.Blue;
      else if (imgbLockStatus.Visible && locked)
        lblTitle.ForeColor = Color.SaddleBrown;
      else
        lblTitle.ForeColor = Color.Black;
    }

    #endregion

    #region Input Processing Methods

    private bool controlKeyDown;
    protected void KeyDownProcessor(KeyEventArgs ke)
    {
      controlKeyDown = ke.Control;
    }

    protected void NumericInputProcessor(object sender, KeyPressEventArgs kpe, bool allowNegativeNumbers, bool allowDecimals)
    {
      if (controlKeyDown) // User is probably doing a command sequence; do not filter their keys.
        return;

      if (!(sender is TextBoxX))
      {
#if DEBUG
        MessageBox.Show("Hey stupid, this method is intended for TextBoxX controls only!");
#endif
        return;
      }

      char key = kpe.KeyChar;
      TextBoxX control = (TextBoxX)sender;

      if (!Char.IsDigit(key) && !(key == (char)Keys.Back) && !(key == '.') && !(key == '-') && !(key == (char)Keys.Enter))
      {
        // If the key is not a digit (0-9), backspace key, enter key, or period, ignore it.
        kpe.Handled = true;
      }
      else if (key == (char)Keys.Enter)
      {
        TagEditor.SelectNextControl(control, true, true, true, true);
        kpe.Handled = true;
      }
      else if (Char.IsDigit(key))
      {
        // Ensure all numbers are added after the negative sign if it exists.
        if (control.SelectionStart == 0) // If the cursor is at the front of the TextBox ...
          if (control.Text.Contains("-")) // And the current value is negative ...
            if (!control.SelectedText.Contains("-")) // And the user will NOT overwrite the negative sign with this keystroke ...
              kpe.Handled = true; // Do not add the key to TextBox.
      }
      else if (key == '.')
      {
        if (!allowDecimals)
        {
          kpe.Handled = true;
          return;
        }

        // Ensure only one decimal exists in the value and it is in an allowed location.
        if (control.Text.Contains(".")) // If the value currently has a decimal ...
        {
          if (!control.SelectedText.Contains(".")) // And the user will NOT overwrite the existing decimal with this keystroke ...
            kpe.Handled = true; // Do not add the decimal to TextBox.
        }
        else // The value does not currently contain a decimal, one is being added.
        {
          // Ensure decimals are only placed after the negative sign.
          if (control.SelectionStart == 0) // If the cursor is at the front of the TextBox ...
            if (control.Text.Contains("-")) // And the current value is negative ...
              if (!control.SelectedText.Contains("-")) // And the user will NOT overwrite the negative sign with this keystroke ...
                kpe.Handled = true; // Do not add the decimal to TextBox.
        }
      }
      else if (key == '-')
      {
        if (!allowNegativeNumbers)
        {
          kpe.Handled = true;
          return;
        }

        // Ensure all numbers are added after the negative sign if it exists.
        if (control.SelectionStart != 0 || control.Text.Contains("-")) // If the cursor is NOT at the front of the TextBox OR if the current value is negative ...
          if (!control.SelectedText.Contains("-")) // And the user will NOT overwrite the negative sign with this keystroke ...
            kpe.Handled = true; // Do not add the key to TextBox.
      }
    }

    #endregion

    #endregion

    #region Event Handlers

    private void imgbLockStatus_Click(object sender, EventArgs e)
    {
      Locked = !Locked;
    }

    private void imgbRevertChanges_Click(object sender, EventArgs e)
    {
      Dirty = !RevertChanges(); // If the method succeeded, Dirty is set to false.
    }

    private void imgbError_Click(object sender, EventArgs e)
    {
      bool result = (!RevertChanges() ? HandleError() : true); // Try RevertChanges() first, if that doesn't work then run HandleError().

      Error = (ErrorLevel)Convert.ToInt32(!result); // If the method succeeded, Error is set to false.
      Dirty = !result; // If the method succeeded, Dirty is set to false.
    }

    private void imageButton_VisibleChanged(object sender, EventArgs e)
    {
      if (imgbLockStatus.Visible || imgbRevertChanges.Visible || imgbError.Visible)
      {
        lblTitle.Location = new Point(18, 5);
        lblTitle.Width = 112;
      }
      else
      {
        lblTitle.Location = new Point(2, 5);
        lblTitle.Width = 128;
      }
    }

    #endregion
  }
}