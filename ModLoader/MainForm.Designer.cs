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
            components = new System.ComponentModel.Container();
            ChangeList = new System.Windows.Forms.ListBox();
            ChangeGroup = new System.Windows.Forms.GroupBox();
            PackGroup = new System.Windows.Forms.GroupBox();
            PacksPane = new System.Windows.Forms.SplitContainer();
            PackList = new System.Windows.Forms.CheckedListBox();
            PackContext = new System.Windows.Forms.ContextMenuStrip(components);
            UpdateButton = new System.Windows.Forms.ToolStripMenuItem();
            MetaGroup = new System.Windows.Forms.GroupBox();
            DetailsPane = new System.Windows.Forms.SplitContainer();
            PackImage = new System.Windows.Forms.PictureBox();
            MetaPane = new System.Windows.Forms.TableLayoutPanel();
            NotesGroup = new System.Windows.Forms.GroupBox();
            NotesEdit = new System.Windows.Forms.TextBox();
            EditPane = new System.Windows.Forms.TableLayoutPanel();
            label1 = new System.Windows.Forms.Label();
            NameEdit = new System.Windows.Forms.TextBox();
            label2 = new System.Windows.Forms.Label();
            AuthorEdit = new System.Windows.Forms.TextBox();
            label3 = new System.Windows.Forms.Label();
            FallbackEdit = new System.Windows.Forms.ComboBox();
            ConflictGroup = new System.Windows.Forms.GroupBox();
            ConflictList = new System.Windows.Forms.CheckedListBox();
            ModuleGroup = new System.Windows.Forms.GroupBox();
            ModuleList = new System.Windows.Forms.CheckedListBox();
            MenuBar = new System.Windows.Forms.MenuStrip();
            fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            OpenGameButton = new System.Windows.Forms.ToolStripMenuItem();
            OpenModsButton = new System.Windows.Forms.ToolStripMenuItem();
            ImportModButton = new System.Windows.Forms.ToolStripMenuItem();
            AboutButton = new System.Windows.Forms.ToolStripMenuItem();
            ImportFileDialog = new System.Windows.Forms.OpenFileDialog();
            TopPane = new System.Windows.Forms.SplitContainer();
            MainPane = new System.Windows.Forms.SplitContainer();
            BottomPane = new System.Windows.Forms.SplitContainer();
            OtherPane = new System.Windows.Forms.SplitContainer();
            ActionGroup = new System.Windows.Forms.GroupBox();
            tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            RunGameButton = new System.Windows.Forms.Button();
            LoadButton = new System.Windows.Forms.Button();
            RebuildButton = new System.Windows.Forms.Button();
            splitter1 = new System.Windows.Forms.Splitter();
            ChangeGroup.SuspendLayout();
            PackGroup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)PacksPane).BeginInit();
            PacksPane.Panel1.SuspendLayout();
            PacksPane.Panel2.SuspendLayout();
            PacksPane.SuspendLayout();
            PackContext.SuspendLayout();
            MetaGroup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)DetailsPane).BeginInit();
            DetailsPane.Panel1.SuspendLayout();
            DetailsPane.Panel2.SuspendLayout();
            DetailsPane.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)PackImage).BeginInit();
            MetaPane.SuspendLayout();
            NotesGroup.SuspendLayout();
            EditPane.SuspendLayout();
            ConflictGroup.SuspendLayout();
            ModuleGroup.SuspendLayout();
            MenuBar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)TopPane).BeginInit();
            TopPane.Panel1.SuspendLayout();
            TopPane.Panel2.SuspendLayout();
            TopPane.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)MainPane).BeginInit();
            MainPane.Panel1.SuspendLayout();
            MainPane.Panel2.SuspendLayout();
            MainPane.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)BottomPane).BeginInit();
            BottomPane.Panel1.SuspendLayout();
            BottomPane.Panel2.SuspendLayout();
            BottomPane.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)OtherPane).BeginInit();
            OtherPane.Panel1.SuspendLayout();
            OtherPane.Panel2.SuspendLayout();
            OtherPane.SuspendLayout();
            ActionGroup.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // ChangeList
            // 
            ChangeList.Dock = System.Windows.Forms.DockStyle.Fill;
            ChangeList.FormattingEnabled = true;
            ChangeList.HorizontalScrollbar = true;
            ChangeList.IntegralHeight = false;
            ChangeList.Location = new System.Drawing.Point(5, 37);
            ChangeList.Margin = new System.Windows.Forms.Padding(8, 8, 8, 8);
            ChangeList.Name = "ChangeList";
            ChangeList.Size = new System.Drawing.Size(473, 525);
            ChangeList.TabIndex = 1;
            ChangeList.SelectedIndexChanged += ChangeList_SelectedIndexChanged;
            // 
            // ChangeGroup
            // 
            ChangeGroup.Controls.Add(ChangeList);
            ChangeGroup.Dock = System.Windows.Forms.DockStyle.Fill;
            ChangeGroup.Location = new System.Drawing.Point(0, 0);
            ChangeGroup.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            ChangeGroup.Name = "ChangeGroup";
            ChangeGroup.Padding = new System.Windows.Forms.Padding(5, 5, 5, 5);
            ChangeGroup.Size = new System.Drawing.Size(483, 567);
            ChangeGroup.TabIndex = 3;
            ChangeGroup.TabStop = false;
            ChangeGroup.Text = "Changes";
            // 
            // PackGroup
            // 
            PackGroup.Controls.Add(PacksPane);
            PackGroup.Dock = System.Windows.Forms.DockStyle.Fill;
            PackGroup.Location = new System.Drawing.Point(0, 0);
            PackGroup.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            PackGroup.Name = "PackGroup";
            PackGroup.Padding = new System.Windows.Forms.Padding(5, 5, 5, 5);
            PackGroup.Size = new System.Drawing.Size(968, 567);
            PackGroup.TabIndex = 4;
            PackGroup.TabStop = false;
            PackGroup.Text = "Mod Packs";
            // 
            // PacksPane
            // 
            PacksPane.Dock = System.Windows.Forms.DockStyle.Fill;
            PacksPane.Location = new System.Drawing.Point(5, 37);
            PacksPane.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            PacksPane.Name = "PacksPane";
            // 
            // PacksPane.Panel1
            // 
            PacksPane.Panel1.Controls.Add(PackList);
            // 
            // PacksPane.Panel2
            // 
            PacksPane.Panel2.Controls.Add(MetaGroup);
            PacksPane.Size = new System.Drawing.Size(958, 525);
            PacksPane.SplitterDistance = 561;
            PacksPane.SplitterWidth = 7;
            PacksPane.TabIndex = 4;
            // 
            // PackList
            // 
            PackList.ContextMenuStrip = PackContext;
            PackList.Dock = System.Windows.Forms.DockStyle.Fill;
            PackList.FormattingEnabled = true;
            PackList.HorizontalScrollbar = true;
            PackList.IntegralHeight = false;
            PackList.Location = new System.Drawing.Point(0, 0);
            PackList.Margin = new System.Windows.Forms.Padding(8, 8, 8, 8);
            PackList.Name = "PackList";
            PackList.Size = new System.Drawing.Size(561, 525);
            PackList.TabIndex = 1;
            PackList.ItemCheck += PackList_ItemCheck;
            PackList.SelectedIndexChanged += PackList_SelectedIndexChanged;
            // 
            // PackContext
            // 
            PackContext.ImageScalingSize = new System.Drawing.Size(36, 36);
            PackContext.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { UpdateButton });
            PackContext.Name = "PackContext";
            PackContext.Size = new System.Drawing.Size(264, 42);
            // 
            // UpdateButton
            // 
            UpdateButton.Enabled = false;
            UpdateButton.Name = "UpdateButton";
            UpdateButton.Size = new System.Drawing.Size(263, 38);
            UpdateButton.Text = "Update Selected";
            UpdateButton.Click += UpdateButton_Click;
            // 
            // MetaGroup
            // 
            MetaGroup.Controls.Add(DetailsPane);
            MetaGroup.Dock = System.Windows.Forms.DockStyle.Fill;
            MetaGroup.Location = new System.Drawing.Point(0, 0);
            MetaGroup.Name = "MetaGroup";
            MetaGroup.Size = new System.Drawing.Size(390, 525);
            MetaGroup.TabIndex = 2;
            MetaGroup.TabStop = false;
            MetaGroup.Text = "Metadata";
            // 
            // DetailsPane
            // 
            DetailsPane.Dock = System.Windows.Forms.DockStyle.Fill;
            DetailsPane.Location = new System.Drawing.Point(3, 35);
            DetailsPane.Name = "DetailsPane";
            DetailsPane.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // DetailsPane.Panel1
            // 
            DetailsPane.Panel1.Controls.Add(PackImage);
            // 
            // DetailsPane.Panel2
            // 
            DetailsPane.Panel2.Controls.Add(MetaPane);
            DetailsPane.Size = new System.Drawing.Size(384, 487);
            DetailsPane.SplitterDistance = 126;
            DetailsPane.SplitterWidth = 3;
            DetailsPane.TabIndex = 0;
            // 
            // PackImage
            // 
            PackImage.Dock = System.Windows.Forms.DockStyle.Fill;
            PackImage.Location = new System.Drawing.Point(0, 0);
            PackImage.Name = "PackImage";
            PackImage.Size = new System.Drawing.Size(384, 126);
            PackImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            PackImage.TabIndex = 0;
            PackImage.TabStop = false;
            // 
            // MetaPane
            // 
            MetaPane.ColumnCount = 1;
            MetaPane.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            MetaPane.Controls.Add(NotesGroup, 0, 1);
            MetaPane.Controls.Add(EditPane, 0, 0);
            MetaPane.Dock = System.Windows.Forms.DockStyle.Fill;
            MetaPane.Location = new System.Drawing.Point(0, 0);
            MetaPane.Name = "MetaPane";
            MetaPane.RowCount = 2;
            MetaPane.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 49.99999F));
            MetaPane.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.00002F));
            MetaPane.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 17F));
            MetaPane.Size = new System.Drawing.Size(384, 358);
            MetaPane.TabIndex = 3;
            // 
            // NotesGroup
            // 
            NotesGroup.Controls.Add(NotesEdit);
            NotesGroup.Dock = System.Windows.Forms.DockStyle.Fill;
            NotesGroup.Location = new System.Drawing.Point(3, 181);
            NotesGroup.Name = "NotesGroup";
            NotesGroup.Size = new System.Drawing.Size(378, 174);
            NotesGroup.TabIndex = 8;
            NotesGroup.TabStop = false;
            NotesGroup.Text = "Notes:";
            // 
            // NotesEdit
            // 
            NotesEdit.Dock = System.Windows.Forms.DockStyle.Fill;
            NotesEdit.Location = new System.Drawing.Point(3, 35);
            NotesEdit.Multiline = true;
            NotesEdit.Name = "NotesEdit";
            NotesEdit.ReadOnly = true;
            NotesEdit.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            NotesEdit.Size = new System.Drawing.Size(372, 136);
            NotesEdit.TabIndex = 0;
            // 
            // EditPane
            // 
            EditPane.ColumnCount = 2;
            EditPane.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            EditPane.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 75F));
            EditPane.Controls.Add(label1, 0, 0);
            EditPane.Controls.Add(NameEdit, 1, 0);
            EditPane.Controls.Add(label2, 0, 1);
            EditPane.Controls.Add(AuthorEdit, 1, 1);
            EditPane.Controls.Add(label3, 0, 2);
            EditPane.Controls.Add(FallbackEdit, 1, 2);
            EditPane.Dock = System.Windows.Forms.DockStyle.Fill;
            EditPane.Location = new System.Drawing.Point(3, 3);
            EditPane.Name = "EditPane";
            EditPane.RowCount = 3;
            EditPane.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            EditPane.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            EditPane.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            EditPane.Size = new System.Drawing.Size(378, 172);
            EditPane.TabIndex = 7;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(3, 0);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(83, 32);
            label1.TabIndex = 0;
            label1.Text = "Name:";
            // 
            // NameEdit
            // 
            NameEdit.Dock = System.Windows.Forms.DockStyle.Fill;
            NameEdit.Location = new System.Drawing.Point(97, 3);
            NameEdit.Name = "NameEdit";
            NameEdit.ReadOnly = true;
            NameEdit.Size = new System.Drawing.Size(278, 39);
            NameEdit.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(3, 57);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(87, 57);
            label2.TabIndex = 2;
            label2.Text = "Author:";
            // 
            // AuthorEdit
            // 
            AuthorEdit.Dock = System.Windows.Forms.DockStyle.Fill;
            AuthorEdit.Location = new System.Drawing.Point(97, 60);
            AuthorEdit.Name = "AuthorEdit";
            AuthorEdit.ReadOnly = true;
            AuthorEdit.Size = new System.Drawing.Size(278, 39);
            AuthorEdit.TabIndex = 3;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new System.Drawing.Point(3, 114);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(86, 58);
            label3.TabIndex = 4;
            label3.Text = "Fallback:";
            // 
            // FallbackEdit
            // 
            FallbackEdit.Dock = System.Windows.Forms.DockStyle.Fill;
            FallbackEdit.Enabled = false;
            FallbackEdit.FormattingEnabled = true;
            FallbackEdit.Location = new System.Drawing.Point(97, 117);
            FallbackEdit.Name = "FallbackEdit";
            FallbackEdit.Size = new System.Drawing.Size(278, 40);
            FallbackEdit.TabIndex = 5;
            // 
            // ConflictGroup
            // 
            ConflictGroup.Controls.Add(ConflictList);
            ConflictGroup.Dock = System.Windows.Forms.DockStyle.Fill;
            ConflictGroup.Location = new System.Drawing.Point(0, 0);
            ConflictGroup.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            ConflictGroup.Name = "ConflictGroup";
            ConflictGroup.Padding = new System.Windows.Forms.Padding(5, 5, 5, 5);
            ConflictGroup.Size = new System.Drawing.Size(483, 563);
            ConflictGroup.TabIndex = 5;
            ConflictGroup.TabStop = false;
            ConflictGroup.Text = "Conflict";
            // 
            // ConflictList
            // 
            ConflictList.CheckOnClick = true;
            ConflictList.Dock = System.Windows.Forms.DockStyle.Fill;
            ConflictList.FormattingEnabled = true;
            ConflictList.HorizontalScrollbar = true;
            ConflictList.IntegralHeight = false;
            ConflictList.Location = new System.Drawing.Point(5, 37);
            ConflictList.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            ConflictList.Name = "ConflictList";
            ConflictList.Size = new System.Drawing.Size(473, 521);
            ConflictList.TabIndex = 0;
            ConflictList.ItemCheck += ModuleList_ItemCheck;
            // 
            // ModuleGroup
            // 
            ModuleGroup.Controls.Add(ModuleList);
            ModuleGroup.Dock = System.Windows.Forms.DockStyle.Fill;
            ModuleGroup.Location = new System.Drawing.Point(0, 0);
            ModuleGroup.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            ModuleGroup.Name = "ModuleGroup";
            ModuleGroup.Padding = new System.Windows.Forms.Padding(5, 5, 5, 5);
            ModuleGroup.Size = new System.Drawing.Size(968, 350);
            ModuleGroup.TabIndex = 4;
            ModuleGroup.TabStop = false;
            ModuleGroup.Text = "Modules";
            // 
            // ModuleList
            // 
            ModuleList.CheckOnClick = true;
            ModuleList.Dock = System.Windows.Forms.DockStyle.Fill;
            ModuleList.FormattingEnabled = true;
            ModuleList.HorizontalScrollbar = true;
            ModuleList.IntegralHeight = false;
            ModuleList.Location = new System.Drawing.Point(5, 37);
            ModuleList.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            ModuleList.Name = "ModuleList";
            ModuleList.Size = new System.Drawing.Size(958, 308);
            ModuleList.TabIndex = 1;
            ModuleList.ItemCheck += ModuleList_ItemCheck;
            // 
            // MenuBar
            // 
            MenuBar.BackColor = System.Drawing.SystemColors.ControlLight;
            MenuBar.ImageScalingSize = new System.Drawing.Size(36, 36);
            MenuBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { fileToolStripMenuItem, AboutButton });
            MenuBar.Location = new System.Drawing.Point(0, 0);
            MenuBar.Name = "MenuBar";
            MenuBar.Padding = new System.Windows.Forms.Padding(10, 3, 0, 3);
            MenuBar.Size = new System.Drawing.Size(1458, 42);
            MenuBar.TabIndex = 7;
            MenuBar.Text = "MenuBar";
            // 
            // fileToolStripMenuItem
            // 
            fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { OpenGameButton, OpenModsButton, ImportModButton });
            fileToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 9F);
            fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            fileToolStripMenuItem.Size = new System.Drawing.Size(71, 36);
            fileToolStripMenuItem.Text = "File";
            // 
            // OpenGameButton
            // 
            OpenGameButton.Name = "OpenGameButton";
            OpenGameButton.Size = new System.Drawing.Size(379, 44);
            OpenGameButton.Text = "Open Game Directory";
            OpenGameButton.Click += OpenGameButton_Click;
            // 
            // OpenModsButton
            // 
            OpenModsButton.Name = "OpenModsButton";
            OpenModsButton.Size = new System.Drawing.Size(379, 44);
            OpenModsButton.Text = "Open Mod Directory";
            OpenModsButton.Click += OpenModsButton_Click;
            // 
            // ImportModButton
            // 
            ImportModButton.Name = "ImportModButton";
            ImportModButton.Size = new System.Drawing.Size(379, 44);
            ImportModButton.Text = "Import Mod";
            ImportModButton.Click += ImportModButton_Click;
            // 
            // AboutButton
            // 
            AboutButton.Name = "AboutButton";
            AboutButton.Size = new System.Drawing.Size(99, 36);
            AboutButton.Text = "About";
            AboutButton.Click += AboutButton_Click;
            // 
            // ImportFileDialog
            // 
            ImportFileDialog.DefaultExt = "zip";
            ImportFileDialog.Filter = "ModLoader Pack Files|*.zip";
            // 
            // TopPane
            // 
            TopPane.Dock = System.Windows.Forms.DockStyle.Fill;
            TopPane.Location = new System.Drawing.Point(0, 0);
            TopPane.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            TopPane.Name = "TopPane";
            // 
            // TopPane.Panel1
            // 
            TopPane.Panel1.Controls.Add(ChangeGroup);
            // 
            // TopPane.Panel2
            // 
            TopPane.Panel2.Controls.Add(PackGroup);
            TopPane.Size = new System.Drawing.Size(1458, 567);
            TopPane.SplitterDistance = 483;
            TopPane.SplitterWidth = 7;
            TopPane.TabIndex = 8;
            // 
            // MainPane
            // 
            MainPane.Dock = System.Windows.Forms.DockStyle.Fill;
            MainPane.Location = new System.Drawing.Point(0, 42);
            MainPane.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            MainPane.Name = "MainPane";
            MainPane.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // MainPane.Panel1
            // 
            MainPane.Panel1.Controls.Add(TopPane);
            // 
            // MainPane.Panel2
            // 
            MainPane.Panel2.Controls.Add(BottomPane);
            MainPane.Size = new System.Drawing.Size(1458, 1136);
            MainPane.SplitterDistance = 567;
            MainPane.SplitterWidth = 6;
            MainPane.TabIndex = 9;
            // 
            // BottomPane
            // 
            BottomPane.Dock = System.Windows.Forms.DockStyle.Fill;
            BottomPane.Location = new System.Drawing.Point(0, 0);
            BottomPane.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            BottomPane.Name = "BottomPane";
            // 
            // BottomPane.Panel1
            // 
            BottomPane.Panel1.Controls.Add(ConflictGroup);
            // 
            // BottomPane.Panel2
            // 
            BottomPane.Panel2.Controls.Add(OtherPane);
            BottomPane.Size = new System.Drawing.Size(1458, 563);
            BottomPane.SplitterDistance = 483;
            BottomPane.SplitterWidth = 7;
            BottomPane.TabIndex = 0;
            // 
            // OtherPane
            // 
            OtherPane.Dock = System.Windows.Forms.DockStyle.Fill;
            OtherPane.Location = new System.Drawing.Point(0, 0);
            OtherPane.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            OtherPane.Name = "OtherPane";
            OtherPane.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // OtherPane.Panel1
            // 
            OtherPane.Panel1.Controls.Add(ActionGroup);
            // 
            // OtherPane.Panel2
            // 
            OtherPane.Panel2.Controls.Add(ModuleGroup);
            OtherPane.Size = new System.Drawing.Size(968, 563);
            OtherPane.SplitterDistance = 207;
            OtherPane.SplitterWidth = 6;
            OtherPane.TabIndex = 10;
            // 
            // ActionGroup
            // 
            ActionGroup.Controls.Add(tableLayoutPanel1);
            ActionGroup.Dock = System.Windows.Forms.DockStyle.Fill;
            ActionGroup.Location = new System.Drawing.Point(0, 0);
            ActionGroup.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            ActionGroup.Name = "ActionGroup";
            ActionGroup.Padding = new System.Windows.Forms.Padding(5, 5, 5, 5);
            ActionGroup.Size = new System.Drawing.Size(968, 207);
            ActionGroup.TabIndex = 7;
            ActionGroup.TabStop = false;
            ActionGroup.Text = "Actions";
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 1;
            tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            tableLayoutPanel1.Controls.Add(RunGameButton, 0, 2);
            tableLayoutPanel1.Controls.Add(LoadButton, 0, 1);
            tableLayoutPanel1.Controls.Add(RebuildButton, 0, 0);
            tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            tableLayoutPanel1.Location = new System.Drawing.Point(5, 37);
            tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 3;
            tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33334F));
            tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            tableLayoutPanel1.Size = new System.Drawing.Size(958, 165);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // RunGameButton
            // 
            RunGameButton.Dock = System.Windows.Forms.DockStyle.Fill;
            RunGameButton.Location = new System.Drawing.Point(5, 114);
            RunGameButton.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            RunGameButton.Name = "RunGameButton";
            RunGameButton.Size = new System.Drawing.Size(948, 46);
            RunGameButton.TabIndex = 7;
            RunGameButton.Text = "Launch Game";
            RunGameButton.UseVisualStyleBackColor = true;
            RunGameButton.Click += RunGameButton_Click;
            // 
            // LoadButton
            // 
            LoadButton.Dock = System.Windows.Forms.DockStyle.Fill;
            LoadButton.Location = new System.Drawing.Point(5, 59);
            LoadButton.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            LoadButton.Name = "LoadButton";
            LoadButton.Size = new System.Drawing.Size(948, 45);
            LoadButton.TabIndex = 6;
            LoadButton.Text = "Load All Mods";
            LoadButton.UseVisualStyleBackColor = true;
            LoadButton.Click += LoadButton_Click;
            // 
            // RebuildButton
            // 
            RebuildButton.Dock = System.Windows.Forms.DockStyle.Fill;
            RebuildButton.Location = new System.Drawing.Point(5, 5);
            RebuildButton.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            RebuildButton.Name = "RebuildButton";
            RebuildButton.Size = new System.Drawing.Size(948, 44);
            RebuildButton.TabIndex = 4;
            RebuildButton.Text = "Rebuild Packs / Reload";
            RebuildButton.UseVisualStyleBackColor = true;
            RebuildButton.Click += RebuildButton_Click;
            // 
            // splitter1
            // 
            splitter1.Location = new System.Drawing.Point(3, 39);
            splitter1.Name = "splitter1";
            splitter1.Size = new System.Drawing.Size(10, 142);
            splitter1.TabIndex = 1;
            splitter1.TabStop = false;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(13F, 32F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(1458, 1178);
            Controls.Add(MainPane);
            Controls.Add(MenuBar);
            Icon = new System.Drawing.Icon(GetType().Assembly
                .GetManifestResourceStream("ModLoader.Logo.Icon.ico"));
            MainMenuStrip = MenuBar;
            Margin = new System.Windows.Forms.Padding(8, 8, 8, 8);
            Name = "MainForm";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "ModLoader";
            FormClosing += MainForm_FormClosing;
            Load += MainForm_Load;
            ChangeGroup.ResumeLayout(false);
            PackGroup.ResumeLayout(false);
            PacksPane.Panel1.ResumeLayout(false);
            PacksPane.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)PacksPane).EndInit();
            PacksPane.ResumeLayout(false);
            PackContext.ResumeLayout(false);
            MetaGroup.ResumeLayout(false);
            DetailsPane.Panel1.ResumeLayout(false);
            DetailsPane.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)DetailsPane).EndInit();
            DetailsPane.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)PackImage).EndInit();
            MetaPane.ResumeLayout(false);
            NotesGroup.ResumeLayout(false);
            NotesGroup.PerformLayout();
            EditPane.ResumeLayout(false);
            EditPane.PerformLayout();
            ConflictGroup.ResumeLayout(false);
            ModuleGroup.ResumeLayout(false);
            MenuBar.ResumeLayout(false);
            MenuBar.PerformLayout();
            TopPane.Panel1.ResumeLayout(false);
            TopPane.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)TopPane).EndInit();
            TopPane.ResumeLayout(false);
            MainPane.Panel1.ResumeLayout(false);
            MainPane.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)MainPane).EndInit();
            MainPane.ResumeLayout(false);
            BottomPane.Panel1.ResumeLayout(false);
            BottomPane.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)BottomPane).EndInit();
            BottomPane.ResumeLayout(false);
            OtherPane.Panel1.ResumeLayout(false);
            OtherPane.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)OtherPane).EndInit();
            OtherPane.ResumeLayout(false);
            ActionGroup.ResumeLayout(false);
            tableLayoutPanel1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();

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

