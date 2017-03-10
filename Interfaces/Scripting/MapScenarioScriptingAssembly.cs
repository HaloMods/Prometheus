using Interfaces.Games;

namespace Interfaces.Scripting
{
	public class MapScenarioScriptingAssembly
	{
		private ScenarioBase m_scenario;
		private IMapFile m_mapFile;

		public ScenarioBase Scenario
		{
			get { return m_scenario; }
		}

		public IMapFile MapFile
		{
			get { return m_mapFile; }
		}

		public MapScenarioScriptingAssembly(ScenarioBase scenario, IMapFile mapFile)
		{
			m_scenario = scenario;
			m_mapFile = mapFile;
		}
	}
}
