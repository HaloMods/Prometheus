using System;
using System.Drawing;
using System.IO;
using Microsoft.DirectX;
using Microsoft.DirectX.Direct3D;

namespace Interfaces.Rendering.Primitives
{
  /// <summary>
  /// Represents a bounding box in 3-dimensional space.
  /// </summary>
  public class BoundingBox
  {
    public float[] min = new float[3];
    public float[] max = new float[3];
    private float[] centroidSum = new float[3];
    private int centroidCount = 0;

    private static Material color = new Material();
    private static CustomVertex.PositionColored[] boxOutline = new CustomVertex.PositionColored[18];

    public BoundingBox()
    {
      min[0] = 40000.0f;
      min[0] = 40000.0f;
      min[0] = 40000.0f;
      max[0] = -40000.0f;
      max[0] = -40000.0f;
      max[0] = -40000.0f;
      centroidSum[0] = 0.0f;
      centroidSum[1] = 0.0f;
      centroidSum[2] = 0.0f;
      color.Diffuse = Color.White;
      color.Ambient = Color.White;
    }

    public void SetBounds(Vector3 vec1, Vector3 vec2)
    {
      if (vec1.X > vec2.X)
      {
        min[0] = vec2.X;
        max[0] = vec1.X;
      }
      else
      {
        min[0] = vec1.X;
        max[0] = vec2.X;
      }

      if (vec1.Y > vec2.Y)
      {
        min[1] = vec2.Y;
        max[1] = vec1.Y;
      }
      else
      {
        min[1] = vec1.Y;
        max[1] = vec2.Y;
      }

      if (vec1.Z > vec2.Z)
      {
        min[2] = vec2.Z;
        max[2] = vec1.Z;
      }
      else
      {
        min[2] = vec1.Z;
        max[2] = vec2.Z;
      }
    }

    public Color BoxColor
    {
      get { return color.Diffuse; }
      set
      {
        color.Ambient = value;
        color.Diffuse = value;
      }
    }
    public static BoundingBox WorldUnitOrigin
    {
      get
      {
        BoundingBox bb = new BoundingBox();
        bb.Update(-1.0f, -1.0f, -1.0f);
        bb.Update(1.0f, 1.0f, 1.0f);
        return bb;
      }
    }

    public static BoundingBox Zero
    {
      get
      {
        BoundingBox bb = new BoundingBox();
        bb.Update(0.0f, 0.0f, 0.0f);
        return bb;
      }
    }

    public Vector3[] Vertices
    {
      get
      {
        Vector3[] vertices = new Vector3[8];
        vertices[0] = new Vector3(min[0], min[1], min[2]);
        vertices[1] = new Vector3(max[0], min[1], min[2]);
        vertices[2] = new Vector3(min[0], max[1], min[2]);
        vertices[3] = new Vector3(max[0], max[1], min[2]);
        vertices[4] = new Vector3(min[0], min[1], max[2]);
        vertices[5] = new Vector3(max[0], min[1], max[2]);
        vertices[6] = new Vector3(min[0], max[1], max[2]);
        vertices[7] = new Vector3(max[0], max[1], max[2]);
        return vertices;
      }
    }

    public Vector3 Minimum
    {
      get
      { return new Vector3(min[0], min[1], min[2]); }
    }

    public Vector3 Maximum
    {
      get
      { return new Vector3(max[0], max[1], max[2]); }
    }

    public void Load(BinaryReader br)
    {
      min[0] = br.ReadSingle();
      min[1] = br.ReadSingle();
      min[2] = br.ReadSingle();

      max[0] = br.ReadSingle();
      max[1] = br.ReadSingle();
      max[2] = br.ReadSingle();
    }

    public void Update(float x, float y, float z)
    {
      if (x < min[0])
        min[0] = x;
      if (y < min[1])
        min[1] = y;
      if (z < min[2])
        min[2] = z;

      if (x > max[0])
        max[0] = x;
      if (y > max[1])
        max[1] = y;
      if (z > max[2])
        max[2] = z;

      centroidSum[0] += x;
      centroidSum[1] += y;
      centroidSum[2] += z;
      centroidCount++;
    }

    public void Update(BoundingBox bb)
    {
      Update(bb.min[0], bb.min[1], bb.min[2]);
      Update(bb.max[0], bb.max[1], bb.max[2]);
    }

    public BoundingBox Clone()
    {
      BoundingBox box = new BoundingBox();
      box.min[0] = min[0];
      box.min[1] = min[1];
      box.min[2] = min[2];
      box.max[0] = max[0];
      box.max[1] = max[1];
      box.max[2] = max[2];
      box.centroidCount = centroidCount;
      box.centroidSum[0] = centroidSum[0];
      box.centroidSum[1] = centroidSum[1];
      box.centroidSum[2] = centroidSum[2];
      return box;
    }

    BoundingBox box;
    public BoundingBox Translate(float x, float y, float z)
    {
      //BoundingBox box = Clone();
      // This is kind of ghetto, but it speeds things up about 10x since we don't have
      // to create a new object.
      // We can't initialize the object in the constructor because it is a nested
      // object of the same type of the parent, and will cause a stack overflow.
      if (box == null) box = new BoundingBox();
      box.min[0] = min[0] + x;
      box.min[1] = min[1] + y;
      box.min[2] = min[2] + z;
      box.max[0] = max[0] + x;
      box.max[1] = max[1] + y;
      box.max[2] = max[2] + z;
      box.centroidSum[0] = centroidSum[0] + x;
      box.centroidSum[1] = centroidSum[1] + y;
      box.centroidSum[2] = centroidSum[2] + z;
      return box;
    }

    public void GetCentroid(out float x, out float y, out float z)
    {
      if (centroidCount == 0)
      {
        x = 0;
        y = 0;
        z = 0;
      }
      else
      {
        x = centroidSum[0] / (float)centroidCount;
        y = centroidSum[1] / (float)centroidCount;
        z = centroidSum[2] / (float)centroidCount;
      }
    }

    public void GetCenter(out float x, out float y, out float z)
    {
      x = (max[0] + min[0]) / 2.0f;
      y = (max[1] + min[1]) / 2.0f;
      z = (max[2] + min[2]) / 2.0f;
    }

    public float Radius
    {
      get
      {
        float dist1, dist2;

        dist1 = (float)Math.Sqrt(min[0] * min[0] + min[1] * min[1] + min[2] * min[2]);
        dist2 = (float)Math.Sqrt(max[0] * max[0] + max[1] * max[1] + max[2] * max[2]);

        return Math.Max(dist1, dist2);
      }
    }

    public void RenderBoundingBox()
    {
      Vector3 tempMin = new Vector3(min[0], min[1], min[2]);
      Vector3 tempMax = new Vector3(max[0], max[1], max[2]);

      for (int i = 0; i < boxOutline.Length; i++)
        boxOutline[i].Color = color.Diffuse.ToArgb();// Color.DarkGray.ToArgb();

      boxOutline[0].X = tempMin.X;
      boxOutline[0].Y = tempMin.Y;
      boxOutline[0].Z = tempMin.Z;

      boxOutline[1].X = tempMin.X;
      boxOutline[1].Y = tempMax.Y;
      boxOutline[1].Z = tempMin.Z;

      boxOutline[2].X = tempMax.X;
      boxOutline[2].Y = tempMax.Y;
      boxOutline[2].Z = tempMin.Z;

      boxOutline[3].X = tempMax.X;
      boxOutline[3].Y = tempMin.Y;
      boxOutline[3].Z = tempMin.Z;

      boxOutline[4].X = tempMin.X;
      boxOutline[4].Y = tempMin.Y;
      boxOutline[4].Z = tempMin.Z;

      boxOutline[5].X = tempMin.X;
      boxOutline[5].Y = tempMin.Y;
      boxOutline[5].Z = tempMax.Z;

      boxOutline[6].X = tempMin.X;
      boxOutline[6].Y = tempMax.Y;
      boxOutline[6].Z = tempMax.Z;

      boxOutline[7].X = tempMin.X;
      boxOutline[7].Y = tempMax.Y;
      boxOutline[7].Z = tempMin.Z;

      boxOutline[8].X = tempMin.X;
      boxOutline[8].Y = tempMax.Y;
      boxOutline[8].Z = tempMax.Z;

      boxOutline[9].X = tempMax.X;
      boxOutline[9].Y = tempMax.Y;
      boxOutline[9].Z = tempMax.Z;

      boxOutline[10].X = tempMax.X;
      boxOutline[10].Y = tempMax.Y;
      boxOutline[10].Z = tempMin.Z;

      boxOutline[11].X = tempMax.X;
      boxOutline[11].Y = tempMax.Y;
      boxOutline[11].Z = tempMax.Z;

      boxOutline[12].X = tempMax.X;
      boxOutline[12].Y = tempMin.Y;
      boxOutline[12].Z = tempMax.Z;

      boxOutline[13].X = tempMax.X;
      boxOutline[13].Y = tempMin.Y;
      boxOutline[13].Z = tempMin.Z;

      boxOutline[14].X = tempMax.X;
      boxOutline[14].Y = tempMin.Y;
      boxOutline[14].Z = tempMax.Z;

      boxOutline[15].X = tempMin.X;
      boxOutline[15].Y = tempMin.Y;
      boxOutline[15].Z = tempMax.Z;

      boxOutline[16].X = tempMin.X;
      boxOutline[16].Y = tempMin.Y;
      boxOutline[16].Z = tempMin.Z;

      boxOutline[17].X = tempMin.X;
      boxOutline[17].Y = tempMin.Y;
      boxOutline[17].Z = tempMax.Z;

      //color.Diffuse = Color.White;
      //color.Ambient = Color.White;
      MdxRender.Device.Material = color;
      MdxRender.ConfigureForDiffuseColor();
      MdxRender.Device.VertexFormat = CustomVertex.PositionColored.Format;
      MdxRender.Device.DrawUserPrimitives(PrimitiveType.LineStrip, 16, boxOutline);
    }

    /// <summary>
    /// Ray-Axis Aligned Bounding Box intersection test. (Un-tested)
    /// </summary>
    /// <param name="position">Start position of ray.</param>
    /// <param name="direction">Direction of ray.</param>
    public bool RayAABBIntersect(Vector3 position, Vector3 direction)
    {
      const int DimensionCount = 3;

      int whichPlane;
      bool inside = true;
      float[] coord = new float[DimensionCount]; //Point of intersection.
      float[] dir = new float[DimensionCount] { direction.X, direction.Y, direction.Z };
      float[] origin = new float[DimensionCount] { position.X, position.Y, position.Z };
      float[] maxT = new float[DimensionCount];
      float[] candidatePlane = new float[DimensionCount];
      Region[] quadrant = new Region[DimensionCount];

      /* Find candidate planes; this loop can be avoided if
        rays cast all from the eye(assume perpsective view) */
      for (int i = 0; i < DimensionCount; i++)
      {
        if (origin[i] < min[i])
        {
          quadrant[i] = Region.Left;
          candidatePlane[i] = min[i];
          inside = false;
        }
        else if (origin[i] > max[i])
        {
          quadrant[i] = Region.Right;
          candidatePlane[i] = max[i];
          inside = false;
        }
        else
        {
          quadrant[i] = Region.Middle;
        }
      }

      /* Ray origin inside bounding box */
      if (inside)
      {
        coord = origin;
        return true;
      }

      /* Calculate T distances to candidate planes */
      for (int i = 0; i < DimensionCount; i++)
      {
        if (quadrant[i] != Region.Middle && dir[i] != 0)
          maxT[i] = (candidatePlane[i] - origin[i]) / dir[i];
        else
          maxT[i] = -1;
      }

      /* Get largest of the maxT's for final choice of intersection */
      whichPlane = 0;
      for (int i = 1; i < DimensionCount; i++)
      {
        if (maxT[whichPlane] < maxT[i])
          whichPlane = i;
      }

      /* Check final candidate actually inside box */
      if (maxT[whichPlane] < 0)
        return false;

      for (int i = 0; i < DimensionCount; i++)
      {
        if (whichPlane != i)
        {
          coord[i] = origin[i] + maxT[whichPlane] * dir[i];
          if (coord[i] < min[i] || coord[i] > max[i])
            return false;
        }
        else
        {
          coord[i] = candidatePlane[i];
        }
      }
      /* ray hits box */
      return true;
    }
    public bool RayAABBStandard(Ray ray, out float t)
    {
      /*float tnear = -1e6;
      float tfar = 1e6;

      if (r->i == 0.0)
      {
        if ((r->x < b->x0) || (r->x > b->x1))
          return false;
      }
      else
      {
        // multiply by the inverse instead of dividing
        float t1 = (b->x0 - r->x) * r->ii;
        float t2 = (b->x1 - r->x) * r->ii;

        if (t1 > t2)
        {
          float temp = t1;
          t1 = t2;
          t2 = temp;
        }
        if (t1 > tnear)
          tnear = t1;
        if (t2 < tfar)
          tfar = t2;

        if (tnear > tfar)
          return false;
        if (tfar < 0.0)
          return false;
      }

      if (r->j == 0.0)
      {
        if ((r->y < b->y0) || (r->y > b->y1))
          return false;
      }
      else
      {
        float t1 = (b->y0 - r->y) * r->ij;
        float t2 = (b->y1 - r->y) * r->ij;

        if (t1 > t2)
        {
          float temp = t1;
          t1 = t2;
          t2 = temp;
        }
        if (t1 > tnear)
          tnear = t1;
        if (t2 < tfar)
          tfar = t2;

        if (tnear > tfar)
          return false;
        if (tfar < 0.0)
          return false;
      }

      if (r->k == 0.0)
      {
        if ((r->z < b->z0) || (r->z > b->z1))
          return false;
      }
      else
      {
        float t1 = (b->z0 - r->z) * r->ik;
        float t2 = (b->z1 - r->z) * r->ik;

        if (t1 > t2)
        {
          float temp = t1;
          t1 = t2;
          t2 = temp;
        }
        if (t1 > tnear)
          tnear = t1;
        if (t2 < tfar)
          tfar = t2;

        if (tnear > tfar)
          return false;
        if (tfar < 0.0)
          return false;
      }

      *t = tnear;
      return true;*/
      t = float.NaN;
      return true;
    }
    public bool RayAABBPluecker(Ray ray, out float t)
    {
      // Proven to be 93% faster, but is 500x longer... x_x
      /*
       if(r->i < 0) 
	{
		if(r->j < 0) 
		{
			if(r->k < 0)
			{
				// case MMM: side(R,HD) < 0 or side(R,FB) > 0 or side(R,EF) > 0 or side(R,DC) < 0 or side(R,CB) < 0 or side(R,HE) > 0 to miss

				if ((r->x < b->x0) || (r->y < b->y0) || (r->z < b->z0))
					return false;

				float xa = b->x0 - r->x; 
				float ya = b->y0 - r->y; 
				float za = b->z0 - r->z; 
				float xb = b->x1 - r->x;
				float yb = b->y1 - r->y;
				float zb = b->z1 - r->z;

				if(	(r->i * ya - r->j * xb < 0) ||
					(r->i * yb - r->j * xa > 0) ||
					(r->i * zb - r->k * xa > 0) ||
					(r->i * za - r->k * xb < 0) ||
					(r->j * za - r->k * yb < 0) ||
					(r->j * zb - r->k * ya > 0))
					return false;

				// compute the intersection distance

				*t = xb * r->ii;
				float t1 = yb * r->ij;
				if(t1 > *t)
					*t = t1;
				float t2 = zb * r->ik;
				if(t2 > *t)
					*t = t2;

				return true;
			}
			else
			{
				// case MMP: side(R,HD) < 0 or side(R,FB) > 0 or side(R,HG) > 0 or side(R,AB) < 0 or side(R,DA) < 0 or side(R,GF) > 0 to miss

				if ((r->x < b->x0) || (r->y < b->y0) || (r->z > b->z1))
					return false;

				float xa = b->x0 - r->x; 
				float ya = b->y0 - r->y; 
				float za = b->z0 - r->z; 
				float xb = b->x1 - r->x;
				float yb = b->y1 - r->y;
				float zb = b->z1 - r->z;

				if(	(r->i * ya - r->j * xb < 0) ||
					(r->i * yb - r->j * xa > 0) ||
					(r->i * zb - r->k * xb > 0) ||
					(r->i * za - r->k * xa < 0) ||
					(r->j * za - r->k * ya < 0) ||
					(r->j * zb - r->k * yb > 0))
					return false;

				*t = xb * r->ii;
				float t1 = yb * r->ij;
				if(t1 > *t)
					*t = t1;
				float t2 = za * r->ik;
				if(t2 > *t)
					*t = t2;

				return true;
			}
		} 
		else 
		{
			if(r->k < 0)
			{
				// case MPM: side(R,EA) < 0 or side(R,GC) > 0 or side(R,EF) > 0 or side(R,DC) < 0 or side(R,GF) < 0 or side(R,DA) > 0 to miss

				if ((r->x < b->x0) || (r->y > b->y1) || (r->z < b->z0))
					return false;

				float xa = b->x0 - r->x; 
				float ya = b->y0 - r->y; 
				float za = b->z0 - r->z; 
				float xb = b->x1 - r->x;
				float yb = b->y1 - r->y;
				float zb = b->z1 - r->z;

				if(	(r->i * ya - r->j * xa < 0) ||
					(r->i * yb - r->j * xb > 0) ||
					(r->i * zb - r->k * xa > 0) ||
					(r->i * za - r->k * xb < 0) ||
					(r->j * zb - r->k * yb < 0) ||
					(r->j * za - r->k * ya > 0))
					return false;

				*t = xb * r->ii;
				float t1 = ya * r->ij;
				if(t1 > *t)
					*t = t1;
				float t2 = zb * r->ik;
				if(t2 > *t)
					*t = t2;

				return true;
			}
			else
			{
				// case MPP: side(R,EA) < 0 or side(R,GC) > 0 or side(R,HG) > 0 or side(R,AB) < 0 or side(R,HE) < 0 or side(R,CB) > 0 to miss

				if ((r->x < b->x0) || (r->y > b->y1) || (r->z > b->z1))
					return false;

				float xa = b->x0 - r->x; 
				float ya = b->y0 - r->y; 
				float za = b->z0 - r->z; 
				float xb = b->x1 - r->x;
				float yb = b->y1 - r->y;
				float zb = b->z1 - r->z;

				if(	(r->i * ya - r->j * xa < 0) ||
					(r->i * yb - r->j * xb > 0) ||
					(r->i * zb - r->k * xb > 0) ||
					(r->i * za - r->k * xa < 0) ||
					(r->j * zb - r->k * ya < 0) ||
					(r->j * za - r->k * yb > 0))
					return false;

				*t = xb * r->ii;
				float t1 = ya * r->ij;
				if(t1 > *t)
					*t = t1;
				float t2 = za * r->ik;
				if(t2 > *t)
					*t = t2;

				return true;
			}
		}
	}
	else 
	{
		if(r->j < 0) 
		{
			if(r->k < 0)
			{
				// case PMM: side(R,GC) < 0 or side(R,EA) > 0 or side(R,AB) > 0 or side(R,HG) < 0 or side(R,CB) < 0 or side(R,HE) > 0 to miss

				if ((r->x > b->x1) || (r->y < b->y0) || (r->z < b->z0))
					return false;

				float xa = b->x0 - r->x; 
				float ya = b->y0 - r->y; 
				float za = b->z0 - r->z; 
				float xb = b->x1 - r->x;
				float yb = b->y1 - r->y;
				float zb = b->z1 - r->z;

				if(	(r->i * yb - r->j * xb < 0) ||
					(r->i * ya - r->j * xa > 0) ||
					(r->i * za - r->k * xa > 0) ||
					(r->i * zb - r->k * xb < 0) ||
					(r->j * za - r->k * yb < 0) ||
					(r->j * zb - r->k * ya > 0))
					return false;

				*t = xa * r->ii;
				float t1 = yb * r->ij;
				if(t1 > *t)
					*t = t1;
				float t2 = zb * r->ik;
				if(t2 > *t)
					*t = t2;

				return true;
			}
			else
			{
				// case PMP: side(R,GC) < 0 or side(R,EA) > 0 or side(R,DC) > 0 or side(R,EF) < 0 or side(R,DA) < 0 or side(R,GF) > 0 to miss

				if ((r->x > b->x1) || (r->y < b->y0) || (r->z > b->z1))
					return false;

				float xa = b->x0 - r->x; 
				float ya = b->y0 - r->y; 
				float za = b->z0 - r->z; 
				float xb = b->x1 - r->x;
				float yb = b->y1 - r->y;
				float zb = b->z1 - r->z;

				if(	(r->i * yb - r->j * xb < 0) ||
					(r->i * ya - r->j * xa > 0) ||
					(r->i * za - r->k * xb > 0) ||
					(r->i * zb - r->k * xa < 0) ||
					(r->j * za - r->k * ya < 0) ||
					(r->j * zb - r->k * yb > 0))
					return false;

				*t = xa * r->ii;
				float t1 = yb * r->ij;
				if(t1 > *t)
					*t = t1;
				float t2 = za * r->ik;
				if(t2 > *t)
					*t = t2;

				return true;
			}
		}
		else 
		{
			if(r->k < 0)
			{
				// case PPM: side(R,FB) < 0 or side(R,HD) > 0 or side(R,AB) > 0 or side(R,HG) < 0 or side(R,GF) < 0 or side(R,DA) > 0 to miss

				if ((r->x > b->x1) || (r->y > b->y1) || (r->z < b->z0))
					return false;

				float xa = b->x0 - r->x; 
				float ya = b->y0 - r->y; 
				float za = b->z0 - r->z; 
				float xb = b->x1 - r->x;
				float yb = b->y1 - r->y;
				float zb = b->z1 - r->z;

				if(	(r->i * yb - r->j * xa < 0) ||
					(r->i * ya - r->j * xb > 0) ||
					(r->i * za - r->k * xa > 0) ||
					(r->i * zb - r->k * xb < 0) ||
					(r->j * zb - r->k * yb < 0) ||
					(r->j * za - r->k * ya > 0))
					return false;

				*t = xa * r->ii;
				float t1 = ya * r->ij;
				if(t1 > *t)
					*t = t1;
				float t2 = zb * r->ik;
				if(t2 > *t)
					*t = t2;

				return true;
			}
			else
			{
				// case PPP: side(R,FB) < 0 or side(R,HD) > 0 or side(R,DC) > 0 or side(R,EF) < 0 or side(R,HE) < 0 or side(R,CB) > 0 to miss

				if ((r->x > b->x1) || (r->y > b->y1) || (r->z > b->z1))
					return false;

				float xa = b->x0 - r->x; 
				float ya = b->y0 - r->y; 
				float za = b->z0 - r->z; 
				float xb = b->x1 - r->x;
				float yb = b->y1 - r->y;
				float zb = b->z1 - r->z;

				if(	(r->i * yb - r->j * xa < 0) ||
					(r->i * ya - r->j * xb > 0) ||
					(r->i * za - r->k * xb > 0) ||
					(r->i * zb - r->k * xa < 0) ||
					(r->j * zb - r->k * ya < 0) ||
					(r->j * za - r->k * yb > 0))
					return false;

				*t = xa * r->ii;
				float t1 = ya * r->ij;
				if(t1 > *t)
					*t = t1;
				float t2 = za * r->ik;
				if(t2 > *t)
					*t = t2;

				return true;
			}
		}
	}

	return false;
       */
      t = float.NaN;
      return true;
    }
  }
}
