using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Interfaces.Rendering.Interfaces
{
  public interface IRealColor
  {
    float R { get; set; }
    float G { get; set; }
    float B { get; set; }
    float A { get; set; }
  }
}
