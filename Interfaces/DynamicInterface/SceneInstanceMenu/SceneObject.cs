using System;

namespace Interfaces.DynamicInterface.SceneInstanceMenu
{
  public class SceneObject
  {
    private int palette;
    private string objectName;

    public SceneObject(int palette, string objectName)
    {
      this.palette = palette;
      this.objectName = objectName;
    }

    public int PaletteID
    {
      get
      { return palette; }
    }

    public string ObjectName
    {
      get
      { return objectName; }
    }
  }
}
