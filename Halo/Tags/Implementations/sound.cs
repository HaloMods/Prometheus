using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using Microsoft.DirectX.DirectSound;
using Interfaces.Sound;
using Interfaces.Sound.Codecs;

namespace Games.Halo.Tags.Classes
{
  public partial class sound : ISoundDataProvider
  {
    private byte[][][] chunks = null;
    private WaveFormat format = new WaveFormat();

    public override void DoPostProcess()
    {
      base.DoPostProcess();

      format.FormatTag = WaveFormatTag.Pcm;
      format.SamplesPerSecond = soundValues.SampleRate.Value == 0 ? 22050 : 44100;
      format.Channels = (short)(soundValues.Encoding.Value == 0 ? 1 : 2);
      format.BitsPerSample = 16;
      format.BlockAlign = (short)(format.BitsPerSample / 8 * format.Channels);
      format.AverageBytesPerSecond = format.SamplesPerSecond * format.BlockAlign;

      chunks = new byte[soundValues.PitchRanges.Count][][];
      for (int i = 0; i < chunks.Length; i++)
      {
        if (soundValues.Flags.GetFlag(2)) // split long sound into permutations
        {
          short count = 0;
          for (int j = 0; j < soundValues.PitchRanges[i].Permutations.Count; j++)
            if (soundValues.PitchRanges[i].Permutations[j].NextPermutationIndex.Value < 0)
              count++;

          List<short>[] permutations = new List<short>[count];
          for (short j = 0; j < count; j++)
          {
            permutations[j] = new List<short>();
            short nextPermutation = soundValues.PitchRanges[i].Permutations[j].NextPermutationIndex.Value;
            permutations[j].Add(j);
            while (nextPermutation >= 0)
            {
              permutations[j].Add(nextPermutation);
              nextPermutation = soundValues.PitchRanges[i].Permutations[nextPermutation].NextPermutationIndex.Value;
            }
          }

          chunks[i] = new byte[count][];
          for (short j = 0; j < count; j++)
          {
            MemoryStream stream = new MemoryStream();
            for (int k = 0; k < permutations[j].Count; k++)
            {
              byte[] chunk = DecodeSamples(soundValues.PitchRanges[i].Permutations[permutations[j][k]].Samples.Binary, soundValues.PitchRanges[i].Permutations[permutations[j][k]].Compression.Value, format);
              stream.Write(chunk, 0, chunk.Length);
            }
            chunks[i][j] = stream.ToArray();
            stream.Close();
          }
        }
        else
        {
          chunks[i] = new byte[soundValues.PitchRanges[i].Permutations.Count][];
          for (int j = 0; j < chunks[i].Length; j++)
            chunks[i][j] = DecodeSamples(soundValues.PitchRanges[i].Permutations[j].Samples.Binary, soundValues.PitchRanges[i].Permutations[j].Compression.Value, format);
        }
      }
    }

    private static byte[] DecodeSamples(byte[] binary, short encoding, WaveFormat format)
    {
      switch (encoding)
      {
        case 0: // none
          PCM pcm = new PCM(format.Channels, format.SamplesPerSecond);
          pcm.SetEncodedData(binary);
          return pcm.GetRaw();
        case 1: // xbox adpcm
          XboxADPCM xbadpcm = new XboxADPCM(format.Channels, format.SamplesPerSecond);
          xbadpcm.SetEncodedData(binary);
          return xbadpcm.GetRaw();
        case 2: // ima adpcm
          throw new HaloException("The sound encoding 'ima adpcm' is not yet supported.");
        case 3: // ogg vorbis
          throw new HaloException("The sound encoding 'ogg vorbis' is not yet supported.");
        default:
          throw new HaloException("The sound encoding {0} does not exist.", encoding);
      }
    }

    public WaveFormat WaveFormat
    {
      get
      { return format; }
    }

    public byte[] GetNextChunk()
    {
      return chunks[0][Random.Next(chunks[0].Length - 1)];
    }
  }
}
