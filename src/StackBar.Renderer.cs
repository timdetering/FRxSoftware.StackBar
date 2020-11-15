using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace FRxSoftware.Common.Controls
{
    public partial class StackBar
    {
        /// <summary>
        /// Professional renderer for the StackBar control
        /// </summary>
        internal class StackRenderer : ToolStripProfessionalRenderer
        {
            Pen borderPen;

            /// <summary>
            /// Default Constructor
            /// </summary>
            public StackRenderer()
            {
                this.RoundedEdges = false;
                borderPen = new Pen(Color.Black, 2);
            }

            protected override void OnRenderToolStripBorder(ToolStripRenderEventArgs e)
            {
                e.Graphics.DrawLine(borderPen, e.AffectedBounds.Left, e.AffectedBounds.Bottom, e.AffectedBounds.Right,
                                    e.AffectedBounds.Bottom);
            }

            protected override void OnRenderButtonBackground(ToolStripItemRenderEventArgs e)
            {
                if (e.Item == null) return;

                Rectangle bounds = new Rectangle(Point.Empty, e.Item.Size);
                ToolStripButton button = e.Item as ToolStripButton;

                System.Diagnostics.Debug.Assert(button != null,
                                                "Rendered button is not of type ToolStripButton");

                Color gradientBegin;
                Color gradientEnd;

                if (button.Enabled)
                {
                    if (button.Checked && button.Selected)
                    {
                        gradientBegin = ColorTable.ButtonCheckedGradientEnd;
                        gradientEnd = ColorTable.ButtonCheckedGradientBegin;
                    }
                    else if (button.Checked || button.Selected)
                    {
                        gradientBegin = ColorTable.ButtonCheckedGradientBegin;
                        gradientEnd = ColorTable.ButtonCheckedGradientEnd;
                    }
                    else
                    {
                        gradientBegin = ColorTable.ToolStripGradientBegin;
                        gradientEnd = ColorTable.ToolStripGradientEnd;
                    }
                }
                else
                {
                    gradientBegin = SystemColors.ButtonHighlight;
                    gradientEnd = SystemColors.ButtonShadow;
                }

                using (Brush b = new LinearGradientBrush(
                    bounds,
                    gradientBegin,
                    gradientEnd,
                    LinearGradientMode.Vertical))
                {
                    e.Graphics.FillRectangle(b, bounds);
                }

                e.Graphics.DrawRectangle(SystemPens.WindowText, bounds);
            }

            protected override void OnRenderItemImage(ToolStripItemImageRenderEventArgs e)
            {
                if (e.Image == null) return;

                Padding pad = e.Item.Padding;
                Rectangle bounds = new Rectangle(Point.Empty, e.Item.Size);
                int size = bounds.Height - (pad.Top + pad.Bottom);
                Rectangle imgRect = new Rectangle(pad.Left, pad.Top, size, size);

                e.Graphics.DrawImage(e.Image, imgRect);
            }

            protected override void OnRenderItemText(ToolStripItemTextRenderEventArgs e)
            {
                if (String.IsNullOrEmpty(e.Text)) return;

                ToolStripButton button = e.Item as ToolStripButton;
                Brush textBrush;

                if (button.Enabled)
                    textBrush = SystemBrushes.MenuText;
                else
                    textBrush = SystemBrushes.ControlDarkDark;

                Padding pad = e.Item.Padding;

                Rectangle bounds = new Rectangle(Point.Empty, e.Item.Size);
                Font font = e.Item.Font;

                // Offset text so that the same spacing exists both horizontally and vertically
                //
                int textOffset = pad.Left
                                 + pad.Right
                                 + bounds.Height
                                 - (pad.Top + pad.Bottom);

                e.Graphics.DrawString(e.Text,
                                      font,
                                      textBrush,
                                      textOffset,
                                      (bounds.Height - font.Height) / 2);
            }
        }
    }
}
