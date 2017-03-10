using System;
using System.IO;
using System.Runtime.InteropServices;
using Interfaces.IO;

namespace Interfaces.Sound.Codecs
{
  /// <summary>
  /// Represents the Microsoft Xbox ADPCM sound codec.
  /// </summary>
  /// <remarks>
  /// Based on the XboxAdpcm class written by ZeldaFreak.
  /// </remarks>
  public class XboxADPCM : RIFF, ICodec
  {
    private bool hasBeenSet = false;
    private byte[] data;
    private XboxAdpcmFormat format;

    public string Name
    {
      get
      { return "Xbox ADPCM"; }
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

    public void SetRawData(byte[] data)
    {
      if (hasBeenSet)
        throw new SoundSystemException("Cannot set data to the same codec object more than once.");
      
      short[,] expanded = ExpandSampleArray(data, format.ChannelCount);
      EncodeMemory(ref expanded, ref data);
      AddBlock("data", data);
      hasBeenSet = true;
    }

    public void SetEncodedData(byte[] data)
    {
      if (hasBeenSet)
        throw new SoundSystemException("Cannot set data to the same codec object more than once.");

      this.data = data;
      AddBlock("data", data);
      hasBeenSet = true;
    }

    public byte[] GetRaw()
    {
      short[,] samples = DecodeMemory(data, 0, data.Length, format.ChannelCount);
      return FlattenSampleArray(samples);
    }

    public byte[] GetEncoded()
    {
      return data;
    }

    public XboxADPCM(Stream stream)
      : base(stream)
    {
      format = Reinterpret.Memory<XboxAdpcmFormat>(this["fmt "].ResourceData);
      data = this["data"].ResourceData;
      hasBeenSet = true;
    }

    public XboxADPCM(short channels, int sampleRate)
      : base("WAVE")
    {
      format = new XboxAdpcmFormat();
      format.ChannelCount = channels;
      format.BlockAlign = (short)(format.ChannelCount * 36);
      format.SampleRate = sampleRate;
      format.BytesPerSecond = (format.SampleRate * format.BlockAlign) >> 6;
      format.SignificantBitsPerSample = 4;
      format.CompressionCode = 105;
      format.ExtendedByteCount = 2;
      format.SamplesPerBlock = 64;
      AddBlock("fmt ", Reinterpret.Object(format));
    }

    #region Codec Implementation
    private const int XboxAdpcmChunkSize = 36;
    private const short XboxAdpcmSampleCount = 64;

    private static short[] StepTable = {
                7, 8, 9, 10, 11, 12, 13, 14, 16, 17,
                19, 21, 23, 25, 28, 31, 34, 37, 41, 45,
                50, 55, 60, 66, 73, 80, 88, 97, 107, 118,
                130, 143, 157, 173, 190, 209, 230, 253, 279, 307,
                337, 371, 408, 449, 494, 544, 598, 658, 724, 796,
                876, 963, 1060, 1166, 1282, 1411, 1552, 1707, 1878, 2066,
                2272, 2499, 2749, 3024, 3327, 3660, 4026, 4428, 4871, 5358,
                5894, 6484, 7132, 7845, 8630, 9493, 10442, 11487, 12635, 13899,
                15289, 16818, 18500, 20350, 22385, 24623, 27086, 29794, 32767 };

    private static sbyte[] IndexTable = { -1, -1, -1, -1, 2, 4, 6, 8,
                             -1, -1, -1, -1, 2, 4, 6, 8 };

    private struct AdpcmState
    {
      public sbyte Index;
      public short StepSize;
      public short Previous;

      public int sampleCount;
    }

    private struct XboxAdpcmFormat
    {
      public short CompressionCode; // 105 for xbox adpcm
      public short ChannelCount;
      public int SampleRate; // 8000 - 48000
      public int BytesPerSecond; // ((SampleRate * BlockAlign) >> 6)
      public short BlockAlign; // ChannelCount * 36
      public short SignificantBitsPerSample; // 4
      public short ExtendedByteCount; // 2
      public short SamplesPerBlock; // 64
    }

    private static short DecodeSample(byte sample, ref AdpcmState State)
    {
      short result = 0;

      // Decode the sample...
      result = (short)(State.StepSize >> 3);
      if ((sample & 4) != 0) result += State.StepSize;
      if ((sample & 2) != 0) result += (short)(State.StepSize >> 1);
      if ((sample & 1) != 0) result += (short)(State.StepSize >> 2);
      if ((sample & 8) != 0)
        State.Previous -= result;
      else
        State.Previous += result;

      // Delimit the result...
      if (State.Previous > 32767)
        State.Previous = 32767;
      else if (State.Previous < -32768)
        State.Previous = -32768;

      // Adjust the step index...
      State.Index += IndexTable[sample];

      // Delimit the step index...
      if (State.Index > 88)
        State.Index = 88;
      else if (State.Index < 0)
        State.Index = 0;

      // Adjust the step size to the new step index...
      State.StepSize = StepTable[State.Index];

      return State.Previous;
    }

    private static byte EncodeSample(short sample, ref AdpcmState State)
    {
      byte bytecode = 0;      // this will store the sample

      short dif = (short)(sample - State.Previous);   // this will store the unresolved difference between 
      // the current sample and the previous prediction.
      // short tempDif = dif;
      //   short predictedDelta;                           // The difference between the current prediction and 
      // the previous

      State.StepSize = StepTable[State.Index];        //

      #region Old stuff
      /*if (dif < 0)
        {
            bytecode = 8;
            dif = (short)Math.Abs(dif);
        }
        predictedDelta = (short)(State.StepSize >> 3);

        for (int x = 1; x <= 3; x++)
        {
            if (dif >= (State.StepSize >> x))
            {
                bytecode |= (byte)(1 << (3-x));
                dif -= (short)(State.StepSize >> x);
                predictedDelta += (short)(State.StepSize >> x);
            }
        }
        if ((bytecode & 8) != 0) State.Previous -= predictedDelta;
        else State.Previous += predictedDelta;

        if (State.Previous > 32767) State.Previous = 32767;
        else if (State.Previous < -32768) State.Previous = -32768;

        State.Index += IndexTable[bytecode];
        if (State.Index > 88) State.Index = 88;
        else if (State.Index < 0) State.Index = 0;

        return bytecode;*/
      #endregion

      short predictedDelta = (short)(State.StepSize >> 3);
      if (dif < 0)
      {
        bytecode = 8;
        dif = (short)(dif * -1);
      }
      byte mask = 4;
      short step = State.StepSize;
      while (mask != 0)
      {
        if (dif >= step)
        {
          bytecode |= mask;
          dif -= step;
          predictedDelta += step;
        }
        step >>= 1;
        mask >>= 1;
      }
      if ((bytecode & 8) != 0) State.Previous -= predictedDelta;
      else State.Previous += predictedDelta;
      if (State.Previous > 32767) State.Previous = 32767;
      else if (State.Previous < -32768) State.Previous = -32768;

      State.Index += IndexTable[bytecode];
      if (State.Index > 88) State.Index = 88;
      else if (State.Index < 0) State.Index = 0;
      return bytecode;

    }

    private static short[,] DecodeBlock(byte[] block, ref AdpcmState[] State)
    {
      return DecodeBlock(block, 0, ref State);
    }

    private static short[,] DecodeBlock(byte[] block, int startPos, ref AdpcmState[] State)
    {
      return DecodeBlock(block, startPos, (block.Length - startPos) / XboxAdpcmChunkSize, ref State);
    }

    private static short[,] DecodeBlock(byte[] block, int startPos, int FChannels, ref AdpcmState[] State)
    {
      //    AdpcmState[] State = new AdpcmState[FChannels];
      if (((block.Length - startPos) / XboxAdpcmChunkSize) < FChannels)
        return new short[0, 0]; // Not enough data to decode a block.
      short[,] samples = new short[XboxAdpcmSampleCount, FChannels];

      int blockPos = startPos;

      // Decode the header-- initialize block state
      for (int chan = 0; chan < FChannels; chan++)
      {
        samples[0, chan] = (short)(block[blockPos] | (block[blockPos + 1] << 8));
        State[chan].Previous = samples[0, chan];
        State[chan].Index = (sbyte)block[blockPos + 2];
        State[chan].StepSize = StepTable[State[chan].Index];
        State[chan].sampleCount = 1;
        blockPos += 4;
      }
      // There are 8 32-bit sample chunks, each with eight samples
      for (int x = 0; x < 8; x++)
      {
        for (int chan = 0; chan < FChannels; chan++)
        {
          int sampleBuf = ((block[blockPos]) | (block[blockPos + 1]) << 8 | (block[blockPos + 2] << 16) | (block[blockPos + 3] << 24));
          blockPos += 4;
          for (int y = 0; y < 8; y++)
          {
            if (State[chan].sampleCount >= 64)
              break;
            samples[State[chan].sampleCount, chan] = DecodeSample((byte)(sampleBuf & 0xF), ref State[chan]);
            sampleBuf >>= 4;
            State[chan].sampleCount++;
          }
        }
      }
      return samples;
    }

    /// <summary>
    /// Encodes 64 samples into XBADPCM. Any extra samples are discarded. Channel count is inferred based on the second dimension of "samples".
    /// </summary>
    /// <param name="samples">A two-dimensional array of 16-bit samples. The first dimension should be the sample index, the second being the channel index.</param>
    /// <returns>The byte array of the current block</returns>
    private static int EncodeBlock(ref short[,] samples, int startPos, ref AdpcmState[] State, ref byte[] block)
    {
      int FChannels = samples.GetLength(1);
      int sampleCount = (samples.GetLength(0) - startPos) / FChannels;
      //block = new byte[XboxAdpcmChunkSize * FChannels];

      int blockPos = 0;
      //        int samplePos = startPos;

      for (int chan = 0; chan < FChannels; chan++)
      {
        block[blockPos++] = (byte)(samples[startPos, chan] & 0xFF);
        block[blockPos++] = (byte)((samples[startPos, chan] >> 8) & 0xFF);
        State[chan].Previous = samples[startPos, chan];
        block[blockPos++] = (byte)State[chan].Index;
        blockPos++;
        State[chan].sampleCount = 1;
      }
      for (int x = 0; x < 8; x++)
      {
        for (int chan = 0; chan < FChannels; chan++)
        {
          for (int y = 0; y < 4; y++)
          {
            block[blockPos] = 0;
            for (int z = 0; z < 2; z++)
            {
              if (State[chan].sampleCount == XboxAdpcmSampleCount)
                continue;

              byte bytecode1 = EncodeSample(samples[State[chan].sampleCount + startPos, chan], ref State[chan]);

              block[blockPos] |= (byte)(bytecode1 << (z * 4));
              State[chan].sampleCount++;
            }
            blockPos++;
          }
        }
      }
      for (; blockPos < block.Length; blockPos++)
        block[blockPos] = 0;
      return block.Length;
    }

    /// <summary>
    /// Decodes the byte array of Xbox ADPCM blocks. Returns a two-dimensional short array of all the decoded samples.
    /// </summary>
    /// <param name="data">The byte array to decode.</param>
    /// <param name="startPos">The position in the byte array at which to start.</param>
    /// <param name="size">The size of data to decode in the byte array.</param>
    /// <param name="FChannels">The number of channels.</param>
    /// <returns>A two-dimensional short array of all the decoded samples in 16-bit PCM.</returns>
    private static short[,] DecodeMemory(byte[] data, int startPos, int size, int FChannels)
    {
      AdpcmState[] State = new AdpcmState[FChannels];
      int blockCount = size / (XboxAdpcmChunkSize * FChannels);
      byte[] block = new byte[XboxAdpcmChunkSize * FChannels];
      short[,] samples = new short[blockCount * 64, FChannels];
      int sampleCount = 0;

      for (int x = 0; x < blockCount; x++)
      {
        if (MemCpy(data, ref block, XboxAdpcmChunkSize * FChannels, (x * XboxAdpcmChunkSize * FChannels) + startPos) < XboxAdpcmChunkSize * FChannels)
          return samples;
        short[,] temp = DecodeBlock(block, 0, FChannels, ref State);
        for (int y = 0; y < 64; y++)
        {
          for (int chan = 0; chan < FChannels; chan++)
            samples[sampleCount, chan] = temp[y, chan];
          sampleCount++;
        }
      }
      return samples;
    }

    /// <summary>
    /// Encodes the array of 16-bit uncompressed PCM samples into Xbox ADPCM blocks.
    /// </summary>
    /// <param name="samples">The array of 16-bit uncompressed PCM samples.</param>
    /// <returns>A memory buffer of type byte array with the encoded Xbox ADPCM blocks.</returns>
    private static int EncodeMemory(ref short[,] samples, ref byte[] data)
    {
      int FChannels = samples.GetLength(1);
      AdpcmState[] State = new AdpcmState[FChannels];
      int sampleCount = samples.GetLength(0);
      int blockCount = (sampleCount / XboxAdpcmSampleCount);

      data = new byte[blockCount * XboxAdpcmChunkSize * FChannels];
      byte[] block = new byte[XboxAdpcmChunkSize * FChannels];
      int dataPos = 0;

      for (int x = 0; x < blockCount; x++)
      {
        EncodeBlock(ref samples, x * 64, ref State, ref block);

        for (int y = 0; y < block.Length; y++)
          data[dataPos++] = block[y];
      }
      return data.Length;
    }

    private static int MemCpy(byte[] data, ref byte[] outDat, int size, int startPos)
    {
      /*if (size <= data.Length)
      {
          outDat = data;
          return data.Length;
      }*/
      if (size > data.Length - startPos)
        size = data.Length - startPos;

      if (outDat.Length < size)
        outDat = new byte[size];

      for (int x = 0; x < size; x++)
        outDat[x] = data[startPos++];

      return size;
    }

    private static byte[] FlattenSampleArray(short[,] samples)
    {
      int counter = 0;
      byte[] flattened = new byte[samples.Length * sizeof(short)];
      for (int x = 0; x < samples.GetLength(0); x++)
      {
        for (int y = 0; y < samples.GetLength(1); y++)
        {
          byte[] word = BitConverter.GetBytes(samples[x, y]);
          flattened[counter++] = word[0];
          flattened[counter++] = word[1];
        }
      }
      return flattened;
    }

    private static short[,] ExpandSampleArray(byte[] flattened, short channels)
    {
      int dimension = flattened.Length / sizeof(short) / channels;
      short[,] samples = new short[dimension, channels];
      for (int i = 0; i < flattened.Length; i += 2)
      {
        int remainder;
        int quotient = Math.DivRem(i, dimension, out remainder);
        samples[remainder, quotient] = BitConverter.ToInt16(flattened, i);
      }
      return samples;
    }

    private static string ReadString(byte[] array, int Start, int Length)
    {
      string ret = "";
      if (Start + Length < array.Length)
      {
        for (int x = Start; x < Start + Length; x++)
          ret += (char)array[x];
      }
      else
        for (int x = Start; x < array.Length; x++)
          ret += (char)array[x];
      return ret;
    }

    private static string ReadString(byte[] array, int Start)
    {
      string ret = "";
      while (Start < array.Length)
      {
        if (array[Start] == 0)
          break;
        ret += (char)array[Start];
        Start++;
      }
      return ret;
    }

    private static string ReadString(byte[] array)
    {
      return ReadString(array, 0);
    }
    #endregion
  }
}
