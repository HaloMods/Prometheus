using System.Windows.Forms;
using System.Xml;
using Interfaces.Factory;

namespace Interfaces.TagEditor
{
  public interface IBoundPropertyCapable
  {
    string BoundPropertyName { get; set;}
  }
  /// <summary>
  /// Represents a FieldControl.
  /// </summary>
  public interface IFieldControl : IBoundPropertyCapable
  {
    //string BoundPropertyName { get; set; }
    string Title { get; set; }
    bool BindSupported(IField field);
    void DataBind(IField field);
    Binding[] GetDataBindings();
    Binding[] GetDataBindings(Control control);
    void Configure(XmlNode valueNode);
  }
}