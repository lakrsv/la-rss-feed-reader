namespace LaRSSFeedReader
{
    partial class BookmarkInputForm
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
            this.bookmarkname = new System.Windows.Forms.TextBox();
            this.bookmarkurl = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.addbookmarkbutton = new System.Windows.Forms.Button();
            this.cancelbutton = new System.Windows.Forms.Button();
            this.removebookmarkbutton = new System.Windows.Forms.Button();
            this.bookmarkremovelist = new System.Windows.Forms.ComboBox();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // bookmarkname
            // 
            this.bookmarkname.Location = new System.Drawing.Point(12, 22);
            this.bookmarkname.Name = "bookmarkname";
            this.bookmarkname.Size = new System.Drawing.Size(260, 20);
            this.bookmarkname.TabIndex = 0;
            // 
            // bookmarkurl
            // 
            this.bookmarkurl.Location = new System.Drawing.Point(0, 19);
            this.bookmarkurl.Name = "bookmarkurl";
            this.bookmarkurl.Size = new System.Drawing.Size(260, 20);
            this.bookmarkurl.TabIndex = 1;
            // 
            // groupBox1
            // 
            this.groupBox1.Location = new System.Drawing.Point(12, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(260, 13);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Name";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.bookmarkurl);
            this.groupBox2.Location = new System.Drawing.Point(12, 48);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(260, 40);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Feed Url";
            // 
            // addbookmarkbutton
            // 
            this.addbookmarkbutton.Location = new System.Drawing.Point(12, 95);
            this.addbookmarkbutton.Name = "addbookmarkbutton";
            this.addbookmarkbutton.Size = new System.Drawing.Size(89, 24);
            this.addbookmarkbutton.TabIndex = 3;
            this.addbookmarkbutton.Text = "Add bookmark";
            this.addbookmarkbutton.UseVisualStyleBackColor = true;
            this.addbookmarkbutton.Click += new System.EventHandler(this.addbookmarkbutton_Click);
            // 
            // cancelbutton
            // 
            this.cancelbutton.Location = new System.Drawing.Point(188, 96);
            this.cancelbutton.Name = "cancelbutton";
            this.cancelbutton.Size = new System.Drawing.Size(84, 24);
            this.cancelbutton.TabIndex = 4;
            this.cancelbutton.Text = "Cancel";
            this.cancelbutton.UseVisualStyleBackColor = true;
            this.cancelbutton.Click += new System.EventHandler(this.cancelbutton_Click);
            // 
            // removebookmarkbutton
            // 
            this.removebookmarkbutton.Location = new System.Drawing.Point(12, 125);
            this.removebookmarkbutton.Name = "removebookmarkbutton";
            this.removebookmarkbutton.Size = new System.Drawing.Size(260, 23);
            this.removebookmarkbutton.TabIndex = 5;
            this.removebookmarkbutton.Text = "Remove bookmark";
            this.removebookmarkbutton.UseVisualStyleBackColor = true;
            this.removebookmarkbutton.Click += new System.EventHandler(this.removebookmarkbutton_Click);
            // 
            // bookmarkremovelist
            // 
            this.bookmarkremovelist.FormattingEnabled = true;
            this.bookmarkremovelist.Location = new System.Drawing.Point(12, 154);
            this.bookmarkremovelist.Name = "bookmarkremovelist";
            this.bookmarkremovelist.Size = new System.Drawing.Size(260, 21);
            this.bookmarkremovelist.TabIndex = 6;
            this.bookmarkremovelist.Text = "Choose Bookmark";
            this.bookmarkremovelist.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.bookmarkremovelist_KeyPress);
            // 
            // BookmarkInputForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 322);
            this.Controls.Add(this.bookmarkremovelist);
            this.Controls.Add(this.removebookmarkbutton);
            this.Controls.Add(this.cancelbutton);
            this.Controls.Add(this.addbookmarkbutton);
            this.Controls.Add(this.bookmarkname);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.Name = "BookmarkInputForm";
            this.Text = "Add Bookmark";
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox bookmarkname;
        private System.Windows.Forms.TextBox bookmarkurl;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button addbookmarkbutton;
        private System.Windows.Forms.Button cancelbutton;
        private System.Windows.Forms.Button removebookmarkbutton;
        private System.Windows.Forms.ComboBox bookmarkremovelist;
    }
}