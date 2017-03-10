using System;
using Interfaces.Pool;
using Interfaces.Rendering.Instancing;
using Interfaces.Rendering.Interfaces;
using Interfaces.Rendering.Wrappers;
using Microsoft.DirectX;
using Microsoft.DirectX.Direct3D;

namespace Games.Halo.Tags.Classes
{
  public partial class @object : IDynamicObject, IInstanceable
  {
    private int pixelCount = 0;
    private int[] permutations = null;
    private IInstanceable modelTag = null;
    private model_collision_geometry collisionModel;
    //private IModel model;

    public model_collision_geometry CollisionModel
    {
      get { return collisionModel; }
    }

    public IModel ModelTag
    {
      get { return modelTag as IModel; }
    }

    public InstanceCollection DynamicInstances
    {
      get
      {
        if (modelTag == null)
          return new InstanceCollection();
        else
        {
          if (modelTag is IRenderable)
            (modelTag as IRenderable).PixelFillCount = pixelCount;
          Instance modelInstance = null;
          if (permutations == null)
          {
            modelInstance = modelTag.Instance;
            if (modelTag is model)
              permutations = (modelTag as model).CurrentPermutations;
            else if (modelTag is gbxmodel)
              permutations = (modelTag as gbxmodel).CurrentPermutations;
          }
          else
          {
            if (modelTag is model)
              modelInstance = (modelTag as model).GetPermutation(permutations);
            else if (modelTag is gbxmodel)
              modelInstance = (modelTag as gbxmodel).GetPermutation(permutations);
          }
          if (modelInstance is InstanceCollection)
            return modelInstance as InstanceCollection;
          else
          {
            InstanceCollection collection = new InstanceCollection();
            collection.Add(modelInstance);
            return collection;
          }
        }
      }
    }

    public Instance Instance
    {
      get
      { return new DynamicObjectInstance(this, DynamicInstances.Centroid, DynamicInstances.BoundingBox); }
    }

    public override void DoPostProcess()
    {
      base.DoPostProcess();
      modelTag = OpenModel(objectValues.Model.Value, objectValues.Model.TagGroup);
      collisionModel = Open<model_collision_geometry>(objectValues.CollisionModel.Value);
    }

    public override void Dispose()
    {
      base.Dispose();
      if (modelTag is Tag)
        Release(modelTag as Tag);
      if (modelTag is IDisposable)
        (modelTag as IDisposable).Dispose();
      if (collisionModel is Tag)
        Release(collisionModel);
    }

    protected IInstanceable OpenModel(string name, string type)
    {
      switch (type)
      {
        case "mode":
          return Open<model>(name);
        case "mod2":
          return Open<gbxmodel>(name);
        default:
          throw new HaloException("'{0}' is not a known model type.", type);
      }
    }

    public int ColorSourceCount
    {
      get
      { return objectValues.ChangeColors.Count; }
    }

    public int GetColorPermutation(int source)
    {
      if (source < 0)
        throw new ArgumentException("Change color permutation source cannot be less than 0.", "source");
      else if (source > ColorSourceCount)
        throw new ArgumentException("Change color permutation source was greater than source count.", "source");

      int permutation = -1;
      float currentValue = -1.0f;
      for (int i = 0; i < objectValues.ChangeColors[source].Permutations.Count; i++)
      {
        float value = (float)Random.NextDouble() * (objectValues.ChangeColors[source].Permutations[i].Weight.Value / (float)(i + 1));
        if (value > currentValue)
        {
          currentValue = value;
          permutation = i;
        }
      }

      return permutation;
    }

    public ColorValue GetColor(int source, int permutation, float interpolator)
    {
      if (objectValues.ChangeColors[source].Permutations.Count == 0)
        return Interpolate(objectValues.ChangeColors[source].ColorLowerBound.R, objectValues.ChangeColors[source].ColorLowerBound.G, objectValues.ChangeColors[source].ColorLowerBound.B, objectValues.ChangeColors[source].ColorUpperBound.R, objectValues.ChangeColors[source].ColorUpperBound.G, objectValues.ChangeColors[source].ColorUpperBound.B, interpolator);
      else
        return Interpolate(objectValues.ChangeColors[source].Permutations[permutation].ColorLowerBound.R, objectValues.ChangeColors[source].Permutations[permutation].ColorLowerBound.G, objectValues.ChangeColors[source].Permutations[permutation].ColorLowerBound.B, objectValues.ChangeColors[source].Permutations[permutation].ColorUpperBound.R, objectValues.ChangeColors[source].Permutations[permutation].ColorUpperBound.G, objectValues.ChangeColors[source].Permutations[permutation].ColorUpperBound.B, interpolator);
    }

    protected ColorValue Interpolate(float r1, float g1, float b1, float r2, float g2, float b2, float interpolator)
    { return new ColorValue(Interpolate(r1, r2, interpolator), Interpolate(g1, g2, interpolator), Interpolate(b1, b2, interpolator)); }

    protected float Interpolate(float x, float y, float s)
    { return x + s * (y - x); }

    public float[] OutputFunctions
    {
      get
      { throw new Exception("The method or operation is not implemented."); }
    }

    public void Render()
    {
      if (modelTag != null)
        modelTag.Instance.Render();
    }

    public bool IntersectRayAABB(Vector3 origin, Vector3 direction)
    {
      if (modelTag == null)
        return false;
      else
        return modelTag.Instance.IntersectRayAABB(origin, direction);
    }

    public Intersection IntersectRay(Vector3 origin, Vector3 direction)
    {
      if (modelTag == null)
        return null;
      else
        return modelTag.Instance.IntersectRay(origin, direction);
    }

    public int PixelFillCount
    {
      get
      { return pixelCount; }
      set
      { pixelCount = value; }
    }

    public bool IntersectCamera(ICamera camera)
    {
      if (modelTag == null)
        return false;
      else
        return modelTag.Instance.IntersectCamera(camera);
    }

    public bool IntersectPlaneAABB(IPlane plane)
    {
      if (modelTag == null)
        return false;
      else
        return modelTag.Instance.IntersectPlaneAABB(plane);
    }
  }
}
