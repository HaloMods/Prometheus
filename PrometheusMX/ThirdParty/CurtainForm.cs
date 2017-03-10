/***************************************************
 * Written by Mathieu Jacques, september 2006
 * 
 * No rights reserved.  Free to use and modify as you want. 
 * 
 * History:
 * 
 * September 20, 2006:  - Enhancement: Hide the curtain when the binded control is destroyed
 * September 21, 2006:  - New Feature: Binders for Form load/close and TabControl
 * September 22, 2006:  - New Feature: AutoCloseCurtain since not closing a curtain waste resources
 *                      - Refactoring: CurtainAnimation created to encapsulate how the curtain is dismissed
 * September 28, 2006:  - No more topmost. Now only topmost for the application.  This avoids hiding other
 *                        applications as well.
 * January 10, 2007:    - Enhancement (thanks to Igor Velikorossov): make sure bitmap buffers are valid before
 *                        displaying the curtain.
 * *************************************************/

using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;
// for DllImport

namespace Prometheus.ThirdParty.Controls
{
    /// <summary>
    /// Freeze a screen part until update is done.  Like a theater curtain hiding the setting up
    /// of the next scene and gracefully opens when it's done.
    /// </summary>
    /// References:
    /// 
    /// Making a window click-through:
    /// http://www.codeproject.com/vb/net/ClickThroughWindows.asp    
    /// 
    /// Preventing a window from getting focus by giving back the focus to the
    /// deactivated window.  Not perfect since the window may blink but enough
    /// for this component.
    /// http://forums.microsoft.com/MSDN/ShowPost.aspx?PostID=402741&SiteID=1
    public partial class CurtainForm : Form
    {        
        public CurtainForm()
        {   
            InitializeComponent();            

            m_frameDuration = 50;
            
            m_timer.Interval = m_frameDuration;
            m_timer.Tick += new EventHandler(timer_Tick);            

            SetStyle(ControlStyles.Selectable, false);            
            UpdateStyles();
            
            Opacity = 0.00;            

            AnimationDuration = 250;
            ClickThrough = true;
        }       
        
        /// <summary>
        /// Get/Set the duration of one frame in msec.  This is like the animation quality in frames per second.
        /// Frame duration in msec is 1000/frames per second.   
        /// </summary>
        public int FrameDuration
        {
            set
            {
                if (value <= 0)
                {
                    value = 1;
                }

                m_frameDuration = value;
                m_timer.Interval = value;

                // recalculate other parameters... 
                AnimationDuration = AnimationDuration;
            }

            get
            {
                return m_frameDuration;
            }
        }

        /// <summary>
        /// Get/Set animation duration in msec.  This is the time from which the curtain is completely opaque until
        /// the curtain is transparent.
        /// </summary>
        public int AnimationDuration
        {
            set
            {
                // duration must not be less than the smallest time unit
                if (value < m_frameDuration)
                {
                    value = m_frameDuration;
                }

                m_animationDuration = value;
            }

            get
            {
                return m_animationDuration;
            }
        }

        /// <summary>
        /// Get/Set whether the curtain is click-though.  Useful when using long fade duration.
        /// </summary>
        /// That is, whether the user can click
        /// through the curtain while it is fading.  This has no effect when not fading since the 
        /// goal of the curtain is to hide what's going on behind.
        public bool ClickThrough
        {
            set
            {
                m_clickThrough = value;
            }

            get
            {
                return m_clickThrough;
            }
        }

        /// <summary>
        /// Override the Opacity get/set to make sure the opacity is always less
        /// than 1.0.  Avoid screen flickering when switching from layered window
        /// to normal window.
        /// </summary>
        public new double Opacity
        {
            get
            {
                return base.Opacity;
            }

            set
            {
                if (value > 0.999)
                {
                    value = 0.999;
                }

                base.Opacity = value;
            }
        }


        /// <summary>
        /// Show the curtain without owner window.
        /// </summary>
        /// Don't forget to set the curtain position manually before.
        public new void Show()
        {
          if (InvokeRequired)
          {
            Invoke(new MethodInvoker(delegate { Show(); }));
            return;
          }

          Hide();            
          Appear();
        }

        /// <summary>
        /// Show the curtain over this window or control.  
        /// </summary>        
        /// Providing an owner window prevents the curtain from stealing the focus, which may have indesirable
        /// effects like title bar blinking. If the window is a control, the 
        /// curtain will be positionned over the control.
        public new void Show(IWin32Window owner)
        {
          if (InvokeRequired)
          {
            Invoke(new MethodInvoker(delegate { Show(owner); }));
            return;
          }
  
          Hide();
            
          Control control = FromHandle(owner.Handle);
          if (control != null)
          {
            BindTo(control);
          }
          Appear();            
        }

        /// <summary>
        /// Hide the curtain using this animation
        /// </summary>        
        public void Hide(CurtainAnimation animation)
        {
          if (InvokeRequired)
          {
            Invoke(new MethodInvoker(delegate { Hide(animation); }));
            return;
          }
  
          if (m_isAnimating)
          {   
            return;
          }
            
          m_animation = animation;
          animation.Begin(this);
            
          m_curAnimationStep = 0;
          m_totalAnimationSteps = AnimationDuration / FrameDuration + 1;
          m_isAnimating = true;
          m_timer.Start();
        }        

        /// <summary>
        /// End the current animation if any and hide the curtain
        /// </summary>
        public new void Hide()
        {
          if (InvokeRequired)
          {
            Invoke(new MethodInvoker(delegate { Hide(); }));
            return;
          }
  
          Opacity = 0.00;
          m_timer.Stop();
          m_isAnimating = false;            
            
          UnBind();
          base.Hide();            
        }
        
        /// <summary>
        /// Hide the curtain using a smooth fade animation
        /// </summary>
        public void Fade()
        {
          if (InvokeRequired)
          {
            Invoke(new MethodInvoker(delegate { Fade(); }));
            return;
          }
          Hide(new FadeCurtain());
        }

        /// <summary>
        /// Delegate to a method without parameter
        /// </summary> 
        private delegate void NoParamDelegate();

        public new void Close()
        {
            // may be called from a destructor which may be executed
            // in another thread...
            if (InvokeRequired)
            {
                NoParamDelegate del = new NoParamDelegate(Close);
                Invoke(del);
                return;
            }

            Hide();
            base.Close();            
        }

        /// <summary>
        /// Position the curtain over this control and listen to a position
        /// change in order to follow it if needed.
        /// </summary>        
        private void BindTo(Control control)
        {
            if (m_bindedControl != null)
            {
                UnBind();
            }

            Rectangle bounds = ComputeControlScreenBounds(control);;
                
            if (Bounds != bounds)
            {
                Bounds = bounds;
            }

            control.TopLevelControl.LocationChanged += new EventHandler(bindedControl_LocationChanged);
            control.TopLevelControl.HandleDestroyed += new EventHandler(bindedControl_HandleDestroyed);            

            // Make sure the window appear on top of its owner...
            if (Owner == null)
            {
                Owner = control.TopLevelControl as Form;
                BringToFront();
            }

            m_bindedControl = control;
        }
        
        /// <summary>
        /// Compute a control screen coordinates 
        /// </summary>        
        private Rectangle ComputeControlScreenBounds(Control control)
        {
            // top level window doesn't need any position conversion... already screen coordinates
            if (control.TopLevelControl == control)
            {
                return control.Bounds;
            }

            Rectangle rect = control.Bounds;
            rect.X = 0;
            rect.Y = 0;
            return control.RectangleToScreen(rect);
        }

        /// <summary>
        /// Release all references on the binded control
        /// </summary>
        private void UnBind()
        {
            if (m_bindedControl != null)
            {
                if (m_bindedControl.TopLevelControl != null)
                {
                    m_bindedControl.TopLevelControl.LocationChanged -= new EventHandler(bindedControl_LocationChanged);
                    m_bindedControl.TopLevelControl.HandleDestroyed -= new EventHandler(bindedControl_HandleDestroyed);
                }
            }
            
            m_bindedControl = null;
        }

        private void bindedControl_LocationChanged(object sender, EventArgs e)
        {
            Rectangle bounds = ComputeControlScreenBounds(m_bindedControl);            
            Left = bounds.X;
            Top = bounds.Y;
            Refresh();
        }

        void bindedControl_HandleDestroyed(object sender, EventArgs e)
        {
            // the control is destroyed... so nothing to hide anymore!
            Close();
        }       

        protected override void OnResize(EventArgs e)
        {
            // terminate current animation if any...
            Hide();

            // recreate screen buffer to fit the new size...

            CreateCurtainScreenBitmap(Bounds);       
            
            base.OnResize(e);
        }
        
        private void CreateCurtainScreenBitmap(Rectangle bounds)
        {
            Clear();

            using (Graphics g = CreateGraphics())
            {
                // create a bitmap large enough to cover the whole curtain...
                m_screenBmp = new Bitmap(bounds.Width, bounds.Height, g);

                // create a graphics linked to the bitmap so when you draw with
                // the graphics object, you actually modify the bitmap...
                m_screenGraphics = Graphics.FromImage(m_screenBmp);
            }        
        }
        
        /// <summary>
        /// Show the curtain, mirroring the specified region.
        /// </summary>        
        private void Appear()
        {
            DisplayStillImage();

            Opacity = 0;
            m_curAnimationStep = 0;

            // show the curtain without stealing focus... 
            ShowWindow(Handle, SW_SHOWNOACTIVATE);                        

            // don't wait for the paint message to be processed... paint immediately!
            // This way, if the UI under the curtain changes right away, it will be hidden.            
            Refresh();
        }       
        
        private void DisplayStillImage()
        {
            try
            {
                TakeScreenSnapshot();
            }
            catch
            {
                // buffer may be invalid or not created yet...give it a try!                
                CreateCurtainScreenBitmap(Bounds);
                TakeScreenSnapshot();
            }

            BackgroundImage = m_screenBmp;
        }

        /// <summary>
        /// Take a screen snapshot at the curtain position
        /// </summary>
        private void TakeScreenSnapshot()
        {
            m_screenGraphics.CopyFromScreen(Bounds.Left, Bounds.Top, 0, 0, Bounds.Size);
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            if (m_curAnimationStep >= m_totalAnimationSteps)
            {
                m_animation.End(this);
                Hide();
            }

            m_animation.Animate(this, m_curAnimationStep, m_totalAnimationSteps);            
            
            m_curAnimationStep++;           
        }
        
        protected override void OnPaint(PaintEventArgs e)
        {
            if (m_screenBmp != null )
            {
                if (Opacity == 0 && m_curAnimationStep == 0)
                {
                    // setting the opacity to less than 1.0 avoids screen flicker
                    Opacity = 0.999;
                }
                
                base.OnPaint(e);
            }            
        }       

        protected override void WndProc(ref Message m)
        {
            switch (m.Msg)
            {
                // Although ShowWindow doesnt't activate the curtain, the user can still
                // click while loading, and thus activate it.  
                case WM_ACTIVATE:
                    {
                        if (((int)m.WParam & 0xFFFF) != WA_INACTIVE)
                        {
                            if (m.LParam != IntPtr.Zero)
                            {
                                // re-focus the deactivated control!
                                Control control = FromHandle(m.LParam);
                                if (control != null)
                                {
                                    control.Focus();
                                }
                            }
                        }
                    }
                    break;

                // when fading, the window may be click-through...
                case WM_NCHITTEST:
                    {
                        if( m_clickThrough && m_isAnimating )
                        {
                            m.Result = (IntPtr)HTTRANSPARENT;
                            return;
                        }
                    }
                    break;
            }          

            base.WndProc(ref m);
        } 


        /// <summary>
        /// Dispose memory hungry objects
        /// </summary>
        private void Clear()
        {
            if (m_screenGraphics != null) { m_screenGraphics.Dispose(); }
            if (m_screenBmp != null) { m_screenBmp.Dispose(); }

            m_screenGraphics = null;
            m_screenBmp = null;
        }
        
        private Timer m_timer = new Timer();
        
        /// <summary>
        /// The still image displayed 
        /// </summary>
        private Bitmap m_screenBmp = null;              
        
        /// <summary>
        /// Graphics object linked to the screenBmp
        /// </summary>
        private Graphics m_screenGraphics = null;               
       
        /// <summary>
        /// The current animation object
        /// </summary>
        private CurtainAnimation m_animation = null;

        private int m_curAnimationStep;
        private int m_totalAnimationSteps;

        /// <summary>
        /// Total fade duration in msec
        /// </summary>
        private int m_animationDuration = 0;                 
        
        /// <summary>
        /// One frame duration in msec
        /// </summary>
        private int m_frameDuration = 50;               
        
        /// <summary>
        /// Whether the form is click-through
        /// </summary>
        private bool m_clickThrough = false;            
        
        /// <summary>
        /// Whether the curtain is currently fading
        /// </summary>
        private bool m_isAnimating = false;             

        /// <summary>
        /// The control under the curtain, so we can track its position etc...
        /// </summary>
        private Control m_bindedControl = null;

        [DllImport("user32.dll")]
        private static extern Boolean ShowWindow(IntPtr hWnd, Int32 nCmdShow);

        private const int SW_SHOWNOACTIVATE = 4;        // show a window without activating it
        private const int WM_ACTIVATE = 6;
        private const int WA_INACTIVE = 0;
        private const int WM_NCHITTEST = 132;
        private const int HTTRANSPARENT = -1;        
        
    }

    /// <summary>
    /// Wrap a curtain and automatically close it when the object is out of scope
    /// </summary>
    class AutoCloseCurtain
    {
        /// <summary>
        /// Get the wrapped curtain
        /// </summary>
        public CurtainForm Curtain
        {
            get
            {
                return m_curtain;
            }
        }

        ~AutoCloseCurtain()
        {
            m_curtain.Close();
        }      

        private CurtainForm m_curtain = new CurtainForm();
    }

    
    /// <summary>
    /// Transition animation.  Blend the old content with the new one.
    /// </summary>
    public interface CurtainAnimation
    {
        /// <summary>
        /// Called at the beginning of the animation.  Useful to setup things.
        /// </summary>
        /// <param name="curtain">the curtain to animate</param>
        /// Don't call curtain.Hide() here!
        void Begin(CurtainForm curtain);
        
        /// <summary>
        /// Called at each step of the animation
        /// </summary>
        /// <param name="curtain">the curtain to animate</param>
        /// <param name="step">current animation step</param>
        /// <param name="totalSteps">total number of steps for the animation</param>
        /// Call curtain.Hide() to end the animation before the end
        void Animate(CurtainForm curtain, int step, int totalSteps);
        
        /// <summary>
        /// Called at the end of the animation.  
        /// </summary>
        /// <param name="curtain">the curtain to animate</param>
        void End(CurtainForm curtain);        
    }

    /// <summary>
    /// Hide the curtain immediately without animation.
    /// </summary>
    class HideCurtain : CurtainAnimation
    {
        public void Begin(CurtainForm curtain)
        {
            
        }

        public void Animate(CurtainForm curtain, int step, int totalSteps)
        {
            curtain.Hide();
        }
        
        public void End(CurtainForm curtain)
        {

        }
    }

    /// <summary>
    /// Fade the curtain away.
    /// </summary>
    class FadeCurtain : CurtainAnimation
    {
        public void Begin(CurtainForm curtain)
        {

        }

        public void Animate(CurtainForm curtain, int step, int totalSteps)
        {
            curtain.Opacity = 1.0 - (step / (double)totalSteps);
        }

        public void End(CurtainForm curtain)
        {
            curtain.Opacity = 0.0;
        }
    }

    

}