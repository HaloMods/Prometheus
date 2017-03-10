using System;
using System.Collections.Generic;
using System.Text;

namespace Interfaces.UserInterface
{
  /// <summary>
  /// Represents an action that can be undone/redone.
  /// </summary>
  public interface IUndoableAction
  {
    /// <summary>
    /// Signifies that when this action is undone or redone, the document will be in a clean state.
    /// </summary>
    bool CleanPoint { get; set; }
    
    /// <summary>
    /// Undoes the action.
    /// </summary>
    void Undo();
    
    /// <summary>
    /// Redoes the action.
    /// </summary>
    void Redo();
  }
}
