using System;
using System.Windows.Forms;
using Interfaces.Factory;
using Interfaces.TagEditor;
using DevComponents.DotNetBar.Controls;

namespace Games.Halo.Controls
{
  public partial class ARGBColor : FieldControl
  {
    private Tags.Fields.ARGBColor value
    {
      get { return (Tags.Fields.ARGBColor)BaseValue; }
    }

    public ARGBColor()
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

      if (ValueInRange(txtbx.Text, false) == 0) // Value is in range if 0.
      {
        short r = (String.IsNullOrEmpty(txtbxR.Text) ? (short)0 : Convert.ToInt16(txtbxR.Text)),
              g = (String.IsNullOrEmpty(txtbxG.Text) ? (short)0 : Convert.ToInt16(txtbxG.Text)),
              b = (String.IsNullOrEmpty(txtbxB.Text) ? (short)0 : Convert.ToInt16(txtbxB.Text));

        updatingText = true;
        cpbColor.SelectedColor = System.Drawing.Color.FromArgb(r, g, b);
        updatingText = false;
      }
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

      return true;
    }

    public override string ToString(bool withMarkup, bool originalValue)
    {
      Tags.Fields.ARGBColor oldValue = (Tags.Fields.ARGBColor)Tag;

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