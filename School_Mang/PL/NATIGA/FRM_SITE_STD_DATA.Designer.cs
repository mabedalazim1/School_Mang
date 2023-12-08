
namespace School_Mang.PL.NATIGA
{
    partial class FRM_SITE_STD_DATA
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FRM_SITE_STD_DATA));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.cmb_grade = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lbl_count = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btn_edit_std = new Bunifu.Framework.UI.BunifuThinButton2();
            this.btn_del_std = new Bunifu.Framework.UI.BunifuThinButton2();
            this.btn_new_std = new Bunifu.Framework.UI.BunifuThinButton2();
            this.btn_close_b = new Bunifu.Framework.UI.BunifuThinButton2();
            this.dt_std_data = new System.Windows.Forms.DataGridView();
            this.panel4 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.txt_std_data = new Bunifu.Framework.UI.BunifuMaterialTextbox();
            this.label11 = new System.Windows.Forms.Label();
            this.pn_top = new System.Windows.Forms.Panel();
            this.btn_close = new DevExpress.XtraEditors.SimpleButton();
            this.pic_help = new System.Windows.Forms.PictureBox();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dt_std_data)).BeginInit();
            this.pn_top.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pic_help)).BeginInit();
            this.SuspendLayout();
            // 
            // cmb_grade
            // 
            this.cmb_grade.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_grade.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cmb_grade.Font = new System.Drawing.Font("Noto Naskh Arabic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmb_grade.ForeColor = System.Drawing.Color.DimGray;
            this.cmb_grade.FormattingEnabled = true;
            this.cmb_grade.Location = new System.Drawing.Point(14, 66);
            this.cmb_grade.Name = "cmb_grade";
            this.cmb_grade.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.cmb_grade.Size = new System.Drawing.Size(181, 40);
            this.cmb_grade.TabIndex = 85;
            this.cmb_grade.DropDownClosed += new System.EventHandler(this.cmb_grade_DropDownClosed);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label2.Font = new System.Drawing.Font("LBC", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(201, 76);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 25);
            this.label2.TabIndex = 78;
            this.label2.Text = "الصف";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label3.Font = new System.Drawing.Font("LBC", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(1078, 76);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 25);
            this.label3.TabIndex = 79;
            this.label3.Text = "عدد الطلاب";
            // 
            // lbl_count
            // 
            this.lbl_count.AutoSize = true;
            this.lbl_count.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lbl_count.Font = new System.Drawing.Font("LBC", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_count.ForeColor = System.Drawing.Color.Black;
            this.lbl_count.Location = new System.Drawing.Point(1049, 76);
            this.lbl_count.Name = "lbl_count";
            this.lbl_count.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lbl_count.Size = new System.Drawing.Size(0, 25);
            this.lbl_count.TabIndex = 80;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btn_edit_std);
            this.groupBox3.Controls.Add(this.btn_del_std);
            this.groupBox3.Controls.Add(this.btn_new_std);
            this.groupBox3.Controls.Add(this.btn_close_b);
            this.groupBox3.Location = new System.Drawing.Point(10, 511);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(1168, 73);
            this.groupBox3.TabIndex = 82;
            this.groupBox3.TabStop = false;
            // 
            // btn_edit_std
            // 
            this.btn_edit_std.ActiveBorderThickness = 1;
            this.btn_edit_std.ActiveCornerRadius = 20;
            this.btn_edit_std.ActiveFillColor = System.Drawing.Color.CadetBlue;
            this.btn_edit_std.ActiveForecolor = System.Drawing.Color.White;
            this.btn_edit_std.ActiveLineColor = System.Drawing.Color.CadetBlue;
            this.btn_edit_std.BackColor = System.Drawing.SystemColors.Control;
            this.btn_edit_std.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_edit_std.BackgroundImage")));
            this.btn_edit_std.ButtonText = "تعديل الدرجات";
            this.btn_edit_std.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_edit_std.Font = new System.Drawing.Font("LBC", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_edit_std.ForeColor = System.Drawing.Color.RoyalBlue;
            this.btn_edit_std.IdleBorderThickness = 1;
            this.btn_edit_std.IdleCornerRadius = 20;
            this.btn_edit_std.IdleFillColor = System.Drawing.Color.WhiteSmoke;
            this.btn_edit_std.IdleForecolor = System.Drawing.Color.DodgerBlue;
            this.btn_edit_std.IdleLineColor = System.Drawing.Color.SteelBlue;
            this.btn_edit_std.Location = new System.Drawing.Point(776, 15);
            this.btn_edit_std.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btn_edit_std.Name = "btn_edit_std";
            this.btn_edit_std.Size = new System.Drawing.Size(138, 50);
            this.btn_edit_std.TabIndex = 74;
            this.btn_edit_std.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btn_edit_std.Click += new System.EventHandler(this.btn_edit_std_Click);
            // 
            // btn_del_std
            // 
            this.btn_del_std.ActiveBorderThickness = 1;
            this.btn_del_std.ActiveCornerRadius = 20;
            this.btn_del_std.ActiveFillColor = System.Drawing.Color.Crimson;
            this.btn_del_std.ActiveForecolor = System.Drawing.Color.White;
            this.btn_del_std.ActiveLineColor = System.Drawing.Color.Crimson;
            this.btn_del_std.BackColor = System.Drawing.SystemColors.Control;
            this.btn_del_std.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_del_std.BackgroundImage")));
            this.btn_del_std.ButtonText = "حذف الطالب";
            this.btn_del_std.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_del_std.Font = new System.Drawing.Font("LBC", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_del_std.ForeColor = System.Drawing.Color.Crimson;
            this.btn_del_std.IdleBorderThickness = 1;
            this.btn_del_std.IdleCornerRadius = 20;
            this.btn_del_std.IdleFillColor = System.Drawing.Color.WhiteSmoke;
            this.btn_del_std.IdleForecolor = System.Drawing.Color.Crimson;
            this.btn_del_std.IdleLineColor = System.Drawing.Color.PaleVioletRed;
            this.btn_del_std.Location = new System.Drawing.Point(215, 15);
            this.btn_del_std.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btn_del_std.Name = "btn_del_std";
            this.btn_del_std.Size = new System.Drawing.Size(138, 50);
            this.btn_del_std.TabIndex = 18;
            this.btn_del_std.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btn_new_std
            // 
            this.btn_new_std.ActiveBorderThickness = 1;
            this.btn_new_std.ActiveCornerRadius = 20;
            this.btn_new_std.ActiveFillColor = System.Drawing.Color.SeaGreen;
            this.btn_new_std.ActiveForecolor = System.Drawing.Color.White;
            this.btn_new_std.ActiveLineColor = System.Drawing.Color.SeaGreen;
            this.btn_new_std.BackColor = System.Drawing.SystemColors.Control;
            this.btn_new_std.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_new_std.BackgroundImage")));
            this.btn_new_std.ButtonText = "إضافة  جديد";
            this.btn_new_std.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_new_std.Font = new System.Drawing.Font("LBC", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_new_std.ForeColor = System.Drawing.Color.SeaGreen;
            this.btn_new_std.IdleBorderThickness = 1;
            this.btn_new_std.IdleCornerRadius = 20;
            this.btn_new_std.IdleFillColor = System.Drawing.Color.WhiteSmoke;
            this.btn_new_std.IdleForecolor = System.Drawing.Color.SeaGreen;
            this.btn_new_std.IdleLineColor = System.Drawing.Color.SeaGreen;
            this.btn_new_std.Location = new System.Drawing.Point(984, 15);
            this.btn_new_std.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btn_new_std.Name = "btn_new_std";
            this.btn_new_std.Size = new System.Drawing.Size(138, 50);
            this.btn_new_std.TabIndex = 18;
            this.btn_new_std.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
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
            this.btn_close_b.Location = new System.Drawing.Point(7, 15);
            this.btn_close_b.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btn_close_b.Name = "btn_close_b";
            this.btn_close_b.Size = new System.Drawing.Size(138, 50);
            this.btn_close_b.TabIndex = 19;
            this.btn_close_b.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btn_close_b.Click += new System.EventHandler(this.btn_close_b_Click);
            // 
            // dt_std_data
            // 
            this.dt_std_data.AllowUserToAddRows = false;
            this.dt_std_data.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Noto Naskh Arabic", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dt_std_data.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dt_std_data.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dt_std_data.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("LBC", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dt_std_data.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dt_std_data.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dt_std_data.Location = new System.Drawing.Point(10, 113);
            this.dt_std_data.Name = "dt_std_data";
            this.dt_std_data.ReadOnly = true;
            this.dt_std_data.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Noto Naskh Arabic", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dt_std_data.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Noto Naskh Arabic", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dt_std_data.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dt_std_data.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Noto Naskh Arabic", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dt_std_data.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dt_std_data.Size = new System.Drawing.Size(1178, 395);
            this.dt_std_data.TabIndex = 76;
            this.dt_std_data.DoubleClick += new System.EventHandler(this.dt_std_data_DoubleClick);
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.panel4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel4.Location = new System.Drawing.Point(0, 608);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(1200, 10);
            this.panel4.TabIndex = 75;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label1.Font = new System.Drawing.Font("LBC", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(916, 76);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 25);
            this.label1.TabIndex = 81;
            this.label1.Text = "بحث";
            // 
            // txt_std_data
            // 
            this.txt_std_data.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_std_data.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txt_std_data.Font = new System.Drawing.Font("Noto Naskh Arabic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_std_data.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txt_std_data.HintForeColor = System.Drawing.Color.Empty;
            this.txt_std_data.HintText = "";
            this.txt_std_data.isPassword = false;
            this.txt_std_data.LineFocusedColor = System.Drawing.Color.Blue;
            this.txt_std_data.LineIdleColor = System.Drawing.Color.Gray;
            this.txt_std_data.LineMouseHoverColor = System.Drawing.Color.Blue;
            this.txt_std_data.LineThickness = 5;
            this.txt_std_data.Location = new System.Drawing.Point(441, 62);
            this.txt_std_data.Margin = new System.Windows.Forms.Padding(4);
            this.txt_std_data.Name = "txt_std_data";
            this.txt_std_data.Padding = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.txt_std_data.Size = new System.Drawing.Size(464, 44);
            this.txt_std_data.TabIndex = 77;
            this.txt_std_data.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txt_std_data.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txt_std_data_KeyUp);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("LBC", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.White;
            this.label11.Location = new System.Drawing.Point(434, 13);
            this.label11.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(114, 25);
            this.label11.TabIndex = 46;
            this.label11.Text = "بيانات الطلاب ";
            // 
            // pn_top
            // 
            this.pn_top.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.pn_top.Controls.Add(this.label11);
            this.pn_top.Controls.Add(this.btn_close);
            this.pn_top.Dock = System.Windows.Forms.DockStyle.Top;
            this.pn_top.Location = new System.Drawing.Point(0, 0);
            this.pn_top.Name = "pn_top";
            this.pn_top.Size = new System.Drawing.Size(1200, 50);
            this.pn_top.TabIndex = 74;
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
            // pic_help
            // 
            this.pic_help.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pic_help.Image = global::School_Mang.Properties.Resources.help_80;
            this.pic_help.Location = new System.Drawing.Point(397, 69);
            this.pic_help.Name = "pic_help";
            this.pic_help.Size = new System.Drawing.Size(38, 32);
            this.pic_help.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pic_help.TabIndex = 83;
            this.pic_help.TabStop = false;
            // 
            // FRM_SITE_STD_DATA
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1200, 618);
            this.Controls.Add(this.cmb_grade);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lbl_count);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.dt_std_data);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txt_std_data);
            this.Controls.Add(this.pic_help);
            this.Controls.Add(this.pn_top);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FRM_SITE_STD_DATA";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "بيانات الطلاب - الموقع";
            this.Load += new System.EventHandler(this.FRM_SITE_STD_DATA_Load);
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dt_std_data)).EndInit();
            this.pn_top.ResumeLayout(false);
            this.pn_top.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pic_help)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmb_grade;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lbl_count;
        private System.Windows.Forms.GroupBox groupBox3;
        private Bunifu.Framework.UI.BunifuThinButton2 btn_edit_std;
        private Bunifu.Framework.UI.BunifuThinButton2 btn_del_std;
        private Bunifu.Framework.UI.BunifuThinButton2 btn_new_std;
        private Bunifu.Framework.UI.BunifuThinButton2 btn_close_b;
        private System.Windows.Forms.DataGridView dt_std_data;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label label1;
        public Bunifu.Framework.UI.BunifuMaterialTextbox txt_std_data;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Panel pn_top;
        private DevExpress.XtraEditors.SimpleButton btn_close;
        private System.Windows.Forms.PictureBox pic_help;
    }
}