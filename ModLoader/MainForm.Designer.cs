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
            this.ChangeGroup = new System.Windows.Forms.GroupBox();
            this.PackGroup = new System.Windows.Forms.GroupBox();
            this.PacksPane = new System.Windows.Forms.SplitContainer();
            this.PackList = new System.Windows.Forms.CheckedListBox();
            this.DetailsPane = new System.Windows.Forms.SplitContainer();
            this.PackImage = new System.Windows.Forms.PictureBox();
            this.NoteGroup = new System.Windows.Forms.GroupBox();
            this.PackNotes = new System.Windows.Forms.TextBox();
            this.PropGroup = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.FallbackLabel = new System.Windows.Forms.Label();
            this.FallbackSelect = new System.Windows.Forms.ComboBox();
            this.ActionGroup = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.RunGameButton = new System.Windows.Forms.Button();
            this.LoadButton = new System.Windows.Forms.Button();
            this.RebuildButton = new System.Windows.Forms.Button();
            this.ConflictGroup = new System.Windows.Forms.GroupBox();
            this.ConflictList = new System.Windows.Forms.CheckedListBox();
            this.ModuleGroup = new System.Windows.Forms.GroupBox();
            this.ModuleList = new System.Windows.Forms.CheckedListBox();
            this.MenuBar = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.OpenGameButton = new System.Windows.Forms.ToolStripMenuItem();
            this.OpenModsButton = new System.Windows.Forms.ToolStripMenuItem();
            this.ImportModButton = new System.Windows.Forms.ToolStripMenuItem();
            this.buildToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.BuildPackButton = new System.Windows.Forms.ToolStripMenuItem();
            this.BuildPatchButton = new System.Windows.Forms.ToolStripMenuItem();
            this.AboutButton = new System.Windows.Forms.ToolStripMenuItem();
            this.ImportFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.TopPane = new System.Windows.Forms.SplitContainer();
            this.MainPane = new System.Windows.Forms.SplitContainer();
            this.BottomPane = new System.Windows.Forms.SplitContainer();
            this.OtherPane = new System.Windows.Forms.SplitContainer();
            this.PropActionPane = new System.Windows.Forms.SplitContainer();
            this.ChangeGroup.SuspendLayout();
            this.PackGroup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PacksPane)).BeginInit();
            this.PacksPane.Panel1.SuspendLayout();
            this.PacksPane.Panel2.SuspendLayout();
            this.PacksPane.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DetailsPane)).BeginInit();
            this.DetailsPane.Panel1.SuspendLayout();
            this.DetailsPane.Panel2.SuspendLayout();
            this.DetailsPane.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PackImage)).BeginInit();
            this.NoteGroup.SuspendLayout();
            this.PropGroup.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.ActionGroup.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
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
            ((System.ComponentModel.ISupportInitialize)(this.PropActionPane)).BeginInit();
            this.PropActionPane.Panel1.SuspendLayout();
            this.PropActionPane.Panel2.SuspendLayout();
            this.PropActionPane.SuspendLayout();
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
            this.PacksPane.Panel2.Controls.Add(this.DetailsPane);
            this.PacksPane.Size = new System.Drawing.Size(1104, 608);
            this.PacksPane.SplitterDistance = 647;
            this.PacksPane.SplitterWidth = 8;
            this.PacksPane.TabIndex = 4;
            // 
            // PackList
            // 
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
            // DetailsPane
            // 
            this.DetailsPane.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DetailsPane.Location = new System.Drawing.Point(0, 0);
            this.DetailsPane.Margin = new System.Windows.Forms.Padding(6);
            this.DetailsPane.Name = "DetailsPane";
            this.DetailsPane.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // DetailsPane.Panel1
            // 
            this.DetailsPane.Panel1.Controls.Add(this.PackImage);
            // 
            // DetailsPane.Panel2
            // 
            this.DetailsPane.Panel2.Controls.Add(this.NoteGroup);
            this.DetailsPane.Size = new System.Drawing.Size(449, 608);
            this.DetailsPane.SplitterDistance = 397;
            this.DetailsPane.SplitterWidth = 7;
            this.DetailsPane.TabIndex = 0;
            // 
            // PackImage
            // 
            this.PackImage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PackImage.Location = new System.Drawing.Point(0, 0);
            this.PackImage.Margin = new System.Windows.Forms.Padding(6);
            this.PackImage.Name = "PackImage";
            this.PackImage.Size = new System.Drawing.Size(449, 397);
            this.PackImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.PackImage.TabIndex = 2;
            this.PackImage.TabStop = false;
            // 
            // NoteGroup
            // 
            this.NoteGroup.Controls.Add(this.PackNotes);
            this.NoteGroup.Dock = System.Windows.Forms.DockStyle.Fill;
            this.NoteGroup.Location = new System.Drawing.Point(0, 0);
            this.NoteGroup.Margin = new System.Windows.Forms.Padding(6);
            this.NoteGroup.Name = "NoteGroup";
            this.NoteGroup.Padding = new System.Windows.Forms.Padding(6);
            this.NoteGroup.Size = new System.Drawing.Size(449, 204);
            this.NoteGroup.TabIndex = 3;
            this.NoteGroup.TabStop = false;
            this.NoteGroup.Text = "Notes";
            // 
            // PackNotes
            // 
            this.PackNotes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PackNotes.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.PackNotes.Location = new System.Drawing.Point(6, 42);
            this.PackNotes.Margin = new System.Windows.Forms.Padding(6);
            this.PackNotes.Multiline = true;
            this.PackNotes.Name = "PackNotes";
            this.PackNotes.ReadOnly = true;
            this.PackNotes.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.PackNotes.Size = new System.Drawing.Size(437, 156);
            this.PackNotes.TabIndex = 0;
            // 
            // PropGroup
            // 
            this.PropGroup.Controls.Add(this.tableLayoutPanel2);
            this.PropGroup.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PropGroup.Enabled = false;
            this.PropGroup.Location = new System.Drawing.Point(0, 0);
            this.PropGroup.Margin = new System.Windows.Forms.Padding(6);
            this.PropGroup.Name = "PropGroup";
            this.PropGroup.Padding = new System.Windows.Forms.Padding(6);
            this.PropGroup.Size = new System.Drawing.Size(646, 240);
            this.PropGroup.TabIndex = 5;
            this.PropGroup.TabStop = false;
            this.PropGroup.Text = "Properties";
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 80F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 21F));
            this.tableLayoutPanel2.Controls.Add(this.FallbackLabel, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.FallbackSelect, 1, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(6, 42);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(4);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(634, 192);
            this.tableLayoutPanel2.TabIndex = 3;
            // 
            // FallbackLabel
            // 
            this.FallbackLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FallbackLabel.Location = new System.Drawing.Point(0, 0);
            this.FallbackLabel.Margin = new System.Windows.Forms.Padding(0);
            this.FallbackLabel.Name = "FallbackLabel";
            this.FallbackLabel.Size = new System.Drawing.Size(126, 192);
            this.FallbackLabel.TabIndex = 1;
            this.FallbackLabel.Text = "Fallback:";
            // 
            // FallbackSelect
            // 
            this.FallbackSelect.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FallbackSelect.FormattingEnabled = true;
            this.FallbackSelect.Location = new System.Drawing.Point(132, 6);
            this.FallbackSelect.Margin = new System.Windows.Forms.Padding(6);
            this.FallbackSelect.Name = "FallbackSelect";
            this.FallbackSelect.Size = new System.Drawing.Size(496, 45);
            this.FallbackSelect.TabIndex = 0;
            this.FallbackSelect.SelectedIndexChanged += new System.EventHandler(this.FallbackSelect_SelectedIndexChanged);
            // 
            // ActionGroup
            // 
            this.ActionGroup.Controls.Add(this.tableLayoutPanel1);
            this.ActionGroup.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ActionGroup.Location = new System.Drawing.Point(0, 0);
            this.ActionGroup.Margin = new System.Windows.Forms.Padding(6);
            this.ActionGroup.Name = "ActionGroup";
            this.ActionGroup.Padding = new System.Windows.Forms.Padding(6);
            this.ActionGroup.Size = new System.Drawing.Size(462, 240);
            this.ActionGroup.TabIndex = 6;
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
            this.tableLayoutPanel1.Size = new System.Drawing.Size(450, 192);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // RunGameButton
            // 
            this.RunGameButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.RunGameButton.Location = new System.Drawing.Point(6, 133);
            this.RunGameButton.Margin = new System.Windows.Forms.Padding(6);
            this.RunGameButton.Name = "RunGameButton";
            this.RunGameButton.Size = new System.Drawing.Size(438, 53);
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
            this.LoadButton.Size = new System.Drawing.Size(438, 52);
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
            this.RebuildButton.Size = new System.Drawing.Size(438, 51);
            this.RebuildButton.TabIndex = 4;
            this.RebuildButton.Text = "Rebuild Packs / Reload";
            this.RebuildButton.UseVisualStyleBackColor = true;
            this.RebuildButton.Click += new System.EventHandler(this.RebuildButton_Click);
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
            this.buildToolStripMenuItem,
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
            // buildToolStripMenuItem
            // 
            this.buildToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.BuildPackButton,
            this.BuildPatchButton});
            this.buildToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.buildToolStripMenuItem.Name = "buildToolStripMenuItem";
            this.buildToolStripMenuItem.Size = new System.Drawing.Size(99, 41);
            this.buildToolStripMenuItem.Text = "Build";
            // 
            // BuildPackButton
            // 
            this.BuildPackButton.Name = "BuildPackButton";
            this.BuildPackButton.Size = new System.Drawing.Size(231, 48);
            this.BuildPackButton.Text = "Pack";
            this.BuildPackButton.Click += new System.EventHandler(this.BuildPackButton_Click);
            // 
            // BuildPatchButton
            // 
            this.BuildPatchButton.Name = "BuildPatchButton";
            this.BuildPatchButton.Size = new System.Drawing.Size(231, 48);
            this.BuildPatchButton.Text = "Patch";
            this.BuildPatchButton.Click += new System.EventHandler(this.BuildPatchButton_Click);
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
            this.OtherPane.Panel1.Controls.Add(this.PropActionPane);
            // 
            // OtherPane.Panel2
            // 
            this.OtherPane.Panel2.Controls.Add(this.ModuleGroup);
            this.OtherPane.Size = new System.Drawing.Size(1116, 650);
            this.OtherPane.SplitterDistance = 240;
            this.OtherPane.SplitterWidth = 7;
            this.OtherPane.TabIndex = 10;
            // 
            // PropActionPane
            // 
            this.PropActionPane.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PropActionPane.Location = new System.Drawing.Point(0, 0);
            this.PropActionPane.Margin = new System.Windows.Forms.Padding(6);
            this.PropActionPane.Name = "PropActionPane";
            // 
            // PropActionPane.Panel1
            // 
            this.PropActionPane.Panel1.Controls.Add(this.PropGroup);
            // 
            // PropActionPane.Panel2
            // 
            this.PropActionPane.Panel2.Controls.Add(this.ActionGroup);
            this.PropActionPane.Size = new System.Drawing.Size(1116, 240);
            this.PropActionPane.SplitterDistance = 646;
            this.PropActionPane.SplitterWidth = 8;
            this.PropActionPane.TabIndex = 0;
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
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ChangeGroup.ResumeLayout(false);
            this.PackGroup.ResumeLayout(false);
            this.PacksPane.Panel1.ResumeLayout(false);
            this.PacksPane.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.PacksPane)).EndInit();
            this.PacksPane.ResumeLayout(false);
            this.DetailsPane.Panel1.ResumeLayout(false);
            this.DetailsPane.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DetailsPane)).EndInit();
            this.DetailsPane.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.PackImage)).EndInit();
            this.NoteGroup.ResumeLayout(false);
            this.NoteGroup.PerformLayout();
            this.PropGroup.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.ActionGroup.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
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
            this.PropActionPane.Panel1.ResumeLayout(false);
            this.PropActionPane.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.PropActionPane)).EndInit();
            this.PropActionPane.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox ChangeList;
        private System.Windows.Forms.GroupBox ChangeGroup;
        private System.Windows.Forms.GroupBox PackGroup;
        private System.Windows.Forms.CheckedListBox PackList;
        private System.Windows.Forms.GroupBox PropGroup;
        private System.Windows.Forms.GroupBox ActionGroup;
        private System.Windows.Forms.GroupBox ConflictGroup;
        private System.Windows.Forms.Label FallbackLabel;
        private System.Windows.Forms.ComboBox FallbackSelect;
        private System.Windows.Forms.PictureBox PackImage;
        private System.Windows.Forms.GroupBox ModuleGroup;
        private System.Windows.Forms.GroupBox NoteGroup;
        private System.Windows.Forms.TextBox PackNotes;
        private System.Windows.Forms.CheckedListBox ConflictList;
        private System.Windows.Forms.CheckedListBox ModuleList;
        private System.Windows.Forms.MenuStrip MenuBar;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem OpenModsButton;
        private System.Windows.Forms.ToolStripMenuItem ImportModButton;
        private System.Windows.Forms.ToolStripMenuItem buildToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem BuildPackButton;
        private System.Windows.Forms.ToolStripMenuItem BuildPatchButton;
        private System.Windows.Forms.OpenFileDialog ImportFileDialog;
        private System.Windows.Forms.ToolStripMenuItem OpenGameButton;
        private System.Windows.Forms.ToolStripMenuItem AboutButton;
        private System.Windows.Forms.SplitContainer PacksPane;
        private System.Windows.Forms.SplitContainer PropActionPane;
        private System.Windows.Forms.SplitContainer DetailsPane;
        private System.Windows.Forms.SplitContainer TopPane;
        private System.Windows.Forms.SplitContainer MainPane;
        private System.Windows.Forms.SplitContainer BottomPane;
        private System.Windows.Forms.SplitContainer OtherPane;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button RunGameButton;
        private System.Windows.Forms.Button LoadButton;
        private System.Windows.Forms.Button RebuildButton;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
    }
}

