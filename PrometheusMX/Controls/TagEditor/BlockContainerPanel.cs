using System;
using System.Diagnostics;
using System.Reflection;
using System.Windows.Forms;
using Interfaces.Factory;
using Interfaces.TagEditor;

/*
 * [11:18] ZeldaFreak: fix block spacing
 * [11:18] ZeldaFreak: make the combobox items update their names
 * [11:18] ZeldaFreak: fix the strange databinding bug with the Node block
 */
namespace Prometheus.Controls.TagEditor
{
  public partial class BlockContainerPanel
  {
    private IBlock linkedBlock;
    private UndoManager undoManager = new UndoManager();

    public UndoManager LinkedUndoManager
    {
      get { return undoManager; }
      set { undoManager = value; }
    }
    
    public BlockContainerPanel()
    {
      InitializeComponent();
    }
    bool readOnly = false;
    private void bind_Parse(object sender, ConvertEventArgs e)
    {
      try
      {
        // Get the existing value from the object.
        Binding binding = (Binding)sender;
        string boundProperty = binding.BindingMemberInfo.BindingField;
        object datasource = binding.DataSource;
        Type controlType = datasource.GetType();
        PropertyInfo pi = controlType.GetProperty(boundProperty);
        object oldValue = pi.GetValue(datasource, null);

        // If this is the first modification to this FieldControl, store a copy of
        // its original underlying IField value in the Tag property.
        if (binding.Control.Parent.Parent is FieldControl)
          if (binding.Control.Parent.Parent.Tag == null)
            if (((FieldControl)binding.Control.Parent.Parent).BaseValue != null)
              binding.Control.Parent.Parent.Tag = ShallowClone(((FieldControl)binding.Control.Parent.Parent).BaseValue);

        bool readOnly = false;
        if (binding.Control.Parent.Parent is FieldControl)
          readOnly = (binding.Control.Parent.Parent as FieldControl).ReadOnly;

        // Convert to the desired type.
        string[] parts = e.DesiredType.ToString().Split('.');
        if (parts[0] != "System")
          throw new Exception("Cannot convert type '" + e.DesiredType + "' - it is not a standard System type.");

        Type t = Type.GetType("System.Convert");
        MethodInfo mi = t.GetMethod("To" + parts[1], new Type[1] { typeof(string) });
        object newValue = mi.Invoke(null, new object[1] { e.Value.ToString() });

        if (readOnly)
          e.Value = oldValue; // No changes for j00!
        else
        {
          // Notify the FieldControl that it is Dirty.
          if (binding.Control.Parent.Parent is FieldControl)
              ((FieldControl)binding.Control.Parent.Parent).Dirty = true;

          // Add this action to the UndoManager.
          IField field = binding.DataSource as IField;
          if (field != null)
            undoManager.AddAction(new UndoableFieldEditAction(field, boundProperty, oldValue, newValue));
        }
      }
      catch (Exception ex)
      {
        Trace.WriteLine("Could not set undo state for object: " + ex.Message);
      }
    }

    public static object ShallowClone(object obj)
    {
      return typeof(object).GetMethod("MemberwiseClone", BindingFlags.NonPublic
       | BindingFlags.Instance).Invoke(obj, new object[0]);
    } 

    /// <summary>
    /// Locates the child field of the specified name within the specified object.
    /// </summary>
    private object LocateFieldByName(object obj, string name)
    {
      string[] parts = name.Split('.');
      string currentObject = parts[0];
      Type objectType = obj.GetType();
      object value;
      FieldInfo fi = objectType.GetField(currentObject);
      
      if (fi != null)
        value = fi.GetValue(obj);
      else
      {
        // This is a property, not a field.
        PropertyInfo pi = objectType.GetProperty(currentObject);
        if (pi != null)
          value = pi.GetValue(obj, null);
        else
          return null;
      }
      
      if (parts.Length > 1)
        return LocateFieldByName(value, name.Replace(currentObject + ".", ""));
      else
        return value;
    }
    

    /// <summary>
    /// Databinds all of the child fields of the current block control to the specified block.
    /// </summary>
    public void DatabindChildrenToBlock(IBlock block)
    {
      DatabindChildrenToBlock(block, this);
    }

    public void DatabindChildrenToBlock(IBlock block, IFieldControlContainer container)
    {
      #region Old Method
      /*linkedBlock = block;
      
      if (block != null)
      {
        int index = -1;
        IFieldControl[] childFields = GetChildFields();
        foreach (FieldControlBase field in childFields)
        {
          index++;
          field.Enabled = true;

          try
          {
            // If the field is not a block, we will need to databind it.
            if (!(field is IBlockControl))
            {
              IField binding = (LocateFieldByName(linkedBlock, field.BoundPropertyName) as IField);
              if (binding != null)
              {
                field.DataBind(binding);
                Binding[] bindings = field.GetDataBindings();
                foreach (Binding bind in bindings)
                {
                  bind.Parse += bind_Parse;
                }
              }
            }
            // If it is a block, we need to recurse on the block so that its children get databound.
            else
            {
              IBlockCollection binding = LocateFieldByName(linkedBlock, field.BoundPropertyName) as IBlockCollection;
              if (binding != null)
              {
                (field as IBlockControl).DataBindCollection(binding);
                (field as IBlockControl).Initialize();
              }
              else
                field.Enabled = false;
            }
          }
          catch (Exception ex)
          {
            Interfaces.Output.Write(Interfaces.OutputTypes.Warning, "There was an error databinding to " + field.BoundPropertyName + ":" + ex.Message, ex);
            //MessageBox.Show("There was an error binding \"" + field.BoundPropertyName + ":\" " + ex.Message);
          }
        }
      }
      else
      {
        foreach (FieldControlBase field in GetChildFields())
          field.Enabled = false;
      }*/
      #endregion

      #region New Method
      if (container is FieldContainerBase)
        container = (container as FieldContainerBase).FieldPanel;
      if (container == null)
        return;
      //(container as Control).Enabled = (block != null);
      if (block == null)
      {        
        IFieldControl[] children = container.GetChildFields();
        foreach (FieldControlBase field in children)
          field.Enabled = false;
        return;
      }

      Control control = container as Control;
      // This is a bug-fix. At some point along the line, databinding was attached to an FieldContainerBase... so to fix it, we relink to the FieldPanel property.
      if (container is FieldContainerBase)
        control = (container as FieldContainerBase).FieldPanel;

      for (int x = 0; x < control.Controls.Count; x++)
      {
        Control curControl = control.Controls[x];
        curControl.Visible = true;

        // Determine whether or not the field is a FieldControlBase or not.
        FieldControlBase field = (curControl is FieldControlBase) ? curControl as FieldControlBase : null;

        #region the current control is a field
        if (field != null) 
        {
          field.Enabled = true;
          #region If the field is not a block, we will need to databind it.
          if (!(field is IBlockControl))
          {
            IField binding = (LocateFieldByName(block, field.BoundPropertyName) as IField);
            if (binding != null)
            {
              field.DataBind(binding);
              Binding[] bindings = field.GetDataBindings();
              foreach (Binding bind in bindings)
              {
                bind.Parse += bind_Parse;
              }
            }
            else
              field.Enabled = false;
          }
          #endregion
          else // This shouldn't happen, EVER!
          {            
            Interfaces.Output.Write(Interfaces.OutputTypes.Information, "DatabindChildrenToBlock came across an IBlockControl.");
          }
        }
        #endregion
        #region the current control is a block container.
        else if (curControl is Prometheus.Controls.BlockContainer)
        {
          Prometheus.Controls.BlockContainer blockContainer = curControl as Prometheus.Controls.BlockContainer;
          blockContainer.Enabled = true;
          IBlock nextBlock = null;
          BlockContainerPanel nextContainer = null;

          #region get the next container
          // We're getting all of the controls of type FieldContainerPanel, though there should only be one.
          /*Control[] fieldContainerPanels = GetChildControlsByType(blockContainer, typeof(BlockContainerPanel));
          if (fieldContainerPanels.Length > 0)
          {
            nextContainer = fieldContainerPanels[0] as BlockContainerPanel;
          }
          else
          {
            // This is a warning because the rest of the tag will work properly and execution can continue as normal.
            Interfaces.Output.Write(Interfaces.OutputTypes.Warning, "During databinding, the block \"" + blockContainer.BoundPropertyName + "\" did not have a field container panel!");
            continue;
          }*/
          if (blockContainer.FieldPanel != null)
            nextContainer = blockContainer.FieldPanel;

          #endregion

          #region get the next block
          /*Control[] blocks = GetChildControlsByType(blockContainer, typeof(IBlockControl));
          if (blocks.Length > 0)
          {
            IBlockControl blockControl = blocks[0] as IBlockControl;
            blockControl.Container = nextContainer as IFieldControlContainer;
            IBlockCollection binding = LocateFieldByName(block, (blockControl as IBoundPropertyCapable).BoundPropertyName) as IBlockCollection;
            if (binding != null)
            {
              blockControl.DataBindCollection(binding);
              blockControl.Initialize();
            }
          }
          else
          {
            Interfaces.Output.Write(Interfaces.OutputTypes.Warning, "During databinding, the block \"" + blockContainer.BoundPropertyName + "\" did not have an IBlockControl!");
            continue;
          }*/
          if (blockContainer.Block != null)
          {
            IBlockControl blockControl = blockContainer.Block;
            if (blockContainer.FieldPanel == null)
              blockControl.Container = blockContainer;
            else
              blockControl.Container = blockContainer.FieldPanel;
            IBlockCollection binding = LocateFieldByName(block, (blockControl as IBoundPropertyCapable).BoundPropertyName) as IBlockCollection;
            if (binding != null)
            {
              blockControl.DataBindCollection(binding);
              blockControl.Initialize();
            }
            if (blockControl.SelectedBlockIndex > -1)
              nextBlock = blockControl.BlockCollection.GetBlock(blockControl.SelectedBlockIndex);
          }
          #endregion

          if ((nextBlock != null) && (nextContainer != null))
            DatabindChildrenToBlock(nextBlock, nextContainer);
        }
        else if (curControl is FieldContainerBase)
        {
          FieldContainerBase fieldContainer = curControl as FieldContainerBase;
          fieldContainer.Enabled = true;

          DatabindChildrenToBlock(block, fieldContainer.FieldPanel);
        }
        #endregion
      }
      #endregion
    }
    /// <summary>
    /// Looks the first generation of the inputted control and gets all the controls that match the specified "type."
    /// </summary>
    /// <param name="control">The control to look through.</param>
    /// <param name="type">The type you're looking for.</param>
    /// <returns>An array of controls matching "type".</returns>
    private Control[] GetChildControlsByType(Control control, Type type)
    {
      System.Collections.Generic.List<Control> controls = new System.Collections.Generic.List<Control>();
      foreach (Control c in control.Controls)
      {
        if (type.IsInstanceOfType(c))
        {
          controls.Add(c);
        }
      }
      return controls.ToArray();
    }
  }
}
