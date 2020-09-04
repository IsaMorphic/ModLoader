using ModLoader.Core;
using ModLoader.Core.Abstract;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

namespace ModLoader
{
    public partial class MainForm : Form
    {
        private bool Refreshing { get; set; }

        public Game Game { get; set; }

        public MainForm()
        {
            InitializeComponent();
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

        private void MainForm_Load(object sender, EventArgs e)
        {
            Hide();
            new LoaderForm(this).ShowDialog();
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

            using (var stream = pack.Archive.GetEntry("_pack.png").Open())
                PackImage.Image = Bitmap.FromStream(stream);

            using (var stream = pack.Archive.GetEntry("_pack.txt").Open())
                PackNotes.Text = new StreamReader(stream).ReadToEnd();
        }

        private void ChangeList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ChangeList.SelectedItem is Conflict<Module>)
            {
                var conflict = ChangeList.SelectedItem as Conflict<Module>;
                RefreshConflictPane(conflict);
            }
            else if (ChangeList.SelectedItem is XunkGroup<Hunk>)
            {
                var merger = ChangeList.SelectedItem as XunkMerger<Hunk>;
                if (merger == null)
                    merger = new XunkMerger<Hunk>(null, null, null, new HashSet<XunkGroup<Hunk>>
                    { ChangeList.SelectedItem as XunkGroup<Hunk> });
                new MergerForm<Hunk>(merger).ShowDialog();
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

        private void PackList_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            var pack = PackList.SelectedItem as Pack;
            if (pack == null) return;

            pack.Enabled = e.NewValue == CheckState.Checked;

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
        }

        private void FallbackSelect_SelectedIndexChanged(object sender, EventArgs e)
        {
            var pack = PackList.SelectedItem as Pack;

            pack.Fallback = FallbackSelect.SelectedItem as Pack;

            RefreshChangeList();
        }

        private void RebuildButton_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }
    }
}
