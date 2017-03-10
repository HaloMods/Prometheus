using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Interfaces.Factory;
using Interfaces.Pool;

namespace Interfaces.Games
{
  /// <summary>
  /// Defines a palette of referenced tags and its corresponding instance collection within a Scenario.
  /// </summary>
  public class PaletteDefinition
  {
    IBlockCollection paletteBlock;
    IBlockCollection instancesBlock;

    /// <summary>
    /// Gets or sets the name of this palette.
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// Delegate method that handles creating a new instance within the scene graph.
    /// </summary>
    public AddInstanceMethod AddInstance { get; set; }

    public PaletteDefinition(string name, 
      IBlockCollection paletteBlock, IBlockCollection instancesBlock)
    {
      Name = name;
      this.paletteBlock = paletteBlock;
      this.instancesBlock = instancesBlock;
    }
  }

  /// <summary>
  /// Represents a delegate method used to add an item to a palette.
  /// </summary>
  public delegate void AddPaletteItemMethod(Tag tag);
  
  /// <summary>
  /// Represents a method used to add an instance of an item to a scenario.
  /// </summary>
  public delegate int AddInstanceMethod(IBlock block);

  /// <summary>
  /// Represents a method used to add a a block to 
  /// </summary>
  /// <param name="block"></param>
  public delegate void AddPaletteItemBlockMethod(IBlock block);
  public delegate void AddInstanceBlockMethod(Dictionary<string, object> values);
}


      //// --- Scenery
      //PaletteDefinition sceneryDefinition = paletteDefinitions["Scenery"];
      //foreach (ScenarioSceneryBlock scenery in scenarioValues.Scenery)
      //{
      //  if (scenery.Type.Value >= 0)
      //    sceneryDefinition.AddInstance(scenery);
      //}

    ///// <summary>
    ///// Casts the supplied block to the type specified by BlockType.
    ///// </summary>
    //private BlockType CastBlock<BlockType>(IBlock block) where BlockType : class
    //{
    //  if (!(block is BlockType))
    //    throw new Exception("The specified block was not of the appropriate type.");

    //  if (block == null)
    //    throw new Exception("The supplied block is null and cannot be cast to the specified type.");

    //  return block as BlockType;
    //}

    //private void SetupPalettes()
    //{
    //  // --- Scenery Palette Definition ---
    //  PaletteDefinition sceneryDef = new PaletteDefinition("Scenery",
    //    scenarioValues._sceneryPaletteList, scenarioValues._sceneryList);
      
    //  sceneryDef.AddInstance = delegate(IBlock block)
    //  {
    //    ScenarioSceneryBlock sceneryBlock = CastBlock<ScenarioSceneryBlock>(block);

    //    WorldInstance instance = (WorldInstance)sceneryPalette[sceneryBlock.Type.Value].Instance;
    //    if (instance is ObjectInstance)
    //      (instance as ObjectInstance).EnvironmentProvider = this;
    //    instance.TargetType = TargetType.Object;
    //    instance.OcclusionNode = true;
    //    instance.SetBindingTransform(new BindingTransform(sceneryBlock.Rotation, sceneryBlock.Position));
    //    instances.Add(instance);
    //    return 0; // TODO: instances.Add needs to return a unique identifier within the scope of the scene.
    //  };
    //  paletteDefinitions.Add(sceneryDef.Name, sceneryDef);

    //  //// --- Vehicles Palette Definition ---

    //}