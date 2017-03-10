using System;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Runtime.InteropServices;
using System.Globalization;
using Microsoft.Win32;

namespace Core.Radiosity.ConsoleDebug
{
	/// <summary>
	/// Extended console for both Windows and Console Applications.
	/// </summary>
	public class WinConsole
	{
		#region Construction
		private WinConsole()
		{
			Initialize();
		}
		#endregion

		#region Windows API

		[DllImport("user32")]
		static extern void FlashWindowEx(ref FlashWInfo info);

		[DllImport("user32")]
		static extern void MessageBeep(int type);

		[DllImport("user32")]
		static extern int SetWindowLong(IntPtr hWnd, int nIndex, int newValue);

		[DllImport("user32")]
		static extern int GetWindowLong(IntPtr hWnd, int nIndex);

		[DllImport("kernel32")]
		static extern bool AllocConsole();
		
		[DllImport("kernel32")]
		static extern bool FreeConsole();

		[DllImport("kernel32")]
		static extern bool GetConsoleScreenBufferInfo(IntPtr consoleOutput, out ConsoleScreenBufferInfo info);
		
		[DllImport("kernel32")]
		static extern bool GetConsoleTitle(StringBuilder text, int size);
		
		[DllImport("kernel32")]
		static extern IntPtr GetConsoleWindow();

		[DllImport("kernel32")]
		static extern IntPtr GetStdHandle(int handle);

		[DllImport("kernel32")]
		static extern int SetConsoleCursorPosition(IntPtr buffer, Coord position);
		
		[DllImport("kernel32")]
		static extern int FillConsoleOutputCharacter(IntPtr buffer, char character, int length, Coord position, out int written);

		[DllImport("kernel32")]
		static extern bool SetConsoleTextAttribute(IntPtr hConsoleOutput, ConsoleColor wAttributes);

		[DllImport("kernel32")]
		static extern bool SetConsoleTitle(string lpConsoleTitle);

		[DllImport("kernel32")]
		static extern bool SetConsoleCtrlHandler(HandlerRoutine routine, bool add);

		[DllImport("user32")]
		static extern bool ShowWindow(IntPtr hwnd, int nCmdShow);

		[DllImport("user32")]
		static extern bool IsWindowVisible(IntPtr hwnd);

		[DllImport("kernel32")]
		static extern IntPtr CreateConsoleScreenBuffer(int access, int share, IntPtr security, int flags, IntPtr reserved);

		[DllImport("kernel32")]
		static extern bool SetConsoleActiveScreenBuffer(IntPtr handle);

		[DllImport("kernel32")]
		static extern bool WriteConsole(IntPtr handle, string s, int length, out int written, IntPtr reserved);

		[DllImport("kernel32")]
		static extern int GetConsoleCP();

		[DllImport("kernel32")]
		static extern int GetConsoleOutputCP();

		[DllImport("kernel32")]
		static extern bool GetConsoleMode(IntPtr handle, out int flags);

		[DllImport("kernel32")]
		static extern bool SetStdHandle(int handle1, IntPtr handle2);
		
		[DllImport("user32")]
		static extern IntPtr SetParent(IntPtr hwnd, IntPtr hwnd2);

		[DllImport("user32")]
		static extern IntPtr GetParent(IntPtr hwnd);

		[DllImport("user32")]
		static extern bool SetWindowPos(IntPtr hWnd, IntPtr hWndInsertAfter,
			int x, int y, int cx, int cy, int flags);

		[DllImport("user32")]
		static extern bool GetClientRect(IntPtr hWnd, ref RECT rect);

		#endregion
				
		#region Constants

		const int WS_POPUP = unchecked((int) 0x80000000);
		const int WS_OVERLAPPED = 0x0;
		const int WS_CHILD = 0x40000000;
		const int WS_MINIMIZE = 0x20000000;
		const int WS_VISIBLE = 0x10000000;
		const int WS_DISABLED = 0x8000000;
		const int WS_CLIPSIBLINGS = 0x4000000;
		const int WS_CLIPCHILDREN = 0x2000000;
		const int WS_MAXIMIZE = 0x1000000;
		const int WS_CAPTION = 0xC00000;                  //  WS_BORDER | WS_DLGFRAME
		const int WS_BORDER = 0x800000;
		const int WS_DLGFRAME = 0x400000;
		const int WS_VSCROLL = 0x200000;
		const int WS_HSCROLL = 0x100000;
		const int WS_SYSMENU = 0x80000;
		const int WS_THICKFRAME = 0x40000;
		const int WS_GROUP = 0x20000;
		const int WS_TABSTOP = 0x10000;

		const int WS_MINIMIZEBOX = 0x20000;
		const int WS_MAXIMIZEBOX = 0x10000;

		const int WS_TILED = WS_OVERLAPPED;
		const int WS_ICONIC = WS_MINIMIZE;
		const int WS_SIZEBOX = WS_THICKFRAME;
		const int WS_OVERLAPPEDWINDOW = (WS_OVERLAPPED | WS_CAPTION | WS_SYSMENU | WS_THICKFRAME | WS_MINIMIZEBOX | WS_MAXIMIZEBOX);
		const int WS_TILEDWINDOW = WS_OVERLAPPEDWINDOW;


		const int GWL_STYLE = (-16);

		const int SW_HIDE = 0;
		const int SW_SHOWNORMAL = 1;
		const int SW_NORMAL = 1;
		const int SW_SHOWMINIMIZED = 2;
		const int SW_SHOWMAXIMIZED = 3;
		const int SW_MAXIMIZE = 3;
		const int SW_SHOWNOACTIVATE = 4;
		const int SW_SHOW = 5;
		const int SW_MINIMIZE = 6;
		const int SW_SHOWMINNOACTIVE = 7;
		const int SW_SHOWNA = 8;
		const int SW_RESTORE = 9;
		const int SW_SHOWDEFAULT = 10;
		const int SW_MAX = 10;

		const int EMPTY = 32;
		const int CONSOLE_TEXTMODE_BUFFER = 1;

		const int FLASHW_STOP = 0;
		const int FLASHW_CAPTION = 1;
		const int FLASHW_TRAY = 2;
		const int FLASHW_ALL = 3;
		const int FLASHW_TIMER = 4;
		const int FLASHW_TIMERNOFG = 0xc;

		const int _DefaultConsoleBufferSize = 256;

		const int FOREGROUND_BLUE = 0x1;     //  text color contains blue.
		const int FOREGROUND_GREEN = 0x2;     //  text color contains green.
		const int FOREGROUND_RED = 0x4;     //  text color contains red.
		const int FOREGROUND_INTENSITY = 0x8;     //  text color is intensified.
		const int BACKGROUND_BLUE = 0x10;    //  background color contains blue.
		const int BACKGROUND_GREEN = 0x20;    //  background color contains green.
		const int BACKGROUND_RED = 0x40;    //  background color contains red.
		const int BACKGROUND_INTENSITY = 0x80;    //  background color is intensified.
		const int COMMON_LVB_REVERSE_VIDEO = 0x4000;
		const int COMMON_LVB_UNDERSCORE = 0x8000;

		const int GENERIC_READ = unchecked((int) 0x80000000);
		const int GENERIC_WRITE = 0x40000000;

		const int FILE_SHARE_READ = 0x1;
		const int FILE_SHARE_WRITE = 0x2;

		const int STD_INPUT_HANDLE = -10;
		const int STD_OUTPUT_HANDLE = -11;
		const int STD_ERROR_HANDLE = -12;

		const int SWP_NOSIZE = 0x1;
		const int SWP_NOMOVE = 0x2;
		const int SWP_NOZORDER = 0x4;
		const int SWP_NOREDRAW = 0x8;
		const int SWP_NOACTIVATE = 0x10;

		#endregion

		#region Structures
		public delegate bool HandlerRoutine(int type);

		struct RECT
		{ 
			public int left; 
			public int top; 
			public int right; 
			public int bottom; 
		} ; 

		struct ConsoleScreenBufferInfo
		{
			public Coord Size;
			public Coord CursorPosition;
			public ConsoleColor Attributes;
			public SmallRect Window;
			public Coord MaximumWindowSize;
		}

		public struct ConsoleSelectionInfo
		{
			public int Flags;
			public Coord SelectionAnchor;
			public SmallRect Selection;
		}

		public struct SmallRect
		{
			public short Left;
			public short Top;
			public short Right;
			public short Bottom;
		}

		struct FlashWInfo
		{
			public int Size;
			public IntPtr Hwnd;
			public int Flags;
			public int Count;
			public int Timeout;
		}
		
		#endregion

		#region Variables
		static IntPtr buffer;
		static bool initialized;
		static bool breakHit;
		public static event HandlerRoutine Break;
		#endregion

		#region Properties

		/// <summary>
		/// Specifies whether the console window should be visible or hidden
		/// </summary>
		public static bool Visible
		{
			get 
			{
				IntPtr hwnd = GetConsoleWindow();
				return hwnd != IntPtr.Zero && IsWindowVisible(hwnd);
			}
			set
			{
				Initialize();
				IntPtr hwnd = GetConsoleWindow();
				if (hwnd != IntPtr.Zero)
					ShowWindow(hwnd, value ? SW_SHOW : SW_HIDE);
			}
		}

		/// <summary>
		/// Initializes WinConsole -- should be called at the start of the program using it
		/// </summary>
		public static void Initialize()
		{
			if (initialized)
				return;

			IntPtr hwnd = GetConsoleWindow();
			initialized = true;

			SetConsoleCtrlHandler(new HandlerRoutine(HandleBreak), true);
			
			// Console app
			if (hwnd != IntPtr.Zero)
			{
				buffer = GetStdHandle(STD_OUTPUT_HANDLE);
				return;
			}

			// Windows app
			bool success = AllocConsole();
			if (!success)
				return;

			buffer = CreateConsoleScreenBuffer(GENERIC_READ|GENERIC_WRITE,
				FILE_SHARE_READ|FILE_SHARE_WRITE, IntPtr.Zero, CONSOLE_TEXTMODE_BUFFER, IntPtr.Zero);

			bool result = SetConsoleActiveScreenBuffer(buffer);

			SetStdHandle(STD_OUTPUT_HANDLE, buffer);
			SetStdHandle(STD_ERROR_HANDLE, buffer);

			Title = "Console";

			Stream s = Console.OpenStandardInput(_DefaultConsoleBufferSize);
			StreamReader reader = null;
			if (s==Stream.Null)
				reader = StreamReader.Null;
			else
				reader = new StreamReader(s, Encoding.GetEncoding(GetConsoleCP()),
					false, _DefaultConsoleBufferSize);

			Console.SetIn(reader);
    
			// Set up Console.Out
			StreamWriter writer = null;
			s = Console.OpenStandardOutput(_DefaultConsoleBufferSize);
			if (s == Stream.Null) 
				writer = StreamWriter.Null;
			else 
			{
				writer = new StreamWriter(s, Encoding.GetEncoding(GetConsoleOutputCP()),
					_DefaultConsoleBufferSize);
				writer.AutoFlush = true;
			}

			Console.SetOut(writer);

			s = Console.OpenStandardError(_DefaultConsoleBufferSize);
			if (s == Stream.Null) 
				writer = StreamWriter.Null;
			else 
			{
				writer = new StreamWriter(s, Encoding.GetEncoding(GetConsoleOutputCP()),
					_DefaultConsoleBufferSize);
				writer.AutoFlush = true;
			}
			
			Console.SetError(writer);
		}

		/// <summary>
		/// Gets or sets the title of the console window
		/// </summary>
		public static string Title
		{
			get 
			{
				StringBuilder sb = new StringBuilder(256);
				GetConsoleTitle(sb, sb.Capacity);
				return sb.ToString();
			}
			set
			{
				SetConsoleTitle(value);
			}
		}

		/// <summary>
		/// Get the HWND of the console window
		/// </summary>
		/// <returns></returns>

		public static IntPtr Handle
		{
			get
			{
				Initialize();
				return GetConsoleWindow();
			}
		}

		/// <summary>
		/// Gets and sets a new parent hwnd to the console window
		/// </summary>
		/// <param name="window"></param>
		public static IntPtr ParentHandle
		{
			get
			{
				IntPtr hwnd = GetConsoleWindow();
				return GetParent(hwnd);
			}
			set
			{
				IntPtr hwnd = Handle;
				if (hwnd==IntPtr.Zero)
					return;

				SetParent(hwnd, value);
				int style = GetWindowLong(hwnd, GWL_STYLE);
				if (value==IntPtr.Zero)
					SetWindowLong(hwnd, GWL_STYLE, (style &~ WS_CHILD) | WS_OVERLAPPEDWINDOW);
				else
					SetWindowLong(hwnd, GWL_STYLE, (style | WS_CHILD) &~ WS_OVERLAPPEDWINDOW);
				SetWindowPos(hwnd, IntPtr.Zero, 0, 0, 0, 0, SWP_NOSIZE|SWP_NOZORDER|SWP_NOACTIVATE);
			}
		}

		/// <summary>
		/// Get the current Win32 buffer handle
		/// </summary>

		public static IntPtr Buffer
		{
			get 
			{
				if (!initialized) Initialize();
				return buffer;
			}
		}

		/// <summary>
		/// Produces a simple beep.
		/// </summary>

		public static void Beep()
		{
			MessageBeep(-1);
		}

		/// <summary>
		/// Flashes the console window
		/// </summary>
		/// <param name="once">if off, flashes repeated until the user makes the console foreground</param>
		public static void Flash(bool once)
		{
			IntPtr hwnd = GetConsoleWindow();
			if (hwnd==IntPtr.Zero)
				return;

			int style = GetWindowLong(hwnd, GWL_STYLE);
			if ((style & WS_CAPTION)==0)
				return;

			FlashWInfo info = new FlashWInfo();
			info.Size = Marshal.SizeOf(typeof(FlashWInfo));
			info.Flags = FLASHW_ALL;
			if (!once) info.Flags |= FLASHW_TIMERNOFG;
			FlashWindowEx(ref info);
		}

		/// <summary>
		/// Clear the console window
		/// </summary>

		public static void Clear()
		{
			Initialize();
			ConsoleScreenBufferInfo info;
			int writtenChars;
			GetConsoleScreenBufferInfo(buffer, out info);
			FillConsoleOutputCharacter(buffer, ' ', info.Size.X * info.Size.Y, new Coord(), out writtenChars);
			CursorPosition = new Coord();
		}

		/// <summary>
		/// Get the current position of the cursor
		/// </summary>
		/// 
		public static Coord CursorPosition
		{
			get	{ return Info.CursorPosition; }
			set 
			{
				Initialize();
				SetConsoleCursorPosition(buffer, new Coord());
			}
		}

		/// <summary>
		/// Returns a coordinates of visible window of the buffer
		/// </summary>
		
		public static SmallRect ScreenSize
		{
			get { return Info.Window; }
		}

		/// <summary>
		/// Returns the size of buffer
		/// </summary>

		public static Coord BufferSize
		{
			get { return Info.Size; }
		}

		/// <summary>
		/// Returns the maximum size of the screen given the desktop dimensions
		/// </summary>

		public static Coord MaximumScreenSize
		{
			get { return Info.MaximumWindowSize; }
		}

		/// <summary>
		/// Redirects debug output to the console
		/// </summary>
		/// <param name="clear">clear all other listeners first</param>
		/// <param name="color">color to use for display debug output</param>

		public void RedirectDebugOutput(bool clear, ConsoleColor color, bool beep)
		{
			if (clear)
			{
				Debug.Listeners.Clear();
				// Debug.Listeners.Remove("Default");
			}
			Debug.Listeners.Add( new TextWriterTraceListener(new ConsoleWriter(Console.Error, color, ConsoleFlashMode.FlashUntilResponse, beep), "console") );
		}

		/// <summary>
		/// Redirects trace output to the console
		/// </summary>
		/// <param name="clear">clear all other listeners first</param>
		/// <param name="color">color to use for display trace output</param>

		public void RedirectTraceOutput(bool clear, ConsoleColor color)
		{
			if (clear)
			{
				Trace.Listeners.Clear();
				// Trace.Listeners.Remove("Default");
			}
			Trace.Listeners.Add( new TextWriterTraceListener(new ConsoleWriter(Console.Error, color, 0, false), "console") );
		}


		/// <summary>
		/// Returns various information about the screen buffer
		/// </summary>
		static ConsoleScreenBufferInfo Info
		{
			get
			{
				ConsoleScreenBufferInfo info = new ConsoleScreenBufferInfo();
				IntPtr buffer = Buffer;
				if (buffer!=IntPtr.Zero)
					GetConsoleScreenBufferInfo(buffer, out info);
				return info;
			}
		}

		/// <summary>
		/// Gets or sets the current color and attributes of text 
		/// </summary>
		public static ConsoleColor Color
		{
			get 
			{
				return Info.Attributes;
			}
			set
			{
				IntPtr buffer = Buffer;
				if (buffer != IntPtr.Zero)
					WinConsole.SetConsoleTextAttribute(buffer, value);
			}
		}

		/// <summary>
		/// Returns true if Ctrl-C or Ctrl-Break was hit since the last time this property
		/// was called. The value of this property is set to false after each request.
		/// </summary>
		public static bool CtrlBreakPressed
		{
			get 
			{ 
				bool value = breakHit;
				breakHit = false;
				return value; 
			}
		}

		private static bool HandleBreak(int type)
		{
			breakHit = true;
			if (Break != null)
				Break(type);

			return true;
		}


		#endregion

		#region Location

		/// <summary>
		/// Gets the Console Window location and size in pixels
		/// </summary>
		public void GetWindowPosition(out int x, out int y, out int width, out int height)
		{
			RECT rect = new RECT();
			GetClientRect(Handle, ref rect);
			x = rect.top;
			y = rect.left;
			width = rect.right - rect.left;
			height = rect.bottom - rect.top;
		}

		/// <summary>
		/// Sets the console window location and size in pixels
		/// </summary>
		public void SetWindowPosition(int x, int y, int width, int height)
		{
			SetWindowPos(Handle, IntPtr.Zero, x, y, width, height, SWP_NOZORDER|SWP_NOACTIVATE);
		}

		#endregion

		#region Console Replacements

		/// <summary>
		/// Returns the error stream (same as Console.Error)
		/// </summary>
		public static TextWriter Error
		{
			get 
			{ 
				return Console.Error; 
			} 
		}

		/// <summary>
		/// Returns the input stream (same as Console.In)
		/// </summary>
		public static TextReader In
		{
			get { return Console.In; }
		}

		/// <summary>
		/// Returns the output stream (same as Console.Out)
		/// </summary>
		public static TextWriter Out 
		{
			get { return Console.Out; }
		}
        
		/// <summary>
		/// Same as the Console counterpart
		/// </summary>
		public static Stream OpenStandardInput() 
		{
			return Console.OpenStandardInput();
		}
        
		/// <summary>
		/// Same as the Console counterpart
		/// </summary>
		public static Stream OpenStandardInput(int bufferSize) 
		{
			return Console.OpenStandardInput(bufferSize);
		}

		/// <summary>
		/// Same as the Console counterpart
		/// </summary>
		public static Stream OpenStandardError() 
		{
			return Console.OpenStandardError();
		}
        
		/// <summary>
		/// Same as the Console counterpart
		/// </summary>
		public static Stream OpenStandardError(int bufferSize) 
		{
			return Console.OpenStandardError(bufferSize);
		}

		/// <summary>
		/// Same as the Console counterpart
		/// </summary>
		public static Stream OpenStandardOutput() 
		{
			return Console.OpenStandardOutput();
		}
        
		/// <summary>
		/// Same as the Console counterpart
		/// </summary>
		public static Stream OpenStandardOutput(int bufferSize) 
		{
			return Console.OpenStandardOutput(bufferSize);
		}
        
		/// <summary>
		/// Same as the Console counterpart
		/// </summary>
		public static void SetIn(TextReader newIn) 
		{
			Console.SetIn(newIn);
		}
    
		/// <summary>
		/// Same as the Console counterpart
		/// </summary>
		public static void SetOut(TextWriter newOut) 
		{
			Console.SetOut(newOut);
		}
    
		/// <summary>
		/// Same as the Console counterpart
		/// </summary>
		public static void SetError(TextWriter newError) 
		{
			Console.SetError(newError);
		}
        
		/// <summary>
		/// Same as the Console counterpart
		/// </summary>
		public static int Read()
		{
			return Console.Read();
		}
        
		/// <summary>
		/// Same as the Console counterpart
		/// </summary>
		public static String ReadLine()
		{
			return Console.ReadLine();
		}
        
		/// <summary>
		/// Same as the Console counterpart
		/// </summary>
		public static void WriteLine()
		{
			Console.WriteLine();
		}
        
		/// <summary>
		/// Same as the Console counterpart
		/// </summary>
		public static void WriteLine(bool value)
		{
			Console.WriteLine(value);
		}
        
		/// <summary>
		/// Same as the Console counterpart
		/// </summary>
		public static void WriteLine(char value)
		{
			Console.WriteLine(value);
		}   
        
		/// <summary>
		/// Same as the Console counterpart
		/// </summary>
		public static void WriteLine(char[] buffer)
		{
			Console.WriteLine(buffer);
		}
                   
		/// <summary>
		/// Same as the Console counterpart
		/// </summary>
		public static void WriteLine(char[] buffer, int index, int count)
		{
			Console.WriteLine(buffer, index, count);
		}
        
		/// <summary>
		/// Same as the Console counterpart
		/// </summary>
		public static void WriteLine(decimal value)
		{
			Console.WriteLine(value);
		}   

		/// <summary>
		/// Same as the Console counterpart
		/// </summary>
		public static void WriteLine(double value)
		{
			Console.WriteLine(value);
		}   
        
		/// <summary>
		/// Same as the Console counterpart
		/// </summary>
		public static void WriteLine(float value)
		{
			Console.WriteLine(value);
		}   
           
		/// <summary>
		/// Same as the Console counterpart
		/// </summary>
		public static void WriteLine(int value)
		{
			Console.WriteLine(value);
		}
        
		/// <summary>
		/// Same as the Console counterpart
		/// </summary>
		[CLSCompliant(false)]
		public static void WriteLine(uint value)
		{
			Console.WriteLine(value);
		}
    
		/// <summary>
		/// Same as the Console counterpart
		/// </summary>
		public static void WriteLine(long value)
		{
			Console.WriteLine(value);
		}
        
		/// <summary>
		/// Same as the Console counterpart
		/// </summary>
		[CLSCompliant(false)]
		public static void WriteLine(ulong value)
		{
			Console.WriteLine(value);
		}
    
		/// <summary>
		/// Same as the Console counterpart
		/// </summary>
		public static void WriteLine(Object value)
		{
			Console.WriteLine(value);
		}
        
		/// <summary>
		/// Same as the Console counterpart
		/// </summary>
		public static void WriteLine(String value)
		{
			Console.WriteLine(value);
		}
    
		/// <summary>
		/// Same as the Console counterpart
		/// </summary>
		public static void WriteLine(String format, Object arg0)
		{
			Console.WriteLine(format, arg0);
		}
    
		/// <summary>
		/// Same as the Console counterpart
		/// </summary>
		public static void WriteLine(String format, Object arg0, Object arg1)
		{
			Console.WriteLine(format, arg0, arg1);
		}
        
		/// <summary>
		/// Same as the Console counterpart
		/// </summary>
		public static void WriteLine(String format, Object arg0, Object arg1, Object arg2)
		{
			Console.WriteLine(format, arg0, arg1, arg2);
		}
        
		/// <summary>
		/// Same as the Console counterpart
		/// </summary>
		public static void WriteLine(String format, params Object[] arg)
		{
			Console.WriteLine(format, arg);
		}
        
		/// <summary>
		/// Same as the Console counterpart
		/// </summary>
		public static void Write(String format, Object arg0)
		{
			Console.Write(format, arg0);
		}
        
		/// <summary>
		/// Same as the Console counterpart
		/// </summary>
		public static void Write(String format, Object arg0, Object arg1)
		{
			Console.Write(format, arg0, arg1);
		}
        
		/// <summary>
		/// Same as the Console counterpart
		/// </summary>
		public static void Write(String format, Object arg0, Object arg1, Object arg2)
		{
			Console.Write(format, arg0, arg1, arg2);
		}

		/// <summary>
		/// Same as the Console counterpart
		/// </summary>
		public static void Write(String format, params Object[] arg)
		{
			Console.Write(format, arg);
		}
        
		/// <summary>
		/// Same as the Console counterpart
		/// </summary>
		public static void Write(bool value)
		{
			Console.Write(value);
		}
    
		/// <summary>
		/// Same as the Console counterpart
		/// </summary>
		public static void Write(char value)
		{
			Console.Write(value);
		}   
        
		/// <summary>
		/// Same as the Console counterpart
		/// </summary>
		public static void Write(char[] buffer)
		{
			Console.Write(buffer);
		}
        
		/// <summary>
		/// Same as the Console counterpart
		/// </summary>
		public static void Write(char[] buffer, int index, int count)
		{
			Console.Write(buffer, index, count);
		}
        
		/// <summary>
		/// Same as the Console counterpart
		/// </summary>
		public static void Write(double value)
		{
			Console.Write(value);
		}   
        
		/// <summary>
		/// Same as the Console counterpart
		/// </summary>
		public static void Write(decimal value)
		{
			Console.Write(value);
		}   
        
		/// <summary>
		/// Same as the Console counterpart
		/// </summary>
		public static void Write(float value)
		{
			Console.Write(value);
		}   
        
		/// <summary>
		/// Same as the Console counterpart
		/// </summary>
		public static void Write(int value)
		{
			Console.Write(value);
		}
        
		/// <summary>
		/// Same as the Console counterpart
		/// </summary>
		[CLSCompliant(false)]
		public static void Write(uint value)
		{
			Console.Write(value);
		}
    
		/// <summary>
		/// Same as the Console counterpart
		/// </summary>
		public static void Write(long value)
		{
			Console.Write(value);
		}
        
		/// <summary>
		/// Same as the Console counterpart
		/// </summary>
		public static void Write(ulong value)
		{
			Console.Write(value);
		}
    
		/// <summary>
		/// Same as the Console counterpart
		/// </summary>
		public static void Write(Object value)
		{
			Console.Write(value);
		}
        
		/// <summary>
		/// Same as the Console counterpart
		/// </summary>
		public static void Write(String value)
		{
			Console.Write(value);
		}

		#endregion

		#region Notepad Launcher

		public static int LaunchNotepadDialog(string arguments)
		{
			ProcessStartInfo info = new ProcessStartInfo();
			info.FileName = "notepad.exe";
			info.Arguments = arguments;
			
			Process process = Process.Start(info);
			if (process == null)
				return 1;
			process.WaitForExit();
			return process.ExitCode;
		}

		#endregion
	}

	[Flags]
	public enum ConsoleColor : short
	{
		Black		  = 0x0000,
		Blue		  = 0x0001,
		Green		  = 0x0002,
		Cyan		  = 0x0003,
		Red		 	  = 0x0004,
		Violet		  = 0x0005,
		Yellow		  = 0x0006,
		White		  = 0x0007,
		Intensified	  = 0x0008,
		Normal	      = White,

		BlackBG		  = 0x0000,
		BlueBG	 	  = 0x0010,
		GreenBG		  = 0x0020,
		CyanBG		  = 0x0030,
		RedBG		  = 0x0040,
		VioletBG	  = 0x0050,
		YellowBG      = 0x0060,
		WhiteBG	      = 0x0070,
		IntensifiedBG = 0x0080,

		Underline    = 0x4000,
		ReverseVideo = unchecked((short)0x8000),
	}

	public struct Coord
	{
		public short X;
		public short Y;
	}

}
