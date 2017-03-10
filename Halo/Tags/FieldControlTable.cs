using System;
using System.Collections.Generic;
using Games.Halo.Controls;

namespace Games.Halo.Platforms.PC
{
  /// <summary>
  /// Represents a list of field controls and their Type.
  /// This is a singleton class.
  /// </summary>
  public class HaloFieldControlTable : Dictionary<string, Type>
  {
    private static HaloFieldControlTable instance;
    public static HaloFieldControlTable Instance
    {
      get
      {
        if (instance == null) instance = new HaloFieldControlTable();
        return instance;
      }
    }
    
    /// <summary>
    /// Initializes the field control table with all of the types for this platform.
    /// </summary>
    protected HaloFieldControlTable()
    {
      // TODO: Add all of the types to the list.
      Add("Angle", typeof(Angle)); // 2nd Pass Complete - Nick
      //angle bounds
      Add("ARGBColor", typeof(ARGBColor)); // 2nd Pass Complete (No 2-way databinding yet) - Nick
      Add("Block", typeof(Block)); // 1st Pass Complete - Nick
      Add("CharInteger", typeof(CharInteger)); // 2nd Pass Complete - Nick
      //data?
      Add("Enum", typeof(Games.Halo.Controls.Enum)); // 2nd Pass Complete (sort of ... enum is messy) - Nick
      Add("Flags", typeof(Flags)); //
      Add("FixedLengthString", typeof(FixedLengthString)); //
      Add("LongBlockIndex", typeof(LongBlockIndex));
      Add("LongInteger", typeof(LongInteger)); // 1st Pass Complete - Nick
      //pad
      Add("Point2D", typeof(Point2D)); // 1st Pass Complete - Nick
      Add("Real", typeof(Real)); // 2nd Pass Complete - Nick
      Add("RealARGBColor", typeof(RealARGBColor)); // 2nd Pass Complete - Nick
      Add("RealBounds", typeof(RealBounds)); //
      Add("RealEulerAngles2D", typeof(RealEulerAngles2D)); //
      Add("RealEulerAngles3D", typeof(RealEulerAngles3D)); // 1st Pass Complete - Nick
      Add("RealFraction", typeof(RealFraction));
      Add("RealFractionBounds", typeof(RealFractionBounds));
      Add("RealPlane2D", typeof(RealPlane2D)); //
      Add("RealPlane3D", typeof(RealPlane3D)); //
      Add("RealPoint2D", typeof(RealPoint2D)); // 1st Pass Complete - Nick
      Add("RealPoint3D", typeof(RealPoint3D)); // 1st Pass Complete - Nick
      Add("RealQuaternion", typeof(RealQuaternion)); //
      Add("RealRGBColor", typeof(RealRGBColor)); //
      Add("RealVector2D", typeof(RealVector2D)); //
      Add("RealVector3D", typeof(RealVector3D)); //
      Add("Rectangle2D", typeof(Rectangle2D)); //
      Add("RGBColor", typeof(RGBColor)); //
      Add("ShortBlockIndex", typeof(ShortBlockIndex));
      Add("ShortBounds", typeof(ShortBounds)); // 1st Pass Complete - Nick
      Add("ShortInteger", typeof(ShortInteger)); // 2nd Pass Complete - Nick
      //skip
      Add("TagReference", typeof(TagReference)); // 1st Pass Complete - Nick
      //tag signature
      //var length string
    }
  }
}