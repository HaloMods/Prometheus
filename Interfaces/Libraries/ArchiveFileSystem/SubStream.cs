using System;
using System.IO;

namespace Core.Libraries.ArchiveFileSystem
{
  public class SubStream : Stream
  {
    private Stream baseStream;
    private long length;
    private long startOffset;
    private long lastPosition;
    
    public SubStream(Stream baseStream, long startOffset, long length)
    {
      this.baseStream = baseStream;
      this.startOffset = startOffset;
      this.length = length;
    }
    
    public override void Flush()
    {
      baseStream.Flush();
    }

    public override long Seek(long offset, SeekOrigin origin)
    {
      if (origin == SeekOrigin.Begin) return Seek(offset);
      else if (origin == SeekOrigin.Current) return Seek(offset + Position);
      else return Seek(Length - offset);
    }

    protected long Seek(long offset)
    {
      if (startOffset + offset > length)
        throw new Exception("Cannot seek past the end of the stream.");
      if (offset < 0)
        throw new Exception("Cannot seek to an offset before the beginning of the stream.");
      
      Position = offset;
      return Position;
    }
    
    public override void SetLength(long value)
    {
      long newLength = startOffset + length;
      if (newLength > baseStream.Length) baseStream.SetLength(newLength);
    }

    public override int Read(byte[] buffer, int offset, int count)
    {
      long totalBytes = (Position + count > Length) ? (length - Position) : count;
      if (lastPosition != Position) Seek(lastPosition);
      int bytesRead = baseStream.Read(buffer, offset, (int)totalBytes);
      lastPosition += bytesRead;
      return bytesRead;
    }

    public override void Write(byte[] buffer, int offset, int count)
    {
      if (Position + count > length)
        throw new ArgumentException("Cannot write past the end of the stream.");
      if (lastPosition != Position) Seek(lastPosition);
      baseStream.Write(buffer, offset, count);
      lastPosition += count;
    }

    public override bool CanRead
    {
      get { return baseStream.CanRead; }
    }

    public override bool CanSeek
    {
      get { return baseStream.CanSeek; }
    }

    public override bool CanWrite
    {
      get { return baseStream.CanWrite; }
    }

    public override long Length
    {
      get { return length; }
    }

    public override long Position
    {
      get { return baseStream.Position - startOffset; }
      set
      {
        baseStream.Position = startOffset + value;
        lastPosition = value;
      }
    }
  }
}
