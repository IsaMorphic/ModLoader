using ModLoader.Core.Utilities;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;
using System;
using System.Windows.Forms;

namespace ModMaker
{
    public partial class PackForm : Form
    {
        public PackForm()
        {
            InitializeComponent();
        }

        private void FolderBrowseButton_Click(object sender, EventArgs e)
        {
            FolderDialog.ShowDialog();
        }

        private void ImageBrowseButton_Click(object sender, EventArgs e)
        {
            ImageDialog.ShowDialog();
        }

        private async void BuildButton_Click(object sender, EventArgs e)
        {
            try
            {
                await PackBuilder
                    .FromDirectory(FolderDialog.SelectedPath)
                    .WithBitmap(await Image.LoadAsync(ImageDialog.FileName))
                    .WithName(NameEntry.Text)
                    .WithNote(NoteEntry.Text)
                    .BuildAsync();

                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message}\n{ex.StackTrace}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
