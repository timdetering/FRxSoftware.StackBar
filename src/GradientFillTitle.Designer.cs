namespace FRxSoftware.Common.Controls
{
	partial class GradientFillTitle
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

		#region Component Designer generated code

		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Globalization", "CA1303:DoNotPassLiteralsAsLocalizedParameters", Scope = "method")] // Allowing string literals in Designer files for design time support
		private void InitializeComponent()
		{
			this.gradientFillToolStrip1 = new FRxSoftware.Common.Controls.GradientFillToolStrip();
			this.tslTitle = new System.Windows.Forms.ToolStripLabel();
			this.tsbClose = new System.Windows.Forms.ToolStripButton();
			this.gradientFillToolStrip1.SuspendLayout();
			this.SuspendLayout();
			// 
			// gradientFillToolStrip1
			// 
			this.gradientFillToolStrip1.AutoSize = false;
			this.gradientFillToolStrip1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.gradientFillToolStrip1.GradientBegin = System.Drawing.Color.FromArgb(((int)(((byte)(123)))), ((int)(((byte)(164)))), ((int)(((byte)(224)))));
			this.gradientFillToolStrip1.GradientEnd = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(45)))), ((int)(((byte)(150)))));
			this.gradientFillToolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
			this.gradientFillToolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tslTitle,
            this.tsbClose});
			this.gradientFillToolStrip1.Location = new System.Drawing.Point(0, 0);
			this.gradientFillToolStrip1.Name = "gradientFillToolStrip1";
			this.gradientFillToolStrip1.Size = new System.Drawing.Size(460, 24);
			this.gradientFillToolStrip1.TabIndex = 0;
			this.gradientFillToolStrip1.Text = "gradientFillToolStrip1";
			// 
			// tslTitle
			// 
			this.tslTitle.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
			this.tslTitle.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
			this.tslTitle.Name = "tslTitle";
			this.tslTitle.Size = new System.Drawing.Size(52, 21);
			this.tslTitle.Text = "Title ";
			// 
			// tsbClose
			// 
			this.tsbClose.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
			this.tsbClose.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.tsbClose.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.tsbClose.ForeColor = System.Drawing.SystemColors.ControlText;
			this.tsbClose.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsbClose.Margin = new System.Windows.Forms.Padding(2);
			this.tsbClose.Name = "tsbClose";
			this.tsbClose.Size = new System.Drawing.Size(23, 20);
			this.tsbClose.Text = "X";
			this.tsbClose.ToolTipText = "Close";
			this.tsbClose.Visible = false;
			this.tsbClose.Click += new System.EventHandler(this.tsbClose_Click);
			// 
			// GradientFillTitle
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.gradientFillToolStrip1);
			this.Margin = new System.Windows.Forms.Padding(0);
			this.Name = "GradientFillTitle";
			this.Size = new System.Drawing.Size(460, 24);
			this.gradientFillToolStrip1.ResumeLayout(false);
			this.gradientFillToolStrip1.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private GradientFillToolStrip gradientFillToolStrip1;
		private System.Windows.Forms.ToolStripLabel tslTitle;
		private System.Windows.Forms.ToolStripButton tsbClose;
	}
}
