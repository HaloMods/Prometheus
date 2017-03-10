using System;
using System.Drawing;
using System.IO;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;
using System.Xml;
using Interfaces;
using Interfaces.Settings;
using Prometheus.Dialogs;
using Interfaces.Libraries;
using Prometheus.Controls;

namespace Prometheus.Testing
{
  [TestInfo("MonoxideC", "UI Thread Test", "Mmmmmmm hmmmm!")]
  public class FakeTest : ITest
  {
    public class TestClass
    {
      public string Test;
    }
    Panel p;
    Form existingForm;
    Form f;
    public void PerformTest()
    {
      existingForm = new Form();
      Button btn = new Button();
      btn.Text = "Show Form";
      btn.Click += btn_Click;
      existingForm.Controls.Add(btn);
      existingForm.Show();

      f = new Form();
      f.Size = new Size(200, 200);
      p = new Panel();
      p.Size = new Size(100, 200);
      p.Location = new Point(1, 1);
      f.Controls.Add(p);
      
      //CreateControl(new Point(10, 10));
      Thread thread = new Thread(threadStart);
      thread.Start();
    }

    void btn_Click(object sender, EventArgs e)
    {
      f.Visible = !f.Visible;
    }
    private void threadStart()
    {
      for (int x = 0; x < 50; x++)
      {
        CreateControl(new Point(x*2, x*2));
        Thread.Sleep(200);
      }
    }
    private void CreateControl(Point location)
    {
      TextBox txt = new TextBox();
      txt.Location = location;
      existingForm.Invoke((MethodInvoker)delegate { p.Controls.Add(txt); });
      txt.TextChanged += txt_TextChanged;
    }

    void txt_TextChanged(object sender, EventArgs e)
    {
      ((TextBox) sender).Text = ((TextBox) sender).Text.ToUpper();
      Output.Write(OutputTypes.Debug, ((TextBox) sender).Text);
    }
  }

  [TestInfo("MonoxideC", "Recycle Bin Explorer Test", "")]
  public class RecycleBinExplorerTest : ITest
  {
    public void PerformTest()
    {
      RecycleBin bin = Core.Prometheus.Instance.ProjectManager.Project.RecycleBin;
      RecycleBinBrowser browser = new RecycleBinBrowser();
      browser.Dock = DockStyle.Fill;
      browser.Initialize(bin);
      
      Form f = new Form();
      f.Size = new Size(640, 480);
      f.Controls.Add(browser);

      f.ShowDialog();
    }
  }

  [TestInfo("MonoxideC", "Regex Test", "")]
  public class RegexTest : ITest
  {
    public void PerformTest()
    {
      string s = Regex.Replace("Th1s is the _w&ay_ to %do it.", "[^0-9 a-z]", "", RegexOptions.IgnoreCase);
      Console.WriteLine(s);
    }
  }

  [TestInfo("MonoxideC", "Take Viewport Screenshot", "Saves a screenshot containing the current backbuffer contents of the Direct3D device.")]
  public class ScreenShot : ITest
  {
    public void PerformTest()
    {
      SaveFileDialog sfd = new SaveFileDialog();
      sfd.Filter = "Jpeg files (*.jpg)|*.jpg";
      if (sfd.ShowDialog() == DialogResult.Cancel) return;

      string filename = sfd.FileName;
      Core.Prometheus.Instance.SaveImage(filename);
    }
  }

  [TestInfo("MonoxideC", "New project Wizard", "Tests the new project wizard dialog.")]
  public class NewProjectWizardTest : ITest
  {
    public void PerformTest()
    {
      NewProjectDialog f = new NewProjectDialog();
      f.ShowDialog();
    }
  }

  [TestInfo("Project Tools", "Build XML Tag Definitions", "Creates a set of Prometheus XML Tag Definitions from a set of Kornman XML Tag Definitions extracted from Guerilla.")]
  public class BuildPromXMLFromKornmanXML : ITest
  {
    public void PerformTest()
    {
      FolderBrowserDialog fbd = new FolderBrowserDialog();
      fbd.SelectedPath = Application.StartupPath;
      fbd.Description = "Choose the folder where Kornman's XML files are located.";
      if (fbd.ShowDialog() == DialogResult.OK)
      {
        string newPath = fbd.SelectedPath + "\\output\\";
        if (!Directory.Exists(newPath)) Directory.CreateDirectory(newPath);
        foreach (string file in Directory.GetFiles(fbd.SelectedPath))
        {
          XmlDocument doc = new XmlDocument();
          doc.Load(file);
          XmlDocument newDoc = Core.Factory.TdfXmlConverter.ToPrometheusFormat(doc);
          newDoc.Save(newPath + Path.GetFileName(file));
        }
      }
    }
  }

  [TestInfo("MonoxideC", "Base Class Test", "Shit.")]
  public class BaseClassTest : ITest
  {
    public void PerformTest()
    {
      TestClassNew t = new TestClassNew();
      t.DoIt();
    }
    public class TestClassNew : TestClass
    {
      protected override void DoStuff()
      {
        MessageBox.Show("Inherited Message");
      }
    }
    public class TestClass
    {
      public void DoIt()
      {
        DoStuff();
      }
      protected virtual void DoStuff()
      {
        MessageBox.Show("Original Message");
      }
    }
  }

  [TestInfo("MonoxideC", "Tag Browser Tester", "Nuff said bitches.")]
  public class TBDTest : ITest
  {
    public void PerformTest()
    {
      //Form f = new TagBrowserDialog(Core.Prometheus.Instance.GetGameDefinitionByGameID("halo1pc"));
      //f.ShowDialog();
    }
  }

  [TestInfo("MonoxideC", "Options Persistance Test", "Tests loading/saving settings to the options files.")]
  public class SettingsSystemTest : ITest
  {
    public void PerformTest()
    {
      TestObject obj = new TestObject();
      obj.InstanceName = "Test Object #1";
      obj.Load();
      obj.SomeIntValue = 123456;
      obj.SomeIntValue = 100;
      obj.SomeIntValue = 99999;
      obj.SomeBoolValue = true;
      obj.Save();
    }

    public class TestObject : IPersistable
    {
      private string instanceName;
      public string InstanceName
      {
        get { return instanceName;  }
        set { instanceName = value;  }
      }

      private int someIntValue;
      [PersistableOption("Some Int Value", "Random Garbage", 100, OptionsFile.System, true)]
      public int SomeIntValue
      {
        get { return someIntValue; }
        set
        {
          someIntValue = value;
          if (SomeIntValueUpdated != null)
            SomeIntValueUpdated(this, null);
        }
      }
      
      [OptionUpdateNotifier("Some Int Value")]
      public event EventHandler SomeIntValueUpdated;

      private bool someBoolValue;
      [PersistableOption("Nick is Gay", "Truths", true, OptionsFile.System)]
      public bool SomeBoolValue
      {
        get { return someBoolValue; }
        set { someBoolValue = value; }
      }

      public void Load()
      {
        SettingsManager.Instance.LoadInstance(this);
      }

      public void Save()
      {
        SettingsManager.Instance.SaveInstance(this);
      }
    }
  }  
}
