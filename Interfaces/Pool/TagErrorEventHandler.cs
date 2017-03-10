using System;
using System.Collections.Generic;
using System.Text;

namespace Interfaces.Pool
{
  /// <summary>
  /// Represents a method that will handle a tag error event.
  /// </summary>
  /// <param name="sender">the object raising the event</param>
  /// <param name="e">the event data</param>
  public delegate void TagErrorEventHandler(object sender, TagErrorEventArgs e);
}
