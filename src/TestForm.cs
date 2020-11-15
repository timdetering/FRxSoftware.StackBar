using System.Windows.Forms;

namespace StackBar
{
    public partial class TestForm : Form
    {
        public TestForm()
        {
            InitializeComponent();

            // Add three buttons
            //

            this.stackBar1.Items.Add("b1", "Button 1", Properties.Resources.b1.ToBitmap());
            this.stackBar1.Items.Add("b2", "Button 2", Properties.Resources.b2.ToBitmap());
            this.stackBar1.Items.Add("b3", "Button 3", Properties.Resources.b3.ToBitmap());


            this.stackBar1.ButtonStackHeight = 100;
        }
    }
}