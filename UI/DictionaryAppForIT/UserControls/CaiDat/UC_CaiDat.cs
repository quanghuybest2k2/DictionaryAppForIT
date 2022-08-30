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
        public bool tuDongCapNhat;
        private string phienBan = "1.0.0";
        public UC_CaiDat()
        {
            InitializeComponent();
            ThongTinUngDung();
        }
        private void ThongTinUngDung()
        {
            RichTextBox rtb1 = new RichTextBox();
            guna2Transition1.SetDecoration(rtb1, Guna.UI2.AnimatorNS.DecorationType.None);
            rtb1.Font = new System.Drawing.Font("Segoe UI", 10F);
            rtb1.SelectionColor = Color.Gray;
            rtb1.AppendText(" Phiên bản ");
            rtb1.SelectionColor = ColorTranslator.FromHtml("#0098ff");
            rtb1.AppendText(phienBan);
            rtb1.SelectionColor = Color.Gray;
            rtb1.AppendText(" BETA");
            rtb1.Size = new System.Drawing.Size(287, 23);
            rtb1.Location = new Point(30, 58);
            rtb1.Name = "rtxtThongTinPhienBan";
            rtb1.BorderStyle = BorderStyle.None;
            rtb1.ReadOnly = true;
            panelThongTinUngDung.Controls.Add(rtb1);
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
