
namespace School_Mang.RPT
{
    partial class FRM_REPORTS
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
            this.pn_top = new System.Windows.Forms.Panel();
            this.btn_min = new DevExpress.XtraEditors.SimpleButton();
            this.btn_max = new DevExpress.XtraEditors.SimpleButton();
            this.lbl_caption = new System.Windows.Forms.Label();
            this.btn_close = new DevExpress.XtraEditors.SimpleButton();
            this.panel4 = new System.Windows.Forms.Panel();
            this.crystalReportViewer1 = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.pn_top.SuspendLayout();
            this.SuspendLayout();
            // 
            // pn_top
            // 
            this.pn_top.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.pn_top.Controls.Add(this.btn_min);
            this.pn_top.Controls.Add(this.btn_max);
            this.pn_top.Controls.Add(this.btn_close);
            this.pn_top.Controls.Add(this.lbl_caption);
            this.pn_top.Dock = System.Windows.Forms.DockStyle.Top;
            this.pn_top.Location = new System.Drawing.Point(0, 0);
            this.pn_top.Name = "pn_top";
            this.pn_top.Size = new System.Drawing.Size(1027, 50);
            this.pn_top.TabIndex = 73;
            this.pn_top.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.pn_top_MouseDoubleClick);
            this.pn_top.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pn_top_MouseDown);
            this.pn_top.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pn_top_MouseMove);
            this.pn_top.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pn_top_MouseUp);
            // 
            // btn_min
            // 
            this.btn_min.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btn_min.ImageOptions.Image = global::School_Mang.Properties.Resources.minimize_w;
            this.btn_min.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.btn_min.Location = new System.Drawing.Point(91, 7);
            this.btn_min.Name = "btn_min";
            this.btn_min.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light;
            this.btn_min.Size = new System.Drawing.Size(39, 37);
            this.btn_min.TabIndex = 48;
            this.btn_min.Click += new System.EventHandler(this.btn_min_Click);
            // 
            // btn_max
            // 
            this.btn_max.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btn_max.ImageOptions.Image = global::School_Mang.Properties.Resources.maximize_w;
            this.btn_max.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.btn_max.Location = new System.Drawing.Point(52, 7);
            this.btn_max.Name = "btn_max";
            this.btn_max.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light;
            this.btn_max.Size = new System.Drawing.Size(39, 37);
            this.btn_max.TabIndex = 47;
            this.btn_max.Click += new System.EventHandler(this.btn_max_Click);
            // 
            // lbl_caption
            // 
            this.lbl_caption.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lbl_caption.AutoSize = true;
            this.lbl_caption.Font = new System.Drawing.Font("LBC", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_caption.ForeColor = System.Drawing.Color.White;
            this.lbl_caption.Location = new System.Drawing.Point(384, 13);
            this.lbl_caption.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.lbl_caption.Name = "lbl_caption";
            this.lbl_caption.Size = new System.Drawing.Size(259, 25);
            this.lbl_caption.TabIndex = 46;
            this.lbl_caption.Text = "بيانات العام الدراسى 2021-2022";
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
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.panel4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel4.Location = new System.Drawing.Point(0, 636);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(1027, 10);
            this.panel4.TabIndex = 74;
            // 
            // crystalReportViewer1
            // 
            this.crystalReportViewer1.ActiveViewIndex = -1;
            this.crystalReportViewer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crystalReportViewer1.Cursor = System.Windows.Forms.Cursors.Default;
            this.crystalReportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.crystalReportViewer1.Location = new System.Drawing.Point(0, 50);
            this.crystalReportViewer1.Name = "crystalReportViewer1";
            this.crystalReportViewer1.ShowGotoPageButton = false;
            this.crystalReportViewer1.Size = new System.Drawing.Size(1027, 586);
            this.crystalReportViewer1.TabIndex = 75;
            this.crystalReportViewer1.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
            this.crystalReportViewer1.Load += new System.EventHandler(this.crystalReportViewer1_Load);
            // 
            // FRM_REPORTS
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(1027, 646);
            this.Controls.Add(this.crystalReportViewer1);
            this.Controls.Add(this.pn_top);
            this.Controls.Add(this.panel4);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FRM_REPORTS";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "تقرير";
            this.pn_top.ResumeLayout(false);
            this.pn_top.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pn_top;
        private DevExpress.XtraEditors.SimpleButton btn_close;
        private System.Windows.Forms.Panel panel4;
        public CrystalDecisions.Windows.Forms.CrystalReportViewer crystalReportViewer1;
        private DevExpress.XtraEditors.SimpleButton btn_min;
        private DevExpress.XtraEditors.SimpleButton btn_max;
        public System.Windows.Forms.Label lbl_caption;
    }
}