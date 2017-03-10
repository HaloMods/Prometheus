using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Interfaces.Factory;
using Interfaces.TagEditor;

namespace Games.Halo.Controls
{
  public partial class RealEulerAngles3D : FieldControl
  {
    private Tags.Fields.RealEulerAngles3D value;

    public RealEulerAngles3D()
    {
      InitializeComponent();
      txtbxYaw.Validated += delegate { value.Yaw = Convert.ToSingle(txtbxYaw.Text); };
      txtbxPitch.Validated += delegate { value.Pitch = Convert.ToSingle(txtbxPitch.Text); };
      txtbxRoll.Validated += delegate { value.Roll = Convert.ToSingle(txtbxRoll.Text); };
    }

    public override bool BindSupported(IField field)
    {
      return (value.GetType() == field.GetType());
    }
    
    public override void DataBind(IField value)
    {
      this.value = value as Tags.Fields.RealEulerAngles3D;
      this.value.PropertyChanged += new PropertyChangedEventHandler(value_PropertyChanged);
      UpdateProperties("Yaw", "Pitch", "Roll");
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
          if (propertyName == "Yaw")
            txtbxYaw.Text = value.Yaw.ToString();
          else if (propertyName == "Pitch")
            txtbxPitch.Text = value.Pitch.ToString();
          else if (propertyName == "Roll")
            txtbxRoll.Text = value.Roll.ToString();
        }
      }
    }

    #region Input Validation

    private bool controlDown; // Always set by KeyDown event.

    private void txtbYPR_KeyDown(object sender, KeyEventArgs e)
    {
      controlDown = e.Control;
    }

    private void txtbYPR_KeyPress(object sender, KeyPressEventArgs e)
    {
      if (controlDown) // User is probably doing a command sequence; do not filter their keys.
        return;

      char key = e.KeyChar;
      DevComponents.DotNetBar.Controls.TextBoxX control = (sender as DevComponents.DotNetBar.Controls.TextBoxX);

      if (!Char.IsDigit(key) && !(key == (char)Keys.Back) && !(key == '.') && !(key == '-'))
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

    private void txtbYPR_TextChanged(object sender, System.EventArgs e)
    {
      DevComponents.DotNetBar.Controls.TextBoxX control = (sender as DevComponents.DotNetBar.Controls.TextBoxX);

      if (control.Text.Contains("-"))
        control.ForeColor = Color.Red;
      else
        control.ForeColor = Color.DarkBlue;
    }
  }
}