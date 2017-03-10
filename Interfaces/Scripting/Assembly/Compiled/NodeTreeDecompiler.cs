using System;
using System.Collections.Generic;
using System.IO;
using Interfaces.Games;
using Interfaces.Scripting.Assembly.Nodes;
using Interfaces.Scripting.Assembly.Nodes.Bsl;
using Interfaces.Scripting.Assembly.Nodes.ValueNodes;
using Interfaces.Scripting.EngineDefinition;
using Interfaces.Scripting.EngineDefinition.Types;
using Interfaces.Scripting.ScenarioInterface;

namespace Interfaces.Scripting.Assembly.Compiled
{
	static class NodeTreeDecompiler
	{
		private static BinaryReader s_nodeDataReader;
		private static List<NodeBase> s_globals;
		private static List<NodeBase> s_scripts;
		private static ScriptEngineDefinition s_engineDefinition;
		private static string[] s_tagList;
		private static ScenarioBase s_scnr;

		public static ScriptingAssembly Decompile(byte[] scriptNodeData, ScriptEngineDefinition engineDefinition, string[] tagList, ScenarioBase scnr)
		{
			s_nodeDataReader = new BinaryReader(new MemoryStream(scriptNodeData, 56, scriptNodeData.Length - 56, false));
			s_globals = new List<NodeBase>();
			s_scripts = new List<NodeBase>();

			s_engineDefinition = engineDefinition;
			s_tagList = tagList;
			s_scnr = scnr;

			ScenarioScriptGlobal[] scnrGlobals = s_scnr.GetScriptGlobals();
			ScenarioScript[] scnrScripts = s_scnr.GetScripts();

			foreach (ScenarioScriptGlobal g in scnrGlobals)
			{
				CompiledScriptNode cnode = new CompiledScriptNode(g.InitialisationExpressionIndex, s_nodeDataReader);
				s_globals.Add(new VariableNode(g.Name, g.Type, DecompileNode(cnode)));
			}

			foreach (ScenarioScript s in scnrScripts)
			{
				CompiledScriptNode cnode = new CompiledScriptNode(s.RootExpressionIndex, s_nodeDataReader);
				s_scripts.Add(new ScriptNode(s.Name, (ScriptType)s.ScriptType, s.ReturnType, DecompileNode(cnode).Children));
			}

			ScriptingAssembly assembly = new ScriptingAssembly(s_engineDefinition, s_globals, s_scripts);

			s_nodeDataReader = null;
			s_globals = null;
			s_scripts = null;
			s_engineDefinition = null;
			s_tagList = null;
			s_scnr = null;

			return assembly;
		}
		// handle null nodes
		private static NodeBase DecompileNode(CompiledScriptNode node)
		{
			switch (node.NodeType)
			{
				case CompiledNodeType.FunctionCall:
					{
						List<NodeBase> parameters = new List<NodeBase>();

						CompiledScriptNode firstChild = new CompiledScriptNode(BitConverter.ToInt16(node.ValueData, 0), s_nodeDataReader);
						short childIndex = firstChild.NextSiblingIndex;
						while (childIndex != -1)
						{
							CompiledScriptNode child = new CompiledScriptNode(childIndex, s_nodeDataReader);
							parameters.Add(DecompileNode(child));
							childIndex = child.NextSiblingIndex;
						}

						/*if (node.OpCode == 0) // Begin
							return new GroupingNode(parameters);*/

						return new BslFunctionCallNode(node.OpCode, parameters);
					}
				case CompiledNodeType.ScriptCall:
					{
						List<NodeBase> parameters = new List<NodeBase>();

						CompiledScriptNode firstChild = new CompiledScriptNode(BitConverter.ToInt16(node.ValueData, 0), s_nodeDataReader);
						short childIndex = firstChild.NextSiblingIndex;
						while (childIndex != -1)
						{
							CompiledScriptNode child = new CompiledScriptNode(childIndex, s_nodeDataReader);
							parameters.Add(DecompileNode(child));
							childIndex = child.NextSiblingIndex;
						}

						return new ScriptCallNode(s_scripts[node.OpCode] as ScriptNode, parameters);
					}
				case CompiledNodeType.GlobalReference:
					{
						uint index = BitConverter.ToUInt32(node.ValueData, 0);

						if (index >= 0xFFFF8000)
							return new BslGameGlobalReferenceNode((short)(index - 0xFFFF8000), node.ValueType);
						else
							return new VariableReferenceValueNode(s_globals[(short)index] as VariableNode, node.ValueType);
					}
				case CompiledNodeType.Value:
					{
						switch ((IntegralValueType)node.ValueType)
						{
							case IntegralValueType.Bool:
								return new BoolValueNode(BitConverter.ToBoolean(node.ValueData, 0));
							case IntegralValueType.Real:
								return new RealValueNode(BitConverter.ToSingle(node.ValueData, 0));
							case IntegralValueType.Short:
								return new ShortValueNode(BitConverter.ToInt16(node.ValueData, 0));
							case IntegralValueType.Long:
								return new LongValueNode(BitConverter.ToInt32(node.ValueData, 0));
							case IntegralValueType.String:
								return new StringValueNode(s_scnr.GetScriptString(node.StringTableOffset));
							case IntegralValueType.Script:
								return new ScriptReferenceValueNode(s_scripts[BitConverter.ToInt16(node.ValueData, 0)] as ScriptNode);
						}

						ExtendedTypeBase type = s_engineDefinition.ExtendedTypes[node.ValueType - ExtendedTypeBase.FirstTypeIndex];

						if (type is EnumerationType)
							return new EnumerationValueNode(type as EnumerationType, BitConverter.ToInt16(node.ValueData, 0));
						if (type is BlockReferenceType)
							return
								new BlockReferenceValueNode(type as BlockReferenceType,
								                            s_scnr.GetBlockStringForScriptingReferenceType(
								                            	BitConverter.ToInt16(node.ValueData, 0), type.TypeIndex));
						if (type is TagReferenceType)
							return new TagReferenceValueNode(type as TagReferenceType, s_tagList[BitConverter.ToInt16(node.ValueData, 0)]);

						throw new OnlyForDebuggingException("N.B. :(");
					}
			}

			throw new OnlyForDebuggingException("N.B. :X");
		}
	}
}
