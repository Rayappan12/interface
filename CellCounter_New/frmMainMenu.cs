using CellCounter_New.Model;
using log4net;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CellCounter_New
{
    public partial class frmMainMenu : Form
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(frmMainMenu));

        public string txtIPAddress = "";
        public int txtPort = 0;
        public string txtFilePath = "";
        public int ClearDataLength = 500;

        string fileName = "cellcounter.txt";
        string folderName = "NigDignosticSolutionManager";
        string GuarnteedWritePath = System.Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData);
        public frmMainMenu()
        {
            InitializeComponent();
        }

        private void toolStripLabel1_Click(object sender, EventArgs e)
        {
            var frmConfigPage = new frmConfig();
            frmConfigPage.Show();
        }

        private void toolStripLabel2_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to exit the application", "Exit Application", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Application.ExitThread();
                Application.Exit();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {            
            lblStatus.Text = "Start the progress";
            txtIPAddress = Properties.Settings.Default.IPAddress;
            txtPort = Convert.ToInt32(Properties.Settings.Default.Port);
            txtFilePath = Properties.Settings.Default.FilePath;
            ClearDataLength = Properties.Settings.Default.ClearData;

            log.Info("Application Started");
            backgroundWorker1.RunWorkerAsync();
            toolStripLabel2.Text = string.Format("Logged in : {0}", UserData.name);

            panel1.Controls.Clear();
            frmReport frmCellCounter = new frmReport();
            frmCellCounter.TopLevel = false;
            frmCellCounter.MdiParent = this;
            panel1.Controls.Add(frmCellCounter);
            frmCellCounter.Show();
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                var main = new OurSimpleMultiThreadedMllpHl7ServerNew();
                main.GeneralMessageHandler += new OurSimpleMultiThreadedMllpHl7ServerNew.GeneralMessageUpdateHandler(WriteGeneralMessage);
                main.StartOurTcpServer(txtIPAddress, txtPort);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                log.Error("Error this data process thread process", ex);
                Application.ExitThread();
                Application.Exit();
            }
        }

        private void WriteGeneralMessage(object sender, GeneralMessageUpdateEventArgs e)
        {
            this.lblStatus.Text = e.Messages;
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            try
            {
                lblStatus.Text = "Process Completed";                
                log.Info("Application Process Exited");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                log.Error("backgroundWorker Exited", ex);
                System.Windows.Forms.Application.ExitThread();
                System.Windows.Forms.Application.Exit();
            }
        }
        
        private void toolStripReports_Click(object sender, EventArgs e)
        {
            panel1.Controls.Clear();
            frmReport frmCellCounter = new frmReport();
            frmCellCounter.TopLevel = false;
            frmCellCounter.MdiParent = this;
            panel1.Controls.Add(frmCellCounter);
            frmCellCounter.Show();
        }
        private void ClearExistingData()
        {
            string folder = Path.Combine(GuarnteedWritePath, folderName);
            string file = Path.Combine(GuarnteedWritePath, folderName, fileName);
            FileInfo info = new FileInfo(file);
            try
            {
                if (!Directory.Exists(folder))
                {
                    Directory.CreateDirectory(folder);
                }

                if (!File.Exists(file))
                {
                    File.Create(file);
                }
                info.Refresh();
                if (info.CreationTime <= DateTime.Now.AddDays(-1))
                {
                    info.Delete();
                    Directory.Delete(folder);
                    Directory.CreateDirectory(folder);
                    File.Create(file);
                }

            }
            catch (IOException)
            {
                throw;
            }
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            ClearExistingData();
        }
    }
}
