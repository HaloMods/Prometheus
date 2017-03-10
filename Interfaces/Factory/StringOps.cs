using System;
using System.IO;
using System.Text;

namespace Interfaces.Factory
{
  /// <summary>
  /// Performs operations on strings.
  /// </summary>
  public static class StringOps
  {
		/// <summary>
		/// Reads a C-style string from the specified <c>BinaryReader</c>.
		/// </summary>
		public static string ReadCString(BinaryReader reader)
		{
			StringBuilder sb = new StringBuilder();
			char c;

			while ((c = reader.ReadChar()) != 0)
				sb.Append(c);
			reader.BaseStream.Position += 1;

			return sb.ToString();
		}

		/// <summary>
		/// Reads a C-style string from a fixed length block from the specified <c>BinaryReader</c>.
		/// </summary>
		public static string ReadFixedLengthCString(BinaryReader reader, int length)
		{
			StringBuilder sb = new StringBuilder();
			long endOffset = reader.BaseStream.Position + length;
			char c;

			while ((c = reader.ReadChar()) != 0 && sb.Length != length)
				sb.Append(c);
			reader.BaseStream.Position = endOffset;

			return sb.ToString();
		}

		/// <summary>
		/// Reads a C-style string from a fixed length block from a byte array at the specified offset.
		/// </summary>
		public static string ReadFixedLengthCString(byte[] sourceData, int offset, int length)
		{
			int readCount = Math.Min(length, sourceData.Length - offset);
			BinaryReader br = new BinaryReader(new MemoryStream(sourceData, offset, readCount));

			return ReadFixedLengthCString(br, readCount);
		}

		/// <summary>
		/// Reads a C-style string from a byte array at the specified offset.
		/// </summary>
		public static string ReadCString(byte[] sourceData, int offset)
		{
			BinaryReader br = new BinaryReader(new MemoryStream(sourceData, offset, sourceData.Length - offset));
			
			return ReadCString(br);
		}

    /// <summary>
    /// Writes a non-formatted string to the specified <c>BinaryWriter</c>.
    /// </summary>
    public static void WriteString(string value, BinaryWriter writer)
    {
      byte[] bin = Encoding.ASCII.GetBytes(value);
      writer.Write(bin);
    }

    /// <summary>
		/// Writes a non-formatted NULL-terminated string to the specified <c>BinaryWriter</c>.
    /// </summary>
    public static void WriteCString(string value, BinaryWriter writer)
    {
      WriteString(value, writer);
      writer.Write((byte)0);
    }

		/// <summary>
		/// Writes a non-formatted NULL-terminated string to the specified <c>BinaryWriter</c> and pads for the specified fixed length.
		/// </summary>
		public static void WriteFixedLengthCString(string value, BinaryWriter writer, int length)
		{
			WriteString(value, writer);

			int padLength = length - value.Length;
			for (int i = 0; i < padLength; i++)
				writer.Write((byte)0);
		}

		/// <summary>
		/// Returns the length of the longest string contained within the specified array.
		/// </summary>
		public static int LongestStringLength(params string[] values)
    {
      int longestString = 0;
      foreach (string s in values)
        if (s.Length > longestString) longestString = s.Length;
      return longestString;
    }

    /// <summary>
    /// Capitalizes the first letter of each word in the specified string.
    /// </summary>
    public static string CapitalizeWords(string text)
    {
      string[] parts = text.Split(' ');
      string result = String.Empty;
      for (int x = 0; x < parts.Length; x++)
      {
        string firstLetter = parts[x].Substring(0, 1);
        string remainingLetters = parts[x].Substring(1);
        result += firstLetter.ToUpper() + remainingLetters + " ";
      }
      return result.TrimEnd(' ');
    }
  }
}
