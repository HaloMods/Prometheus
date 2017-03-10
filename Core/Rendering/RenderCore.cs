using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;
using System.Reflection;
using System.Security;
using System.Windows.Forms;
using Core.Rendering.Camera;
using Interfaces;
using Interfaces.DebugConsole;
using Interfaces.Options;
using Interfaces.Rendering;
using Interfaces.Rendering.Instancing;
using Interfaces.Rendering.Primitives;
using Interfaces.Rendering.Selection;
using Interfaces.Rendering.Utilties;
using Microsoft.DirectX;
using Microsoft.DirectX.Direct3D;
using DXFont = Microsoft.DirectX.Direct3D.Font;
using Font=System.Drawing.Font;
using Interfaces.Rendering.Wrappers;

namespace Core.Rendering
{
    /// <summary>
    /// Handles static rendering for the Core.
    /// </summary>
    public static class RenderCore
    {
        private static bool canRender = true;
        private static Color background = Color.MidnightBlue;
        private static CustomVertex.PositionTextured[] m_debugTextureVertices;

        //[ConsoleAttribute("near_plane", "this is the closest anything can be to the viewer and still be rendered.")]
        //private static float m_MinDrawDistance = OptionManager.CameraNearPlane;
        //[ConsoleAttribute("far_plane", "this is the farthest anything can be from the viewer and still be rendered.")]
        //private static float m_MaxDrawDistance = OptionManager.CameraFarPlane;

        //camera stuff
        private static Camera.Camera camera = null;
        private static RunningAvg m_PitchAvg = new RunningAvg();
        private static RunningAvg m_YawAvg = new RunningAvg();
        private static bool bUpdateViewTransform = true;
        private static DeviceType deviceType = DeviceType.Hardware;
        private static bool fullScreen = false;
        private static bool bDeviceLost = false;
        private static bool d3dInitialized = false;
        private static Control renderTarget = null;
        private static PresentParameters pp = new PresentParameters();
        private static int lastViewportWidth;
        private static int lastViewportHeight;
        private static Caps caps;
        private static bool m_mouseEnabled;
        private static bool enableCameraInput;
        private static bool enableKeyboardInput;
        private static DXFont fontFPS;
        private static Mesh m_logo;
        private static Texture m_logo_texture;
        private static Effect m_logo_effect;
        private static DebugConsole.DebugConsole console;
        private static bool paused = false;

        public static DXFont DebugFont;

        // scene management
        private static int sceneIndex = -1;
        private static List<SceneState> scenes = new List<SceneState>();

        private static Pool.Pool tagPool;
        private static bool bRenderLockRequested = false;
        public static event EventHandler OnRender;

        /// <summary>
        /// Returns the number of active scenes.
        /// </summary>
        public static int SceneCount
        {
            get { return scenes.Count; }
        }

        /// <summary>
        /// Gets or sets if the mouse is enabled.
        /// </summary>
        public static bool MouseEnabled
        {
            get { return m_mouseEnabled; }
            set { m_mouseEnabled = value; }
        }

        public static event EventHandler PausedChanged;

        /// <summary>
        /// Gets or sets if rendering is paused.
        /// </summary>
        public static bool Paused
        {
            get { return paused; }
            set
            {
                if (paused == value)
                    return;
                paused = value;
                if (PausedChanged != null)
                    PausedChanged(null, null);
            }
        }

        public static bool CameraLockRequested
        {
            get { return bRenderLockRequested; }
            set { bRenderLockRequested = value; }
        }

        /// <summary>
        /// Gets or sets if camera input is enabled.
        /// </summary>
        public static bool EnableCameraInput
        {
            get { return enableCameraInput; }
            set { enableCameraInput = value; }
        }
        public static bool EnableKeyboardInput
        {
            get { return enableKeyboardInput; }
            set { enableKeyboardInput = value; }
        }

        /// <summary>
        /// Gets if the device is initialized.
        /// </summary>
        public static bool DeviceInitialized
        {
            get { return d3dInitialized; }
        }

        /// <summary>
        /// Gets the static InstanceCollection that contains all manner of render-able goodies.
        /// </summary>
        //public static InstanceCollection Instances
        //{
        //  get
        //  { return instances; }
        //}

        /// <summary>
        /// Gets or sets the device type currently in use.
        /// </summary>
        public static DeviceType DeviceType
        {
            get
            { return deviceType; }
            set
            { deviceType = value; }
        }

        /// <summary>
        /// Gets or sets the full screen mode in use.
        /// </summary>
        public static bool FullScreen
        {
            get
            { return fullScreen; }
            set
            { fullScreen = value; }
        }

        /// <summary>
        /// Gets or sets if the current device has been lost.
        /// </summary>
        public static bool DeviceLost
        {
            get { return bDeviceLost; }
            set { bDeviceLost = value; }
        }

        /// <summary>
        /// Gets the static camera currently in use.
        /// </summary>
        //public static ICamera Camera
        //{
        //  get { return (ICamera)camera; }
        //  set { camera = value; }
        //}

        /// <summary>
        /// Gets the projection matrix currently in use.
        /// </summary>
        public static Matrix CurrentProjectionMatrix
        {
            get
            {
                Viewport viewport = MdxRender.Device.Viewport;
                return Matrix.PerspectiveFovRH((float)Math.PI / 4.0f,
                    (float)viewport.Width / (float)viewport.Height, OptionManager.CameraNearPlane, OptionManager.CameraFarPlane);
            }
        }


        /// <summary>
        /// Sets up various device parameters.
        /// </summary>
        private static void SetupDevice()
        {
            //Set up texture filtering to get rid of blocky uglies
            MdxRender.Device.SamplerState[0].MagFilter = TextureFilter.Linear;
            MdxRender.Device.SamplerState[0].MinFilter = TextureFilter.Linear;
            MdxRender.Device.SamplerState[0].MipFilter = TextureFilter.Linear;
            MdxRender.Device.SamplerState[1].MagFilter = TextureFilter.Linear;
            MdxRender.Device.SamplerState[1].MinFilter = TextureFilter.Linear;
            MdxRender.Device.SamplerState[1].MipFilter = TextureFilter.Linear;
            MdxRender.Device.SamplerState[2].MagFilter = TextureFilter.Linear;
            MdxRender.Device.SamplerState[2].MinFilter = TextureFilter.Linear;
            MdxRender.Device.SamplerState[2].MipFilter = TextureFilter.Linear;
            MdxRender.Device.SamplerState[3].MagFilter = TextureFilter.Linear;
            MdxRender.Device.SamplerState[3].MinFilter = TextureFilter.Linear;
            MdxRender.Device.SamplerState[3].MipFilter = TextureFilter.Linear;
            MdxRender.Device.SamplerState[4].MagFilter = TextureFilter.Linear;
            MdxRender.Device.SamplerState[4].MinFilter = TextureFilter.Linear;
            MdxRender.Device.SamplerState[4].MipFilter = TextureFilter.Linear;
            MdxRender.Device.SamplerState[5].MagFilter = TextureFilter.Linear;
            MdxRender.Device.SamplerState[5].MinFilter = TextureFilter.Linear;
            MdxRender.Device.SamplerState[5].MipFilter = TextureFilter.Linear;
            MdxRender.Device.SamplerState[6].MagFilter = TextureFilter.Linear;
            MdxRender.Device.SamplerState[6].MinFilter = TextureFilter.Linear;
            MdxRender.Device.SamplerState[6].MipFilter = TextureFilter.Linear;

            MdxRender.Device.RenderState.AlphaFunction = Compare.GreaterEqual;
            MdxRender.Device.SetRenderState(RenderStates.ReferenceAlpha, 0x80);

            MdxRender.Device.RenderState.Ambient = Color.Gray;
            MdxRender.Device.Lights[0].Type = LightType.Directional;
            MdxRender.Device.Lights[0].Diffuse = Color.White;
            MdxRender.Device.Lights[0].Specular = Color.White;
            MdxRender.Device.Lights[0].Direction = new Vector3(0.5f, -1, -1);
            MdxRender.Device.Lights[0].Update();
            MdxRender.Device.Lights[0].Enabled = true;
            MdxRender.Device.RenderState.Lighting = true;

            MdxRender.Device.RenderState.CullMode = Cull.CounterClockwise;
            MdxRender.Device.RenderState.ZBufferEnable = true;
            MdxRender.Device.RenderState.PointSize = 10.0f;

            //disable vsync, might get some tearing - re-enabled by swamp. sorry but I had to to effectively debug without my computer being wasted.
            //MdxRender.Device.PresentationParameters.PresentationInterval = PresentInterval.Immediate; 
        }

        /// <summary>
        /// Initializes the device.
        /// </summary>
        public static void Initialize(Control renderTarget, Pool.Pool pool)
        {
            tagPool = pool;
            if (d3dInitialized)
                MdxRender.Device.Dispose();

            RenderCore.renderTarget = renderTarget;
            int adapter = Manager.Adapters.Default.Adapter;
            caps = Manager.GetDeviceCaps(adapter, DeviceType);

            pp.PresentationInterval = PresentInterval.Default;
            pp.Windowed = true;// !MdxRender.FullScreen;
            pp.SwapEffect = SwapEffect.Discard;
            pp.EnableAutoDepthStencil = true;
            pp.AutoDepthStencilFormat = GetDepthFormat(adapter);
            //pp.MultiSample = GetMultiSampleType(adapter);
            //pp.MultiSampleQuality = 0;

            CreateFlags flags;
            flags = CreateFlags.SoftwareVertexProcessing;
            if (caps.DeviceCaps.SupportsHardwareTransformAndLight)
                flags = CreateFlags.HardwareVertexProcessing;

            // Disable built in events.

            Device.IsUsingEventHandlers = false;
            MdxRender.Device = new Device(adapter, DeviceType, renderTarget, flags, pp);
            SetupDevice();

            //MdxRender.Device.DeviceResizing += new System.ComponentModel.CancelEventHandler(device_DeviceResizing);
            //MdxRender.Device.DeviceReset += new EventHandler(device_DeviceReset);

            camera = new Camera.Camera();
            MdxRender.FrameTimer = new FPSCounter(50);
            SelectTool.InitializeHandleModel();
            Billboard.LoadResources(0.5f, 0.5f);
            fontFPS = new DXFont(MdxRender.Device, new Font("Arial", 12, FontStyle.Bold));
            DebugFont = new Microsoft.DirectX.Direct3D.Font(MdxRender.Device, new Font("Arial", 12, FontStyle.Bold));
            console = new DebugConsole.DebugConsole(MdxRender.Device);

            d3dInitialized = true;
        }

        /// <summary>
        /// Retrieves an appropriate depth format from the manager.
        /// </summary>
        private static DepthFormat GetDepthFormat(int adapter)
        {
            if (Manager.CheckDepthStencilMatch(adapter, DeviceType, Format.X8B8G8R8, Format.A8B8G8R8, DepthFormat.D32))
                return DepthFormat.D32;
            else if (Manager.CheckDepthStencilMatch(adapter, DeviceType, Format.X8B8G8R8, Format.A8B8G8R8, DepthFormat.D24X8))
                return DepthFormat.D24X8;
            else if (Manager.CheckDepthStencilMatch(adapter, DeviceType, Format.X8R8G8B8, Format.A8R8G8B8, DepthFormat.D16))
                return DepthFormat.D16;
            else
                throw new RenderException("No suitable depth stencil format was found. Your video card is out of date.");
        }

        ///// <summary>
        ///// Retrieves an appropriate multi sample format from the manager.
        ///// </summary>
        //private static MultiSampleType GetMultiSampleType(int adapter)
        //{
        //  if (Manager.CheckDeviceMultiSampleType(adapter, DeviceType, Format.X8R8G8B8, !FullScreen, MultiSampleType.FourSamples))
        //    return MultiSampleType.FourSamples;
        //  else if (Manager.CheckDeviceMultiSampleType(adapter, DeviceType, Format.X8R8G8B8, !FullScreen, MultiSampleType.TwoSamples))
        //    return MultiSampleType.TwoSamples;
        //  else if (Manager.CheckDeviceMultiSampleType(adapter, DeviceType, Format.X8R8G8B8, !FullScreen, MultiSampleType.NonMaskable))
        //    return MultiSampleType.NonMaskable;
        //  else
        //    return MultiSampleType.None;
        //}

        public static void PerformDeviceReset(int sizeX, int sizeY)
        {
            int res;
            MdxRender.Device.CheckCooperativeLevel(out res);

            //clean up unmanaged resources
            fontFPS.OnLostDevice();
            DebugFont.OnLostDevice();
            tagPool.OnLostDevice();
            console.OnLostDevice();
            SelectTool.OnLostDevice();
            Billboard.OnLostDevice();
            foreach (SceneState scene in scenes)
                scene.Instance.OnDeviceLost();

            //reset the device with new viewport dimensions
            pp.BackBufferWidth = sizeX;
            pp.BackBufferHeight = sizeY;
            //MdxRender.Device.Reset(pp);

            //re-create unmanaged resources
            fontFPS.OnResetDevice();
            DebugFont.OnResetDevice();
            tagPool.OnResetDevice();
            console.OnResetDevice();
            SelectTool.OnResetDevice();
            Billboard.OnResetDevice();
            foreach (SceneState scene in scenes)
                scene.Instance.OnDeviceReset();

            //re-init any state variables we need
            SetupDevice();
            UpdateViewTransform();
            MdxRender.Device.Transform.World = Matrix.Identity;
            MdxRender.Device.Transform.View = camera.GetViewMatrix();
        }

        /// <summary>
        /// Commits a projection matrix.
        /// </summary>
        [Console("commit_projection", "commits any changes made to the projection matrix to the device.")]
        public static void CommitProjection()
        {
            bUpdateViewTransform = true;
            UpdateViewTransform();
        }

        /// <summary>
        /// Updates the view transform when we resize the viewport.  Called from
        /// </summary>
        public static void UpdateViewTransform()
        {
            if (d3dInitialized)
            {
                //TODO:  implement MDX callback method so we don't pull the vp every frame (inefficient)
                //Trace.WriteLine(OutputTypes.Debug, "Updating ViewTransform");

                Viewport vp = MdxRender.Device.Viewport;
                vp.Width = renderTarget.Width;
                vp.Height = renderTarget.Height;

                if ((lastViewportWidth != vp.Width) ||
                   (lastViewportHeight != vp.Height) ||
                   (bUpdateViewTransform))
                {
                    vp.MinZ = 0.1f;
                    vp.MaxZ = 1.0f;
                    MdxRender.Device.Viewport = vp;
                    MdxRender.Device.Transform.Projection = Matrix.PerspectiveFovRH((float)Math.PI / 4,
                      (float)vp.Width / (float)vp.Height, OptionManager.CameraNearPlane, OptionManager.CameraFarPlane);

                    lastViewportWidth = vp.Width;
                    lastViewportHeight = vp.Height;
                    bUpdateViewTransform = false;
                }
            }
        }

        /// <summary>
        /// Adds a scene to the list available to be rendered.
        /// </summary>
        public static void AddScene(string identifier, string name, Camera.Camera camera, Instance instance, RenderState state, SceneType type)
        {
            for (int i = 0; i < scenes.Count; i++)
            {
                if (scenes[i].Identifier == identifier)
                {
                    ActiveSceneName = identifier;
                    return;
                }
            }
            SceneState newScene = new SceneState(identifier, name, camera, instance, state, type);
            scenes.Add(newScene);
            if (SceneAdded != null)
                SceneAdded(newScene);
        }

        public static event SceneActionHandler SceneAdded;
        public static event SceneActionHandler SceneRemoved;
        public static event SceneActionHandler SceneChanged;

        /// <summary>
        /// Removes a scene from the list available to be rendered.
        /// </summary>
        public static void RemoveScene(string name)
        {
            for (int i = 0; i < scenes.Count; i++)
            {
                if (scenes[i].Identifier == name)
                {
                    if (sceneIndex >= i)
                        sceneIndex--;

                    SceneState scene = scenes[i];
                    scenes.RemoveAt(i);
                    if (SceneRemoved != null)
                        SceneRemoved(scene);
                    break;
                }
            }
        }

        public static SceneState ActiveSceneState
        {
            get
            {
                if (sceneIndex > -1)
                    return scenes[sceneIndex];
                else
                    return null;
            }
        }

        /// <summary>
        /// Gets or sets the active scene name.
        /// </summary>
        public static string ActiveSceneName
        {
            get
            { return scenes[sceneIndex].Identifier; }
            set
            {
                sceneIndex = -1;
                for (int i = 0; i < scenes.Count; i++)
                {
                    if (scenes[i].Identifier == value)
                    {
                        if (sceneIndex == i) return;
                        sceneIndex = i;
                        if (SceneChanged != null)
                            SceneChanged(scenes[i]);
                        break;
                    }
                }
                if (sceneIndex >= 0)
                    MdxRender.Camera = camera = scenes[sceneIndex].Camera;
            }
        }

        /// <summary>
        /// Handles draw tasks for each frame.
        /// </summary>
        private static void RenderInternal()
        {
            if (OnRender != null)
                OnRender(null, new EventArgs());

            if (sceneIndex >= 0)
            {
                scenes[sceneIndex].Camera.CalculateViewFrustum();
                MdxRender.DrawingTransparent = false;
                scenes[sceneIndex].RenderScene();
                if (MdxRender.DualRendering)
                {
                    MdxRender.DrawingTransparent = true;
                    scenes[sceneIndex].RenderScene();
                    background = scenes[sceneIndex].ClearColor;
                }
            }
            else
            {
                if (m_logo != null)
                {
                    int _passes = m_logo_effect.Begin(0);
                    for (int pass = 0; pass < _passes; pass++)
                    {
                        m_logo_effect.BeginPass(pass);
                        m_logo.DrawSubset(0);
                        m_logo_effect.EndPass();
                    }
                    m_logo_effect.End();
                }
                else
                {
                    // Load and optimise logo mesh.
                    Assembly _current = Assembly.GetExecutingAssembly();
                    Stream _s = _current.GetManifestResourceStream("Core.Resources.X.prom_logo.X");
                    m_logo = Mesh.FromStream(_s, MeshFlags.SystemMemory, MdxRender.Device);
                    int[] _adjacency = new int[m_logo.NumberFaces * 3];
                    m_logo.GenerateAdjacency(10.0f, _adjacency);
                    m_logo.OptimizeInPlace(MeshFlags.OptimizeVertexCache, _adjacency);

                    // Load the texture.
                    _s = _current.GetManifestResourceStream("Core.Resources.textures.sand.dds");
                    m_logo_texture = TextureLoader.FromStream(MdxRender.Device, _s);

                    // Load shader:
                    _s = _current.GetManifestResourceStream("Core.Resources.shaders.deferred_shading.fx");
                    m_logo_effect = Effect.FromStream(MdxRender.Device, _s, null, null, ShaderFlags.None, null);
                    m_logo_effect.SetValue("g_WorldViewProjection", MdxRender.Device.Transform.World *
                        MdxRender.Device.Transform.World *
                        MdxRender.Device.Transform.Projection);
                    m_logo_effect.SetValue("g_World", MdxRender.Device.Transform.World);
                    m_logo_effect.SetValue("g_LightDirection", new Vector4(0.5f, 0.5f, 0.5f, 0.0f));
                    m_logo_effect.SetValue("g_MaterialTexture", m_logo_texture);
                    m_logo_effect.Technique = "RenderScene";
                }
            }
            console.Render();
        }

        /// <summary>
        /// Runs the standard render loop. Should be called every time the application reaches an idle state.
        /// </summary>
        public static void Render()
        {
            while (!MessageOnQueue && canRender && !Paused)
            {
                int result;
                ResultCode coop;
                MdxRender.Device.CheckCooperativeLevel(out result);
                coop = (ResultCode)result;

                if (coop == ResultCode.DeviceLost)
                {
                    Trace.WriteLine("Device lost");
                }
                else
                {
                    Prometheus.Input.Update();
                    UpdateCameraFromInput();

                    try
                    {
                        CanRender = false;
                        MdxRender.FrameTimer.EndFrame();
                        MdxRender.FrameTimer.BeginFrame();

                        UpdateViewTransform();

                        if (MdxRender.Device == null)
                        {
                            canRender = false;
                            AttemptRecovery();
                            return;
                        }

                        MdxRender.Device.Clear(ClearFlags.Target | ClearFlags.ZBuffer, background, 1.0f, 0);
                        MdxRender.Device.Transform.World = Matrix.Identity;
                        MdxRender.Device.RenderState.ZBufferWriteEnable = true;
                        MdxRender.Device.RenderState.ZBufferEnable = true;
                        MdxRender.Device.RenderState.ZBufferFunction = Compare.LessEqual;

                        if (sceneIndex >= 0)
                        {
                            scenes[sceneIndex].SetupCamera();
                        }
                        MdxRender.Device.BeginScene();

                        RenderInternal();
                        DrawFPS();

                        MdxRender.Device.EndScene();

                        MdxRender.Device.Present();

                        //SwapChain sc = MdxRender.Dev.GetSwapChain(0);
                        //sc.Present(Present.LinearContent);
                        CanRender = true;
                    }
                    catch (Exception _ex)
                    {
                        Output.Write(OutputTypes.Error, string.Format("Error during render cycle: {0}", _ex.Message));
                        AttemptRecovery();
                    }
                }
            }
        }

        /// <summary>
        /// Attempts to recover the device if it has been lost at any point.
        /// </summary>
        public static void AttemptRecovery()
        {
            try
            {
                MdxRender.Device.TestCooperativeLevel();
            }
            catch (DeviceLostException)
            {
                Output.Write(OutputTypes.Error, "Device is lost state: AttemptRecovery()");
            }
            catch (DeviceNotResetException)
            {
                try
                {
                    MdxRender.Device.Reset(pp);
                    bDeviceLost = false;
                    canRender = true;
                }
                catch (Exception _ex)
                {
                    Output.Write(OutputTypes.Error, string.Format("Total device failure: {0}", _ex.Message));
                    Initialize(renderTarget, tagPool);
                    bDeviceLost = false;
                    CanRender = true;
                }
            }
        }

        /// <summary>
        /// Draws the frames per second to the screen (fps).
        /// </summary>
        private static void DrawFPS()
        {
            //if (OptionsManager.EnableFPS)
            fontFPS.DrawText(null, string.Format("{0} fps", MdxRender.FrameTimer.FPS), 3, 3, Color.White);
        }

        /// <summary>
        /// Gets or sets a value indicating the preparedness of the engine to draw. Render will cease to be active and no longer function if false.
        /// </summary>
        public static bool CanRender
        {
            get
            { return canRender; }
            set
            { canRender = value; }
        }

        /// <summary>
        /// Updates camera position and orientation based on input from user.
        /// </summary>
        public static void UpdateCameraFromInput()
        {
            //      if (d3dInitialized && enableCameraInput && (camera != null) && enableKeyboardInput)//&&MdxInput.Initialized
            if (d3dInitialized && (camera != null))//&&MdxInput.Initialized
            {
                camera.SetFPS(MdxRender.FrameTimer.FPS);

                if (Prometheus.Input.CameraForward)
                    camera.Move(-1);

                if (Prometheus.Input.CameraLeft)
                    camera.Strafe(-1);

                if (Prometheus.Input.CameraBack)
                    camera.Move(1);

                if (Prometheus.Input.CameraRight)
                    camera.Strafe(1);

                if (Prometheus.Input.CameraUp)
                    camera.Up(1);

                if (Prometheus.Input.CameraDown)
                    camera.Up(-1);

                if (Prometheus.Input.CameraSpinLeft)
                    camera.Spin(-1);

                if (Prometheus.Input.CameraSpinRight)
                    camera.Spin(1);

                //if(state[Key.PageUp])
                //  Camera.IncreaseSpeed();

                //if(state[Key.PageDown])
                //  Camera.DecreaseSpeed();

                if (m_mouseEnabled)
                {
                    float input_x = Prometheus.Input.MouseX;
                    float input_y = Prometheus.Input.MouseY;

                    float xScale = -0.006f;
                    float yScale = -0.006f;
                    input_x *= xScale;
                    input_y *= yScale;

                    if ((Prometheus.Input.CameraActive) && (CameraLockRequested == false))
                    {
                        m_PitchAvg.Update(-input_y);
                        m_YawAvg.Update(-input_x);
                        camera.Pitch(m_PitchAvg.Average);
                        camera.Yaw(m_YawAvg.Average);
                    }
                }

                camera.Update();
            }
        }

        /// <summary>
        /// Peeks messages on queue.
        /// </summary>
        [SuppressUnmanagedCodeSecurity, DllImport("User32.dll")]
        public static extern bool PeekMessage(out PeekMsg msg, IntPtr hWnd, uint messageFilterMin, uint messageFilterMax, uint flags);

        [StructLayout(LayoutKind.Sequential)]
        public struct PeekMsg
        {
            public IntPtr hWnd;
            public Message msg;
            public IntPtr wParam;
            public IntPtr lParam;
            public uint time;
            public Point p;
        }

        /// <summary>
        /// Returns true if there is a message waiting on the queue.
        /// </summary>
        private static bool MessageOnQueue
        {
            get
            {
                PeekMsg msg;
                return PeekMessage(out msg, IntPtr.Zero, 0, 0, 0);
            }
        }

        public static bool ContainsScene(string identifier)
        {
            for (int i = 0; i < scenes.Count; i++)
                if (scenes[i].Identifier == identifier)
                    return true;
            return false;
        }

        public static void SetClearColor(Color color)
        {
            scenes[sceneIndex].ClearColor = color;
        }

        public static Vector3 IntersectCurrentScene(Vector3 origin, Vector3 direction)
        {
            if (sceneIndex < 0)
                return Vector3.Empty;

            Intersection intersection = scenes[sceneIndex].Instance.IntersectRay(origin, direction);

            if (intersection == null)
                return scenes[sceneIndex].Camera.Position;
            else
                return intersection.Position;
        }
    }

    public delegate void SceneActionHandler(SceneState scene);
}