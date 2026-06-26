using DevExpress.Xpo.Logger.Transport;
using Org.BouncyCastle.Crypto.Tls;
using System;
using System.Drawing;
using System.Net;
using System.Windows.Forms;

namespace School_Mang.PL.Controls
{
    public partial class UC_EnvironmentIndicator : UserControl
    {
        private Timer blink = new Timer();
        private Panel pnlDot;
        private Label lblServer;
        private Label lblText;
        private bool state = false;
        private readonly ToolTip _toolTip = new ToolTip();
        private bool _isServerMode;

        public UC_EnvironmentIndicator()
        {
            InitializeComponent();

            this.Load += UC_EnvironmentIndicator_Load;

            blink.Interval = 500;
            blink.Tick += Blink_Tick;
            blink.Start();
        }

        public void SetServerName(string name)
        {
            lblServer.Text = name;
        }
        // =========================
        // LOAD
        // =========================
        private void UC_EnvironmentIndicator_Load(object sender, EventArgs e)
        {
            MakeCircle(pnlDot);

            RefreshServerInfo();
        }

        public void RefreshServerInfo()
        {
            lblServer.Text = Properties.Settings.Default.Server_Name;

            _isServerMode = IsServerMode();

            if (_isServerMode)
            {
                lblServer.ForeColor = Color.LimeGreen;
                lblText.ForeColor = Color.Red;
                lblText.Text = "متصل";
            }
            else
            {
                lblServer.ForeColor = Color.LimeGreen;
                lblServer.Text = "السيرفر المحلي";
                lblText.Text = "";
            }

            _toolTip.SetToolTip(
                this,
                _isServerMode ? "Server Mode" : "Development Mode");
        }
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                blink?.Stop();
                blink?.Dispose();
                _toolTip?.Dispose();
            }

            base.Dispose(disposing);
        }

        // =========================
        // BLINK
        // =========================
        private void Blink_Tick(object sender, EventArgs e)
        {
            state = !state;
            pnlDot.BackColor = state ? Color.LimeGreen : Color.DarkGreen;
        }

        // =========================
        // SERVER CHECK
        // =========================
        private bool IsServerMode()
        {
            string server = Properties.Settings.Default.Server_Name;

            if (string.IsNullOrWhiteSpace(server))
                return false;

            string host = server.Split('\\')[0];

            return IPAddress.TryParse(host, out _);
        }

        // =========================
        // MAKE CIRCLE
        // =========================
        private void MakeCircle(Control c)
        {
            if (c == null) return;

            using (var gp = new System.Drawing.Drawing2D.GraphicsPath())
            {
                gp.AddEllipse(0, 0, c.Width - 1, c.Height - 1);
                c.Region = new Region(gp);
            }
        }

        private void InitializeComponent()
        {
            this.pnlDot = new System.Windows.Forms.Panel();
            this.lblServer = new System.Windows.Forms.Label();
            this.lblText = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // pnlDot
            // 
            this.pnlDot.Location = new System.Drawing.Point(61, 22);
            this.pnlDot.Name = "pnlDot";
            this.pnlDot.Size = new System.Drawing.Size(12, 12);
            this.pnlDot.TabIndex = 1;
            // 
            // lblServer
            // 
            this.lblServer.AutoSize = true;
            this.lblServer.Font = new System.Drawing.Font("LBC", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblServer.Location = new System.Drawing.Point(77, 16);
            this.lblServer.Name = "lblServer";
            this.lblServer.Size = new System.Drawing.Size(61, 21);
            this.lblServer.TabIndex = 2;
            this.lblServer.Text = "label1";
            // 
            // lblText
            // 
            this.lblText.AutoSize = true;
            this.lblText.Font = new System.Drawing.Font("LBC", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblText.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.lblText.Location = new System.Drawing.Point(214, 16);
            this.lblText.Name = "lblText";
            this.lblText.Size = new System.Drawing.Size(53, 21);
            this.lblText.TabIndex = 3;
            this.lblText.Text = "سيرفر";
            // 
            // UC_EnvironmentIndicator
            // 
            this.Controls.Add(this.lblText);
            this.Controls.Add(this.lblServer);
            this.Controls.Add(this.pnlDot);
            this.Name = "UC_EnvironmentIndicator";
            this.Size = new System.Drawing.Size(271, 39);
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}
