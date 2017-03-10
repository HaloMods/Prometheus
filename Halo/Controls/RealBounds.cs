using System.Windows.Forms;
using Interfaces.Factory;
using Interfaces.TagEditor;

namespace Games.Halo.Controls
{
  public partial class RealBounds : FieldControl
  {
    private Tags.Fields.RealBounds value;

    public RealBounds()
    {
      InitializeComponent();
    }

    public override bool BindSupported(IField field)
    {
      return (value.GetType() == field.GetType());
    }
    
    public override void DataBind(IField value)
    {
      this.value = value as Tags.Fields.RealBounds;
      
      txtLower.DataBindings.Clear();
      txtUpper.DataBindings.Clear();

      txtLower.DataBindings.Add(new Binding("Text", this.value, "Lower"));
      txtUpper.DataBindings.Add(new Binding("Text", this.value, "Upper"));
    }
  }
}