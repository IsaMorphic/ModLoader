
namespace ModLoader
{
    partial class UpdaterForm
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
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.MetaGroup = new System.Windows.Forms.GroupBox();
            this.DetailsPane = new System.Windows.Forms.SplitContainer();
            this.TopPane = new System.Windows.Forms.SplitContainer();
            this.EditPane = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.NameEdit = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.AuthorEdit = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.FallbackEdit = new System.Windows.Forms.ComboBox();
            this.PackImage = new System.Windows.Forms.PictureBox();
            this.NotesGroup = new System.Windows.Forms.GroupBox();
            this.NotesEdit = new System.Windows.Forms.TextBox();
            this.LeftPane = new System.Windows.Forms.SplitContainer();
            this.ModuleGroup = new System.Windows.Forms.GroupBox();
            this.ModuleList = new System.Windows.Forms.ListBox();
            this.ActionsPane = new System.Windows.Forms.TableLayoutPanel();
            this.RemoveButton = new System.Windows.Forms.Button();
            this.ReplaceButton = new System.Windows.Forms.Button();
            this.AddButton = new System.Windows.Forms.Button();
            this.ResetButton = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.ModuleNameEdit = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.MainPane = new System.Windows.Forms.SplitContainer();
            this.MenuBar = new System.Windows.Forms.MenuStrip();
            this.FileButton = new System.Windows.Forms.ToolStripMenuItem();
            this.RevertButton = new System.Windows.Forms.ToolStripMenuItem();
            this.SaveButton = new System.Windows.Forms.ToolStripMenuItem();
            this.FileDialog = new System.Windows.Forms.OpenFileDialog();
            this.MetaGroup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DetailsPane)).BeginInit();
            this.DetailsPane.Panel1.SuspendLayout();
            this.DetailsPane.Panel2.SuspendLayout();
            this.DetailsPane.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TopPane)).BeginInit();
            this.TopPane.Panel1.SuspendLayout();
            this.TopPane.Panel2.SuspendLayout();
            this.TopPane.SuspendLayout();
            this.EditPane.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PackImage)).BeginInit();
            this.NotesGroup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.LeftPane)).BeginInit();
            this.LeftPane.Panel1.SuspendLayout();
            this.LeftPane.Panel2.SuspendLayout();
            this.LeftPane.SuspendLayout();
            this.ModuleGroup.SuspendLayout();
            this.ActionsPane.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MainPane)).BeginInit();
            this.MainPane.Panel1.SuspendLayout();
            this.MainPane.Panel2.SuspendLayout();
            this.MainPane.SuspendLayout();
            this.MenuBar.SuspendLayout();
            this.SuspendLayout();
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(94, 37);
            this.label4.TabIndex = 0;
            this.label4.Text = "Name:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(3, 66);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(104, 37);
            this.label5.TabIndex = 2;
            this.label5.Text = "Author:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(3, 132);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(118, 37);
            this.label6.TabIndex = 4;
            this.label6.Text = "Fallback:";
            // 
            // MetaGroup
            // 
            this.MetaGroup.Controls.Add(this.DetailsPane);
            this.MetaGroup.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MetaGroup.Location = new System.Drawing.Point(0, 0);
            this.MetaGroup.Name = "MetaGroup";
            this.MetaGroup.Size = new System.Drawing.Size(1004, 979);
            this.MetaGroup.TabIndex = 1;
            this.MetaGroup.TabStop = false;
            this.MetaGroup.Text = "Metadata";
            // 
            // DetailsPane
            // 
            this.DetailsPane.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DetailsPane.Location = new System.Drawing.Point(3, 39);
            this.DetailsPane.Name = "DetailsPane";
            this.DetailsPane.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // DetailsPane.Panel1
            // 
            this.DetailsPane.Panel1.Controls.Add(this.TopPane);
            // 
            // DetailsPane.Panel2
            // 
            this.DetailsPane.Panel2.Controls.Add(this.NotesGroup);
            this.DetailsPane.Size = new System.Drawing.Size(998, 937);
            this.DetailsPane.SplitterDistance = 332;
            this.DetailsPane.TabIndex = 0;
            // 
            // TopPane
            // 
            this.TopPane.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TopPane.Location = new System.Drawing.Point(0, 0);
            this.TopPane.Name = "TopPane";
            // 
            // TopPane.Panel1
            // 
            this.TopPane.Panel1.Controls.Add(this.EditPane);
            // 
            // TopPane.Panel2
            // 
            this.TopPane.Panel2.Controls.Add(this.PackImage);
            this.TopPane.Size = new System.Drawing.Size(998, 332);
            this.TopPane.SplitterDistance = 332;
            this.TopPane.TabIndex = 2;
            // 
            // EditPane
            // 
            this.EditPane.ColumnCount = 2;
            this.EditPane.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.EditPane.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 75F));
            this.EditPane.Controls.Add(this.label1, 0, 0);
            this.EditPane.Controls.Add(this.NameEdit, 1, 0);
            this.EditPane.Controls.Add(this.label2, 0, 1);
            this.EditPane.Controls.Add(this.AuthorEdit, 1, 1);
            this.EditPane.Controls.Add(this.label3, 0, 2);
            this.EditPane.Controls.Add(this.FallbackEdit, 1, 2);
            this.EditPane.Dock = System.Windows.Forms.DockStyle.Fill;
            this.EditPane.Location = new System.Drawing.Point(0, 0);
            this.EditPane.Name = "EditPane";
            this.EditPane.RowCount = 3;
            this.EditPane.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.EditPane.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.EditPane.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.EditPane.Size = new System.Drawing.Size(332, 332);
            this.EditPane.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 74);
            this.label1.TabIndex = 0;
            this.label1.Text = "Name:";
            // 
            // NameEdit
            // 
            this.NameEdit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.NameEdit.Location = new System.Drawing.Point(86, 3);
            this.NameEdit.Name = "NameEdit";
            this.NameEdit.Size = new System.Drawing.Size(243, 43);
            this.NameEdit.TabIndex = 1;
            this.NameEdit.TextChanged += new System.EventHandler(this.NameEdit_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 110);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 74);
            this.label2.TabIndex = 2;
            this.label2.Text = "Author:";
            // 
            // AuthorEdit
            // 
            this.AuthorEdit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.AuthorEdit.Location = new System.Drawing.Point(86, 113);
            this.AuthorEdit.Name = "AuthorEdit";
            this.AuthorEdit.Size = new System.Drawing.Size(243, 43);
            this.AuthorEdit.TabIndex = 3;
            this.AuthorEdit.TextChanged += new System.EventHandler(this.AuthorEdit_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 220);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(73, 74);
            this.label3.TabIndex = 4;
            this.label3.Text = "Fallback:";
            // 
            // FallbackEdit
            // 
            this.FallbackEdit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FallbackEdit.FormattingEnabled = true;
            this.FallbackEdit.Location = new System.Drawing.Point(86, 223);
            this.FallbackEdit.Name = "FallbackEdit";
            this.FallbackEdit.Size = new System.Drawing.Size(243, 45);
            this.FallbackEdit.TabIndex = 5;
            this.FallbackEdit.SelectedValueChanged += new System.EventHandler(this.FallbackEdit_SelectedValueChanged);
            // 
            // PackImage
            // 
            this.PackImage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PackImage.Location = new System.Drawing.Point(0, 0);
            this.PackImage.Name = "PackImage";
            this.PackImage.Size = new System.Drawing.Size(662, 332);
            this.PackImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.PackImage.TabIndex = 0;
            this.PackImage.TabStop = false;
            this.PackImage.DoubleClick += new System.EventHandler(this.PackImage_DoubleClick);
            // 
            // NotesGroup
            // 
            this.NotesGroup.Controls.Add(this.NotesEdit);
            this.NotesGroup.Dock = System.Windows.Forms.DockStyle.Fill;
            this.NotesGroup.Location = new System.Drawing.Point(0, 0);
            this.NotesGroup.Name = "NotesGroup";
            this.NotesGroup.Size = new System.Drawing.Size(998, 601);
            this.NotesGroup.TabIndex = 1;
            this.NotesGroup.TabStop = false;
            this.NotesGroup.Text = "Notes";
            // 
            // NotesEdit
            // 
            this.NotesEdit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.NotesEdit.Location = new System.Drawing.Point(3, 39);
            this.NotesEdit.Multiline = true;
            this.NotesEdit.Name = "NotesEdit";
            this.NotesEdit.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.NotesEdit.Size = new System.Drawing.Size(992, 559);
            this.NotesEdit.TabIndex = 0;
            this.NotesEdit.TextChanged += new System.EventHandler(this.NotesEdit_TextChanged);
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
            this.LeftPane.Panel1.Controls.Add(this.ModuleGroup);
            // 
            // LeftPane.Panel2
            // 
            this.LeftPane.Panel2.Controls.Add(this.ActionsPane);
            this.LeftPane.Size = new System.Drawing.Size(503, 979);
            this.LeftPane.SplitterDistance = 700;
            this.LeftPane.TabIndex = 0;
            // 
            // ModuleGroup
            // 
            this.ModuleGroup.Controls.Add(this.ModuleList);
            this.ModuleGroup.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ModuleGroup.Location = new System.Drawing.Point(0, 0);
            this.ModuleGroup.Name = "ModuleGroup";
            this.ModuleGroup.Size = new System.Drawing.Size(503, 700);
            this.ModuleGroup.TabIndex = 1;
            this.ModuleGroup.TabStop = false;
            this.ModuleGroup.Text = "Modules";
            // 
            // ModuleList
            // 
            this.ModuleList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ModuleList.FormattingEnabled = true;
            this.ModuleList.IntegralHeight = false;
            this.ModuleList.ItemHeight = 37;
            this.ModuleList.Location = new System.Drawing.Point(3, 39);
            this.ModuleList.Name = "ModuleList";
            this.ModuleList.Size = new System.Drawing.Size(497, 658);
            this.ModuleList.TabIndex = 0;
            // 
            // ActionsPane
            // 
            this.ActionsPane.ColumnCount = 1;
            this.ActionsPane.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.ActionsPane.Controls.Add(this.RemoveButton, 0, 0);
            this.ActionsPane.Controls.Add(this.ReplaceButton, 0, 1);
            this.ActionsPane.Controls.Add(this.AddButton, 0, 2);
            this.ActionsPane.Controls.Add(this.ResetButton, 0, 4);
            this.ActionsPane.Controls.Add(this.tableLayoutPanel1, 0, 3);
            this.ActionsPane.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ActionsPane.Location = new System.Drawing.Point(0, 0);
            this.ActionsPane.Name = "ActionsPane";
            this.ActionsPane.RowCount = 5;
            this.ActionsPane.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25.00062F));
            this.ActionsPane.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25.00062F));
            this.ActionsPane.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25.00062F));
            this.ActionsPane.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.ActionsPane.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 24.99813F));
            this.ActionsPane.Size = new System.Drawing.Size(503, 275);
            this.ActionsPane.TabIndex = 0;
            // 
            // RemoveButton
            // 
            this.RemoveButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.RemoveButton.Location = new System.Drawing.Point(3, 3);
            this.RemoveButton.Name = "RemoveButton";
            this.RemoveButton.Size = new System.Drawing.Size(497, 49);
            this.RemoveButton.TabIndex = 0;
            this.RemoveButton.Text = "Remove";
            this.RemoveButton.UseVisualStyleBackColor = true;
            this.RemoveButton.Click += new System.EventHandler(this.RemoveButton_Click);
            // 
            // ReplaceButton
            // 
            this.ReplaceButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ReplaceButton.Location = new System.Drawing.Point(3, 58);
            this.ReplaceButton.Name = "ReplaceButton";
            this.ReplaceButton.Size = new System.Drawing.Size(497, 49);
            this.ReplaceButton.TabIndex = 1;
            this.ReplaceButton.Text = "Replace";
            this.ReplaceButton.UseVisualStyleBackColor = true;
            this.ReplaceButton.Click += new System.EventHandler(this.ReplaceButton_Click);
            // 
            // AddButton
            // 
            this.AddButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.AddButton.Location = new System.Drawing.Point(3, 113);
            this.AddButton.Name = "AddButton";
            this.AddButton.Size = new System.Drawing.Size(497, 49);
            this.AddButton.TabIndex = 2;
            this.AddButton.Text = "Add New";
            this.AddButton.UseVisualStyleBackColor = true;
            this.AddButton.Click += new System.EventHandler(this.AddButton_Click);
            // 
            // ResetButton
            // 
            this.ResetButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ResetButton.Location = new System.Drawing.Point(3, 223);
            this.ResetButton.Name = "ResetButton";
            this.ResetButton.Size = new System.Drawing.Size(497, 49);
            this.ResetButton.TabIndex = 4;
            this.ResetButton.Text = "Reset";
            this.ResetButton.UseVisualStyleBackColor = true;
            this.ResetButton.Click += new System.EventHandler(this.ResetButton_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 70F));
            this.tableLayoutPanel1.Controls.Add(this.ModuleNameEdit, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.label7, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 168);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(497, 49);
            this.tableLayoutPanel1.TabIndex = 5;
            // 
            // ModuleNameEdit
            // 
            this.ModuleNameEdit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ModuleNameEdit.Location = new System.Drawing.Point(152, 3);
            this.ModuleNameEdit.Name = "ModuleNameEdit";
            this.ModuleNameEdit.Size = new System.Drawing.Size(342, 43);
            this.ModuleNameEdit.TabIndex = 0;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(3, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(94, 37);
            this.label7.TabIndex = 1;
            this.label7.Text = "Name:";
            // 
            // MainPane
            // 
            this.MainPane.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainPane.Location = new System.Drawing.Point(0, 45);
            this.MainPane.Name = "MainPane";
            // 
            // MainPane.Panel1
            // 
            this.MainPane.Panel1.Controls.Add(this.LeftPane);
            // 
            // MainPane.Panel2
            // 
            this.MainPane.Panel2.Controls.Add(this.MetaGroup);
            this.MainPane.Size = new System.Drawing.Size(1511, 979);
            this.MainPane.SplitterDistance = 503;
            this.MainPane.TabIndex = 0;
            // 
            // MenuBar
            // 
            this.MenuBar.ImageScalingSize = new System.Drawing.Size(36, 36);
            this.MenuBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.FileButton});
            this.MenuBar.Location = new System.Drawing.Point(0, 0);
            this.MenuBar.Name = "MenuBar";
            this.MenuBar.Size = new System.Drawing.Size(1511, 45);
            this.MenuBar.TabIndex = 1;
            this.MenuBar.Text = "MenuBar";
            // 
            // FileButton
            // 
            this.FileButton.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.RevertButton,
            this.SaveButton});
            this.FileButton.Name = "FileButton";
            this.FileButton.Size = new System.Drawing.Size(80, 41);
            this.FileButton.Text = "File";
            // 
            // RevertButton
            // 
            this.RevertButton.Name = "RevertButton";
            this.RevertButton.Size = new System.Drawing.Size(350, 48);
            this.RevertButton.Text = "Revert Changes";
            this.RevertButton.Click += new System.EventHandler(this.RevertButton_Click);
            // 
            // SaveButton
            // 
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(350, 48);
            this.SaveButton.Text = "Save Changes";
            this.SaveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // FileDialog
            // 
            this.FileDialog.Filter = "All files|*.*";
            // 
            // UpdaterForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(15F, 37F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1511, 1024);
            this.Controls.Add(this.MainPane);
            this.Controls.Add(this.MenuBar);
            this.MainMenuStrip = this.MenuBar;
            this.Name = "UpdaterForm";
            this.Text = "UpdaterForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.UpdaterForm_FormClosing);
            this.Load += new System.EventHandler(this.UpdaterForm_Load);
            this.MetaGroup.ResumeLayout(false);
            this.DetailsPane.Panel1.ResumeLayout(false);
            this.DetailsPane.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DetailsPane)).EndInit();
            this.DetailsPane.ResumeLayout(false);
            this.TopPane.Panel1.ResumeLayout(false);
            this.TopPane.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.TopPane)).EndInit();
            this.TopPane.ResumeLayout(false);
            this.EditPane.ResumeLayout(false);
            this.EditPane.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PackImage)).EndInit();
            this.NotesGroup.ResumeLayout(false);
            this.NotesGroup.PerformLayout();
            this.LeftPane.Panel1.ResumeLayout(false);
            this.LeftPane.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.LeftPane)).EndInit();
            this.LeftPane.ResumeLayout(false);
            this.ModuleGroup.ResumeLayout(false);
            this.ActionsPane.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.MainPane.Panel1.ResumeLayout(false);
            this.MainPane.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.MainPane)).EndInit();
            this.MainPane.ResumeLayout(false);
            this.MenuBar.ResumeLayout(false);
            this.MenuBar.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox MetaGroup;
        private System.Windows.Forms.SplitContainer LeftPane;
        private System.Windows.Forms.GroupBox ModuleGroup;
        private System.Windows.Forms.ListBox ModuleList;
        private System.Windows.Forms.TableLayoutPanel ActionsPane;
        private System.Windows.Forms.Button RemoveButton;
        private System.Windows.Forms.Button ReplaceButton;
        private System.Windows.Forms.Button AddButton;
        private System.Windows.Forms.SplitContainer MainPane;
        private System.Windows.Forms.MenuStrip MenuBar;
        private System.Windows.Forms.ToolStripMenuItem FileButton;
        private System.Windows.Forms.ToolStripMenuItem RevertButton;
        private System.Windows.Forms.ToolStripMenuItem SaveButton;
        private System.Windows.Forms.SplitContainer DetailsPane;
        private System.Windows.Forms.SplitContainer TopPane;
        private System.Windows.Forms.TableLayoutPanel EditPane;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox NameEdit;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox AuthorEdit;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox FallbackEdit;
        private System.Windows.Forms.PictureBox PackImage;
        private System.Windows.Forms.GroupBox NotesGroup;
        private System.Windows.Forms.TextBox NotesEdit;
        private System.Windows.Forms.OpenFileDialog FileDialog;
        private System.Windows.Forms.Button ResetButton;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TextBox ModuleNameEdit;
        private System.Windows.Forms.Label label7;
    }
}