using System;
using System.Collections.Generic;
using Microsoft.DirectX;
using Microsoft.DirectX.Direct3D;
using Interfaces.Rendering;
using Interfaces.Rendering.Instancing;
using Interfaces.Rendering.Interfaces;
using Interfaces.Rendering.Primitives;
using Interfaces.Rendering.Wrappers;

namespace Games.Halo.Tags.Classes
{
  public partial class model : IModel, IInstanceable
  {
    private shader[] shaders = null;
    private EnhancedMesh[/* geometries */][/* parts */] meshes = null;
    private BoundingBox bounds = new BoundingBox();
    private InstanceCollection instances;
    private LevelOfDetail lod = LevelOfDetail.SuperHigh;
    private int pixelFillCount;
    private int[] currentPermutation = null;
    private InstanceCollection[][] superLow, low, medium, high, superHigh;

    public override void DoPostProcess()
    {
      base.DoPostProcess();

      shaders = new shader[modelValues.Shaders.Count];
      for (int i = 0; i < shaders.Length; i++)
        shaders[i] = OpenShader(modelValues.Shaders[i].Shader.Value, modelValues.Shaders[i].Shader.TagGroup);

      meshes = new EnhancedMesh[modelValues.Geometries.Count][];
      for (int i = 0; i < meshes.Length; i++)
      {
        meshes[i] = new EnhancedMesh[modelValues.Geometries[i].Parts.Count];
        for (int j = 0; j < meshes[i].Length; j++)
        {
          ushort[] strip = new ushort[modelValues.Geometries[i].Parts[j].Triangles.Count * 3];
          Vertex[] vertices = new Vertex[modelValues.Geometries[i].Parts[j].UncompressedVertices.Count];

          for (int k = 0; k < vertices.Length; k++)
          {
            vertices[k].position.X = modelValues.Geometries[i].Parts[j].UncompressedVertices[k].Position.X;
            vertices[k].position.Y = modelValues.Geometries[i].Parts[j].UncompressedVertices[k].Position.Y;
            vertices[k].position.Z = modelValues.Geometries[i].Parts[j].UncompressedVertices[k].Position.Z;
            vertices[k].normal.X = modelValues.Geometries[i].Parts[j].UncompressedVertices[k].Normal.I;
            vertices[k].normal.Y = modelValues.Geometries[i].Parts[j].UncompressedVertices[k].Normal.J;
            vertices[k].normal.Z = modelValues.Geometries[i].Parts[j].UncompressedVertices[k].Normal.K;
            vertices[k].u1 = modelValues.Geometries[i].Parts[j].UncompressedVertices[k].TextureCoords.X * ((modelValues.BaseMap.Value == 0.0f) ? 1.0f : modelValues.BaseMap.Value);
            vertices[k].v1 = modelValues.Geometries[i].Parts[j].UncompressedVertices[k].TextureCoords.Y * ((modelValues.BaseMap2.Value == 0.0f) ? 1.0f : modelValues.BaseMap2.Value);
            vertices[k].u2 = modelValues.Geometries[i].Parts[j].UncompressedVertices[k].Node0Weight.Value;
            vertices[k].v2 = modelValues.Geometries[i].Parts[j].UncompressedVertices[k].Node1Weight.Value;
            vertices[k].nodeIndex1 = modelValues.Geometries[i].Parts[j].UncompressedVertices[k].Node0Index.Value;
            vertices[k].nodeIndex2 = modelValues.Geometries[i].Parts[j].UncompressedVertices[k].Node1Index.Value;
            bounds.Update(vertices[k].position.X, vertices[k].position.Y, vertices[k].position.Z);
          }
          for (int k = 0; k < modelValues.Geometries[i].Parts[j].Triangles.Count; k++)
          {
            strip[k * 3] = (ushort)modelValues.Geometries[i].Parts[j].Triangles[k].Vertex0Index.Value;
            strip[k * 3 + 1] = (ushort)modelValues.Geometries[i].Parts[j].Triangles[k].Vertex1Index.Value;
            strip[k * 3 + 2] = (ushort)modelValues.Geometries[i].Parts[j].Triangles[k].Vertex2Index.Value;
          }

          try
          {
            SubMesh[] sub = new SubMesh[1];
            sub[0] = new SubMesh(0, (ushort)(strip.Length - 2), 0);
            meshes[i][j] = new EnhancedMesh(vertices, strip, sub, true, false, true);
            meshes[i][j].DefaultShader = shaders[modelValues.Geometries[i].Parts[j].ShaderIndex.Value];
          }
          catch (Exception ex)
          {
            LogError("Model tag {0}.{1} failed to create Mesh: {2}", Name, "model", ex.Message);
          }

          //instances.Add(new ObjectInstance(meshes[i][j], new Vector3(modelValues.Geometries[i].Parts[j].Centroid.X, modelValues.Geometries[i].Parts[j].Centroid.Y, modelValues.Geometries[i].Parts[j].Centroid.Z)));
          //instances.Add(new PartInstance(meshes[i][j], new Vector3(modelValues.Geometries[i].Parts[j].Centroid.X, modelValues.Geometries[i].Parts[j].Centroid.Y, modelValues.Geometries[i].Parts[j].Centroid.Z)));
        }
      }

      int[] regionPermutationCounts = new int[modelValues.Regions.Count];
      for(int i = 0; i < modelValues.Regions.Count; i++)
        regionPermutationCounts[i] = modelValues.Regions[i].Permutations.Count;

      superLow = new InstanceCollection[regionPermutationCounts.Length][];
      low = new InstanceCollection[regionPermutationCounts.Length][];
      medium = new InstanceCollection[regionPermutationCounts.Length][];
      high = new InstanceCollection[regionPermutationCounts.Length][];
      superHigh = new InstanceCollection[regionPermutationCounts.Length][];

      for (int i = 0; i < regionPermutationCounts.Length; i++)
      {
        superLow[i] = new InstanceCollection[regionPermutationCounts[i]];
        low[i] = new InstanceCollection[regionPermutationCounts[i]];
        medium[i] = new InstanceCollection[regionPermutationCounts[i]];
        high[i] = new InstanceCollection[regionPermutationCounts[i]];
        superHigh[i] = new InstanceCollection[regionPermutationCounts[i]];
      }

      int geometry;
      for (int i = 0; i < regionPermutationCounts.Length; i++)
      {
        for (int j = 0; j < regionPermutationCounts[i]; j++)
        {
          geometry = modelValues.Regions[i].Permutations[j].SuperLow.Value;
          superLow[i][j] = new InstanceCollection();
          for (int k = 0; k < meshes[geometry].Length; k++)
          {
            superLow[i][j].Add(new PartInstance(meshes[geometry][k],
                  meshes[geometry][k].DefaultShader,
                  new Vector3(modelValues.Geometries[geometry].Parts[k].Centroid.X,
                    modelValues.Geometries[geometry].Parts[k].Centroid.Y,
                    modelValues.Geometries[geometry].Parts[k].Centroid.Z),
                  meshes[geometry][k].BoundingBox));
          }

          geometry = modelValues.Regions[i].Permutations[j].Low.Value;
          low[i][j] = new InstanceCollection();
          for (int k = 0; k < meshes[geometry].Length; k++)
          {
            low[i][j].Add(new PartInstance(meshes[geometry][k],
                  meshes[geometry][k].DefaultShader,
                  new Vector3(modelValues.Geometries[geometry].Parts[k].Centroid.X,
                    modelValues.Geometries[geometry].Parts[k].Centroid.Y,
                    modelValues.Geometries[geometry].Parts[k].Centroid.Z),
                  meshes[geometry][k].BoundingBox));
          }

          geometry = modelValues.Regions[i].Permutations[j].Medium.Value;
          medium[i][j] = new InstanceCollection();
          for (int k = 0; k < meshes[geometry].Length; k++)
          {
            medium[i][j].Add(new PartInstance(meshes[geometry][k],
                  meshes[geometry][k].DefaultShader,
                  new Vector3(modelValues.Geometries[geometry].Parts[k].Centroid.X,
                    modelValues.Geometries[geometry].Parts[k].Centroid.Y,
                    modelValues.Geometries[geometry].Parts[k].Centroid.Z),
                  meshes[geometry][k].BoundingBox));
          }

          geometry = modelValues.Regions[i].Permutations[j].High.Value;
          high[i][j] = new InstanceCollection();
          for (int k = 0; k < meshes[geometry].Length; k++)
          {
            high[i][j].Add(new PartInstance(meshes[geometry][k],
                  meshes[geometry][k].DefaultShader,
                  new Vector3(modelValues.Geometries[geometry].Parts[k].Centroid.X,
                    modelValues.Geometries[geometry].Parts[k].Centroid.Y,
                    modelValues.Geometries[geometry].Parts[k].Centroid.Z),
                  meshes[geometry][k].BoundingBox));
          }

          geometry = modelValues.Regions[i].Permutations[j].SuperHigh.Value;
          superHigh[i][j] = new InstanceCollection();
          for (int k = 0; k < meshes[geometry].Length; k++)
          {
            superHigh[i][j].Add(new PartInstance(meshes[geometry][k],
                  meshes[geometry][k].DefaultShader,
                  new Vector3(modelValues.Geometries[geometry].Parts[k].Centroid.X,
                    modelValues.Geometries[geometry].Parts[k].Centroid.Y,
                    modelValues.Geometries[geometry].Parts[k].Centroid.Z),
                  meshes[geometry][k].BoundingBox));
          }
        }
      }
    }

    public override void Dispose()
    {
      base.Dispose();
      if (shaders != null)
        for (int i = 0; i < shaders.Length; i++)
          Release(shaders[i]);
    }

    public void Render()
    {
      for (int i = 0; i < meshes[modelValues.Regions[0].Permutations[0].SuperHigh.Value].Length; i++)
        meshes[(int)lod][i].Render();
    }

    public bool IntersectRayAABB(Vector3 origin, Vector3 direction)
    {
      throw new Exception("The method or operation is not implemented.");
    }

    public Intersection IntersectRay(Vector3 origin, Vector3 direction)
    {
      throw new Exception("The method or operation is not implemented.");
    }

    public Instance Instance
    {
      get
      {
        currentPermutation = new int[modelValues.Regions.Count];

        for (int i = 0; i < modelValues.Regions.Count; i++)
        {
          int permutation = -1/*, geometry = -1*/;
          bool acceptable = false;

          for (int j = 0; j < modelValues.Regions[i].Permutations.Count; j++)
          {
            if (!modelValues.Regions[i].Permutations[j].Flags.GetFlag(1))
            {
              acceptable = true;
              break;
            }
          }

          if (!acceptable)
          {
            LogError("Could not find an acceptable permutation; all available permutations were marked not to be chosen.");
            permutation = 0;
          }
          else
          {
            do
            {
              permutation = Random.Next(modelValues.Regions[i].Permutations.Count - 1);
            } while (modelValues.Regions[i].Permutations[permutation].Flags.GetFlag(1) /* cannot be chosen randomly */);
          }

          currentPermutation[i] = permutation;
        }

        //return instances;
        return GetPermutation(currentPermutation);
      }
    }

    public int[] CurrentPermutations
    {
      get
      { return currentPermutation; }
    }

    public Instance GetPermutation(int[] permutations)
    {
      if (instances == null)
        instances = new InstanceCollection();
      else
        instances.Clear();

      for (int i = 0; i < modelValues.Regions.Count; i++)
      {
        switch (lod)
        {
          case LevelOfDetail.SuperLow:
            for(int j = 0; j < superLow[i][permutations[i]].Count; j++)
              instances.Add(superLow[i][permutations[i]][j]);
            break;
          case LevelOfDetail.Low:
            for (int j = 0; j < low[i][permutations[i]].Count; j++)
              instances.Add(low[i][permutations[i]][j]);
            break;
          case LevelOfDetail.Medium:
            for (int j = 0; j < medium[i][permutations[i]].Count; j++)
              instances.Add(medium[i][permutations[i]][j]);
            break;
          case LevelOfDetail.High:
            for (int j = 0; j < high[i][permutations[i]].Count; j++)
              instances.Add(high[i][permutations[i]][j]);
            break;
          case LevelOfDetail.SuperHigh:
            for (int j = 0; j < superHigh[i][permutations[i]].Count; j++)
              instances.Add(superHigh[i][permutations[i]][j]);
            break;
        }
      }

      return instances;
    }

    /// <summary>
    /// Opens a shader generically.
    /// </summary>
    private shader OpenShader(string name, string type)
    {
      switch (type)
      {
        case "senv":
          return Open<shader_environment>(name);
        case "soso":
          return Open<shader_model>(name);
        case "sgla":
          return Open<shader_transparent_glass>(name);
        case "swat":
          return Open<shader_transparent_water>(name);
        case "schi":
          return Open<shader_transparent_chicago>(name);
        case "scex":
          return Open<shader_transparent_chicago_extended>(name);
        case "sotr":
          return Open<shader_transparent_generic>(name);
        case "smet":
          return Open<shader_transparent_meter>(name);
        case "spla":
          return Open<shader_transparent_plasma>(name);
        default:
          return null;
      }
    }

    /// <summary>
    /// Gets/Sets level of detail.
    /// </summary>
    public int PixelFillCount
    {
      get { return pixelFillCount; }
      set
      {
        pixelFillCount = value;

        //update Level of Detail setting based on pixel fill
        if (pixelFillCount > modelValues.SuperHighDetailCutoff.Value)
          lod = LevelOfDetail.SuperHigh;
        else if (pixelFillCount > modelValues.HighDetailCutoff.Value)
          lod = LevelOfDetail.High;
        else if (pixelFillCount > modelValues.MediumDetailCutoff.Value)
          lod = LevelOfDetail.Medium;
        else if (pixelFillCount > modelValues.LowDetailCutoff.Value)
          lod = LevelOfDetail.Low;
        else if (pixelFillCount > modelValues.SuperLowDetailCutoff.Value)
          lod = LevelOfDetail.SuperLow;
        else
          lod = LevelOfDetail.SuperLow;
      }
    }

    #region IModel Members

    public ModelType GetModelType
    {
      get { return ModelType.Other; }
    }

    public Interfaces.Rendering.Radiosity.RadiosityIntersection Intersection(Vector3 direction, Vector3 origin)
    {
      throw new Exception("The method or operation is not implemented.");
    }

    #endregion

    #region IRenderable Members


    public bool IntersectCamera(ICamera Camera)
    {
      throw new Exception("The method or operation is not implemented.");
    }

    public bool IntersectPlaneAABB(IPlane Plane)
    {
      throw new Exception("The method or operation is not implemented.");
    }

    #endregion

    public List<ILight> RadiosityLights
    {
      get
      {
        List<ILight> lights = new List<ILight>();
        int g =0;
        foreach (ModelGeometryBlock geometryBlock in modelValues.Geometries)
        {
          int p = 0;
          foreach (ModelGeometryPartBlock partBlock in geometryBlock.Parts)
          {
            if (partBlock.ShaderIndex >= 0)
            {
              shader shader = shaders[partBlock.ShaderIndex];
              if (shader.ShaderValues.Power > 0f)
                foreach (ModelTriangleBlock tri in partBlock.Triangles)
                {
                  lights.Add(new Interfaces.Rendering.Radiosity.DiffuseLight(
                    new Vertex[] { meshes[g][p].Vertices[tri.Vertex0Index], 
                  meshes[g][p].Vertices[tri.Vertex1Index], 
                  meshes[g][p].Vertices[tri.Vertex2Index] },
                    new RealColor(shader.ShaderValues.ColorOfEmittedLight),
                    shader.ShaderValues.Power));
                }
            }
            p++;
          }
          g++;
        }
        return lights;
      }
    }

   
  }
}
