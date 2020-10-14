using ModLoader.Core;
using ModLoader.Core.Utilities;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;
using System;
using System.IO;
using System.Windows.Forms;

namespace ModLoader
{
    public partial class LoaderForm : Form
    {
        private Game Game { get; }

        public Exception Error { get; private set; }

        public LoaderForm(Game game)
        {
            InitializeComponent();
            Game = game;
        }

        private async void FormLoad(object sender, EventArgs e)
        {
            try
            {
                var dirs = Directory.GetDirectories(Game.ModPath);
                foreach (var dir in dirs)
                {
                    await new PackBuilder(dir, Path.GetFileName(dir))
                        .WithBitmap(new Image<Rgba32>(100, 100))
                        .WithNote("Your mod pack (under construction)")
                        .BuildAsync();
                }

                await Game.LoadAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message}\n\n{ex.StackTrace}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Error = ex;
            }
            finally
            {
                Close();
            }
        }
    }
}
