using Interfaces.Factory;
using System;

namespace Interfaces.TagEditor
{
  /// <summary>
  /// Represents a method that will handle the BlockChanged event.
  /// </summary>
  public delegate void BlockChangedHandler(IBlock e, IFieldControlContainer container);
  
  /// <summary>
  /// Base for implementing a block control.
  /// </summary>
  public interface IBlockControl
  {
    event BlockChangedHandler BlockChanged;
    event BlockCollectionChangedHandler BlockCollectionChanged;
    void Initialize();
    void DataBindCollection(IBlockCollection blockCollection);
    string[] BlockValues { get; }
    string LinkedStructName { get; }
    /// <summary>
    /// Gets or sets the parent container of this block.
    /// </summary>
    IFieldControlContainer Container { get; set;} // I wish I didn't have to do this... :(
    /// <summary>
    /// Gets or sets the selected block index.
    /// </summary>
    int SelectedBlockIndex { get; set;}
    /// <summary>
    /// Gets or sets the collection of blocks contained in the IBlockControl.
    /// </summary>
    IBlockCollection BlockCollection { get; }

    int MaxBlockCount { get; set;}
  }

  public delegate void BlockCollectionChangedHandler(object sender, string[] values);
}