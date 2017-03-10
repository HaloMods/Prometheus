using System;

namespace Interfaces.UserInterface
{
  public interface IDocumentManager
  {
    void CloseAllDocuments();
    bool CloseDocument(IDocument document, bool fromGUI);
    event DocumentClosingHandler DirtyDocumentClosing;
    event DocumentActionHandler DocumentActivated;
    event DocumentClosedHandler DocumentClosed;
    event DocumentActionHandler DocumentOpened;
    event DocumentRenamedHandler DocumentRenamed;
    event DocumentStateChangedHandler DocumentStateChanged;
    void OpenDocument(IDocument document);
    void ActivateDocument(IDocument document, bool fromGUI);
    void SaveDocument(IDocument document);
    void SaveDocumentAs(IDocument document, string newPath);
    void SaveAllDocuments();
    bool DocumentExists(string path);
    IDocument ActiveDocument { get; }
  }

  /// <summary>
  /// Used to handle document-related actions that can be cancelled.
  /// </summary>
  public delegate void DocumentClosingHandler(IDocument document, DocumentSavingEventArgs action);

  /// <summary>
  /// Represents a method that handles the DocumentClosed event.
  /// </summary>
  public delegate void DocumentClosedHandler(string documentIdentifier, bool fromGUI);

  /// <summary>
  /// Used to handle document-related actions.
  /// </summary>
  public delegate void DocumentActionHandler(IDocument document, bool fromGUI);

  /// <summary>
  /// Used to signal when a document's state has changed.
  /// </summary>
  public delegate void DocumentStateChangedHandler(IDocument document, DocumentState state);

  /// <summary>
  /// Used to signal when a document has been renamed.
  /// </summary>
  public delegate void DocumentRenamedHandler(IDocument document, string oldPath);

  /// <summary>
  /// Used to represent the action that will take place when a document is being saved.
  /// </summary>
  public class DocumentSavingEventArgs : EventArgs
  {
    private SaveAction action;
    private bool fromGUI;

    /// <summary>
    /// The action that will be taken.
    /// </summary>
    public SaveAction Action
    {
      get { return action; }
      set { action = value; }
    }

    /// <summary>
    /// Creates an instance of the class with the specified SaveAction.
    /// </summary>
    public DocumentSavingEventArgs(SaveAction action)
    {
      this.action = action;
    }
  }

  /// <summary>
  /// Provides a list of actions that can take place when a document is being saved.
  /// </summary>
  public enum SaveAction
  {
    SaveChanges,
    IgnoreChanges,
    Cancel
  }
}