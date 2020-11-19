using ModLoader.Core;
using ModLoader.Core.Abstract;
using ModLoader.Properties;
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
            ChangeList.Items.AddRange(Game.Modules.ResolveSelf().Members.ToArray());

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

        private async void MainForm_Load(object sender, EventArgs e)
        {
            BeginInvoke((Action)Hide);

            Width = (int)(Settings.Default.LoaderAppWidth * Screen.PrimaryScreen.Bounds.Width);
            Height = (int)(Settings.Default.LoaderAppHeight * Screen.PrimaryScreen.Bounds.Height);

            Top = Screen.PrimaryScreen.Bounds.Y + Screen.PrimaryScreen.Bounds.Height / 2 - Height / 2;
            Left = Screen.PrimaryScreen.Bounds.X + Screen.PrimaryScreen.Bounds.Width / 2 - Width / 2;

            MainPane.SplitterDistance = (int)(Settings.Default.LoaderMainPanelSplit * MainPane.Height);
            TopPane.SplitterDistance = (int)(Settings.Default.LoaderTopPanelSplit * TopPane.Width);
            BottomPane.SplitterDistance = (int)(Settings.Default.LoaderBottomPanelSplit * BottomPane.Width);
            PacksPane.SplitterDistance = (int)(Settings.Default.LoaderPacksPanelSplit * PacksPane.Width);
            DetailsPane.SplitterDistance = (int)(Settings.Default.LoaderDetailsPanelSplit * DetailsPane.Height);
            OtherPane.SplitterDistance = (int)(Settings.Default.LoaderOtherPanelSplit * OtherPane.Height);
            PropActionPane.SplitterDistance = (int)(Settings.Default.LoaderPropActionPanelSplit * PropActionPane.Width);

            var waiter = new WaitingForm();
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
            finally
            {
                waiter.Hide();
            }

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

                if (ChangeList.SelectedItem is XunkGroup<Hunk> || ChangeList.SelectedItem is XunkMerger<Hunk>)
                {
                    var merger = ChangeList.SelectedItem as XunkMerger<Hunk>;
                    if (merger == null)
                        merger = new XunkMerger<Hunk>(null, new HashSet<IPotential<Module>>
                    { ChangeList.SelectedItem as XunkGroup<Hunk> });
                    new MergerForm<Hunk>(merger).ShowDialog();

                    RefreshModuleList();
                    RefreshChangeList();
                }
                else if (ChangeList.SelectedItem is XunkGroup<Chunk> || ChangeList.SelectedItem is XunkMerger<Chunk>)
                {
                    var merger = ChangeList.SelectedItem as XunkMerger<Chunk>;
                    if (merger == null)
                        merger = new XunkMerger<Chunk>(null, new HashSet<IPotential<Module>>
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

            var waiter = new WaitingForm();
            waiter.Show();

            try
            {
                await Game.ReloadAsync();
                waiter.Hide();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message}\n\n{ex.StackTrace}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                waiter.Hide();
                Close();
                return;
            }

            Show();

            RefreshPackList();
            RefreshModuleList();
            RefreshChangeList();
        }

        private void OpenGameButton_Click(object sender, EventArgs e)
        {
            Process.Start("explorer.exe", Game.GamePath);
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

        private async void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Settings.Default.LoaderAppWidth = (double)Width / Screen.PrimaryScreen.Bounds.Width;
            Settings.Default.LoaderAppHeight = (double)Height / Screen.PrimaryScreen.Bounds.Height;

            Settings.Default.LoaderMainPanelSplit = (double)MainPane.SplitterDistance / MainPane.Height;
            Settings.Default.LoaderTopPanelSplit = (double)TopPane.SplitterDistance / TopPane.Width;
            Settings.Default.LoaderBottomPanelSplit = (double)BottomPane.SplitterDistance / BottomPane.Width;
            Settings.Default.LoaderPacksPanelSplit = (double)PacksPane.SplitterDistance / PacksPane.Width;
            Settings.Default.LoaderDetailsPanelSplit = (double)DetailsPane.SplitterDistance / DetailsPane.Height;
            Settings.Default.LoaderOtherPanelSplit = (double)OtherPane.SplitterDistance / OtherPane.Height;
            Settings.Default.LoaderPropActionPanelSplit = (double)PropActionPane.SplitterDistance / PropActionPane.Width;

            Settings.Default.Save();

            await Game.UnloadAsync();
        }

        private void AboutButton_Click(object sender, EventArgs e)
        {
            new AboutForm().ShowDialog();
        }
    }
}
