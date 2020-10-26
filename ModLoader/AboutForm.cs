using System.Diagnostics;
using System.Windows.Forms;

namespace ModLoader
{
    public partial class AboutForm : Form
    {
        public string GamePath { get; private set; }
        public string GameName { get; private set; }

        public AboutForm()
        {
            InitializeComponent();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("https://www.chosenfewsoftware.com/");
        }
    }
}
