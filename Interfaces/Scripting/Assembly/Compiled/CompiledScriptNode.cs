using System.IO;

namespace Interfaces.Scripting.Assembly.Compiled
{
	enum CompiledNodeType
	{
		FunctionCall = 8,
		Value = 9,
		ScriptCall = 10,
		GlobalReference = 13
	}

	class CompiledScriptNode
	{
		private short m_index;
		private short m_opCode;
		private short m_valueType;
		private CompiledNodeType m_nodeType;
		private short m_nextSiblingIndex;
		private int m_stringTableOffset;
		private byte[] m_valueData;

		#region Accessors

		public short Index
		{
			get { return m_index; }
		}

		public short OpCode
		{
			get { return m_opCode; }
		}

		public short ValueType
		{
			get { return m_valueType; }
		}

		public CompiledNodeType NodeType
		{
			get { return m_nodeType; }
		}

		public short NextSiblingIndex
		{
			get { return m_nextSiblingIndex; }
		}

		public int StringTableOffset
		{
			get { return m_stringTableOffset; }
		}

		public byte[] ValueData
		{
			get { return m_valueData; }
		}

		#endregion

		public CompiledScriptNode(short index, BinaryReader br)
		{
			br.BaseStream.Position = index * 20;
			m_index = index;
			m_opCode = br.ReadInt16();
			m_valueType = br.ReadInt16();
			m_nodeType = (CompiledNodeType)br.ReadInt16();
			m_nextSiblingIndex = br.ReadInt16();
			br.BaseStream.Seek(2, SeekOrigin.Current);
			m_stringTableOffset = br.ReadInt32();
			m_valueData = br.ReadBytes(4);
		}
	}
}
