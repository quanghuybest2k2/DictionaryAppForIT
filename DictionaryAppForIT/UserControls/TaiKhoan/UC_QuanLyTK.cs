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
        private int soNgayTao = 365;
        private int soMucYeuThich = 9;
        private int tgSuDung = 2;
        //Class_TaiKhoan TaiKhoan = new Class_TaiKhoan();
        public UC_QuanLyTK()
        {
            InitializeComponent();
        }
        #region Xử lý richtextbox đổi màu chữ
        private void ThoiGianTaoTaiKhoan()
        {
            RichTextBox rtb1 = new RichTextBox();
            rtb1.Font = new System.Drawing.Font("Segoe UI", 10F);
            rtb1.SelectionColor = Color.Gray;
            rtb1.AppendText(" Bạn đã tạo tài khoản được ");
            rtb1.SelectionColor = ColorTranslator.FromHtml("#3776ab");
            rtb1.AppendText(soNgayTao.ToString());
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
        private void SoMucYeuThich()
        {
            RichTextBox rtxtSoMucYeuThich = new RichTextBox();
            rtxtSoMucYeuThich.Font = new System.Drawing.Font("Segoe UI", 10F);
            rtxtSoMucYeuThich.SelectionColor = Color.Gray;
            rtxtSoMucYeuThich.AppendText(" Hiện tại bạn có tất cả ");
            rtxtSoMucYeuThich.SelectionColor = ColorTranslator.FromHtml("#3776ab");
            rtxtSoMucYeuThich.AppendText(soMucYeuThich.ToString());
            rtxtSoMucYeuThich.SelectionColor = Color.Gray;
            rtxtSoMucYeuThich.AppendText(" mục yêu thích");
            rtxtSoMucYeuThich.Size = new System.Drawing.Size(242, 23);
            rtxtSoMucYeuThich.Location = new Point(69, 29);
            rtxtSoMucYeuThich.Name = "rtxtMucYeuThich";
            rtxtSoMucYeuThich.BorderStyle = BorderStyle.None;
            rtxtSoMucYeuThich.ReadOnly = true;
            rtxtSoMucYeuThich.BackColor = System.Drawing.Color.LemonChiffon;
            panelSoMucYeuThich.Controls.Add(rtxtSoMucYeuThich);
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
                MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                // xóa tài khoản
                try
                {
                    string query = "Delete from TaiKhoan where Email = @email";
                    int num = DataProvider.Instance.ExecuteNonQuery(query, new object[] { txtEmail.Text });
                    if (num > 0)
                    {
                        RJMessageBox.Show("Đã xóa tài khoản vĩnh viễn!");
                        Application.Exit();
                    }
                    else
                    {
                        RJMessageBox.Show("Không thể xóa tài khoản!");
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

        private void LuuThayDoiTK_Click(object sender, EventArgs e)
        {
            string query = "";
            DataProvider.Instance.ExecuteNonQuery(query, new object[] { /* tham so */  });
        }

        private void btnSuaEmail_Click(object sender, EventArgs e)
        {

        }

        private void btnSuaTenDangNhap_Click(object sender, EventArgs e)
        {

        }

        private void btnSuaMatKhau_Click(object sender, EventArgs e)
        {

        }

        private void UC_QuanLyTK_Load(object sender, EventArgs e)
        {
            ThoiGianTaoTaiKhoan();
            SoMucYeuThich();
            ThoiGianSuDung();
            HienThiThongTinTaiKhoan(); // Hiển thị thông tin tài khoản
        }
        private void HienThiThongTinTaiKhoan()
        {
            try
            {
                SqlConnection Conn = new SqlConnection(connString);
                SqlCommand cmd = new SqlCommand($"EXEC HienThiThongTinTaiKhoan {Class_TaiKhoan.IdTaiKhoan}", Conn);
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
                MessageBox.Show(ex.Message);
            }
        }
    }
}
