using System;
using System.Collections.Generic;
using System.Reflection;

namespace Prometheus.Testing
{
  /// <summary>
  /// Controls access to instances of all ITest objects in the assembly.
  /// </summary>
  public class TestController
  {
    private List<TestInfo> tests = new List<TestInfo>();

    /// <summary>
    /// Returns a list of all registered tests.
    /// </summary>
    public List<TestInfo> Tests
    {
      get { return tests; }
    }

    /// <summary>
    /// Creates a new instance of the TestContoller class.
    /// </summary>
    public TestController()
    {
      Assembly assembly = Assembly.GetAssembly(typeof(ITest));

      // Add a type reference for all classes in the assembly that inherit
      // from ITest to the list.
      foreach (Type t in assembly.GetTypes())
      {
        if (t.IsClass)
        {
          Type[] interfaces = t.GetInterfaces();
          foreach (Type i in interfaces)
          {
            if (i == typeof(ITest))
            {
              // This is an ITest-derived class - get it's attributes.
              object[] attributes = t.GetCustomAttributes(typeof(TestInfoAttribute), false);
              foreach (TestInfoAttribute infoAttribute in attributes)
              {
                TestInfo info = new TestInfo(t, infoAttribute);
                tests.Add(info);
              }
            }
          }
        }
      }
    }

    /// <summary>
    /// Performs the test with the specified name.
    /// </summary>
    public void PerformTest(string developerName, string name)
    {
      foreach (TestInfo info in tests)
      {
        if ((info.Info.DeveloperName == developerName) && (info.Info.Name == name))
        {
          ITest test = info.CreateInstance();
          test.PerformTest();
        }
      }
    }
  }
  
  /// <summary>
  /// Encapsulates an ITest type and it's descriptors.
  /// </summary>
  public class TestInfo
  {
    private Type testType;
    private TestInfoAttribute info;

    /// <summary>
    /// The test's Type.
    /// </summary>
    public Type TestType
    {
      get { return testType; }
    }

    /// <summary>
    /// The test's attributes.
    /// </summary>
    public TestInfoAttribute Info
    {
      get { return info; }
    }
    
    /// <summary>
    /// Creates a new instance of the class.
    /// </summary>
    public TestInfo(Type testType, TestInfoAttribute info)
    {
      this.testType = testType;
      this.info = info;
    }
    
    /// <summary>
    /// Creates an instance of the ITest-derived type contained in TestType.
    /// </summary>
    public ITest CreateInstance()
    {
      ITest test = (ITest)Activator.CreateInstance(testType);
      return test;
    }
  }
}
