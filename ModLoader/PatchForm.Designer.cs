namespace ModLoader
{
    partial class PatchForm
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
            this.Step1Label = new System.Windows.Forms.Label();
            this.OriginalButton = new System.Windows.Forms.Button();
            this.ModdedButton = new System.Windows.Forms.Button();
            this.Step2Label = new System.Windows.Forms.Label();
            this.FileDialog = new System.Windows.Forms.OpenFileDialog();
            this.BuildButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SaveButton = new System.Windows.Forms.Button();
            this.SaveDialog = new System.Windows.Forms.SaveFileDialog();
            this.SuspendLayout();
            // 
            // Step1Label
            // 
            this.Step1Label.Font = new System.Drawing.Font("Lucida Console", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Step1Label.Location = new System.Drawing.Point(7, 5);
            this.Step1Label.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Step1Label.Name = "Step1Label";
            this.Step1Label.Size = new System.Drawing.Size(334, 23);
            this.Step1Label.TabIndex = 0;
            this.Step1Label.Text = "Step 1: Select Original File";
            this.Step1Label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // OriginalButton
            // 
            this.OriginalButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.OriginalButton.Location = new System.Drawing.Point(7, 30);
            this.OriginalButton.Margin = new System.Windows.Forms.Padding(2);
            this.OriginalButton.Name = "OriginalButton";
            this.OriginalButton.Size = new System.Drawing.Size(331, 43);
            this.OriginalButton.TabIndex = 2;
            this.OriginalButton.Text = "Browse";
            this.OriginalButton.UseVisualStyleBackColor = true;
            this.OriginalButton.Click += new System.EventHandler(this.BrowseButton_Click);
            // 
            // ModdedButton
            // 
            this.ModdedButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ModdedButton.Location = new System.Drawing.Point(7, 128);
            this.ModdedButton.Margin = new System.Windows.Forms.Padding(2);
            this.ModdedButton.Name = "ModdedButton";
            this.ModdedButton.Size = new System.Drawing.Size(331, 43);
            this.ModdedButton.TabIndex = 3;
            this.ModdedButton.Text = "Browse";
            this.ModdedButton.UseVisualStyleBackColor = true;
            this.ModdedButton.Click += new System.EventHandler(this.BrowseButton_Click);
            // 
            // Step2Label
            // 
            this.Step2Label.Font = new System.Drawing.Font("Lucida Console", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Step2Label.Location = new System.Drawing.Point(7, 99);
            this.Step2Label.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Step2Label.Name = "Step2Label";
            this.Step2Label.Size = new System.Drawing.Size(331, 28);
            this.Step2Label.TabIndex = 4;
            this.Step2Label.Text = "Step 2: Select Modified File";
            this.Step2Label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // BuildButton
            // 
            this.BuildButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BuildButton.Location = new System.Drawing.Point(7, 317);
            this.BuildButton.Margin = new System.Windows.Forms.Padding(2);
            this.BuildButton.Name = "BuildButton";
            this.BuildButton.Size = new System.Drawing.Size(331, 43);
            this.BuildButton.TabIndex = 7;
            this.BuildButton.Text = "Build Patch";
            this.BuildButton.UseVisualStyleBackColor = true;
            this.BuildButton.Click += new System.EventHandler(this.BuildButton_Click);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Lucida Console", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(7, 203);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(331, 28);
            this.label1.TabIndex = 9;
            this.label1.Text = "Step 3: Select Output File";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // SaveButton
            // 
            this.SaveButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SaveButton.Location = new System.Drawing.Point(7, 232);
            this.SaveButton.Margin = new System.Windows.Forms.Padding(2);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(331, 43);
            this.SaveButton.TabIndex = 8;
            this.SaveButton.Text = "Browse";
            this.SaveButton.UseVisualStyleBackColor = true;
            this.SaveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // PatchForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(344, 372);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.SaveButton);
            this.Controls.Add(this.BuildButton);
            this.Controls.Add(this.Step2Label);
            this.Controls.Add(this.ModdedButton);
            this.Controls.Add(this.OriginalButton);
            this.Controls.Add(this.Step1Label);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.Name = "PatchForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Patch Builder";
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label Step1Label;
        private System.Windows.Forms.Button OriginalButton;
        private System.Windows.Forms.Button ModdedButton;
        private System.Windows.Forms.Label Step2Label;
        private System.Windows.Forms.OpenFileDialog FileDialog;
        private System.Windows.Forms.Button BuildButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button SaveButton;
        private System.Windows.Forms.SaveFileDialog SaveDialog;
    }
}

