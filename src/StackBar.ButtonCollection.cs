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
        /// A collection of ToolStripButtons for use by the StackBar control.
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design",
                                                         "CA1034:NestedTypesShouldNotBeVisible")] // This type needs to be visible and has to be nested due to the way it interacts with the StackBar control
        public class StackBarButtonCollection : List<StackBarButton>
        {
            private StackBar parent;
            private int threshold = -1;

            private StackBarButtonCollection()
            {
            }

            /// <summary>
            /// The StackBarButtonCollection class can only be instantiated by the StackBar class
            /// </summary>
            /// <param name="parentBar"></param>
            internal StackBarButtonCollection(StackBar parentBar)
            {
                parent = parentBar;
            }

            /// <summary>
            /// The index of the last ButtonStack button
            /// </summary>
            public int Threshold
            {
                get { return threshold; }
                set { threshold = value; }
            }

            /// <summary>
            /// Add a StackBarButton to the collection 
            /// </summary>
            /// <param name="buttonName">Name identifier for this button</param>
            /// <param name="buttonText">Text displayed on button</param>
            /// <param name="buttonImage">Image displayed on button</param>
            [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Reliability",
                                                             "CA2000:DisposeObjectsBeforeLosingScope")] // False hit. The button is being new'ed up and added to the button collection and should not be disposed
            public void Add(string buttonName, string buttonText, Image buttonImage)
            {
                this.Add(new StackBarButton(buttonName, buttonText, buttonImage));
            }

            /// <summary>
            /// Add a StackBarButton to the collection 
            /// </summary>
            /// <param name="buttonName">Name identifier for this button</param>
            /// <param name="buttonText">Text displayed on button</param>
            /// <param name="buttonImage">Image displayed on button</param>
            [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Reliability",
                                                             "CA2000:DisposeObjectsBeforeLosingScope")] // False hit. The button is being new'ed up and added to the button collection and should not be disposed
            public void Add(string buttonName, string buttonText, Image buttonImage, Control navigationPaneControl)
            {
                this.Add(new StackBarButton(buttonName, buttonText, buttonImage, navigationPaneControl));
            }

            /// <summary>
            /// Add a StackBarButton to the collection 
            /// </summary>
            /// <param name="button">StackBarButton to add</param>
            public new void Add(StackBarButton button)
            {
                this.AddToParent(button);
            }

            /// <summary>
            /// Remove a StackBarButton from the collection
            /// </summary>
            /// <param name="button">StackBarButton to remove</param>
            public new void Remove(StackBarButton button)
            {
                parent.SuspendLayout();
                RemoveFromParent(button);
                parent.ResumeLayout();
            }

            /// <summary>
            /// Remove a StackBarButton from the collection at the specified index
            /// </summary>
            /// <param name="index">Index of the StackBarButton</param>
            public new void RemoveAt(int index)
            {
                parent.SuspendLayout();
                RemoveFromParent(this[index]);
                parent.ResumeLayout();
            }

            /// <summary>
            /// Remove a range of StackBarButton from the collection
            /// </summary>
            /// <param name="index">Starting index</param>
            /// <param name="count">Number of StackBarButton to remove</param>
            public new void RemoveRange(int index, int count)
            {
                parent.SuspendLayout();

                for (int i = index, removedCount = 0; removedCount < count && i < this.Count; i++, removedCount++)
                {
                    RemoveFromParent(this[i]);
                }

                parent.ResumeLayout();
            }

            /// <summary>
            /// Clear all StackBarButton from the collection
            /// </summary>
            public new void Clear()
            {
                parent.SuspendLayout();
                parent.ClearButtons();
                parent.ResumeLayout();
                base.Clear();
                Threshold = -1;
            }

            /// <summary>
            /// Add a range of StackBarButton to the collection
            /// </summary>
            /// <param name="buttons">Collection of StackBarButton</param>
            public new void AddRange(IEnumerable<StackBarButton> buttons)
            {
                parent.SuspendLayout();

                foreach (StackBarButton button in buttons)
                {
                    if (button != null)
                    {
                        AddToParent(button);
                    }
                }

                parent.ResumeLayout();
            }

            /// <summary>
            /// Insert a StackBarButton at the specified location
            /// </summary>
            /// <param name="button">StackBarButton to insert</param>
            public new void Insert(int index, StackBarButton button)
            {
                List<StackBarButton> list = new List<StackBarButton>();
                list.Add(button);
                InsertRange(index, list);
            }

            /// <summary>
            /// Insert a range of StackBarButton at the specified index
            /// </summary>
            /// <param name="buttons">Collection of StackBarButton to insert</param>
            public new void InsertRange(int index, IEnumerable<StackBarButton> buttons)
            {
                parent.SuspendLayout();
                StackBarButton[] savedButtons = new StackBarButton[this.Count - index];
                this.CopyTo(savedButtons, index);

                // Remove all buttons after range start
                //
                for (int i = this.Count - 1; i >= index; i--)
                {
                    RemoveFromParent(this[i]);
                }

                // Add newly inserted buttons
                //
                foreach (StackBarButton button in buttons)
                {
                    AddToParent(button);
                }

                // Add previously removed buttons after inserted range
                //
                for (int i = 0; i < savedButtons.Length; i++)
                {
                    AddToParent(savedButtons[i]);
                }

                parent.ResumeLayout();
            }

            /// <summary>
            /// Add a button to the parent StackBar control
            /// </summary>
            /// <param name="button"></param>
            private void AddToParent(StackBarButton button)
            {
                if (this.Count == 0)
                {
                    button.Button.Checked = true;
                }

                button.Button.Font = parent.ButtonFormat.Font;
                button.Button.Padding = parent.ButtonFormat.ButtonPadding;
                button.Button.Height = parent.ButtonFormat.StackButtonHeight;
                button.Button.Width = parent.Width - 1;

                base.Add(button);
                Threshold++;
                parent.AddButton(button.Button);
            }

            /// <summary>
            /// Remove a StackBarButton from the parent StackBar control
            /// </summary>
            /// <param name="button"></param>
            private void RemoveFromParent(StackBarButton button)
            {
                int index = this.IndexOf(button);

                if (index <= Threshold)
                {
                    Threshold--;
                }

                parent.RemoveButton(button.Button);
                base.RemoveAt(index);
            }

            #region NYI Methods
            /// <summary>
            /// This method is not implemented
            /// </summary>

            [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage",
                                                             "CA1801:ReviewUnusedParameters")] // Method is stub that throws NotImplementedException
            [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance",
                                                             "CA1822:MarkMembersAsStatic")] // Method is stub that throws NotImplementedException
            public new void RemoveAll(Predicate<StackBarButton> match)
            {
                throw new NotImplementedException();
            }

            /// <summary>
            /// This method is not implemented
            /// </summary>
            [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage",
                                                             "CA1801:ReviewUnusedParameters")] // Method is stub that throws NotImplementedException
            [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance",
                                                             "CA1822:MarkMembersAsStatic")] // Method is stub that throws NotImplementedException
            public new void Reverse(int index, int count)
            {
                throw new NotImplementedException();
            }

            /// <summary>
            /// This method is not implemented
            /// </summary>
            [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage",
                                                             "CA1801:ReviewUnusedParameters")] // Method is stub that throws NotImplementedException
            [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance",
                                                             "CA1822:MarkMembersAsStatic")] // Method is stub that throws NotImplementedException
            public new void Reverse()
            {
                throw new NotImplementedException();
            }

            /// <summary>
            /// This method is not implemented
            /// </summary>
            [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage",
                                                             "CA1801:ReviewUnusedParameters")] // Method is stub that throws NotImplementedException
            [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance",
                                                             "CA1822:MarkMembersAsStatic")] // Method is stub that throws NotImplementedException
            public new void Sort()
            {
                throw new NotImplementedException();
            }

            /// <summary>
            /// This method is not implemented
            /// </summary>
            [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage",
                                                             "CA1801:ReviewUnusedParameters")] // Method is stub that throws NotImplementedException
            [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance",
                                                             "CA1822:MarkMembersAsStatic")] // Method is stub that throws NotImplementedException
            public new void Sort(IComparer<StackBarButton> compare)
            {
                throw new NotImplementedException();
            }

            /// <summary>
            /// This method is not implemented
            /// </summary>
            [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage",
                                                             "CA1801:ReviewUnusedParameters")] // Method is stub that throws NotImplementedException
            [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance",
                                                             "CA1822:MarkMembersAsStatic")] // Method is stub that throws NotImplementedException
            public new void Sort(Comparison<StackBarButton> compare)
            {
                throw new NotImplementedException();
            }

            /// <summary>
            /// This method is not implemented
            /// </summary>
            [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage",
                                                             "CA1801:ReviewUnusedParameters")] // Method is stub that throws NotImplementedException
            [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance",
                                                             "CA1822:MarkMembersAsStatic")] // Method is stub that throws NotImplementedException
            public new void Sort(int index, int count, IComparer<StackBarButton> compare)
            {
                throw new NotImplementedException();
            }
            #endregion
        }
    }
}