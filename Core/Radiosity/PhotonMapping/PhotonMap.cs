using System;
using System.IO;
using System.Collections.Generic;
using System.Text;
using Microsoft.DirectX;

using Interfaces.Rendering.Primitives;
using Interfaces.Rendering.Radiosity;

namespace Core.Radiosity.PhotonMapping
{
  public class LimitedList<T> : IList<T>
  {
    List<T> back = null;
    int start, length;

    public LimitedList(List<T> a, int start, int length) { back = a; this.start = start; this.length = length; }

    #region IList<T> Members

    public int IndexOf(T item)
    {
      return back.IndexOf(item) - start;
    }

    public void Insert(int index, T item)
    {
      back.Insert(index + start, item);
    }

    public void RemoveAt(int index)
    {
      back.RemoveAt(index + start);
    }

    public T this[int index]
    {
      get
      {
        return back[index + start];
      }
      set
      {
        back[index + start] = value;
      }
    }

    #endregion

    #region ICollection<T> Members

    public void Add(T item)
    {
      throw new Exception("The method or operation is not implemented.");
    }

    public void Clear()
    {
      throw new Exception("The method or operation is not implemented.");
    }

    public bool Contains(T item)
    {
      throw new Exception("The method or operation is not implemented.");
    }

    public void CopyTo(T[] array, int arrayIndex)
    {
      throw new Exception("The method or operation is not implemented.");
    }

    public int Count
    {
      get { return length; }
    }

    public bool IsReadOnly
    {
      get { throw new Exception("The method or operation is not implemented."); }
    }

    public bool Remove(T item)
    {
      throw new Exception("The method or operation is not implemented.");
    }

    #endregion

    #region IEnumerable<T> Members

    public IEnumerator<T> GetEnumerator()
    {
      for (int x = start; x < start + length; x++)
        yield return this.back[x];
    }

    #endregion

    #region IEnumerable Members

    System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
    {
      for (int x = start; x < start + length; x++)
        yield return this.back[x];
    }

    #endregion
  }

  public struct RetrievedPhoton
  {
    public CompressedPhoton photonPtr;
    public float dist2;
    public RetrievedPhoton(CompressedPhoton phtn, float dist)
    {
      photonPtr = phtn;
      dist2 = dist;
    }
  }
  public class RetrievedPhotons
  {
    int index = 0;
    public RetrievedPhoton[] list;

    public RetrievedPhotons(int count)
    {
      list = new RetrievedPhoton[count];
    }

    public void AddIfClosest(CompressedPhoton photon, float dist2)
    {
      int insertPos = 0;
      for (; insertPos < index; insertPos++)
        if (dist2 < list[insertPos].dist2)
          break; // we've found the location this one should be at.

      if (insertPos == index)
      {
        if (index < list.Length)
          list[index++] = new RetrievedPhoton(photon, dist2);
        return;
      }

      if (index == list.Length)
        return; // the list is fully populated.

      int end = index + 1; // start one slot to the right of the last record.

      // if we can't start there, start at the second to the last entry, overwriting the last one.
      if (end >= list.Length) end = list.Length - 1; 
      index = end + 1;

      for (int l = end - 1; l >= insertPos; l--)
       list[l + 1] = list[l];

      list[insertPos] = new RetrievedPhoton(photon, dist2);
    }

    public int Count { get { return index; } }
  }

  public class Photon
  {
    public PhotonVector3 position;
    public PhotonVector3 Direction;
    public RealColor Power;
    public short LightmapIndex, MaterialIndex;
  }
  public class Node<T>
    where T : I3DSpace
  {
    T _this = default(T);
    Node<T> _left = null, _right = null, parent = null;

    public short Axis;

    public Node(T @this)
    {
      _this = @this;
    }
    public Node(T @this, T left, T right)
      : this(@this)
    {
      _left = new Node<T>(left); _right = new Node<T>(right);
    }

    public bool IsRoot { get { return parent == null; } }
    public Node<T> Parent { get { return parent; } set { parent = value; } }
    public Node<T> Left
    {
      get
      {
        return _left;
      }
      set
      {
        _left = value;
      }
    }
    public Node<T> Right
    {
      get
      {
        return _right;
      }
      set
      {
        _right = value;
      }
    }
    public T Current
    {
      get
      {
        return _this;
      }
      set
      {
        _this = value;
      }
    }
    public static implicit operator T(Node<T> a)
    {
      return a.Current;
    }
  }

  public class KDTree<T>
  {
    List<T> store = null;
  }

  public class PhotonMap
  {
    public const int ResizeStep = 1000;
    public CompressedPhoton[] store = null;
    public PhotonVector3 bBoxMax = new PhotonVector3(float.MinValue, float.MinValue, float.MinValue);
    public PhotonVector3 bBoxMin = new PhotonVector3(float.MaxValue, float.MaxValue, float.MaxValue);

    Node<CompressedPhoton> root = null;

    static float[] cosPhi, cosTheta, sinPhi, sinTheta;

    public Node<CompressedPhoton> Root
    {
      get { return root; }
    }

    static PhotonMap()
    {
      cosPhi = new float[256];
      cosTheta = new float[256];
      sinPhi = new float[256];
      sinTheta = new float[256];

      for (int i = 0; i < 256; i++)
      {
        double angle = (double)i * (1.0 / 256.0) * Math.PI;
        cosTheta[i] = (float)Math.Cos(angle);
        sinTheta[i] = (float)Math.Sin(angle);
        cosPhi[i] = (float)Math.Cos(2.0 * angle);
        sinPhi[i] = (float)Math.Sin(2.0 * angle);
      }
    }
    public PhotonMap(int maxPhotonCount)
    {
      store = new CompressedPhoton[maxPhotonCount];
    }

    public void Store(Photon photon)
    {
      CompressedPhoton a = new CompressedPhoton();

      if (photon.position != PhotonVector3.Empty)
      {
        a.position[0] = photon.position[0];
        a.position[1] = photon.position[1];
        a.position[2] = photon.position[2];

        for (int x = 0; x < 3; x++)
          a.Power[x] = photon.Power[x];

        int theta = (int)(Math.Acos(photon.Direction[2]) * (256 / Math.PI));
        if (theta > 255)
          a.Theta = 255;
        else a.Theta = (byte)theta;

        int phi = (int)(Math.Atan2(photon.Direction[1], photon.Direction[0]) * (256 / Math.PI));
        if (phi > 255)
          a.Phi = 255;
        else a.Phi = (byte)phi;

        a.Direction = (Vector3)photon.Direction;

        for (int x = 0; x < 3; x++)
          a.Power[x] = photon.Power[x];

        bBoxMax = new PhotonVector3(a.Position.X < bBoxMax.X ? bBoxMax.X : a.Position.X, a.Position.Y < bBoxMax.Y ? bBoxMax.Y : a.Position.Y, a.Position.Z < bBoxMax.Z ? bBoxMax.Z : a.Position.Z);
        bBoxMin = new PhotonVector3(a.Position.X > bBoxMin.X ? bBoxMin.X : a.Position.X, a.Position.Y > bBoxMin.Y ? bBoxMin.Y : a.Position.Y, a.Position.Z > bBoxMin.Z ? bBoxMin.Z : a.Position.Z);
        //a.LightmapIndex = photon.LightmapIndex;
        //a.MaterialIndex = photon.MaterialIndex;
        if (a == null)
          System.Diagnostics.Debugger.Break();
        //this.store.Add(a);
        AddPhoton(a);
      }
      else System.Diagnostics.Debugger.Break();
    }
    public void Store(CompressedPhoton a)
    {
      bBoxMax = new PhotonVector3(a.Position.X < bBoxMax.X ? bBoxMax.X : a.Position.X, a.Position.Y < bBoxMax.Y ? bBoxMax.Y : a.Position.Y, a.Position.Z < bBoxMax.Z ? bBoxMax.Z : a.Position.Z);
      bBoxMin = new PhotonVector3(a.Position.X > bBoxMin.X ? bBoxMin.X : a.Position.X, a.Position.Y > bBoxMin.Y ? bBoxMin.Y : a.Position.Y, a.Position.Z > bBoxMin.Z ? bBoxMin.Z : a.Position.Z);
      //store.Add(a);
      AddPhoton(a);
    }
    private void AddPhoton(CompressedPhoton photon)
    {
      if (storeIndex >= store.Length)
        Array.Resize(ref store, store.Length + ResizeStep);

      store[storeIndex++] = photon;
    }

    public void BeginLight()
    {
      lastIndex = storeIndex;
    }
    public void EndLight()
    {
      float scale = 1f / (float)(storeIndex - lastIndex);
      for (int x = lastIndex; x < storeIndex; x++)
        store[x].Power.Multiply(scale);  
    }

    int storeIndex = 0;
    int lastIndex = 0;
    public void Scale(float scale)
    {
      if (lastIndex < store.Length)
      {
        for (int x = lastIndex; x < store.Length; x++)
          store[x].Power.Multiply(scale);
        
        lastIndex = store.Length;
      }
    }
    public int GetCountSinceLastScale()
    {
      return store.Length - lastIndex;
    }

    public int Progress, Total;
    public void Balance()
    {
      // Find the cube surrounding the points
      // select dimension dim in which the cube is largest 
      // find median of the points in dim
      // s1 = all points below median
      // s2 = all points above or equal to median
      // node = median
      // node.left = balance(s1);
      // node.right = balance(s2);
      // return node;

      int removed = 0;
      Array.Resize(ref store, storeIndex);
      for (int x = 0; x < store.Length-removed; x++)
        if ((store[x] == null) || (store[x].position == PhotonVector3.Empty))
        {
          for (int z = x; z < store.Length - 1; z++)
            store[z] = store[z + 1];
          removed++;
        }
      Array.Resize(ref store, store.Length - removed);

      Total = (int)Math.Ceiling((double)store.Length * Math.Log(store.Length, 2.0) * 3);
      Progress = 0;

      root = BalanceSegment(0, store.Length, bBoxMax, bBoxMin);
    }

    private Node<CompressedPhoton> BalanceSegment(int start, int length, PhotonVector3 bBoxMax, PhotonVector3 bBoxMin)
    {
      
      #region special case
      if (length <= 0)
        return null;
      #endregion

      #region select dimension
      float distanceX = bBoxMax[0] - bBoxMin[0];
      float distanceY = bBoxMax[1] - bBoxMin[1];
      float distanceZ = bBoxMax[2] - bBoxMin[2];
      int axis = 2;

      float distance = bBoxMax[2] - bBoxMin[2];
      if (bBoxMax[1] - bBoxMin[1] > distance)
      {
        distance = bBoxMax[1] - bBoxMin[1];
        axis = 1;
      }
      if (bBoxMax[0] - bBoxMin[0] > distance)
        axis = 0;
      #endregion
      int firstAxis = axis;
    begin:
      #region Special case
      if (length == 1)
      {
        Node<CompressedPhoton> phot = new Node<CompressedPhoton>(store[start]);
        phot.Axis = (short)axis;
        return phot;
      }
      #endregion

      #region find the median

      int median = start + (length >> 1); // divide by two
      if (length > 0)
      {
        //LimitedList<CompressedPhoton> newStore = new LimitedList<CompressedPhoton>(store, start, length);
        HeapSort.NewSort(store, axis, start, length);
      }
      /*else
        QuickSort.Sort(store, start, start + length - 1, axis);*/
      /*LimitedList<CompressedPhoton> newStore = new LimitedList<CompressedPhoton>(store, start, length);
      HeapSort.NewSort(newStore, axis);*/
      //else
      //InsertionSort.Sort(store, 0, store.Count)

      // Anything that is above or equal to the median needs to be on the right side of the root node.
      // What we are doing here is starting at the median and looking for another axis-position of the same degree to the left of the median.
      int newMedian = median;
      for (int j = median - 1; j >= start; j--)
        if (store[median].position[axis] == store[j].position[axis])
          newMedian = j;
      median = newMedian;
      Progress += length;
      #endregion

      #region special case
      /*if (length == 2)
      {
        Node<CompressedPhoton> parent = new Node<CompressedPhoton>(store[median]);
        parent.Axis = (short)axis;
        parent.Left = new Node<CompressedPhoton>(store[start]);
        // TODO: Make sure this is the best way
        parent.Left.Axis = (short)axis;
        return parent;
      }*/
      #endregion

      Node<CompressedPhoton> phot1 = new Node<CompressedPhoton>(store[median]);
      phot1.Axis = (short)axis;

      if (median - start > 0)
      {
        float tmp = bBoxMax[axis];
        bBoxMax[axis] = store[median].Position[axis];
        phot1.Left = BalanceSegment(start, median - start, bBoxMax, bBoxMin);
        bBoxMax[axis] = tmp;
      }

      if (median + 1 < start + length)
      {
        if (length + start - median - 1 > 0)
        {
          if (median == start)
          {
            axis = (axis + 1) % 3;
            if (axis != firstAxis)
            {
              Progress -= length;
              goto begin;
            }
          }
          float tmp1 = bBoxMin[axis];
          bBoxMin[axis] = store[median].Position[axis];
          phot1.Right = BalanceSegment(median + 1, length + start - median - 1, bBoxMax, bBoxMin);
          bBoxMin[axis] = tmp1;
        }
      }

      return phot1;
    }

    #region Heapsort
    /*
     * function heapSort(a, count) is
     input:  an unordered array a of length count
 
     (first place a in max-heap order)
     heapify(a, count)
 
     end := count - 1
     while end > 0 do
         (swap the root(maximum value) of the heap with the last element of the heap)
         swap(a[end], a[0])
         (decrease the size of the heap by one so that the previous max value will
         stay in its proper placement)
         end := end - 1
         (put the heap back in max-heap order)
         siftDown(a, 0, end)*/
    void AHeapSort(int count, int axis, int offset)
    {
      Heapify(count, axis, offset);
      int end = count - 1;
      while (end > 0)
      {
        Swap(end, offset);
        end--;
        SiftDown(0, end, axis, offset);
      }
    }

    /*function heapify(a,count) is
        (start is assigned the index in a of the last parent node)
        start := (count - 1) / 2
     
        while start ≥ 0 do
            (sift down the node at index start to the proper place such that all nodes below
             the start index are in heap order)
            siftDown(a, start, count-1)
            start := start - 1
        (after sifting down the root all nodes/elements are in heap order)*/
    void Heapify(int count, int axis, int offset)
    {
      int start = ((count - 1) / 2);

      while (start >= 0)
      {
        SiftDown(start, count - 1, axis, offset);
        start--;
      }
    }

    /*function siftDown(a, start, end) is
        input:  end represents the limit of how far down the heap
                      to sift.
        root := start

        while root * 2 + 1 ≤ end do          (While the root has at least one child)
            child := root * 2 + 1            (root*2+1 points to the left child)
            (If the child has a sibling and the child's value is less than its sibling's...)
            if child < end and a[child] < a[child + 1] then
                child := child + 1           (... then point to the right child instead)
            if a[root] < a[child] then       (out of max-heap order)
                swap(a[root], a[child])
                root := child                (repeat to continue sifting down the child now)
            else
                return*/
    void SiftDown(int start, int end, int axis, int offset)
    {
      int root = start;
      while ((root * 2) + 1 <= end)
      {
        int child = (root * 2) + 1;
        if (child < end)
          if (store[child + offset].position[axis] < store[child + offset + 1].position[axis])
            child++;
        if (store[root + offset].position[axis] < store[child + offset].position[axis])
        {
          Swap(root + offset, child + offset);
          root = child;
        }
        else return;
      }
    }
    #endregion

    /*private void MedianSplit(int start, int end, int median, int axis)
    {
      List<CompressedPhoton> p = store;
      int left = start;
      int right = end;
      while (right > left)
      {
        float v = p[right].Position[axis];
        int i = left - 1;
        int j = right;
        while (true)
        {
          while (p[++i].Position[axis] < v) ;
          while ((p[--j].Position[axis] > v) && (j > left)) ;
          if (i >= j)
            break;

          Swap(i, j);
        }

        Swap(i, right);
        if (i >= median)
          right = i - 1;
        if (i <= median)
          left = i + 1;
      }
    }*/

    private void Sort(int start, int length, int axis)
    {
    // Insertion sort. Maybe a faster algorithm another day. I'm not too worried about performance right now...
    begin:
      for (int x = start + 1; x < start + length; x++)
      {
        if (x < start + 1)
          x = start + 1;
        float lower = store[x - 1].position[axis];
        float higher = store[x].position[axis];
        if (lower > higher)
        {
          Swap(x - 1, x);
          x -= 2;
        }
      }
    }
    private bool CheckSort(int start, int length, int axis)
    {
      for (int x = start; x < start + length - 1; x++)
        if (store[x].position[axis] > store[x + 1].position[axis])
          return false;
      return true;
    }
    public void Swap(int a, int b)
    {
      CompressedPhoton ab = store[a];
      store[a] = store[b];
      store[b] = ab;
    }

    //List<CompressedPhoton> _retrieved;
    //PhotonVector3 _p; float _distSquared;
    public List<CompressedPhoton> RetrieveNearestNeighbors(PhotonVector3 point, float distanceSquared, int maxPhotons)
    {      
      List<CompressedPhoton>_retrieved = new List<CompressedPhoton>();
      LocatePhotons(root, point, distanceSquared, ref _retrieved);
      for (int x = 0; x < _retrieved.Count; x++)
      {
      }

      return _retrieved;
    }
    

    public RetrievedPhotons RetrieveNearestNeighbors(PhotonVector3 point, float distanceSquared, int maxPhotons, Vector3 normal)
    {
      RetrievedPhotons _retrieved = new RetrievedPhotons(maxPhotons);
      LocatePhotons(root, point, distanceSquared, ref _retrieved, normal);

      return _retrieved;
    }

    //int rejected = 0;
    public void LocatePhotons(Node<CompressedPhoton> node, PhotonVector3 _p, float _distSquared, ref List<CompressedPhoton> _retrieved)
    {
      if (node == null)
        return;
      // Step 1: Check distance between current node and point. If it's within radius, add it.
      PhotonVector3 difference = node.Current.position - _p;
      float dist2 = difference[0] * difference[0];
      dist2 += difference[1] * difference[1];
      dist2 += difference[2] * difference[2];

      if (dist2 < _distSquared)
      {
        if (node.Current != null)
          _retrieved.Add(node.Current);
        
      }

      // Step 2: Is the point greater or lesser than the current node? Go left or right depending.
      if (difference[node.Axis] >= 0)
      {
        LocatePhotons(node.Right, _p, _distSquared, ref _retrieved);
        if (difference[node.Axis] * difference[node.Axis] < _distSquared)
          LocatePhotons(node.Left, _p, _distSquared,ref  _retrieved);
      }
      else
      {
        LocatePhotons(node.Left, _p, _distSquared, ref _retrieved);
        if (difference[node.Axis] * difference[node.Axis] < _distSquared)
          LocatePhotons(node.Right, _p, _distSquared, ref _retrieved);
      }

      // Step 3: Does the radius extend past the splitting plane? If so, check the other side.
    }
    public void LocatePhotons(Node<CompressedPhoton> node, PhotonVector3 _p, float _distSquared, ref RetrievedPhotons _retrieved, Vector3 normal)
    {
      if (node == null)
        return;
      // Step 1: Check distance between current node and point. If it's within radius, add it.
      PhotonVector3 difference = node.Current.position - _p;
      float dist2 = difference[0] * difference[0];
      dist2 += difference[1] * difference[1];
      dist2 += difference[2] * difference[2];

      if (dist2 < _distSquared)
        if ((node.Current != null) && (Vector3.Dot(node.Current.Direction, normal) < 0))
          _retrieved.AddIfClosest(node.Current, dist2);

      // Step 2: Is the point greater or lesser than the current node? Go left or right depending.
      if (difference[node.Axis] >= 0)
      {
        LocatePhotons(node.Right, _p, _distSquared,ref  _retrieved, normal);
        if (difference[node.Axis] * difference[node.Axis] < _distSquared)
          LocatePhotons(node.Left, _p, _distSquared, ref _retrieved, normal);
      }
      else
      {
        LocatePhotons(node.Left, _p, _distSquared, ref _retrieved, normal);
        if (difference[node.Axis] * difference[node.Axis] < _distSquared)
          LocatePhotons(node.Right, _p, _distSquared, ref _retrieved, normal);
      }
    }

    public int TestPhotonMap()
    {
      int notFound = 0;
      for (int x = 0; x < storeIndex; x++)
      {
        var photon = FindPhotonAt(store[x].position);
        if (photon != null)
          if (photon.position != store[x].position)
          notFound++;
      }
      return notFound;
    }

    public CompressedPhoton FindPhotonAt(PhotonVector3 location)
    {
      Node<CompressedPhoton> cur = root;
      while (cur != null)
      {
        if (cur.Current.position[cur.Axis] == location[cur.Axis])
          if (cur.Current.position == location)
            return cur.Current;
          else
            cur = cur.Right;
        else if (location[cur.Axis] < cur.Current.position[cur.Axis])
          cur = cur.Left;
        else cur = cur.Right;
      }
      return null;
    }
    public CompressedPhoton FindPhotonAt(PhotonVector3 location, out int comparisons)
    {
      comparisons = 0;
      Node<CompressedPhoton> cur = root;
      while (cur != null)
      {
        if (cur.Current.position[cur.Axis] == location[cur.Axis])
          if (cur.Current.position == location)
            return cur.Current;
          else
            cur = cur.Right;
        else if (location[cur.Axis] < cur.Current.position[cur.Axis])
          cur = cur.Left;
        else cur = cur.Right;
        comparisons++;
      }
      return null;
    }

    #region Save/Load
    public void SaveToFile(string path, bool overwrite)
    {
      if (overwrite || !File.Exists(path))
      {
        BinaryWriter bw = new BinaryWriter(new FileStream(path, FileMode.Create, FileAccess.Write));
        //SaveStoreToStream(bw);
        SaveMapToStream(bw);
        bw.Close();
      }
      else throw new Exception("File already exists and overwrite permissions were not given.");
    }
    public void LoadFromFile(string path)
    {
      BinaryReader br = new BinaryReader(new FileStream(path, FileMode.Open, FileAccess.Read));
      //LoadStoreFromStream(br);
      LoadMapFromStream(br);
      br.Close();
    }

    public void SaveStoreToStream(BinaryWriter bw)
    {
      //BinaryWriter bw = new BinaryWriter(new FileStream(path, FileMode.Create, FileAccess.Write));
      bw.Write(new char[] { 'S', 'T', 'O', 'R' });
      bw.Write(store.Length);
      for (int x=0;x<store.Length;x++)
      {
        /*bw.Write(store[x].position.X);
        bw.Write(store[x].position.Y);
        bw.Write(store[x].position.Z);
        bw.Write(store[x].Direction.X);
        bw.Write(store[x].Direction.Y);
        bw.Write(store[x].Direction.Z);
        bw.Write(store[x].Power.A);
        bw.Write(store[x].Power.R);
        bw.Write(store[x].Power.G);
        bw.Write(store[x].Power.B);
        bw.Write(store[x].LightmapIndex);
        bw.Write(store[x].MaterialIndex);
        bw.Write(store[x].Phi);
        bw.Write(store[x].Theta);*/
        store[x].SaveToStream(bw);
      }
    }
    public void SaveMapToStream(BinaryWriter bw)
    {
      bw.Write(new char[] { 'P', 'H', 'T', 'N' });
      bw.Write(store.Length);
      SaveNodeToStream(bw, root);
    }
    public void SaveNodeToStream(BinaryWriter bw, Node<CompressedPhoton> node)
    {
      if (node == null)
      {
        bw.Write((int)-1);
        return;
      }
      
      bw.Write((int)node.Axis);
      node.Current.SaveToStream(bw);
      //bw.Flush();

      SaveNodeToStream(bw, node.Left);
      SaveNodeToStream(bw, node.Right);
    }
    public Node<CompressedPhoton> LoadNodeFromStream(BinaryReader br)
    {
      int axis = br.ReadInt32();
      if (axis == -1)
        return null;
      
      if ((axis < 0) || (axis > 2))
        throw new IndexOutOfRangeException();
      CompressedPhoton phot = CompressedPhoton.FromStream(br);
      Node<CompressedPhoton> node = new Node<CompressedPhoton>(phot);
      AddPhoton(phot);
      node.Left = LoadNodeFromStream(br);
      node.Right = LoadNodeFromStream(br);
      return node;
    }
    public void LoadStoreFromStream(BinaryReader br)
    {
      string id = new string(br.ReadChars(4));
      if (id != "STOR") return;

      int count = br.ReadInt32();
      if (count < 0) return;
      store = new CompressedPhoton[count];

      storeIndex = 0;
      for (int x = 0; x < count; x++)
        AddPhoton(CompressedPhoton.FromStream(br));
    }
    public void LoadMapFromStream(BinaryReader br)
    {
      string id = new string(br.ReadChars(4));
      if (id != "PHTN") return;
      int count = br.ReadInt32();
      store = new CompressedPhoton[count];//new List<CompressedPhoton>(count);

      root = LoadNodeFromStream(br);
    }
    #endregion
  }
}
 