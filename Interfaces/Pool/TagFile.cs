using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Text;
using Interfaces.Notes;

namespace Interfaces.Pool
{
  /// <summary>
  /// Represents a tag and its revisions wrapped as a file.
  /// </summary>
  public class TagFile
  {
    protected int signature = PromSignature;
    protected short headerSize = PromHeaderSize;
    protected short reserved_a = 0;
    protected short tagRevision = TagVersion;
    protected short revisionRevision = RevisionVersion;
    protected byte[] game = null; // 
    protected string tagType = "ÿÿÿÿ";
    protected string parentType = "ÿÿÿÿ";
    protected string grandparentType = "ÿÿÿÿ";
    protected int headRevision = 0; // 
    protected int revisionCount = 0;
    protected int revisionOffset = PromHeaderSize;
    protected int noteCount = 0;
    protected int noteOffset = 0; // 
    protected int attachmentCount = 0;
    protected int attachmentOffset = 0;
    protected int reserved_f = 0;
    protected int reserved_g = 0; // end of header

    protected List<string> authors = new List<string>();
    protected List<string> informations = new List<string>();
    protected List<byte[]> binaryBlobs = new List<byte[]>();
    protected List<ObjectRevision> revisions = new List<ObjectRevision>();
    protected List<Note> notes = new List<Note>();
    protected List<Attachment> attachments = new List<Attachment>();

    protected const short TagVersion = 4;
    protected const short RevisionVersion = 1;
    protected const short BlamHeaderSize = 64;
    protected const short PromHeaderSize = 64;
    protected const int BlamSignature = 0x6d616c62; // 'blam' in big endian
    protected const int PromSignature = 0x4d4f5250; // 'PROM' in little endian

    /// <summary>
    /// Gets a list of all attachments.
    /// </summary>
    public string[] Attachments
    {
      get
      {
        List<string> attachments = new List<string>();
        for (int x = 0; x < this.attachments.Count; x++)
          if (this.attachments[x].Name.Length > 0)
            attachments.Add(this.attachments[x].Name);
        return attachments.ToArray();
      }
    }

    /// <summary>
    /// Creates a new TagFile wrapping the provided metadata.
    /// </summary>
    /// <param name="dataStream">metadata stream to wrap</param>
    public TagFile(byte[] dataStream, string author, string information, string tagType, string parentType, string grandparentType, byte[] gameID)
    {
      this.tagType = tagType;
      this.parentType = parentType;
      this.grandparentType = grandparentType;
      game = gameID;
      headRevision = 0;

      binaryBlobs = new List<byte[]>();
      binaryBlobs.Add(dataStream);

      authors = new List<string>();
      authors.Add(author);

      informations = new List<string>();
      informations.Add(information);

      revisions = new List<ObjectRevision>();
      ObjectRevision revision = new ObjectRevision();
      revision.AuthorLength = (short)authors[headRevision].Length;
      revision.InfoLength = (short)informations[headRevision].Length;
      revision.DataLength = dataStream.Length;
      revision.CompressionStyle = CompressionStyle.GZip;
      revision.Date = DateTime.Now;
      revision.Version = 1.0f;
      revisions.Add(revision);
    }

    /// <summary>
    /// Creates a new instance of the TagFile class from a stream.
    /// </summary>
    /// <param name="stream">input stream</param>
    public TagFile(Stream stream)
    {
      Read(stream);
    }

    /// <summary>
    /// Reads from a stream.
    /// </summary>
    public void Read(Stream stream)
    {
      byte[] buffer = new byte[PromHeaderSize];
      stream.Read(buffer, 0, PromHeaderSize);

      if (BitConverter.ToInt32(buffer, 0x0) == PromSignature)
        signature = PromSignature;
      else
        throw new Exception("File is not a valid Prometheus tag.");

      headerSize = BitConverter.ToInt16(buffer, 0x4);
      if (headerSize != PromHeaderSize)
      {
        stream.Position -= PromHeaderSize;
        buffer = new byte[headerSize];
        stream.Read(buffer, 0, headerSize);
      }

      reserved_a = BitConverter.ToInt16(buffer, 0x6);
      tagRevision = BitConverter.ToInt16(buffer, 0x8);
      revisionRevision = BitConverter.ToInt16(buffer, 0xa);
      Array.Copy(buffer, 0xc, game = new byte[4], 0, 4);

      tagType = ExtractString(buffer, 0x10, 4);
      parentType = ExtractString(buffer, 0x14, 4);
      grandparentType = ExtractString(buffer, 0x18, 4);
      headRevision = BitConverter.ToInt32(buffer, 0x1c);

      revisionCount = BitConverter.ToInt32(buffer, 0x20);
      revisionOffset = BitConverter.ToInt32(buffer, 0x24);
      noteCount = BitConverter.ToInt32(buffer, 0x28);
      noteOffset = BitConverter.ToInt32(buffer, 0x2c);

      attachmentCount = BitConverter.ToInt32(buffer, 0x30);
      attachmentOffset = BitConverter.ToInt32(buffer, 0x34);
      reserved_f = BitConverter.ToInt32(buffer, 0x38);
      reserved_g = BitConverter.ToInt32(buffer, 0x3c);

      // the header is done, lets load up the revisions
      stream.Position = revisionOffset;
      revisions = new List<ObjectRevision>(revisionCount);
      binaryBlobs = new List<byte[]>(revisionCount);
      authors = new List<string>(revisionCount);
      informations = new List<string>(revisionCount);

      for (int i = 0; i < revisionCount; i++)
      {
        revisions.Add(new ObjectRevision());
        revisions[i].Read(stream);
      }

      BinaryReader br = new BinaryReader(stream, Encoding.ASCII);
      for (int i = 0; i < revisionCount; i++)
      {
        stream.Position = revisions[i].AuthorOffset;
        authors.Add(new string(br.ReadChars(revisions[i].AuthorLength)));

        stream.Position = revisions[i].InfoOffset;
        informations.Add(new string(br.ReadChars(revisions[i].InfoLength)));

        stream.Position = revisions[i].DataOffset;
        if (revisions[i].CompressionStyle == CompressionStyle.Store)
          binaryBlobs.Add(br.ReadBytes(revisions[i].DataLength));
        else if (revisions[i].CompressionStyle == CompressionStyle.GZip)
        {
          GZipStream gz = new GZipStream(stream, CompressionMode.Decompress, true);
          binaryBlobs.Add(new byte[revisions[i].DataLength]);
          gz.Read(binaryBlobs[i], 0, revisions[i].DataLength);
          gz.Close();
        }
        else
          throw new Exception(revisions[i].CompressionStyle + " is not valid for a tag file.");
      }

      notes = new List<Note>(noteCount);
      stream.Position = noteOffset;
      for (int i = 0; i < noteCount; i++)
        notes.Add(new Note(stream));

      attachments = new List<Attachment>(attachmentCount);
      stream.Position = attachmentOffset;
      for (int i = 0; i < attachmentCount; i++)
      {
        attachments.Add(new Attachment());
        attachments[i].Read(stream);
      }

      br.Close();
    }

    /// <summary>
    /// Writes to a stream.
    /// </summary>
    public void Write(Stream stream)
    {
      int position = PromHeaderSize + ObjectRevision.RevisionSize * revisions.Count;
      byte[] header = new byte[PromHeaderSize];

      revisionCount = revisions.Count;
      revisionOffset = PromHeaderSize;
      noteCount = notes.Count;

      Insert(PromSignature, header, 0x0);
      Insert(PromHeaderSize, header, 0x4);
      Insert(reserved_a, header, 0x6);
      Insert(TagVersion, header, 0x8);
      Insert(RevisionVersion, header, 0xa);
      Array.Copy(game, 0, header, 0xc, 4);
      InsertString(tagType, header, 0x10);
      InsertString(parentType, header, 0x14);
      InsertString(grandparentType, header, 0x18);
      Insert(headRevision, header, 0x1c);
      Insert(revisionCount, header, 0x20);
      Insert(revisionOffset, header, 0x24);
      Insert(noteCount, header, 0x28);
      Insert(attachmentCount, header, 0x30);
      Insert(reserved_f, header, 0x38);
      Insert(reserved_g, header, 0x3c);

      stream.SetLength(PromHeaderSize);

      // HACK: Just for testing purposes, we're only saving the head revision.
      //revisionCount = 1;
      for (int i = 0; i < revisionCount; i++)
      {
        stream.Position = revisions[i].AuthorOffset = position;
        WriteString(authors[i], stream);
        position += revisions[i].AuthorLength + 1;

        stream.Position = revisions[i].InfoOffset = position;
        WriteString(informations[i], stream);
        position += revisions[i].InfoLength + 1;

        stream.Position = revisions[i].DataOffset = position;
        if (revisions[i].CompressionStyle == CompressionStyle.Store)
        {
          stream.Write(binaryBlobs[i], 0, revisions[i].DataLength);
          position += revisions[i].DataLength + 1;
        }
        else if (revisions[i].CompressionStyle == CompressionStyle.GZip)
        {
          long previous = stream.Position;
          GZipStream gz = new GZipStream(stream, CompressionMode.Compress, true);
          gz.Write(binaryBlobs[i], 0, revisions[i].DataLength);
          gz.Close();
          position += (int)(stream.Position - previous);
        }
        else
          throw new Exception(revisions[i].CompressionStyle + " is not valid for a tag file.");

        stream.Position = PromHeaderSize + ObjectRevision.RevisionSize * i;
        revisions[i].Write(stream);
      }

      Insert(noteOffset = (int)stream.Length, header, 0x2c);
      stream.Position = noteOffset;
      stream.SetLength(stream.Length + noteCount * Note.NoteSize);
      for (int j = 0; j < noteCount; j++)
        notes[j].Write(stream);

      Insert(attachmentOffset = (int)stream.Length, header, 0x34);
      stream.Position = stream.Length;
      stream.SetLength(stream.Length + Attachment.AttachmentSize * attachmentCount);
      for (int j = 0; j < attachmentCount; j++)
        attachments[j].Write(stream);

      stream.Position = 0;
      stream.Write(header, 0, PromHeaderSize);
    }

    /// <summary>
    /// Returns this instance as an array of bytes, ready to be written to a library.
    /// </summary>
    public byte[] ToBytes()
    {
      MemoryStream stream = new MemoryStream();
      Write(stream);
      return stream.ToArray();
    }

    /// <summary>
    /// Gets the number of revisions owned by this tag.
    /// </summary>
    public int RevisionCount
    {
      get
      { return revisionCount; }
    }

    /// <summary>
    /// Gets the current head revision index.
    /// </summary>
    public int HeadRevision
    {
      get
      { return headRevision; }
    }

    /// <summary>
    /// Gets the description associated with the specified revision.
    /// </summary>
    public string GetInformation(int revision)
    { return informations[revision]; }

    /// <summary>
    /// Gets the author associated with the specified revision.
    /// </summary>
    public string GetAuthor(int revision)
    { return authors[revision]; }

    /// <summary>
    /// Gets the binary metadata associated with the specified revision.
    /// </summary>
    public byte[] GetBinary(int revision)
    {
      if (revisions[revision].DataLength == 0)
        throw new Exception("Cannot get the binary metadata for a deleted revision.");
      return binaryBlobs[revision];
    }

    /// <summary>
    /// Saves a new binary blob over the head revision.
    /// </summary>
    public void SetHeadBinary(byte[] binary)
    {
      binaryBlobs[headRevision] = binary;
      revisions[headRevision].DataLength = binary.Length;
    }

    /// <summary>
    /// Gets a floating point version for a given revision.
    /// </summary>
    public float GetVersion(int revision)
    { return revisions[revision].Version; }

    /// <summary>
    /// Adds a new revision to the collection of revisions in this tag.
    /// </summary>
    /// <param name="author">author of the revision</param>
    /// <param name="description">information about what is changed or added or removed</param>
    /// <param name="binary">the new binary blob</param>
    /// <param name="compStyle">compression mode to use</param>
    /// <param name="version">a numeric floating-point version to associate with this revision</param>
    public virtual void AddRevision(string author, string description, byte[] binary, CompressionStyle compStyle, float version)
    {
      int r = revisions.Count;
      revisions.Add(new ObjectRevision());

      revisions[r].Date = DateTime.Now;
      revisions[r].Version = version;
      revisions[r].CompressionStyle = compStyle;

      authors.Add(author);
      revisions[r].AuthorLength = (short)author.Length;
      informations.Add(description);
      revisions[r].InfoLength = (short)description.Length;
      binaryBlobs.Add(binary);
      revisions[r].DataLength = binary.Length;

      headRevision = r;
    }

    /// <summary>
    /// Deletes the binary blob for the specified revision.
    /// </summary>
    /// <param name="revision">revision to 'delete'</param>
    public virtual void DeleteRevision(int revision)
    {
      revisions[revision].DataLength = 0;
      binaryBlobs[revision] = new byte[0];
    }

    public virtual void AddAttachment(string name)
    {
      foreach (Attachment attachment in attachments)
        if (attachment.Name == name)
          throw new ArgumentException("An attachment with this name already exists.", "name");

      Attachment newAttachment = new Attachment();
      newAttachment.Name = name;
      attachments.Add(newAttachment);
      attachmentCount++;
    }

    public virtual void AddAttachmentRevision(string attachmentName, byte[] data, float version, CompressionStyle compression)
    {
      foreach (Attachment attachment in attachments)
      {
        if (attachment.Name == attachmentName)
        {
          attachment.AddRevision(compression, data, version);
          break;
        }
      }
    }

    /// <summary>
    /// Gets the head revision of the specified attachment.
    /// </summary>
    public virtual byte[] GetAttachmentRevision(string attachmentName)
    {
      foreach (Attachment attachment in attachments)
        if (attachment.Name == attachmentName)
          return attachment.GetData(attachment.HeadRevision);
      throw new ArgumentException("Attachment not found.", "attachmentName");
    }

    /// <summary>
    /// Gets the specified revision of the specified attachment.
    /// </summary>
    public virtual byte[] GetAttachmentRevision(string attachmentName, int revision)
    {
      foreach (Attachment attachment in attachments)
        if (attachment.Name == attachmentName)
          return attachment.GetData(revision);
      throw new ArgumentException("Attachment not found.", "attachmentName");
    }

    /// <summary>
    /// Gets the specified version of the specified attachment.
    /// </summary>
    public virtual byte[] GetAttachmentRevision(string attachmentName, float version)
    {
      foreach (Attachment attachment in attachments)
        if (attachment.Name == attachmentName)
          return attachment.GetData(version);
      throw new ArgumentException("Attachment not found.", "attachmentName");
    }

    /// <summary>
    /// Deletes the specified revision of the specified attachment.
    /// </summary>
    public virtual void DeleteAttachmentRevision(string attachmentName, int revision)
    {
      foreach (Attachment attachment in attachments)
        if (attachment.Name == attachmentName)
          attachment.DeleteRevision(revision);
      throw new ArgumentException("Attachment not found.", "attachmentName");
    }

    /// <summary>
    /// Gets the four character code associated with this tag's game.
    /// </summary>
    public byte[] GameID
    {
      get
      { return game; }
    }

    /// <summary>
    /// Gets the four character tag type of this tag file.
    /// </summary>
    public string Type
    {
      get
      { return tagType; }
    }

    /// <summary>
    /// Manages multiple revisions of an object.
    /// </summary>
    protected class Attachment
    {
      public const int AttachmentSize = 32 + NameSize;
      public const int NameSize = 64;

      protected int headRevision = 0; // 
      protected int revisionCount = 0;
      protected int revisionOffset = AttachmentSize;
      protected int reserved_a = 0;
      protected int reserved_b = 0; //
      protected int reserved_c = 0;
      protected int reserved_d = 0;
      protected int reserved_e = 0;
      protected byte[] name = new byte[NameSize];

      protected List<byte[]> datas = new List<byte[]>();
      protected List<ObjectRevision> revisions = new List<ObjectRevision>();

      public virtual void Read(Stream stream)
      {
        byte[] buffer = new byte[AttachmentSize];
        stream.Read(buffer, 0, AttachmentSize);

        headRevision = BitConverter.ToInt32(buffer, 0);
        revisionCount = BitConverter.ToInt32(buffer, 4);
        revisionOffset = BitConverter.ToInt32(buffer, 8);
        reserved_a = BitConverter.ToInt32(buffer, 12);
        reserved_b = BitConverter.ToInt32(buffer, 16);
        reserved_c = BitConverter.ToInt32(buffer, 20);
        reserved_d = BitConverter.ToInt32(buffer, 24);
        reserved_e = BitConverter.ToInt32(buffer, 28);
        name = new byte[NameSize];
        for (int i = 0; i < NameSize; i++)
          name[i] = buffer[i + 32];

        long position = stream.Position;

        stream.Position = revisionOffset;
        for (int i = 0; i < revisionCount; i++)
        {
          ObjectRevision revision = new ObjectRevision();
          revision.Read(stream);
          revisions.Add(revision);
        }
        for (int i = 0; i < revisionCount; i++)
        {
          stream.Position = revisions[i].DataOffset;
          byte[] data = new byte[revisions[i].DataLength];
          stream.Read(data, 0, revisions[i].DataLength);
          datas.Add(data);
        }

        stream.Position = position;
      }

      public virtual void Write(Stream stream)
      {
        byte[] buffer = new byte[AttachmentSize];

        Insert(headRevision, buffer, 0);
        Insert(revisionCount, buffer, 4);
        Insert(reserved_a, buffer, 12);
        Insert(reserved_b, buffer, 16);
        Insert(reserved_c, buffer, 20);
        Insert(reserved_d, buffer, 24);
        Insert(reserved_e, buffer, 28);
        for (int i = 0; i < NameSize; i++)
          buffer[i + 32] = name[i];

        long position = stream.Position + AttachmentSize;

        long indexPosition = stream.Length;
        Insert(revisionOffset = (int)indexPosition, buffer, 8);
        stream.Write(buffer, 0, AttachmentSize);

        stream.SetLength(stream.Length + ObjectRevision.RevisionSize * revisionCount);
        for (int i = 0; i < revisionCount; i++)
        {
          stream.Position = indexPosition + ObjectRevision.RevisionSize * i;
          stream.SetLength(stream.Length + datas[i].Length);
          revisions[i].DataOffset = (int)stream.Length;
          revisions[i].Write(stream);
          stream.Position = stream.Length;
          stream.Write(datas[i], 0, datas[i].Length);
        }

        stream.Position = position;
      }

      /// <summary>
      /// Adds a new revision to this attachment.
      /// </summary>
      public virtual void AddRevision(CompressionStyle compression, byte[] data, float version)
      {
        int r = revisions.Count;
        revisions.Add(new ObjectRevision());

        revisions[r].Date = DateTime.Now;
        revisions[r].Version = version;
        revisions[r].CompressionStyle = compression;

        if (compression == CompressionStyle.Store)
          datas.Add(data);
        else if (compression == CompressionStyle.GZip)
        {
          MemoryStream compressionStream = new MemoryStream();
          GZipStream gz = new GZipStream(compressionStream, CompressionMode.Compress, true);
          gz.Write(data, 0, data.Length);
          gz.Close();
          datas.Add(compressionStream.ToArray());
          compressionStream.Close();
        }
        else
          throw new Exception(compression + " is not valid for a tag attachment.");

        revisions[r].DataLength = data.Length;

        headRevision = r;
        revisionCount = r + 1;
      }

      /// <summary>
      /// Deletes the data for the specified revision.
      /// </summary>
      /// <param name="revision">revision to 'delete'</param>
      public virtual void DeleteRevision(int revision)
      {
        revisions[revision].DataLength = 0;
        datas[revision] = new byte[0];
      }

      /// <summary>
      /// Returns the data for the given revision.
      /// </summary>
      public virtual byte[] GetData(int revision)
      {
        switch (revisions[revision].CompressionStyle)
        {
          case CompressionStyle.Store:
            return datas[revision];
          case CompressionStyle.GZip:
            byte[] gZipBuffer = new byte[revisions[revision].DataLength];
            GZipStream gZipStream = new GZipStream(new MemoryStream(datas[revision], false), CompressionMode.Decompress, false);
            gZipStream.Read(gZipBuffer, 0, revisions[revision].DataLength);
            gZipStream.Close();
            return gZipBuffer;
          default:
            throw new InvalidOperationException("The compression mode for this revision is invalid.");
        }
      }

      /// <summary>
      /// Returns the data for the given version.
      /// </summary>
      public virtual byte[] GetData(float version)
      {
        int revision = 0;
        bool found = false;
        for (; revision < revisions.Count; revision++)
        {
          if (revisions[revision].Version == version)
          {
            found = true;
            break;
          }
        }

        if (!found)
          throw new ArgumentException("The specified version was not found.", "version");

        switch (revisions[revision].CompressionStyle)
        {
          case CompressionStyle.Store:
            return datas[revision];
          case CompressionStyle.GZip:
            byte[] gZipBuffer = new byte[revisions[revision].DataLength];
            GZipStream gZipStream = new GZipStream(new MemoryStream(datas[revision], false), CompressionMode.Decompress, false);
            gZipStream.Read(gZipBuffer, 0, revisions[revision].DataLength);
            gZipStream.Close();
            return gZipBuffer;
          default:
            throw new InvalidOperationException("The compression mode for this revision is invalid.");
        }
      }

      /// <summary>
      /// Gets the number of revisions owned by this tag.
      /// </summary>
      public int RevisionCount
      {
        get
        { return revisionCount; }
      }

      /// <summary>
      /// Gets the current head revision index.
      /// </summary>
      public int HeadRevision
      {
        get
        { return headRevision; }
      }

      /// <summary>
      /// Gets or sets the offset of revisions in this attachment.
      /// </summary>
      public int RevisionOffset
      {
        get
        { return revisionOffset; }
        set
        { revisionOffset = value; }
      }

      /// <summary>
      /// Gets or sets the name of this attachment.
      /// </summary>
      public string Name
      {
        get
        { return Encoding.ASCII.GetString(name).TrimEnd('\0'); }
        set
        {
          byte[] stringData = Encoding.ASCII.GetBytes(value);
          int i = 0;
          for (; i < stringData.Length; i++)
            name[i] = stringData[i];
          for (; i < NameSize; i++)
            name[i] = 0;
        }
      }
    }

    /// <summary>
    /// Represents the binary object revision structure.
    /// </summary>
    protected class ObjectRevision
    {
      private short revisionSize = RevisionSize;
      private CompressionStyle compression = CompressionStyle.Store;
      private float version = 0.0f;
      private long date = 0; // 
      private int reserved_a = 0;
      private int reserved_b = 0;
      private int reserved_c = 0;
      private short authorLength = 0;
      private short infoLength = 0; // 
      private int authorOffset = 0;
      private int infoOffset = 0;
      private int dataLength = 0;
      private int dataOffset = 0; // end of revision

      public const short RevisionSize = 48;

      /// <summary>
      /// Reads from a stream.
      /// </summary>
      public void Read(Stream stream)
      {
        byte[] buffer = new byte[RevisionSize];
        stream.Read(buffer, 0, RevisionSize);

        revisionSize = BitConverter.ToInt16(buffer, 0x0);
        if (revisionSize != RevisionSize)
        {
          stream.Position -= RevisionSize;
          buffer = new byte[revisionSize];
          stream.Read(buffer, 0, revisionSize);
        }

        compression = (CompressionStyle)BitConverter.ToInt16(buffer, 0x2);
        version = BitConverter.ToSingle(buffer, 0x4);
        date = BitConverter.ToInt64(buffer, 0x8);
        reserved_a = BitConverter.ToInt32(buffer, 0x10);
        reserved_b = BitConverter.ToInt32(buffer, 0x14);
        reserved_c = BitConverter.ToInt32(buffer, 0x18);
        authorLength = BitConverter.ToInt16(buffer, 0x1c);
        infoLength = BitConverter.ToInt16(buffer, 0x1e);
        authorOffset = BitConverter.ToInt32(buffer, 0x20);
        infoOffset = BitConverter.ToInt32(buffer, 0x24);
        dataLength = BitConverter.ToInt32(buffer, 0x28);
        dataOffset = BitConverter.ToInt32(buffer, 0x2c);
      }

      /// <summary>
      /// Writes to a stream.
      /// </summary>
      public void Write(Stream stream)
      {
        byte[] buffer = new byte[RevisionSize];

        Insert(RevisionSize, buffer, 0x0);
        Insert((short)compression, buffer, 0x2);
        Insert(version, buffer, 0x4);
        Insert(date, buffer, 0x8);
        Insert(reserved_a, buffer, 0x10);
        Insert(reserved_b, buffer, 0x14);
        Insert(reserved_c, buffer, 0x18);
        Insert(authorLength, buffer, 0x1c);
        Insert(infoLength, buffer, 0x1e);
        Insert(authorOffset, buffer, 0x20);
        Insert(infoOffset, buffer, 0x24);
        Insert(dataLength, buffer, 0x28);
        Insert(dataOffset, buffer, 0x2c);

        stream.Write(buffer, 0, RevisionSize);
      }

      /// <summary>
      /// Gets or sets the compression style used by this revision.
      /// </summary>
      public CompressionStyle CompressionStyle
      {
        get
        { return compression; }
        set
        { compression = value; }
      }

      /// <summary>
      /// Gets or sets a floating-point version associated with this revision.
      /// </summary>
      public float Version
      {
        get
        { return version; }
        set
        { version = value; }
      }

      /// <summary>
      /// Gets or sets the revision date of this revision.
      /// </summary>
      public DateTime Date
      {
        get
        { return DateTime.FromBinary(date); }
        set
        { date = value.ToBinary(); }
      }

      public short AuthorLength
      {
        get
        { return authorLength; }
        set
        { authorLength = value; }
      }

      /// <summary>
      /// Gets or sets the length of information associated with this revision.
      /// </summary>
      public short InfoLength
      {
        get
        { return infoLength; }
        set
        { infoLength = value; }
      }

      /// <summary>
      /// Gets or sets the length of information associated with this revision.
      /// </summary>
      public int AuthorOffset
      {
        get
        { return authorOffset; }
        set
        { authorOffset = value; }
      }

      /// <summary>
      /// Gets or sets the length of information associated with this revision.
      /// </summary>
      public int InfoOffset
      {
        get
        { return infoOffset; }
        set
        { infoOffset = value; }
      }

      /// <summary>
      /// Gets or sets the length of metadata associated with this revision.
      /// </summary>
      public int DataLength
      {
        get
        { return dataLength; }
        set
        { dataLength = value; }
      }

      /// <summary>
      /// Gets or sets the offset of metadata associated with this revision.
      /// </summary>
      public int DataOffset
      {
        get
        { return dataOffset; }
        set
        { dataOffset = value; }
      }
    }

    protected static void Insert(int value, byte[] buffer, int offset)
    { Array.Copy(BitConverter.GetBytes(value), 0, buffer, offset, sizeof(int)); }

    protected static void Insert(short value, byte[] buffer, int offset)
    { Array.Copy(BitConverter.GetBytes(value), 0, buffer, offset, sizeof(short)); }

    protected static void Insert(long value, byte[] buffer, int offset)
    { Array.Copy(BitConverter.GetBytes(value), 0, buffer, offset, sizeof(long)); }

    protected static void Insert(float value, byte[] buffer, int offset)
    { Array.Copy(BitConverter.GetBytes(value), 0, buffer, offset, sizeof(float)); }

    protected static string ExtractString(byte[] buffer, int offset, int length)
    {
      char[] chars = new char[length];
      for (int i = 0; i < length; i++)
        chars[i] = Convert.ToChar(buffer[offset + i]);
      return new string(chars);
    }

    protected static void InsertString(string value, byte[] buffer, int offset)
    {
      for (int i = 0; i < value.Length; i++)
        buffer[offset + i] = Convert.ToByte(value[i]);
    }

    protected static void WriteString(string value, Stream stream)
    {
      byte[] buffer = new byte[value.Length + 1];
      for (int i = 0; i < value.Length; i++)
        buffer[i] = Convert.ToByte(value[i]);
      buffer[value.Length] = 0;
      stream.Write(buffer, 0, buffer.Length);
    }
  }
}
