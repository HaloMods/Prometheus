namespace Interfaces
{
  /// <summary>
  /// Provides an interface for a class to support undo and redo functionality.
  /// </summary>
  public interface ISupportsUndoRedo
  {
    void Undo();
    void Redo();
  }
}
