using ModLoader.Core.Utilities;
using System;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ModLoader
{
    public partial class DiffBuilderForm : Form
    {
        private string origFilePath, modFilePath, outFilePath;

        public DiffBuilderForm()
        {
            InitializeComponent();
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
                modFilePathBox.Text = origFilePath;
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
                var builder = new DiffBuilder(origFilePath, modFilePath);
                await builder.BuildAsync(outFilePath);

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
