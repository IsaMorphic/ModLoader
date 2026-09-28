namespace ModLoader
{
    partial class ManagerForm
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
            GameList = new System.Windows.Forms.ListBox();
            ModuleGroup = new System.Windows.Forms.GroupBox();
            LoadGameButton = new System.Windows.Forms.Button();
            AddGameButton = new System.Windows.Forms.Button();
            RemoveGameButton = new System.Windows.Forms.Button();
            menuStrip = new System.Windows.Forms.MenuStrip();
            fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            setHomeDirectoryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            ModuleGroup.SuspendLayout();
            menuStrip.SuspendLayout();
            SuspendLayout();
            // 
            // GameList
            // 
            GameList.FormattingEnabled = true;
            GameList.HorizontalScrollbar = true;
            GameList.IntegralHeight = false;
            GameList.Location = new System.Drawing.Point(13, 37);
            GameList.Margin = new System.Windows.Forms.Padding(8);
            GameList.Name = "GameList";
            GameList.Size = new System.Drawing.Size(1039, 375);
            GameList.TabIndex = 1;
            GameList.SelectedIndexChanged += GameList_SelectedIndexChanged;
            // 
            // ModuleGroup
            // 
            ModuleGroup.Controls.Add(GameList);
            ModuleGroup.Location = new System.Drawing.Point(19, 45);
            ModuleGroup.Margin = new System.Windows.Forms.Padding(5);
            ModuleGroup.Name = "ModuleGroup";
            ModuleGroup.Padding = new System.Windows.Forms.Padding(5);
            ModuleGroup.Size = new System.Drawing.Size(1068, 425);
            ModuleGroup.TabIndex = 3;
            ModuleGroup.TabStop = false;
            ModuleGroup.Text = "Games";
            // 
            // LoadGameButton
            // 
            LoadGameButton.Enabled = false;
            LoadGameButton.Location = new System.Drawing.Point(392, 482);
            LoadGameButton.Margin = new System.Windows.Forms.Padding(5);
            LoadGameButton.Name = "LoadGameButton";
            LoadGameButton.Size = new System.Drawing.Size(338, 75);
            LoadGameButton.TabIndex = 4;
            LoadGameButton.Text = "Load Game";
            LoadGameButton.UseVisualStyleBackColor = true;
            LoadGameButton.Click += LoadGameButton_Click;
            // 
            // AddGameButton
            // 
            AddGameButton.Location = new System.Drawing.Point(19, 482);
            AddGameButton.Margin = new System.Windows.Forms.Padding(5);
            AddGameButton.Name = "AddGameButton";
            AddGameButton.Size = new System.Drawing.Size(362, 75);
            AddGameButton.TabIndex = 5;
            AddGameButton.Text = "Add Game";
            AddGameButton.UseVisualStyleBackColor = true;
            AddGameButton.Click += AddGameButton_Click;
            // 
            // RemoveGameButton
            // 
            RemoveGameButton.Enabled = false;
            RemoveGameButton.Location = new System.Drawing.Point(739, 482);
            RemoveGameButton.Margin = new System.Windows.Forms.Padding(5);
            RemoveGameButton.Name = "RemoveGameButton";
            RemoveGameButton.Size = new System.Drawing.Size(348, 75);
            RemoveGameButton.TabIndex = 6;
            RemoveGameButton.Text = "Remove Game (Careful!)";
            RemoveGameButton.UseVisualStyleBackColor = true;
            RemoveGameButton.Click += RemoveGameButton_Click;
            // 
            // menuStrip
            // 
            menuStrip.ImageScalingSize = new System.Drawing.Size(32, 32);
            menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { fileToolStripMenuItem });
            menuStrip.Location = new System.Drawing.Point(0, 0);
            menuStrip.Name = "menuStrip";
            menuStrip.Size = new System.Drawing.Size(1107, 40);
            menuStrip.TabIndex = 7;
            menuStrip.Text = "menuStrip";
            // 
            // fileToolStripMenuItem
            // 
            fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { setHomeDirectoryToolStripMenuItem });
            fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            fileToolStripMenuItem.Size = new System.Drawing.Size(71, 36);
            fileToolStripMenuItem.Text = "File";
            // 
            // setHomeDirectoryToolStripMenuItem
            // 
            setHomeDirectoryToolStripMenuItem.Name = "setHomeDirectoryToolStripMenuItem";
            setHomeDirectoryToolStripMenuItem.Size = new System.Drawing.Size(357, 44);
            setHomeDirectoryToolStripMenuItem.Text = "Set Home Directory";
            setHomeDirectoryToolStripMenuItem.Click += setHomeDirectoryToolStripMenuItem_Click;
            // 
            // ManagerForm
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(13F, 32F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(1107, 576);
            Controls.Add(RemoveGameButton);
            Controls.Add(AddGameButton);
            Controls.Add(LoadGameButton);
            Controls.Add(ModuleGroup);
            Controls.Add(menuStrip);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            MainMenuStrip = menuStrip;
            Margin = new System.Windows.Forms.Padding(8);
            MaximizeBox = false;
            Name = "ManagerForm";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Icon = new System.Drawing.Icon(GetType().Assembly
                .GetManifestResourceStream("ModLoader.Logo.Icon.ico"));
            Text = "Game Manager";
            Load += ManagerForm_Load;
            ModuleGroup.ResumeLayout(false);
            menuStrip.ResumeLayout(false);
            menuStrip.PerformLayout();
            ResumeLayout(false);
            PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox GameList;
        private System.Windows.Forms.GroupBox ModuleGroup;
        private System.Windows.Forms.Button LoadGameButton;
        private System.Windows.Forms.Button AddGameButton;
        private System.Windows.Forms.Button RemoveGameButton;
        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem setHomeDirectoryToolStripMenuItem;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog;
    }
}

