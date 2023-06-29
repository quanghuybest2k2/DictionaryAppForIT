using DictionaryAppForIT.Class;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Guna.UI2.WinForms;

namespace DictionaryAppForIT.UserControls.TaiKhoan
{
    public partial class UC_PhanHoi : UserControl
    {
        public UC_PhanHoi()
        {
            InitializeComponent();
        }

        private void guna2Panel9_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2PictureBox4_Click(object sender, EventArgs e)
        {

        }

        private void guna2PictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void guna2PictureBox12_Click(object sender, EventArgs e)
        {

        }

        private void btnDanhGia(object sender, EventArgs e)
        {
            var getText = (sender as Guna2Button).Text;
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            RJMessageBox.Show("Cảm ơn bạn đã đánh giá ứng dụng", "Thank you", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
