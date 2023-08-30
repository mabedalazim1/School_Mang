
namespace School_Mang.PL.MAIN
{
    partial class FRM_BACK_UP
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FRM_BACK_UP));
            this.panel4 = new System.Windows.Forms.Panel();
            this.pn_top = new System.Windows.Forms.Panel();
            this.lbl_title = new System.Windows.Forms.Label();
            this.btn_close = new DevExpress.XtraEditors.SimpleButton();
            this.group_box_login = new System.Windows.Forms.GroupBox();
            this.pic_help = new System.Windows.Forms.PictureBox();
            this.lbl_select = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btn_login = new Bunifu.Framework.UI.BunifuThinButton2();
            this.btn_cancel = new Bunifu.Framework.UI.BunifuThinButton2();
            this.txt_bath = new System.Windows.Forms.TextBox();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.pn_top.SuspendLayout();
            this.group_box_login.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pic_help)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.panel4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel4.Location = new System.Drawing.Point(0, 229);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(491, 10);
            this.panel4.TabIndex = 60;
            // 
            // pn_top
            // 
            this.pn_top.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.pn_top.Controls.Add(this.lbl_title);
            this.pn_top.Controls.Add(this.btn_close);
            this.pn_top.Dock = System.Windows.Forms.DockStyle.Top;
            this.pn_top.ForeColor = System.Drawing.Color.White;
            this.pn_top.Location = new System.Drawing.Point(0, 0);
            this.pn_top.Name = "pn_top";
            this.pn_top.Size = new System.Drawing.Size(491, 43);
            this.pn_top.TabIndex = 59;
            // 
            // lbl_title
            // 
            this.lbl_title.AutoSize = true;
            this.lbl_title.Font = new System.Drawing.Font("LBC", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_title.ForeColor = System.Drawing.Color.White;
            this.lbl_title.Location = new System.Drawing.Point(163, 9);
            this.lbl_title.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.lbl_title.Name = "lbl_title";
            this.lbl_title.Size = new System.Drawing.Size(166, 25);
            this.lbl_title.TabIndex = 45;
            this.lbl_title.Text = "إنشاء نسخة احتياطية";
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
            // group_box_login
            // 
            this.group_box_login.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.group_box_login.Controls.Add(this.pic_help);
            this.group_box_login.Controls.Add(this.lbl_select);
            this.group_box_login.Controls.Add(this.panel1);
            this.group_box_login.Controls.Add(this.txt_bath);
            this.group_box_login.Font = new System.Drawing.Font("LBC", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.group_box_login.ForeColor = System.Drawing.Color.DarkGray;
            this.group_box_login.Location = new System.Drawing.Point(6, 49);
            this.group_box_login.Name = "group_box_login";
            this.group_box_login.Size = new System.Drawing.Size(476, 171);
            this.group_box_login.TabIndex = 61;
            this.group_box_login.TabStop = false;
            // 
            // pic_help
            // 
            this.pic_help.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pic_help.Image = global::School_Mang.Properties.Resources.icons8_edit_100;
            this.pic_help.Location = new System.Drawing.Point(1, 38);
            this.pic_help.Name = "pic_help";
            this.pic_help.Size = new System.Drawing.Size(38, 32);
            this.pic_help.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pic_help.TabIndex = 80;
            this.pic_help.TabStop = false;
            this.pic_help.Click += new System.EventHandler(this.pic_help_Click);
            // 
            // lbl_select
            // 
            this.lbl_select.AutoSize = true;
            this.lbl_select.Font = new System.Drawing.Font("LBC", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_select.ForeColor = System.Drawing.Color.DimGray;
            this.lbl_select.Location = new System.Drawing.Point(370, 42);
            this.lbl_select.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.lbl_select.Name = "lbl_select";
            this.lbl_select.Size = new System.Drawing.Size(101, 25);
            this.lbl_select.TabIndex = 45;
            this.lbl_select.Text = "مسار الحفظ";
            this.lbl_select.Click += new System.EventHandler(this.lbl_select_Click);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.btn_login);
            this.panel1.Controls.Add(this.btn_cancel);
            this.panel1.Location = new System.Drawing.Point(6, 109);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(460, 58);
            this.panel1.TabIndex = 59;
            // 
            // btn_login
            // 
            this.btn_login.ActiveBorderThickness = 1;
            this.btn_login.ActiveCornerRadius = 20;
            this.btn_login.ActiveFillColor = System.Drawing.Color.SeaGreen;
            this.btn_login.ActiveForecolor = System.Drawing.Color.White;
            this.btn_login.ActiveLineColor = System.Drawing.Color.SeaGreen;
            this.btn_login.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btn_login.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_login.BackgroundImage")));
            this.btn_login.ButtonText = "موافق";
            this.btn_login.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_login.Font = new System.Drawing.Font("LBC", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_login.ForeColor = System.Drawing.Color.SeaGreen;
            this.btn_login.IdleBorderThickness = 1;
            this.btn_login.IdleCornerRadius = 20;
            this.btn_login.IdleFillColor = System.Drawing.Color.WhiteSmoke;
            this.btn_login.IdleForecolor = System.Drawing.Color.SeaGreen;
            this.btn_login.IdleLineColor = System.Drawing.Color.SeaGreen;
            this.btn_login.Location = new System.Drawing.Point(310, 7);
            this.btn_login.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btn_login.Name = "btn_login";
            this.btn_login.Size = new System.Drawing.Size(139, 50);
            this.btn_login.TabIndex = 2;
            this.btn_login.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btn_login.Click += new System.EventHandler(this.btn_login_Click);
            // 
            // btn_cancel
            // 
            this.btn_cancel.ActiveBorderThickness = 1;
            this.btn_cancel.ActiveCornerRadius = 20;
            this.btn_cancel.ActiveFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.btn_cancel.ActiveForecolor = System.Drawing.Color.White;
            this.btn_cancel.ActiveLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btn_cancel.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btn_cancel.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_cancel.BackgroundImage")));
            this.btn_cancel.ButtonText = "إلغاء";
            this.btn_cancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_cancel.Font = new System.Drawing.Font("LBC", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_cancel.ForeColor = System.Drawing.Color.Red;
            this.btn_cancel.IdleBorderThickness = 1;
            this.btn_cancel.IdleCornerRadius = 20;
            this.btn_cancel.IdleFillColor = System.Drawing.Color.WhiteSmoke;
            this.btn_cancel.IdleForecolor = System.Drawing.Color.Red;
            this.btn_cancel.IdleLineColor = System.Drawing.Color.Red;
            this.btn_cancel.Location = new System.Drawing.Point(4, 1);
            this.btn_cancel.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btn_cancel.Name = "btn_cancel";
            this.btn_cancel.Size = new System.Drawing.Size(139, 50);
            this.btn_cancel.TabIndex = 3;
            this.btn_cancel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btn_cancel.Click += new System.EventHandler(this.btn_cancel_Click);
            // 
            // txt_bath
            // 
            this.txt_bath.Font = new System.Drawing.Font("LBC", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_bath.Location = new System.Drawing.Point(42, 38);
            this.txt_bath.MaxLength = 50;
            this.txt_bath.Name = "txt_bath";
            this.txt_bath.Size = new System.Drawing.Size(326, 32);
            this.txt_bath.TabIndex = 1;
            this.txt_bath.DoubleClick += new System.EventHandler(this.txt_bath_DoubleClick);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // FRM_BACK_UP
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(491, 239);
            this.Controls.Add(this.group_box_login);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.pn_top);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FRM_BACK_UP";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FRM_BACK_UP";
            this.Load += new System.EventHandler(this.FRM_BACK_UP_Load);
            this.pn_top.ResumeLayout(false);
            this.pn_top.PerformLayout();
            this.group_box_login.ResumeLayout(false);
            this.group_box_login.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pic_help)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel pn_top;
        private System.Windows.Forms.Label lbl_title;
        private DevExpress.XtraEditors.SimpleButton btn_close;
        public System.Windows.Forms.GroupBox group_box_login;
        private System.Windows.Forms.Label lbl_select;
        private System.Windows.Forms.Panel panel1;
        private Bunifu.Framework.UI.BunifuThinButton2 btn_login;
        private Bunifu.Framework.UI.BunifuThinButton2 btn_cancel;
        private System.Windows.Forms.TextBox txt_bath;
        private System.Windows.Forms.PictureBox pic_help;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
    }
}