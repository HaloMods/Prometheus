using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.DirectX;
using Interfaces.Rendering.Interfaces;
using Interfaces.Rendering.Wrappers;

namespace Interfaces.Rendering.Radiosity
{
  public class RadiosityModel : IModel
  {
    private BindingTransform transform;
    private Matrix Inverse;
    private IModel @base;

    public RadiosityModel(IModel model, BindingTransform transform)
    {
      @base = model; this.transform = transform;
      Inverse = Matrix.Invert(transform.matrix);
    }

    public IModel Model { get { return @base; } }
    public BindingTransform Transform
    {
      get { return transform; }
      set
      {
        if (transform != null) transform = value;
//#if DEBUG
        else throw new Exception("Invalid transform. Core.Radiosity.Wrapper.RadiosityModelInstance");
//#endif
      }
    }

    class RealEulerAngles3D : IAngle3D
    {
      #region IAngle3D Members

      public float Pitch
      {
        get;
        set;
      }

      public float Roll
      {
        get;
        set;
      }

      public float Yaw
      {
        get;
        set;
      }

      #endregion
    }
    class RealPoint3D : IPoint3D
    {
      #region IPoint3D Members

      public float X
      {
        get;
        set;
      }

      public float Y
      {
        get;
        set;
      }

      public float Z
      {
        get;
        set;
      }

      #endregion
    }
    private static Vector3 AnglesToVector(float p, float y, float r)
    {
      Vector3 angleTransform = AngleTransform(p, y, r, new Vector3(-1f, 0,0 ));
      return angleTransform;
    }
    private static Vector3 AngleTransform(float p, float y, float r, Vector3 angle)
    {
      RealEulerAngles3D angle3D = new RealEulerAngles3D();
      angle3D.Pitch = p;
      angle3D.Yaw = y;
      angle3D.Roll = r;
      BindingTransform transform = new BindingTransform(angle3D, new RealPoint3D());
      Vector4 vector = Vector3.Transform(new Vector3(-angle.X, angle.Y, angle.Z), transform.matrix);

      return new Vector3(vector.X, vector.Y, vector.Z);
    }

    public RadiosityIntersection Intersection(Microsoft.DirectX.Vector3 origin, Microsoft.DirectX.Vector3 direction)
    {
      Vector3 newDir = AngleTransform(transform.Pitch, transform.Yaw, transform.Roll, direction);

      direction = new Vector3(-direction.X, direction.Y, direction.Z);
      Vector3 closeVector = new Vector3(origin.X - transform.X, origin.Y - transform.Y, origin.Z - transform.Z);
      origin = new Vector3(-origin.X, origin.Y, origin.Z);

      Vector4 vector4 = Vector3.Transform(direction, transform.matrix);

      direction = new Vector3(vector4.X - transform.X, vector4.Y - transform.Y, vector4.Z - transform.Z);
      //direction.Normalize();
      //direction = newDir;
      vector4 = Vector3.Transform(origin, transform.matrix);
      origin = new Vector3(vector4.X, vector4.Y, vector4.Z);
      
      RadiosityIntersection m = @base.Intersection(direction, origin);
      //if (!m.NoIntersection)
      //  System.Diagnostics.Debugger.Break();
      vector4 = Vector3.Transform(m.Position, Inverse); 
      m.Position = new Vector3(-vector4.X, vector4.Y, vector4.Z);
      vector4 = Vector3.Transform(m.NewDirection, Inverse);
      m.NewDirection = new Vector3(-vector4.X, vector4.Y, vector4.Z);
      return m;
    }

    #region IModel Members

    public ModelType GetModelType
    {
      get { return Model.GetModelType; }
    }

    RadiosityIntersection IModel.Intersection(Microsoft.DirectX.Vector3 direction, Microsoft.DirectX.Vector3 origin)
    {
      return Intersection(origin, direction);
    }

    #endregion

    #region IRenderable Members

    public void Render()
    {
      //throw new Exception("The method or operation is not implemented.");
    }

    public bool IntersectRayAABB(Microsoft.DirectX.Vector3 origin, Microsoft.DirectX.Vector3 direction)
    {
      throw new Exception("The method or operation is not implemented.");
    }

    public Intersection IntersectRay(Microsoft.DirectX.Vector3 origin, Microsoft.DirectX.Vector3 direction)
    {
      Vector4 vector4 = Vector3.Transform(direction, transform.matrix);
      direction = new Vector3(vector4.X, vector4.Y, vector4.Z);
      vector4 = Vector3.Transform(origin, transform.matrix);
      origin = new Vector3(vector4.X, vector4.Y, vector4.Z);
      return Model.IntersectRay(origin, direction);
    }

    public int PixelFillCount
    {
      get
      {
        return 0;
      }
      set
      {
      }
    }

    public bool IntersectCamera(ICamera camera)
    {
      return false;
    }

    public bool IntersectPlaneAABB(IPlane plane)
    {
      return false;
    }

    #endregion

    #region IModel Members


    public List<ILight> RadiosityLights
    {
      get { throw new NotImplementedException(); }
    }

    #endregion
  }

  public class Ellipsoid
  {
    Vector2[] locusXY = new Vector2[2], locusXZ = new Vector2[2];
    float distanceXY, distanceXZ;
    Matrix transform;

    public Ellipsoid(Vector3 size, Vector3 center, Vector3 normal)
    {
      // calculate XY plane ellipse
      if (size.X > size.Y)
      {
        float radius = size.Y / 2;
        float halfSize = size.X / 2;

        locusXY[0] = new Vector2(center.X - halfSize + radius, center.Y);
        locusXY[1] = new Vector2(center.X + halfSize - radius, center.Y);
        distanceXY = radius + size.X - size.Y;
      }
      else
      {
        float radius = size.X / 2;
        float halfSize = size.Y / 2;

        locusXY[0] = new Vector2(center.X, center.Y - halfSize + radius);
        locusXY[1] = new Vector2(center.X, center.Y + halfSize - radius);
        distanceXY = radius + size.Y - size.X;
      }

      // calculate XZ plane ellipse
      if (size.X > size.Z)
      {
        float radius = size.Z / 2;
        float halfSize = size.X / 2;

        locusXY[0] = new Vector2(center.X - halfSize + radius, center.Z);
        locusXY[1] = new Vector2(center.X + halfSize - radius, center.Z);
        distanceXZ = radius + size.X - size.Z;
      }
      else
      {
        float radius = size.X / 2;
        float halfSize = size.Z / 2;

        locusXY[0] = new Vector2(center.X, center.Z - halfSize + radius);
        locusXY[1] = new Vector2(center.X, center.Z + halfSize - radius);
        distanceXZ = radius + size.Z - size.X;
      }

      transform = Matrix.RotationX((float)Math.Acos(Vector3.Dot(normal, new Vector3(1, 0, 0))));
      transform *= Matrix.RotationY((float)Math.Acos(Vector3.Dot(normal, new Vector3(0, 1, 0))));
      transform *= Matrix.RotationZ((float)Math.Acos(Vector3.Dot(normal, new Vector3(0, 0, 1))));
    }

    public bool PointInEllipse(Vector3 point)
    {
      Vector4 vector = Vector3.Transform(point, transform);
      Vector2 XZ = new Vector2(vector.X, vector.Z);
      Vector2 XY = new Vector2(vector.X, vector.Y);

      float distance1 = (locusXY[0] - XY).Length();
      float distance2 = (locusXY[1] - XY).Length();

      if (distance1 + distance2 > distanceXY)
        return false;

      distance1 = (locusXZ[0] - XZ).Length();
      distance2 = (locusXZ[1] - XZ).Length();

      return distance1 + distance2 <= distanceXZ;
    }
  }
}
