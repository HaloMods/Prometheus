using System;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;
using DevComponents.DotNetBar.Controls;
using Interfaces.Factory;
using Interfaces.TagEditor;

namespace Games.Halo.Controls
{
  public partial class Real : FieldControl
  {
    private Tags.Fields.Real value
    {
      get { return (Tags.Fields.Real)BaseValue; }
    }
    
    public Real()
    {
      InitializeComponent();
    }
    
    public override void DataBind(IField value)
    {
      base.DataBind(value);

      txtbReal.DataBindings.Clear();
      txtbReal.DataBindings.Add(new Binding("Text", this.value, "Value"));
    }

    #region Input Validation

    private void txtbReal_KeyDown(object sender, KeyEventArgs e)
    {
      KeyDownProcessor(e);
    }

    private void txtbReal_KeyPress(object sender, KeyPressEventArgs e)
    {
      NumericInputProcessor(sender, e, true, true);
    }

    #endregion

    private void txtbReal_TextChanged(object sender, System.EventArgs e)
    {
      Interfaces.Helpers.Strings.ColorizeNumericTextBoxX((DevComponents.DotNetBar.Controls.TextBoxX)sender);
    }

    protected override bool HandleError()
    {
      txtbReal.Text = "0";
      return true;
    }

    public override string ToString(bool withMarkup, bool originalValue)
    {
      Tags.Fields.Real oldValue = (Tags.Fields.Real)Tag;

      if (oldValue == null)
        oldValue = value;

      if (withMarkup)
        return Interfaces.Helpers.Strings.CreateColorizedNumericString((originalValue ? oldValue.Value : value.Value), true);
      else
        return (originalValue ? oldValue.ToString() : value.ToString());
    }
  }
}