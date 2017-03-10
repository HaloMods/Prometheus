using System;
using System.CodeDom;

namespace Interfaces.Factory
{
  /// <summary>
  /// Provides the class factory with global, generic code generation methods.
  /// </summary>
  public static class GlobalMethods
  {
    public static CodeMemberProperty GeneratePublicAccessors(string type, string name, Accessors accessors)
    {
      string publicName = MakePublicName(name);
      name = MakePrivateName(name);

      CodeMemberProperty accessor = new CodeMemberProperty();
      accessor.Name = publicName;
      accessor.Type = new CodeTypeReference(type);
      accessor.Attributes = MemberAttributes.Public | MemberAttributes.Final;
      accessor.HasGet = false;
      accessor.HasSet = false;

      if ((accessors == Accessors.Get) || (accessors == Accessors.Both))
      {
        accessor.HasGet = true;
        accessor.GetStatements.Add(new CodeMethodReturnStatement(
          new CodeFieldReferenceExpression(
          new CodeThisReferenceExpression(), name)));
      }
      if ((accessors == Accessors.Set) || (accessors == Accessors.Both))
      {
        accessor.HasSet = true;
        accessor.SetStatements.Add(new CodeAssignStatement(
          new CodeFieldReferenceExpression(
          new CodeThisReferenceExpression(), name),
          new CodePropertySetValueReferenceExpression()));
      }
      return accessor;
    }

    public static CodeMemberField GeneratePrivateMember(string type, string name, string initialization)
    {
      string privateName = MakePrivateName(name);
      name = name.Replace(" ", "");
      CodeMemberField member = new CodeMemberField(type, privateName);
      if (initialization != null)
        member.InitExpression = new CodeObjectCreateExpression(type, new CodeExpression[] { });
      return member;
    }

    public static CodeMemberField GeneratePrivateMember(string type, string name)
    {
      return GeneratePrivateMember(type, name, null);
    }

    public static float DegreesToRadians(float angle)
    {
      if (angle == 0.0f)
        return 0.0f;

      double radians = (Math.PI / 180.0) * (double)angle;
      return (float)radians;
    }

    public static float RadiansToDegrees(float radian)
    {
      if (radian == 0.0f)
        return 0.0f;

      double degrees = (180.0 / Math.PI) * (double)radian;
      return (float)degrees;
    }

    public static string MakePublicName(string name)
    {
      if (String.IsNullOrEmpty(name))
        name = "__empty_name";
      name = name.Trim();
      string[] parts = name.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
      string result = "";
      for (int x = 0; x < parts.Length; x++)
      {
        result += parts[x].Substring(0, 1).ToUpper() + parts[x].Substring(1);
      }

      if (result.IndexOf('_') != -1)
        result = result.Replace("_", "");

      if (result.IndexOf('.') != -1)
        result = result.Replace(".", "_Pt");

      if (result.IndexOf('+') != -1)
        result = result.Replace("+", "_Plus");

      if (result.IndexOf('-') != -1)
        result = result.Replace("-", "_Minus");

      if (result.IndexOf('\"') != -1)
        result = result.Replace("\"", "");

      char[] numeric = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };
      for (int i = 0; i < 10; i++)
        if (result[0] == numeric[i])
          result = "_" + result;

      result = result.Replace(" ", "");

      return result;
    }

    public static string MakePrivateName(string name)
    {
      string result = MakePublicName(name);
      return "_" + result.Substring(0, 1).ToLower() + result.Substring(1);
    }
  }
}
