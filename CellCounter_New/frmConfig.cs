using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using log4net;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Reflection;
using System.IO;

namespace CellCounter_New
{
    public partial class frmConfig : Form
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(frmConfig));
        public frmConfig()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                Properties.Settings.Default.IPAddress = textBox1.Text;
                Properties.Settings.Default.Port =Convert.ToInt32(textBox2.Text);
                Properties.Settings.Default.FilePath = textBox3.Text;
                Properties.Settings.Default.ClearData = Convert.ToInt32(numericUpDown1.Value);
                Properties.Settings.Default.Save();

                MessageBox.Show("Saved Successfully \nAfter Save application need be restart !", "Save Settings", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                log.Info("Save Settings");
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                log.Error("Save Settings", ex);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmConfig_Load(object sender, EventArgs e)
        {
            try
            {
                textBox1.Text = Properties.Settings.Default.IPAddress;
                textBox2.Text = Properties.Settings.Default.Port.ToString();
                textBox3.Text = Properties.Settings.Default.FilePath;
                numericUpDown1.Value = Properties.Settings.Default.ClearData;

                Uri uri = new Uri(Assembly.GetExecutingAssembly().CodeBase);
                string folderPath = Path.GetDirectoryName(uri.LocalPath);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "No Data Found", MessageBoxButtons.OK, MessageBoxIcon.Error);
                log.Error("Load Settings", ex);
            }
        }
    }
}
