using System;
using System.Windows.Forms;
using Interfaces.Factory;
using Interfaces.TagEditor;
using System.Xml;

namespace Games.Halo.Controls
{
  public partial class Enum : FieldControl
  {
    private Tags.Fields.Enum value;

    public Enum()
    {
      InitializeComponent();
    }

    public override void Configure(XmlNode valueNode)
    {
      base.Configure(valueNode);

      XmlNodeList items = valueNode.SelectNodes("item");
      foreach (XmlNode itemNode in items)
      {
        // ex: <item value="0" name="none" />
        cboxxEnumList.Items.Add(itemNode.Attributes["name"].InnerText);
      }
    }
    
    public override void DataBind(IField value)
    {
      base.DataBind(value);

      if ((value as Tags.Fields.Enum).Value <= cboxxEnumList.Items.Count)
      {
        this.value = value as Tags.Fields.Enum;
      }
      else
      {
        this.value = new Games.Halo.Tags.Fields.Enum(0);
        Interfaces.Output.Write(Interfaces.OutputTypes.Information, "During databinding, an enumeration's index exceeded the number of the number of enumerations available. The index was reset to 0.");
      }

      cboxxEnumList.DataBindings.Clear();
      cboxxEnumList.DataBindings.Add(new Binding("SelectedIndex", this.value, "Value"));
    }

    protected override bool HandleError()
    {
      this.value = new Games.Halo.Tags.Fields.Enum(0);
      return true;
    }

    public override string ToString(bool withMarkup, bool originalValue)
    {
      Tags.Fields.Enum oldValue = (Tags.Fields.Enum)Tag;

      if (oldValue == null)
        oldValue = value;
      
      return (originalValue ? oldValue.ToString() : value.ToString());
    }
  }
}