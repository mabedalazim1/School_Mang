
namespace School_Mang.PL.STD
{
    partial class FRM_TAHEEL_STD
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FRM_TAHEEL_STD));
            this.panel4 = new System.Windows.Forms.Panel();
            this.pn_top = new System.Windows.Forms.Panel();
            this.lbl_title = new System.Windows.Forms.Label();
            this.txt_std_code = new System.Windows.Forms.TextBox();
            this.btn_close = new DevExpress.XtraEditors.SimpleButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.chk_kotob_no = new System.Windows.Forms.CheckBox();
            this.chk_kotob_yes = new System.Windows.Forms.CheckBox();
            this.chk_resom_no = new System.Windows.Forms.CheckBox();
            this.chk_resom_yes = new System.Windows.Forms.CheckBox();
            this.label17 = new System.Windows.Forms.Label();
            this.txt_transfer_reason = new System.Windows.Forms.TextBox();
            this.txt_adrs = new System.Windows.Forms.TextBox();
            this.txt_guardian_name = new System.Windows.Forms.TextBox();
            this.txt_to_school = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txt_std_name = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lbl_mohwel = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btn_edit_std = new Bunifu.Framework.UI.BunifuThinButton2();
            this.btn_new_std = new Bunifu.Framework.UI.BunifuThinButton2();
            this.btn_close_b = new Bunifu.Framework.UI.BunifuThinButton2();
            this.txt_trans_code = new System.Windows.Forms.TextBox();
            this.pn_top.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.panel4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel4.Location = new System.Drawing.Point(0, 465);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(536, 10);
            this.panel4.TabIndex = 70;
            // 
            // pn_top
            // 
            this.pn_top.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.pn_top.Controls.Add(this.lbl_title);
            this.pn_top.Controls.Add(this.txt_trans_code);
            this.pn_top.Controls.Add(this.txt_std_code);
            this.pn_top.Controls.Add(this.btn_close);
            this.pn_top.Dock = System.Windows.Forms.DockStyle.Top;
            this.pn_top.Location = new System.Drawing.Point(0, 0);
            this.pn_top.Name = "pn_top";
            this.pn_top.Size = new System.Drawing.Size(536, 50);
            this.pn_top.TabIndex = 69;
            this.pn_top.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pn_top_MouseDown);
            this.pn_top.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pn_top_MouseMove);
            this.pn_top.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pn_top_MouseUp);
            // 
            // lbl_title
            // 
            this.lbl_title.AutoSize = true;
            this.lbl_title.Font = new System.Drawing.Font("LBC", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_title.ForeColor = System.Drawing.Color.White;
            this.lbl_title.Location = new System.Drawing.Point(200, 13);
            this.lbl_title.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.lbl_title.Name = "lbl_title";
            this.lbl_title.Size = new System.Drawing.Size(144, 25);
            this.lbl_title.TabIndex = 46;
            this.lbl_title.Text = "طلب تحويل طالب";
            // 
            // txt_std_code
            // 
            this.txt_std_code.Enabled = false;
            this.txt_std_code.Font = new System.Drawing.Font("Noto Naskh Arabic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_std_code.Location = new System.Drawing.Point(136, 25);
            this.txt_std_code.MaxLength = 11;
            this.txt_std_code.Name = "txt_std_code";
            this.txt_std_code.Size = new System.Drawing.Size(15, 40);
            this.txt_std_code.TabIndex = 78;
            this.txt_std_code.Visible = false;
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
            this.btn_close.TabIndex = 12;
            this.btn_close.TabStop = false;
            this.btn_close.Click += new System.EventHandler(this.btn_close_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.groupBox1.Controls.Add(this.chk_kotob_no);
            this.groupBox1.Controls.Add(this.chk_kotob_yes);
            this.groupBox1.Controls.Add(this.chk_resom_no);
            this.groupBox1.Controls.Add(this.chk_resom_yes);
            this.groupBox1.Controls.Add(this.label17);
            this.groupBox1.Controls.Add(this.txt_transfer_reason);
            this.groupBox1.Controls.Add(this.txt_adrs);
            this.groupBox1.Controls.Add(this.txt_guardian_name);
            this.groupBox1.Controls.Add(this.txt_to_school);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txt_std_name);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.lbl_mohwel);
            this.groupBox1.Font = new System.Drawing.Font("LBC", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.Color.DarkGray;
            this.groupBox1.Location = new System.Drawing.Point(4, 54);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.groupBox1.Size = new System.Drawing.Size(522, 335);
            this.groupBox1.TabIndex = 81;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "بيانات التحويل";
            // 
            // chk_kotob_no
            // 
            this.chk_kotob_no.AutoSize = true;
            this.chk_kotob_no.Font = new System.Drawing.Font("Noto Naskh Arabic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chk_kotob_no.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.chk_kotob_no.Location = new System.Drawing.Point(77, 275);
            this.chk_kotob_no.Name = "chk_kotob_no";
            this.chk_kotob_no.Size = new System.Drawing.Size(80, 31);
            this.chk_kotob_no.TabIndex = 7;
            this.chk_kotob_no.Text = "لم يستلم";
            this.chk_kotob_no.UseVisualStyleBackColor = true;
            this.chk_kotob_no.CheckedChanged += new System.EventHandler(this.chk_kotob_no_CheckedChanged);
            // 
            // chk_kotob_yes
            // 
            this.chk_kotob_yes.AutoSize = true;
            this.chk_kotob_yes.Font = new System.Drawing.Font("Noto Naskh Arabic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chk_kotob_yes.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.chk_kotob_yes.Location = new System.Drawing.Point(93, 302);
            this.chk_kotob_yes.Name = "chk_kotob_yes";
            this.chk_kotob_yes.Size = new System.Drawing.Size(64, 31);
            this.chk_kotob_yes.TabIndex = 8;
            this.chk_kotob_yes.Text = "استلم";
            this.chk_kotob_yes.UseVisualStyleBackColor = true;
            this.chk_kotob_yes.CheckedChanged += new System.EventHandler(this.chk_kotob_yes_CheckedChanged);
            // 
            // chk_resom_no
            // 
            this.chk_resom_no.AutoSize = true;
            this.chk_resom_no.Font = new System.Drawing.Font("Noto Naskh Arabic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chk_resom_no.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.chk_resom_no.Location = new System.Drawing.Point(333, 275);
            this.chk_resom_no.Name = "chk_resom_no";
            this.chk_resom_no.Size = new System.Drawing.Size(77, 31);
            this.chk_resom_no.TabIndex = 5;
            this.chk_resom_no.Text = "لم يسدد";
            this.chk_resom_no.UseVisualStyleBackColor = true;
            this.chk_resom_no.CheckedChanged += new System.EventHandler(this.chk_resom_no_CheckedChanged);
            // 
            // chk_resom_yes
            // 
            this.chk_resom_yes.AutoSize = true;
            this.chk_resom_yes.Font = new System.Drawing.Font("Noto Naskh Arabic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chk_resom_yes.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.chk_resom_yes.Location = new System.Drawing.Point(353, 302);
            this.chk_resom_yes.Name = "chk_resom_yes";
            this.chk_resom_yes.Size = new System.Drawing.Size(57, 31);
            this.chk_resom_yes.TabIndex = 6;
            this.chk_resom_yes.Text = "سدد";
            this.chk_resom_yes.UseVisualStyleBackColor = true;
            this.chk_resom_yes.CheckedChanged += new System.EventHandler(this.chk_resom_yes_CheckedChanged);
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Noto Naskh Arabic", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.label17.Location = new System.Drawing.Point(416, 51);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(82, 29);
            this.label17.TabIndex = 79;
            this.label17.Text = "اسم الطالب";
            // 
            // txt_transfer_reason
            // 
            this.txt_transfer_reason.Font = new System.Drawing.Font("Noto Naskh Arabic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_transfer_reason.Location = new System.Drawing.Point(7, 232);
            this.txt_transfer_reason.MaxLength = 150;
            this.txt_transfer_reason.Name = "txt_transfer_reason";
            this.txt_transfer_reason.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txt_transfer_reason.Size = new System.Drawing.Size(407, 40);
            this.txt_transfer_reason.TabIndex = 4;
            this.txt_transfer_reason.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_transfer_reason_KeyPress);
            // 
            // txt_adrs
            // 
            this.txt_adrs.Font = new System.Drawing.Font("Noto Naskh Arabic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_adrs.Location = new System.Drawing.Point(7, 183);
            this.txt_adrs.MaxLength = 150;
            this.txt_adrs.Name = "txt_adrs";
            this.txt_adrs.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txt_adrs.Size = new System.Drawing.Size(407, 40);
            this.txt_adrs.TabIndex = 3;
            this.txt_adrs.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_adrs_KeyPress);
            // 
            // txt_guardian_name
            // 
            this.txt_guardian_name.Font = new System.Drawing.Font("Noto Naskh Arabic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_guardian_name.Location = new System.Drawing.Point(7, 137);
            this.txt_guardian_name.MaxLength = 150;
            this.txt_guardian_name.Name = "txt_guardian_name";
            this.txt_guardian_name.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txt_guardian_name.Size = new System.Drawing.Size(407, 40);
            this.txt_guardian_name.TabIndex = 2;
            this.txt_guardian_name.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_guardian_name_KeyPress);
            // 
            // txt_to_school
            // 
            this.txt_to_school.Font = new System.Drawing.Font("Noto Naskh Arabic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_to_school.Location = new System.Drawing.Point(7, 90);
            this.txt_to_school.MaxLength = 150;
            this.txt_to_school.Name = "txt_to_school";
            this.txt_to_school.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txt_to_school.Size = new System.Drawing.Size(407, 40);
            this.txt_to_school.TabIndex = 1;
            this.txt_to_school.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_to_school_KeyPress);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Noto Naskh Arabic", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.label5.Location = new System.Drawing.Point(166, 288);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(92, 29);
            this.label5.TabIndex = 73;
            this.label5.Text = "استلام الكتب";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Noto Naskh Arabic", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.label4.Location = new System.Drawing.Point(416, 288);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(89, 29);
            this.label4.TabIndex = 73;
            this.label4.Text = "سداد الرسوم";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Noto Naskh Arabic", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.label3.Location = new System.Drawing.Point(417, 238);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(96, 29);
            this.label3.TabIndex = 73;
            this.label3.Text = "سبب التحويل";
            // 
            // txt_std_name
            // 
            this.txt_std_name.Enabled = false;
            this.txt_std_name.Font = new System.Drawing.Font("Noto Naskh Arabic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_std_name.Location = new System.Drawing.Point(7, 44);
            this.txt_std_name.MaxLength = 50;
            this.txt_std_name.Name = "txt_std_name";
            this.txt_std_name.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txt_std_name.Size = new System.Drawing.Size(407, 40);
            this.txt_std_name.TabIndex = 78;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Noto Naskh Arabic", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.label2.Location = new System.Drawing.Point(419, 189);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 29);
            this.label2.TabIndex = 73;
            this.label2.Text = "العنوان";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Noto Naskh Arabic", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.label1.Location = new System.Drawing.Point(418, 143);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 29);
            this.label1.TabIndex = 73;
            this.label1.Text = "ولى الأمر";
            // 
            // lbl_mohwel
            // 
            this.lbl_mohwel.AutoSize = true;
            this.lbl_mohwel.Font = new System.Drawing.Font("Noto Naskh Arabic", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_mohwel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.lbl_mohwel.Location = new System.Drawing.Point(417, 97);
            this.lbl_mohwel.Name = "lbl_mohwel";
            this.lbl_mohwel.Size = new System.Drawing.Size(74, 29);
            this.lbl_mohwel.TabIndex = 73;
            this.lbl_mohwel.Text = "محول إلى";
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.btn_edit_std);
            this.groupBox3.Controls.Add(this.btn_new_std);
            this.groupBox3.Controls.Add(this.btn_close_b);
            this.groupBox3.Location = new System.Drawing.Point(4, 390);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(522, 69);
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
            this.btn_edit_std.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btn_edit_std.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_edit_std.BackgroundImage")));
            this.btn_edit_std.ButtonText = "طباعة الطلب";
            this.btn_edit_std.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_edit_std.Font = new System.Drawing.Font("LBC", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_edit_std.ForeColor = System.Drawing.Color.RoyalBlue;
            this.btn_edit_std.IdleBorderThickness = 1;
            this.btn_edit_std.IdleCornerRadius = 20;
            this.btn_edit_std.IdleFillColor = System.Drawing.Color.WhiteSmoke;
            this.btn_edit_std.IdleForecolor = System.Drawing.Color.DodgerBlue;
            this.btn_edit_std.IdleLineColor = System.Drawing.Color.SteelBlue;
            this.btn_edit_std.Location = new System.Drawing.Point(191, 11);
            this.btn_edit_std.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btn_edit_std.Name = "btn_edit_std";
            this.btn_edit_std.Size = new System.Drawing.Size(138, 50);
            this.btn_edit_std.TabIndex = 10;
            this.btn_edit_std.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
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
            this.btn_new_std.ButtonText = "حفظ";
            this.btn_new_std.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_new_std.Font = new System.Drawing.Font("LBC", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_new_std.ForeColor = System.Drawing.Color.SeaGreen;
            this.btn_new_std.IdleBorderThickness = 1;
            this.btn_new_std.IdleCornerRadius = 20;
            this.btn_new_std.IdleFillColor = System.Drawing.Color.WhiteSmoke;
            this.btn_new_std.IdleForecolor = System.Drawing.Color.SeaGreen;
            this.btn_new_std.IdleLineColor = System.Drawing.Color.SeaGreen;
            this.btn_new_std.Location = new System.Drawing.Point(372, 11);
            this.btn_new_std.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btn_new_std.Name = "btn_new_std";
            this.btn_new_std.Size = new System.Drawing.Size(138, 50);
            this.btn_new_std.TabIndex = 9;
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
            this.btn_close_b.Location = new System.Drawing.Point(9, 11);
            this.btn_close_b.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btn_close_b.Name = "btn_close_b";
            this.btn_close_b.Size = new System.Drawing.Size(138, 50);
            this.btn_close_b.TabIndex = 11;
            this.btn_close_b.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btn_close_b.Click += new System.EventHandler(this.btn_close_b_Click);
            // 
            // txt_trans_code
            // 
            this.txt_trans_code.Enabled = false;
            this.txt_trans_code.Font = new System.Drawing.Font("Noto Naskh Arabic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_trans_code.Location = new System.Drawing.Point(97, 25);
            this.txt_trans_code.MaxLength = 11;
            this.txt_trans_code.Name = "txt_trans_code";
            this.txt_trans_code.Size = new System.Drawing.Size(15, 40);
            this.txt_trans_code.TabIndex = 78;
            this.txt_trans_code.Visible = false;
            // 
            // FRM_TAHEEL_STD
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(536, 475);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.pn_top);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FRM_TAHEEL_STD";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FRM_TAHEEL_STD";
            this.Load += new System.EventHandler(this.FRM_TAHEEL_STD_Load);
            this.pn_top.ResumeLayout(false);
            this.pn_top.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel pn_top;
        private DevExpress.XtraEditors.SimpleButton btn_close;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label17;
        public System.Windows.Forms.TextBox txt_std_code;
        public System.Windows.Forms.TextBox txt_std_name;
        private System.Windows.Forms.GroupBox groupBox3;
        private Bunifu.Framework.UI.BunifuThinButton2 btn_edit_std;
        private Bunifu.Framework.UI.BunifuThinButton2 btn_new_std;
        private Bunifu.Framework.UI.BunifuThinButton2 btn_close_b;
        public System.Windows.Forms.TextBox txt_transfer_reason;
        public System.Windows.Forms.TextBox txt_adrs;
        public System.Windows.Forms.TextBox txt_guardian_name;
        public System.Windows.Forms.TextBox txt_to_school;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.CheckBox chk_kotob_no;
        public System.Windows.Forms.CheckBox chk_resom_no;
        public System.Windows.Forms.Label lbl_mohwel;
        public System.Windows.Forms.Label lbl_title;
        public System.Windows.Forms.CheckBox chk_kotob_yes;
        public System.Windows.Forms.CheckBox chk_resom_yes;
        public System.Windows.Forms.TextBox txt_trans_code;
    }
}