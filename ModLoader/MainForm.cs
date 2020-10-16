using ModLoader.Core;
using ModLoader.Core.Abstract;
using ModLoader.Core.Utilities;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ModLoader
{
    public partial class MainForm : Form
    {
        private bool Refreshing { get; set; }

        private Game Game { get; }

        public MainForm(Game game)
        {
            InitializeComponent();
            Game = game;
        }

        private void RefreshChangeList()
        {
            Refreshing = true;
            var item = ChangeList.SelectedItem;

            ChangeList.Items.Clear();
            ChangeList.Items.AddRange(Game.Modules.Resolve().Members.ToArray());

            ChangeList.SelectedItem = item;

            Refreshing = false;
        }

        private void RefreshModuleList()
        {
            Refreshing = true;
            var item = ModuleList.SelectedItem;

            ModuleList.Items.Clear();

            var pack = PackList.SelectedItem as Pack;

            if (pack != null)
            {
                ModuleList.Items.AddRange(pack.Members.ToArray());
                for (int i = 0; i < ModuleList.Items.Count; i++)
                {
                    var state = (ModuleList.Items[i] as Module).Enabled;
                    ModuleList.SetItemChecked(i, state);
                }
            }

            ModuleList.SelectedItem = item;
            Refreshing = false;
        }

        private void RefreshPackList()
        {
            Refreshing = true;
            var item = PackList.SelectedItem;

            PackList.Items.Clear();
            PackList.Items.AddRange(Game.Packs.ToArray());

            for (int i = 0; i < PackList.Items.Count; i++)
            {
                var state = (PackList.Items[i] as Pack).Enabled;
                PackList.SetItemChecked(i, state);
            }

            FallbackSelect.Items.Clear();
            FallbackSelect.Items.Add("");
            FallbackSelect.Items.AddRange(Game.Packs.ToArray());

            PackList.SelectedItem = item;
            Refreshing = false;
        }

        private void RefreshConflictPane(Conflict<Module> conflict)
        {
            Refreshing = true;

            ConflictList.Items.Clear();

            if (conflict != null)
            {
                ConflictList.Items.Add(conflict.Instigator);
                ConflictList.Items.AddRange(conflict.Conflictors.ToArray());
                for (int i = 0; i < ConflictList.Items.Count; i++)
                {
                    var state = (ConflictList.Items[i] as Module).Enabled;
                    ConflictList.SetItemChecked(i, state);
                }
            }

            Refreshing = false;
        }

        private async Task RebuildPacksAsync()
        {
            var dirs = Directory.GetDirectories(Game.ModPath);

            var stream = System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("ModLoader.Resources.UnderDevPack.png");
            foreach (var dir in dirs)
            {
                await new PackBuilder(dir, Path.GetFileName(dir))
                    .WithImageStream(stream)
                    .WithNote("This is a generated test pack. Once you're ready to ship your mod, go to Build->Pack and follow the steps!")
                    .BuildAsync();
            }

        }

        private async void MainForm_Load(object sender, EventArgs e)
        {
            Hide();

            var waiter = new WaitingForm("Loading game...");
            waiter.Show();

            try
            {
                await RebuildPacksAsync();

                await Game.ReloadAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message}\n\n{ex.StackTrace}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Close();
                return;
            }

            waiter.Hide();

            Show();

            RefreshPackList();
            RefreshChangeList();
        }

        private void PackList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Refreshing || PackList.SelectedItem == null)
            {
                PropGroup.Enabled = false;
                return;
            }

            PropGroup.Enabled = true;

            var pack = PackList.SelectedItem as Pack;

            EnabledCheckBox.Checked = pack.Enabled;
            FallbackSelect.SelectedItem = pack.Fallback;

            RefreshModuleList();

            if (pack.Enabled)
            {
                PackImage.Image?.Dispose();

                using (var stream = pack.Archive.GetEntry("_pack.png").Open())
                    PackImage.Image = Image.FromStream(stream);

                using (var stream = pack.Archive.GetEntry("_pack.txt").Open())
                    PackNotes.Text = new StreamReader(stream).ReadToEnd();
            }
            else
            {
                using (var stream = System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("ModLoader.Resources.UnloadedPack.png"))
                    PackImage.Image = Image.FromStream(stream);
                PackNotes.Text = "This pack is unloaded. Re-enable it to see more details!";
            }
        }

        private void ChangeList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ChangeList.SelectedItem is Conflict<Module>)
            {
                var conflict = ChangeList.SelectedItem as Conflict<Module>;
                RefreshConflictPane(conflict);
            }
            else
            {
                if (Refreshing) return;

                if (ChangeList.SelectedItem is XunkGroup<Hunk>)
                {
                    var merger = ChangeList.SelectedItem as XunkMerger<Hunk>;
                    if (merger == null)
                        merger = new XunkMerger<Hunk>(null, null, null, new HashSet<XunkGroup<Hunk>>
                    { ChangeList.SelectedItem as XunkGroup<Hunk> });
                    new MergerForm<Hunk>(merger).ShowDialog();

                    RefreshModuleList();
                    RefreshChangeList();
                }
                else if (ChangeList.SelectedItem is XunkGroup<Chunk>)
                {
                    var merger = ChangeList.SelectedItem as XunkMerger<Chunk>;
                    if (merger == null)
                        merger = new XunkMerger<Chunk>(null, null, null, new HashSet<XunkGroup<Chunk>>
                    { ChangeList.SelectedItem as XunkGroup<Chunk> });
                    new MergerForm<Chunk>(merger).ShowDialog();
                }
            }
        }

        private void PackList_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            var pack = PackList.SelectedItem as Pack;
            if (pack == null) return;

            try
            {
                pack.Enabled = e.NewValue == CheckState.Checked;
            }
            catch (Exception)
            {
                MessageBox.Show("An unexpected error occured while toggling this pack. Please verify that the pack file still exists.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            RefreshChangeList();
            RefreshModuleList();
        }

        private void ModuleList_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            ((sender as CheckedListBox).Items[e.Index] as Module).Enabled = e.NewValue == CheckState.Checked;
            if (!Refreshing)
            {
                RefreshChangeList();

                if (sender != ModuleList)
                    RefreshModuleList();
            }
        }

        private async void LoadButton_Click(object sender, EventArgs e)
        {
            try
            {
                LoadButton.Enabled = false;
                RunGameButton.Enabled = false;
                LoadButton.Text = "Loading mods...";

                await Game.ReloadBaseModulesAsync(CancellationToken.None);
                await Game.LoadModulesAsync(CancellationToken.None);
                await Game.SaveConfigAsync();
                await Game.SaveGraphAsync();

                await Game.ExecuteLoadScript();

                MessageBox.Show("Load operation completed successfully!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message}\n\n{ex.StackTrace}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                LoadButton.Enabled = true;
                RunGameButton.Enabled = true;
                LoadButton.Text = "Load All Mods";
            }
        }

        private async void RunGameButton_Click(object sender, EventArgs e)
        {
            LoadButton.Enabled = false;
            RunGameButton.Enabled = false;
            RunGameButton.Text = "Game is running...";

            try
            {
                await Game.RunGameAsync();
            }
            catch (Exception)
            {
                MessageBox.Show("Could not auto-launch game, make sure there is only one .exe file in the game directory", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            LoadButton.Enabled = true;
            RunGameButton.Enabled = true;
            RunGameButton.Text = "Launch Game";
        }

        private void FallbackSelect_SelectedIndexChanged(object sender, EventArgs e)
        {
            var pack = PackList.SelectedItem as Pack;

            pack.Fallback = FallbackSelect.SelectedItem as Pack;

            RefreshChangeList();
        }

        private async void RebuildButton_Click(object sender, EventArgs e)
        {
            Hide();

            var waiter = new WaitingForm("Reloading game...");
            waiter.Show();

            try
            {
                await Game.ReloadAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message}\n\n{ex.StackTrace}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Close();
                return;
            }

            waiter.Hide();

            Show();

            RefreshPackList();
            RefreshModuleList();
            RefreshChangeList();
        }

        private void OpenModsButton_Click(object sender, EventArgs e)
        {
            Process.Start("explorer.exe", Game.ModPath);
        }

        private void BuildPackButton_Click(object sender, EventArgs e)
        {
            new PackForm().ShowDialog();
        }

        private void BuildPatchButton_Click(object sender, EventArgs e)
        {
            new PatchForm().ShowDialog();
        }

        private async void ImportModButton_Click(object sender, EventArgs e)
        {
            if (ImportFileDialog.ShowDialog() == DialogResult.OK)
            {
                string fileName = Path.GetFileName(ImportFileDialog.FileName);
                string destPath = Path.Combine(Game.ModPath, fileName);

                await Task.Run(() => File.Move(ImportFileDialog.FileName, destPath));

                await Game.ReloadAsync();

                RefreshPackList();
                RefreshChangeList();
            }
        }
    }
}
