namespace ModLoader
{
    partial class MainForm
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
            this.ChangeList = new System.Windows.Forms.ListBox();
            this.ModuleGroup = new System.Windows.Forms.GroupBox();
            this.PackGroup = new System.Windows.Forms.GroupBox();
            this.NoteGroup = new System.Windows.Forms.GroupBox();
            this.PackNotes = new System.Windows.Forms.TextBox();
            this.PackList = new System.Windows.Forms.CheckedListBox();
            this.PackImage = new System.Windows.Forms.PictureBox();
            this.PropGroup = new System.Windows.Forms.GroupBox();
            this.EnabledCheckBox = new System.Windows.Forms.CheckBox();
            this.FallbackLabel = new System.Windows.Forms.Label();
            this.FallbackSelect = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.RebuildButton = new System.Windows.Forms.Button();
            this.RunGameButton = new System.Windows.Forms.Button();
            this.LoadButton = new System.Windows.Forms.Button();
            this.ChangeGroup = new System.Windows.Forms.GroupBox();
            this.ConflictList = new System.Windows.Forms.CheckedListBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.ModuleList = new System.Windows.Forms.CheckedListBox();
            this.ModuleGroup.SuspendLayout();
            this.PackGroup.SuspendLayout();
            this.NoteGroup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PackImage)).BeginInit();
            this.PropGroup.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.ChangeGroup.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // ChangeList
            // 
            this.ChangeList.FormattingEnabled = true;
            this.ChangeList.HorizontalScrollbar = true;
            this.ChangeList.IntegralHeight = false;
            this.ChangeList.ItemHeight = 16;
            this.ChangeList.Location = new System.Drawing.Point(8, 23);
            this.ChangeList.Margin = new System.Windows.Forms.Padding(5);
            this.ChangeList.Name = "ChangeList";
            this.ChangeList.Size = new System.Drawing.Size(286, 395);
            this.ChangeList.TabIndex = 1;
            this.ChangeList.SelectedIndexChanged += new System.EventHandler(this.ChangeList_SelectedIndexChanged);
            // 
            // ModuleGroup
            // 
            this.ModuleGroup.Controls.Add(this.ChangeList);
            this.ModuleGroup.Location = new System.Drawing.Point(12, 13);
            this.ModuleGroup.Name = "ModuleGroup";
            this.ModuleGroup.Size = new System.Drawing.Size(302, 424);
            this.ModuleGroup.TabIndex = 3;
            this.ModuleGroup.TabStop = false;
            this.ModuleGroup.Text = "Changes";
            // 
            // PackGroup
            // 
            this.PackGroup.Controls.Add(this.NoteGroup);
            this.PackGroup.Controls.Add(this.PackList);
            this.PackGroup.Controls.Add(this.PackImage);
            this.PackGroup.Location = new System.Drawing.Point(320, 13);
            this.PackGroup.Name = "PackGroup";
            this.PackGroup.Size = new System.Drawing.Size(643, 424);
            this.PackGroup.TabIndex = 4;
            this.PackGroup.TabStop = false;
            this.PackGroup.Text = "Mod Packs";
            // 
            // NoteGroup
            // 
            this.NoteGroup.Controls.Add(this.PackNotes);
            this.NoteGroup.Location = new System.Drawing.Point(353, 257);
            this.NoteGroup.Name = "NoteGroup";
            this.NoteGroup.Size = new System.Drawing.Size(276, 161);
            this.NoteGroup.TabIndex = 3;
            this.NoteGroup.TabStop = false;
            this.NoteGroup.Text = "Notes";
            // 
            // PackNotes
            // 
            this.PackNotes.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PackNotes.Location = new System.Drawing.Point(7, 21);
            this.PackNotes.Multiline = true;
            this.PackNotes.Name = "PackNotes";
            this.PackNotes.ReadOnly = true;
            this.PackNotes.Size = new System.Drawing.Size(263, 134);
            this.PackNotes.TabIndex = 0;
            // 
            // PackList
            // 
            this.PackList.FormattingEnabled = true;
            this.PackList.HorizontalScrollbar = true;
            this.PackList.IntegralHeight = false;
            this.PackList.Location = new System.Drawing.Point(8, 23);
            this.PackList.Margin = new System.Windows.Forms.Padding(5);
            this.PackList.Name = "PackList";
            this.PackList.Size = new System.Drawing.Size(337, 395);
            this.PackList.TabIndex = 1;
            this.PackList.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.PackList_ItemCheck);
            this.PackList.SelectedIndexChanged += new System.EventHandler(this.PackList_SelectedIndexChanged);
            // 
            // PackImage
            // 
            this.PackImage.Location = new System.Drawing.Point(353, 23);
            this.PackImage.Name = "PackImage";
            this.PackImage.Size = new System.Drawing.Size(276, 228);
            this.PackImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.PackImage.TabIndex = 2;
            this.PackImage.TabStop = false;
            // 
            // PropGroup
            // 
            this.PropGroup.Controls.Add(this.EnabledCheckBox);
            this.PropGroup.Controls.Add(this.FallbackLabel);
            this.PropGroup.Controls.Add(this.FallbackSelect);
            this.PropGroup.Enabled = false;
            this.PropGroup.Location = new System.Drawing.Point(320, 443);
            this.PropGroup.Name = "PropGroup";
            this.PropGroup.Size = new System.Drawing.Size(345, 148);
            this.PropGroup.TabIndex = 5;
            this.PropGroup.TabStop = false;
            this.PropGroup.Text = "Properties";
            // 
            // EnabledCheckBox
            // 
            this.EnabledCheckBox.AutoSize = true;
            this.EnabledCheckBox.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.EnabledCheckBox.Enabled = false;
            this.EnabledCheckBox.Location = new System.Drawing.Point(6, 21);
            this.EnabledCheckBox.Name = "EnabledCheckBox";
            this.EnabledCheckBox.Size = new System.Drawing.Size(82, 21);
            this.EnabledCheckBox.TabIndex = 2;
            this.EnabledCheckBox.Text = "Enabled";
            this.EnabledCheckBox.UseVisualStyleBackColor = true;
            // 
            // FallbackLabel
            // 
            this.FallbackLabel.AutoSize = true;
            this.FallbackLabel.Location = new System.Drawing.Point(93, 22);
            this.FallbackLabel.Name = "FallbackLabel";
            this.FallbackLabel.Size = new System.Drawing.Size(64, 17);
            this.FallbackLabel.TabIndex = 1;
            this.FallbackLabel.Text = "Fallback:";
            // 
            // FallbackSelect
            // 
            this.FallbackSelect.FormattingEnabled = true;
            this.FallbackSelect.Location = new System.Drawing.Point(163, 19);
            this.FallbackSelect.Name = "FallbackSelect";
            this.FallbackSelect.Size = new System.Drawing.Size(176, 24);
            this.FallbackSelect.TabIndex = 0;
            this.FallbackSelect.SelectedIndexChanged += new System.EventHandler(this.FallbackSelect_SelectedIndexChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.RebuildButton);
            this.groupBox1.Controls.Add(this.RunGameButton);
            this.groupBox1.Controls.Add(this.LoadButton);
            this.groupBox1.Location = new System.Drawing.Point(673, 443);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(290, 148);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Actions";
            // 
            // RebuildButton
            // 
            this.RebuildButton.Location = new System.Drawing.Point(7, 21);
            this.RebuildButton.Name = "RebuildButton";
            this.RebuildButton.Size = new System.Drawing.Size(277, 36);
            this.RebuildButton.TabIndex = 2;
            this.RebuildButton.Text = "Rebuild Packs / Reload";
            this.RebuildButton.UseVisualStyleBackColor = true;
            this.RebuildButton.Click += new System.EventHandler(this.RebuildButton_Click);
            // 
            // RunGameButton
            // 
            this.RunGameButton.Location = new System.Drawing.Point(7, 103);
            this.RunGameButton.Name = "RunGameButton";
            this.RunGameButton.Size = new System.Drawing.Size(277, 33);
            this.RunGameButton.TabIndex = 1;
            this.RunGameButton.Text = "Launch Game";
            this.RunGameButton.UseVisualStyleBackColor = true;
            this.RunGameButton.Click += new System.EventHandler(this.RunGameButton_Click);
            // 
            // LoadButton
            // 
            this.LoadButton.Location = new System.Drawing.Point(7, 63);
            this.LoadButton.Name = "LoadButton";
            this.LoadButton.Size = new System.Drawing.Size(277, 34);
            this.LoadButton.TabIndex = 0;
            this.LoadButton.Text = "Load All Mods";
            this.LoadButton.UseVisualStyleBackColor = true;
            this.LoadButton.Click += new System.EventHandler(this.LoadButton_Click);
            // 
            // ChangeGroup
            // 
            this.ChangeGroup.Controls.Add(this.ConflictList);
            this.ChangeGroup.Location = new System.Drawing.Point(12, 443);
            this.ChangeGroup.Name = "ChangeGroup";
            this.ChangeGroup.Size = new System.Drawing.Size(302, 362);
            this.ChangeGroup.TabIndex = 5;
            this.ChangeGroup.TabStop = false;
            this.ChangeGroup.Text = "Conflict";
            // 
            // ConflictList
            // 
            this.ConflictList.CheckOnClick = true;
            this.ConflictList.FormattingEnabled = true;
            this.ConflictList.HorizontalScrollbar = true;
            this.ConflictList.IntegralHeight = false;
            this.ConflictList.Location = new System.Drawing.Point(6, 19);
            this.ConflictList.Name = "ConflictList";
            this.ConflictList.Size = new System.Drawing.Size(288, 335);
            this.ConflictList.TabIndex = 0;
            this.ConflictList.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.ModuleList_ItemCheck);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.ModuleList);
            this.groupBox2.Location = new System.Drawing.Point(320, 597);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(643, 208);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Modules";
            // 
            // ModuleList
            // 
            this.ModuleList.CheckOnClick = true;
            this.ModuleList.FormattingEnabled = true;
            this.ModuleList.HorizontalScrollbar = true;
            this.ModuleList.IntegralHeight = false;
            this.ModuleList.Location = new System.Drawing.Point(6, 20);
            this.ModuleList.Name = "ModuleList";
            this.ModuleList.Size = new System.Drawing.Size(631, 180);
            this.ModuleList.TabIndex = 1;
            this.ModuleList.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.ModuleList_ItemCheck);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(970, 812);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.ChangeGroup);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.PropGroup);
            this.Controls.Add(this.PackGroup);
            this.Controls.Add(this.ModuleGroup);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(5);
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Text = "ModLoader";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ModuleGroup.ResumeLayout(false);
            this.PackGroup.ResumeLayout(false);
            this.NoteGroup.ResumeLayout(false);
            this.NoteGroup.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PackImage)).EndInit();
            this.PropGroup.ResumeLayout(false);
            this.PropGroup.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.ChangeGroup.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox ChangeList;
        private System.Windows.Forms.GroupBox ModuleGroup;
        private System.Windows.Forms.GroupBox PackGroup;
        private System.Windows.Forms.CheckedListBox PackList;
        private System.Windows.Forms.GroupBox PropGroup;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button RunGameButton;
        private System.Windows.Forms.Button LoadButton;
        private System.Windows.Forms.GroupBox ChangeGroup;
        private System.Windows.Forms.CheckBox EnabledCheckBox;
        private System.Windows.Forms.Label FallbackLabel;
        private System.Windows.Forms.ComboBox FallbackSelect;
        private System.Windows.Forms.PictureBox PackImage;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox NoteGroup;
        private System.Windows.Forms.TextBox PackNotes;
        private System.Windows.Forms.CheckedListBox ConflictList;
        private System.Windows.Forms.CheckedListBox ModuleList;
        private System.Windows.Forms.Button RebuildButton;
    }
}

