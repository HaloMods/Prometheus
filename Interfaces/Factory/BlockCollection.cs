using System;
using System.Collections.Generic;
using Interfaces.Factory;

namespace Interfaces.Factory
{
  /// <summary>
  /// A generic collection of IBlock-derived objects.
  /// </summary>
  public class BlockCollection<BlockType> : List<BlockType>, IBlockCollection where BlockType : IBlock
  {
    public event EventHandler BlockAdded;
    public event EventHandler BlockRemoved;

    /// <summary>
    /// Returns the total number of blocks in the collection.
    /// </summary>
    public int BlockCount
    {
      get { return Count; }
    }

    /// <summary>
    /// Creates a new block and adds it to the collection.
    /// </summary>
    public void AddNewBlock()
    {
      Type blockType = GetType().GetGenericArguments()[0];
      BlockType block = (BlockType)Activator.CreateInstance(blockType);
      Add(block);
      if (BlockAdded != null)
        BlockAdded(this, new EventArgs());
    }
    
    /// <summary>
    /// Removes the block at the specified index.
    /// </summary>
    public void RemoveBlock(int index)
    {
      RemoveAt(index);
      if (BlockRemoved != null)
        BlockRemoved(this, new EventArgs());
    }

    /// <summary>
    /// Removes all blocks from the collection.
    /// </summary>
    public void ClearBlocks()
    {
      //Clear();
      //if (CollectionChanged != null)
      //  CollectionChanged(this, new EventArgs());
      while (Count > 0)
        RemoveBlock(0);
    }
    
    /// <summary>
    /// Retrieves the block at the specified index.
    /// </summary>
    public IBlock GetBlock(int index)
    {
      return this[index];
    }
    public void InsertNew(int index)
    {
      Type blockType = GetType().GetGenericArguments()[0];
      BlockType block = (BlockType)Activator.CreateInstance(blockType);
      Insert(index, block);

      if (BlockAdded != null)
        BlockAdded(this, new EventArgs());
    }

    #region Duplicate stuff
    private class AutoEnlargingMemoryStream : System.IO.MemoryStream
    {
      public override long Position
      {
        get
        {
          return base.Position;
        }
        set
        {
          if (value > Length)
          {
            Write(new byte[value - Length], 0, (int)(value - Length));
            base.Position = value;
          }
          else base.Position = value;
        }
      }
      public override long Seek(long offset, System.IO.SeekOrigin loc)
      {
        if (loc == System.IO.SeekOrigin.Begin)
          Position = offset;
        else if (loc == System.IO.SeekOrigin.Current)
          Position += offset;
        else Position = Length - offset;
        return Position;
      }
    }
    /// <summary>
    /// Duplicates a block and inserts it into the correct location.
    /// </summary>
    /// <param name="sourceIndex">The index of the block to duplicate.</param>
    /// <param name="destIndex">The index to insert the duplicate block. If this index is beyond the length of the block collection, it will be added to the end.</param>
    public void Duplicate(int sourceIndex, int destIndex)
    {
      // Ensure that both indexes are valid.
      if (sourceIndex < 0) // check for negatives
        throw new IndexOutOfRangeException("When duplicating a block, the index (" + sourceIndex + ") for the source block must be within the bounds of the count (" + Count + ").");
      else if (sourceIndex >= Count)
        throw new IndexOutOfRangeException("When duplicating a block, the index (" + sourceIndex + ") for the source block must be within the bounds of the count (" + Count + ").");

      if (destIndex < 0)
        throw new IndexOutOfRangeException("When duplicating a block, the index (" + sourceIndex + ") for the source block must be within the bounds of the count (" + Count + ").");
      else if (sourceIndex >= Count)
      {
        destIndex = Count;
      }

      System.IO.MemoryStream blockData = new AutoEnlargingMemoryStream();
      System.IO.MemoryStream childData = new AutoEnlargingMemoryStream();

      if (this[sourceIndex] != null)
      {
        this[sourceIndex].Write(new System.IO.BinaryWriter(blockData));
        this[sourceIndex].WriteChildData(new System.IO.BinaryWriter(childData));
      }
      else
      {
        this.InsertNew(destIndex);
        return;
      }

      blockData.Position = 0;
      childData.Position = 0;

      Type blockType = GetType().GetGenericArguments()[0];
      BlockType block = (BlockType)Activator.CreateInstance(blockType);
      
        block.Read(new System.IO.BinaryReader(blockData));
        block.ReadChildData(new System.IO.BinaryReader(childData));
      

      this.Insert(destIndex, block);
    }
    #endregion
  }
  
  /// <summary>
  /// Provides a method in which to perform non-typed actions on a block collection.
  /// </summary>
  public interface IBlockCollection
  {
    int BlockCount { get; }
    void AddNewBlock();
    void RemoveBlock(int index);
    void ClearBlocks();

    IBlock GetBlock(int index);
    void InsertNew(int index);
    void Duplicate(int sourceIndex, int destIndex);

    event EventHandler BlockAdded;
    event EventHandler BlockRemoved;
  }
}