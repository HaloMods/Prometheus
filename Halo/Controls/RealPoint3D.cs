using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using DevComponents.DotNetBar.Controls;
using Interfaces.Factory;
using Interfaces.TagEditor;

namespace Games.Halo.Controls
{
  public partial class RealPoint3D : FieldControl
  {
    private Tags.Fields.RealPoint3D value;

    public RealPoint3D()
    {
      InitializeComponent();
      txtbxXAxis.Validated += delegate { value.X = Convert.ToSingle(txtbxXAxis.Text); };
      txtbxYAxis.Validated += delegate { value.Y = Convert.ToSingle(txtbxYAxis.Text); };
      txtbxZAxis.Validated += delegate { value.Z = Convert.ToSingle(txtbxZAxis.Text); };
    }

    public override bool BindSupported(IField field)
    {
      return (value.GetType() == field.GetType());
    }

    public override void DataBind(IField value)
    {
      this.value = value as Tags.Fields.RealPoint3D;
      this.value.PropertyChanged += new PropertyChangedEventHandler(value_PropertyChanged);
      UpdateProperties("X", "Y", "Z");
    }

    private void value_PropertyChanged(object sender, PropertyChangedEventArgs e)
    {
      UpdateProperties(e.PropertyName);
    }

    private void UpdateProperties(params string[] propertyNames)
    {
      if (InvokeRequired)
        Invoke((MethodInvoker)delegate { UpdateProperties(propertyNames); });
      else
      {
        foreach (string propertyName in propertyNames)
        {
          if (propertyName == "X")
            txtbxXAxis.Text = value.X.ToString();
          else if (propertyName == "Y")
            txtbxYAxis.Text = value.Y.ToString();
          else if (propertyName == "Z")
            txtbxZAxis.Text = value.Z.ToString();
        }
      }
    }

    #region Input Validation

    private bool controlDown; // Always set by KeyDown event.

    private void txtbXYZ_KeyDown(object sender, KeyEventArgs e)
    {
      controlDown = e.Control;
    }

    private void txtbXYZ_KeyPress(object sender, KeyPressEventArgs e)
    {
      if (controlDown) // User is probably doing a command sequence; do not filter their keys.
        return;

      char key = e.KeyChar;
      TextBoxX control = (TextBoxX)sender;

      if (!Char.IsDigit(key) && !(key == (char) Keys.Back) && !(key == '.') && !(key == '-'))
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
      else if (key == '.')
      {
        // If there is already one period, do not allow another.
        if (control.Text.Contains("."))
          e.Handled = true;
          // If the user tries to put a period before the - sign, stop them.
        else if ((control.SelectionStart == 0) && control.Text.Contains("-"))
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

    private void txtbXYZ_TextChanged(object sender, EventArgs e)
    {
      TextBoxX control = (TextBoxX) sender;

      if (control.Text.Contains("-"))
        control.ForeColor = Color.Red;
      else
        control.ForeColor = Color.DarkBlue;
    }
  }
}