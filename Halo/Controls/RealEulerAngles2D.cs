using System.Windows.Forms;
using Interfaces.Factory;
using Interfaces.TagEditor;

namespace Games.Halo.Controls
{
  public partial class RealEulerAngles2D : FieldControl
  {
    private Tags.Fields.RealEulerAngles2D value;

    public RealEulerAngles2D()
    {
      InitializeComponent();
    }

    public override bool BindSupported(IField field)
    {
      return (value.GetType() == field.GetType());
    }
    
    public override void DataBind(IField value)
    {
      this.value = value as Tags.Fields.RealEulerAngles2D;
      
      txtYaw.DataBindings.Clear();
      txtPitch.DataBindings.Clear();

      txtYaw.DataBindings.Add(new Binding("Text", this.value, "Y"));
      txtPitch.DataBindings.Add(new Binding("Text", this.value, "P"));
    }
  }
}