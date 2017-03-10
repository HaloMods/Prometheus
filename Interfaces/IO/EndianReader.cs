using System;
using System.IO;
using System.Text;

namespace Interfaces.IO
{
  /// <summary>
  /// Reads primitive data types using a specified byte order.
  /// </summary>
  public class EndianReader : BinaryReader
  {
    private ByteOrder order;

    public EndianReader(Stream inStream, ByteOrder bOrder, Encoding tEncoding)
      : base(inStream, tEncoding)
    {
      order = bOrder;
    }

    public EndianReader(Stream inStream, ByteOrder bOrder)
      : base(inStream, Encoding.ASCII)
    {
      order = bOrder;
    }

    public virtual Int24 ReadInt24()
    {
      return new Int24(BitConverter.ToInt32(ByteSwap(BitConverter.GetBytes(base.ReadInt32())), 0));
    }

    public virtual Int24 ReadInt24(int magic)
    {
      Int24 int24 = new Int24(BitConverter.ToInt32(ByteSwap(BitConverter.GetBytes(base.ReadInt32())), 0));
      int24.Integer += magic;
      return int24;
    }

    public override short ReadInt16()
    {
      return BitConverter.ToInt16(ByteSwap(BitConverter.GetBytes(base.ReadInt16())), 0);
    }

    public override int ReadInt32()
    {
      return BitConverter.ToInt32(ByteSwap(BitConverter.GetBytes(base.ReadInt32())), 0);
    }

    public override long ReadInt64()
    {
      return BitConverter.ToInt64(ByteSwap(BitConverter.GetBytes(base.ReadInt64())), 0);
    }

    public override ushort ReadUInt16()
    {
      return BitConverter.ToUInt16(ByteSwap(BitConverter.GetBytes(base.ReadUInt16())), 0);
    }

    public override uint ReadUInt32()
    {
      return BitConverter.ToUInt32(ByteSwap(BitConverter.GetBytes(base.ReadUInt32())), 0);
    }

    public override ulong ReadUInt64()
    {
      return BitConverter.ToUInt64(ByteSwap(BitConverter.GetBytes(base.ReadUInt64())), 0);
    }

    public override float ReadSingle()
    {
      return BitConverter.ToSingle(ByteSwap(BitConverter.GetBytes(base.ReadSingle())), 0);
    }

    public override double ReadDouble()
    {
      return BitConverter.ToDouble(ByteSwap(BitConverter.GetBytes(base.ReadDouble())), 0);
    }

    public virtual string ReadFourCC()
    {
      string fourcc = ReadString(4);
      if (order == ByteOrder.LittleEndian)
        return EndianSwap.ReverseString(fourcc);
      else
        return fourcc;
    }

    public virtual int Position
    {
      get { return (int)base.BaseStream.Position; }
      set { base.BaseStream.Position = value; }
    }

    public virtual int Length
    {
      get { return (int)base.BaseStream.Length; }
      set { base.BaseStream.SetLength(value); }
    }

    public virtual string ReadString(int len)
    {
      string ret = String.Empty;
      for (int x = 0; x < len; x++)
        ret += Convert.ToChar(base.ReadByte());
      return ret;
    }

    public virtual string ReadString(Int24 stats)
    {
      long pos = base.BaseStream.Position;
      base.BaseStream.Position = stats.Integer;
      string str = String.Empty;
      for (byte x = 0; x < stats.Byte; x++)
        str += Convert.ToChar(base.ReadByte());
      base.BaseStream.Position = pos;
      return str;
    }

    public override string ReadString()
    {
      char chr = '\0';
      string str = "";
      do
      {
        chr = Convert.ToChar(base.ReadByte());
        str += chr;
      } while (chr != '\0');
      return str;
    }

    protected byte[] ByteSwap(byte[] bytes)
    {
      if (order == ByteOrder.BigEndian)
      {
        switch (bytes.Length)
        {
          case 2:
            EndianSwap.ByteSwap2(bytes);
            break;
          case 4:
            EndianSwap.ByteSwap4(bytes);
            break;
          case 8:
            EndianSwap.ByteSwap8(bytes);
            break;
          default:
            throw new NotSupportedException("Stream lengths other than 2, 4, and 8 are invalid for an endian swap.");
        }
      }
      return bytes;
    }
  }
}
