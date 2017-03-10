using System;
using System.IO;
using System.Reflection;
using System.Windows.Forms;
using Interfaces.Games;
using Interfaces.Pool;
using Interfaces.UserInterface;

namespace Prometheus.Controls.ScriptEditor
{
  public partial class ScriptEditorControl : UserControl, IDocument
  {
  	private string m_documentFilename;
  	private DocumentState m_documentState;
  	private IDocumentManager m_documentManager;

  	public ScriptEditorControl()
    {
      InitializeComponent();
      syntaxEditor.Document.LoadLanguageFromXml(Assembly.GetExecutingAssembly().GetManifestResourceStream("Prometheus.Resources.Scripting.PSL.Lexer.xml"), 0);
    }

		public void Create(GameDefinition game, string fileName, bool readOnly)
    {
			m_documentFilename = fileName;

      PslDynamicSyntaxLanguage language = (PslDynamicSyntaxLanguage) syntaxEditor.Document.Language;
      language.LoadScriptEngineDefinition(game.ScriptEngineDefinition);

    	//syntaxEditor.Document.ReadOnly = readOnly;
    	m_documentState = readOnly ? DocumentState.ReadOnly : DocumentState.Clean;
    }

		public void Create(GameDefinition game)
		{
			Create(game, null, false);
		}

		public void Create(GameDefinition game, string fileName, bool readOnly, string text)
		{
			Create(game, fileName, readOnly);
			syntaxEditor.Text = text;
		}

		#region IDocument Members

		public string DocumentFilename
  	{
  		get { return m_documentFilename; }
  		set { m_documentFilename = value; }
  	}

  	public string DocumentTitle
  	{
			get
			{
				if (TagPath.IsFullyQualifiedPath(m_documentFilename))
				{
					TagPath fullPath = new TagPath(m_documentFilename);
					return Path.GetFileNameWithoutExtension(fullPath.Path) + "|" + fullPath.AttachmentName;
				}
				else
					return m_documentFilename;
			}
      set { ; }
  	}

  	public string DocumentTooltip
  	{
			get { return String.Empty; }
  		set { }
  	}

  	public DocumentState DocumentState
  	{
  		get { return m_documentState; }
  	}

  	public IDocumentManager DocumentManager
  	{
  		get { return m_documentManager; }
  		set { m_documentManager = value; }
  	}

  	public void LoadDocument()
  	{
  	}

  	public void SaveDocument()
  	{
  	}

    public void SaveDocumentAs(string path)
    {
    }

    public void CloseDocument()
  	{
  	}

  	public void Undo()
  	{
  	}

  	public void Redo()
  	{
  	}

  	public event DocumentStateChangedHandler DocumentStateChanged;

  	#endregion
  }
}
