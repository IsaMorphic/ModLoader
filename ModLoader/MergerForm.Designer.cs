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
            this.ConflictGroup.SuspendLayout();
            this.ChangeGroup.SuspendLayout();
            this.ContentGroup.SuspendLayout();
            this.ModuleGroup.SuspendLayout();
            this.MemberGroup.SuspendLayout();
            this.SuspendLayout();
            // 
            // TextBox
            // 
            this.TextBox.Font = new System.Drawing.Font("Lucida Console", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TextBox.Location = new System.Drawing.Point(6, 21);
            this.TextBox.Name = "TextBox";
            this.TextBox.Size = new System.Drawing.Size(545, 586);
            this.TextBox.TabIndex = 1;
            this.TextBox.Text = "Select a member from the list(s) to view its contents...";
            // 
            // ConflictList
            // 
            this.ConflictList.FormattingEnabled = true;
            this.ConflictList.HorizontalScrollbar = true;
            this.ConflictList.IntegralHeight = false;
            this.ConflictList.Location = new System.Drawing.Point(6, 21);
            this.ConflictList.Name = "ConflictList";
            this.ConflictList.Size = new System.Drawing.Size(402, 223);
            this.ConflictList.TabIndex = 3;
            this.ConflictList.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.ListItemCheck);
            this.ConflictList.SelectedIndexChanged += new System.EventHandler(this.ListSelectedIndexChanged);
            // 
            // ConflictGroup
            // 
            this.ConflictGroup.Controls.Add(this.ConflictList);
            this.ConflictGroup.Location = new System.Drawing.Point(435, 375);
            this.ConflictGroup.Name = "ConflictGroup";
            this.ConflictGroup.Size = new System.Drawing.Size(414, 254);
            this.ConflictGroup.TabIndex = 4;
            this.ConflictGroup.TabStop = false;
            this.ConflictGroup.Text = "Conflict";
            // 
            // ChangeList
            // 
            this.ChangeList.FormattingEnabled = true;
            this.ChangeList.HorizontalScrollbar = true;
            this.ChangeList.IntegralHeight = false;
            this.ChangeList.Location = new System.Drawing.Point(6, 21);
            this.ChangeList.Name = "ChangeList";
            this.ChangeList.Size = new System.Drawing.Size(402, 325);
            this.ChangeList.TabIndex = 2;
            this.ChangeList.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.ListItemCheck);
            this.ChangeList.SelectedIndexChanged += new System.EventHandler(this.ListSelectedIndexChanged);
            // 
            // ChangeGroup
            // 
            this.ChangeGroup.Controls.Add(this.ChangeList);
            this.ChangeGroup.Location = new System.Drawing.Point(435, 12);
            this.ChangeGroup.Name = "ChangeGroup";
            this.ChangeGroup.Size = new System.Drawing.Size(414, 357);
            this.ChangeGroup.TabIndex = 5;
            this.ChangeGroup.TabStop = false;
            this.ChangeGroup.Text = "Changes";
            // 
            // ContentGroup
            // 
            this.ContentGroup.Controls.Add(this.TextBox);
            this.ContentGroup.Location = new System.Drawing.Point(855, 12);
            this.ContentGroup.Name = "ContentGroup";
            this.ContentGroup.Size = new System.Drawing.Size(557, 617);
            this.ContentGroup.TabIndex = 6;
            this.ContentGroup.TabStop = false;
            this.ContentGroup.Text = "Contents";
            // 
            // ModuleGroup
            // 
            this.ModuleGroup.Controls.Add(this.ModuleList);
            this.ModuleGroup.Location = new System.Drawing.Point(12, 12);
            this.ModuleGroup.Name = "ModuleGroup";
            this.ModuleGroup.Size = new System.Drawing.Size(417, 357);
            this.ModuleGroup.TabIndex = 6;
            this.ModuleGroup.TabStop = false;
            this.ModuleGroup.Text = "Modules";
            // 
            // ModuleList
            // 
            this.ModuleList.FormattingEnabled = true;
            this.ModuleList.HorizontalScrollbar = true;
            this.ModuleList.IntegralHeight = false;
            this.ModuleList.Location = new System.Drawing.Point(6, 21);
            this.ModuleList.Name = "ModuleList";
            this.ModuleList.Size = new System.Drawing.Size(401, 325);
            this.ModuleList.TabIndex = 2;
            this.ModuleList.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.ListItemCheck);
            this.ModuleList.SelectedIndexChanged += new System.EventHandler(this.ListSelectedIndexChanged);
            // 
            // MemberGroup
            // 
            this.MemberGroup.Controls.Add(this.MemberList);
            this.MemberGroup.Location = new System.Drawing.Point(12, 375);
            this.MemberGroup.Name = "MemberGroup";
            this.MemberGroup.Size = new System.Drawing.Size(417, 254);
            this.MemberGroup.TabIndex = 7;
            this.MemberGroup.TabStop = false;
            this.MemberGroup.Text = "Members";
            // 
            // MemberList
            // 
            this.MemberList.FormattingEnabled = true;
            this.MemberList.HorizontalScrollbar = true;
            this.MemberList.IntegralHeight = false;
            this.MemberList.Location = new System.Drawing.Point(6, 21);
            this.MemberList.Name = "MemberList";
            this.MemberList.Size = new System.Drawing.Size(401, 223);
            this.MemberList.TabIndex = 2;
            this.MemberList.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.ListItemCheck);
            this.MemberList.SelectedIndexChanged += new System.EventHandler(this.ListSelectedIndexChanged);
            // 
            // MergerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1421, 637);
            this.Controls.Add(this.MemberGroup);
            this.Controls.Add(this.ModuleGroup);
            this.Controls.Add(this.ContentGroup);
            this.Controls.Add(this.ChangeGroup);
            this.Controls.Add(this.ConflictGroup);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "MergerForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Merge Modules";
            this.Load += new System.EventHandler(this.FormLoad);
            this.ConflictGroup.ResumeLayout(false);
            this.ChangeGroup.ResumeLayout(false);
            this.ContentGroup.ResumeLayout(false);
            this.ModuleGroup.ResumeLayout(false);
            this.MemberGroup.ResumeLayout(false);
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
    }
}

