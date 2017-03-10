using System;

namespace Games.Halo2.Compiler.Classes
{
  public class ElementWrapper
  {
    private Element element;

    public ElementWrapper()
    {
      element = new Element();
    }

    public ElementWrapper(Element source)
    {
      element = source;
    }

    public Element Element
    {
      get
      { return element; }
    }
  }
}
