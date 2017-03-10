using System;
using System.Drawing;
using System.Windows.Forms;
using Interfaces;
using Interfaces.Factory;
using Interfaces.TagEditor;

namespace Games.Halo.Controls
{
  public partial class ShortInteger : FieldControl
  {
    private Tags.Fields.ShortInteger value
    {
      get { return (Tags.Fields.ShortInteger)BaseValue; }
    }

    public ShortInteger()
    {
      InitializeComponent();
    }

    public override bool BindSupported(IField field)
    {
      return (value.GetType() == field.GetType());
    }
    
    public override void DataBind(IField value)
    {
      if (value is Tags.Fields.ShortInteger)
      {
        base.DataBind(value);

        txtbxShortInt.DataBindings.Clear();
        txtbxShortInt.DataBindings.Add(new Binding("Text", this.value, "Value"));
      }
      else
      {
        Output.Write(OutputTypes.Error, "Error databinding to ShortInteger '" + Name + "' - supplied value was of type " + value.GetType().ToString());
      }
    }

    #region Input Validation

    private void txtbxShortInt_KeyDown(object sender, KeyEventArgs e)
    {
      KeyDownProcessor(e);
    }

    private void txtbxShortInt_KeyPress(object sender, KeyPressEventArgs e)
    {
      NumericInputProcessor(sender, e, true, false);
    }

    #endregion

    private void txtbxShortInt_TextChanged(object sender, System.EventArgs e)
    {
      Interfaces.Helpers.Strings.ColorizeNumericTextBoxX((DevComponents.DotNetBar.Controls.TextBoxX)sender);
    }

    protected override bool HandleError()
    {
      txtbxShortInt.Text = "0";
      return true;
    }

    public override string ToString(bool withMarkup, bool originalValue)
    {
      Tags.Fields.ShortInteger oldValue = (Tags.Fields.ShortInteger)Tag;

      if (oldValue == null)
        oldValue = value;

      if (withMarkup)
        return Interfaces.Helpers.Strings.CreateColorizedNumericString((originalValue ? oldValue.Value : value.Value), true);
      else
        return (originalValue ? oldValue.ToString() : value.ToString());
    }
  }
}