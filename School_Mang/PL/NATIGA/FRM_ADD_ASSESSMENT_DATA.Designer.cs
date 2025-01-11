
namespace School_Mang.PL.NATIGA
{
    partial class FRM_ADD_ASSESSMENT_DATA
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FRM_ADD_ASSESSMENT_DATA));
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btn_show_data = new Bunifu.Framework.UI.BunifuThinButton2();
            this.btn_close_b = new Bunifu.Framework.UI.BunifuThinButton2();
            this.pn_top = new System.Windows.Forms.Panel();
            this.btn_close = new DevExpress.XtraEditors.SimpleButton();
            this.label11 = new System.Windows.Forms.Label();
            this.cmb_subject = new System.Windows.Forms.ComboBox();
            this.label18 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cmb_grade = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.btn_del = new Bunifu.Framework.UI.BunifuThinButton2();
            this.cmb_term = new System.Windows.Forms.ComboBox();
            this.lbl_term = new System.Windows.Forms.Label();
            this.cmb_year = new System.Windows.Forms.ComboBox();
            this.lbl_year = new System.Windows.Forms.Label();
            this.lbl_info = new System.Windows.Forms.Label();
            this.groupBox3.SuspendLayout();
            this.pn_top.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btn_del);
            this.groupBox3.Controls.Add(this.btn_show_data);
            this.groupBox3.Controls.Add(this.btn_close_b);
            this.groupBox3.Location = new System.Drawing.Point(7, 201);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(515, 67);
            this.groupBox3.TabIndex = 102;
            this.groupBox3.TabStop = false;
            // 
            // btn_show_data
            // 
            this.btn_show_data.ActiveBorderThickness = 1;
            this.btn_show_data.ActiveCornerRadius = 20;
            this.btn_show_data.ActiveFillColor = System.Drawing.Color.SeaGreen;
            this.btn_show_data.ActiveForecolor = System.Drawing.Color.White;
            this.btn_show_data.ActiveLineColor = System.Drawing.Color.SeaGreen;
            this.btn_show_data.BackColor = System.Drawing.SystemColors.Control;
            this.btn_show_data.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_show_data.BackgroundImage")));
            this.btn_show_data.ButtonText = "رفع الدرجات";
            this.btn_show_data.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_show_data.Font = new System.Drawing.Font("LBC", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_show_data.ForeColor = System.Drawing.Color.SeaGreen;
            this.btn_show_data.IdleBorderThickness = 1;
            this.btn_show_data.IdleCornerRadius = 20;
            this.btn_show_data.IdleFillColor = System.Drawing.Color.WhiteSmoke;
            this.btn_show_data.IdleForecolor = System.Drawing.Color.SeaGreen;
            this.btn_show_data.IdleLineColor = System.Drawing.Color.SeaGreen;
            this.btn_show_data.Location = new System.Drawing.Point(359, 13);
            this.btn_show_data.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btn_show_data.Name = "btn_show_data";
            this.btn_show_data.Size = new System.Drawing.Size(138, 50);
            this.btn_show_data.TabIndex = 18;
            this.btn_show_data.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btn_show_data.Click += new System.EventHandler(this.btn_show_data_Click);
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
            // pn_top
            // 
            this.pn_top.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.pn_top.Controls.Add(this.btn_close);
            this.pn_top.Controls.Add(this.label11);
            this.pn_top.Dock = System.Windows.Forms.DockStyle.Top;
            this.pn_top.Location = new System.Drawing.Point(0, 0);
            this.pn_top.Name = "pn_top";
            this.pn_top.Size = new System.Drawing.Size(532, 50);
            this.pn_top.TabIndex = 104;
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
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("LBC", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.White;
            this.label11.Location = new System.Drawing.Point(155, 13);
            this.label11.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(222, 25);
            this.label11.TabIndex = 46;
            this.label11.Text = "إضافة درجات استمارة التقييم";
            // 
            // cmb_subject
            // 
            this.cmb_subject.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_subject.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cmb_subject.Font = new System.Drawing.Font("Noto Naskh Arabic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmb_subject.ForeColor = System.Drawing.Color.DimGray;
            this.cmb_subject.FormattingEnabled = true;
            this.cmb_subject.Items.AddRange(new object[] {
            "ar,1",
            "en,2"});
            this.cmb_subject.Location = new System.Drawing.Point(260, 41);
            this.cmb_subject.Name = "cmb_subject";
            this.cmb_subject.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.cmb_subject.Size = new System.Drawing.Size(190, 40);
            this.cmb_subject.TabIndex = 93;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Noto Naskh Arabic", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.label18.Location = new System.Drawing.Point(465, 46);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(46, 29);
            this.label18.TabIndex = 92;
            this.label18.Text = "المادة";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lbl_info);
            this.groupBox1.Controls.Add(this.cmb_term);
            this.groupBox1.Controls.Add(this.lbl_term);
            this.groupBox1.Controls.Add(this.cmb_year);
            this.groupBox1.Controls.Add(this.lbl_year);
            this.groupBox1.Controls.Add(this.cmb_grade);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.cmb_subject);
            this.groupBox1.Controls.Add(this.label18);
            this.groupBox1.Font = new System.Drawing.Font("LBC", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.Color.DarkGray;
            this.groupBox1.Location = new System.Drawing.Point(7, 54);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.groupBox1.Size = new System.Drawing.Size(517, 137);
            this.groupBox1.TabIndex = 103;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "اختر المادة";
            // 
            // cmb_grade
            // 
            this.cmb_grade.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_grade.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cmb_grade.Font = new System.Drawing.Font("Noto Naskh Arabic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmb_grade.ForeColor = System.Drawing.Color.DimGray;
            this.cmb_grade.FormattingEnabled = true;
            this.cmb_grade.Items.AddRange(new object[] {
            "ar,1",
            "en,2"});
            this.cmb_grade.Location = new System.Drawing.Point(21, 41);
            this.cmb_grade.Name = "cmb_grade";
            this.cmb_grade.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.cmb_grade.Size = new System.Drawing.Size(149, 40);
            this.cmb_grade.TabIndex = 95;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Noto Naskh Arabic", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.label1.Location = new System.Drawing.Point(185, 46);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 29);
            this.label1.TabIndex = 94;
            this.label1.Text = "الصف";
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.panel4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel4.Location = new System.Drawing.Point(0, 277);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(532, 10);
            this.panel4.TabIndex = 105;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // btn_del
            // 
            this.btn_del.ActiveBorderThickness = 1;
            this.btn_del.ActiveCornerRadius = 20;
            this.btn_del.ActiveFillColor = System.Drawing.Color.Red;
            this.btn_del.ActiveForecolor = System.Drawing.Color.White;
            this.btn_del.ActiveLineColor = System.Drawing.Color.OrangeRed;
            this.btn_del.BackColor = System.Drawing.SystemColors.Control;
            this.btn_del.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_del.BackgroundImage")));
            this.btn_del.ButtonText = "حذف الدرجات";
            this.btn_del.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_del.Font = new System.Drawing.Font("LBC", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_del.ForeColor = System.Drawing.Color.Red;
            this.btn_del.IdleBorderThickness = 1;
            this.btn_del.IdleCornerRadius = 20;
            this.btn_del.IdleFillColor = System.Drawing.Color.WhiteSmoke;
            this.btn_del.IdleForecolor = System.Drawing.Color.SaddleBrown;
            this.btn_del.IdleLineColor = System.Drawing.Color.Sienna;
            this.btn_del.Location = new System.Drawing.Point(338, 13);
            this.btn_del.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btn_del.Name = "btn_del";
            this.btn_del.Size = new System.Drawing.Size(138, 50);
            this.btn_del.TabIndex = 20;
            this.btn_del.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btn_del.Click += new System.EventHandler(this.btn_del_Click);
            // 
            // cmb_term
            // 
            this.cmb_term.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_term.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cmb_term.Font = new System.Drawing.Font("Noto Naskh Arabic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmb_term.ForeColor = System.Drawing.Color.DimGray;
            this.cmb_term.FormattingEnabled = true;
            this.cmb_term.Items.AddRange(new object[] {
            "ar,1",
            "en,2"});
            this.cmb_term.Location = new System.Drawing.Point(21, 87);
            this.cmb_term.Name = "cmb_term";
            this.cmb_term.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.cmb_term.Size = new System.Drawing.Size(149, 40);
            this.cmb_term.TabIndex = 99;
            // 
            // lbl_term
            // 
            this.lbl_term.AutoSize = true;
            this.lbl_term.Font = new System.Drawing.Font("Noto Naskh Arabic", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_term.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.lbl_term.Location = new System.Drawing.Point(185, 92);
            this.lbl_term.Name = "lbl_term";
            this.lbl_term.Size = new System.Drawing.Size(42, 29);
            this.lbl_term.TabIndex = 98;
            this.lbl_term.Text = "الترم";
            // 
            // cmb_year
            // 
            this.cmb_year.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_year.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cmb_year.Font = new System.Drawing.Font("Noto Naskh Arabic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmb_year.ForeColor = System.Drawing.Color.DimGray;
            this.cmb_year.FormattingEnabled = true;
            this.cmb_year.Items.AddRange(new object[] {
            "ar,1",
            "en,2"});
            this.cmb_year.Location = new System.Drawing.Point(260, 87);
            this.cmb_year.Name = "cmb_year";
            this.cmb_year.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.cmb_year.Size = new System.Drawing.Size(190, 40);
            this.cmb_year.TabIndex = 97;
            // 
            // lbl_year
            // 
            this.lbl_year.AutoSize = true;
            this.lbl_year.Font = new System.Drawing.Font("Noto Naskh Arabic", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_year.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.lbl_year.Location = new System.Drawing.Point(465, 92);
            this.lbl_year.Name = "lbl_year";
            this.lbl_year.Size = new System.Drawing.Size(40, 29);
            this.lbl_year.TabIndex = 96;
            this.lbl_year.Text = "العام";
            // 
            // lbl_info
            // 
            this.lbl_info.AutoSize = true;
            this.lbl_info.BackColor = System.Drawing.SystemColors.ControlLight;
            this.lbl_info.Font = new System.Drawing.Font("LBC", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_info.ForeColor = System.Drawing.Color.Red;
            this.lbl_info.Location = new System.Drawing.Point(5, 102);
            this.lbl_info.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.lbl_info.Name = "lbl_info";
            this.lbl_info.Size = new System.Drawing.Size(504, 25);
            this.lbl_info.TabIndex = 47;
            this.lbl_info.Text = "سوف يتم تحديد الصف والترم والعام الدراسي بناء علي ملف الإكسيل";
            // 
            // FRM_ADD_ASSESSMENT_DATA
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btn_close;
            this.ClientSize = new System.Drawing.Size(532, 287);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.pn_top);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.panel4);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FRM_ADD_ASSESSMENT_DATA";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FRM_ADD_ASSESSMENT_DATA";
            this.Load += new System.EventHandler(this.FRM_ADD_ASSESSMENT_DATA_Load);
            this.groupBox3.ResumeLayout(false);
            this.pn_top.ResumeLayout(false);
            this.pn_top.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox3;
        private Bunifu.Framework.UI.BunifuThinButton2 btn_show_data;
        private Bunifu.Framework.UI.BunifuThinButton2 btn_close_b;
        private System.Windows.Forms.Panel pn_top;
        private DevExpress.XtraEditors.SimpleButton btn_close;
        private System.Windows.Forms.Label label11;
        public System.Windows.Forms.ComboBox cmb_subject;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        public System.Windows.Forms.ComboBox cmb_grade;
        private System.Windows.Forms.Label label1;
        private Bunifu.Framework.UI.BunifuThinButton2 btn_del;
        public System.Windows.Forms.ComboBox cmb_term;
        private System.Windows.Forms.Label lbl_term;
        public System.Windows.Forms.ComboBox cmb_year;
        private System.Windows.Forms.Label lbl_year;
        private System.Windows.Forms.Label lbl_info;
    }
}