using System.Windows.Forms;
using Interfaces.Factory;
using Interfaces.TagEditor;

namespace Games.Halo.Controls
{
  public partial class RealVector2D : FieldControl
  {
    private Tags.Fields.RealVector2D value;

    public RealVector2D()
    {
      InitializeComponent();
    }

    public override bool BindSupported(IField field)
    {
      return (value.GetType() == field.GetType());
    }
    
    public override void DataBind(IField value)
    {
      this.value = value as Tags.Fields.RealVector2D;
      
      txtIValue.DataBindings.Clear();
      txtJValue.DataBindings.Clear();

      txtIValue.DataBindings.Add(new Binding("Text", this.value, "I"));
      txtJValue.DataBindings.Add(new Binding("Text", this.value, "K"));
    }
  }
}