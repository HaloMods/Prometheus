using System.Windows.Forms;
using Interfaces.Factory;
using Interfaces.TagEditor;
using System.Collections.Generic;
using System.Xml;
using System;

namespace Games.Halo.Controls
{
  public partial class ShortBlockIndex : FieldControl, IBlockIndexControl
  {
    private Tags.Fields.ShortBlockIndex value;
    private List<string> blockValues = new List<string>();
    private string linkedBlockName = "";
    private IBlockControl linkedBlock = null;

    public ShortBlockIndex()
    {
      InitializeComponent();
      lblWarning.Visible = false;
    }

    public override void Configure(XmlNode valueNode)
    {
      base.Configure(valueNode);
      XmlAttribute linkedBlock = valueNode.Attributes["block"];
      if (linkedBlock != null)
        linkedBlockName = linkedBlock.Value;
    }

    public override bool BindSupported(IField field)
    {
      return (value.GetType() == field.GetType());
    }
    
    public override void DataBind(IField value)
    {
      this.value = value as Tags.Fields.ShortBlockIndex;
      txtValue.DataBindings.Clear();
      txtValue.DataBindings.Add(new Binding("Text", this.value, "Value"));
      txtValue.TextChanged += new System.EventHandler(txtValue_TextChanged);
      cboValue.SelectedIndexChanged += new EventHandler(cboValue_SelectedIndexChanged);
    }

    void txtValue_TextChanged(object sender, System.EventArgs e)
    {
      DataBindComboBox();
    }

    private void DataBindComboBox()
    {
      if (txtValue.Text == "") return;
      int selectedIndex = Convert.ToInt32(txtValue.Text);
      if (cboValue.Items.Count > selectedIndex)
      {
        cboValue.SelectedIndex = selectedIndex;
        lblWarning.Visible = false;
        txtValue.Visible = false;
        cboValue.Visible = true;
      }
      else
      {
        lblWarning.Visible = true;
        txtValue.Visible = true;
        cboValue.Visible = false;
      }
    }

    void cboValue_SelectedIndexChanged(object sender, EventArgs e)
    {
      txtValue.Text = cboValue.SelectedIndex.ToString();
    }

    public void ConnectBlockControl(IBlockControl control)
    {
      control.BlockCollectionChanged += new BlockCollectionChangedHandler(control_BlockCollectionChanged);
      UpdateComboBox(control.BlockValues);
      DataBindComboBox();
    }

    void control_BlockCollectionChanged(object sender, string[] blockValues)
    {
      UpdateComboBox(blockValues);
      DataBindComboBox();
    }

    private void UpdateComboBox(string[] values)
    {
      cboValue.Items.Clear();
      foreach (string value in values)
        cboValue.Items.Add(value);
      UpdateComboBox();
    }

    private void UpdateComboBox()
    {
      cboValue.Enabled = cboValue.Items.Count > 0;
    }

    public string LinkedStructName
    {
      get { return linkedBlockName; }
    }
  }
}