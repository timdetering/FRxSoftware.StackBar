using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace FRxSoftware.Common.Controls
{
	/// <summary>
	/// The ButtonFormat class allows the caller to specify how StackBar buttons will appear 
	/// in the UI. All buttons added to the control will use these settings and updating a format
	/// setting will affect all buttons in the StackBar
	/// </summary>
	public class StackBarButtonFormat : IDisposable
	{
		private StackBar.StackBarButtonCollection buttonCollection;
		private Font font;
		private Padding buttonPadding = new Padding(5);
		private int stackButtonHeight = 31;
		private int stripButtonHeight = 22;

		private StackBarButtonFormat() { }
		/// <summary>
		/// The DefaultButtonFormat class can only be instantiated by the StackBar
		/// </summary>
		internal StackBarButtonFormat(StackBar.StackBarButtonCollection collection)
		{
			font = new Font(SystemFonts.DialogFont, FontStyle.Bold);
			buttonCollection = collection;
		}

		/// <summary>
		/// Get or Set the Font used for button text
		/// </summary>
		public Font Font
		{
			get { return font; }
			set
			{
				if (value == null) return;

				if (!value.Bold)
					font = new Font(value, FontStyle.Bold);
				else
					font = value;

				foreach (StackBar.StackBarButton b in buttonCollection)
				{
					b.Button.Font = font;
				}
			}
		}
		/// <summary>
		/// Get or Set the button padding
		/// </summary>
		public Padding ButtonPadding
		{
			get { return buttonPadding; }
			set
			{
				buttonPadding = value;
				foreach (StackBar.StackBarButton b in buttonCollection)
				{
					b.Button.Padding = buttonPadding;
				}
			}
		}
		/// <summary>
		/// Get or Set the StackBar button height
		/// </summary>
		public int StackButtonHeight
		{
			get { return stackButtonHeight; }
			set
			{
				stackButtonHeight = value;

				for (int i = 0; i <= buttonCollection.Threshold; i++)
				{
					buttonCollection[i].Button.Height = stackButtonHeight;
				}
			}
		}
		/// <summary>
		/// Get or Set the StripBar button height
		/// </summary>
		public int StripButtonHeight
		{
			get { return stripButtonHeight; }
			set
			{
				stripButtonHeight = value;

				for (int i = buttonCollection.Threshold + 1; i < buttonCollection.Count; i++)
				{
					buttonCollection[i].Button.Height = stripButtonHeight;
				}
			}
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
					font.Dispose();
				}

				// Clean up any unmanaged resources here
				//
			}

			disposed = true;
		}

		/// <summary>
		/// Destructor
		/// </summary>
		~StackBarButtonFormat()
		{
			Dispose(false);
		}
	}
}
