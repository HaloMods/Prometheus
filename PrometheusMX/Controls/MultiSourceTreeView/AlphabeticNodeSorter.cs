using System.Collections;

namespace Prometheus.Controls
{
  /// <summary>
  /// Sorts Nodes by their dominant NodeType's SortPriority, and secondarily, by their Text property.
  /// </summary>
  public class AlphabeticNodeSorter : IComparer
  {
    public int Compare(object x, object y)
    {
      MultiSourceTreeNode tx = (MultiSourceTreeNode)x;
      MultiSourceTreeNode ty = (MultiSourceTreeNode)y;

      // If the nodes both contain InfoEntries, we can sort further.
      if ((tx.EntryCount > 0) && (ty.EntryCount > 0))
      {
        string txt = tx.InfoEntries[0].NodeType.Name;
        string tyt = ty.InfoEntries[0].NodeType.Name;
        if (txt != tyt)
        {
          int txp = tx.InfoEntries[0].NodeType.SortingPriority;
          int typ = ty.InfoEntries[0].NodeType.SortingPriority;
          if (txp > typ) return -1;
          else if (txp < typ) return 1;
        }
      }
      // If the previous sorting was equal (or was not possible), apply an alphabetical sort only.
      return string.Compare(tx.Text, ty.Text);
    }
  }
}