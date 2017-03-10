using System.Windows.Forms;
using Interfaces.Factory;
using Interfaces.TagEditor;

namespace Games.Halo.Controls
{
  public partial class LongBlockIndex : FieldControl
  {
    private Tags.Fields.LongBlockIndex value;

    public LongBlockIndex()
    {
      InitializeComponent();
    }

    public override bool BindSupported(IField field)
    {
      return (value.GetType() == field.GetType());
    }
    
    public override void DataBind(IField value)
    {
      this.value = value as Tags.Fields.LongBlockIndex;
      txtValue.DataBindings.Clear();
      txtValue.DataBindings.Add(new Binding("Text", this.value, "Value"));
    }
  }
}