using DictionaryAppForIT.API;
using DictionaryAppForIT.Class;
using DictionaryAppForIT.DTO;
using DictionaryAppForIT.DTO.Account;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace DictionaryAppForIT.Forms
{
    public partial class frmSignUp : Form
    {
        private readonly HttpClient client = new HttpClient();
        private readonly string apiUrl = BaseUrl.base_url;
        string gioiTinh;
        public frmSignUp()
        {
            InitializeComponent();
        }

        #region Main button
        private void btnMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        #endregion

        #region Hiện và ẩn Mật khẩu
        private void btnEyesOpen1_Click(object sender, EventArgs e)
        {
            if (txtMatKhauDK.PasswordChar == '\0')
            {
                btnEyesClose1.BringToFront();
                txtMatKhauDK.PasswordChar = '●';
            }
        }

        private void btnEyesClose1_Click(object sender, EventArgs e)
        {
            if (txtMatKhauDK.PasswordChar == '●')
            {
                btnEyesOpen1.BringToFront();
                txtMatKhauDK.PasswordChar = '\0';
            }
        }

        private void btnEyesOpen2_Click(object sender, EventArgs e)
        {
            if (txtNhapLaiMatKhauDK.PasswordChar == '\0')
            {
                btnEyesClose2.BringToFront();
                txtNhapLaiMatKhauDK.PasswordChar = '●';
            }
        }
        private void btnEyesClose2_Click(object sender, EventArgs e)
        {
            if (txtNhapLaiMatKhauDK.PasswordChar == '●')
            {
                btnEyesOpen2.BringToFront();
                txtNhapLaiMatKhauDK.PasswordChar = '\0';
            }
        }
        #endregion

        #region Xử lý đăng ký

        private bool checkUserName(string username)
        {
            if (username.Length < 1 && username.Length >= 26)
            {
                return false;
            }
            return true;
        }
        private bool checkMatKhau(string account) // check mat khau
        {
            return Regex.IsMatch(account, "^[a-zA-Z0-9]{8,24}$");
        }

        private bool checkEmail(string email) // check tai khoan va mat khau
        {
            return Regex.IsMatch(email, @"^[a-zA-Z0-9_.]{3,20}@gmail.com(.vn|)$");
        }
        private async void btnDangKy_Click(object sender, EventArgs e)
        {
            if (!chkThoaThuan.Checked)
            {
                RJMessageBox.Show("Bạn phải đồng ý các điều khoản mà chúng tôi đưa ra.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            try
            {
                string email = txtEmailDK.Text.Trim();
                string tenDangNhap = txtTenDangNhapDK.Text.Trim();
                string matkhau = txtMatKhauDK.Text.Trim();
                string nhaplaiMK = txtNhapLaiMatKhauDK.Text.Trim();

                if (!checkUserName(tenDangNhap)) { RJMessageBox.Show("Tên người dùng tối đa 26 ký tự!!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
                if (!checkEmail(email)) { RJMessageBox.Show("Emai không đúng định dạng!!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
                if (!checkMatKhau(matkhau)) { RJMessageBox.Show("Mật khẩu từ 8 đến 24 ký tự! từ a-z hoặc A-Z hoặc 0-9.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
                if (matkhau != nhaplaiMK) { RJMessageBox.Show("Mật khẩu không khớp!!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
                if (rdNam.Checked) { gioiTinh = "1"; }
                if (rdNu.Checked) { gioiTinh = "2"; }
                if (rdKhac.Checked) { gioiTinh = "3"; }

                var requestData = new Dictionary<string, string>
                {
                        { "name", txtTenDangNhapDK.Text.Trim() },
                        { "email", txtEmailDK.Text.Trim() },
                        { "gender", gioiTinh },
                        { "password", txtMatKhauDK.Text.Trim() }
                };

                //gửi request
                var response = await client.PostAsync(apiUrl + "register", new FormUrlEncodedContent(requestData));
                var responseContent = await response.Content.ReadAsStringAsync();

                var apiResponse = JsonConvert.DeserializeObject<ApiResponse<AccountResponse>>(responseContent);

                if (apiResponse.Status && apiResponse.Data != null)
                {
                    RJMessageBox.Show(apiResponse.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                    frmLogin frmLogin = new frmLogin();
                    frmLogin.Show();
                }
                else
                {
                    RJMessageBox.Show(apiResponse.Message, "Lỗi rồi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                RJMessageBox.Show(ex.Message, "Lỗi rồi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion
    }
}
