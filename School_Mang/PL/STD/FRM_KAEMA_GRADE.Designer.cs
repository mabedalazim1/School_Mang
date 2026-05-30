
namespace School_Mang.PL.STD
{
    partial class FRM_KAEMA_GRADE
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FRM_KAEMA_GRADE));
            this.panel4 = new System.Windows.Forms.Panel();
            this.pn_top = new System.Windows.Forms.Panel();
            this.btn_close = new DevExpress.XtraEditors.SimpleButton();
            this.label11 = new System.Windows.Forms.Label();
            this.cmb_grade = new System.Windows.Forms.ComboBox();
            this.btn_print_kaema_all = new Bunifu.Framework.UI.BunifuThinButton2();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btn_close_b = new Bunifu.Framework.UI.BunifuThinButton2();
            this.btn_print_kaema = new Bunifu.Framework.UI.BunifuThinButton2();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.chk_sort = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cmb_sana = new System.Windows.Forms.ComboBox();
            this.label12 = new System.Windows.Forms.Label();
            this.pn_top.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.panel4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel4.Location = new System.Drawing.Point(0, 284);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(539, 10);
            this.panel4.TabIndex = 70;
            // 
            // pn_top
            // 
            this.pn_top.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.pn_top.Controls.Add(this.btn_close);
            this.pn_top.Controls.Add(this.label11);
            this.pn_top.Dock = System.Windows.Forms.DockStyle.Top;
            this.pn_top.Location = new System.Drawing.Point(0, 0);
            this.pn_top.Name = "pn_top";
            this.pn_top.Size = new System.Drawing.Size(539, 50);
            this.pn_top.TabIndex = 69;
            this.pn_top.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pn_top_MouseDown);
            this.pn_top.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pn_top_MouseMove);
            this.pn_top.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pn_top_MouseUp);
            // 
            // btn_close
            // 
            this.btn_close.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btn_close.ImageOptions.Image = global::School_Mang.Properties.Resources.close_w;
            this.btn_close.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.btn_close.Location = new System.Drawing.Point(12, 12);
            this.btn_close.Name = "btn_close";
            this.btn_close.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light;
            this.btn_close.Size = new System.Drawing.Size(34, 33);
            this.btn_close.TabIndex = 11;
            this.btn_close.TabStop = false;
            this.btn_close.Click += new System.EventHandler(this.btn_close_Click);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("LBC", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.White;
            this.label11.Location = new System.Drawing.Point(211, 13);
            this.label11.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(116, 25);
            this.label11.TabIndex = 46;
            this.label11.Text = "قوائم الفصول";
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
            this.cmb_grade.Location = new System.Drawing.Point(308, 67);
            this.cmb_grade.Name = "cmb_grade";
            this.cmb_grade.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.cmb_grade.Size = new System.Drawing.Size(153, 40);
            this.cmb_grade.TabIndex = 80;
            // 
            // btn_print_kaema_all
            // 
            this.btn_print_kaema_all.ActiveBorderThickness = 1;
            this.btn_print_kaema_all.ActiveCornerRadius = 20;
            this.btn_print_kaema_all.ActiveFillColor = System.Drawing.Color.CadetBlue;
            this.btn_print_kaema_all.ActiveForecolor = System.Drawing.Color.White;
            this.btn_print_kaema_all.ActiveLineColor = System.Drawing.Color.CadetBlue;
            this.btn_print_kaema_all.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btn_print_kaema_all.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_print_kaema_all.BackgroundImage")));
            this.btn_print_kaema_all.ButtonText = "عرض الكل";
            this.btn_print_kaema_all.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_print_kaema_all.Font = new System.Drawing.Font("LBC", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_print_kaema_all.ForeColor = System.Drawing.Color.RoyalBlue;
            this.btn_print_kaema_all.IdleBorderThickness = 1;
            this.btn_print_kaema_all.IdleCornerRadius = 20;
            this.btn_print_kaema_all.IdleFillColor = System.Drawing.Color.WhiteSmoke;
            this.btn_print_kaema_all.IdleForecolor = System.Drawing.Color.DodgerBlue;
            this.btn_print_kaema_all.IdleLineColor = System.Drawing.Color.SteelBlue;
            this.btn_print_kaema_all.Location = new System.Drawing.Point(176, 9);
            this.btn_print_kaema_all.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btn_print_kaema_all.Name = "btn_print_kaema_all";
            this.btn_print_kaema_all.Size = new System.Drawing.Size(150, 50);
            this.btn_print_kaema_all.TabIndex = 74;
            this.btn_print_kaema_all.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btn_print_kaema_all.Click += new System.EventHandler(this.btn_print_kaema_all_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btn_close_b);
            this.groupBox3.Controls.Add(this.btn_print_kaema);
            this.groupBox3.Controls.Add(this.btn_print_kaema_all);
            this.groupBox3.Location = new System.Drawing.Point(18, 205);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(507, 67);
            this.groupBox3.TabIndex = 78;
            this.groupBox3.TabStop = false;
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
            this.btn_close_b.ButtonText = "إغلاق";
            this.btn_close_b.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_close_b.Font = new System.Drawing.Font("LBC", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_close_b.ForeColor = System.Drawing.Color.Red;
            this.btn_close_b.IdleBorderThickness = 1;
            this.btn_close_b.IdleCornerRadius = 20;
            this.btn_close_b.IdleFillColor = System.Drawing.Color.WhiteSmoke;
            this.btn_close_b.IdleForecolor = System.Drawing.Color.Red;
            this.btn_close_b.IdleLineColor = System.Drawing.Color.Red;
            this.btn_close_b.Location = new System.Drawing.Point(7, 9);
            this.btn_close_b.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btn_close_b.Name = "btn_close_b";
            this.btn_close_b.Size = new System.Drawing.Size(139, 50);
            this.btn_close_b.TabIndex = 76;
            this.btn_close_b.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btn_close_b.Click += new System.EventHandler(this.btn_close_b_Click);
            // 
            // btn_print_kaema
            // 
            this.btn_print_kaema.ActiveBorderThickness = 1;
            this.btn_print_kaema.ActiveCornerRadius = 20;
            this.btn_print_kaema.ActiveFillColor = System.Drawing.Color.Teal;
            this.btn_print_kaema.ActiveForecolor = System.Drawing.Color.White;
            this.btn_print_kaema.ActiveLineColor = System.Drawing.Color.LightSeaGreen;
            this.btn_print_kaema.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btn_print_kaema.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_print_kaema.BackgroundImage")));
            this.btn_print_kaema.ButtonText = "عرض الصف المحدد";
            this.btn_print_kaema.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_print_kaema.Font = new System.Drawing.Font("LBC", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_print_kaema.ForeColor = System.Drawing.Color.Teal;
            this.btn_print_kaema.IdleBorderThickness = 1;
            this.btn_print_kaema.IdleCornerRadius = 20;
            this.btn_print_kaema.IdleFillColor = System.Drawing.Color.WhiteSmoke;
            this.btn_print_kaema.IdleForecolor = System.Drawing.Color.Teal;
            this.btn_print_kaema.IdleLineColor = System.Drawing.Color.DarkSlateGray;
            this.btn_print_kaema.Location = new System.Drawing.Point(348, 9);
            this.btn_print_kaema.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btn_print_kaema.Name = "btn_print_kaema";
            this.btn_print_kaema.Size = new System.Drawing.Size(147, 50);
            this.btn_print_kaema.TabIndex = 75;
            this.btn_print_kaema.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btn_print_kaema.Click += new System.EventHandler(this.btn_print_kaema_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.chk_sort);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.cmb_sana);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.cmb_grade);
            this.groupBox1.Font = new System.Drawing.Font("LBC", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.Color.DarkGray;
            this.groupBox1.Location = new System.Drawing.Point(12, 56);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.groupBox1.Size = new System.Drawing.Size(520, 226);
            this.groupBox1.TabIndex = 81;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "الصف - العام الدراسى";
            // 
            // chk_sort
            // 
            this.chk_sort.AutoSize = true;
            this.chk_sort.Font = new System.Drawing.Font("LBC", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chk_sort.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.chk_sort.Location = new System.Drawing.Point(13, 23);
            this.chk_sort.Name = "chk_sort";
            this.chk_sort.Size = new System.Drawing.Size(150, 29);
            this.chk_sort.TabIndex = 84;
            this.chk_sort.Text = "من الأصغر للأكبر";
            this.chk_sort.UseVisualStyleBackColor = true;
            this.chk_sort.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Noto Naskh Arabic", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.label1.Location = new System.Drawing.Point(470, 72);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 29);
            this.label1.TabIndex = 83;
            this.label1.Text = "الصف";
            // 
            // cmb_sana
            // 
            this.cmb_sana.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_sana.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cmb_sana.Font = new System.Drawing.Font("Noto Naskh Arabic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmb_sana.ForeColor = System.Drawing.Color.DimGray;
            this.cmb_sana.FormattingEnabled = true;
            this.cmb_sana.Items.AddRange(new object[] {
            "ذكر",
            "أنثى"});
            this.cmb_sana.Location = new System.Drawing.Point(13, 67);
            this.cmb_sana.Name = "cmb_sana";
            this.cmb_sana.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.cmb_sana.Size = new System.Drawing.Size(141, 40);
            this.cmb_sana.TabIndex = 81;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Noto Naskh Arabic", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.label12.Location = new System.Drawing.Point(160, 72);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(98, 29);
            this.label12.TabIndex = 82;
            this.label12.Text = "العام  الدراسى";
            // 
            // FRM_KAEMA_GRADE
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(539, 294);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.pn_top);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.Name = "FRM_KAEMA_GRADE";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "قوائم الفصول";
            this.Load += new System.EventHandler(this.FRM_KAEMA_GRADE_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FRM_KAEMA_GRADE_KeyDown);
            this.pn_top.ResumeLayout(false);
            this.pn_top.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel pn_top;
        private DevExpress.XtraEditors.SimpleButton btn_close;
        public System.Windows.Forms.ComboBox cmb_grade;
        private Bunifu.Framework.UI.BunifuThinButton2 btn_print_kaema_all;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox1;
        private Bunifu.Framework.UI.BunifuThinButton2 btn_print_kaema;
        public System.Windows.Forms.ComboBox cmb_sana;
        private System.Windows.Forms.Label label12;
        private Bunifu.Framework.UI.BunifuThinButton2 btn_close_b;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.Label label11;
        public System.Windows.Forms.CheckBox chk_sort;
    }
}