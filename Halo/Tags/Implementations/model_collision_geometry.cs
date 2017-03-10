using System;
using System.Collections.Generic;
using Microsoft.DirectX;
using Microsoft.DirectX.Direct3D;
using Interfaces.Rendering;
using Interfaces.Rendering.Instancing;
using Interfaces.Rendering.Interfaces;
using Interfaces.Rendering.Primitives;
using Interfaces.Rendering.Wrappers;
using Interfaces.Rendering.Radiosity;

namespace Games.Halo.Tags.Classes
{
  public partial class model_collision_geometry : IModel, IInstanceable
  {
    //public const bool UseTwoLevelBoundingBox = true;
    BoundingBox modelBoundingBox;
    BoundingBox[/* nodes */] nodeBoundingBox;

    //public EnhancedMesh[/* nodes */][/* bsps */] meshes;

    public override void DoPostProcess()
    {
      modelBoundingBox = new BoundingBox();
      nodeBoundingBox = new BoundingBox[modelCollisionGeometryValues.Nodes.Count];
      int nodeIndex = 0;
      foreach (NodeBlock node in modelCollisionGeometryValues.Nodes)
      {
        nodeBoundingBox[nodeIndex] = new BoundingBox();
        int bspIndex = 0;
        foreach (BspBlock bsp in node.Bsps)
        {
          for (int x = 0; x < bsp.Vertices.Count; x++)
          {
            modelBoundingBox.Update(bsp.Vertices[x].Point.X, bsp.Vertices[x].Point.Y, bsp.Vertices[x].Point.Z);
            nodeBoundingBox[nodeIndex].Update(bsp.Vertices[x].Point.X, bsp.Vertices[x].Point.Y, bsp.Vertices[x].Point.Z);
          }
          
        }
        nodeIndex++;
      }
    }

    #region IModel Members

    public ModelType GetModelType
    {
      get { return ModelType.Collision; }
    }

    public Interfaces.Rendering.Radiosity.RadiosityIntersection Intersection(Vector3 direction, Vector3 origin)
    {
      //TODO: First check for bounding box collision.
      Interfaces.Rendering.Radiosity.RadiosityIntersection intersect = RadiosityIntersect(origin, direction);

      intersect.Scale = 1.0f;
      intersect.LightmapIndex = -1;

      return intersect;
    }

    #endregion

    #region IRenderable Members

    public void Render()
    {
    }

    public bool IntersectRayAABB(Vector3 origin, Vector3 direction)
    {
      throw new Exception("The method or operation is not implemented.");
    }

    public Intersection IntersectRay(Vector3 origin, Vector3 direction)
    {
      return RadiosityIntersect(origin, direction);
    }
    private Interfaces.Rendering.Radiosity.RadiosityIntersection RadiosityIntersect(Vector3 origin, Vector3 direction)
    {
      if (direction.Length() != 1)
        direction.Normalize();
      // TODO: Check bounding box for model, then for each node, then for each bsp.

      Interfaces.Rendering.Radiosity.RadiosityIntersection closest = RadiosityIntersection.None;

      // if (ax + by + cz == -D) then COLLISION
      foreach (NodeBlock node in modelCollisionGeometryValues._nodesList)
      {
        foreach (BspBlock bsp in node.Bsps)
        {
          //cosAlpha = DotProduct( 
          //         vnRayVector ,  vnPlaneNormal );
          // if (cosAlpha==0) return -1.0f;
          // deltaD = planeD - 
          //         DotProduct(vRayOrigin,vnPlaneNormal);
          //     return (deltaD/cosAlpha);
          int surfaceIndex = 0;
          foreach (SurfaceBlock surface in bsp.Surfaces)
          {
            RadiosityIntersection tempIntersect = Ray.IntersectRayOnPlane(new Ray(origin, direction), new Plane(bsp.Planes[surface.Plane.Value].Plane.I, bsp.Planes[surface.Plane.Value].Plane.J, bsp.Planes[surface.Plane.Value].Plane.K, bsp.Planes[surface.Plane.Value].Plane.D));

            if ((bool)tempIntersect)
            {

              if (closest != RadiosityIntersection.None)
                if (closest.Distance < tempIntersect.Distance)
                  continue;

              closest = tempIntersect;
            }
          }
        }
      }
      return closest;
    }

    int pixelFillCount = 0;
    public int PixelFillCount
    {
      get
      {
        return pixelFillCount;
      }
      set
      {
        pixelFillCount = value;
      }
    }

    public bool IntersectCamera(ICamera camera)
    {
      throw new Exception("The method or operation is not implemented.");
    }

    public bool IntersectPlaneAABB(IPlane plane)
    {
      throw new Exception("The method or operation is not implemented.");
    }

    #endregion

    #region IInstanceable Members

    public Instance Instance
    {
      get 
      {
        InstanceCollection newCollection = new InstanceCollection();

        ObjectInstance oi = new ObjectInstance(this, Vector3.Empty, BoundingBox.Zero);
        newCollection.Add(oi);
        newCollection.TargetType = Interfaces.Rendering.Selection.TargetType.Object;

        return newCollection;
      }
    }

    #endregion

    #region IRenderable Members

    void IRenderable.Render()
    {
      throw new Exception("The method or operation is not implemented.");
    }

    bool IRenderable.IntersectRayAABB(Vector3 origin, Vector3 direction)
    {
      throw new Exception("The method or operation is not implemented.");
    }

    Intersection IRenderable.IntersectRay(Vector3 origin, Vector3 direction)
    {
      throw new Exception("The method or operation is not implemented.");
    }

    int IRenderable.PixelFillCount
    {
      get
      {
        throw new Exception("The method or operation is not implemented.");
      }
      set
      {
        throw new Exception("The method or operation is not implemented.");
      }
    }

    bool IRenderable.IntersectCamera(ICamera camera)
    {
      throw new Exception("The method or operation is not implemented.");
    }

    bool IRenderable.IntersectPlaneAABB(IPlane plane)
    {
      throw new Exception("The method or operation is not implemented.");
    }

    #endregion

    #region IModel Members


    public List<ILight> RadiosityLights
    {
      get { throw new NotImplementedException(); }
    }

    #endregion
  }
}
