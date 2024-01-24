using DictionaryAppForIT.Class;
using Guna.UI2.WinForms;
using System;
using System.Windows.Forms;

namespace DictionaryAppForIT.UserControls.TaiKhoan
{
    public partial class UC_PhanHoi : UserControl
    {
        public UC_PhanHoi()
        {
            InitializeComponent();
        }

        private void btnDanhGia(object sender, EventArgs e)
        {
            var getText = (sender as Guna2Button).Text;
            RJMessageBox.Show(getText);
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            RJMessageBox.Show("Cảm ơn bạn đã đánh giá ứng dụng", "Thank you", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
