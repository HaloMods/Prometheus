using System;
using System.Drawing;
using Interfaces.Rendering.Interfaces;
using Microsoft.DirectX;
using Microsoft.DirectX.Direct3D;
using Interfaces.Rendering.Primitives;

namespace Interfaces.Rendering.Instancing
{
  /// <summary>
  /// Represents an instance of an object with a render model.
  /// </summary>
  public class ObjectInstance : WorldInstance
  {
    private int visibilityID = -1;
    private float boundingRadius = 0.0f;
    private Vector3 boundingOffset = Vector3.Empty;
    protected bool updateEnvironment = true;
    protected Color ambientColor = Color.White;
    protected Query occlusionQuery = new Query(MdxRender.Device, QueryType.Occlusion);
    protected IEnvironmentProvider environmentProvider = null;

    public override void Render()
    {
      BeginOcclusionQuery();
      Render(true);
      EndOcclusionQuery();
    }

    protected void BeginOcclusionQuery()
    {
      if (!MdxRender.DrawingTransparent)
          occlusionQuery.Issue(IssueFlags.Begin);
    }

    protected void EndOcclusionQuery()
    {
      if (!MdxRender.DrawingTransparent)
        occlusionQuery.Issue(IssueFlags.End);
    }

    protected virtual bool Render(bool draw)
    {
      //render WorldInstance.selectionTool
      base.Render();

      bool occlude;
      int pixels = (int)occlusionQuery.GetData(typeof(int), true, out occlude);
      if (occlude)
        pixelFillCount = entity.PixelFillCount = pixels;

      if (updateEnvironment)
        if (environmentProvider != null)
          visibilityID = environmentProvider.Environment.GetVisibilityID(X, Y, Z);

      bool pvs = true;
      if (environmentProvider != null)
        pvs = (visibilityID >= 0 || environmentProvider.Environment.CameraID < 0) && environmentProvider.Environment.IDIsVisibleFrom(visibilityID, environmentProvider.Environment.CameraID);

      if (pvs)
      {
        if (updateEnvironment)
        {
          if (environmentProvider == null)
            ambientColor = Color.White;
          else
            ambientColor = environmentProvider.Environment.GetAmbientLighting(X + boundingOffset.X, Y + boundingOffset.Y, Z + boundingOffset.Z, boundingRadius, true);
        }

        Material material = new Material();
        material.Ambient = Color.White;
        material.Diffuse = ambientColor;
        MdxRender.Device.Material = material;

        if (draw)
        {
          entity.Render();
        }
      }

      updateEnvironment = false;
      return pvs;
    }

    public IEnvironmentProvider EnvironmentProvider
    {
      get
      { return environmentProvider; }
      set
      { environmentProvider = value; }
    }

    public override void OnDeviceReset()
    {
      base.OnDeviceReset();
      if (occlusionQuery != null)
        if (!occlusionQuery.Disposed)
          occlusionQuery.Dispose();
      occlusionQuery = new Query(MdxRender.Device, QueryType.Occlusion);
    }

    public override void OnDeviceLost()
    {
      base.OnDeviceLost();
      if (occlusionQuery != null)
        if (!occlusionQuery.Disposed)
          occlusionQuery.Dispose();
    }

    public ObjectInstance(IRenderable entity, Vector3 centroid, BoundingBox boundingBox)
      : base(entity, centroid, boundingBox)
    { /* nothing!.. */ }
  }
}
