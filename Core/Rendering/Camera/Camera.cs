using System;
using Interfaces.Rendering.Utilties;
using Microsoft.DirectX;
using Interfaces.Rendering;
using Interfaces.Rendering.Primitives;
using Interfaces.Rendering.Interfaces;
using Interfaces.Options;
using System.Diagnostics;

namespace Core.Rendering.Camera
{
  /// <summary>
  /// Quaternion-based 3D camera.
  /// </summary>
  public class Camera : ICamera
  {
    private static float MIN_PITCH_RAD = -3.14f;
    private static float MAX_PITCH_RAD = 3.14f;
    private Matrix m_matView = new Matrix();
    private Matrix m_invView = new Matrix();
    private bool m_bNeedUpdated = true;
    private float m_fRPM = 30.0f;
    private float m_PitchAngle = 0;
    private float m_dt = 0.01f;
    private Plane[] viewFrustum = new Plane[6];

    private enum eOrient
    {
      cePitch,
      ceRoll,
      ceYaw
    }

    //public static float CameraSpeed
    //{
    //  get { return CameraTranslationPlane.CameraSpeed; }
    //  set { CameraTranslationPlane.CameraSpeed = value; }
    //}

    //new implementation
    private Vector3 m_LookVector = new Vector3();
    private Vector3 m_UpVector = new Vector3(0, 0, 1);
    private Vector3 m_PositionVector = new Vector3();

    public Vector3 NewSpawnLocation
    {
      get
      {
        float dist = 5.0f;
        return (new Vector3(m_PositionVector.X + LookVector.X * dist,
          m_PositionVector.Y + LookVector.Y * dist,
          m_PositionVector.Z + LookVector.Z * dist));
      }
    }
    public Vector3 LookVector
    {
      get { return m_LookVector; }
    }
    public Vector3 Position
    {
      get { return m_PositionVector; }

      set
      {
				m_PositionVector = value;
				m_bNeedUpdated = true;
      }
    }
    public Matrix InverseView
    {
      get { return m_invView; }
    }
    
    public Camera()
    {
      //translationControl.EnableTranslateMode();
      //RotationControl.EnableRotateMode();
      SetLookAt(new Vector3(-18, 0, 0), new Vector3());
    }

    public void SetLookAt(Vector3 vFrom, Vector3 vTo)
    {
      //we don't use the "up" vector since it is always assumed to be +Z

      //Calculate the baseline "look" quaternion
      m_LookVector.X = vTo.X - vFrom.X;
      m_LookVector.Y = vTo.Y - vFrom.Y;
      m_LookVector.Z = vTo.Z - vFrom.Z;
      m_LookVector.Normalize();

      m_PositionVector = vFrom;

      //reset Pitch tracking to match look vector
      float xy = (float)Math.Sqrt(m_LookVector.X * m_LookVector.X + m_LookVector.Y * m_LookVector.Y);
      m_PitchAngle = (float)Math.Atan(m_LookVector.Z / xy);

      m_bNeedUpdated = true;
    }
    public void SetFPS(float fps)
    {
      if (fps != 0)
      {
        m_dt = 1.0f / fps;

        //if(m_dt > 0.01)
        //  m_dt = 0.01f;
      }
    }
    public void Pitch(float fAngle)
    {
      float scale = (OptionManager.CameraSensitivity / 10f) * 4;

      float test_ang = m_PitchAngle + fAngle * scale;

      if ((test_ang > MIN_PITCH_RAD) && (test_ang < MAX_PITCH_RAD))
      {
        //fAngle *= RotationControl.Speed;
        m_PitchAngle += fAngle * scale;
        ApplyRotate(fAngle * scale, eOrient.cePitch);
      }
    }
    public void Yaw(float fAngle)
    {
      float scale = (OptionManager.CameraSensitivity / 10f) * 4;
      //fAngle *= RotationControl.Speed;
      ApplyRotate(fAngle * scale, eOrient.ceYaw);
    }

    private bool moved = false;
    private CameraTranslationPlane m_parallelTranslation = new CameraTranslationPlane();
    private CameraTranslationPlane m_perpendicularTranslation = new CameraTranslationPlane(0.75f);
    private CameraTranslationPlane m_verticalTranslation = new CameraTranslationPlane(0.75f);
    
    public void Move(float fDistance)
    {
      m_parallelTranslation.Drive += fDistance;
      moved = true;
    }
    public void Strafe(float fDistance)
    {
      m_perpendicularTranslation.Drive += fDistance;
      moved = true;
    }
    public void Up(float fDistance)
    {
      m_verticalTranslation.Drive += fDistance;
      moved = true;
    }
    public void Spin(float fDistance)
    {
      Yaw(fDistance * 2.5f * m_dt);
    }
    public Matrix GetViewMatrix()
    {
      if (m_bNeedUpdated)
        UpdateViewMatrix();
      return m_matView;
    }
    public void SetRPM(float fRPM)
    {
      m_fRPM = (fRPM < 0.0f) ? 0.0f : fRPM;
    }
    protected void UpdateViewMatrix()
    {
      m_matView = Matrix.LookAtRH(m_PositionVector, m_PositionVector + m_LookVector, m_UpVector);
      m_invView = Matrix.Invert(m_matView);
      // 3) Set flag to false, to save CPU
      m_bNeedUpdated = false;
    }

    public void Update()
    {
      m_parallelTranslation.Update(m_dt);
      m_perpendicularTranslation.Update(m_dt);
      m_verticalTranslation.Update(m_dt);
      
      m_parallelTranslation.Drive = 0;
      m_perpendicularTranslation.Drive = 0;
      m_verticalTranslation.Drive = 0;

      //Trace.WriteLine(string.Format("cam update:  FPS={0:F3} speed={1:F3}", m_dt, m_parallelTranslation.Speed));

      if (m_parallelTranslation.Speed != 0)
      {
        Vector3 vDir = -m_LookVector;
        if (!OptionManager.CameraZPitching)
          vDir.Z = 0;
        vDir.Normalize();
        m_PositionVector += vDir * (m_parallelTranslation.Speed * m_dt);
        m_bNeedUpdated = true;
      }
      if (m_perpendicularTranslation.Speed != 0)
      {
        Vector3 vDir = Vector3.Cross(m_LookVector, m_UpVector);
        vDir.Normalize();
        m_PositionVector += vDir * (m_perpendicularTranslation.Speed * m_dt);
        m_bNeedUpdated = true;
      }
      if (m_verticalTranslation.Speed != 0)
      {
        m_PositionVector += m_UpVector * (m_verticalTranslation.Speed * m_dt);
        m_bNeedUpdated = true;
      }
    }
    
    private void ApplyRotate(float fAngle, eOrient oeOrient)
    {
      fAngle *= (m_fRPM / 60); // angle * per minute rotation

      switch (oeOrient)
      {
        case eOrient.cePitch:
          {
            Vector3 Axis = Vector3.Cross(m_LookVector, m_UpVector);
            RotateCamera(fAngle, Axis);
            break;
          }
        case eOrient.ceRoll:
          {
            break;
          }
        case eOrient.ceYaw:
          {
            RotateCamera(fAngle, m_UpVector);
            break;
          }
      }

      m_bNeedUpdated = true;
    }
    private void RotateCamera(float Angle, Vector3 axis)
    {
      Quaternion conj;
      Quaternion temp = new Quaternion();
      Quaternion quat_view = new Quaternion();

      temp.X = axis.X * (float)Math.Sin(Angle / 2);
      temp.Y = axis.Y * (float)Math.Sin(Angle / 2);
      temp.Z = axis.Z * (float)Math.Sin(Angle / 2);
      temp.W = (float)Math.Cos(Angle / 2);
      temp.Normalize();

      quat_view.X = m_LookVector.X;
      quat_view.Y = m_LookVector.Y;
      quat_view.Z = m_LookVector.Z;
      quat_view.W = 0;
      //normalize?

      conj = temp;
      conj.Invert();

      temp.Multiply(quat_view);
      temp.Multiply(conj);

      m_LookVector.X = temp.X;
      m_LookVector.Y = temp.Y;
      m_LookVector.Z = temp.Z;
    }
    public void UpdateCameraByCentroid(BoundingBox bb)
    {
      Vector3 centroid = new Vector3();
      bb.GetCentroid(out centroid.X, out centroid.Y, out centroid.Z);

      SetLookAt(new Vector3(centroid.X - 10, centroid.Y - 10, centroid.Z + 4), centroid);
    }
    public void UpdateCameraByBoundingBox(BoundingBox bb, float scale, float speed)
    {
      float tx, ty, tz;
      float fx, fy, fz;
      float sizex, sizey, sizez, maxdim;

      //calculate centroid for the "to" vector
      bb.GetCenter(out tx, out ty, out tz);

      //calculate appropriate "from" vector
      sizex = bb.max[0] - bb.min[0];
      sizey = bb.max[1] - bb.min[1];
      sizez = bb.max[2] - bb.min[2];

      maxdim = sizex;
      if (sizey > maxdim)
        maxdim = sizey;
      if (sizez > maxdim)
        maxdim = sizez;

      fx = scale * maxdim;
      fy = ty;
      fz = tz;

      //SpeedControl.m_fSpeed = speed;

      SetLookAt(new Vector3(fx, fy, fz), new Vector3(tx, ty, tz));
    }
    /// <summary>
    /// Calculates the distance between the camera and the specified point.
    /// </summary>
    public float GetObjectDistance(float x, float y, float z)
    {
      //todo: optimize by using squared dist for LOD cutoff
      float dx = m_PositionVector.X - x;
      float dy = m_PositionVector.Y - y;
      float dz = m_PositionVector.Z - z;
      float dist = (float)Math.Sqrt(dx * dx + dy * dy + dz * dz);

      return (dist);
    }
    public void GetFrustumPlanes(int StartX, int StartY, int StopX, int StopY, out Plane[] FrustumPlanes)
    {
      FrustumPlanes = new Plane[6];
      Vector3 temp;
      Vector3 direction;
      Vector3 plane_norm;
      Vector3 pt = new Vector3();

      //make sure StartX < StartY, StopX < StopY
      if (StartY > StopY)
      {
        int tmp = StopY;
        StopY = StartY;
        StartY = tmp;
      }

      if (StartX > StopX)
      {
        int tmp = StopX;
        StopX = StartX;
        StartX = tmp;
      }

      for (int i = 0; i < 6; i++)
        FrustumPlanes[i] = new Plane();

      //near
      FrustumPlanes[0].A = LookVector.X;
      FrustumPlanes[0].B = LookVector.Y;
      FrustumPlanes[0].C = LookVector.Z;
      FrustumPlanes[0].Normalize();
      pt.X = m_PositionVector.X + m_LookVector.X * 0.1f;
      pt.Y = m_PositionVector.Y + m_LookVector.Y * 0.1f;
      pt.Z = m_PositionVector.Z + m_LookVector.Z * 0.1f;
      CalculatePlaneDist(ref FrustumPlanes[0], pt);

      //far
      FrustumPlanes[1].A = -LookVector.X;
      FrustumPlanes[1].B = -LookVector.Y;
      FrustumPlanes[1].C = -LookVector.Z;
      FrustumPlanes[1].Normalize();
      pt.X = m_PositionVector.X + m_LookVector.X * 30f;
      pt.Y = m_PositionVector.Y + m_LookVector.Y * 30;
      pt.Z = m_PositionVector.Z + m_LookVector.Z * 30f;
      CalculatePlaneDist(ref FrustumPlanes[1], pt);

      //i think the cross between the direction and up vectors will give the plane normal
      //but that may only be for a cases where the look vector is right in the center of the
      //screen

      //right
      MdxRender.CalculatePickRayWorld(StartX, 0, out direction, out temp);
      plane_norm = Vector3.Cross(direction, m_UpVector);
      plane_norm.Normalize();
      FrustumPlanes[2].A = plane_norm.X;
      FrustumPlanes[2].B = plane_norm.Y;
      FrustumPlanes[2].C = plane_norm.Z;
      CalculatePlaneDist(ref FrustumPlanes[2], m_PositionVector);

      //left
      MdxRender.CalculatePickRayWorld(StopX, 0, out direction, out temp);
      plane_norm = -Vector3.Cross(direction, m_UpVector);
      plane_norm.Normalize();
      FrustumPlanes[3].A = plane_norm.X;
      FrustumPlanes[3].B = plane_norm.Y;
      FrustumPlanes[3].C = plane_norm.Z;
      CalculatePlaneDist(ref FrustumPlanes[3], m_PositionVector);

      Vector3 left_vec;
      left_vec = Vector3.Cross(m_UpVector, m_LookVector);

      //top
      MdxRender.CalculatePickRayWorld(0, StopY, out direction, out temp);
      plane_norm = Vector3.Cross(direction, left_vec);
      plane_norm.Normalize();
      FrustumPlanes[4].A = plane_norm.X;
      FrustumPlanes[4].B = plane_norm.Y;
      FrustumPlanes[4].C = plane_norm.Z;
      CalculatePlaneDist(ref FrustumPlanes[4], m_PositionVector);

      //bottom
      MdxRender.CalculatePickRayWorld(0, StartY, out direction, out temp);
      plane_norm = -Vector3.Cross(direction, left_vec);
      plane_norm.Normalize();
      FrustumPlanes[5].A = plane_norm.X;
      FrustumPlanes[5].B = plane_norm.Y;
      FrustumPlanes[5].C = plane_norm.Z;
      CalculatePlaneDist(ref FrustumPlanes[5], m_PositionVector);
    }

    private void CalculatePlaneDist(ref Plane p, Vector3 PointOnPlane)
    {
      p.Normalize();
      p.D = -(p.A * PointOnPlane.X + p.B * PointOnPlane.Y + p.C * PointOnPlane.Z);
    }

    //FrustumPlane[] frustumPlanes = new FrustumPlane[6];
    public void CalculateViewFrustum()
    {
      Matrix worldSpace = m_matView * RenderCore.CurrentProjectionMatrix;
      viewFrustum[0] /* left */ = new Plane(worldSpace.M14 + worldSpace.M11, worldSpace.M24 + worldSpace.M21, worldSpace.M34 + worldSpace.M31, worldSpace.M44 + worldSpace.M41);
      viewFrustum[1] /* right */ = new Plane(worldSpace.M14 - worldSpace.M11, worldSpace.M24 - worldSpace.M21, worldSpace.M34 - worldSpace.M31, worldSpace.M44 - worldSpace.M41);
      viewFrustum[2] /* lower */ = new Plane(worldSpace.M14 + worldSpace.M12, worldSpace.M24 + worldSpace.M22, worldSpace.M34 + worldSpace.M32, worldSpace.M44 + worldSpace.M42);
      viewFrustum[3] /* upper */ = new Plane(worldSpace.M14 - worldSpace.M12, worldSpace.M24 - worldSpace.M22, worldSpace.M34 - worldSpace.M32, worldSpace.M44 - worldSpace.M42);
      viewFrustum[4] /* near */ = new Plane(worldSpace.M13, worldSpace.M23, worldSpace.M33, worldSpace.M43);
      viewFrustum[5] /* far */ = new Plane(worldSpace.M14 - worldSpace.M13, worldSpace.M24 - worldSpace.M23, worldSpace.M34 - worldSpace.M33, worldSpace.M44 - worldSpace.M43);

      #region Grenadiac's Implementation
      /*
      // Get combined matrix
      Matrix matrixComb = Matrix.Multiply(m_matView, RenderCore.CurrentProjectionMatrix);

      // Left clipping plane
      frustumPlanes[0] = new FrustumPlane();
      frustumPlanes[0].Normal = new Vector3(matrixComb.M14 + matrixComb.M11,
        matrixComb.M24 + matrixComb.M21,
        matrixComb.M34 + matrixComb.M31);
      frustumPlanes[0].Distance = matrixComb.M44 + matrixComb.M41;

      // Right clipping plane
      frustumPlanes[1] = new FrustumPlane();
      frustumPlanes[1].Normal = new Vector3(matrixComb.M14 - matrixComb.M11,
        matrixComb.M24 - matrixComb.M21,
        matrixComb.M34 - matrixComb.M31);
      frustumPlanes[1].Distance = matrixComb.M44 - matrixComb.M41;

      // Top clipping plane
      frustumPlanes[2] = new FrustumPlane();
      frustumPlanes[2].Normal = new Vector3(matrixComb.M14 - matrixComb.M12,
        matrixComb.M24 - matrixComb.M22,
        matrixComb.M34 - matrixComb.M32);
      frustumPlanes[2].Distance = matrixComb.M44 - matrixComb.M42;

      // Bottom clipping plane
      frustumPlanes[3] = new FrustumPlane();
      frustumPlanes[3].Normal = new Vector3(matrixComb.M14 + matrixComb.M12,
        matrixComb.M24 + matrixComb.M23,
        matrixComb.M34 + matrixComb.M33);
      frustumPlanes[3].Distance = matrixComb.M44 + matrixComb.M42;

      // Near clipping plane
      frustumPlanes[4] = new FrustumPlane();
      frustumPlanes[4].Normal = new Vector3(matrixComb.M13, matrixComb.M23, matrixComb.M33);
      frustumPlanes[4].Distance = matrixComb.M43;

      // Far clipping plane
      frustumPlanes[5] = new FrustumPlane();
      frustumPlanes[5].Normal = new Vector3(matrixComb.M14 - matrixComb.M13,
        matrixComb.M23 - matrixComb.M21,
        matrixComb.M33 - matrixComb.M31);
      frustumPlanes[5].Distance = matrixComb.M44 - matrixComb.M43;
      */
      #endregion
    }

    public bool VisibleBoundingBox(BoundingBox box)
    {
      Vector3[] vertices = box.Vertices;
      for (byte p = 0; p < 6; p++)
      {
        for (byte v = 0; v < 8; v++)
          if (VisibilityTestPoint(vertices[v], viewFrustum[p]))
            goto NoEscape;
        return false;
      NoEscape: ;
      }
      return true;
    }

    public bool VisibleBoundingSphere(Vector3 position, float radius)
    {
      for (byte p = 0; p < 6; p++)
        if (!VisibilityTestSphere(position, radius, viewFrustum[p]))
          return false;
      return true;
    }

    private bool VisibilityTestPoint(Vector3 position, Plane plane)
    { return Plane.DotNormal(plane, position) + plane.D >= 0.0f; }

    private bool VisibilityTestSphere(Vector3 position, float radius, Plane plane)
    { return Plane.DotNormal(plane, position) + plane.D > -Math.Abs(radius); }

    public bool Moved
    {
      get
      { return moved; }
      set
      { moved = value; }
    }

    #region Old Frustum Cull Method
    /*
    /// <summary>
    /// Taking an AABB min and max in world space, work out its interaction with the view frustum.
    /// Note: the viewing frustum must be calculated first
    /// </summary>
    /// <returns>0 is outside, 1 is partially in, 2 is completely within.</returns>
    public int CullAABB(Vector3 aabbMin, Vector3 aabbMax)
    {
      bool intersect = false;
      int result;
      Vector3 minExtreme, maxExtreme;

      for (int i = 0; i < 6; i++)
      {
        if (frustumPlanes[i].Normal.X <= 0)
        {
          minExtreme.X = aabbMin.X;
          maxExtreme.X = aabbMax.X;
        }
        else
        {
          minExtreme.X = aabbMax.X;
          maxExtreme.X = aabbMin.X;
        }

        if (frustumPlanes[i].Normal.Y <= 0)
        {
          minExtreme.Y = aabbMin.Y;
          maxExtreme.Y = aabbMax.Y;
        }
        else
        {
          minExtreme.Y = aabbMax.Y;
          maxExtreme.Y = aabbMin.Y;
        }

        if (frustumPlanes[i].Normal.Z <= 0)
        {
          minExtreme.Z = aabbMin.Z;
          maxExtreme.Z = aabbMax.Z;
        }
        else
        {
          minExtreme.Z = aabbMax.Z;
          maxExtreme.Z = aabbMin.Z;
        }

        if (frustumPlanes[i].DistanceToPoint(minExtreme) > 0)
        {
          result = 0;
          return result;
        }

        if (frustumPlanes[i].DistanceToPoint(maxExtreme) >= 0)
          intersect = true;
      }

      if (intersect)
        result = 1;
      else
        result = 2;

      return result;
    }
    */
    #endregion
  }
}
