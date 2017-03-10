using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Interfaces.Factory
{
  /// <summary>
  /// In addition to being a field, this interface exposes a ReadString and WriteString method on a type.
  /// </summary>
  public interface IStringField : IField
  {
    void ReadString(BinaryReader reader);

    void WriteString(BinaryWriter writer);
  }
}
