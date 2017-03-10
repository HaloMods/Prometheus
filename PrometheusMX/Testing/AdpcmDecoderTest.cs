using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.IO;
using Interfaces.Sound.Codecs;

#if DEBUG
namespace Prometheus.Testing
{
  [TestInfo("SwampFox", "ADPCM Decoder Test",
  "Prompts for the user to open an ADPCM sound file and attempts to save it as a PCM wave format file.")]
  public sealed class AdpcmDecoderTest : ITest
  {
    public void PerformTest()
    {
      OpenFileDialog ofd = new OpenFileDialog();
      ofd.Title = "Open Sound File";
      ofd.Filter = "ADPCM Wave File (*.wav)|*.wav";
      if (ofd.ShowDialog() == DialogResult.OK)
      {
        SaveFileDialog sfd = new SaveFileDialog();
        sfd.Title = "Save Sound File";
        sfd.Filter = "Wave File (*.wav)|*.wav";
        if (sfd.ShowDialog() == DialogResult.OK)
        {
          Stream input = ofd.OpenFile();
          XboxADPCM encoded = new XboxADPCM(input);
          PCM decoded = new PCM(encoded.ChannelCount, encoded.SampleRate);
          decoded.SetRawData(encoded.GetRaw());
          Stream output = File.OpenWrite(sfd.FileName);
          decoded.Write(output);
          output.Close();
          input.Close();
        }
      }
    }
  }
}
#endif
