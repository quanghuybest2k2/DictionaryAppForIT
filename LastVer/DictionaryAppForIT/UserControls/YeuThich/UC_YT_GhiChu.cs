using System;
using DictionaryAppForIT.Class;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DictionaryAppForIT.DAL;
using DictionaryAppForIT.DTO;

namespace DictionaryAppForIT.UserControls.YeuThich
{
    public partial class UC_YT_GhiChu : UserControl
    {
        string maxKiTuNhap = "115";
        public bool isClose;
        public int _loai; // 1 là từ vựng, 2 là văn bản
        public UC_YT_GhiChu(string index, string ghiChu, int loai)
        {
            InitializeComponent();
            statusStripSoKyTuNhap.SizingGrip = false;
            isClose = false;

            this.lblIndex.Text = index;
            this.txtGhiChu.Text = ghiChu;
            this._loai = loai;
        }

        public string Index
        {
            get { return lblIndex.Text; }
            set { lblIndex.Text = value; }
        }

        public string GhiChu
        {
            get { return txtGhiChu.Text; }
            set { txtGhiChu.Text = value; }
        }

        private void txtGhiChu_TextChanged(object sender, EventArgs e)
        {
            txtGhiChu.Text = txtGhiChu.Text.Replace(Environment.NewLine, "");
            tsslSoKyTuNhap.Text = "Số ký tự nhập: " + txtGhiChu.Text.Length.ToString() + "/" + maxKiTuNhap;
        }

        private void UC_YT_GhiChu_Load(object sender, EventArgs e)
        {
            tsslSoKyTuNhap.Text = "Số ký tự nhập: " + txtGhiChu.Text.Length.ToString() + "/" + maxKiTuNhap;
        }

        private void btnChinhSuaGhiChu_Click(object sender, EventArgs e)
        {
            txtGhiChu.Enabled = true;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            isClose = true;

        }

        private void btnXoaGhiChu_Click(object sender, EventArgs e)
        {
            txtGhiChu.Enabled = true;
            txtGhiChu.Clear();
            txtGhiChu.Enabled = false;
            CapNhatGhiChu();
        }

        public void KTGhiChu()
        {
            if (string.IsNullOrEmpty(txtGhiChu.Text))
            {
                btnChinhSuaGhiChu.PerformClick();
                txtGhiChu.PlaceholderText = "Nhập ghi chú [nhấn Enter để lưu]";
            }
        }

        private void txtGhiChu_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                CapNhatGhiChu();
            }
        }

        private void CapNhatGhiChu()
        {
            if (_loai == 1)
            {
                int num = DataProvider.Instance.ExecuteNonQuery($"UPDATE YeuThichTuVung SET GhiChu = N'{txtGhiChu.Text.Trim()}' WHERE ID = {lblIndex.Text} and IDTK = {Class_TaiKhoan.IdTaiKhoan}");
                if (num > 0)
                {
                    RJMessageBox.Show("Ghi chú thành công!");
                    txtGhiChu.Enabled = false;
                }
                else
                {
                    RJMessageBox.Show("Thất bại!");
                }
            }
            else
            {
                int num = DataProvider.Instance.ExecuteNonQuery($"UPDATE YeuThichVanBan SET GhiChu = N'{txtGhiChu.Text.Trim()}' WHERE ID = {lblIndex.Text} and IDTK = {Class_TaiKhoan.IdTaiKhoan}");
                if (num > 0)
                {
                    RJMessageBox.Show("Ghi chú thành công!");
                    txtGhiChu.Enabled = false;
                }
                else
                {
                    RJMessageBox.Show("Thất bại!");
                }
            }
        }
    }
}
