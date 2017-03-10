using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace Interfaces.Rendering.Interfaces
{
    /// <summary>
    /// Interface for tonemap operators. Impelmentations
    /// of this interface should map continuous values to
    /// descrete values.
    /// </summary>
    public interface IToneMapOperator
    {
        /// <summary>
        /// Converts an HDR image to a descrete image.
        /// </summary>
        /// <param name="HDRi">HDR image input.</param>
        /// <param name="optionalsettings">Settings for operator.</param>
        /// <returns>Filtered image.</returns>
        Bitmap CreateImage(double[, ,] HDRi, params object[] optionalsettings);
    }
}
