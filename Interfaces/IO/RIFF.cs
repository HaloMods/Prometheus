using System;
using System.IO;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Interfaces.IO
{
  /// <summary>
  /// Implements the resource interchange file format (RIFF) metaformat.
  /// </summary>
  public class RIFF
  {
    private RiffHeader header;
    private List<RiffBlock> blocks = null;

    /// <summary>
    /// Creates an empty RIFF container file.
    /// </summary>
    /// <param name="type">a fourcc typecode to embed in the header</param>
    public RIFF(string type)
    {
      header = new RiffHeader(Reinterpret.FourCC(type, ByteOrder.BigEndian));
      blocks = new List<RiffBlock>();
    }

    /// <summary>
    /// Creates a RIFF object with data from the given RIFF-compatable stream.
    /// </summary>
    /// <param name="input">a stream containing RIFF data</param>
    public RIFF(Stream input)
    {
      if (!input.CanRead)
        throw new ArgumentException("The RIFF parser requires a readable stream.", "input");

      long initial = input.Position;
      int headerLength = Marshal.SizeOf(typeof(RiffHeader));
      int innerHeaderLength = Marshal.SizeOf(typeof(RiffBlockHeader));
      byte[] data = new byte[headerLength];
      input.Read(data, 0, headerLength);
      header = Reinterpret.Memory<RiffHeader>(data);
      blocks = new List<RiffBlock>();

      while (input.Position - initial < header.HeaderBlockHeader.Length + innerHeaderLength)
        blocks.Add(new RiffBlock(input));
    }

    /// <summary>
    /// Writes this instance to an output stream.
    /// </summary>
    /// <param name="output">output stream</param>
    public void Write(Stream output)
    {
      byte[] buffer = Reinterpret.Object(header);
      output.Write(buffer, 0, buffer.Length);
      for (int i = 0; i < blocks.Count; i++)
        blocks[i].Write(output);
    }

    /// <summary>
    /// Adds a block to the end of this RIFF object.
    /// </summary>
    /// <param name="fourcc">fourcc describing the data that the new block contains</param>
    /// <param name="data">the resource raw data</param>
    public void AddBlock(string fourcc, byte[] data)
    {
      if (data.Length % 2 > 0)
        Array.Resize<byte>(ref data, data.Length + 1);

      int headerLength = Marshal.SizeOf(typeof(RiffBlockHeader));
      header.HeaderBlockHeader.Length += data.Length + headerLength;
      blocks.Add(new RiffBlock(data, fourcc));
    }

    /// <summary>
    /// Gets the RiffBlock at the specified index.
    /// </summary>
    /// <param name="index">index to retrieve from</param>
    /// <returns>RiffBlock at the given index</returns>
    public RiffBlock this[int index]
    {
      get
      { return blocks[index]; }
    }

    /// <summary>
    /// Gets the first RiffBlock with the given four character code.
    /// </summary>
    /// <param name="fourcc">a four character code to search for</param>
    /// <returns>either the first block with the given fourcc or null if none exists</returns>
    public RiffBlock this[string fourcc]
    {
      get
      {
        for (int i = 0; i < blocks.Count; i++)
          if (blocks[i].FourCC == fourcc)
            return blocks[i];
        return null;
      }
    }

    /// <summary>
    /// This header is found at the beginning of every RIFF file.
    /// </summary>
    private struct RiffHeader
    {
      public RiffBlockHeader HeaderBlockHeader;
      public uint Type;

      public RiffHeader(uint type)
      {
        Type = type;
        HeaderBlockHeader = new RiffBlockHeader();
        HeaderBlockHeader.FourCC = Reinterpret.FourCC("RIFF", ByteOrder.BigEndian);
        HeaderBlockHeader.Length = 4;
      }
    }

    /// <summary>
    /// This header is located at the start of a RIFF resource block.
    /// </summary>
    private struct RiffBlockHeader
    {
      public uint FourCC;
      public int Length;

      public RiffBlockHeader(uint fourcc, int length)
      {
        FourCC = fourcc;
        Length = length;
      }
    }

    /// <summary>
    /// This class represents a RIFF block header and the data associated with it.
    /// </summary>
    public sealed class RiffBlock
    {
      private RiffBlockHeader header;
      private byte[] data;

      internal RiffBlock(byte[] resourceData, string fourcc)
      {
        data = resourceData;
        header = new RiffBlockHeader(Reinterpret.FourCC(fourcc, ByteOrder.BigEndian), data.Length);
      }

      internal RiffBlock(Stream stream)
      {
        int headerLength = Marshal.SizeOf(typeof(RiffBlockHeader));
        data = new byte[headerLength];
        stream.Read(data, 0, headerLength);
        header = Reinterpret.Memory<RiffBlockHeader>(data);
        if (header.Length == 0)
          data = new byte[0];
        else
        {
          data = new byte[header.Length];
          stream.Read(data, 0, header.Length);
        }
      }

      internal void Write(Stream stream)
      {
        byte[] buffer = Reinterpret.Object(header);
        stream.Write(buffer, 0, buffer.Length);
        stream.Write(data, 0, header.Length);
      }

      /// <summary>
      /// Gets a four character code describing this resource.
      /// </summary>
      public string FourCC
      {
        get
        { return Reinterpret.FourCC(header.FourCC, ByteOrder.BigEndian); }
      }

      /// <summary>
      /// Gets the data that makes up this resource.
      /// </summary>
      public byte[] ResourceData
      {
        get
        { return data; }
      }
    }
  }
}
