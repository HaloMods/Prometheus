using System;
using System.IO;
using System.Runtime.InteropServices;
using Interfaces.IO;

namespace Interfaces.Sound.Codecs
{
  /// <summary>
  /// Represents the PCM sound codec.
  /// </summary>
  public class PCM : RIFF, ICodec
  {
    private bool hasBeenSet = false;
    private byte[] data;
    private PCMFormat format;

    public void SetRawData(byte[] data)
    {
      if (hasBeenSet)
        throw new SoundSystemException("Cannot set data to the same codec object more than once.");

      this.data = data;
      AddBlock("fact", BitConverter.GetBytes(data.Length / (format.SignificantBitsPerSample / 8 * format.ChannelCount)));
      AddBlock("data", data);
      hasBeenSet = true;
    }

    public void SetEncodedData(byte[] data)
    {
      if (hasBeenSet)
        throw new SoundSystemException("Cannot set data to the same codec object more than once.");

      this.data = data;
      AddBlock("fact", BitConverter.GetBytes(data.Length / (format.SignificantBitsPerSample / 8 * format.ChannelCount)));
      AddBlock("data", data);
      hasBeenSet = true;
    }

    public byte[] GetRaw()
    {
      return data;
    }

    public byte[] GetEncoded()
    {
      return data;
    }

    public string Name
    {
      get
      { return "PCM"; }
    }

    public short ChannelCount
    {
      get
      { return format.ChannelCount; }
    }

    public int SampleRate
    {
      get
      { return format.SampleRate; }
    }

    public PCM(Stream stream)
      : base(stream)
    {
      format = Reinterpret.Memory<PCMFormat>(this["fmt "].ResourceData);
      data = this["data"].ResourceData;
      hasBeenSet = true;
    }

    public PCM(short channels, int sampleRate)
      : base("WAVE")
    {
      format = new PCMFormat();
      format.ChannelCount = channels;
      format.SignificantBitsPerSample = 16;
      format.BlockAlign = (short)(format.SignificantBitsPerSample / 8 * format.ChannelCount);
      format.SampleRate = sampleRate;
      format.BytesPerSecond = format.SampleRate * format.BlockAlign;
      format.CompressionCode = 1;
      format.ExtraByteCount = 0;
      AddBlock("fmt ", Reinterpret.Object(format));
    }

    [StructLayout(LayoutKind.Sequential, Pack = 2)]
    private struct PCMFormat
    {
      public short CompressionCode; // 1 for uncompressed PCM
      public short ChannelCount;
      public int SampleRate;
      public int BytesPerSecond; // SampleRate * BlockAlign
      public short BlockAlign; // SignificantBitsPerSample / 8 * ChannelCount
      public short SignificantBitsPerSample;
      public short ExtraByteCount; // 0
    }
  }
}
