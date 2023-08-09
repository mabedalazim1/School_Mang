
namespace School_Mang.PL.STD
{
    partial class FRM_CURRENT_STD
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FRM_CURRENT_STD));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pn_top = new System.Windows.Forms.Panel();
            this.lbl_current_year = new System.Windows.Forms.Label();
            this.btn_close = new DevExpress.XtraEditors.SimpleButton();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btn_talab_elthak = new Bunifu.Framework.UI.BunifuThinButton2();
            this.btn_tahwel = new Bunifu.Framework.UI.BunifuThinButton2();
            this.btn_del_std = new Bunifu.Framework.UI.BunifuThinButton2();
            this.btn_new_std = new Bunifu.Framework.UI.BunifuThinButton2();
            this.btn_close_b = new Bunifu.Framework.UI.BunifuThinButton2();
            this.panel4 = new System.Windows.Forms.Panel();
            this.cmb_grade = new System.Windows.Forms.ComboBox();
            this.lbl_help = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lbl_count = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txt_std_data = new Bunifu.Framework.UI.BunifuMaterialTextbox();
            this.dt_std_data = new System.Windows.Forms.DataGridView();
            this.cmb_class = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.pic_help = new System.Windows.Forms.PictureBox();
            this.pn_top.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dt_std_data)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_help)).BeginInit();
            this.SuspendLayout();
            // 
            // pn_top
            // 
            this.pn_top.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.pn_top.Controls.Add(this.lbl_current_year);
            this.pn_top.Controls.Add(this.btn_close);
            this.pn_top.Dock = System.Windows.Forms.DockStyle.Top;
            this.pn_top.Location = new System.Drawing.Point(0, 0);
            this.pn_top.Name = "pn_top";
            this.pn_top.Size = new System.Drawing.Size(1027, 50);
            this.pn_top.TabIndex = 71;
            this.pn_top.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pn_top_MouseDown);
            this.pn_top.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pn_top_MouseMove);
            this.pn_top.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pn_top_MouseUp);
            // 
            // lbl_current_year
            // 
            this.lbl_current_year.AutoSize = true;
            this.lbl_current_year.Font = new System.Drawing.Font("LBC", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_current_year.ForeColor = System.Drawing.Color.White;
            this.lbl_current_year.Location = new System.Drawing.Point(384, 13);
            this.lbl_current_year.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.lbl_current_year.Name = "lbl_current_year";
            this.lbl_current_year.Size = new System.Drawing.Size(259, 25);
            this.lbl_current_year.TabIndex = 46;
            this.lbl_current_year.Text = "بيانات العام الدراسى 2021-2022";
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
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.btn_talab_elthak);
            this.groupBox3.Controls.Add(this.btn_tahwel);
            this.groupBox3.Controls.Add(this.btn_del_std);
            this.groupBox3.Controls.Add(this.btn_new_std);
            this.groupBox3.Controls.Add(this.btn_close_b);
            this.groupBox3.Location = new System.Drawing.Point(12, 529);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(1003, 73);
            this.groupBox3.TabIndex = 73;
            this.groupBox3.TabStop = false;
            // 
            // btn_talab_elthak
            // 
            this.btn_talab_elthak.ActiveBorderThickness = 1;
            this.btn_talab_elthak.ActiveCornerRadius = 20;
            this.btn_talab_elthak.ActiveFillColor = System.Drawing.Color.Teal;
            this.btn_talab_elthak.ActiveForecolor = System.Drawing.Color.White;
            this.btn_talab_elthak.ActiveLineColor = System.Drawing.Color.Teal;
            this.btn_talab_elthak.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btn_talab_elthak.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_talab_elthak.BackgroundImage")));
            this.btn_talab_elthak.ButtonText = "طباعة طلب التحاق";
            this.btn_talab_elthak.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_talab_elthak.Font = new System.Drawing.Font("LBC", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_talab_elthak.ForeColor = System.Drawing.Color.DarkCyan;
            this.btn_talab_elthak.IdleBorderThickness = 1;
            this.btn_talab_elthak.IdleCornerRadius = 20;
            this.btn_talab_elthak.IdleFillColor = System.Drawing.Color.WhiteSmoke;
            this.btn_talab_elthak.IdleForecolor = System.Drawing.Color.DarkCyan;
            this.btn_talab_elthak.IdleLineColor = System.Drawing.Color.CadetBlue;
            this.btn_talab_elthak.Location = new System.Drawing.Point(610, 15);
            this.btn_talab_elthak.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btn_talab_elthak.Name = "btn_talab_elthak";
            this.btn_talab_elthak.Size = new System.Drawing.Size(169, 50);
            this.btn_talab_elthak.TabIndex = 75;
            this.btn_talab_elthak.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btn_talab_elthak.Click += new System.EventHandler(this.btn_talab_elthak_Click);
            // 
            // btn_tahwel
            // 
            this.btn_tahwel.ActiveBorderThickness = 1;
            this.btn_tahwel.ActiveCornerRadius = 20;
            this.btn_tahwel.ActiveFillColor = System.Drawing.Color.CadetBlue;
            this.btn_tahwel.ActiveForecolor = System.Drawing.Color.White;
            this.btn_tahwel.ActiveLineColor = System.Drawing.Color.CadetBlue;
            this.btn_tahwel.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btn_tahwel.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_tahwel.BackgroundImage")));
            this.btn_tahwel.ButtonText = " تحويل من المدرسة";
            this.btn_tahwel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_tahwel.Font = new System.Drawing.Font("LBC", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_tahwel.ForeColor = System.Drawing.Color.RoyalBlue;
            this.btn_tahwel.IdleBorderThickness = 1;
            this.btn_tahwel.IdleCornerRadius = 20;
            this.btn_tahwel.IdleFillColor = System.Drawing.Color.WhiteSmoke;
            this.btn_tahwel.IdleForecolor = System.Drawing.Color.DodgerBlue;
            this.btn_tahwel.IdleLineColor = System.Drawing.Color.SteelBlue;
            this.btn_tahwel.Location = new System.Drawing.Point(409, 15);
            this.btn_tahwel.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btn_tahwel.Name = "btn_tahwel";
            this.btn_tahwel.Size = new System.Drawing.Size(169, 50);
            this.btn_tahwel.TabIndex = 74;
            this.btn_tahwel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btn_tahwel.Click += new System.EventHandler(this.btn_tahwel_Click);
            // 
            // btn_del_std
            // 
            this.btn_del_std.ActiveBorderThickness = 1;
            this.btn_del_std.ActiveCornerRadius = 20;
            this.btn_del_std.ActiveFillColor = System.Drawing.Color.Crimson;
            this.btn_del_std.ActiveForecolor = System.Drawing.Color.White;
            this.btn_del_std.ActiveLineColor = System.Drawing.Color.Crimson;
            this.btn_del_std.BackColor = System.Drawing.Color.WhiteSmoke;
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
            this.btn_del_std.Location = new System.Drawing.Point(208, 15);
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
            this.btn_new_std.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btn_new_std.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_new_std.BackgroundImage")));
            this.btn_new_std.ButtonText = "تعديل البيانات";
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
            this.btn_close_b.Location = new System.Drawing.Point(7, 15);
            this.btn_close_b.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btn_close_b.Name = "btn_close_b";
            this.btn_close_b.Size = new System.Drawing.Size(169, 50);
            this.btn_close_b.TabIndex = 19;
            this.btn_close_b.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btn_close_b.Click += new System.EventHandler(this.btn_close_b_Click);
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.panel4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel4.Location = new System.Drawing.Point(0, 608);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(1027, 10);
            this.panel4.TabIndex = 72;
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
            this.cmb_grade.Location = new System.Drawing.Point(151, 69);
            this.cmb_grade.Name = "cmb_grade";
            this.cmb_grade.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.cmb_grade.Size = new System.Drawing.Size(153, 40);
            this.cmb_grade.TabIndex = 81;
            this.cmb_grade.SelectedIndexChanged += new System.EventHandler(this.cmb_grade_SelectedIndexChanged);
            // 
            // lbl_help
            // 
            this.lbl_help.AutoSize = true;
            this.lbl_help.Font = new System.Drawing.Font("Noto Naskh Arabic", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_help.Location = new System.Drawing.Point(419, 53);
            this.lbl_help.Name = "lbl_help";
            this.lbl_help.Size = new System.Drawing.Size(29, 29);
            this.lbl_help.TabIndex = 80;
            this.lbl_help.Text = "    ";
            this.lbl_help.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label2.Font = new System.Drawing.Font("LBC", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(303, 79);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 25);
            this.label2.TabIndex = 75;
            this.label2.Text = "الصف";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label3.Font = new System.Drawing.Font("LBC", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(897, 79);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 25);
            this.label3.TabIndex = 76;
            this.label3.Text = "عدد الطلاب";
            // 
            // lbl_count
            // 
            this.lbl_count.AutoSize = true;
            this.lbl_count.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lbl_count.Font = new System.Drawing.Font("LBC", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_count.ForeColor = System.Drawing.Color.Black;
            this.lbl_count.Location = new System.Drawing.Point(851, 79);
            this.lbl_count.Name = "lbl_count";
            this.lbl_count.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lbl_count.Size = new System.Drawing.Size(0, 25);
            this.lbl_count.TabIndex = 77;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label1.Font = new System.Drawing.Font("LBC", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(799, 79);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 25);
            this.label1.TabIndex = 78;
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
            this.txt_std_data.Location = new System.Drawing.Point(396, 65);
            this.txt_std_data.Margin = new System.Windows.Forms.Padding(4);
            this.txt_std_data.Name = "txt_std_data";
            this.txt_std_data.Padding = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.txt_std_data.Size = new System.Drawing.Size(400, 44);
            this.txt_std_data.TabIndex = 74;
            this.txt_std_data.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txt_std_data.Enter += new System.EventHandler(this.txt_std_data_Enter);
            this.txt_std_data.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_std_data_KeyPress);
            this.txt_std_data.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txt_std_data_KeyUp);
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
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("LBC", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dt_std_data.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dt_std_data.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dt_std_data.Location = new System.Drawing.Point(12, 131);
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
            this.dt_std_data.TabIndex = 82;
            this.dt_std_data.DoubleClick += new System.EventHandler(this.dt_std_data_DoubleClick);
            // 
            // cmb_class
            // 
            this.cmb_class.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_class.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cmb_class.Font = new System.Drawing.Font("Noto Naskh Arabic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmb_class.ForeColor = System.Drawing.Color.DimGray;
            this.cmb_class.FormattingEnabled = true;
            this.cmb_class.Location = new System.Drawing.Point(15, 69);
            this.cmb_class.Name = "cmb_class";
            this.cmb_class.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.cmb_class.Size = new System.Drawing.Size(77, 40);
            this.cmb_class.TabIndex = 84;
            this.cmb_class.SelectedIndexChanged += new System.EventHandler(this.cmb_class_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label4.Font = new System.Drawing.Font("LBC", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(89, 79);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(59, 25);
            this.label4.TabIndex = 83;
            this.label4.Text = "الفصل";
            // 
            // pic_help
            // 
            this.pic_help.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pic_help.Image = global::School_Mang.Properties.Resources.help_80;
            this.pic_help.Location = new System.Drawing.Point(357, 72);
            this.pic_help.Name = "pic_help";
            this.pic_help.Size = new System.Drawing.Size(38, 32);
            this.pic_help.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pic_help.TabIndex = 79;
            this.pic_help.TabStop = false;
            this.pic_help.MouseLeave += new System.EventHandler(this.pic_help_MouseLeave);
            this.pic_help.MouseHover += new System.EventHandler(this.pic_help_MouseHover);
            // 
            // FRM_CURRENT_STD
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(1027, 618);
            this.Controls.Add(this.cmb_class);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.dt_std_data);
            this.Controls.Add(this.cmb_grade);
            this.Controls.Add(this.lbl_help);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lbl_count);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txt_std_data);
            this.Controls.Add(this.pic_help);
            this.Controls.Add(this.pn_top);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.panel4);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FRM_CURRENT_STD";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "بيانات العام الحالى";
            this.Load += new System.EventHandler(this.FRM_CURRENT_STD_Load);
            this.pn_top.ResumeLayout(false);
            this.pn_top.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dt_std_data)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_help)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pn_top;
        private System.Windows.Forms.Label lbl_current_year;
        private DevExpress.XtraEditors.SimpleButton btn_close;
        private System.Windows.Forms.GroupBox groupBox3;
        private Bunifu.Framework.UI.BunifuThinButton2 btn_close_b;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label lbl_help;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lbl_count;
        private System.Windows.Forms.Label label1;
        private Bunifu.Framework.UI.BunifuMaterialTextbox txt_std_data;
        private System.Windows.Forms.PictureBox pic_help;
        private System.Windows.Forms.ComboBox cmb_class;
        private System.Windows.Forms.Label label4;
        public System.Windows.Forms.ComboBox cmb_grade;
        public System.Windows.Forms.DataGridView dt_std_data;
        public Bunifu.Framework.UI.BunifuThinButton2 btn_tahwel;
        public Bunifu.Framework.UI.BunifuThinButton2 btn_del_std;
        public Bunifu.Framework.UI.BunifuThinButton2 btn_new_std;
        private Bunifu.Framework.UI.BunifuThinButton2 btn_talab_elthak;
    }
}