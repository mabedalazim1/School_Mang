
namespace School_Mang.PL.MAIN
{
    partial class FRM_MALIAT
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
            this.label5 = new System.Windows.Forms.Label();
            this.pn_home.SuspendLayout();
            this.SuspendLayout();
            // 
            // pn_home
            // 
            this.pn_home.Controls.Add(this.label5);
            this.pn_home.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pn_home.Location = new System.Drawing.Point(0, 0);
            this.pn_home.Name = "pn_home";
            this.pn_home.Size = new System.Drawing.Size(1370, 749);
            this.pn_home.TabIndex = 0;
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("LBC", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(1184, 111);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(174, 62);
            this.label5.TabIndex = 7;
            this.label5.Text = "الماليات";
            // 
            // FRM_MALIAT
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(37F, 82F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1370, 749);
            this.Controls.Add(this.pn_home);
            this.Font = new System.Drawing.Font("LBC", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(18, 19, 18, 19);
            this.Name = "FRM_MALIAT";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.ShowIcon = false;
            this.Text = "FRM_MALIAT";
            this.pn_home.ResumeLayout(false);
            this.pn_home.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label label5;
        public System.Windows.Forms.Panel pn_home;
    }
}