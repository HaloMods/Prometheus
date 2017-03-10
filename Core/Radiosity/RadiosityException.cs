using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Radiosity
{
  public enum RadiosityLocation
  {
    NotSet, Begin, ProcessModelCollision, ProcessBSPCollision, Reinhardt
  }
  public class RadiosityException : Exception
  {
    private const string DefaultMessage = "An exception occurred during radiosity.";
    private const string LocationMessage = "During radiosity, an error occurred at the following location: ";
    private RadiosityLocation radiosityLocation = RadiosityLocation.NotSet;
    public RadiosityLocation RadiosityLocation { get { return radiosityLocation; } }
    public RadiosityException()
      : this(RadiosityLocation.NotSet)
    {
    }
    public RadiosityException(RadiosityLocation location)
      : this(location != RadiosityLocation.NotSet ? LocationMessage + Enum.GetName(typeof(RadiosityLocation), location) : DefaultMessage, location) 
    {
    }
    public RadiosityException(string message) : base(message)
    {
    }
    public RadiosityException(string message, Exception innerException)
      : base(message, innerException)
    {
    }
    public RadiosityException(string message, RadiosityLocation location)
      : base(message)
    {
      radiosityLocation = location;
    }
  }
}
