using System;
using System.Collections;
using Games.Halo.Compiler.XPE;

namespace Games.Halo.Compiler
{
  /// <summary>
  /// Generates predicted resources to be used by objects, scenarios, and structure bsps.
  /// </summary>
  public class Predictor
  {
    private uint resourceCount = 0;
    private TagLibrary lib = null;

    public class PredictedResource
    {
      public int tag;
      public short index;
      public short type;

      public PredictedResource(int Tag, short Index, short Type)
      {
        tag = Tag;
        index = Index;
        type = Type;
      }
    }

    private int[] GenerateShaderModel(Tag tag)
    {
      byte count = 0;
      if (tag == null)
        return new int[0];
      int baseIndex = (int)tag["base map"];
      int multiIndex = (int)tag["multipurpose map"];
      int detailIndex = (int)tag["detail map"];
      int reflectionIndex = (int)tag["reflection cube map"];

      if (baseIndex >= 0)
        count++;
      if (multiIndex >= 0)
        count++;
      if (detailIndex >= 0)
        count++;
      if (reflectionIndex >= 0)
        count++;

      int[] resources = new int[count];
      resourceCount += count;
      count = 0;

      if (baseIndex >= 0)
        resources[count++] = baseIndex;
      if (multiIndex >= 0)
        resources[count++] = multiIndex;
      if (detailIndex >= 0)
        resources[count++] = detailIndex;
      if (reflectionIndex >= 0)
        resources[count++] = reflectionIndex;

      return resources;
    }

    private int[] GenerateShaderGlass(Tag tag)
    {
      byte count = 0;
      if (tag == null)
        return new int[0];
      int tintIndex = (int)tag["background tint map"];
      int reflectionIndex = (int)tag["reflection map"];
      int bumpIndex = (int)tag["bump map"];
      int diffuseIndex = (int)tag["diffuse map"];
      int detailIndex = (int)tag["diffuse detail map"];
      int specularIndex = (int)tag["specular map"];

      if (tintIndex >= 0)
        count++;
      if (reflectionIndex >= 0)
        count++;
      if (bumpIndex >= 0)
        count++;
      if (diffuseIndex >= 0)
        count++;
      if (detailIndex >= 0)
        count++;
      if (specularIndex >= 0)
        count++;

      int[] resources = new int[count];
      resourceCount += count;
      count = 0;

      if (tintIndex >= 0)
        resources[count++] = tintIndex;
      if (reflectionIndex >= 0)
        resources[count++] = reflectionIndex;
      if (bumpIndex >= 0)
        resources[count++] = bumpIndex;
      if (diffuseIndex >= 0)
        resources[count++] = diffuseIndex;
      if (detailIndex >= 0)
        resources[count++] = detailIndex;
      if (specularIndex >= 0)
        resources[count++] = specularIndex;

      return resources;
    }

    private int[] GenerateShaderEnvironment(Tag tag)
    {
      byte count = 0;
      if (tag == null)
        return new int[0];
      int baseIndex = (int)tag["base map"];
      int bumpIndex = (int)tag["bump map"];
      int multiIndex = (int)tag["map"];
      int pDetailIndex = (int)tag["primary detail map"];
      int sDetailIndex = (int)tag["secondary detail map"];
      int mDetailIndex = (int)tag["micro detail map"];
      int reflectionIndex = (int)tag["reflection cube map"];

      if (baseIndex >= 0)
        count++;
      if (bumpIndex >= 0)
        count++;
      if (multiIndex >= 0)
        count++;
      if (pDetailIndex >= 0)
        count++;
      if (sDetailIndex >= 0)
        count++;
      if (mDetailIndex >= 0)
        count++;
      if (reflectionIndex >= 0)
        count++;

      int[] resources = new int[count];
      resourceCount += count;
      count = 0;

      if (baseIndex >= 0)
        resources[count++] = baseIndex;
      if (pDetailIndex >= 0)
        resources[count++] = pDetailIndex;
      if (sDetailIndex >= 0)
        resources[count++] = sDetailIndex;
      if (mDetailIndex >= 0)
        resources[count++] = mDetailIndex;
      if (bumpIndex >= 0)
        resources[count++] = bumpIndex;
      if (multiIndex >= 0)
        resources[count++] = multiIndex;
      if (reflectionIndex >= 0)
        resources[count++] = reflectionIndex;

      return resources;
    }

    private void GenerateStructureBsp(Tag tag)
    {
      // Just getting started and I'm already sick of this shit...
      Xpe sbsp = lib.CXPE["sbsp"];
      Xpe.Field lightmaps = sbsp.FieldByName("structure lightmaps");
      Xpe.Field materials = lightmaps.FieldByName("structure materials");
      Xpe.Field clusters = sbsp.FieldByName("clusters");
      Xpe.Field resources = clusters.FieldByName("predicted resources");
      Xpe.Field subclusters = clusters.FieldByName("subclusters");
      int ilightmaps = sbsp.IndexByName("structure lightmaps");
      int imaterials = lightmaps["structure materials"];
      int ifaces = materials["surfaces"];
      int icount = materials["surface count"];
      int ishader = materials["shader"];
      int iclusters = sbsp.IndexByName("clusters");
      int iresources = clusters["predicted resources"];
      int isubclusters = clusters["subclusters"];
      int isurfaces = subclusters["surface indices"];

      // Sigh... this is going to be the slowest resource builder ever...
      int lightmapTag = (int)tag["lightmaps"];
      Array vis = tag["cluster data"] as Array;
      Array cluster = tag["clusters"] as Array;
      for (int clusterIndex = 0; clusterIndex < cluster.GetLength(0); clusterIndex++)
      {
        ArrayList localResources = new ArrayList();

        for (int innerClusterIndex = 0; innerClusterIndex < cluster.GetLength(0); innerClusterIndex++)
        {
          if (innerClusterIndex == clusterIndex || IsClusterVisible(clusterIndex, innerClusterIndex, cluster.GetLength(0), vis as byte[]))
          {
            Array subcluster = cluster.GetValue(clusterIndex, isubclusters) as Array;
            for (int subclusterIndex = 0; subclusterIndex < subcluster.GetLength(0); subclusterIndex++)
            {
              Array surface = subcluster.GetValue(subclusterIndex, isurfaces) as Array;
              for (int indexIndex = 0; indexIndex < surface.GetLength(0); indexIndex++)
              {
                Array lightmap = tag["structure lightmaps"] as Array;
                for (int lightmapIndex = 0; lightmapIndex < lightmap.GetLength(0); lightmapIndex++)
                {
                  short lightmapResourceIndex = (short)lightmap.GetValue(lightmapIndex, 0);
                  Array material = lightmap.GetValue(lightmapIndex, imaterials) as Array;
                  for (int materialIndex = 0; materialIndex < material.GetLength(0); materialIndex++)
                  {
                    int shaderIndex = (int)material.GetValue(materialIndex, ishader);
                    int localFace = (int)surface.GetValue(indexIndex, 0) - (int)material.GetValue(materialIndex, ifaces);
                    int faceCount = (int)material.GetValue(materialIndex, icount);
                    if (localFace >= 0)
                    {
                      if (localFace < faceCount)
                      {
                        foreach (PredictedResource pr in localResources)
                          if (pr.index == lightmapResourceIndex)
                            goto getShader;
                        localResources.Add(new PredictedResource(lightmapTag, lightmapResourceIndex, 0));

                      getShader:
                        Tag shader = lib[shaderIndex];
                        if (shader.Xpe.FourCC != "senv" && shader.Xpe.FourCC != "soso" && shader.Xpe.FourCC != "sgla")
                          goto getNextSurface;

                        int[] shaderResources = shader.Xpe.FourCC == "senv" ? GenerateShaderEnvironment(shader) : shader.Xpe.FourCC == "soso" ? GenerateShaderModel(shader) : GenerateShaderGlass(shader);
                        foreach (int bitmap in shaderResources) // Not another one!..
                        {
                          foreach (PredictedResource pr in localResources) // GAH I'M GONNA GO INSANE!!!
                            if (pr.tag == bitmap)
                              goto getNextBitmap;
                          localResources.Add(new PredictedResource(bitmap, 0, 0));
                        getNextBitmap: ;
                        }
                        goto getNextSurface;
                      }
                    }
                  }
                }

              getNextSurface: ;
              }
            }
          }
        }

        // If we made it this far, we're invincible... Right?..
        int resourceCount = 0;
        foreach (PredictedResource tpr in localResources)
          if (tpr.tag >= 0)
            resourceCount++;
        Array predictedResources = Array.CreateInstance(typeof(object), resourceCount, 3);
        int currentResource = 0;
        foreach (PredictedResource pr in localResources)
        {
          if (pr.tag >= 0)
          {
            predictedResources.SetValue(pr.type, currentResource, 0);
            predictedResources.SetValue(pr.index, currentResource, 1);
            predictedResources.SetValue(lib.GetID(pr.tag), currentResource, 2);
            currentResource++;
          }
        }
        cluster.SetValue(predictedResources, clusterIndex, iresources);
        // WOO-HOO!!!
      }
    }

    private void GenerateObject(Tag tag)
    {
      int modelIndex = (int)tag["model"];
      if (modelIndex < 0)
        return;
      Tag model = lib[modelIndex];

      ArrayList modelResources = new ArrayList();
      Array shaders = model["shaders"] as Array;
      for (int u = 0; u < shaders.GetLength(0); u++)
      {
        int shader = (int)shaders.GetValue(u, 0);
        if (shader < 0)
          continue;
        string type = lib.GetClass(shader);
        if (type != "soso" && type != "senv" && type != "sgla")
          continue;
        int[] shaderResources = type == "soso" ? GenerateShaderModel(lib[shader]) : type == "senv" ? GenerateShaderEnvironment(lib[shader]) : GenerateShaderGlass(lib[shader]);
        foreach (int bitmap in shaderResources)
        {
          foreach (PredictedResource pr in modelResources)
            if (pr.tag == bitmap)
              goto nextBitmap;
          modelResources.Add(new PredictedResource(bitmap, 0, 0));
        nextBitmap: ;
        }
      }

      ArrayList fpResources = new ArrayList();
      if (tag.Xpe.FourCC == "weap")
      {
        int fpIndex = (int)tag["first person model"];
        if (fpIndex < 0)
          return;
        Tag fp = lib[fpIndex];

        Array fpshaders = fp["shaders"] as Array;
        for (int u = 0; u < fpshaders.GetLength(0); u++)
        {
          int fpshader = (int)fpshaders.GetValue(u, 0);
          if (fpshader < 0)
            continue;
          string fptype = lib.GetClass(fpshader);
          if (fptype != "soso" && fptype != "senv")
            continue;
          int[] fpshaderResources = fptype == "soso" ? GenerateShaderModel(lib[fpshader]) : GenerateShaderEnvironment(lib[fpshader]);
          foreach (int fpbitmap in fpshaderResources)
          {
            foreach (PredictedResource pr in fpResources)
              if (pr.tag == fpbitmap)
                goto fpnextBitmap;
            fpResources.Add(new PredictedResource(fpbitmap, 0, 0));
          fpnextBitmap: ;
          }
        }

        int scopeInSound = (int)tag["zoom-in sound"];
        int scopeOutSound = (int)tag["zoom-out sound"];
        if (scopeInSound >= 0)
          fpResources.Add(new PredictedResource(scopeInSound, 0, 1));
        if (scopeOutSound >= 0)
          fpResources.Add(new PredictedResource(scopeOutSound, 0, 1));
      }

      Array predictedResources = Array.CreateInstance(typeof(object), modelResources.Count + fpResources.Count, 3);
      int currentResource = 0;
      foreach (PredictedResource pr in modelResources)
      {
        predictedResources.SetValue(pr.type, currentResource, 0);
        predictedResources.SetValue(pr.index, currentResource, 1);
        predictedResources.SetValue(lib.GetID(pr.tag), currentResource, 2);
        currentResource++;
      }
      foreach (PredictedResource pr in fpResources)
      {
        predictedResources.SetValue(pr.type, currentResource, 0);
        predictedResources.SetValue(pr.index, currentResource, 1);
        predictedResources.SetValue(lib.GetID(pr.tag), currentResource, 2);
        currentResource++;
      }
      tag["predicted resources"] = predictedResources;
    }

    private void GenerateScenario(Tag tag)
    {
      // TODO: Finish this scenario resource code, find out how resource index is used...
      /*Array scriptReferences = tag["references"] as Array;
      PredictedResource[] prs = new PredictedResource[scriptReferences.GetLength(0)];
      for(int u = 0; u < prs.Length; u++)
      {
      }*/
    }

    public void GeneratePRs(Tag tag)
    {
      if (tag.Xpe.FourCC == "sbsp")
      {
        GenerateStructureBsp(tag);
        return;
      }

      if (tag.Xpe.FourCC == "scnr")
      {
        GenerateScenario(tag);
        return;
      }

      if (tag.Xpe.FourCC == "obje" || tag.Xpe.ParentFourCC == "obje" || tag.Xpe.GrandparentFourCC == "obje")
      {
        GenerateObject(tag);
        return;
      }
    }

    public Predictor(TagLibrary tags)
    {
      lib = tags;
    }

    private bool IsClusterVisible(int activeCluster, int testCluster, int clusterCount, byte[] vis)
    {
      int blockSize = (int)Math.Ceiling((float)clusterCount / 32.0f) * 4;
      int offset = testCluster / 8;
      int bit = testCluster % 8;
      byte testByte = vis[blockSize * activeCluster + offset];
      testByte >>= bit;
      testByte &= 0x1;
      return testByte == 1;
    }
  }
}
