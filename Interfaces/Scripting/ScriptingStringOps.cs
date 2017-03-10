using System;
using System.Text;

namespace Interfaces.Scripting
{
	public static class ScriptingStringOps
	{
		/// <summary>
		/// Formats a BSL string as a PSL string for the given map.
		/// </summary>
		public static string ToPslFormatting(string input, string mapName)
		{
			// fix this so it detects a change from number/mapname to letter or backwards, not just one way.
			StringBuilder sb = new StringBuilder();

			string[] parts = input.Split('_');
			foreach (string part in parts)
			{
				char initialCharacter = part[0];
				if (Char.IsDigit(initialCharacter) || part == mapName)
					sb.Append("_");
				sb.Append(Char.ToUpper(initialCharacter));
				sb.Append(part.Substring(1));
			}

			return sb.ToString();
		}
	}
}
