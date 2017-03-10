using System.Windows.Forms;
using Interfaces.Factory;
using Interfaces.TagEditor;

namespace Games.Halo.Controls
{
  public partial class RealPlane2D : FieldControl
  {
    private Tags.Fields.RealPlane2D value;

    public RealPlane2D()
    {
      InitializeComponent();
    }

    public override bool BindSupported(IField field)
    {
      return (value.GetType() == field.GetType());
    }
    
    public override void DataBind(IField value)
    {
      this.value = value as Tags.Fields.RealPlane2D;
      
      txtI.DataBindings.Clear();
      txtJ.DataBindings.Clear();
      txtD.DataBindings.Clear();

      txtI.DataBindings.Add(new Binding("Text", this.value, "I"));
      txtJ.DataBindings.Add(new Binding("Text", this.value, "J"));
      txtD.DataBindings.Add(new Binding("Text", this.value, "D"));
    }
  }
}