using System;
using System.Drawing;
using Interfaces.Pool;
using Interfaces.UserInterface;

namespace Prometheus.Controls.TagExplorers.Library
{
  public class DocumentOpenState : NodeState
  {
    private IDocumentManager manager;
    private string gameID;
    private TagLocation tagLocation;

    /// <summary>
    /// Provides a state that corresponds to a sepcified document being opened in the DocumentManager.
    /// </summary>
    /// <param name="manager">The document manager that will be used to determine state.</param>
    /// <param name="gameID">The GameID of the game that opened documents will belong to.</param>
    /// <param name="location">The TagLocation that opened documents will exist in.</param>
    /// <param name="collapsedIcon">The icon that will be displayed when the node is collapsed.</param>
    /// <param name="expandedIcon">The icon that will be displayed when the node is expanded.</param>
    /// <param name="foregroundColor">The foreground color of the node.</param>
    /// <param name="backgroundColor">The background color of the node.</param>
    public DocumentOpenState(IDocumentManager manager, string gameID, TagLocation location,
      Bitmap collapsedIcon, Bitmap expandedIcon, Color foregroundColor, Color backgroundColor)
      : base("document_open", collapsedIcon, expandedIcon, foregroundColor, backgroundColor)
    {
      this.manager = manager;
      this.gameID = gameID;
      tagLocation = location;
      this.manager.DocumentOpened += new DocumentActionHandler(manager_DocumentOpened);
      this.manager.DocumentClosed += new DocumentClosedHandler(manager_DocumentClosed);
    }

    private void manager_DocumentOpened(IDocument document, bool fromGUI)
    {
      string identifier = GetIdentifierFromDocument(document);
      UpdateSubscribers(identifier, true);
    }

    void manager_DocumentClosed(string documentIdentifier, bool fromGUI)
    {
      string identifier = GetIdentifierFromDocumentFilename(documentIdentifier);
      UpdateSubscribers(identifier, false);
    }

    string GetIdentifierFromDocument(IDocument document)
    {
      return GetIdentifierFromDocumentFilename(document.DocumentFilename);
    }

    string GetIdentifierFromDocumentFilename(string documentFilename)
    {
      // TODO: This should really be implemented as a property of the TagPath.
      TagPath path = new TagPath(documentFilename);
      if (path.Game == gameID)
        if (path.Location == tagLocation)
        {
          string identifier = path.Path + "." + path.Extension;
          if (path.AttachmentName != null)
            if (path.AttachmentName.Length > 0)
              identifier += "|" + path.AttachmentName;
          return identifier;
        }
      return "";
    }

    /// <summary>
    /// Determines the initial state that subscribers of this state will be in.
    /// </summary>
    protected override bool DetermineState(NodeInfo info)
    {
      // Look up the document in the DocumentManager
      TagPath path = new TagPath(info.Identifier, gameID, tagLocation);
      return manager.DocumentExists(path.ToPath());
    }
  }
}