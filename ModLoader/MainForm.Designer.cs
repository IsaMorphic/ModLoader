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
            this.components = new System.ComponentModel.Container();
            this.ChangeList = new System.Windows.Forms.ListBox();
            this.ChangeGroup = new System.Windows.Forms.GroupBox();
            this.PackGroup = new System.Windows.Forms.GroupBox();
            this.PacksPane = new System.Windows.Forms.SplitContainer();
            this.PackList = new System.Windows.Forms.CheckedListBox();
            this.PackContext = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.UpdateButton = new System.Windows.Forms.ToolStripMenuItem();
            this.MetaGroup = new System.Windows.Forms.GroupBox();
            this.DetailsPane = new System.Windows.Forms.SplitContainer();
            this.PackImage = new System.Windows.Forms.PictureBox();
            this.MetaPane = new System.Windows.Forms.TableLayoutPanel();
            this.NotesGroup = new System.Windows.Forms.GroupBox();
            this.NotesEdit = new System.Windows.Forms.TextBox();
            this.EditPane = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.NameEdit = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.AuthorEdit = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.FallbackEdit = new System.Windows.Forms.ComboBox();
            this.ConflictGroup = new System.Windows.Forms.GroupBox();
            this.ConflictList = new System.Windows.Forms.CheckedListBox();
            this.ModuleGroup = new System.Windows.Forms.GroupBox();
            this.ModuleList = new System.Windows.Forms.CheckedListBox();
            this.MenuBar = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.OpenGameButton = new System.Windows.Forms.ToolStripMenuItem();
            this.OpenModsButton = new System.Windows.Forms.ToolStripMenuItem();
            this.ImportModButton = new System.Windows.Forms.ToolStripMenuItem();
            this.AboutButton = new System.Windows.Forms.ToolStripMenuItem();
            this.ImportFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.TopPane = new System.Windows.Forms.SplitContainer();
            this.MainPane = new System.Windows.Forms.SplitContainer();
            this.BottomPane = new System.Windows.Forms.SplitContainer();
            this.OtherPane = new System.Windows.Forms.SplitContainer();
            this.ActionGroup = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.RunGameButton = new System.Windows.Forms.Button();
            this.LoadButton = new System.Windows.Forms.Button();
            this.RebuildButton = new System.Windows.Forms.Button();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.ChangeGroup.SuspendLayout();
            this.PackGroup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PacksPane)).BeginInit();
            this.PacksPane.Panel1.SuspendLayout();
            this.PacksPane.Panel2.SuspendLayout();
            this.PacksPane.SuspendLayout();
            this.PackContext.SuspendLayout();
            this.MetaGroup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DetailsPane)).BeginInit();
            this.DetailsPane.Panel1.SuspendLayout();
            this.DetailsPane.Panel2.SuspendLayout();
            this.DetailsPane.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PackImage)).BeginInit();
            this.MetaPane.SuspendLayout();
            this.NotesGroup.SuspendLayout();
            this.EditPane.SuspendLayout();
            this.ConflictGroup.SuspendLayout();
            this.ModuleGroup.SuspendLayout();
            this.MenuBar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TopPane)).BeginInit();
            this.TopPane.Panel1.SuspendLayout();
            this.TopPane.Panel2.SuspendLayout();
            this.TopPane.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MainPane)).BeginInit();
            this.MainPane.Panel1.SuspendLayout();
            this.MainPane.Panel2.SuspendLayout();
            this.MainPane.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BottomPane)).BeginInit();
            this.BottomPane.Panel1.SuspendLayout();
            this.BottomPane.Panel2.SuspendLayout();
            this.BottomPane.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.OtherPane)).BeginInit();
            this.OtherPane.Panel1.SuspendLayout();
            this.OtherPane.Panel2.SuspendLayout();
            this.OtherPane.SuspendLayout();
            this.ActionGroup.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // ChangeList
            // 
            this.ChangeList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ChangeList.FormattingEnabled = true;
            this.ChangeList.HorizontalScrollbar = true;
            this.ChangeList.IntegralHeight = false;
            this.ChangeList.ItemHeight = 37;
            this.ChangeList.Location = new System.Drawing.Point(6, 42);
            this.ChangeList.Margin = new System.Windows.Forms.Padding(9);
            this.ChangeList.Name = "ChangeList";
            this.ChangeList.Size = new System.Drawing.Size(546, 608);
            this.ChangeList.TabIndex = 1;
            this.ChangeList.SelectedIndexChanged += new System.EventHandler(this.ChangeList_SelectedIndexChanged);
            // 
            // ChangeGroup
            // 
            this.ChangeGroup.Controls.Add(this.ChangeList);
            this.ChangeGroup.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ChangeGroup.Location = new System.Drawing.Point(0, 0);
            this.ChangeGroup.Margin = new System.Windows.Forms.Padding(6);
            this.ChangeGroup.Name = "ChangeGroup";
            this.ChangeGroup.Padding = new System.Windows.Forms.Padding(6);
            this.ChangeGroup.Size = new System.Drawing.Size(558, 656);
            this.ChangeGroup.TabIndex = 3;
            this.ChangeGroup.TabStop = false;
            this.ChangeGroup.Text = "Changes";
            // 
            // PackGroup
            // 
            this.PackGroup.Controls.Add(this.PacksPane);
            this.PackGroup.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PackGroup.Location = new System.Drawing.Point(0, 0);
            this.PackGroup.Margin = new System.Windows.Forms.Padding(6);
            this.PackGroup.Name = "PackGroup";
            this.PackGroup.Padding = new System.Windows.Forms.Padding(6);
            this.PackGroup.Size = new System.Drawing.Size(1116, 656);
            this.PackGroup.TabIndex = 4;
            this.PackGroup.TabStop = false;
            this.PackGroup.Text = "Mod Packs";
            // 
            // PacksPane
            // 
            this.PacksPane.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PacksPane.Location = new System.Drawing.Point(6, 42);
            this.PacksPane.Margin = new System.Windows.Forms.Padding(6);
            this.PacksPane.Name = "PacksPane";
            // 
            // PacksPane.Panel1
            // 
            this.PacksPane.Panel1.Controls.Add(this.PackList);
            // 
            // PacksPane.Panel2
            // 
            this.PacksPane.Panel2.Controls.Add(this.MetaGroup);
            this.PacksPane.Size = new System.Drawing.Size(1104, 608);
            this.PacksPane.SplitterDistance = 647;
            this.PacksPane.SplitterWidth = 8;
            this.PacksPane.TabIndex = 4;
            // 
            // PackList
            // 
            this.PackList.ContextMenuStrip = this.PackContext;
            this.PackList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PackList.FormattingEnabled = true;
            this.PackList.HorizontalScrollbar = true;
            this.PackList.IntegralHeight = false;
            this.PackList.Location = new System.Drawing.Point(0, 0);
            this.PackList.Margin = new System.Windows.Forms.Padding(9);
            this.PackList.Name = "PackList";
            this.PackList.Size = new System.Drawing.Size(647, 608);
            this.PackList.TabIndex = 1;
            this.PackList.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.PackList_ItemCheck);
            this.PackList.SelectedIndexChanged += new System.EventHandler(this.PackList_SelectedIndexChanged);
            // 
            // PackContext
            // 
            this.PackContext.ImageScalingSize = new System.Drawing.Size(36, 36);
            this.PackContext.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.UpdateButton});
            this.PackContext.Name = "PackContext";
            this.PackContext.Size = new System.Drawing.Size(290, 48);
            // 
            // UpdateButton
            // 
            this.UpdateButton.Enabled = false;
            this.UpdateButton.Name = "UpdateButton";
            this.UpdateButton.Size = new System.Drawing.Size(289, 44);
            this.UpdateButton.Text = "Update Selected";
            this.UpdateButton.Click += new System.EventHandler(this.UpdateButton_Click);
            // 
            // MetaGroup
            // 
            this.MetaGroup.Controls.Add(this.DetailsPane);
            this.MetaGroup.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MetaGroup.Location = new System.Drawing.Point(0, 0);
            this.MetaGroup.Name = "MetaGroup";
            this.MetaGroup.Size = new System.Drawing.Size(449, 608);
            this.MetaGroup.TabIndex = 2;
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
            this.DetailsPane.Panel1.Controls.Add(this.PackImage);
            // 
            // DetailsPane.Panel2
            // 
            this.DetailsPane.Panel2.Controls.Add(this.MetaPane);
            this.DetailsPane.Size = new System.Drawing.Size(443, 566);
            this.DetailsPane.SplitterDistance = 147;
            this.DetailsPane.TabIndex = 0;
            // 
            // PackImage
            // 
            this.PackImage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PackImage.Location = new System.Drawing.Point(0, 0);
            this.PackImage.Name = "PackImage";
            this.PackImage.Size = new System.Drawing.Size(443, 147);
            this.PackImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.PackImage.TabIndex = 0;
            this.PackImage.TabStop = false;
            // 
            // MetaPane
            // 
            this.MetaPane.ColumnCount = 1;
            this.MetaPane.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.MetaPane.Controls.Add(this.NotesGroup, 0, 1);
            this.MetaPane.Controls.Add(this.EditPane, 0, 0);
            this.MetaPane.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MetaPane.Location = new System.Drawing.Point(0, 0);
            this.MetaPane.Name = "MetaPane";
            this.MetaPane.RowCount = 2;
            this.MetaPane.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 49.99999F));
            this.MetaPane.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.00002F));
            this.MetaPane.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.MetaPane.Size = new System.Drawing.Size(443, 415);
            this.MetaPane.TabIndex = 3;
            // 
            // NotesGroup
            // 
            this.NotesGroup.Controls.Add(this.NotesEdit);
            this.NotesGroup.Dock = System.Windows.Forms.DockStyle.Fill;
            this.NotesGroup.Location = new System.Drawing.Point(3, 210);
            this.NotesGroup.Name = "NotesGroup";
            this.NotesGroup.Size = new System.Drawing.Size(437, 202);
            this.NotesGroup.TabIndex = 8;
            this.NotesGroup.TabStop = false;
            this.NotesGroup.Text = "Notes:";
            // 
            // NotesEdit
            // 
            this.NotesEdit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.NotesEdit.Location = new System.Drawing.Point(3, 39);
            this.NotesEdit.Multiline = true;
            this.NotesEdit.Name = "NotesEdit";
            this.NotesEdit.ReadOnly = true;
            this.NotesEdit.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.NotesEdit.Size = new System.Drawing.Size(431, 160);
            this.NotesEdit.TabIndex = 0;
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
            this.EditPane.Location = new System.Drawing.Point(3, 3);
            this.EditPane.Name = "EditPane";
            this.EditPane.RowCount = 3;
            this.EditPane.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.EditPane.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.EditPane.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.EditPane.Size = new System.Drawing.Size(437, 201);
            this.EditPane.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(94, 37);
            this.label1.TabIndex = 0;
            this.label1.Text = "Name:";
            // 
            // NameEdit
            // 
            this.NameEdit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.NameEdit.Location = new System.Drawing.Point(112, 3);
            this.NameEdit.Name = "NameEdit";
            this.NameEdit.ReadOnly = true;
            this.NameEdit.Size = new System.Drawing.Size(322, 43);
            this.NameEdit.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 67);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(98, 67);
            this.label2.TabIndex = 2;
            this.label2.Text = "Author:";
            // 
            // AuthorEdit
            // 
            this.AuthorEdit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.AuthorEdit.Location = new System.Drawing.Point(112, 70);
            this.AuthorEdit.Name = "AuthorEdit";
            this.AuthorEdit.ReadOnly = true;
            this.AuthorEdit.Size = new System.Drawing.Size(322, 43);
            this.AuthorEdit.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 134);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(99, 67);
            this.label3.TabIndex = 4;
            this.label3.Text = "Fallback:";
            // 
            // FallbackEdit
            // 
            this.FallbackEdit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FallbackEdit.Enabled = false;
            this.FallbackEdit.FormattingEnabled = true;
            this.FallbackEdit.Location = new System.Drawing.Point(112, 137);
            this.FallbackEdit.Name = "FallbackEdit";
            this.FallbackEdit.Size = new System.Drawing.Size(322, 45);
            this.FallbackEdit.TabIndex = 5;
            // 
            // ConflictGroup
            // 
            this.ConflictGroup.Controls.Add(this.ConflictList);
            this.ConflictGroup.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ConflictGroup.Location = new System.Drawing.Point(0, 0);
            this.ConflictGroup.Margin = new System.Windows.Forms.Padding(6);
            this.ConflictGroup.Name = "ConflictGroup";
            this.ConflictGroup.Padding = new System.Windows.Forms.Padding(6);
            this.ConflictGroup.Size = new System.Drawing.Size(558, 650);
            this.ConflictGroup.TabIndex = 5;
            this.ConflictGroup.TabStop = false;
            this.ConflictGroup.Text = "Conflict";
            // 
            // ConflictList
            // 
            this.ConflictList.CheckOnClick = true;
            this.ConflictList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ConflictList.FormattingEnabled = true;
            this.ConflictList.HorizontalScrollbar = true;
            this.ConflictList.IntegralHeight = false;
            this.ConflictList.Location = new System.Drawing.Point(6, 42);
            this.ConflictList.Margin = new System.Windows.Forms.Padding(6);
            this.ConflictList.Name = "ConflictList";
            this.ConflictList.Size = new System.Drawing.Size(546, 602);
            this.ConflictList.TabIndex = 0;
            this.ConflictList.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.ModuleList_ItemCheck);
            // 
            // ModuleGroup
            // 
            this.ModuleGroup.Controls.Add(this.ModuleList);
            this.ModuleGroup.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ModuleGroup.Location = new System.Drawing.Point(0, 0);
            this.ModuleGroup.Margin = new System.Windows.Forms.Padding(6);
            this.ModuleGroup.Name = "ModuleGroup";
            this.ModuleGroup.Padding = new System.Windows.Forms.Padding(6);
            this.ModuleGroup.Size = new System.Drawing.Size(1116, 403);
            this.ModuleGroup.TabIndex = 4;
            this.ModuleGroup.TabStop = false;
            this.ModuleGroup.Text = "Modules";
            // 
            // ModuleList
            // 
            this.ModuleList.CheckOnClick = true;
            this.ModuleList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ModuleList.FormattingEnabled = true;
            this.ModuleList.HorizontalScrollbar = true;
            this.ModuleList.IntegralHeight = false;
            this.ModuleList.Location = new System.Drawing.Point(6, 42);
            this.ModuleList.Margin = new System.Windows.Forms.Padding(6);
            this.ModuleList.Name = "ModuleList";
            this.ModuleList.Size = new System.Drawing.Size(1104, 355);
            this.ModuleList.TabIndex = 1;
            this.ModuleList.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.ModuleList_ItemCheck);
            // 
            // MenuBar
            // 
            this.MenuBar.BackColor = System.Drawing.SystemColors.ControlLight;
            this.MenuBar.ImageScalingSize = new System.Drawing.Size(36, 36);
            this.MenuBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.AboutButton});
            this.MenuBar.Location = new System.Drawing.Point(0, 0);
            this.MenuBar.Name = "MenuBar";
            this.MenuBar.Padding = new System.Windows.Forms.Padding(11, 4, 0, 4);
            this.MenuBar.Size = new System.Drawing.Size(1682, 49);
            this.MenuBar.TabIndex = 7;
            this.MenuBar.Text = "MenuBar";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.OpenGameButton,
            this.OpenModsButton,
            this.ImportModButton});
            this.fileToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(80, 41);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // OpenGameButton
            // 
            this.OpenGameButton.Name = "OpenGameButton";
            this.OpenGameButton.Size = new System.Drawing.Size(424, 48);
            this.OpenGameButton.Text = "Open Game Directory";
            this.OpenGameButton.Click += new System.EventHandler(this.OpenGameButton_Click);
            // 
            // OpenModsButton
            // 
            this.OpenModsButton.Name = "OpenModsButton";
            this.OpenModsButton.Size = new System.Drawing.Size(424, 48);
            this.OpenModsButton.Text = "Open Mod Directory";
            this.OpenModsButton.Click += new System.EventHandler(this.OpenModsButton_Click);
            // 
            // ImportModButton
            // 
            this.ImportModButton.Name = "ImportModButton";
            this.ImportModButton.Size = new System.Drawing.Size(424, 48);
            this.ImportModButton.Text = "Import Mod";
            this.ImportModButton.Click += new System.EventHandler(this.ImportModButton_Click);
            // 
            // AboutButton
            // 
            this.AboutButton.Name = "AboutButton";
            this.AboutButton.Size = new System.Drawing.Size(112, 41);
            this.AboutButton.Text = "About";
            this.AboutButton.Click += new System.EventHandler(this.AboutButton_Click);
            // 
            // ImportFileDialog
            // 
            this.ImportFileDialog.DefaultExt = "zip";
            this.ImportFileDialog.Filter = "ModLoader Pack Files|*.zip";
            // 
            // TopPane
            // 
            this.TopPane.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TopPane.Location = new System.Drawing.Point(0, 0);
            this.TopPane.Margin = new System.Windows.Forms.Padding(6);
            this.TopPane.Name = "TopPane";
            // 
            // TopPane.Panel1
            // 
            this.TopPane.Panel1.Controls.Add(this.ChangeGroup);
            // 
            // TopPane.Panel2
            // 
            this.TopPane.Panel2.Controls.Add(this.PackGroup);
            this.TopPane.Size = new System.Drawing.Size(1682, 656);
            this.TopPane.SplitterDistance = 558;
            this.TopPane.SplitterWidth = 8;
            this.TopPane.TabIndex = 8;
            // 
            // MainPane
            // 
            this.MainPane.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainPane.Location = new System.Drawing.Point(0, 49);
            this.MainPane.Margin = new System.Windows.Forms.Padding(6);
            this.MainPane.Name = "MainPane";
            this.MainPane.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // MainPane.Panel1
            // 
            this.MainPane.Panel1.Controls.Add(this.TopPane);
            // 
            // MainPane.Panel2
            // 
            this.MainPane.Panel2.Controls.Add(this.BottomPane);
            this.MainPane.Size = new System.Drawing.Size(1682, 1313);
            this.MainPane.SplitterDistance = 656;
            this.MainPane.SplitterWidth = 7;
            this.MainPane.TabIndex = 9;
            // 
            // BottomPane
            // 
            this.BottomPane.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BottomPane.Location = new System.Drawing.Point(0, 0);
            this.BottomPane.Margin = new System.Windows.Forms.Padding(6);
            this.BottomPane.Name = "BottomPane";
            // 
            // BottomPane.Panel1
            // 
            this.BottomPane.Panel1.Controls.Add(this.ConflictGroup);
            // 
            // BottomPane.Panel2
            // 
            this.BottomPane.Panel2.Controls.Add(this.OtherPane);
            this.BottomPane.Size = new System.Drawing.Size(1682, 650);
            this.BottomPane.SplitterDistance = 558;
            this.BottomPane.SplitterWidth = 8;
            this.BottomPane.TabIndex = 0;
            // 
            // OtherPane
            // 
            this.OtherPane.Dock = System.Windows.Forms.DockStyle.Fill;
            this.OtherPane.Location = new System.Drawing.Point(0, 0);
            this.OtherPane.Margin = new System.Windows.Forms.Padding(6);
            this.OtherPane.Name = "OtherPane";
            this.OtherPane.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // OtherPane.Panel1
            // 
            this.OtherPane.Panel1.Controls.Add(this.ActionGroup);
            // 
            // OtherPane.Panel2
            // 
            this.OtherPane.Panel2.Controls.Add(this.ModuleGroup);
            this.OtherPane.Size = new System.Drawing.Size(1116, 650);
            this.OtherPane.SplitterDistance = 240;
            this.OtherPane.SplitterWidth = 7;
            this.OtherPane.TabIndex = 10;
            // 
            // ActionGroup
            // 
            this.ActionGroup.Controls.Add(this.tableLayoutPanel1);
            this.ActionGroup.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ActionGroup.Location = new System.Drawing.Point(0, 0);
            this.ActionGroup.Margin = new System.Windows.Forms.Padding(6);
            this.ActionGroup.Name = "ActionGroup";
            this.ActionGroup.Padding = new System.Windows.Forms.Padding(6);
            this.ActionGroup.Size = new System.Drawing.Size(1116, 240);
            this.ActionGroup.TabIndex = 7;
            this.ActionGroup.TabStop = false;
            this.ActionGroup.Text = "Actions";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.RunGameButton, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.LoadButton, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.RebuildButton, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(6, 42);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(6);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33334F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 41F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1104, 192);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // RunGameButton
            // 
            this.RunGameButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.RunGameButton.Location = new System.Drawing.Point(6, 133);
            this.RunGameButton.Margin = new System.Windows.Forms.Padding(6);
            this.RunGameButton.Name = "RunGameButton";
            this.RunGameButton.Size = new System.Drawing.Size(1092, 53);
            this.RunGameButton.TabIndex = 7;
            this.RunGameButton.Text = "Launch Game";
            this.RunGameButton.UseVisualStyleBackColor = true;
            this.RunGameButton.Click += new System.EventHandler(this.RunGameButton_Click);
            // 
            // LoadButton
            // 
            this.LoadButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LoadButton.Location = new System.Drawing.Point(6, 69);
            this.LoadButton.Margin = new System.Windows.Forms.Padding(6);
            this.LoadButton.Name = "LoadButton";
            this.LoadButton.Size = new System.Drawing.Size(1092, 52);
            this.LoadButton.TabIndex = 6;
            this.LoadButton.Text = "Load All Mods";
            this.LoadButton.UseVisualStyleBackColor = true;
            this.LoadButton.Click += new System.EventHandler(this.LoadButton_Click);
            // 
            // RebuildButton
            // 
            this.RebuildButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.RebuildButton.Location = new System.Drawing.Point(6, 6);
            this.RebuildButton.Margin = new System.Windows.Forms.Padding(6);
            this.RebuildButton.Name = "RebuildButton";
            this.RebuildButton.Size = new System.Drawing.Size(1092, 51);
            this.RebuildButton.TabIndex = 4;
            this.RebuildButton.Text = "Rebuild Packs / Reload";
            this.RebuildButton.UseVisualStyleBackColor = true;
            this.RebuildButton.Click += new System.EventHandler(this.RebuildButton_Click);
            // 
            // splitter1
            // 
            this.splitter1.Location = new System.Drawing.Point(3, 39);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(10, 142);
            this.splitter1.TabIndex = 1;
            this.splitter1.TabStop = false;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(15F, 37F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1682, 1362);
            this.Controls.Add(this.MainPane);
            this.Controls.Add(this.MenuBar);
            this.MainMenuStrip = this.MenuBar;
            this.Margin = new System.Windows.Forms.Padding(9);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ModLoader";
            this.Icon = new System.Drawing.Icon(GetType().Assembly
                .GetManifestResourceStream("ModLoader.Logo.Icon.ico"));
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ChangeGroup.ResumeLayout(false);
            this.PackGroup.ResumeLayout(false);
            this.PacksPane.Panel1.ResumeLayout(false);
            this.PacksPane.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.PacksPane)).EndInit();
            this.PacksPane.ResumeLayout(false);
            this.PackContext.ResumeLayout(false);
            this.MetaGroup.ResumeLayout(false);
            this.DetailsPane.Panel1.ResumeLayout(false);
            this.DetailsPane.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DetailsPane)).EndInit();
            this.DetailsPane.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.PackImage)).EndInit();
            this.MetaPane.ResumeLayout(false);
            this.NotesGroup.ResumeLayout(false);
            this.NotesGroup.PerformLayout();
            this.EditPane.ResumeLayout(false);
            this.EditPane.PerformLayout();
            this.ConflictGroup.ResumeLayout(false);
            this.ModuleGroup.ResumeLayout(false);
            this.MenuBar.ResumeLayout(false);
            this.MenuBar.PerformLayout();
            this.TopPane.Panel1.ResumeLayout(false);
            this.TopPane.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.TopPane)).EndInit();
            this.TopPane.ResumeLayout(false);
            this.MainPane.Panel1.ResumeLayout(false);
            this.MainPane.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.MainPane)).EndInit();
            this.MainPane.ResumeLayout(false);
            this.BottomPane.Panel1.ResumeLayout(false);
            this.BottomPane.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.BottomPane)).EndInit();
            this.BottomPane.ResumeLayout(false);
            this.OtherPane.Panel1.ResumeLayout(false);
            this.OtherPane.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.OtherPane)).EndInit();
            this.OtherPane.ResumeLayout(false);
            this.ActionGroup.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox ChangeList;
        private System.Windows.Forms.GroupBox ChangeGroup;
        private System.Windows.Forms.GroupBox PackGroup;
        private System.Windows.Forms.CheckedListBox PackList;
        private System.Windows.Forms.GroupBox ConflictGroup;
        private System.Windows.Forms.GroupBox ModuleGroup;
        private System.Windows.Forms.CheckedListBox ConflictList;
        private System.Windows.Forms.CheckedListBox ModuleList;
        private System.Windows.Forms.MenuStrip MenuBar;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem OpenModsButton;
        private System.Windows.Forms.ToolStripMenuItem ImportModButton;
        private System.Windows.Forms.OpenFileDialog ImportFileDialog;
        private System.Windows.Forms.ToolStripMenuItem OpenGameButton;
        private System.Windows.Forms.ToolStripMenuItem AboutButton;
        private System.Windows.Forms.SplitContainer PacksPane;
        private System.Windows.Forms.SplitContainer TopPane;
        private System.Windows.Forms.SplitContainer MainPane;
        private System.Windows.Forms.SplitContainer BottomPane;
        private System.Windows.Forms.SplitContainer OtherPane;
        private System.Windows.Forms.ContextMenuStrip PackContext;
        private System.Windows.Forms.ToolStripMenuItem UpdateButton;
        private System.Windows.Forms.GroupBox MetaGroup;
        private System.Windows.Forms.GroupBox ActionGroup;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button RunGameButton;
        private System.Windows.Forms.Button LoadButton;
        private System.Windows.Forms.Button RebuildButton;
        private System.Windows.Forms.SplitContainer DetailsPane;
        private System.Windows.Forms.PictureBox PackImage;
        private System.Windows.Forms.TableLayoutPanel MetaPane;
        private System.Windows.Forms.GroupBox NotesGroup;
        private System.Windows.Forms.TextBox NotesEdit;
        private System.Windows.Forms.TableLayoutPanel EditPane;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox NameEdit;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox AuthorEdit;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox FallbackEdit;
        private System.Windows.Forms.Splitter splitter1;
    }
}

