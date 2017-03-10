using System;
using Microsoft.DirectX;
using Microsoft.DirectX.Direct3D;
using Interfaces.Rendering.Interfaces;
using Interfaces.Rendering.Wrappers;
using Interfaces.Rendering.Selection;
using Interfaces.Rendering.Primitives;
using System.Diagnostics;
using Interfaces.Factory.CommonTypes;

namespace Interfaces.Rendering.Instancing
{
  public abstract class WorldInstance : Instance
  {
    protected BindingTransform bindingTransform = new BindingTransform();
    protected SelectTool selectTool = new SelectTool();
    protected bool bSelected = false;
    protected bool bEditActive = false;

    public bool Selected
    {
      get { return bSelected; }
      set { bSelected = value; }
    }

    public void MakeEditInactive()
    {
      bEditActive = false;
    }

    public EditMode EditMode
    {
      get { return selectTool.m_Mode; }
      set { selectTool.m_Mode = value; }
    }

    public BindingTransform ObjectTransform
    {
      get { return bindingTransform; }
    }

    public void SetBindingTransform(BindingTransform transform)
    {
      bindingTransform = transform;
    }

    #region Properties
    /// <summary>
    /// Exposes the x-component of the object's world position.  Used for distance calculations.
    /// </summary>
    public float X
    {
      get { return bindingTransform.X; }
    }

    /// <summary>
    /// Exposes the y-component of the object's world position.  Used for distance calculations.
    /// </summary>
    public float Y
    {
      get { return bindingTransform.Y; }
    }

    /// <summary>
    /// Exposes the z-component of the object's world position.  Used for distance calculations.
    /// </summary>
    public float Z
    {
      get { return bindingTransform.Z; }
    }

    /// <summary>
    /// Gets this instance's centroid translated by its world position.
    /// </summary>
    public override Vector3 Centroid
    {
      get
      { return Vector3.Add(base.Centroid, new Vector3(X, Y, Z)); }
    }
    #endregion

    public override BoundingBox BoundingBox
    {
      get
      { return base.BoundingBox.Translate(X, Y, Z); }
    }

    /// <summary>
    /// Provides a means to cache transforms information in the case that it is unchanged.
    /// </summary>
    protected override void Update()
    {
      base.Update();
      //TODO: understand this function
      //transform = Matrix.Transformation(Vector3.Empty, Quaternion.Identity, new Vector3(1.0f, 1.0f, 1.0f), Vector3.Empty, Quaternion.RotationYawPitchRoll(pitch, roll, yaw), new Vector3(x, y, z));
      update = false;
    }

    /// <summary>
    /// Exposes a method that is used to draw the instance. Must be inherited by derived classes.
    /// </summary>
    public override void Render()
    {
      if (update)
        Update();
      MdxRender.Device.Transform.World = bindingTransform.matrix;
      //todo: figure out how to set up editActive flag in the following function
      selectTool.Render(bindingTransform.matrix, bEditActive);
    }

    public void MouseDown(Vector3 pickRayOrigin, Vector3 pickRayDirection)
    {
      //check to see if we are in an active edit mode, otherwise skip it
      if ((selectTool.m_Mode != EditMode.NotSelected) &&
        (selectTool.m_Mode != EditMode.Selected) &&
        (selectTool.m_Mode != EditMode.IdleTranslate) &&
        (selectTool.m_Mode != EditMode.IdleRotate))
      {
        //tell the selection tool to ???
        selectTool.MouseDown_StartEdit(bindingTransform.matrix, pickRayOrigin, pickRayDirection, false);

        //we are now in active edit mode, set flag for mouse hover
        bEditActive = true;

        //Trace.WriteLine("MouseDown (edit start):  " + m_EditTranslationStart.ToString());
      }
    }

    /// <summary>
    /// Perform intersection test on Mouse-up to control EditMode of edit widget.
    /// State of edit widget changes if WorldInstance is clicked on or not.
    /// Actual editing is down on mouse down and mouse move.
    /// </summary>
    /// <param name="pickRayOrigin">origin of the Picking Ray</param>
    /// <param name="pickRayDirection">Unit direction of the picking ray</param>
    /// <returns></returns>
    public bool MouseUp(Vector3 pickRayOrigin, Vector3 pickRayDirection)
    {
      bool bLog = false;
      bool bModelIntersected = false;
      //transform pick ray into model space
      Matrix inv = new Matrix();
      inv = this.ObjectTransform.matrix;
      inv.Invert();

      Vector3 t_org = new Vector3();
      Vector3 t_dir = new Vector3();

      //if ((bBillboardMode == true) && (m_SelectTool.m_Mode == EditMode.NotSelected))
      if (this.entity != null)
      {
        //todo: perform ray-AABB rejection test
        t_org = pickRayOrigin;
        t_dir = pickRayDirection;
        t_org.TransformCoordinate(inv);
        t_dir.TransformNormal(inv);

        Intersection ii = null;
        bool bAABBIntersected = entity.IntersectRayAABB(t_org, t_dir);
        
        //TODO:  there might be some oddness with state management and billboards
        if (bAABBIntersected)
        {
          ii = entity.IntersectRay(t_org, t_dir);
        }

        if (ii == null) //did not intersect the visible mesh
        {
          if ((selectTool.m_Mode == EditMode.IdleTranslate) ||
            (selectTool.m_Mode == EditMode.Selected) ||
            (selectTool.m_Mode == EditMode.IdleRotate))
          {
            selectTool.m_Mode = EditMode.NotSelected;
          }
          else
          {
            if (bLog)
              Trace.WriteLine("clicked outside of model: " + selectTool.m_Mode.ToString());
          }
        }
        else
        {
          bModelIntersected = true;
          UpdateIdleSelectionState();

          //Process the edit
          if (bLog)
            Trace.WriteLine("Processing edit: " + selectTool.m_Mode.ToString());
        }
      }

      return (bModelIntersected);
    }

    public void Hover(Vector3 origin, Vector3 direction)
    {
      //transform pick ray into model space
      Matrix inv = new Matrix();
      inv = selectTool.WorldSpaceTransform;//m_Matrix;
      inv.Invert();

      Vector3 t_org = new Vector3();
      Vector3 t_dir = new Vector3();
      t_org = origin;
      t_dir = direction;
      t_org.TransformCoordinate(inv);
      t_dir.TransformNormal(inv);

      //update the selection tool (rotation "pie" drawing)

      if (bEditActive)
      {
        Vector3 translation_delta;
        BindingAngle3 rotation_delta;
        selectTool.HoverEdit(origin, direction, out translation_delta, out rotation_delta);
        bindingTransform.IncrementTranslation(translation_delta);
        UpdateLocalColor();
        bindingTransform.IncrementRotation(rotation_delta.Roll, rotation_delta.Pitch, rotation_delta.Yaw);
      }
      else
      {
        selectTool.Hover(t_org, t_dir);
      }
    }

    public void UpdateIdleSelectionState()
    {
      switch (selectTool.m_Mode)
      {
        case EditMode.NotSelected:
          selectTool.m_Mode = EditMode.Selected;
          break;

        case EditMode.Selected:
          selectTool.m_Mode = EditMode.IdleTranslate;
          break;

        case EditMode.IdleTranslate:
          selectTool.m_Mode = EditMode.IdleRotate;
          break;

        case EditMode.IdleRotate:
          selectTool.m_Mode = EditMode.NotSelected;
          break;
      }
    }

    public void UpdateLocalColor()
    {
      /*
      TagBsp bsp = MdxRender.GetCurrentBsp;

      if (bsp != null)
      {
        float scale;
        float[] uv = new float[2];
        int lightmap_index;
        Vector3 point, direction;

        if (bsp.Intersect(this.Translation, new Vector3(0, 0, -1), out point, out direction, out scale, out uv, out lightmap_index) == false)
          bsp.Intersect(this.Translation, new Vector3(0, 0, 1), out point, out direction, out scale, out uv, out lightmap_index);

        Color clr = MdxRender.SM.m_TextureManager.GetLightmapTexelColor(bsp.m_LightmapTextures, lightmap_index, uv[0], uv[1]);
        this.ObjectColor = clr;

        Trace.WriteLine("new color!" + clr.ToString());
        //bsp.ApplyLightmapColor(this.Translation, new Vector3(0, 0, -1), Color.Black);
        //Trace.WriteLine(string.Format("instance[{0}]: lma = {4} u = {1} v = {2}, color = {3}", i, uv[0], uv[1], clr.ToString(), lightmap_index));
      }
      */
    }

    public WorldInstance(IRenderable entity, Vector3 centroid, BoundingBox boundingBox)
      : base(entity, centroid, boundingBox)
    { /* Stupid C#... */ }
  }
}