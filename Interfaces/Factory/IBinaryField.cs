using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Interfaces.Factory
{
  /// <summary>
  /// In addition to being a normal field, this interface exposes Read and Write Binary methods on an object.
  /// </summary>
  public interface IBinaryField : IField
  {
    void ReadBinary(BinaryReader reader);

    void WriteBinary(BinaryWriter writer);
  }
}
