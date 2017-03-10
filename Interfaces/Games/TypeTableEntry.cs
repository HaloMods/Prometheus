using System;

namespace Interfaces.Games
{
  /// <summary>
  /// Represents a tag's type, it's name, and fourCC.
  /// </summary>
  public class TypeTableEntry
  {
    private string fourCC;
    private string fullName;
    private Type tagType;
    private TagTypeDesignation typeDesignation = TagTypeDesignation.LowLevelTag;

    /// <summary>
    /// The FourCC code that represents the tag type.
    /// </summary>
    public string FourCC
    {
      get { return fourCC; }
    }

    /// <summary>
    /// The full name of the tag type.
    /// </summary>
    public string FullName
    {
      get { return fullName; }
    }

    /// <summary>
    /// The Type object that represents the tag.
    /// </summary>    
    public Type TagType
    {
      get { return tagType; }
    }

    /// <summary>
    /// Returns a value indicating whether this type is designated as a HLT or a LLT.
    /// </summary>
    public TagTypeDesignation TypeDesignation
    {
      get { return typeDesignation; }
    }

    /// <summary>
    /// Creates an TypeEntry struct with the specified values.
    /// </summary>
    public TypeTableEntry(string fourCC, string fullName, Type tagType, TagTypeDesignation typeDesignation)
    {
      this.fourCC = fourCC;
      this.fullName = fullName;
      this.tagType = tagType;
      this.typeDesignation = typeDesignation;
    }
  }
  
  /// <summary>
  /// Represents a tag's type designation - either HLT, or LLT.
  /// </summary>
  public enum TagTypeDesignation
  {
    HighLevelTag,
    LowLevelTag
  }
}
