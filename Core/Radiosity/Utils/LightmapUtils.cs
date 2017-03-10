using System;
using System.Collections.Generic;
using System.Drawing;
using Microsoft.DirectX;
using Microsoft.DirectX.Direct3D;
using Interfaces.Rendering;
using Core.Rendering;


namespace Core.Radiosity
{
    #region Grens lightmap debug stuff
    public class GrenLightmapDebug
    {
        private CustomVertex.PositionColored[] vertData = new CustomVertex.PositionColored[1000];
        private int mycount = 0;
        private CustomVertex.PositionColored[] lineData = new CustomVertex.PositionColored[2000];
        private int lineCount = 0;

        public void AddRay(Vector3 start, Vector3 end)
        {
            if (lineCount < 1999)
            {
                lineData[lineCount] = new CustomVertex.PositionColored(start.X, start.Y, start.Z, Color.Magenta.ToArgb());
                lineCount++;
                lineData[lineCount] = new CustomVertex.PositionColored(end.X, end.Y, end.Z, Color.Magenta.ToArgb());
                lineCount++;
            }
        }

        public void AddIntersectPoint(Vector3 pt)
        {
            if (mycount < 1000)
            {
                vertData[mycount] = new CustomVertex.PositionColored(pt.X, pt.Y, pt.Z, Color.Magenta.ToArgb());
                mycount++;
            }
        }

        public void Reset()
        {
            for (int i = 0; i < 1000; i++)
                vertData[i] = new CustomVertex.PositionColored(0, 0, 0, Color.Magenta.ToArgb());

            for (int i = 0; i < 2000; i++)
                lineData[i] = new CustomVertex.PositionColored(0, 0, 0, Color.Magenta.ToArgb());

            mycount = 0;
            lineCount = 0;
        }

        public void Render()
        {
            Material bbColor = new Material();
            bbColor.Diffuse = Color.Magenta;
            bbColor.Ambient = Color.White;
            MdxRender.Device.Material = bbColor;
            MdxRender.Device.TextureState[0].ColorArgument2 = TextureArgument.Diffuse;
            MdxRender.Device.TextureState[0].ColorOperation = TextureOperation.SelectArg2;
            MdxRender.Device.TextureState[1].ColorOperation = TextureOperation.Disable;
            MdxRender.Device.RenderState.Lighting = false;
            MdxRender.Device.DrawUserPrimitives(PrimitiveType.PointList, mycount, vertData);
            MdxRender.Device.DrawUserPrimitives(PrimitiveType.LineList, lineCount / 2, lineData);
            MdxRender.Device.RenderState.Lighting = true;
        }
    }
    #endregion

    #region Fast Min\Max
    /// <summary>
    /// Calculates the minium and maximum values contained in the array.
    /// </summary>
    /// <typeparam name="T">Generic type T</typeparam>
    public class FastMinMax<T>
        where T : IComparable
    {
        /// <summary>
        /// Calculates min\max simultaneously.
        /// O(logn) efficient, for large n.
        /// </summary>
        /// <param name="array"></param>
        /// <returns></returns>
        public T[] SimMinMax(T[] array)
        {
            if (array.Length > 2)
            {
                T min, max;

                // Subdivide array into two.
                T[] larray = new T[(int)Math.Ceiling((float)array.Length / 2)];
                T[] rarray = new T[(int)Math.Ceiling((float)array.Length / 2)];

                // Copy array parts.
                Array.Copy(array, 0, larray, 0, larray.Length);
                Array.Copy(array, array.Length / 2, rarray, 0, rarray.Length);

                T[] x = this.SimMinMax(larray);
                T[] y = this.SimMinMax(rarray);

                // Calculate min.
                if (x[0].CompareTo(y[0]) < 0)
                    min = x[0];
                else
                    min = y[0];

                // Calculate max.
                if (x[x.Length - 1].CompareTo(y[y.Length - 1]) > 0)
                    max = x[x.Length - 1];
                else
                    max = y[y.Length - 1];

                return new T[] { min, max };
            }
            else
            {
                T min, max;

                // Calculate min\max for array dimension two.
                if (array[0].CompareTo(array[array.Length - 1]) < 0)
                    min = array[0];
                else
                    min = array[array.Length - 1];

                if (array[0].CompareTo(array[array.Length - 1]) > 0)
                    max = array[0];
                else
                    max = array[array.Length - 1];

                return new T[] { min, max };
            }
        }
    }
    #endregion
}
