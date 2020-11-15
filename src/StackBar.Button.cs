using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace FRxSoftware.Common.Controls
{
    public partial class StackBar
    {
        /// <summary>
        /// Button displayed on the StackBar control
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design",
                                                         "CA1034:NestedTypesShouldNotBeVisible")] // This type needs to be visible and has to be nested due to the way it interacts with the StackBar control
        public class StackBarButton : IDisposable
        {
            public event EventHandler VisibleChanged;

            private bool visible = true;
            private ToolStripButton button;
            private ToolStripMenuItem menuItem;
            private Control navPaneControl;

            private StackBarButton()
            {
            }

            public StackBarButton(ToolStripButton button)
            {
                if (button == null)
                {
                    throw new ArgumentNullException("button", string.Empty);
                }

                InitializeButton(button.Name, button.Text, button.Image);
            }

            public StackBarButton(string buttonName, string buttonText, Image buttonImage)
            {
                InitializeButton(buttonName, buttonText, buttonImage);
            }

            public StackBarButton(string buttonName, string buttonText, Image buttonImage, Control control)
            {
                navPaneControl = control;
                InitializeButton(buttonName, buttonText, buttonImage);
            }

            /// <summary>
            /// Dispose the control object
            /// </summary>
            public void Dispose()
            {
                this.Dispose(true);
                GC.SuppressFinalize(this);
            }

            /// <summary>
            /// Enable or disable the button
            /// </summary>
            public bool Enabled
            {
                get { return button.Enabled; }
                set { button.Enabled = value; }
            }

            /// <summary>
            /// Control that will be displayed in the Navigation Pane when button is activated
            /// </summary>
            public Control NavigationPaneControl
            {
                get { return navPaneControl; }
                set { navPaneControl = value; }
            }

            /// <summary>
            /// Button Name
            /// </summary>
            public string Name
            {
                get { return button.Name; }
            }

            /// <summary>
            /// Button Text
            /// </summary>
            public string Text
            {
                get { return button.Text; }
                set { button.Text = value; }
            }

            /// <summary>
            /// Button Image
            /// </summary>
            public Image Image
            {
                get { return button.Image; }
                set { button.Image = value; }
            }

            /// <summary>
            /// Transparent Image color
            /// </summary>
            public Color ImageTransparentColor
            {
                get { return button.ImageTransparentColor; }
                set { button.ImageTransparentColor = value; }
            }

            /// <summary>
            /// Get the button's Visible property
            /// </summary>
            public bool Visible
            {
                get { return visible; }
                set
                {
                    visible = value;
                    button.Visible = visible;
                    menuItem.Checked = visible;

                    if (VisibleChanged != null) VisibleChanged(this, EventArgs.Empty);
                }
            }


            internal ToolStripButton Button
            {
                get { return button; }
            }

            /// <summary>
            /// The MenuButton associated with this control
            /// </summary>
            internal ToolStripMenuItem MenuButton
            {
                get { return menuItem; }
            }


            private void InitializeButton(string name, string text, Image image)
            {
                // Add ToolStrip button
                button = new ToolStripButton();
                button.Name = name;
                button.Text = text;
                button.Image = image;
                button.Margin = new Padding(0);
                button.CheckOnClick = true;
                button.CheckState = CheckState.Unchecked;
                button.ImageAlign = ContentAlignment.MiddleLeft;
                button.ImageScaling = ToolStripItemImageScaling.SizeToFit;
                button.TextAlign = ContentAlignment.MiddleLeft;
                button.TextDirection = ToolStripTextDirection.Horizontal;
                button.ImageTransparentColor = Color.Black;
                button.Tag = this;

                // Add menu button
                //
                menuItem = new ToolStripMenuItem();
                menuItem.Checked = true;
                menuItem.Tag = button;
                menuItem.Name = StackBar.GetMenuButtonNameFromButtonName(button.Name);
                menuItem.Text = button.Text;
                menuItem.Image = button.Image;
            }

            /// <summary>
            /// Disposal boolean
            /// </summary>
            private bool disposed;

            /// <summary>
            /// protected disposal method
            /// </summary>
            /// <param name="disposing"></param>
            protected virtual void Dispose(bool disposing)
            {
                if (!this.disposed)
                {
                    // Cleanup up managed resources
                    //
                    if (disposing)
                    {
                        button.Dispose();
                        menuItem.Dispose();
                        navPaneControl.Dispose();
                    }

                    // Clean up any unmanaged resources here
                    //
                }

                disposed = true;
            }

            /// <summary>
            /// Destructor
            /// </summary>
            ~StackBarButton()
            {
                Dispose(false);
            }
        }
    }
}