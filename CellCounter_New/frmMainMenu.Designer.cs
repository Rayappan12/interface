namespace CellCounter_New
{
    partial class frmMainMenu
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
            this.components = new System.ComponentModel.Container();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripSettings = new System.Windows.Forms.ToolStripButton();
            this.toolStripReports = new System.Windows.Forms.ToolStripButton();
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.lblStatus = new System.Windows.Forms.ToolStripLabel();
            this.toolStripLabel2 = new System.Windows.Forms.ToolStripLabel();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.panel1 = new System.Windows.Forms.Panel();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.toolStrip1.SuspendLayout();
            this.toolStrip2.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackColor = System.Drawing.Color.LightSeaGreen;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripSettings,
            this.toolStripReports});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1040, 63);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripSettings
            // 
            this.toolStripSettings.Font = new System.Drawing.Font("Nirmala UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripSettings.ForeColor = System.Drawing.Color.White;
            this.toolStripSettings.Image = global::CellCounter_New.Properties.Resources.settings;
            this.toolStripSettings.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripSettings.Margin = new System.Windows.Forms.Padding(0, 5, 0, 5);
            this.toolStripSettings.Name = "toolStripSettings";
            this.toolStripSettings.Size = new System.Drawing.Size(62, 53);
            this.toolStripSettings.Text = "Settings";
            this.toolStripSettings.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.toolStripSettings.Click += new System.EventHandler(this.toolStripLabel1_Click);
            // 
            // toolStripReports
            // 
            this.toolStripReports.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripReports.ForeColor = System.Drawing.Color.White;
            this.toolStripReports.Image = global::CellCounter_New.Properties.Resources.report;
            this.toolStripReports.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.toolStripReports.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripReports.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripReports.Margin = new System.Windows.Forms.Padding(0, 5, 0, 5);
            this.toolStripReports.Name = "toolStripReports";
            this.toolStripReports.Size = new System.Drawing.Size(59, 53);
            this.toolStripReports.Text = "Reports";
            this.toolStripReports.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.toolStripReports.Click += new System.EventHandler(this.toolStripReports_Click);
            // 
            // toolStrip2
            // 
            this.toolStrip2.BackColor = System.Drawing.Color.LightSeaGreen;
            this.toolStrip2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblStatus,
            this.toolStripLabel2});
            this.toolStrip2.Location = new System.Drawing.Point(0, 584);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.Size = new System.Drawing.Size(1040, 25);
            this.toolStrip2.TabIndex = 0;
            this.toolStrip2.Text = "toolStrip2";
            // 
            // lblStatus
            // 
            this.lblStatus.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.lblStatus.Font = new System.Drawing.Font("Nirmala UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatus.ForeColor = System.Drawing.Color.White;
            this.lblStatus.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(46, 22);
            this.lblStatus.Text = "Status";
            // 
            // toolStripLabel2
            // 
            this.toolStripLabel2.Font = new System.Drawing.Font("Nirmala UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripLabel2.ForeColor = System.Drawing.Color.White;
            this.toolStripLabel2.Name = "toolStripLabel2";
            this.toolStripLabel2.Size = new System.Drawing.Size(102, 22);
            this.toolStripLabel2.Text = "toolStripLabel2";
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
            // 
            // panel1
            // 
            this.panel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 63);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1040, 521);
            this.panel1.TabIndex = 3;
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // frmMainMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1040, 609);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.toolStrip2);
            this.Controls.Add(this.toolStrip1);
            this.IsMdiContainer = true;
            this.Name = "frmMainMenu";
            this.Text = "Nig Diagnostic v1.0";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Form1_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStrip toolStrip2;
        private System.Windows.Forms.ToolStripLabel lblStatus;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.ToolStripButton toolStripReports;
        private System.Windows.Forms.ToolStripButton toolStripSettings;
        private System.Windows.Forms.ToolStripLabel toolStripLabel2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Timer timer1;
    }
}

