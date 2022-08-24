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

namespace DictionaryAppForIT.UserControls.TaiKhoan
{
    public partial class UC_QuanLyTK : UserControl
    {
        //Class_TaiKhoan TaiKhoan = new Class_TaiKhoan();
        public UC_QuanLyTK()
        {
            InitializeComponent();
        }

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
    }
}
