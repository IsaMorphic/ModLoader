using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
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
            var mods = new PackGroup(Environment.CurrentDirectory);
            var dirs = Directory.GetDirectories(mods.ModPath);

            foreach (var dir in dirs)
            {
                await PackBuilder
                    .FromDirectory(dir)
                    .WithBitmap(new Bitmap(100, 100))
                    .WithNote("Mod Packaging Test")
                    .WithName(Path.GetFileName(dir))
                    .BuildAsync();
            }

            await mods.InitializeAsync();

            Form.Mods = mods;

            Close();
        }
    }
}
