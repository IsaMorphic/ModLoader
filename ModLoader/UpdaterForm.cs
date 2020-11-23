using ModLoader.Core;
using ModLoader.Core.Utilities;
using ModLoader.Properties;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace ModLoader
{
    public partial class UpdaterForm : Form
    {
        private PackUpdater Updater { get; }

        private Game Game => Updater.Pack.Parent;

        public UpdaterForm(Pack pack)
        {
            Updater = new PackUpdater(pack);
            InitializeComponent();
        }

        private void RefreshModuleList()
        {
            var selected = ModuleList.SelectedItem;
            ModuleList.Items.Clear();
            ModuleList.Items.AddRange(Updater.Modules.Values.ToArray());
            ModuleList.SelectedItem = selected;
        }

        private void RefreshMetaData()
        {
            NameEdit.Text = Updater.MetaData.Name;
            AuthorEdit.Text = Updater.MetaData.Author;

            FallbackEdit.Items.Clear();
            FallbackEdit.Items.Add("");
            FallbackEdit.Items.AddRange(Game.Packs.ToArray());

            FallbackEdit.SelectedItem = Game.Packs.SingleOrDefault(p => p.Id == Updater.MetaData.Fallback);

            NotesEdit.Text = Updater.MetaData.Notes;

            using (var stream = Updater.Archive.GetEntry("_pack.png").Open())
                PackImage.Image = Image.FromStream(stream);
        }

        private async void UpdaterForm_Load(object sender, System.EventArgs e)
        {
            Text = $"Editing {Updater.Pack}";

            Width = (int)(Settings.Default.UpdaterAppWidth * Screen.PrimaryScreen.Bounds.Width);
            Height = (int)(Settings.Default.UpdaterAppHeight * Screen.PrimaryScreen.Bounds.Height);

            Top = Screen.PrimaryScreen.Bounds.Y + Screen.PrimaryScreen.Bounds.Height / 2 - Height / 2;
            Left = Screen.PrimaryScreen.Bounds.X + Screen.PrimaryScreen.Bounds.Width / 2 - Width / 2;

            MainPane.SplitterDistance = (int)(Settings.Default.UpdaterMainPanelSplit * MainPane.Width);
            TopPane.SplitterDistance = (int)(Settings.Default.UpdaterTopPanelSplit * TopPane.Width);
            LeftPane.SplitterDistance = (int)(Settings.Default.UpdaterLeftPanelSplit * LeftPane.Height);
            DetailsPane.SplitterDistance = (int)(Settings.Default.UpdaterDetailsPanelSplit * DetailsPane.Height);

            MessageBox.Show("Before updating a pack file, it is wise to make a backup copy!\nAlso, before updating this pack, make sure any test folders of the same name have been moved outside of the Mods directory.\nIf you do not do this, your changes will be overwritten!", "Warning!!!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            await Updater.RevertChangesAsync();
            RefreshModuleList();
            RefreshMetaData();
        }

        private void NameEdit_TextChanged(object sender, System.EventArgs e)
        {
            Updater.MetaData.Name = NameEdit.Text;
        }

        private void AuthorEdit_TextChanged(object sender, System.EventArgs e)
        {
            Updater.MetaData.Author = AuthorEdit.Text;
        }

        private void FallbackEdit_SelectedValueChanged(object sender, System.EventArgs e)
        {
            Updater.MetaData.Fallback = (FallbackEdit.SelectedItem as Pack)?.Id;
        }

        private void NotesEdit_TextChanged(object sender, System.EventArgs e)
        {
            Updater.MetaData.Notes = NotesEdit.Text;
        }

        private async void RevertButton_Click(object sender, System.EventArgs e)
        {
            await Updater.RevertChangesAsync();

            RefreshModuleList();
            RefreshMetaData();
        }

        private async void SaveButton_Click(object sender, System.EventArgs e)
        {
            await Updater.SaveChangesAsync();
            MessageBox.Show("Changes saved!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Close();
        }

        private void RemoveButton_Click(object sender, System.EventArgs e)
        {
            var module = ModuleList.SelectedItem as PackUpdater.Module;
            Updater.Modules[module.Name].Update.Type = PackUpdater.UpdateType.Remove;
            RefreshModuleList();
        }

        private void ReplaceButton_Click(object sender, System.EventArgs e)
        {
            if (FileDialog.ShowDialog() == DialogResult.OK)
            {
                var module = ModuleList.SelectedItem as PackUpdater.Module;
                var update = Updater.Modules[module.Name].Update;

                update.Type = PackUpdater.UpdateType.Replace;
                update.FilePath = FileDialog.FileName;

                RefreshModuleList();
            }
        }

        private void AddButton_Click(object sender, System.EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(ModuleNameEdit.Text) && FileDialog.ShowDialog() == DialogResult.OK)
            {
                var name = ModuleNameEdit.Text;

                var module = new PackUpdater.Module(name);
                var update = module.Update;

                update.Type = PackUpdater.UpdateType.Add;
                update.FilePath = FileDialog.FileName;

                Updater.Modules.Add(name, module);

                ModuleNameEdit.Text = null;
                RefreshModuleList();
            }
            else
            {
                MessageBox.Show("Could not add module to pack.  Please enter a valid module name and make sure to select a file.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void ResetButton_Click(object sender, System.EventArgs e)
        {
            var module = ModuleList.SelectedItem as PackUpdater.Module;
            Updater.Modules[module.Name].Update.Type = PackUpdater.UpdateType.None;
            RefreshModuleList();
        }

        private void PackImage_DoubleClick(object sender, System.EventArgs e)
        {
            var filter = FileDialog.Filter;
            FileDialog.Filter = "PNG Image (.png)|*.png";
            if (FileDialog.ShowDialog() == DialogResult.OK)
            {
                Updater.ImagePath = FileDialog.FileName;
                PackImage.Image = Image.FromFile(Updater.ImagePath);
            }
            FileDialog.Filter = filter;
        }

        private void UpdaterForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Settings.Default.UpdaterMainPanelSplit = (double)MainPane.SplitterDistance / MainPane.Width;
            Settings.Default.UpdaterTopPanelSplit = (double)TopPane.SplitterDistance / TopPane.Width;
            Settings.Default.UpdaterLeftPanelSplit = (double)LeftPane.SplitterDistance / LeftPane.Height;
            Settings.Default.UpdaterDetailsPanelSplit = (double)DetailsPane.SplitterDistance / DetailsPane.Height;

            Settings.Default.Save();

            Updater.Dispose();
        }
    }
}
