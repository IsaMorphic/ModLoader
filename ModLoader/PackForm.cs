using ModLoader.Core;
using ModLoader.Core.Utilities;
using System;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace ModLoader
{
    public partial class PackForm : Form
    {
        private Stream ImageStream { get; set; }

        public PackForm()
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

        private void ImageBrowseButton_Click(object sender, EventArgs e)
        {
            ImageDialog.ShowDialog();

            try
            {
                ImageStream = File.OpenRead(ImageDialog.FileName);
            }
            catch (Exception)
            {
                MessageBox.Show("The image you've selected either does not exist or is in an unknown format. Please select a valid image file.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private async void BuildButton_Click(object sender, EventArgs e)
        {
            try
            {
                var meta = new Pack.Meta(Guid.NewGuid(), null, NameEntry.Text, "ModLoader", NoteEntry.Text);
                await new PackBuilder(
                        Directory.Exists(FolderDialog.SelectedPath) ? FolderDialog.SelectedPath :
                        throw new Exception("The user has failed to select a vaild directory."),
                        !string.IsNullOrEmpty(NameEntry.Text) &&
                        !NameEntry.Text.Any(c => Path.GetInvalidFileNameChars().Contains(c)) ?
                         NameEntry.Text : throw new Exception("The user has failed to enter a valid pack name. Pack names must be a valid file-name on the host system and cannot be empty."))
                    .WithImageStream(ImageStream ?? throw new Exception("The user has failed to select a valid image file."))
                    .WithMetaData(meta)
                    .BuildAsync();

                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message}\n\n{ex.StackTrace}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
