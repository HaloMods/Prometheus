using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using Interfaces.Factory;
using Interfaces.TagEditor;
using System.Reflection;
using DevComponents.DotNetBar.Rendering;

namespace Games.Halo.Controls
{
  public partial class Block : FieldControlBase, IBlockControl
  {
    private IBlockCollection blockCollection;
    private string linkedStructName = "";
    private IFieldControlContainer container = null;
    int maxBlockCount = -1;

    public event BlockCollectionChangedHandler BlockCollectionChanged;

    public Block()
    {
      InitializeComponent();
      btnAdd.EnabledChanged += new EventHandler(btnAdd_EnabledChanged);
      btnAdd.Click += new EventHandler(btnAdd_Click);
      btnInsert.Click += new EventHandler(btnInsert_Click);
      btnDuplicate.Click += new EventHandler(btnDuplicate_Click);
      btnDelete.Click += new EventHandler(btnDelete_Click);
      btnDeleteAll.Click += new EventHandler(btnDeleteAll_Click);
      cboBlockList.SelectedIndexChanged += new EventHandler(cboBlockList_SelectedIndexChanged);
    }

    void btnAdd_EnabledChanged(object sender, EventArgs e)
    {
      //DEBUG
    }

    public event BlockChangedHandler BlockChanged;

    public override void Configure(XmlNode valueNode)
    {
      base.Configure(valueNode);
      linkedStructName = valueNode.Attributes["struct"].Value;
      Title = Name;
    }

    public string[] BlockValues
    {
      get 
      {
        if (blockCollection == null)
          return new string[0];

        List<string> values = new List<string>();
        for (int x = 0; x < blockCollection.BlockCount; x++)
        {
          IBlock block = blockCollection.GetBlock(x);
          string blockName = block.BlockName;
          if (blockName == "")
            blockName = "Block " + x.ToString();
          values.Add(blockName);
        }
        return values.ToArray();
      }
    }

    public void DataBindCollection(IBlockCollection blockCollection)
    {
      this.blockCollection = blockCollection;
      //blockCollection.CollectionChanged += new EventHandler(blockCollection_CollectionChanged);
      blockCollection.BlockAdded += blockCollection_CollectionChanged;
      blockCollection.BlockRemoved += blockCollection_CollectionChanged;
      UpdateComboBox();
    }

    void blockCollection_CollectionChanged(object sender, EventArgs e)
    {
      if (BlockCollectionChanged != null)
        BlockCollectionChanged(this, BlockValues);
    }

    public void Initialize()
    {
      if (cboBlockList.Items.Count > 0) SelectBlock(0);
      else SelectBlock(-1);
    }

    IBlock currentBlock = null;
    protected void SelectBlock(int index)
    {
      if (currentBlock != null)
        currentBlock.BlockNameChanged -= currentBlock_BlockNameChanged;
      if (BlockChanged != null)
      {
        if (index > -1)
        {
          currentBlock = blockCollection.GetBlock(index);
          currentBlock.BlockNameChanged += currentBlock_BlockNameChanged;
          BlockChanged(currentBlock, Container);
        }
        else
        {
          BlockChanged(null, Container);
        }
      }
    }

    void currentBlock_BlockNameChanged(object sender, EventArgs e)
    {
      cboBlockList.Items[cboBlockList.SelectedIndex] = (object)currentBlock.BlockName;
    }

    private void UpdateComboBox()
    {
      UpdateComboBox(0);
    }

    private void UpdateComboBox(int selectedIndex)
    {
      this.SuspendLayout();
      cboBlockList.SuspendLayout();
       cboBlockList.Items.Clear();
      for (int x = 0; x < blockCollection.BlockCount; x++)
      {
        IBlock block = blockCollection.GetBlock(x);
        string blockName = block.BlockName;
        if (String.IsNullOrEmpty(blockName))
          blockName = "block " + x.ToString();
        cboBlockList.Items.Add(blockName);
      }

      if (blockCollection.BlockCount > 0)
      {
        cboBlockList.SelectedIndex = selectedIndex;
        SelectBlock(selectedIndex);
        cboBlockList.Enabled = true;
      }
      else
      {
        cboBlockList.Enabled = false;
        SelectBlock(-1);
      }     
      btnDelete.Enabled = (blockCollection.BlockCount > 0);
      btnDeleteAll.Enabled = (blockCollection.BlockCount > 0);
      if (MaxBlockCount > -1)
      {
        btnAdd.Enabled = (blockCollection.BlockCount < MaxBlockCount);
        btnInsert.Enabled = (blockCollection.BlockCount > 0) && (blockCollection.BlockCount < MaxBlockCount);
        btnDuplicate.Enabled = (blockCollection.BlockCount > 0) && (blockCollection.BlockCount < MaxBlockCount);
      }
      else
      {
        btnAdd.Enabled = true;
        btnInsert.Enabled = (blockCollection.BlockCount > 0);
        btnDuplicate.Enabled = (blockCollection.BlockCount > 0);
      }

      if (cboBlockList.SelectedIndex == -1)
        cboBlockList.SelectedText = "";
      cboBlockList.ResumeLayout();
      this.ResumeLayout();

      Dirty = true;
    }

    private void btnAdd_Click(object sender, EventArgs e)
    {
      blockCollection.AddNewBlock();
      UpdateComboBox(blockCollection.BlockCount - 1);
    }

    private void btnInsert_Click(object sender, EventArgs e)
    {
      int index = cboBlockList.SelectedIndex;
      blockCollection.InsertNew(index);
      UpdateComboBox(index);
    }

    private void btnDuplicate_Click(object sender, EventArgs e)
    {
      blockCollection.Duplicate(cboBlockList.SelectedIndex, blockCollection.BlockCount);
      UpdateComboBox(blockCollection.BlockCount-1);
    }

    private void btnDelete_Click(object sender, EventArgs e)
    {
      blockCollection.RemoveBlock(cboBlockList.SelectedIndex);
      int newIndex = cboBlockList.SelectedIndex - 1;
      if ((newIndex < 0) && (blockCollection.BlockCount > 0))
        newIndex = 0;
      UpdateComboBox(newIndex);
    }

    private void btnDeleteAll_Click(object sender, EventArgs e)
    {
      blockCollection.ClearBlocks();
      UpdateComboBox(-1);
    }

    private void cboBlockList_SelectedIndexChanged(object sender, EventArgs e)
    {
      // Update to the new block.
      SelectBlock(cboBlockList.SelectedIndex);
    }

    public string LinkedStructName
    {
      get { return linkedStructName; }
    }

    protected override void SetReadOnly()
    {
      if (btnAdd == null || btnDelete == null || btnDeleteAll == null || btnDuplicate == null | btnInsert == null)
        return;

      if (Locked)
        return;

      btnAdd.Enabled = !ReadOnly;
      btnDelete.Enabled = !ReadOnly;
      btnDeleteAll.Enabled = !ReadOnly;
      btnDuplicate.Enabled = !ReadOnly;
      btnInsert.Enabled = !ReadOnly;
    }

    /// <summary>
    /// Force fixes a really strange bug with the background color of this control.
    /// </summary>
    protected override void UpdateTheme()
    {
      // Simply matching the values from Controls\BlockContainer.cs
      if(((Office2007Renderer)GlobalManager.Renderer).ColorTable.InitialColorScheme == eOffice2007ColorScheme.Black)
        BackColor = ColorTable.TabControl.Default.TopBackground.Start;
      else
        BackColor = ColorTable.TabControl.Default.BottomBackground.End;

      base.UpdateTheme();
    }

    // These three properties added by ZF for more functional databinding.

    /// <summary>
    /// Gets or sets the selected block's index.
    /// </summary>
    public int SelectedBlockIndex
    {
      get { return cboBlockList.SelectedIndex; }
      set { cboBlockList.SelectedIndex = value; }
    }
    /// <summary>
    /// Gets the block collection.
    /// </summary>
    public IBlockCollection BlockCollection
    {
      get { return blockCollection; }
    }
    /// <summary>
    /// Gets the container which contains this control.
    /// </summary>
    public IFieldControlContainer Container
    {
      get { return container; }
      set { container = value; }
    }

    public int MaxBlockCount
    {
      get { return maxBlockCount; }
      set { maxBlockCount = value; }
    }
  }
}