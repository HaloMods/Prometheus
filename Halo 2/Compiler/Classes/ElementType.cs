using System;

namespace Games.Halo2.Compiler.Classes
{
  /// <summary>
  /// Specifies whether an Element is a base, block, a chunk of data, a string, or a tag reference.
  /// </summary>
  public enum ElementType : byte
  {
    Block, // element count, offset + magic
    TagData, // byte count, offset + magic
    StringID, // (short)index, (byte)0, (byte)size
    TagReference, // identifier
    ResourceBlock, // masked offset, size
    ResourceBlockInverted, // size, masked offset
    BitmapData, // <all masked> offset, offset, offset, offset, offset, offset, size, size, size, size, size, size
    SelfReference, // identifier
    PredictedResource, // identifier
  }
}
