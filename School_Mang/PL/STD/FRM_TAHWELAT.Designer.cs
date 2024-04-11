
namespace School_Mang.PL.STD
{
    partial class FRM_TAHWELAT
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FRM_TAHWELAT));
            this.cmb_status = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.dt_std_data = new System.Windows.Forms.DataGridView();
            this.cmb_grade = new System.Windows.Forms.ComboBox();
            this.lbl_help = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lbl_count = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txt_std_data = new Bunifu.Framework.UI.BunifuMaterialTextbox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btn_talab_tahewl = new Bunifu.Framework.UI.BunifuThinButton2();
            this.btn_del_std = new Bunifu.Framework.UI.BunifuThinButton2();
            this.btn_new_std = new Bunifu.Framework.UI.BunifuThinButton2();
            this.btn_close_b = new Bunifu.Framework.UI.BunifuThinButton2();
            this.lbl_current_year = new System.Windows.Forms.Label();
            this.pn_top = new System.Windows.Forms.Panel();
            this.lbl_year_b = new System.Windows.Forms.Label();
            this.btn_close = new DevExpress.XtraEditors.SimpleButton();
            this.panel4 = new System.Windows.Forms.Panel();
            this.pic_help = new System.Windows.Forms.PictureBox();
            this.btn_current_year = new Bunifu.Framework.UI.BunifuThinButton2();
            ((System.ComponentModel.ISupportInitialize)(this.dt_std_data)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.pn_top.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pic_help)).BeginInit();
            this.SuspendLayout();
            // 
            // cmb_status
            // 
            this.cmb_status.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_status.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cmb_status.Font = new System.Drawing.Font("Noto Naskh Arabic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmb_status.ForeColor = System.Drawing.Color.DimGray;
            this.cmb_status.FormattingEnabled = true;
            this.cmb_status.Items.AddRange(new object[] {
            "من المدرسة",
            "إلى المدرسة"});
            this.cmb_status.Location = new System.Drawing.Point(16, 69);
            this.cmb_status.Name = "cmb_status";
            this.cmb_status.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.cmb_status.Size = new System.Drawing.Size(103, 40);
            this.cmb_status.TabIndex = 98;
            this.cmb_status.SelectedIndexChanged += new System.EventHandler(this.cmb_status_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label4.Font = new System.Drawing.Font("LBC", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(124, 79);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(98, 25);
            this.label4.TabIndex = 97;
            this.label4.Text = "نوع التحويل";
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
            this.dt_std_data.Location = new System.Drawing.Point(12, 126);
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
            this.dt_std_data.Size = new System.Drawing.Size(1003, 395);
            this.dt_std_data.TabIndex = 96;
            // 
            // cmb_grade
            // 
            this.cmb_grade.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_grade.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cmb_grade.Font = new System.Drawing.Font("Noto Naskh Arabic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmb_grade.ForeColor = System.Drawing.Color.DimGray;
            this.cmb_grade.FormattingEnabled = true;
            this.cmb_grade.Items.AddRange(new object[] {
            "الكل",
            "الأول الإبتدائى",
            "الثانى الإبتدائى",
            "الثالث الإبتدائى",
            "الرابع الإبتدائى",
            "الخامس الإبتدائى",
            "السادس الإبتدائى",
            "الأول الإعدادى",
            "الثانى  الإعدادى",
            "الثالث  الإعدادى",
            "KG1",
            "KG2"});
            this.cmb_grade.Location = new System.Drawing.Point(218, 69);
            this.cmb_grade.Name = "cmb_grade";
            this.cmb_grade.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.cmb_grade.Size = new System.Drawing.Size(110, 40);
            this.cmb_grade.TabIndex = 95;
            this.cmb_grade.SelectedIndexChanged += new System.EventHandler(this.cmb_grade_SelectedIndexChanged);
            // 
            // lbl_help
            // 
            this.lbl_help.AutoSize = true;
            this.lbl_help.Font = new System.Drawing.Font("Noto Naskh Arabic", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_help.Location = new System.Drawing.Point(436, 53);
            this.lbl_help.Name = "lbl_help";
            this.lbl_help.Size = new System.Drawing.Size(29, 29);
            this.lbl_help.TabIndex = 94;
            this.lbl_help.Text = "    ";
            this.lbl_help.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label2.Font = new System.Drawing.Font("LBC", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(330, 79);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 25);
            this.label2.TabIndex = 89;
            this.label2.Text = "الصف";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label3.Font = new System.Drawing.Font("LBC", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(793, 77);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 25);
            this.label3.TabIndex = 90;
            this.label3.Text = "عدد الطلاب";
            // 
            // lbl_count
            // 
            this.lbl_count.AutoSize = true;
            this.lbl_count.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lbl_count.Font = new System.Drawing.Font("LBC", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_count.ForeColor = System.Drawing.Color.Black;
            this.lbl_count.Location = new System.Drawing.Point(763, 79);
            this.lbl_count.Name = "lbl_count";
            this.lbl_count.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lbl_count.Size = new System.Drawing.Size(0, 25);
            this.lbl_count.TabIndex = 91;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label1.Font = new System.Drawing.Font("LBC", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(707, 79);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 25);
            this.label1.TabIndex = 92;
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
            this.txt_std_data.Location = new System.Drawing.Point(419, 65);
            this.txt_std_data.Margin = new System.Windows.Forms.Padding(4);
            this.txt_std_data.Name = "txt_std_data";
            this.txt_std_data.Padding = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.txt_std_data.Size = new System.Drawing.Size(292, 44);
            this.txt_std_data.TabIndex = 88;
            this.txt_std_data.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txt_std_data.Enter += new System.EventHandler(this.txt_std_data_Enter);
            this.txt_std_data.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_std_data_KeyPress);
            this.txt_std_data.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txt_std_data_KeyUp);
            this.txt_std_data.MouseLeave += new System.EventHandler(this.txt_std_data_MouseLeave);
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.btn_talab_tahewl);
            this.groupBox3.Controls.Add(this.btn_del_std);
            this.groupBox3.Controls.Add(this.btn_new_std);
            this.groupBox3.Controls.Add(this.btn_close_b);
            this.groupBox3.Location = new System.Drawing.Point(12, 529);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(1003, 73);
            this.groupBox3.TabIndex = 87;
            this.groupBox3.TabStop = false;
            // 
            // btn_talab_tahewl
            // 
            this.btn_talab_tahewl.ActiveBorderThickness = 1;
            this.btn_talab_tahewl.ActiveCornerRadius = 20;
            this.btn_talab_tahewl.ActiveFillColor = System.Drawing.Color.Teal;
            this.btn_talab_tahewl.ActiveForecolor = System.Drawing.Color.White;
            this.btn_talab_tahewl.ActiveLineColor = System.Drawing.Color.Teal;
            this.btn_talab_tahewl.BackColor = System.Drawing.SystemColors.Control;
            this.btn_talab_tahewl.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_talab_tahewl.BackgroundImage")));
            this.btn_talab_tahewl.ButtonText = "طباعة طلب التحويل";
            this.btn_talab_tahewl.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_talab_tahewl.Font = new System.Drawing.Font("LBC", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_talab_tahewl.ForeColor = System.Drawing.Color.DarkCyan;
            this.btn_talab_tahewl.IdleBorderThickness = 1;
            this.btn_talab_tahewl.IdleCornerRadius = 20;
            this.btn_talab_tahewl.IdleFillColor = System.Drawing.Color.WhiteSmoke;
            this.btn_talab_tahewl.IdleForecolor = System.Drawing.Color.DarkCyan;
            this.btn_talab_tahewl.IdleLineColor = System.Drawing.Color.CadetBlue;
            this.btn_talab_tahewl.Location = new System.Drawing.Point(543, 15);
            this.btn_talab_tahewl.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btn_talab_tahewl.Name = "btn_talab_tahewl";
            this.btn_talab_tahewl.Size = new System.Drawing.Size(169, 50);
            this.btn_talab_tahewl.TabIndex = 76;
            this.btn_talab_tahewl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btn_talab_tahewl.Click += new System.EventHandler(this.btn_talab_tahewl_Click);
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
            this.btn_del_std.ButtonText = "حذف طلب التحويل";
            this.btn_del_std.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_del_std.Font = new System.Drawing.Font("LBC", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_del_std.ForeColor = System.Drawing.Color.Crimson;
            this.btn_del_std.IdleBorderThickness = 1;
            this.btn_del_std.IdleCornerRadius = 20;
            this.btn_del_std.IdleFillColor = System.Drawing.Color.WhiteSmoke;
            this.btn_del_std.IdleForecolor = System.Drawing.Color.Crimson;
            this.btn_del_std.IdleLineColor = System.Drawing.Color.PaleVioletRed;
            this.btn_del_std.Location = new System.Drawing.Point(275, 15);
            this.btn_del_std.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btn_del_std.Name = "btn_del_std";
            this.btn_del_std.Size = new System.Drawing.Size(169, 50);
            this.btn_del_std.TabIndex = 18;
            this.btn_del_std.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btn_del_std.Click += new System.EventHandler(this.btn_del_std_Click);
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
            this.btn_new_std.ButtonText = "تعديل طلب التحويل";
            this.btn_new_std.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_new_std.Font = new System.Drawing.Font("LBC", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_new_std.ForeColor = System.Drawing.Color.SeaGreen;
            this.btn_new_std.IdleBorderThickness = 1;
            this.btn_new_std.IdleCornerRadius = 20;
            this.btn_new_std.IdleFillColor = System.Drawing.Color.WhiteSmoke;
            this.btn_new_std.IdleForecolor = System.Drawing.Color.SeaGreen;
            this.btn_new_std.IdleLineColor = System.Drawing.Color.SeaGreen;
            this.btn_new_std.Location = new System.Drawing.Point(811, 15);
            this.btn_new_std.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btn_new_std.Name = "btn_new_std";
            this.btn_new_std.Size = new System.Drawing.Size(169, 50);
            this.btn_new_std.TabIndex = 18;
            this.btn_new_std.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btn_new_std.Click += new System.EventHandler(this.btn_new_std_Click);
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
            this.btn_close_b.Size = new System.Drawing.Size(169, 50);
            this.btn_close_b.TabIndex = 19;
            this.btn_close_b.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btn_close_b.Click += new System.EventHandler(this.btn_close_b_Click);
            // 
            // lbl_current_year
            // 
            this.lbl_current_year.AutoSize = true;
            this.lbl_current_year.Font = new System.Drawing.Font("LBC", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_current_year.ForeColor = System.Drawing.Color.White;
            this.lbl_current_year.Location = new System.Drawing.Point(457, 13);
            this.lbl_current_year.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.lbl_current_year.Name = "lbl_current_year";
            this.lbl_current_year.Size = new System.Drawing.Size(112, 25);
            this.lbl_current_year.TabIndex = 46;
            this.lbl_current_year.Text = "بيان التحويلات";
            // 
            // pn_top
            // 
            this.pn_top.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.pn_top.Controls.Add(this.btn_close);
            this.pn_top.Controls.Add(this.lbl_year_b);
            this.pn_top.Controls.Add(this.lbl_current_year);
            this.pn_top.Dock = System.Windows.Forms.DockStyle.Top;
            this.pn_top.Location = new System.Drawing.Point(0, 0);
            this.pn_top.Name = "pn_top";
            this.pn_top.Size = new System.Drawing.Size(1027, 50);
            this.pn_top.TabIndex = 85;
            this.pn_top.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pn_top_MouseDown);
            this.pn_top.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pn_top_MouseMove);
            this.pn_top.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pn_top_MouseUp);
            // 
            // lbl_year_b
            // 
            this.lbl_year_b.AutoSize = true;
            this.lbl_year_b.BackColor = System.Drawing.SystemColors.Highlight;
            this.lbl_year_b.Font = new System.Drawing.Font("LBC", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_year_b.ForeColor = System.Drawing.Color.White;
            this.lbl_year_b.Location = new System.Drawing.Point(408, 16);
            this.lbl_year_b.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.lbl_year_b.Name = "lbl_year_b";
            this.lbl_year_b.Size = new System.Drawing.Size(50, 22);
            this.lbl_year_b.TabIndex = 48;
            this.lbl_year_b.Text = "2023";
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
            this.panel4.Location = new System.Drawing.Point(0, 608);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(1027, 10);
            this.panel4.TabIndex = 86;
            // 
            // pic_help
            // 
            this.pic_help.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pic_help.Image = global::School_Mang.Properties.Resources.help_80;
            this.pic_help.Location = new System.Drawing.Point(382, 72);
            this.pic_help.Name = "pic_help";
            this.pic_help.Size = new System.Drawing.Size(38, 32);
            this.pic_help.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pic_help.TabIndex = 93;
            this.pic_help.TabStop = false;
            this.pic_help.MouseLeave += new System.EventHandler(this.pic_help_MouseLeave);
            this.pic_help.MouseHover += new System.EventHandler(this.pic_help_MouseHover);
            // 
            // btn_current_year
            // 
            this.btn_current_year.ActiveBorderThickness = 1;
            this.btn_current_year.ActiveCornerRadius = 20;
            this.btn_current_year.ActiveFillColor = System.Drawing.Color.Crimson;
            this.btn_current_year.ActiveForecolor = System.Drawing.Color.White;
            this.btn_current_year.ActiveLineColor = System.Drawing.Color.Pink;
            this.btn_current_year.BackColor = System.Drawing.SystemColors.Control;
            this.btn_current_year.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_current_year.BackgroundImage")));
            this.btn_current_year.ButtonText = "العام القادم";
            this.btn_current_year.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_current_year.Font = new System.Drawing.Font("LBC", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_current_year.ForeColor = System.Drawing.Color.Crimson;
            this.btn_current_year.IdleBorderThickness = 1;
            this.btn_current_year.IdleCornerRadius = 20;
            this.btn_current_year.IdleFillColor = System.Drawing.Color.WhiteSmoke;
            this.btn_current_year.IdleForecolor = System.Drawing.Color.Crimson;
            this.btn_current_year.IdleLineColor = System.Drawing.Color.MediumVioletRed;
            this.btn_current_year.Location = new System.Drawing.Point(900, 70);
            this.btn_current_year.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btn_current_year.Name = "btn_current_year";
            this.btn_current_year.Size = new System.Drawing.Size(114, 53);
            this.btn_current_year.TabIndex = 99;
            this.btn_current_year.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btn_current_year.Click += new System.EventHandler(this.btn_current_year_Click);
            // 
            // FRM_TAHWELAT
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1027, 618);
            this.Controls.Add(this.btn_current_year);
            this.Controls.Add(this.cmb_status);
            this.Controls.Add(this.dt_std_data);
            this.Controls.Add(this.cmb_grade);
            this.Controls.Add(this.lbl_help);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lbl_count);
            this.Controls.Add(this.txt_std_data);
            this.Controls.Add(this.pic_help);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.pn_top);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FRM_TAHWELAT";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "التحويلات";
            this.Load += new System.EventHandler(this.FRM_TAHWELAT_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dt_std_data)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.pn_top.ResumeLayout(false);
            this.pn_top.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pic_help)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmb_status;
        private System.Windows.Forms.Label label4;
        public System.Windows.Forms.DataGridView dt_std_data;
        public System.Windows.Forms.ComboBox cmb_grade;
        private System.Windows.Forms.Label lbl_help;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lbl_count;
        private System.Windows.Forms.Label label1;
        private Bunifu.Framework.UI.BunifuMaterialTextbox txt_std_data;
        private System.Windows.Forms.PictureBox pic_help;
        public Bunifu.Framework.UI.BunifuThinButton2 btn_del_std;
        public Bunifu.Framework.UI.BunifuThinButton2 btn_new_std;
        private Bunifu.Framework.UI.BunifuThinButton2 btn_close_b;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label lbl_current_year;
        private DevExpress.XtraEditors.SimpleButton btn_close;
        private System.Windows.Forms.Panel pn_top;
        private System.Windows.Forms.Panel panel4;
        private Bunifu.Framework.UI.BunifuThinButton2 btn_talab_tahewl;
        private Bunifu.Framework.UI.BunifuThinButton2 btn_current_year;
        private System.Windows.Forms.Label lbl_year_b;
    }
}