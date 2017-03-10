using System;
using System.Collections.Generic;
using System.Text;
using Interfaces.Sound;

namespace Games.Halo.Tags.Classes
{
  public partial class sound_looping
  {
    private sound[] inSounds = null;
    private sound[] loopSounds = null;
    private sound[] outSounds = null;

    public override void DoPostProcess()
    {
      base.DoPostProcess();

      inSounds = new sound[soundLoopingValues.Tracks.Count];
      for (int i = 0; i < inSounds.Length; i++)
        inSounds[i] = Open<sound>(soundLoopingValues.Tracks[i].Start.Value);
      loopSounds = new sound[soundLoopingValues.Tracks.Count];
      for (int i = 0; i < loopSounds.Length; i++)
        loopSounds[i] = Open<sound>(soundLoopingValues.Tracks[i].Loop.Value);
      outSounds = new sound[soundLoopingValues.Tracks.Count];
      for (int i = 0; i < outSounds.Length; i++)
        outSounds[i] = Open<sound>(soundLoopingValues.Tracks[i].End.Value);
    }

    public override void Dispose()
    {
      base.Dispose();

      if (inSounds != null)
        for (int i = 0; i < inSounds.Length; i++)
          Release(inSounds[i]);
      if (loopSounds != null)
        for (int i = 0; i < loopSounds.Length; i++)
          Release(loopSounds[i]);
      if (outSounds != null)
        for (int i = 0; i < outSounds.Length; i++)
          Release(outSounds[i]);
    }
  }
}
