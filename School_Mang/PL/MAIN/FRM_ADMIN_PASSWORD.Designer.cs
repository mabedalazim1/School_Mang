namespace School_Mang.PL.MAIN
{
    partial class FRM_ADMIN_PASSWORD
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FRM_ADMIN_PASSWORD));
            this.pn_top = new System.Windows.Forms.Panel();
            this.btn_close = new DevExpress.XtraEditors.SimpleButton();
            this.lbl_title = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btn_ok = new Bunifu.Framework.UI.BunifuThinButton2();
            this.btn_close_b = new Bunifu.Framework.UI.BunifuThinButton2();
            this.group_box_login = new System.Windows.Forms.GroupBox();
            this.txt_pass = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.pn_top.SuspendLayout();
            this.panel1.SuspendLayout();
            this.group_box_login.SuspendLayout();
            this.SuspendLayout();
            // 
            // pn_top
            // 
            this.pn_top.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.pn_top.Controls.Add(this.btn_close);
            this.pn_top.Controls.Add(this.lbl_title);
            this.pn_top.Dock = System.Windows.Forms.DockStyle.Top;
            this.pn_top.ForeColor = System.Drawing.Color.White;
            this.pn_top.Location = new System.Drawing.Point(0, 0);
            this.pn_top.Name = "pn_top";
            this.pn_top.Size = new System.Drawing.Size(412, 43);
            this.pn_top.TabIndex = 14;
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
            this.btn_close.Click += new System.EventHandler(this.btn_close_Click);
            // 
            // lbl_title
            // 
            this.lbl_title.AutoSize = true;
            this.lbl_title.Font = new System.Drawing.Font("LBC", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_title.ForeColor = System.Drawing.Color.White;
            this.lbl_title.Location = new System.Drawing.Point(127, 9);
            this.lbl_title.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.lbl_title.Name = "lbl_title";
            this.lbl_title.Size = new System.Drawing.Size(136, 25);
            this.lbl_title.TabIndex = 45;
            this.lbl_title.Text = "تأكيد كلمة المرور";
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.btn_ok);
            this.panel1.Controls.Add(this.btn_close_b);
            this.panel1.Location = new System.Drawing.Point(14, 114);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(376, 58);
            this.panel1.TabIndex = 60;
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
            this.btn_ok.Location = new System.Drawing.Point(227, 1);
            this.btn_ok.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btn_ok.Name = "btn_ok";
            this.btn_ok.Size = new System.Drawing.Size(139, 50);
            this.btn_ok.TabIndex = 2;
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
            this.btn_close_b.ButtonText = "إلغاء";
            this.btn_close_b.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_close_b.Font = new System.Drawing.Font("LBC", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_close_b.ForeColor = System.Drawing.Color.Red;
            this.btn_close_b.IdleBorderThickness = 1;
            this.btn_close_b.IdleCornerRadius = 20;
            this.btn_close_b.IdleFillColor = System.Drawing.Color.WhiteSmoke;
            this.btn_close_b.IdleForecolor = System.Drawing.Color.Red;
            this.btn_close_b.IdleLineColor = System.Drawing.Color.Red;
            this.btn_close_b.Location = new System.Drawing.Point(7, 4);
            this.btn_close_b.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btn_close_b.Name = "btn_close_b";
            this.btn_close_b.Size = new System.Drawing.Size(139, 50);
            this.btn_close_b.TabIndex = 3;
            this.btn_close_b.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btn_close_b.Click += new System.EventHandler(this.btn_close_b_Click);
            // 
            // group_box_login
            // 
            this.group_box_login.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.group_box_login.Controls.Add(this.panel1);
            this.group_box_login.Controls.Add(this.txt_pass);
            this.group_box_login.Controls.Add(this.label6);
            this.group_box_login.Font = new System.Drawing.Font("LBC", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.group_box_login.ForeColor = System.Drawing.Color.DarkGray;
            this.group_box_login.Location = new System.Drawing.Point(6, 48);
            this.group_box_login.Name = "group_box_login";
            this.group_box_login.Size = new System.Drawing.Size(399, 184);
            this.group_box_login.TabIndex = 61;
            this.group_box_login.TabStop = false;
            // 
            // txt_pass
            // 
            this.txt_pass.Font = new System.Drawing.Font("LBC", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_pass.Location = new System.Drawing.Point(20, 42);
            this.txt_pass.MaxLength = 50;
            this.txt_pass.Name = "txt_pass";
            this.txt_pass.PasswordChar = '*';
            this.txt_pass.Size = new System.Drawing.Size(269, 32);
            this.txt_pass.TabIndex = 1;
            this.txt_pass.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_pass_KeyDown);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("LBC", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.label6.Location = new System.Drawing.Point(298, 45);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(86, 22);
            this.label6.TabIndex = 5;
            this.label6.Text = "كلمة المرور";
            // 
            // FRM_ADMIN_PASSWORD
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btn_close;
            this.ClientSize = new System.Drawing.Size(412, 238);
            this.ControlBox = false;
            this.Controls.Add(this.group_box_login);
            this.Controls.Add(this.pn_top);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FRM_ADMIN_PASSWORD";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FRM_ADMIN_PASSWORD";
            this.Load += new System.EventHandler(this.FRM_ADMIN_PASSWORD_Load);
            this.pn_top.ResumeLayout(false);
            this.pn_top.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.group_box_login.ResumeLayout(false);
            this.group_box_login.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pn_top;
        private DevExpress.XtraEditors.SimpleButton btn_close;
        private System.Windows.Forms.Label lbl_title;
        private System.Windows.Forms.Panel panel1;
        private Bunifu.Framework.UI.BunifuThinButton2 btn_ok;
        private Bunifu.Framework.UI.BunifuThinButton2 btn_close_b;
        public System.Windows.Forms.GroupBox group_box_login;
        private System.Windows.Forms.TextBox txt_pass;
        private System.Windows.Forms.Label label6;
    }
}