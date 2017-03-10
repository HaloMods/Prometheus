using System;
using System.IO;
using System.Reflection;
using System.Xml.Serialization;
using Interfaces.Scripting;
using Interfaces.Scripting.EngineDefinition;

namespace Games.Halo.Platforms.PC
{
	public static class HaloPCScriptEngine
	{
		private static ScriptEngineDefinition definition = null;

		public static ScriptEngineDefinition Definition
		{
			get
			{
				//throw new Exception("Currently out of action.");

				if (definition == null)
				{
					XmlSerializer s = new XmlSerializer(typeof(ScriptEngineDefinition));
					Stream def = Assembly.GetExecutingAssembly().GetManifestResourceStream("Games.Halo.Resources.Scripting.HaloPCScriptEngineDefinition.xml");
					definition = (ScriptEngineDefinition)s.Deserialize(def);
					def.Close();
				}
				return definition;
			}
		}

		private static IScriptProcessor processor = null;

		public static IScriptProcessor Processor
		{
			get
			{
				throw new Exception("Currently out of action.");

				if (processor == null)
					processor = new DynamicScriptProcessor(Definition);
				return processor;
			}
		}
	}

  partial class HaloPCGameDefinition
  {
    public override ScriptEngineDefinition ScriptEngineDefinition
    {
			get { return HaloPCScriptEngine.Definition; }
    }

		public override IScriptProcessor ScriptProcessor
		{
			get { return HaloPCScriptEngine.Processor; }
		}
  }
}
