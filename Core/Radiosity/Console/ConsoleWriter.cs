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
	/// Summary description for ConsoleWriter.
	/// </summary>
	/// 
	
	public enum ConsoleFlashMode
	{
		NoFlashing,
		FlashOnce,
		FlashUntilResponse,
	}

	public class ConsoleWriter : TextWriter
	{
		#region Variables
		TextWriter writer;
		ConsoleColor color;
		ConsoleFlashMode flashing;
		bool beep;
		#endregion

		#region Construction
		public ConsoleWriter(TextWriter writer, ConsoleColor color, ConsoleFlashMode mode, bool beep) 
		{
			this.color = color;
			this.flashing = mode;
			this.writer = writer;
			this.beep = beep;
		}
		#endregion

		#region Properties
		public ConsoleColor Color
		{
			get { return color; }
			set { color = value; }
		}
		
		public ConsoleFlashMode FlashMode
		{
			get { return flashing; }
			set { flashing = value; }
		}

		public bool BeepOnWrite
		{
			get { return beep; }
			set { beep = value; }
		}
		#endregion

		#region Write Routines
 
		public override Encoding Encoding
		{
			get { return writer.Encoding; }
		}

		protected void Flash()
		{
			switch (flashing)
			{
				case ConsoleFlashMode.FlashOnce:
					WinConsole.Flash(true);
					break;
				case ConsoleFlashMode.FlashUntilResponse:
					WinConsole.Flash(false);
					break;
			}

			if (beep)
				WinConsole.Beep();
		}

		public override void Write(char ch)
		{
			ConsoleColor oldColor = WinConsole.Color;
			try
			{
				WinConsole.Color = color;
				writer.Write(ch);
			}
			finally
			{
				WinConsole.Color = oldColor;
			}
			Flash();
		}

		public override void Write(string s)
		{
			ConsoleColor oldColor = WinConsole.Color;
			try
			{
				WinConsole.Color = color;
				Flash();
				writer.Write(s);
			}
			finally
			{
				WinConsole.Color = oldColor;
			}
			Flash();
		}

		public override void Write(char[] data, int start, int count)
		{
			ConsoleColor oldColor = WinConsole.Color;
			try
			{
				WinConsole.Color = color;
				writer.Write(data, start, count);
			}
			finally
			{
				WinConsole.Color = oldColor;
			}
			Flash();
		}
		#endregion
	}

}
