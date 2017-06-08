namespace WindowsFormsApplication1
{
    partial class Form1
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.msgenk = new System.Windows.Forms.RichTextBox();
            this.pathenk = new System.Windows.Forms.TextBox();
            this.loadenk = new System.Windows.Forms.Button();
            this.eksenk = new System.Windows.Forms.Button();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.eksemb = new System.Windows.Forms.Button();
            this.passemb = new System.Windows.Forms.TextBox();
            this.pathemb2 = new System.Windows.Forms.TextBox();
            this.pathemb1 = new System.Windows.Forms.TextBox();
            this.loademb2 = new System.Windows.Forms.Button();
            this.loademb1 = new System.Windows.Forms.Button();
            this.tmplgbremb = new System.Windows.Forms.PictureBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.eksext = new System.Windows.Forms.Button();
            this.passext = new System.Windows.Forms.TextBox();
            this.loadext = new System.Windows.Forms.Button();
            this.pathext = new System.Windows.Forms.TextBox();
            this.tmplgbrext = new System.Windows.Forms.PictureBox();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.msgdek = new System.Windows.Forms.RichTextBox();
            this.pathdek = new System.Windows.Forms.TextBox();
            this.loaddek = new System.Windows.Forms.Button();
            this.eksdek = new System.Windows.Forms.Button();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.button11 = new System.Windows.Forms.Button();
            this.button10 = new System.Windows.Forms.Button();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.msghslenk = new System.Windows.Forms.RichTextBox();
            this.saveenk = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.msghsldek = new System.Windows.Forms.RichTextBox();
            this.savedek = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tmplgbremb)).BeginInit();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tmplgbrext)).BeginInit();
            this.tabPage4.SuspendLayout();
            this.tabPage5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Controls.Add(this.tabPage5);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(739, 456);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.saveenk);
            this.tabPage3.Controls.Add(this.eksenk);
            this.tabPage3.Controls.Add(this.groupBox2);
            this.tabPage3.Controls.Add(this.groupBox1);
            this.tabPage3.Controls.Add(this.pathenk);
            this.tabPage3.Controls.Add(this.loadenk);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(731, 430);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Enkripsi";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // msgenk
            // 
            this.msgenk.Location = new System.Drawing.Point(6, 37);
            this.msgenk.Name = "msgenk";
            this.msgenk.Size = new System.Drawing.Size(255, 178);
            this.msgenk.TabIndex = 3;
            this.msgenk.Text = "";
            // 
            // pathenk
            // 
            this.pathenk.Location = new System.Drawing.Point(18, 75);
            this.pathenk.Name = "pathenk";
            this.pathenk.ReadOnly = true;
            this.pathenk.Size = new System.Drawing.Size(602, 20);
            this.pathenk.TabIndex = 2;
            // 
            // loadenk
            // 
            this.loadenk.Location = new System.Drawing.Point(626, 75);
            this.loadenk.Name = "loadenk";
            this.loadenk.Size = new System.Drawing.Size(75, 23);
            this.loadenk.TabIndex = 1;
            this.loadenk.Text = "Open";
            this.loadenk.UseVisualStyleBackColor = true;
            this.loadenk.Click += new System.EventHandler(this.loadenk_Click);
            // 
            // eksenk
            // 
            this.eksenk.Location = new System.Drawing.Point(304, 262);
            this.eksenk.Name = "eksenk";
            this.eksenk.Size = new System.Drawing.Size(85, 72);
            this.eksenk.TabIndex = 0;
            this.eksenk.Text = "Execute";
            this.eksenk.UseVisualStyleBackColor = true;
            this.eksenk.Click += new System.EventHandler(this.eksenk_Click);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.eksemb);
            this.tabPage1.Controls.Add(this.passemb);
            this.tabPage1.Controls.Add(this.pathemb2);
            this.tabPage1.Controls.Add(this.pathemb1);
            this.tabPage1.Controls.Add(this.loademb2);
            this.tabPage1.Controls.Add(this.loademb1);
            this.tabPage1.Controls.Add(this.tmplgbremb);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(731, 430);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Embedding";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // eksemb
            // 
            this.eksemb.Location = new System.Drawing.Point(530, 345);
            this.eksemb.Name = "eksemb";
            this.eksemb.Size = new System.Drawing.Size(138, 23);
            this.eksemb.TabIndex = 6;
            this.eksemb.Text = "Execute";
            this.eksemb.UseVisualStyleBackColor = true;
            this.eksemb.Click += new System.EventHandler(this.eksemb_Click);
            // 
            // passemb
            // 
            this.passemb.Location = new System.Drawing.Point(289, 293);
            this.passemb.Name = "passemb";
            this.passemb.Size = new System.Drawing.Size(379, 20);
            this.passemb.TabIndex = 5;
            // 
            // pathemb2
            // 
            this.pathemb2.Location = new System.Drawing.Point(289, 183);
            this.pathemb2.Name = "pathemb2";
            this.pathemb2.ReadOnly = true;
            this.pathemb2.Size = new System.Drawing.Size(298, 20);
            this.pathemb2.TabIndex = 4;
            // 
            // pathemb1
            // 
            this.pathemb1.Location = new System.Drawing.Point(289, 116);
            this.pathemb1.Name = "pathemb1";
            this.pathemb1.ReadOnly = true;
            this.pathemb1.Size = new System.Drawing.Size(298, 20);
            this.pathemb1.TabIndex = 3;
            // 
            // loademb2
            // 
            this.loademb2.Location = new System.Drawing.Point(593, 180);
            this.loademb2.Name = "loademb2";
            this.loademb2.Size = new System.Drawing.Size(75, 23);
            this.loademb2.TabIndex = 2;
            this.loademb2.Text = "Open";
            this.loademb2.UseVisualStyleBackColor = true;
            this.loademb2.Click += new System.EventHandler(this.loademb2_Click);
            // 
            // loademb1
            // 
            this.loademb1.Location = new System.Drawing.Point(593, 116);
            this.loademb1.Name = "loademb1";
            this.loademb1.Size = new System.Drawing.Size(75, 23);
            this.loademb1.TabIndex = 1;
            this.loademb1.Text = "Open";
            this.loademb1.UseVisualStyleBackColor = true;
            this.loademb1.Click += new System.EventHandler(this.loademb1_Click);
            // 
            // tmplgbremb
            // 
            this.tmplgbremb.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.tmplgbremb.Location = new System.Drawing.Point(23, 59);
            this.tmplgbremb.Name = "tmplgbremb";
            this.tmplgbremb.Size = new System.Drawing.Size(246, 285);
            this.tmplgbremb.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.tmplgbremb.TabIndex = 0;
            this.tmplgbremb.TabStop = false;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.eksext);
            this.tabPage2.Controls.Add(this.passext);
            this.tabPage2.Controls.Add(this.loadext);
            this.tabPage2.Controls.Add(this.pathext);
            this.tabPage2.Controls.Add(this.tmplgbrext);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(731, 430);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Extracting";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // eksext
            // 
            this.eksext.Location = new System.Drawing.Point(509, 349);
            this.eksext.Name = "eksext";
            this.eksext.Size = new System.Drawing.Size(170, 23);
            this.eksext.TabIndex = 4;
            this.eksext.Text = "Execute";
            this.eksext.UseVisualStyleBackColor = true;
            this.eksext.Click += new System.EventHandler(this.eksext_Click);
            // 
            // passext
            // 
            this.passext.Location = new System.Drawing.Point(320, 301);
            this.passext.Name = "passext";
            this.passext.Size = new System.Drawing.Size(359, 20);
            this.passext.TabIndex = 3;
            // 
            // loadext
            // 
            this.loadext.Location = new System.Drawing.Point(604, 122);
            this.loadext.Name = "loadext";
            this.loadext.Size = new System.Drawing.Size(75, 23);
            this.loadext.TabIndex = 2;
            this.loadext.Text = "Open";
            this.loadext.UseVisualStyleBackColor = true;
            this.loadext.Click += new System.EventHandler(this.loadext_Click);
            // 
            // pathext
            // 
            this.pathext.Location = new System.Drawing.Point(316, 125);
            this.pathext.Name = "pathext";
            this.pathext.ReadOnly = true;
            this.pathext.Size = new System.Drawing.Size(253, 20);
            this.pathext.TabIndex = 1;
            // 
            // tmplgbrext
            // 
            this.tmplgbrext.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.tmplgbrext.Location = new System.Drawing.Point(75, 122);
            this.tmplgbrext.Name = "tmplgbrext";
            this.tmplgbrext.Size = new System.Drawing.Size(207, 212);
            this.tmplgbrext.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.tmplgbrext.TabIndex = 0;
            this.tmplgbrext.TabStop = false;
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.savedek);
            this.tabPage4.Controls.Add(this.groupBox4);
            this.tabPage4.Controls.Add(this.groupBox3);
            this.tabPage4.Controls.Add(this.pathdek);
            this.tabPage4.Controls.Add(this.loaddek);
            this.tabPage4.Controls.Add(this.eksdek);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Size = new System.Drawing.Size(731, 430);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Dekripsi";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // msgdek
            // 
            this.msgdek.Location = new System.Drawing.Point(6, 34);
            this.msgdek.Name = "msgdek";
            this.msgdek.ReadOnly = true;
            this.msgdek.Size = new System.Drawing.Size(253, 200);
            this.msgdek.TabIndex = 3;
            this.msgdek.Text = "";
            // 
            // pathdek
            // 
            this.pathdek.Location = new System.Drawing.Point(93, 61);
            this.pathdek.Name = "pathdek";
            this.pathdek.ReadOnly = true;
            this.pathdek.Size = new System.Drawing.Size(475, 20);
            this.pathdek.TabIndex = 2;
            // 
            // loaddek
            // 
            this.loaddek.Location = new System.Drawing.Point(574, 61);
            this.loaddek.Name = "loaddek";
            this.loaddek.Size = new System.Drawing.Size(75, 23);
            this.loaddek.TabIndex = 1;
            this.loaddek.Text = "Open";
            this.loaddek.UseVisualStyleBackColor = true;
            this.loaddek.Click += new System.EventHandler(this.loaddek_Click);
            // 
            // eksdek
            // 
            this.eksdek.Location = new System.Drawing.Point(312, 275);
            this.eksdek.Name = "eksdek";
            this.eksdek.Size = new System.Drawing.Size(72, 78);
            this.eksdek.TabIndex = 0;
            this.eksdek.Text = "Execute";
            this.eksdek.UseVisualStyleBackColor = true;
            this.eksdek.Click += new System.EventHandler(this.eksdek_Click);
            // 
            // tabPage5
            // 
            this.tabPage5.Controls.Add(this.button11);
            this.tabPage5.Controls.Add(this.button10);
            this.tabPage5.Controls.Add(this.dataGridView2);
            this.tabPage5.Controls.Add(this.dataGridView1);
            this.tabPage5.Location = new System.Drawing.Point(4, 22);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Size = new System.Drawing.Size(731, 430);
            this.tabPage5.TabIndex = 4;
            this.tabPage5.Text = "Lookup Pixel";
            this.tabPage5.UseVisualStyleBackColor = true;
            // 
            // button11
            // 
            this.button11.Location = new System.Drawing.Point(594, 74);
            this.button11.Name = "button11";
            this.button11.Size = new System.Drawing.Size(75, 23);
            this.button11.TabIndex = 5;
            this.button11.Text = "button11";
            this.button11.UseVisualStyleBackColor = true;
            // 
            // button10
            // 
            this.button10.Location = new System.Drawing.Point(274, 71);
            this.button10.Name = "button10";
            this.button10.Size = new System.Drawing.Size(75, 23);
            this.button10.TabIndex = 2;
            this.button10.Text = "button10";
            this.button10.UseVisualStyleBackColor = true;
            // 
            // dataGridView2
            // 
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Location = new System.Drawing.Point(377, 122);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.Size = new System.Drawing.Size(292, 191);
            this.dataGridView2.TabIndex = 1;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(56, 122);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(293, 191);
            this.dataGridView1.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.msgenk);
            this.groupBox1.Location = new System.Drawing.Point(12, 119);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(274, 224);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Teks Asli";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.msghslenk);
            this.groupBox2.Location = new System.Drawing.Point(411, 119);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(296, 224);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Teks Enkripsi";
            // 
            // msghslenk
            // 
            this.msghslenk.Location = new System.Drawing.Point(6, 37);
            this.msghslenk.Name = "msghslenk";
            this.msghslenk.ReadOnly = true;
            this.msghslenk.Size = new System.Drawing.Size(284, 178);
            this.msghslenk.TabIndex = 0;
            this.msghslenk.Text = "";
            // 
            // saveenk
            // 
            this.saveenk.Location = new System.Drawing.Point(546, 378);
            this.saveenk.Name = "saveenk";
            this.saveenk.Size = new System.Drawing.Size(161, 28);
            this.saveenk.TabIndex = 6;
            this.saveenk.Text = "Save As";
            this.saveenk.UseVisualStyleBackColor = true;
            this.saveenk.Click += new System.EventHandler(this.saveenk_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.msgdek);
            this.groupBox3.Location = new System.Drawing.Point(32, 119);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(264, 244);
            this.groupBox3.TabIndex = 4;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Teks Enkripsi";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.msghsldek);
            this.groupBox4.Location = new System.Drawing.Point(403, 119);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(290, 244);
            this.groupBox4.TabIndex = 5;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Teks Dekripsi";
            // 
            // msghsldek
            // 
            this.msghsldek.Location = new System.Drawing.Point(6, 34);
            this.msghsldek.Name = "msghsldek";
            this.msghsldek.ReadOnly = true;
            this.msghsldek.Size = new System.Drawing.Size(278, 200);
            this.msghsldek.TabIndex = 0;
            this.msghsldek.Text = "";
            // 
            // savedek
            // 
            this.savedek.Location = new System.Drawing.Point(574, 384);
            this.savedek.Name = "savedek";
            this.savedek.Size = new System.Drawing.Size(119, 23);
            this.savedek.TabIndex = 6;
            this.savedek.Text = "Save As";
            this.savedek.UseVisualStyleBackColor = true;
            this.savedek.Click += new System.EventHandler(this.savedek_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(763, 480);
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Aplikasi";
            this.tabControl1.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tmplgbremb)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tmplgbrext)).EndInit();
            this.tabPage4.ResumeLayout(false);
            this.tabPage4.PerformLayout();
            this.tabPage5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Button eksemb;
        private System.Windows.Forms.TextBox passemb;
        private System.Windows.Forms.TextBox pathemb2;
        private System.Windows.Forms.TextBox pathemb1;
        private System.Windows.Forms.Button loademb2;
        private System.Windows.Forms.Button loademb1;
        private System.Windows.Forms.PictureBox tmplgbremb;
        private System.Windows.Forms.Button eksext;
        private System.Windows.Forms.TextBox passext;
        private System.Windows.Forms.Button loadext;
        private System.Windows.Forms.TextBox pathext;
        private System.Windows.Forms.PictureBox tmplgbrext;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.TextBox pathenk;
        private System.Windows.Forms.Button loadenk;
        private System.Windows.Forms.Button eksenk;
        private System.Windows.Forms.TextBox pathdek;
        private System.Windows.Forms.Button loaddek;
        private System.Windows.Forms.Button eksdek;
        private System.Windows.Forms.TabPage tabPage5;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button button10;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.Button button11;
        private System.Windows.Forms.RichTextBox msgenk;
        private System.Windows.Forms.RichTextBox msgdek;
        private System.Windows.Forms.Button saveenk;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RichTextBox msghslenk;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button savedek;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.RichTextBox msghsldek;
        private System.Windows.Forms.GroupBox groupBox3;
    }
}

