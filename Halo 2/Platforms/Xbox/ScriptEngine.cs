using System;
using Interfaces.Scripting;
using Interfaces.Scripting.EngineDefinition;

namespace Games.Halo2.Platforms.Xbox
{
  public partial class Halo2XboxGameDefinition
  {
		public override ScriptEngineDefinition ScriptEngineDefinition
		{
			get { throw new NotImplementedException(); }
		}

		public override IScriptProcessor ScriptProcessor
		{
			get { throw new NotImplementedException(); }
		}
  }
}
