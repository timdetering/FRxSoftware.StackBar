using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Text;
using System.Windows.Forms;

namespace FRxSoftware.Common.Controls
{
	internal partial class GradientFillToolStrip : ToolStrip
	{
		private Color gradientBegin = SystemColors.GradientInactiveCaption;
		private Color gradientEnd = SystemColors.Highlight;
		private ProfessionalColorTable colorTable = new ProfessionalColorTable();
		
		public GradientFillToolStrip()
		{
			InitializeComponent();
		}

		/// <summary>
		/// Get or Set the Color to begin gradient fill
		/// </summary>
		[Browsable(true)]
		public Color GradientBegin
		{
			get { return gradientBegin; }
			set { gradientBegin = value; }
		}
		/// <summary>
		/// Get or Set the Color to end gradient fill
		/// </summary>
		[Browsable(true)]
		public Color GradientEnd
		{
			get { return gradientEnd; }
			set { gradientEnd = value; }
		}

		protected override void OnPaintBackground(PaintEventArgs pe)
		{
			Graphics g = pe.Graphics;
			Rectangle bounds = new Rectangle(Point.Empty, this.Size);
			
			// Draw Background
			//
			GradientBegin = colorTable.ImageMarginGradientEnd;
			GradientEnd = colorTable.MenuBorder;

			using (Brush b = new LinearGradientBrush(
				bounds,
				GradientBegin,
				GradientEnd,
				LinearGradientMode.Vertical))
			{
				g.FillRectangle(b, bounds);
			}


			// Calling the base class OnPaint
			//base.OnPaint(pe);
		}
	}
}
