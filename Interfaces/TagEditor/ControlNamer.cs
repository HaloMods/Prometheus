using System.Collections.Generic;
using System.Windows.Forms;

namespace Interfaces.TagEditor
{
  /// <summary>
  /// Automatically assigns unique names to controls.
  /// </summary>
  public class ControlNamer
  {
    private List<Control> controlList = new List<Control>();
    public void AssignName(Control control)
    {
      string typeName = control.GetType().ToString();
      if (typeName.IndexOf('.') > 0) typeName = typeName.Substring(typeName.LastIndexOf('.') + 1);
      if (!controlList.Contains(control))
      {
        int typeCount = 0;
        foreach (Control c in controlList)
          if (c.GetType() == control.GetType())
            typeCount++;
        control.Name = typeName + typeCount;
        controlList.Add(control);
      }
    }
  }
}
