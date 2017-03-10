using System;
using System.IO;
using System.Text;

namespace Interfaces.IO
{
  /// <summary>
  /// Writes primitive data types in binary form in various byte orders.
  /// </summary>
  public class EndianWriter : BinaryWriter
  {
    private Stream stream;
    private ByteOrder order;

    public EndianWriter(Stream inStream, ByteOrder inOrder)
      : base(inStream, Encoding.ASCII)
    {
      stream = inStream;
      order = inOrder;
    }

    public EndianWriter(Stream inStream, ByteOrder inOrder, Encoding encoding)
      : base(inStream, encoding)
    {
      stream = inStream;
      order = inOrder;
    }

    public virtual int Position
    {
      get { return (int)stream.Position; }
      set { stream.Position = value; }
    }

    public virtual int Length
    {
      get { return (int)stream.Length; }
      set { stream.SetLength(value); }
    }

    public virtual void Write(Int24 value)
    {
      this.Write(value.DWord);
    }

    public override void Write(float value)
    {
      base.Write(BitConverter.ToSingle(ByteSwap(BitConverter.GetBytes(value)), 0));
    }

    public override void Write(double value)
    {
      base.Write(BitConverter.ToDouble(ByteSwap(BitConverter.GetBytes(value)), 0));
    }

    public override void Write(short value)
    {
      base.Write(BitConverter.ToInt16(ByteSwap(BitConverter.GetBytes(value)), 0));
    }

    public override void Write(int value)
    {
      base.Write(BitConverter.ToInt32(ByteSwap(BitConverter.GetBytes(value)), 0));
    }

    public override void Write(long value)
    {
      base.Write(BitConverter.ToInt64(ByteSwap(BitConverter.GetBytes(value)), 0));
    }

    public override void Write(ushort value)
    {
      base.Write(BitConverter.ToUInt16(ByteSwap(BitConverter.GetBytes(value)), 0));
    }

    public override void Write(uint value)
    {
      base.Write(BitConverter.ToUInt32(ByteSwap(BitConverter.GetBytes(value)), 0));
    }

    public override void Write(ulong value)
    {
      base.Write(BitConverter.ToUInt64(ByteSwap(BitConverter.GetBytes(value)), 0));
    }

    public virtual void Write(string value, bool nullEnd)
    {
      for (int x = 0; x < value.Length; x++)
        base.Write(Convert.ToByte(value[x]));
      if (nullEnd)
        base.Write((byte)0);
    }

    public virtual Int24 Append(string data)
    {
      long pos = stream.Position;
      stream.Position = stream.Length;
      Int24 int24 = new Int24(Position, (byte)data.Length);
      stream.SetLength(stream.Length + data.Length + 1);
      for (int x = 0; x < data.Length; x++)
        base.Write(Convert.ToByte(data[x]));
      base.Write((byte)0);
      stream.Position = pos;
      return int24;
    }

    public virtual void WriteFourCC(string data)
    {
      if (order == ByteOrder.LittleEndian)
        Write(EndianSwap.ReverseString(data), false);
      else
        Write(data, false);
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
