using System;
using System.Windows.Forms;
using Interfaces.Factory;
using Interfaces.TagEditor;
using DevComponents.DotNetBar.Controls;

namespace Games.Halo.Controls
{
  public partial class RealARGBColor : FieldControl
  {
    private bool errorA, errorR, errorG, errorB;

    private Tags.Fields.RealARGBColor value
    {
      get { return (Tags.Fields.RealARGBColor)BaseValue; }
    }

    public RealARGBColor()
    {
      InitializeComponent();
      Range = new FieldRange(0, 255);
      StrictRange = true;
    }

    public override bool BindSupported(IField field)
    {
      return (value.GetType() == field.GetType());
    }
    
    public override void DataBind(IField value)
    {
      base.DataBind(value);

      txtbxA.DataBindings.Clear();
      txtbxR.DataBindings.Clear();
      txtbxG.DataBindings.Clear();
      txtbxB.DataBindings.Clear();

      txtbxA.DataBindings.Add(new Binding("Text", this.value, "A"));
      txtbxR.DataBindings.Add(new Binding("Text", this.value, "R"));
      txtbxG.DataBindings.Add(new Binding("Text", this.value, "G"));
      txtbxB.DataBindings.Add(new Binding("Text", this.value, "B"));
    }

    #region Input Validation

    private void txtbx_KeyDown(object sender, KeyEventArgs e)
    {
      KeyDownProcessor(e);
    }

    private void txtbx_KeyPress(object sender, KeyPressEventArgs e)
    {
      NumericInputProcessor(sender, e, false, false);
    }

    #endregion

    protected override void SetError()
    {
      if (!errorA && !errorR && !errorG && !errorB) // All values are in range.
        error = ErrorLevel.None;
      else
        error = (strictRange ? ErrorLevel.Error : ErrorLevel.Warning);

      base.SetError();
    }

    bool updatingColor;
    private void cpbColor_SelectedColorChanged(object sender, System.EventArgs e)
    {
      if (updatingText) return;

      updatingColor = true;
      value.A = cpbColor.SelectedColor.A;
      value.R = cpbColor.SelectedColor.R;
      value.G = cpbColor.SelectedColor.G;
      value.B = cpbColor.SelectedColor.B;
      updatingColor = false;
    }

    bool updatingText;
    private void txtbx_TextChanged(object sender, System.EventArgs e)
    {
      TextBoxX txtbx = (TextBoxX)sender;

      if (updatingColor || handlingError) return;

      if (String.IsNullOrEmpty(txtbx.Text))
      {
        txtbx.Text = "0";
        return;
      }

      if (txtbx.Text == "0")
        txtbx.SelectAll();

      errorA = !(ValueInRange(txtbxA.Text, false) == 0);
      errorR = !(ValueInRange(txtbxR.Text, false) == 0);
      errorG = !(ValueInRange(txtbxG.Text, false) == 0);
      errorB = !(ValueInRange(txtbxB.Text, false) == 0);

      SetError(); // Forces error status evaluation since errorB will always be what it previously was until after ValueInRange() (and thus the last SetError() call) has finished excuting.

      if (Convert.ToBoolean(Error)) return; // If there is something wrong with any of the values, we cannot proceed.

      // The colors range between 0.0-1.0 --- we need to convert them to their RGB components.
      short r = Convert.ToInt16(Convert.ToSingle(txtbxR.Text) * 255f),
            g = Convert.ToInt16(Convert.ToSingle(txtbxG.Text) * 255f),
            b = Convert.ToInt16(Convert.ToSingle(txtbxB.Text) * 255f);

      updatingText = true;
      cpbColor.SelectedColor = System.Drawing.Color.FromArgb(r, g, b);
      updatingText = false;
    }

    bool handlingError;
    protected override bool HandleError()
    {
      handlingError = true;
      value.A = 0;
      value.R = 0;
      value.G = 0;
      value.B = 0;
      handlingError = false;

      errorA = errorR = errorG = errorB = false;

      return true;
    }

    public override string ToString(bool withMarkup, bool originalValue)
    {
      Tags.Fields.RealARGBColor oldValue = (Tags.Fields.RealARGBColor)Tag;

      if (oldValue == null)
        oldValue = value;

      if (withMarkup)
      {
        return "<span width=\"15\"><b>A:</b></span>" + (originalValue ? oldValue.A.ToString() : value.A.ToString()) + "<br />" +
               "<span width=\"15\"><b>R:</b></span>" + (originalValue ? oldValue.R.ToString() : value.R.ToString()) + "<br />" +
               "<span width=\"15\"><b>G:</b></span>" + (originalValue ? oldValue.G.ToString() : value.G.ToString()) + "<br />" +
               "<span width=\"15\"><b>B:</b></span>" + (originalValue ? oldValue.B.ToString() : value.B.ToString());
      }
      else
      {
        return "A: " + (originalValue ? oldValue.A.ToString() : value.A.ToString()) + "\n" +
               "R: " + (originalValue ? oldValue.R.ToString() : value.R.ToString()) + "\n" +
               "G: " + (originalValue ? oldValue.G.ToString() : value.G.ToString()) + "\n" +
               "B: " + (originalValue ? oldValue.B.ToString() : value.B.ToString());
      }
    }

    protected override void SetReadOnly()
    {
      if (cpbColor == null)
        return;

      if (Locked)
        return;

      cpbColor.Enabled = !ReadOnly;
    }
  }
}