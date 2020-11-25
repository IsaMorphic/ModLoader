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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ManagerForm));
            this.GameList = new System.Windows.Forms.ListBox();
            this.ModuleGroup = new System.Windows.Forms.GroupBox();
            this.LoadGameButton = new System.Windows.Forms.Button();
            this.AddGameButton = new System.Windows.Forms.Button();
            this.RemoveGameButton = new System.Windows.Forms.Button();
            this.ModuleGroup.SuspendLayout();
            this.SuspendLayout();
            // 
            // GameList
            // 
            this.GameList.FormattingEnabled = true;
            this.GameList.HorizontalScrollbar = true;
            this.GameList.IntegralHeight = false;
            this.GameList.ItemHeight = 37;
            this.GameList.Location = new System.Drawing.Point(15, 43);
            this.GameList.Margin = new System.Windows.Forms.Padding(9, 9, 9, 9);
            this.GameList.Name = "GameList";
            this.GameList.Size = new System.Drawing.Size(1198, 461);
            this.GameList.TabIndex = 1;
            this.GameList.SelectedIndexChanged += new System.EventHandler(this.GameList_SelectedIndexChanged);
            // 
            // ModuleGroup
            // 
            this.ModuleGroup.Controls.Add(this.GameList);
            this.ModuleGroup.Location = new System.Drawing.Point(22, 22);
            this.ModuleGroup.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.ModuleGroup.Name = "ModuleGroup";
            this.ModuleGroup.Padding = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.ModuleGroup.Size = new System.Drawing.Size(1232, 522);
            this.ModuleGroup.TabIndex = 3;
            this.ModuleGroup.TabStop = false;
            this.ModuleGroup.Text = "Games";
            // 
            // LoadGameButton
            // 
            this.LoadGameButton.Enabled = false;
            this.LoadGameButton.Location = new System.Drawing.Point(452, 557);
            this.LoadGameButton.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.LoadGameButton.Name = "LoadGameButton";
            this.LoadGameButton.Size = new System.Drawing.Size(390, 87);
            this.LoadGameButton.TabIndex = 4;
            this.LoadGameButton.Text = "Load Game";
            this.LoadGameButton.UseVisualStyleBackColor = true;
            this.LoadGameButton.Click += new System.EventHandler(this.LoadGameButton_Click);
            // 
            // AddGameButton
            // 
            this.AddGameButton.Location = new System.Drawing.Point(22, 557);
            this.AddGameButton.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.AddGameButton.Name = "AddGameButton";
            this.AddGameButton.Size = new System.Drawing.Size(418, 87);
            this.AddGameButton.TabIndex = 5;
            this.AddGameButton.Text = "Add Game";
            this.AddGameButton.UseVisualStyleBackColor = true;
            this.AddGameButton.Click += new System.EventHandler(this.AddGameButton_Click);
            // 
            // RemoveGameButton
            // 
            this.RemoveGameButton.Enabled = false;
            this.RemoveGameButton.Location = new System.Drawing.Point(853, 557);
            this.RemoveGameButton.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.RemoveGameButton.Name = "RemoveGameButton";
            this.RemoveGameButton.Size = new System.Drawing.Size(401, 87);
            this.RemoveGameButton.TabIndex = 6;
            this.RemoveGameButton.Text = "Remove Game (Careful!)";
            this.RemoveGameButton.UseVisualStyleBackColor = true;
            this.RemoveGameButton.Click += new System.EventHandler(this.RemoveGameButton_Click);
            // 
            // ManagerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(15F, 37F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1277, 666);
            this.Controls.Add(this.RemoveGameButton);
            this.Controls.Add(this.AddGameButton);
            this.Controls.Add(this.LoadGameButton);
            this.Controls.Add(this.ModuleGroup);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(9, 9, 9, 9);
            this.MaximizeBox = false;
            this.Name = "ManagerForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Game Manager";
            this.Load += new System.EventHandler(this.ManagerForm_Load);
            this.ModuleGroup.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox GameList;
        private System.Windows.Forms.GroupBox ModuleGroup;
        private System.Windows.Forms.Button LoadGameButton;
        private System.Windows.Forms.Button AddGameButton;
        private System.Windows.Forms.Button RemoveGameButton;
    }
}

