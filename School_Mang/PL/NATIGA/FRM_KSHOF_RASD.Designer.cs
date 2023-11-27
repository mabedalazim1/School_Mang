
namespace School_Mang.PL.NATIGA
{
    partial class FRM_KSHOF_RASD
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FRM_KSHOF_RASD));
            this.panel4 = new System.Windows.Forms.Panel();
            this.pn_top = new System.Windows.Forms.Panel();
            this.lbl_title = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cmb_month = new System.Windows.Forms.ComboBox();
            this.cmb_grade = new System.Windows.Forms.ComboBox();
            this.label18 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.btn_close = new DevExpress.XtraEditors.SimpleButton();
            this.pic_rasd = new System.Windows.Forms.PictureBox();
            this.btn_mark = new Bunifu.Framework.UI.BunifuThinButton2();
            this.btn_degree = new Bunifu.Framework.UI.BunifuThinButton2();
            this.btn_close_b = new Bunifu.Framework.UI.BunifuThinButton2();
            this.pn_top.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pic_rasd)).BeginInit();
            this.SuspendLayout();
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.panel4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel4.Location = new System.Drawing.Point(0, 277);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(531, 10);
            this.panel4.TabIndex = 101;
            // 
            // pn_top
            // 
            this.pn_top.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.pn_top.Controls.Add(this.lbl_title);
            this.pn_top.Controls.Add(this.btn_close);
            this.pn_top.Dock = System.Windows.Forms.DockStyle.Top;
            this.pn_top.Location = new System.Drawing.Point(0, 0);
            this.pn_top.Name = "pn_top";
            this.pn_top.Size = new System.Drawing.Size(531, 50);
            this.pn_top.TabIndex = 100;
            this.pn_top.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pn_top_MouseDown);
            this.pn_top.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pn_top_MouseMove);
            this.pn_top.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pn_top_MouseUp);
            // 
            // lbl_title
            // 
            this.lbl_title.AutoSize = true;
            this.lbl_title.Font = new System.Drawing.Font("LBC", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_title.ForeColor = System.Drawing.Color.White;
            this.lbl_title.Location = new System.Drawing.Point(183, 13);
            this.lbl_title.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.lbl_title.Name = "lbl_title";
            this.lbl_title.Size = new System.Drawing.Size(164, 25);
            this.lbl_title.TabIndex = 46;
            this.lbl_title.Text = "ملفات كشوف الرصد";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.pic_rasd);
            this.groupBox1.Controls.Add(this.cmb_month);
            this.groupBox1.Controls.Add(this.cmb_grade);
            this.groupBox1.Controls.Add(this.label18);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Font = new System.Drawing.Font("LBC", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.Color.DarkGray;
            this.groupBox1.Location = new System.Drawing.Point(7, 61);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.groupBox1.Size = new System.Drawing.Size(517, 137);
            this.groupBox1.TabIndex = 99;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "الصف والشهر";
            // 
            // cmb_month
            // 
            this.cmb_month.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_month.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cmb_month.Font = new System.Drawing.Font("Noto Naskh Arabic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmb_month.ForeColor = System.Drawing.Color.DimGray;
            this.cmb_month.FormattingEnabled = true;
            this.cmb_month.Items.AddRange(new object[] {
            "ذكر",
            "أنثى"});
            this.cmb_month.Location = new System.Drawing.Point(16, 53);
            this.cmb_month.Name = "cmb_month";
            this.cmb_month.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.cmb_month.Size = new System.Drawing.Size(140, 40);
            this.cmb_month.TabIndex = 96;
            // 
            // cmb_grade
            // 
            this.cmb_grade.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_grade.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cmb_grade.Font = new System.Drawing.Font("Noto Naskh Arabic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmb_grade.ForeColor = System.Drawing.Color.DimGray;
            this.cmb_grade.FormattingEnabled = true;
            this.cmb_grade.Items.AddRange(new object[] {
            "ذكر",
            "أنثى"});
            this.cmb_grade.Location = new System.Drawing.Point(295, 53);
            this.cmb_grade.Name = "cmb_grade";
            this.cmb_grade.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.cmb_grade.Size = new System.Drawing.Size(140, 40);
            this.cmb_grade.TabIndex = 93;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Noto Naskh Arabic", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.label18.Location = new System.Drawing.Point(458, 59);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(48, 29);
            this.label18.TabIndex = 92;
            this.label18.Text = "الصف";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Noto Naskh Arabic", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.label5.Location = new System.Drawing.Point(171, 58);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(45, 29);
            this.label5.TabIndex = 94;
            this.label5.Text = "الشهر";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btn_mark);
            this.groupBox3.Controls.Add(this.btn_degree);
            this.groupBox3.Controls.Add(this.btn_close_b);
            this.groupBox3.Location = new System.Drawing.Point(7, 206);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(515, 67);
            this.groupBox3.TabIndex = 98;
            this.groupBox3.TabStop = false;
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
            // pic_rasd
            // 
            this.pic_rasd.Image = global::School_Mang.Properties.Resources.excel_48;
            this.pic_rasd.Location = new System.Drawing.Point(220, 0);
            this.pic_rasd.Name = "pic_rasd";
            this.pic_rasd.Size = new System.Drawing.Size(48, 48);
            this.pic_rasd.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pic_rasd.TabIndex = 97;
            this.pic_rasd.TabStop = false;
            // 
            // btn_mark
            // 
            this.btn_mark.ActiveBorderThickness = 1;
            this.btn_mark.ActiveCornerRadius = 20;
            this.btn_mark.ActiveFillColor = System.Drawing.Color.DodgerBlue;
            this.btn_mark.ActiveForecolor = System.Drawing.Color.White;
            this.btn_mark.ActiveLineColor = System.Drawing.Color.LightSteelBlue;
            this.btn_mark.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btn_mark.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_mark.BackgroundImage")));
            this.btn_mark.ButtonText = "الاختبارات";
            this.btn_mark.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_mark.Font = new System.Drawing.Font("LBC", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_mark.ForeColor = System.Drawing.Color.MediumBlue;
            this.btn_mark.IdleBorderThickness = 1;
            this.btn_mark.IdleCornerRadius = 20;
            this.btn_mark.IdleFillColor = System.Drawing.Color.WhiteSmoke;
            this.btn_mark.IdleForecolor = System.Drawing.Color.DarkBlue;
            this.btn_mark.IdleLineColor = System.Drawing.Color.Blue;
            this.btn_mark.Location = new System.Drawing.Point(188, 13);
            this.btn_mark.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btn_mark.Name = "btn_mark";
            this.btn_mark.Size = new System.Drawing.Size(138, 50);
            this.btn_mark.TabIndex = 20;
            this.btn_mark.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btn_mark.Click += new System.EventHandler(this.btn_mark_Click);
            // 
            // btn_degree
            // 
            this.btn_degree.ActiveBorderThickness = 1;
            this.btn_degree.ActiveCornerRadius = 20;
            this.btn_degree.ActiveFillColor = System.Drawing.Color.SeaGreen;
            this.btn_degree.ActiveForecolor = System.Drawing.Color.White;
            this.btn_degree.ActiveLineColor = System.Drawing.Color.SeaGreen;
            this.btn_degree.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btn_degree.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_degree.BackgroundImage")));
            this.btn_degree.ButtonText = "التقييمات";
            this.btn_degree.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_degree.Font = new System.Drawing.Font("LBC", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_degree.ForeColor = System.Drawing.Color.SeaGreen;
            this.btn_degree.IdleBorderThickness = 1;
            this.btn_degree.IdleCornerRadius = 20;
            this.btn_degree.IdleFillColor = System.Drawing.Color.WhiteSmoke;
            this.btn_degree.IdleForecolor = System.Drawing.Color.SeaGreen;
            this.btn_degree.IdleLineColor = System.Drawing.Color.SeaGreen;
            this.btn_degree.Location = new System.Drawing.Point(359, 13);
            this.btn_degree.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btn_degree.Name = "btn_degree";
            this.btn_degree.Size = new System.Drawing.Size(138, 50);
            this.btn_degree.TabIndex = 18;
            this.btn_degree.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btn_degree.Click += new System.EventHandler(this.btn_degree_Click);
            // 
            // btn_close_b
            // 
            this.btn_close_b.ActiveBorderThickness = 1;
            this.btn_close_b.ActiveCornerRadius = 20;
            this.btn_close_b.ActiveFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.btn_close_b.ActiveForecolor = System.Drawing.Color.White;
            this.btn_close_b.ActiveLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btn_close_b.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btn_close_b.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_close_b.BackgroundImage")));
            this.btn_close_b.ButtonText = "إلغاء";
            this.btn_close_b.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_close_b.Font = new System.Drawing.Font("LBC", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_close_b.ForeColor = System.Drawing.Color.Red;
            this.btn_close_b.IdleBorderThickness = 1;
            this.btn_close_b.IdleCornerRadius = 20;
            this.btn_close_b.IdleFillColor = System.Drawing.Color.WhiteSmoke;
            this.btn_close_b.IdleForecolor = System.Drawing.Color.Red;
            this.btn_close_b.IdleLineColor = System.Drawing.Color.Red;
            this.btn_close_b.Location = new System.Drawing.Point(16, 13);
            this.btn_close_b.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btn_close_b.Name = "btn_close_b";
            this.btn_close_b.Size = new System.Drawing.Size(138, 50);
            this.btn_close_b.TabIndex = 19;
            this.btn_close_b.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btn_close_b.Click += new System.EventHandler(this.btn_close_b_Click);
            // 
            // FRM_KSHOF_RASD
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.CancelButton = this.btn_close;
            this.ClientSize = new System.Drawing.Size(531, 287);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.pn_top);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox3);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FRM_KSHOF_RASD";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "كشوف الرصد";
            this.pn_top.ResumeLayout(false);
            this.pn_top.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pic_rasd)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel pn_top;
        private System.Windows.Forms.Label lbl_title;
        private DevExpress.XtraEditors.SimpleButton btn_close;
        private System.Windows.Forms.GroupBox groupBox1;
        public System.Windows.Forms.ComboBox cmb_grade;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox groupBox3;
        private Bunifu.Framework.UI.BunifuThinButton2 btn_degree;
        private Bunifu.Framework.UI.BunifuThinButton2 btn_close_b;
        private Bunifu.Framework.UI.BunifuThinButton2 btn_mark;
        public System.Windows.Forms.ComboBox cmb_month;
        private System.Windows.Forms.PictureBox pic_rasd;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
    }
}