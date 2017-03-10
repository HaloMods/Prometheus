using System;
using System.Collections.Generic;
using System.Text;

using Interfaces.Rendering.Radiosity;

namespace Core.Radiosity.PhotonMapping
{
  public static class QuickSort
  {
    /*public static void Sort<T>(List<T> array, int start, int end) where T: IComparable<T>
    {

    }*/
    public static void Sort<T>(List<T> array, int left, int right) where T : IComparable<T>
    {
      T pivot;
      int lHold, rHold;
      lHold = left;
      rHold = right;
      pivot = array[left];

      while (left < right)
      {
        while ((array[right].CompareTo(pivot) >= 0) && (left < right))
          right--;
        if (left != right)
        {
          array[left] = array[right];
          left++;
        }
        while ((array[left].CompareTo(pivot) <= 0) && (left < right))
          left++;
        if (left != right)
        {
          array[right] = array[left];
          right--;
        }
      }
      array[left] = pivot;
      int newPivot = left;
      left = lHold;
      right = rHold;

      if (left < newPivot)
        Sort(array, left, newPivot - 1);
      if (right > newPivot)
        Sort(array, newPivot + 1, right);
    }
    public static void Sort(PhotonVector3[] array, int left, int right, int axis)
    {
      PhotonVector3 pivot;
      int lHold, rHold;
      lHold = left;
      rHold = right;
      pivot = array[left];

      while (left < right)
      {
        while ((array[right][axis] >= pivot[axis]) && (left < right))
          right++;
        if (left != right)
        {
          array[left] = array[right];
          left++;
        }
        while ((array[left][axis] <= pivot[axis]) && (left < right))
          left++;
        if (left != right)
        {
          array[right] = array[left];
          right--;
        }
      }
      array[left] = pivot;
      int newPivot = left;
      left = lHold;
      right = rHold;

      if (left < newPivot)
        Sort(array, left, newPivot - 1, axis);
      if (right > newPivot)
        Sort(array, newPivot + 1, right, axis);
    }
    public static void Sort(List<CompressedPhoton> array, int left, int right, int axis)
    {
      CompressedPhoton pivot;
      int lHold, rHold;
      lHold = left;
      rHold = right;
      pivot = array[left];

      while (left < right)
      {
        while ((array[right].position[axis] >= pivot.position[axis]) && (left < right))
          right--;
        if (left != right)
        {
          array[left] = array[right];
          left++;
        }
        while ((array[left].position[axis] <= pivot.position[axis]) && (left < right))
          left++;
        if (left != right)
        {
          array[right] = array[left];
          right--;
        }
      }
      array[left] = pivot;
      int newPivot = left;
      left = lHold;
      right = rHold;

      if (left < newPivot)
        Sort(array, left, newPivot - 1, axis);
      if (right > newPivot)
        Sort(array, newPivot + 1, right, axis);
    }
  }
}
