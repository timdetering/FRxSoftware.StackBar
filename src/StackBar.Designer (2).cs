namespace FRxSoftware.Common.Controls
{
	partial class StackBar
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StackBar));
			this.navigationPanel = new System.Windows.Forms.Panel();
			this.ButtonStack = new System.Windows.Forms.ToolStrip();
			this.ButtonStrip = new System.Windows.Forms.ToolStrip();
			this.ButtonStripDropDownButton = new System.Windows.Forms.ToolStripDropDownButton();
			this.menu_ShowMoreButtons = new System.Windows.Forms.ToolStripMenuItem();
			this.menu_ShowFewerButtons = new System.Windows.Forms.ToolStripMenuItem();
			this.menuAddRemove = new System.Windows.Forms.ToolStripMenuItem();
			this.stackBarLayout = new System.Windows.Forms.TableLayoutPanel();
			this.titleLabel = new FRxSoftware.Common.Controls.GradientFillTitle();
			this.Bar = new FRxSoftware.Common.Controls.DragBar();
			this.ButtonStrip.SuspendLayout();
			this.stackBarLayout.SuspendLayout();
			this.SuspendLayout();
			// 
			// navigationPanel
			// 
			this.navigationPanel.Dock = System.Windows.Forms.DockStyle.Fill;
			this.navigationPanel.Location = new System.Drawing.Point(0, 25);
			this.navigationPanel.Margin = new System.Windows.Forms.Padding(0);
			this.navigationPanel.Name = "navigationPanel";
			this.navigationPanel.Size = new System.Drawing.Size(267, 309);
			this.navigationPanel.TabIndex = 0;
			this.navigationPanel.TabStop = true;
			// 
			// ButtonStack
			// 
			this.ButtonStack.AutoSize = false;
			this.ButtonStack.CanOverflow = false;
			this.ButtonStack.Dock = System.Windows.Forms.DockStyle.Fill;
			this.ButtonStack.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
			this.ButtonStack.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.VerticalStackWithOverflow;
			this.ButtonStack.Location = new System.Drawing.Point(0, 340);
			this.ButtonStack.Name = "ButtonStack";
			this.ButtonStack.Padding = new System.Windows.Forms.Padding(0);
			this.ButtonStack.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
			this.ButtonStack.ShowItemToolTips = false;
			this.ButtonStack.Size = new System.Drawing.Size(267, 21);
			this.ButtonStack.TabIndex = 2;
			this.ButtonStack.Text = "toolStrip1";
			// 
			// ButtonStrip
			// 
			this.ButtonStrip.AutoSize = false;
			this.ButtonStrip.Dock = System.Windows.Forms.DockStyle.Fill;
			this.ButtonStrip.Font = new System.Drawing.Font("Tahoma", 8F);
			this.ButtonStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
			this.ButtonStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ButtonStripDropDownButton});
			this.ButtonStrip.Location = new System.Drawing.Point(0, 361);
			this.ButtonStrip.Name = "ButtonStrip";
			this.ButtonStrip.Padding = new System.Windows.Forms.Padding(0);
			this.ButtonStrip.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
			this.ButtonStrip.Size = new System.Drawing.Size(267, 30);
			this.ButtonStrip.Stretch = true;
			this.ButtonStrip.TabIndex = 3;
			// 
			// ButtonStripDropDownButton
			// 
			this.ButtonStripDropDownButton.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menu_ShowMoreButtons,
            this.menu_ShowFewerButtons,
            this.menuAddRemove});
			this.ButtonStripDropDownButton.Font = new System.Drawing.Font("Tahoma", 8F);
			this.ButtonStripDropDownButton.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
			this.ButtonStripDropDownButton.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
			this.ButtonStripDropDownButton.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.ButtonStripDropDownButton.Margin = new System.Windows.Forms.Padding(5, 0, 0, 0);
			this.ButtonStripDropDownButton.Name = "ButtonStripDropDownButton";
			this.ButtonStripDropDownButton.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.ButtonStripDropDownButton.Size = new System.Drawing.Size(13, 30);
			this.ButtonStripDropDownButton.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			this.ButtonStripDropDownButton.TextDirection = System.Windows.Forms.ToolStripTextDirection.Horizontal;
			this.ButtonStripDropDownButton.TextImageRelation = System.Windows.Forms.TextImageRelation.TextAboveImage;
			// 
			// menu_ShowMoreButtons
			// 
			this.menu_ShowMoreButtons.Enabled = false;
			this.menu_ShowMoreButtons.Image = ((System.Drawing.Image)(resources.GetObject("menu_ShowMoreButtons.Image")));
			this.menu_ShowMoreButtons.ImageTransparentColor = System.Drawing.Color.Black;
			this.menu_ShowMoreButtons.Name = "menu_ShowMoreButtons";
			this.menu_ShowMoreButtons.Size = new System.Drawing.Size(199, 22);
			this.menu_ShowMoreButtons.Text = "Show &More Buttons";
			this.menu_ShowMoreButtons.Click += new System.EventHandler(this.menu_ShowMoreButtons_Click);
			// 
			// menu_ShowFewerButtons
			// 
			this.menu_ShowFewerButtons.Enabled = false;
			this.menu_ShowFewerButtons.Image = ((System.Drawing.Image)(resources.GetObject("menu_ShowFewerButtons.Image")));
			this.menu_ShowFewerButtons.ImageTransparentColor = System.Drawing.Color.Black;
			this.menu_ShowFewerButtons.Name = "menu_ShowFewerButtons";
			this.menu_ShowFewerButtons.Size = new System.Drawing.Size(199, 22);
			this.menu_ShowFewerButtons.Text = "Show &Fewer Buttons";
			this.menu_ShowFewerButtons.Click += new System.EventHandler(this.menu_ShowFewerButtons_Click);
			// 
			// menuAddRemove
			// 
			this.menuAddRemove.Name = "menuAddRemove";
			this.menuAddRemove.Size = new System.Drawing.Size(199, 22);
			this.menuAddRemove.Text = "&Add or Remove Buttons";
			// 
			// stackBarLayout
			// 
			this.stackBarLayout.ColumnCount = 1;
			this.stackBarLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.stackBarLayout.Controls.Add(this.titleLabel, 0, 0);
			this.stackBarLayout.Controls.Add(this.ButtonStrip, 0, 4);
			this.stackBarLayout.Controls.Add(this.ButtonStack, 0, 3);
			this.stackBarLayout.Controls.Add(this.Bar, 0, 2);
			this.stackBarLayout.Controls.Add(this.navigationPanel, 0, 1);
			this.stackBarLayout.Dock = System.Windows.Forms.DockStyle.Fill;
			this.stackBarLayout.Location = new System.Drawing.Point(0, 0);
			this.stackBarLayout.Name = "stackBarLayout";
			this.stackBarLayout.RowCount = 5;
			this.stackBarLayout.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.stackBarLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.stackBarLayout.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.stackBarLayout.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.stackBarLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
			this.stackBarLayout.Size = new System.Drawing.Size(267, 391);
			this.stackBarLayout.TabIndex = 5;
			// 
			// titleLabel
			// 
			this.titleLabel.Dock = System.Windows.Forms.DockStyle.Top;
			this.titleLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
			this.titleLabel.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
			this.titleLabel.GradientBegin = System.Drawing.Color.FromArgb(((int)(((byte)(123)))), ((int)(((byte)(164)))), ((int)(((byte)(224)))));
			this.titleLabel.GradientEnd = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(45)))), ((int)(((byte)(150)))));
			this.titleLabel.Location = new System.Drawing.Point(0, 0);
			this.titleLabel.Margin = new System.Windows.Forms.Padding(0);
			this.titleLabel.Name = "titleLabel";
			this.titleLabel.Size = new System.Drawing.Size(267, 25);
			this.titleLabel.TabIndex = 4;
			this.titleLabel.Text = "Title";
			this.titleLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// Bar
			// 
			this.Bar.BackColor = System.Drawing.SystemColors.ActiveCaption;
			this.Bar.Cursor = System.Windows.Forms.Cursors.SizeNS;
			this.Bar.Dock = System.Windows.Forms.DockStyle.Top;
			this.Bar.GradientBegin = System.Drawing.Color.FromArgb(((int)(((byte)(123)))), ((int)(((byte)(164)))), ((int)(((byte)(224)))));
			this.Bar.GradientEnd = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(45)))), ((int)(((byte)(150)))));
			this.Bar.Location = new System.Drawing.Point(0, 334);
			this.Bar.Margin = new System.Windows.Forms.Padding(0);
			this.Bar.Name = "Bar";
			this.Bar.Size = new System.Drawing.Size(267, 6);
			this.Bar.TabIndex = 1;
			this.Bar.Text = "-----";
			this.Bar.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Bar_MouseDown);
			this.Bar.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Bar_MouseMove);
			this.Bar.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Bar_MouseUp);
			// 
			// StackBar
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.stackBarLayout);
			this.Name = "StackBar";
			this.Size = new System.Drawing.Size(267, 391);
			this.ButtonStrip.ResumeLayout(false);
			this.ButtonStrip.PerformLayout();
			this.stackBarLayout.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Panel navigationPanel;
		private DragBar Bar;
		private System.Windows.Forms.ToolStrip ButtonStack;
		private System.Windows.Forms.ToolStrip ButtonStrip;
		private FRxSoftware.Common.Controls.GradientFillTitle titleLabel;
		private System.Windows.Forms.ToolStripDropDownButton ButtonStripDropDownButton;
		private System.Windows.Forms.ToolStripMenuItem menu_ShowMoreButtons;
		private System.Windows.Forms.ToolStripMenuItem menu_ShowFewerButtons;
		private System.Windows.Forms.ToolStripMenuItem menuAddRemove;
		private System.Windows.Forms.TableLayoutPanel stackBarLayout;
	}
}
