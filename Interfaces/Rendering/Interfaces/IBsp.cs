using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.DirectX;
using Microsoft.DirectX.Direct3D;
using Interfaces.Rendering.Radiosity;

namespace Interfaces.Rendering.Interfaces
{
  /// <summary>
  /// Outlines functionality that any game's BSP should be capable of supplying.
  /// </summary>
  public interface IBsp : IRenderable
  {
    Radiosity.WorldBounds WorldBounds { get;}

    int LoadHeader(ref byte[] metadata);

    /// <summary>
    /// Gets an array of lightmaps loaded for this BSP.
    /// </summary>
    BaseTexture[] Lightmaps { get; }
    
    void UpdateLightmap(int index, Texture lightmap);

    /// <summary>
    /// Calculates the intersection of the ray and BSP.
    /// </summary>
    /// <param name="Origin">Origin of ray.</param>
    /// <param name="Direction">Direction of ray.</param>
    /// <param name="point">out: Point of intersection.</param>
    /// <param name="UV">out: UV's of intersection.</param>
    /// <param name="LightMapIndex">out: Lightmap texture index.</param>
    /// <param name="new_dir">out: New direction of ray.</param>
    /// <param name="scale">out: Scale of light power.</param>
    /// <returns>Result of ray test.</returns>
    Rendering.Radiosity.RadiosityIntersection RadiosityIntersect(Vector3 Origin, Vector3 Direction);
    Vector3 ConvertUVTo3D(Vector2 UV, int lightmapIndex, int materialIndex, float threshold2, Vector2 allowableRadius);
    Vector3 ConvertUVTo3D(Vector2 UV, int lightmapIndex, int materialIndex, float threshold2, out Vector3 normal);
    Vector3 ConvertUVTo3D(Vector2 UV, int lightmapIndex, int materialIndex, out RadiosityMaterial material, out Vector3 normal);
    Vector3 ConvertUVTo3D(int x, int y, int lightmapIndex, int materialIndex, out RadiosityMaterial material, out Vector3 normal);
    Wrappers.EnhancedMesh[] GetMeshes(int lightmapIndex);
    WorldBounds CalculateRadiosityBounds(Vector3 skyLightDirection);
    bool[,] ImportanceMap { get; }
    bool[,] CreateImportanceMap(Vector3 lightDirection, int photonCount, WorldBounds bounds);
    Vector3 GetFaceNormal(int lightmapIndex, int materialIndex, int face);
  }

  public interface IPlane
  {
    float I { get; set;}
    float J { get; set;}
    float K { get; set;}
    int[] GetSurfaceReferences { get;}
  }
  
}
