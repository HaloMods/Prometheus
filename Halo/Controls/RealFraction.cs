using System.Windows.Forms;
using Interfaces.Factory;
using Interfaces.TagEditor;

namespace Games.Halo.Controls
{
  public partial class RealFraction : FieldControl
  {
    private Tags.Fields.RealFraction value;

    public RealFraction()
    {
      InitializeComponent();
    }

    public override bool BindSupported(IField field)
    {
      return (value.GetType() == field.GetType());
    }
    
    public override void DataBind(IField value)
    {
      this.value = value as Tags.Fields.RealFraction;
      txtValue.DataBindings.Clear();
      txtValue.DataBindings.Add(new Binding("Text", this.value, "Value"));
    }
  }
}