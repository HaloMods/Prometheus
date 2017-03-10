/*
 * ObjectListView - A listview to show various aspects of a collection of objects
 *
 * User: Phillip Piper
 * Date: 9/10/2006 11:15 AM
 *
 * Change log:
 * 2007-04-12  JPP  - Allow owner drawn on steriods!
 *                  - Column headers now display sort indicators
 *                  - ImageGetter delegates can now return ints, strings or Images 
 *                    (Images are only visible if the list is owner drawn)
 *                  - Added OLVColumn.MakeGroupies to help with group partitioning
 *                  - All normal listview views are now supported
 *                  - Allow dotted aspect names, e.g. Owner.Workgroup.Name (thanks to OlafD)
 *                  - Added SelectedObject and SelectedObjects properties
 * 2007-03-01  JPP  - Added DataListView
 *                  - Added VirtualObjectListView
 * 					- Added Freeze/Unfreeze capabilities
 *                  - Allowed sort handler to be installed
 *                  - Simplified sort comparisons: handles 95% of cases with only 6 lines of code!
 *                  - Fixed bug with alternative line colors on unsorted lists (thanks to cmarlow)
 * 2007-01-13  JPP  - Fixed bug with lastSortOrder (thanks to Kwan Fu Sit)
 *                  - Non-OLVColumns are no longer allowed
 * 2007-01-04  JPP  - Clear sorter before rebuilding list. 10x faster! (thanks to aaberg)
 *                  - Include GetField in GetAspectByName() so field values can be Invoked too.
 * 					- Fixed subtle bug in RefreshItem() that erased background colors.
 * 2006-11-01  JPP  - Added alternate line colouring
 * 2006-10-20  JPP  - Refactored all sorting comparisons and made it extendable. See ComparerManager.
 *                  - Improved IDE integration
 *                  - Made control DoubleBuffered
 *                  - Added object selection methods
 * 2006-10-13  JPP  Implemented grouping and column sorting
 * 2006-10-09  JPP  Initial version
 * 
 * CONDITIONS OF USE
 * This code may be freely used for non-commerical purposes. Commerical use requires a one-time
 * license fee obtainable from phillip_piper@bigfoot.com. This code must be kept intact, 
 * complete with this header and conditions of use.
 * 
 * Copyright (C) 2006-2007 Phillip Piper
 */

using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Design;
using System.Drawing.Drawing2D;
using System.Globalization;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Prometheus.ThirdParty.Controls
{
  /// <summary>
  /// An object list displays 'aspects' of a collection of objects in a
  /// multi-column list control.
  /// </summary>
  /// <remarks>
  /// <para>The intelligence for this control is in the columns. OLVColumns are
  /// extended so they understand how to fetch an 'aspect' from each row
  /// object. They also understand how to sort by their aspect, and
  /// how to group them.</para>
  /// <para>Aspects are extracted by giving the name of a method to be called or a
  /// property to be fetched. These names can be simple names or they can be dotted
  /// to chain property access e.g. "Owner.Address.Postcode". 
  /// Aspects can also be extracted by installing a delegate.</para>
  /// <para>Sorting by column clicking is handled automatically.
  /// Grouping by column is also handled automatically.</para>
  /// <para>This list puts sort indicators in the column headers to show the column sorting direction.
  /// If you wish to replace the standard images with your own images, put entries in the small image list
  /// with the key values "sort-indicator-up" and "sort-indicator-down".</para>
  /// <para>For these classes to build correctly, the project must have references to these assemblies:
  /// <list>
  /// <item>System.Data</item>
  /// <item>System.Design</item>
  /// <item>System.Drawing</item>
  /// <item>System.Windows.Forms (obviously)</item>
  /// </list>
  /// </para>
  /// </remarks>
  public class ObjectListView : ListView, ISupportInitialize
  {
    /// <summary>
    /// Create an ObjectListView
    /// </summary>
    public ObjectListView()
      : base()
    {
      this.ColumnClick += new ColumnClickEventHandler(this.HandleColumnClick);

      this.View = View.Details;
      this.DoubleBuffered = true; // kill nasty flickers. hiss... me hates 'em
      this.AlternateRowBackColor = Color.Empty;
    }

    #region Public properties

    /// <summary>
    /// Should the list view show images on subitems?
    /// </summary>
    /// <remarks>
    /// <para>Under Windows, this works by sending messages to the underlying
    /// Windows control. To make this work under Mono, we would have to owner drawing the items :-(</para></remarks>
    [Category("Behavior"),
     Description("Should the list view show images on subitems?"),
     DefaultValue(false)]
    public bool ShowImagesOnSubItems
    {
      get { return showImagesOnSubItems; }
      set { showImagesOnSubItems = value; }
    }

    /// <summary>
    /// This property controls whether group labels will be suffixed with a count of items.
    /// </summary>
    /// <remarks>
    /// The format of the suffix is controlled by GroupWithItemCountFormat property
    /// </remarks>
    [Category("Behavior"),
     Description("Will group titles be suffixed with a count of the items in the group?"),
     DefaultValue(false)]
    public bool ShowItemCountOnGroups
    {
      get { return showItemCountOnGroups; }
      set { showItemCountOnGroups = value; }
    }

    /// <summary>
    /// When a group title has an item count, how should the lable be formatted?
    /// </summary>
    /// <remarks>
    /// The given format string can/should have two placeholders:
    /// <list type="bullet">
    /// <item>{0} - the original group title</item>
    /// <item>{1} - the number of items in the group</item>
    /// </list>
    /// </remarks>
    /// <example>"{0} [{1} items]"</example>
    [Category("Behavior"),
     Description("The format to use when suffixing item counts to group titles"),
     DefaultValue(null)]
    public string GroupWithItemCountFormat
    {
      get { return groupWithItemCountFormat; }
      set { groupWithItemCountFormat = value; }
    }

    /// <summary>
    /// Should the list give a different background color to every second row?
    /// </summary>
    /// <remarks><para>The color of the alternate rows is given by AlternateRowBackColor.</para>
    /// <para>There is a "feature" in .NET for listviews in non-full-row-select mode, where
    /// selected rows are not drawn with their correct background color.</para></remarks>
    [Category("Appearance"),
     Description("Should the list view use a different backcolor to alternate rows?"),
     DefaultValue(false)]
    public bool UseAlternatingBackColors
    {
      get { return useAlternatingBackColors; }
      set { useAlternatingBackColors = value; }
    }

    /// <summary>
    /// If every second row has a background different to the control, what color should it be?
    /// </summary>
    [Category("Appearance"),
     Description("If using alternate colors, what color should alterate rows be?")
      //DefaultValue(Color.Empty) // I should be able to do this!
    ]
    public Color AlternateRowBackColor
    {
      get { return alternateRowBackColor; }
      set { alternateRowBackColor = value; }
    }

    /// <summary>
    /// Return the alternate row background color that has been set, or the default color
    /// </summary>
    [Browsable(false)]
    public Color AlternateRowBackColorOrDefault
    {
      get
      {
        if (alternateRowBackColor == Color.Empty)
          return Color.LemonChiffon;
        //					return Color.AliceBlue; // very slight
        else
          return alternateRowBackColor;
      }
    }

    /// <summary>
    /// This delegate can be used to sort the table in a custom fasion.
    /// </summary>
    [Browsable(false),
     DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public SortDelegate CustomSorter
    {
      get { return customSorter; }
      set { customSorter = value; }
    }


    /// <summary>
    /// Get or set whether or not the listview is frozen. When the listview is
    /// frozen, it will not update itself.
    /// </summary>
    /// <remarks><para>The Frozen property is similar to the methods Freeze()/Unfreeze()
    /// except that changes to the Frozen property do not nest.</para></remarks>
    /// <example>objectListView1.Frozen = false; // unfreeze the control regardless of the number of Freeze() calls
    /// </example>
    [Browsable(false),
     DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public bool Frozen
    {
      get { return freezeCount > 0; }
      set
      {
        if (value)
          Freeze();
        else if (freezeCount > 0)
        {
          freezeCount = 1;
          Unfreeze();
        }
      }
    }
    private int freezeCount;

    /// <summary>
    /// Get/set the list of columns that should be used when the list switches to tile view.
    /// </summary>
    /// <remarks>If no list of columns has been installed, this value will default to the
    /// first column plus any column where IsTileViewColumn is true.</remarks>
    [Browsable(false),
     DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public List<OLVColumn> ColumnsForTileView
    {
      get
      {
        if (this.columnsForTileView.Count == 0)
        {
          foreach (ColumnHeader column in this.Columns)
          {
            if (column.Index == 0 || ((OLVColumn)column).IsTileViewColumn)
              this.columnsForTileView.Add((OLVColumn)column);
          }
        }
        return columnsForTileView;
      }
      set { columnsForTileView = value; }
    }
    private List<OLVColumn> columnsForTileView = new List<OLVColumn>();

    /// <summary>
    /// Get the model object from the currently selected row. If no row is selected, or more than one is selected, return null.
    /// Select the row that is displaying the given model object. All other rows are deselected.
    /// </summary>
    [Browsable(false),
     DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public Object SelectedObject
    {
      get { return this.GetSelectedObject(); }
      set { this.SelectObject(value); }
    }

    /// <summary>
    /// Get the model objects from the currently selected rows. If no row is selected, the returned List will be empty.
    /// Select the rows that is displaying the given model objects. All other rows are deselected.
    /// </summary>
    [Browsable(false),
     DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public ArrayList SelectedObjects
    {
      get { return this.GetSelectedObjects(); }
      set { this.SelectObjects(value); }
    }

    /// <summary>
    /// Get/set the style of view that this listview is using
    /// </summary>
    /// <remarks>Switching to tile view installs the columns from ColumnsForTileView property.
    /// Confusingly, in tile view, every column is shown as a row of information.</remarks>
    new public View View
    {
      get
      {
        return base.View;
      }
      set
      {
        if (base.View == value)
          return;

        if (this.Frozen)
        {
          base.View = value;
          return;
        }

        // If we are leaving a details view, remember the columns we had
        if (base.View == View.Details && this.Columns.Count > 0)
        {
          this.columnsToRestore = new List<OLVColumn>();
          foreach (ColumnHeader column in this.Columns)
            this.columnsToRestore.Add((OLVColumn)column);
        }

        this.Freeze();

        // If we are switching to tile view, install our tile columns and set a reasonable default tile size
        if (value == View.Tile)
        {
          if (this.ColumnsForTileView.Count > 0)
          {
            this.Columns.Clear();
            this.Columns.AddRange(this.ColumnsForTileView.ToArray());
          }
          if (this.Columns.Count > 0 && this.TileSize.Width == 0 && this.TileSize.Height == 0)
          {
            int imageHeight = (this.LargeImageList == null ? 16 : this.LargeImageList.ImageSize.Height);
            int dataHeight = (this.Font.Height + 1) * this.Columns.Count;
            this.TileSize = new Size(200, ((imageHeight > dataHeight) ? imageHeight : dataHeight));
          }
          // We changed the columns, so we have to rebuild the list contents
          this.BuildList();
        }

        // If we're switching back to the details view from the tile view,
        // put the original columns back.
        if (value == View.Details && this.columnsToRestore != null)
        {
          this.Columns.Clear();
          this.Columns.AddRange(this.columnsToRestore.ToArray());
          this.columnsToRestore = null;

          // We changed the columns, so we have to rebuild the list contents
          this.BuildList();
        }

        base.View = value;
        this.Unfreeze();
      }
    }
    private List<OLVColumn> columnsToRestore = null;

    #endregion

    #region List commands

    /// <summary>
    /// Set the collection of objects that will be shown in this list view.
    /// </summary>
    /// <remarks>The list is updated immediately</remarks>
    /// <param name="collection">The objects to be displayed</param>
    virtual public void SetObjects(IEnumerable collection)
    {
      this.objects = collection;
      this.BuildList();
    }

    /// <summary>
    /// Build/rebuild all the list view items in the list
    /// </summary>
    virtual public void BuildList()
    {
      if (this.Frozen)
        return;

      this.BeginUpdate();
      this.Items.Clear();
      this.ListViewItemSorter = null;

      if (this.objects != null)
      {
        foreach (object rowObject in this.objects)
        {
          OLVListItem lvi = new OLVListItem(rowObject);
          this.FillInValues(lvi, rowObject);
          this.Items.Add(lvi);
        }
        this.SetAllSubItemImages();
        this.Sort(this.lastSortColumn);
      }

      this.EndUpdate();
    }

    /// <summary>
    /// Sort the items by the last sort column
    /// </summary>
    new public void Sort()
    {
      this.Sort(this.lastSortColumn);
    }

    /// <summary>
    /// Organise the view items into groups, based on the last sort column or the first column
    /// if there is no last sort column
    /// </summary>
    public void BuildGroups()
    {
      this.BuildGroups(this.lastSortColumn);
    }

    /// <summary>
    /// Organise the view items into groups, based on the given column
    /// </summary>
    /// <param name="column">The column whose values should be used for sorting.</param>
    virtual public void BuildGroups(OLVColumn column)
    {
      if (column == null)
        column = (OLVColumn)this.Columns[0];

      this.Groups.Clear();

      // Seperate the list view items into groups, using the group key as the descrimanent
      Dictionary<object, List<OLVListItem>> map = new Dictionary<object, List<OLVListItem>>();
      foreach (OLVListItem olvi in this.Items)
      {
        object key = column.GetGroupKey(olvi.RowObject);
        if (key == null)
          key = "{null}"; // null can't be used as the key for a dictionary
        if (!map.ContainsKey(key))
          map[key] = new List<OLVListItem>();
        map[key].Add(olvi);
      }

      // Make a list of the required groups
      List<ListViewGroup> groups = new List<ListViewGroup>();
      foreach (object key in map.Keys)
      {
        ListViewGroup lvg = new ListViewGroup(column.ConvertGroupKeyToTitle(key));
        lvg.Tag = key;
        groups.Add(lvg);
      }

      // Sort the groups
      groups.Sort(new ListViewGroupComparer(this.lastSortOrder));

      // Put each group into the list view, and give each group its member items.
      // The order of statements is important here:
      // - the header must be calculate before the group is added to the list view,
      //   otherwise changing the header causes a nasty redraw (even in the middle of a BeginUpdate...EndUpdate pair)
      // - the group must be added before it is given items, otherwise an exception is thrown (is this documented?)
      string fmt = this.GroupWithItemCountFormat;
      if (String.IsNullOrEmpty(fmt))
        fmt = "{0} [{1} items]";
      foreach (ListViewGroup group in groups)
      {
        if (this.ShowItemCountOnGroups)
          group.Header = String.Format(fmt, group.Header, map[group.Tag].Count);
        this.Groups.Add(group);
        map[group.Tag].Sort(new ColumnComparer(column, this.lastSortOrder));
        group.Items.AddRange(map[group.Tag].ToArray());
      }
    }

    #endregion

    #region Object manipulation

    /// <summary>
    /// Return the model object of the row that is selected or null if there is no selection or more than one selection
    /// </summary>
    /// <returns>Model object or null</returns>
    virtual public object GetSelectedObject()
    {
      if (this.SelectedItems.Count == 1)
        return ((OLVListItem)this.SelectedItems[0]).RowObject;
      else
        return null;
    }

    /// <summary>
    /// Return the model objects of the rows that are selected or an empty collection if there is no selection
    /// </summary>
    /// <returns>ArrayList</returns>
    virtual public ArrayList GetSelectedObjects()
    {
      ArrayList objects = new ArrayList(this.SelectedItems.Count);
      foreach (ListViewItem lvi in this.SelectedItems)
        objects.Add(((OLVListItem)lvi).RowObject);

      return objects;
    }

    /// <summary>
    /// Select the row that is displaying the given model object. All other rows are deselected.
    /// </summary>
    /// <param name="modelObject">The object to be selected</param>
    virtual public void SelectObject(object modelObject)
    {
      this.SelectedItems.Clear();

      //TODO: If this is too slow, we could keep a map of model object to ListViewItems
      foreach (ListViewItem lvi in this.Items)
      {
        if (((OLVListItem)lvi).RowObject == modelObject)
        {
          lvi.Selected = true;
          break;
        }
      }
    }

    /// <summary>
    /// Select the rows that is displaying any of the given model object. All other rows are deselected.
    /// </summary>
    /// <param name="modelObjects">A collection of model objects</param>
    virtual public void SelectObjects(IList modelObjects)
    {
      this.SelectedItems.Clear();

      //TODO: If this is too slow, we could keep a map of model object to ListViewItems
      foreach (ListViewItem lvi in this.Items)
      {
        if (modelObjects.Contains(((OLVListItem)lvi).RowObject))
          lvi.Selected = true;
      }
    }

    /// <summary>
    /// Update the ListViewItem with the data from its associated model.
    /// </summary>
    /// <remarks>This method does not resort or regroup the view. It simply updates
    /// the displayed data of the given item</remarks>
    virtual public void RefreshItem(OLVListItem olvi)
    {
      // For some reason, clearing the subitems also wipes out the back color,
      // so we need to store it and then put it back again later
      Color c = olvi.BackColor;
      olvi.SubItems.Clear();
      this.FillInValues(olvi, olvi.RowObject);
      this.SetSubItemImages(olvi.Index, olvi);
      olvi.BackColor = c;
    }

    /// <summary>
    /// Update the rows that are showing the given objects
    /// </summary>
    /// <remarks>This method does not resort or regroup the view.</remarks>
    virtual public void RefreshObject(object modelObject)
    {
      this.RefreshObjects(new object[] { modelObject });
    }

    /// <summary>
    /// Update the rows that are showing the given objects
    /// </summary>
    /// <remarks>This method does not resort or regroup the view.</remarks>
    virtual public void RefreshObjects(IList modelObjects)
    {
      foreach (ListViewItem lvi in this.Items)
      {
        OLVListItem olvi = (OLVListItem)lvi;
        if (modelObjects.Contains(olvi.RowObject))
          this.RefreshItem(olvi);
      }
    }

    /// <summary>
    /// Update the rows that are selected
    /// </summary>
    /// <remarks>This method does not resort or regroup the view.</remarks>
    public void RefreshSelectedObjects()
    {
      foreach (ListViewItem lvi in this.SelectedItems)
      {
        OLVListItem olvi = (OLVListItem)lvi;
        this.RefreshItem(olvi);
      }
    }

    #endregion

    #region Freezing

    /// <summary>
    /// Freeze the listview so that it no longer updates itself.
    /// </summary>
    /// <remarks>Freeze()/Unfreeze() calls nest correctly</remarks>
    public void Freeze()
    {
      freezeCount++;
    }

    /// <summary>
    /// Unfreeze the listview. If this call is the outermost Unfreeze(),
    /// the contents of the listview will be rebuilt.
    /// </summary>
    /// <remarks>Freeze()/Unfreeze() calls nest correctly</remarks>
    public void Unfreeze()
    {
      if (freezeCount <= 0)
        return;

      freezeCount--;
      if (freezeCount == 0)
        DoUnfreeze();
    }

    /// <summary>
    /// Do the actual work required when the listview is unfrozen
    /// </summary>
    virtual protected void DoUnfreeze()
    {
      BuildList();
    }

    #endregion

    #region ColumnSorting

    /// <summary>
    /// Event handler for the column click event
    /// </summary>
    protected void HandleColumnClick(object sender, ColumnClickEventArgs e)
    {
      // Toggle the sorting direction on sucessive clicks on the same column
      if (this.lastSortColumn != null && e.Column == this.lastSortColumn.Index)
        this.lastSortOrder = (this.lastSortOrder == SortOrder.Descending ? SortOrder.Ascending : SortOrder.Descending);
      else
        this.lastSortOrder = SortOrder.Ascending;

      this.BeginUpdate();
      this.Sort(e.Column);
      this.EndUpdate();
    }

    /// <summary>
    /// Sort the items in the list view by the values in the given column.
    /// If ShowGroups is true, the rows will be grouped by the given column,
    /// otherwise, it will be a straight sort.
    /// </summary>
    /// <param name="columnToSortIndex">The index of the column whose values will be used for the sorting</param>
    public void Sort(int columnToSortIndex)
    {
      if (columnToSortIndex >= 0 && columnToSortIndex < this.Columns.Count)
        this.Sort(this.Columns[columnToSortIndex] as OLVColumn);
    }

    /// <summary>
    /// Sort the items in the list view by the values in the given column.
    /// If ShowGroups is true, the rows will be grouped by the given column,
    /// otherwise, it will be a straight sort.
    /// </summary>
    /// <param name="columnToSort">The column whose values will be used for the sorting</param>
    public void Sort(OLVColumn columnToSort)
    {
      if (columnToSort == null)
        columnToSort = (OLVColumn)this.Columns[0];

      if (lastSortOrder == SortOrder.None)
        lastSortOrder = this.Sorting;

      if (this.ShowGroups)
        this.BuildGroups(columnToSort);
      else if (this.CustomSorter != null)
        this.CustomSorter(columnToSort, lastSortOrder);
      else
        this.ListViewItemSorter = new ColumnComparer(columnToSort, lastSortOrder);

      this.ShowSortIndicator(columnToSort, lastSortOrder);

      if (this.UseAlternatingBackColors && this.View == View.Details)
        PrepareAlternateBackColors();

      this.lastSortColumn = columnToSort;
    }

    /// <summary>
    /// Put a sort indicator next to the text of the given given column
    /// </summary>
    /// <param name="columnToSort">The column to be marked</param>
    /// <param name="sortOrder">The sort order in effect on that column</param>
    protected void ShowSortIndicator(OLVColumn columnToSort, SortOrder sortOrder)
    {
      MakeSortIndictorImages();

      // Remove all previous sort indicators
      for (int i = 0; i < this.Columns.Count; i++)
        ListViewNative.SetColumnImage(this, i, -1);

      // Find the index of the sort indicator we want to use.
      // SortOrder.None doesn't show an image.
      int imageIndex = -1;
      if (sortOrder == SortOrder.Ascending)
        imageIndex = this.SmallImageList.Images.IndexOfKey(SORT_INDICATOR_UP_KEY);
      else if (sortOrder == SortOrder.Descending)
        imageIndex = this.SmallImageList.Images.IndexOfKey(SORT_INDICATOR_DOWN_KEY);

      ListViewNative.SetColumnImage(this, columnToSort.Index, imageIndex);
    }

    private const string SORT_INDICATOR_UP_KEY = "sort-indicator-up";
    private const string SORT_INDICATOR_DOWN_KEY = "sort-indicator-down";

    /// <summary>
    /// If the sort indicator images don't already exist, this method will make and install them
    /// </summary>
    protected void MakeSortIndictorImages()
    {
      ImageList il = this.SmallImageList;
      if (il == null)
      {
        il = this.SmallImageList = new ImageList();
        il.ImageSize = new Size(16, 16);
      }

      // This arrangement of points works well with (16,16) images, and OK with others
      int midX = il.ImageSize.Width / 2;
      int midY = (il.ImageSize.Height / 2) - 1;
      int deltaX = midX - 2;
      int deltaY = deltaX / 2;

      if (il.Images.IndexOfKey(SORT_INDICATOR_UP_KEY) == -1)
      {
        Point pt1 = new Point(midX - deltaX, midY + deltaY);
        Point pt2 = new Point(midX, midY - deltaY - 1);
        Point pt3 = new Point(midX + deltaX, midY + deltaY);
        il.Images.Add(SORT_INDICATOR_UP_KEY, this.MakeTriangleBitmap(il.ImageSize, new Point[] { pt1, pt2, pt3 }));
      }

      if (il.Images.IndexOfKey(SORT_INDICATOR_DOWN_KEY) == -1)
      {
        Point pt1 = new Point(midX - deltaX, midY - deltaY);
        Point pt2 = new Point(midX, midY + deltaY);
        Point pt3 = new Point(midX + deltaX, midY - deltaY);
        il.Images.Add(SORT_INDICATOR_DOWN_KEY, this.MakeTriangleBitmap(il.ImageSize, new Point[] { pt1, pt2, pt3 }));
      }
    }

    private Bitmap MakeTriangleBitmap(Size sz, Point[] pts)
    {
      Bitmap bm = new Bitmap(sz.Width, sz.Height);
      Graphics g = Graphics.FromImage(bm);
      g.FillPolygon(new SolidBrush(Color.Gray), pts);
      return bm;
    }

    #endregion

    #region Utilities

    /// <summary>
    /// Fill in the given OLVListItem with values of the given row
    /// </summary>
    /// <param name="lvi">the OLVListItem that is to be stuff with values</param>
    /// <param name="rowObject">the model object from which values will be taken</param>
    protected void FillInValues(OLVListItem lvi, object rowObject)
    {
      if (this.Columns.Count == 0)
        return;

      OLVColumn column = (OLVColumn)this.Columns[0];
      lvi.Text = column.GetStringValue(rowObject);
      lvi.ImageSelector = column.GetImage(rowObject);

      for (int i = 1; i < this.Columns.Count; i++)
      {
        column = (OLVColumn)this.Columns[i];
        lvi.SubItems.Add(new OLVListSubItem(column.GetStringValue(rowObject),
                                            column.GetImage(rowObject)));
      }
    }

    /// <summary>
    /// Setup all subitem images on all rows
    /// </summary>
    protected void SetAllSubItemImages()
    {
      if (!this.ShowImagesOnSubItems || this.OwnerDraw)
        return;

      this.ForceSubItemImagesExStyle();

      for (int rowIndex = 0; rowIndex < this.Items.Count; rowIndex++)
        SetSubItemImages(rowIndex, (OLVListItem)this.Items[rowIndex]);
    }

    /// <summary>
    /// Tell the underlying list control which images to show against the subitems
    /// </summary>
    /// <param name="rowIndex">the index at which the item occurs</param>
    /// <param name="item">the item whose subitems are to be set</param>
    /// <remarks>When we are owner drawing, this method is a no-op since
    /// we draw the images ourself.</remarks>
    protected void SetSubItemImages(int rowIndex, OLVListItem item)
    {
      if (!this.ShowImagesOnSubItems || this.OwnerDraw)
        return;

      int imageIndex;

      for (int i = 1; i < item.SubItems.Count; i++)
      {
        imageIndex = this.GetActualImageIndex(((OLVListSubItem)item.SubItems[i]).ImageSelector);
        if (imageIndex != -1)
          this.SetSubItemImage(rowIndex, i, imageIndex);
      }
    }

    /// <summary>
    /// Prepare the listview to show alternate row backcolors
    /// </summary>
    /// <remarks>When groups are shown, the ordering of list items is different.
    /// In a straight list, <code>lvi.Index</code> is the display index, and can be used to determine
    /// whether the row should be colored. But when organised by groups, <code>lvi.Index</code> is not
    /// useable because it still refers to the position in the overall list, not the display order.
    /// So we have to walk each group and then the items in each group, counting as we go, to know
    /// at which row an item will be shown (and therefore how it should be back colored).</remarks>
    virtual protected void PrepareAlternateBackColors()
    {
      Color rowBackColor = this.AlternateRowBackColorOrDefault;

      if (this.ShowGroups)
      {
        int i = 0;
        foreach (ListViewGroup group in this.Groups)
        {
          foreach (ListViewItem lvi in group.Items)
          {
            if (i % 2 == 0)
              lvi.BackColor = this.BackColor;
            else
              lvi.BackColor = rowBackColor;
            i++;
          }
        }
      }
      else
      {
        foreach (ListViewItem lvi in this.Items)
        {
          if (lvi.Index % 2 == 0)
            lvi.BackColor = this.BackColor;
          else
            lvi.BackColor = rowBackColor;
        }
      }
    }

    /// <summary>
    /// Convert the given image selector to an index into our image list.
    /// Return -1 if that's not possible
    /// </summary>
    /// <param name="imageSelector"></param>
    /// <returns>Index of the image in the imageList, or -1</returns>
    public int GetActualImageIndex(Object imageSelector)
    {
      if (imageSelector == null)
        return -1;

      if (imageSelector is Int32)
        return (int)imageSelector;

      if (imageSelector is String && this.SmallImageList != null)
        return this.SmallImageList.Images.IndexOfKey((String)imageSelector);

      return -1;
    }

    /// <summary>
    /// Make sure the ListView has the extended style that says to display subitem images.
    /// </summary>
    /// <remarks>This method must be called after any .NET call that update the extended styles
    /// since they seem to erase this setting.</remarks>
    protected void ForceSubItemImagesExStyle()
    {
      ListViewNative.ForceSubItemImagesExStyle(this);
    }

    /// <summary>
    /// For the given item and subitem, make it display the given image
    /// </summary>
    /// <param name="itemIndex">row number (0 based)</param>
    /// <param name="subItemIndex">subitem (0 is the item itself)</param>
    /// <param name="imageIndex">index into the image list</param>
    protected void SetSubItemImage(int itemIndex, int subItemIndex, int imageIndex)
    {
      ListViewNative.SetSubItemImage(this, itemIndex, subItemIndex, imageIndex);
    }

    #endregion

    #region ISupportInitialize Members

    void ISupportInitialize.BeginInit()
    {
      this.Frozen = true;
    }

    void ISupportInitialize.EndInit()
    {
      this.Frozen = false;
      this.MakeSortIndictorImages();
    }

    #endregion

    #region Owner drawing

    /// <summary>
    /// Owner draw the column header
    /// </summary>
    /// <param name="e"></param>
    protected override void OnDrawColumnHeader(DrawListViewColumnHeaderEventArgs e)
    {
      e.DrawDefault = true;
      base.OnDrawColumnHeader(e);
    }

    /// <summary>
    /// Owner draw the item
    /// </summary>
    /// <param name="e"></param>
    protected override void OnDrawItem(DrawListViewItemEventArgs e)
    {
      e.DrawDefault = (this.View != View.Details);
      base.OnDrawItem(e);
    }

    int[] columnRightEdge = new int[128]; // will anyone ever want more than 128 columns??

    /// <summary>
    /// Owner draw a single subitem
    /// </summary>
    /// <param name="e"></param>
    protected override void OnDrawSubItem(DrawListViewSubItemEventArgs e)
    {
      // Get the special renderer for this column. 
      // If there isn't one, don't draw anything.
      OLVColumn column = (OLVColumn)this.Columns[e.ColumnIndex];
      if (column.RendererDelegate == null)
        return;

      // Calculate where the subitem should be drawn
      // It should be as simple as 'e.Bounds', but it isn't :-(

      // There seems to be a bug in .NET where the left edge of the bounds of subitem 0
      // is always 0. This is normally what is required, but it's wrong when
      // someone drags column 0 to somewhere else in the listview. We could
      // drop down into Windows-ville and use LVM_GETSUBITEMRECT, but I'm specifically
      // avoiding Windows dependencies -- Mono-ready, I guess.
      // So, we keep track of the right edge of all columns, and when subitem 0
      // isn't being shown at column 0, we make its left edge to be the right
      // edge of the previous column plus a little bit.
      Rectangle r = e.Bounds;
      if (e.ColumnIndex == 0 && e.Header.DisplayIndex != 0)
      {
        r.X = this.columnRightEdge[e.Header.DisplayIndex - 1] + 1;
      }
      else
        //TODO: Check the size of columnRightEdge and dynamically reallocate?
        this.columnRightEdge[e.Header.DisplayIndex] = e.Bounds.Right;

      // Get a graphics context for the renderer to use. 
      // But we have more complications. Virtual lists have a nasty habit of drawing column 0
      // whenever there is any mouse move events over a row, and doing it in an un-double buffered manner,
      // which results in nasty flickers! There are also some unbuffered draw when a mouse is first
      // hovered over column 0 of a normal row. So, to avoid all complications,
      // we always manually double-buffer the drawing.
      Graphics g;
      BufferedGraphics buffer = null;
      bool avoidFlickerMode = true; // set this to false to see the probems with flicker
      if (avoidFlickerMode)
      {
        buffer = BufferedGraphicsManager.Current.Allocate(e.Graphics, r);
        g = buffer.Graphics;
      }
      else
        g = e.Graphics;

      // Finally, give the renderer a chance to draw something
      Object row = ((OLVListItem)e.Item).RowObject;
      column.RendererDelegate(e, g, r, row);

      if (buffer != null)
      {
        buffer.Render();
        buffer.Dispose();
      }
    }

    #endregion

    #region Design Time

    /// <summary>
    /// This class works in conjunction with the OLVColumns property to allow OLVColumns
    /// to be added to the ObjectListView.
    /// </summary>
    internal class OLVColumnCollectionEditor : System.ComponentModel.Design.CollectionEditor
    {
      public OLVColumnCollectionEditor(Type t)
        : base(t)
      {
      }

      protected override Type CreateCollectionItemType()
      {
        return typeof(OLVColumn);
      }
    }

    /// <summary>
    /// Return Columns for this list. We hide the original so we can associate
    /// a specialised editor with it.
    /// </summary>
    [Editor(typeof(OLVColumnCollectionEditor), typeof(System.Drawing.Design.UITypeEditor))]
    new public ListView.ColumnHeaderCollection Columns
    {
      get
      {
        return base.Columns;
      }
    }

    #endregion

    private IEnumerable objects; // the collection of objects on show
    private OLVColumn lastSortColumn; // which column did we last sort by
    private bool showImagesOnSubItems; // should we try to show images on subitems?
    private SortOrder lastSortOrder; // which direction did we last sort
    private bool showItemCountOnGroups; // should we show items count in group labels?
    private string groupWithItemCountFormat; // when a group title has an item count, how should the label be formatted?
    private bool useAlternatingBackColors; // should we use different colors for alternate lines?
    private Color alternateRowBackColor; // what color background should alternate lines have?
    private SortDelegate customSorter; // callback for handling custom sort by column processing

  }

  /// <summary>
  /// Wrapper for all native method calls on ListView controls
  /// </summary>
  internal class ListViewNative
  {

    private const int LVM_SETEXTENDEDLISTVIEWSTYLE = 0x1000 + 54; // LVM_FIRST + 54
    private const int LVM_SETITEM = 0x1000 + 76; // LVM_FIRST + 76
    private const int LVM_GETCOLUMN = 0x1000 + 95; // LVM_FIRST + 95
    private const int LVM_SETCOLUMN = 0x1000 + 96; // LVM_FIRST + 96
    private const int LVS_EX_SUBITEMIMAGES = 0x0002;

    private const int LVIF_TEXT = 0x0001;
    private const int LVIF_IMAGE = 0x0002;
    private const int LVIF_PARAM = 0x0004;
    private const int LVIF_STATE = 0x0008;
    private const int LVIF_INDENT = 0x0010;
    private const int LVIF_NORECOMPUTE = 0x0800;

    private const int LVCF_FMT = 0x0001;
    private const int LVCF_WIDTH = 0x0002;
    private const int LVCF_TEXT = 0x0004;
    private const int LVCF_SUBITEM = 0x0008;
    private const int LVCF_IMAGE = 0x0010;
    private const int LVCF_ORDER = 0x0020;
    private const int LVCFMT_LEFT = 0x0000;
    private const int LVCFMT_RIGHT = 0x0001;
    private const int LVCFMT_CENTER = 0x0002;
    private const int LVCFMT_JUSTIFYMASK = 0x0003;

    private const int LVCFMT_IMAGE = 0x0800;
    private const int LVCFMT_BITMAP_ON_RIGHT = 0x1000;
    private const int LVCFMT_COL_HAS_IMAGES = 0x8000;

    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
    private struct LVITEM
    {
      public int mask;
      public int iItem;
      public int iSubItem;
      public int state;
      public int stateMask;
      [MarshalAs(UnmanagedType.LPTStr)]
      public string pszText;
      public int cchTextMax;
      public int iImage;
      public int lParam;
      // These are available in Common Controls >= 0x0300
      public int iIndent;
      // These are available in Common Controls >= 0x056
      public int iGroupId;
      public int cColumns;
      public IntPtr puColumns;
    };

    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
    private struct LVCOLUMN
    {
      public int mask;
      public int fmt;
      public int cx;
      [MarshalAs(UnmanagedType.LPTStr)]
      public string pszText;
      public int cchTextMax;
      public int iSubItem;
      // These are available in Common Controls >= 0x0300
      public int iImage;
      public int iOrder;
    };

    // Three different imports of SendMessage: 
    // 1) plain vanilla; 
    // 2) passes a references to LVITEM
    // 3) passes a references to LVCOLUMN
    [DllImport("user32.dll", CharSet = CharSet.Auto)]
    private static extern IntPtr SendMessage(IntPtr hWnd, int msg, int wParam, int lParam);
    [DllImport("user32.dll", EntryPoint = "SendMessage", CharSet = CharSet.Auto)]
    private static extern IntPtr SendMessageLVItem(IntPtr hWnd, int msg, int wParam, ref LVITEM lvi);
    [DllImport("user32.dll", EntryPoint = "SendMessage", CharSet = CharSet.Auto)]
    private static extern IntPtr SendMessageLVColumn(IntPtr hWnd, int msg, int wParam, ref LVCOLUMN lvc);

    /// <summary>
    /// Make sure the ListView has the extended style that says to display subitem images.
    /// </summary>
    /// <remarks>This method must be called after any .NET call that update the extended styles
    /// since they seem to erase this setting.</remarks>
    /// <param name="list">The listview to send a message to</param>
    public static void ForceSubItemImagesExStyle(ListView list)
    {
      SendMessage(list.Handle, LVM_SETEXTENDEDLISTVIEWSTYLE, LVS_EX_SUBITEMIMAGES, LVS_EX_SUBITEMIMAGES);
    }

    /// <summary>
    /// For the given item and subitem, make it display the given image
    /// </summary>
    /// <param name="list">The listview to send a message to</param>
    /// <param name="itemIndex">row number (0 based)</param>
    /// <param name="subItemIndex">subitem (0 is the item itself)</param>
    /// <param name="imageIndex">index into the image list</param>
    public static void SetSubItemImage(ListView list, int itemIndex, int subItemIndex, int imageIndex)
    {
      LVITEM lvItem = new LVITEM();
      lvItem.mask = LVIF_IMAGE;
      lvItem.iItem = itemIndex;
      lvItem.iSubItem = subItemIndex;
      lvItem.iImage = imageIndex;
      SendMessageLVItem(list.Handle, LVM_SETITEM, 0, ref lvItem);
    }

    /// <summary>
    /// Setup the given column of the listview to show the given image to the right of the text.
    /// If the image index is -1, any previous image is cleared
    /// </summary>
    /// <param name="list">The listview to send a message to</param>
    /// <param name="columnIndex">Index of the column to modifiy</param>
    /// <param name="imageIndex">Index into the small image list</param>
    public static void SetColumnImage(ListView list, int columnIndex, int imageIndex)
    {
      LVCOLUMN lvColumn = new LVCOLUMN();

      // Get the columns current format
      lvColumn.mask = LVCF_FMT;
      IntPtr result = SendMessageLVColumn(list.Handle, LVM_GETCOLUMN, columnIndex, ref lvColumn);
      if (result.ToInt32() == 0)
        return;

      // Tell it to show an image on the right, or remove it altogether
      lvColumn.mask = LVCF_FMT | LVCF_IMAGE;
      if (imageIndex == -1)
        lvColumn.fmt &= ~(LVCFMT_IMAGE | LVCFMT_BITMAP_ON_RIGHT);
      else
        lvColumn.fmt |= (LVCFMT_IMAGE | LVCFMT_BITMAP_ON_RIGHT);
      lvColumn.iImage = imageIndex;
      result = SendMessageLVColumn(list.Handle, LVM_SETCOLUMN, columnIndex, ref lvColumn);
    }
  }

  /// <summary>
  /// A virtual object list view operates in virtual mode, that is, it only gets model objects for
  /// a row when it is needed. This gives it the ability to handle very large numbers of rows with
  /// minimal resources.
  /// </summary>
  /// <remarks><para>A listview is not a great user interface for a large number of items. But if you've
  /// ever wanted to have a list with 10 million items, go ahead, knock yourself out.</para>
  /// <para>Virtual lists can never iterate their contents. That would defeat the whole purpose.</para>
  /// <para>Given the above, sorting is not possible on virtual lists. But if the backing data store has
  /// a sorting mechanism, a CustomSorter can be installed which will be called when the sorting is required.</para>
  /// </remarks>
  public class VirtualObjectListView : ObjectListView
  {
    /// <summary>
    /// Create a VirtualObjectListView
    /// </summary>
    public VirtualObjectListView()
      : base()
    {
      this.VirtualMode = true;
      this.RetrieveVirtualItem += new RetrieveVirtualItemEventHandler(this.HandleRetrieveVirtualItem);

      // Turn off sorting. Who wants to fetch and sort 10 million items?
      this.CustomSorter = delegate(OLVColumn column, SortOrder sortOrder) { };
    }

    #region Public Properties

    /// <summary>
    /// This delegate is used to fetch a rowObject, given it's index within the list
    /// </summary>
    public RowGetterDelegate RowGetter
    {
      get { return rowGetter; }
      set { rowGetter = value; }
    }

    #endregion

    #region Object manipulation

    /// <summary>
    /// Return the model object of the row that is selected or null if there is no selection or more than one selection
    /// </summary>
    /// <returns>Model object or null</returns>
    override public object GetSelectedObject()
    {
      if (this.SelectedIndices.Count == 1)
        return this.GetRowObjectAt(this.SelectedIndices[0]);
      else
        return null;
    }

    /// <summary>
    /// Return the model objects of the rows that are selected or an empty collection if there is no selection
    /// </summary>
    /// <returns>ArrayList</returns>
    override public ArrayList GetSelectedObjects()
    {
      ArrayList objects = new ArrayList(this.SelectedIndices.Count);
      foreach (int index in this.SelectedIndices)
        objects.Add(this.GetRowObjectAt(index));

      return objects;
    }

    /// <summary>
    /// Select the row that is displaying the given model object.
    /// This does nothing in virtual lists.
    /// </summary>
    /// <remarks>This is a no-op for virtual lists, since there is no way to map the model
    /// object back to the ListViewItem that represents it.</remarks>
    /// <param name="modelObject">The object that gave data</param>
    override public void SelectObject(object modelObject)
    {
      // do nothing
    }

    /// <summary>
    /// Select the rows that is displaying any of the given model object.
    /// This does nothing in virtual lists.
    /// </summary>
    /// <remarks>This is a no-op for virtual lists, since there is no way to map the model
    /// objects back to the ListViewItem that represents them.</remarks>
    /// <param name="modelObjects">A collection of model objects</param>
    override public void SelectObjects(IList modelObjects)
    {
      // do nothing
    }

    #endregion

    /// <summary>
    /// Prepare the listview to show alternate row backcolors
    /// </summary>
    /// <remarks>Alternate colored backrows can't be handle in the same way as our base class.
    /// With virtual lists, they are handled at RetrieveVirtualItem time.</remarks>
    protected override void PrepareAlternateBackColors()
    {
      // do nothing
    }

    #region Event handlers

    /// <summary>
    /// Handle a RetrieveVirtualItem
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void HandleRetrieveVirtualItem(object sender, RetrieveVirtualItemEventArgs e)
    {
      // .NET 2.0 seems to generate a lot of these events. Before drawing *each* sub-item,
      // this event is triggered 4-8 times for the same index. So we save lots of CPU time
      // by caching the last result.
      if (this.lastRetrieveVirtualItemIndex != e.ItemIndex)
      {
        this.lastRetrieveVirtualItemIndex = e.ItemIndex;
        this.lastRetrieveVirtualItem = this.MakeListViewItem(e.ItemIndex);
      }
      e.Item = this.lastRetrieveVirtualItem;
    }

    /// <summary>
    /// Create a OLVListItem for given row index
    /// </summary>
    /// <param name="itemIndex">The index of the row that is needed</param>
    /// <returns>An OLVListItem</returns>
    protected OLVListItem MakeListViewItem(int itemIndex)
    {
      OLVListItem olvi = new OLVListItem(this.GetRowObjectAt(itemIndex));
      this.FillInValues(olvi, olvi.RowObject);
      if (this.UseAlternatingBackColors && this.View == View.Details && itemIndex % 2 == 1)
        olvi.BackColor = this.AlternateRowBackColorOrDefault;
      else
        olvi.BackColor = this.BackColor;
      this.SetSubItemImages(itemIndex, olvi);
      return olvi;
    }

    /// <summary>
    /// Return the row object for the given row index
    /// </summary>
    /// <param name="index">index of the row whose object is to be fetched</param>
    /// <returns>A model object or null if no delegate is installed</returns>
    protected object GetRowObjectAt(int index)
    {
      if (this.RowGetter == null)
        return null;
      else
        return this.RowGetter(index);
    }

    #endregion

    #region Variable declaractions

    private RowGetterDelegate rowGetter;
    private int lastRetrieveVirtualItemIndex = -1;
    private OLVListItem lastRetrieveVirtualItem;

    #endregion
  }

  /// <summary>
  /// A DataListView is specialised to show the contents of a data source, which would normally be a DataTable or DataView.
  /// </summary>
  /// <remarks><para>This listview keeps itself in sync with its source datatable by listening for change events on the data view.</para>
  /// <para>If the listview has no columns when given a data source, it will automatically create columns to show all of the datatables columns.
  /// This will be only the simpliest view of the world, and would look more interesting with a few delegates installed.</para>
  /// <para>This listview will also automatically generate missing aspect getters to fetch the values from the data view.</para>
  /// <para>Changing data sources is possible, but error prone. Before changing data sources, the programmer is responsible for modifying/resetting
  /// the column collection to be valid for the new data source.</para>
  /// </remarks>
  public class DataListView : ObjectListView
  {
    /// <summary>
    /// Make a DataListView
    /// </summary>
    public DataListView()
      : base()
    {
      this.bindingSource = new BindingSource();
      this.bindingSource.ListChanged += new ListChangedEventHandler(OnListChanged);
    }

    #region Public Properties

    /// <summary>
    /// Get or set the DataSource that will be displayed in this list view.
    /// </summary>
    /// <remarks>The DataSource can be one of the following types of objects:
    /// <list type="unordered">
    /// <item>A DataView</item>
    /// <item>A DataTable</item>
    /// <item>A DataSet</item>
    /// <item>A DataViewManager</item>
    /// <item>A BindingSource</item>
    /// <item>plus possibly other data sources I haven't been able to test :-)</item>
    /// </list>
    /// <para>This property is not quite orthagonal. If you set it to a BindingSource, the value returned
    /// is the data source for the binding source, not the BindingSource itself.</para>
    /// </remarks>
    [Category("Data"),
     RefreshProperties(RefreshProperties.Repaint),
     DefaultValue((string)null),
     AttributeProvider(typeof(IListSource))]
    public Object DataSource
    {
      get { return dataSource; }
      set
      {
        if (dataSource != value)
        {
          dataSource = value;
          this.RebindDataSource(value);
        }
      }
    }
    private Object dataSource;
    private BindingSource bindingSource;

    /// <summary>
    /// Gets or sets the name of the list or table in the data source for which the DataListView is displaying data.
    /// </summary>
    /// <remarks>If the data source is not a DataSet or DataViewManager, this property has no effect</remarks>
    [Category("Data"),
     Editor("System.Windows.Forms.Design.DataMemberListEditor, System.Design, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", typeof(UITypeEditor)),
     DefaultValue("")]
    public string DataMember
    {
      get { return bindingSourceDataMember; }
      set
      {
        if (bindingSourceDataMember != value)
        {
          bindingSourceDataMember = value;
          RebindDataSource(this.bindingSource);
        }
      }
    }
    private string bindingSourceDataMember = "";

    #endregion

    #region Initialization

    /// <summary>
    /// Our data source has changed. Figure out how to handle the new source
    /// </summary>
    /// <param name="newSource">Our new source of data</param>
    protected void RebindDataSource(Object newSource)
    {
      if (this.bindingSource != null)
        this.bindingSource.ListChanged -= new ListChangedEventHandler(OnListChanged);

      // If the new source is a BindingSource, we keep a reference to it directly,
      // otherwise we create a new BindingSource to wrap the given datasource.
      if (newSource is BindingSource)
      {
        this.bindingSource = (BindingSource)newSource;
        if (!String.IsNullOrEmpty(this.bindingSourceDataMember))
          this.bindingSource.DataMember = this.bindingSourceDataMember;
      }
      else
      {
        try
        {
          this.bindingSource = new BindingSource(newSource, this.bindingSourceDataMember);
        }
        catch (ArgumentException)
        {
          this.bindingSource = new BindingSource(newSource, "");
        }
      }
      if (this.bindingSource != null)
      {
        this.bindingSource.ListChanged += new ListChangedEventHandler(OnListChanged);
      }
      InitializeDataSource();
    }

    /// <summary>
    /// The data source for this control has changed. Reconfigure the control for the new source
    /// </summary>
    protected void InitializeDataSource()
    {
      if (this.Frozen || this.bindingSource == null)
        return;

      // Can we figure out what our source of data is?
      Object sourceList = this.bindingSource.List;

      // If the source is a format we recognize, try to automatically configure the columns.
      // If we don't recognize the source, remove our auto generated aspect getters, since they
      // are certainly wrong.
      if (sourceList is DataTable)
      {
        CreateColumnsFromDataTable((DataTable)sourceList);
        CreateMissingAspectGetters(false);
      }
      else if (sourceList is DataView)
      {
        CreateColumnsFromDataTable(((DataView)sourceList).Table);
        CreateMissingAspectGetters(true);
      }
      else
        RemoveAutoGeneratedAspectGetters();

      this.SetObjects((IEnumerable)sourceList);
    }

    /// <summary>
    /// Create columns for the listview based on what columns are available in the datatable
    /// </summary>
    protected void CreateColumnsFromDataTable(DataTable table)
    {
      if (table == null || this.Columns.Count != 0)
        return;

      foreach (DataColumn dataColumn in table.Columns)
      {
        OLVColumn column = new OLVColumn(dataColumn.Caption, dataColumn.ColumnName);
        this.Columns.Add(column);
        if (dataColumn.DataType == typeof(System.Byte[]))
          column.Renderer = new ImageRenderer();
      }
    }

    /// <summary>
    /// Create aspect getters that will retrieve a column's value, for any column that doesn't
    /// already have an aspect getter.
    /// </summary>
    protected void CreateMissingAspectGetters(bool isForDataView)
    {
      foreach (ColumnHeader ch in this.Columns)
      {
        OLVColumn column = (OLVColumn)ch;
        if ((column.AspectGetter == null || column.AspectGetterAutoGenerated) && !String.IsNullOrEmpty(column.AspectName))
          CreateAspectGetter(column, isForDataView);
      }
    }

    /// <summary>
    /// For the given column, install an aspect getter that will fetch the related column
    /// value from the data row.
    /// </summary>
    /// <param name="column">The OLVColumn for which an aspect getter will be created</param>
    /// <param name="isForDataView">Should the generated aspect getter assume that the row is a DataViewRow</param>
    protected void CreateAspectGetter(OLVColumn column, bool isForDataView)
    {
      if (isForDataView)
      {
        column.AspectGetter = delegate(object row)
        {
          try
          {
            return ((DataRowView)row)[column.AspectName];
          }
          catch (ArgumentException)
          {
            return String.Format("No data column '{0}'", column.AspectName);
          }
        };
      }
      else
      {
        column.AspectGetter = delegate(object row)
        {
          try
          {
            return ((DataRow)row)[column.AspectName];
          }
          catch (ArgumentException)
          {
            return String.Format("No data column '{0}'", column.AspectName);
          }
        };
      }
      column.AspectGetterAutoGenerated = true;
    }

    /// <summary>
    /// Remove all autogenerated aspect getters
    /// </summary>
    protected void RemoveAutoGeneratedAspectGetters()
    {
      foreach (ColumnHeader ch in this.Columns)
      {
        OLVColumn column = (OLVColumn)ch;
        if (column.AspectGetterAutoGenerated)
          column.AspectGetter = null;
      }
    }

    #endregion

    #region Event Handlers

    /// <summary>
    /// Handle a ListChanged event
    /// </summary>
    protected void OnListChanged(object sender, ListChangedEventArgs args)
    {
      if (this.Frozen ||
          args.ListChangedType == ListChangedType.PropertyDescriptorAdded ||
          args.ListChangedType == ListChangedType.PropertyDescriptorChanged ||
          args.ListChangedType == ListChangedType.PropertyDescriptorDeleted)
        return;

      if (args.ListChangedType == ListChangedType.Reset)
        this.InitializeDataSource();
      else
        this.SetObjects(this.bindingSource.List);
    }

    /// <summary>
    /// What should we do when the list is unfrozen
    /// </summary>
    override protected void DoUnfreeze()
    {
      InitializeDataSource();
    }

    #endregion

  }

  #region Delegate declarations

  /// <summary>
  /// These delegates are used to extract an aspect from a row object
  /// </summary>
  public delegate object AspectGetterDelegate(object rowObject);

  /// <summary>
  /// These delegates are used to fetch the image selector that should be used
  /// to choose an image for this column.
  /// </summary>
  public delegate Object ImageGetterDelegate(object rowObject);

  /// <summary>
  /// These delegates can be used to convert an aspect value to a display string,
  /// instead of using the default ToString()
  /// </summary>
  public delegate string AspectToStringConverterDelegate(object value);

  /// <summary>
  /// These delegates are used to retrieve the object that is the key of the group to which the given row belongs.
  /// </summary>
  public delegate object GroupKeyGetterDelegate(object rowObject);

  /// <summary>
  /// These delegates are used to convert a group key into a title for the group
  /// </summary>
  public delegate string GroupKeyToTitleConverterDelegate(object groupKey);

  /// <summary>
  /// These delegates are used to fetch a row object for virtual lists
  /// </summary>
  public delegate object RowGetterDelegate(int rowIndex);

  /// <summary>
  /// These delegates are used to sort the listview in some custom fashion
  /// </summary>
  public delegate void SortDelegate(OLVColumn column, SortOrder sortOrder);

  /// <summary>
  /// These delegates are used to draw a cell
  /// </summary>
  public delegate void RenderDelegate(DrawListViewSubItemEventArgs e, Graphics g, Rectangle r, Object rowObject);

  #endregion

  #region Column

  /// <summary>
  /// An OLVColumn knows which aspect of an object it should present.
  /// </summary>
  /// <remarks>
  /// The column knows how to:
  /// <list type="bullet">
  ///	<item>extract its aspect from the row object</item>
  ///	<item>convert an aspect to a string</item>
  ///	<item>calculate the image for the row object</item>
  ///	<item>extract a group "key" from the row object</item>
  ///	<item>convert a group "key" into a title for the group</item>
  /// </list>
  /// <para>For sorting to work correctly, aspects from the same column
  /// must be of the same type, that is, the same aspect cannot sometimes
  /// return strings and other times integers.</para>
  /// </remarks>
  [Browsable(false)]
  public class OLVColumn : ColumnHeader
  {
    /// <summary>
    /// Create an OLVColumn
    /// </summary>
    public OLVColumn()
      : base()
    {
      this.Renderer = new BaseRenderer();
    }

    /// <summary>
    /// Initialize a column to have the given title, and show the given aspect
    /// </summary>
    /// <param name="title">The title of the column</param>
    /// <param name="aspect">The aspect to be shown in the column</param>
    public OLVColumn(string title, string aspect)
      : this()
    {
      this.Text = title;
      this.AspectName = aspect;
    }

    #region Public Properties

    /// <summary>
    /// The name of the property or method that should be called to get the value to display in this column.
    /// This is only used if a ValueGetterDelegate has not been given.
    /// </summary>
    [Category("Behavior"),
     Description("The name of the property or method that should be called to get the aspect to display in this column")]
    public string AspectName
    {
      get { return aspectName; }
      set { aspectName = value; }
    }

    /// <summary>
    /// This format string will be used to convert an aspect to its string representation.
    /// </summary>
    /// <remarks>
    /// This string is passed as the first parameter to the String.Format() method.
    /// This is only used if ToStringDelegate has not been set.</remarks>
    /// <example>"{0:C}" to convert a number to currency</example>
    [Category("Behavior"),
     Description("The format string that will be used to convert an aspect to its string representation"),
     DefaultValue(null)]
    public string AspectToStringFormat
    {
      get { return aspectToStringFormat; }
      set { aspectToStringFormat = value; }
    }

    /// <summary>
    /// Group objects by the initial letter of the aspect of the column
    /// </summary>
    /// <remarks>
    /// One common pattern is to group column by the initial letter of the value for that group.
    /// The aspect must be a string (obviously).
    /// </remarks>
    [Category("Behavior"),
     Description("The name of the property or method that should be called to get the aspect to display in this column"),
     DefaultValue(false)]
    public bool UseInitialLetterForGroup
    {
      get { return useInitialLetterForGroup; }
      set { useInitialLetterForGroup = value; }
    }

    /// <summary>
    /// Get/set whether this column should be used when the view is switched to tile view.
    /// </summary>
    /// <remarks>Column 0 is always included in tileview regardless of this setting.
    /// Tile views do not work well with many "columns" of information, 2 or 3 works best.</remarks>
    [Category("Behavior"),
    Description("Will this column be used when the view is switched to tile view"),
     DefaultValue(false)]
    public bool IsTileViewColumn
    {
      get { return isTileViewColumn; }
      set { isTileViewColumn = value; }
    }
    private bool isTileViewColumn = false;

    /// <summary>
    /// This delegate will be used to extract a value to be displayed in this column.
    /// </summary>
    /// <remarks>
    /// If this is set, AspectName is ignored.
    /// </remarks>
    [Browsable(false),
     DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public AspectGetterDelegate AspectGetter
    {
      get { return aspectGetter; }
      set
      {
        aspectGetter = value;
        aspectGetterAutoGenerated = false;
      }
    }

    /// <summary>
    /// The delegate that will be used to translate the aspect to display in this column into a string.
    /// </summary>
    /// <remarks>If this value is set, ValueToStringFormat will be ignored.</remarks>
    [Browsable(false),
     DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public AspectToStringConverterDelegate AspectToStringConverter
    {
      get { return aspectToStringConverter; }
      set { aspectToStringConverter = value; }
    }

    /// <summary>
    /// This delegate is called to get the image selector of the image that should be shown in this column.
    /// It can return an int, string, Image or null.
    /// </summary>
    /// <remarks><para>This delegate can use these return value to identify the image:</para>
    /// <list>
    /// <item>null or -1 -- indicates no image</item>
    /// <item>an int -- the int value will be used as an index into the small image list</item>
    /// <item>a String -- the string value will be used as a key into the small image list</item>
    /// <item>an Image -- the Image will be drawn directly</item>
    /// </list>
    /// </remarks>
    [Browsable(false),
     DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public ImageGetterDelegate ImageGetter
    {
      get { return imageGetter; }
      set { imageGetter = value; }
    }

    /// <summary>
    /// This delegate is called to get the object that is the key for the group
    /// to which the given row belongs.
    /// </summary>
    [Browsable(false),
     DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public GroupKeyGetterDelegate GroupKeyGetter
    {
      get { return groupKeyGetter; }
      set { groupKeyGetter = value; }
    }

    /// <summary>
    /// This delegate is called to convert a group key into a title for that group.
    /// </summary>
    [Browsable(false),
     DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public GroupKeyToTitleConverterDelegate GroupKeyToTitleConverter
    {
      get { return groupKeyToTitleConverter; }
      set { groupKeyToTitleConverter = value; }
    }

    /// <summary>
    /// This delegate is called when a cell needs to be drawn.
    /// </summary>
    [Browsable(false),
     DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public RenderDelegate RendererDelegate
    {
      get { return rendererDelegate; }
      set { rendererDelegate = value; }
    }

    /// <summary>
    /// Get/set the renderer that will be invoked when a cell needs to be redrawn
    /// </summary>
    [Browsable(false),
     DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public BaseRenderer Renderer
    {
      get { return renderer; }
      set
      {
        renderer = value;
        if (renderer == null)
          this.RendererDelegate = null;
        else
        {
          renderer.Column = this;
          this.RendererDelegate = new RenderDelegate(renderer.HandleRendering);
        }
      }
    }
    private BaseRenderer renderer;

    /// <summary>
    /// Remember if this aspect getter for this column was generated internally, and can therefore
    /// be regenerated at will
    /// </summary>
    [Browsable(false),
     DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public bool AspectGetterAutoGenerated
    {
      get { return aspectGetterAutoGenerated; }
      set { aspectGetterAutoGenerated = value; }
    }
    private bool aspectGetterAutoGenerated;

    #endregion

    /// <summary>
    /// For a given row object, return the object that is to be displayed in this column.
    /// </summary>
    /// <param name="rowObject">The row object that is being displayed</param>
    /// <returns>An object, which is the aspect to be displayed</returns>
    public object GetValue(object rowObject)
    {
      if (this.aspectGetter == null)
        return this.GetAspectByName(rowObject);
      else
        return this.aspectGetter(rowObject);
    }

    /// <summary>
    /// For a given row object, extract the object called 'AspectName'.
    /// </summary>
    /// <param name="rowObject">The row object that is being displayed</param>
    /// <returns>An object, which is the aspect named by AspectName</returns>
    protected object GetAspectByName(object rowObject)
    {
      if (string.IsNullOrEmpty(this.aspectName))
        return null;

      //CONSIDER: Should we include NonPublic in this list?
      BindingFlags flags = BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance |
        BindingFlags.InvokeMethod | BindingFlags.GetProperty | BindingFlags.GetField;
      object source = rowObject;
      foreach (string property in this.aspectName.Split('.'))
      {
        try
        {
          source = source.GetType().InvokeMember(property, flags, null, source, null);
        }
        catch (System.MissingMethodException)
        {
          return String.Format("Cannot invoke '{0}' on a {1}", property, source.GetType());
        }
      }
      return source;
    }

    /// <summary>
    /// For a given row object, return the string representation of the value shown in this column.
    /// </summary>
    /// <remarks>
    /// For aspects that are string (e.g. aPerson.Name), the aspect and its string representation are the same.
    /// For non-strings (e.g. aPerson.DateOfBirth), the string representation is very different.
    /// </remarks>
    /// <param name="rowObject"></param>
    /// <returns></returns>
    public string GetStringValue(object rowObject)
    {
      return this.ValueToString(this.GetValue(rowObject));
    }

    /// <summary>
    /// Convert the aspect object to its string representation.
    /// </summary>
    /// <remarks>
    /// If the column has been given a ToStringDelegate, that will be used to do
    /// the conversion, otherwise just use ToString(). Nulls are always converted
    /// to empty strings.
    /// </remarks>
    /// <param name="value">The value of the aspect that should be displayed</param>
    /// <returns>A string representation of the aspect</returns>
    public string ValueToString(object value)
    {
      // CONSIDER: Should we give aspect-to-string converters a chance to work on a null value?
      if (value == null)
        return "";

      if (this.aspectToStringConverter != null)
        return this.aspectToStringConverter(value);

      string fmt = this.AspectToStringFormat;
      if (String.IsNullOrEmpty(fmt))
        fmt = "{0}";
      return String.Format(fmt, value);
    }

    /// <summary>
    /// For a given row object, return the image selector of the image that should displayed in this column.
    /// </summary>
    /// <param name="rowObject">The row object that is being displayed</param>
    /// <returns>int or string or Image. int or string will be used as index into image list. null or -1 means no image</returns>
    public Object GetImage(object rowObject)
    {
      if (this.imageGetter == null)
        return null;
      else
        return this.imageGetter(rowObject);
    }

    /// <summary>
    /// For a given row object, return the object that is the key of the group that this row belongs to.
    /// </summary>
    /// <param name="rowObject">The row object that is being displayed</param>
    /// <returns>Group key object</returns>
    public object GetGroupKey(object rowObject)
    {
      if (this.groupKeyGetter == null)
      {
        object key = this.GetValue(rowObject);
        if (key is string && this.UseInitialLetterForGroup)
          key = ((string)key).Substring(0, 1).ToUpper();
        return key;
      }
      else
        return this.groupKeyGetter(rowObject);
    }

    /// <summary>
    /// For a given group value, return the string that should be used as the groups title.
    /// </summary>
    /// <param name="value">The group key that is being converted to a title</param>
    /// <returns>string</returns>
    public string ConvertGroupKeyToTitle(object value)
    {
      if (this.groupKeyToTitleConverter == null)
        return this.ValueToString(value);
      else
        return this.groupKeyToTitleConverter(value);
    }

    #region Utilities

    /// <summary>
    /// Install delegates that will group the columns aspects into progressive partitions.
    /// If an aspect is less than value[n], it will be grouped with description[n]. 
    /// If an aspect has a value greater than the last element in "values", it will be grouped
    /// with the last element in "descriptions".
    /// </summary>
    /// <param name="values">Array of values. Values must be able to be
    /// compared to the aspect (using IComparable)</param>
    /// <param name="descriptions">The description for the matching value. The last element is the default description.
    /// If there are n values, there must be n+1 descriptions.</param>
    /// <example>
    /// this.salaryColumn.MakeGroupies(
    ///     new UInt32[] { 20000, 100000 },
    ///     new string[] { "Lowly worker",  "Middle management", "Rarified elevation"});
    /// </example>
    public void MakeGroupies<T>(T[] values, string[] descriptions)
    {
      if (values.Length + 1 != descriptions.Length)
        throw new ArgumentException("descriptions must have one more element than values.");

      // Install a delegate that returns the index of the description to be shown
      this.GroupKeyGetter = delegate(object row)
      {
        Object aspect = this.GetValue(row);
        if (aspect == null || aspect == System.DBNull.Value)
          return -1;
        IComparable comparable = (IComparable)aspect;
        for (int i = 0; i < values.Length; i++)
        {
          if (comparable.CompareTo(values[i]) < 0)
            return i;
        }

        // Display the last element in the array
        return descriptions.Length - 1;
      };

      // Install a delegate that simply looks up the given index in the descriptions. 
      this.GroupKeyToTitleConverter = delegate(object key)
      {
        if ((int)key < 0)
          return "";

        return descriptions[(int)key];
      };
    }

    #endregion

    #region Private Variables

    private string aspectName;
    private string aspectToStringFormat;
    private bool useInitialLetterForGroup;
    private AspectGetterDelegate aspectGetter;
    private AspectToStringConverterDelegate aspectToStringConverter;
    private ImageGetterDelegate imageGetter;
    private GroupKeyGetterDelegate groupKeyGetter;
    private GroupKeyToTitleConverterDelegate groupKeyToTitleConverter;
    private RenderDelegate rendererDelegate;


    #endregion

  }

  #endregion

  #region OLVListItem and OLVListSubItem

  /// <summary>
  /// OLVListItems are specialized ListViewItems that know which row object they came from,
  /// and the row index at which they are displayed, even when in group view mode. They
  /// also know the image they should draw against themselves
  /// </summary>
  public class OLVListItem : ListViewItem
  {
    /// <summary>
    /// Create a OLVListItem for the given row object
    /// </summary>
    public OLVListItem(object rowObject)
      : base()
    {
      this.rowObject = rowObject;
    }

    /// <summary>
    /// Create a OLVListItem for the given row object, represented by the given string and image
    /// </summary>
    public OLVListItem(object rowObject, string text, Object image)
      : base(text, -1)
    {
      this.rowObject = rowObject;
      this.imageSelector = image;
    }

    /// <summary>
    /// RowObject is the model object that is source of the data for this list item.
    /// </summary>
    public object RowObject
    {
      get { return rowObject; }
      set { rowObject = value; }
    }
    private object rowObject;

    /// <summary>
    /// DisplayIndex is the index of the row where this item is displayed. For flat lists,
    /// this is the same as ListViewItem.Index, but for grouped views, it is different.
    /// </summary>
    public int DisplayIndex
    {
      get { return displayIndex; }
      set { displayIndex = value; }
    }
    private int displayIndex;

    /// <summary>
    /// Get or set the image that should be shown against this item
    /// </summary>
    /// <remarks><para>This can be an Image, a string or an int. A string or an int will
    /// be used as an index into the small image list.</para></remarks>
    public Object ImageSelector
    {
      get { return imageSelector; }
      set
      {
        imageSelector = value;
        if (value is Int32)
          this.ImageIndex = (Int32)value;
        else if (value is String)
          this.ImageKey = (String)value;
        else
          this.ImageIndex = -1;
      }
    }
    private Object imageSelector;
  }

  /// <summary>
  /// A ListViewSubItem that knows which image should be drawn against it.
  /// </summary>
  [Browsable(false)]
  public class OLVListSubItem : ListViewItem.ListViewSubItem
  {
    /// <summary>
    /// Create a OLVListSubItem
    /// </summary>
    public OLVListSubItem()
      : base()
    {
    }

    /// <summary>
    /// Create a OLVListSubItem that shows the given string and image
    /// </summary>
    public OLVListSubItem(string text, Object image)
      : base()
    {
      this.Text = text;
      this.ImageSelector = image;
    }

    /// <summary>
    /// Get or set the image that should be shown against this item
    /// </summary>
    /// <remarks><para>This can be an Image, a string or an int. A string or an int will
    /// be used as an index into the small image list.</para></remarks>
    public Object ImageSelector
    {
      get { return imageSelector; }
      set { imageSelector = value; }
    }
    private Object imageSelector;
  }

  #endregion

  #region Comparers

  /// <summary>
  /// This comparer sort list view groups.
  /// It does this on the basis of the values in the Tags, if we can figure out how to compare
  /// objects of that type. Failing that, it uses a case insensitive compare on the group header.
  /// </summary>
  internal class ListViewGroupComparer : IComparer<ListViewGroup>
  {
    public ListViewGroupComparer(SortOrder order)
    {
      this.sortOrder = order;
    }

    public int Compare(ListViewGroup x, ListViewGroup y)
    {
      // If we know how to compare the tags, do that.
      // Otherwise do a case insensitive compare on the group header.
      // We have explicitly catch the "almost-null" value of DBNull.Value,
      // since comparing to that value always produces a type exception.
      int result;
      IComparable comparable = x.Tag as IComparable;
      if (comparable != null && y.Tag != System.DBNull.Value)
        result = comparable.CompareTo(y.Tag);
      else
        result = String.Compare(x.Header, y.Header, true);

      if (this.sortOrder == SortOrder.Descending)
        result = 0 - result;

      return result;
    }

    private SortOrder sortOrder;
  }

  /// <summary>
  /// ColumnComparer is the workhorse for all comparison between two values of a particular column.
  /// If the column has a specific comparer, use that to compare the values. Otherwise, do
  /// a case insensitive string compare of the string representations of the values.
  /// </summary>
  /// <remarks><para>This class inherits from both IComparer and its generic counterpart
  /// so that it can be used on untyped and typed collections.</para></remarks>
  internal class ColumnComparer : IComparer, IComparer<OLVListItem>
  {
    public ColumnComparer(OLVColumn col, SortOrder order)
    {
      this.column = col;
      this.sortOrder = order;
    }

    public int Compare(object x, object y)
    {
      return this.Compare((OLVListItem)x, (OLVListItem)y);
    }

    public int Compare(OLVListItem x, OLVListItem y)
    {
      int result = 0;
      object x1 = this.column.GetValue(x.RowObject);
      object y1 = this.column.GetValue(y.RowObject);

      if (this.sortOrder == SortOrder.None)
        return 0;

      // Handle nulls. Null values come last
      bool xIsNull = (x1 == null || x1 == System.DBNull.Value);
      bool yIsNull = (y1 == null || y1 == System.DBNull.Value);
      if (xIsNull || yIsNull)
        if (xIsNull && yIsNull)
          result = 0;
        else
          result = (xIsNull ? -1 : 1);
      else
        result = this.CompareValues(x1, y1);

      if (this.sortOrder == SortOrder.Descending)
        result = 0 - result;

      return result;
    }

    public int CompareValues(object x, object y)
    {
      // Force case insensitive compares on strings
      if (x is String)
        return String.Compare((String)x, (String)y, true);
      else
      {
        IComparable comparable = x as IComparable;
        if (comparable != null)
          return comparable.CompareTo(y);
        else
          return 0;
      }
    }

    private OLVColumn column;
    private SortOrder sortOrder;
  }

  #endregion

  #region Renderers

  /// <summary>
  /// Renderers are responsible for drawing a single cell within an owner drawn ObjectListView. 
  /// </summary>
  /// <remarks>
  /// <para>Methods on this class are called during the DrawSubItem event.</para>
  /// <para>Subclasses will normally override the Render method, and use the other
  /// methods as helper functions.</para>
  /// </remarks>
  [Browsable(false)]
  public class BaseRenderer
  {
    /// <summary>
    /// Make a simple renderer
    /// </summary>
    public BaseRenderer()
    {
    }

    #region Properties

    /// <summary>
    /// Get/set the event that caused this renderer to be called
    /// </summary>
    public DrawListViewSubItemEventArgs Event
    {
      get { return eventArgs; }
      set { eventArgs = value; }
    }
    private DrawListViewSubItemEventArgs eventArgs;

    /// <summary>
    /// Get/set the listview for which the drawing is to be done
    /// </summary>
    public ObjectListView ListView
    {
      get { return objectListView; }
      set { objectListView = value; }
    }
    private ObjectListView objectListView;

    /// <summary>
    /// Get or set the OLVColumn that this renderer will draw
    /// </summary>
    public OLVColumn Column
    {
      get { return column; }
      set { column = value; }
    }
    private OLVColumn column;

    /// <summary>
    /// Get or set the model object that this renderer should draw
    /// </summary>
    public Object RowObject
    {
      get { return rowObject; }
      set { rowObject = value; }
    }
    private Object rowObject;

    /// <summary>
    /// Get or set the aspect of the model object that this renderer should draw
    /// </summary>
    public Object Aspect
    {
      get
      {
        if (aspect == null)
          aspect = column.GetValue(this.rowObject);
        return aspect;
      }
      set { aspect = value; }
    }
    private Object aspect;

    /// <summary>
    /// Get or set the listitem that this renderer will be drawing
    /// </summary>
    public OLVListItem ListItem
    {
      get { return listItem; }
      set { listItem = value; }
    }
    private OLVListItem listItem;

    /// <summary>
    /// Get or set the list subitem that this renderer will be drawing
    /// </summary>
    public ListViewItem.ListViewSubItem SubItem
    {
      get { return listSubItem; }
      set { listSubItem = value; }
    }
    private ListViewItem.ListViewSubItem listSubItem;

    /// <summary>
    /// Get the specialized OLVSubItem that this renderer is drawing
    /// </summary>
    /// <remarks>This returns null for column 0.</remarks>
    public OLVListSubItem OLVSubItem
    {
      get { return listSubItem as OLVListSubItem; }
    }

    /// <summary>
    /// Cache whether or not our item is selected
    /// </summary>
    public bool IsItemSelected
    {
      get { return isItemSelected; }
      set { isItemSelected = value; }
    }
    private bool isItemSelected;

    /// <summary>
    /// Is this renderer drawing into a graphics double buffer?
    /// </summary>
    /// <remarks>.NET 2.0 has bugs in its handling of double buffered graphics,
    /// so we sometimes need to behave differently if we are drawing into a 
    /// buffered graphics context.</remarks>
    public bool DoubleBuffered
    {
      get
      {
        return true; // set this to false if you've changed the DrawSubItem event code
      }
    }

    #endregion

    #region Utilities

    /// <summary>
    /// Return the image that should be drawn against this subitem
    /// </summary>
    /// <returns>An Image or null if no image should be drawn.</returns>
    public Image GetImage()
    {
      if (this.Column.Index == 0)
        return this.GetImage(this.ListItem.ImageSelector);
      else
        return this.GetImage(this.OLVSubItem.ImageSelector);
    }

    /// <summary>
    /// Return the actual image that should be drawn when keyed by the given image selector.
    /// An image selector can be: <list>
    /// <item>an int, giving the index into the image list</item>
    /// <item>a string, giving the image key into the image list</item>
    /// <item>an Image, being the image itself</item>
    /// </list>
    /// </summary>
    /// <param name="imageSelector">The value that indicates the image to be used</param>
    /// <returns>An Image or null</returns>
    public Image GetImage(Object imageSelector)
    {
      if (imageSelector == null)
        return null;

      ImageList il = this.ListView.SmallImageList;
      if (imageSelector is Int32)
      {
        Int32 index = (Int32)imageSelector;
        if (index < 0 || index >= il.Images.Count)
          return null;
        else
          return il.Images[index];
      }

      if (imageSelector is String)
      {
        if (il.Images.ContainsKey((String)imageSelector))
          return il.Images[(String)imageSelector];
        else
          return null;
      }

      return imageSelector as Image;
    }

    /// <summary>
    /// Return the Color that is the background color for this item's cell
    /// </summary>
    /// <returns>The background color of the subitem</returns>
    protected Color GetBackgroundColor()
    {
      if (this.IsItemSelected && this.ListView.FullRowSelect)
      {
        return SystemColors.Highlight;
      }
      else
      {
        return this.ListItem.BackColor;
      }
    }

    /// <summary>
    /// Return the Color that is the background color for this item's text
    /// </summary>
    /// <returns>The background color of the subitem's text</returns>
    protected Color GetTextBackgroundColor()
    {
      if (this.IsItemSelected && (this.Column.Index == 0 || this.ListView.FullRowSelect))
        return SystemColors.Highlight;
      else
        return this.ListItem.BackColor;
    }

    /// <summary>
    /// Return the color to be used for text in this cell
    /// </summary>
    /// <returns>The text color of the subitem</returns>
    protected Color GetForegroundColor()
    {
      if (this.IsItemSelected && (this.Column.Index == 0 || this.ListView.FullRowSelect))
        return SystemColors.HighlightText;
      else
        return this.SubItem.ForeColor;
    }

    /// <summary>
    /// Align the second rectangle with the first rectangle, 
    /// according to the alignment of the column
    /// </summary>
    /// <param name="outer">The cell's bounds</param>
    /// <param name="inner">The rectangle to be aligned within the bounds</param>
    /// <returns>An aligned rectangle</returns>
    protected Rectangle AlignRectangle(Rectangle outer, Rectangle inner)
    {
      if (inner.Width >= outer.Width)
        return inner;

      Rectangle r = new Rectangle(inner.Location, inner.Size);
      switch (this.Column.TextAlign)
      {
        case HorizontalAlignment.Left:
          r.X = outer.Left;
          break;
        case HorizontalAlignment.Center:
          r.X = outer.Left + ((outer.Width - inner.Width) / 2);
          break;
        case HorizontalAlignment.Right:
          r.X = outer.Right - inner.Width - 1;
          break;
      }

      if (inner.Height < outer.Height)
        r.Y = outer.Top + ((outer.Height - inner.Height) / 2);

      return r;
    }

    /// <summary>
    /// Draw the given image aligned horizontally within the column
    /// </summary>
    /// <param name="g">Graphics context to use for drawing</param>
    /// <param name="r">Bounds of the cell</param>
    /// <param name="image"></param>
    protected void DrawAlignedImage(Graphics g, Rectangle r, Image image)
    {
      if (image == null)
        return;

      Rectangle imageBounds = this.AlignRectangle(r, new Rectangle(r.Location, image.Size));

      // If the image is too big to be drawn in the space provided, proportionally scale it down
      if (r.Height < image.Height)
        imageBounds.Width = (int)((float)image.Width * (float)r.Height / (float)image.Height);

      g.DrawImage(image, imageBounds);
    }

    /// <summary>
    /// Fill in the background of this cell
    /// </summary>
    /// <param name="g">Graphics context to use for drawing</param>
    /// <param name="r">Bounds of the cell</param>
    protected void DrawBackground(Graphics g, Rectangle r)
    {
      g.FillRectangle(new SolidBrush(this.GetBackgroundColor()), r);
    }

    #endregion


    /// <summary>
    /// The delegate that is called from the list view. This is the main entry point, but
    /// subclasses should override Render instead of this method.
    /// </summary>
    /// <param name="e">The event that caused this redraw</param>
    /// <param name="g">The context that our drawing should be done using</param>
    /// <param name="r">The bounds of the cell within which the renderer can draw</param>
    /// <param name="rowObject">The model object for this row</param>
    public void HandleRendering(DrawListViewSubItemEventArgs e, Graphics g, Rectangle r, Object rowObject)
    {
      this.Event = e;
      this.ListView = (ObjectListView)this.Column.ListView;
      this.RowObject = rowObject;
      this.ListItem = e.Item as OLVListItem;
      this.SubItem = e.SubItem;
      this.Aspect = null; // uncache previous result
      this.IsItemSelected = this.ListItem.Selected; // ((e.ItemState & ListViewItemStates.Selected) == ListViewItemStates.Selected);
      this.Render(g, r);
    }

    /// <summary>
    /// Draw our data into the given rectangle using the given graphics context.
    /// </summary>
    /// <remarks>
    /// <para>Subclasses should override this method.</para></remarks>
    /// <param name="g">The graphics context that should be used for drawing</param>
    /// <param name="r">The bounds of the subitem cell</param>
    virtual public void Render(Graphics g, Rectangle r)
    {
      this.DrawBackground(g, r);

      // Adjust the rectangle to match the padding used by the native mode of the ListView
      Rectangle r2 = r;
      r2.X += 4;
      r2.Width -= 2;
      this.DrawImageAndText(g, r2);
    }

    /// <summary>
    /// Draw our subitems image and text
    /// </summary>
    /// <param name="g">Graphics context to use for drawing</param>
    /// <param name="r">Bounds of the cell</param>
    protected void DrawImageAndText(Graphics g, Rectangle r)
    {
      DrawImageAndText(g, r, this.SubItem.Text, this.GetImage());
    }

    /// <summary>
    /// Draw the given text and optional image in the "normal" fashion
    /// </summary>
    /// <param name="g">Graphics context to use for drawing</param>
    /// <param name="r">Bounds of the cell</param>
    /// <param name="txt">The string to be drawn</param>
    /// <param name="image">The optional image to be drawn</param>
    protected void DrawImageAndText(Graphics g, Rectangle r, String txt, Image image)
    {
      // Draw the image
      int textStart = 3;
      if (image != null)
      {
        g.DrawImageUnscaled(image, r.X, r.Y);
        textStart += image.Width;
        r.X += image.Width;
        r.Width -= image.Width;
      }

      // One more problem. When double-buffered, the TextRenderer doesn't correctly offset
      // the drawing, so we have to position the text at the left of the buffer.
      if (this.DoubleBuffered)
        r = new Rectangle(textStart, 0, r.Width, r.Height);

      TextFormatFlags flags = TextFormatFlags.EndEllipsis | TextFormatFlags.NoPrefix | TextFormatFlags.VerticalCenter;
      switch (this.Column.TextAlign)
      {
        case HorizontalAlignment.Center: flags |= TextFormatFlags.HorizontalCenter; break;
        case HorizontalAlignment.Left: flags |= TextFormatFlags.Left; break;
        case HorizontalAlignment.Right: flags |= TextFormatFlags.Right; break;
      }
      TextRenderer.DrawText(g, txt, this.ListView.Font, r,
                            this.GetForegroundColor(), this.GetTextBackgroundColor(), flags);

      // We should put a focus rectange around the column 0 text if it's selected --
      // but we don't because:
      // - I really dislike this UI convention
      // - we are using buffered graphics, so the DrawFocusRecatangle method of the event doesn't work

      //if (this.Column.Index == 0) {
      //    Size size = TextRenderer.MeasureText(this.SubItem.Text, this.ListView.Font);
      //    if (r.Width > size.Width)
      //        r.Width = size.Width;
      //    this.Event.DrawFocusRectangle(r);
      //}
    }
  }

  /// <summary>
  /// This class maps a data value to an image that should be drawn for that value.
  /// </summary>
  /// <remarks><para>It is useful for drawing data that is represented as an enum or boolean.</para></remarks>
  class MappedImageRenderer : BaseRenderer
  {
    /// <summary>
    /// Return a renderer that draw boolean values using the given images
    /// </summary>
    /// <param name="trueImage">Draw this when our data value is true</param>
    /// <param name="falseImage">Draw this when our data value is false</param>
    /// <returns>A Renderer</returns>
    static public MappedImageRenderer Boolean(Object trueImage, Object falseImage)
    {
      return new MappedImageRenderer(true, trueImage, false, falseImage);
    }

    /// <summary>
    /// Return a renderer that draw tristate boolean values using the given images
    /// </summary>
    /// <param name="trueImage">Draw this when our data value is true</param>
    /// <param name="falseImage">Draw this when our data value is false</param>
    /// <param name="nullImage">Draw this when our data value is null</param>
    /// <returns>A Renderer</returns>
    static public MappedImageRenderer TriState(Object trueImage, Object falseImage, Object nullImage)
    {
      return new MappedImageRenderer(new Object[] { true, trueImage, false, falseImage, null, nullImage });
    }

    /// <summary>
    /// Make a new empty renderer
    /// </summary>
    public MappedImageRenderer()
      : base()
    {
      map = new System.Collections.Hashtable();
    }

    /// <summary>
    /// Make a new renderer that will show the given image when the given key is the aspect value
    /// </summary>
    /// <param name="key">The data value to be matched</param>
    /// <param name="image">The image to be shown when the key is matched</param>
    public MappedImageRenderer(Object key, Object image)
      : this()
    {
      this.Add(key, image);
    }

    public MappedImageRenderer(Object key1, Object image1, Object key2, Object image2)
      : this()
    {
      this.Add(key1, image1);
      this.Add(key2, image2);
    }

    /// <summary>
    /// Build a renderer from the given array of keys and their matching images
    /// </summary>
    /// <param name="keysAndImages">An array of key/image pairs</param>
    public MappedImageRenderer(Object[] keysAndImages)
      : this()
    {
      if ((keysAndImages.GetLength(0) % 2) != 0)
        throw new ArgumentException("Array must have key/image pairs");

      for (int i = 0; i < keysAndImages.GetLength(0); i += 2)
        this.Add(keysAndImages[i], keysAndImages[i + 1]);
    }

    /// <summary>
    /// Register the image that should be drawn when our Aspect has the data value.
    /// </summary>
    /// <param name="value">Value that the Aspect must match</param>
    /// <param name="image">An ImageSelector -- an int, string or image</param>
    public void Add(Object value, Object image)
    {
      if (value == null)
        this.nullImage = image;
      else
        map[value] = image;
    }

    /// <summary>
    /// Render our value
    /// </summary>
    /// <param name="g"></param>
    /// <param name="r"></param>
    public override void Render(Graphics g, Rectangle r)
    {
      this.DrawBackground(g, r);

      Image image = null;
      if (this.Aspect == null)
        image = this.GetImage(this.nullImage);
      else
        if (map.ContainsKey(this.Aspect))
          image = this.GetImage(map[this.Aspect]);

      this.DrawAlignedImage(g, r, image);
    }

    #region Private variables

    private Hashtable map; // Track the association between values and images
    private Object nullImage; // image to be drawn for null values (since null can't be a key)

    #endregion
  }

  /// <summary>
  /// Render an image that comes from our data source
  /// </summary>
  public class ImageRenderer : BaseRenderer
  {
    /// <summary>
    /// Make an empty image renderer
    /// </summary>
    public ImageRenderer()
      : base()
    {
    }

    /// <summary>
    /// Draw our image taken from
    /// </summary>
    /// <param name="g"></param>
    /// <param name="r"></param>
    public override void Render(Graphics g, Rectangle r)
    {
      this.DrawBackground(g, r);
      this.DrawAlignedImage(g, r, this.GetImageFromAspect());
    }

    private Image GetImageFromAspect()
    {
      if (this.Aspect == null || this.Aspect == System.DBNull.Value)
        return null;

      if (this.OLVSubItem != null && this.OLVSubItem.ImageSelector is Image)
        return (Image)this.OLVSubItem.ImageSelector;

      // Try to convert our Aspect into an Image
      // If its a byte array, we treat it as an in-memory image
      // If it's an int, we use that as an index into our image list
      // If it's a string, we try to find a file by that name. If we can't, we use
      //   the string as an index into our image list.
      //CONSIDER: Do we really want to look for files on the disk?
      Image image = null;
      if (this.Aspect is System.Byte[])
      {
        using (MemoryStream stream = new MemoryStream((System.Byte[])this.Aspect))
        {
          try
          {
            image = Image.FromStream(stream);
          }
          catch (ArgumentException)
          {
            // ignore
          }
        }
      }
      else if (this.Aspect is Int32)
      {
        image = this.GetImage(this.Aspect);
      }
      else if (this.Aspect is String)
      {
        try
        {
          image = Image.FromFile((String)this.Aspect);
        }
        catch (FileNotFoundException)
        {
          image = this.GetImage(this.Aspect);
        }
        catch (OutOfMemoryException)
        {
          image = this.GetImage(this.Aspect);
        }
      }

      // Cache the image so we don't repeat this dreary process
      if (this.OLVSubItem != null && this.OLVSubItem.ImageSelector == null)
        this.OLVSubItem.ImageSelector = image;

      return image;
    }

    #region Private variables

    #endregion
  }

  /// <summary>
  /// Render our Aspect as a progress bar
  /// </summary>
  public class BarRenderer : BaseRenderer
  {
    #region Constructors

    /// <summary>
    /// Make a BarRenderer
    /// </summary>
    public BarRenderer()
      : base()
    {
      this.Pen = new Pen(Color.Blue, 1);
      this.Brush = Brushes.Aquamarine;
      this.BackgroundBrush = Brushes.White;
      this.StartColor = Color.Empty;
    }

    /// <summary>
    /// Make a BarRenderer for the given range of data values
    /// </summary>
    public BarRenderer(int minimum, int maximum)
      : this()
    {
      this.MinimumValue = minimum;
      this.MaximumValue = maximum;
    }

    /// <summary>
    /// Make a BarRenderer using a custom bar scheme
    /// </summary>
    public BarRenderer(Pen aPen, Brush aBrush)
      : this()
    {
      this.Pen = aPen;
      this.Brush = aBrush;
      this.UseStandardBar = false;
    }

    /// <summary>
    /// Make a BarRenderer using a custom bar scheme
    /// </summary>
    public BarRenderer(int minimum, int maximum, Pen aPen, Brush aBrush)
      : this(minimum, maximum)
    {
      this.Pen = aPen;
      this.Brush = aBrush;
      this.UseStandardBar = false;
    }

    /// <summary>
    /// Make a BarRenderer that uses a horizontal gradient
    /// </summary>
    public BarRenderer(Pen aPen, Color start, Color end)
      : this()
    {
      this.Pen = aPen;
      this.SetGradient(start, end);
    }

    /// <summary>
    /// Make a BarRenderer that uses a horizontal gradient
    /// </summary>
    public BarRenderer(int minimum, int maximum, Pen aPen, Color start, Color end)
      : this(minimum, maximum)
    {
      this.Pen = aPen;
      this.SetGradient(start, end);
    }

    #endregion

    #region Public variables

    /// <summary>
    /// Should this bar be drawn in the system style
    /// </summary>
    public bool UseStandardBar = true;

    /// <summary>
    /// How many pixels in from our cell border will this bar be drawn
    /// </summary>
    public int Padding = 2;

    /// <summary>
    /// The Pen that will draw the frame surrounding this bar
    /// </summary>
    public Pen Pen;

    /// <summary>
    /// The brush that will be used to fill the bar
    /// </summary>
    public Brush Brush;

    /// <summary>
    /// The brush that will be used to fill the background of the bar
    /// </summary>
    public Brush BackgroundBrush;

    /// <summary>
    /// The first color when a gradient is used to fill the bar
    /// </summary>
    public Color StartColor;

    /// <summary>
    /// The end color when a gradient is used to fill the bar
    /// </summary>
    public Color EndColor;

    /// <summary>
    /// Regardless of how wide the column become the progress bar will never be wider than this
    /// </summary>
    public int MaximumWidth = 100;

    /// <summary>
    /// Regardless of how high the cell is  the progress bar will never be taller than this
    /// </summary>
    public int MaximumHeight = 16;

    /// <summary>
    /// The minimum data value expected. Values less than this will given an empty bar
    /// </summary>
    public int MinimumValue = 0;

    /// <summary>
    /// The maximum value for the range. Values greater than this will give a full bar
    /// </summary>
    public int MaximumValue = 100;

    #endregion

    /// <summary>
    /// Draw this progress bar using a gradient
    /// </summary>
    /// <param name="start"></param>
    /// <param name="end"></param>
    public void SetGradient(Color start, Color end)
    {
      this.StartColor = start;
      this.EndColor = end;
      this.UseStandardBar = false;
    }

    /// <summary>
    /// Draw our aspect
    /// </summary>
    /// <param name="g"></param>
    /// <param name="r"></param>
    public override void Render(Graphics g, Rectangle r)
    {
      this.DrawBackground(g, r);

      Rectangle frameRect = Rectangle.Inflate(r, 0 - this.Padding, 0 - this.Padding);
      if (frameRect.Width > this.MaximumWidth)
        frameRect.Width = this.MaximumWidth;
      if (frameRect.Height > this.MaximumHeight)
        frameRect.Height = this.MaximumHeight;
      frameRect = this.AlignRectangle(r, frameRect);

      // Convert our aspect to a numeric value
      // CONSIDER: Is this the best way to do this?
      if (!(this.Aspect is IConvertible))
        return;
      double aspectValue = ((IConvertible)this.Aspect).ToDouble(NumberFormatInfo.InvariantInfo);

      Rectangle fillRect = Rectangle.Inflate(frameRect, -1, -1);
      if (aspectValue <= this.MinimumValue)
        fillRect.Width = 0;
      else if (aspectValue < this.MaximumValue)
        fillRect.Width = (int)(fillRect.Width * (aspectValue - this.MinimumValue) / this.MaximumValue);

      if (this.UseStandardBar && ProgressBarRenderer.IsSupported)
      {
        ProgressBarRenderer.DrawHorizontalBar(g, frameRect);
        ProgressBarRenderer.DrawHorizontalChunks(g, fillRect);
      }
      else
      {
        g.FillRectangle(this.BackgroundBrush, frameRect);
        g.DrawRectangle(this.Pen, frameRect);
        if (fillRect.Width > 0)
        {
          fillRect.Height++;
          if (this.StartColor == Color.Empty)
            g.FillRectangle(this.Brush, fillRect);
          else
          {
            using (LinearGradientBrush gradient = new LinearGradientBrush(frameRect, this.StartColor, this.EndColor, LinearGradientMode.Horizontal))
            {
              g.FillRectangle(gradient, fillRect);
            }
          }
        }
      }
    }
  }

  /// <summary>
  /// A MultiImageRenderer draws the same image a number of times based on our data value
  /// </summary>
  /// <remarks><para>The stars in the Rating column of iTunes is a good example of this type of renderer.</para></remarks>
  public class MultiImageRenderer : BaseRenderer
  {
    /// <summary>
    /// Make a quiet rendererer
    /// </summary>
    public MultiImageRenderer()
      : base()
    {

    }

    /// <summary>
    /// Make an image renderer that will draw the indicated image, at most maxImages times.
    /// </summary>
    /// <param name="imageSelector"></param>
    /// <param name="maxImages"></param>
    /// <param name="minValue"></param>
    /// <param name="maxValue"></param>
    public MultiImageRenderer(Object imageSelector, int maxImages, int minValue, int maxValue)
      : this()
    {
      this.ImageSelector = imageSelector;
      this.MaxNumberImages = maxImages;
      this.MinimumValue = minValue;
      this.MaximumValue = maxValue;
    }

    /// <summary>
    /// The image selector that will give the image to be drawn
    /// </summary>
    public Object ImageSelector
    {
      get { return imageSelector; }
      set { imageSelector = value; }
    }
    private Object imageSelector;

    /// <summary>
    /// Get or set the number of pixels between each image
    /// </summary>
    public int Spacing
    {
      get { return spacing; }
      set { spacing = value; }
    }
    private int spacing = 1;

    /// <summary>
    /// What is the maximum number of images that this renderer should draw?
    /// </summary>
    public int MaxNumberImages
    {
      get { return maxNumberImage; }
      set { maxNumberImage = value; }
    }
    private int maxNumberImage;

    /// <summary>
    /// Values less than or equal to this will have 0 images drawn
    /// </summary>
    public int MinimumValue = 0;

    /// <summary>
    /// Values greater than or equal to this will have MaxNumberImages images drawn
    /// </summary>
    public int MaximumValue = 100;

    /// <summary>
    /// Draw our data value
    /// </summary>
    /// <param name="g"></param>
    /// <param name="r"></param>
    public override void Render(Graphics g, Rectangle r)
    {
      this.DrawBackground(g, r);

      Image image = this.GetImage(this.ImageSelector);
      if (image == null)
        return;

      // Convert our aspect to a numeric value
      // CONSIDER: Is this the best way to do this?
      if (!(this.Aspect is IConvertible))
        return;
      double aspectValue = ((IConvertible)this.Aspect).ToDouble(NumberFormatInfo.InvariantInfo);

      // Calculate how many images we need to draw to represent our aspect value
      int numberOfImages;
      if (aspectValue <= this.MinimumValue)
        numberOfImages = 0;
      else if (aspectValue < this.MaximumValue)
        numberOfImages = 1 + (int)(this.MaxNumberImages * (aspectValue - this.MinimumValue) / this.MaximumValue);
      else
        numberOfImages = this.MaxNumberImages;

      // If we need to shrink the image, what will its on-screen dimensions be?
      int imageScaledWidth = image.Width;
      int imageScaledHeight = image.Height;
      if (r.Height < image.Height)
      {
        imageScaledWidth = (int)((float)image.Width * (float)r.Height / (float)image.Height);
        imageScaledHeight = r.Height;
      }
      // Calculate where the images should be drawn
      Rectangle imageBounds = r;
      imageBounds.Width = (this.MaxNumberImages * (imageScaledWidth + this.Spacing)) - this.Spacing;
      imageBounds.Height = imageScaledHeight;
      imageBounds = this.AlignRectangle(r, imageBounds);

      // Finally, draw the images
      for (int i = 0; i < numberOfImages; i++)
      {
        g.DrawImage(image, imageBounds.X, imageBounds.Y, imageScaledWidth, imageScaledHeight);
        imageBounds.X += (imageScaledWidth + this.Spacing);
      }
    }
  }
  #endregion
}