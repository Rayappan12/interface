using CellCounter_New.Model;
using Newtonsoft.Json;
using NigDiagnostics.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Sockets;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Windows.Forms;
using static CellCounter_New.Model.TestResult;

namespace CellCounter_New
{
    public partial class frmReport : Form
    {
        #region variables
        string baseAddress = GetAppSettingsKey.GetAppSettingValue("ApiBaseAddress");
        int count;
        private bool _IsLoginSuccess;
        private bool uncheckedAll = false;
        List<PatientDetails> _patientDetails = new List<PatientDetails>();
        List<Testdetail> _testdetails = new List<Testdetail>();
        List<PatientTestFieldList> _PatientTestFieldLists = new List<PatientTestFieldList>();
        List<StoreTestResults> _storeTestResults = new List<StoreTestResults>();
        HttpResponseMessage _reportCreate = new HttpResponseMessage();
        List<MachineReport> _machineReports = new List<MachineReport>();
        SampleBarcode _barcode = new SampleBarcode();
        string _fileName = "cellcounter.txt";
        string _folderName = "NigDignosticSolutionManager";
        string _GuarnteedWritePath = System.Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData);
        DataTable dt = new DataTable();
        #endregion

        public frmReport()
        {
            InitializeComponent();
            DataGridViewDesignHelper.DesignDataGridView(dgvTestReports);
            DataGridViewDesignHelper.DesignDataGridView(dataGridView1);
            //IPAddress[] localIP = Dns.GetHostAddresses(Dns.GetHostName());      //Vai buscar o IP do computador

            //foreach (IPAddress address in localIP)
            //{
            //    if (address.AddressFamily == AddressFamily.InterNetwork) // se o Ip corresponder com o IPv4 vai aparecer na txtbox o ip da maquina
            //    {
            //        txtSearch.Text = address.ToString();
            //    }
            //}
        }
        private void frmReport_Load(object sender, EventArgs e)
        {
            MachineReports();
            txtBillId.Focus();
            EnableDisableInputs(true);
        }

        private async Task<bool> TestDetailsBySample()
        {
            try
            {
                string SampleBarcodeId = "";  // MUST set the Regex result to a variable for it to take effect
                SampleBarcodeId = Regex.Replace(txtBillId.Text = _barcode.Barcode, @"\s+", "");
                var body = new List<KeyValuePair<string, string>>
                    {
                        new KeyValuePair<string, string>("bill_id", SampleBarcodeId)
                    };
                HttpResponseMessage response = await APIHelper.PostMethodAsync(baseAddress, APIConstants.TestDetailsBySampleId, new FormUrlEncodedContent(body), UserData.access_token);
                if (response.IsSuccessStatusCode)
                {
                    var sampleDetailsObjects = JsonConvert.DeserializeObject<RootOne>(response.Content.ReadAsStringAsync().Result);
                    if (sampleDetailsObjects != null)
                    {
                        _patientDetails = sampleDetailsObjects.patient_details.Where(x => x.patient_id > 0).ToList();
                        _testdetails = sampleDetailsObjects.testdetails.Where(x => x.bill_id > 0).ToList();
                        return true;
                    }
                }
                else
                {
                    ClearInputs();
                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        Status _Status = new Status();

        public async Task<bool> SessionTimeout()
        {
            try
            {
                //string token = "eyJ0eXAiOiJKV1QiLCJhbGciOiJIUzI1NiJ9.eyJpc3MiOiJodHRwOlwvXC9hcGkubmlnc29mdC5jb206ODA4MFwvYXBpXC9hdXRoXC9sb2dpbiIsImlhdCI6MTY0NTYxMjg3NSwiZXhwIjoxNjQ1NjE2NDc1LCJuYmYiOjE2NDU2MTI4NzUsImp0aSI6ImozN284d0h3c2pYWEJ4aWsiLCJzdWIiOjQzOCwicHJ2IjoiODdlMGFmMWVmOWZkMTU4MTJmZGVjOTcxNTNhMTRlMGIwNDc1NDZhYSJ9.ykpcJKmercwqySMv4z734krqUj9oCEB5jjz9Wj2MCy8";
                HttpResponseMessage response = await APIHelper.GetMethodAsync(baseAddress, APIConstants.TestFieldList, UserData.access_token);

                if (response.IsSuccessStatusCode)
                {
                    var sessionTimeout = JsonConvert.DeserializeObject<Status>(response.Content.ReadAsStringAsync().Result);
                    if (sessionTimeout != null)
                    {
                        _Status = sessionTimeout;
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }        

        public async void FetchTestFieldReportFromNigsoftApi()
        {
            try
            {
                HttpResponseMessage response = await APIHelper.GetMethodAsync(baseAddress, APIConstants.TestFieldList, UserData.access_token);
                if (response.IsSuccessStatusCode)
                {
                    var PatientTestFieldList = JsonConvert.DeserializeObject<List<PatientTestFieldList>>(response.Content.ReadAsStringAsync().Result);
                    if (PatientTestFieldList != null)
                    {
                        _PatientTestFieldLists = PatientTestFieldList.Where(x => x.field_id > 0).ToList();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Invalid exception occured on patient profile information binding");
            }
        }

        private async Task FetchPatientInformationFromNigSoft()
        {
            try
            {
                //Patient Details
                var billData = _patientDetails.FirstOrDefault(x => x.patient_id.ToString() != null);
                if (billData != null)
                {
                    txtPatientName.Text = billData.name;
                    txtAge.Text = billData.age;
                    txtGender.Text = billData.gender;
                    txtDOB.Text = billData.dob;
                }
                else
                {
                    MessageBox.Show(string.Format("Bill ID {0} is not found.", txtBillId.Text), "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtPatientName.Text = "";
                    txtAge.Text = "";
                    txtGender.Text = "";
                    txtDOB.Text = "";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void MachineReports()
        {
            string folder = Path.Combine(_GuarnteedWritePath, _folderName);
            string path = Path.Combine(_GuarnteedWritePath, _folderName, _fileName);
            string json = File.ReadAllText(path);
            List<GridReports.Roots> Orders = JsonExtensions.FromDelimitedJson<GridReports.Roots>(new StringReader(json)).ToList();
            if (Orders.Count > 0)
            {
                foreach (var item in Orders)
                {
                    if (item.GridViewObject != null)
                    {
                        var TestReport = item.GridViewObject.Select(i => new { i.first_name, i.last_name, i.PID }).FirstOrDefault();
                        if (TestReport != null)
                        {
                            _machineReports.Add(new MachineReport()
                            {
                                name = TestReport.first_name + TestReport.last_name,
                                barcode = TestReport.PID
                            });

                            ListtoDataTableConverter converter = new ListtoDataTableConverter();
                            dt = converter.ToDataTable(_machineReports);
                            dataGridView1.DataSource = dt;
                        }
                    }
                }
            }
        }

        private void PatientTestResultFromJson()
        {
            string folder = Path.Combine(_GuarnteedWritePath, _folderName);
            string path = Path.Combine(_GuarnteedWritePath, _folderName, _fileName);

            string json = File.ReadAllText(path);
            List<GridReports.Roots> Orders = JsonExtensions.FromDelimitedJson<GridReports.Roots>(new StringReader(json)).ToList();

            var testone = Orders.Where(x => x.barcode == txtBillId.Text).FirstOrDefault();

            if (testone != null) 
            {
                if (testone.GridViewObject!=null)
                {
                    foreach (var item in testone.GridViewObject.ToList())
                    {
                        var fname = item.first_name;
                        var lname = item.last_name;
                        if (fname == lname)
                        {
                            txtBillPatientName.Text = fname;
                        }
                        else
                        {
                            txtBillPatientName.Text = item.first_name + " " + item.last_name;
                        }
                        txtBillAge.Text = item.age;
                        txtBarcode.Text = item.PID;
                        txtBillGender.Text = item.Gender;
                        txtBillTestTime.Text = item.MshDate;

                        var ListOfTest = _testdetails.Where(x => x.test_id > 0).ToList();
                        foreach (var TestList in ListOfTest)
                        {
                            var TestData = _PatientTestFieldLists.Where(x => x.test_id == TestList.test_id).ToList();
                            if (TestData.Count > 0)
                            {
                                foreach (var items in TestData)
                                {
                                    foreach (var shortname in item.test_details)
                                    {
                                        if (shortname.test_name == items.test_short_name)
                                        {
                                            var gender = _patientDetails.Select(x => x.gender).FirstOrDefault();
                                            if (gender.ToLower() == items.gender.ToLower() || items.gender.ToLower() == "all" || gender.ToLower() == null)
                                            {
                                                _storeTestResults.Add(new StoreTestResults()
                                                {
                                                    field_name = items.field_name,
                                                    test_result = shortname.test_result,
                                                    min_range = items.min_range,
                                                    max_range = items.max_range,
                                                    units = items.units,
                                                    test_field_name = shortname.test_name,
                                                    test_id = items.test_id.ToString(),
                                                    Test_name_nigsoft = TestList.test_name
                                                });
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                    Gridview();
                    _storeTestResults.Clear();   
                }             
            }
            else
            {
                MessageBox.Show("Test Results is Empty.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearInputs();
            }
        }

        private void Gridview()
        {
            var TestResults = _storeTestResults.Where(x => x.test_id != null).ToList();

            if (TestResults.Count > 0)
            {
                foreach (var Result in TestResults)
                {
                    count++;
                    int m = dgvTestReports.Rows.Add();
                    dgvTestReports.Rows[m].Cells[0].Value = false;
                    dgvTestReports.Rows[m].Cells[1].Value = Result.field_name;
                    if (Result.test_field_name == "WBC" || Result.test_field_name == "NEU#" || Result.test_field_name == "LYM#" || Result.test_field_name == "EOS#"
                        || Result.test_field_name == "MON#" || Result.test_field_name == "BAS#")
                    {
                        dgvTestReports.Rows[m].Cells[2].Value = Sum(Convert.ToDouble(Result.test_result));
                    }
                    else if (Result.test_field_name == "PLT")
                    {
                        dgvTestReports.Rows[m].Cells[2].Value = Div(Convert.ToDouble(Result.test_result));
                    }
                    else
                    {
                        dgvTestReports.Rows[m].Cells[2].Value = Result.test_result;
                    }
                    dgvTestReports.Rows[m].Cells[3].Value = Result.min_range;
                    dgvTestReports.Rows[m].Cells[4].Value = Result.max_range;
                    dgvTestReports.Rows[m].Cells[5].Value = Result.units;
                    dgvTestReports.Rows[m].Cells[6].Value = Result.test_field_name;
                    dgvTestReports.Rows[m].Cells[7].Value = Result.test_id;
                    dgvTestReports.Rows[m].Cells[8].Value = Result.Test_name_nigsoft;
                    //dgvTestReports.EnableHeadersVisualStyles = true;
                    dgvTestReports.AllowUserToAddRows = false;
                    dgvTestReports.RowHeadersVisible = false;

                }
            }
        }

        private double Sum(double value)
        {
            return value * 1000;
        }

        private double Div(double PLT)
        {
            return PLT / 100;
        }

        private void ClearInputs()
        {
            txtBillId.Text = "";
            txtPatientName.Text = "";
            txtAge.Text = "";
            txtGender.Text = "";
            txtDOB.Text = "";
            txtBarcode.Text = "";
            txtBillPatientName.Text = "";
            txtBillAge.Text = "";
            txtBillGender.Text = "";
            txtBillTestTime.Text = "";
            dgvTestReports.DataSource = null;
            dgvTestReports.Refresh();
            dgvTestReports.Rows.Clear();
            txtBillId.Focus();
            _PatientTestFieldLists.Clear();
        }

        private bool _IsKeyExpired;

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            var TimeoutResult = SessionTimeout().Result;
            if (!TimeoutResult)
            {
                var IsvalidBillId = TestDetailsBySample().Result;

                if (IsvalidBillId)
                {
                    _IsLoginSuccess = true;
                }
                else
                {
                    _IsLoginSuccess = false;
                }
                _IsKeyExpired = true;
            }
            else
            {
                _IsKeyExpired = false;
            }
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (_IsKeyExpired)
            {
                if (_IsLoginSuccess)
                {
                    FetchPatientInformationFromNigSoft();
                    FetchTestFieldReportFromNigsoftApi();
                    PatientTestResultFromJson();
                }
                else
                {
                    MessageBox.Show("Incorrect Bill id. Please scan valid Bill id.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ClearInputs();
                }
                EnableDisableInputs(true);
            }
            else
            {
                //Logout();
                if (_Status.status == "Token is Expired")
                {
                    LogoutApplication();
                }
            }
            EnableDisableInputs(false);
        }

        private void LogoutApplication()
        {
            List<Form> openForms = new List<Form>();

            foreach (Form f in Application.OpenForms)
                openForms.Add(f);

            foreach (Form f in openForms)
            {
                if (f.Name != "frmLogin")
                {
                    f.Close();
                }
                else
                {
                    frmLogin login = new frmLogin();
                    login.Show();
                }
            }
        }

        private void EnableDisableInputs(bool IsDisable)
        {
            txtBillId.Enabled = IsDisable;
            PcLoader.Visible = !IsDisable;
        }

        private void txtBillId_TextChanged(object sender, EventArgs e)
        {
            if (txtBillId.Text.Length >= 8 && txtBillId.Text.Length < 20)
            {
                FetchTestFieldReportFromNigsoftApi();
                EnableDisableInputs(false);
                backgroundWorker1.RunWorkerAsync();
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                for (int i = 0; i < dgvTestReports.RowCount; i++)
                {
                    dgvTestReports[0, i].Value = true;
                }
            }
            else
            {
                if (uncheckedAll)
                {
                    for (int i = 0; i < dgvTestReports.RowCount; i++)
                    {
                        dgvTestReports[0, i].Value = false;
                    }
                }
            }
            uncheckedAll = true;
        }

        private async void BindingTestResultsAsync()
        {
            try
            {
                if (btnSubmit.InvokeRequired)
                {
                    btnSubmit.Invoke(new Action(BindingTestResultsAsync));
                    return;
                }
                if (ValidateInputs())
                {
                    btnSubmit.Enabled = false;
                    if (_testdetails != null)
                    {
                        List<CellCounterTestResults> cellCounterTestResults = new List<CellCounterTestResults>();
                        foreach (DataGridViewRow row in dgvTestReports.Rows)
                        {
                            if (row.Cells[0].Value != null || ((bool)dgvTestReports.SelectedRows[0].Cells[0].Value != false))
                            {
                                if ((bool)row.Cells[0].Value == true)
                                {
                                    cellCounterTestResults.Add(new CellCounterTestResults()
                                    {
                                        test_id = row.Cells[7].Value.ToString(),
                                        test_name = row.Cells[1].Value.ToString(),
                                        test_value = row.Cells[2].Value.ToString(),
                                        test_short_name = row.Cells[6].Value.ToString(),
                                    });
                                }
                            }
                        }
                        if (cellCounterTestResults.Count > 0)
                        {
                            List<CCTestRecord> cCTestRecords = new List<CCTestRecord>();
                            var ListOfTest = _testdetails.Where(x => x.test_id > 0).ToList();
                            foreach (var items in ListOfTest)
                            {
                                var testData = _PatientTestFieldLists.Where(x => x.test_id == items.test_id).ToList();
                                if (testData != null)
                                {
                                    var MatchedTestId = cellCounterTestResults.Where(x => testData.Any(y => y.test_id.ToString() == x.test_id)).ToList();
                                    foreach (var fieldList in MatchedTestId)
                                    {
                                        cCTestRecords.Add(new CCTestRecord()
                                        {
                                            test_name = fieldList.test_name,
                                            test_value = fieldList.test_value,
                                            test_short_name = fieldList.test_short_name
                                        });
                                    }
                                    if (cCTestRecords.Count > 0)
                                    {
                                        CellCounterRecordCreate recordCreates = new CellCounterRecordCreate();
                                        recordCreates.test_id = items.test_id.ToString();
                                        recordCreates.bill_id = items.bill_id.ToString();
                                        recordCreates.patient_id = _patientDetails.FirstOrDefault().patient_id.ToString(); ;
                                        recordCreates.group_id = items.group_id.ToString();
                                        recordCreates.department_id = items.department;
                                        recordCreates.test_result = cCTestRecords;
                                        string content = JsonConvert.SerializeObject(recordCreates);
                                        string baseAddress = GetAppSettingsKey.GetAppSettingValue("ApiBaseAddress");
                                        HttpResponseMessage _reportCreate = await APIHelper.PostMethodAsync(baseAddress, APIConstants.ReportCreate, new StringContent(content, UnicodeEncoding.UTF8, "application/json"), UserData.access_token);
                                        cCTestRecords.Clear();
                                    }
                                }
                            }
                            if (_reportCreate.IsSuccessStatusCode)
                            {
                                MessageBox.Show("Record created.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                ClearInputs();
                                cellCounterTestResults.Clear();
                                checkBox1.Checked = false;
                            }
                            else
                            {
                                MessageBox.Show("Record creation failed.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                        else
                        {
                            MessageBox.Show("Select atleast one test result to proceed", "Information!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    else
                    {
                        MessageBox.Show("No Test results found.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    btnSubmit.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Invalid exception occured on saving tests Report Information", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private bool ValidateInputs()
        {
            bool Isvalidated = true;
            string billId = txtBillId.Text.Trim();
            //int testId = Convert.ToInt32(cmbTestList.SelectedValue);
            int count = dgvTestReports.Rows.Count;
            if (string.IsNullOrEmpty(billId))
            {
                Isvalidated = false;
                MessageBox.Show("Please Scan Patient Bill ID", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            //if (testId == 0)
            //{
            //    Isvalidated = false;
            //    MessageBox.Show("Please choose Test in Patient Information", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //}
            if (count == 0)
            {
                Isvalidated = false;
                MessageBox.Show("No Test results found.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            return Isvalidated;
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                EnableDisableInputs(false);
                backgroundWorker2.RunWorkerAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void backgroundWorker2_DoWork(object sender, DoWorkEventArgs e)
        {
            BindingTestResultsAsync();
        }

        private void backgroundWorker2_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            EnableDisableInputs(true);
        }

        private void btnPatientNameRefresh_Click(object sender, EventArgs e)
        {
            ClearInputs();
        }

        private async void dataGridView1_CellClickAsync(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dataGridView1.SelectedCells.Count > 0)
                {
                    dgvTestReports.DataSource = null;
                    dgvTestReports.Rows.Clear();
                    int selectedrowindex = dataGridView1.SelectedCells[0].RowIndex;
                    DataGridViewRow selectedRow = dataGridView1.Rows[selectedrowindex];
                    _barcode.PatientName = Convert.ToString(selectedRow.Cells["Name"].Value);
                    _barcode.Barcode = selectedRow.Cells["BarCode"].Value.ToString();
                    EnableDisableInputs(false);
                    await TestDetailsBySample();
                    if (!backgroundWorker1.IsBusy)
                    {
                        backgroundWorker1.RunWorkerAsync();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dgvTestReports_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                if ((bool)dgvTestReports.SelectedRows[0].Cells[0].Value == false)
                {
                    dgvTestReports.SelectedRows[0].Cells[0].Value = true;
                }
                else
                {
                    dgvTestReports.SelectedRows[0].Cells[0].Value = false;
                }
                foreach (DataGridViewRow r in dgvTestReports.Rows)
                {
                    if ((bool)r.Cells[0].Value == true)
                    {
                        uncheckedAll = false;
                        break;
                    }
                }
                checkBox1.Checked = false;
            }

            bool check = true;
            foreach (DataGridViewRow r in dgvTestReports.Rows)
            {

                if ((bool)r.Cells[0].Value == false)
                {
                    check = false;
                    break;
                }

            }
            if (check)
            {
                checkBox1.Checked = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            _machineReports.Clear();
            MachineReports();
        }
        
        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            try
            {
                DataView dataView = dt.DefaultView;
                dataView.RowFilter = "Name LIKE '%" + txtSearch.Text + "%'";
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
        }

        private void txtBillGender_TextChanged(object sender, EventArgs e)
        {
            this.txtBillGender.BackColor = System.Drawing.Color.White;
        }
    }
}
