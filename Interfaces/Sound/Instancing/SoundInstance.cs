using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.DirectX.DirectSound;

namespace Interfaces.Sound.Instancing
{
  /// <summary>
  /// The abstract base class from which all sound instances must inherit.
  /// </summary>
  public abstract class SoundInstance : IDisposable
  {
    protected StreamingSoundBuffer buffer = null;

    public SoundInstance(Device device, WaveFormat format, ISoundDataProvider provider)
    {
      buffer = new StreamingSoundBuffer(device, format, provider);
    }

    public virtual void Play()
    {
      buffer.Start();
    }

    public virtual void Stop()
    {
      buffer.Stop();
    }

    public virtual void Dispose()
    {
      buffer.Dispose();
    }
  }
}
