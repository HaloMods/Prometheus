using System;
using System.CodeDom;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Security.Principal;
using System.Xml;
using Interfaces.Factory;
using Interfaces.Games;
using Interfaces.Pool;
using Microsoft.CSharp;

namespace Core.Factory
{
  /// <summary>
  /// Generates a C# class for a tag definition based on an XML plugin file.
  /// </summary>
  public class ClassGenerator
  {
    public static bool DebugMode = false;

    private string typedefNamespace = null;
    private Assembly typedefAssembly = null;
    private CodeDomProvider provider = null;
    private CodeGeneratorOptions codeGenOptions = null;
    private CodeNamespace ns = null;
    private CodeTypeDeclaration rootClassDeclaration = null;

    public ClassGenerator(Assembly typeDefinitionAssembly, string typeDefinitionNamespace)
    {
      // Save typedef assembly info.
      typedefNamespace = typeDefinitionNamespace;
      typedefAssembly = typeDefinitionAssembly;
    }

    private void InitializeCodeGenerator()
    {
      provider = new CSharpCodeProvider();
      codeGenOptions = new CodeGeneratorOptions();
      codeGenOptions.BlankLinesBetweenMembers = false;
      codeGenOptions.IndentString = "  ";
      codeGenOptions.BracingStyle = "Block";
    }

    private CodeNamespace GenerateNamespaceAndImports(string platformName, string className, string parentType)
    {
      platformName = platformName.Replace(" ", "");
      platformName = platformName.Replace("Halo1", "Halo");
      CodeNamespace cns = new CodeNamespace("Games." + platformName + ".Tags.Classes");

      string headerLine1 = String.Format("Prometheus Tag Library - {0}", platformName);
      string userName = WindowsIdentity.GetCurrent().Name.ToString();

      if (userName.Contains("_AZ")) userName = "Grenadiac";
      if (userName.Contains("Owner")) userName = "The Swamp Fox";
      if (userName.Contains("Black")) userName = "MonoxideC";

      string objectName = String.Format("Tag definition for '{0}'", className);
      if (parentType != null) objectName += String.Format(" (derived from '{0}')", parentType);
      string buildInfo = String.Format("Generated on {0} at {1} by {2}", DateTime.Today.ToShortDateString(),
        DateTime.Now.ToShortTimeString(), userName);
      string commentBorder = new string('-', StringOps.LongestStringLength(headerLine1, buildInfo, objectName));

      cns.Comments.Add(new CodeCommentStatement(commentBorder));
      cns.Comments.Add(new CodeCommentStatement(headerLine1));
      cns.Comments.Add(new CodeCommentStatement(objectName));
      cns.Comments.Add(new CodeCommentStatement(buildInfo));
      cns.Comments.Add(new CodeCommentStatement(commentBorder));

      cns.Imports.Add(new CodeNamespaceImport("System.IO"));
      cns.Imports.Add(new CodeNamespaceImport("System.Diagnostics"));
      cns.Imports.Add(new CodeNamespaceImport("System.Collections.Generic"));
      cns.Imports.Add(new CodeNamespaceImport("Interfaces"));
      cns.Imports.Add(new CodeNamespaceImport("Interfaces.Factory"));
      cns.Imports.Add(new CodeNamespaceImport(typedefNamespace));

      return (cns);
    }

    private CodeTypeDeclaration GenerateRootClass(string className, string friendlyClassName, string mainBlockName, string parentType, string extension)
    {
      // Setup the class type declaration.
      CodeTypeDeclaration classType = new CodeTypeDeclaration(className);
      classType.IsClass = true;
      classType.IsPartial = true;
      classType.TypeAttributes = TypeAttributes.Public;
      if (parentType != null)
        classType.BaseTypes.Add(parentType);
      else
        classType.BaseTypes.Add(typeof(Tag));
      
      // Use the friendly name from here on.
      className = friendlyClassName;
      className = className.Substring(0, 1).ToLower() + className.Substring(1);

      CodeMemberField mainField = new CodeMemberField(mainBlockName, className + "Values");
      mainField.InitExpression = new CodeObjectCreateExpression(mainBlockName, new CodeExpression[] { });
      classType.Members.Add(mainField);

      // Create the Property for the main values block (for use with DataBinding).
      CodeMemberProperty mainProperty = new CodeMemberProperty();
      mainProperty.Type = new CodeTypeReference(mainBlockName);
      mainProperty.Name = StringOps.CapitalizeWords(className + "Values");
      mainProperty.HasGet = true;
      mainProperty.HasSet = false;
      mainProperty.Attributes = MemberAttributes.Public;
      mainProperty.GetStatements.Add(new CodeMethodReturnStatement(new CodeArgumentReferenceExpression(className + "Values"))); 
      classType.Members.Add(mainProperty);

      CodeMemberProperty tagReferences = new CodeMemberProperty();
      tagReferences.Type = new CodeTypeReference(typeof(string[]));
      tagReferences.Name = "TagReferenceList";
      tagReferences.HasGet = true;
      tagReferences.HasSet = false;
      tagReferences.Attributes = MemberAttributes.Public | MemberAttributes.Override;
      tagReferences.GetStatements.Add(new CodeSnippetStatement("UniqueStringCollection references = new UniqueStringCollection();"));
      if (parentType != null) tagReferences.GetStatements.Add(new CodeSnippetStatement(
        "references.AddRange(base.TagReferenceList);"));
      tagReferences.GetStatements.Add(new CodeSnippetStatement("references.AddRange(" + mainProperty.Name + ".TagReferenceList);"));
      tagReferences.GetStatements.Add(new CodeSnippetStatement("return references.ToArray();"));
      classType.Members.Add(tagReferences);
      
      // create the FileExtension property
      classType.Members.Add(GenerateExtensionProperty(extension));

      // Create the standard methods.
      CodeMemberMethod loadMethod = GenerateLoadMethod(parentType != null);
      loadMethod.StartDirectives.Add(new CodeRegionDirective(CodeRegionMode.Start, "Read/Write Methods"));
      classType.Members.Add(loadMethod);
      classType.Members.Add(CreateReadWriteMethod("Read", parentType, "BinaryReader", "reader", className));
      classType.Members.Add(CreateReadWriteMethod("ReadChildData", parentType, "BinaryReader", "reader", className));
      classType.Members.Add(GenerateSaveMethod(parentType != null));
      classType.Members.Add(CreateReadWriteMethod("Write", parentType, "BinaryWriter", "writer", className));

      CodeMemberMethod readWriteMethod = CreateReadWriteMethod("WriteChildData", parentType, "BinaryWriter", "writer", className);
      readWriteMethod.EndDirectives.Add(new CodeRegionDirective(CodeRegionMode.End, string.Empty));
      classType.Members.Add(readWriteMethod);

      return (classType);
    }

    protected CodeMemberEvent GeneratePostProcessEvent()
    {
      CodeMemberEvent cme = new CodeMemberEvent();
      cme.Type = new CodeTypeReference(typeof(EventHandler));
      cme.Name = "PostProcess";
      cme.Attributes = MemberAttributes.Private;
      cme.Comments.Add(new CodeCommentStatement("Fires when the initial loading is completed and the tag is ready to be post-processed."));
      return cme;
    }

    protected CodeMemberProperty GenerateExtensionProperty(string extension)
    {
      CodeMemberProperty cmp = new CodeMemberProperty();
      cmp.Type = new CodeTypeReference(typeof(string));
      cmp.Name = "FileExtension";
      cmp.HasGet = true;
      cmp.HasSet = false;
      cmp.Attributes = MemberAttributes.Public | MemberAttributes.Override;

      cmp.GetStatements.Add(new CodeSnippetStatement("return \"" + extension + "\";"));

      return cmp;
    }

    protected CodeMemberMethod GenerateReadMethod(List<XmlNode> fieldList, bool isBase)
    {
      CodeMemberMethod readMethod = new CodeMemberMethod();
      readMethod.ReturnType = new CodeTypeReference(typeof(void));
      readMethod.Name = "Read";
      readMethod.Parameters.Add(new CodeParameterDeclarationExpression("BinaryReader", "reader"));
      readMethod.Attributes = MemberAttributes.Public/* | MemberAttributes.Override*/;
      if (isBase)
        readMethod.Attributes |= MemberAttributes.Override;

      bool bFirstPass = true;
      foreach (XmlNode fieldNode in fieldList)
      {
        if (bFirstPass)
          bFirstPass = false;

        if (fieldNode.Attributes["type"].InnerText == "Custom") continue;
        if (fieldNode.Attributes["type"].InnerText == "ArrayStart") continue;
        string name = GlobalMethods.MakePrivateName(fieldNode.Attributes["name"].InnerText);

        CodeMethodInvokeExpression readField = new CodeMethodInvokeExpression(
        new CodeVariableReferenceExpression(name), "Read", new CodeVariableReferenceExpression("reader"));
        readMethod.Statements.Add(readField);
      }

      return (readMethod);
    }
    protected CodeMemberMethod GenerateWriteMethod(List<XmlNode> fieldList, bool isBase)
    {
      CodeMemberMethod writeMethod = new CodeMemberMethod();
      writeMethod.ReturnType = new CodeTypeReference(typeof(void));
      writeMethod.Name = "Write";
      writeMethod.Parameters.Add(new CodeParameterDeclarationExpression("BinaryWriter", "bw"));
      writeMethod.Attributes = MemberAttributes.Public/* | MemberAttributes.Override*/;
      if (isBase)
        writeMethod.Attributes |= MemberAttributes.Override;

      bool bFirstPass = true;
      foreach (XmlNode fieldNode in fieldList)
      {
        if (bFirstPass)
          bFirstPass = false;

        //todo:  figure out how to add the "offset check" to see if data is in the right spot
        if (fieldNode.Attributes["type"].InnerText == "Custom") continue;
        if (fieldNode.Attributes["type"].InnerText == "ArrayStart") continue;

				string name = GlobalMethods.MakePrivateName(fieldNode.Attributes["name"].InnerText);

				if ((fieldNode.Attributes["type"].InnerText == "Block") || (fieldNode.Attributes["type"].InnerText == "H2Block"))
				{
					string blockCollection = name.Substring(1, 1).ToUpper() + name.Substring(2);
					writeMethod.Statements.Add(new CodeSnippetStatement(name + ".Count = " + blockCollection + ".Count;"));
				}

        CodeMethodInvokeExpression writeField = new CodeMethodInvokeExpression(
        new CodeVariableReferenceExpression(name), "Write", new CodeVariableReferenceExpression("bw"));
        writeMethod.Statements.Add(writeField);
      }

      return (writeMethod);
    }
    protected CodeMemberMethod GenerateLoadMethod(bool bHasParentType)
    {
      CodeMemberMethod loadMethod = new CodeMemberMethod();
      loadMethod.ReturnType = new CodeTypeReference(typeof(int));
      loadMethod.Name = "Load";
      loadMethod.Parameters.Add(new CodeParameterDeclarationExpression(typeof(byte[]), "metadata"));
      loadMethod.Attributes = MemberAttributes.Public | MemberAttributes.Override;

      loadMethod.Statements.Add(new CodeVariableDeclarationStatement(typeof(BinaryReader), "reader", new CodeObjectCreateExpression(typeof(BinaryReader), new CodeObjectCreateExpression(typeof(MemoryStream), new CodeVariableReferenceExpression("metadata")))));
      //if (bHasParentType)
      //  loadMethod.Statements.Add(new CodeSnippetStatement("reader.BaseStream.Position = base.Load(metadata);"));
      loadMethod.Statements.Add(new CodeSnippetStatement("Read(reader);"));
      loadMethod.Statements.Add(new CodeSnippetStatement("int position = (int)reader.BaseStream.Position;"));
      loadMethod.Statements.Add(new CodeSnippetStatement("ReadChildData(reader);"));
      loadMethod.Statements.Add(new CodeSnippetStatement("reader.Close();"));
      loadMethod.Statements.Add(new CodeMethodReturnStatement(new CodeVariableReferenceExpression("position")));

      return (loadMethod);
    }

    protected CodeMemberMethod GenerateSaveMethod(bool bHasParentType)
    {
      CodeMemberMethod saveMethod = new CodeMemberMethod();
      saveMethod.ReturnType = new CodeTypeReference(typeof(byte[]));
      saveMethod.Name = "Save";
      saveMethod.Attributes = MemberAttributes.Public | MemberAttributes.Override;

      //saveMethod.Statements.Add(new CodeVariableDeclarationStatement(typeof(BinaryWriter), "writer", new CodeObjectCreateExpression(typeof(BinaryWriter), new CodeObjectCreateExpression(typeof(MemoryStream)))));
      //if (bHasParentType)
      //  loadMethod.Statements.Add(new CodeSnippetStatement("reader.BaseStream.Position = base.Load(metadata);"));
      saveMethod.Statements.Add(new CodeSnippetStatement("BinaryWriter writer = new BinaryWriter(new MemoryStream());"));
      saveMethod.Statements.Add(new CodeSnippetStatement("Write(writer);"));
      saveMethod.Statements.Add(new CodeSnippetStatement("WriteChildData(writer);"));
      saveMethod.Statements.Add(new CodeSnippetStatement("return (writer.BaseStream as MemoryStream).ToArray();"));
      //saveMethod.Statements.Add(new CodeMethodReturnStatement(new CodeVariableReferenceExpression("metadata")));

      return (saveMethod);
    }


    private CodeIterationStatement GenerateForLoop(CodeFieldReferenceExpression stopVariableValue)
    {
      CodeAssignStatement forStart = new CodeAssignStatement(new CodeVariableReferenceExpression("x"), new CodePrimitiveExpression(0));

      CodeBinaryOperatorExpression forTest = new CodeBinaryOperatorExpression(new CodeVariableReferenceExpression("x"),
        CodeBinaryOperatorType.LessThan, stopVariableValue);

      CodeAssignStatement forIncrement = new CodeAssignStatement(new CodeVariableReferenceExpression("x"), new CodeBinaryOperatorExpression(
        new CodeVariableReferenceExpression("x"), CodeBinaryOperatorType.Add, new CodePrimitiveExpression(1)));

      CodeIterationStatement forLoopRead = new CodeIterationStatement(forStart, forTest, forIncrement);

      return (forLoopRead);
    }
    private CodeMethodInvokeExpression GenerateBlockIndexTrace(string counterVar, string blockName)
    {
      CodeMethodInvokeExpression traceBlockNum = new CodeMethodInvokeExpression(
          new CodeTypeReferenceExpression("Trace"),
          "WriteLine",
          new CodeExpression[] {
                 new CodeMethodInvokeExpression(new CodeTypeReferenceExpression("System.String"), "Format",
              new CodeExpression[] {new CodePrimitiveExpression("  " + blockName + " Block {0}"),
                new CodeVariableReferenceExpression(counterVar)
              })
               });

      return (traceBlockNum);
    }

    private CodeTypeMemberCollection GeneratePrivateMemberVars(List<XmlNode> fieldList)
    {
      CodeTypeMemberCollection members = new CodeTypeMemberCollection();
      foreach (XmlNode fieldNode in fieldList)
      {
        try
        {
          if (fieldNode.Attributes["type"].InnerText == "Custom") continue;
          if (fieldNode.Attributes["type"].InnerText == "ArrayStart") continue;
          members.Add(GeneratePrivateMember(fieldNode));
        }
        catch (Exception ex)
        {
          throw new Exception(fieldNode.Attributes["type"].InnerText + " - GeneratePrivateMember on " + fieldNode.Attributes["name"].InnerText + " : " + ex.Message);
        }
      }
      return members;
    }
    private void GenerateConstructorStatements(List<XmlNode> fieldList, CodeConstructor cc)
    {
      foreach (XmlNode fieldNode in fieldList)
      {
        try
        {
          if (fieldNode.Attributes["type"].InnerText == "Custom") continue;
          if (fieldNode.Attributes["type"].InnerText == "ArrayStart") continue;
          CodeStatement constructorStatement = GenerateConstructorLogic(fieldNode);
          if (constructorStatement != null) cc.Statements.Add(constructorStatement);
        }
        catch (Exception ex)
        {
          throw new Exception(fieldNode.Attributes["type"].InnerText + " - GenerateConstructorLogic on " + fieldNode.Attributes["name"].InnerText + " : " + ex.Message);
        }
      }
    }
    private CodeMethodInvokeExpression GenerateBlockOffsetCheckCode(string blockName)
    {
      CodeMethodInvokeExpression methodInvoke = new CodeMethodInvokeExpression(
          new CodeTypeReferenceExpression("TagDebug"),
          "CheckOffset",
          new CodeExpression[] {
                 new CodeVariableReferenceExpression("reader.BaseStream.Position"),
                 new CodeVariableReferenceExpression(blockName),
                 new CodePrimitiveExpression(blockName)
               });

      return (methodInvoke);
    }
    private void GenerateBlockCollectionAccessors(List<XmlNode> fieldList, CodeTypeDeclaration classType, CodeMemberProperty tagReferences)
    {
      foreach (XmlNode fieldNode in fieldList)
      {
        try
        {
          if (fieldNode.Attributes["type"].InnerText == "Custom") continue;
          if (fieldNode.Attributes["type"].InnerText == "ArrayStart") continue;
          if ((fieldNode.Attributes["type"].InnerText == "Block") || (fieldNode.Attributes["type"].InnerText == "H2Block"))
          {
            string blockName = fieldNode.Attributes["struct"].InnerText + "Block";
            string linkName = GlobalMethods.MakePrivateName(fieldNode.Attributes["name"].InnerText);
            string memberName = linkName + "List";
            
            //FIX: Underscore problem (no bug ID)
            string publicName = linkName.Substring(1, 1).ToUpper() + linkName.Substring(2);

            // Add the member variable block List<>
            CodeTypeReference collectionType = new CodeTypeReference("BlockCollection", new CodeTypeReference[] { new CodeTypeReference(blockName) });
            CodeMemberField blockList = new CodeMemberField();
            blockList.Attributes = MemberAttributes.Public;
            blockList.Type = collectionType;
            blockList.Name = memberName;
            blockList.InitExpression = new CodeObjectCreateExpression(collectionType);

            classType.Members.Add(blockList);

            // Generate the public collection accessor.
            CodeMemberProperty collectionAccessor = new CodeMemberProperty();
            collectionAccessor.Name = publicName;
            collectionAccessor.Type = collectionType;
            collectionAccessor.Attributes = MemberAttributes.Public | MemberAttributes.Final;
            collectionAccessor.HasGet = true;
            collectionAccessor.HasSet = false;
            collectionAccessor.GetStatements.Add(
              new CodeMethodReturnStatement(
              new CodeFieldReferenceExpression(
              new CodeThisReferenceExpression(), memberName)));

            classType.Members.Add(collectionAccessor);

            tagReferences.GetStatements.Add(new CodeSnippetStatement("for (int x=0; x<" + publicName + ".BlockCount; x++)"));
            tagReferences.GetStatements.Add(new CodeSnippetStatement("{"));
            tagReferences.GetStatements.Add(new CodeSnippetStatement("  IBlock block = " + publicName + ".GetBlock(x);"));
            tagReferences.GetStatements.Add(new CodeSnippetStatement("  references.AddRange(block.TagReferenceList);"));
            tagReferences.GetStatements.Add(new CodeSnippetStatement("}"));
          }
        }
        catch (Exception ex)
        {
          throw new Exception(fieldNode.Attributes["type"].InnerText + " - GenerateBlockCollection on " + fieldNode.Attributes["name"].InnerText + " : " + ex.Message);
        }
      }
    }
    private void GenerateOtherPublicAccessors(List<XmlNode> fieldList, CodeTypeDeclaration ctd)
    {
      foreach (XmlNode fieldNode in fieldList)
      {
        try
        {
          // We don't need public accessors for pad or block fields.
          if (fieldNode.Attributes["type"].InnerText == "Pad") continue;
          if (fieldNode.Attributes["type"].InnerText == "Block") continue;
          if (fieldNode.Attributes["type"].InnerText == "H2Block") continue;
          if (fieldNode.Attributes["type"].InnerText == "Custom") continue;
          if (fieldNode.Attributes["type"].InnerText == "Skip") continue;
          if (fieldNode.Attributes["type"].InnerText == "ArrayStart") continue;
          ctd.Members.Add(GeneratePublicAccessors(fieldNode));
        }
        catch (Exception ex)
        {
          throw new Exception(fieldNode.Attributes["type"].InnerText + " - GeneratePublicAccessors on " + fieldNode.Attributes["name"].InnerText + " : " + ex.Message);
        }
      }
    }
    private CodeMemberMethod GenerateReadChildrenMethod(List<XmlNode> fieldList, bool isBase)
    {
      // Generate the ReadChildData method.
      // This reads strings, child blocks, and data fields in the order that they appear.
      CodeMemberMethod readChildDataMethod = new CodeMemberMethod();
      readChildDataMethod.ReturnType = new CodeTypeReference(typeof(void));
      readChildDataMethod.Name = "ReadChildData";
      readChildDataMethod.Parameters.Add(new CodeParameterDeclarationExpression("BinaryReader", "reader"));
      readChildDataMethod.Attributes = MemberAttributes.Public/* | MemberAttributes.Final*/;
      if (isBase)
        readChildDataMethod.Attributes |= MemberAttributes.Override;

      foreach (XmlNode fieldNode in fieldList)
      {
        if ((fieldNode.Attributes["type"].InnerText == "Block") || (fieldNode.Attributes["type"].InnerText == "H2Block"))
        {
          readChildDataMethod.Statements.Add(new CodeVariableDeclarationStatement(typeof(int), "x", new CodePrimitiveExpression(0)));
          break;
        }
      }

      //for loop blocks
      foreach (XmlNode fieldNode in fieldList)
      {
        string name = GlobalMethods.MakePrivateName(fieldNode.Attributes["name"].InnerText);
        string type = fieldNode.Attributes["type"].InnerText;
        if ((type == "Block") || (type == "H2Block"))
        {
          string blockName = fieldNode.Attributes["struct"].InnerText + "Block";
          //fix underscore problem
          string blockCollection = name.Substring(1, 1).ToUpper() + name.Substring(2);

          //readChildDataMethod.Statements.Add(GenerateBlockOffsetCheckCode(name));

          CodeIterationStatement forLoopRead = GenerateForLoop(new CodeFieldReferenceExpression(
              new CodeVariableReferenceExpression(name), "Count"));

          //Read loop child:  debug trace output
          //forLoopRead.Statements.Add(new CodeExpressionStatement(GenerateBlockIndexTrace("x", name)));
          //Read loop child:  Add new block
          forLoopRead.Statements.Add(new CodeExpressionStatement(
                new CodeMethodInvokeExpression(new CodeVariableReferenceExpression(blockCollection), "Add", new CodeExpression[] { new CodeObjectCreateExpression(blockName) })));
          //Read loop child:  load block (read)
          forLoopRead.Statements.Add(new CodeExpressionStatement(
                new CodeMethodInvokeExpression(new CodeIndexerExpression(
                new CodeVariableReferenceExpression(blockCollection), new CodeVariableReferenceExpression("x")), "Read",
                new CodeVariableReferenceExpression("reader"))));

          readChildDataMethod.Statements.Add(forLoopRead);

          //for loop for ReadChildren()
          CodeIterationStatement forLoopReadChildren = GenerateForLoop(new CodeFieldReferenceExpression(
            new CodeVariableReferenceExpression(name), "Count"));
          //ReadChildren loop child:  ReadChildData();
          forLoopReadChildren.Statements.Add(new CodeExpressionStatement(
                new CodeMethodInvokeExpression(new CodeIndexerExpression(
                new CodeVariableReferenceExpression(blockCollection), new CodeVariableReferenceExpression("x")), "ReadChildData",
                new CodeVariableReferenceExpression("reader"))));

          readChildDataMethod.Statements.Add(forLoopReadChildren);
        }

        // hack: this defeats the generic-ness of this class generator.
        if ((type == "TagReference") || (type == "StringId") || (type == "PredictedResource"))
       {     
            CodeMethodInvokeExpression readString = new CodeMethodInvokeExpression(
            new CodeVariableReferenceExpression(name), "ReadString", new CodeVariableReferenceExpression("reader"));
          readChildDataMethod.Statements.Add(readString);
        }

        if (type == "Data" || type == "BitmapData" || type == "ResourceBlock" || type == "ResourceBlockInverted")
        {
          CodeMethodInvokeExpression readBinary = new CodeMethodInvokeExpression(
            new CodeVariableReferenceExpression(name), "ReadBinary", new CodeVariableReferenceExpression("reader"));
          readChildDataMethod.Statements.Add(readBinary);
        }
      }

      return (readChildDataMethod);
    }

    private CodeMemberMethod GenerateWriteChildrenMethod(List<XmlNode> fieldList, bool isBase)
    {
      // Generate the WriteChildData method.
      // This writes strings, child blocks, and data fields in the order that they appear.
      CodeMemberMethod writeChildDataMethod = new CodeMemberMethod();
      writeChildDataMethod.ReturnType = new CodeTypeReference(typeof(void));
      writeChildDataMethod.Name = "WriteChildData";
      writeChildDataMethod.Parameters.Add(new CodeParameterDeclarationExpression("BinaryWriter", "writer"));
      writeChildDataMethod.Attributes = MemberAttributes.Public/* | MemberAttributes.Final*/;
      if (isBase)
        writeChildDataMethod.Attributes |= MemberAttributes.Override;

      foreach (XmlNode fieldNode in fieldList)
      {
        if (fieldNode.Attributes["type"].InnerText == "Block")
        {
          writeChildDataMethod.Statements.Add(new CodeVariableDeclarationStatement(typeof(int), "x", new CodePrimitiveExpression(0)));
          break;
        }
      }

      //for loop blocks
      foreach (XmlNode fieldNode in fieldList)
      {
        string name = GlobalMethods.MakePrivateName(fieldNode.Attributes["name"].InnerText);
        string type = fieldNode.Attributes["type"].InnerText;
        if ((type == "Block") || (type == "H2Block"))
        {
          string blockName = fieldNode.Attributes["struct"].InnerText + "Block";
          //fix underscore problem
          string blockCollection = name.Substring(1, 1).ToUpper() + name.Substring(2);

          //readChildDataMethod.Statements.Add(GenerateBlockOffsetCheckCode(name));

          CodeIterationStatement forLoopWrite = GenerateForLoop(new CodeFieldReferenceExpression(
              new CodeVariableReferenceExpression(name), "Count"));

          //forLoopWrite.Statements.Add(new CodeExpressionStatement(
          //      new CodeMethodInvokeExpression(new CodeVariableReferenceExpression(blockCollection), "Add", new CodeExpression[] { new CodeObjectCreateExpression(blockName) })));
          forLoopWrite.Statements.Add(new CodeExpressionStatement(
                new CodeMethodInvokeExpression(new CodeIndexerExpression(
                new CodeVariableReferenceExpression(blockCollection), new CodeVariableReferenceExpression("x")), "Write",
                new CodeVariableReferenceExpression("writer"))));

          writeChildDataMethod.Statements.Add(forLoopWrite);

          CodeIterationStatement forLoopWriteChildren = GenerateForLoop(new CodeFieldReferenceExpression(
            new CodeVariableReferenceExpression(name), "Count"));
          forLoopWriteChildren.Statements.Add(new CodeExpressionStatement(
                new CodeMethodInvokeExpression(new CodeIndexerExpression(
                new CodeVariableReferenceExpression(blockCollection), new CodeVariableReferenceExpression("x")), "WriteChildData",
                new CodeVariableReferenceExpression("writer"))));

          writeChildDataMethod.Statements.Add(forLoopWriteChildren);
        }

        if ((type == "TagReference") || (type == "StringId") || (type == "PredictedResource"))
        {
          CodeMethodInvokeExpression readString = new CodeMethodInvokeExpression(
            new CodeVariableReferenceExpression(name), "WriteString", new CodeVariableReferenceExpression("writer"));
          writeChildDataMethod.Statements.Add(readString);
        }

        if (type == "Data" || type == "BitmapData" || type == "ResourceBlock" || type == "ResourceBlockInverted")
        {
          CodeMethodInvokeExpression readBinary = new CodeMethodInvokeExpression(
            new CodeVariableReferenceExpression(name), "WriteBinary", new CodeVariableReferenceExpression("writer"));
          writeChildDataMethod.Statements.Add(readBinary);
        }
      }

      return (writeChildDataMethod);
    }

    public string GenerateClass(XmlNode node, TypeTable typeTable)
    {
      InitializeCodeGenerator();

      // Get the namespace and class type from the XML.
      XmlNode platformNode = node.SelectSingleNode("platform");
      XmlNode nameNode = node.SelectSingleNode("name");
      XmlNode mainNode = node.SelectSingleNode("//struct");

      string className = typeTable.LocateEntryByFourCC(nameNode.Attributes["type"].InnerText).FullName;
      string friendlyClassName = nameNode.InnerText;
      string parentType = null;
      try
      {
        string fourCC = nameNode.Attributes["parenttype"].InnerText;
        if (fourCC != "????")
          parentType = typeTable.LocateEntryByFourCC(fourCC).FullName;
      }
      catch { parentType = null; }
      string mainBlockName = mainNode.Attributes["name"].InnerText + "Block";

      //generate root level code
      ns = GenerateNamespaceAndImports(platformNode.InnerText, className, parentType);
      rootClassDeclaration = GenerateRootClass(className, friendlyClassName, mainBlockName, parentType, className/*typeTable.GetExtended(nameNode.Attributes["type"].InnerText)*/);

      // Generate all of the component block classes.
      List<string> structs = new List<string>();
      XmlNodeList structsList = node.SelectNodes("//struct");
      foreach (XmlNode structNode in structsList)
      {
        string nameOfClass = structNode.Attributes["name"].InnerText;

        // If the class already exists, don't generate it again.
        if (!structs.Contains(nameOfClass))
        {
          CodeTypeDeclaration ct = GenerateBlockClass(structNode, false);
          rootClassDeclaration.Members.Add(ct);
          structs.Add(nameOfClass);
        }
      }
      ns.Types.Add(rootClassDeclaration);

      // Generate the code and return it as a string.
      StreamWriter writer = new StreamWriter(new MemoryStream());
      provider.GenerateCodeFromNamespace(ns, writer, codeGenOptions);
      writer.Flush();
      StreamReader reader = new StreamReader(writer.BaseStream);
      reader.BaseStream.Position = 0;
      string code = reader.ReadToEnd();
      reader.Close();
      writer.Close();
      return code;
    }

    /// <summary>
    /// Generates a list of "struct" nodes, but also includes structs
    /// under a "group" node.  Preserves ordering of structs.
    /// </summary>
    /// <param name="node"></param>
    /// <returns></returns>
    protected List<XmlNode> GetStructsAndGroupStructs(XmlNode node, string xpath)
    {
      List<XmlNode> list = new List<XmlNode>();

      foreach (XmlNode cn in node.ChildNodes)
      {
        if (cn.Name == xpath)
          list.Add(cn);
        else if (cn.Name == "group")
        {
          foreach (XmlNode gcn in cn.ChildNodes)
          {
            if (gcn.Name == "section")
            {
              foreach (XmlNode ggcn in gcn.ChildNodes)
              {
                if (ggcn.Name == xpath)
                  list.Add(ggcn);
              }
            }
            if (gcn.Name == xpath)
              list.Add(gcn);
          }
        }
      }

      return (list);
    }

    /// <summary>
    /// Generates a c# tag block class from a struct node.
    /// </summary>
    protected CodeTypeDeclaration GenerateBlockClass(XmlNode node, bool isBase)
    {
      // Setup the class type declaration.
      string nameOfClass = node.Attributes["name"].InnerText + "Block";
      CodeTypeDeclaration classDeclaration = new CodeTypeDeclaration(nameOfClass);
      classDeclaration.IsClass = true;
      classDeclaration.TypeAttributes = TypeAttributes.Public;
      classDeclaration.BaseTypes.Add("IBlock");

      List<XmlNode> fieldList = GetStructsAndGroupStructs(node, "value");
      string blockNameField = "";
      foreach (XmlNode fieldNode in fieldList)
        if (fieldNode.Attributes["blockname"] != null)
          blockNameField = fieldNode.Attributes["name"].Value;

      // Generate the constructor.
      CodeConstructor constructor = new CodeConstructor();
      constructor.Attributes = MemberAttributes.Public;
      classDeclaration.Members.Add(constructor);

      // Add shit to the class based on the xml children nodes
      CodeTypeMemberCollection members = GeneratePrivateMemberVars(fieldList);
      classDeclaration.Members.AddRange(members);

      // Generate the TagReferenceList property.
      CodeMemberProperty tagReferences = new CodeMemberProperty();
      tagReferences.Type = new CodeTypeReference(typeof(string[]));
      tagReferences.Name = "TagReferenceList";
      tagReferences.HasGet = true;
      tagReferences.HasSet = false;
      tagReferences.Attributes = MemberAttributes.Public /*| MemberAttributes.Override*/;
      tagReferences.GetStatements.Add(new CodeSnippetStatement("UniqueStringCollection references = new UniqueStringCollection();"));
      
      foreach (CodeMemberField member in members)
        if (member.Type.BaseType == "TagReference")
          tagReferences.GetStatements.Add(new CodeSnippetStatement("references.Add(" + member.Name + ".Value);"));

      // Next step: return the references from each member of type IBlockCollection
      GenerateBlockCollectionAccessors(fieldList, classDeclaration, tagReferences);
      tagReferences.GetStatements.Add(new CodeSnippetStatement("return references.ToArray();"));
      classDeclaration.Members.Add(tagReferences);

      // Add the event from IBlock.
      string blockNameChangedEvent = "public event System.EventHandler BlockNameChanged;";
      CodeSnippetTypeMember eventMember = new CodeSnippetTypeMember(blockNameChangedEvent);
      eventMember.Attributes = MemberAttributes.Public;
      classDeclaration.Members.Add(eventMember);

      // Generate the BlockName property.
      CodeMemberProperty blockName = new CodeMemberProperty();
      blockName.Type = new CodeTypeReference(typeof(string));
      blockName.Name = "BlockName";
      blockName.HasGet = true;
      blockName.HasSet = false;
      blockName.Attributes = MemberAttributes.Public;

      string returnStatement = "return \"\";";
      if (!String.IsNullOrEmpty(blockNameField))
      {
        string privateName = GlobalMethods.MakePrivateName(blockNameField);
        
        // Returns the linked field's ToString() from the BlockName property.
        returnStatement = "return " + privateName + ".ToString();";

        // Hook up the PropertyChanged event handler in the constructor.
        string eventSetup = "if (this." + privateName + " is System.ComponentModel.INotifyPropertyChanged)\r\n" +
          "  (this." + privateName + " as System.ComponentModel.INotifyPropertyChanged).PropertyChanged +=\r\n" +
          "  (System.ComponentModel.PropertyChangedEventHandler)delegate\r\n" +
          "  { if (BlockNameChanged != null) BlockNameChanged(this, new System.EventArgs()); };";

        constructor.Statements.Add(new CodeSnippetStatement(eventSetup));
      }
      blockName.GetStatements.Add(new CodeSnippetStatement(returnStatement));
      classDeclaration.Members.Add(blockName);

      // Generate the rest of the shit.
      GenerateOtherPublicAccessors(fieldList, classDeclaration);
      GenerateConstructorStatements(fieldList, constructor);
      classDeclaration.Members.Add(GenerateReadMethod(fieldList, isBase));
      classDeclaration.Members.Add(GenerateReadChildrenMethod(fieldList, isBase));
      classDeclaration.Members.Add(GenerateWriteMethod(fieldList, isBase));
      classDeclaration.Members.Add(GenerateWriteChildrenMethod(fieldList, isBase));

      return classDeclaration;
    }

    /// <summary>
    /// Creates one of the standard Read/Write methods for the class.
    /// </summary>
    private CodeMemberMethod CreateReadWriteMethod(
      string methodName, string parentType, string paramObject, string paramName, string className)
    {
      CodeMemberMethod method = new CodeMemberMethod();
      method.Name = methodName;
      method.Parameters.Add(new CodeParameterDeclarationExpression(paramObject, paramName));
      method.ReturnType = new CodeTypeReference(typeof(void));
      if (parentType != null)
      {
        method.Attributes = MemberAttributes.Public | MemberAttributes.Override;
        method.Statements.Add(new CodeSnippetStatement(String.Format("base.{0}({1});", methodName, paramName)));
      }
      else
      {
        method.Attributes = MemberAttributes.Public | MemberAttributes.Override;
      }
      method.Statements.Add(new CodeSnippetStatement(
        String.Format("{0}Values.{1}({2});", className, methodName, paramName)));
      return method;
    }

    protected CodeMemberField GeneratePrivateMember(XmlNode node)
    {
      string fieldClassName = node.Attributes["type"].InnerText;
      string fullName = typedefNamespace + "." + fieldClassName + "CodeGenerator";
      return (CodeMemberField)InvokeMethod(fullName, "GeneratePrivateMember", node);
    }

    protected CodeMemberProperty GeneratePublicAccessors(XmlNode node)
    {
      string fieldClassName = node.Attributes["type"].InnerText;
      string fullName = typedefNamespace + "." + fieldClassName + "CodeGenerator";
      return (CodeMemberProperty)InvokeMethod(fullName, "GeneratePublicAccessors", node);
    }

    protected CodeStatement GenerateConstructorLogic(XmlNode node)
    {
      string fieldClassName = node.Attributes["type"].InnerText;
      string fullName = typedefNamespace + "." + fieldClassName + "CodeGenerator";
      return (CodeStatement)InvokeMethod(fullName, "GenerateConstructorLogic", node);
    }

    protected object InvokeMethod(string fullName, string methodName, params object[] args)
    {
      object instance = typedefAssembly.CreateInstance(fullName, true, BindingFlags.CreateInstance, null, args, null, null);
      Type type = instance.GetType();

      MethodInfo mi = type.GetMethod(methodName);
      object r = null;
      try
      { r = mi.Invoke(instance, null); }
      catch
      { System.Diagnostics.Debugger.Break(); }
      return r;
    }

    protected CodeTypeDeclaration GenerateBlockCollection(string blockName)
    {
      // Setup the class type declaration.
      string collectionName = blockName + "Collection";
      CodeTypeDeclaration classType = new CodeTypeDeclaration(collectionName);
      classType.IsClass = true;
      classType.TypeAttributes = TypeAttributes.Public;
      classType.BaseTypes.Add("System.Collections.CollectionBase");

      CodeMemberField linkedBlock = new CodeMemberField("Block", "linkedBlock");
      linkedBlock.Attributes = MemberAttributes.Private;
      classType.Members.Add(linkedBlock);

      CodeConstructor constructor = new CodeConstructor();
      constructor.Attributes = MemberAttributes.Public;
      constructor.Parameters.Add(new CodeParameterDeclarationExpression("Block", "linkedBlock"));
      constructor.Statements.Add(new CodeSnippetStatement("this.linkedBlock = linkedBlock;"));
      classType.Members.Add(constructor);

      CodeMemberMethod addMethod = new CodeMemberMethod();
      addMethod.ReturnType = new CodeTypeReference(typeof(void));
      addMethod.Name = "Add";
      addMethod.Attributes = MemberAttributes.Public | MemberAttributes.Final;
      addMethod.Parameters.Add(new CodeParameterDeclarationExpression(blockName, "block"));
      addMethod.Statements.Add(new CodeSnippetStatement("InnerList.Add(block);"));
      addMethod.Statements.Add(new CodeSnippetStatement(
        "if (linkedBlock.Count < InnerList.Count) linkedBlock.Count = InnerList.Count;"));
      classType.Members.Add(addMethod);

      CodeMemberMethod addNewMethod = new CodeMemberMethod();
      addNewMethod.ReturnType = new CodeTypeReference(typeof(void));
      addNewMethod.Name = "AddNew";
      addNewMethod.Attributes = MemberAttributes.Public | MemberAttributes.Final;
      addNewMethod.Statements.Add(new CodeMethodInvokeExpression(
        new CodeThisReferenceExpression(), "Add", new CodeObjectCreateExpression(blockName, new CodeExpression[] { })));
      classType.Members.Add(addNewMethod);

      CodeMemberMethod removeMethod = new CodeMemberMethod();
      removeMethod.ReturnType = new CodeTypeReference(typeof(void));
      removeMethod.Name = "Remove";
      removeMethod.Attributes = MemberAttributes.Public | MemberAttributes.Final;
      removeMethod.Parameters.Add(new CodeParameterDeclarationExpression(typeof(int), "index"));
      removeMethod.Statements.Add(new CodeSnippetStatement("InnerList.RemoveAt(index);"));
      removeMethod.Statements.Add(new CodeSnippetStatement(
        "if (linkedBlock.Count > InnerList.Count) linkedBlock.Count = InnerList.Count;"));
      classType.Members.Add(removeMethod);

      CodeMemberProperty itemAccessor = new CodeMemberProperty();
      itemAccessor.Name = "Item";
      itemAccessor.Type = new CodeTypeReference(blockName);
      itemAccessor.Attributes = MemberAttributes.Public | MemberAttributes.Final;
      itemAccessor.Parameters.Add(new CodeParameterDeclarationExpression(typeof(int), "index"));
      itemAccessor.HasGet = true;
      itemAccessor.HasSet = false;
      itemAccessor.GetStatements.Add(new CodeMethodReturnStatement(
        new CodeCastExpression(blockName,
        new CodeArrayIndexerExpression(new CodeFieldReferenceExpression(
        new CodeThisReferenceExpression(), "InnerList"),
        new CodeArgumentReferenceExpression("index")))));
      classType.Members.Add(itemAccessor);

      return classType;
    }
  }
}