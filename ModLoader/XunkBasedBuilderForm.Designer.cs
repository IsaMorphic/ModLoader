namespace ModLoader
{
    partial class XunkBasedBuilderForm<T>
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
            openFileDialog = new System.Windows.Forms.OpenFileDialog();
            origFilePathBox = new System.Windows.Forms.TextBox();
            label1 = new System.Windows.Forms.Label();
            origFileButton = new System.Windows.Forms.Button();
            modFileButton = new System.Windows.Forms.Button();
            label2 = new System.Windows.Forms.Label();
            modFilePathBox = new System.Windows.Forms.TextBox();
            outFileButton = new System.Windows.Forms.Button();
            label3 = new System.Windows.Forms.Label();
            outFilePathBox = new System.Windows.Forms.TextBox();
            buildButton = new System.Windows.Forms.Button();
            saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            SuspendLayout();
            // 
            // openFileDialog
            // 
            openFileDialog.FileName = "";
            openFileDialog.Filter = "All files|*.*";
            // 
            // origFilePathBox
            // 
            origFilePathBox.Location = new System.Drawing.Point(12, 50);
            origFilePathBox.Name = "origFilePathBox";
            origFilePathBox.ReadOnly = true;
            origFilePathBox.Size = new System.Drawing.Size(486, 39);
            origFilePathBox.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(12, 9);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(138, 32);
            label1.TabIndex = 1;
            label1.Text = "Original file";
            // 
            // origFileButton
            // 
            origFileButton.Location = new System.Drawing.Point(504, 46);
            origFileButton.Name = "origFileButton";
            origFileButton.Size = new System.Drawing.Size(150, 46);
            origFileButton.TabIndex = 2;
            origFileButton.Text = "Select";
            origFileButton.UseVisualStyleBackColor = true;
            origFileButton.Click += origFileButton_Click;
            // 
            // modFileButton
            // 
            modFileButton.Location = new System.Drawing.Point(504, 129);
            modFileButton.Name = "modFileButton";
            modFileButton.Size = new System.Drawing.Size(150, 46);
            modFileButton.TabIndex = 5;
            modFileButton.Text = "Select";
            modFileButton.UseVisualStyleBackColor = true;
            modFileButton.Click += modFileButton_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(12, 92);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(145, 32);
            label2.TabIndex = 4;
            label2.Text = "Modded file";
            // 
            // modFilePathBox
            // 
            modFilePathBox.Location = new System.Drawing.Point(12, 133);
            modFilePathBox.Name = "modFilePathBox";
            modFilePathBox.ReadOnly = true;
            modFilePathBox.Size = new System.Drawing.Size(486, 39);
            modFilePathBox.TabIndex = 3;
            // 
            // outFileButton
            // 
            outFileButton.Location = new System.Drawing.Point(504, 212);
            outFileButton.Name = "outFileButton";
            outFileButton.Size = new System.Drawing.Size(150, 46);
            outFileButton.TabIndex = 8;
            outFileButton.Text = "Select";
            outFileButton.UseVisualStyleBackColor = true;
            outFileButton.Click += outFileButton_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new System.Drawing.Point(12, 175);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(130, 32);
            label3.TabIndex = 7;
            label3.Text = "Output file";
            // 
            // outFilePathBox
            // 
            outFilePathBox.Location = new System.Drawing.Point(12, 216);
            outFilePathBox.Name = "outFilePathBox";
            outFilePathBox.ReadOnly = true;
            outFilePathBox.Size = new System.Drawing.Size(486, 39);
            outFilePathBox.TabIndex = 6;
            // 
            // buildButton
            // 
            buildButton.Enabled = false;
            buildButton.Location = new System.Drawing.Point(12, 264);
            buildButton.Name = "buildButton";
            buildButton.Size = new System.Drawing.Size(642, 46);
            buildButton.TabIndex = 9;
            buildButton.Text = "Build";
            buildButton.UseVisualStyleBackColor = true;
            buildButton.Click += buildButton_Click;
            // 
            // saveFileDialog
            // 
            saveFileDialog.AddExtension = true;
            // 
            // DiffBuilderForm
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(13F, 32F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(666, 324);
            Controls.Add(buildButton);
            Controls.Add(outFileButton);
            Controls.Add(label3);
            Controls.Add(outFilePathBox);
            Controls.Add(modFileButton);
            Controls.Add(label2);
            Controls.Add(modFilePathBox);
            Controls.Add(origFileButton);
            Controls.Add(label1);
            Controls.Add(origFilePathBox);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            Name = "DiffBuilderForm";
            Text = "Diff Builder";
            Icon = new System.Drawing.Icon(GetType().Assembly
                .GetManifestResourceStream("ModLoader.Logo.Icon.ico"));
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.TextBox origFilePathBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button origFileButton;
        private System.Windows.Forms.Button modFileButton;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox modFilePathBox;
        private System.Windows.Forms.Button outFileButton;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox outFilePathBox;
        private System.Windows.Forms.Button buildButton;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
    }
}