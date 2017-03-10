using System.Windows.Forms;
using Interfaces.Factory;
using Interfaces.TagEditor;

namespace Games.Halo.Controls
{
  public partial class RGBColor : FieldControl
  {
    private Tags.Fields.RGBColor value;

    public RGBColor()
    {
      InitializeComponent();
    }

    public override bool BindSupported(IField field)
    {
      return (value.GetType() == field.GetType());
    }
    
    public override void DataBind(IField value)
    {
      this.value = value as Tags.Fields.RGBColor;
      
      txtRed.DataBindings.Clear();
      txtGreen.DataBindings.Clear();
      txtBlue.DataBindings.Clear();

      txtRed.DataBindings.Add(new Binding("Text", this.value, "R"));
      txtGreen.DataBindings.Add(new Binding("Text", this.value, "G"));
      txtBlue.DataBindings.Add(new Binding("Text", this.value, "B"));
    }
  }
}