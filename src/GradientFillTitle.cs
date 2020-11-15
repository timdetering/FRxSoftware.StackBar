using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace FRxSoftware.Common.Controls
{
	public partial class GradientFillTitle : UserControl
	{
		public event EventHandler CloseClicked;

		public GradientFillTitle()
		{
			InitializeComponent();
			// TODO: move this to resoure
			//
			this.tsbClose.ToolTipText = "Close";
		}

		/// <summary>
		/// Get or Set a boolean to show or hide the Close button
		/// </summary>
		[Browsable(true)]
		public bool ShowCloseBox
		{
			get { return this.tsbClose.Visible; }
			set { this.tsbClose.Visible = value; }
		}

		/// <summary>
		/// Get or Set the title
		/// </summary>
		[Browsable(true)]
		public override string Text
		{
			get { return this.tslTitle.Text; }
			set { this.tslTitle.Text = value; }
		}

		/// <summary>
		/// Get or Set the title's alignment
		/// </summary>
		[Browsable(true)]
		public ContentAlignment TextAlign
		{
			get { return this.tslTitle.TextAlign; }
			set { this.tslTitle.TextAlign = value; }
		}

		/// <summary>
		/// Get or Set the Color to begin gradient fill
		/// </summary>
		[Browsable(true)]
		public Color GradientBegin
		{
			get { return this.gradientFillToolStrip1.GradientBegin; }
			set { this.gradientFillToolStrip1.GradientBegin = value; }
		}
		/// <summary>
		/// Get or Set the Color to end gradient fill
		/// </summary>
		[Browsable(true)]
		public Color GradientEnd
		{
			get { return this.gradientFillToolStrip1.GradientEnd; }
			set { this.gradientFillToolStrip1.GradientEnd = value; }
		}

		private void tsbClose_Click(object sender, EventArgs e)
		{
			if (CloseClicked != null) CloseClicked(this, EventArgs.Empty);
		}
	}
}
