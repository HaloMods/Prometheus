using System;
using System.Drawing;
using System.Collections;

namespace Interfaces.DynamicInterface.SceneInstanceMenu
{
  public class ScenePalette
  {
    private int id;
    private Image image;
    private string name;
    private PaletteTarget target;
    private IList palette;

    public ScenePalette(int id, Image image, string name, IList palette, PaletteTarget target)
    {
      this.id = id;
      this.image = image;
      this.name = name;
      this.palette = palette;
      this.target = target;
    }

    public int ID
    {
      get
      { return id; }
    }

    public string Name
    {
      get
      { return name; }
    }

    public Image Image
    {
      get
      { return image; }
    }

    public PaletteTarget Target
    {
      get
      { return target; }
    }

    public IList Palette
    {
      get
      { return palette; }
    }
  }
}
