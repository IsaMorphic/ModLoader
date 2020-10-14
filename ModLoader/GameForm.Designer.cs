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
            this.Step1Label.Font = new System.Drawing.Font("Lucida Console", 11F);
            this.Step1Label.Location = new System.Drawing.Point(7, 5);
            this.Step1Label.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Step1Label.Name = "Step1Label";
            this.Step1Label.Size = new System.Drawing.Size(334, 23);
            this.Step1Label.TabIndex = 0;
            this.Step1Label.Text = "Step 1: Select Game Folder";
            this.Step1Label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // FolderBrowseButton
            // 
            this.FolderBrowseButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.FolderBrowseButton.Location = new System.Drawing.Point(7, 30);
            this.FolderBrowseButton.Margin = new System.Windows.Forms.Padding(2);
            this.FolderBrowseButton.Name = "FolderBrowseButton";
            this.FolderBrowseButton.Size = new System.Drawing.Size(331, 43);
            this.FolderBrowseButton.TabIndex = 2;
            this.FolderBrowseButton.Text = "Browse";
            this.FolderBrowseButton.UseVisualStyleBackColor = true;
            this.FolderBrowseButton.Click += new System.EventHandler(this.FolderBrowseButton_Click);
            // 
            // AddButton
            // 
            this.AddButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.AddButton.Location = new System.Drawing.Point(7, 173);
            this.AddButton.Margin = new System.Windows.Forms.Padding(2);
            this.AddButton.Name = "AddButton";
            this.AddButton.Size = new System.Drawing.Size(331, 43);
            this.AddButton.TabIndex = 7;
            this.AddButton.Text = "Add Game";
            this.AddButton.UseVisualStyleBackColor = true;
            this.AddButton.Click += new System.EventHandler(this.AddButton_Click);
            // 
            // Step33Label
            // 
            this.Step33Label.Font = new System.Drawing.Font("Lucida Console", 11F);
            this.Step33Label.Location = new System.Drawing.Point(7, 88);
            this.Step33Label.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Step33Label.Name = "Step33Label";
            this.Step33Label.Size = new System.Drawing.Size(331, 28);
            this.Step33Label.TabIndex = 8;
            this.Step33Label.Text = "Step 2: Name your game";
            this.Step33Label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // NameEntry
            // 
            this.NameEntry.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NameEntry.Location = new System.Drawing.Point(7, 118);
            this.NameEntry.Margin = new System.Windows.Forms.Padding(2);
            this.NameEntry.Name = "NameEntry";
            this.NameEntry.Size = new System.Drawing.Size(332, 41);
            this.NameEntry.TabIndex = 9;
            // 
            // GameForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(344, 235);
            this.Controls.Add(this.NameEntry);
            this.Controls.Add(this.Step33Label);
            this.Controls.Add(this.AddButton);
            this.Controls.Add(this.FolderBrowseButton);
            this.Controls.Add(this.Step1Label);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.Name = "GameForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Pack Builder";
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

