using Interfaces.Scripting.EngineDefinition;

namespace Interfaces.Scripting
{
	public class DynamicScriptProcessor : IScriptProcessor
	{
		private ScriptEngineDefinition m_engineDefinition;

		public DynamicScriptProcessor(ScriptEngineDefinition engineDefinition)
		{
			m_engineDefinition = engineDefinition;
		}

		/*
		public string DecompileForMapScenario<T>(TagFile scenarioTag, IMapFile map)
		{
			IPool pool = null;
			ScenarioBase scnr = pool.Create<T>(null);
			scnr.Load(tf.GetBinary(tf.HeadRevision));

			ScriptAssembly intermediate = new ScriptAssembly();
			ScriptNodeStore nodes = new ScriptNodeStore(assembly.Scenario.GetScriptSyntaxData());
			intermediate.LoadFromCompiled(nodes, m_engineDefinition, assembly);
			return intermediate.ToPsl();
		}
		*/

		public string DecompileForMapScenario(MapScenarioScriptingAssembly assembly)
		{
			/*ScriptNodeStore nodes = new ScriptNodeStore(assembly.Scenario.GetScriptSyntaxData());
			ScriptAssembly intermediate = new ScriptAssembly(m_engineDefinition, nodes, assembly);
			
			return intermediate.ToPsl();*/
			return null;
		}
	}
}
