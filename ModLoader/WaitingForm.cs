using System.Windows.Forms;

namespace ModLoader
{
    public partial class WaitingForm : Form
    {
        public WaitingForm(string message)
        {
            InitializeComponent();
            label1.Text = message;
        }
    }
}
