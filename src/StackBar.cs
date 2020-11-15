using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace FRxSoftware.Common.Controls
{
	/// <summary>
	/// The StackBar is a theme aware control consisting of 4 main pieces which are, (In order from top to bottom):
	/// 
	/// Title Label		-	GradientFillLabel
	/// Navigation Panel	-	Panel
	/// DragBar			-	DragBar
	/// ButtonStack		-	ToolStrip, vertical
	/// Button strip		-	ToolStrip, horizontal
	/// 
	/// The StackBar duplicates many of the basic features of the Outlook Wonderbar control and performs
	/// dynamic resizing of the ButtonStack by shifting buttons to the ButtonStrip.
	/// </summary>
	public partial class StackBar : UserControl
	{
		/// <summary>
		/// Event that fires when a StackBar button is clicked
		/// </summary>
		public event EventHandler ButtonClicked;
		/// <summary>
		/// Event that fires when a StackBar's Visible property changes
		/// </summary>
		public event EventHandler ButtonVisibleChanged;
		/// <summary>
		/// Event that fires when the StackBar's Button Stack height changes
		/// </summary>
		public event EventHandler ButtonStackHeightChanged;
	
		private const string menuPrePend = "menu";
		private bool moving;
		private Point startPos;
		private Point startBar;
		private Size startSize;
		private StackBarButton selectedButton;
		private StackBarButtonCollection buttonList;
		private readonly StackBarButtonFormat buttonFormat;

		/// <summary>
		/// Default constructor
		/// </summary>
		public StackBar()
		{
			InitializeComponent();

			this.Font = SystemFonts.DialogFont;

			buttonList = new StackBarButtonCollection(this);
			buttonFormat = new StackBarButtonFormat(buttonList);

			ButtonStack.Renderer = new StackRenderer();

			ToolStripProfessionalRenderer stripRenderer = new ToolStripProfessionalRenderer();
			stripRenderer.RoundedEdges = false;
			ButtonStrip.Renderer = stripRenderer;
		}

		/// <summary>
		/// Button format
		/// </summary>
		public StackBarButtonFormat ButtonFormat
		{
			get { return buttonFormat; }
		}

		/// <summary>
		/// Get or Set the selected button by index. If there are not buttons in the stack
		/// Get returns -1
		/// </summary>
		public int SelectedButtonIndex
		{
			get 
			{
				if (selectedButton == null) return -1;
				return buttonList.IndexOf(SelectedButton);
			}
			set
			{
				if (buttonList.Count == 0) return;
				if( value < 0 ) value = 0;
				if (value > buttonList.Count) value = buttonList.Count - 1;

				SelectedButton = buttonList[value];					
			}
		}
		/// <summary>
		/// Get the collection of ToolStripButtons associated with this control
		/// </summary>
		public StackBarButtonCollection Items 
		{ 
			get { return buttonList; } 
		}
		/// <summary>
		/// Get or Set the Navigation Panel
		/// </summary>
		public Panel NavigationPanel
		{
			get { return this.navigationPanel; }
			set { this.navigationPanel = value; }
		}
		/// <summary>
		/// Get or Set the currently selected button
		/// </summary>
		public StackBarButton SelectedButton
		{
			get { return selectedButton; }
			set
			{
				if (value == null) return;

				if (value != selectedButton)
				{
					toolStripButton_Click(value.Button, new EventArgs());
				}
			}
		}
		/// <summary>
		/// The Font used for the control's title label
		/// </summary>
		[Browsable(true)]
		public Font TitleFont
		{
			get { return titleLabel.Font; }
			set { if( value != null ) titleLabel.Font = value; }
		}
		/// <summary>
		/// The text displayed in the control's title label
		/// </summary>
		[Browsable(true)]
		public override string Text
		{
			get { return titleLabel.Text; }
			set { titleLabel.Text = value; }
		}
		/// <summary>
		/// Hide a Button
		/// </summary>
		/// <param name="buttonName">Name of button to Hide</param>
		public void HideButton(string buttonName)
		{
			StackBarButton button = GetButtonByName(buttonName);
			button.Visible = false;
			ResizeButtonStack(ButtonStackHeight);
			return;
		}
		/// <summary>
		/// Show a Button
		/// </summary>
		/// <param name="buttonName">Name of button to Show</param>
		public void ShowButton(string buttonName)
		{
			StackBarButton button = GetButtonByName(buttonName);
			button.Visible = true;
			ResizeButtonStack(ButtonStackHeight);
			menu_ShowFewerButtons.Enabled = true;
		}
		/// <summary>
		/// Retrieve a StackBarButton from the button's name
		/// </summary>
		/// <param name="buttonName">Name of button</param>
		/// <returns>StackBarButton</returns>
		public StackBarButton GetButtonByName(string buttonName)
		{
			for (int i = 0; i < buttonList.Count; i++)
			{
				if (buttonList[i].Name.Equals(buttonName))
				{
					return buttonList[i];
				}
			}

			return null;
		}
		/// <summary>
		/// Get or Set the hieght available to display buttons on the ButtonStack in pixels. Setting this
		/// property will force a resize of the control
		/// </summary>
		public int ButtonStackHeight
		{
			get
			{
				int height = 0;

				foreach (ToolStripButton b in ButtonStack.Items)
				{
					if (((StackBarButton)b.Tag).Visible)
					{
						height += b.Height;
					}
				}

				return height;
			}
			set { ResizeButtonStack(value); }
		}

	
		/// <summary>
		/// Resize the ButtonStack to the specified height. The stack will resize to show as many buttons
		/// as possible within the alotted hieght
		/// </summary>
		/// <param name="desiredHeight">Final hieght of the ButtonStack</param>
		private void ResizeButtonStack(int desiredHeight)
		{
			if (desiredHeight < 0) desiredHeight = 0;

			this.SuspendLayout();

			while (ButtonStackHeight <= desiredHeight && ButtonStrip.Items.Count > 1) MoveToStack();
			while (ButtonStackHeight > desiredHeight && ButtonStack.Items.Count > 0) MoveToStrip();

			ButtonStack.Height = ButtonStackHeight;
			
			this.ResumeLayout();

			if (ButtonStackHeightChanged != null) ButtonStackHeightChanged(this, EventArgs.Empty);
		}
		/// <summary>
		/// If possible, remove a button from the ButtonStrip and add it to the ButtonStack
		/// </summary>
		private void MoveToStack()
		{
			buttonList.Threshold++;
			ToolStripButton button = buttonList[buttonList.Threshold].Button;
			ButtonStrip.Items.Remove(button);
			button.DisplayStyle = ToolStripItemDisplayStyle.ImageAndText;
			button.ImageAlign = ContentAlignment.MiddleLeft;
			ButtonStack.Items.Add(button);
			UpdateStripMenuButtons();
		}
		/// <summary>
		/// If possible, remove a button fromt the ButtonStack and add it to the ButtonStrip
		/// </summary>
		private void MoveToStrip()
		{
			ToolStripButton button = buttonList[buttonList.Threshold].Button;
			ButtonStack.Items.Remove(button);
			button.DisplayStyle = ToolStripItemDisplayStyle.Image;
			button.ImageAlign = ContentAlignment.MiddleCenter;
			ButtonStrip.Items.Add(button);
			buttonList.Threshold--;
			UpdateStripMenuButtons();
		}
		/// <summary>
		/// Update the ButtonStrip accessability menu
		/// </summary>
		private void UpdateStripMenuButtons()
		{
			if (buttonList.Count > 0) menuAddRemove.Enabled = true;
			else menuAddRemove.Enabled = false;

			menu_ShowFewerButtons.Enabled = false;
			menu_ShowMoreButtons.Enabled = false;

			for (int i = 0; i < buttonList.Count; i++)
			{
				if (i > buttonList.Threshold && buttonList[i].Visible)
				{
					menu_ShowMoreButtons.Enabled = true;	
				}
				else if( buttonList[i].Visible)
				{
					menu_ShowFewerButtons.Enabled = true;
				}
			}
		}
		/// <summary>
		/// Called by nested class ToolStripButtonCollection to add a newly added collection
		/// button to the visible ButtonStack control
		/// </summary>
		/// <param name="button"></param>
		private void AddButton(ToolStripButton button)
		{
			button.Width = this.Width;
			button.Click += new EventHandler(toolStripButton_Click);
			button.MouseMove += new MouseEventHandler(button_MouseMove);
			button.ToolTipText = string.Empty;
			ButtonStack.Items.Add(button);

			((StackBarButton)button.Tag).MenuButton.Click += new System.EventHandler(this.menuAddRemove_Button_Click);
			((StackBarButton)button.Tag).VisibleChanged += new EventHandler(StackBar_VisibleChanged);
			menuAddRemove.DropDownItems.Add(((StackBarButton)button.Tag).MenuButton);

			UpdateStripMenuButtons();
		}
		/// <summary>
		/// Called by nested class ToolStripButtonCollection to remove a button from the
		/// ButtonStack or ButtonStrip
		/// </summary>
		/// <param name="button"></param>
		private void RemoveButton(ToolStripButton button)
		{
			int buttonIndex = buttonList.IndexOf((StackBarButton)button.Tag);

			if (buttonIndex > buttonList.Threshold)
			{
				ButtonStrip.Items.Remove(buttonList[buttonIndex].Button);
			}
			else
			{
				ButtonStack.Items.Remove(buttonList[buttonIndex].Button);
			}

			menuAddRemove.DropDownItems.RemoveByKey(GetMenuButtonNameFromButtonName(button.Name));

			UpdateStripMenuButtons();
		}
		/// <summary>
		/// Called by nested class ToolStripButtonCollection to clear all buttons from both
		/// the ButtonStack and the ButtonStrip
		/// </summary>
		private void ClearButtons()
		{
			ButtonStack.Items.Clear();
			ButtonStrip.Items.Clear();
		}
		/// <summary>
		/// Create a unique button name for the menu button
		/// </summary>
		/// <param name="button"></param>
		private static string GetMenuButtonNameFromButtonName(string buttonName)
		{
			return menuPrePend + buttonName;
		}
	
		/// <summary>
		/// Retrieve the button name from a menu button item
		/// </summary>
		/// <param name="buttonName"></param>
		/// <returns></returns>
		private static string GetButtonNameFromMenuButtonName(string buttonName)
		{
			return buttonName.Substring(menuPrePend.Length);
		}

		private void StackBar_VisibleChanged(object sender, EventArgs e)
		{
			if (ButtonVisibleChanged != null) ButtonVisibleChanged(sender, e);
		}
		private void Bar_MouseDown(object sender, MouseEventArgs e)
		{
			moving = true;
			startPos = new Point(e.X, e.Y);
			startBar = Bar.Location;
			startSize = ButtonStack.Size;
		}
		private void Bar_MouseMove(object sender, MouseEventArgs e)
		{
			if (!moving) return;
		
			int displacement = startPos.Y - (e.Y + Bar.Location.Y - startBar.Y);
			ResizeButtonStack(startSize.Height + displacement);
		}
		private void Bar_MouseUp(object sender, MouseEventArgs e) { moving = false; }
		private void toolStripButton_Click(object sender, EventArgs e)
		{
			StackBarButton senderButton = (StackBarButton)((ToolStripButton)sender).Tag;

			if (senderButton == this.selectedButton)
			{
				// Just need to re-set the checked status
				senderButton.Button.Checked = true;
			}
			else
			{
				foreach (StackBarButton button in buttonList)
				{
					button.Button.Checked = false;
				}

				senderButton.Button.Checked = true;
				selectedButton = senderButton;
				titleLabel.Text = senderButton.Button.Text;

				if (senderButton.NavigationPaneControl != null)
				{
					navigationPanel.SuspendLayout();
					navigationPanel.Controls.Clear();
					navigationPanel.Controls.Add(senderButton.NavigationPaneControl);
					navigationPanel.ResumeLayout();
				}
				
				if (ButtonClicked != null)
				{
					ButtonClicked.Invoke(senderButton, EventArgs.Empty);
				}
			}
		}
		private void menu_ShowMoreButtons_Click(object sender, EventArgs e)
		{
			ResizeButtonStack(ButtonStackHeight + ButtonFormat.StackButtonHeight);
		}
		private void menu_ShowFewerButtons_Click(object sender, EventArgs e)
		{
			ResizeButtonStack(ButtonStackHeight - ButtonFormat.StackButtonHeight/2);
		}
		private void menuAddRemove_Button_Click(object sender, EventArgs e)
		{
			ToolStripMenuItem menuItem = (ToolStripMenuItem)sender;
			menuItem.Checked = !menuItem.Checked;
		
			if (menuItem.Checked)
				ShowButton(GetButtonNameFromMenuButtonName(menuItem.Name));
			else
				HideButton(GetButtonNameFromMenuButtonName(menuItem.Name));

			foreach (StackBarButton b in buttonList)
			{
				if (b.Visible) return;
			}

			menu_ShowFewerButtons.Enabled = false;
		}
		private void button_MouseMove(object sender, MouseEventArgs e)
		{
			Cursor.Current = Cursors.Hand;
		}
	}
}