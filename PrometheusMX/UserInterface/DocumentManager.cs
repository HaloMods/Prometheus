using System;
using System.Collections.Generic;
using Interfaces.UserInterface;

namespace Prometheus.UserInterface
{
  public class DocumentManager : IDocumentManager
  {
    private List<IDocument> documents = new List<IDocument>();
    private IDocument activeDocument = null;

    public IDocument ActiveDocument
    {
      get { return activeDocument; }
    }

    public event DocumentActionHandler DocumentOpened;
    public event DocumentRenamedHandler DocumentRenamed;
    public event DocumentClosingHandler DirtyDocumentClosing;
    public event DocumentClosedHandler DocumentClosed;
    public event DocumentActionHandler DocumentActivated;
    public event DocumentStateChangedHandler DocumentStateChanged;

    /// <summary>
    /// Register the specified document with the DocumentManager.
    /// Generates the DocumentOpened event, which should be caught by
    /// the UI in order to display the document.
    /// </summary>
    public void OpenDocument(IDocument document)
    {
      if (documents.Contains(document))
        throw new Exception("The specified document is already open in the DocumentManager.");

      documents.Add(document);
      document.DocumentStateChanged += new DocumentStateChangedHandler(document_DocumentStateChanged);
      if (DocumentOpened != null)
        DocumentOpened(document, false);
    }

    void document_DocumentStateChanged(IDocument document, DocumentState state)
    {
      if (DocumentStateChanged != null)
        DocumentStateChanged(document, state);
    }

    /// <summary>
    /// Closes the specified document and removes it from the DocumentManager.
    /// Generates the DocumentClosed event, which should be caught by
    /// the UI in order to dispose of the document.
    /// If the document is Dirty, the DirtyDocumentClosing event will be generated
    /// to give the UI a chance to decide what action should be taken.
    /// </summary>
    public bool CloseDocument(IDocument document, bool fromGUI)
    {
      // If the document isn't in the list, then we've probably looped back from the GUI.
      if (!documents.Contains(document)) return true;

      if (document.DocumentState == DocumentState.Dirty)
      {
        if (DirtyDocumentClosing != null)
        {
          DocumentSavingEventArgs e = new DocumentSavingEventArgs(SaveAction.SaveChanges);
          DirtyDocumentClosing(document, e);
          if (e.Action == SaveAction.Cancel)
            return false;
          else if (e.Action == SaveAction.SaveChanges)
            document.SaveDocument();
        }
      }

      string documentIdentifier = document.DocumentFilename;
      document.CloseDocument();
      documents.Remove(document);
      
      if (DocumentClosed != null)
        DocumentClosed(documentIdentifier, fromGUI);
      return true;
    }

    /// <summary>
    /// Closes all of the open documents.
    /// </summary>
    public void CloseAllDocuments()
    {
      foreach (IDocument doc in documents.ToArray())
        CloseDocument(doc, false);
    }

    /// <summary>
    ///Saves all of the open documents.
    /// </summary>
    public void SaveAllDocuments()
    {
      foreach (IDocument doc in documents.ToArray())
        SaveDocument(doc);
    }

    public bool DocumentExists(string path)
    {
      foreach (IDocument doc in documents)
        if (doc.DocumentFilename == path)
          return true;
      return false;
    }

    /// <summary>
    /// Activates the specified document.
    /// Generates the DocumentActivated event to allow synchronization with the UI.
    /// </summary>
    public void ActivateDocument(IDocument document, bool fromGUI)
    {
      activeDocument = document;
      if (!fromGUI)
        if (DocumentActivated != null)
          DocumentActivated(document, false);
    }

    /// <summary>
    /// Activates the specified document.
    /// Generates the DocumentActivated event to allow synchronization with the UI.
    /// </summary>
    public void SaveDocument(IDocument document)
    {
      document.SaveDocument();
    }

    public void SaveDocumentAs(IDocument document, string newPath)
    {
      if (document.DocumentFilename != newPath)
      {
        string oldPath = document.DocumentFilename;
        document.SaveDocumentAs(newPath);
        if (DocumentRenamed != null)
          DocumentRenamed(document, oldPath);
      }
    }
  }
}