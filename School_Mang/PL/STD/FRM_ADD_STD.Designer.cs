
namespace School_Mang.PL.STD
{
    partial class FRM_ADD_STD
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FRM_ADD_STD));
            this.pn_top = new System.Windows.Forms.Panel();
            this.label11 = new System.Windows.Forms.Label();
            this.btn_close = new DevExpress.XtraEditors.SimpleButton();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btn_ok = new Bunifu.Framework.UI.BunifuThinButton2();
            this.btn_close_b = new Bunifu.Framework.UI.BunifuThinButton2();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.link_edit_osra = new System.Windows.Forms.LinkLabel();
            this.link_get_osra_data = new System.Windows.Forms.LinkLabel();
            this.link_new_osra_data = new System.Windows.Forms.LinkLabel();
            this.pn_osraa = new System.Windows.Forms.Panel();
            this.label9 = new System.Windows.Forms.Label();
            this.txt_mother_name = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txt_mother_tel = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txt_father_tel = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txt_osra_id = new System.Windows.Forms.TextBox();
            this.txt_wazifa = new System.Windows.Forms.TextBox();
            this.txt_adrs = new System.Windows.Forms.TextBox();
            this.txt_father_name = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.cmb_national = new System.Windows.Forms.ComboBox();
            this.cmb_religion = new System.Windows.Forms.ComboBox();
            this.cmb_hala = new System.Windows.Forms.ComboBox();
            this.cmb_grade = new System.Windows.Forms.ComboBox();
            this.txt_std_code = new System.Windows.Forms.TextBox();
            this.cmb_type = new System.Windows.Forms.ComboBox();
            this.label18 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.txt_std_name = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txt_nat = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txt_sen = new System.Windows.Forms.TextBox();
            this.cmb_sana = new System.Windows.Forms.ComboBox();
            this.txt_tarikh = new System.Windows.Forms.TextBox();
            this.pn_top.SuspendLayout();
            this.panel3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.pn_osraa.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pn_top
            // 
            this.pn_top.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.pn_top.Controls.Add(this.btn_close);
            this.pn_top.Controls.Add(this.label11);
            this.pn_top.Dock = System.Windows.Forms.DockStyle.Top;
            this.pn_top.ForeColor = System.Drawing.Color.White;
            this.pn_top.Location = new System.Drawing.Point(0, 0);
            this.pn_top.Name = "pn_top";
            this.pn_top.Size = new System.Drawing.Size(598, 43);
            this.pn_top.TabIndex = 0;
            this.pn_top.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pn_top_MouseDown);
            this.pn_top.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pn_top_MouseMove);
            this.pn_top.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pn_top_MouseUp);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("LBC", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.White;
            this.label11.Location = new System.Drawing.Point(247, 9);
            this.label11.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(104, 25);
            this.label11.TabIndex = 45;
            this.label11.Text = "إضافة طالب";
            // 
            // btn_close
            // 
            this.btn_close.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btn_close.ImageOptions.Image = global::School_Mang.Properties.Resources.close_w;
            this.btn_close.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.btn_close.Location = new System.Drawing.Point(7, 4);
            this.btn_close.Name = "btn_close";
            this.btn_close.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light;
            this.btn_close.Size = new System.Drawing.Size(34, 33);
            this.btn_close.TabIndex = 10;
            this.btn_close.TabStop = false;
            this.btn_close.Click += new System.EventHandler(this.btn_close_Click);
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.panel4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel4.Location = new System.Drawing.Point(0, 601);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(598, 10);
            this.panel4.TabIndex = 57;
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.btn_ok);
            this.panel3.Controls.Add(this.btn_close_b);
            this.panel3.Location = new System.Drawing.Point(23, 541);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(559, 58);
            this.panel3.TabIndex = 58;
            // 
            // btn_ok
            // 
            this.btn_ok.ActiveBorderThickness = 1;
            this.btn_ok.ActiveCornerRadius = 20;
            this.btn_ok.ActiveFillColor = System.Drawing.Color.SeaGreen;
            this.btn_ok.ActiveForecolor = System.Drawing.Color.White;
            this.btn_ok.ActiveLineColor = System.Drawing.Color.SeaGreen;
            this.btn_ok.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btn_ok.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_ok.BackgroundImage")));
            this.btn_ok.ButtonText = "حفظ";
            this.btn_ok.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_ok.Font = new System.Drawing.Font("LBC", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_ok.ForeColor = System.Drawing.Color.SeaGreen;
            this.btn_ok.IdleBorderThickness = 1;
            this.btn_ok.IdleCornerRadius = 20;
            this.btn_ok.IdleFillColor = System.Drawing.Color.WhiteSmoke;
            this.btn_ok.IdleForecolor = System.Drawing.Color.SeaGreen;
            this.btn_ok.IdleLineColor = System.Drawing.Color.SeaGreen;
            this.btn_ok.Location = new System.Drawing.Point(397, 4);
            this.btn_ok.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btn_ok.Name = "btn_ok";
            this.btn_ok.Size = new System.Drawing.Size(139, 50);
            this.btn_ok.TabIndex = 11;
            this.btn_ok.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btn_ok.Click += new System.EventHandler(this.btn_ok_Click);
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
            this.btn_close_b.Location = new System.Drawing.Point(26, 2);
            this.btn_close_b.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btn_close_b.Name = "btn_close_b";
            this.btn_close_b.Size = new System.Drawing.Size(139, 50);
            this.btn_close_b.TabIndex = 12;
            this.btn_close_b.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btn_close_b.Click += new System.EventHandler(this.btn_close_b_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.groupBox2.Controls.Add(this.link_edit_osra);
            this.groupBox2.Controls.Add(this.link_get_osra_data);
            this.groupBox2.Controls.Add(this.link_new_osra_data);
            this.groupBox2.Controls.Add(this.pn_osraa);
            this.groupBox2.Font = new System.Drawing.Font("LBC", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.ForeColor = System.Drawing.Color.DarkGray;
            this.groupBox2.Location = new System.Drawing.Point(23, 361);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.groupBox2.Size = new System.Drawing.Size(559, 174);
            this.groupBox2.TabIndex = 60;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "بيانات الأسرة";
            // 
            // link_edit_osra
            // 
            this.link_edit_osra.AutoSize = true;
            this.link_edit_osra.Enabled = false;
            this.link_edit_osra.Font = new System.Drawing.Font("LBC", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.link_edit_osra.Location = new System.Drawing.Point(31, 28);
            this.link_edit_osra.Name = "link_edit_osra";
            this.link_edit_osra.Size = new System.Drawing.Size(112, 25);
            this.link_edit_osra.TabIndex = 25;
            this.link_edit_osra.TabStop = true;
            this.link_edit_osra.Text = "تعديل البيانات";
            // 
            // link_get_osra_data
            // 
            this.link_get_osra_data.AutoSize = true;
            this.link_get_osra_data.Font = new System.Drawing.Font("LBC", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.link_get_osra_data.Location = new System.Drawing.Point(399, 28);
            this.link_get_osra_data.Name = "link_get_osra_data";
            this.link_get_osra_data.Size = new System.Drawing.Size(128, 25);
            this.link_get_osra_data.TabIndex = 10;
            this.link_get_osra_data.TabStop = true;
            this.link_get_osra_data.Text = "بحث عن البيانات";
            this.link_get_osra_data.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.link_get_osra_data_LinkClicked);
            // 
            // link_new_osra_data
            // 
            this.link_new_osra_data.AutoSize = true;
            this.link_new_osra_data.Font = new System.Drawing.Font("LBC", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.link_new_osra_data.Location = new System.Drawing.Point(215, 28);
            this.link_new_osra_data.Name = "link_new_osra_data";
            this.link_new_osra_data.Size = new System.Drawing.Size(112, 25);
            this.link_new_osra_data.TabIndex = 9;
            this.link_new_osra_data.TabStop = true;
            this.link_new_osra_data.Text = "إضافة بيانات  ";
            this.link_new_osra_data.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.link_new_osra_data_LinkClicked);
            // 
            // pn_osraa
            // 
            this.pn_osraa.AutoScroll = true;
            this.pn_osraa.Controls.Add(this.label9);
            this.pn_osraa.Controls.Add(this.txt_mother_name);
            this.pn_osraa.Controls.Add(this.label8);
            this.pn_osraa.Controls.Add(this.txt_mother_tel);
            this.pn_osraa.Controls.Add(this.label10);
            this.pn_osraa.Controls.Add(this.label6);
            this.pn_osraa.Controls.Add(this.txt_father_tel);
            this.pn_osraa.Controls.Add(this.label5);
            this.pn_osraa.Controls.Add(this.label4);
            this.pn_osraa.Controls.Add(this.label1);
            this.pn_osraa.Controls.Add(this.txt_osra_id);
            this.pn_osraa.Controls.Add(this.txt_wazifa);
            this.pn_osraa.Controls.Add(this.txt_adrs);
            this.pn_osraa.Controls.Add(this.txt_father_name);
            this.pn_osraa.Location = new System.Drawing.Point(6, 62);
            this.pn_osraa.Name = "pn_osraa";
            this.pn_osraa.Size = new System.Drawing.Size(531, 132);
            this.pn_osraa.TabIndex = 70;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Noto Naskh Arabic", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.label9.Location = new System.Drawing.Point(443, 159);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(62, 29);
            this.label9.TabIndex = 24;
            this.label9.Text = "اسم الأم";
            // 
            // txt_mother_name
            // 
            this.txt_mother_name.Enabled = false;
            this.txt_mother_name.Font = new System.Drawing.Font("Noto Naskh Arabic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_mother_name.Location = new System.Drawing.Point(17, 154);
            this.txt_mother_name.MaxLength = 50;
            this.txt_mother_name.Name = "txt_mother_name";
            this.txt_mother_name.Size = new System.Drawing.Size(412, 40);
            this.txt_mother_name.TabIndex = 23;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Noto Naskh Arabic", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.label8.Location = new System.Drawing.Point(189, 209);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(51, 29);
            this.label8.TabIndex = 22;
            this.label8.Text = "ت الأم";
            // 
            // txt_mother_tel
            // 
            this.txt_mother_tel.Enabled = false;
            this.txt_mother_tel.Font = new System.Drawing.Font("Noto Naskh Arabic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_mother_tel.Location = new System.Drawing.Point(17, 204);
            this.txt_mother_tel.MaxLength = 50;
            this.txt_mother_tel.Name = "txt_mother_tel";
            this.txt_mother_tel.Size = new System.Drawing.Size(167, 40);
            this.txt_mother_tel.TabIndex = 21;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Noto Naskh Arabic", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.label10.Location = new System.Drawing.Point(449, 228);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(0, 29);
            this.label10.TabIndex = 20;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Noto Naskh Arabic", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.label6.Location = new System.Drawing.Point(449, 209);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(56, 29);
            this.label6.TabIndex = 20;
            this.label6.Text = "ت الأب";
            // 
            // txt_father_tel
            // 
            this.txt_father_tel.Enabled = false;
            this.txt_father_tel.Font = new System.Drawing.Font("Noto Naskh Arabic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_father_tel.Location = new System.Drawing.Point(246, 204);
            this.txt_father_tel.MaxLength = 50;
            this.txt_father_tel.Name = "txt_father_tel";
            this.txt_father_tel.Size = new System.Drawing.Size(183, 40);
            this.txt_father_tel.TabIndex = 19;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Noto Naskh Arabic", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.label5.Location = new System.Drawing.Point(444, 112);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(61, 29);
            this.label5.TabIndex = 18;
            this.label5.Text = "الوظيفة";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Noto Naskh Arabic", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.label4.Location = new System.Drawing.Point(450, 64);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(55, 29);
            this.label4.TabIndex = 18;
            this.label4.Text = "العنوان";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Noto Naskh Arabic", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.label1.Location = new System.Drawing.Point(438, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 29);
            this.label1.TabIndex = 18;
            this.label1.Text = "اسم الأب";
            // 
            // txt_osra_id
            // 
            this.txt_osra_id.Font = new System.Drawing.Font("Noto Naskh Arabic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_osra_id.Location = new System.Drawing.Point(498, 46);
            this.txt_osra_id.MaxLength = 11;
            this.txt_osra_id.Name = "txt_osra_id";
            this.txt_osra_id.Size = new System.Drawing.Size(17, 40);
            this.txt_osra_id.TabIndex = 3;
            this.txt_osra_id.Visible = false;
            // 
            // txt_wazifa
            // 
            this.txt_wazifa.Enabled = false;
            this.txt_wazifa.Font = new System.Drawing.Font("Noto Naskh Arabic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_wazifa.Location = new System.Drawing.Point(17, 107);
            this.txt_wazifa.MaxLength = 50;
            this.txt_wazifa.Name = "txt_wazifa";
            this.txt_wazifa.Size = new System.Drawing.Size(411, 40);
            this.txt_wazifa.TabIndex = 3;
            // 
            // txt_adrs
            // 
            this.txt_adrs.Enabled = false;
            this.txt_adrs.Font = new System.Drawing.Font("Noto Naskh Arabic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_adrs.Location = new System.Drawing.Point(17, 59);
            this.txt_adrs.MaxLength = 50;
            this.txt_adrs.Name = "txt_adrs";
            this.txt_adrs.Size = new System.Drawing.Size(411, 40);
            this.txt_adrs.TabIndex = 3;
            // 
            // txt_father_name
            // 
            this.txt_father_name.Enabled = false;
            this.txt_father_name.Font = new System.Drawing.Font("Noto Naskh Arabic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_father_name.Location = new System.Drawing.Point(17, 11);
            this.txt_father_name.MaxLength = 50;
            this.txt_father_name.Name = "txt_father_name";
            this.txt_father_name.Size = new System.Drawing.Size(411, 40);
            this.txt_father_name.TabIndex = 3;
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.groupBox3.Controls.Add(this.cmb_national);
            this.groupBox3.Controls.Add(this.cmb_religion);
            this.groupBox3.Controls.Add(this.cmb_hala);
            this.groupBox3.Controls.Add(this.cmb_grade);
            this.groupBox3.Controls.Add(this.txt_std_code);
            this.groupBox3.Controls.Add(this.cmb_type);
            this.groupBox3.Controls.Add(this.label18);
            this.groupBox3.Controls.Add(this.label17);
            this.groupBox3.Controls.Add(this.label15);
            this.groupBox3.Controls.Add(this.label16);
            this.groupBox3.Controls.Add(this.txt_std_name);
            this.groupBox3.Controls.Add(this.label14);
            this.groupBox3.Controls.Add(this.label13);
            this.groupBox3.Font = new System.Drawing.Font("LBC", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.ForeColor = System.Drawing.Color.DarkGray;
            this.groupBox3.Location = new System.Drawing.Point(23, 174);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.groupBox3.Size = new System.Drawing.Size(559, 181);
            this.groupBox3.TabIndex = 59;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "بيانات الطالب";
            // 
            // cmb_national
            // 
            this.cmb_national.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_national.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cmb_national.Font = new System.Drawing.Font("Noto Naskh Arabic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmb_national.ForeColor = System.Drawing.Color.DimGray;
            this.cmb_national.FormattingEnabled = true;
            this.cmb_national.Items.AddRange(new object[] {
            "ذكر",
            "أنثى"});
            this.cmb_national.Location = new System.Drawing.Point(269, 129);
            this.cmb_national.Name = "cmb_national";
            this.cmb_national.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.cmb_national.Size = new System.Drawing.Size(192, 40);
            this.cmb_national.TabIndex = 30;
            // 
            // cmb_religion
            // 
            this.cmb_religion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_religion.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cmb_religion.Font = new System.Drawing.Font("Noto Naskh Arabic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmb_religion.ForeColor = System.Drawing.Color.DimGray;
            this.cmb_religion.FormattingEnabled = true;
            this.cmb_religion.Items.AddRange(new object[] {
            "ذكر",
            "أنثى"});
            this.cmb_religion.Location = new System.Drawing.Point(12, 129);
            this.cmb_religion.Name = "cmb_religion";
            this.cmb_religion.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.cmb_religion.Size = new System.Drawing.Size(180, 40);
            this.cmb_religion.TabIndex = 30;
            // 
            // cmb_hala
            // 
            this.cmb_hala.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_hala.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cmb_hala.Font = new System.Drawing.Font("Noto Naskh Arabic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmb_hala.ForeColor = System.Drawing.Color.DimGray;
            this.cmb_hala.FormattingEnabled = true;
            this.cmb_hala.Items.AddRange(new object[] {
            "ذكر",
            "أنثى"});
            this.cmb_hala.Location = new System.Drawing.Point(12, 77);
            this.cmb_hala.Name = "cmb_hala";
            this.cmb_hala.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.cmb_hala.Size = new System.Drawing.Size(180, 40);
            this.cmb_hala.TabIndex = 30;
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
            this.cmb_grade.Location = new System.Drawing.Point(269, 77);
            this.cmb_grade.Name = "cmb_grade";
            this.cmb_grade.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.cmb_grade.Size = new System.Drawing.Size(192, 40);
            this.cmb_grade.TabIndex = 30;
            this.cmb_grade.SelectedIndexChanged += new System.EventHandler(this.cmb_grade_SelectedIndexChanged);
            // 
            // txt_std_code
            // 
            this.txt_std_code.Font = new System.Drawing.Font("Noto Naskh Arabic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_std_code.Location = new System.Drawing.Point(248, 28);
            this.txt_std_code.MaxLength = 14;
            this.txt_std_code.Name = "txt_std_code";
            this.txt_std_code.Size = new System.Drawing.Size(19, 40);
            this.txt_std_code.TabIndex = 1;
            this.txt_std_code.Visible = false;
            this.txt_std_code.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_nat_KeyPress);
            this.txt_std_code.Leave += new System.EventHandler(this.txt_nat_Leave);
            // 
            // cmb_type
            // 
            this.cmb_type.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_type.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cmb_type.Font = new System.Drawing.Font("Noto Naskh Arabic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmb_type.ForeColor = System.Drawing.Color.DimGray;
            this.cmb_type.FormattingEnabled = true;
            this.cmb_type.Items.AddRange(new object[] {
            "ذكر",
            "أنثى"});
            this.cmb_type.Location = new System.Drawing.Point(12, 25);
            this.cmb_type.Name = "cmb_type";
            this.cmb_type.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.cmb_type.Size = new System.Drawing.Size(180, 40);
            this.cmb_type.TabIndex = 20;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Noto Naskh Arabic", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.label18.Location = new System.Drawing.Point(467, 82);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(48, 29);
            this.label18.TabIndex = 29;
            this.label18.Text = "الصف";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Noto Naskh Arabic", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.label17.Location = new System.Drawing.Point(467, 36);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(81, 29);
            this.label17.TabIndex = 18;
            this.label17.Text = "الاسم الأول";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Noto Naskh Arabic", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.label15.Location = new System.Drawing.Point(467, 134);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(62, 29);
            this.label15.TabIndex = 25;
            this.label15.Text = "الجنسية";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Noto Naskh Arabic", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.label16.Location = new System.Drawing.Point(200, 82);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(48, 29);
            this.label16.TabIndex = 26;
            this.label16.Text = "الحالة";
            // 
            // txt_std_name
            // 
            this.txt_std_name.Font = new System.Drawing.Font("Noto Naskh Arabic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_std_name.Location = new System.Drawing.Point(269, 28);
            this.txt_std_name.MaxLength = 11;
            this.txt_std_name.Name = "txt_std_name";
            this.txt_std_name.Size = new System.Drawing.Size(191, 40);
            this.txt_std_name.TabIndex = 3;
            this.txt_std_name.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_std_name_KeyPress);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Noto Naskh Arabic", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.label14.Location = new System.Drawing.Point(196, 133);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(52, 29);
            this.label14.TabIndex = 19;
            this.label14.Text = "الديانة";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Noto Naskh Arabic", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.label13.Location = new System.Drawing.Point(204, 33);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(44, 29);
            this.label13.TabIndex = 20;
            this.label13.Text = "النوع";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Noto Naskh Arabic", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.label2.Location = new System.Drawing.Point(465, 36);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(91, 29);
            this.label2.TabIndex = 3;
            this.label2.Text = "الرقم القومى";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Noto Naskh Arabic", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.label12.Location = new System.Drawing.Point(150, 36);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(98, 29);
            this.label12.TabIndex = 3;
            this.label12.Text = "العام  الدراسى";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Noto Naskh Arabic", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.label3.Location = new System.Drawing.Point(465, 79);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(88, 29);
            this.label3.TabIndex = 8;
            this.label3.Text = "تاريخ الميلاد";
            // 
            // txt_nat
            // 
            this.txt_nat.Font = new System.Drawing.Font("Noto Naskh Arabic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_nat.Location = new System.Drawing.Point(269, 33);
            this.txt_nat.MaxLength = 14;
            this.txt_nat.Name = "txt_nat";
            this.txt_nat.Size = new System.Drawing.Size(191, 40);
            this.txt_nat.TabIndex = 1;
            this.txt_nat.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_nat_KeyPress);
            this.txt_nat.Leave += new System.EventHandler(this.txt_nat_Leave);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Noto Naskh Arabic", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.label7.Location = new System.Drawing.Point(206, 79);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(42, 29);
            this.label7.TabIndex = 19;
            this.label7.Text = "السن";
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.groupBox1.Controls.Add(this.txt_sen);
            this.groupBox1.Controls.Add(this.cmb_sana);
            this.groupBox1.Controls.Add(this.txt_tarikh);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.txt_nat);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Font = new System.Drawing.Font("LBC", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.Color.DarkGray;
            this.groupBox1.Location = new System.Drawing.Point(23, 47);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.groupBox1.Size = new System.Drawing.Size(559, 127);
            this.groupBox1.TabIndex = 50;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "تاريخ الميلاد والسن";
            // 
            // txt_sen
            // 
            this.txt_sen.Enabled = false;
            this.txt_sen.Font = new System.Drawing.Font("Noto Naskh Arabic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_sen.Location = new System.Drawing.Point(12, 79);
            this.txt_sen.MaxLength = 14;
            this.txt_sen.Name = "txt_sen";
            this.txt_sen.Size = new System.Drawing.Size(180, 40);
            this.txt_sen.TabIndex = 4;
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
            this.cmb_sana.Location = new System.Drawing.Point(12, 31);
            this.cmb_sana.Name = "cmb_sana";
            this.cmb_sana.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.cmb_sana.Size = new System.Drawing.Size(135, 40);
            this.cmb_sana.TabIndex = 0;
            this.cmb_sana.SelectedIndexChanged += new System.EventHandler(this.cmb_sana_SelectedIndexChanged);
            // 
            // txt_tarikh
            // 
            this.txt_tarikh.Enabled = false;
            this.txt_tarikh.Font = new System.Drawing.Font("Noto Naskh Arabic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_tarikh.Location = new System.Drawing.Point(269, 79);
            this.txt_tarikh.MaxLength = 14;
            this.txt_tarikh.Name = "txt_tarikh";
            this.txt_tarikh.Size = new System.Drawing.Size(191, 40);
            this.txt_tarikh.TabIndex = 3;
            // 
            // FRM_ADD_STD
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 27F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(598, 611);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.pn_top);
            this.Font = new System.Drawing.Font("LBC", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "FRM_ADD_STD";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "بيانات الطالب";
            this.Load += new System.EventHandler(this.FRM_ADD_STD_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FRM_ADD_STD_KeyDown);
            this.pn_top.ResumeLayout(false);
            this.pn_top.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.pn_osraa.ResumeLayout(false);
            this.pn_osraa.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pn_top;
        private DevExpress.XtraEditors.SimpleButton btn_close;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Panel panel3;
        private Bunifu.Framework.UI.BunifuThinButton2 btn_ok;
        private Bunifu.Framework.UI.BunifuThinButton2 btn_close_b;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txt_sen;
        private System.Windows.Forms.TextBox txt_tarikh;
        private System.Windows.Forms.Panel pn_osraa;
        private System.Windows.Forms.LinkLabel link_get_osra_data;
        private System.Windows.Forms.LinkLabel link_edit_osra;
        private System.Windows.Forms.Label label9;
        public System.Windows.Forms.TextBox txt_mother_name;
        private System.Windows.Forms.Label label8;
        public System.Windows.Forms.TextBox txt_mother_tel;
        private System.Windows.Forms.Label label6;
        public System.Windows.Forms.TextBox txt_father_tel;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.TextBox txt_wazifa;
        public System.Windows.Forms.TextBox txt_adrs;
        public System.Windows.Forms.TextBox txt_father_name;
        public System.Windows.Forms.TextBox txt_osra_id;
        private System.Windows.Forms.Label label10;
        public System.Windows.Forms.TextBox txt_nat;
        private System.Windows.Forms.LinkLabel link_new_osra_data;
        public System.Windows.Forms.GroupBox groupBox3;
        public System.Windows.Forms.TextBox txt_std_name;
        public System.Windows.Forms.ComboBox cmb_type;
        public System.Windows.Forms.ComboBox cmb_grade;
        public System.Windows.Forms.ComboBox cmb_national;
        public System.Windows.Forms.ComboBox cmb_religion;
        public System.Windows.Forms.ComboBox cmb_hala;
        public System.Windows.Forms.TextBox txt_std_code;
        public System.Windows.Forms.ComboBox cmb_sana;
    }
}