using System;

namespace Interfaces.Sound
{
  /// <summary>
  /// Exposes a method on an object to provide sound chunks to a StreamingSoundBuffer.
  /// </summary>
  public interface ISoundDataProvider
  {
    /// <summary>
    /// Gets a buffer of PCM waveform data to play.
    /// </summary>
    /// <returns>PCM buffer of bytes to play, or an empty array if none are left. may NOT return null</returns>
    byte[] GetNextChunk();
  }
}
