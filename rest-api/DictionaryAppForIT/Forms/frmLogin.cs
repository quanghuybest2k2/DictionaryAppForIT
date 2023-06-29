using DictionaryAppForIT.API;
using DictionaryAppForIT.Class;
using DictionaryAppForIT.CustomMessageBox;
using DictionaryAppForIT.DTO;
using DictionaryAppForIT.Forms;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DictionaryAppForIT
{
    public partial class frmLogin : Form
    {
        private readonly HttpClient client = new HttpClient();
        private readonly string apiUrl = BaseUrl.base_url + "login";

        public frmLogin()
        {
            InitializeComponent();
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.TenDangNhap != string.Empty)
            {
                txtTaiKhoanDN.Text = Properties.Settings.Default.TenDangNhap;
                txtMatKhauDN.Text = Properties.Settings.Default.MatKhau;
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
        private void LuuMatKhau()
        {
            if (cbLuuDangNhap.Checked == true)
            {
                Properties.Settings.Default.TenDangNhap = txtTaiKhoanDN.Text;
                Properties.Settings.Default.MatKhau = txtMatKhauDN.Text;
                Properties.Settings.Default.Save();
            }
            if (cbLuuDangNhap.Checked == false)
            {
                Properties.Settings.Default.TenDangNhap = "";
                Properties.Settings.Default.MatKhau = "";
                Properties.Settings.Default.Save();
            }
        }

        private async Task Login(string email, string password)
        {
            var formContent = new FormUrlEncodedContent(new[]
            {
                new KeyValuePair<string, string>("email", email),
                new KeyValuePair<string, string>("password", password)
            });

            var response = await client.PostAsync(apiUrl, formContent);
            var responseContent = await response.Content.ReadAsStringAsync();

            if (response.IsSuccessStatusCode)
            {
                var loginResponse = Newtonsoft.Json.JsonConvert.DeserializeObject<LoginResponse>(responseContent);

                var username = loginResponse.Username;
                Class_TaiKhoan.Token = loginResponse.Token;
                var role = loginResponse.Role;
                Class_TaiKhoan.IdTaiKhoan = loginResponse.userId;
                Class_TaiKhoan.ngayTaoTK = loginResponse.created_at;

                frmMain frmMain = new frmMain();
                this.Hide();
                frmMain.Show();
            }
            else
            {
                // Xử lý lỗi
                //RJMessageBox.Show("Đăng nhập thất bại. Mã lỗi HTTP: " + (int)response.StatusCode);
                //RJMessageBox.Show("Nội dung lỗi: " + responseContent);
                var errorResponse = Newtonsoft.Json.JsonConvert.DeserializeObject<dynamic>(responseContent);

                if (errorResponse.validator_errors != null)
                {
                    var errorMessageBuilder = new StringBuilder();
                    var validatorErrors = errorResponse.validator_errors;

                    foreach (var keyValuePair in validatorErrors)
                    {
                        var errorMessages = keyValuePair.Value;

                        errorMessageBuilder.AppendLine($"{errorMessages[0]}");
                    }

                    RJMessageBox.Show(Environment.NewLine + errorMessageBuilder.ToString());
                }
                else if (errorResponse.message != null)
                {
                    var errorMessage = errorResponse.message;
                    RJMessageBox.Show(errorMessage.ToString());
                }
                else
                {
                    RJMessageBox.Show("Đăng nhập thất bại. status code: " + (int)response.StatusCode);
                }
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
            }
            catch (Exception ex)
            {
                RJMessageBox.Show(ex.Message);
            }
            LuuMatKhau();
        }
        private void lblDangKyNgay_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmSignUp frmSign = new frmSignUp();
            frmSign.Show();
        }

        private void txtMatKhauDN_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnDangNhap.PerformClick();
            }
        }
    }
}
