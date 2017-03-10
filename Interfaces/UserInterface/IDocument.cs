using System;
using System.Collections.Generic;
using System.Text;

namespace Interfaces.UserInterface
{
  public interface IDocument
  {
    string DocumentFilename { get; set; }
    string DocumentTitle { get; set; }
    string DocumentTooltip { get; set; }
    DocumentState DocumentState { get; }
    IDocumentManager DocumentManager { get; set; }
    void LoadDocument();
    void SaveDocument();
    void SaveDocumentAs(string path);
    void CloseDocument();
    void Undo();
    void Redo();
    event DocumentStateChangedHandler DocumentStateChanged;
  }

  /// <summary>
  /// Specifies the state of a document.
  /// </summary>
  public enum DocumentState
  {
    /// <summary>
    /// Document has been modified since the last time it was saved to disk (or has never been saved).
    /// </summary>
    Dirty,
    /// <summary>
    /// Document has no unsaved changes and can be closed with no data loss.
    /// </summary>
    Clean,
    /// <summary>
    /// The user is not allowed to save the document.
    /// </summary>
    ReadOnly
  }
}