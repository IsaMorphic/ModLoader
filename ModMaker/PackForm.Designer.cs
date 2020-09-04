namespace ModMaker
{
    partial class PackForm
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
            this.ImageBrowseButton = new System.Windows.Forms.Button();
            this.Step2Label = new System.Windows.Forms.Label();
            this.NoteEntry = new System.Windows.Forms.TextBox();
            this.Step4Label = new System.Windows.Forms.Label();
            this.ImageDialog = new System.Windows.Forms.OpenFileDialog();
            this.BuildButton = new System.Windows.Forms.Button();
            this.Step33Label = new System.Windows.Forms.Label();
            this.NameEntry = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // Step1Label
            // 
            this.Step1Label.Font = new System.Drawing.Font("Lucida Console", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Step1Label.Location = new System.Drawing.Point(7, 5);
            this.Step1Label.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Step1Label.Name = "Step1Label";
            this.Step1Label.Size = new System.Drawing.Size(334, 23);
            this.Step1Label.TabIndex = 0;
            this.Step1Label.Text = "Step 1: Select Pack Folder";
            this.Step1Label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // FolderBrowseButton
            // 
            this.FolderBrowseButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FolderBrowseButton.Location = new System.Drawing.Point(7, 30);
            this.FolderBrowseButton.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.FolderBrowseButton.Name = "FolderBrowseButton";
            this.FolderBrowseButton.Size = new System.Drawing.Size(331, 43);
            this.FolderBrowseButton.TabIndex = 2;
            this.FolderBrowseButton.Text = "Browse";
            this.FolderBrowseButton.UseVisualStyleBackColor = true;
            this.FolderBrowseButton.Click += new System.EventHandler(this.FolderBrowseButton_Click);
            // 
            // ImageBrowseButton
            // 
            this.ImageBrowseButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ImageBrowseButton.Location = new System.Drawing.Point(7, 128);
            this.ImageBrowseButton.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.ImageBrowseButton.Name = "ImageBrowseButton";
            this.ImageBrowseButton.Size = new System.Drawing.Size(331, 43);
            this.ImageBrowseButton.TabIndex = 3;
            this.ImageBrowseButton.Text = "Browse";
            this.ImageBrowseButton.UseVisualStyleBackColor = true;
            this.ImageBrowseButton.Click += new System.EventHandler(this.ImageBrowseButton_Click);
            // 
            // Step2Label
            // 
            this.Step2Label.Font = new System.Drawing.Font("Lucida Console", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Step2Label.Location = new System.Drawing.Point(7, 99);
            this.Step2Label.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Step2Label.Name = "Step2Label";
            this.Step2Label.Size = new System.Drawing.Size(331, 28);
            this.Step2Label.TabIndex = 4;
            this.Step2Label.Text = "Step 2: Select Pack Image";
            this.Step2Label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // NoteEntry
            // 
            this.NoteEntry.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NoteEntry.Location = new System.Drawing.Point(7, 290);
            this.NoteEntry.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.NoteEntry.Multiline = true;
            this.NoteEntry.Name = "NoteEntry";
            this.NoteEntry.Size = new System.Drawing.Size(332, 63);
            this.NoteEntry.TabIndex = 5;
            // 
            // Step4Label
            // 
            this.Step4Label.Font = new System.Drawing.Font("Lucida Console", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Step4Label.Location = new System.Drawing.Point(7, 260);
            this.Step4Label.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Step4Label.Name = "Step4Label";
            this.Step4Label.Size = new System.Drawing.Size(331, 28);
            this.Step4Label.TabIndex = 6;
            this.Step4Label.Text = "Step 4: Describe your Mod";
            this.Step4Label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // BuildButton
            // 
            this.BuildButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BuildButton.Location = new System.Drawing.Point(7, 382);
            this.BuildButton.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.BuildButton.Name = "BuildButton";
            this.BuildButton.Size = new System.Drawing.Size(331, 43);
            this.BuildButton.TabIndex = 7;
            this.BuildButton.Text = "Build Pack";
            this.BuildButton.UseVisualStyleBackColor = true;
            this.BuildButton.Click += new System.EventHandler(this.BuildButton_Click);
            // 
            // Step33Label
            // 
            this.Step33Label.Font = new System.Drawing.Font("Lucida Console", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Step33Label.Location = new System.Drawing.Point(7, 192);
            this.Step33Label.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Step33Label.Name = "Step33Label";
            this.Step33Label.Size = new System.Drawing.Size(331, 28);
            this.Step33Label.TabIndex = 8;
            this.Step33Label.Text = "Step 3: Name your Mod";
            this.Step33Label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // NameEntry
            // 
            this.NameEntry.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NameEntry.Location = new System.Drawing.Point(7, 222);
            this.NameEntry.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.NameEntry.Name = "NameEntry";
            this.NameEntry.Size = new System.Drawing.Size(332, 26);
            this.NameEntry.TabIndex = 9;
            // 
            // PackForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(344, 432);
            this.Controls.Add(this.NameEntry);
            this.Controls.Add(this.Step33Label);
            this.Controls.Add(this.BuildButton);
            this.Controls.Add(this.Step4Label);
            this.Controls.Add(this.NoteEntry);
            this.Controls.Add(this.Step2Label);
            this.Controls.Add(this.ImageBrowseButton);
            this.Controls.Add(this.FolderBrowseButton);
            this.Controls.Add(this.Step1Label);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.MaximizeBox = false;
            this.Name = "PackForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Pack Builder";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FolderBrowserDialog FolderDialog;
        private System.Windows.Forms.Label Step1Label;
        private System.Windows.Forms.Button FolderBrowseButton;
        private System.Windows.Forms.Button ImageBrowseButton;
        private System.Windows.Forms.Label Step2Label;
        private System.Windows.Forms.TextBox NoteEntry;
        private System.Windows.Forms.Label Step4Label;
        private System.Windows.Forms.OpenFileDialog ImageDialog;
        private System.Windows.Forms.Button BuildButton;
        private System.Windows.Forms.Label Step33Label;
        private System.Windows.Forms.TextBox NameEntry;
    }
}

