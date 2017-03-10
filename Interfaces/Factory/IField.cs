using System;
using System.IO;

namespace Interfaces.Factory
{
  /// <summary>
  /// Provides a base for a field in a Blam tag definition.
  /// </summary>
  public interface IField
  {
    void Read(BinaryReader reader);

    void Write(BinaryWriter writer);
  }
}
