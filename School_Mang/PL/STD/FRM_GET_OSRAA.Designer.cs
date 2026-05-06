
namespace School_Mang.PL.STD
{
    partial class FRM_GET_OSRAA 
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FRM_GET_OSRAA));
            this.pn_top = new System.Windows.Forms.Panel();
            this.label11 = new System.Windows.Forms.Label();
            this.btn_close = new DevExpress.XtraEditors.SimpleButton();
            this.panel4 = new System.Windows.Forms.Panel();
            this.dt_osra_data = new System.Windows.Forms.DataGridView();
            this.txt_osra_data = new Bunifu.Framework.UI.BunifuMaterialTextbox();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_close_b = new Bunifu.Framework.UI.BunifuThinButton2();
            this.btn_ok = new Bunifu.Framework.UI.BunifuThinButton2();
            this.btn_new_osra = new Bunifu.Framework.UI.BunifuThinButton2();
            this.btn_edit_osra = new Bunifu.Framework.UI.BunifuThinButton2();
            this.btn_del_osra = new Bunifu.Framework.UI.BunifuThinButton2();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.pic_help = new System.Windows.Forms.PictureBox();
            this.lbl_help = new System.Windows.Forms.Label();
            this.pn_top.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dt_osra_data)).BeginInit();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pic_help)).BeginInit();
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
            this.pn_top.Size = new System.Drawing.Size(1027, 50);
            this.pn_top.TabIndex = 2;
            this.pn_top.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pn_top_MouseDown);
            this.pn_top.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pn_top_MouseMove);
            this.pn_top.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pn_top_MouseUp);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("LBC", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.White;
            this.label11.Location = new System.Drawing.Point(461, 13);
            this.label11.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(104, 25);
            this.label11.TabIndex = 46;
            this.label11.Text = "بيانات الأسرة";
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
            this.panel4.TabIndex = 59;
            // 
            // dt_osra_data
            // 
            this.dt_osra_data.AllowUserToAddRows = false;
            this.dt_osra_data.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Noto Naskh Arabic", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dt_osra_data.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dt_osra_data.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dt_osra_data.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("LBC", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dt_osra_data.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dt_osra_data.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dt_osra_data.Location = new System.Drawing.Point(12, 134);
            this.dt_osra_data.Name = "dt_osra_data";
            this.dt_osra_data.ReadOnly = true;
            this.dt_osra_data.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Noto Naskh Arabic", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dt_osra_data.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Noto Naskh Arabic", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dt_osra_data.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dt_osra_data.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Noto Naskh Arabic", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dt_osra_data.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dt_osra_data.Size = new System.Drawing.Size(1003, 363);
            this.dt_osra_data.TabIndex = 60;
            this.dt_osra_data.DoubleClick += new System.EventHandler(this.dt_osra_data_DoubleClick);
            // 
            // txt_osra_data
            // 
            this.txt_osra_data.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_osra_data.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txt_osra_data.Font = new System.Drawing.Font("Noto Naskh Arabic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_osra_data.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txt_osra_data.HintForeColor = System.Drawing.Color.Empty;
            this.txt_osra_data.HintText = "";
            this.txt_osra_data.isPassword = false;
            this.txt_osra_data.LineFocusedColor = System.Drawing.Color.Blue;
            this.txt_osra_data.LineIdleColor = System.Drawing.Color.Gray;
            this.txt_osra_data.LineMouseHoverColor = System.Drawing.Color.Blue;
            this.txt_osra_data.LineThickness = 5;
            this.txt_osra_data.Location = new System.Drawing.Point(236, 70);
            this.txt_osra_data.Margin = new System.Windows.Forms.Padding(4);
            this.txt_osra_data.Name = "txt_osra_data";
            this.txt_osra_data.Padding = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.txt_osra_data.Size = new System.Drawing.Size(541, 44);
            this.txt_osra_data.TabIndex = 61;
            this.txt_osra_data.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txt_osra_data.OnValueChanged += new System.EventHandler(this.txt_osra_data_OnValueChanged);
            this.txt_osra_data.Enter += new System.EventHandler(this.txt_osra_data_Enter);
            this.txt_osra_data.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_osra_data_KeyPress);
            this.txt_osra_data.Leave += new System.EventHandler(this.txt_osra_data_Leave);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label1.Font = new System.Drawing.Font("LBC", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(784, 84);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 25);
            this.label1.TabIndex = 62;
            this.label1.Text = "بحث";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            this.label1.MouseLeave += new System.EventHandler(this.label1_MouseLeave);
            this.label1.MouseHover += new System.EventHandler(this.label1_MouseHover);
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
            this.btn_close_b.Size = new System.Drawing.Size(139, 50);
            this.btn_close_b.TabIndex = 19;
            this.btn_close_b.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btn_close_b.Click += new System.EventHandler(this.btn_close_b_Click);
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
            this.btn_ok.ButtonText = "إضافة لبيانات الطالب";
            this.btn_ok.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_ok.Font = new System.Drawing.Font("LBC", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_ok.ForeColor = System.Drawing.Color.SeaGreen;
            this.btn_ok.IdleBorderThickness = 1;
            this.btn_ok.IdleCornerRadius = 20;
            this.btn_ok.IdleFillColor = System.Drawing.Color.WhiteSmoke;
            this.btn_ok.IdleForecolor = System.Drawing.Color.SeaGreen;
            this.btn_ok.IdleLineColor = System.Drawing.Color.SeaGreen;
            this.btn_ok.Location = new System.Drawing.Point(815, 12);
            this.btn_ok.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btn_ok.Name = "btn_ok";
            this.btn_ok.Size = new System.Drawing.Size(177, 50);
            this.btn_ok.TabIndex = 18;
            this.btn_ok.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btn_ok.Click += new System.EventHandler(this.btn_ok_Click);
            // 
            // btn_new_osra
            // 
            this.btn_new_osra.ActiveBorderThickness = 1;
            this.btn_new_osra.ActiveCornerRadius = 20;
            this.btn_new_osra.ActiveFillColor = System.Drawing.Color.CadetBlue;
            this.btn_new_osra.ActiveForecolor = System.Drawing.Color.White;
            this.btn_new_osra.ActiveLineColor = System.Drawing.Color.CadetBlue;
            this.btn_new_osra.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btn_new_osra.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_new_osra.BackgroundImage")));
            this.btn_new_osra.ButtonText = "إضافة بيانات أسرة جديدة";
            this.btn_new_osra.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_new_osra.Font = new System.Drawing.Font("LBC", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_new_osra.ForeColor = System.Drawing.Color.RoyalBlue;
            this.btn_new_osra.IdleBorderThickness = 1;
            this.btn_new_osra.IdleCornerRadius = 20;
            this.btn_new_osra.IdleFillColor = System.Drawing.Color.WhiteSmoke;
            this.btn_new_osra.IdleForecolor = System.Drawing.Color.DodgerBlue;
            this.btn_new_osra.IdleLineColor = System.Drawing.Color.SteelBlue;
            this.btn_new_osra.Location = new System.Drawing.Point(598, 12);
            this.btn_new_osra.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btn_new_osra.Name = "btn_new_osra";
            this.btn_new_osra.Size = new System.Drawing.Size(189, 50);
            this.btn_new_osra.TabIndex = 18;
            this.btn_new_osra.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btn_new_osra.Click += new System.EventHandler(this.btn_new_osra_Click);
            // 
            // btn_edit_osra
            // 
            this.btn_edit_osra.ActiveBorderThickness = 1;
            this.btn_edit_osra.ActiveCornerRadius = 20;
            this.btn_edit_osra.ActiveFillColor = System.Drawing.Color.Teal;
            this.btn_edit_osra.ActiveForecolor = System.Drawing.Color.White;
            this.btn_edit_osra.ActiveLineColor = System.Drawing.Color.Teal;
            this.btn_edit_osra.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btn_edit_osra.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_edit_osra.BackgroundImage")));
            this.btn_edit_osra.ButtonText = "تعديل بيانات أسرة ";
            this.btn_edit_osra.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_edit_osra.Font = new System.Drawing.Font("LBC", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_edit_osra.ForeColor = System.Drawing.Color.DarkCyan;
            this.btn_edit_osra.IdleBorderThickness = 1;
            this.btn_edit_osra.IdleCornerRadius = 20;
            this.btn_edit_osra.IdleFillColor = System.Drawing.Color.WhiteSmoke;
            this.btn_edit_osra.IdleForecolor = System.Drawing.Color.DarkCyan;
            this.btn_edit_osra.IdleLineColor = System.Drawing.Color.CadetBlue;
            this.btn_edit_osra.Location = new System.Drawing.Point(378, 12);
            this.btn_edit_osra.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btn_edit_osra.Name = "btn_edit_osra";
            this.btn_edit_osra.Size = new System.Drawing.Size(189, 50);
            this.btn_edit_osra.TabIndex = 18;
            this.btn_edit_osra.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btn_edit_osra.Click += new System.EventHandler(this.btn_edit_osra_Click);
            // 
            // btn_del_osra
            // 
            this.btn_del_osra.ActiveBorderThickness = 1;
            this.btn_del_osra.ActiveCornerRadius = 20;
            this.btn_del_osra.ActiveFillColor = System.Drawing.Color.Crimson;
            this.btn_del_osra.ActiveForecolor = System.Drawing.Color.White;
            this.btn_del_osra.ActiveLineColor = System.Drawing.Color.Crimson;
            this.btn_del_osra.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btn_del_osra.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_del_osra.BackgroundImage")));
            this.btn_del_osra.ButtonText = "حذف بيانات أسرة ";
            this.btn_del_osra.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_del_osra.Font = new System.Drawing.Font("LBC", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_del_osra.ForeColor = System.Drawing.Color.Crimson;
            this.btn_del_osra.IdleBorderThickness = 1;
            this.btn_del_osra.IdleCornerRadius = 20;
            this.btn_del_osra.IdleFillColor = System.Drawing.Color.WhiteSmoke;
            this.btn_del_osra.IdleForecolor = System.Drawing.Color.Crimson;
            this.btn_del_osra.IdleLineColor = System.Drawing.Color.PaleVioletRed;
            this.btn_del_osra.Location = new System.Drawing.Point(169, 12);
            this.btn_del_osra.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btn_del_osra.Name = "btn_del_osra";
            this.btn_del_osra.Size = new System.Drawing.Size(189, 50);
            this.btn_del_osra.TabIndex = 18;
            this.btn_del_osra.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btn_del_osra.Click += new System.EventHandler(this.btn_del_osra_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btn_del_osra);
            this.groupBox3.Controls.Add(this.btn_edit_osra);
            this.groupBox3.Controls.Add(this.btn_new_osra);
            this.groupBox3.Controls.Add(this.btn_ok);
            this.groupBox3.Controls.Add(this.btn_close_b);
            this.groupBox3.Location = new System.Drawing.Point(12, 515);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(1003, 73);
            this.groupBox3.TabIndex = 63;
            this.groupBox3.TabStop = false;
            // 
            // pic_help
            // 
            this.pic_help.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pic_help.Image = global::School_Mang.Properties.Resources.help_80;
            this.pic_help.Location = new System.Drawing.Point(191, 77);
            this.pic_help.Name = "pic_help";
            this.pic_help.Size = new System.Drawing.Size(38, 32);
            this.pic_help.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pic_help.TabIndex = 64;
            this.pic_help.TabStop = false;
            this.pic_help.MouseLeave += new System.EventHandler(this.pic_help_MouseLeave);
            this.pic_help.MouseHover += new System.EventHandler(this.pic_help_MouseHover);
            // 
            // lbl_help
            // 
            this.lbl_help.AutoSize = true;
            this.lbl_help.Font = new System.Drawing.Font("Noto Naskh Arabic", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_help.Location = new System.Drawing.Point(489, 53);
            this.lbl_help.Name = "lbl_help";
            this.lbl_help.Size = new System.Drawing.Size(29, 29);
            this.lbl_help.TabIndex = 65;
            this.lbl_help.Text = "    ";
            this.lbl_help.Visible = false;
            // 
            // FRM_GET_OSRAA
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(1027, 618);
            this.Controls.Add(this.lbl_help);
            this.Controls.Add(this.pic_help);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txt_osra_data);
            this.Controls.Add(this.dt_osra_data);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.pn_top);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FRM_GET_OSRAA";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "بيانات الأسرة";
            this.pn_top.ResumeLayout(false);
            this.pn_top.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dt_osra_data)).EndInit();
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pic_help)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Panel pn_top;
        private System.Windows.Forms.Label label11;
        private DevExpress.XtraEditors.SimpleButton btn_close;
        private System.Windows.Forms.Panel panel4;
        private Bunifu.Framework.UI.BunifuMaterialTextbox txt_osra_data;
        private System.Windows.Forms.Label label1;
        private Bunifu.Framework.UI.BunifuThinButton2 btn_close_b;
        private Bunifu.Framework.UI.BunifuThinButton2 btn_ok;
        private Bunifu.Framework.UI.BunifuThinButton2 btn_new_osra;
        private Bunifu.Framework.UI.BunifuThinButton2 btn_edit_osra;
        private Bunifu.Framework.UI.BunifuThinButton2 btn_del_osra;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.PictureBox pic_help;
        private System.Windows.Forms.Label lbl_help;
        public System.Windows.Forms.DataGridView dt_osra_data;
    }
}