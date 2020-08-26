using ModLoader.Core.Abstract;
using System;
using System.Linq;
using System.Windows.Forms;

namespace ModLoader
{
    public partial class MergerForm<T> : Form
        where T : Xunk<T>
    {
        private bool Refreshing { get; set; }

        private XunkMerger<T> Merger { get; }

        public MergerForm(XunkMerger<T> merger)
        {
            Merger = merger;
            InitializeComponent();
        }

        private void FormLoad(object sender, EventArgs e)
        {
            RefreshMemberList();
        }

        private void RefreshMemberList()
        {
            Refreshing = true;

            var members = Merger.Resolver.Resolve().Members.ToArray();

            MemberList.Items.Clear();
            MemberList.Items.AddRange(members);

            for (int i = 0; i < MemberList.Items.Count; i++)
            {
                MemberList.SetItemChecked(i, (MemberList.Items[i] as IResolvable<T>).Enabled);
            }

            Refreshing = false;
        }

        private void RefreshConflictPane(Conflict<T> conflict)
        {
            Refreshing = true;

            ConflictList.Items.Clear();

            if (conflict == null) return;

            ConflictList.Items.Add(conflict.Instigator);
            ConflictList.Items.AddRange(conflict.Conflictors.ToArray());

            for (int i = 0; i < ConflictList.Items.Count; i++)
            {
                ConflictList.SetItemChecked(i, (ConflictList.Items[i] as IResolvable<T>).Enabled);
            }

            Refreshing = false;
        }

        private void ListSelectedIndexChanged(object sender, EventArgs e)
        {
            var listBox = sender as CheckedListBox;
            var item = listBox.SelectedItem as T;

            if (item == null)
            {
                var conflict = listBox.SelectedItem as Conflict<T>;
                RefreshConflictPane(conflict);
            }
            else
            {
                if (listBox == MemberList)
                    RefreshConflictPane(null);

                TextBox.Lines = item.GetDisplayText();
            }
        }

        private void ListItemCheck(object sender, ItemCheckEventArgs e)
        {
            if (Refreshing) return;

            var listBox = sender as CheckedListBox;

            var item = listBox.Items[e.Index] as T;

            if (item != null)
                item.Enabled = e.NewValue == CheckState.Checked;

            if (listBox == ConflictList)
                RefreshMemberList();
        }
    }
}
