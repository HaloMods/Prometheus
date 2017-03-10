using System;
using System.Collections.Generic;
using System.Text;
using DevComponents.DotNetBar;
using DevComponents.DotNetBar.Controls;
using System.Drawing;
using System.Windows.Forms;

namespace Interfaces.Helpers
{
  public static class Strings
  {
    #region Color Numeric Labels / TextBoxes / String

    private static bool numericLabelItemUpdating;
    /// <summary>
    /// Change the color of the LabelItem to red if it contains a negative sign ("-") or to blue if it does not.
    /// 
    /// The negative sign will be removed if present.
    /// </summary>
    /// <param name="labelItem">The LabelItem to be updated.</param>
    public static void ColorizeNumericLabelItem(LabelItem labelItem)
    {
      if (numericLabelItemUpdating)
        return;

      if (labelItem.Text == null)
        return;

      if (labelItem.Text[0] == '-')
      {
        numericLabelItemUpdating = true; // Prevents endless loop caused in some situations by the next line.
        labelItem.Text = labelItem.Text.Remove(0, 1);
        labelItem.ForeColor = Color.Red;
      }
      else
        labelItem.ForeColor = Color.Blue;

      numericLabelItemUpdating = false;
    }

    private static bool numericLabelUpdating;
    /// <summary>
    /// Change the color of the Label to red if it contains a negative sign ("-") or to blue if it does not.
    /// 
    /// The negative sign will be removed if present.
    /// </summary>
    /// <param name="labelItem">The Label to be updated.</param>
    public static void ColorizeNumericLabel(Label label)
    {
      if (numericLabelUpdating)
        return;

      if (label.Text == null)
        return;

      if (label.Text[0] == '-')
      {
        numericLabelUpdating = true; // Prevents endless loop caused in some situations by the next line.
        label.Text = label.Text.Remove(0, 1);
        label.ForeColor = Color.Red;
      }
      else
        label.ForeColor = Color.Blue;

      numericLabelUpdating = false;
    }

    /// <summary>
    /// Change the color of the TextBoxX text to red if it contains a negative sign ("-") or to blue if it does not.
    /// 
    /// The negative sign will not be removed.
    /// </summary>
    /// <param name="labelItem">The TextBoxX to be updated.</param>
    public static void ColorizeNumericTextBoxX(TextBoxX textBoxX)
    {
      if (String.IsNullOrEmpty(textBoxX.Text))
        return;

      if (textBoxX.Text[0] == '-')
        textBoxX.ForeColor = Color.Red;
      else
        textBoxX.ForeColor = Color.DarkBlue;
    }

    /// <summary>
    /// Create a string with markup colorizing it red if it contains a negative sign ('-') or blue if it does not.
    /// </summary>
    /// <param name="input">The string to be evaluated and updated.</param>
    /// <param name="darkColors">true to use dark variants of red and blue; false to use plain red and blue.</param>
    /// <returns>Colorized (by means of markup) string.</returns>
    public static string CreateColorizedNumericString(string input, bool darkColors)
    {
      if (String.IsNullOrEmpty(input))
        return String.Empty;

      if (input[0] == '-')
        return (darkColors ? "<font color=\"darkred\">" : "<font color=\"red\">") + input + "</font>";
      else
        return (darkColors ? "<font color=\"darkblue\">" : "<font color=\"blue\">") + input + "</font>";
    }

    public static string CreateColorizedNumericString(string input) { return CreateColorizedNumericString(input, false); }
    public static string CreateColorizedNumericString(int input) { return CreateColorizedNumericString(input.ToString(), false); }
    public static string CreateColorizedNumericString(int input, bool darkColors) { return CreateColorizedNumericString(input.ToString(), darkColors); }
    public static string CreateColorizedNumericString(long input) { return CreateColorizedNumericString(input.ToString(), false); }
    public static string CreateColorizedNumericString(long input, bool darkColors) { return CreateColorizedNumericString(input.ToString(), darkColors); }
    public static string CreateColorizedNumericString(float input) { return CreateColorizedNumericString(input.ToString(), false); }
    public static string CreateColorizedNumericString(float input, bool darkColors) { return CreateColorizedNumericString(input.ToString(), darkColors); }
    public static string CreateColorizedNumericString(double input) { return CreateColorizedNumericString(input.ToString(), false); }
    public static string CreateColorizedNumericString(double input, bool darkColors) { return CreateColorizedNumericString(input.ToString(), darkColors); }

    #endregion

    #region Data Parsers

    public static string ComputeReadableTime(float seconds)
    {
      TimeSpan time = TimeSpan.FromSeconds(seconds);

      return ((time.Days > 0) ? time.Days + "d " : String.Empty) +
             ((time.Hours > 0) ? time.Hours + "h " : String.Empty) +
             ((time.Minutes > 0) ? time.Minutes + "m " : String.Empty) +
             time.Seconds + "s";
    }

    #endregion
  }
}
