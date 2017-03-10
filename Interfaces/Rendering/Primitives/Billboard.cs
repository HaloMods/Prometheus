using System;
using System.Reflection;
using System.IO;
using System.Collections.Generic;
using System.Text;
using Microsoft.DirectX;
using Microsoft.DirectX.Direct3D;
using Interfaces.Rendering.Interfaces;
using Interfaces.Rendering.Wrappers;
using System.Diagnostics;

namespace Interfaces.Rendering.Primitives
{
  public class Billboard : IRenderable
  {
    static private Texture[] billboardTextures;
    private Texture billboardTexture;
    static private CustomVertex.PositionTextured[] billboardVerts;
    static private float dx;
    static private float dy;
    static private VertexBuffer vertexBuffer;

    static public void LoadResources(float width, float length)
    {
      dx = width * 0.5f;
      dy = length;

      billboardVerts = new CustomVertex.PositionTextured[4];
      billboardVerts[0] = new CustomVertex.PositionTextured(dx, 0, 0, 1, 1);
      billboardVerts[1] = new CustomVertex.PositionTextured(dx, length, 0, 1, 0);
      billboardVerts[2] = new CustomVertex.PositionTextured(-dx, 0, 0, 0, 1);
      billboardVerts[3] = new CustomVertex.PositionTextured(-dx, length, 0, 0, 0);

      vertexBuffer = new VertexBuffer(typeof(CustomVertex.PositionTextured), billboardVerts.Length, MdxRender.Device,
        Usage.WriteOnly, CustomVertex.PositionTextured.Format, Microsoft.DirectX.Direct3D.Pool.Default);
      OnVertexBufferUpdate(vertexBuffer, null);

      Assembly assm = Assembly.GetExecutingAssembly();
      Stream ddsFile;
      billboardTextures = new Texture[10];

      ddsFile = assm.GetManifestResourceStream("Interfaces.Resources.ctf.dds");
      billboardTextures[(int)BillboardType.CTF_Flag] = TextureLoader.FromStream(MdxRender.Device, ddsFile);
      ddsFile.Close();

      ddsFile = assm.GetManifestResourceStream("Interfaces.Resources.ctf_vehicle.dds");
      billboardTextures[(int)BillboardType.CTF_Vehicle] = TextureLoader.FromStream(MdxRender.Device, ddsFile);
      ddsFile.Close();

      ddsFile = assm.GetManifestResourceStream("Interfaces.Resources.oddball.dds");
      billboardTextures[(int)BillboardType.Oddball] = TextureLoader.FromStream(MdxRender.Device, ddsFile);
      ddsFile.Close();

      ddsFile = assm.GetManifestResourceStream("Interfaces.Resources.race.dds");
      billboardTextures[(int)BillboardType.Race_Track] = TextureLoader.FromStream(MdxRender.Device, ddsFile);
      ddsFile.Close();

      ddsFile = assm.GetManifestResourceStream("Interfaces.Resources.race_vehicle.dds");
      billboardTextures[(int)BillboardType.Race_Vehicle] = TextureLoader.FromStream(MdxRender.Device, ddsFile);
      ddsFile.Close();

      ddsFile = assm.GetManifestResourceStream("Interfaces.Resources.vegas_bank.dds");
      billboardTextures[(int)BillboardType.Vegas_Bank] = TextureLoader.FromStream(MdxRender.Device, ddsFile);
      ddsFile.Close();

      ddsFile = assm.GetManifestResourceStream("Interfaces.Resources.teleporter_enter.dds");
      billboardTextures[(int)BillboardType.Teleport_From] = TextureLoader.FromStream(MdxRender.Device, ddsFile);
      ddsFile.Close();

      ddsFile = assm.GetManifestResourceStream("Interfaces.Resources.teleporter_exit.dds");
      billboardTextures[(int)BillboardType.Teleport_To] = TextureLoader.FromStream(MdxRender.Device, ddsFile);
      ddsFile.Close();

      ddsFile = assm.GetManifestResourceStream("Interfaces.Resources.koh.dds");
      billboardTextures[(int)BillboardType.KOH] = TextureLoader.FromStream(MdxRender.Device, ddsFile);
      ddsFile.Close();

      ddsFile = assm.GetManifestResourceStream("Interfaces.Resources.sound_scenery.dds");
      billboardTextures[(int)BillboardType.Sound_Scenery] = TextureLoader.FromStream(MdxRender.Device, ddsFile);
      ddsFile.Close();
    }

    public Billboard(BillboardType bt)
    {
      billboardTexture = billboardTextures[(int)bt];
    }
    static private void OnVertexBufferUpdate(object sender, EventArgs e)
    {
      VertexBuffer vb = (VertexBuffer)sender;
      GraphicsStream data = vb.Lock(0, 0, LockFlags.None);

      for (int v = 0; v < billboardVerts.Length; v++)
        data.Write(billboardVerts[v]);

      vb.Unlock();
    }
    public void Render()
    {
      MdxRender.Device.VertexShader = null;
      MdxRender.Device.PixelShader = null;
      MdxRender.Device.VertexFormat = CustomVertex.PositionTextured.Format;
      MdxRender.Device.RenderState.CullMode = Cull.None;
      MdxRender.Device.TextureState[1].AlphaOperation = TextureOperation.Disable;
      MdxRender.Device.TextureState[1].ColorOperation = TextureOperation.Disable;
      MdxRender.Device.RenderState.SourceBlend = Blend.SourceAlpha;
      MdxRender.Device.RenderState.DestinationBlend = Blend.InvSourceAlpha;
      MdxRender.Device.RenderState.AlphaBlendEnable = true;
      MdxRender.Device.TextureState[0].ColorArgument1 = TextureArgument.TextureColor;
      MdxRender.Device.TextureState[0].AlphaArgument1 = TextureArgument.TextureColor;
      MdxRender.Device.TextureState[0].AlphaOperation = TextureOperation.SelectArg1;
      MdxRender.Device.TextureState[0].ColorOperation = TextureOperation.SelectArg1;//.ModulateInvAlphaAddColor;
      MdxRender.Device.TextureState[0].TextureTransform = TextureTransform.Disable;

      MdxRender.Device.SetTexture(0, billboardTexture);
      MdxRender.Device.SetStreamSource(0, vertexBuffer, 0);
      MdxRender.Device.DrawPrimitives(PrimitiveType.TriangleStrip, 0, 2);
    }
    public Intersection IntersectRay(Vector3 origin, Vector3 direction)
    {
      Intersection ii = null;

      //set z=0 and see where x,y are
      float dz = origin.Z;
      float x_loc = origin.X + direction.X * dz;
      float y_loc = origin.Y + direction.Y * dz;

      if (Math.Abs(x_loc) < dx)
      {
        if ((y_loc > 0) && (y_loc < dy))
          ii = new Intersection(new IntersectInformation(), Vector3.Empty);
      }

      if (ii != null)
      {
        Trace.WriteLine("intersected billboard: ");
      }

      return (ii);
    }
    public bool IntersectRayAABB(Vector3 origin, Vector3 direction)
    {
      return true;
    }
    public bool IntersectPlaneAABB(IPlane plane)
    {
      return false;
    }
    public int PixelFillCount
    {
      get { return 0; }
      set { }
    }
    public bool IntersectCamera(ICamera camera)
    {
      return false;
    }

    static public void OnLostDevice()
    {
      if (vertexBuffer != null)
        vertexBuffer.Dispose();
    }

    static public void OnResetDevice()
    {
      vertexBuffer = new VertexBuffer(typeof(CustomVertex.PositionTextured), billboardVerts.Length, MdxRender.Device,
        Usage.WriteOnly, CustomVertex.PositionTextured.Format, Microsoft.DirectX.Direct3D.Pool.Default);
      OnVertexBufferUpdate(vertexBuffer, null);
    }
  }
}
