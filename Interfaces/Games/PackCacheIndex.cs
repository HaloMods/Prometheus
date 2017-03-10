using System;
using System.IO;
using System.Text;

namespace Interfaces.Games
{
	public class PackCacheIndex
	{
		private PackCacheIndexPage[] pages = null;

		public PackCacheIndex()
		{
      pages = new PackCacheIndexPage[0];
		}

		public PackCacheIndex(BinaryReader reader)
		{
			pages = new PackCacheIndexPage[reader.ReadInt32()];
      for (int i = 0; i < pages.Length; i++)
        pages[i] = new PackCacheIndexPage(reader);
		}

		public void Write(BinaryWriter writer)
		{
			writer.Write(pages.Length);
			for(int i = 0; i < pages.Length; i++)
				pages[i].Write(writer);
		}

		public int GetOffset(string name, byte[] data)
		{
			for(int i = 0; i < pages.Length; i++)
				if(pages[i].Equals(name, data, false, false))
          return pages[i].DataOffset;
      /*for (int i = 0; i < pages.Length; i++)
        if (pages[i].Equals(name, data, false, true))
          return pages[i].DataOffset;
      for (int i = 0; i < pages.Length; i++)
        if (pages[i].Equals(name, data, true, true))
          return pages[i].DataOffset;*/
      throw new ObjectNotInPackCacheException(name);
		}

		public void AddEntry(string name, byte[] data, int offset)
		{
			for(int i = 0; i < pages.Length; i++)
				if(pages[i].Equals(name, data, false, false))
					return;

			PackCacheIndexPage[] morePages = new PackCacheIndexPage[pages.Length + 1];
			Array.Copy(pages, morePages, pages.Length);
			morePages[pages.Length] = new PackCacheIndexPage(name, data, offset);
			pages = morePages;
		}

		private class PackCacheIndexPage
		{
			private int nameChecksum;
			private int dataChecksum;
			private int dataLength;
			private int dataOffset;

      public PackCacheIndexPage(BinaryReader reader)
      {
        Read(reader);
      }

			public PackCacheIndexPage(string name, byte[] data, int dataOffset)
			{
				this.dataOffset = dataOffset;
				nameChecksum = XOR(name);
				dataLength = data.Length;
				dataChecksum = XOR(data);
			}

			public bool Equals(string name, byte[] data, bool ignoreLength, bool ignoreData)
			{
				if (ignoreLength || dataLength == data.Length)
					if (nameChecksum == XOR(name))
						if (ignoreData || dataChecksum == XOR(data))
							return true;
          return false;
			}

			public int DataOffset
			{
				get
				{ return dataOffset; }
			}

			public void Read(BinaryReader reader)
			{
				nameChecksum = reader.ReadInt32();
				dataChecksum = reader.ReadInt32();
				dataLength = reader.ReadInt32();
				dataOffset = reader.ReadInt32();
			}

			public void Write(BinaryWriter writer)
			{
				writer.Write(nameChecksum);
				writer.Write(dataChecksum);
				writer.Write(dataLength);
				writer.Write(dataOffset);
			}

			private static int XOR(byte[] data)
			{
				int xor = 0;
				for (int i = 0; i < (data.Length - (data.Length % 4)) / 4; i++)
					xor ^= BitConverter.ToInt32(data, i * 4);
				return xor;
			}

      private static int XOR(string text)
      {
        return XOR(Encoding.UTF8.GetBytes(text));
      }
		}
	}
}
