using System;
using System.Collections.Generic;
using System.Drawing;

namespace Interfaces.DynamicInterface.RuntimeMenu
{
  public abstract class RuntimeMenuObject
  {
    private bool beginsGroup;
    private Image image;
    private string name;
    private string tooltip;
    private RuntimeMenuType type;
    protected List<RuntimeMenuObject> children;

    protected RuntimeMenuObject(RuntimeMenuType type)
    {
      this.type = type;
      children = new List<RuntimeMenuObject>();
    }

    protected RuntimeMenuObject(string name, RuntimeMenuType type, string tooltip, Image image, bool beginsGroup)
      : this(type)
    {
      this.name = name;
      this.tooltip = tooltip;
      this.image = image;
      this.beginsGroup = beginsGroup;
    }

    public RuntimeMenuType Type
    {
      get
      { return type; }
    }

    public string Name
    {
      get
      { return name; }
      set
      { name = value; }
    }

    public string ToolTip
    {
      get
      { return tooltip; }
      set
      { tooltip = value; }
    }

    public bool BeginsGroup
    {
      get
      { return beginsGroup; }
      set
      { beginsGroup = value; }
    }

    public Image Image
    {
      get
      { return image; }
      set
      { image = value; }
    }

    public RuntimeMenuObject[] Children
    {
      get
      { return children.ToArray(); }
    }
  }
}
