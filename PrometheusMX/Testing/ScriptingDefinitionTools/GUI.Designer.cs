namespace Prometheus.Testing.ScriptingDefinitionTools
{
	partial class GUI
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.ofdToolExe = new System.Windows.Forms.OpenFileDialog();
			this.ofdGameExe = new System.Windows.Forms.OpenFileDialog();
			this.btnToolExe = new System.Windows.Forms.Button();
			this.btnGameExe = new System.Windows.Forms.Button();
			this.sfdXmlOutput = new System.Windows.Forms.SaveFileDialog();
			this.btnXmlOutput = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// btnToolExe
			// 
			this.btnToolExe.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
									| System.Windows.Forms.AnchorStyles.Right)));
			this.btnToolExe.Location = new System.Drawing.Point(12, 12);
			this.btnToolExe.Name = "btnToolExe";
			this.btnToolExe.Size = new System.Drawing.Size(263, 23);
			this.btnToolExe.TabIndex = 0;
			this.btnToolExe.Text = "Process Tool.exe";
			this.btnToolExe.UseVisualStyleBackColor = true;
			this.btnToolExe.Click += new System.EventHandler(this.btnToolExe_Click);
			// 
			// btnGameExe
			// 
			this.btnGameExe.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
									| System.Windows.Forms.AnchorStyles.Right)));
			this.btnGameExe.Location = new System.Drawing.Point(12, 42);
			this.btnGameExe.Name = "btnGameExe";
			this.btnGameExe.Size = new System.Drawing.Size(263, 23);
			this.btnGameExe.TabIndex = 1;
			this.btnGameExe.Text = "Process Game Exe";
			this.btnGameExe.UseVisualStyleBackColor = true;
			// 
			// btnXmlOutput
			// 
			this.btnXmlOutput.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
									| System.Windows.Forms.AnchorStyles.Right)));
			this.btnXmlOutput.Location = new System.Drawing.Point(13, 72);
			this.btnXmlOutput.Name = "btnXmlOutput";
			this.btnXmlOutput.Size = new System.Drawing.Size(262, 23);
			this.btnXmlOutput.TabIndex = 2;
			this.btnXmlOutput.Text = "Save XML Output";
			this.btnXmlOutput.UseVisualStyleBackColor = true;
			// 
			// GUI
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(287, 106);
			this.Controls.Add(this.btnXmlOutput);
			this.Controls.Add(this.btnGameExe);
			this.Controls.Add(this.btnToolExe);
			this.Name = "GUI";
			this.Text = "ScriptEngineDefinition Tools";
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.OpenFileDialog ofdToolExe;
		private System.Windows.Forms.OpenFileDialog ofdGameExe;
		private System.Windows.Forms.Button btnToolExe;
		private System.Windows.Forms.Button btnGameExe;
		private System.Windows.Forms.SaveFileDialog sfdXmlOutput;
		private System.Windows.Forms.Button btnXmlOutput;
	}
}