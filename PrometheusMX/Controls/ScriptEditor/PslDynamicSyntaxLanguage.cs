using System;
using System.Collections.Generic;
using System.Web;
using ActiproSoftware.SyntaxEditor;
using ActiproSoftware.SyntaxEditor.Addons.Dynamic;
using System.Text;
using System.Windows.Forms;
using Interfaces.Scripting.EngineDefinition;

namespace Prometheus.Controls.ScriptEditor
{

  /// <summary>
  /// Provides an implementation of a <c>PSL</c> syntax language that can perform automatic outlining.
  /// </summary>
  public class PslDynamicSyntaxLanguage : DynamicOutliningSyntaxLanguage
  {
    /////////////////////////////////////////////////////////////////////////////////////////////////////
    // OBJECT
    /////////////////////////////////////////////////////////////////////////////////////////////////////

    /// <summary>
    /// This constructor is for designer use only and should never be called by your code.
    /// </summary>
    public PslDynamicSyntaxLanguage() : base() { }

    /// <summary>
    /// Initializes a new instance of the <c>PslDynamicSyntaxLanguage</c> class. 
    /// </summary>
    /// <param name="key">The key of the language.</param>
    /// <param name="secure">Whether the language is secure.</param>
    public PslDynamicSyntaxLanguage(string key, bool secure) : base(key, secure) { }

    /////////////////////////////////////////////////////////////////////////////////////////////////////
    // PUBLIC PROCEDURES
    /////////////////////////////////////////////////////////////////////////////////////////////////////

    /// <summary>
    /// Returns token parsing information for automatic outlining that determines if the current <see cref="IToken"/>
    /// in the <see cref="TokenStream"/> starts or ends an outlining node.
    /// </summary>
    /// <param name="tokenStream">A <see cref="TokenStream"/> that is positioned at the <see cref="IToken"/> requiring outlining data.</param>
    /// <param name="outliningKey">Returns the outlining node key to assign.  A <see langword="null"/> should be returned if the token doesn't start or end a node.</param>
    /// <param name="tokenAction">Returns the <see cref="OutliningNodeAction"/> to take for the token.</param>
    public override void GetTokenOutliningAction(TokenStream tokenStream, ref string outliningKey, ref OutliningNodeAction tokenAction)
    {
      // Get the token
      IToken token = tokenStream.Peek();

      // See if the token starts or ends an outlining node
      switch (token.Key)
      {
        case "OpenCurlyBraceToken":
          outliningKey = "CodeBlock";
          tokenAction = OutliningNodeAction.Start;
          break;
        case "CloseCurlyBraceToken":
          outliningKey = "CodeBlock";
          tokenAction = OutliningNodeAction.End;
          break;
        case "MultiLineCommentStartToken":
          outliningKey = "MultiLineComment";
          tokenAction = OutliningNodeAction.Start;
          break;
        case "MultiLineCommentEndToken":
          outliningKey = "MultiLineComment";
          tokenAction = OutliningNodeAction.End;
          break;
        case "XMLCommentStartToken":
          outliningKey = "XMLComment";
          tokenAction = OutliningNodeAction.Start;
          break;
        case "XMLCommentEndToken":
          outliningKey = "XMLComment";
          tokenAction = OutliningNodeAction.End;
          break;
        case "RegionPreProcessorDirectiveStartToken":
          outliningKey = "RegionPreProcessorDirective";
          tokenAction = OutliningNodeAction.Start;
          break;
        case "EndRegionPreProcessorDirectiveStartToken":
          outliningKey = "RegionPreProcessorDirective";
          tokenAction = OutliningNodeAction.End;
          break;
      }
    }

    /// <summary>
    /// Occurs after automatic outlining is performed on a <see cref="Document"/> that uses this language.
    /// </summary>
    /// <param name="document">The <see cref="Document"/> that is being modified.</param>
    /// <param name="e">A <c>DocumentModificationEventArgs</c> that contains the event data.</param>
    /// <remarks>
    /// A <see cref="DocumentModification"/> may or may not be passed in the event arguments, depending on if the outlining
    /// is performed in the main thread.
    /// </remarks>
    protected override void OnDocumentAutomaticOutliningComplete(Document document, DocumentModificationEventArgs e)
    {
      // If programmatically setting the text of a document...
      if (e.IsProgrammaticTextReplacement)
      {
        // Collapse all outlining region nodes
        document.Outlining.RootNode.CollapseDescendants("RegionPreProcessorDirective");
      }
    }

    class NamespaceReference
    {
      public System.Collections.Generic.List<string> Namespace = new System.Collections.Generic.List<string>();

      public override string ToString()
      {
        StringBuilder sb = new StringBuilder();
        foreach (string s in Namespace)
        {
          sb.Append(s);
          sb.Append(".");
        }
        return sb.ToString().TrimEnd('.');
      }
    }

    private ScriptEngineDefinition m_scriptEngineDefinition;
    
    public void LoadScriptEngineDefinition(ScriptEngineDefinition def)
    {
      m_scriptEngineDefinition = def;
      m_scriptEngineDefinition.CreateNamespaceLookup();
    }

		private Function GetFunction(TextStream textStream, Document document)
  	{
			int nesting = 0;
			while (nesting != -1)
			{
				if (textStream.TokenIndex == 0)
					return null;
				
				textStream.SeekToken(-1);

				switch (textStream.PeekToken().Key)
				{
					case "OpenParenthesisToken":
						nesting--;
						break;
					case "CloseParenthesisToken":
						nesting++;
						break;
				}
			}

			if (!textStream.GoToPreviousToken())
				return null;

			string functionName;
			if (textStream.Token.Key == "IdentifierToken")
				functionName = document.GetTokenText(textStream.Token);
			else
				return null;
			
			/*if (textStream.TokenIndex == 0)
				return null;

			textStream.SeekToken(-1);*/

			Namespace ns = GetNamespace(textStream, document);

			if (ns == null)
				return null;
			
			foreach (Function f in ns.Functions)
			{
				if (f.Name == functionName)
					return f;
			}
			return null;
  	}

    private Namespace GetNamespace(TextStream textStream, Document document)
    {
      Namespace ns = null;
      Dictionary<string, Namespace> lookup;
      
      List<string> parts = new List<string>();
      while (textStream.GoToPreviousToken() && textStream.Token.Key == "DotOperatorToken")
      {
        textStream.GoToPreviousToken();
        IToken token = textStream.PeekToken();
        if (token.Key != "IdentifierToken")
          break;
        parts.Insert(0, document.GetTokenText(token));
      }
      foreach (string part in parts)
      {
        if (ns == null)
          lookup = m_scriptEngineDefinition.NamespaceLookup;
        else
          lookup = ns.NamespaceLookup;

        if (!lookup.TryGetValue(part, out ns))
          return null;
      }
      return ns;
    }

    /// <summary>
    /// Occurs after a <see cref="Trigger"/> is activated
    /// for a <see cref="SyntaxEditor"/> that has a <see cref="Document"/> using this language.
    /// </summary>
    /// <param name="syntaxEditor">The <see cref="SyntaxEditor"/> that will raise the event.</param>
    /// <param name="e">An <c>TriggerEventArgs</c> that contains the event data.</param>
    protected override void OnSyntaxEditorTriggerActivated(SyntaxEditor syntaxEditor, TriggerEventArgs e)
    {
      switch (e.Trigger.Key)
      {
        case "MemberListTrigger":
          {
          	// Hide parameter info
						syntaxEditor.IntelliPrompt.ParameterInfo.Hide();
          	
            // Create an intermediate member list
						List<IntelliPromptMemberListItem> memberList = new List<IntelliPromptMemberListItem>();
            
          	// Retrieve the namespace in front of the caret
          	TextStream scriptStream = syntaxEditor.Document.GetTextStream(syntaxEditor.Caret.Offset);
            Namespace ns = GetNamespace(scriptStream, syntaxEditor.Document);

          	// Set the image list
						syntaxEditor.IntelliPrompt.MemberList.ImageList = SyntaxEditor.ReflectionImageList;

            // Add items to the intermediate list
            if (ns != null)
            {
              int imageIndex;
              
              imageIndex = (int)ActiproSoftware.Products.SyntaxEditor.IconResource.PublicMethod;
              foreach (Function f in ns.Functions)
              {
								memberList.Add(new IntelliPromptMemberListItem(f.Name, imageIndex, GetFunctionDescription(f, -1)));
              }
              
              imageIndex = (int)ActiproSoftware.Products.SyntaxEditor.IconResource.PublicField;
              foreach (Global g in ns.Globals)
              {
								memberList.Add(new IntelliPromptMemberListItem(g.Name, imageIndex, GetGlobalDescription(g)));
              }
              
              imageIndex = (int)ActiproSoftware.Products.SyntaxEditor.IconResource.Namespace;
              foreach (Namespace n in ns.Namespaces)
              {
                memberList.Add(new IntelliPromptMemberListItem(n.Name, imageIndex));
              }
            }

						syntaxEditor.IntelliPrompt.MemberList.Clear();
          	
            // Commit and show the list
						if (memberList.Count > 0)
						{
							// Add all member list items at once for better performance
							syntaxEditor.IntelliPrompt.MemberList.AddRange(memberList.ToArray());
							syntaxEditor.IntelliPrompt.MemberList.Show();
						}
            break;
          }
				case "OpenParameterInfoTrigger":
      		{
						IntelliPromptParameterInfo paramInfo = syntaxEditor.IntelliPrompt.ParameterInfo;
						paramInfo.Info.Clear();

						TextStream scriptStream = syntaxEditor.Document.GetTextStream(syntaxEditor.Caret.Offset);
						Function f = GetFunction(scriptStream, syntaxEditor.Document);
						if (f == null)
						{
							paramInfo.Hide();
							break;
						}
      			
						for (int i = 0; i < f.Overloads.Length; i++)
							paramInfo.Info.Add(GetFunctionDescription(f, i));
      			
						paramInfo.Show(syntaxEditor.Caret.Offset);
      			break;
      		}
				case "CloseParameterInfoTrigger":
					{
						IntelliPromptParameterInfo paramInfo = syntaxEditor.IntelliPrompt.ParameterInfo;
						paramInfo.Info.Clear();

						TextStream scriptStream = syntaxEditor.Document.GetTextStream(syntaxEditor.Caret.Offset);
						Function f = GetFunction(scriptStream, syntaxEditor.Document);
						if (f == null)
						{
							paramInfo.Hide();
							break;
						}

						for (int i = 0; i < f.Overloads.Length; i++)
							paramInfo.Info.Add(GetFunctionDescription(f, i));

						paramInfo.Show(syntaxEditor.Caret.Offset);
						break;
					}
      }
    }
  	
  	private string GetFormattedTypeString(short type)
  	{
			// out of action
			// take all logic into a separate class out of the gui assembly
  		return "";
  		/*string typeString;
			if (type >= (int)ScriptValueType.GameSpecificTypesStart)
				typeString = m_scriptEngineDefinition.ExtendedTypes[type - (int)ScriptValueType.GameSpecificTypesStart].Name;
			else
				typeString = ((ScriptValueType)type).ToString().ToLower();
			return "<span style=\"color: #0000FF\">" + typeString + "</span>";*/
  	}
  	
  	private string GetFunctionDescription(Function f, int index)
  	{
			string overloadIndicator = String.Empty;

  		if (index == -1)
  		{
				index = 0;
				if (f.Overloads.Length > 1)
					overloadIndicator = String.Format("&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span style=\"color: #888888; font-size: 7.5pt\">(+{0} overloads)</span>", f.Overloads.Length - 1);
  		}
  		
			InternalFunction iF = f.Overloads[index];
  		
			StringBuilder description = new StringBuilder();

			description.Append(GetFormattedTypeString(iF.ReturnType) + " ");
			description.Append("<strong>" + f.Name + "</strong>(");
			for (int i = 0; i < iF.Arguments.Length; i++)
			{
				description.Append(GetFormattedTypeString(iF.Arguments[i].Type));
				if (iF.Arguments[i].Name != String.Empty)
					description.Append(" " + iF.Arguments[i].Name);
				if (i != iF.Arguments.Length - 1)
					description.Append(", ");
			}
			description.Append(")" + overloadIndicator + "<br /><span style=\"color: #008800\">" + IntelliPrompt.EscapeMarkupText(iF.Description) + "</span>");
			
  		return description.ToString();
  	}

		private string GetGlobalDescription(Global g)
		{
			StringBuilder description = new StringBuilder();

			description.Append(GetFormattedTypeString(g.Type) + " ");
			description.Append("<strong>" + g.Name + "</strong>");
			if (g.Description != String.Empty)
				description.Append("<br /><span style=\"color: #008800\">"+IntelliPrompt.EscapeMarkupText(g.Description)+"</span>");

			bool get = true;
			bool set = true;
			if (g.IsProperty)
			{
				get = g.GetAccessor != null;
				set = g.SetAccessor != null;
			}

			description.Append("<br /><span style=\"font-size: 7.5pt\">Supports: <span style=\"color: #0000FF\">" + (get ? "get</span>; " : "") + (set ? (get ? "<span style=\"color: #0000FF\">set" : "set") : "") +"</span>;</span>");

			return description.ToString();
		}

    protected override void OnSyntaxEditorSmartIndent(SyntaxEditor syntaxEditor, SmartIndentEventArgs e)
    {
			TokenStream tokenStream = syntaxEditor.Document.GetTokenStream(syntaxEditor.SelectedView.GetCurrentToken());
			int nesting = 0;
			while (nesting != -1)
			{
				tokenStream.Seek(-1);
				if (tokenStream.Position < 0)
					return;
				
				switch (tokenStream.Peek().Key)
				{
					case "OpenCurlyBraceToken":
						nesting--;
						break;
					case "CloseCurlyBraceToken":
						nesting++;
						break;
				}
			}
    	
    	int indent = 0;
    	if (nesting == -1)
    	{
				int startIndex;
				IToken indentToken = GetLineIndent(tokenStream, out startIndex);
				indent = GetAbsoluteWhitespaceLength(indentToken, syntaxEditor.Document) + syntaxEditor.Document.TabSize;
    	}

			e.IndentAmount = indent;
    }

    private IToken GetLineIndent(TokenStream tokens, out int startIndex)
    {
      while (tokens.Position != 0 && tokens.PeekReverse().Key != "LineTerminatorToken")
        tokens.Seek(-1);
      IToken spacer = tokens.Peek();
      startIndex = spacer.StartOffset;
      return spacer.IsWhitespace ? spacer : null;
    }
  	
  	private int GetAbsoluteWhitespaceLength(IToken token, Document document)
  	{
  		if (token == null)
  			return 0;
  		
  		int length = 0;
  		
  		string tokenText = document.GetTokenText(token);
			foreach (char c in tokenText)
				length += c == '\t' ? document.TabSize : 1;
  		
  		return length;
  	}
    
    protected override void OnSyntaxEditorKeyTyped(SyntaxEditor syntaxEditor, KeyTypedEventArgs e)
    {
      //TextStream scriptStream = syntaxEditor.Document.GetTextStream(syntaxEditor.Caret.Offset);
      
      switch (e.KeyChar)
      {
        case '{':
          break;
        case '}':
          BracketHighlighting brackets = syntaxEditor.SelectedView.BracketHighlighting;
          if (brackets.MatchingBracketToken == null)
            break;
          
          TokenStream startTokens = syntaxEditor.Document.GetTokenStream(brackets.MatchingBracketToken);
          int startLineStart;
          IToken startSpacer = GetLineIndent(startTokens, out startLineStart);
          TokenStream endTokens = syntaxEditor.Document.GetTokenStream(brackets.BracketToken);
          int endLineStart;
          IToken endSpacer = GetLineIndent(endTokens, out endLineStart);

          TextRange replace = endSpacer != null ? endSpacer.TextRange : new TextRange(endLineStart);
          
          if (replace.EndOffset != brackets.BracketToken.StartOffset)
            break;
          
          syntaxEditor.Document.ReplaceText(DocumentModificationType.AutoIndent, replace,
            startSpacer != null ? syntaxEditor.Document.GetTokenText(startSpacer) : String.Empty, DocumentModificationOptions.RetainSelection);
         
          break;
      }
    }

    /// <summary>
    /// Allows for setting the collapsed text for the specified <see cref="OutliningNode"/>.
    /// </summary>
    /// <param name="node">The <see cref="OutliningNode"/> that is requesting collapsed text.</param>
    public override void SetOutliningNodeCollapsedText(OutliningNode node)
    {
      TokenCollection tokens = node.Document.Tokens;
      int tokenIndex = tokens.IndexOf(node.StartOffset);

      switch (tokens[tokenIndex].Key)
      {
        case "MultiLineCommentStartToken":
        case "XMLCommentStartToken":
          node.CollapsedText = "/**/";
          break;
        case "RegionPreProcessorDirectiveStartToken":
          {
            string collapsedText = String.Empty;
            while (++tokenIndex < tokens.Count)
            {
              if (tokens[tokenIndex].Key == "PreProcessorDirectiveEndToken")
                break;

              collapsedText += tokens.Document.GetTokenText(tokens[tokenIndex]);
            }
            node.CollapsedText = collapsedText.Trim();
            break;
          }
      }
    }

  }
}
