using ModLoader.Core;
using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace ModLoader
{
    public partial class MainForm : Form
    {
        private bool Refreshing { get; set; }

        public PackGroup Mods { get; set; }

        public MainForm()
        {
            InitializeComponent();
        }

        private void RefreshChangeList()
        {
            Refreshing = true;
            var item = ChangeList.SelectedItem;

            ChangeList.Items.Clear();
            ChangeList.Items.AddRange(Mods.Resolve().Members.ToArray());

            ChangeList.SelectedItem = item;

            RefreshConflictPane(ChangeList.SelectedItem as Conflict<Module>);
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
                    ModuleList.SetItemChecked(i, (ModuleList.Items[i] as Module).Enabled);
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
            PackList.Items.AddRange(Mods.Mergers.ToArray());

            FallbackSelect.Items.Clear();
            FallbackSelect.Items.Add("");
            FallbackSelect.Items.AddRange(Mods.Mergers.ToArray());

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
                ConflictList.Items.AddRange(conflict.Mergers.ToArray());
                for (int i = 0; i < ConflictList.Items.Count; i++)
                {
                    ConflictList.SetItemChecked(i, (ConflictList.Items[i] as Module).Enabled);
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

        private void EnabledCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            var pack = PackList.SelectedItem as Pack;

            pack.Enabled = EnabledCheckBox.Checked;

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

        private void ChangeList_SelectedIndexChanged(object sender, EventArgs e)
        {
            var conflict = ChangeList.SelectedItem as Conflict<Module>;
            RefreshConflictPane(conflict);
        }

        private async void LoadButton_Click(object sender, EventArgs e)
        {
            try
            {
                await Mods.LoadAsync();
                await Mods.ReloadBaseModulesAsync();
                await Mods.SaveConfigAsync();
                await Mods.SaveGraphAsync();

                await Mods.ExecuteLoadScript();

                MessageBox.Show("Load operation completed successfully!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FallbackSelect_SelectedIndexChanged(object sender, EventArgs e)
        {
            var pack = PackList.SelectedItem as Pack;

            pack.Fallback = FallbackSelect.SelectedItem as Pack;

            RefreshChangeList();
        }
    }
}
