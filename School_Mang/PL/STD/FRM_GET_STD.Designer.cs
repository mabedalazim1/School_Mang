
namespace School_Mang.PL.STD
{
    partial class FRM_GET_STD
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FRM_GET_STD));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle15 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle16 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btn_close = new DevExpress.XtraEditors.SimpleButton();
            this.pn_top = new System.Windows.Forms.Panel();
            this.label11 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txt_std_data = new Bunifu.Framework.UI.BunifuMaterialTextbox();
            this.lbl_help = new System.Windows.Forms.Label();
            this.btn_del_std = new Bunifu.Framework.UI.BunifuThinButton2();
            this.pic_help = new System.Windows.Forms.PictureBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btn_talab_elthak = new Bunifu.Framework.UI.BunifuThinButton2();
            this.btn_edit_std = new Bunifu.Framework.UI.BunifuThinButton2();
            this.btn_new_std = new Bunifu.Framework.UI.BunifuThinButton2();
            this.btn_close_b = new Bunifu.Framework.UI.BunifuThinButton2();
            this.dt_std_data = new System.Windows.Forms.DataGridView();
            this.panel4 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.cmb_sana = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.lbl_count = new System.Windows.Forms.Label();
            this.pic_sort = new System.Windows.Forms.PictureBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.pn_top.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pic_help)).BeginInit();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dt_std_data)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_sort)).BeginInit();
            this.SuspendLayout();
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
            // pn_top
            // 
            this.pn_top.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.pn_top.Controls.Add(this.btn_close);
            this.pn_top.Controls.Add(this.label11);
            this.pn_top.Dock = System.Windows.Forms.DockStyle.Top;
            this.pn_top.Location = new System.Drawing.Point(0, 0);
            this.pn_top.Name = "pn_top";
            this.pn_top.Size = new System.Drawing.Size(1027, 50);
            this.pn_top.TabIndex = 3;
            this.pn_top.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pn_top_MouseDown);
            this.pn_top.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pn_top_MouseMove);
            this.pn_top.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pn_top_MouseUp);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("LBC", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.White;
            this.label11.Location = new System.Drawing.Point(436, 13);
            this.label11.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(155, 25);
            this.label11.TabIndex = 46;
            this.label11.Text = "بيانات الطلاب الجدد";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label1.Font = new System.Drawing.Font("LBC", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(821, 81);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 25);
            this.label1.TabIndex = 69;
            this.label1.Text = "بحث";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            this.label1.MouseLeave += new System.EventHandler(this.label1_MouseLeave);
            this.label1.MouseHover += new System.EventHandler(this.label1_MouseHover);
            // 
            // txt_std_data
            // 
            this.txt_std_data.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            this.txt_std_data.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            this.txt_std_data.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_std_data.characterCasing = System.Windows.Forms.CharacterCasing.Normal;
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
            this.txt_std_data.Location = new System.Drawing.Point(355, 67);
            this.txt_std_data.Margin = new System.Windows.Forms.Padding(4);
            this.txt_std_data.MaxLength = 32767;
            this.txt_std_data.Name = "txt_std_data";
            this.txt_std_data.Padding = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.txt_std_data.Size = new System.Drawing.Size(464, 44);
            this.txt_std_data.TabIndex = 68;
            this.txt_std_data.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txt_std_data.OnValueChanged += new System.EventHandler(this.txt_std_data_OnValueChanged);
            this.txt_std_data.Enter += new System.EventHandler(this.txt_std_data_Enter);
            this.txt_std_data.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_std_data_KeyPress);
            this.txt_std_data.Leave += new System.EventHandler(this.txt_std_data_Leave);
            // 
            // lbl_help
            // 
            this.lbl_help.AutoSize = true;
            this.lbl_help.Font = new System.Drawing.Font("Noto Naskh Arabic", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_help.Location = new System.Drawing.Point(513, 52);
            this.lbl_help.Name = "lbl_help";
            this.lbl_help.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lbl_help.Size = new System.Drawing.Size(29, 29);
            this.lbl_help.TabIndex = 72;
            this.lbl_help.Text = "    ";
            this.lbl_help.Visible = false;
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
            this.btn_del_std.Location = new System.Drawing.Point(215, 15);
            this.btn_del_std.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btn_del_std.Name = "btn_del_std";
            this.btn_del_std.Size = new System.Drawing.Size(138, 50);
            this.btn_del_std.TabIndex = 18;
            this.btn_del_std.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btn_del_std.Click += new System.EventHandler(this.btn_del_std_Click);
            // 
            // pic_help
            // 
            this.pic_help.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pic_help.Image = global::School_Mang.Properties.Resources.help_80;
            this.pic_help.Location = new System.Drawing.Point(311, 74);
            this.pic_help.Name = "pic_help";
            this.pic_help.Size = new System.Drawing.Size(38, 32);
            this.pic_help.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pic_help.TabIndex = 71;
            this.pic_help.TabStop = false;
            this.pic_help.MouseLeave += new System.EventHandler(this.pic_help_MouseLeave);
            this.pic_help.MouseHover += new System.EventHandler(this.pic_help_MouseHover);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btn_talab_elthak);
            this.groupBox3.Controls.Add(this.btn_edit_std);
            this.groupBox3.Controls.Add(this.btn_del_std);
            this.groupBox3.Controls.Add(this.btn_new_std);
            this.groupBox3.Controls.Add(this.btn_close_b);
            this.groupBox3.Location = new System.Drawing.Point(12, 516);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(1003, 73);
            this.groupBox3.TabIndex = 70;
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
            this.btn_talab_elthak.ButtonText = "طلب التحاق";
            this.btn_talab_elthak.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_talab_elthak.Font = new System.Drawing.Font("LBC", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_talab_elthak.ForeColor = System.Drawing.Color.DarkCyan;
            this.btn_talab_elthak.IdleBorderThickness = 1;
            this.btn_talab_elthak.IdleCornerRadius = 20;
            this.btn_talab_elthak.IdleFillColor = System.Drawing.Color.WhiteSmoke;
            this.btn_talab_elthak.IdleForecolor = System.Drawing.Color.DarkCyan;
            this.btn_talab_elthak.IdleLineColor = System.Drawing.Color.CadetBlue;
            this.btn_talab_elthak.Location = new System.Drawing.Point(423, 15);
            this.btn_talab_elthak.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btn_talab_elthak.Name = "btn_talab_elthak";
            this.btn_talab_elthak.Size = new System.Drawing.Size(138, 50);
            this.btn_talab_elthak.TabIndex = 75;
            this.btn_talab_elthak.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btn_talab_elthak.Click += new System.EventHandler(this.btn_talab_elthak_Click);
            // 
            // btn_edit_std
            // 
            this.btn_edit_std.ActiveBorderThickness = 1;
            this.btn_edit_std.ActiveCornerRadius = 20;
            this.btn_edit_std.ActiveFillColor = System.Drawing.Color.CadetBlue;
            this.btn_edit_std.ActiveForecolor = System.Drawing.Color.White;
            this.btn_edit_std.ActiveLineColor = System.Drawing.Color.CadetBlue;
            this.btn_edit_std.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btn_edit_std.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_edit_std.BackgroundImage")));
            this.btn_edit_std.ButtonText = "تعديل البيانات";
            this.btn_edit_std.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_edit_std.Font = new System.Drawing.Font("LBC", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_edit_std.ForeColor = System.Drawing.Color.RoyalBlue;
            this.btn_edit_std.IdleBorderThickness = 1;
            this.btn_edit_std.IdleCornerRadius = 20;
            this.btn_edit_std.IdleFillColor = System.Drawing.Color.WhiteSmoke;
            this.btn_edit_std.IdleForecolor = System.Drawing.Color.DodgerBlue;
            this.btn_edit_std.IdleLineColor = System.Drawing.Color.SteelBlue;
            this.btn_edit_std.Location = new System.Drawing.Point(631, 15);
            this.btn_edit_std.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btn_edit_std.Name = "btn_edit_std";
            this.btn_edit_std.Size = new System.Drawing.Size(138, 50);
            this.btn_edit_std.TabIndex = 74;
            this.btn_edit_std.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btn_edit_std.Click += new System.EventHandler(this.btn_edit_std_Click);
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
            this.btn_new_std.ButtonText = "إضافة  جديد";
            this.btn_new_std.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_new_std.Font = new System.Drawing.Font("LBC", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_new_std.ForeColor = System.Drawing.Color.SeaGreen;
            this.btn_new_std.IdleBorderThickness = 1;
            this.btn_new_std.IdleCornerRadius = 20;
            this.btn_new_std.IdleFillColor = System.Drawing.Color.WhiteSmoke;
            this.btn_new_std.IdleForecolor = System.Drawing.Color.SeaGreen;
            this.btn_new_std.IdleLineColor = System.Drawing.Color.SeaGreen;
            this.btn_new_std.Location = new System.Drawing.Point(839, 15);
            this.btn_new_std.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btn_new_std.Name = "btn_new_std";
            this.btn_new_std.Size = new System.Drawing.Size(138, 50);
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
            this.btn_close_b.Size = new System.Drawing.Size(138, 50);
            this.btn_close_b.TabIndex = 19;
            this.btn_close_b.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btn_close_b.Click += new System.EventHandler(this.btn_close_b_Click);
            // 
            // dt_std_data
            // 
            this.dt_std_data.AllowUserToAddRows = false;
            this.dt_std_data.AllowUserToDeleteRows = false;
            dataGridViewCellStyle13.Font = new System.Drawing.Font("Noto Naskh Arabic", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dt_std_data.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle13;
            this.dt_std_data.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dt_std_data.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle14.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle14.Font = new System.Drawing.Font("LBC", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle14.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle14.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle14.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle14.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dt_std_data.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle14;
            this.dt_std_data.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dt_std_data.Location = new System.Drawing.Point(12, 118);
            this.dt_std_data.Name = "dt_std_data";
            this.dt_std_data.ReadOnly = true;
            this.dt_std_data.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            dataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle15.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle15.Font = new System.Drawing.Font("Noto Naskh Arabic", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle15.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle15.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle15.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle15.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dt_std_data.RowHeadersDefaultCellStyle = dataGridViewCellStyle15;
            dataGridViewCellStyle16.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle16.Font = new System.Drawing.Font("Noto Naskh Arabic", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dt_std_data.RowsDefaultCellStyle = dataGridViewCellStyle16;
            this.dt_std_data.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Noto Naskh Arabic", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dt_std_data.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dt_std_data.Size = new System.Drawing.Size(1003, 395);
            this.dt_std_data.TabIndex = 67;
            this.dt_std_data.Click += new System.EventHandler(this.dt_std_data_Click);
            this.dt_std_data.DoubleClick += new System.EventHandler(this.dt_std_data_DoubleClick);
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.panel4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel4.Location = new System.Drawing.Point(0, 608);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(1027, 10);
            this.panel4.TabIndex = 66;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label2.Font = new System.Drawing.Font("LBC", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(157, 81);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(114, 25);
            this.label2.TabIndex = 69;
            this.label2.Text = "العام الدراسى";
            this.label2.Click += new System.EventHandler(this.label1_Click);
            this.label2.MouseLeave += new System.EventHandler(this.label1_MouseLeave);
            this.label2.MouseHover += new System.EventHandler(this.label1_MouseHover);
            // 
            // cmb_sana
            // 
            this.cmb_sana.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_sana.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cmb_sana.Font = new System.Drawing.Font("Noto Naskh Arabic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmb_sana.ForeColor = System.Drawing.Color.DimGray;
            this.cmb_sana.FormattingEnabled = true;
            this.cmb_sana.Items.AddRange(new object[] {
            "الكل",
            "2022-2021",
            "2023-2022",
            "2024-2023",
            "2025-2024",
            "2026-2025",
            "2027-2026",
            "2028-2027",
            "2029-2028",
            "2030-2029",
            "2031-2030",
            "2032-2031"});
            this.cmb_sana.Location = new System.Drawing.Point(16, 71);
            this.cmb_sana.Name = "cmb_sana";
            this.cmb_sana.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.cmb_sana.Size = new System.Drawing.Size(135, 40);
            this.cmb_sana.TabIndex = 73;
            this.cmb_sana.SelectedIndexChanged += new System.EventHandler(this.cmb_sana_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label3.Font = new System.Drawing.Font("LBC", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(921, 81);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 25);
            this.label3.TabIndex = 69;
            this.label3.Text = "عدد الطلاب";
            // 
            // lbl_count
            // 
            this.lbl_count.AutoSize = true;
            this.lbl_count.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lbl_count.Font = new System.Drawing.Font("LBC", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_count.ForeColor = System.Drawing.Color.Black;
            this.lbl_count.Location = new System.Drawing.Point(887, 81);
            this.lbl_count.Name = "lbl_count";
            this.lbl_count.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lbl_count.Size = new System.Drawing.Size(0, 25);
            this.lbl_count.TabIndex = 69;
            // 
            // pic_sort
            // 
            this.pic_sort.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pic_sort.Image = global::School_Mang.Properties.Resources.transfer_to_100;
            this.pic_sort.Location = new System.Drawing.Point(273, 74);
            this.pic_sort.Name = "pic_sort";
            this.pic_sort.Size = new System.Drawing.Size(32, 32);
            this.pic_sort.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pic_sort.TabIndex = 86;
            this.pic_sort.TabStop = false;
            this.pic_sort.Click += new System.EventHandler(this.pic_sort_Click);
            // 
            // FRM_GET_STD
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(1027, 618);
            this.Controls.Add(this.pic_sort);
            this.Controls.Add(this.cmb_sana);
            this.Controls.Add(this.lbl_help);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lbl_count);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txt_std_data);
            this.Controls.Add(this.pic_help);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.dt_std_data);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.pn_top);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FRM_GET_STD";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "بيانات الطلاب الجدد";
            this.Load += new System.EventHandler(this.FRM_GET_STD_Load);
            this.pn_top.ResumeLayout(false);
            this.pn_top.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pic_help)).EndInit();
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dt_std_data)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_sort)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton btn_close;
        private System.Windows.Forms.Panel pn_top;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbl_help;
        private Bunifu.Framework.UI.BunifuThinButton2 btn_del_std;
        private System.Windows.Forms.PictureBox pic_help;
        private System.Windows.Forms.GroupBox groupBox3;
        private Bunifu.Framework.UI.BunifuThinButton2 btn_new_std;
        private Bunifu.Framework.UI.BunifuThinButton2 btn_close_b;
        private System.Windows.Forms.DataGridView dt_std_data;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmb_sana;
        private Bunifu.Framework.UI.BunifuThinButton2 btn_edit_std;
        private Bunifu.Framework.UI.BunifuThinButton2 btn_talab_elthak;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lbl_count;
        public Bunifu.Framework.UI.BunifuMaterialTextbox txt_std_data;
        private System.Windows.Forms.PictureBox pic_sort;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}