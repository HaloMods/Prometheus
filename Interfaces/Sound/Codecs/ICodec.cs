using System;
using System.IO;
using System.Runtime.InteropServices;

namespace Interfaces.Sound.Codecs
{
  /// <summary>
  /// Exposes methods to decode and encode a data stream.
  /// </summary>
  public interface ICodec
  {
    /// <summary>
    /// Gets a name of the represented codec.
    /// </summary>
    string Name
    { get; }

    /// <summary>
    /// Gets the number of samples per second.
    /// </summary>
    int SampleRate
    { get; }

    /// <summary>
    /// Gets the number of independent channels.
    /// </summary>
    short ChannelCount
    { get; }

    /// <summary>
    /// Provides the codec with raw data to encode.
    /// </summary>
    /// <param name="data">data to encode</param>
    void SetRawData(byte[] data);

    /// <summary>
    /// Provides the codec with pre-encoded data to store.
    /// </summary>
    /// <param name="data">data to store</param>
    void SetEncodedData(byte[] data);

    /// <summary>
    /// Gets raw (decoded) sound data from the object.
    /// </summary>
    byte[] GetRaw();

    /// <summary>
    /// Gets encoded sound data from the object.
    /// </summary>
    byte[] GetEncoded();
  }
}
