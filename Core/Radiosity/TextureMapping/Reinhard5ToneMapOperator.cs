using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace Core.Radiosity.TextureMapping
{
  class Reinhard5ToneMapOperator : Interfaces.Rendering.Interfaces.IToneMapOperator
  {
    #region IToneMapOperator Members

    public Bitmap CreateImage(double[, ,] HDRi, params object[] optionalsettings)
    {
      return null;
    }

    #endregion
  }
}
