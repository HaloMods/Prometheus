using System.Windows.Forms;
using Interfaces.Factory;
using Interfaces.TagEditor;
using Interfaces.Helpers;

namespace Games.Halo.Controls
{
  public partial class RealVector3D : FieldControl
  {
    private Tags.Fields.RealVector3D value
    {
      get { return (Tags.Fields.RealVector3D)BaseValue; }
    }

    public RealVector3D()
    {
      InitializeComponent();
    }
   
    public override void DataBind(IField value)
    {
      base.DataBind(value);
      
      txtIValue.DataBindings.Clear();
      txtJValue.DataBindings.Clear();
      txtKValue.DataBindings.Clear();

      txtIValue.DataBindings.Add(new Binding("Text", this.value, "I"));
      txtJValue.DataBindings.Add(new Binding("Text", this.value, "J"));
      txtKValue.DataBindings.Add(new Binding("Text", this.value, "K"));
    }

    public override string ToString(bool withMarkup, bool originalValue)
    {
      Tags.Fields.RealVector3D oldValue = (Tags.Fields.RealVector3D)Tag;

      if (oldValue == null)
        oldValue = value;

      if (withMarkup)
      {
        return "<span width=\"13\"><b>I:</b></span>" + Strings.CreateColorizedNumericString((originalValue ? oldValue.I : value.I), true) + "<br />" +
               "<span width=\"13\"><b>J:</b></span>" + Strings.CreateColorizedNumericString((originalValue ? oldValue.J : value.J), true) + "<br />" +
               "<span width=\"13\"><b>K:</b></span>" + Strings.CreateColorizedNumericString((originalValue ? oldValue.K : value.K), true);
      }
      else
      {
        return "I: " + (originalValue ? oldValue.I.ToString() : value.I.ToString()) + "\n" +
               "J: " + (originalValue ? oldValue.J.ToString() : value.J.ToString()) + "\n" +
               "K: " + (originalValue ? oldValue.K.ToString() : value.K.ToString());
      }
    }
  }
}