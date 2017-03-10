using System.Windows.Forms;
using Interfaces.Factory;
using Interfaces.TagEditor;

namespace Games.Halo.Controls
{
  public partial class RealQuaternion : FieldControl
  {
    private Tags.Fields.RealQuaternion value;

    public RealQuaternion()
    {
      InitializeComponent();
    }

    public override bool BindSupported(IField field)
    {
      return (value.GetType() == field.GetType());
    }
    
    public override void DataBind(IField value)
    {
      this.value = value as Tags.Fields.RealQuaternion;
      
      txtI.DataBindings.Clear();
      txtJ.DataBindings.Clear();
      txtK.DataBindings.Clear();
      txtW.DataBindings.Clear();

      txtI.DataBindings.Add(new Binding("Text", this.value, "I"));
      txtJ.DataBindings.Add(new Binding("Text", this.value, "J"));
      txtK.DataBindings.Add(new Binding("Text", this.value, "K"));
      txtW.DataBindings.Add(new Binding("Text", this.value, "W"));
    }
  }
}