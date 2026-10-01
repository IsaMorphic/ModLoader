using ModLoader.Core.Utilities;

using System;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ModLoader
{
    public partial class XunkBasedBuilderForm : Form
    {
        private readonly IXunkBasedBuilder builder;

        private string origFilePath, modFilePath, outFilePath;

        public XunkBasedBuilderForm(IXunkBasedBuilder builder)
        {
            this.builder = builder;
            InitializeComponent();

            Text = $"{builder.Name} Builder";
            saveFileDialog.DefaultExt = builder.DefaultExt.TrimStart('.');
            saveFileDialog.Filter = $"ModLoader {builder.Name} Files|*{builder.DefaultExt}";
        }

        private bool IsStateValid() 
        {
            return File.Exists(origFilePath) && File.Exists(modFilePath) && !string.IsNullOrEmpty(outFilePath);
        }

        private void origFileButton_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                origFilePath = openFileDialog.FileName;
                origFilePathBox.Text = origFilePath;
                buildButton.Enabled = IsStateValid();
            }
        }

        private void modFileButton_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                modFilePath = openFileDialog.FileName;
                modFilePathBox.Text = modFilePath;
                buildButton.Enabled = IsStateValid();
            }
        }

        private void outFileButton_Click(object sender, EventArgs e)
        {
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                outFilePath = saveFileDialog.FileName;
                outFilePathBox.Text = outFilePath;
                buildButton.Enabled = IsStateValid();
            }
        }

        private async void buildButton_Click(object sender, EventArgs e)
        {
            try
            {
                await builder.BuildAsync(origFilePath, modFilePath, outFilePath);

                ProcessStartInfo startInfo = new ProcessStartInfo
                {
                    FileName = outFilePath,
                    UseShellExecute = true,
                };

                using (Process process = Process.Start(startInfo))
                {
                    await (process?.WaitForExitAsync() ?? Task.CompletedTask);
                }
            }
            catch (Exception ex) 
            {
                MessageBox.Show($"{ex.Message}\n\n{ex.StackTrace}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
