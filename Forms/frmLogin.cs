using Bunifu.UI.WinForms;
using DictionaryAppForIT.Forms;
using DictionaryAppForIT.DAL;
using DictionaryAppForIT.DTO;
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
using System.Data.SqlClient;
using System.Xml;
using System.IO;


namespace DictionaryAppForIT
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
            MainBtn.SetInitial(this);
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
            MainBtn.Close(this);
        }

        private void btnMinimize_Click(object sender, EventArgs e)
        {
            //Button btn = (Button)sender;
            //MainBtn.DoMaximize(this, btn);
            MainBtn.Minnimize(this);
        }
        #endregion


        private void lblDangKy_Click(object sender, EventArgs e)
        {
            var form = new frmSignUp();
            if (form.ShowDialog() == DialogResult.Cancel)
            {
            }
        }

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
        private void SaveXml()
        {
            try
            {
                XmlDocument doc = new XmlDocument();
                string filePath = Path.Combine(@"D:\Window Form\DictionaryAppForIT\DTO\SaveUser.xml");
                XmlNode usersNode;
                //XmlNode nodeRole = doc.SelectSingleNode("/Account/User/Role");

                if (File.Exists(filePath))
                {
                    doc.Load(filePath);
                    usersNode = doc.SelectSingleNode("/Account");

                    XmlNodeList NodeLists = doc.SelectNodes("Account/UserName");
                    //XmlNodeList nodelist = doc.GetElementsByTagName("UserName");
                    //foreach (var item in NodeLists)
                    //{

                    //}
                    string username = doc.DocumentElement["User"]["UserName"].InnerText;
                    if (username != txtTaiKhoanDN.Text)
                    {
                        XmlElement user = doc.CreateElement("User");
                        XmlElement userName = doc.CreateElement("UserName");
                        XmlElement pass = doc.CreateElement("Password");
                        userName.InnerText = txtTaiKhoanDN.Text;
                        pass.InnerText = txtMatKhauDN.Text;

                        user.AppendChild(userName);
                        user.AppendChild(pass);
                        usersNode.AppendChild(user);
                        doc.Save(filePath);
                        return;
                    }
                    else
                    {
                        return;
                    }

                }
                else
                {
                    usersNode = doc.CreateElement("/Account");
                    doc.AppendChild(usersNode);

                    XmlElement user = doc.CreateElement("User");
                    XmlElement userName = doc.CreateElement("UserName");
                    XmlElement pass = doc.CreateElement("Password");
                    userName.InnerText = txtTaiKhoanDN.Text;
                    pass.InnerText = txtMatKhauDN.Text;

                    user.AppendChild(userName);
                    user.AppendChild(pass);
                    usersNode.AppendChild(user);
                    doc.Save(filePath);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            try
            {
                frmMain frmMain = new frmMain();
                string query = "KiemTraDangNhap @tendangnhap , @matkhau";
                object kq = DataProvider.Instance.ExecuteScalar(query, new object[] { txtTaiKhoanDN.Text, txtMatKhauDN.Text });
                TaiKhoan.displayUsername = txtTaiKhoanDN.Text;
                int code = Convert.ToInt32(kq);
                if (code == 0)
                {
                    this.Hide();
                    frmMain.Show();
                    //MessageBox.Show("Người dùng " + TenTaiKhoan + " đăng nhập thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (code == 1)
                {
                    this.Hide();
                    frmMain.Show();
                    //MessageBox.Show("Admin " + TenTaiKhoan + " đăng nhập thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (code == 2)
                {
                    MessageBox.Show("Tài khoản hoặc mật khẩu không đúng !!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtMatKhauDN.Text = "";
                    txtTaiKhoanDN.Text = "";
                    txtTaiKhoanDN.Focus();
                }
                else
                {
                    MessageBox.Show("Tài khoản không tồn tại !!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtMatKhauDN.Text = "";
                    txtTaiKhoanDN.Text = "";
                    txtTaiKhoanDN.Focus();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            LuuMatKhau();
            SaveXml();
        }
       
    }
}
