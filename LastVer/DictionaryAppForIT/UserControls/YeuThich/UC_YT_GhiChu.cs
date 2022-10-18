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

namespace DictionaryAppForIT.UserControls.YeuThich
{
    public partial class UC_YT_GhiChu : UserControl
    {
        string maxKiTuNhap = "115";
        public bool isClose;
        public UC_YT_GhiChu()
        {
            InitializeComponent();
            statusStripSoKyTuNhap.SizingGrip = false;
            isClose = false;
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

        }

        private void txtGhiChu_KeyDown(object sender, KeyEventArgs e)
        {
               
            if (e.KeyCode == Keys.Enter) {
                RJMessageBox.Show("Lưu thành công!");
                txtGhiChu.Enabled = false;
            }
        }
    }
}
