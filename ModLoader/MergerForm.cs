using ModLoader.Core;
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
            RefreshModuleList();
            RefreshChangeList();
        }

        private void RefreshModuleList()
        {
            Refreshing = true;

            var modules = Merger.Mergers.ToArray();

            ModuleList.Items.Clear();
            ModuleList.Items.AddRange(modules);

            for (int i = 0; i < ModuleList.Items.Count; i++)
            {
                var state = (ModuleList.Items[i] as Module).Enabled;
                ModuleList.SetItemChecked(i, state);
            }

            Refreshing = false;
        }

        private void RefreshMemberList()
        {
            Refreshing = true;

            var module = ModuleList.SelectedItem as XunkGroup<T>;
            if (module == null)
            {
                Refreshing = false;
                return;
            }

            var members = module.Members.ToArray();

            MemberList.Items.Clear();
            MemberList.Items.AddRange(members);

            for (int i = 0; i < MemberList.Items.Count; i++)
            {
                var state = (MemberList.Items[i] as T).Enabled;
                MemberList.SetItemChecked(i, state);
            }

            Refreshing = false;
        }

        private void RefreshChangeList()
        {
            Refreshing = true;

            var members = Merger.Resolver.Resolve().Members.ToArray();

            ChangeList.Items.Clear();
            ChangeList.Items.AddRange(members);

            for (int i = 0; i < ChangeList.Items.Count; i++)
            {
                var state = (ChangeList.Items[i] as T)?.Enabled;
                ChangeList.SetItemCheckState(i, state.HasValue ? (state.Value ? CheckState.Checked : CheckState.Unchecked) : CheckState.Indeterminate);
            }

            Refreshing = false;
        }

        private void RefreshConflictPane(Conflict<T> conflict)
        {
            Refreshing = true;

            ConflictList.Items.Clear();

            if (conflict == null)
            {
                Refreshing = false;
                return;
            }

            ConflictList.Items.Add(conflict.Instigator);
            ConflictList.Items.AddRange(conflict.Conflictors.ToArray());

            for (int i = 0; i < ConflictList.Items.Count; i++)
            {
                var state = (ConflictList.Items[i] as T).Enabled;
                ConflictList.SetItemChecked(i, state);
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
                if (conflict == null && listBox == ModuleList)
                {
                    RefreshMemberList();
                    RefreshConflictPane(null);
                }
                else
                {
                    RefreshConflictPane(conflict);
                }
            }
            else
            {
                if (listBox != ConflictList)
                    RefreshConflictPane(null);

                TextBox.Lines = item.GetDisplayText();
            }
        }

        private void ListItemCheck(object sender, ItemCheckEventArgs e)
        {
            var listBox = sender as CheckedListBox;

            var item = listBox.Items[e.Index];

            if (item is T)
                (item as T).Enabled = e.NewValue == CheckState.Checked;
            else if (item is Module)
                (item as Module).Enabled = e.NewValue == CheckState.Checked;

            if (!Refreshing)
            {
                if (listBox != MemberList)
                {
                    RefreshMemberList();
                }
                if (listBox != ChangeList)
                {
                    RefreshChangeList();
                }
                if (listBox != ModuleList)
                {
                    RefreshModuleList();
                }
            }
        }
    }
}
