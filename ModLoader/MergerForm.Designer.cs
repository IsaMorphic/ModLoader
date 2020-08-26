using ModLoader.Core.Abstract;

namespace ModLoader
{
    partial class MergerForm<T>
        where T : Xunk<T>
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
            this.TextBox = new System.Windows.Forms.RichTextBox();
            this.ConflictList = new System.Windows.Forms.CheckedListBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.MemberList = new System.Windows.Forms.CheckedListBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // TextBox
            // 
            this.TextBox.Font = new System.Drawing.Font("Lucida Console", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TextBox.Location = new System.Drawing.Point(6, 34);
            this.TextBox.Name = "TextBox";
            this.TextBox.Size = new System.Drawing.Size(529, 714);
            this.TextBox.TabIndex = 1;
            this.TextBox.Text = "Select a member from the list(s) to view its contents...";
            // 
            // ConflictList
            // 
            this.ConflictList.FormattingEnabled = true;
            this.ConflictList.HorizontalScrollbar = true;
            this.ConflictList.IntegralHeight = false;
            this.ConflictList.Location = new System.Drawing.Point(6, 34);
            this.ConflictList.Name = "ConflictList";
            this.ConflictList.Size = new System.Drawing.Size(402, 335);
            this.ConflictList.TabIndex = 3;
            this.ConflictList.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.ListItemCheck);
            this.ConflictList.SelectedIndexChanged += new System.EventHandler(this.ListSelectedIndexChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.ConflictList);
            this.groupBox1.Location = new System.Drawing.Point(13, 392);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(414, 375);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Conflict";
            // 
            // MemberList
            // 
            this.MemberList.FormattingEnabled = true;
            this.MemberList.HorizontalScrollbar = true;
            this.MemberList.IntegralHeight = false;
            this.MemberList.Location = new System.Drawing.Point(6, 34);
            this.MemberList.Name = "MemberList";
            this.MemberList.Size = new System.Drawing.Size(402, 333);
            this.MemberList.TabIndex = 2;
            this.MemberList.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.ListItemCheck);
            this.MemberList.SelectedIndexChanged += new System.EventHandler(this.ListSelectedIndexChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.MemberList);
            this.groupBox2.Location = new System.Drawing.Point(13, 13);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(414, 373);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Members";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.TextBox);
            this.groupBox3.Location = new System.Drawing.Point(433, 13);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(541, 754);
            this.groupBox3.TabIndex = 6;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Contents";
            // 
            // ResolverForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.ClientSize = new System.Drawing.Size(990, 779);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "ResolverForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Merge Modules";
            this.Load += new System.EventHandler(this.FormLoad);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox TextBox;
        private System.Windows.Forms.CheckedListBox ConflictList;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckedListBox MemberList;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
    }
}

