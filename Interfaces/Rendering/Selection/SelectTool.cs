using System;
using System.Diagnostics;
using System.IO;
using System.Drawing;
using Microsoft.DirectX;
using Microsoft.DirectX.Direct3D;
using Interfaces.Factory.CommonTypes;

namespace Interfaces.Rendering.Selection
{
  /// <summary>
  /// Summary description for SelectTool.
  /// </summary>
  public class SelectTool
  {
    #region Tool Members
    private static float Scale = 1.0f;
    public EditMode m_Mode = EditMode.NotSelected;
    //private int m_Counter = 0;

    private Matrix m_WorldSpaceTransform;
    private Matrix m_ModelSpaceTransform;

    private Vector3 m_EditTranslationStart = new Vector3();
    private BindingAngle3 m_EditRotationStart = new BindingAngle3();
    private BindingAngle3 m_MouseDownAngle = new BindingAngle3();

    private Plane m_EditAxisTestPlane = new Plane();

    private static CustomVertex.PositionOnly[] m_XAxis = new CustomVertex.PositionOnly[2];
    private static CustomVertex.PositionOnly[] m_XAxisY = new CustomVertex.PositionOnly[2];
    private static CustomVertex.PositionOnly[] m_XAxisZ = new CustomVertex.PositionOnly[2];

    private static CustomVertex.PositionOnly[] m_YAxis = new CustomVertex.PositionOnly[2];
    private static CustomVertex.PositionOnly[] m_YAxisX = new CustomVertex.PositionOnly[2];
    private static CustomVertex.PositionOnly[] m_YAxisZ = new CustomVertex.PositionOnly[2];

    private static CustomVertex.PositionOnly[] m_ZAxis = new CustomVertex.PositionOnly[2];
    private static CustomVertex.PositionOnly[] m_ZAxisX = new CustomVertex.PositionOnly[2];
    private static CustomVertex.PositionOnly[] m_ZAxisY = new CustomVertex.PositionOnly[2];

    private static Mesh m_XAxisTip;
    private static Mesh m_YAxisTip;
    private static Mesh m_ZAxisTip;
    private static Mesh m_XYPlane;
    private static Mesh m_XZPlane;
    private static Mesh m_YZPlane;
    private static Mesh m_Selector;

    private static Material m_BlueX;
    private static Material m_RedZ;
    private static Material m_GreenY;
    private static Material m_Gray;
    private static Material m_Yellow;
    private static Material m_SelectorColor;

    private static ArcHandle m_PitchHandle = new ArcHandle();
    private static ArcHandle m_RollHandle = new ArcHandle();
    private static ArcHandle m_YawHandle = new ArcHandle();
    #endregion

    public SelectTool()
    {
    }
    public Matrix WorldSpaceTransform
    {
      get { return m_WorldSpaceTransform; }
    }

    #region Tool Rendering
    public static void TransformMesh(Mesh mesh, Matrix transform)
    {

      CustomVertex.PositionNormal[] tmp = new CustomVertex.PositionNormal[mesh.NumberVertices];
      Vector3 pos = new Vector3();
      Vector3 norm = new Vector3();
      using (VertexBuffer vb = mesh.VertexBuffer)
      {
        GraphicsStream vertexData = vb.Lock(0, 0, LockFlags.None);
        BinaryReader br = new BinaryReader(vertexData);
        for (int v = 0; v < mesh.NumberVertices; v++)
        {
          pos.X = br.ReadSingle();
          pos.Y = br.ReadSingle();
          pos.Z = br.ReadSingle();
          norm.X = br.ReadSingle();
          norm.Y = br.ReadSingle();
          norm.Z = br.ReadSingle();
          pos.TransformCoordinate(transform);
          norm.TransformNormal(transform);
          tmp[v] = new CustomVertex.PositionNormal(pos.X, pos.Y, pos.Z, norm.X, norm.Y, norm.Z);
        }
        vb.Unlock();
      }

      mesh.SetVertexBufferData(tmp, LockFlags.None);
    }
    public static void EnableExtendedAxes(bool bLongX, bool bLongY, bool bLongZ)
    {
      if (bLongX)
      {
        m_XAxis[0] = new CustomVertex.PositionOnly(-100, 0, 0);
        m_XAxis[1] = new CustomVertex.PositionOnly(100, 0, 0);
      }
      else
      {
        m_XAxis[0] = new CustomVertex.PositionOnly(0.35f * Scale, 0, 0);
        m_XAxis[1] = new CustomVertex.PositionOnly(Scale, 0, 0);
      }

      if (bLongY)
      {
        m_YAxis[0] = new CustomVertex.PositionOnly(0, -100, 0);
        m_YAxis[1] = new CustomVertex.PositionOnly(0, 100, 0);
      }
      else
      {
        m_YAxis[0] = new CustomVertex.PositionOnly(0, 0.35f * Scale, 0);
        m_YAxis[1] = new CustomVertex.PositionOnly(0, Scale, 0);
      }

      if (bLongZ)
      {
        m_ZAxis[0] = new CustomVertex.PositionOnly(0, 0, -100);
        m_ZAxis[1] = new CustomVertex.PositionOnly(0, 0, 100);
      }
      else
      {
        m_ZAxis[0] = new CustomVertex.PositionOnly(0, 0, 0.35f * Scale);
        m_ZAxis[1] = new CustomVertex.PositionOnly(0, 0, Scale);
      }
    }
    public static void InitializeHandleModel()
    {
      m_SelectorColor = new Material();
      m_SelectorColor.Ambient = Color.DarkGray;
      m_SelectorColor.Diffuse = Color.DarkGray;

      m_GreenY = new Material();
      m_GreenY.Ambient = Color.Green;
      m_GreenY.Diffuse = Color.Green;

      m_Gray = new Material();
      m_Gray.Ambient = Color.Gray;
      m_Gray.Diffuse = Color.Gray;

      m_BlueX = new Material();
      m_BlueX.Ambient = Color.Blue;
      m_BlueX.Diffuse = Color.Blue;

      m_RedZ = new Material();
      m_RedZ.Ambient = Color.Red;
      m_RedZ.Diffuse = Color.Red;

      Color transparent_yellow = Color.Yellow;
      m_Yellow = new Material();
      m_Yellow.Ambient = Color.Yellow;
      m_Yellow.Diffuse = Color.Yellow;

      m_XAxis[0] = new CustomVertex.PositionOnly(0.35f * Scale, 0, 0);
      m_XAxis[1] = new CustomVertex.PositionOnly(Scale, 0, 0);
      m_XAxisY[0] = new CustomVertex.PositionOnly(0.5f * Scale, 0, 0);
      m_XAxisY[1] = new CustomVertex.PositionOnly(0.5f * Scale, 0.5f * Scale, 0);
      m_XAxisZ[0] = new CustomVertex.PositionOnly(0.5f * Scale, 0, 0);
      m_XAxisZ[1] = new CustomVertex.PositionOnly(0.5f * Scale, 0, 0.5f * Scale);

      m_YAxis[0] = new CustomVertex.PositionOnly(0, 0.35f * Scale, 0);
      m_YAxis[1] = new CustomVertex.PositionOnly(0, Scale, 0);
      m_YAxisX[0] = new CustomVertex.PositionOnly(0, 0.5f * Scale, 0);
      m_YAxisX[1] = new CustomVertex.PositionOnly(0.5f * Scale, 0.5f * Scale, 0);
      m_YAxisZ[0] = new CustomVertex.PositionOnly(0, 0.5f * Scale, 0);
      m_YAxisZ[1] = new CustomVertex.PositionOnly(0, 0.5f * Scale, 0.5f * Scale);

      m_ZAxis[0] = new CustomVertex.PositionOnly(0, 0, 0.35f * Scale);
      m_ZAxis[1] = new CustomVertex.PositionOnly(0, 0, Scale);
      m_ZAxisX[0] = new CustomVertex.PositionOnly(0, 0, 0.5f * Scale);
      m_ZAxisX[1] = new CustomVertex.PositionOnly(0.5f * Scale, 0, 0.5f * Scale);
      m_ZAxisY[0] = new CustomVertex.PositionOnly(0, 0, 0.5f * Scale);
      m_ZAxisY[1] = new CustomVertex.PositionOnly(0, 0.5f * Scale, 0.5f * Scale);


      m_Selector = Mesh.Sphere(MdxRender.Device, 0.05f * Scale, 8, 4);

      Matrix rotate = new Matrix();
      Matrix translate = new Matrix();
      Matrix scale = new Matrix();
      Matrix overall_transform = new Matrix();

      //x-axis
      rotate.RotateY((float)Math.PI / 2);
      translate.Translate(1 * Scale, 0, 0);
      overall_transform = Matrix.Multiply(rotate, translate);

      m_XAxisTip = Mesh.Cylinder(MdxRender.Device, 0.05f * Scale, 0f, 0.3f * Scale, 6, 1);
      TransformMesh(m_XAxisTip, overall_transform);

      //y-axis
      rotate.RotateX((float)Math.PI / -2);
      translate.Translate(0, 1 * Scale, 0);
      overall_transform = Matrix.Multiply(rotate, translate);

      m_YAxisTip = Mesh.Cylinder(MdxRender.Device, 0.05f * Scale, 0f, 0.3f * Scale, 6, 1);
      TransformMesh(m_YAxisTip, overall_transform);

      //z-axis
      rotate.RotateZ((float)Math.PI / -2);
      translate.Translate(0, 0, 1 * Scale);
      overall_transform = Matrix.Multiply(rotate, translate);

      m_ZAxisTip = Mesh.Cylinder(MdxRender.Device, 0.05f * Scale, 0f, 0.3f * Scale, 6, 1);
      TransformMesh(m_ZAxisTip, overall_transform);

      m_XYPlane = Mesh.Box(MdxRender.Device, 0.5f * Scale, 0.5f * Scale, 0.001f * Scale);
      translate.Translate(0.25f * Scale, 0.25f * Scale, 0);
      TransformMesh(m_XYPlane, translate);

      m_XZPlane = Mesh.Box(MdxRender.Device, 0.5f * Scale, 0.001f * Scale, 0.5f * Scale);
      translate.Translate(0.25f * Scale, 0, 0.25f * Scale);
      TransformMesh(m_XZPlane, translate);

      m_YZPlane = Mesh.Box(MdxRender.Device, 0.001f * Scale, 0.5f * Scale, 0.5f * Scale);
      translate.Translate(0, 0.25f * Scale, 0.25f * Scale);
      TransformMesh(m_YZPlane, translate);


      m_PitchHandle.InitializeModel(ArcMode.Pitch);
      m_RollHandle.InitializeModel(ArcMode.Roll);
      m_YawHandle.InitializeModel(ArcMode.Yaw);
      EnableExtendedAxes(true, true, true);
    }
    public static void OnResetDevice()
    {
      m_PitchHandle.OnResetDevice();
      m_RollHandle.OnResetDevice();
      m_YawHandle.OnResetDevice();
    }
    public static void OnLostDevice()
    {
      m_PitchHandle.OnDeviceLost();
      m_RollHandle.OnDeviceLost();
      m_YawHandle.OnDeviceLost();
    }
    public void DrawXAxis(bool bActive, bool bY, bool bZ)
    {
      if (bActive)
        MdxRender.Device.Material = m_Yellow;
      else
        MdxRender.Device.Material = m_BlueX;

      MdxRender.Device.RenderState.ZBufferEnable = true;
      MdxRender.Device.DrawUserPrimitives(PrimitiveType.LineList, 1, m_XAxis);
      MdxRender.Device.RenderState.ZBufferEnable = false;

      MdxRender.Device.Material = m_BlueX;
      MdxRender.Device.RenderState.Ambient = Color.Gray;
      m_XAxisTip.DrawSubset(0);

      MdxRender.Device.RenderState.Ambient = Color.White;

      if (bY)
        MdxRender.Device.Material = m_Yellow;
      else
        MdxRender.Device.Material = m_BlueX;

      MdxRender.Device.DrawUserPrimitives(PrimitiveType.LineList, 1, m_XAxisY);

      if (bZ)
        MdxRender.Device.Material = m_Yellow;
      else
        MdxRender.Device.Material = m_BlueX;

      MdxRender.Device.DrawUserPrimitives(PrimitiveType.LineList, 1, m_XAxisZ);
    }
    public void DrawYAxis(bool bActive, bool bX, bool bZ)
    {
      if (bActive)
        MdxRender.Device.Material = m_Yellow;
      else
        MdxRender.Device.Material = m_GreenY;
      MdxRender.Device.RenderState.ZBufferEnable = true;
      MdxRender.Device.DrawUserPrimitives(PrimitiveType.LineList, 1, m_YAxis);
      MdxRender.Device.RenderState.ZBufferEnable = false;

      MdxRender.Device.Material = m_GreenY;
      MdxRender.Device.RenderState.Ambient = Color.Gray;
      m_YAxisTip.DrawSubset(0);

      MdxRender.Device.RenderState.Ambient = Color.White;

      if (bX)
        MdxRender.Device.Material = m_Yellow;
      else
        MdxRender.Device.Material = m_GreenY;

      MdxRender.Device.DrawUserPrimitives(PrimitiveType.LineList, 1, m_YAxisX);

      if (bZ)
        MdxRender.Device.Material = m_Yellow;
      else
        MdxRender.Device.Material = m_GreenY;

      MdxRender.Device.DrawUserPrimitives(PrimitiveType.LineList, 1, m_YAxisZ);
    }
    public void DrawZAxis(bool bActive, bool bX, bool bY)
    {
      if (bActive)
        MdxRender.Device.Material = m_Yellow;
      else
        MdxRender.Device.Material = m_RedZ;

      MdxRender.Device.RenderState.ZBufferEnable = true;
      MdxRender.Device.DrawUserPrimitives(PrimitiveType.LineList, 1, m_ZAxis);
      MdxRender.Device.RenderState.ZBufferEnable = false;
      MdxRender.Device.Material = m_RedZ;
      MdxRender.Device.RenderState.Ambient = Color.Gray;
      m_ZAxisTip.DrawSubset(0);

      MdxRender.Device.RenderState.Ambient = Color.White;

      if (bX)
        MdxRender.Device.Material = m_Yellow;
      else
        MdxRender.Device.Material = m_RedZ;

      MdxRender.Device.DrawUserPrimitives(PrimitiveType.LineList, 1, m_ZAxisX);

      if (bY)
        MdxRender.Device.Material = m_Yellow;
      else
        MdxRender.Device.Material = m_RedZ;

      MdxRender.Device.DrawUserPrimitives(PrimitiveType.LineList, 1, m_ZAxisY);
    }
    public void DrawXYPlane(bool bActive)
    {
      if (bActive)
      {
        //TODO:
        //if (MdxRender.DeviceInfo.caps.SourceBlendCaps.SupportsBlendFactor)
        //{
        //  MdxRender.Device.RenderState.BlendFactor = Color.Gray;
        //  MdxRender.Device.RenderState.SourceBlend = Blend.BlendFactor;
        //  MdxRender.Device.RenderState.DestinationBlend = Blend.InvBlendFactor;
        //  MdxRender.Device.RenderState.AlphaBlendEnable = true;
        //}

        MdxRender.Device.Material = m_Yellow;
        m_XYPlane.DrawSubset(0);

        //TODO:
        //if (MdxRender.DeviceInfo.caps.SourceBlendCaps.SupportsBlendFactor)
        //{
        //  MdxRender.Device.RenderState.AlphaBlendEnable = false;
        //}
      }
    }
    public void DrawXZPlane(bool bActive)
    {
      if (bActive)
      {
        //TODO:
        //if (MdxRender.DeviceInfo.caps.SourceBlendCaps.SupportsBlendFactor)
        //{
        //  MdxRender.Device.RenderState.BlendFactor = Color.Gray;
        //  MdxRender.Device.RenderState.SourceBlend = Blend.BlendFactor;
        //  MdxRender.Device.RenderState.DestinationBlend = Blend.InvBlendFactor;
        //  MdxRender.Device.RenderState.AlphaBlendEnable = true;
        //}

        MdxRender.Device.Material = m_Yellow;
        m_XZPlane.DrawSubset(0);

        //TODO:
        //if (MdxRender.DeviceInfo.caps.SourceBlendCaps.SupportsBlendFactor)
        //{
        //  MdxRender.Device.RenderState.AlphaBlendEnable = false;
        //}
      }
      else
      {
      }
    }
    public void DrawYZPlane(bool bActive)
    {
      if (bActive)
      {
        //TODO:
        //if (MdxRender.DeviceInfo.caps.SourceBlendCaps.SupportsBlendFactor)
        //{
        //  MdxRender.Device.RenderState.BlendFactor = Color.Gray;
        //  MdxRender.Device.RenderState.SourceBlend = Blend.BlendFactor;
        //  MdxRender.Device.RenderState.DestinationBlend = Blend.InvBlendFactor;
        //  MdxRender.Device.RenderState.AlphaBlendEnable = true;
        //}

        MdxRender.Device.Material = m_Yellow;
        m_YZPlane.DrawSubset(0);

        //TODO:
        //if (MdxRender.DeviceInfo.caps.SourceBlendCaps.SupportsBlendFactor)
        //{
        //  MdxRender.Device.RenderState.AlphaBlendEnable = false;
        //}
      }
    }

    public void Render(Matrix WorldTransform, bool bEditActive)
    {
      if (m_Mode != EditMode.NotSelected)
      {
        m_WorldSpaceTransform = Matrix.Identity;
        m_WorldSpaceTransform.M41 = WorldTransform.M41;
        m_WorldSpaceTransform.M42 = WorldTransform.M42;
        m_WorldSpaceTransform.M43 = WorldTransform.M43;
        m_ModelSpaceTransform = WorldTransform;

        MdxRender.Device.RenderState.Ambient = Color.White;

        MdxRender.Device.Transform.World = m_WorldSpaceTransform;
        MdxRender.ConfigureForDiffuseColor();
        MdxRender.Device.RenderState.AlphaBlendEnable = false;
        MdxRender.Device.RenderState.CullMode = Cull.None;
        MdxRender.Device.RenderState.DiffuseMaterialSource = ColorSource.Material;
        MdxRender.Device.RenderState.Lighting = true;

        if (m_Mode != EditMode.NotSelected)
        {
          MdxRender.Device.RenderState.ZBufferEnable = false;
          MdxRender.Device.Material = m_SelectorColor;
          m_Selector.DrawSubset(0);
          MdxRender.Device.RenderState.ZBufferEnable = true;
        }
        MdxRender.Device.RenderState.ZBufferEnable = false;
        switch (m_Mode)
        {
          case EditMode.NotSelected:
            break;

          case EditMode.Selected:
            MdxRender.Device.Material = m_SelectorColor;
            break;

          case EditMode.IdleTranslate:
            DrawXAxis(false, false, false);
            DrawYAxis(false, false, false);
            DrawZAxis(false, false, false);
            MdxRender.Device.Material = m_SelectorColor;
            break;

          case EditMode.IdleRotate:
            MdxRender.Device.Material = m_BlueX;
            m_PitchHandle.RenderArc(0, 0);
            MdxRender.Device.Material = m_GreenY;
            m_RollHandle.RenderArc(0, 0);
            MdxRender.Device.Material = m_RedZ;
            m_YawHandle.RenderArc(0, 0);
            break;

          case EditMode.MoveXY:
            DrawXYPlane(true);
            DrawXAxis(false, true, false);
            DrawYAxis(false, true, false);
            DrawZAxis(false, false, false);
            break;

          case EditMode.MoveYZ:
            DrawYZPlane(true);
            DrawXAxis(false, false, false);
            DrawYAxis(false, false, true);
            DrawZAxis(false, false, true);
            break;

          case EditMode.MoveXZ:
            DrawXZPlane(true);
            DrawXAxis(false, false, true);
            DrawYAxis(false, false, false);
            DrawZAxis(false, true, false);
            break;

          case EditMode.MoveDX:
            DrawXAxis(true, false, false);
            DrawYAxis(false, false, false);
            DrawZAxis(false, false, false);
            break;

          case EditMode.MoveDY:
            DrawXAxis(false, false, false);
            DrawYAxis(true, false, false);
            DrawZAxis(false, false, false);
            break;

          case EditMode.MoveDZ:
            DrawXAxis(false, false, false);
            DrawYAxis(false, false, false);
            DrawZAxis(true, false, false);
            break;

          case EditMode.Pitch:
            MdxRender.Device.Material = m_Yellow;
            m_PitchHandle.RenderArc(0, 0);
            if (bEditActive)
              m_PitchHandle.RenderPie(m_MouseDownAngle.Pitch, m_EditRotationStart.Pitch - m_MouseDownAngle.Pitch);

            MdxRender.Device.Material = m_GreenY;
            m_RollHandle.RenderArc(0, 0);
            MdxRender.Device.Material = m_RedZ;
            m_YawHandle.RenderArc(0, 0);
            break;
          case EditMode.Roll:
            MdxRender.Device.Material = m_BlueX;
            m_PitchHandle.RenderArc(0, 0);
            MdxRender.Device.Material = m_Yellow;
            m_RollHandle.RenderArc(0, 0);
            if (bEditActive)
              m_RollHandle.RenderPie(m_MouseDownAngle.Roll, m_EditRotationStart.Roll - m_MouseDownAngle.Roll);

            MdxRender.Device.Material = m_RedZ;
            m_YawHandle.RenderArc(0, 0);
            break;
          case EditMode.Yaw:
            MdxRender.Device.Material = m_BlueX;
            m_PitchHandle.RenderArc(0, 0);
            MdxRender.Device.Material = m_GreenY;
            m_RollHandle.RenderArc(0, 0);
            MdxRender.Device.Material = m_Yellow;
            m_YawHandle.RenderArc(0, 0);
            if (bEditActive)
              m_YawHandle.RenderPie(m_MouseDownAngle.Yaw, m_EditRotationStart.Yaw - m_MouseDownAngle.Yaw);
            break;
        }

        MdxRender.DisableBlend();
        MdxRender.Device.RenderState.Ambient = Color.Gray;
        //MdxRender.Device.RenderState.Lighting = true;
        MdxRender.Device.RenderState.ZBufferEnable = true;
        MdxRender.Device.Transform.World = WorldTransform;
      }
    }
    #endregion

    #region Tool Interaction
    public void MouseDown_StartEdit(Matrix WorldTransform, Vector3 origin, Vector3 direction, bool bLog)
    {
      Vector3 t_org = new Vector3();
      Vector3 t_dir = new Vector3();

      //transform pick ray into model space (only for rotation)
      if (ModeIsRotation() == true)
      {
        Matrix inv = new Matrix();
        inv = m_WorldSpaceTransform;
        inv.Invert();

        t_org = origin;
        t_dir = direction;
        t_org.TransformCoordinate(inv);
        t_dir.TransformNormal(inv);
      }

      //select best test plane if we are using x,y,z direct movement
      //larger dot product indicates larger incidence angle
      Vector3 look = MdxRender.Camera.LookVector;
      float xplane_score = (float)Math.Abs(Vector3.Dot(look, new Vector3(1, 0, 0)));
      float yplane_score = (float)Math.Abs(Vector3.Dot(look, new Vector3(0, 1, 0)));
      float zplane_score = (float)Math.Abs(Vector3.Dot(look, new Vector3(0, 0, 1)));

      switch (m_Mode)
      {
        case EditMode.Pitch:
          m_EditRotationStart.Pitch = m_PitchHandle.MouseDown_StartEdit(t_org, t_dir);
          m_MouseDownAngle.Pitch = m_EditRotationStart.Pitch;
          break;

        case EditMode.Roll:
          m_EditRotationStart.Roll = m_RollHandle.MouseDown_StartEdit(t_org, t_dir);
          m_MouseDownAngle.Roll = m_EditRotationStart.Roll;
          break;

        case EditMode.Yaw:
          m_EditRotationStart.Yaw = m_YawHandle.MouseDown_StartEdit(t_org, t_dir);
          m_MouseDownAngle.Yaw = m_EditRotationStart.Yaw;
          break;

        case EditMode.MoveDX:
          if (yplane_score > zplane_score)
            m_EditAxisTestPlane = new Plane(0, 1, 0, m_ModelSpaceTransform.M42);
          else
            m_EditAxisTestPlane = new Plane(0, 0, 1, m_ModelSpaceTransform.M43);

          PMath.RayIntersectPlane(origin, direction, m_EditAxisTestPlane, out m_EditTranslationStart);
          break;

        case EditMode.MoveDY:
          if (xplane_score > zplane_score)
            m_EditAxisTestPlane = new Plane(1, 0, 0, m_ModelSpaceTransform.M41);
          else
            m_EditAxisTestPlane = new Plane(0, 0, 1, m_ModelSpaceTransform.M43);

          PMath.RayIntersectPlane(origin, direction, m_EditAxisTestPlane, out m_EditTranslationStart);
          break;

        case EditMode.MoveDZ:
          if (xplane_score > yplane_score)
            m_EditAxisTestPlane = new Plane(1, 0, 0, m_ModelSpaceTransform.M41);
          else
            m_EditAxisTestPlane = new Plane(0, 1, 0, m_ModelSpaceTransform.M42);

          PMath.RayIntersectPlane(origin, direction, m_EditAxisTestPlane, out m_EditTranslationStart);
          break;

        case EditMode.MoveXY:
          m_EditAxisTestPlane = new Plane(0, 0, 1, m_ModelSpaceTransform.M43);
          PMath.RayIntersectPlane(origin, direction, m_EditAxisTestPlane, out m_EditTranslationStart);
          break;

        case EditMode.MoveXZ:
          m_EditAxisTestPlane = new Plane(0, 1, 0, m_ModelSpaceTransform.M42);
          PMath.RayIntersectPlane(origin, direction, m_EditAxisTestPlane, out m_EditTranslationStart);
          break;

        case EditMode.MoveYZ:
          m_EditAxisTestPlane = new Plane(1, 0, 0, m_ModelSpaceTransform.M41);
          PMath.RayIntersectPlane(origin, direction, m_EditAxisTestPlane, out m_EditTranslationStart);
          break;
      }

      Trace.WriteLine(string.Format("sPitch = {0:N3}  sRoll = {1:N3}  sYaw = {2:N3}",
        m_EditRotationStart.Pitch,
        m_EditRotationStart.Roll,
        m_EditRotationStart.Yaw));
    }
    private bool ModeIsRotation()
    {
      bool bRotate = false;
      if ((m_Mode == EditMode.IdleRotate) ||
        (m_Mode == EditMode.Pitch) ||
        (m_Mode == EditMode.Roll) ||
        (m_Mode == EditMode.Yaw))
        bRotate = true;

      return (bRotate);
    }
    public void HoverEdit(Vector3 origin, Vector3 direction, out Vector3 trans_delta, out BindingAngle3 rot_delta)
    {
      Vector3 t_org = new Vector3();
      Vector3 t_dir = new Vector3();

      //transform pick ray into model space (only for rotation)
      if (ModeIsRotation() == true)
      {
        Matrix inv = new Matrix();
        inv = m_WorldSpaceTransform;
        inv.Invert();

        t_org = origin;
        t_dir = direction;
        t_org.TransformCoordinate(inv);
        t_dir.TransformNormal(inv);
      }

      Vector3 intersect_point = new Vector3();
      BindingAngle3 rotation_edit = new BindingAngle3();
      BindingAngle3 temp = new BindingAngle3();
      rot_delta = temp;

      trans_delta.X = 0;
      trans_delta.Y = 0;
      trans_delta.Z = 0;
      rot_delta.Pitch = 0;
      rot_delta.Roll = 0;
      rot_delta.Yaw = 0;

      switch (m_Mode)
      {
        case EditMode.Pitch:
          rotation_edit.Pitch = m_PitchHandle.HoverEdit(t_org, t_dir);
          rot_delta.Pitch = rotation_edit.Pitch - m_EditRotationStart.Pitch;
          m_EditRotationStart.Pitch = rotation_edit.Pitch;
          //rotation_edit.Roll =  m_PitchHandle.HoverEdit(t_org, t_dir);
          //rot_delta.Roll = rotation_edit.Roll - m_EditRotationStart.Roll;
          //m_EditRotationStart.Roll = rotation_edit.Roll;
          break;

        case EditMode.Roll:
          rotation_edit.Roll = m_RollHandle.HoverEdit(t_org, t_dir);
          rot_delta.Roll = rotation_edit.Roll - m_EditRotationStart.Roll;
          m_EditRotationStart.Roll = rotation_edit.Roll;
          //rotation_edit.Pitch =  m_RollHandle.HoverEdit(t_org, t_dir);
          //rot_delta.Pitch = rotation_edit.Pitch - m_EditRotationStart.Pitch;
          //m_EditRotationStart.Pitch = rotation_edit.Pitch;
          break;

        case EditMode.Yaw:
          rotation_edit.Yaw = m_YawHandle.HoverEdit(t_org, t_dir);
          rot_delta.Yaw = rotation_edit.Yaw - m_EditRotationStart.Yaw;

          //          if(Math.Abs(rot_delta.Yaw) > 0.5)
          //          {
          //            int j=0;
          //          }
          m_EditRotationStart.Yaw = rotation_edit.Yaw;
          break;

        case EditMode.MoveDX:
          PMath.RayIntersectPlane(origin, direction, m_EditAxisTestPlane, out intersect_point);
          intersect_point.Y = m_EditTranslationStart.Y;
          intersect_point.Z = m_EditTranslationStart.Z;
          trans_delta = intersect_point - m_EditTranslationStart;
          m_EditTranslationStart = intersect_point;
          break;

        case EditMode.MoveDY:
          PMath.RayIntersectPlane(origin, direction, m_EditAxisTestPlane, out intersect_point);
          intersect_point.X = m_EditTranslationStart.X;
          intersect_point.Z = m_EditTranslationStart.Z;
          trans_delta = intersect_point - m_EditTranslationStart;
          m_EditTranslationStart = intersect_point;
          break;

        case EditMode.MoveDZ:
          PMath.RayIntersectPlane(origin, direction, m_EditAxisTestPlane, out intersect_point);
          intersect_point.X = m_EditTranslationStart.X;
          intersect_point.Y = m_EditTranslationStart.Y;
          trans_delta = intersect_point - m_EditTranslationStart;
          m_EditTranslationStart = intersect_point;
          break;

        case EditMode.MoveXY:
          PMath.RayIntersectPlane(origin, direction, m_EditAxisTestPlane, out intersect_point);
          intersect_point.Z = m_EditTranslationStart.Z;
          trans_delta = intersect_point - m_EditTranslationStart;
          m_EditTranslationStart = intersect_point;
          break;

        case EditMode.MoveXZ:
          PMath.RayIntersectPlane(origin, direction, m_EditAxisTestPlane, out intersect_point);
          intersect_point.Y = m_EditTranslationStart.Y;
          trans_delta = intersect_point - m_EditTranslationStart;
          m_EditTranslationStart = intersect_point;
          break;

        case EditMode.MoveYZ:
          PMath.RayIntersectPlane(origin, direction, m_EditAxisTestPlane, out intersect_point);
          intersect_point.X = m_EditTranslationStart.X;
          trans_delta = intersect_point - m_EditTranslationStart;
          m_EditTranslationStart = intersect_point;
          break;
      }

      //if((Math.Abs(rot_delta.Pitch) > 0.001)||(Math.Abs(rot_delta.Roll) > 0.001)||(Math.Abs(rot_delta.Yaw) > 0.5))
      //  Trace.WriteLine(string.Format("droll={0}  dpitch={1}  dyaw={2}",
      //    rot_delta.Pitch,
      //    rot_delta.Roll,
      //    rot_delta.Yaw));
    }
    public void Hover(Vector3 t_origin, Vector3 t_direction)
    {
      if ((m_Mode == EditMode.NotSelected) || (m_Mode == EditMode.Selected))
      {
        //do nothing
      }
      else if (ModeIsRotation() == true)
      {
        float closest_prox = 100;
        float pitch_prox = m_PitchHandle.Hover(t_origin, t_direction);
        float roll_prox = m_RollHandle.Hover(t_origin, t_direction);
        float yaw_prox = m_YawHandle.Hover(t_origin, t_direction);


        //get the closest intersection
        EditMode tmp = EditMode.IdleRotate;

        if ((pitch_prox < 0.2f) && (pitch_prox >= 0))
        {
          closest_prox = pitch_prox;
          tmp = EditMode.Pitch;
        }

        if ((roll_prox < 0.2f) && (roll_prox >= 0) && (roll_prox < closest_prox))
        {
          closest_prox = roll_prox;
          tmp = EditMode.Roll;
        }

        if ((yaw_prox < 0.2f) && (yaw_prox >= 0) && (yaw_prox < closest_prox))
        {
          closest_prox = yaw_prox;
          tmp = EditMode.Yaw;
        }

        //if((m_Counter++ % 20) == 0)
        //  Trace.WriteLine(string.Format("pitchprx: {0} rollprx: {1} yaw_prox: {2}", pitch_prox, roll_prox, yaw_prox) + tmp.ToString());

        m_Mode = tmp;
      }
      else
      {
        if (m_XAxisTip.Intersect(t_origin, t_direction))
        {
          m_Mode = EditMode.MoveDX;
        }
        else if (m_YAxisTip.Intersect(t_origin, t_direction))
        {
          m_Mode = EditMode.MoveDY;
        }
        else if (m_ZAxisTip.Intersect(t_origin, t_direction))
        {
          m_Mode = EditMode.MoveDZ;
        }
        else if (m_XYPlane.Intersect(t_origin, t_direction))
        {
          m_Mode = EditMode.MoveXY;
        }
        else if (m_XZPlane.Intersect(t_origin, t_direction))
        {
          m_Mode = EditMode.MoveXZ;
        }
        else if (m_YZPlane.Intersect(t_origin, t_direction))
        {
          m_Mode = EditMode.MoveYZ;
        }
        else
        {
          m_Mode = EditMode.IdleTranslate;
        }
      }
    }
    #endregion
  }
}