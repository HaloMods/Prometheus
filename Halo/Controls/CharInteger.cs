using System;
using System.Drawing;
using System.Windows.Forms;
using Interfaces.Factory;
using Interfaces.TagEditor;

namespace Games.Halo.Controls
{
  public partial class CharInteger : FieldControl
  {
    private Tags.Fields.CharInteger value
    {
      get { return (Tags.Fields.CharInteger)BaseValue; }
    }

    public CharInteger()
    {
      InitializeComponent();
    }

    public override void DataBind(IField value)
    {
      base.DataBind(value);

      txtbxCharInt.DataBindings.Clear();
      txtbxCharInt.DataBindings.Add(new Binding("Text", this.value, "Value"));
    }

    #region Input Validation

    private void txtbxCharInt_KeyDown(object sender, KeyEventArgs e)
    {
      KeyDownProcessor(e);
    }

    private void txtbxCharInt_KeyPress(object sender, KeyPressEventArgs e)
    {
      NumericInputProcessor(sender, e, true, false);
    }

    #endregion

    private void txtbxCharInt_TextChanged(object sender, System.EventArgs e)
    {
      Interfaces.Helpers.Strings.ColorizeNumericTextBoxX((DevComponents.DotNetBar.Controls.TextBoxX)sender);
    }

    protected override bool HandleError()
    {
      txtbxCharInt.Text = "0";
      return true;
    }

    public override string ToString(bool withMarkup, bool originalValue)
    {
      Tags.Fields.CharInteger oldValue = (Tags.Fields.CharInteger)Tag;

      if (oldValue == null)
        oldValue = value;

      if (withMarkup)
        return Interfaces.Helpers.Strings.CreateColorizedNumericString((originalValue ? oldValue.Value : value.Value), true);
      else
        return (originalValue ? oldValue.ToString() : value.ToString());
    }
  }
}