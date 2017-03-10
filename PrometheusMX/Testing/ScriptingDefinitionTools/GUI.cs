using System.Windows.Forms;

namespace Prometheus.Testing.ScriptingDefinitionTools
{
	[TestInfo("rec0", "Scripting Definition Tools",
		"Tools for extraction of script definitions etc.")]
	public partial class GUI : Form, ITest
	{
		public GUI()
		{
			InitializeComponent();
		}

		public void PerformTest()
		{
			Show();
		}

		private void btnToolExe_Click(object sender, System.EventArgs e)
		{

		}
	}
}