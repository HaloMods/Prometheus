using System;
using System.Collections.Generic;
using System.IO;
using Interfaces.Factory;
using Interfaces.Scripting;
using Interfaces.Scripting.EngineDefinition;
using Interfaces.Scripting.EngineDefinition.Types;

namespace Prometheus.Testing.ScriptingDefinitionTools
{
	enum GameMajorVersion
	{
		Halo1,
		Halo2
	}

	class DefinitionReader
	{
		private GameMajorVersion m_majorVersion;
		private InternalFunction[] m_functions;
		private InternalGlobal[] m_globals;
		private ExtendedTypeBase[] m_types;

		public DefinitionReader(GameMajorVersion majorVersion)
		{
			m_majorVersion = majorVersion;
		}

		public void ReadFromToolExe(BinaryReader br)
		{
			short functionCount, globalCount;
			uint functionTablePointer, globalTablePointer, typeArrayPointer;

			switch (m_majorVersion)
			{
				case GameMajorVersion.Halo1:
					functionCount = 545;
					functionTablePointer = 0x002EC220;
					
					globalCount = 495;
					globalTablePointer = 0x00328B00;

					typeArrayPointer = 0x00722C8C;
					break;
				case GameMajorVersion.Halo2:
					functionCount = 924;
					functionTablePointer = 0x005ECFE0;

					globalCount = 704;
					globalTablePointer = 0x005EDE6C; // this is not the pointer table, fix

					typeArrayPointer = 0;
					break;
				default:
					throw new Exception("Not a supported version.");
			}

			m_functions = new InternalFunction[functionCount];
			
			for (short i = 0; i < functionCount; i++)
			{
				br.BaseStream.Position = functionTablePointer + i*4;
				br.BaseStream.Position = br.ReadUInt32() - 0x400000;

				short returnType = br.ReadInt16();
				br.BaseStream.Position += 2;
				uint namePointer = br.ReadUInt32();
				br.BaseStream.Position += 8;
				uint descriptionPointer = br.ReadUInt32();
				uint argumentHelpPointer = br.ReadUInt32();
				br.BaseStream.Position += 2;
				short argumentCount = br.ReadInt16();
				Argument[] args = new Argument[argumentCount];
				for (short j = 0; j < argumentCount; j++)
					args[j] = new Argument(String.Empty, br.ReadInt16(), String.Empty);

				br.BaseStream.Position = namePointer - 0x400000;
				string name = StringOps.ReadCString(br);
				string description = String.Empty;
				if (descriptionPointer != 0)
				{
					br.BaseStream.Position = descriptionPointer - 0x400000;
					description = StringOps.ReadCString(br);
				}
				//unused: string argumentHelp = String.Empty;
				if (argumentHelpPointer != 0)
				{
					br.BaseStream.Position = argumentHelpPointer - 0x400000;
					//unused: argumentHelp = StringOps.ReadCString(br);
				}

				m_functions[i] = new InternalFunction(name, i, returnType, description, args);
			}

			m_globals = new InternalGlobal[globalCount];

			for (short i = 0; i < globalCount; i++)
			{
				br.BaseStream.Position = globalTablePointer + i * 4;
				br.BaseStream.Position = br.ReadUInt32() - 0x400000;

				uint namePointer = br.ReadUInt32();
				short type = br.ReadInt16();

				br.BaseStream.Position = namePointer - 0x400000;
				string name = StringOps.ReadCString(br);

				m_globals[i] = new InternalGlobal(name, i, type);
			}

			uint typeTablePointer = typeArrayPointer + 4;
			br.BaseStream.Position = typeArrayPointer;
			int typeCount = br.ReadInt32() - (int)IntegralValueType.IntegralValueTypeCount;
			m_types = new ExtendedTypeBase[typeCount];

			for (short i = 0; i < typeCount; i++)
			{
				short typeIndex = (short)(i + IntegralValueType.IntegralValueTypeCount);
				br.BaseStream.Position = typeTablePointer + typeIndex*4;
				br.BaseStream.Position = br.ReadUInt32() - 0x400000;
				string name = StringOps.ReadCString(br);
				
				Dictionary<string, short> objectReferences = new Dictionary<string, short>();

				// fuck, how to handle Hud.Navpoints["red_flag"] with the dot/namespacing dealy

				switch (name)
				{
					case "trigger_volume":
						m_types[i] = new BlockReferenceType(name, "TriggerVolumes", typeIndex, typeIndex, BlockSourceTag.Scenario);
						break;
					case "navpoint":
						m_types[i] = new BlockReferenceType(name, "Navpoints", typeIndex, typeIndex, BlockSourceTag.HudGlobals);
						break;
					default:
						m_types[i] = new BlockReferenceType(name, ScriptingStringOps.ToPslFormatting(name, null)+'s', typeIndex, typeIndex, BlockSourceTag.Scenario);
						break;
				}				
			}

			// enumerations 0x00656F4C


		}
	}
}
