using System;
using System.Collections;
using System.Reflection;
using Interfaces.UserInterface;
using System.Collections.Generic;

namespace Interfaces.TagEditor
{
  /// <summary>
  /// Manages undo and redo states or the tag editor via reflection.
  /// </summary>
  public class UndoManager
  {
    private int maxItems = 20;
    private List<IUndoableAction> actions = new List<IUndoableAction>();
    private int position = -1;
    private int cleanPosition = -1;
    public event StateChangedHandler StateChanged;

    /// <summary>
    /// The position of the current action within the action list.
    /// </summary>
    public int Position
    {
      get { return position; }
    }

    /// <summary>
    /// Adds the specified action state to the action lsit.
    /// </summary>
    public void AddAction(IUndoableAction action)
    {
      // Remove the oldest action is we have reached the max number of actions allowed.
      if (position == maxItems - 1)
      {
        actions.RemoveAt(0);
        position--;
      }

      // Remove any existing actions after our current position (as they will no longer
      // be valid in the undo sequence.)
      if (position < actions.Count - 1)
      {
        for (int x = actions.Count - 1; x > position; x--)
          actions.RemoveAt(x);
      }

      // Add the action to the list and update out position.
      actions.Add(action);
      position++;
      
      // Set our new clean point if this state is clean.
      if (action.CleanPoint) SetCleanState();
      
      // Signal that a state change has occurred.
      if (StateChanged != null)
        StateChanged(position != cleanPosition);
    }

    /// <summary>
    /// Sets the currently active action state as the document's "clean" state, in which
    /// there are no unsaved changes.
    /// </summary>
    public void SetCleanState()
    {
      cleanPosition = position;
    }

    /// <summary>
    /// Undo the current action.
    /// </summary>
    public void Undo()
    {
      if (position > -1)
      {
        actions[position].Undo();
        position--;

        if (StateChanged != null)
          StateChanged(position != cleanPosition);
      }
    }
    
    /// <summary>
    /// Redo the next action up the list.
    /// </summary>
    public void Redo()
    {
      if (position == actions.Count - 1) return;
      position++;
      actions[position].Redo();
      
      if (StateChanged != null)
        StateChanged(position == cleanPosition);
    }
  }

  public delegate void StateChangedHandler(bool dirty);
}