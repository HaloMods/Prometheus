#if DEBUG
using System;
using System.Drawing;
using System.Windows.Forms;
using DevComponents.DotNetBar;
using Prometheus.Testing;
using Padding=System.Windows.Forms.Padding;

namespace Prometheus.Dialogs
{
  /// <summary>
  /// This partial class contains the code that is used to display tests on the 
  /// Testing Ribbon, and to handle running tests the the developer selects.
  /// </summary>
  public partial class PrometheusGUI
  {
    private RibbonPanel testingPanel = new RibbonPanel();
    TestController testController = new TestController();
    
    private void InitializeTests()
    {
      // Initialize the testing ribbon.
      CreateTestTab();

      foreach (TestInfo info in testController.Tests)
      {
        CreateTestItem(info);
      }
    }
    
    private void CreateTestTab()
    {
      RibbonTabItem testingTab = new RibbonTabItem();
      
      rcPromRibbon.SuspendLayout();
      rcPromRibbon.Items.AddRange(new BaseItem[] { testingTab });
      rcPromRibbon.Controls.Add(testingPanel);

      testingTab.Panel = testingPanel;
      testingTab.Text = "Testing";
      testingTab.ColorTable = eRibbonTabColor.Magenta;

      testingPanel.ColorSchemeStyle = eDotNetBarStyle.Office2007;
      testingPanel.Dock = DockStyle.Fill;
      testingPanel.Location = new Point(0, 26);
      testingPanel.Name = "ribbonPanel1";
      testingPanel.Padding = new Padding(3, 0, 3, 3);
      testingPanel.Size = new Size(222, 86);
      testingPanel.TabIndex = 1;

      rcPromRibbon.ResumeLayout();
    }
    
    private void CreateTestItem(TestInfo test)
    {
      ButtonX button = null;
      ButtonX lastButton = null;
      foreach (Control c in testingPanel.Controls)
      {
        if (c is ButtonX)
        {
          lastButton = c as ButtonX;
          if ((c as ButtonX).Text == test.Info.DeveloperName)
          {
            button = c as ButtonX;
            break;
          }
        }
      }
      
      if (button == null)
      {
        button = new ButtonX();
        button.ColorScheme.DockSiteBackColorGradientAngle = 0;
        button.TabIndex = 0;
        button.Text = test.Info.DeveloperName;
        button.TextAlignment = eButtonTextAlignment.Center;
        button.AutoExpandOnClick = true;
        
        if (lastButton == null)
          button.Location = new Point(3, 3);
        else
          button.Location = new Point(
            lastButton.Location.X + lastButton.Width + 3, 3);
        
        button.Size = new Size(96, 79);
        testingPanel.Controls.Add(button);
        
        ItemContainer newContainer = new ItemContainer();
        newContainer.Name = "Container";
        newContainer.LayoutOrientation = eOrientation.Vertical;
        newContainer.MinimumSize = new Size(0, 0);
        button.SubItems.AddRange(new BaseItem[] { newContainer } );
      }
      
      ItemContainer container = button.SubItems["Container"] as ItemContainer;
      string name = test.Info.DeveloperName + "|" + test.Info.Name;
      bool found = false;
      foreach (BaseItem search in container.SubItems)
      {
        if (search.Name == name)
        {
          found = true;
          break;
        }
      }
      if (!found)
      {
        // Create the test item button.
        ButtonItem item = new ButtonItem();
        item.Name = name;
        item.Text = "<b>" + test.Info.Name + "</b><br />" + test.Info.Description;
        container.SubItems.Add(item);
        item.Click += new EventHandler(item_Click);
      }
    }

    /// <summary>
    /// Handles the click events for the items.
    /// </summary>
    void item_Click(object sender, EventArgs e)
    {
      if (sender is ButtonItem)
      {
        ButtonItem item = sender as ButtonItem;
        string[] parts = item.Name.Split('|');
        testController.PerformTest(parts[0], parts[1]);
      }
    }
  }
}
#endif