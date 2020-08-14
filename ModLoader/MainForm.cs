using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ModLoader
{
    public partial class MainForm : Form
    {
        public PackGroup Mods { get; }

        public MainForm()
        {
            InitializeComponent();
            Mods = new PackGroup(Environment.CurrentDirectory);
        }

        private void RefreshChangeList()
        {
            ChangeList.Items.Clear();
            ChangeList.Items.AddRange(Mods.Resolve().Members.ToArray());
        }

        private void RefreshPackList()
        {
            PackList.Items.Clear();
            PackList.Items.AddRange(Mods.Mergers.ToArray());
        }

        private void SelectPack(Pack pack)
        {
            ModuleList.Items.Clear();

            EnabledCheckBox.Checked = pack.Enabled;

            ModuleList.Items.AddRange(pack.Members.ToArray());

            using (var stream = pack.Archive.GetEntry("_pack.png").Open())
                PackImage.Image = Bitmap.FromStream(stream);

            using (var stream = pack.Archive.GetEntry("_pack.txt").Open())
                PackNotes.Text = new StreamReader(stream).ReadToEnd();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            RefreshPackList();
            RefreshChangeList();
        }

        private void PackList_SelectedIndexChanged(object sender, EventArgs e)
        {
            var pack = PackList.SelectedItem as Pack;
            SelectPack(pack);
        }

        private void EnabledCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            var pack = PackList.SelectedItem as Pack;
            pack.Enabled = EnabledCheckBox.Checked;
            RefreshChangeList();
        }

        private void ConflictList_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            (ConflictList.Items[e.Index] as Module).Enabled = e.NewValue == CheckState.Checked;
            RefreshChangeList();
        }

        private void ChangeList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ChangeList.SelectedIndex < 0) return;

            var conflict = ChangeList.SelectedItem as Conflict<Module>;

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
        }
    }
}
