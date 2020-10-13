using ModLoader.Core.Utilities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace ModLoader
{
    public partial class PatchForm : Form
    {
        private Dictionary<object, string> FilePaths { get; }

        public PatchForm()
        {
            InitializeComponent();
            FilePaths = new Dictionary<object, string> 
            {
                { OriginalButton, null },
                { ModdedButton, null },
                { SaveButton, null }
            };
        }

        private void BrowseButton_Click(object sender, EventArgs e)
        {
            FileDialog.ShowDialog();

            if(!File.Exists(FileDialog.FileName))
            {
                MessageBox.Show("The file you have selected does not exist. Please select a valid folder.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            FilePaths[sender] = FileDialog.FileName;
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            SaveDialog.ShowDialog();

            FilePaths[sender] = SaveDialog.FileName;
        }

        private async void BuildButton_Click(object sender, EventArgs e)
        {
            try
            {
                await new PatchBuilder(
                    FilePaths[OriginalButton] ?? throw new Exception("The user has failed to specify a valid path for the \"Original\" file."), 
                    FilePaths[ModdedButton] ?? throw new Exception("The user has failed to specify a valid path for the \"Modded\" file.")
                    ).BuildAsync(
                    FilePaths[SaveButton] ?? throw new Exception("The user has failed to specify a valid path for the \"Output\" file.")
                    );
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message}\n\n{ex.StackTrace}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
