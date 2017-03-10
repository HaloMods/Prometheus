using System;
using System.Collections;
using System.Text;
using System.IO;
using Games.Halo.Compiler.XPE;
using Interfaces.IO;
using Interfaces.Pool;

namespace Games.Halo.Compiler
{
  /// <summary>
  /// Contains a list of loaded tags and references to their classes, for reusage.
  /// </summary>
  public class TagLibrary
  {
    Cxpe structs;
    ArrayList tags;
    ArrayList missingTags;
    ArrayList structureBsps;
    int modelIndexOffset;
    int modelVertexOffset;
    uint[] refStringOffsets;
    EndianReader bitmaps;
    EndianReader sounds;
    MapFormat format;

    public TagLibrary(Cxpe inStructure)
    {
      tags = new ArrayList();
      missingTags = new ArrayList();
      structureBsps = new ArrayList();
      structs = inStructure;
    }

    public int GetDependencyTag(string tagName, string fourcc, ILibrary library, string alias, bool explicitBsp)
    {
      if (fourcc == "sbsp" && !explicitBsp)
      {
        for (int x = 0; x < structureBsps.Count; x++)
          if (Convert.ToString(structureBsps[x]) == tagName)
            return -1;
        structureBsps.Add(tagName);
        return -1;
      }

      for (int x = 0; x < tags.Count; x++)
      {
        TagIndexInstance cTag = tags[x] as TagIndexInstance;
        if (cTag.Name == tagName && cTag.Type == fourcc)
          return x;
      }

      string extension = structs[fourcc].Extension;

      if (!library.FileExists(tagName + '.' + extension))
      {
        foreach (string checkTag in missingTags)
          if (checkTag == tagName + '.' + extension)
            return -1;
        missingTags.Add(tagName + '.' + extension);
        return -1;
      }

      int curCount = tags.Count;
      TagIndexInstance instance = new TagIndexInstance();
      instance.ID = (uint)((curCount * 0x10001) + 0xe1740000 + 0x10000 * GetMeterCount());
      instance.Type = fourcc;
      instance.Name = alias;
      tags.Add(instance);
      instance.Tag = new Tag(tagName + '.' + extension, library, this);
      return curCount;
    }

    public int GetDependencyTag(string name, string fourcc, ILibrary library)
    {
      return GetDependencyTag(name, fourcc, library, name, false);
    }

    public int GetDependencyTag(string name, string type, string directory)
    {
      return GetDependencyTag(name, type, directory, name, false);
    }

    public int GetDependencyTag(string name, string type, string directory, string alias, bool explicitBsp)
    {
      if (type == "sbsp" && !explicitBsp)
      {
        for (int x = 0; x < structureBsps.Count; x++)
          if (Convert.ToString(structureBsps[x]) == name)
            return -1;
        structureBsps.Add(name);
        return -1;
      }

      for (int x = 0; x < tags.Count; x++)
      {
        TagIndexInstance cTag = tags[x] as TagIndexInstance;
        if (cTag.Name == name && cTag.Type == type)
          return x;
      }

      if (!File.Exists(directory + '\\' + name + '.' + structs[type].Extension))
      {
        foreach (string checkTag in missingTags)
          if (checkTag == name + '.' + structs[type].Extension)
            return -1;
        missingTags.Add(name + '.' + structs[type].Extension); //throw new IOException("Need to get the following tag: " + name + '.' + structs[oType].Extension);
        return -1;
      }

      int curCount = tags.Count;
      TagIndexInstance instance = new TagIndexInstance();
      instance.ID = (uint)((curCount * 0x10001) + 0xe1740000 + 0x10000 * GetMeterCount());
      instance.Type = type;
      instance.Name = alias;
      tags.Add(instance);
      instance.Tag = new Tag(directory + '\\' + name + '.' + structs[type].Extension, directory, this);
      return curCount;
    }

    private int GetMeterCount()
    {
      int meterCount = 0;
      for (int i = 0; i < tags.Count; i++)
        if ((tags[i] as TagIndexInstance).Type == "metr")
          meterCount++;
      return meterCount;
    }

    public Tag this[int index]
    {
      get { return (tags[index] as TagIndexInstance).Tag; }
      set { (tags[index] as TagIndexInstance).Tag = value; }
    }

    public uint GetID(int index)
    {
      return (tags[index] as TagIndexInstance).ID;
    }

    public string GetName(int index)
    {
      return (tags[index] as TagIndexInstance).Name;
    }

    public string GetClass(int index)
    {
      return (tags[index] as TagIndexInstance).Type;
    }

    public uint IDByTag(Tag tag)
    {
      for (int x = 0; x < tags.Count; x++)
        if ((tags[x] as TagIndexInstance).Tag == tag)
          return (tags[x] as TagIndexInstance).ID;
      return 0xffffffff;
    }

    public int IndexByName(string name, string type)
    {
      for (int x = 0; x < tags.Count; x++)
      {
        TagIndexInstance test = tags[x] as TagIndexInstance;
        if (test.Name == name)
          if (test.Type == type)
            return x;
      }
      return -1;
    }

    public int IndexByID(uint id)
    {
      for (int x = 0; x < tags.Count; x++)
        if ((tags[x] as TagIndexInstance).ID == id)
          return x;
      return -1;
    }

    public int Count
    {
      get { return tags.Count; }
    }

    public void AddTag(string name, string type, uint id, Tag tag)
    {
      TagIndexInstance instance = new TagIndexInstance();
      instance.ID = id;//(uint)((tags.Count * 0x10001) + 0xe1740000);
      instance.Type = type;
      instance.Name = name;
      instance.Tag = tag;
      tags.Add(instance);
    }

    public void AssertAllTagsPresent()
    {
      if (missingTags.Count == 0)
        return;
      string message = "Need to get the following tags:\n";
      for (int x = 0; x < missingTags.Count; x++)
        message += missingTags[x] as string + '\n';
      message += "These tags could not be located.";
      throw new HaloException(message);
    }

    private class TagIndexInstance
    {
      public Tag Tag;
      public string Name;
      public string Type;
      public uint ID;
    }

    public Cxpe CXPE
    {
      get { return structs; }
    }

    public string[] StructureBsps
    {
      get { return structureBsps.ToArray(typeof(string)) as string[]; }
    }

    public uint[] StringOffsets
    {
      get { return refStringOffsets; }
      set { refStringOffsets = value; }
    }

    public MapFormat MapFormat
    {
      get { return format; }
      set { format = value; }
    }

    public EndianReader Sounds
    {
      get { return sounds; }
      set { sounds = value; }
    }

    public EndianReader Bitmaps
    {
      get { return bitmaps; }
      set { bitmaps = value; }
    }

    public int ModelIndexOffset
    {
      get { return modelIndexOffset; }
      set { modelIndexOffset = value; }
    }

    public int ModelVertexOffset
    {
      get { return modelVertexOffset; }
      set { modelVertexOffset = value; }
    }

    public void Refactor(int index, string newName)
    {
      (tags[index] as TagIndexInstance).Name = newName;
    }

    public void Recommission(int index, string newType)
    {
      (tags[index] as TagIndexInstance).Type = newType;
    }
  }
}
