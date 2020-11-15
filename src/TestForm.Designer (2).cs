namespace StackBar
{
	partial class TestForm
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
			this.stackBar1 = new FRxSoftware.Common.Controls.StackBar();
			this.SuspendLayout();
			// 
			// stackBar1
			// 
			this.stackBar1.BackColor = System.Drawing.SystemColors.InactiveBorder;
			this.stackBar1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.stackBar1.ButtonStackHeight = 0;
			this.stackBar1.Dock = System.Windows.Forms.DockStyle.Left;
			this.stackBar1.Font = new System.Drawing.Font("Tahoma", 8F);
			this.stackBar1.Location = new System.Drawing.Point(0, 0);
			this.stackBar1.Name = "stackBar1";
			this.stackBar1.SelectedButton = null;
			this.stackBar1.SelectedButtonIndex = -1;
			this.stackBar1.Size = new System.Drawing.Size(267, 457);
			this.stackBar1.TabIndex = 0;
			this.stackBar1.TitleFont = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
			// 
			// TestForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.SystemColors.Window;
			this.ClientSize = new System.Drawing.Size(473, 457);
			this.Controls.Add(this.stackBar1);
			this.Name = "TestForm";
			this.Text = "Form1";
			this.ResumeLayout(false);

		}

		#endregion

		private FRxSoftware.Common.Controls.StackBar stackBar1;
	}
}

