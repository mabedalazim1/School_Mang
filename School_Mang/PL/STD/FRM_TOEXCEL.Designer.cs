
namespace School_Mang.PL.STD
{
    partial class FRM_TOEXCEL
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FRM_TOEXCEL));
            this.panel3 = new System.Windows.Forms.Panel();
            this.btn_ok = new Bunifu.Framework.UI.BunifuThinButton2();
            this.btn_close_b = new Bunifu.Framework.UI.BunifuThinButton2();
            this.pn_top = new System.Windows.Forms.Panel();
            this.btn_close = new DevExpress.XtraEditors.SimpleButton();
            this.label11 = new System.Windows.Forms.Label();
            this.cmb_sana = new System.Windows.Forms.ComboBox();
            this.label12 = new System.Windows.Forms.Label();
            this.cmb_data = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel3.SuspendLayout();
            this.pn_top.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.btn_ok);
            this.panel3.Controls.Add(this.btn_close_b);
            this.panel3.Location = new System.Drawing.Point(10, 179);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(559, 58);
            this.panel3.TabIndex = 60;
            // 
            // btn_ok
            // 
            this.btn_ok.ActiveBorderThickness = 1;
            this.btn_ok.ActiveCornerRadius = 20;
            this.btn_ok.ActiveFillColor = System.Drawing.Color.SeaGreen;
            this.btn_ok.ActiveForecolor = System.Drawing.Color.White;
            this.btn_ok.ActiveLineColor = System.Drawing.Color.SeaGreen;
            this.btn_ok.BackColor = System.Drawing.SystemColors.Control;
            this.btn_ok.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_ok.BackgroundImage")));
            this.btn_ok.ButtonText = "موافق";
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
            this.btn_close_b.Location = new System.Drawing.Point(26, 2);
            this.btn_close_b.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btn_close_b.Name = "btn_close_b";
            this.btn_close_b.Size = new System.Drawing.Size(139, 50);
            this.btn_close_b.TabIndex = 12;
            this.btn_close_b.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btn_close_b.Click += new System.EventHandler(this.btn_close_b_Click);
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
            this.pn_top.Size = new System.Drawing.Size(581, 43);
            this.pn_top.TabIndex = 59;
            this.pn_top.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pn_top_MouseDown);
            this.pn_top.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pn_top_MouseMove);
            this.pn_top.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pn_top_MouseUp);
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
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("LBC", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.White;
            this.label11.Location = new System.Drawing.Point(235, 9);
            this.label11.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(111, 25);
            this.label11.TabIndex = 45;
            this.label11.Text = "تصدير البيانات";
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
            this.cmb_sana.Location = new System.Drawing.Point(34, 93);
            this.cmb_sana.Name = "cmb_sana";
            this.cmb_sana.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.cmb_sana.Size = new System.Drawing.Size(142, 40);
            this.cmb_sana.TabIndex = 61;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Noto Naskh Arabic", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.label12.Location = new System.Drawing.Point(183, 98);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(98, 29);
            this.label12.TabIndex = 62;
            this.label12.Text = "العام  الدراسى";
            // 
            // cmb_data
            // 
            this.cmb_data.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_data.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cmb_data.Font = new System.Drawing.Font("Noto Naskh Arabic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmb_data.ForeColor = System.Drawing.Color.DimGray;
            this.cmb_data.FormattingEnabled = true;
            this.cmb_data.Items.AddRange(new object[] {
            "قوائم الفصول",
            "أرقام التليفونات"});
            this.cmb_data.Location = new System.Drawing.Point(314, 93);
            this.cmb_data.Name = "cmb_data";
            this.cmb_data.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.cmb_data.Size = new System.Drawing.Size(148, 40);
            this.cmb_data.TabIndex = 63;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Noto Naskh Arabic", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.label1.Location = new System.Drawing.Point(468, 98);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(101, 29);
            this.label1.TabIndex = 64;
            this.label1.Text = "البيان المطلوب";
            // 
            // FRM_TOEXCEL
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(581, 256);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmb_data);
            this.Controls.Add(this.cmb_sana);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.pn_top);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FRM_TOEXCEL";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FRM_TOEXCEL";
            this.Load += new System.EventHandler(this.FRM_TOEXCEL_Load);
            this.panel3.ResumeLayout(false);
            this.pn_top.ResumeLayout(false);
            this.pn_top.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel3;
        private Bunifu.Framework.UI.BunifuThinButton2 btn_ok;
        private Bunifu.Framework.UI.BunifuThinButton2 btn_close_b;
        private System.Windows.Forms.Panel pn_top;
        private DevExpress.XtraEditors.SimpleButton btn_close;
        private System.Windows.Forms.Label label11;
        public System.Windows.Forms.ComboBox cmb_sana;
        private System.Windows.Forms.Label label12;
        public System.Windows.Forms.ComboBox cmb_data;
        private System.Windows.Forms.Label label1;
    }
}