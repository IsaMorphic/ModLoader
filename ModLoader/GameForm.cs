using System;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace ModLoader
{
    public partial class GameForm : Form
    {
        public string GamePath { get; private set; }
        public string GameName { get; private set; }

        public GameForm()
        {
            InitializeComponent();
        }

        private void FolderBrowseButton_Click(object sender, EventArgs e)
        {
            FolderDialog.ShowDialog();

            if(!Directory.Exists(FolderDialog.SelectedPath))
            {
                MessageBox.Show("The folder you have selected does not exist.  Please select a valid folder.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            try
            {
                GamePath = Directory.Exists(FolderDialog.SelectedPath) ? FolderDialog.SelectedPath :
                        throw new Exception("The user has failed to select a vaild directory.");
                GameName = !string.IsNullOrEmpty(NameEntry.Text) &&
                        !NameEntry.Text.Any(c => Path.GetInvalidFileNameChars().Contains(c)) ?
                         NameEntry.Text : throw new Exception("The user has failed to enter a valid game name. Game names must be a valid file-name on the host system and cannot be empty.");
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message}\n\n{ex.StackTrace}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
