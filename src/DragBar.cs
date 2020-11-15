using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace FRxSoftware.Common.Controls
{
	/// <summary>
	/// A Label control that renders a gradient fill background and drag bar dots
	/// </summary>
	public sealed partial class DragBar : Label
	{
		private Color gradientBegin = SystemColors.GradientInactiveCaption;
		private Color gradientEnd = SystemColors.Highlight;
		private static SolidBrush gripTopBrush = new SolidBrush(Color.Black);
		private static SolidBrush gripBottomBrush = new SolidBrush(Color.White);
		private ProfessionalColorTable colorTable = new ProfessionalColorTable();

		/// <summary>
		/// Default constructor
		/// </summary>
		public DragBar()
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

		protected override void OnPaint(PaintEventArgs e)
		{
			Graphics g = e.Graphics;
			Rectangle bounds = new Rectangle(Point.Empty, this.Size);

			GradientBegin = colorTable.ImageMarginGradientEnd;
			GradientEnd = colorTable.MenuBorder;

			// Draw the background gradient fill
			//
			using (Brush b = new LinearGradientBrush(
			    bounds,
			    GradientBegin,
			    GradientEnd,
			    LinearGradientMode.Vertical))
			{
				g.FillRectangle(b, bounds);
			}

			int startX = bounds.X + bounds.Width / 2;
			int y = bounds.Y + 1;
			int x;
			int dotWidth = 2;
			int dotSpacing = 1;

			// There are 9 centered dots that need to be drawn on the bar. This loop draws them in order
			// from left, -4, to right, +4, for a total of 9 dots.
			//
			for (int i = -4; i < 5; i++)
			{
				x = startX + 5 * i;
				g.FillRectangle(gripTopBrush, x, y, dotWidth, dotWidth);
				g.FillRectangle(gripBottomBrush, x + dotSpacing, y + dotSpacing, dotWidth, dotWidth);
				g.FillRectangle(SystemBrushes.Highlight, x + dotSpacing, y + dotSpacing, dotSpacing, dotSpacing);
			}

			base.OnPaint(e);
		}
	}
}
