using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using Interfaces.IO;

namespace Games.Halo.Compiler.XPE
{
  public class Xpe
  {
    private string fourcc;
    private string parent;
    private string grandparent;
    private string extension;
    private int headerLength;
    private int version;
    private int fieldCount;
    private int fieldOffset;
    private Field[] fields;

    /*
     * int fourcc
     * int parent
     * int grandparent
     * int extension
     * int headerLength
     * int version
     * int fieldCount
     * int fieldOffset
     */

    public Xpe(EndianReader er)
    {
      fourcc = er.ReadString(4);
      parent = er.ReadString(4);
      grandparent = er.ReadString(4);
      extension = er.ReadString(er.ReadInt24());
      headerLength = er.ReadInt32();
      version = er.ReadInt32();
      fields = new Field[fieldCount = er.ReadInt32()];
      er.Position = fieldOffset = er.ReadInt32();
      for (int x = 0; x < fieldCount; x++)
        fields[x] = new Field(er);
    }

    public void Write(EndianWriter ew)
    {
      if (ew.Position + 32 > ew.Length)
        ew.BaseStream.SetLength(ew.Position + 32);
      ew.Write(fourcc, false);
      ew.Write(parent, false);
      ew.Write(grandparent, false);
      ew.Write(ew.Append(extension));
      ew.Write(headerLength);
      ew.Write(version);
      ew.Write(fieldCount = fields.Length);
      ew.Write(fieldOffset = ew.Length);
      ew.Flush();
      ew.Position = fieldOffset;
      for (int x = 0; x < fieldCount; x++)
        fields[x].Write(ew);
    }

    private void AddField(Field field)
    {
      if (field == null)
        return;
      Field[] nFields = new Field[fields.Length + 1];
      Array.Copy(fields, 0, nFields, 0, fields.Length);
      nFields[fields.Length] = field;
      fields = nFields;
    }

    public string FourCC
    {
      get { return fourcc; }
    }

    public string ParentFourCC
    {
      get { return parent; }
    }

    public string GrandparentFourCC
    {
      get { return grandparent; }
    }

    public string Extension
    {
      get { return extension; }
    }

    public short Version
    {
      get { return (short)version; }
    }

    public int HeaderLength
    {
      get { return headerLength; }
      set { headerLength = value; }
    }

    public Field[] Children
    {
      get { return fields; }
    }

    public Field FieldByName(string name)
    {
      for (int x = 0; x < fields.Length; x++)
        if (fields[x].Name == name)
          return fields[x];
      return null;
    }

    public int IndexByName(string name)
    {
      for (int x = 0; x < fields.Length; x++)
        if (fields[x].Name == name)
          return x;
      return -1;
    }

    internal static object DefaultValue(FieldType type, int size, int bCount)
    {
      Array tag = null;
      switch (type)
      {
        case FieldType.Char:
        case FieldType.CharFlags:
          return (sbyte)0;
        case FieldType.String:
          return String.Empty;
        case FieldType.Float1:
          return 0.0f;
        case FieldType.Float2:
          tag = Array.CreateInstance(typeof(float), 2);
          tag.SetValue(0.0f, 0);
          tag.SetValue(0.0f, 1);
          return tag;
        case FieldType.Float3:
          tag = Array.CreateInstance(typeof(float), 3);
          tag.SetValue(0.0f, 0);
          tag.SetValue(0.0f, 1);
          tag.SetValue(0.0f, 2);
          return tag;
        case FieldType.Float4:
          tag = Array.CreateInstance(typeof(float), 4);
          tag.SetValue(0.0f, 0);
          tag.SetValue(0.0f, 1);
          tag.SetValue(0.0f, 2);
          tag.SetValue(0.0f, 3);
          return tag;
        case FieldType.TagReference:
          return -1;
        case FieldType.DWordFlags:
        case FieldType.Int1:
          return 0;
        case FieldType.Int2:
          tag = Array.CreateInstance(typeof(int), 2);
          tag.SetValue(0, 0);
          tag.SetValue(0, 1);
          return tag;
        case FieldType.Int3:
          tag = Array.CreateInstance(typeof(int), 3);
          tag.SetValue(0, 0);
          tag.SetValue(0, 1);
          tag.SetValue(0, 2);
          return tag;
        case FieldType.Int4:
          tag = Array.CreateInstance(typeof(int), 4);
          tag.SetValue(0, 0);
          tag.SetValue(0, 1);
          tag.SetValue(0, 2);
          tag.SetValue(0, 3);
          return tag;
        case FieldType.Enum:
        case FieldType.WordFlags:
        case FieldType.Short1:
          return (short)0;
        case FieldType.Short2:
          tag = Array.CreateInstance(typeof(short), 2);
          tag.SetValue((short)0, 0);
          tag.SetValue((short)0, 1);
          return tag;
        case FieldType.Short3:
          tag = Array.CreateInstance(typeof(short), 3);
          tag.SetValue((short)0, 0);
          tag.SetValue((short)0, 1);
          tag.SetValue((short)0, 2);
          return tag;
        case FieldType.Short4:
          tag = Array.CreateInstance(typeof(short), 4);
          tag.SetValue((short)0, 0);
          tag.SetValue((short)0, 1);
          tag.SetValue((short)0, 2);
          tag.SetValue((short)0, 3);
          return tag;
        case FieldType.Block:
          return Array.CreateInstance(typeof(object), 0, bCount);
        case FieldType.Prestructure:
        case FieldType.SoundDataBlock:
        case FieldType.BitmapPixelData:
        case FieldType.ScriptData:
          return Array.CreateInstance(typeof(byte), 0);
        case FieldType.Padding:
          tag = Array.CreateInstance(typeof(byte), size);
          for (int x = 0; x < size; x++)
            tag.SetValue((byte)0, x);
          return tag;
        default:
          return null;
      }
    }

    public class Field
    {
      private string name;
      private string description;
      private string[] options;
      private int fieldOffset;
      private int optionOffset;
      private int offset;
      private int maxCount;
      private int size;
      private int nextOffset;
      private FieldType type;
      private Field[] children;

      /*
       * int name
       * int description
       * int24 offset
       * int8 type
       * int childCount
       * int childOffset
       * int optionCount
       * int optionOffset
       * int maxElements
       * int size
       * int nextSiblingOffset
       */

      public Field(EndianReader er)
      {
        int pos = er.Position;
        name = er.ReadString(er.ReadInt24());
        description = er.ReadString(er.ReadInt24());
        Int24 int24 = er.ReadInt24();
        offset = int24.Integer;
        type = (FieldType)int24.Byte;
        children = new Field[er.ReadInt32()];
        fieldOffset = er.ReadInt32();
        er.Position = fieldOffset;
        for (int x = 0; x < children.Length; x++)
          children[x] = new Field(er);
        er.Position = pos + 20;
        options = new string[er.ReadInt32()];
        optionOffset = er.ReadInt32();
        er.Position = optionOffset;
        for (int x = 0; x < options.Length; x++)
          options[x] = er.ReadString(er.ReadInt24());
        er.Position = pos + 28;
        maxCount = er.ReadInt32();
        size = er.ReadInt32();
        nextOffset = er.ReadInt32();
        er.Position = nextOffset;
      }

      private Field(int position, string inName, string inDesc, int fieldSize, FieldType inType)
      {
        offset = position;
        name = inName;
        description = inDesc;
        size = fieldSize;
        children = new Field[0];
        options = new string[0];
        type = inType;
      }

      private Field(int position, string inName, string inDesc, int fieldSize, int maxElementCount, FieldType inType)
      {
        offset = position;
        name = inName;
        description = inDesc;
        size = fieldSize;
        maxCount = maxElementCount;
        children = new Field[0];
        options = new string[0];
        type = inType;
      }

      private Field(int position, string inName, string inDesc, int fieldSize, FieldType inType, string[] items)
      {
        offset = position;
        name = inName;
        description = inDesc;
        size = fieldSize;
        children = new Field[0];
        options = items;
        type = inType;
      }

      private Field(int position, string inName, string inDesc, int maxElementCount, int fieldSize)
      {
        offset = position;
        name = inName;
        description = inDesc;
        size = fieldSize;
        maxCount = maxElementCount;
        children = new Field[0];
        options = new string[0];
        type = FieldType.Block;
      }

      public void PadEnd(int padSize)
      {
        AddField(new Field(size, "", "", padSize, FieldType.Padding));
        size += padSize;
      }

      internal void AddField(Field field)
      {
        if (field == null)
          return;
        Field[] nFields = new Field[children.Length + 1];
        Array.Copy(children, 0, nFields, 0, children.Length);
        nFields[children.Length] = field;
        children = nFields;
      }

      internal void Write(EndianWriter ew)
      {
        int pos = ew.Position;
        if (pos + 40 > ew.Length)
          ew.BaseStream.SetLength(pos + 40);
        ew.Write(ew.Append(name));
        ew.Write(ew.Append(description));
        ew.Write(new Int24(offset, (byte)type));
        ew.Write(children.Length);
        ew.Write(0);
        ew.Write(options.Length);
        ew.Write(optionOffset = ew.Length);
        ew.Position = ew.Length;
        ew.BaseStream.SetLength(ew.Length + (options.Length * 4));
        for (int x = 0; x < options.Length; x++)
          ew.Write(ew.Append(options[x]));
        ew.Position = pos + 28;
        ew.Write(maxCount);
        ew.Write(size);
        ew.Position = pos + 16;
        ew.Write(fieldOffset = ew.Length);
        ew.Position = fieldOffset;
        for (int x = 0; x < children.Length; x++)
          children[x].Write(ew);
        ew.Position = pos + 36;
        ew.Write(nextOffset = ew.Length);
        ew.Flush();
        ew.Position = nextOffset;
      }

      public Field[] Children
      {
        get { return children; }
      }

      public FieldType Type
      {
        get { return type; }
      }

      public string Name
      {
        get { return name; }
      }

      public string Description
      {
        get { return description; }
      }

      public int Offset
      {
        get { return offset; }
        set { offset = value; }
      }

      public int Size
      {
        get { return size; }
        set { size = value; }
      }

      public string[] Arguments
      {
        get { return options; }
      }

      public int MaxElementCount
      {
        get { return maxCount; }
      }

      public int this[string Name]
      {
        get
        {
          for (int x = 0; x < children.Length; x++)
            if (children[x].name == Name)
              return x;
          return -1;
        }
      }

      public Field FieldByName(string Name)
      {
        for (int x = 0; x < children.Length; x++)
          if (children[x].name == Name)
            return children[x];
        return null;
      }

      public Array AddBlock(Array array, int dupeIndex)
      {
        Array val = null;
        if (type != FieldType.Block)
          throw new InvalidOperationException("Cannot add an element to a field that is not a block.");
        if (array.GetLength(0) >= maxCount - 1)
          throw new Exception("Cannot add another element to this block; it has too many.");
        if (dupeIndex >= array.GetLength(0) || dupeIndex < -1)
          throw new ArgumentException("Cannot duplicate this element (" + dupeIndex.ToString() + "); it does not exist.", "dupeIndex");
        if (array.GetLength(1) != children.Length)
          throw new ArgumentException("The given array is not suitable for the current field.");

        val = Array.CreateInstance(typeof(object), array.GetLength(0) + 1, children.Length);
        for (int x = 0; x < array.GetLength(0); x++)
          for (int y = 0; y < array.GetLength(1); y++)
            val.SetValue(array.GetValue(x, y), x, y);

        if (dupeIndex == -1)
        {
          for (int x = 0; x < children.Length; x++)
            val.SetValue(DefaultValue(children[x].type, children[x].size, children[x].children.Length), array.GetLength(0), x);
        }
        else
        {
          for (int x = 0; x < array.GetLength(1); x++)
            val.SetValue(array.GetValue(dupeIndex, x), array.GetLength(0), x);
        }

        return val;
      }

      public Array DeleteBlock(Array array, int index)
      {
        Array val = null;
        if (type != FieldType.Block)
          throw new InvalidOperationException("Cannot delete an element from a field that is not a block.");
        if (array.GetLength(0) <= 0)
          throw new Exception("Cannot delete an element from this block; it has none.");
        if (index >= array.GetLength(0) || index < 0)
          throw new ArgumentException("Cannot delete this element (" + index.ToString() + "); it does not exist.", "index");
        if (array.GetLength(1) != children.Length)
          throw new ArgumentException("The given array is not suitable for the current field.");

        val = Array.CreateInstance(typeof(object), array.GetLength(0) - 1, children.Length);

        for (int x = 0; x < index; x++)
          for (int y = 0; y < array.GetLength(1); y++)
            val.SetValue(array.GetValue(x, y), x, y);
        for (int x = index + 1; x < val.GetLength(0); x++)
          for (int y = 0; y < array.GetLength(1); y++)
            val.SetValue(array.GetValue(x, y), x, y);

        return val;
      }
    }

    public enum FieldType : sbyte
    {
      Float1 = 0,
      Float2 = 1,
      Float3 = 2,
      Float4 = 3,
      Int1 = 4,
      Int2 = 5,
      Int3 = 6,
      Int4 = 7,
      String = 8,
      Char = 9,
      TagReference = 10,
      Block = 11,
      BspVertexDataHeader = 12,
      ModelIndexBlock = 13,
      ModelVertexBlock = 14,
      BitmapDataBlock = 15,
      SoundDataBlock = 16,
      Enum = 17,
      CharFlags = 18,
      WordFlags = 19,
      DWordFlags = 20,
      Explanation = 21,
      Prestructure = 22, // count, zeros, unknown, offset, zeros
      Short1 = 23,
      Short2 = 24,
      Short3 = 25,
      Short4 = 26,
      SelfReference = 27,
      BspUncompressedVertexBlock = 28,
      BspCompressedVertexBlock = 29,
      ScriptData = 30,
      BitmapPixelData = 31,
      Padding = -1
    }
  }
}
