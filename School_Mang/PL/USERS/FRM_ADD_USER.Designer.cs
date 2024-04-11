
namespace School_Mang.PL.USERS
{
    partial class FRM_ADD_USER
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FRM_ADD_USER));
            this.panel4 = new System.Windows.Forms.Panel();
            this.label11 = new System.Windows.Forms.Label();
            this.pn_top = new System.Windows.Forms.Panel();
            this.btn_close = new DevExpress.XtraEditors.SimpleButton();
            this.group_box_login = new System.Windows.Forms.GroupBox();
            this.txt_pass = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txt_user_id = new System.Windows.Forms.TextBox();
            this.txt_role_permissions_id = new System.Windows.Forms.TextBox();
            this.txt_user_role_id = new System.Windows.Forms.TextBox();
            this.txt_user = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.chk_amlin = new System.Windows.Forms.CheckBox();
            this.chk_maliat = new System.Windows.Forms.CheckBox();
            this.chk_takimat = new System.Windows.Forms.CheckBox();
            this.chk_talba = new System.Windows.Forms.CheckBox();
            this.chk_admin = new System.Windows.Forms.CheckBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btn_add_user = new Bunifu.Framework.UI.BunifuThinButton2();
            this.btn_cancel = new Bunifu.Framework.UI.BunifuThinButton2();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.chk_all_prem = new System.Windows.Forms.CheckBox();
            this.chk_some_perm = new System.Windows.Forms.CheckBox();
            this.chk_read = new System.Windows.Forms.CheckBox();
            this.pn_top.SuspendLayout();
            this.group_box_login.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.panel4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel4.Location = new System.Drawing.Point(0, 531);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(579, 10);
            this.panel4.TabIndex = 61;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("LBC", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.White;
            this.label11.Location = new System.Drawing.Point(224, 12);
            this.label11.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(130, 25);
            this.label11.TabIndex = 46;
            this.label11.Text = "إضافة مستخدم";
            // 
            // pn_top
            // 
            this.pn_top.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.pn_top.Controls.Add(this.btn_close);
            this.pn_top.Controls.Add(this.label11);
            this.pn_top.Dock = System.Windows.Forms.DockStyle.Top;
            this.pn_top.Location = new System.Drawing.Point(0, 0);
            this.pn_top.Name = "pn_top";
            this.pn_top.Size = new System.Drawing.Size(579, 50);
            this.pn_top.TabIndex = 60;
            this.pn_top.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pn_top_MouseDown);
            this.pn_top.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pn_top_MouseMove);
            this.pn_top.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pn_top_MouseUp);
            // 
            // btn_close
            // 
            this.btn_close.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btn_close.ImageOptions.Image = global::School_Mang.Properties.Resources.close_w;
            this.btn_close.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.btn_close.Location = new System.Drawing.Point(10, 12);
            this.btn_close.Name = "btn_close";
            this.btn_close.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light;
            this.btn_close.Size = new System.Drawing.Size(34, 33);
            this.btn_close.TabIndex = 11;
            this.btn_close.TabStop = false;
            this.btn_close.Click += new System.EventHandler(this.btn_close_Click);
            // 
            // group_box_login
            // 
            this.group_box_login.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.group_box_login.Controls.Add(this.txt_pass);
            this.group_box_login.Controls.Add(this.label6);
            this.group_box_login.Controls.Add(this.txt_user_id);
            this.group_box_login.Controls.Add(this.txt_role_permissions_id);
            this.group_box_login.Controls.Add(this.txt_user_role_id);
            this.group_box_login.Controls.Add(this.txt_user);
            this.group_box_login.Controls.Add(this.label9);
            this.group_box_login.Font = new System.Drawing.Font("LBC", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.group_box_login.ForeColor = System.Drawing.Color.DarkGray;
            this.group_box_login.Location = new System.Drawing.Point(25, 65);
            this.group_box_login.Name = "group_box_login";
            this.group_box_login.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.group_box_login.Size = new System.Drawing.Size(531, 156);
            this.group_box_login.TabIndex = 62;
            this.group_box_login.TabStop = false;
            this.group_box_login.Text = "بيانات المستخدم";
            // 
            // txt_pass
            // 
            this.txt_pass.Font = new System.Drawing.Font("LBC", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_pass.Location = new System.Drawing.Point(50, 90);
            this.txt_pass.MaxLength = 50;
            this.txt_pass.Name = "txt_pass";
            this.txt_pass.Size = new System.Drawing.Size(269, 32);
            this.txt_pass.TabIndex = 1;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("LBC", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.label6.Location = new System.Drawing.Point(324, 93);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(86, 22);
            this.label6.TabIndex = 5;
            this.label6.Text = "كلمة المرور";
            // 
            // txt_user_id
            // 
            this.txt_user_id.Font = new System.Drawing.Font("LBC", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_user_id.Location = new System.Drawing.Point(457, 118);
            this.txt_user_id.MaxLength = 50;
            this.txt_user_id.Name = "txt_user_id";
            this.txt_user_id.Size = new System.Drawing.Size(68, 32);
            this.txt_user_id.TabIndex = 0;
            this.txt_user_id.Visible = false;
            // 
            // txt_role_permissions_id
            // 
            this.txt_role_permissions_id.Font = new System.Drawing.Font("LBC", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_role_permissions_id.Location = new System.Drawing.Point(457, 82);
            this.txt_role_permissions_id.MaxLength = 50;
            this.txt_role_permissions_id.Name = "txt_role_permissions_id";
            this.txt_role_permissions_id.Size = new System.Drawing.Size(68, 32);
            this.txt_role_permissions_id.TabIndex = 0;
            this.txt_role_permissions_id.Visible = false;
            // 
            // txt_user_role_id
            // 
            this.txt_user_role_id.Font = new System.Drawing.Font("LBC", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_user_role_id.Location = new System.Drawing.Point(457, 44);
            this.txt_user_role_id.MaxLength = 50;
            this.txt_user_role_id.Name = "txt_user_role_id";
            this.txt_user_role_id.Size = new System.Drawing.Size(68, 32);
            this.txt_user_role_id.TabIndex = 0;
            this.txt_user_role_id.Visible = false;
            // 
            // txt_user
            // 
            this.txt_user.Font = new System.Drawing.Font("LBC", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_user.Location = new System.Drawing.Point(50, 44);
            this.txt_user.MaxLength = 50;
            this.txt_user.Name = "txt_user";
            this.txt_user.Size = new System.Drawing.Size(269, 32);
            this.txt_user.TabIndex = 0;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("LBC", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.label9.Location = new System.Drawing.Point(324, 47);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(113, 22);
            this.label9.TabIndex = 5;
            this.label9.Text = "اسم المستخدم";
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.groupBox1.Controls.Add(this.chk_amlin);
            this.groupBox1.Controls.Add(this.chk_maliat);
            this.groupBox1.Controls.Add(this.chk_takimat);
            this.groupBox1.Controls.Add(this.chk_talba);
            this.groupBox1.Controls.Add(this.chk_admin);
            this.groupBox1.Font = new System.Drawing.Font("LBC", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.Color.DarkGray;
            this.groupBox1.Location = new System.Drawing.Point(25, 227);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.groupBox1.Size = new System.Drawing.Size(531, 121);
            this.groupBox1.TabIndex = 62;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "الأقسام";
            // 
            // chk_amlin
            // 
            this.chk_amlin.AutoSize = true;
            this.chk_amlin.Font = new System.Drawing.Font("LBC", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chk_amlin.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.chk_amlin.Location = new System.Drawing.Point(173, 79);
            this.chk_amlin.Name = "chk_amlin";
            this.chk_amlin.Size = new System.Drawing.Size(119, 25);
            this.chk_amlin.TabIndex = 64;
            this.chk_amlin.Text = "شئون العاملين";
            this.chk_amlin.UseVisualStyleBackColor = true;
            this.chk_amlin.CheckedChanged += new System.EventHandler(this.chk_amlin_CheckedChanged);
            // 
            // chk_maliat
            // 
            this.chk_maliat.AutoSize = true;
            this.chk_maliat.Font = new System.Drawing.Font("LBC", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chk_maliat.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.chk_maliat.Location = new System.Drawing.Point(356, 79);
            this.chk_maliat.Name = "chk_maliat";
            this.chk_maliat.Size = new System.Drawing.Size(76, 25);
            this.chk_maliat.TabIndex = 65;
            this.chk_maliat.Text = "الماليات";
            this.chk_maliat.UseVisualStyleBackColor = true;
            this.chk_maliat.CheckedChanged += new System.EventHandler(this.chk_maliat_CheckedChanged);
            // 
            // chk_takimat
            // 
            this.chk_takimat.AutoSize = true;
            this.chk_takimat.Font = new System.Drawing.Font("LBC", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chk_takimat.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.chk_takimat.Location = new System.Drawing.Point(52, 37);
            this.chk_takimat.Name = "chk_takimat";
            this.chk_takimat.Size = new System.Drawing.Size(88, 25);
            this.chk_takimat.TabIndex = 66;
            this.chk_takimat.Text = "التقييمات";
            this.chk_takimat.UseVisualStyleBackColor = true;
            this.chk_takimat.CheckedChanged += new System.EventHandler(this.chk_takimat_CheckedChanged);
            // 
            // chk_talba
            // 
            this.chk_talba.AutoSize = true;
            this.chk_talba.Font = new System.Drawing.Font("LBC", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chk_talba.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.chk_talba.Location = new System.Drawing.Point(179, 37);
            this.chk_talba.Name = "chk_talba";
            this.chk_talba.Size = new System.Drawing.Size(113, 25);
            this.chk_talba.TabIndex = 67;
            this.chk_talba.Text = "شئون الطلاب";
            this.chk_talba.UseVisualStyleBackColor = true;
            this.chk_talba.CheckedChanged += new System.EventHandler(this.chk_talba_CheckedChanged);
            // 
            // chk_admin
            // 
            this.chk_admin.AutoSize = true;
            this.chk_admin.Font = new System.Drawing.Font("LBC", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chk_admin.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.chk_admin.Location = new System.Drawing.Point(331, 37);
            this.chk_admin.Name = "chk_admin";
            this.chk_admin.Size = new System.Drawing.Size(101, 25);
            this.chk_admin.TabIndex = 63;
            this.chk_admin.Text = "مدير النظام";
            this.chk_admin.UseVisualStyleBackColor = true;
            this.chk_admin.CheckedChanged += new System.EventHandler(this.chk_admin_CheckedChanged);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.btn_add_user);
            this.panel1.Controls.Add(this.btn_cancel);
            this.panel1.Location = new System.Drawing.Point(20, 460);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(536, 58);
            this.panel1.TabIndex = 62;
            // 
            // btn_add_user
            // 
            this.btn_add_user.ActiveBorderThickness = 1;
            this.btn_add_user.ActiveCornerRadius = 20;
            this.btn_add_user.ActiveFillColor = System.Drawing.Color.SeaGreen;
            this.btn_add_user.ActiveForecolor = System.Drawing.Color.White;
            this.btn_add_user.ActiveLineColor = System.Drawing.Color.SeaGreen;
            this.btn_add_user.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btn_add_user.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_add_user.BackgroundImage")));
            this.btn_add_user.ButtonText = "إضافة";
            this.btn_add_user.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_add_user.Font = new System.Drawing.Font("LBC", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_add_user.ForeColor = System.Drawing.Color.SeaGreen;
            this.btn_add_user.IdleBorderThickness = 1;
            this.btn_add_user.IdleCornerRadius = 20;
            this.btn_add_user.IdleFillColor = System.Drawing.Color.WhiteSmoke;
            this.btn_add_user.IdleForecolor = System.Drawing.Color.SeaGreen;
            this.btn_add_user.IdleLineColor = System.Drawing.Color.SeaGreen;
            this.btn_add_user.Location = new System.Drawing.Point(380, 5);
            this.btn_add_user.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btn_add_user.Name = "btn_add_user";
            this.btn_add_user.Size = new System.Drawing.Size(139, 50);
            this.btn_add_user.TabIndex = 2;
            this.btn_add_user.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btn_add_user.Click += new System.EventHandler(this.btn_add_user_Click);
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
            // groupBox2
            // 
            this.groupBox2.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.groupBox2.Controls.Add(this.chk_all_prem);
            this.groupBox2.Controls.Add(this.chk_some_perm);
            this.groupBox2.Controls.Add(this.chk_read);
            this.groupBox2.Font = new System.Drawing.Font("LBC", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.ForeColor = System.Drawing.Color.DarkGray;
            this.groupBox2.Location = new System.Drawing.Point(25, 354);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.groupBox2.Size = new System.Drawing.Size(531, 93);
            this.groupBox2.TabIndex = 62;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "الصلاحيات";
            // 
            // chk_all_prem
            // 
            this.chk_all_prem.AutoSize = true;
            this.chk_all_prem.Font = new System.Drawing.Font("LBC", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chk_all_prem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.chk_all_prem.Location = new System.Drawing.Point(331, 45);
            this.chk_all_prem.Name = "chk_all_prem";
            this.chk_all_prem.Size = new System.Drawing.Size(120, 25);
            this.chk_all_prem.TabIndex = 63;
            this.chk_all_prem.Text = "صلاحيات كاملة";
            this.chk_all_prem.UseVisualStyleBackColor = true;
            this.chk_all_prem.CheckedChanged += new System.EventHandler(this.chk_all_prem_CheckedChanged);
            // 
            // chk_some_perm
            // 
            this.chk_some_perm.AutoSize = true;
            this.chk_some_perm.Font = new System.Drawing.Font("LBC", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chk_some_perm.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.chk_some_perm.Location = new System.Drawing.Point(182, 45);
            this.chk_some_perm.Name = "chk_some_perm";
            this.chk_some_perm.Size = new System.Drawing.Size(138, 25);
            this.chk_some_perm.TabIndex = 67;
            this.chk_some_perm.Text = "صلاحيات محدودة";
            this.chk_some_perm.UseVisualStyleBackColor = true;
            this.chk_some_perm.CheckedChanged += new System.EventHandler(this.chk_some_perm_CheckedChanged);
            // 
            // chk_read
            // 
            this.chk_read.AutoSize = true;
            this.chk_read.Font = new System.Drawing.Font("LBC", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chk_read.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.chk_read.Location = new System.Drawing.Point(58, 45);
            this.chk_read.Name = "chk_read";
            this.chk_read.Size = new System.Drawing.Size(101, 25);
            this.chk_read.TabIndex = 66;
            this.chk_read.Text = "اطلاع فقط";
            this.chk_read.UseVisualStyleBackColor = true;
            this.chk_read.CheckedChanged += new System.EventHandler(this.chk_read_CheckedChanged);
            // 
            // FRM_ADD_USER
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(579, 541);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.group_box_login);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.pn_top);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FRM_ADD_USER";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "FRM_ADD_USER";
            this.pn_top.ResumeLayout(false);
            this.pn_top.PerformLayout();
            this.group_box_login.ResumeLayout(false);
            this.group_box_login.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Panel pn_top;
        private DevExpress.XtraEditors.SimpleButton btn_close;
        public System.Windows.Forms.GroupBox group_box_login;
        private System.Windows.Forms.Label label6;
        public System.Windows.Forms.TextBox txt_user;
        private System.Windows.Forms.Label label9;
        public System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Panel panel1;
        private Bunifu.Framework.UI.BunifuThinButton2 btn_add_user;
        private Bunifu.Framework.UI.BunifuThinButton2 btn_cancel;
        public System.Windows.Forms.GroupBox groupBox2;
        public System.Windows.Forms.TextBox txt_pass;
        public System.Windows.Forms.CheckBox chk_amlin;
        public System.Windows.Forms.CheckBox chk_maliat;
        public System.Windows.Forms.CheckBox chk_takimat;
        public System.Windows.Forms.CheckBox chk_talba;
        public System.Windows.Forms.CheckBox chk_admin;
        public System.Windows.Forms.CheckBox chk_all_prem;
        public System.Windows.Forms.CheckBox chk_some_perm;
        public System.Windows.Forms.CheckBox chk_read;
        public System.Windows.Forms.TextBox txt_role_permissions_id;
        public System.Windows.Forms.TextBox txt_user_role_id;
        public System.Windows.Forms.TextBox txt_user_id;
    }
}