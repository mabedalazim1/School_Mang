
namespace School_Mang.PL.MAIN
{
    partial class FRM_NATEG
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
            this.pn_home.ForeColor = System.Drawing.Color.Black;
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
            this.label5.Location = new System.Drawing.Point(1001, 109);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(357, 62);
            this.label5.TabIndex = 6;
            this.label5.Text = "التقييمات والنتائج";
            // 
            // FRM_NATEG
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(37F, 82F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1370, 749);
            this.Controls.Add(this.pn_home);
            this.Font = new System.Drawing.Font("LBC", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(18, 18, 18, 18);
            this.Name = "FRM_NATEG";
            this.Text = "FRM_NATEG";
            this.pn_home.ResumeLayout(false);
            this.pn_home.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.Panel pn_home;
        private System.Windows.Forms.Label label5;
    }
}