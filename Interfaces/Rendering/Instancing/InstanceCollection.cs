using System;
using System.Collections;
using System.Collections.Generic;
using Interfaces.Rendering.Interfaces;
using Interfaces.Rendering.Wrappers;
using Microsoft.DirectX;
using Microsoft.DirectX.Direct3D;
using Interfaces.Rendering.Primitives;

namespace Interfaces.Rendering.Instancing
{
  public class InstanceCollection : WorldInstance, IList<Instance>, IInstanceable
  {
    private List<Instance> innerList = new List<Instance>();

    public int IndexOf(Instance item)
    {
      return innerList.IndexOf(item);
    }

    public void Insert(int index, Instance item)
    {
      innerList.Insert(index, item);
      UpdateProperties();
    }

    public void RemoveAt(int index)
    {
      innerList.RemoveAt(index);
      UpdateProperties();
    }

    public Instance this[int index]
    {
      get
      { return innerList[index]; }
      set
      {
        innerList[index] = value;
        UpdateProperties();
      }
    }

    public void Add(Instance item)
    {
      innerList.Add(item);
      UpdateProperties();
    }

    public void Clear()
    {
      innerList.Clear();
      UpdateProperties();
    }

    public bool Contains(Instance item)
    {
      return innerList.Contains(item);
    }

    public void CopyTo(Instance[] array, int arrayIndex)
    {
      innerList.CopyTo(array, arrayIndex);
    }

    public int Count
    {
      get
      { return innerList.Count; }
    }

    public bool IsReadOnly
    {
      get
      { return false; }
    }

    public bool Remove(Instance item)
    {
      bool flag = innerList.Remove(item);
      UpdateProperties();
      return flag;
    }

    public IEnumerator<Instance> GetEnumerator()
    {
      return innerList.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
      return (innerList as IEnumerable).GetEnumerator();
    }

    public void Sort()
    {
      innerList.Sort(new ViewerDistanceComparer());
      for (int i = 0; i < innerList.Count; i++)
        if (innerList[i] is InstanceCollection)
          (innerList[i] as InstanceCollection).Sort();
    }

    public override void Render()
    {
      base.Render();
      for (int i = 0; i < innerList.Count; i++)
        if (!(innerList[i] is ObjectInstance || innerList[i] is DynamicObjectInstance) || !innerList[i].OcclusionNode || MdxRender.Camera.VisibleBoundingBox(innerList[i].BoundingBox.Translate(X, Y, Z)))
          innerList[i].Render();
    }

    public override bool IntersectRayAABB(Vector3 origin, Vector3 direction)
    {
      for (int i = 0; i < innerList.Count; i++)
        if (innerList[i].IntersectRayAABB(origin, direction))
          return true;
      return false;
    }

    public override Intersection IntersectRay(Vector3 origin, Vector3 direction)
    {
      Intersection[] iis = new Intersection[innerList.Count];
      for (int i = 0; i < innerList.Count; i++)
        iis[i] = innerList[i].IntersectRay(origin, direction);

      int minIndex = -1;
      float min = Single.MaxValue;
      for (int i = 0; i < innerList.Count; i++)
      {
        if (iis[i] != null)
        {
          if (iis[i].Distance < min)
          {
            min = iis[i].Distance;
            minIndex = i;
          }
        }
      }

      if (minIndex < 0)
        return null;
      else
        return iis[minIndex];
    }

    public Instance Instance
    {
      get
      { return this; }
    }

    public InstanceCollection()
      : base(null, Vector3.Empty, BoundingBox.Zero)
    { /* sigh */ }

    private void UpdateProperties()
    {
      Vector3 sum = Vector3.Empty;
      for (int i = 0; i < innerList.Count; i++)
        sum += innerList[i].Centroid;
      sum.Scale(1.0f / (float)innerList.Count);
      centroid = sum;

      bounds = BoundingBox.Zero;
      for (int i = 0; i < innerList.Count; i++)
        bounds.Update(innerList[i].BoundingBox);
    }

    public override void OnDeviceLost()
    {
      base.OnDeviceLost();
      foreach (Instance child in innerList)
        child.OnDeviceLost();
    }

    public override void OnDeviceReset()
    {
      base.OnDeviceReset();
      foreach (Instance child in innerList)
        child.OnDeviceReset();
    }
  }
}
