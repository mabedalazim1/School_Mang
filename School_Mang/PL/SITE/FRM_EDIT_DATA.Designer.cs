
namespace School_Mang.PL.SITE
{
    partial class FRM_EDIT_DATA
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FRM_EDIT_DATA));
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btn_close_b = new Bunifu.Framework.UI.BunifuThinButton2();
            this.pn_top = new System.Windows.Forms.Panel();
            this.btn_close = new DevExpress.XtraEditors.SimpleButton();
            this.lbl_title = new System.Windows.Forms.Label();
            this.bunifuCards4 = new Bunifu.Framework.UI.BunifuCards();
            this.pic_get_file = new System.Windows.Forms.PictureBox();
            this.lbl_get_file = new System.Windows.Forms.Label();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.bunifuCards1 = new Bunifu.Framework.UI.BunifuCards();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.groupBox3.SuspendLayout();
            this.pn_top.SuspendLayout();
            this.bunifuCards4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pic_get_file)).BeginInit();
            this.bunifuCards1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btn_close_b);
            this.groupBox3.Location = new System.Drawing.Point(21, 279);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(366, 64);
            this.groupBox3.TabIndex = 102;
            this.groupBox3.TabStop = false;
            // 
            // btn_close_b
            // 
            this.btn_close_b.ActiveBorderThickness = 1;
            this.btn_close_b.ActiveCornerRadius = 20;
            this.btn_close_b.ActiveFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.btn_close_b.ActiveForecolor = System.Drawing.Color.White;
            this.btn_close_b.ActiveLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btn_close_b.BackColor = System.Drawing.SystemColors.Control;
            this.btn_close_b.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_close_b.BackgroundImage")));
            this.btn_close_b.ButtonText = "إغلاق";
            this.btn_close_b.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_close_b.Font = new System.Drawing.Font("LBC", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_close_b.ForeColor = System.Drawing.Color.Red;
            this.btn_close_b.IdleBorderThickness = 1;
            this.btn_close_b.IdleCornerRadius = 20;
            this.btn_close_b.IdleFillColor = System.Drawing.Color.WhiteSmoke;
            this.btn_close_b.IdleForecolor = System.Drawing.Color.Red;
            this.btn_close_b.IdleLineColor = System.Drawing.Color.Red;
            this.btn_close_b.Location = new System.Drawing.Point(114, 7);
            this.btn_close_b.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btn_close_b.Name = "btn_close_b";
            this.btn_close_b.Size = new System.Drawing.Size(138, 50);
            this.btn_close_b.TabIndex = 11;
            this.btn_close_b.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btn_close_b.Click += new System.EventHandler(this.btn_close_b_Click);
            // 
            // pn_top
            // 
            this.pn_top.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.pn_top.Controls.Add(this.btn_close);
            this.pn_top.Controls.Add(this.lbl_title);
            this.pn_top.Dock = System.Windows.Forms.DockStyle.Top;
            this.pn_top.Location = new System.Drawing.Point(0, 0);
            this.pn_top.Name = "pn_top";
            this.pn_top.Size = new System.Drawing.Size(414, 50);
            this.pn_top.TabIndex = 101;
            this.pn_top.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pn_top_MouseDown);
            this.pn_top.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pn_top_MouseMove);
            this.pn_top.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pn_top_MouseUp);
            // 
            // btn_close
            // 
            this.btn_close.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btn_close.ImageOptions.Image = global::School_Mang.Properties.Resources.close_w;
            this.btn_close.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.btn_close.Location = new System.Drawing.Point(4, 12);
            this.btn_close.Name = "btn_close";
            this.btn_close.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light;
            this.btn_close.Size = new System.Drawing.Size(34, 33);
            this.btn_close.TabIndex = 11;
            this.btn_close.TabStop = false;
            this.btn_close.Click += new System.EventHandler(this.btn_close_Click);
            // 
            // lbl_title
            // 
            this.lbl_title.AutoSize = true;
            this.lbl_title.Font = new System.Drawing.Font("LBC", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_title.ForeColor = System.Drawing.Color.White;
            this.lbl_title.Location = new System.Drawing.Point(142, 13);
            this.lbl_title.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.lbl_title.Name = "lbl_title";
            this.lbl_title.Size = new System.Drawing.Size(147, 25);
            this.lbl_title.TabIndex = 46;
            this.lbl_title.Text = "إضافة مستخدمين";
            // 
            // bunifuCards4
            // 
            this.bunifuCards4.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.bunifuCards4.BackColor = System.Drawing.Color.White;
            this.bunifuCards4.BorderRadius = 5;
            this.bunifuCards4.BottomSahddow = true;
            this.bunifuCards4.color = System.Drawing.Color.Tomato;
            this.bunifuCards4.Controls.Add(this.pic_get_file);
            this.bunifuCards4.Controls.Add(this.lbl_get_file);
            this.bunifuCards4.LeftSahddow = false;
            this.bunifuCards4.Location = new System.Drawing.Point(215, 90);
            this.bunifuCards4.Name = "bunifuCards4";
            this.bunifuCards4.Padding = new System.Windows.Forms.Padding(20);
            this.bunifuCards4.RightSahddow = true;
            this.bunifuCards4.ShadowDepth = 20;
            this.bunifuCards4.Size = new System.Drawing.Size(178, 160);
            this.bunifuCards4.TabIndex = 103;
            // 
            // pic_get_file
            // 
            this.pic_get_file.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pic_get_file.Image = global::School_Mang.Properties.Resources.excel_48;
            this.pic_get_file.Location = new System.Drawing.Point(63, 37);
            this.pic_get_file.Name = "pic_get_file";
            this.pic_get_file.Size = new System.Drawing.Size(58, 54);
            this.pic_get_file.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pic_get_file.TabIndex = 1;
            this.pic_get_file.TabStop = false;
            this.pic_get_file.Click += new System.EventHandler(this.pic_get_file_Click);
            // 
            // lbl_get_file
            // 
            this.lbl_get_file.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lbl_get_file.AutoSize = true;
            this.lbl_get_file.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lbl_get_file.Font = new System.Drawing.Font("LBC", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_get_file.Location = new System.Drawing.Point(32, 94);
            this.lbl_get_file.Name = "lbl_get_file";
            this.lbl_get_file.Size = new System.Drawing.Size(113, 31);
            this.lbl_get_file.TabIndex = 7;
            this.lbl_get_file.Text = "تجهيز ملف";
            this.lbl_get_file.Click += new System.EventHandler(this.lbl_get_file_Click);
            // 
            // bunifuCards1
            // 
            this.bunifuCards1.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.bunifuCards1.BackColor = System.Drawing.Color.White;
            this.bunifuCards1.BorderRadius = 5;
            this.bunifuCards1.BottomSahddow = true;
            this.bunifuCards1.color = System.Drawing.Color.Tomato;
            this.bunifuCards1.Controls.Add(this.pictureBox1);
            this.bunifuCards1.Controls.Add(this.label1);
            this.bunifuCards1.LeftSahddow = false;
            this.bunifuCards1.Location = new System.Drawing.Point(21, 90);
            this.bunifuCards1.Name = "bunifuCards1";
            this.bunifuCards1.Padding = new System.Windows.Forms.Padding(20);
            this.bunifuCards1.RightSahddow = true;
            this.bunifuCards1.ShadowDepth = 20;
            this.bunifuCards1.Size = new System.Drawing.Size(178, 160);
            this.bunifuCards1.TabIndex = 104;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox1.Image = global::School_Mang.Properties.Resources.excel_to_2100;
            this.pictureBox1.Location = new System.Drawing.Point(63, 37);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(58, 54);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label1.AutoSize = true;
            this.label1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label1.Font = new System.Drawing.Font("LBC", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(41, 98);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(96, 31);
            this.label1.TabIndex = 7;
            this.label1.Text = "رفع ملف";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // FRM_EDIT_DATA
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btn_close;
            this.ClientSize = new System.Drawing.Size(414, 349);
            this.Controls.Add(this.bunifuCards1);
            this.Controls.Add(this.bunifuCards4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.pn_top);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FRM_EDIT_DATA";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FRM_EDIT_DATA";
            this.Load += new System.EventHandler(this.FRM_EDIT_DATA_Load);
            this.groupBox3.ResumeLayout(false);
            this.pn_top.ResumeLayout(false);
            this.pn_top.PerformLayout();
            this.bunifuCards4.ResumeLayout(false);
            this.bunifuCards4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pic_get_file)).EndInit();
            this.bunifuCards1.ResumeLayout(false);
            this.bunifuCards1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox3;
        private Bunifu.Framework.UI.BunifuThinButton2 btn_close_b;
        private System.Windows.Forms.Panel pn_top;
        private DevExpress.XtraEditors.SimpleButton btn_close;
        private Bunifu.Framework.UI.BunifuCards bunifuCards4;
        public System.Windows.Forms.PictureBox pic_get_file;
        private System.Windows.Forms.Label lbl_get_file;
        public System.Windows.Forms.Label lbl_title;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private Bunifu.Framework.UI.BunifuCards bunifuCards1;
        public System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
    }
}