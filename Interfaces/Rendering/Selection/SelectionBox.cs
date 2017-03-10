using Microsoft.DirectX;
using Microsoft.DirectX.Direct3D;
using Interfaces.Rendering.Primitives;
using System.Diagnostics;
using System.Drawing;
using System.IO;

namespace Interfaces.Rendering.Selection
{
  public class SelectionBox
  {
    public enum SelectionBoxState
    {
      Inactive,
      FindPlane,
      FindStartCorner,
      FindEndCorner,
      FindHeight,
      Active
    };

    private SelectionBoxState currentState = SelectionBoxState.Inactive;
    static private Plane basePlane = new Plane(0, 0, 1, 0);
    static private Plane intersectPlane = new Plane(0, 0, 1, 0);
    static private Vector3 startCorner = new Vector3();
    static private Vector3 endCorner = new Vector3();
    static private Vector3 tempVector = new Vector3();
    static private float boxHeight = 0;

    //rendering
    static private BoundingBox boxOutline = new BoundingBox();
    static private CustomVertex.PositionOnly[] xLine = new CustomVertex.PositionOnly[2];
    static private CustomVertex.PositionOnly[] yLine = new CustomVertex.PositionOnly[2];
    static private CustomVertex.PositionOnly[] zLine = new CustomVertex.PositionOnly[2];
    static private Mesh boxMesh;
    static private Mesh cursor;
    static private Material aqua;
    static private Material white;

    public bool UpdateNeeded
    {
      get { return (currentState != SelectionBoxState.Inactive); }
    }
    public SelectionBox()
    {
    }
    public void Begin()
    {
      Vector3 pos = new Vector3();
      Vector3 dir = new Vector3();
      Vector3 point_in_plane = new Vector3();
      pos = MdxRender.Camera.Position;
      dir = MdxRender.Camera.LookVector;

      intersectPlane.A = dir.X;
      intersectPlane.B = dir.Y;
      intersectPlane.C = dir.Z;
      intersectPlane = Plane.Normalize(intersectPlane);

      //calculate the coordinate that is 20 units directly in front of camera
      point_in_plane.X = pos.X + dir.X * 20;
      point_in_plane.Y = pos.Y + dir.Y * 20;
      point_in_plane.Z = pos.Z + dir.Z * 20;
      Trace.WriteLine("cam_loc = " + pos.ToString());
      Trace.WriteLine("cam_dir = " + dir.ToString());
      Trace.WriteLine("point in plane = " + point_in_plane.ToString());

      //distance here is from the point to the origin, not the nearest distance from plane to origin...need to fix
      intersectPlane.D = (point_in_plane.X * intersectPlane.A + point_in_plane.Y * intersectPlane.B + point_in_plane.Z * intersectPlane.C);

      Trace.WriteLine("intersect plane = " + intersectPlane.ToString());

      //todo: get the optimal intersect plane based on camera orientation
      currentState = SelectionBoxState.FindPlane;
    }
    public void Click(Vector3 origin, Vector3 dir)
    {
      switch (currentState)
      {
        case SelectionBoxState.FindPlane:
          if (PMath.RayIntersectPlane(origin, dir, intersectPlane, out startCorner))
          {
            basePlane.D = startCorner.Z;
            currentState = SelectionBoxState.FindStartCorner;
          }
          break;

        case SelectionBoxState.FindStartCorner:
          PMath.RayIntersectPlane(origin, dir, basePlane, out startCorner);
          currentState = SelectionBoxState.FindEndCorner;
          break;

        case SelectionBoxState.FindEndCorner:
          PMath.RayIntersectPlane(origin, dir, basePlane, out endCorner);
          currentState = SelectionBoxState.FindHeight;
          break;

        case SelectionBoxState.FindHeight:
          Vector3 temp = new Vector3();
          if (PMath.RayIntersectPlane(origin, dir, intersectPlane, out temp))
          {
            boxHeight = temp.Z - startCorner.Z;
          }
          //todo: calc new vertical intersectPlane based on endCorner
          currentState = SelectionBoxState.Active;
          break;

        case SelectionBoxState.Active:
          //todo: if clicked outside of bounding box model, deselect it
          currentState = SelectionBoxState.Inactive;
          break;
      }
      Trace.WriteLine(string.Format("Selection Box State: {0}", currentState));
      Trace.WriteLine(string.Format("start: {0} {1} {2}", startCorner.X, startCorner.Y, startCorner.Z));
      Trace.WriteLine(string.Format("end  : {0} {1} {2}", endCorner.X, endCorner.Y, endCorner.Z));
    }
    public void Hover(Vector3 origin, Vector3 dir)
    {
      switch (currentState)
      {
        case SelectionBoxState.FindPlane:
          if (PMath.RayIntersectPlane(origin, dir, intersectPlane, out startCorner))
            basePlane.D = startCorner.Z;
          Trace.WriteLine(string.Format("findplane:  {0} {1} {2}", startCorner.X, startCorner.Y, startCorner.Z));
          UpdatePrimitives();
          break;

        case SelectionBoxState.FindStartCorner:
          if (PMath.RayIntersectPlane(origin, dir, basePlane, out startCorner) == false)
          {
            startCorner.X = 0;
            startCorner.Y = 0;
            startCorner.Z = 0;
          }
          Trace.WriteLine(string.Format("start corner:  {0} {1} {2}", startCorner.X, startCorner.Y, startCorner.Z));
          UpdatePrimitives();
          break;

        case SelectionBoxState.FindEndCorner:
          if (PMath.RayIntersectPlane(origin, dir, basePlane, out endCorner) == false)
          {
            endCorner.X = 0;
            endCorner.Y = 0;
            endCorner.Z = 0;
          }
          UpdateBox(startCorner, endCorner, 0.005f);
          boxOutline.min[0] = startCorner.X;
          boxOutline.min[1] = startCorner.Y;
          boxOutline.min[2] = startCorner.Z;
          boxOutline.max[0] = endCorner.X;
          boxOutline.max[1] = endCorner.Y;
          boxOutline.max[2] = endCorner.Z + 0.005f;
          break;

        case SelectionBoxState.FindHeight:
          Vector3 temp = new Vector3();
          if (PMath.RayIntersectPlane(origin, dir, intersectPlane, out temp))
          {
            boxHeight = temp.Z - startCorner.Z;
          }
          UpdateBox(startCorner, endCorner, boxHeight);
          boxOutline.min[0] = startCorner.X;
          boxOutline.min[1] = startCorner.Y;
          boxOutline.min[2] = startCorner.Z;
          boxOutline.max[0] = endCorner.X;
          boxOutline.max[1] = endCorner.Y;
          boxOutline.max[2] = endCorner.Z + boxHeight;
          break;
      }
    }

    public void Render()
    {
      if (boxMesh != null)
      {

        MdxRender.Device.Transform.World = Matrix.Identity;
        switch (currentState)
        {
          case SelectionBoxState.FindPlane:
            MdxRender.Device.Material = white;
            MdxRender.Device.DrawUserPrimitives(PrimitiveType.LineList, 1, xLine);
            MdxRender.Device.DrawUserPrimitives(PrimitiveType.LineList, 1, yLine);
            MdxRender.Device.DrawUserPrimitives(PrimitiveType.LineList, 1, zLine);
            RenderTransparentBox();
            break;

          case SelectionBoxState.FindStartCorner:
            MdxRender.Device.Material = white;
            MdxRender.Device.DrawUserPrimitives(PrimitiveType.LineList, 1, xLine);
            MdxRender.Device.DrawUserPrimitives(PrimitiveType.LineList, 1, yLine);
            MdxRender.Device.DrawUserPrimitives(PrimitiveType.LineList, 1, zLine);
            RenderTransparentBox();
            break;

          case SelectionBoxState.FindEndCorner:
            MdxRender.Device.Material = white;
            MdxRender.Device.DrawUserPrimitives(PrimitiveType.LineList, 1, xLine);
            MdxRender.Device.DrawUserPrimitives(PrimitiveType.LineList, 1, yLine);
            boxOutline.RenderBoundingBox();
            RenderTransparentBox();
            break;

          case SelectionBoxState.FindHeight:
          case SelectionBoxState.Active:
            MdxRender.Device.Material = white;
            boxOutline.RenderBoundingBox();
            RenderTransparentBox();
            break;
        }

      }
    }
    public void RenderTransparentBox()
    {
      //TODO:
      //if (MdxRender.DeviceInfo.caps.SourceBlendCaps.SupportsBlendFactor)
      //{
      //  MdxRender.Device.RenderState.BlendFactor = Color.Gray;
      //  MdxRender.Device.RenderState.SourceBlend = Blend.BlendFactor;
      //  MdxRender.Device.RenderState.DestinationBlend = Blend.InvBlendFactor;
      //  MdxRender.Device.RenderState.AlphaBlendEnable = true;
      //}

      MdxRender.Device.Material = aqua;
      boxMesh.DrawSubset(0);

      //TODO:
      //if (MdxRender.DeviceInfo.caps.SourceBlendCaps.SupportsBlendFactor)
      //{
      //  MdxRender.Device.RenderState.AlphaBlendEnable = false;
      //}
    }

    static private void UpdatePrimitives()
    {
      UpdateBox(new Vector3(startCorner.X - 500, startCorner.Y - 500, startCorner.Z),
        new Vector3(startCorner.X + 500, startCorner.Y + 500, startCorner.Z), 0.005f);

      zLine[0].X = startCorner.X;
      zLine[0].Y = startCorner.Y;
      zLine[0].Z = startCorner.Z - 500;
      zLine[1].X = startCorner.X;
      zLine[1].Y = startCorner.Y;
      zLine[1].Z = startCorner.Z + 500;

      //update plane lines
      xLine[0].X = startCorner.X - 500;
      xLine[0].Y = startCorner.Y;
      xLine[0].Z = basePlane.D;
      xLine[1].X = startCorner.X + 500;
      xLine[1].Y = startCorner.Y;
      xLine[1].Z = basePlane.D + 0.06f;

      yLine[0].X = startCorner.X;
      yLine[0].Y = startCorner.Y - 500;
      yLine[0].Z = basePlane.D;
      yLine[1].X = startCorner.X;
      yLine[1].Y = startCorner.Y + 500;
      yLine[1].Z = basePlane.D + 0.06f;
    }
    static public void Initialize()
    {
      boxMesh = Mesh.Box(MdxRender.Device, 1, 1, 1);
      cursor = Mesh.Box(MdxRender.Device, 0.5f, 0.5f, 2);

      xLine[0] = new CustomVertex.PositionOnly();
      xLine[1] = new CustomVertex.PositionOnly();
      yLine[0] = new CustomVertex.PositionOnly();
      yLine[1] = new CustomVertex.PositionOnly();
      zLine[0] = new CustomVertex.PositionOnly();
      zLine[1] = new CustomVertex.PositionOnly();

      aqua = new Material();
      aqua.Ambient = Color.Aqua;
      aqua.Diffuse = Color.Aqua;
      white = new Material();
      white.Ambient = Color.White;
      white.Diffuse = Color.White;

      UpdatePrimitives();
    }
    public static void UpdateBox(Vector3 start, Vector3 end, float height)
    {
      CustomVertex.PositionNormal[] tmp = new CustomVertex.PositionNormal[boxMesh.NumberVertices];
      Vector3 pos = new Vector3();
      Vector3 norm = new Vector3();
      using (VertexBuffer vb = boxMesh.VertexBuffer)
      {
        GraphicsStream vertexData = vb.Lock(0, 0, LockFlags.None);
        BinaryReader br = new BinaryReader(vertexData);
        for (int v = 0; v < boxMesh.NumberVertices; v++)
        {
          pos.X = br.ReadSingle();
          pos.Y = br.ReadSingle();
          pos.Z = br.ReadSingle();
          norm.X = br.ReadSingle();
          norm.Y = br.ReadSingle();
          norm.Z = br.ReadSingle();
          tmp[v] = new CustomVertex.PositionNormal(pos.X, pos.Y, pos.Z, norm.X, norm.Y, norm.Z);
        }
        vb.Unlock();
      }

      tmp[0].X = start.X;
      tmp[0].Y = start.Y;
      tmp[0].Z = start.Z;

      tmp[1].X = start.X;
      tmp[1].Y = start.Y;
      tmp[1].Z = start.Z + height;

      tmp[2].X = start.X;
      tmp[2].Y = end.Y;
      tmp[2].Z = start.Z + height;

      tmp[3].X = start.X;
      tmp[3].Y = end.Y;
      tmp[3].Z = start.Z;

      tmp[4].X = start.X;
      tmp[4].Y = end.Y;
      tmp[4].Z = start.Z;

      tmp[5].X = start.X;
      tmp[5].Y = end.Y;
      tmp[5].Z = start.Z + height;

      tmp[6].X = end.X;
      tmp[6].Y = end.Y;
      tmp[6].Z = start.Z + height;

      tmp[7].X = end.X;
      tmp[7].Y = end.Y;
      tmp[7].Z = start.Z;

      tmp[8].X = end.X;
      tmp[8].Y = end.Y;
      tmp[8].Z = start.Z;

      tmp[9].X = end.X;
      tmp[9].Y = end.Y;
      tmp[9].Z = start.Z + height;

      tmp[10].X = end.X;
      tmp[10].Y = start.Y;
      tmp[10].Z = start.Z + height;

      tmp[11].X = end.X;
      tmp[11].Y = start.Y;
      tmp[11].Z = start.Z;

      tmp[12].X = start.X;
      tmp[12].Y = start.Y;
      tmp[12].Z = end.Z + height;

      tmp[13].X = start.X;
      tmp[13].Y = start.Y;
      tmp[13].Z = start.Z;

      tmp[14].X = end.X;
      tmp[14].Y = start.Y;
      tmp[14].Z = start.Z;

      tmp[15].X = end.X;
      tmp[15].Y = start.Y;
      tmp[15].Z = start.Z + height;

      tmp[16].X = start.X;
      tmp[16].Y = start.Y;
      tmp[16].Z = start.Z + height;

      tmp[17].X = end.X;
      tmp[17].Y = start.Y;
      tmp[17].Z = start.Z + height;

      tmp[18].X = end.X;
      tmp[18].Y = end.Y;
      tmp[18].Z = start.Z + height;

      tmp[19].X = start.X;
      tmp[19].Y = end.Y;
      tmp[19].Z = start.Z + height;

      tmp[20].X = start.X;
      tmp[20].Y = start.Y;
      tmp[20].Z = start.Z;

      tmp[21].X = start.X;
      tmp[21].Y = end.Y;
      tmp[21].Z = start.Z;

      tmp[22].X = end.X;
      tmp[22].Y = end.Y;
      tmp[22].Z = start.Z;

      tmp[23].X = end.X;
      tmp[23].Y = start.Y;
      tmp[23].Z = start.Z;

      boxMesh.SetVertexBufferData(tmp, LockFlags.None);
    }

    public bool Inside(Vector3 ObjectOrigin)
    {
      bool bOverall = false;

      if (currentState == SelectionBoxState.FindHeight)
      {
        //test if x within bounds
        if ((ObjectOrigin.X > startCorner.X) && (ObjectOrigin.X < endCorner.X))
          bOverall = true;
        else if ((ObjectOrigin.X > endCorner.X) && (ObjectOrigin.X < startCorner.X))
          bOverall = true;

        if (bOverall)
        {
          bOverall = false;
          //test if y within bounds
          if ((ObjectOrigin.Y > startCorner.Y) && (ObjectOrigin.Y < endCorner.Y))
            bOverall = true;
          else if ((ObjectOrigin.Y > endCorner.Y) && (ObjectOrigin.Y < startCorner.Y))
            bOverall = true;

          if (bOverall)
          {
            bOverall = false;
            float ht_start = startCorner.Z;
            float ht_end = startCorner.Z + boxHeight;

            //test if z within bounds
            if ((ObjectOrigin.Z > ht_start) && (ObjectOrigin.Z < ht_end))
              bOverall = true;
            else if ((ObjectOrigin.Z > ht_end) && (ObjectOrigin.Z < ht_start))
              bOverall = true;
          }
        }
      }

      return (bOverall);
    }
  }
}