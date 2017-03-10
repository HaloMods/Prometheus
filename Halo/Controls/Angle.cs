using System;
using System.Drawing;
using System.Windows.Forms;
using Interfaces.Factory;
using Interfaces.TagEditor;

namespace Games.Halo.Controls
{
  public partial class Angle : FieldControl
  {
    private Tags.Fields.Angle value
    {
      get { return (Tags.Fields.Angle)BaseValue; }
    }
    
    public Angle()
    {
      InitializeComponent();
      Range = new FieldRange(-360, 360);
      StrictRange = true;
    }

    public override bool BindSupported(IField field)
    {
      return (value.GetType() == field.GetType());
    }
    
    public override void DataBind(IField value)
    {
      base.DataBind(value);

      txtbxAngle.DataBindings.Clear();
      txtbxAngle.DataBindings.Add(new Binding("Text", this.value, "Value"));
    }

    #region Input Validation

    private void txtbxAngle_KeyDown(object sender, KeyEventArgs e)
    {
      KeyDownProcessor(e);
    }

    private void txtbxAngle_KeyPress(object sender, KeyPressEventArgs e)
    {
      NumericInputProcessor(sender, e, true, true);
    }

    #endregion

    private void txtbxAngle_TextChanged(object sender, System.EventArgs e)
    {
      // Keep it grammatical, mmm.
      if (txtbxAngle.Text.Equals("1"))
        lblDegrees.Text = "degree";
      else
        lblDegrees.Text = "degrees";

      Interfaces.Helpers.Strings.ColorizeNumericTextBoxX((DevComponents.DotNetBar.Controls.TextBoxX)sender);
      ValueInRange(((DevComponents.DotNetBar.Controls.TextBoxX)sender).Text);
    }

    protected override bool HandleError()
    {
      txtbxAngle.Text = "0";
      return true;
    }

    public override string ToString(bool withMarkup, bool originalValue)
    {
      Tags.Fields.Angle oldValue = (Tags.Fields.Angle)Tag;

      if (oldValue == null)
        oldValue = value;

      if (withMarkup)
        return Interfaces.Helpers.Strings.CreateColorizedNumericString((originalValue ? oldValue.Value : value.Value) + "º", true);
      else
        return (originalValue ? oldValue.ToString() : value.ToString()) + "º";
    }

    #region Degree / Radian Converters

    private float DegreesToRadians(float degrees)
    { return (float)((degrees / 360) * (Math.PI * 2)); }

    private float RadianstoDegrees(float radians)
    { return (float)(radians / (Math.PI * 2) * 360); }

    #endregion
  }
}