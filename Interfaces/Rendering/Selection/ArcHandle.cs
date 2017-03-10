using System;
using System.Drawing;
using Microsoft.DirectX;
using Microsoft.DirectX.Direct3D;
using Interfaces.Rendering.Interfaces;

namespace Interfaces.Rendering.Selection
{
  public class ArcHandle
  {
    #region Arc Members
    private static int CircleVertCount = 100;
    private static float RadiusScale = 0.5f;
    private ArcMode m_Mode = ArcMode.Pitch;

    private CustomVertex.PositionOnly[] m_Verts = null;

    private short[] m_Arc = new short[CircleVertCount - 1];
    private short[] m_Pie = new short[(CircleVertCount - 1) * 3];
    private VertexBuffer m_VertexBuffer;
    private IndexBuffer m_ArcIndexBuffer;
    private IndexBuffer m_PieIndexBuffer;

    private CustomVertex.PositionOnly[] m_IntersectPoint = new CustomVertex.PositionOnly[2];
    #endregion

    #region Arc Rendering
    public void InitializeModel(ArcMode mode)
    {
      m_IntersectPoint[0] = new CustomVertex.PositionOnly();
      m_IntersectPoint[1] = new CustomVertex.PositionOnly();

      m_Mode = mode;
      //Set up rotation handles
      m_Verts = new CustomVertex.PositionOnly[CircleVertCount + 1];

      float dc = 2f * (float)Math.PI / (CircleVertCount - 2);
      float arc = 0;
      float a, b;

      m_Verts[CircleVertCount] = new CustomVertex.PositionOnly(0, 0, 0);
      for (int i = 0; i < CircleVertCount; i++)
      {
        b = (float)(RadiusScale * Math.Cos(arc));
        a = (float)(RadiusScale * Math.Sin(arc));

        switch (m_Mode)
        {
          case ArcMode.Pitch:
            m_Verts[i] = new CustomVertex.PositionOnly(0, b, a);
            break;
          case ArcMode.Roll:
            m_Verts[i] = new CustomVertex.PositionOnly(a, 0, b);
            break;
          case ArcMode.Yaw:
            m_Verts[i] = new CustomVertex.PositionOnly(b, a, 0);
            break;
        }
        arc += dc;
      }

      for (short i = 0; i < CircleVertCount - 1; i++)
      {
        m_Arc[i] = i;

        m_Pie[i * 3] = (short)CircleVertCount;
        m_Pie[i * 3 + 1] = i;
        m_Pie[i * 3 + 2] = (short)(i + 1);
      }

      m_VertexBuffer = new VertexBuffer(typeof(CustomVertex.PositionOnly), m_Verts.Length, MdxRender.Device,
        Usage.WriteOnly, CustomVertex.PositionOnly.Format, Microsoft.DirectX.Direct3D.Pool.Default);
      m_VertexBuffer.Created += new EventHandler(this.OnVertexBufferCreate);
      OnVertexBufferCreate(m_VertexBuffer, null);

      m_ArcIndexBuffer = new IndexBuffer(typeof(short), m_Arc.Length, MdxRender.Device, 
        Usage.WriteOnly, Microsoft.DirectX.Direct3D.Pool.Default);
      m_ArcIndexBuffer.Created += new EventHandler(this.OnArcIndexBufferCreate);
      OnArcIndexBufferCreate(m_ArcIndexBuffer, null);

      m_PieIndexBuffer = new IndexBuffer(typeof(short), m_Pie.Length, MdxRender.Device, 
        Usage.WriteOnly, Microsoft.DirectX.Direct3D.Pool.Default);
      m_PieIndexBuffer.Created += new EventHandler(this.OnPieIndexBufferCreate);
      OnPieIndexBufferCreate(m_PieIndexBuffer, null);
    }
    private void OnArcIndexBufferCreate(object sender, EventArgs e)
    {
      IndexBuffer buffer = (IndexBuffer)sender;
      buffer.SetData(m_Arc, 0, LockFlags.None);
    }
    private void OnPieIndexBufferCreate(object sender, EventArgs e)
    {
      IndexBuffer buffer = (IndexBuffer)sender;
      buffer.SetData(m_Pie, 0, LockFlags.None);
    }
    private void OnVertexBufferCreate(object sender, EventArgs e)
    {
      VertexBuffer vb = (VertexBuffer)sender;
      GraphicsStream data = vb.Lock(0, 0, LockFlags.None);

      for (int v = 0; v < m_Verts.Length; v++)
        data.Write(m_Verts[v]);

      vb.Unlock();
    }
    private void DebugRenderCutPlane()
    {
      float x, y, z;
      float a=0, b=0, c=0;
      int angle_start = 0, angle_stop = 0;
      CustomVertex.PositionOnly[] cross_line = new CustomVertex.PositionOnly[2];

      a = -MdxRender.Camera.LookVector.X;
      b = -MdxRender.Camera.LookVector.Y;
      c = -MdxRender.Camera.LookVector.Z;

      //Calculate cut plane intersect points
      switch (m_Mode)
      {
        case ArcMode.Pitch:
          z = (float)Math.Sqrt((RadiusScale * RadiusScale) / ((c * c) / (b * b) + 1.0));
          y = -(c / b) * z;
          x = 0;
          cross_line[0] = new CustomVertex.PositionOnly(x, y, z);
          cross_line[1] = new CustomVertex.PositionOnly(-x, -y, -z);
          angle_start = (int)((GetQuadrantAngle(y, z) / (Math.PI * 2)) * CircleVertCount - 1);
          angle_stop = (int)((GetQuadrantAngle(-y, -z) / (Math.PI * 2)) * CircleVertCount - 1);
          break;

        case ArcMode.Roll:
          z = (float)Math.Sqrt((RadiusScale * RadiusScale) / ((c * c) / (a * a) + 1.0));
          x = -(c / a) * z;
          y = 0;
          cross_line[0] = new CustomVertex.PositionOnly(x, y, z);
          cross_line[1] = new CustomVertex.PositionOnly(-x, -y, -z);
          angle_start = (int)((GetQuadrantAngle(x, z) / (Math.PI * 2)) * CircleVertCount - 1);
          angle_stop = (int)((GetQuadrantAngle(-x, -z) / (Math.PI * 2)) * CircleVertCount - 1);
          break;

        case ArcMode.Yaw:
          y = (float)Math.Sqrt((RadiusScale * RadiusScale) / ((b * b) / (a * a) + 1.0));
          x = -(b / a) * y;
          z = 0;
          cross_line[0] = new CustomVertex.PositionOnly(x, y, z);
          cross_line[1] = new CustomVertex.PositionOnly(-x, -y, -z);
          angle_start = (int)((GetQuadrantAngle(y, x) / (Math.PI * 2)) * CircleVertCount - 1);
          angle_stop = (int)((GetQuadrantAngle(-y, -x) / (Math.PI * 2)) * CircleVertCount - 1);
          break;
      }

      MdxRender.Device.DrawUserPrimitives(PrimitiveType.LineList, 1, cross_line);
      //      MdxRender.Dev.VertexFormat = CustomVertex.PositionOnly.Format;
      //      MdxRender.Dev.Indices = m_ArcIndexBuffer;
      //      MdxRender.Dev.SetStreamSource(0, m_VertexBuffer, 0);
      //      if(angle_stop > angle_start)
      //        MdxRender.Dev.DrawIndexedPrimitives(PrimitiveType.LineStrip, 0, 0, m_Verts.Length, angle_start*2, angle_stop-angle_start);
    }
    public void RenderArc(float RadStart, float RadEnd)
    {
      MdxRender.Device.VertexFormat = CustomVertex.PositionOnly.Format;
      MdxRender.Device.Indices = m_ArcIndexBuffer;
      MdxRender.Device.SetStreamSource(0, m_VertexBuffer, 0);

      int index_start = 0;
      int index_count = m_Arc.Length - 1;
      MdxRender.Device.DrawIndexedPrimitives(PrimitiveType.LineStrip, 0, 0, m_Verts.Length, index_start, index_count);
      //DebugRenderCutPlane();
    }
    public void RenderPie(float RadStart, float RadLength)
    {
      MdxRender.Device.VertexFormat = CustomVertex.PositionOnly.Format;
      MdxRender.Device.Indices = m_PieIndexBuffer;
      MdxRender.Device.SetStreamSource(0, m_VertexBuffer, 0);

      //determine pie start index
      int rad_start_index = (int)(RadStart / (Math.PI * 2) * CircleVertCount - 1);
      float stop_angle = RadStart + RadLength;
      int rad_stop_index = (int)((stop_angle) / (Math.PI * 2) * CircleVertCount - 1);

      if (RadLength < 0)
      {
        int temp = rad_start_index;
        rad_start_index = rad_stop_index;
        rad_stop_index = temp;
      }

      //if((m_Counter%10)==0)
      // Trace.WriteLine(string.Format("before:  pie_start = {0}  pie_stop = {1}", rad_start_index, rad_stop_index));


      if (rad_start_index < 0)
        rad_start_index = 0;
      if (rad_start_index >= CircleVertCount)
        rad_start_index = CircleVertCount - 1;

      //determine pie stop index
      while (stop_angle >= 2 * (float)Math.PI)
        stop_angle -= 2 * (float)Math.PI;
      if (rad_stop_index < 0)
        rad_stop_index = 0;
      if (rad_stop_index >= CircleVertCount)
        rad_stop_index = CircleVertCount - 1;

      //if((m_Counter++%10)==0)
      // Trace.WriteLine(string.Format("after:   pie_start = {0}  pie_stop = {1}", rad_start_index, rad_stop_index));

      //Draw stop and start angle lines
      MdxRender.Device.DrawIndexedPrimitives(PrimitiveType.LineList, 0, 0, m_Verts.Length, rad_start_index * 3, 1);
      MdxRender.Device.DrawIndexedPrimitives(PrimitiveType.LineList, 0, 0, m_Verts.Length, rad_stop_index * 3, 1);

      //Draw the pie
      if (rad_stop_index != rad_start_index)
      {
        //enable alpha blending
        if (true)//TODO: MdxRender.DeviceInfo.caps.SourceBlendCaps.SupportsBlendFactor)
        {
          MdxRender.Device.RenderState.BlendFactor = Color.Gray;
          MdxRender.Device.RenderState.SourceBlend = Blend.BlendFactor;
          MdxRender.Device.RenderState.DestinationBlend = Blend.InvBlendFactor;
          MdxRender.Device.RenderState.AlphaBlendEnable = true;
        }

        //see if pie needs to be rendered in 2 pieces (it wraps around theta = 0)
        if (rad_stop_index < rad_start_index)
        {
          MdxRender.Device.DrawIndexedPrimitives(PrimitiveType.TriangleList, 0, 0, m_Verts.Length, 0, rad_stop_index);
          MdxRender.Device.DrawIndexedPrimitives(PrimitiveType.TriangleList, 0, 0, m_Verts.Length,
            rad_start_index * 3, CircleVertCount - rad_start_index - 2);
        }
        else
        {
          MdxRender.Device.DrawIndexedPrimitives(PrimitiveType.TriangleList, 0, 0, m_Verts.Length,
            rad_start_index * 3, rad_stop_index - rad_start_index);
        }
        //disable alpha blending
        if (true)//TODO: MdxRender.DeviceInfo.caps.SourceBlendCaps.SupportsBlendFactor)
        {
          MdxRender.Device.RenderState.AlphaBlendEnable = false;
        }
      }
    }
    public void DrawIntersectPoint()
    {
      MdxRender.Device.RenderState.PointSize = 3;
      MdxRender.Device.DrawUserPrimitives(PrimitiveType.LineList, 1, m_IntersectPoint);
    }
    public void OnResetDevice()
    {
      m_VertexBuffer = new VertexBuffer(typeof(CustomVertex.PositionOnly), m_Verts.Length, MdxRender.Device,
        Usage.WriteOnly, CustomVertex.PositionOnly.Format, Microsoft.DirectX.Direct3D.Pool.Default);
      //m_VertexBuffer.Created += new EventHandler(this.OnVertexBufferCreate);
      OnVertexBufferCreate(m_VertexBuffer, null);

      m_ArcIndexBuffer = new IndexBuffer(typeof(short), m_Arc.Length, MdxRender.Device,
        Usage.WriteOnly, Microsoft.DirectX.Direct3D.Pool.Default);
      //m_ArcIndexBuffer.Created += new EventHandler(this.OnArcIndexBufferCreate);
      OnArcIndexBufferCreate(m_ArcIndexBuffer, null);

      m_PieIndexBuffer = new IndexBuffer(typeof(short), m_Pie.Length, MdxRender.Device,
        Usage.WriteOnly, Microsoft.DirectX.Direct3D.Pool.Default);
      //m_PieIndexBuffer.Created += new EventHandler(this.OnPieIndexBufferCreate);
      OnPieIndexBufferCreate(m_PieIndexBuffer, null);
    }
    public void OnDeviceLost()
    {
      m_VertexBuffer.Dispose();
      m_ArcIndexBuffer.Dispose();
      m_PieIndexBuffer.Dispose();
    }
    #endregion

    #region Arc Interaction
    public float HoverEdit(Vector3 PickRayOrigin, Vector3 PickRayDirection)
    {
      float current_angle = GetCurrentAngle(PickRayOrigin, PickRayDirection);

      return (current_angle);
    }
    public float Hover(Vector3 PickRayOrigin, Vector3 PickRayDirection)
    {
      Vector3 intersect_pt = new Vector3();
      bool bIntersected = false;
      float proximity = -1;

      switch (m_Mode)
      {
        case ArcMode.Pitch:
          bIntersected = PMath.RayIntersectPlane(PickRayOrigin, PickRayDirection, new Plane(1, 0, 0, 0), out intersect_pt);
          break;
        case ArcMode.Roll:
          bIntersected = PMath.RayIntersectPlane(PickRayOrigin, PickRayDirection, new Plane(0, 1, 0, 0), out intersect_pt);
          break;
        case ArcMode.Yaw:
          bIntersected = PMath.RayIntersectPlane(PickRayOrigin, PickRayDirection, new Plane(0, 0, 1, 0), out intersect_pt);
          break;
      }

      if (bIntersected)
        proximity = (float)Math.Abs(RadiusScale - intersect_pt.Length());

      return (proximity);
    }
    protected float GetCurrentAngle(Vector3 PickRayOrigin, Vector3 PickRayDirection)
    {
      Vector3 intersect_pt = new Vector3();
      bool bIntersected = false;
      float angle = 0;
      float a = 0;
      float b = 0;

      switch (m_Mode)
      {
        case ArcMode.Pitch: //blue
          bIntersected = PMath.RayIntersectPlane(PickRayOrigin, PickRayDirection, new Plane(1, 0, 0, 0), out intersect_pt);
          a = intersect_pt.Z;
          b = intersect_pt.Y;
          break;
        case ArcMode.Roll: //green
          bIntersected = PMath.RayIntersectPlane(PickRayOrigin, PickRayDirection, new Plane(0, 1, 0, 0), out intersect_pt);
          a = intersect_pt.X;
          b = intersect_pt.Z;
          break;
        case ArcMode.Yaw: //red
          bIntersected = PMath.RayIntersectPlane(PickRayOrigin, PickRayDirection, new Plane(0, 0, 1, 0), out intersect_pt);
          a = intersect_pt.Y;
          b = intersect_pt.X;
          break;
      }

      if (bIntersected)
      {
        m_IntersectPoint[1].X = a;
        m_IntersectPoint[1].Y = b;

        angle = GetQuadrantAngle(b, a);
      }

      while (angle < 0)
        angle += (float)Math.PI * 2;

      while (angle > Math.PI * 2)
        angle -= (float)Math.PI * 2;

      return (angle);
    }
    float GetQuadrantAngle(float x, float y)
    {
      float angle = (float)Math.Atan(y / x);

      //correct angle based on quadrant
      if (y >= 0)
      {
        if (x >= 0)
        {
          //quadrant I
          //angle = angle;
          //Trace.WriteLine("quadrant I");
        }
        else
        {
          //quadrant II
          angle = (float)Math.PI + angle;
          //Trace.WriteLine("quadrant II");
        }
      }
      else
      {
        if (x >= 0)
        {
          //quadrant IV
          angle = (float)Math.PI * 2 + angle;
          //Trace.WriteLine("quadrant IV");
        }
        else
        {
          //quadrant III
          angle = (float)Math.PI + angle;
          //Trace.WriteLine("quadrant III");
        }
      }

      return (angle);
    }
    public float MouseDown_StartEdit(Vector3 PickRayOrigin, Vector3 PickRayDirection)
    {
      float start_angle = GetCurrentAngle(PickRayOrigin, PickRayDirection);
      //Trace.WriteLine("start_angle = " + start_angle.ToString());

      return (start_angle);
    }
    #endregion
  }
}