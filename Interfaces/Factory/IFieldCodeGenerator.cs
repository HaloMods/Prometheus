using System;
using System.CodeDom;

namespace Interfaces.Factory
{
  public interface IFieldCodeGenerator
  {
    string Name { get; }

    CodeMemberField GeneratePrivateMember();

    CodeMemberProperty GeneratePublicAccessors();

    string GenerateMetadataInitializer();

    CodeStatement GenerateConstructorLogic();
  }
}
