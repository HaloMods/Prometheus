using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using DevComponents.DotNetBar;
using Interfaces;
using Interfaces.Factory;
using Interfaces.Games;
using Interfaces.TagEditor;
using Prometheus.Controls.TagEditor;
using Padding=System.Windows.Forms.Padding;
using Interfaces.UserInterface;
using Interfaces.Pool;

namespace Prometheus.Controls.TagEditor
{
  //   Group is a range of fields that belong on their own tab. For now, we can stick fields not defined inside of a 
  // group in a default tab, but by release every field should have a group or there should be no groups in the XML 
  // (that is, if it is appropriate to group any part of the tag, the rest of the tag must also be defined in 
  // groups or there will be no groups at all).
  //   Section is a container that holds Blocks. It looks just like a Block, but has no description or more info, 
  // and the theme colors will be different (so they should all be settable). For example, I could put the "Vehicle 
  // Palette" and "Vehicle Instances" blocks from Scenario into a "Vehicles" section; this would create a Block called 
  // "Vehicles" that would have the two blocks in its body.
  //   Region is what we will call the groupings of fields that are not Blocks but are defined in the XML. These 
  // groupings will have the rounded style, a header section (identical to Block's header section), be collapsable, 
  // and have customizable colors.
  //   Auto-regions are similar to regions style-wise, but have no definition in the XML. 
  //
  //   http://forums.halodev.org/priv/index.php?act=Attach&type=post&id=27

  /// <summary>
  /// The TagEditor GUI control.
  /// </summary>
  public class TagEditorControl : UserControl, ISupportsUndoRedo, IDocument
  {
    private IContainer components;
    private IDocumentManager documentManager = Core.Prometheus.Instance.DocumentManager;
    private DocumentState documentState = DocumentState.Clean;
    
    #region Private Members

    private Tag tagData;
    private TagFile tagFile;
    private string className = "";
    private XmlDocument tagDefinition;
    private UndoManager undoManager = new UndoManager();
    private Stack<IFieldControlContainer> containers = new Stack<IFieldControlContainer>();
    private string mainStructName = "";
    private Stack<int> buildDepth = new Stack<int>();
    private DevComponents.DotNetBar.TabControl tabControl;
    private TabControlPanel tabControlPanel1;
    private TabItem tabItem1;
    private GameDefinition gameDefinition = null;

    private List<bool> isLoaded = new List<bool>(3);
    private List<TabArguments> tabArguments = new List<TabArguments>(3);
    //private List<BlockGlobals> blockGlobals = new List<BlockGlobals>(3);
    #endregion

    #region Ctor
    public TagEditorControl()
    {
      InitializeComponent();
      tabControl.Tabs.Remove(tabItem1);
      tabControl.SelectedTabChanged += new TabStrip.SelectedTabChangedEventHandler(tabControl_SelectedTabChanged);
      // TODO: Loading curtain when tab changed-- dunno if you want that on "changed" or "changing."
      SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint | ControlStyles.DoubleBuffer, true);
    }

    void tabControl_SelectedTabChanged(object sender, TabStripTabChangedEventArgs e)
    {
      if (tabControl.SelectedTabIndex > -1)
        if (tabControl.SelectedTabIndex < tabArguments.Count)
          if (!tabArguments[tabControl.SelectedTabIndex].IsLoaded)
            LoadTab(tabArguments[tabControl.SelectedTabIndex]);
      ForceAutoCenter();
    }   
    ~TagEditorControl()
    {
      Dispose();
    }
    #endregion

    public event DocumentStateChangedHandler DocumentStateChanged;
    public event OpenTagPathEventHandler OpenTag;
    
    #region Public "Create" Method - Starting point for constructing the control.
    /// <summary>
    /// Constructs the UI from a tag definition and a loaded tag object.
    /// </summary>
    public void Create(GameDefinition game, string tagClass, Tag tagData)
    {
      TagCreate(game, tagClass, tagData);

      LoadTab(tabArguments[tabControl.SelectedTabIndex]);

      
    }

    private void TagCreate(GameDefinition game, string tagClass, Tag tagData)
    {
      gameDefinition = game;
      XmlDocument tagDefinitionDocument = game.GetTagDefinitionDocument(tagClass);
      this.tagData = tagData;
      tagDefinition = tagDefinitionDocument;

      // Check to see if this is a derived type.
      XmlNode nameNode = tagDefinitionDocument.SelectSingleNode("//name");
      string parentClass = nameNode.Attributes["parenttype"].InnerText;
      if ((parentClass != "") && (parentClass != "????"))
      {
        XmlDocument tempDefinitionStorage = tagDefinition;
        
        TagCreate(game, parentClass, this.tagData);
        tagDefinition = tempDefinitionStorage;
      }

      // Query for the main node.
      mainStructName = nameNode.InnerText;
      XmlNode mainNode = tagDefinition.SelectSingleNode("//struct[@name='" + mainStructName + "']");

      // If it's not there, then this object doesn't match the supplied tag definition.
      if (mainNode == null)
        throw new Exception("'" + mainStructName + "' node was not found in the tag definition.");

      string tabName = mainNode.Attributes["name"].InnerText;
      if (mainNode.Attributes["caption"] != null)
        tabName = mainNode.Attributes["caption"].InnerText;
      CreateTab(tabName);

      TabArguments tabArgs = new TabArguments();
      tabArgs.Game = game;
      tabArgs.Container = containers.Pop();
      tabArgs.TagData = tagData;
      tabArgs.MaxDepth = GetMaxDepth(mainNode);
      tabArgs.TagClass = tagClass;
      tabArgs.NameNode = nameNode;
      tabArgs.MainNode = mainNode;
      tabArgs.TagDefinition = tagDefinition;

      tabArguments.Add(tabArgs);
    }

    private void LoadTab(TabArguments tabArgs)
    {
      this.tagData = tabArgs.TagData;
      this.tagDefinition = tabArgs.TagDefinition;
      //XmlNode nameNode = tabArgs.NameNode;
      XmlNode mainNode = tabArgs.MainNode;
      int maxDepth = tabArgs.MaxDepth;
      //tagDefinition = tabArgs.TagDefinition;
      containers.Push(tabArgs.Container);

      className = tagDefinition.SelectSingleNode("//xml/name").InnerText;

      buildDepth.Push(0);

      tabArgs.MainBlockGlobals = new ContainerGlobals(null, mainNode, maxDepth);
      tabArgs.MainBlockGlobals.DepthDifference = maxDepth;
      tabArgs.MainBlockGlobals.TagDefinition = tabArgs.TagDefinition;

      // This is the top-most block container and is placed directly into the tab, because CreateTab pushes itself onto the stack.
      BlockContainerPanel container = BuildStruct(tabArgs.MainBlockGlobals);
      container.Location = new Point((containers.Peek() as Control).Margin.Left, (containers.Peek() as Control).Margin.Top);
      container.DepthDifference = maxDepth;
      container.DatabindChildrenToBlock(tagData);
      container.AutoSizeMode = Prometheus.Controls.TagEditor.AutoSizeType.GrowAndShrink | Prometheus.Controls.TagEditor.AutoSizeType.WidthAndHeight;
      container.DrawBorder = true;

      IFieldControlContainer cont = containers.Peek();
      cont.AddFieldContainer(container);

      buildDepth.Pop();

      ConnectBlocks(container);
      tabArgs.IsLoaded = true;

      //AttachedControl_SizeChanged(tabControl.Tabs[tabControl.TabIndex].AttachedControl, null);
    }

    private static void ConnectBlocks(BlockContainerPanel container)
    {
      IFieldControl[] controls = container.GetChildFields();
      List<IBlockControl> blocks = new List<IBlockControl>();
      List<IBlockIndexControl> blockIndexControls = new List<IBlockIndexControl>();
      foreach (IFieldControl control in controls)
      {
        if (control is IBlockControl)
          if (!blocks.Contains(control as IBlockControl))
            blocks.Add(control as IBlockControl);
        if (control is IBlockIndexControl)
          if (!blockIndexControls.Contains(control as IBlockIndexControl))
            blockIndexControls.Add(control as IBlockIndexControl);
      }

      foreach (IBlockIndexControl blockIndex in blockIndexControls)
      {
        foreach (IBlockControl block in blocks)
        {
          if (block.LinkedStructName == blockIndex.LinkedStructName)
          {
            blockIndex.ConnectBlockControl(block);
            break;
          }
        }
      }
    }

    private int GetMaxDepth(XmlNode structNode)
    {
      int depth = 1;

      for (int x = 0; x < structNode.ChildNodes.Count; x++)
      {
        if (structNode.ChildNodes[x].Name.ToLower() == "group")
        {
          // groups are on an entirely different tab, so don't even bother with them.
        }
        else if (XmlNameIsContainer(structNode.ChildNodes[x].Name.ToLower()))
        {
          int structDepth = GetMaxDepth(structNode.ChildNodes[x]);
          if (structDepth + 1 > depth)
            depth = structDepth + 1;
        }
      }
      return depth;
    }
    /// <summary>
    /// Returns true if 'name' is the name of an xml node which contains values (e.g. 'struct', 'section', 'region').
    /// </summary>
    /// <param name="name"></param>
    /// <returns></returns>
    private static bool XmlNameIsContainer(string name)
    {
      return (name == "struct") || (name == "region") || (name == "section");
    }

    /// <summary>
    /// Setup double buffering on the specified control and all of its child controls.
    /// This requires the use of reflection to access the protected SetStyle method.
    /// </summary>
    private void MakeDoubleBuffered(Control control)
    {
      Type t = typeof(Control);
      MethodInfo inf = t.GetMethod("SetStyle", BindingFlags.NonPublic | BindingFlags.Instance);
      if (inf != null)
        inf.Invoke(control, new object[] { ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, true });
      foreach (Control childControl in control.Controls)
      {
        Output.Write(OutputTypes.Debug, (childControl.Name + " - " + childControl.Size.ToString()).Replace("{", "").Replace("}", ""));
        MakeDoubleBuffered(childControl);
      }
    }
    #endregion

    #region Protected "BuildStruct" and supporting methods.
    /// <summary>
    /// Builds a BlockContainer control, populating it with the appropriate controls
    /// based on the supplied XML TDF data.
    /// </summary>
    protected BlockContainerPanel BuildStruct(ContainerGlobals globals)
    {
      XmlNode node = globals.BlockNode;
      bool mainBlock = globals.MainBlock;
      int maxDepth = globals.MaxDepth;

      //int depth = (int)buildDepth.Peek();

      // Setup the block container.
      BlockContainerPanel container = new BlockContainerPanel();
      container.Name = node.Attributes["name"].Value;
      container.SuspendLayout();
      container.Location = new Point(0, 0);
      container.LinkedUndoManager = undoManager;
      container.LinkedUndoManager.StateChanged += new StateChangedHandler(LinkedUndoManager_StateChanged);
      containers.Push(container);

      XmlNodeList valueNodes = node.SelectNodes("*");
      foreach (XmlNode valueNode in valueNodes)
      {
        if (valueNode.Name.ToLower() == "group")
          ProcessGroup(container, valueNode, mainBlock, maxDepth);
        else if (valueNode.Name.ToLower() == "section")
          ProcessSection(globals, valueNode, mainBlock, maxDepth);
        else if (valueNode.Name.ToLower() == "region")
          ProcessRegion(globals, valueNode, mainBlock, maxDepth);
        else if (valueNode.Name.ToLower() == "value")
        {
          string valueName = valueNode.Attributes["name"].InnerText;
          IFieldControl fieldControl;
          string valueText = valueNode.Attributes["type"].InnerText;
          string fullPropertyName = (mainBlock ? className + "Values." : "") + GlobalMethods.MakePublicName(valueName);

          // Create the proper control based on the name that we got from the XML.
          if (gameDefinition.FieldControlTable.ContainsKey(valueText))
          {
            Type fieldControlType = gameDefinition.FieldControlTable[valueText];
            Assembly targetAssembly = Assembly.GetAssembly(fieldControlType);
            fieldControl = (targetAssembly.CreateInstance(fieldControlType.FullName) as IFieldControl);
            
            fieldControl.Configure(valueNode);
            //((Control)fieldControl).Font = new Font("Verdana", 6.75f); // Set in Interfaces\TagEditor\FieldControl.cs 
            if (valueText != "Block")
            {
              // If this is a tag reference control, hook up its events.
              if (fieldControl is ITagReferenceControl)
                (fieldControl as ITagReferenceControl).OpenTag += new OpenTagEventHandler(TagEditorControl_OpenTag);

              IFieldControlContainer c = containers.Peek();
              c.AddField(fieldControl);
              (fieldControl as Control).Visible = true;
            }
            else
            {
              ProcessBlock(globals, valueNode, fieldControl, fullPropertyName);
            }
          }
          else
          {
            continue;
          }
          fieldControl.BoundPropertyName = fullPropertyName;
        }
      }
//      depth = (int)(buildDepth.Pop());
  //    buildDepth.Push(depth - 1);
      containers.Pop();
      container.ResumeLayout(false);
      container.Width = container.Width;
      return container;
    }

    private void ProcessBlock(ContainerGlobals globals, XmlNode valueNode, IFieldControl fieldControl, string fullPropertyName)
    {
      int maxDepth = globals.MaxDepth;

      IBlockControl blockControl = fieldControl as IBlockControl;

      if (valueNode.Attributes["maxelements"] != null)
        blockControl.MaxBlockCount = Convert.ToInt32(valueNode.Attributes["maxelements"].Value);
      else
        blockControl.MaxBlockCount = -1;
      // At this point, we need to recurse and create the sub control for this block.
      // Step 1: Locate the proper struct in the document and construct it's full path.
      string structName = valueNode.Attributes["struct"].InnerText;
      XmlNode structNode = tagDefinition.SelectSingleNode("//struct[@name='" + structName + "']");

      Controls.BlockContainer fieldControlContainer = new Controls.BlockContainer();
      fieldControlContainer.Globals = new ContainerGlobals(globals, structNode, maxDepth);
      InitContainer(fieldControlContainer);
      fieldControlContainer.ContainerName = StringOps.CapitalizeWords(fieldControl.Title);
      fieldControlContainer.FooterText = "End of '" + fieldControlContainer.ContainerName + "' Block";
      fieldControlContainer.BoundPropertyName = fullPropertyName;
      //fieldControlContainer.Block.BlockChanged += new BlockChangedHandler();

      // add the IBlockControl
      fieldControlContainer.AddField(fieldControl);

      containers.Peek().AddFieldContainer(fieldControlContainer);

      // Step 3: Wire up the BlockChanged event for databinding.
      blockControl.Initialize();
    }

    protected void ProcessGroup(BlockContainerPanel container, XmlNode node, bool mainBlock, int maxDepth)
    {
      // Make sure that this node is a direct child of the Main Struct.
      // (That's the only place that groups are allowed to exist.)
      if (node.ParentNode.Name.ToLower() == "struct")
        if (node.ParentNode.Attributes["name"] != null)
        {
          groupCount++;

          string groupCaption = "";
          if (node.Attributes["caption"] != null)
            groupCaption = node.Attributes["caption"].InnerText;
          else if (node.Attributes["name"] != null)
            groupCaption = node.Attributes["name"].InnerText;
          else
            groupCaption = "Group " + groupCount;
          //buildDepth.Push(0);
          CreateTab(groupCaption);
          //BlockContainerPanel newContainer = BuildStruct(new BlockGlobals(null, node, maxDepth));

          TabArguments tabArgs = new TabArguments();
          tabArgs.Container = containers.Pop();
          tabArgs.TagDefinition = tagDefinition;
          tabArgs.Game = gameDefinition;
          tabArgs.MainNode = node;
          tabArgs.MaxDepth = maxDepth;
          tabArgs.TagData = tagData;
          tabArguments.Add(tabArgs);

          //newContainer.DatabindChildrenToBlock(tagData);
          //containers.Peek().AddFieldContainer(newContainer);
          //containers.Pop();
          //buildDepth.Pop();
          return;
        }
      throw new Exception("Unable to create group: Not a direct member of the main struct.");
    }

    protected void ProcessSection(ContainerGlobals parent, XmlNode node, bool mainBlock, int maxDepth)
    {
     SectionContainer container = new SectionContainer();

      ContainerGlobals globals = new ContainerGlobals(parent.Parent, node, maxDepth);
      if (globals.Parent == null)
        globals.TagDefinition = tagDefinition;
      globals.DepthDifference = parent.DepthDifference - 1;

      container.Globals = globals;

      InitContainer(container);

      container.FooterText = "End of '" + container.ContainerName + "' Section";

      containers.Peek().AddFieldContainer(container);
    }
    protected void ProcessRegion(ContainerGlobals parent, XmlNode node, bool mainBlock, int maxDepth)
    {
      RegionContainer container = new RegionContainer();

      ContainerGlobals globals = new ContainerGlobals(parent.Parent, node, maxDepth);
      if (globals.Parent == null)
        globals.TagDefinition = tagDefinition;
      globals.DepthDifference = parent.DepthDifference - 1;
      container.Globals = globals;
      InitContainer(container);
      //container.FieldPanel = BuildStruct(globals);
      container.FooterText = "End of '" + container.ContainerName + "' Region";
      container.PerformingLoad += new DynamicContainerDelegate(Subblock_OnExpanding);
      containers.Peek().AddFieldContainer(container);
    }
    private void InitContainer(FieldContainerBase container)
    {
      if (container.Globals.Parent != null)
        container.Globals.DepthDifference = container.Globals.Parent.DepthDifference - 1;
      container.PerformingLoad += new DynamicContainerDelegate(Subblock_OnExpanding);
      if (container.Globals.BlockNode.Attributes["name"] != null)
      {
        container.Name = container.Globals.BlockNode.Attributes["name"].Value;
        container.ContainerName = StringOps.CapitalizeWords(container.Name);
      }
      container.FooterFont = new System.Drawing.Font("Segoe UI", 8.25F, FontStyle.Bold);
      container.Collapsed = true;
      XmlNode node = container.Globals.BlockNode;
      XmlNode shortDescNode = node.SelectSingleNode("shortdesc");
      XmlNode longDescNode = node.SelectSingleNode("longdesc");
      XmlNode warningNode = node.SelectSingleNode("warning");
      if (shortDescNode != null)
        container.ShortDescription = shortDescNode.InnerText;
      if (longDescNode != null)
        container.LongDescription = longDescNode.InnerText;
      if (warningNode != null)
        container.Warning = warningNode.InnerText;

      container.ResumeLayout(true);
      //container.LayoutEngine.Layout(container, new LayoutEventArgs(container, "Size"));
    }

    void Subblock_OnExpanding(IDynamicContainer container, ContainerGlobals globals)
    {
      if (container.Globals != null)
      {
        if (!container.Globals.IsLoaded)
        {
          LoadBlock(container);
        }
      }
      ForceAutoCenter();
    }

    private void LoadBlock(IDynamicContainer container)
    {
      this.tagDefinition = container.Globals.TagDefinition;
      //int depth = (int)buildDepth.Pop();
      //buildDepth.Push(depth + 1);
      BlockContainerPanel panel = BuildStruct(container.Globals);
      panel.SuspendLayout();
      panel.DepthDifference = container.Globals.DepthDifference;
      container.FieldPanel = panel;
      //container.Block.BlockChanged += new BlockChangedHandler(panel.DatabindChildrenToBlock);
      /*if (container.Block != null)
      {
        container.Block.BlockChanged += new BlockChangedHandler((panel as BlockContainerPanel).DatabindChildrenToBlock);
        if (container.Block.SelectedBlockIndex > -1)
          (panel as BlockContainerPanel).DatabindChildrenToBlock(container.Block.BlockCollection.GetBlock(container.Block.SelectedBlockIndex));
        else
        {
          if ((container.Parent != null) && (container.Parent.Block != null) && (container.Parent.Block.SelectedBlockIndex != null))
            ((tabArguments[tabControl.SelectedTabIndex].Container as IDynamicContainer).FieldPanel).DatabindChildrenToBlock(container.Parent.Block.BlockCollection.GetBlock(container.Parent.Block.SelectedBlockIndex));
          else
            ((tabArguments[tabControl.SelectedTabIndex].Container as Control).Controls[0] as BlockContainerPanel).DatabindChildrenToBlock(tabArguments[tabControl.SelectedTabIndex].TagData, container);
        }
      }
      else
      {
        //((tabArguments[tabControl.SelectedTabIndex].Container as Control).Controls[0] as BlockContainerPanel).DatabindChildrenToBlock(tabArguments[tabControl.SelectedTabIndex].TagData);
        if ((container.Parent != null) && (container.Parent.Block != null) && (container.Parent.Block.SelectedBlockIndex != null))
          ((tabArguments[tabControl.SelectedTabIndex].Container as IDynamicContainer).FieldPanel).DatabindChildrenToBlock(container.Parent.Block.BlockCollection.GetBlock(container.Parent.Block.SelectedBlockIndex));
        else
          ((tabArguments[tabControl.SelectedTabIndex].Container as Control).Controls[0] as BlockContainerPanel).DatabindChildrenToBlock(tabArguments[tabControl.SelectedTabIndex].TagData, container);
      }*/
      // Sets the active block to being the block's selection and performs databinding
      IBlockControl block = panel.GetParentBlock();
      if ((block != null) && (block.BlockCollection != null))
      {
        block.BlockChanged += new BlockChangedHandler(panel.DatabindChildrenToBlock);
        IBlock tempBlock = null;
        if (block.BlockCollection.BlockCount > 0)
        {
          if (block.SelectedBlockIndex > 0)
            tempBlock = block.BlockCollection.GetBlock(block.SelectedBlockIndex);
          else
          {
            block.SelectedBlockIndex = 0;
            tempBlock = block.BlockCollection.GetBlock(0);
          }
        }


        // if this is a region, we don't want the databinding to disable the controls.
        // Basically, it will always databind if it's not null, or if it is a block, rather than a region/section/whatever.
        if ((tempBlock != null) || (container is BlockContainer))
          panel.DatabindChildrenToBlock(tempBlock);
      }
      else
      {
        panel.DatabindChildrenToBlock(tabArguments[tabControl.SelectedTabIndex].TagData, panel);
        
      }

      // Databind the block.
      if (panel != null)
      {
        panel.Visible = true;
        if (panel is BlockContainerPanel)
          ConnectBlocks(panel as BlockContainerPanel);
      }
      container.Globals.IsLoaded = true;
      panel.ResumeLayout();
    }

    void TagEditorControl_OpenTag(string relativePath)
    {
      if (OpenTag != null)
      {
        TagPath path;
        if (TagPath.IsFullyQualifiedPath(relativePath))
          path = new TagPath(relativePath);
        else
          path = new TagPath(relativePath, gameDefinition.GameID, TagLocation.Auto);
        
        OpenTag(path);
      }
    }

    void LinkedUndoManager_StateChanged(bool dirty)
    {
      if (dirty)
        documentState = DocumentState.Dirty;
      else
        documentState = DocumentState.Clean;

      if (DocumentStateChanged != null)
        DocumentStateChanged(this, documentState);
    }

    int groupCount = 0; // global integer used by process group in the case that a block does not have a name or caption.
    #endregion

    /// <summary>
    /// Creates a new Tab page in the tab control.
    /// </summary>
    private void CreateTab(string caption)
    {
      TabItem item = tabControl.CreateTab(caption);
      tabControl.Margin = new Padding(0);

      isLoaded.Add(false);

      ThemedPanel intermediatePanel = new ThemedPanel();
      intermediatePanel.Dock = DockStyle.Fill;
      intermediatePanel.AutoScroll = true;
      intermediatePanel.Margin = new Padding(0);
      item.AttachedControl.Controls.Add(intermediatePanel);

      intermediatePanel.Scroll += new ScrollEventHandler(intermediatePanel_Scroll);
      intermediatePanel.SizeChanged += new EventHandler(intermediatePanel_SizeChanged);

      FieldContainerPanel panel = new FieldContainerPanel();
      panel.AutoSize = true;
      panel.AutoSizeMode = Prometheus.Controls.TagEditor.AutoSizeType.GrowAndShrink | Prometheus.Controls.TagEditor.AutoSizeType.WidthAndHeight;
      panel.Location = new Point(0, 0);
      panel.Margin = new Padding(0, 0, 0, 0);
      panel.Name = "TagEditorTab";

      intermediatePanel.Controls.Add(panel);
      containers.Push(panel);
    }

    int yScrollPos = 0;
    int xScrollPos = 0;
    void intermediatePanel_Scroll(object sender, ScrollEventArgs e)
    {
      if (e.ScrollOrientation == ScrollOrientation.HorizontalScroll)
        xScrollPos = e.NewValue;
      else
        yScrollPos = e.NewValue;
      
    }    
    void ForceAutoCenter()
    {
      /*Control panel = tabControl.Tabs[tabControl.SelectedTabIndex].AttachedControl;
      if (panel != null)
        AttachedControl_SizeChanged(panel, null);*/
    }
    void AttachedControl_SizeChanged(object sender, EventArgs e)
    {
      if (sender is Control)
      {
        Control control = sender as Control;
        if (sender is ThemedPanel)
          intermediatePanel_SizeChanged(sender, null);

        for (int x = 0; x < control.Controls.Count; x++)
        {
          if (control.Controls[x] is ThemedPanel)
            intermediatePanel_SizeChanged(control.Controls[x], null);
        }
      }
    }

    void intermediatePanel_SizeChanged(object sender, EventArgs e)
    {
      if (sender != null)
      {
        if (sender is ThemedPanel)
        {
          ThemedPanel themedPanel = sender as ThemedPanel;
          if (themedPanel.Controls.Count > 0)
          {
            for (int x = 0; x < themedPanel.Controls.Count; x++)
              if (themedPanel.Controls[x] is FieldContainerPanel)
              {
                int modifier = ((ScrollbarsShowing(themedPanel, themedPanel.Controls[0]) & 2) == 2) ? 8 : 0;
                int panelLocationX = (themedPanel.Width - themedPanel.Controls[x].Width) / 2;
                panelLocationX -= modifier; // Adjust for the vertical scrollbar.
                panelLocationX += themedPanel.AutoScrollPosition.X; // Adjust for the scroll amount... *should* always be zero.
                
                if (themedPanel.Width > themedPanel.Controls[x].Width + modifier)
                  themedPanel.Controls[x].Location = new Point(panelLocationX, themedPanel.Controls[x].Location.Y);
                else
                {
                  themedPanel.Controls[x].Location = new Point(themedPanel.AutoScrollPosition.X, themedPanel.AutoScrollPosition.Y);
                  //(themedPanel.Controls[x] as FieldContainerPanel).ForceAutoSize();
                }
                break;
              }
          }
        }
      }
    }

    /// <summary>
    /// Determines whether or not the scrollbars are showing on the themedpanel.
    /// </summary>
    /// <returns> 1 if the horizontal scrollbar is showing, 2 if the vertical scrollbar is showing, 3 if both are showing, and 0 if none are showing.</returns>
    private static int ScrollbarsShowing(Control parent, Control child)
    {
      int result = 0;


      int childX = (child.Location.X > 0) ? child.Location.X : 0;
      int childY = (child.Location.Y > 0) ? child.Location.Y : 0;
      // First lets see if the width of the child is larger than the parent
      if (child.Width + childX > parent.Width)
      {
        result |= 1; // horizontal scrollbar must be showing.
        // check to see if the height of the child is larger than the parent.
        if (child.Height + childY > parent.Height - 16)
          result |= 2; // vertical scrollbar must be showing
      }
      else
      {
        // the raw width of the child does not surpass the parent.
        // does the height surpass the parent?
        if (child.Height + childY > parent.Height)
        {
          result |= 2; // the height does.
          if (child.Width + childX > parent.Width - 16)
            result |= 1; // the vertical scrollbar as made the horizontal scrollbar necessary.
        }
      }
        
      return result;
    }
    public int ScrollBars
    {
      get 
      {
        try
        {
          return ScrollbarsShowing(tabControl.Tabs[tabControl.TabIndex].AttachedControl, tabControl.Tabs[tabControl.TabIndex].AttachedControl.Controls[0].Controls[0]);
        }
        catch
        {
        }
        return -1;
      }
    }

    #region Undo/Redo
    public void Undo()
    {
      undoManager.Undo();
    }
    public void Redo()
    {
      undoManager.Redo();
    }
    #endregion

    #region Component Designer generated code
    /// <summary> 
    /// Required method for Designer support - do not modify 
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
      this.components = new System.ComponentModel.Container();
      this.tabControl = new DevComponents.DotNetBar.TabControl();
      this.tabControlPanel1 = new DevComponents.DotNetBar.TabControlPanel();
      this.tabItem1 = new DevComponents.DotNetBar.TabItem(this.components);
      ((System.ComponentModel.ISupportInitialize)(this.tabControl)).BeginInit();
      this.tabControl.SuspendLayout();
      this.SuspendLayout();
      // 
      // tabControl
      // 
      this.tabControl.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(232)))), ((int)(((byte)(238)))));
      this.tabControl.CanReorderTabs = true;
      this.tabControl.Controls.Add(this.tabControlPanel1);
      this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
      this.tabControl.Location = new System.Drawing.Point(0, 0);
      this.tabControl.Name = "tabControl";
      this.tabControl.SelectedTabFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
      this.tabControl.SelectedTabIndex = 0;
      this.tabControl.Size = new System.Drawing.Size(576, 544);
      this.tabControl.Style = DevComponents.DotNetBar.eTabStripStyle.Office2007Dock;
      this.tabControl.TabAlignment = DevComponents.DotNetBar.eTabStripAlignment.Bottom;
      this.tabControl.TabIndex = 0;
      this.tabControl.TabLayoutType = DevComponents.DotNetBar.eTabLayoutType.MultilineNoNavigationBox;
      this.tabControl.Tabs.Add(this.tabItem1);
      // 
      // tabControlPanel1
      // 
      this.tabControlPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.tabControlPanel1.Location = new System.Drawing.Point(0, 0);
      this.tabControlPanel1.Name = "tabControlPanel1";
      this.tabControlPanel1.Padding = new System.Windows.Forms.Padding(1);
      this.tabControlPanel1.Size = new System.Drawing.Size(576, 522);
      this.tabControlPanel1.Style.BackColor1.Color = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(253)))), ((int)(((byte)(254)))));
      this.tabControlPanel1.Style.BackColor2.Color = System.Drawing.Color.FromArgb(((int)(((byte)(157)))), ((int)(((byte)(188)))), ((int)(((byte)(227)))));
      this.tabControlPanel1.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
      this.tabControlPanel1.Style.BorderColor.Color = System.Drawing.Color.FromArgb(((int)(((byte)(146)))), ((int)(((byte)(165)))), ((int)(((byte)(199)))));
      this.tabControlPanel1.Style.BorderSide = ((DevComponents.DotNetBar.eBorderSide)(((DevComponents.DotNetBar.eBorderSide.Left | DevComponents.DotNetBar.eBorderSide.Right)
                  | DevComponents.DotNetBar.eBorderSide.Top)));
      this.tabControlPanel1.Style.GradientAngle = -90;
      this.tabControlPanel1.TabIndex = 1;
      this.tabControlPanel1.TabItem = this.tabItem1;
      // 
      // tabItem1
      // 
      this.tabItem1.AttachedControl = this.tabControlPanel1;
      this.tabItem1.Name = "tabItem1";
      this.tabItem1.Text = "tabItem1";
      // 
      // TagEditorControl
      // 
      this.Controls.Add(this.tabControl);
      this.Name = "TagEditorControl";
      this.Size = new System.Drawing.Size(576, 544);
      ((System.ComponentModel.ISupportInitialize)(this.tabControl)).EndInit();
      this.tabControl.ResumeLayout(false);
      this.ResumeLayout(false);

    }

    /// <summary> 
    /// Clean up any resources being used.
    /// </summary>
    protected override void Dispose(bool disposing)
    {
      if (disposing)
      {
        GC.SuppressFinalize(this); // Standard Dispose/Finalize pattern.

        // We need to get rid of the databindings (maybe).
        RecursiveClearDatabindings(this);

        // Dispose our components.
        if (components != null)
          components.Dispose();

        // Inform the pool that we aren't using this tag anymore.
        if (tagData != null)
          Core.Prometheus.Instance.Pool.DisposeOfTag(ref tagData);

        base.Dispose(disposing);
      }
    }
    public void RecursiveClearDatabindings(Control c)
    {
      Binding[] bindings = new Binding[c.DataBindings.Count];
      c.DataBindings.CopyTo(bindings, 0);
      c.DataBindings.Clear();
      foreach (Binding binding in bindings)
      {
        TypeDescriptor.Refresh(binding.DataSource);
      }
      foreach (Control cc in c.Controls)
      {
        RecursiveClearDatabindings(cc);
      }
    }
    public void RecursiveDispose(Control c)
    {
      for (int x = 0; x < c.Controls.Count; x++)
        RecursiveDispose(c.Controls[x]);
      if (!c.IsDisposed)
        c.Dispose();
    }
    #endregion

    #region IDocument Members
    public string DocumentFilename
    {
      get { if (tagData != null) return tagData.TagPath.ToPath(); else return "(none"; }
      set { if (tagData != null) tagData.TagPath.Parse(value); else Output.Write(OutputTypes.Warning, "When setting DocumentFilename, tagData was null."); }
    }

    public string DocumentTitle
    {
      get { return Path.GetFileName(tagData.Name + "." + tagData.FileExtension); }
      set { }
    }

    public string DocumentTooltip
    {
      get { return Prometheus.Controls.UIHelpers.GetTagPathToolTip(tagData.TagPath); }
      set { }
    }

    public DocumentState DocumentState
    {
      get { return documentState; }
    }

    public IDocumentManager DocumentManager
    {
      get { return documentManager; }
      set { documentManager = value; }
    }

    public void LoadDocument()
    {
      throw new Exception("The method or operation is not implemented.");
    }

    public void SaveDocumentAs(string path)
    {
      string oldPath = tagData.TagPath.ToPath();
      try
      {
        TagFile file = Core.Prometheus.Instance.Pool.GetTagFile(tagData.TagPath);
        tagData.TagPath = new TagPath(path);
        Core.Prometheus.Instance.Pool.SaveTag(tagData, file);
        Output.Write(OutputTypes.Debug, "File was written to the project folder.");

        Debug.Assert(tagData.TagPath.Location != TagLocation.Archive);
        SaveDocument();
      }
      catch (Exception ex)
      {
        // TODO: Perhaps a better rollback solution than this :P
        tagData.TagPath = new TagPath(oldPath);
      }
    }

    public void SaveDocument()
    {
      lock (tagData)
      {
        // If this is a global tag, re-save to the project automatically.
        if (tagData.TagPath.Location == TagLocation.Archive)
        {
          if (Core.Prometheus.Instance.ProjectManager.ProjectLoaded)
          {
            string newPath = tagData.TagPath.NewLocation(TagLocation.Project).ToPath();
            Output.Write(OutputTypes.Information,
                         "Tag cannot be saved to the Archive, and therefore will be automatically saved to the project.");
            documentManager.SaveDocumentAs(this, newPath);
            return;
          }
        }

        Core.Prometheus.Instance.Pool.SaveTag(tagData);

        undoManager.SetCleanState();
        documentState = DocumentState.Clean;
        if (DocumentStateChanged != null)
          DocumentStateChanged(this, documentState);
      }
    }

    public void CloseDocument()
    {
      Dispose();
    }

    #endregion
  }

  public class TabArguments
  {
    public GameDefinition Game;
    public bool IsGroup = false;
    public IFieldControlContainer Container;
    public string TagClass;
    public Tag TagData;
    public XmlDocument TagDefinition;
    public XmlNode NameNode;
    public XmlNode MainNode;
    public ContainerGlobals MainBlockGlobals;
    public int MaxDepth;
    public bool IsLoaded = false;
  }
  public class ContainerGlobals
  {
    private ContainerGlobals parent;
    public List<ContainerGlobals> Children;
    public XmlDocument TagDefinition;
    public BlockContainerPanel BlockContainerPanel = null;
    public XmlNode BlockNode;
    public int MaxDepth;
    public int DepthDifference;
    public bool IsLoaded;
    public bool MainBlock
    {
      get { return Parent == null; } // if ParentArgs is null, this is the main block.
    }
    public ContainerGlobals Parent
    {
      get { return parent; }
      set { parent = value; if (parent != null) Parent.AddChild(this); }
    }

    private ContainerGlobals()
    {
      Children = new List<ContainerGlobals>();
      IsLoaded = false;
    }
    /// <summary>
    /// Initializes a new instance of BlockArguments.
    /// </summary>
    /// <param name="parent">The parent block's arguments for this block. Null if this is the main block.</param>
    public ContainerGlobals(ContainerGlobals parent, XmlNode node, int maxDepth) : this()
    {
      MaxDepth = maxDepth;
      BlockNode = node;
      Parent = parent;
      if (parent != null)
        TagDefinition = parent.TagDefinition;
    }
    public void AddChild(ContainerGlobals child)
    {
      Children.Add(child);
    }
    public void AddChild(XmlNode node)
    {
      Children.Add(new ContainerGlobals(this, node, MaxDepth));
    }
  }

  /// <summary>
  /// Helper class used to visualize the layout of nested controls as an XML document.
  /// </summary>
  public class ControlHierarchy
  {
    private XmlTextWriter writer;
    
    private string Process(Control c)
    {
      writer = new XmlTextWriter(new MemoryStream(), Encoding.ASCII);
      writer.Formatting = Formatting.Indented;
      writer.WriteStartDocument();
      /**/writer.WriteStartElement("controls");
      /**//**/ProcessControl(c);
      /**/writer.WriteEndElement();
      writer.WriteEndDocument();
      writer.Flush();

      byte[] data = new byte[writer.BaseStream.Length];
      writer.BaseStream.Position = 0;
      writer.BaseStream.Read(data, 0, data.Length);
      string s = Encoding.ASCII.GetString(data);
      return s;
    }
    
    private void ProcessControl(Control c)
    {
      string type = c.GetType().ToString();
      if (type.IndexOf('.') > 0)
        type = type.Substring(type.LastIndexOf('.') + 1);
      
      writer.WriteStartElement(type);
      /**/writer.WriteElementString("name", c.Name);
      /**/writer.WriteElementString("size", c.Size.ToString());
      /**/writer.WriteElementString("location", c.Location.ToString());

      foreach (Control child in c.Controls)
        ProcessControl(child);

      writer.WriteEndElement();
    }
    
    /// <summary>
    /// Visualizes a control heirarchy to an XML file.
    /// </summary>
    public static void Visualize(Control c, string filename)
    {
      ControlHierarchy h = new ControlHierarchy();
      string output = h.Process(c);
      File.AppendAllText(filename, output);
    }
  }
}