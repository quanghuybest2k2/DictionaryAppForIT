using DictionaryAppForIT.API;
using DictionaryAppForIT.Class;
using DictionaryAppForIT.DTO;
using DictionaryAppForIT.DTO.Account;
using DictionaryAppForIT.Forms;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DictionaryAppForIT
{
    public partial class frmLogin : Form
    {
        private readonly HttpClient client = new HttpClient();
        private readonly string apiUrl = BaseUrl.base_url;

        public frmLogin()
        {
            InitializeComponent();
            this.AcceptButton = btnDangNhap;
        }
        private bool checkUserData()
        {
            if (!string.IsNullOrEmpty(Properties.Settings.Default.displayUsername) &&
             !string.IsNullOrEmpty(Properties.Settings.Default.IdTaiKhoan) &&
             !string.IsNullOrEmpty(Properties.Settings.Default.ngayTaoTK) &&
             !string.IsNullOrEmpty(Properties.Settings.Default.Token) &&
             !string.IsNullOrEmpty(Properties.Settings.Default.Role))
            {
                // có tồn tại
                return true;
            }
            else
            {
                return false;
            }
        }
        private void frmLogin_Load(object sender, EventArgs e)
        {
            if (checkUserData())
            {
                frmMain mainForm = new frmMain();
                mainForm.ShowDialog();
                this.Hide();
            }
        }

        #region Main button
        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
        #endregion

        #region xử lý con mắt ở mật khẩu
        private void btnEyesOpen_Click(object sender, EventArgs e)
        {
            if (txtMatKhauDN.PasswordChar == '\0')
            {
                btnEyesClose.BringToFront();
                txtMatKhauDN.PasswordChar = '●';
            }
        }

        private void btnEyesClose_Click(object sender, EventArgs e)
        {
            if (txtMatKhauDN.PasswordChar == '●')
            {
                btnEyesOpen.BringToFront();
                txtMatKhauDN.PasswordChar = '\0';
            }
        }
        #endregion

        #region Xử lý đăng nhập
        private async Task Login(string email, string password)
        {
            var requestData = new Dictionary<string, string>
                {
                        { "email", email },
                        { "password", password }
                };

            //gửi request
            var response = await client.PostAsync(apiUrl + "login", new FormUrlEncodedContent(requestData));
            var responseContent = await response.Content.ReadAsStringAsync();

            var apiResponse = JsonConvert.DeserializeObject<ApiResponse<LoginResponse>>(responseContent);

            if (apiResponse.Status && apiResponse.Data != null)
            {
                var loginResponse = apiResponse.Data;
                // lưu dữ liệu của user
                UserData.SaveUserDataSetting(loginResponse.username,
                   loginResponse.user_id,
                   loginResponse.created_at,
                   loginResponse.token,
                   loginResponse.role
                    );

                frmMain frmMain = new frmMain();
                this.Hide();
                frmMain.Show();
            }
            else
            {
                ErrorResponse.HandleErrors(apiResponse);
                //if (apiResponse.Errors != null)
                //{
                //    var errors = JsonConvert.DeserializeObject<Dictionary<string, List<string>>>(apiResponse.Errors.ToString());
                //    string errorMessage = "";
                //    foreach (KeyValuePair<string, List<string>> errorPair in errors)
                //    {
                //        errorMessage += errorPair.Value[0] + "\n";
                //    }

                //    RJMessageBox.Show(errorMessage, "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //}
                //else
                //{
                //    RJMessageBox.Show(apiResponse.Message, "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //}
            }
        }

        private async void btnDangNhap_Click(object sender, EventArgs e)
        {
            try
            {
                string email = txtTaiKhoanDN.Text.Trim();
                string password = txtMatKhauDN.Text.Trim();
                //if (string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(password))
                //{
                //    RJMessageBox.Show("Bạn phải điền email và mật khẩu!");
                //}
                await Login(email, password);
                // lưu user data
                //UserData.SaveUserDataSetting();
            }
            catch (Exception ex)
            {
                RJMessageBox.Show(ex.Message);
            }
        }
        #endregion

        #region Xử lý các sự kiện
        private void lblDangKyNgay_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmSignUp frmSign = new frmSignUp();
            frmSign.Show();
        }

        private void txtTaiKhoanDN_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
            }
        }

        private void txtMatKhauDN_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
            }
        }
        #endregion
    }
}
