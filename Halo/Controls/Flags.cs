using System.Windows.Forms;
using Interfaces.Factory;
using Interfaces.TagEditor;
using System.Xml;

namespace Games.Halo.Controls
{
  public partial class Flags : FieldControl
  {
    private Tags.Fields.Flags value;

    public Flags()
    {
      InitializeComponent();
    }

    public override bool BindSupported(IField field)
    {
      return (value.GetType() == field.GetType());
    }
    
    public override void DataBind(IField value)
    {
      this.value = value as Tags.Fields.Flags;
      checkValue.DataBindings.Clear();
//      if (this.value != null)
//        this.value.ValueChanged -= new EventHandler(value_ValueChanged);
//      checkValue.ValueChanged += new EventHandler(value_ValueChanged);
      UpdateValue();
    }

    private void checkValue_ItemCheck(object sender, ItemCheckEventArgs e)
    {
      value.SetFlag(e.Index + 1, (e.NewValue == CheckState.Checked));
    }

    public override void Configure(System.Xml.XmlNode valueNode)
    {
      base.Configure(valueNode);
      this.checkValue.Items.Clear();
      XmlNodeList items = valueNode.SelectNodes("bit");
      foreach (XmlNode bitNode in items)
      {
        // ex: <bit index="0" name="turns without animating" />
        this.checkValue.Items.Add(bitNode.Attributes["name"].InnerText, false);
      }

      //TODO:  figure out how to subtract out the border to prevent big gaps at end of control
      int oldHeight = checkValue.Height;
      this.checkValue.Height = oldHeight * items.Count;
      this.Height += (checkValue.Height - oldHeight);
    }

    //private void value_ValueChanged(object sender, EventArgs e)
    //{
    //  UpdateValue();
    //}

    internal void UpdateValue()
    {
      // Update the checkboxes.
      for (int x = 0; x < this.checkValue.Items.Count; x++)
      {
        this.checkValue.SetItemChecked(x, this.value.GetFlag(x + 1));
      }
    }
  }
}