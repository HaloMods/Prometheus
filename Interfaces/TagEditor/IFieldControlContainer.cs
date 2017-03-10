using System;
using System.IO;
using System.Windows.Forms;
using System.Xml;
using Interfaces.Factory;

namespace Interfaces.TagEditor
{
  /// <summary>
  /// Represents an object that contains FieldControl objects.
  /// </summary>
  public interface IFieldControlContainer
  {
    IFieldControl[] GetChildFields(int levels);
    IFieldControl[] GetChildFields();
    void AddField(IFieldControl field);
    void AddFieldContainer(IFieldControlContainer controlContainer);
  }
}