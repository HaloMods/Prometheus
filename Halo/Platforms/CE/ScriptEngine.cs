using System;
using Interfaces.Scripting;
using Interfaces.Scripting.EngineDefinition;

namespace Games.Halo.Platforms.CE
{
  partial class HaloCEGameDefinition
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
