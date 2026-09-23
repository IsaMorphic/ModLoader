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
            label1.Text = $"ModLoader v{GetType().Assembly.GetName().Version}";
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var info = new ProcessStartInfo
            {
                FileName = "https://www.chosenfewsoftware.com/",
                UseShellExecute = true
            };
            Process.Start(info);
        }
    }
}
