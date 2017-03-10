using System;
using System.Collections.Generic;
using Interfaces.Rendering.Instancing;

namespace Games.Halo.Tags.Classes
{
  public partial class item_collection : IInstanceable
  {
    private item[] items = null;

    public override void DoPostProcess()
    {
      base.DoPostProcess();

      items = new item[itemCollectionValues.ItemPermutations.Count];
      for (int i = 0; i < items.Length; i++)
        items[i] = OpenItem(itemCollectionValues.ItemPermutations[i].Item.Value, itemCollectionValues.ItemPermutations[i].Item.TagGroup);
    }

    protected item OpenItem(string tag, string type)
    {
      switch (type)
      {
        case "eqip":
          return Open<equipment>(tag);
        case "weap":
          return Open<weapon>(tag);
        case "garb":
          return Open<garbage>(tag);
        case "item":
          return Open<item>(tag);
      }

      throw new HaloException(type + " is not recognized as a valid item collection entry.");
    }

    public override void Dispose()
    {
      base.Dispose();
      if (items != null)
        for (int i = 0; i < items.Length; i++)
          Release(items[i]);
    }

    public Instance Instance
    {
      get
      {
        int permutation = 0;
        float current = 0.0f;
        for (int i = 0; i < items.Length; i++)
        {
          float checkVal = (float)Random.NextDouble() * itemCollectionValues.ItemPermutations[i].Weight.Value;
          if (checkVal > current)
          {
            permutation = i;
            current = checkVal;
          }
        }
        return items[permutation].Instance;
      }
    }
  }
}
