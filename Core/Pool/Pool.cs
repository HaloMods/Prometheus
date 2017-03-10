using System;
using System.IO;
using System.Collections.Generic;
using Interfaces;
using Interfaces.Pool;
using Interfaces.Games;
using Core.Project;
using System.Text;

namespace Core.Pool
{
  /// <summary>
  /// Acts as a tag manager. Runs an internal content management tree capable of more than you think. This class cannot be inherited.
  /// </summary>
  public sealed class Pool : IPool, IDisposable
  {
    private int idCurrent = 0;
    private TagList<Tag> tags = new TagList<Tag>();
    private string format = null;
    private ILibrary library = null;
    private Dictionary<string, ILibrary> archives = new Dictionary<string, ILibrary>(); // string: format
    private Dictionary<string, ILibrary> prefabs = new Dictionary<string, ILibrary>(); // string: name
    private Dictionary<string, ILibrary> shareds = new Dictionary<string, ILibrary>(); // string: name
    private Dictionary<string, TypeTable> tables = new Dictionary<string, TypeTable>(); // string: format
    private Dictionary<string, Tag> globals = new Dictionary<string, Tag>(); // string: format

    /// <summary>
    /// A method used to open a tag and return a handle to the tag.
    /// </summary>
    /// <typeparam name="T">type of the tag to be opened</typeparam>
    /// <param name="name">tag path name of the tag to be opened</param>
    /// <returns>the newly created tag or null if bad call</returns>
    public T Open<T>(string name, bool @lock) where T : Tag
    {
      return GetTagInstance(PoolAction.LoadExisting, name, typeof(T), true, @lock, false, true) as T;
    }

    public T Open<T>(string name, bool @lock, string gameID) where T : Tag
    {
      return GetTagInstance(PoolAction.LoadExisting, name, typeof(T), true, @lock, false, true, gameID) as T;
    }

    /// <summary>
    /// Returns a list of tag references contained within the specified tag.
    /// </summary>
    public string[] GetTagReferences(string name, Type type)
    {
      Tag t = GetTagInstance(PoolAction.LoadExisting, name, type, false, false, false, false);
      string[] results = t.TagReferenceList;
      return results;
    }
    
    /// <summary>
    /// Creates a new tag with the specified name.
    /// </summary>
    public T Create<T>(string name) where T : Tag
    {
      return GetTagInstance(PoolAction.CreateNew, name, typeof(T), false, false, false, true) as T;
    }

    /// <summary>
    /// Enumerates available tag open modes.
    /// </summary>
    private enum PoolAction
    {
      CreateNew,
      LoadExisting
    }

    /// <summary>
    /// Takes a non-qualified path and creates a fully-qualified path based on tag scope.
    /// This method takes into account scope priority rules.
    /// </summary>
    private string QualifyScope(string gameID, string path)
    {
      // TODO: Eventually, when we supoprt a shared folder and prefabs, we will need to look through them.
      // Check the Project folder first.
      TagPath tagPath = new TagPath(path, gameID, TagLocation.Project);
      if (TagExists(tagPath))
        return tagPath.ToPath();

      // Next check the game archive.
      tagPath.Location = TagLocation.Archive;
      if (TagExists(tagPath))
        return tagPath.ToPath();

      return "";
    }

    private Tag GetTagInstance(PoolAction action, string name, Type type, bool doPostProcessing,
                               bool @lock, bool permanent, bool addToPool)
    {
      return GetTagInstance(action, name, type, doPostProcessing, @lock, permanent, addToPool, "");
    }

    /// <summary>
    /// Checks to see if the tag at the specified path exists.
    /// </summary>
    /// <param name="fullyQualifiedPath">A fully qualified Pool path including prefix.</param>
    public bool TagExists(string fullyQualifiedPath)
    {
      TagPath path = new TagPath(fullyQualifiedPath);
      return TagExists(path);
    }

    /// <summary>
    /// Saves the tag, wrapping it in the supplied TagFile.
    /// </summary>
    public void SaveTag(Tag tag, TagFile tagFile)
    {
      VerifyTagIsSavableToSpecifiedLocation(tag);
      // Until we have the revision functionality more solidified, we will just save over the head revision.
      SaveTagToHeadRevision(tag, tagFile);
    }

    /// <summary>
    /// Does what is says, because I hate duplicate code.
    /// </summary>
    private void VerifyTagIsSavableToSpecifiedLocation(Tag tag)
    {
      if (tag.TagPath.Location == TagLocation.Archive)
        throw new Exception("Tags cannot be saved to the Global Tag Archive!");

      else if (tag.TagPath.Location == TagLocation.Project)
        if (library == null)
          throw new Exception("Cannot save tag to project because a project is not currently loaded: " + tag.TagPath.ToPath());
    }

    /// <summary>
    /// Saves the tag to the file specified in its TagPath.
    /// </summary>
    public void SaveTag(Tag tag)
    {
      VerifyTagIsSavableToSpecifiedLocation(tag);
      
      // Until we have the revision functionality more solidified, we will just save over the head revision.
      SaveTagToHeadRevision(tag);
    }

    /// <summary>
    /// Checks to see if the tag at the specified path exists.
    /// </summary>
    public bool TagExists(TagPath path)
    {
      if (path.Location == TagLocation.Archive)
      {
        GameDefinition def = Core.Prometheus.Instance.GetGameDefinitionByGameID(path.Game);
        if (def == null)
        {
          Output.Write(OutputTypes.Debug, "A tag was passed to 'Pool.TagExists()' that references a game that was not found in the GameDefinition list: " + path.ToPath());
          return false;
        }
        return def.GlobalTagLibrary.FileExists(path.Path + "." + path.Extension);
      }
      else if (path.Location == TagLocation.Project)
      {
        // Make sure that a project is loaded.
        ProjectManager pm = Core.Prometheus.Instance.ProjectManager;
        if (pm != null)
          if (pm.ProjectLoaded)
            if (pm.GameID == path.Game)
              return pm.ProjectFolder.FileExists(path.Path + "." + path.Extension);
        return false;
      }
      else
        throw new Exception("The specified tag source is invalid or not supported.");
    }

    /// <summary>
    /// Creates an instance of a Tag object, optionally loading pre-existing data
    /// from one of the pool's internal ILibrary objects.
    /// </summary>
    private Tag GetTagInstance(PoolAction action, string name, Type type, bool doPostProcessing, 
                               bool @lock, bool permanent, bool addToPool, string gameID)
    {
      // Parse the name
      TagPath path = new TagPath(name);
      if (path.Game == "")
        path.Game = gameID;

      if (path.Location == TagLocation.Auto)
      {
        name = QualifyScope(path.Game, path.Path + "." + path.Extension);
        if (String.IsNullOrEmpty(name))
          throw new TagNotFoundException("Tag {0}.{1} does not exist.", path.Path, path.Extension);
        path = new TagPath(name);
      }
      name = path.Path;

      // make sure that type is inheriting from Tag
      if (!type.IsSubclassOf(typeof(Tag)))
        throw new PoolException("Cannot instantiate a tag of type {0} because it does not inherit from {1}.", type.Name, typeof(Tag).Name);

      Tag match = tags.LocateTag(name, type);
      if (match != null)
      {
        if (action == PoolAction.CreateNew)
          throw new TagAlreadyExistsException("The tag {0} of type {1} already exists in this pool. It cannot be created again.", name, type.Name);
        match.ReferenceCount++;
        if (doPostProcessing && !match.PostProcessed)
          match.DoPostProcess();
        return match;
      }

      
      // Create the tag object.
      Tag tag = Activator.CreateInstance(GetUpdatedType(type, path.Game)) as Tag;
      tag.TagPath = path;
      tag.Initialize(name, idCurrent++, path.Game, !permanent, this);
      path.Extension = tag.FileExtension;
      tag.ReferenceCount = 1;
      tag.NotReferenced += new EventHandler(DisposeOfTag);
      tag.Locked = @lock;

      if (action == PoolAction.LoadExisting)
      {
        try
        {
          byte[] meta = GetTagBinary(path);
          if (meta == null)
            throw new TagNotFoundException("The tag {0} of type {1} was requested for open and was not found.", name, type.Name);
          else
            tag.Load(meta);
        }
        catch (Exception ex)
        {
          throw new PoolException(ex, "An error occured during the deserialization of {0} of type {1}.", name, type.Name);
        }
        if (doPostProcessing)
        {
          try
          { tag.DoPostProcess(); }
          catch (Exception ex)
          { throw new PoolException(ex, "An error occured during postprocessing of {0} of type {1}.", name, type.Name); }
        }
      }
      else tag.New();

      // If the deserialization and postprocessing were successful, add the tag to the pool.
      if (addToPool) tags.Add(tag);
      return tag;
    }

    /// <summary>
    /// A nongeneric method used to open a tag and return a handle to the tag when the strong type of the tag is not accessable.
    /// </summary>
    /// <param name="name">tag path name of the tag to be opened</param>
    /// <param name="type">type of tag to open</param>
    /// <param name="doPostProcessing">true if the tag is to be post processed for rendering, false otherwise</param>
    /// <param name="lock">true if the tag is to be locked, false if it is not</param>
    /// <returns>the newly created tag or null if bad call</returns>
    public Tag Open(string name, Type type, bool doPostProcessing, bool @lock)
    { return GetTagInstance(PoolAction.LoadExisting, name, type, doPostProcessing, @lock, false, true); }

    /// <summary>
    /// A nongeneric method used to open a tag and return a handle to the tag when the strong type of the tag is not accessable.
    /// </summary>
    /// <param name="name">tag path name of the tag to be opened</param>
    /// <param name="type">type of tag to open</param>
    /// <param name="doPostProcessing">true if the tag is to be post processed for rendering, false otherwise</param>
    /// <returns>the newly created tag or null if bad call</returns>
    public Tag Open(string name, Type type, bool doPostProcessing)
    { return GetTagInstance(PoolAction.LoadExisting, name, type, doPostProcessing, false, false, true); }

    /// <summary>
    /// A nongeneric method used to create a tag and return a handle to the tag when the strong type of that tag is not available.
    /// </summary>
    /// <param name="name">tag path name of the tag to be created</param>
    /// <param name="type">type of the tag to be created</typeparam>
    /// <returns>the newly created tag or null if bad call</returns>
    public Tag Create(TagPath path, Type type, bool doPostProcessing)
    {
      return GetTagInstance(PoolAction.CreateNew, path.ToPath(PathFormat.ExplicitLocation), type, doPostProcessing, false, false, true, path.Game);
    }

    /// <summary>
    /// Releases a tag from the grasp of another tag.
    /// </summary>
    /// <param name="tag">tag to release</param>
    public void Release(Tag tag)
    {
      if (tag != null) // silent fail if tag is null
        tag.ReferenceCount--;
    }

    /// <summary>
    /// Disposes of a tag which will no longer be used.
    /// </summary>
    /// <param name="tag">tag to dispose. this function sets it to null to prevent access violation.</param>
    public void DisposeOfTag(ref Tag tag)
    {
      if (tag == null)
        throw new ArgumentNullException("tag", "Tag to dispose cannot be null.");

      tag.ReferenceCount--;
      tag = null;
    }

    /// <summary>
    /// Internal, automatic disposing of unused tags.
    /// </summary>
    private void DisposeOfTag(object sender, EventArgs e)
    {
      Tag tag = sender as Tag;

      if (tag == null)
        throw new ArgumentNullException("sender", "Tag to dispose cannot be null.");
      if (tag.ReferenceCount > 0)
        throw new PoolException("Tried to dispose of a tag with a reference count of {0}.", tag.ReferenceCount);

      if (tag.PostProcessed)
        tag.Dispose();
      tags.Remove(tag);
      Output.Write(OutputTypes.Debug, "Tag " + tag.TagPath.ToPath() + " was disposed.");
    }

    /// <summary>
    /// Disposes all tags in the pool and prepares the pool for garbage collection.
    /// </summary>
    public void Dispose()
    {
      foreach (Tag tag in globals.Values)
        tag.ReferenceCount--;

      lock (typeof(Tag)) // this needs to be done to prevent some nasty effects should another thread attempt to try something with a tag while they are being disposed.
      {
        Tag.NotReferencedCanFire = false;
        foreach (Tag tag in tags)
          if (tag.PostProcessed)
            tag.Dispose();
        foreach (Tag tag in tags)
          if (tag.ReferenceCount != 0)
            Output.Write(OutputTypes.Warning, "Pool: Tag {0} of type {1} was globally disposed with a reference count of {2}.", tag.Name, tag.GetType().Name, tag.ReferenceCount);
        tags.Clear();
        Tag.NotReferencedCanFire = true;
      }

      archives.Clear();
      prefabs.Clear();
      shareds.Clear();
      globals.Clear();

      format = null;
      library = null;
    }

    /// <summary>
    /// Cleans up all unmanaged DirectX resources allocated by tags in this Pool.
    /// </summary>
    public void OnResetDevice()
    {
      foreach (Tag tag in tags)
        tag.OnDeviceReset();
    }

    /// <summary>
    /// Recreates all unmanaged DirectX resources allocated by tags in this Pool.
    /// </summary>
    public void OnLostDevice()
    {
      foreach (Tag tag in tags)
        tag.OnDeviceLost();
    }

    /// <summary>
    /// Returns a helpful little string for debugging.
    /// </summary>
    /// <returns>a helpful string. what more do you want from me? a poem?</returns>
    public override string ToString()
    {
      if (format == null)
        return "Currently holding references to " + tags.Count + " tags with no default game registered.";
      else
        return "Currently holding references to " + tags.Count + " tags with a default game of " + format + '.';
    }

    /// <summary>
    /// Registers a project with the pool.
    /// </summary>
    /// <param name="gameFormat">game format string that the project uses</param>
    /// <param name="library">the project's tag library</param>
    public void RegisterProject(string gameFormat, ILibrary library)
    {
      if (this.library != null)
      {
        ResetProject();
        // TODO: We need to generate an event here that provides a cancel property so
        // that the GUI can be informed that the project is closing and act appropriately
        // by allowing the user to save the project if it is unchanged, close any open
        // documents related to the project, and cancel the close if they want.
      }

      format = gameFormat;
      this.library = library;
    }

    /// <summary>
    /// Removes all project dependency from this Pool instance.
    /// </summary>
    public void ResetProject()
    {
      prefabs.Clear();
      shareds.Clear();
      library = null;
      format = null;
    }

    /// <summary>
    /// Registers a prefab library in the set of available prefabs.
    /// </summary>
    /// <param name="prefab">prefab library to add</param>
    public void RegisterPrefab(ILibrary prefab)
    { prefabs.Add(prefab.Name, prefab); }

    /// <summary>
    /// Removes a prefab from the set of available prefabs.
    /// </summary>
    public void RemovePrefab(ILibrary prefab)
    { prefabs.Remove(prefab.Name); }

    /// <summary>
    /// Registers a shared library in the set of available shared libraries.
    /// </summary>
    public void RegisterShared(ILibrary shared)
    { shareds.Add(shared.Name, shared); }

    /// <summary>
    /// Removes a shared library from the set of available shared libraries.
    /// </summary>
    /// <param name="shared">shared library to remove</param>
    public void RemoveShared(ILibrary shared)
    { shareds.Remove(shared.Name); }

    /// <summary>
    /// Adds a format-specific archive to the list of available archives.
    /// </summary>
    /// <param name="gameFormat">game that the archive supports</param>
    /// <param name="library">archive to add</param>
    public void RegisterGame(string gameFormat, string globalsTagName, TypeTable types, ILibrary library)
    {
      if (archives.ContainsKey(gameFormat)) // halo pc and halo ce, for instance, use the same library.
        return;

      archives.Add(gameFormat, library);
      tables.Add(gameFormat, types);

      if (library == null)
        return;

      if (!String.IsNullOrEmpty(globalsTagName))
      {
        TagPath path = new TagPath(globalsTagName, gameFormat, TagLocation.Archive);

        if (library.FileExists(globalsTagName))
          globals.Add(gameFormat, Open(path.ToPath(), types.LocateEntryByName(path.Extension).TagType, true, true));
      }
    }

    /// <summary>
    /// Returns the default globals tag for the specified game.
    /// </summary>
    /// <param name="game">game to look up</param>
    /// <returns>the game's default globals tag</returns>
    public Tag GetGlobals(string game)
    { return globals[game]; }

    /// <summary>
    /// Retreive the TagFile object from the specified TagPath.
    /// </summary>
    public TagFile GetTagFile(TagPath path)
    {
      // Qualify the scope if necessary.
      if (path.Location == TagLocation.Auto)
      {
        string qualifiedPath = QualifyScope(path.Game, path.Path);
        TagPath newPath = new TagPath(qualifiedPath);
        path.Location = newPath.Location;
      }

      byte[] bin = null;
      if (path.Location == TagLocation.Archive)
        bin = archives[path.Game].ReadFile(path.Path + "." + path.Extension);
      else if (path.Location == TagLocation.Project)
        if (library != null)
          bin = library.ReadFile(path.Path + "." + path.Extension);

      if (bin == null)
        throw new Exception("The specified tag was not found: " + path.ToPath());

      MemoryStream stream = new MemoryStream(bin);
      TagFile file = new TagFile(stream);
      return file;
    }

    /// <summary>
    /// Returns the specified named binary attachment from the TagFile located at the supplied TagPath.
    /// </summary>
    public byte[] GetTagAttachent(TagPath path)
    {
      // First, get the TagFile represented by this path.
      // TODO: This has no exception handling, so.. yeah..
      TagFile file = GetTagFile(path);
      return file.GetAttachmentRevision(path.AttachmentName);
    }

    /// <summary>
    /// Save the specified tag's data over the head revision of the tag file at the specified tag path.
    /// </summary>
    private void SaveTagToHeadRevision(Tag tag)
    {
      TagFile tf = GetTagFile(tag.TagPath);
      SaveTagToHeadRevision(tag, tf);
    }

    /// <summary>
    /// Save the specified tag's data over the head revision of the specified tag file.
    /// </summary>
    private void SaveTagToHeadRevision(Tag tag, TagFile tagFile)
    {
      tagFile.SetHeadBinary(tag.Save());
      ILibrary targetLibrary = GetLibrary(tag.TagPath);
      targetLibrary.AddFile(tag.TagPath.Path + "." + tag.TagPath.Extension, tagFile.ToBytes());
    }

    /// <summary>
    /// Reads tag binary metadata from the archive with highest priority.
    /// </summary>
    /// <param name="path">TagPath object representing the path to the requested metadata</param>
    /// <returns>binary metadata for tag or null if not found</returns>
    private byte[] GetTagBinary(TagPath path)
    {
      //ILibrary library = GetLibrary(path);
      //byte[] metadata = library.ReadFile(path.Path + '.' + path.Extension);
      TagFile tf = GetTagFile(path);
      //TagFile tf = new TagFile(new MemoryStream(metadata));
      return tf.GetBinary(tf.HeadRevision);
    }

    /// <summary>
    /// Gets the library associated with the given TagPath.
    /// </summary>
    /// <param name="path">TagPath to get the library for</param>
    /// <returns>an ILibrary implementation containing the specified TagPath</returns>
    private ILibrary GetLibrary(TagPath path)
    {
      switch (path.Location)
      {
        case TagLocation.Project:
          if (library == null)
            return archives[path.Game];
          else
            return library;
        case TagLocation.Archive:
          return archives[path.Game];
        case TagLocation.Prefab:
          if (path.Game == format)
            return prefabs[path.LocationName];
          else
            throw new PoolException("Tried to load a prefab of a differing game format than the currently registered project, if any.");
        case TagLocation.Shared:
          if (path.Game == format)
            return shareds[path.LocationName];
          else
            throw new PoolException("Tried to load a shared tag of a differing game format than the currently registered project, if any.");
        default:
          throw new PoolException("Invalid path location was passed to GetLibrary.");
      }
    }

    /// <summary>
    /// Gets a tag in this pool with the specified ID.
    /// </summary>
    /// <param name="id">tag ID to retrieve</param>
    /// <returns>tag or null if not found</returns>
    public Tag GetByID(int id)
    {
      return tags.GetByID(id);
    }
    
    /// <summary>
    /// Returns the type to use provided the type we expect to see.
    /// </summary>
    private Type GetUpdatedType(Type initialType, string game)
    { return tables[game].GetTypeHandle(initialType); }

    /// <summary>
    /// Extends a generic list of tag objects to support search functionality.
    /// </summary>
    private class TagList<T> : List<T> where T : Tag
    {
      /// <summary>
      /// Returns a tag from the pool with the specified name and type.
      /// </summary>
      public T LocateTag(string name, Type type)
      {
        foreach (T match in this)
          if (match.Name == name)
            if (match.GetType() == type)
              return match;
        return null;
      }

      /// <summary>
      /// Returns a tag from the pool with the specified ID.
      /// </summary>
      public T GetByID(int id)
      {
        foreach (T tag in this)
          if (tag.ID == id)
            return tag;
        return null;
      }
    }

    /// <summary>
    /// Returns a value indicating if the specified tag is currently loaded in the pool.
    /// </summary>
    public bool Contains(TagPath path, Type type)
    {
      return tags.LocateTag(path.Path, type) != null;
    }
  }
}