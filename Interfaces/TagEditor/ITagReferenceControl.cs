using System;
using System.Collections.Generic;
using System.Text;
using Interfaces.Pool;

namespace Interfaces.TagEditor
{
  public interface ITagReferenceControl
  {
    event OpenTagEventHandler OpenTag;
  }

  public delegate void OpenTagEventHandler(string relativePath);
  public delegate void OpenTagPathEventHandler(TagPath path);
}
