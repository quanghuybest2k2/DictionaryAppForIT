using Bunifu.UI.WinForms;
using DictionaryAppForIT.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.Design;    // Add reference to System.Design
using DictionaryAppForIT.DAL;
using DictionaryAppForIT.DTO;   // Add reference to System.Design
using System.Data.SqlClient;
using System.Xml;
using System.IO;
using DictionaryAppForIT.Class;
using System.Configuration;

namespace DictionaryAppForIT
{
    public partial class frmLogin : Form
    {
        private string connString = ConfigurationManager.ConnectionStrings["DictionaryApp"].ConnectionString;
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
            //Button btn = (Button)sender;
            //MainBtn.DoMaximize(this, btn);
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

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            try
            {
                frmMain frmMain = new frmMain();
                string query = "KiemTraDangNhap @tendangnhap , @matkhau";
                object kq = DataProvider.Instance.ExecuteScalar(query, new object[] { txtTaiKhoanDN.Text.Trim(), txtMatKhauDN.Text.Trim() });
                Class_TaiKhoan.displayUsername = txtTaiKhoanDN.Text;
                int code = Convert.ToInt32(kq);
                if (code == 1)
                {
                    this.Hide();
                    frmMain.Show(); // show form
                }
                else if (code == 2)
                {
                    RJMessageBox.Show("Tài khoản hoặc mật khẩu không đúng !!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtMatKhauDN.Text = "";
                    txtTaiKhoanDN.Text = "";
                    txtTaiKhoanDN.Focus();
                }
                else
                {
                    RJMessageBox.Show("Tài khoản không tồn tại !!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtMatKhauDN.Text = "";
                    txtTaiKhoanDN.Text = "";
                    txtTaiKhoanDN.Focus();
                }
                getIDNguoiDung();
            }
            catch (Exception ex)
            {
                RJMessageBox.Show(ex.Message);
            }
            LuuMatKhau();
        }
        private void getIDNguoiDung()
        {
            try
            {
                SqlConnection Conn = new SqlConnection(connString);
                SqlCommand cmd = new SqlCommand($"SELECT ID FROM TaiKhoan WHERE TenDangNhap = '{Class_TaiKhoan.displayUsername}'", Conn);
                Conn.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    Class_TaiKhoan.IdTaiKhoan = rdr["ID"].ToString();
                }
                Conn.Close();
                Conn.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
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
