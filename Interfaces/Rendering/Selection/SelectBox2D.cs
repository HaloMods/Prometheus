using Interfaces.Rendering.Instancing;
using Microsoft.DirectX;
using Microsoft.DirectX.Direct3D;
using System.Drawing;

namespace Interfaces.Rendering.Selection
{
  public class SelectBox2D
  {
    private int selectionBoxStartX = 0;
    private int selectionBoxStartY = 0;
    private int selectionBoxEndX;
    private int selectionBoxEndY;
    private MultiSelectMode multiSelectMode = MultiSelectMode.Disabled;
    private int activeClickCount = 0;

    public MultiSelectMode Mode
    {
      get { return multiSelectMode; }
    }
    public void MouseMove(int MouseX, int MouseY)
    {
      if (multiSelectMode == MultiSelectMode.FindEnd)
      {
        selectionBoxEndX = MouseX;
        selectionBoxEndY = MouseY;
      }
    }
    public void MouseUp(int MouseX, int MouseY)
    {
      switch (multiSelectMode)
      {
        case MultiSelectMode.Disabled:
          //TODO:  hook up input manager here
          //if (MdxRender.Input.StartSelectionBox)
          //{
          //  selectionBoxStartX = MouseX;
          //  selectionBoxStartY = MouseY;
          //  selectionBoxEndX = MouseX;
          //  selectionBoxEndY = MouseY;
          //  multiSelectMode = MultiSelectMode.FindEnd;
          //}
          break;

        case MultiSelectMode.FindEnd:
          selectionBoxEndX = MouseX;
          selectionBoxEndY = MouseY;
          multiSelectMode = MultiSelectMode.Active;
          break;

        case MultiSelectMode.Active:
          activeClickCount++;
          if (activeClickCount > 1)
          {
            activeClickCount = 0;
            multiSelectMode = MultiSelectMode.Disabled;
          }
          break;
      }
    }
    public InstanceCollection UpdateFrustumSelection(InstanceCollection InstanceList)
    {
      InstanceCollection selected_items = new InstanceCollection();
      WorldInstance wi;
      Plane[] fplanes;
      MdxRender.Camera.GetFrustumPlanes(selectionBoxStartX, selectionBoxStartY,
        selectionBoxEndX, selectionBoxEndY, out fplanes);

      float test;

      //there seems to be a little bit of a plane calculation bug, objects within the bounding box are
      //not always selected perfectly
      bool bInsideFrustum = false;
      int sel_count = 0;
      for (int i = 0; i < InstanceList.Count; i++)
      {
        wi = (WorldInstance)InstanceList[i];
        bInsideFrustum = true;
        for (int p = 0; p < fplanes.Length; p++)
        {
          test = wi.ObjectTransform.X * fplanes[p].A +
            wi.ObjectTransform.Y * fplanes[p].B +
            wi.ObjectTransform.Z * fplanes[p].C +
            fplanes[p].D;

          if (test < 0) //test for behind plane (outside of frustum) (normals point to inside of frustum)
          {
            bInsideFrustum = false;
            break;
          }
        }

        wi.Selected = bInsideFrustum;
        if (bInsideFrustum)
        {
          selected_items.Add(wi);
          sel_count++;
        }
        else
        {
        }
      }
      //Trace.WriteLine("---------------------------------");
      //Trace.WriteLine(string.Format("selected:  {0}/{1}", sel_count, this.Count));      
      //Trace.WriteLine(string.Format("near   Nx={0:N3}   Ny={1:N3}   Nz={2:N3}   D={3:N3}", fplanes[0].A, fplanes[0].B, fplanes[0].C, fplanes[0].D));
      //Trace.WriteLine(string.Format("far    Nx={0:N3}   Ny={1:N3}   Nz={2:N3}   D={3:N3}", fplanes[1].A, fplanes[1].B, fplanes[1].C, fplanes[1].D));
      //Trace.WriteLine(string.Format("right  Nx={0:N3}   Ny={1:N3}   Nz={2:N3}   D={3:N3}", fplanes[2].A, fplanes[2].B, fplanes[2].C, fplanes[2].D));
      //Trace.WriteLine(string.Format("left   Nx={0:N3}   Ny={1:N3}   Nz={2:N3}   D={3:N3}", fplanes[3].A, fplanes[3].B, fplanes[3].C, fplanes[3].D));
      //Trace.WriteLine(string.Format("top    Nx={0:N3}   Ny={1:N3}   Nz={2:N3}   D={3:N3}", fplanes[4].A, fplanes[4].B, fplanes[4].C, fplanes[4].D));
      //Trace.WriteLine(string.Format("Bottom Nx={0:N3}   Ny={1:N3}   Nz={2:N3}   D={3:N3}", fplanes[5].A, fplanes[5].B, fplanes[5].C, fplanes[5].D));
      return (selected_items);
    }
    public void Render()
    {
      //Draw selection box outline
      if ((multiSelectMode == MultiSelectMode.FindEnd) && (MdxRender.Device != null))
      {
        Line ln = new Line(MdxRender.Device);
        Vector2[] box = new Vector2[5];
        box[0] = new Vector2(selectionBoxStartX, selectionBoxStartY);
        box[1] = new Vector2(selectionBoxEndX, selectionBoxStartY);
        box[2] = new Vector2(selectionBoxEndX, selectionBoxEndY);
        box[3] = new Vector2(selectionBoxStartX, selectionBoxEndY);
        box[4] = new Vector2(selectionBoxStartX, selectionBoxStartY);

        ln.Begin();
        ln.Draw(box, Color.Yellow);
        ln.End();
      }
    }
  }
}