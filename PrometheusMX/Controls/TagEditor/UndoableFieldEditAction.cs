using System;
using System.Collections.Generic;
using System.Text;
using Interfaces.UserInterface;
using Interfaces.Factory;
using System.Reflection;

namespace Prometheus.Controls.TagEditor
{
  public class UndoableFieldEditAction : IUndoableAction
  {
    IField field;
    string propertyName;
    object oldValue;
    object newValue;

    bool cleanPoint = false;
    public bool CleanPoint
    {
      get { return cleanPoint; }
      set { cleanPoint = value; }
    }

    public UndoableFieldEditAction(IField field, string propertyName, object oldValue, object newValue)
    {
      this.field = field;
      this.propertyName = propertyName;
      this.oldValue = oldValue;
      this.newValue = newValue;
    }

    private void SetPropertyValue(object value)
    {
      Type fieldType = field.GetType();
      PropertyInfo pi = fieldType.GetProperty(propertyName);
      MethodInfo mi = pi.GetSetMethod();
      mi.Invoke(field, new object[1] { value });
    }

    public void Undo()
    {
      SetPropertyValue(oldValue);
    }

    public void Redo()
    {
      SetPropertyValue(newValue);
    }
  }
}