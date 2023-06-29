using Guna;
using DictionaryAppForIT.Class;
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
using System.Configuration;
using System.Data.SqlClient;

namespace DictionaryAppForIT.UserControls.TaiKhoan
{
    public partial class UC_QuanLyTK : UserControl
    {
        private string connString = ConfigurationManager.ConnectionStrings["DictionaryApp"].ConnectionString;

        private int tgSuDung = 0;
        public UC_QuanLyTK()
        {
            InitializeComponent();
        }
        #region Xử lý richtextbox đổi màu chữ

        public string SoMuc
        {
            get { return lblSoMucTest.Text; }
            set { lblSoMucTest.Text = value; }
        }


        private void ThoiGianTaoTaiKhoan()
        {
            DateTime hienTai = DateTime.Now;
            DateTime end = new DateTime(2021, 09, 10);

            RichTextBox rtb1 = new RichTextBox();
            rtb1.Font = new System.Drawing.Font("Segoe UI", 10F);
            rtb1.SelectionColor = Color.Gray;
            rtb1.AppendText(" Bạn đã tạo tài khoản được ");
            rtb1.SelectionColor = ColorTranslator.FromHtml("#3776ab");
            // tinh toan ngay tao tai khoan
            string ngayTao = Class_TaiKhoan.ngayTaoTK;
            DateTime date = DateTime.ParseExact(ngayTao, "dd/MM/yyyy", null);
            TimeSpan soNgayTaoTK = hienTai - date; // số ngày tạo tài khoản
            rtb1.AppendText(soNgayTaoTK.ToString(@"dd"));
            rtb1.SelectionColor = Color.Gray;
            rtb1.AppendText(" ngày");
            rtb1.Size = new System.Drawing.Size(242, 23);
            rtb1.Location = new Point(69, 29);
            rtb1.Name = "rtxtThoiGianTaoTK";
            rtb1.BorderStyle = BorderStyle.None;
            rtb1.ReadOnly = true;
            rtb1.BackColor = System.Drawing.Color.LemonChiffon;
            panelThoiGianTao.Controls.Add(rtb1);
        }
        private void ThoiGianSuDung()
        {
            RichTextBox rtb1 = new RichTextBox();
            rtb1.Font = new System.Drawing.Font("Segoe UI", 10F);
            rtb1.SelectionColor = Color.Gray;
            rtb1.AppendText("Hôm nay bạn đã sử dụng từ điển trong ");
            rtb1.SelectionColor = ColorTranslator.FromHtml("#3776ab");
            rtb1.AppendText(tgSuDung.ToString());
            rtb1.SelectionColor = Color.Gray;
            rtb1.AppendText(" tiếng đồng hồ");
            rtb1.Size = new System.Drawing.Size(242, 43);
            rtb1.Location = new Point(72, 26);
            rtb1.Name = "rtxtThoiGianSuDung";
            rtb1.BorderStyle = BorderStyle.None;
            rtb1.ReadOnly = true;
            rtb1.BackColor = System.Drawing.Color.LemonChiffon;
            panelThoiGianSuDung.Controls.Add(rtb1);
        }
        #endregion
        private void btnXoaTaiKhoan_Click(object sender, EventArgs e)
        {
            var result = RJMessageBox.Show("Bạn có thực sự muốn xóa tài khoản này vĩnh viễn?",
                "Xác nhận xóa tài khoản",
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                // xóa tài khoản
                try
                {
                    string queryXoaLSDich = $"Delete from LichSuDich where IDTK = '{Class_TaiKhoan.IdTaiKhoan}'";
                    string queryXoaLSTraTu = $"Delete from LichSuTraTu where IDTK = '{Class_TaiKhoan.IdTaiKhoan}'";
                    string queryXoaYTTuVung = $"Delete from YeuThichTuVung where IDTK = '{Class_TaiKhoan.IdTaiKhoan}'";
                    string queryXoaYTVanBan = $"Delete from YeuThichVanBan where IDTK = '{Class_TaiKhoan.IdTaiKhoan}'";
                    string queryXoaTK = $"Delete from TaiKhoan where ID = '{Class_TaiKhoan.IdTaiKhoan}'";

                    int num1 = DataProvider.Instance.ExecuteNonQuery(queryXoaLSDich);
                    int num2 = DataProvider.Instance.ExecuteNonQuery(queryXoaLSTraTu);
                    int num3 = DataProvider.Instance.ExecuteNonQuery(queryXoaYTTuVung);
                    int num4 = DataProvider.Instance.ExecuteNonQuery(queryXoaYTVanBan);
                    int num5 = DataProvider.Instance.ExecuteNonQuery(queryXoaTK);

                    if (num5 > 0)
                    {
                        RJMessageBox.Show("Đã xóa tài khoản vĩnh viễn!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Application.Exit();
                    }
                    else
                    {
                        RJMessageBox.Show("Không thể xóa tài khoản!", "Lỗi rồi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                }
                catch (Exception ex)
                {
                    RJMessageBox.Show(ex.Message);
                }
            }
            if (result == DialogResult.No)
            {
                return;
            }

        }

        private string KTGioiTinh()
        {
            string gt = "";
            if (rdNam.Checked)
            {
                gt = "1";
            }
            else if (rdNu.Checked)
            {
                gt = "2";

            }
            else
            {
                gt = "3";
            }
            return gt;
        }

        private void LuuThayDoiTK_Click(object sender, EventArgs e)
        {
            string query = $"EXEC CapNhatThongTinTaiKhoan '{Class_TaiKhoan.IdTaiKhoan}', '{txtUsername.Text.Trim()}', '{txtPassword.Text.Trim()}', '{txtEmail.Text.Trim()}', '{KTGioiTinh()}'";
            int num = DataProvider.Instance.ExecuteNonQuery(query);
            if (num > 0)
            {
                RJMessageBox.Show("Cập nhật thông tin tài khoản thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                RJMessageBox.Show("Không thể cập nhật tài khoản!", "Lỗi rồi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSuaEmail_Click(object sender, EventArgs e)
        {
            if (btnSuaEmail.Checked)
            {
                txtEmail.ReadOnly = false;
                txtEmail.FillColor = Color.White;
                pbNenEmail1.FillColor = Color.MediumSpringGreen;
                pbNenEmail2.FillColor = Color.MediumSpringGreen;
                btnLuuThayDoiTK.Enabled = true;
            }
            else
            {
                txtEmail.ReadOnly = true;
                txtEmail.FillColor = Color.FromArgb(251, 251, 251);
                pbNenEmail1.FillColor = Color.Tomato;
                pbNenEmail2.FillColor = Color.Tomato;
            }

        }

        private void btnSuaTenDangNhap_Click(object sender, EventArgs e)
        {
            if (btnSuaTenDangNhap.Checked)
            {
                txtUsername.ReadOnly = false;
                txtUsername.FillColor = Color.White;
                pbNenUsername1.FillColor = Color.MediumSpringGreen;
                pbNenUsername2.FillColor = Color.MediumSpringGreen;
                btnLuuThayDoiTK.Enabled = true;
            }
            else
            {
                txtUsername.ReadOnly = true;
                txtUsername.FillColor = Color.FromArgb(251, 251, 251);
                pbNenUsername1.FillColor = Color.Tomato;
                pbNenUsername2.FillColor = Color.Tomato;
            }

        }

        private void btnSuaMatKhau_Click(object sender, EventArgs e)
        {
            if (btnSuaMatKhau.Checked)
            {
                txtPassword.ReadOnly = false;
                txtPassword.FillColor = Color.White;
                pbNenPassword1.FillColor = Color.MediumSpringGreen;
                pbNenPassword2.FillColor = Color.MediumSpringGreen;
                ///
                if (txtPassword.PasswordChar == '●')
                {
                    txtPassword.PasswordChar = '\0';
                }
                btnLuuThayDoiTK.Enabled = true;

            }
            else
            {
                txtPassword.ReadOnly = true;
                txtPassword.FillColor = Color.FromArgb(251, 251, 251);
                pbNenPassword1.FillColor = Color.Tomato;
                pbNenPassword2.FillColor = Color.Tomato;
                ///
                if (txtPassword.PasswordChar == '\0')
                {
                    txtPassword.PasswordChar = '●';
                }
            }
        }

        private void UC_QuanLyTK_Load(object sender, EventArgs e)
        {
            ThoiGianTaoTaiKhoan();
            //SoMucYeuThich();
            ThoiGianSuDung();
            HienThiThongTinTaiKhoan(); // Hiển thị thông tin tài khoản
        }
        private void HienThiThongTinTaiKhoan()
        {
            try
            {
                SqlConnection Conn = new SqlConnection(connString);
                SqlCommand cmd = new SqlCommand($"EXEC HienThiThongTinTaiKhoan '{Class_TaiKhoan.IdTaiKhoan}'", Conn);
                Conn.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    txtUsername.Text = rdr["TenDangNhap"].ToString();
                    txtPassword.Text = rdr["MatKhau"].ToString();
                    txtEmail.Text = rdr["Email"].ToString();
                    object gioiTinh = rdr["GioiTinh"].ToString();
                    if (gioiTinh.ToString() == "1")
                    {
                        rdNam.Checked = true;
                        rdNu.Checked = false;
                        rdKhac.Checked = false;
                    }
                    if (gioiTinh.ToString() == "2")
                    {
                        rdNu.Checked = true;
                        rdNam.Checked = false;
                        rdKhac.Checked = false;
                    }
                    if (gioiTinh.ToString() == "3")
                    {
                        rdKhac.Checked = true;
                        rdNam.Checked = false;
                        rdNu.Checked = false;
                    }
                }
                Conn.Close();
                Conn.Dispose();
            }
            catch (Exception ex)
            {
                RJMessageBox.Show(ex.Message);
            }
        }
    }
}
