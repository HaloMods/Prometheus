using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Xml;
using Interfaces.Factory;
using System.Reflection;
using DevComponents.DotNetBar.Rendering;
using Interfaces.Helpers;

namespace Interfaces.TagEditor
{
  public class FieldControlBase : UserControl, IFieldControl
  {
    #region Variables
    protected static DevComponents.DotNetBar.SuperTooltip stFieldControl;
    protected string errorText = String.Empty;
    private Office2007Renderer renderer = null;
    #endregion

    #region Properties

    public Office2007ColorTable ColorTable
    {
      get { return renderer.ColorTable; }
    }

    private Control tagEditor;
    protected Control TagEditor
    {
      get
      {
        if (tagEditor == null)
        {
          tagEditor = this;

          while (tagEditor != null)
          {
            tagEditor = tagEditor.Parent;
            if (tagEditor is Interfaces.UserInterface.IDocument) break;
          }
        }

        return tagEditor;
      }
    }

    #region Field Details
    
    /// <summary>
    /// Gets or sets the title text that will be displayed on the control.
    /// </summary>
    protected string title;
    public virtual string Title
    {
      get { return title; }
      set { title = value; }
    }

    /// <summary>
    /// If applicable to the field type, gets and sets the range of values allowed as input.
    /// </summary>
    private FieldRange range;
    public FieldRange Range
    {
      get { return range; }
      set { range = value; }
    }

    /// <summary>
    /// Causes the specified range to be enforced, not simply a suggestion.
    /// </summary>
    protected bool strictRange;
    public bool StrictRange
    {
      get { return strictRange; }
      set { strictRange = value; }
    }

    #endregion

    #region Data Binding Properties

    private IField baseValue;
    public IField BaseValue
    {
      get { return baseValue; }
    }
    
    /// <summary>
    /// The name of the property 
    /// </summary>
    private string boundPropertyName;
    public string BoundPropertyName
    {
      get { return boundPropertyName; }
      set { boundPropertyName = value; }
    }

    #endregion

    #region Field State Properties

    /// <summary>
    /// Gets or sets the read-only status of the control.
    /// </summary>
    protected bool readOnly;
    public bool ReadOnly
    {
      get { return readOnly; }
      set
      {
        readOnly = value;

        SetReadOnly();
      }
    }

    /// <summary>
    /// Sets if the lock icon is displayed or not.
    /// </summary>
    protected bool showLock;
    public virtual bool ShowLock
    {
      set
      {
        // Check if Expert Mode is on; if so, do not proceed.
        //if (ProjectExpertModeOn || GlobalExpertModeOn)
        //  return;

        showLock = value;

        if (showLock)
          Locked = true;
      }
    }

    /// <summary>
    /// Gets or sets the status of the lock.
    /// </summary>
    protected bool locked;
    protected bool Locked
    {
      get { return locked; }
      set
      {
        locked = value;

        SetLock();
      }
    }

    /// <summary>
    /// Gets or sets the reason for locking the control.
    /// </summary>
    protected string lockReason = String.Empty;
    public string LockReason
    {
      get { return lockReason; }
      set { lockReason = value; }
    }

    /// <summary>
    /// Gets or sets the status of the field's input state.
    /// </summary>
    protected bool dirty;
    public bool Dirty
    {
      get { return dirty; }
      set
      {
        dirty = value;

        SetDirty();
      }
    }

    /// <summary>
    /// Gets or sets the status of the field's error state.
    /// </summary>
    protected ErrorLevel error;
    protected ErrorLevel Error
    {
      get { return error; }
      set
      {
        error = value;

        SetError();
      }
    }

    #endregion

    #endregion

    static FieldControlBase()
    {
      stFieldControl = new DevComponents.DotNetBar.SuperTooltip();
      stFieldControl.TooltipDuration = 0;
    }

    public FieldControlBase()
    {
      if (GlobalManager.Renderer is Office2007Renderer)
      {
        renderer = (GlobalManager.Renderer as Office2007Renderer);

        // Hook up to theme changes.
        renderer.ColorTableChanged += renderer_ColorTableChanged;
        Load += new EventHandler(FieldControlBase_Load);
      }
    }

    void FieldControlBase_Load(object sender, EventArgs e)
    {
      // Setup the initial theme colors.
      UpdateTheme();
    }

    ~FieldControlBase()
    {
      Dispose(false);
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing)
      {
        GC.SuppressFinalize(this);

        // Unsubscribe to the theme event.
        if (renderer != null)
          renderer.ColorTableChanged -= renderer_ColorTableChanged;
      }

      base.Dispose(disposing);
    }

    #region Theming

    protected virtual void UpdateTheme()
    {
      /* // SupaHACK: Figures out if the control is on a Block or the main TE panel.
         // However, this is probably not needed since MonoxideC is a total newb and
         // was wrong about color inheritance.
      if (this.Parent is FlowLayoutPanel)
      {
        if (this.Parent.Parent != null)
        {
          if(this.Parent.Parent.Parent != null)
            if (this.Parent.Parent.Parent is IBoundPropertyCapable) // We're in a Block.
              BackColor = System.Drawing.Color.Yellow;
        }
      }

      if (BackColor != System.Drawing.Color.Yellow) // Above tests failed, we're directly on the TE.
        BackColor = System.Drawing.Color.Pink;*/

      if (renderer.ColorTable.InitialColorScheme == eOffice2007ColorScheme.Black)
        ForeColor = ColorTable.TabControl.Default.Text;
      else
        ForeColor = ColorTable.RibbonBar.Default.TitleText;
    }

    void renderer_ColorTableChanged(object sender, EventArgs e)
    {
      UpdateTheme();
    }

    #endregion

    #region Data Binding

    /// <summary>
    /// Returns a boolean indicating if the control is able to bind to the specified IField object.
    /// </summary>
    public virtual bool BindSupported(IField field)
    {
      throw new NotImplementedException("This method is not meant to be called from the base class.");
    }

    /// <summary>
    /// When overriden in a derived class, binds the control to the specified IField.
    /// The base DataBind method should be called first, as it wraps the SupportsBinding method and can
    /// generate the appropriate exception in the event that the method returns false.
    /// </summary>
    public virtual void DataBind(IField value)
    {
      // TODO: Perhaps we should just remove the BindSupported method - unless there is a crazy
      // bug in the TE code, it will never return false.
      //if (!BindSupported(value))
      //  throw new Exception(
      //    String.Format("Unable to bind the field of type {0} to the FieldControl of type {1}.",
      //      value.GetType(), GetType()));
      Tag = null;
      baseValue = value;
    }

    /// <summary>
    /// Returns an array of the databindings contained within this control.
    /// </summary>
    public virtual Binding[] GetDataBindings()
    {
      return GetDataBindings(this);
    }

    /// <summary>
    /// Returns a list of databindings contained within the specified control.
    /// </summary>
    public virtual Binding[] GetDataBindings(Control control)
    {
      List<Binding> bindings = new List<Binding>();
      foreach (Control c in control.Controls)
      {
        Binding[] subBindings = GetDataBindings(c);
        bindings.AddRange(subBindings);
      }
      foreach (Binding binding in control.DataBindings)
        bindings.Add(binding);
      return bindings.ToArray();
    }

    /// <summary>
    /// Sets up the control based on the data contained within the specified XML Node.
    /// </summary>
    public virtual void Configure(XmlNode valueNode)
    {
      try
      {
        Name = valueNode.Attributes["name"].InnerText;
        if (valueNode.Attributes["caption"] != null)
          Title = StringOps.CapitalizeWords(valueNode.Attributes["caption"].InnerText);
        else
          Title = StringOps.CapitalizeWords(Name);
      }
      catch (Exception ex)
      {
        throw new Exception("Unable to create value node: " + ex.Message);
      }
    }

    #endregion

    #region Field State Methods

    #region Read Only

    protected virtual void SetReadOnly() { ; }

    #endregion

    #region Lock

    protected virtual void SetLock() { ; }

    #endregion

    #region Dirty

    protected virtual void SetDirty() { ; }

    /// <summary>
    /// Reverts changes made to the control, setting data bound fields back to their loaded or last saved state.
    /// </summary>
    /// <returns>true if the changes were reverted; false if the changes were not reverted.</returns>
    protected bool RevertChanges()
    {
      if (Tag == null) return false;

      IField originalValue = (IField)Tag;
      CopyIField(originalValue, BaseValue);
      Tag = null;

      return true;
    }

    private void CopyIField(IField source, IField destination)
    {
      Type t = source.GetType();
      PropertyInfo[] properties = t.GetProperties();
      foreach (PropertyInfo property in properties)
      {
        object sourceValue = property.GetValue(source, null);
        property.SetValue(destination, sourceValue, null);
      }
    }

    /// <summary>
    /// Custom ToString with markup and original value support.
    /// </summary>
    /// <param name="withMarkup">Toggle string beautification via markup.</param>
    /// <param name="originalValue">true will use the original value of the field when building the string; false will use the current value.</param>
    /// <returns>The potentially beautified original or current value of the field.</returns>
    public virtual string ToString(bool withMarkup, bool originalValue)
    {
      return Tag.ToString();
    }
    public virtual string ToString(bool withMarkup) { return ToString(withMarkup, false); }

    #endregion

    #region Error

    protected virtual void SetError() { ; }

    /// <summary>
    /// Handles the error on a per-control basis.
    /// </summary>
    /// <returns>true if the error was handled; false if the error was not handled.</returns>
    protected virtual bool HandleError()
    {
#if DEBUG
      return true;
#else
      throw new NotImplementedException("Every Tag Editor control must define this method so we know how to handle the error.");
#endif
    }

    #endregion

    #endregion

    #region Range Validation

    /// <summary>
    /// Determine if the specified value is within the set range. If it is not, set the appropriate ErrorLevel and errorText.
    /// </summary>
    /// <param name="input">Value to be verified.</param>
    /// <param name="suppressError">true - prevents errors from being reported to the user; false - any errors are displayed to the user.</param>
    /// <returns>-3 = no range set; -2 = value is NaN; -1 = less than set range; 0 = within set range; 1 = greater than set range.</returns>
    protected int ValueInRange(string input, bool suppressError)
    {
      if (range == null)
        return -3; // Value is automatically in range, since no range has been specified.

      if (String.IsNullOrEmpty(input))
      {
        errorText = "The input value has not been set.";
        Error = (suppressError ? ErrorLevel.None : (strictRange ? ErrorLevel.Error : ErrorLevel.Warning));
       
        return -2; // Nothing there, nothing to compare.
      }

      if (input.Equals(".") || input.Equals("-") || input.Equals("-."))
      {
        errorText = "The input value must contain at least one number.";
        Error = (suppressError ? ErrorLevel.None : (strictRange ? ErrorLevel.Error : ErrorLevel.Warning));
       
        return -2; // Cannot compare, no numbers.
      }

      decimal value;

      try { value = Decimal.Parse(input); }
      catch (Exception) { return -2; } // Psh, whatever, you sent us crap.

      if (Range.Start <= value && value <= Range.End)
      {
        Error = ErrorLevel.None; // Clear Error; for now passing validation clears "all" errors. Not sure if we're going to need some Error List in the future, we'll see.

        return 0; // Value is equal to or between set range values.
      }
      else
      {
        if (Range.Start > value)
        {
          errorText = "The input value of <b>" + Strings.CreateColorizedNumericString(value.ToString(), true) + "</b> is less than the minimum value of <font color=\"green\"><b>" + Range.Start.ToString() + "</b></font>.";
          Error = (suppressError ?  ErrorLevel.None : (strictRange ? ErrorLevel.Error : ErrorLevel.Warning));

          return -1; // Value is less than the start of the range.
        }
        else
        {
          errorText = "The input value <b>" + Strings.CreateColorizedNumericString(value.ToString(), true) + "</b> is greater than the maximum value of <font color=\"green\"><b>" + Range.End.ToString() + "</b></font>.";
          Error = (suppressError ? ErrorLevel.None : (strictRange ? ErrorLevel.Error : ErrorLevel.Warning));

          return 1; // Value is greater than the end of the range.
        }
      }
    }
    protected int ValueInRange(string input) { return ValueInRange(input, false); }

    #endregion

    private void InitializeComponent()
    {
      this.SuspendLayout();
      // 
      // FieldControlBase
      // 
      this.Name = "FieldControlBase";
      this.Size = new System.Drawing.Size(390, 96);
      this.ResumeLayout(false);
    }
  }

  public enum ErrorLevel
  {
    None,
    Warning,
    Error
  }

  public sealed class FieldRange
  {
    private decimal start, end;
    public decimal Start { get { return start; } set { start = value; } }
    public decimal End { get { return end; } set { end = value; } }
    public FieldRange(decimal start, decimal end) { this.start = start; this.end = end; }
  }
}
