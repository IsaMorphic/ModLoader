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
        private MainForm Form { get; }

        public LoaderForm(MainForm form)
        {
            Form = form;
            InitializeComponent();
        }

        private async void FormLoad(object sender, EventArgs e)
        {
            try
            {
                var mods = new Game(Environment.CurrentDirectory);
                var dirs = Directory.GetDirectories(mods.ModPath);

                foreach (var dir in dirs)
                {
                    await new PackBuilder(dir, Path.GetFileName(dir))
                        .WithBitmap(new Image<Rgba32>(100, 100))
                        .WithNote("Your mod pack (under construction)")
                        .BuildAsync();
                }

                await mods.InitializeAsync();

                Form.Game = mods;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message}\n\n{ex.StackTrace}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Close();
            }
        }
    }
}
