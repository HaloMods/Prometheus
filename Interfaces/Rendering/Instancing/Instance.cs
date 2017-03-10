using System;
using Microsoft.DirectX;
using Microsoft.DirectX.Direct3D;
using Interfaces.Rendering.Interfaces;
using Interfaces.Rendering.Wrappers;
using Interfaces.Rendering.Primitives;
using Interfaces.Rendering.Selection;

namespace Interfaces.Rendering.Instancing
{
    /// <summary>
    /// Represents an instance of some renderable entity in 3d space. This class is abstract.
    /// </summary>
  public abstract class Instance : IRenderable, IRenderStateModifier
  {
    protected bool update = false;
    protected bool stationary = false;
    protected bool transparent = false;
    protected bool occlusionNode = false;
    protected Vector3 centroid = Vector3.Empty;
    protected BoundingBox bounds = new BoundingBox();
    protected IRenderable entity = null;
    protected int pixelFillCount;
    protected IRenderStateModifier modifier = null;
    private TargetType targetType = TargetType.None;

    /// <summary>
    /// Creates a new instance of the derived Instance class.
    /// </summary>
    public Instance(IRenderable entity, Vector3 centroid, BoundingBox boundingBox)
    {
      this.entity = entity;
      this.centroid = centroid;
      this.bounds = boundingBox;
    }

    /// <summary>
    /// Provides a means to cache transforms information in the case that it is unchanged.
    /// </summary>
    protected virtual void Update()
    { /* Method Stub */ }

    /// <summary>
    /// Exposes a method that is used to draw the instance. Must be inherited by derived classes.
    /// </summary>
    public abstract void Render();

    /// <summary>
    /// Intersects a ray with the mesh.
    /// </summary>
    public virtual Intersection IntersectRay(Vector3 origin, Vector3 direction)
    {
      return entity.IntersectRay(origin, direction);
    }

    /// <summary>
    /// Intersects a ray with the entity's bounding box.
    /// </summary>
    public virtual bool IntersectRayAABB(Vector3 origin, Vector3 direction)
    {
      return entity.IntersectRayAABB(origin, direction);
    }
    
    /// <summary>
    /// Gets a BoundingBox object that may be used to cull this object.
    /// </summary>
    public virtual BoundingBox BoundingBox
    {
      get
      { return bounds; }
    }

    /// <summary>
    /// Gets the centroid of the entity translated by the position.
    /// </summary>
    public virtual Vector3 Centroid
    {
      get
      { return new Vector3(centroid.X/* + x*/, centroid.Y/* + y*/, centroid.Z/* + z*/); }
    }

    /// <summary>
    /// Gets the pixel Fill Count.
    /// </summary>
    public int PixelFillCount
    {
      get { return pixelFillCount; }
      set { pixelFillCount = value; }
    }

    /// <summary>
    /// Gets or sets the transparency state of this instance, used by sorting methods.
    /// </summary>
    public bool Transparent
    {
      get
      { return transparent; }
      set
      { transparent = value; }
    }

    /// <summary>
    /// Gets or sets whether or not this Instance should be tested against the viewing frustum and culled.
    /// </summary>
    public bool OcclusionNode
    {
      get
      { return occlusionNode; }
      set
      { occlusionNode = value; }
    }

    public virtual void OnDeviceReset()
    { /* Method stub. */ }

    public virtual void OnDeviceLost()
    { /* Method stub. */ }

    public bool IntersectCamera(ICamera Camera)
    {
      throw new Exception("The method or operation is not implemented.");
    }

    public bool IntersectPlaneAABB(IPlane Plane)
    {
      throw new Exception("The method or operation is not implemented.");
    }

    public void ModifyStateBeforeScene()
    {
      if (modifier != null)
        modifier.ModifyStateBeforeScene();
    }

    public void ModifyStateAfterScene()
    {
      if (modifier != null)
        modifier.ModifyStateAfterScene();
    }

    public TargetType TargetType
    {
      get
      { return targetType; }
      set
      { targetType = value; }
    }
  }
}
