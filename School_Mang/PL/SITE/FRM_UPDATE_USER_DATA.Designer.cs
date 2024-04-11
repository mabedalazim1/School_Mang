
namespace School_Mang.PL.SITE
{
    partial class FRM_UPDATE_USER_DATA
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FRM_UPDATE_USER_DATA));
            this.pn_top = new System.Windows.Forms.Panel();
            this.btn_close = new DevExpress.XtraEditors.SimpleButton();
            this.label11 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txt_std_code = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.txt_first_name = new System.Windows.Forms.TextBox();
            this.txt_std_name = new System.Windows.Forms.TextBox();
            this.cmb_grade = new System.Windows.Forms.ComboBox();
            this.label18 = new System.Windows.Forms.Label();
            this.cmb_gender = new System.Windows.Forms.ComboBox();
            this.cmb_class = new System.Windows.Forms.ComboBox();
            this.cmb_relgien = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btn_save_data = new Bunifu.Framework.UI.BunifuThinButton2();
            this.btn_close_b = new Bunifu.Framework.UI.BunifuThinButton2();
            this.txt_stdCode = new System.Windows.Forms.TextBox();
            this.pn_top.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // pn_top
            // 
            this.pn_top.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.pn_top.Controls.Add(this.btn_close);
            this.pn_top.Controls.Add(this.label11);
            this.pn_top.Dock = System.Windows.Forms.DockStyle.Top;
            this.pn_top.Location = new System.Drawing.Point(0, 0);
            this.pn_top.Name = "pn_top";
            this.pn_top.Size = new System.Drawing.Size(549, 50);
            this.pn_top.TabIndex = 82;
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
            this.label11.Location = new System.Drawing.Point(183, 13);
            this.label11.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(183, 25);
            this.label11.TabIndex = 46;
            this.label11.Text = "تعديل بيانات المستخدم";
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.panel4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel4.Location = new System.Drawing.Point(0, 400);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(549, 10);
            this.panel4.TabIndex = 83;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txt_std_code);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label17);
            this.groupBox1.Controls.Add(this.txt_first_name);
            this.groupBox1.Controls.Add(this.txt_std_name);
            this.groupBox1.Controls.Add(this.cmb_grade);
            this.groupBox1.Controls.Add(this.label18);
            this.groupBox1.Controls.Add(this.cmb_gender);
            this.groupBox1.Controls.Add(this.cmb_class);
            this.groupBox1.Controls.Add(this.cmb_relgien);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Font = new System.Drawing.Font("LBC", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.Color.DarkGray;
            this.groupBox1.Location = new System.Drawing.Point(12, 60);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.groupBox1.Size = new System.Drawing.Size(517, 249);
            this.groupBox1.TabIndex = 95;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "بيانات المستخدم";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Noto Naskh Arabic", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.label4.Location = new System.Drawing.Point(156, 42);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(98, 29);
            this.label4.TabIndex = 95;
            this.label4.Text = "كود المستخدم";
            // 
            // txt_std_code
            // 
            this.txt_std_code.Font = new System.Drawing.Font("Noto Naskh Arabic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_std_code.Location = new System.Drawing.Point(13, 37);
            this.txt_std_code.MaxLength = 11;
            this.txt_std_code.Name = "txt_std_code";
            this.txt_std_code.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txt_std_code.ShortcutsEnabled = false;
            this.txt_std_code.Size = new System.Drawing.Size(135, 40);
            this.txt_std_code.TabIndex = 2;
            this.txt_std_code.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_std_code_KeyPress);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Noto Naskh Arabic", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.label6.Location = new System.Drawing.Point(430, 42);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(81, 29);
            this.label6.TabIndex = 93;
            this.label6.Text = "الاسم الاول";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Noto Naskh Arabic", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.label17.Location = new System.Drawing.Point(432, 89);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(79, 29);
            this.label17.TabIndex = 93;
            this.label17.Text = "الاسم كاملاً";
            // 
            // txt_first_name
            // 
            this.txt_first_name.Font = new System.Drawing.Font("Noto Naskh Arabic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_first_name.Location = new System.Drawing.Point(268, 37);
            this.txt_first_name.MaxLength = 11;
            this.txt_first_name.Name = "txt_first_name";
            this.txt_first_name.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txt_first_name.Size = new System.Drawing.Size(153, 40);
            this.txt_first_name.TabIndex = 1;
            // 
            // txt_std_name
            // 
            this.txt_std_name.Font = new System.Drawing.Font("Noto Naskh Arabic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_std_name.Location = new System.Drawing.Point(13, 86);
            this.txt_std_name.MaxLength = 255;
            this.txt_std_name.Name = "txt_std_name";
            this.txt_std_name.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txt_std_name.Size = new System.Drawing.Size(408, 40);
            this.txt_std_name.TabIndex = 3;
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
            this.cmb_grade.Location = new System.Drawing.Point(258, 135);
            this.cmb_grade.Name = "cmb_grade";
            this.cmb_grade.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.cmb_grade.Size = new System.Drawing.Size(163, 40);
            this.cmb_grade.TabIndex = 4;
            this.cmb_grade.SelectedIndexChanged += new System.EventHandler(this.cmb_grade_SelectedIndexChanged);
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Noto Naskh Arabic", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.label18.Location = new System.Drawing.Point(450, 136);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(48, 29);
            this.label18.TabIndex = 88;
            this.label18.Text = "الصف";
            // 
            // cmb_gender
            // 
            this.cmb_gender.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_gender.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cmb_gender.Font = new System.Drawing.Font("Noto Naskh Arabic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmb_gender.ForeColor = System.Drawing.Color.DimGray;
            this.cmb_gender.FormattingEnabled = true;
            this.cmb_gender.Items.AddRange(new object[] {
            "ذكر",
            "أنثى"});
            this.cmb_gender.Location = new System.Drawing.Point(13, 184);
            this.cmb_gender.Name = "cmb_gender";
            this.cmb_gender.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.cmb_gender.Size = new System.Drawing.Size(163, 40);
            this.cmb_gender.TabIndex = 7;
            // 
            // cmb_class
            // 
            this.cmb_class.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_class.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cmb_class.Font = new System.Drawing.Font("Noto Naskh Arabic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmb_class.ForeColor = System.Drawing.Color.DimGray;
            this.cmb_class.FormattingEnabled = true;
            this.cmb_class.Items.AddRange(new object[] {
            "ذكر",
            "أنثى"});
            this.cmb_class.Location = new System.Drawing.Point(13, 135);
            this.cmb_class.Name = "cmb_class";
            this.cmb_class.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.cmb_class.Size = new System.Drawing.Size(163, 40);
            this.cmb_class.TabIndex = 5;
            // 
            // cmb_relgien
            // 
            this.cmb_relgien.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_relgien.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cmb_relgien.Font = new System.Drawing.Font("Noto Naskh Arabic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmb_relgien.ForeColor = System.Drawing.Color.DimGray;
            this.cmb_relgien.FormattingEnabled = true;
            this.cmb_relgien.Items.AddRange(new object[] {
            "ذكر",
            "أنثى"});
            this.cmb_relgien.Location = new System.Drawing.Point(258, 184);
            this.cmb_relgien.Name = "cmb_relgien";
            this.cmb_relgien.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.cmb_relgien.Size = new System.Drawing.Size(163, 40);
            this.cmb_relgien.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Noto Naskh Arabic", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.label1.Location = new System.Drawing.Point(190, 183);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 29);
            this.label1.TabIndex = 87;
            this.label1.Text = "النوع";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Noto Naskh Arabic", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.label3.Location = new System.Drawing.Point(450, 183);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 29);
            this.label3.TabIndex = 87;
            this.label3.Text = "الديانة";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Noto Naskh Arabic", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.label2.Location = new System.Drawing.Point(190, 136);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 29);
            this.label2.TabIndex = 86;
            this.label2.Text = "الفصل";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.txt_stdCode);
            this.groupBox3.Controls.Add(this.btn_save_data);
            this.groupBox3.Controls.Add(this.btn_close_b);
            this.groupBox3.Location = new System.Drawing.Point(12, 315);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(517, 73);
            this.groupBox3.TabIndex = 96;
            this.groupBox3.TabStop = false;
            // 
            // btn_save_data
            // 
            this.btn_save_data.ActiveBorderThickness = 1;
            this.btn_save_data.ActiveCornerRadius = 20;
            this.btn_save_data.ActiveFillColor = System.Drawing.Color.SeaGreen;
            this.btn_save_data.ActiveForecolor = System.Drawing.Color.White;
            this.btn_save_data.ActiveLineColor = System.Drawing.Color.SeaGreen;
            this.btn_save_data.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btn_save_data.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_save_data.BackgroundImage")));
            this.btn_save_data.ButtonText = "تعديل";
            this.btn_save_data.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_save_data.Font = new System.Drawing.Font("LBC", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_save_data.ForeColor = System.Drawing.Color.SeaGreen;
            this.btn_save_data.IdleBorderThickness = 1;
            this.btn_save_data.IdleCornerRadius = 20;
            this.btn_save_data.IdleFillColor = System.Drawing.Color.WhiteSmoke;
            this.btn_save_data.IdleForecolor = System.Drawing.Color.SeaGreen;
            this.btn_save_data.IdleLineColor = System.Drawing.Color.SeaGreen;
            this.btn_save_data.Location = new System.Drawing.Point(362, 14);
            this.btn_save_data.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btn_save_data.Name = "btn_save_data";
            this.btn_save_data.Size = new System.Drawing.Size(138, 50);
            this.btn_save_data.TabIndex = 8;
            this.btn_save_data.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btn_save_data.Click += new System.EventHandler(this.btn_save_data_Click);
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
            this.btn_close_b.Location = new System.Drawing.Point(16, 14);
            this.btn_close_b.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btn_close_b.Name = "btn_close_b";
            this.btn_close_b.Size = new System.Drawing.Size(138, 50);
            this.btn_close_b.TabIndex = 9;
            this.btn_close_b.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btn_close_b.Click += new System.EventHandler(this.btn_close_b_Click);
            // 
            // txt_stdCode
            // 
            this.txt_stdCode.Font = new System.Drawing.Font("Noto Naskh Arabic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_stdCode.Location = new System.Drawing.Point(215, 19);
            this.txt_stdCode.MaxLength = 11;
            this.txt_stdCode.Name = "txt_stdCode";
            this.txt_stdCode.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txt_stdCode.Size = new System.Drawing.Size(79, 40);
            this.txt_stdCode.TabIndex = 96;
            this.txt_stdCode.Visible = false;
            // 
            // FRM_UPDATE_USER_DATA
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.CancelButton = this.btn_close;
            this.ClientSize = new System.Drawing.Size(549, 410);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.pn_top);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FRM_UPDATE_USER_DATA";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "بياتات المستخدم";
            this.Load += new System.EventHandler(this.FRM_UPDATE_USER_DATA_Load);
            this.pn_top.ResumeLayout(false);
            this.pn_top.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pn_top;
        private System.Windows.Forms.Label label11;
        private DevExpress.XtraEditors.SimpleButton btn_close;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label4;
        public System.Windows.Forms.TextBox txt_std_code;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label17;
        public System.Windows.Forms.TextBox txt_first_name;
        public System.Windows.Forms.TextBox txt_std_name;
        public System.Windows.Forms.ComboBox cmb_grade;
        private System.Windows.Forms.Label label18;
        public System.Windows.Forms.ComboBox cmb_gender;
        public System.Windows.Forms.ComboBox cmb_class;
        public System.Windows.Forms.ComboBox cmb_relgien;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox3;
        private Bunifu.Framework.UI.BunifuThinButton2 btn_save_data;
        private Bunifu.Framework.UI.BunifuThinButton2 btn_close_b;
        public System.Windows.Forms.TextBox txt_stdCode;
    }
}