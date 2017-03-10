using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.DirectX.DirectSound;

namespace Interfaces.Sound.Instancing
{
  /// <summary>
  /// A sound instance which will play with no defined position.
  /// </summary>
  public class EnvironmentSoundInstance : SoundInstance
  {
    public EnvironmentSoundInstance(Device device, WaveFormat format, ISoundDataProvider provider)
      : base(device, format, provider)
    {
    }
  }
}
