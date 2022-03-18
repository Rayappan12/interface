using CellCounter_New.Model;
using Newtonsoft.Json;
using NigDiagnostics.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CellCounter_New
{
    public partial class frmLogin : Form
    {
        Users users = new Users();
        bool _IsLoginSuccess = false;

        public frmLogin()
        {
            InitializeComponent();
        }
        private bool ValidateLoginCredentials()
        {

            bool IsValidated = true;
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text.Trim();
            if (string.IsNullOrEmpty(username))
            {
                IsValidated = false;
            }
            if (string.IsNullOrEmpty(password))
            {
                IsValidated = false;
            }

            //TO DO : Show login validation message
            if (!IsValidated)
            {
                lblErrorTxt.Text = "Please Enter Username && Password";
                lblErrorTxt.Visible = true;
            }

            return IsValidated;
        }

        private void EnableDisableInputs(bool IsDisable)
        {
            txtUsername.Enabled = IsDisable;
            txtPassword.Enabled = IsDisable;
            btnSubmit.Enabled = IsDisable;
            btnCancel.Enabled = IsDisable;
            pcLoader.Visible = !IsDisable;
        }
        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if (ValidateLoginCredentials())
            {
                EnableDisableInputs(false);
                bwLoader.RunWorkerAsync();
            }
        }
        private async Task<bool> ValidateCredentialsUsingAPI()
        {
            try
            {
                var body = new List<KeyValuePair<string, string>>
                {
                    new KeyValuePair<string, string>("email", txtUsername.Text),
                    new KeyValuePair<string, string>("password", txtPassword.Text)
                };
                string baseAddress = GetAppSettingsKey.GetAppSettingValue("ApiBaseAddress");
                HttpResponseMessage response = await APIHelper.LoginAsync(baseAddress, APIConstants.Login, new FormUrlEncodedContent(body));
                if (response.IsSuccessStatusCode)
                {
                    Root root = JsonConvert.DeserializeObject<Root>(response.Content.ReadAsStringAsync().Result);
                    if (root != null)
                    {
                        UserData.name = root.lab_profile.name;
                        UserData.access_token = root.access_token;
                        return true;
                    }
                    else
                    {
                        lblErrorTxt.Text = "Incorrect credentials."+Environment.NewLine+" Please enter valid credentials.";
                        lblErrorTxt.Visible = true;
                    }
                }
                else
                {
                    lblErrorTxt.Text = "Incorrect credentials." + Environment.NewLine + " Please enter valid credentials.";
                    lblErrorTxt.Visible = true;
                }
                return false;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            var IsValidLogin = ValidateCredentialsUsingAPI().Result;
            if (IsValidLogin)
            {
                _IsLoginSuccess = true;
            }
            else
            {
                _IsLoginSuccess = false;
            }
        }
        public static bool Isconnected = false;

        public static bool CheckForInternetConnection()
        {
            try
            {
                Ping myPing = new Ping();
                String host = "google.com";
                byte[] buffer = new byte[32];
                int timeout = 10000;
                PingOptions pingOptions = new PingOptions();
                PingReply reply = myPing.Send(host, timeout, buffer, pingOptions);
                if (reply.Status == IPStatus.Success)
                {
                    return true;
                }
                else if (reply.Status == IPStatus.TimedOut)
                {
                    return Isconnected;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            bool Isconnect = CheckForInternetConnection();
            if (_IsLoginSuccess)
            {
                frmMainMenu frmMainMenu = new frmMainMenu();
                frmMainMenu.Show();
                Hide();
            }
            else
            {
                if (Isconnect == false)
                {
                    lblErrorTxt.Text = "Please Check Your Internet Connection!";
                    lblErrorTxt.Visible = true;
                }
                else if (!_IsLoginSuccess)
                {
                    lblErrorTxt.Text = "Incorrect credentials." + Environment.NewLine + " Please enter valid credentials.";
                    lblErrorTxt.Visible = true;
                }
            }
            EnableDisableInputs(true);
        }

        private void txtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (ValidateLoginCredentials())
                {
                    EnableDisableInputs(false);
                    bwLoader.RunWorkerAsync();
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            lblErrorTxt.Visible = false;
        }
    }
}
