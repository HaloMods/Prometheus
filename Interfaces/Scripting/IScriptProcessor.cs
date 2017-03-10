
namespace Interfaces.Scripting
{
	public interface IScriptProcessor
	{
		//string DecompileForMapScenario<T>(TagFile scenarioTag, IMapFile map) where T : ScenarioBase;
		string DecompileForMapScenario(MapScenarioScriptingAssembly assembly);
	}
}
