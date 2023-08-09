
namespace School_Mang.PL.MAIN
{
    partial class FRM_HOME
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
            this.pn_home = new System.Windows.Forms.Panel();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.bunifuCards5 = new Bunifu.Framework.UI.BunifuCards();
            this.lbl_age = new System.Windows.Forms.Label();
            this.bunifuCards7 = new Bunifu.Framework.UI.BunifuCards();
            this.lbl_open_calc = new System.Windows.Forms.Label();
            this.pic_age = new System.Windows.Forms.PictureBox();
            this.pic_open_calc = new System.Windows.Forms.PictureBox();
            this.pn_home.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.bunifuCards5.SuspendLayout();
            this.bunifuCards7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pic_age)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_open_calc)).BeginInit();
            this.SuspendLayout();
            // 
            // pn_home
            // 
            this.pn_home.BackColor = System.Drawing.Color.White;
            this.pn_home.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.pn_home.Controls.Add(this.flowLayoutPanel1);
            this.pn_home.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pn_home.Location = new System.Drawing.Point(0, 0);
            this.pn_home.Name = "pn_home";
            this.pn_home.Size = new System.Drawing.Size(1370, 749);
            this.pn_home.TabIndex = 3;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoScroll = true;
            this.flowLayoutPanel1.Controls.Add(this.bunifuCards5);
            this.flowLayoutPanel1.Controls.Add(this.bunifuCards7);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Padding = new System.Windows.Forms.Padding(20);
            this.flowLayoutPanel1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.flowLayoutPanel1.Size = new System.Drawing.Size(1370, 494);
            this.flowLayoutPanel1.TabIndex = 13;
            // 
            // bunifuCards5
            // 
            this.bunifuCards5.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.bunifuCards5.BackColor = System.Drawing.Color.White;
            this.bunifuCards5.BorderRadius = 5;
            this.bunifuCards5.BottomSahddow = true;
            this.bunifuCards5.color = System.Drawing.Color.Tomato;
            this.bunifuCards5.Controls.Add(this.lbl_age);
            this.bunifuCards5.Controls.Add(this.pic_age);
            this.bunifuCards5.LeftSahddow = false;
            this.bunifuCards5.Location = new System.Drawing.Point(1057, 23);
            this.bunifuCards5.Name = "bunifuCards5";
            this.bunifuCards5.Padding = new System.Windows.Forms.Padding(20);
            this.bunifuCards5.RightSahddow = true;
            this.bunifuCards5.ShadowDepth = 20;
            this.bunifuCards5.Size = new System.Drawing.Size(270, 186);
            this.bunifuCards5.TabIndex = 12;
            // 
            // lbl_age
            // 
            this.lbl_age.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lbl_age.AutoSize = true;
            this.lbl_age.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lbl_age.Font = new System.Drawing.Font("LBC", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_age.Location = new System.Drawing.Point(57, 120);
            this.lbl_age.Name = "lbl_age";
            this.lbl_age.Size = new System.Drawing.Size(153, 37);
            this.lbl_age.TabIndex = 7;
            this.lbl_age.Text = "حساب السن";
            this.lbl_age.Click += new System.EventHandler(this.lbl_age_Click);
            // 
            // bunifuCards7
            // 
            this.bunifuCards7.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.bunifuCards7.BackColor = System.Drawing.Color.White;
            this.bunifuCards7.BorderRadius = 5;
            this.bunifuCards7.BottomSahddow = true;
            this.bunifuCards7.color = System.Drawing.Color.Tomato;
            this.bunifuCards7.Controls.Add(this.lbl_open_calc);
            this.bunifuCards7.Controls.Add(this.pic_open_calc);
            this.bunifuCards7.LeftSahddow = false;
            this.bunifuCards7.Location = new System.Drawing.Point(781, 23);
            this.bunifuCards7.Name = "bunifuCards7";
            this.bunifuCards7.Padding = new System.Windows.Forms.Padding(20);
            this.bunifuCards7.RightSahddow = true;
            this.bunifuCards7.ShadowDepth = 20;
            this.bunifuCards7.Size = new System.Drawing.Size(270, 186);
            this.bunifuCards7.TabIndex = 18;
            // 
            // lbl_open_calc
            // 
            this.lbl_open_calc.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lbl_open_calc.AutoSize = true;
            this.lbl_open_calc.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lbl_open_calc.Font = new System.Drawing.Font("LBC", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_open_calc.Location = new System.Drawing.Point(70, 120);
            this.lbl_open_calc.Name = "lbl_open_calc";
            this.lbl_open_calc.Size = new System.Drawing.Size(128, 37);
            this.lbl_open_calc.TabIndex = 7;
            this.lbl_open_calc.Text = "ألة حاسبة";
            this.lbl_open_calc.Click += new System.EventHandler(this.lbl_open_calc_Click);
            // 
            // pic_age
            // 
            this.pic_age.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pic_age.Image = global::School_Mang.Properties.Resources.icons8_age_100;
            this.pic_age.Location = new System.Drawing.Point(74, 23);
            this.pic_age.Name = "pic_age";
            this.pic_age.Size = new System.Drawing.Size(118, 97);
            this.pic_age.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pic_age.TabIndex = 1;
            this.pic_age.TabStop = false;
            this.pic_age.Click += new System.EventHandler(this.pic_age_Click);
            // 
            // pic_open_calc
            // 
            this.pic_open_calc.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pic_open_calc.Image = global::School_Mang.Properties.Resources.calculator_100;
            this.pic_open_calc.Location = new System.Drawing.Point(74, 23);
            this.pic_open_calc.Name = "pic_open_calc";
            this.pic_open_calc.Size = new System.Drawing.Size(118, 97);
            this.pic_open_calc.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pic_open_calc.TabIndex = 1;
            this.pic_open_calc.TabStop = false;
            this.pic_open_calc.Click += new System.EventHandler(this.pic_open_calc_Click);
            // 
            // FRM_HOME
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(37F, 82F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1370, 749);
            this.Controls.Add(this.pn_home);
            this.Font = new System.Drawing.Font("LBC", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(18, 19, 18, 19);
            this.Name = "FRM_HOME";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.Text = "FRM_HOME";
            this.pn_home.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.bunifuCards5.ResumeLayout(false);
            this.bunifuCards5.PerformLayout();
            this.bunifuCards7.ResumeLayout(false);
            this.bunifuCards7.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pic_age)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_open_calc)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        public System.Windows.Forms.Panel pn_home;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private Bunifu.Framework.UI.BunifuCards bunifuCards5;
        private System.Windows.Forms.Label lbl_age;
        public System.Windows.Forms.PictureBox pic_age;
        private Bunifu.Framework.UI.BunifuCards bunifuCards7;
        private System.Windows.Forms.Label lbl_open_calc;
        private System.Windows.Forms.PictureBox pic_open_calc;
    }
}