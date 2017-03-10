using System;
using System.IO;
using Interfaces.Factory;

namespace Interfaces.Pool
{
  /// <summary>
  /// Abstract base class for any tag in any game.
  /// </summary>
  public abstract class Tag : IBlock, IDisposable
  {
    private int id = -1;
    private int referenceCount = 0;
    private bool locked = false;
    private bool invalid = false;
    private bool postProcessed = false;
    private bool canBeDisposed = true;
    private IPool pool = null;
    private string name = null;
    private string game = null;
    private string errors = String.Empty;
    private TagPath tagPath = null;

    private static bool noReferenceCanFire = true;
    private static Random random = new Random();

    public event EventHandler BlockNameChanged;
   
    /// <summary>
    /// Initializes a new tag.
    /// </summary>
    /// <param name="name">name of the tag</param>
    /// <param name="id">unique identifier</param>
    /// <param name="game">game that the tag belongs to</param>
    /// <param name="pool">pool to create the tag in</param>
    public void Initialize(string name, int id, string game, IPool pool)
    {
      this.name = name;
      this.id = id;
      this.game = game;
      this.pool = pool;
    }

    /// <summary>
    /// Initializes a new tag.
    /// </summary>
    /// <param name="name">name of the tag</param>
    /// <param name="id">unique identifier</param>
    /// <param name="game">game that the tag belongs to</param>
    /// <param name="canBeDisposed">flag indicating whether or not this tag should be auto disposed</param>
    /// <param name="pool">pool to create the tag in</param>
    public void Initialize(string name, int id, string game, bool canBeDisposed, IPool pool)
    {
      this.name = name;
      this.id = id;
      this.game = game;
      this.canBeDisposed = canBeDisposed;
      this.pool = pool;
    }

    /// <summary>
    /// Reinitializes this tag, updating any internal persistant data.
    /// </summary>
    public virtual void Rehash()
    {
      errors = String.Empty;
      if (postProcessed)
      {
        Dispose();
        DoPostProcess();
      }
    }

    /// <summary>
    /// Recreates any unmanaged DirectX resources allocated by this tag.
    /// </summary>
    public virtual void OnDeviceReset()
    { /* There are no DirectX resources used by this tag. The reason this is not an abstract method is so that any derived tags with nothing to reset do not need to have a separate, empty implementation of this function. */ }

    /// <summary>
    /// Cleans up any unmanaged DirectX resources allocated by this tag.
    /// </summary>
    public virtual void OnDeviceLost()
    { /* There are no DirectX resources used by this tag. The reason this is not an abstract method is so that any derived tags with nothing to reset do not need to have a separate, empty implementation of this function. */ }

    /// <summary>
    /// Cleans up any unmanaged resources and releases all tags used by this tag.
    /// </summary>
    public virtual void Dispose()
    { /* There are no unmanaged resources used by this tag. The reason this is not an abstract method is so that any derived tags with nothing to dispose do not need to have a separate, empty implementation of this function. */ }

    /// <summary>
    /// Initializes this tag with default values.
    /// </summary>
    public virtual void New()
    { /* There are no fields to initialize in this tag. The reason this is not an abstract method is so that any derived tags with nothing to dispose do not need to have a separate, empty implementation of this function. */ }

    /// <summary>
    /// Postprocesses the tag - loads dependent tags, initializes directx objects, etc.
    /// When overriding, remember to call base.DoPostProcess()!
    /// </summary>
    public virtual void DoPostProcess()
    { postProcessed = true; }

    /// <summary>
    /// Gets or sets the amount of known references to this tag. When this is zero, this tag may safely be disposed.
    /// </summary>
    public int ReferenceCount
    {
      get
      { return referenceCount; }
      set
      {
        referenceCount = value;
        if (canBeDisposed)
          if (noReferenceCanFire)
            if (referenceCount <= 0)
              if (NotReferenced != null)
                NotReferenced(this, EventArgs.Empty);
      }
    }

    /// <summary>
    /// Gets the default globals tag in the same game as this tag.
    /// </summary>
    protected Tag Globals
    {
      get
      { return pool.GetGlobals(game); }
    }

    /// <summary>
    /// Opens the specified tag.
    /// </summary>
    /// <typeparam name="T">type of tag to open</typeparam>
    /// <param name="name">tag name</param>
    /// <returns>handle to tag</returns>
    protected T Open<T>(string name) where T : Tag
    {
      if (String.IsNullOrEmpty(name))
        return null;

      T tag;
      try
      { tag = pool.Open<T>(name, locked, GameID); }
      catch (Exception ex) // most likely a TagNotFoundException, but that's not accessable here (after a year of this damned message we know this not to be the case)
      {
        LogError("Failed to load dependent tag {0}. Pool.Open threw. Message: {1}", name, ex.Message);
        return null;
      }

      if (tag == null)
      {
        LogError("Failed to load dependent tag {0}. Return value was null.", name);
        return null;
      }

      return tag;
    }

    /// <summary>
    /// Releases a tag from use.
    /// </summary>
    /// <param name="tag">tag to release</param>
    protected void Release(Tag tag)
    { pool.Release(tag); }

    /// <summary>
    /// Creates a Pool-readable path name for the given tag name.
    /// </summary>
    /// <param name="path">tag name</param>
    /// <returns>tag path string</returns>
    private string Path(string path)
    {
      return tagPath.ToPath();
    }

    public TagPath TagPath
    {
      get { return tagPath; }
      set { tagPath = value; }
    }

    /// <summary>
    /// Returns the name, the extension, and the game of this Tag instance.
    /// </summary>
    /// <returns>name, extension, and game of tag</returns>
    public override string ToString()
    { return name + '.' + FileExtension + " [" + game + ']'; }

    /// <summary>
    /// Gets the name of this tag, in hierarchical form.
    /// </summary>
    public string Name
    {
      get
      { return name; }
    }

    /// <summary>
    /// Gets the game that this tag is constituent to.
    /// </summary>
    public string GameID
    {
      get
      { return game; }
    }

    /// <summary>
    /// Gets a unique, pool-relative identifier for this tag.
    /// </summary>
    public int ID
    {
      get
      { return id; }
    }

    /// <summary>
    /// Gets a value indicating whether the tag is in an invalid (unsuitable for rendering) state.
    /// </summary>
    public virtual bool Invalid
    {
      get
      { return invalid; }
    }

    /// <summary>
    /// Gets a list of errors this tag encountered while attempting to initialize.
    /// </summary>
    public string Errors
    {
      get
      { return errors; }
    }

    /// <summary>
    /// Logs errors encountered by this tag.
    /// </summary>
    protected void LogError(string message, params object[] arguments)
    {
      string error = String.Format(message, arguments);
      errors += error + '\n';
      invalid = true;
      Output.Write(OutputTypes.Error, error);
      if (ErrorThrow != null)
        ErrorThrow(this, new TagErrorEventArgs(error));
    }

    /// <summary>
    /// Gets a flag that is true if the tag has been postprocessed, and false if it has not been.
    /// </summary>
    public bool PostProcessed
    {
      get
      { return postProcessed; }
    }

    /// <summary>
    /// Gets or sets a flag that is true if the tag is locked, that is, render-only and uneditable, or false if it is an editable tag.
    /// </summary>
    public bool Locked
    {
      get
      { return locked; }
      set
      { locked = value; }
    }

    /// <summary>
    /// When implemented in a derived class, loads the tag from the specified binary chunk.
    /// </summary>
    /// <param name="metadata">binary chunk of tag data to load</param>
    /// <returns>position in file when header loading was complete</returns>
    public abstract int Load(byte[] metadata);

    public abstract byte[] Save();

    /// <summary>
    /// When implemented in a derived class, gets the extension used by tags of this type.
    /// </summary>
    public abstract string FileExtension
    { get; }

    /// <summary>
    /// When implemented in a derived class, this property returns a list of all tags that this tag depends on.
    /// </summary>
    public abstract string[] TagReferenceList { get; }

    public string BlockName
    {
      get { return ""; }
    }

    //public string BlockName()
    //{
    //  return "";
    //}

    /// <summary>
    /// Reads direct fields of this tag. Rides on an interface method.
    /// </summary>
    public abstract void Read(BinaryReader reader);

    /// <summary>
    /// Reads child fields of this tag. Rides on an interface method.
    /// </summary>
    public abstract void ReadChildData(BinaryReader reader);

    public abstract void Write(BinaryWriter writer);
    public abstract void WriteChildData(BinaryWriter writer);

    /// <summary>
    /// Gets or sets whether or not the NotReferenced event can fire.
    /// </summary>
    public static bool NotReferencedCanFire
    {
      get
      { return noReferenceCanFire; }
      set
      { noReferenceCanFire = value; }
    }

    /// <summary>
    /// Gets a static random number generator.
    /// </summary>
    protected static Random Random
    {
      get
      { return random; }
    }

    /// <summary>
    /// Fires when the reference count reaches zero. Notifies the tag pool that this class needs disposed.
    /// </summary>
    public event EventHandler NotReferenced;

    /// <summary>
    /// Fires when an error is thrown by this tag.
    /// </summary>
    public event TagErrorEventHandler ErrorThrow;
  }
}
