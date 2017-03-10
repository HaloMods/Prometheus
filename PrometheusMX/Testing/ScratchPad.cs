using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Prometheus.Controls;

namespace Prometheus.Testing
{  
  public partial class ScratchPadForm : DevComponents.DotNetBar.Office2007Form
  {
    public ScratchPadForm()
    {
      InitializeComponent();

      checkList1.Add("Capture the Flag", "You uhm ... capture the flag.", "Rulez");
      checkList1.Add("Slayer", false, String.Empty, "Rulez");
      checkList1.Add("King of the Hill", true, String.Empty, "Sux");
      checkList1.Add(new Prometheus.Controls.CheckListItem("Name", "Oddball", true), "Your mom's an oddball.", "sUx");
      checkList1.Add("anudanameudunc", "Juggernaut", true, "I'm da Jugganaut, bitch!", "Rulez");
      checkList1.Add("Territories");
      checkList1.Add("Assault", false);

      checkList1.Add("Testing 1 2 3! Test!", "Test Tooltip!", String.Empty);
      checkList1.Add("Testing 4...6", false, String.Empty, "Test Group That Is Long");
      checkList1.Add(new Prometheus.Controls.CheckListItem("Name", "Testing 7...", true), String.Empty, "Blah");

      AddCheckListItems(5000);
    }

    private void AddCheckListItems(int count)
    {
      for (int i = 0; i < count; i++)
      {
        string guid = Guid.NewGuid().ToString();

        checkList1.Add(new Prometheus.Controls.CheckListItem("Name" + guid, "Testing " + guid, Convert.ToBoolean(i % 2)), String.Empty, "Group " + (i % 10));
      }
    }

    private void buttonX1_Click(object sender, EventArgs e)
    {
      AddCheckListItems(1);
    }

    private void buttonX2_Click(object sender, EventArgs e)
    {
      AddCheckListItems(100);
    }

    private void buttonX3_Click(object sender, EventArgs e)
    {
      AddCheckListItems(1000);
    }
  }

  [TestInfoAttribute("Nick", "Windows Form \"Scratch Pad\"", "A dedicated place to toy with and test out various controls and properties.<br /><br />Anyone is free to use. However, do <b>not</b> submit changes. This should<br />remain a clean sandbox.")]
  public class ScratchPad : ITest
  {
    public void PerformTest()
    {
      new ScratchPadForm().Show();
    }
  }
}