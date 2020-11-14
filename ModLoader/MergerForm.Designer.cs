using ModLoader.Core.Abstract;

namespace ModLoader
{
    partial class MergerForm<T>
        where T : Xunk<T>
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.TextBox = new System.Windows.Forms.RichTextBox();
            this.ConflictList = new System.Windows.Forms.CheckedListBox();
            this.ConflictGroup = new System.Windows.Forms.GroupBox();
            this.ChangeList = new System.Windows.Forms.CheckedListBox();
            this.ChangeGroup = new System.Windows.Forms.GroupBox();
            this.ContentGroup = new System.Windows.Forms.GroupBox();
            this.ModuleGroup = new System.Windows.Forms.GroupBox();
            this.ModuleList = new System.Windows.Forms.CheckedListBox();
            this.MemberGroup = new System.Windows.Forms.GroupBox();
            this.MemberList = new System.Windows.Forms.CheckedListBox();
            this.TopPane = new System.Windows.Forms.SplitContainer();
            this.BottomPane = new System.Windows.Forms.SplitContainer();
            this.MainPane = new System.Windows.Forms.SplitContainer();
            this.LeftPane = new System.Windows.Forms.SplitContainer();
            this.ConflictGroup.SuspendLayout();
            this.ChangeGroup.SuspendLayout();
            this.ContentGroup.SuspendLayout();
            this.ModuleGroup.SuspendLayout();
            this.MemberGroup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TopPane)).BeginInit();
            this.TopPane.Panel1.SuspendLayout();
            this.TopPane.Panel2.SuspendLayout();
            this.TopPane.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BottomPane)).BeginInit();
            this.BottomPane.Panel1.SuspendLayout();
            this.BottomPane.Panel2.SuspendLayout();
            this.BottomPane.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MainPane)).BeginInit();
            this.MainPane.Panel1.SuspendLayout();
            this.MainPane.Panel2.SuspendLayout();
            this.MainPane.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.LeftPane)).BeginInit();
            this.LeftPane.Panel1.SuspendLayout();
            this.LeftPane.Panel2.SuspendLayout();
            this.LeftPane.SuspendLayout();
            this.SuspendLayout();
            // 
            // TextBox
            // 
            this.TextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TextBox.Font = new System.Drawing.Font("Lucida Console", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.TextBox.Location = new System.Drawing.Point(6, 42);
            this.TextBox.Margin = new System.Windows.Forms.Padding(6);
            this.TextBox.Name = "TextBox";
            this.TextBox.Size = new System.Drawing.Size(1031, 1010);
            this.TextBox.TabIndex = 1;
            this.TextBox.Text = "Select a member from the list(s) to view its contents...";
            // 
            // ConflictList
            // 
            this.ConflictList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ConflictList.FormattingEnabled = true;
            this.ConflictList.HorizontalScrollbar = true;
            this.ConflictList.IntegralHeight = false;
            this.ConflictList.Location = new System.Drawing.Point(6, 42);
            this.ConflictList.Margin = new System.Windows.Forms.Padding(6);
            this.ConflictList.Name = "ConflictList";
            this.ConflictList.Size = new System.Drawing.Size(333, 480);
            this.ConflictList.TabIndex = 3;
            this.ConflictList.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.ListItemCheck);
            this.ConflictList.SelectedIndexChanged += new System.EventHandler(this.ListSelectedIndexChanged);
            // 
            // ConflictGroup
            // 
            this.ConflictGroup.Controls.Add(this.ConflictList);
            this.ConflictGroup.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ConflictGroup.Location = new System.Drawing.Point(0, 0);
            this.ConflictGroup.Margin = new System.Windows.Forms.Padding(6);
            this.ConflictGroup.Name = "ConflictGroup";
            this.ConflictGroup.Padding = new System.Windows.Forms.Padding(6);
            this.ConflictGroup.Size = new System.Drawing.Size(345, 528);
            this.ConflictGroup.TabIndex = 4;
            this.ConflictGroup.TabStop = false;
            this.ConflictGroup.Text = "Conflict";
            // 
            // ChangeList
            // 
            this.ChangeList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ChangeList.FormattingEnabled = true;
            this.ChangeList.HorizontalScrollbar = true;
            this.ChangeList.IntegralHeight = false;
            this.ChangeList.Location = new System.Drawing.Point(6, 42);
            this.ChangeList.Margin = new System.Windows.Forms.Padding(6);
            this.ChangeList.Name = "ChangeList";
            this.ChangeList.Size = new System.Drawing.Size(333, 478);
            this.ChangeList.TabIndex = 2;
            this.ChangeList.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.ListItemCheck);
            this.ChangeList.SelectedIndexChanged += new System.EventHandler(this.ListSelectedIndexChanged);
            // 
            // ChangeGroup
            // 
            this.ChangeGroup.Controls.Add(this.ChangeList);
            this.ChangeGroup.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ChangeGroup.Location = new System.Drawing.Point(0, 0);
            this.ChangeGroup.Margin = new System.Windows.Forms.Padding(6);
            this.ChangeGroup.Name = "ChangeGroup";
            this.ChangeGroup.Padding = new System.Windows.Forms.Padding(6);
            this.ChangeGroup.Size = new System.Drawing.Size(345, 526);
            this.ChangeGroup.TabIndex = 5;
            this.ChangeGroup.TabStop = false;
            this.ChangeGroup.Text = "Changes";
            // 
            // ContentGroup
            // 
            this.ContentGroup.Controls.Add(this.TextBox);
            this.ContentGroup.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ContentGroup.Location = new System.Drawing.Point(0, 0);
            this.ContentGroup.Margin = new System.Windows.Forms.Padding(6);
            this.ContentGroup.Name = "ContentGroup";
            this.ContentGroup.Padding = new System.Windows.Forms.Padding(6);
            this.ContentGroup.Size = new System.Drawing.Size(1043, 1058);
            this.ContentGroup.TabIndex = 6;
            this.ContentGroup.TabStop = false;
            this.ContentGroup.Text = "Contents";
            // 
            // ModuleGroup
            // 
            this.ModuleGroup.Controls.Add(this.ModuleList);
            this.ModuleGroup.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ModuleGroup.Location = new System.Drawing.Point(0, 0);
            this.ModuleGroup.Margin = new System.Windows.Forms.Padding(6);
            this.ModuleGroup.Name = "ModuleGroup";
            this.ModuleGroup.Padding = new System.Windows.Forms.Padding(6);
            this.ModuleGroup.Size = new System.Drawing.Size(174, 526);
            this.ModuleGroup.TabIndex = 6;
            this.ModuleGroup.TabStop = false;
            this.ModuleGroup.Text = "Modules";
            // 
            // ModuleList
            // 
            this.ModuleList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ModuleList.FormattingEnabled = true;
            this.ModuleList.HorizontalScrollbar = true;
            this.ModuleList.IntegralHeight = false;
            this.ModuleList.Location = new System.Drawing.Point(6, 42);
            this.ModuleList.Margin = new System.Windows.Forms.Padding(6);
            this.ModuleList.Name = "ModuleList";
            this.ModuleList.Size = new System.Drawing.Size(162, 478);
            this.ModuleList.TabIndex = 2;
            this.ModuleList.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.ListItemCheck);
            this.ModuleList.SelectedIndexChanged += new System.EventHandler(this.ListSelectedIndexChanged);
            // 
            // MemberGroup
            // 
            this.MemberGroup.Controls.Add(this.MemberList);
            this.MemberGroup.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MemberGroup.Location = new System.Drawing.Point(0, 0);
            this.MemberGroup.Margin = new System.Windows.Forms.Padding(6);
            this.MemberGroup.Name = "MemberGroup";
            this.MemberGroup.Padding = new System.Windows.Forms.Padding(6);
            this.MemberGroup.Size = new System.Drawing.Size(174, 528);
            this.MemberGroup.TabIndex = 7;
            this.MemberGroup.TabStop = false;
            this.MemberGroup.Text = "Members";
            // 
            // MemberList
            // 
            this.MemberList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MemberList.FormattingEnabled = true;
            this.MemberList.HorizontalScrollbar = true;
            this.MemberList.IntegralHeight = false;
            this.MemberList.Location = new System.Drawing.Point(6, 42);
            this.MemberList.Margin = new System.Windows.Forms.Padding(6);
            this.MemberList.Name = "MemberList";
            this.MemberList.Size = new System.Drawing.Size(162, 480);
            this.MemberList.TabIndex = 2;
            this.MemberList.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.ListItemCheck);
            this.MemberList.SelectedIndexChanged += new System.EventHandler(this.ListSelectedIndexChanged);
            // 
            // TopPane
            // 
            this.TopPane.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TopPane.Location = new System.Drawing.Point(0, 0);
            this.TopPane.Name = "TopPane";
            // 
            // TopPane.Panel1
            // 
            this.TopPane.Panel1.Controls.Add(this.ModuleGroup);
            // 
            // TopPane.Panel2
            // 
            this.TopPane.Panel2.Controls.Add(this.ChangeGroup);
            this.TopPane.Size = new System.Drawing.Size(523, 526);
            this.TopPane.SplitterDistance = 174;
            this.TopPane.TabIndex = 8;
            // 
            // BottomPane
            // 
            this.BottomPane.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BottomPane.Location = new System.Drawing.Point(0, 0);
            this.BottomPane.Name = "BottomPane";
            // 
            // BottomPane.Panel1
            // 
            this.BottomPane.Panel1.Controls.Add(this.MemberGroup);
            // 
            // BottomPane.Panel2
            // 
            this.BottomPane.Panel2.Controls.Add(this.ConflictGroup);
            this.BottomPane.Size = new System.Drawing.Size(523, 528);
            this.BottomPane.SplitterDistance = 174;
            this.BottomPane.TabIndex = 9;
            // 
            // MainPane
            // 
            this.MainPane.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainPane.Location = new System.Drawing.Point(0, 0);
            this.MainPane.Name = "MainPane";
            // 
            // MainPane.Panel1
            // 
            this.MainPane.Panel1.Controls.Add(this.LeftPane);
            // 
            // MainPane.Panel2
            // 
            this.MainPane.Panel2.Controls.Add(this.ContentGroup);
            this.MainPane.Size = new System.Drawing.Size(1570, 1058);
            this.MainPane.SplitterDistance = 523;
            this.MainPane.TabIndex = 10;
            // 
            // LeftPane
            // 
            this.LeftPane.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LeftPane.Location = new System.Drawing.Point(0, 0);
            this.LeftPane.Name = "LeftPane";
            this.LeftPane.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // LeftPane.Panel1
            // 
            this.LeftPane.Panel1.Controls.Add(this.TopPane);
            // 
            // LeftPane.Panel2
            // 
            this.LeftPane.Panel2.Controls.Add(this.BottomPane);
            this.LeftPane.Size = new System.Drawing.Size(523, 1058);
            this.LeftPane.SplitterDistance = 526;
            this.LeftPane.TabIndex = 11;
            // 
            // MergerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(15F, 37F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1570, 1058);
            this.Controls.Add(this.MainPane);
            this.Margin = new System.Windows.Forms.Padding(9, 10, 9, 10);
            this.Name = "MergerForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Merge Modules";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MergerForm_FormClosing);
            this.Load += new System.EventHandler(this.FormLoad);
            this.ConflictGroup.ResumeLayout(false);
            this.ChangeGroup.ResumeLayout(false);
            this.ContentGroup.ResumeLayout(false);
            this.ModuleGroup.ResumeLayout(false);
            this.MemberGroup.ResumeLayout(false);
            this.TopPane.Panel1.ResumeLayout(false);
            this.TopPane.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.TopPane)).EndInit();
            this.TopPane.ResumeLayout(false);
            this.BottomPane.Panel1.ResumeLayout(false);
            this.BottomPane.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.BottomPane)).EndInit();
            this.BottomPane.ResumeLayout(false);
            this.MainPane.Panel1.ResumeLayout(false);
            this.MainPane.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.MainPane)).EndInit();
            this.MainPane.ResumeLayout(false);
            this.LeftPane.Panel1.ResumeLayout(false);
            this.LeftPane.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.LeftPane)).EndInit();
            this.LeftPane.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox TextBox;
        private System.Windows.Forms.CheckedListBox ConflictList;
        private System.Windows.Forms.GroupBox ConflictGroup;
        private System.Windows.Forms.CheckedListBox ChangeList;
        private System.Windows.Forms.GroupBox ChangeGroup;
        private System.Windows.Forms.GroupBox ContentGroup;
        private System.Windows.Forms.GroupBox ModuleGroup;
        private System.Windows.Forms.CheckedListBox ModuleList;
        private System.Windows.Forms.GroupBox MemberGroup;
        private System.Windows.Forms.CheckedListBox MemberList;
        private System.Windows.Forms.SplitContainer TopPane;
        private System.Windows.Forms.SplitContainer BottomPane;
        private System.Windows.Forms.SplitContainer MainPane;
        private System.Windows.Forms.SplitContainer LeftPane;
    }
}

