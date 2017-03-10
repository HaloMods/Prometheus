using System;
using System.Collections.Generic;
using System.Text;
using Interfaces.Rendering.Instancing;

namespace Interfaces.Games
{
  /// <summary>
  /// Represents a table of TypeEntry objects.
  /// </summary>
  public abstract class TypeTable
  {
    private List<TypeTableEntry> entries = new List<TypeTableEntry>();
    private Dictionary<string, List<TypeTableEntry>> highLevelGroups = new Dictionary<string, List<TypeTableEntry>>();
    
    public string[] HighLevelTypeGroups
    {
      get
      {
        string[] groups = new string[highLevelGroups.Count];
        highLevelGroups.Keys.CopyTo(groups, 0);
        return groups;
      }
    }
    
    /// <summary>
    /// Gets a list of HLT from the specified group.
    /// </summary>
    public TypeTableEntry[] GetHighLevelTypes(string group)
    {
      if (highLevelGroups.ContainsKey(group))
        return highLevelGroups[group].ToArray();
      else
        return new TypeTableEntry[0];
    }

    /// <summary>
    /// Adds an entry with the specified properties to the table, designating it as a LLT.
    /// </summary>
    protected void AddEntry(string fourCC, string fullName, Type tagType)
    {
      entries.Add(new TypeTableEntry(fourCC, fullName, tagType, TagTypeDesignation.LowLevelTag));
    }
    
    /// <summary>
    /// Adds an entry with the specified properties to the table, designating it as a HLT belonging
    /// to the specified HLT group.
    /// </summary>
    protected void AddEntry(string fourCC, string fullName, Type tagType, string group)
    {
      TypeTableEntry newEntry = new TypeTableEntry(fourCC, fullName, tagType, TagTypeDesignation.HighLevelTag);
      entries.Add(newEntry);
      if (!highLevelGroups.ContainsKey(group))
        highLevelGroups.Add(group, new List<TypeTableEntry>());
      highLevelGroups[group].Add(newEntry);
    }
   
    /// <summary>
    /// Locates a type table entry matching the specified name.
    /// </summary>
    public TypeTableEntry LocateEntryByName(string name)
    {
      foreach (TypeTableEntry entry in entries)
        if (entry.FullName == name)
          return entry;
      throw new TypeNotFoundException("A type was not found with the specified name: " + name);
    }

    /// <summary>
    /// Locates a type table entry matching the specified FourCC.
    /// </summary>
    public TypeTableEntry LocateEntryByFourCC(string fourcc)
    {
      foreach (TypeTableEntry entry in entries)
        if (entry.FourCC == fourcc)
          return entry;

      // HACK: Some tags fourcc codes are reversed for me.. (this may be remnants of the old decompiler).
      // For now, I'm just checking the type as well as it's reversed counterpart.  This will be removed.
      byte[] bin = Encoding.ASCII.GetBytes(fourcc);
      Array.Reverse(bin);
      fourcc = Encoding.ASCII.GetString(bin);
      foreach (TypeTableEntry entry in entries)
        if (entry.FourCC == fourcc)
          return entry;
      
      throw new TypeNotFoundException("A type was not found with the specified FourCC: " + fourcc);
    }

    /// <summary>
    /// Locates a type table entry matching the specified typecode.
    /// </summary>
    public TypeTableEntry LocateEntryByTypecode(int typecode)
    {
      return LocateEntryByFourCC(Encoding.ASCII.GetString(BitConverter.GetBytes(typecode)));
    }

    /// <summary>
    /// Updates a currently existing type to a new type.
    /// The new type must inherit from the existing type.
    /// </summary>
    public void UpdateType(Type newType)
    {
      for (int i = 0; i < entries.Count; i++)
      {
        if (newType.IsSubclassOf(entries[i].TagType))
        {
          // Update to the new type.
          TypeTableEntry newEntry = new TypeTableEntry(
            entries[i].FourCC, entries[i].FullName, newType, entries[i].TypeDesignation);
          entries[i] = newEntry;
          return;
        }
      }
    }

    /// <summary>
    /// Returns a type located within the TypeTable that matches or is the parent of the specified type.
    /// </summary>
    public Type GetTypeHandle(Type type)
    {
      // Check for explicit types.
      for (int i = 0; i < entries.Count; i++)
        if (type == entries[i].TagType)
          return entries[i].TagType;
      
      // Check for parent types.
      for (int i = 0; i < entries.Count; i++)
        if (type.IsSubclassOf(entries[i].TagType))
          return entries[i].TagType;
      
      throw new TypeNotFoundException("No type was found that corresponds to the supplied type: " + type);
    }
    
    /// <summary>
    /// Returns a boolean indicating if the specified type can be previewed.
    /// </summary>
    public bool Previewable(TypeTableEntry type)
    {
      Type[] interfaces = type.TagType.GetInterfaces();
      foreach (Type t in interfaces)
        if (t == typeof(IInstanceable))
          return true;
      return false;
    }

    /// <summary>
    /// Returns a boolean indicating if the tag type matching the specified name can be previewed.
    /// </summary>
    public bool Previewable(string type)
    {
      TypeTableEntry entry = LocateEntryByName(type);
      return Previewable(entry);
    }

    /// <summary>
    /// Searches to see if the specified type exists in the TypeTable.
    /// </summary>
    public bool Contains(Type type)
    {
      foreach (TypeTableEntry entry in entries)
        if (entry.TagType == type)
          return true;
      return false;
    }
  }
  
  /// <summary>
  /// Occurs when a type cannot be found in the TypeTable that matches the specified criteria.
  /// </summary>
  public class TypeNotFoundException : Exception
  {
    public TypeNotFoundException(string message) : base(message) { ; }
    public TypeNotFoundException(string message, Exception innerException) : base(message, innerException){ ; }
  }
}