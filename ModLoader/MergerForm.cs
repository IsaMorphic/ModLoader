using ModLoader.Core;
using ModLoader.Core.Abstract;
using ModLoader.Properties;
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

            Width = (int)(Settings.Default.MergerAppWidth * Screen.PrimaryScreen.Bounds.Width);
            Height = (int)(Settings.Default.MergerAppHeight * Screen.PrimaryScreen.Bounds.Height);

            Top = Screen.PrimaryScreen.Bounds.Y + Screen.PrimaryScreen.Bounds.Height / 2 - Height / 2;
            Left = Screen.PrimaryScreen.Bounds.X + Screen.PrimaryScreen.Bounds.Width / 2 - Width / 2;

            MainPane.SplitterDistance = (int)(Settings.Default.MergerMainPanelSplit * MainPane.Width);
            LeftPane.SplitterDistance = (int)(Settings.Default.MergerLeftPanelSplit * LeftPane.Height);
            TopPane.SplitterDistance = (int)(Settings.Default.MergerTopPanelSplit * TopPane.Width);
            BottomPane.SplitterDistance = (int)(Settings.Default.MergerBottomPanelSplit * BottomPane.Width);
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

        private void MergerForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Settings.Default.MergerAppWidth = (double)Width / Screen.PrimaryScreen.Bounds.Width;
            Settings.Default.MergerAppHeight = (double)Height / Screen.PrimaryScreen.Bounds.Height;

            Settings.Default.MergerMainPanelSplit = (double)MainPane.SplitterDistance / MainPane.Width;
            Settings.Default.MergerTopPanelSplit = (double)TopPane.SplitterDistance / TopPane.Width;
            Settings.Default.MergerBottomPanelSplit = (double)BottomPane.SplitterDistance / BottomPane.Width;
            Settings.Default.MergerLeftPanelSplit = (double)LeftPane.SplitterDistance / LeftPane.Height;

            Settings.Default.Save();
        }
    }
}
