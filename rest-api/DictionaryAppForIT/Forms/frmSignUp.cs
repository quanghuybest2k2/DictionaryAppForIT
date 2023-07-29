using DictionaryAppForIT.Class;
using DictionaryAppForIT.DAL;
using DictionaryAppForIT.DTO;
using System;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Net.Http;
using System.Threading.Tasks;
using System.Collections.Generic;
using DictionaryAppForIT.API;

namespace DictionaryAppForIT.Forms
{
    public partial class frmSignUp : Form
    {
        private readonly string apiUrl = BaseUrl.base_url + "register";
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
            else
            {
                try
                {
                    string email = txtEmailDK.Text.Trim();
                    string tenDangNhap = txtTenDangNhapDK.Text.Trim();
                    string matkhau = txtMatKhauDK.Text;
                    string nhaplaiMK = txtNhapLaiMatKhauDK.Text;
                    if (!checkEmail(email)) { RJMessageBox.Show("Emai không đúng định dạng!!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
                    if (!checkMatKhau(matkhau)) { RJMessageBox.Show("Mật khẩu từ 8 đến 24 ký tự! từ a-z hoặc A-Z hoặc 0-9.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
                    if (matkhau != nhaplaiMK) { RJMessageBox.Show("Mật khẩu không khớp!!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
                    if (rdNam.Checked) { gioiTinh = "1"; }
                    if (rdNu.Checked) { gioiTinh = "2"; }
                    if (rdKhac.Checked) { gioiTinh = "3"; }

                    var httpClient = new HttpClient();
                    var requestBody = new Dictionary<string, string>
                    {
                        { "name", txtTenDangNhapDK.Text.Trim() },
                        { "email", txtEmailDK.Text.Trim() },
                        { "gender", gioiTinh },
                        { "password", txtMatKhauDK.Text }
                    };

                    var content = new FormUrlEncodedContent(requestBody);

                    var response = await httpClient.PostAsync(apiUrl, content);
                    var responseContent = await response.Content.ReadAsStringAsync();

                    if (response.IsSuccessStatusCode)
                    {
                        RJMessageBox.Show("Đăng ký thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                        frmLogin frmLogin = new frmLogin();
                        frmLogin.Show();
                    }
                    else
                    {
                        RJMessageBox.Show("Đăng ký không thành công!", "Lỗi rồi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    RJMessageBox.Show("Lỗi khi gọi API: " + ex.Message, "Lỗi rồi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }
        #endregion
    }
}
