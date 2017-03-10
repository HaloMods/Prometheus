using System.Collections.Generic;

using Microsoft.DirectX;

using Interfaces.Factory.CommonTypes;
using Interfaces.Rendering;
using Interfaces.Rendering.Instancing;
using Interfaces.Rendering.Interfaces;
using Interfaces.Rendering.Radiosity;
using Interfaces.Rendering.Selection;
using Interfaces.Scripting.ScenarioInterface;
using Interfaces.DynamicInterface.SceneInstanceMenu;
using Interfaces.Pool;


namespace Interfaces.Games
{
  public abstract class ScenarioBase : Pool.Tag, ISceneInstanceMenu
  {
    //private int activeBsp = 0;
    protected InstanceCollection instances = new InstanceCollection();
    protected InstanceCollection selectionList = new InstanceCollection();
    protected WorldInstance activeSelection;
    protected Instance nonSpecificSelection;
    protected SelectBox2D multiSelectBox;

    /// <summary>
    /// 
    /// </summary>
    /// <param name="mouseX"></param>
    /// <param name="mouseY"></param>
    public virtual void SelectionEdit_MouseDown(int mouseX, int mouseY)
    {
      // Mouse down is only important if there is an active selection in an edit mode
      if (activeSelection != null)
      {
        Vector3 PickRayDirection;
        Vector3 PickRayOrigin;
        MdxRender.CalculatePickRayWorld(mouseX, mouseY, out PickRayDirection, out PickRayOrigin);

        if (activeSelection != null)
          activeSelection.MouseDown(PickRayOrigin, PickRayDirection);
      }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="mouseX"></param>
    /// <param name="mouseY"></param>
    public virtual void SelectionEdit_MouseMove(int mouseX, int mouseY)
    {
      if (activeSelection != null)
      {
        Vector3 PickRayDirection;
        Vector3 PickRayOrigin;
        MdxRender.CalculatePickRayWorld(mouseX, mouseY, out PickRayDirection, out PickRayOrigin);

        if (activeSelection != null)
          activeSelection.Hover(PickRayOrigin, PickRayDirection);
      }

      //if (multiSelectBox.Mode == MultiSelectMode.FindEnd)
      //{
      //todo:  fix this stuff up for multiselect mode
      //multiSelectBox.MouseMove(mouseX, mouseY);
      //multiSelectBox.UpdateFrustumSelection(this);
      //UpdateSelectionLeader();
      //}
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="mouseX"></param>
    /// <param name="mouseY"></param>
    public virtual void SelectionEdit_MouseUp(int mouseX, int mouseY)
    {
      Vector3 PickRayDirection;
      Vector3 PickRayOrigin;
      MdxRender.CalculatePickRayWorld(mouseX, mouseY, out PickRayDirection, out PickRayOrigin);

      #region 2D Selection Box
      /*
      //see if we need to do a 2D select box
      multiSelectBox.MouseUp(mouseX, mouseY);
      if (multiSelectBox.Mode != MultiSelectMode.Disabled)
      {
        if (multiSelectBox.Mode != MultiSelectMode.Disabled)
        {
          ArrayList tmp = multiSelectBox.UpdateFrustumSelection(this);
          bool bFoundDuplicate = false;
          Instance3D inst, tmp_inst;
          //add 2d select box selection list to master selection list
          for (int s = 0; s < tmp.Count; s++)
          {
            tmp_inst = (Instance3D)tmp[s];
            //check for duplication
            for (int k = 0; k < selectionList.Count; k++)
            {
              inst = (Instance3D)selectionList[k];
              if (tmp_inst == inst)
              {
                bFoundDuplicate = true;
                break;
              }
            }

            if (bFoundDuplicate == false)
              selectionList.Add(tmp[s]);
          }
        }
      }
       * */
      #endregion

      //debug code
      if (activeSelection == null)
      {
        foreach (WorldInstance instance in instances)
        {
          if (instance.MouseUp(PickRayOrigin, PickRayDirection))
          {
            activeSelection = instance;
          }
        }

        if ((selectionList.Count != 0) && (multiSelectBox.Mode == MultiSelectMode.Disabled))
        {
          foreach (WorldInstance item in instances)
            item.Selected = false;

          selectionList.Clear();
        }
        //if(m_DebugObject1.MouseUp(PickRayOrigin, PickRayDirection, false))
        //  m_ActiveSelection = m_DebugObject1;
      }
      else
      {
        activeSelection.MakeEditInactive();
        if (activeSelection.MouseUp(PickRayOrigin, PickRayDirection) == false)
        {
          if (activeSelection.EditMode == EditMode.NotSelected)
            activeSelection = null;
        }
      }

      UpdateSelectionLeader();
    }

    /// <summary>
    /// 
    /// </summary>
    public void UpdateSelectionLeader()
    {
      //bool bFoundLeader = false;

      //for (int i = 0; i < instances.Count; i++)
      //{
      //  instances[i].SelectionLeader = false;

      //  if ((instances[i].Selected) && (bFoundLeader == false))
      //  {
      //    instances[i].SelectionLeader = true;
      //    bFoundLeader = true;
      //  }
      //}
    }

    /// <summary>
    /// When an object is being edited, we want to lock the camera attitude controls.
    /// If there is no active selection, or if the active selection is an Idle or
    /// Unselected state, then Camera Lock isn't necessary.
    /// 
    /// Called from camera updating
    /// </summary>
    public bool CameraLockRequested
    {
      get
      {
        bool bLock = false;

        if (activeSelection != null)
        {
          EditMode em = activeSelection.EditMode;

          if ((em != EditMode.IdleTranslate) &&
            (em != EditMode.Selected) &&
            (em != EditMode.IdleRotate) &&
            (em != EditMode.NotSelected))
          {
            bLock = true;
          }
        }
        return (bLock);
      }
    }
    public bool ObjectSelected
    {
      get { return (activeSelection != null); }
    }

    /// <summary>
    /// Used to display selection position in the GUI
    /// </summary>
    public Vector3 SelectionPosition
    {
      get
      {
        Vector3 pos = new Vector3();
        if (activeSelection != null)
          activeSelection.ObjectTransform.GetTranslation(out pos);

        return (pos);
      }
    }

    /// <summary>
    /// Used to display selection rotation in the GUI
    /// </summary>
    public BindingAngle3 SelectionRotation
    {
      get
      {
        BindingAngle3 rot = new BindingAngle3();
        float r, p, y;
        r = p = y = 0;

        if (activeSelection != null)
          activeSelection.ObjectTransform.GetRotation(out r, out p, out y);

        rot.Roll = r;
        rot.Pitch = p;
        rot.Yaw = y;

        return (rot);
      }
      set
      {
        if (activeSelection != null)
        {
          if (activeSelection is BillboardInstance)
          {
            activeSelection.ObjectTransform.SetRotation(0, 0, value.Yaw);
          }
          else
          {
            activeSelection.ObjectTransform.SetRotation(value.Roll, value.Pitch, value.Yaw);
          }
        }
      }
    }

    /// <summary>
    /// Gets the currently active BSP list.
    /// </summary>
    public abstract List<IBsp> ActiveBspList { get; }

    public abstract List<IBsp> BspList { get; }

    /// <summary>
    /// Gets the active bsp's index into the bsp palette.
    /// </summary>
    public abstract int ActiveBspIndex { get; }

    public IBsp ActiveBsp
    {
      get
      {
        if ((BspList.Count > ActiveBspIndex) && (ActiveBspIndex >= 0))
          return BspList[ActiveBspIndex];
        else return null;
      }
    }

    /// <summary>
    /// Gets the currently viewed bsp.
    /// </summary>
    public Tag ActiveBspTag
    {
      get
      { return BspTagList[ActiveBspIndex]; }
    }

    /// <summary>
    /// Gets a list of tags loaded as bsps.
    /// </summary>
    protected abstract Tag[] BspTagList
    {
      get;
    }

    /*/// <summary>
    /// Index into the StructureBsps list to the currently displayed 
    /// </summary>
    public abstract int BspIndex
    {
    }*/

    /// <summary>
    /// Creates a new instance of the given object at the given coordinates.
    /// </summary>
    public abstract void CreateNewObjectInstance(int paletteID, string objectName, float x, float y, float z);

    /// <summary>
    /// Gets this scenario's supported palettes.
    /// </summary>
    public abstract ScenePalette[] Palettes
    { get; }

    /// <summary>
    /// Gets a list of entries currently in the scenario palettes.
    /// </summary>
    public abstract SceneObject[] PaletteEntries
    { get; }

    /// <summary>
    /// Gets the number of selected instances in this scenario.
    /// </summary>
    public int SelectionCount
    {
      get
      { return selectionList.Count; }
    }

    /// <summary>
    /// Gets the currently selected instance.
    /// </summary>
    public Instance SelectedObject
    {
      get
      { return activeSelection; }
    }

    /// <summary>
    /// Gets the world lighting information.
    /// </summary>
    public abstract List<ILight> WorldLighting { get;}

    /// <summary>
    /// Gets static models (scenery, etc) to be used for radiosity calculation. Do NOT include objects that will move (fusion cores, warthogs, etc)
    /// </summary>
    public abstract List<IModel> StaticModels { get;}

    #region Scripting

    public abstract void AddScript(ScenarioScript scenarioScript);
    public abstract ScenarioScript[] GetScripts();

    public abstract void AddScriptGlobal(ScenarioScriptGlobal scenarioScriptGlobal);
    public abstract ScenarioScriptGlobal[] GetScriptGlobals();

    public abstract void ClearScripting();

    public abstract string[] GetBlockStringsForScriptingReferenceType(short type);
    public abstract string GetBlockStringForScriptingReferenceType(short blockIndex, short type);

    public abstract byte[] GetScriptSyntaxData();
    public abstract void SetScriptSyntaxData(byte[] data);

    public abstract string GetScriptString(int offset);
    public abstract void SetScriptStringData(byte[] data);

    #endregion
  }
}