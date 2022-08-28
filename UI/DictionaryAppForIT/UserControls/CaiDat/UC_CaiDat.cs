using Bunifu.UI.WinForms;
using Guna.UI2.WinForms;
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

namespace DictionaryAppForIT.UserControls.CaiDat
{
    public partial class UC_CaiDat : UserControl
    {
        public int tocDo = 0;
        public bool thayDoiTocDo = false;

        public UC_CaiDat()
        {
            InitializeComponent();
        }

        #region cài đặt chung
        private void btnCheDoBanDem_Click(object sender, EventArgs e)
        {
            // bật chế độ ban đêm
        }
        private void btnTuDongCapNhat_Click(object sender, EventArgs e)
        {
            // tự động cập nhật
        }
        private void btnTuDongXoaLS_Click(object sender, EventArgs e)
        {
            // tự động xóa lịch sử sau 1 khoảng thời gian
        }
        #endregion

        #region Âm thanh
        private void btnTuDongPhatAm_Click(object sender, EventArgs e)
        {
            // tự động phát âm
        }
        private void rdChamHon_Click(object sender, EventArgs e)
        {
            tocDo = -3;
            thayDoiTocDo = true;
        }
        private void rdBinhThuong_Click(object sender, EventArgs e)
        {
            tocDo = 0;
            thayDoiTocDo = true;
        }

        private void rdNhanhHon_Click(object sender, EventArgs e)
        {
            tocDo = 3;
            thayDoiTocDo = true;
        }
        #endregion

        #region Thông báo
        private void btnThongBao_Click(object sender, EventArgs e)
        {
            // thông báo
        }
        private void btnNhacHocTuVung_Click(object sender, EventArgs e)
        {
            // nhắc học từ vựng
        }
        #endregion

        private void UC_CaiDat_Load(object sender, EventArgs e)
        {

        }
        
    }
}
