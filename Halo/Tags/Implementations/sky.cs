using System;
using Interfaces.Pool;
using Interfaces.Rendering;
using Interfaces.Rendering.Instancing;
using Interfaces.Rendering.Interfaces;
using Interfaces.Rendering.Wrappers;
using Interfaces.DebugConsole;
using Microsoft.DirectX;
using Microsoft.DirectX.Direct3D;

namespace Games.Halo.Tags.Classes
{
  public partial class sky : IInstanceable
  {
    private IInstanceable modelTag = null;

    [Console("halo_fog", "true to enable atmospheric fog for halo, false to disable.")]
    protected static bool fogEnabled = true;

    public Instance Instance
    {
      get
      {
        if (modelTag == null)
          return new InstanceCollection();
        else
        {
          Instance modelInstance = modelTag.Instance;
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

    public override void DoPostProcess()
    {
      base.DoPostProcess();
      modelTag = OpenModel(skyValues.Model.Value, skyValues.Model.TagGroup);
    }

    public override void Dispose()
    {
      base.Dispose();
      if (modelTag is Tag)
        Release(modelTag as Tag);
      if (modelTag is IDisposable)
        (modelTag as IDisposable).Dispose();
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
      { return -1; }
      set
      { }
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

    public void ApplyWeather(WeatherEffectEnvironment environment)
    {
      if (fogEnabled)
      {
        switch (environment)
        {
          case WeatherEffectEnvironment.Indoor:
            MdxRender.Device.RenderState.FogEnable = skyValues.IndoorFogOpaqueDistance.Value > 0.0f;
            MdxRender.Device.RenderState.FogStart = skyValues.IndoorFogStartDistance.Value;
            MdxRender.Device.RenderState.FogEnd = skyValues.IndoorFogOpaqueDistance.Value;
            MdxRender.Device.RenderState.FogDensity = skyValues.IndoorFogMaximumDensity.Value;
            MdxRender.Device.RenderState.FogColorValue = new ColorValue(skyValues.IndoorFogColor.R, skyValues.IndoorFogColor.G, skyValues.IndoorFogColor.B).ToArgb();
            MdxRender.Device.RenderState.AmbientColor = new ColorValue(skyValues.IndoorAmbientRadiosityColor.R, skyValues.IndoorAmbientRadiosityColor.G, skyValues.IndoorAmbientRadiosityColor.B).ToArgb();
            break;
          case WeatherEffectEnvironment.Outdoor:
            MdxRender.Device.RenderState.FogEnable = skyValues.OutdoorFogOpaqueDistance.Value > 0.0f;
            MdxRender.Device.RenderState.FogStart = skyValues.OutdoorFogStartDistance.Value;
            MdxRender.Device.RenderState.FogEnd = skyValues.OutdoorFogOpaqueDistance.Value;
            MdxRender.Device.RenderState.FogDensity = skyValues.OutdoorFogMaximumDensity.Value;
            MdxRender.Device.RenderState.FogColorValue = new ColorValue(skyValues.OutdoorFogColor.R, skyValues.OutdoorFogColor.G, skyValues.OutdoorFogColor.B).ToArgb();
            MdxRender.Device.RenderState.AmbientColor = new ColorValue(skyValues.OutdoorAmbientRadiosityColor.R, skyValues.OutdoorAmbientRadiosityColor.G, skyValues.OutdoorAmbientRadiosityColor.B).ToArgb();
            break;
        }
        MdxRender.Device.RenderState.FogTableMode = FogMode.None;
        MdxRender.Device.RenderState.FogVertexMode = FogMode.Linear;
      }
      else
        MdxRender.Device.RenderState.FogEnable = false;
    }

    public enum WeatherEffectEnvironment
    {
      Indoor = 0,
      Outdoor
    }
  }
}
