using System;
using System.Collections.Generic;
using System.Text;

namespace Interfaces.Notes
{
  /// <summary>
  /// Represents the method that will handle an event thrown by a note modifier.
  /// </summary>
  /// <param name="index">which note in the collection that is in question</param>
  public delegate void NoteEvent(int index);
}
