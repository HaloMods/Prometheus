using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using System.Xml;
using Interfaces;

namespace Games.Halo2.Compiler.Classes
{
  /// <summary>
  /// Represents a tag definition.
  /// </summary>
  public class Class
  {
    private const int Signature = 0x636c6173; // 'clas'

    private string name = null;
    private ClassHeader header = new ClassHeader();
    private List<ElementWrapper> elements = new List<ElementWrapper>();

    [StructLayout(LayoutKind.Sequential)]
    private struct ClassHeader
    {
      public int Signature;
      public int ID;
      public short ElementCount;
      public short RootElementIndex;
      public short RootBlockSize;
    }

    /// <summary>
    /// Creates a new instance of the Class class using the specified class stream as the source.
    /// </summary>
    /// <param name="name">the name of the class definition</param>
    public Class(Stream source, string name)
    {
      this.name = name;
      BinaryReader reader = new BinaryReader(source);

      header = Reinterpret.Memory<ClassHeader>(reader.ReadBytes(Marshal.SizeOf(typeof(ClassHeader))));

      if (header.Signature != Signature)
        throw new InvalidDataException("Class source stream magic identifier did not match.");

      for(int i = 0; i < header.ElementCount; i++)
        elements.Add(new ElementWrapper(Reinterpret.Memory<Element>(reader.ReadBytes(Marshal.SizeOf(typeof(Element))))));
    }

    /// <summary>
    /// Gets the name of this Class.
    /// </summary>
    public string Name
    {
      get
      { return name; }
    }

    /// <summary>
    /// Gets the identifier of this Class.
    /// </summary>
    public int ID
    {
      get
      { return header.ID; }
    }

    /// <summary>
    /// Gets an array containing all the Elements in the definition.
    /// </summary>
    public Element[] Elements
    {
      get
      {
        Element[] array = new Element[elements.Count];
        for (int i = 0; i < elements.Count; i++)
          array[i] = elements[i].Element;
        return array;
      }
    }

    /// <summary>
    /// Gets the element that acts as the root block of the Class definition.
    /// </summary>
    public short RootElementIndex
    {
      get
      { return header.RootElementIndex; }
    }

    /// <summary>
    /// Gets the size of the root block in metadata.
    /// </summary>
    public short RootBlockSize
    {
      get
      { return header.RootBlockSize; }
    }
  }
}
