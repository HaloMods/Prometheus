using System.Windows.Forms;
using Interfaces.Factory;
using Interfaces.TagEditor;

namespace Games.Halo.Controls
{
  public partial class RealPlane3D : FieldControl
  {
    private Tags.Fields.RealPlane3D value;

    public RealPlane3D()
    {
      InitializeComponent();
    }

    public override bool BindSupported(IField field)
    {
      return (value.GetType() == field.GetType());
    }
    
    public override void DataBind(IField value)
    {
      this.value = value as Tags.Fields.RealPlane3D;
      
      txtI.DataBindings.Clear();
      txtJ.DataBindings.Clear();
      txtK.DataBindings.Clear();
      txtD.DataBindings.Clear();

      txtI.DataBindings.Add(new Binding("Text", this.value, "I"));
      txtJ.DataBindings.Add(new Binding("Text", this.value, "J"));
      txtK.DataBindings.Add(new Binding("Text", this.value, "K"));
      txtD.DataBindings.Add(new Binding("Text", this.value, "D"));
    }
  }
}