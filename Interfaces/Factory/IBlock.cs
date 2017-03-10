using System.IO;
using System;

namespace Interfaces.Factory
{
  /// <summary>
  /// Represents a tag base and a block base.
  /// </summary>
  public interface IBlock
  {
    string[] TagReferenceList { get; }

    string BlockName { get; }
    //string BlockName();
    event EventHandler BlockNameChanged;
    
    void Read(BinaryReader reader);
    void ReadChildData(BinaryReader reader);

    void Write(BinaryWriter writer);
    void WriteChildData(BinaryWriter writer);
  }
}
