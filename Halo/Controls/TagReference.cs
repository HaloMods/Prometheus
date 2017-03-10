using System;
using System.Windows.Forms;
using Interfaces.Factory;
using Interfaces.TagEditor;
using DevComponents.DotNetBar;

namespace Games.Halo.Controls
{
  public partial class TagReference : FieldControl, ITagReferenceControl
  {
    private Games.Halo.Tags.Fields.TagReference value;

    private bool validTagReference;
    private bool ValidTagReference
    {
      get { return validTagReference; }
      set
      {
        validTagReference = value;

        // Set the state of the Open Tag button.
        imgbOpenTag.Enabled = validTagReference;

        if (validTagReference)
          txtbxTagReference.ForeColor = System.Drawing.Color.DarkBlue;
        else
          txtbxTagReference.ForeColor = System.Drawing.Color.Red;
      }
    }

    public event OpenTagEventHandler OpenTag;

    public TagReference()
    {
      InitializeComponent();
    }

    #region Data Binding

    public override bool BindSupported(IField field)
    {
      return (value.GetType() == field.GetType());
    }
    
    public override void DataBind(IField value)
    {
      this.value = value as Games.Halo.Tags.Fields.TagReference;
      txtbxTagReference.DataBindings.Clear();
      txtbxTagReference.DataBindings.Add(new Binding("Text", this.value, "Value"));

      txtbxTagReference.SelectionStart = txtbxTagReference.Text.Length; // Move caret to end of tag reference; the front is typically not too interesting.
    }

    #endregion

    #region Tag Reference Operations

    private Games.Halo.Tags.Fields.TagReference SelectTag()
    {
      // TODO: Open TagBrowserDialog so user can select a tag.

      return new Games.Halo.Tags.Fields.TagReference(); // Just here to stop the compiler complaints.
    }

    private Games.Halo.Tags.Fields.TagReference CreateNewTag()
    {
      // TODO: Create a new tag file and fill in path once it is saved.

      return new Games.Halo.Tags.Fields.TagReference(); // Just here to stop the compiler complaints.
    }

    private Games.Halo.Tags.Fields.TagReference ImportFromTag()
    {
      // TODO: Open existing tag and pull ref from same location in that tag.

      return new Games.Halo.Tags.Fields.TagReference(); // Just here to stop the compiler complaints.
    }

    private string ResolveTagScope()
    {
      string scope = btnxReferenceTagScope.Tag.ToString();

      if (!scope.Equals(String.Empty))
      {
        switch (scope)
        {
          case "Auto": // Automatic tag scope resolution.
            // TODO: If anything needs to happen, it goes here.
            return String.Empty;
          case "Project": // Project-level tag scope.
            // TODO: Return active project once Project Management code is in.
            return String.Empty;
          case "User": // User-level tag scope.
            return "user:\\";
          case "Game": // Game-level tag scope.
            // TODO: Return active game once Project Management code is in.
            return String.Empty;
          default:
#if DEBUG
            // Fix this error by verifying the sub-buttons have their Tag property set to one of the names in the switch case above.
            MessageBoxEx.Show("Incorrect tag scope,\"" + scope + "\", set on one of the biReferenceTagScope buttons.", "Invalid Tag Scope");
#endif
            return String.Empty;
        }
      }

      return String.Empty;
    }

    private bool IsValidTagReference(string tagRef)
    {
      if (string.IsNullOrEmpty(tagRef))
        return false;

      // TODO: Check that the passed string, in combination with the tag scope, points to a valid Tag.

      return true; // Just here to stop the compiler complaints.
    }

    private void OpenTagReference()
    {
      if (OpenTag != null)
        OpenTag(value.Value);
    }

    #endregion

    #region Click Handlers

    /* 
     * Slightly customized version of childButtonItem_Click from PrometheusGUI.cs;
     * check there for more information about this function - mainly it helps swap
     * button info around.
     */
    private void childButtonXItem_Click(object sender, System.EventArgs e)
    {
      ButtonItem child = (sender as ButtonItem); 
      if(child == null) return;

      ButtonItem parent = (child.Parent as ButtonItem);
      if(parent == null) return;

      /* Update the Text property on the parent button to reflect selected button.
       * 
       * If the child's Tag object is null or the parent's Text property is an empty string, do nothing.
       */
      if (!child.Tag.Equals(null) && !parent.Text.Equals(string.Empty))
      {
        parent.Text = child.Tag.ToString();
      }

      // Mirror Tag property from child to parent.
      parent.Tag = child.Tag;

      // Update the image on the parent button.
      if (child.Image != null)
      {
        if (parent.Image != null)
        {
          parent.Image = child.Image;
        }
      }

      // Custom PerformLayout() calls needed
      if (parent.Equals(btnxReferenceAction))
        btnxReferenceAction.PerformLayout();
    }

    private void btnxReferenceAction_Click(object sender, System.EventArgs e)
    {
      ButtonItem bi = (sender as ButtonItem);

      if (bi == null)
        return;

      switch (bi.Text)
      {
        case "Select":
          SelectTag();
          break;
        case "Import":
          ImportFromTag();
          break;
        default:
#if DEBUG
          // Fix this error by verifying the sub-buttons have their Tag property set to one of the names in the switch case above.
          MessageBoxEx.Show("The button name \"" + (sender as ButtonItem).Text + "\" is incorrect. See the btnxReferenceAction_Click method.", "Invalid Button Name");
#endif
          break;
      }
    }

    private void biReferenceActionNew_Click(object sender, System.EventArgs e)
    {
      CreateNewTag();

      btnxReferenceAction.Image = global::Games.Halo.Properties.Resources.view16;
      btnxReferenceAction.Tag = "Select";
    }

    private void biReferenceActionClear_Click(object sender, System.EventArgs e)
    {
      txtbxTagReference.Clear();
    }

    private void imgbOpenTag_Click(object sender, System.EventArgs e)
    {
      OpenTagReference();
    }

    #endregion

    private void txtbTagReference_TextChanged(object sender, System.EventArgs e)
    {
      ValidTagReference = IsValidTagReference(txtbxTagReference.Text);

      /* 
       * The tag scope is hidden from the user, as they set it with a button,
       * so we must update the Tag Reference.
       * 
       * TODO: Figure out where this goes. I don't know how the Data Binding 
       * works so I have no clue where to go from here.
       */
      string fullTagRef = ResolveTagScope() + txtbxTagReference.Text;
    }

    protected override void SetReadOnly()
    {
      if (btnxReferenceAction == null || btnxReferenceTagScope == null)
        return;

      if (Locked)
        return;

      btnxReferenceAction.Enabled = !ReadOnly;
      btnxReferenceTagScope.Enabled = !ReadOnly;
    }
  }
}