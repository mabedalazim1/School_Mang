
namespace School_Mang.PL.SITE
{
    partial class FRM_SITE_USER_DATA
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FRM_SITE_USER_DATA));
            this.lbl_help = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txt_std_data = new Bunifu.Framework.UI.BunifuMaterialTextbox();
            this.dt_std_data = new System.Windows.Forms.DataGridView();
            this.cmb_grade = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lbl_count = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btn_absent_std = new Bunifu.Framework.UI.BunifuThinButton2();
            this.btn_show_data = new Bunifu.Framework.UI.BunifuThinButton2();
            this.btn_close_b = new Bunifu.Framework.UI.BunifuThinButton2();
            this.lbl_title = new System.Windows.Forms.Label();
            this.pn_top = new System.Windows.Forms.Panel();
            this.btn_close = new DevExpress.XtraEditors.SimpleButton();
            this.panel4 = new System.Windows.Forms.Panel();
            this.pic_help = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.dt_std_data)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.pn_top.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pic_help)).BeginInit();
            this.SuspendLayout();
            // 
            // lbl_help
            // 
            this.lbl_help.AutoSize = true;
            this.lbl_help.Font = new System.Drawing.Font("Noto Naskh Arabic", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_help.Location = new System.Drawing.Point(367, 50);
            this.lbl_help.Name = "lbl_help";
            this.lbl_help.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lbl_help.Size = new System.Drawing.Size(29, 29);
            this.lbl_help.TabIndex = 109;
            this.lbl_help.Text = "    ";
            this.lbl_help.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label1.Font = new System.Drawing.Font("LBC", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(670, 72);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 25);
            this.label1.TabIndex = 105;
            this.label1.Text = "بحث";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            this.label1.MouseLeave += new System.EventHandler(this.label1_MouseLeave);
            this.label1.MouseHover += new System.EventHandler(this.label1_MouseHover);
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
            this.txt_std_data.Location = new System.Drawing.Point(294, 58);
            this.txt_std_data.Margin = new System.Windows.Forms.Padding(4);
            this.txt_std_data.Name = "txt_std_data";
            this.txt_std_data.Padding = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.txt_std_data.Size = new System.Drawing.Size(373, 44);
            this.txt_std_data.TabIndex = 101;
            this.txt_std_data.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txt_std_data.OnValueChanged += new System.EventHandler(this.txt_std_data_OnValueChanged);
            this.txt_std_data.Enter += new System.EventHandler(this.txt_std_data_Enter);
            this.txt_std_data.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_std_data_KeyPress);
            this.txt_std_data.MouseLeave += new System.EventHandler(this.txt_std_data_MouseLeave);
            // 
            // dt_std_data
            // 
            this.dt_std_data.AllowUserToAddRows = false;
            this.dt_std_data.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Noto Naskh Arabic", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dt_std_data.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dt_std_data.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dt_std_data.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dt_std_data.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableWithoutHeaderText;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("LBC", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dt_std_data.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dt_std_data.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dt_std_data.Location = new System.Drawing.Point(8, 109);
            this.dt_std_data.MultiSelect = false;
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
            this.dt_std_data.Size = new System.Drawing.Size(870, 395);
            this.dt_std_data.TabIndex = 100;
            this.dt_std_data.MouseClick += new System.Windows.Forms.MouseEventHandler(this.dt_std_data_MouseClick);
            // 
            // cmb_grade
            // 
            this.cmb_grade.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_grade.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cmb_grade.Font = new System.Drawing.Font("Noto Naskh Arabic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmb_grade.ForeColor = System.Drawing.Color.DimGray;
            this.cmb_grade.FormattingEnabled = true;
            this.cmb_grade.Location = new System.Drawing.Point(12, 62);
            this.cmb_grade.Name = "cmb_grade";
            this.cmb_grade.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.cmb_grade.Size = new System.Drawing.Size(181, 40);
            this.cmb_grade.TabIndex = 108;
            this.cmb_grade.SelectedIndexChanged += new System.EventHandler(this.cmb_grade_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label2.Font = new System.Drawing.Font("LBC", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(199, 72);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 25);
            this.label2.TabIndex = 102;
            this.label2.Text = "الصف";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label3.Font = new System.Drawing.Font("LBC", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(779, 72);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 25);
            this.label3.TabIndex = 103;
            this.label3.Text = "عدد الطلاب";
            // 
            // lbl_count
            // 
            this.lbl_count.AutoSize = true;
            this.lbl_count.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lbl_count.Font = new System.Drawing.Font("LBC", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_count.ForeColor = System.Drawing.Color.Black;
            this.lbl_count.Location = new System.Drawing.Point(729, 72);
            this.lbl_count.Name = "lbl_count";
            this.lbl_count.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lbl_count.Size = new System.Drawing.Size(0, 25);
            this.lbl_count.TabIndex = 104;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btn_absent_std);
            this.groupBox3.Controls.Add(this.btn_show_data);
            this.groupBox3.Controls.Add(this.btn_close_b);
            this.groupBox3.Location = new System.Drawing.Point(8, 507);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(870, 73);
            this.groupBox3.TabIndex = 106;
            this.groupBox3.TabStop = false;
            // 
            // btn_absent_std
            // 
            this.btn_absent_std.ActiveBorderThickness = 1;
            this.btn_absent_std.ActiveCornerRadius = 20;
            this.btn_absent_std.ActiveFillColor = System.Drawing.Color.Crimson;
            this.btn_absent_std.ActiveForecolor = System.Drawing.Color.White;
            this.btn_absent_std.ActiveLineColor = System.Drawing.Color.Crimson;
            this.btn_absent_std.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btn_absent_std.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_absent_std.BackgroundImage")));
            this.btn_absent_std.ButtonText = "حذف الطالب";
            this.btn_absent_std.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_absent_std.Font = new System.Drawing.Font("LBC", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_absent_std.ForeColor = System.Drawing.Color.Crimson;
            this.btn_absent_std.IdleBorderThickness = 1;
            this.btn_absent_std.IdleCornerRadius = 20;
            this.btn_absent_std.IdleFillColor = System.Drawing.Color.WhiteSmoke;
            this.btn_absent_std.IdleForecolor = System.Drawing.Color.Crimson;
            this.btn_absent_std.IdleLineColor = System.Drawing.Color.PaleVioletRed;
            this.btn_absent_std.Location = new System.Drawing.Point(366, 13);
            this.btn_absent_std.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btn_absent_std.Name = "btn_absent_std";
            this.btn_absent_std.Size = new System.Drawing.Size(138, 50);
            this.btn_absent_std.TabIndex = 18;
            this.btn_absent_std.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btn_absent_std.Click += new System.EventHandler(this.btn_absent_std_Click);
            // 
            // btn_show_data
            // 
            this.btn_show_data.ActiveBorderThickness = 1;
            this.btn_show_data.ActiveCornerRadius = 20;
            this.btn_show_data.ActiveFillColor = System.Drawing.Color.SeaGreen;
            this.btn_show_data.ActiveForecolor = System.Drawing.Color.White;
            this.btn_show_data.ActiveLineColor = System.Drawing.Color.SeaGreen;
            this.btn_show_data.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btn_show_data.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_show_data.BackgroundImage")));
            this.btn_show_data.ButtonText = "تعديل البيانات";
            this.btn_show_data.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_show_data.Font = new System.Drawing.Font("LBC", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_show_data.ForeColor = System.Drawing.Color.SeaGreen;
            this.btn_show_data.IdleBorderThickness = 1;
            this.btn_show_data.IdleCornerRadius = 20;
            this.btn_show_data.IdleFillColor = System.Drawing.Color.WhiteSmoke;
            this.btn_show_data.IdleForecolor = System.Drawing.Color.SeaGreen;
            this.btn_show_data.IdleLineColor = System.Drawing.Color.SeaGreen;
            this.btn_show_data.Location = new System.Drawing.Point(711, 10);
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
            this.btn_close_b.Location = new System.Drawing.Point(22, 10);
            this.btn_close_b.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btn_close_b.Name = "btn_close_b";
            this.btn_close_b.Size = new System.Drawing.Size(138, 50);
            this.btn_close_b.TabIndex = 19;
            this.btn_close_b.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btn_close_b.Click += new System.EventHandler(this.btn_close_b_Click);
            // 
            // lbl_title
            // 
            this.lbl_title.AutoSize = true;
            this.lbl_title.Font = new System.Drawing.Font("LBC", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_title.ForeColor = System.Drawing.Color.White;
            this.lbl_title.Location = new System.Drawing.Point(369, 13);
            this.lbl_title.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.lbl_title.Name = "lbl_title";
            this.lbl_title.Size = new System.Drawing.Size(152, 25);
            this.lbl_title.TabIndex = 46;
            this.lbl_title.Text = "بيانات المستخدمين";
            // 
            // pn_top
            // 
            this.pn_top.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.pn_top.Controls.Add(this.btn_close);
            this.pn_top.Controls.Add(this.lbl_title);
            this.pn_top.Dock = System.Windows.Forms.DockStyle.Top;
            this.pn_top.Location = new System.Drawing.Point(0, 0);
            this.pn_top.Name = "pn_top";
            this.pn_top.Size = new System.Drawing.Size(890, 50);
            this.pn_top.TabIndex = 98;
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
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.panel4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel4.Location = new System.Drawing.Point(0, 584);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(890, 10);
            this.panel4.TabIndex = 99;
            // 
            // pic_help
            // 
            this.pic_help.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pic_help.Image = global::School_Mang.Properties.Resources.help_80;
            this.pic_help.Location = new System.Drawing.Point(250, 65);
            this.pic_help.Name = "pic_help";
            this.pic_help.Size = new System.Drawing.Size(38, 32);
            this.pic_help.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pic_help.TabIndex = 107;
            this.pic_help.TabStop = false;
            this.pic_help.MouseLeave += new System.EventHandler(this.pic_help_MouseLeave);
            this.pic_help.MouseHover += new System.EventHandler(this.pic_help_MouseHover);
            // 
            // FRM_SITE_USER_DATA
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.CancelButton = this.btn_close;
            this.ClientSize = new System.Drawing.Size(890, 594);
            this.Controls.Add(this.lbl_help);
            this.Controls.Add(this.pic_help);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txt_std_data);
            this.Controls.Add(this.dt_std_data);
            this.Controls.Add(this.cmb_grade);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lbl_count);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.pn_top);
            this.Controls.Add(this.panel4);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FRM_SITE_USER_DATA";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "بيانات المستخدمين";
            this.Load += new System.EventHandler(this.FRM_SITE_USER_DATA_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dt_std_data)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.pn_top.ResumeLayout(false);
            this.pn_top.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pic_help)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_help;
        private Bunifu.Framework.UI.BunifuThinButton2 btn_show_data;
        private Bunifu.Framework.UI.BunifuThinButton2 btn_close_b;
        private System.Windows.Forms.PictureBox pic_help;
        private System.Windows.Forms.Label label1;
        public Bunifu.Framework.UI.BunifuMaterialTextbox txt_std_data;
        private System.Windows.Forms.DataGridView dt_std_data;
        private DevExpress.XtraEditors.SimpleButton btn_close;
        private System.Windows.Forms.ComboBox cmb_grade;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lbl_count;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label lbl_title;
        private System.Windows.Forms.Panel pn_top;
        private System.Windows.Forms.Panel panel4;
        private Bunifu.Framework.UI.BunifuThinButton2 btn_absent_std;
    }
}