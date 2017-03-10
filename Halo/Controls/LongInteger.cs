using System;
using System.Drawing;
using System.Windows.Forms;
using Interfaces.Factory;
using Interfaces.TagEditor;

namespace Games.Halo.Controls
{
  public partial class LongInteger : FieldControl
  {
    private Tags.Fields.LongInteger value;

    public LongInteger()
    {
      InitializeComponent();
    }

    public override bool BindSupported(IField field)
    {
      return (value.GetType() == field.GetType());
    }
    
    public override void DataBind(IField value)
    {
      this.value = value as Tags.Fields.LongInteger;
      txtbxLongInt.DataBindings.Clear();
      txtbxLongInt.DataBindings.Add(new Binding("Text", this.value, "Value"));
    }

    #region Input Validation

    private bool controlDown; // Always set by KeyDown event.

    private void txtbxLongInt_KeyDown(object sender, KeyEventArgs e)
    {
      controlDown = e.Control;
    }

    private void txtbxLongInt_KeyPress(object sender, KeyPressEventArgs e)
    {
      if (controlDown) // User is probably doing a command sequence; do not filter their keys.
        return;

      char key = e.KeyChar;
      DevComponents.DotNetBar.Controls.TextBoxX control = (sender as DevComponents.DotNetBar.Controls.TextBoxX);

      if (!System.Char.IsDigit(key) && !(key == (char)Keys.Back) && !(key == '-'))
      {
        // If the key is not a digit (0-9), backspace key, or period, ignore it.
        e.Handled = true;
      }
      else if (Char.IsDigit(key))
      {
        if ((control.SelectionStart == 0) && control.Text.Contains("-"))
          if (!(control.SelectionLength > 0))
            e.Handled = true;
      }
      else if (key == '-')
      {
        // If the user tries to put a - sign anywhere except the beginning, stop them.
        if (!(control.SelectionStart == 0) || control.Text.Contains("-"))
          if (!(control.SelectionLength > 0))
            e.Handled = true;
      }
    }

    #endregion

    private void txtbxLongInt_TextChanged(object sender, System.EventArgs e)
    {
      DevComponents.DotNetBar.Controls.TextBoxX control = (sender as DevComponents.DotNetBar.Controls.TextBoxX);

      if (control.Text.Contains("-"))
        control.ForeColor = Color.Red;
      else
        control.ForeColor = Color.DarkBlue;
    }
  }
}