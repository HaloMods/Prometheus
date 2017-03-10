using System;
using Games.Halo.Compiler;

namespace Games.Halo.Platforms.Shared
{
  public static class ShaderIndices
  {
    public static Array GetIndex(string shaderType, MapFormat format)
    {
      Array array = Array.CreateInstance(typeof(byte), 2);
      array.SetValue((byte)0x00, 1);
      if (format == MapFormat.Xbox)
      {
        switch (shaderType)
        {
          case "senv":
            array.SetValue((byte)0x03, 0); //
            break;
          case "sgla":
            array.SetValue((byte)0x08, 0); //
            break;
          case "swat":
            array.SetValue((byte)0x07, 0); //
            break;
          case "sotr":
            array.SetValue((byte)0x05, 0); //
            break;
          case "soso":
            array.SetValue((byte)0x04, 0); //
            break;
          case "schi":
          case "scex":
            array.SetValue((byte)0x06, 0); //
            break;
          case "spla":
            array.SetValue((byte)0x0a, 0); //
            break;
          case "smet":
            array.SetValue((byte)0x09, 0); //
            break;
        }
      }
      else
      {
        switch (shaderType)
        {
          case "senv":
            array.SetValue((byte)0x03, 0); //
            break;
          case "sgla":
            array.SetValue((byte)0x09, 0); //
            break;
          case "swat":
            array.SetValue((byte)0x08, 0); //
            break;
          case "sotr":
            array.SetValue((byte)0x05, 0);
            break;
          case "soso":
            array.SetValue((byte)0x04, 0); //
            break;
          case "schi":
            array.SetValue((byte)0x06, 0); //
            break;
          case "scex":
            array.SetValue((byte)0x07, 0); //
            break;
          case "spla":
            array.SetValue((byte)0x0b, 0); //
            break;
          case "smet":
            array.SetValue((byte)0x0a, 0); //
            break;
        }
      }

      return array;
    }
  }
}
