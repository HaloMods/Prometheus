/* Credits: Chad Finsterwald - http://www.wtfdeveloper.com/Default5.aspx */
using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;

namespace Prometheus.ThirdParty.Helpers
{
  /// <summary>
  /// Helper functions for String not already found in C#.
  /// Inspired by PHP String Functions that are missing in .Net.
  /// </summary>
  public static class Strings
  {
    /// <summary>
    /// Base64 encodes a string.
    /// </summary>
    /// <param name="input">A string</param>
    /// <returns>A base64 encoded string</returns>
    public static string Base64StringEncode(string input)
    {
      byte[] encbuff = Encoding.UTF8.GetBytes(input);
      return Convert.ToBase64String(encbuff);
    }

    /// <summary>
    /// Base64 decodes a string.
    /// </summary>
    /// <param name="input">A base64 encoded string</param>
    /// <returns>A decoded string</returns>
    public static string Base64StringDecode(string input)
    {
      byte[] decbuff = Convert.FromBase64String(input);
      return Encoding.UTF8.GetString(decbuff);
    }

    /// <summary>
    /// A case insenstive replace function.
    /// </summary>
    /// <param name="input">The string to examine.</param>
    /// <param name="newValue">The value to replace.</param>
    /// <param name="oldValue">The new value to be inserted</param>
    /// <returns>A string</returns>
    public static string CaseInsenstiveReplace(string input, string newValue, string oldValue)
    {
      Regex regEx = new Regex(oldValue, RegexOptions.IgnoreCase | RegexOptions.Multiline);
      return regEx.Replace(input, newValue);
    }

    /// <summary>
    /// Removes all the words passed in the filter words parameters. The replace is NOT case
    /// sensitive.
    /// </summary>
    /// <param name="input">The string to search.</param>
    /// <param name="filterWords">The words to repace in the input string.</param>
    /// <returns>A string.</returns>
    public static string FilterWords(string input, params string[] filterWords)
    {
      return FilterWords(input, char.MinValue, filterWords);
    }

    /// <summary>
    /// Removes all the words passed in the filter words parameters. The replace is NOT case
    /// sensitive.
    /// </summary>
    /// <param name="input">The string to search.</param>
    /// <param name="mask">A character that is inserted for each letter of the replaced word.</param>
    /// <param name="filterWords">The words to repace in the input string.</param>
    /// <returns>A string.</returns>
    public static string FilterWords(string input, char mask, params string[] filterWords)
    {
      string stringMask = mask == char.MinValue ? string.Empty : mask.ToString();
      string totalMask = stringMask;

      foreach (string s in filterWords)
      {
        Regex regEx = new Regex(s, RegexOptions.IgnoreCase | RegexOptions.Multiline);

        if (stringMask.Length > 0)
        {
          for (int i = 1; i < s.Length; i++)
            totalMask += stringMask;
        }

        input = regEx.Replace(input, totalMask);

        totalMask = stringMask;
      }

      return input;
    }

    /// <summary>
    /// Checks the passed string to see if has any of the passed words. Not case-sensitive.
    /// </summary>
    /// <param name="input">The string to check.</param>
    /// <param name="hasWords">The words to check for.</param>
    /// <returns>A collection of the matched words.</returns>
    public static MatchCollection HasWords(string input, params string[] hasWords)
    {
      StringBuilder sb = new StringBuilder(hasWords.Length + 50);
      //sb.Append("[");

      foreach (string s in hasWords)
      {
        sb.AppendFormat("({0})|", HtmlSpecialEntitiesEncode(s.Trim()));
      }

      string pattern = sb.ToString();
      pattern = pattern.TrimEnd('|'); // +"]";

      Regex regEx = new Regex(pattern, RegexOptions.IgnoreCase | RegexOptions.Multiline);
      return regEx.Matches(input);
    }

    /// <summary>
    /// A wrapper around HttpUtility.HtmlEncode
    /// </summary>
    /// <param name="input">The string to be encoded</param>
    /// <returns>An encoded string</returns>
    public static string HtmlSpecialEntitiesEncode(string input)
    {
      throw new Exception("Not Implemented");
      //return HttpUtility.HtmlEncode(input);
    }

    /// <summary>
    /// A wrapper around HttpUtility.HtmlDecode
    /// </summary>
    /// <param name="input">The string to be decoded</param>
    /// <returns>The decode string</returns>
    public static string HtmlSpecialEntitiesDecode(string input)
    {
      throw new Exception("Not Implemented");
      //return HttpUtility.HtmlDecode(input);
    }

    /// <summary>
    /// MD5 encodes the passed string
    /// </summary>
    /// <param name="input">The string to encode.</param>
    /// <returns>An encoded string.</returns>
    public static string MD5String(string input)
    {
      // Create a new instance of the MD5CryptoServiceProvider object.
      MD5 md5Hasher = MD5.Create();

      // Convert the input string to a byte array and compute the hash.
      byte[] data = md5Hasher.ComputeHash(Encoding.Default.GetBytes(input));

      // Create a new Stringbuilder to collect the bytes
      // and create a string.
      StringBuilder sBuilder = new StringBuilder();

      // Loop through each byte of the hashed data 
      // and format each one as a hexadecimal string.
      for (int i = 0; i < data.Length; i++)
      {
        sBuilder.Append(data[i].ToString("x2"));
      }

      // Return the hexadecimal string.
      return sBuilder.ToString();
    }

    /// <summary>
    /// Verified a string against the passed MD5 hash.
    /// </summary>
    /// <param name="input">The string to compare.</param>
    /// <param name="hash">The hash to compare against.</param>
    /// <returns>True if the input and the hash are the same, false otherwise.</returns>
    public static bool MD5VerifyString(string input, string hash)
    {
      // Hash the input.
      string hashOfInput = MD5String(input);

      // Create a StringComparer an comare the hashes.
      StringComparer comparer = StringComparer.OrdinalIgnoreCase;

      if (0 == comparer.Compare(hashOfInput, hash))
      {
        return true;
      }
      else
      {
        return false;
      }
    }

    /// <summary>
    /// Left pads the passed input using the HTML non-breaking string entity (&nbsp;)
    /// for the total number of spaces.
    /// </summary>
    /// <param name="input">The string to pad.</param>
    /// <param name="totalSpaces">The total number to pad the string.</param>
    /// <returns>A padded string.</returns>
    public static string PadLeftHtmlSpaces(string input, int totalSpaces)
    {
      string space = "&nbsp;";
      return PadLeft(input, space, totalSpaces * space.Length);
    }

    /// <summary>
    /// Left pads the passed input using the passed pad string
    /// for the total number of spaces.  It will not cut-off the pad even if it 
    /// causes the string to exceed the total width.
    /// </summary>
    /// <param name="input">The string to pad.</param>
    /// <param name="pad">The string to uses as padding.</param>
    /// <param name="totalWidth">The total number to pad the string.</param>
    /// <returns>A padded string.</returns>
    public static string PadLeft(string input, string pad, int totalWidth)
    {
      return PadLeft(input, pad, totalWidth, false);
    }

    /// <summary>
    /// Left pads the passed input using the passed pad string
    /// for the total number of spaces.  It will cut-off the pad so that  
    /// the string does not exceed the total width.
    /// </summary>
    /// <param name="input">The string to pad.</param>
    /// <param name="pad">The string to uses as padding.</param>
    /// <param name="totalWidth">The total number to pad the string.</param>
    /// <param name="cutOff">Determine if word is cut or wait until whitespace.</param>
    /// <returns>A padded string.</returns>
    public static string PadLeft(string input, string pad, int totalWidth, bool cutOff)
    {
      if (input.Length >= totalWidth)
        return input;

      int padCount = pad.Length;
      string paddedString = input;

      while (paddedString.Length < totalWidth)
      {
        paddedString += pad;
      }

      // trim the excess.
      if (cutOff)
        paddedString = paddedString.Substring(0, totalWidth);

      return paddedString;
    }

    /// <summary>
    /// Right pads the passed input using the HTML non-breaking string entity (&nbsp;)
    /// for the total number of spaces.
    /// </summary>
    /// <param name="input">The string to pad.</param>
    /// <param name="totalSpaces">The total number to pad the string.</param>
    /// <returns>A padded string.</returns>
    public static string PadRightHtmlSpaces(string input, int totalSpaces)
    {
      string space = "&nbsp;";
      return PadRight(input, space, totalSpaces * space.Length);
    }

    /// <summary>
    /// Right pads the passed input using the passed pad string
    /// for the total number of spaces.  It will not cut-off the pad even if it 
    /// causes the string to exceed the total width.
    /// </summary>
    /// <param name="input">The string to pad.</param>
    /// <param name="pad">The string to uses as padding.</param>
    /// <param name="totalWidth">The total number to pad the string.</param>
    /// <returns>A padded string.</returns>
    public static string PadRight(string input, string pad, int totalWidth)
    {
      return PadRight(input, pad, totalWidth, false);
    }

    /// <summary>
    /// Right pads the passed input using the passed pad string
    /// for the total number of spaces.  It will cut-off the pad so that  
    /// the string does not exceed the total width.
    /// </summary>
    /// <param name="input">The string to pad.</param>
    /// <param name="pad">The string to uses as padding.</param>
    /// <param name="totalWidth">The total number to pad the string.</param>
    /// <param name="cutOff">Determine if word is cut or wait until whitespace.</param>
    /// <returns>A padded string.</returns>
    public static string PadRight(string input, string pad, int totalWidth, bool cutOff)
    {
      if (input.Length >= totalWidth)
        return input;

      string paddedString = string.Empty;

      while (paddedString.Length < totalWidth - input.Length)
      {
        paddedString += pad;
      }

      // trim the excess.
      if (cutOff)
        paddedString = paddedString.Substring(0, totalWidth - input.Length);

      paddedString += input;

      return paddedString;
    }

    /// <summary>
    /// Removes the new line (\n) and carriage return (\r) symbols.
    /// </summary>
    /// <param name="input">The string to search.</param>
    /// <returns>A string</returns>
    public static string RemoveNewLines(string input)
    {
      return RemoveNewLines(input, false);
    }

    /// <summary>
    /// Removes the new line (\n) and carriage return (\r) symbols.
    /// </summary>
    /// <param name="input">The string to search.</param>
    /// <param name="addSpace">If true, adds a space (" ") for each newline and carriage
    /// return found.</param>
    /// <returns>A string</returns>
    public static string RemoveNewLines(string input, bool addSpace)
    {
      string replace = string.Empty;
      if (addSpace)
        replace = " ";

      string pattern = @"[\r|\n]";
      Regex regEx = new Regex(pattern, RegexOptions.IgnoreCase | RegexOptions.Multiline);

      return regEx.Replace(input, replace);
    }

    /// <summary>
    /// Reverse a string.
    /// </summary>
    /// <param name="input">The string to reverse</param>
    /// <returns>A string</returns>
    public static string Reverse(string input)
    {
      if (input.Length <= 1)
        return input;

      char[] c = input.ToCharArray();
      StringBuilder sb = new StringBuilder(c.Length);
      for (int i = c.Length - 1; i > -1; i--)
        sb.Append(c[i]);

      return sb.ToString();
    }

    /// <summary>
    /// Converts a string to sentence case.
    /// </summary>
    /// <param name="input">The string to convert.</param>
    /// <returns>A string</returns>
    public static string SentenceCase(string input)
    {
      if (input.Length < 1)
        return input;

      string sentence = input.ToLower();
      return sentence[0].ToString().ToUpper() + sentence.Substring(1);
    }

    /// <summary>
    /// Converts all spaces to HTML non-breaking spaces
    /// </summary>
    /// <param name="input">The string to convert.</param>
    /// <returns>A string</returns>
    public static string SpaceToNbsp(string input)
    {
      string space = "&nbsp;";
      return input.Replace(" ", space);
    }

    /// <summary>
    /// Removes all HTML tags from the passed string
    /// </summary>
    /// <param name="input">The string whose values should be replaced.</param>
    /// <returns>A string.</returns>
    public static string StripTags(string input)
    {
      Regex stripTags = new Regex("<(.|\n)+?>");
      return stripTags.Replace(input, "");
    }

    /// <summary>
    /// Converts a string to title case.
    /// </summary>
    /// <param name="input">The string to convert.</param>
    /// <returns>A string.</returns>
    public static string TitleCase(string input)
    {
      return TitleCase(input, true);
    }

    /// <summary>
    /// Converts a string to title case.
    /// </summary>
    /// <param name="input">The string to convert.</param>
    /// <param name="ignoreShortWords">If true, does not capitalize words like
    /// "a", "is", "the", etc.</param>
    /// <returns>A string.</returns>
    public static string TitleCase(string input, bool ignoreShortWords)
    {
      List<string> ignoreWords = null;
      if (ignoreShortWords)
      {
        //TODO: Add more ignore words?
        ignoreWords = new List<string>();
        ignoreWords.Add("a");
        ignoreWords.Add("an");
        ignoreWords.Add("by");
        ignoreWords.Add("is");
        ignoreWords.Add("was");
        ignoreWords.Add("the");
        ignoreWords.Add("of");
        ignoreWords.Add("for");
        ignoreWords.Add("to");
      }

      string[] tokens = input.Split(' ');
      StringBuilder sb = new StringBuilder(input.Length);
      if (!tokens[0].Equals(String.Empty))
      {
        foreach (string s in tokens)
        {
          if (ignoreShortWords
              && s != tokens[0]
              && ignoreWords.Contains(s.ToLower()))
          {
            sb.Append(s.ToLower() + " ");
          }
          else
          {
            sb.Append(s[0].ToString().ToUpper());
            sb.Append(s.Substring(1).ToLower());
            sb.Append(" ");
          }
        }
      }

      return sb.ToString().Trim();
    }

    /// <summary>
    /// Removes multiple spaces between words
    /// </summary>
    /// <param name="input">The string to trim.</param>
    /// <returns>A string.</returns>
    public static string TrimIntraWords(string input)
    {
      Regex regEx = new Regex(@"[\s]+");
      return regEx.Replace(input, " ");
    }

    /// <summary>
    /// Converts new line(\n) and carriage return(\r) symbols to
    /// HTML line breaks.
    /// </summary>
    /// <param name="input">The string to convert.</param>
    /// <returns>A string.</returns>
    public static string NewLineToBreak(string input)
    {
      Regex regEx = new Regex(@"[\n|\r]+");
      return regEx.Replace(input, "<br />");
    }

    /// <summary>
    /// Wraps the passed string up the 
    /// until the next whitespace on or after the total charCount has been reached
    /// for that line.  Uses the environment new line
    /// symbol for the break text.
    /// </summary>
    /// <param name="input">The string to wrap.</param>
    /// <param name="charCount">The number of characters per line.</param>
    /// <returns>A string.</returns>
    public static string WordWrap(string input, int charCount)
    {
      return WordWrap(input, charCount, false, Environment.NewLine);
    }

    /// <summary>
    /// Wraps the passed string up the total number of characters (if cuttOff is true)
    /// or until the next whitespace (if cutOff is false).  Uses the environment new line
    /// symbol for the break text.
    /// </summary>
    /// <param name="input">The string to wrap.</param>
    /// <param name="charCount">The number of characters per line.</param>
    /// <param name="cutOff">If true, will break in the middle of a word.</param>
    /// <returns>A string.</returns>
    public static string WordWrap(string input, int charCount, bool cutOff)
    {
      return WordWrap(input, charCount, cutOff, Environment.NewLine);
    }

    /// <summary>
    /// Wraps the passed string up the total number of characters (if cuttOff is true)
    /// or until the next whitespace (if cutOff is false).  Uses the passed breakText
    /// for lineBreaks.
    /// </summary>
    /// <param name="input">The string to wrap.</param>
    /// <param name="charCount">The number of characters per line.</param>
    /// <param name="cutOff">If true, will break in the middle of a word.</param>
    /// <param name="breakText">The line break text to use.</param>
    /// <returns>A string.</returns>
    public static string WordWrap(string input, int charCount, bool cutOff,
        string breakText)
    {
      StringBuilder sb = new StringBuilder(input.Length + 100);
      int counter = 0;

      if (cutOff)
      {
        while (counter < input.Length)
        {
          if (input.Length > counter + charCount)
          {
            sb.Append(input.Substring(counter, charCount));
            sb.Append(breakText);
          }
          else
          {
            sb.Append(input.Substring(counter));
          }
          counter += charCount;
        }
      }
      else
      {
        string[] strings = input.Split(' ');
        for (int i = 0; i < strings.Length; i++)
        {
          counter += strings[i].Length + 1; // the added one is to represent the inclusion of the space.
          if (i != 0 && counter > charCount)
          {
            sb.Append(breakText);
            counter = 0;
          }

          sb.Append(strings[i] + ' ');
        }
      }
      return sb.ToString().TrimEnd(); // to get rid of the extra space at the end.
    }

    public static string AlphanumericalOnly(string input)
    {
      return AlphanumericalOnlyWithSpaces(input).Replace(" ", "");
    }

    public static string AlphanumericalOnlyWithSpaces(string input)
    {
      return Regex.Replace(input, "[^0-9 a-z]", "", RegexOptions.IgnoreCase);
    }
  }
}
