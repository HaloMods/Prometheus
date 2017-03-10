using System.Drawing;
using Interfaces.Rendering;
using Interfaces.Rendering.Instancing;
using Microsoft.DirectX.Direct3D;

namespace Core.Rendering
{
  /// <summary>
  /// Represents the current state of the render window; that is, what it is currently drawing,
  /// what camera it currently uses, as well as a name for the scene.
  /// </summary>
  public class SceneState
  {
    private Color clearColor = Color.Black;
    private string identifier = null;
    private string title = null;
    private Camera.Camera camera = null;
    private Instance instance = null;
    private RenderState renderState;
    private SceneType sceneType;

    /// <summary>
    /// Creates a new instance of the SceneState class.
    /// </summary>
    public SceneState(string identifier, Camera.Camera camera, Instance instance, RenderState state, SceneType type)
      : this(identifier, identifier, camera, instance, state, type) { }
    
    /// <summary>
    /// Creates a new instance of the SceneState class.
    /// </summary>
    public SceneState(string identifier, string title, Camera.Camera camera, Instance instance, RenderState state, SceneType type)
    {
      this.identifier = identifier;
      this.title = title;
      this.camera = camera;
      this.instance = instance;
      RenderState = state;
      sceneType = type;
    }

    public void SetupCamera()
    {
      MdxRender.Device.Transform.View = camera.GetViewMatrix();
      camera.CalculateViewFrustum();
    }

    /// <summary>
    /// Draws the scene using the static device, internal camera, and internal instance.
    /// </summary>
    public void RenderScene()
    {
      // after my z-buffer improvements, sorting doesn't seem too entirely necessary. big fps boost.
      //if (instance is InstanceCollection)
      //  (instance as InstanceCollection).Sort();

      Material material = new Material();
      material.Ambient = Color.White;
      material.Diffuse = Color.White;
      MdxRender.Device.Material = material;
      
      MdxRender.Device.RenderState.Ambient = clearColor;
      instance.ModifyStateBeforeScene();
      instance.Render();
      clearColor = MdxRender.Device.RenderState.Ambient;
      instance.ModifyStateAfterScene();
    }

    /// <summary>
    /// Gets the identifier associated with this scene.
    /// </summary>
    public string Identifier
    {
      get
      { return identifier; }
    }

    /// <summary>
    /// Gets the friendly title that the scene will display in the UI.
    /// </summary>
    public string Title
    {
      get { return title; }
    }

    /// <summary>
    /// Gets or sets a color to clear the device backbuffer with.
    /// </summary>
    public Color ClearColor
    {
      get
      { return clearColor; }
      set
      { clearColor = value; }
    }

    /// <summary>
    /// Gets or sets the scene's render state.
    /// </summary>
    public RenderState RenderState
    {
      get
      {
        return renderState;
      }
      set
      {
        renderState = value;

        switch (value)
        {
          case RenderState.Textured:
            MdxRender.Device.RenderState.FillMode = FillMode.Solid;
            break;
          case RenderState.Wireframe:
            MdxRender.Device.RenderState.FillMode = FillMode.WireFrame;
            break;
          case RenderState.Overlay:
            MdxRender.Device.RenderState.FillMode = FillMode.Point; // Temp as a visual reminder that we need to implement wireframe overlay.
            break;
        }
      }
    }

    /// <summary>
    /// Gets this scene's SceneType.
    /// </summary>
    public SceneType SceneType
    {
      get
      { return sceneType; }
    }

    /// <summary>
    /// Gets or sets the camera associated with this scene.
    /// </summary>
    public Camera.Camera Camera
    {
      get
      { return camera; }
      set
      { camera = value; }
    }

    /// <summary>
    /// Gets the instance that makes up this scene.
    /// </summary>
    public Instance Instance
    {
      get
      { return instance; }
    }
  }
}