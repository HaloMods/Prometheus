using System;
using System.Collections.Generic;
using System.Text;
using Interfaces.Rendering.Radiosity;

namespace Core.Radiosity.PhotonMapping
{
  public static class HeapSort
  {
    public static int Progress, Total;
    public static void NewSort<T>(List<T> a) where T : IComparable<T>
    {
      int n = a.Count;
      Total = (n / 2 + n - 3);
      Progress = 0;
      for (int v = n / 2 - 1; v >= 0; v--)
      {
        DownHeap(a, v, n);
        Progress++;
      }


      while (n > 1)
      {
        n--;
        exchange(a, 0, n);
        DownHeap(a, 0, n);
        Progress++;
      }
    }

    public static void DownHeap<T>(List<T> a, int v, int n) where T : IComparable<T>
    {
      int w = 2 * v + 1;    // first descendant of v
      while (w < n)
      {
        if (w + 1 < n)    // is there a second descendant?
          if (a[w + 1].CompareTo(a[w]) > 0) w++;
        // w is the descendant of v with maximum label

        if (a[v].CompareTo(a[w]) >= 0) return;  // v has heap property
        // otherwise
        exchange(a, v, w);  // exchange labels of v and w
        v = w;        // continue
        w = 2 * v + 1;
      }
    }

    private static void exchange<T>(IList<T> a, int i, int j)
    {
      T t = a[i];
      a[i] = a[j];
      a[j] = t;
    }

    public static void NewSort(IList<CompressedPhoton> a, int axis)
    {
      int n = a.Count;
      for (int v = n / 2 - 1; v >= 0; v--)
        DownHeap(a, v, n, axis);

      while (n > 1)
      {
        n--;
        exchange<CompressedPhoton>(a, 0, n);
        DownHeap(a, 0, n, axis);
      }
    }
    public static void NewSort(CompressedPhoton[] a, int axis)
    {
      int n = a.Length;
      for (int v = n / 2 - 1; v >= 0; v--)
        DownHeap(a, v, n, axis);

      while (n > 1)
      {
        n--;
        exchange<CompressedPhoton>(a, 0, n);
        DownHeap(a, 0, n, axis);
      }
    }

    public static void DownHeap(IList<CompressedPhoton> a, int v, int n, int axis)
    {
      int w = 2 * v + 1;    // first descendant of v
      if (a[v] == null)
      {
        a[v] = new CompressedPhoton();
        a[v].Position = new PhotonVector3(float.MaxValue, float.MaxValue, float.MaxValue);
      }

      while (w < n)
      {
        if (a[w] == null)
        {
          a[w] = new CompressedPhoton();
          a[w].Position = new PhotonVector3(float.MaxValue, float.MaxValue, float.MaxValue);
        }

        if (w + 1 < n)    // is there a second descendant?
        {
          if (a[w + 1] == null)
          {
            a[w + 1] = new CompressedPhoton();
            a[w + 1].position = new PhotonVector3(float.MaxValue, float.MaxValue, float.MaxValue);
          }
          if (a[w + 1].position[axis] > a[w].position[axis]) w++;
        }
        // w is the descendant of v with maximum label


        if (a[v].position[axis] >= a[w].position[axis]) return;  // v has heap property
        // otherwise
        exchange(a, v, w);  // exchange labels of v and w
        v = w;        // continue
        w = 2 * v + 1;
      }
    }
    public static void DownHeap(CompressedPhoton[] a, int v, int n, int axis)
    {
      int w = 2 * v + 1;    // first descendant of v
      if (a[v] == null)
      {
        a[v] = new CompressedPhoton();
        a[v].Position = new PhotonVector3(float.MaxValue, float.MaxValue, float.MaxValue);
      }

      while (w < n)
      {
        if (a[w] == null)
        {
          a[w] = new CompressedPhoton();
          a[w].Position = new PhotonVector3(float.MaxValue, float.MaxValue, float.MaxValue);
        }

        if (w + 1 < n)    // is there a second descendant?
        {
          if (a[w + 1] == null)
          {
            a[w + 1] = new CompressedPhoton();
            a[w + 1].position = new PhotonVector3(float.MaxValue, float.MaxValue, float.MaxValue);
          }
          if (a[w + 1].position[axis] > a[w].position[axis]) w++;
        }
        // w is the descendant of v with maximum label


        if (a[v].position[axis] >= a[w].position[axis]) return;  // v has heap property
        // otherwise
        exchange(a, v, w);  // exchange labels of v and w
        v = w;        // continue
        w = 2 * v + 1;
      }
    }

    public static void NewSort(CompressedPhoton[] a, int axis, int start, int length)
    {
      int n = length;
      for (int v = n / 2 - 1; v >= start; v--)
        DownHeap(a, v, n, axis, start, length);

      while (n > 1)
      {
        n--;
        exchange<CompressedPhoton>(a, start, n+start);
        DownHeap(a, 0, n, axis, start, length);
      }
    }
    public static void DownHeap(CompressedPhoton[] a, int v, int n, int axis, int start, int length)
    {
      int w = 2 * v + 1;    // first descendant of v
      /*if (a[v+start] == null)
      {
        a[v+start] = new CompressedPhoton();
        a[v+start].Position = new PhotonVector3(float.MaxValue, float.MaxValue, float.MaxValue);
      }*/

      while (w < n)
      {
        /*if (a[w + start] == null)
        {
          a[w + start] = new CompressedPhoton();
          a[w + start].Position = new PhotonVector3(float.MaxValue, float.MaxValue, float.MaxValue);
        }*/

        if (w + 1 < n)    // is there a second descendant?
        {
          /*if (a[w + 1 + start] == null)
          {
            a[w + 1 + start] = new CompressedPhoton();
            a[w + 1 + start].position = new PhotonVector3(float.MaxValue, float.MaxValue, float.MaxValue);
          }*/
          if (a[w + 1 + start].position[axis] > a[w + start].position[axis]) w++;
        }
        // w is the descendant of v with maximum label


        if (a[v + start].position[axis] >= a[w + start].position[axis]) return;  // v has heap property
        // otherwise
        exchange(a, v + start, w + start);  // exchange labels of v and w
        v = w;        // continue
        w = 2 * v + 1;
      }
    }

  }
}
