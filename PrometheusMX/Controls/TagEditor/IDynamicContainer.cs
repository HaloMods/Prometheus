using System;
using System.Collections.Generic;
using System.Text;

using Interfaces.TagEditor;
using Prometheus.Controls.TagEditor;

namespace Prometheus.Controls.TagEditor
{
  public delegate void DynamicContainerDelegate(IDynamicContainer container, ContainerGlobals globals);
  /// <summary>
  /// An interface defining the minimum requirements for an on-the-fly-loading container.
  /// </summary>
  public interface IDynamicContainer : Interfaces.TagEditor.IFieldControlContainer
  {
    ContainerGlobals Globals { get; set;}
    event DynamicContainerDelegate PerformingLoad;

    BlockContainerPanel FieldPanel { get; set;}
    IBlockControl Block { get; }
    IDynamicContainer Parent { get; set; }
  }
}
