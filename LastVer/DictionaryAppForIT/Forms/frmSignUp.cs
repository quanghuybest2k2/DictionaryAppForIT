using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DictionaryAppForIT.DAL;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
using DictionaryAppForIT.Class;

namespace DictionaryAppForIT.Forms
{
    public partial class frmSignUp : Form
    {
        string gioiTinh;
        public frmSignUp()
        {
            InitializeComponent();

            #region Restyle checkbox Agreement
            chkThoaThuan.Parent = pbLayout;
            chkThoaThuan.Location = new Point(429, 308);
            #endregion
        }

        #region Main button
        private void btnMinimize_Click(object sender, EventArgs e)
        {
            MainBtn.Minnimize(this);
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
        private bool checkUsername(string account) // check username
        {
            return Regex.IsMatch(account, "^[a-zA-Z0-9]{6,15}$");
        }

        private bool checkMatKhau(string account) // check mat khau
        {
            return Regex.IsMatch(account, "^[a-zA-Z0-9]{6,24}$");
        }

        private bool checkEmail(string email) // check tai khoan va mat khau
        {
            return Regex.IsMatch(email, @"^[a-zA-Z0-9_.]{3,20}@gmail.com(.vn|)$");
        }
        private void btnDangKy_Click(object sender, EventArgs e)
        {
            if (!chkThoaThuan.Checked)
            {
                RJMessageBox.Show("Bạn phải đồng ý các điều khoản mà chúng tôi đưa ra.");
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
                    if (!checkEmail(email)) { RJMessageBox.Show("Emai không đúng định dạng!!!"); return; }
                    if (!checkUsername(tenDangNhap)) { RJMessageBox.Show("Tên đăng nhập sai format!!!"); return; }
                    if (!checkMatKhau(matkhau)) { RJMessageBox.Show("Mật khẩu sai format!!!"); return; }
                    if (matkhau != nhaplaiMK) { RJMessageBox.Show("Mật khẩu không khớp!!!"); return; }
                    if (rdNam.Checked) { gioiTinh = "1"; }
                    if (rdNu.Checked) { gioiTinh = "2"; }
                    if (rdKhac.Checked) { gioiTinh = "3"; }
                    //string queryEmail = $"select Email from TaiKhoan where Email = '{email}'";
                    //int numEmail = DataProvider.Instance.ExecuteNonQuery(queryEmail);
                    //if (numEmail > 0) { RJMessageBox.Show("Email đã tồn tại! Vui lòng chọn email khác."); return; }

                    try
                    {
                        string query = "EXEC DangKyTaiKhoan @tendangnhap , @matkhau , @email , @gioitinh";

                        int num = DataProvider.Instance.ExecuteNonQuery(query, new object[] { tenDangNhap, matkhau, email, gioiTinh });
                        if (num > 0)
                        {
                            RJMessageBox.Show("Đăng ký thành công.");
                            this.Hide();
                            frmLogin frmLogin = new frmLogin();
                            frmLogin.Show();
                        }
                    }
                    catch (SqlException ex)
                    {
                        RJMessageBox.Show(ex.Message);
                    }

                }
                catch (Exception ex)
                {
                    RJMessageBox.Show(ex.Message);
                }
            }

        }
        #endregion
    }
}
