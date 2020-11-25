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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GameForm));
            this.FolderDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.Step1Label = new System.Windows.Forms.Label();
            this.FolderBrowseButton = new System.Windows.Forms.Button();
            this.AddButton = new System.Windows.Forms.Button();
            this.Step33Label = new System.Windows.Forms.Label();
            this.NameEntry = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // Step1Label
            // 
            this.Step1Label.Font = new System.Drawing.Font("Lucida Console", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Step1Label.Location = new System.Drawing.Point(13, 9);
            this.Step1Label.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Step1Label.Name = "Step1Label";
            this.Step1Label.Size = new System.Drawing.Size(626, 43);
            this.Step1Label.TabIndex = 0;
            this.Step1Label.Text = "Step 1: Select Game Folder";
            this.Step1Label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // FolderBrowseButton
            // 
            this.FolderBrowseButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.FolderBrowseButton.Location = new System.Drawing.Point(13, 56);
            this.FolderBrowseButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.FolderBrowseButton.Name = "FolderBrowseButton";
            this.FolderBrowseButton.Size = new System.Drawing.Size(621, 80);
            this.FolderBrowseButton.TabIndex = 2;
            this.FolderBrowseButton.Text = "Browse";
            this.FolderBrowseButton.UseVisualStyleBackColor = true;
            this.FolderBrowseButton.Click += new System.EventHandler(this.FolderBrowseButton_Click);
            // 
            // AddButton
            // 
            this.AddButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.AddButton.Location = new System.Drawing.Point(13, 320);
            this.AddButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.AddButton.Name = "AddButton";
            this.AddButton.Size = new System.Drawing.Size(621, 80);
            this.AddButton.TabIndex = 7;
            this.AddButton.Text = "Add Game";
            this.AddButton.UseVisualStyleBackColor = true;
            this.AddButton.Click += new System.EventHandler(this.AddButton_Click);
            // 
            // Step33Label
            // 
            this.Step33Label.Font = new System.Drawing.Font("Lucida Console", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Step33Label.Location = new System.Drawing.Point(13, 163);
            this.Step33Label.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Step33Label.Name = "Step33Label";
            this.Step33Label.Size = new System.Drawing.Size(621, 52);
            this.Step33Label.TabIndex = 8;
            this.Step33Label.Text = "Step 2: Name your game";
            this.Step33Label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // NameEntry
            // 
            this.NameEntry.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.NameEntry.Location = new System.Drawing.Point(13, 218);
            this.NameEntry.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.NameEntry.Name = "NameEntry";
            this.NameEntry.Size = new System.Drawing.Size(619, 41);
            this.NameEntry.TabIndex = 9;
            // 
            // GameForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(15F, 37F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(645, 435);
            this.Controls.Add(this.NameEntry);
            this.Controls.Add(this.Step33Label);
            this.Controls.Add(this.AddButton);
            this.Controls.Add(this.FolderBrowseButton);
            this.Controls.Add(this.Step1Label);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MaximizeBox = false;
            this.Name = "GameForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Add Game";
            this.ResumeLayout(false);
            this.PerformLayout();

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

