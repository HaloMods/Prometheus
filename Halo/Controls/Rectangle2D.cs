using System.Windows.Forms;
using Interfaces.Factory;
using Interfaces.TagEditor;

namespace Games.Halo.Controls
{
  public partial class Rectangle2D : FieldControl
  {
    private Tags.Fields.Rectangle2D value;

    public Rectangle2D()
    {
      InitializeComponent();
    }

    public override bool BindSupported(IField field)
    {
      return (value.GetType() == field.GetType());
    }
    
    public override void DataBind(IField value)
    {
      this.value = value as Tags.Fields.Rectangle2D;
      
      txtT.DataBindings.Clear();
      txtB.DataBindings.Clear();
      txtR.DataBindings.Clear();
      txtL.DataBindings.Clear();

      txtT.DataBindings.Add(new Binding("Text", this.value, "T"));
      txtB.DataBindings.Add(new Binding("Text", this.value, "B"));
      txtR.DataBindings.Add(new Binding("Text", this.value, "R"));
      txtL.DataBindings.Add(new Binding("Text", this.value, "L"));
    }
  }
}