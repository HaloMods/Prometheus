using System;
using System.Collections.Generic;
using System.Text;

namespace Interfaces.TagEditor
{
  public interface IBlockIndexControl
  {
    string LinkedStructName { get; }
    void ConnectBlockControl(IBlockControl control);
  }
}
