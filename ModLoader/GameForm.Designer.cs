namespace ModLoader
{
    partial class GameForm
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
            FolderDialog = new System.Windows.Forms.FolderBrowserDialog();
            Step1Label = new System.Windows.Forms.Label();
            FolderBrowseButton = new System.Windows.Forms.Button();
            AddButton = new System.Windows.Forms.Button();
            Step33Label = new System.Windows.Forms.Label();
            NameEntry = new System.Windows.Forms.TextBox();
            SuspendLayout();
            // 
            // Step1Label
            // 
            Step1Label.Font = new System.Drawing.Font("Lucida Console", 11F);
            Step1Label.Location = new System.Drawing.Point(11, 8);
            Step1Label.Name = "Step1Label";
            Step1Label.Size = new System.Drawing.Size(543, 37);
            Step1Label.TabIndex = 0;
            Step1Label.Text = "Step 1: Select Game Folder";
            Step1Label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // FolderBrowseButton
            // 
            FolderBrowseButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            FolderBrowseButton.Location = new System.Drawing.Point(11, 48);
            FolderBrowseButton.Name = "FolderBrowseButton";
            FolderBrowseButton.Size = new System.Drawing.Size(538, 69);
            FolderBrowseButton.TabIndex = 2;
            FolderBrowseButton.Text = "Browse";
            FolderBrowseButton.UseVisualStyleBackColor = true;
            FolderBrowseButton.Click += FolderBrowseButton_Click;
            // 
            // AddButton
            // 
            AddButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            AddButton.Location = new System.Drawing.Point(11, 277);
            AddButton.Name = "AddButton";
            AddButton.Size = new System.Drawing.Size(538, 69);
            AddButton.TabIndex = 7;
            AddButton.Text = "Add Game";
            AddButton.UseVisualStyleBackColor = true;
            AddButton.Click += AddButton_Click;
            // 
            // Step33Label
            // 
            Step33Label.Font = new System.Drawing.Font("Lucida Console", 11F);
            Step33Label.Location = new System.Drawing.Point(11, 141);
            Step33Label.Name = "Step33Label";
            Step33Label.Size = new System.Drawing.Size(538, 45);
            Step33Label.TabIndex = 8;
            Step33Label.Text = "Step 2: Name your game";
            Step33Label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // NameEntry
            // 
            NameEntry.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            NameEntry.Location = new System.Drawing.Point(11, 189);
            NameEntry.Name = "NameEntry";
            NameEntry.Size = new System.Drawing.Size(537, 38);
            NameEntry.TabIndex = 9;
            // 
            // GameForm
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(13F, 32F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(559, 376);
            Controls.Add(NameEntry);
            Controls.Add(Step33Label);
            Controls.Add(AddButton);
            Controls.Add(FolderBrowseButton);
            Controls.Add(Step1Label);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            Icon = new System.Drawing.Icon(GetType().Assembly
                .GetManifestResourceStream("ModLoader.Logo.Icon.ico"));
            MaximizeBox = false;
            Name = "GameForm";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "Add Game";
            ResumeLayout(false);
            PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FolderBrowserDialog FolderDialog;
        private System.Windows.Forms.Label Step1Label;
        private System.Windows.Forms.Button FolderBrowseButton;
        private System.Windows.Forms.Button AddButton;
        private System.Windows.Forms.Label Step33Label;
        private System.Windows.Forms.TextBox NameEntry;
    }
}

