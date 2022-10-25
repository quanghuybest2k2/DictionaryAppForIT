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
using DictionaryAppForIT.Properties;
using System.Threading.Tasks;
using System.Windows.Forms;
using DictionaryAppForIT.Forms;

namespace DictionaryAppForIT.UserControls.CaiDat
{
    public partial class UC_CaiDat : UserControl
    {
        // tốc độ đọc nhanh chậm
        public int tocDo = 0;
        public bool thayDoiTocDo = false;
        // tự động phát âm
        public bool tuDongPhatAm = false;
        private string phienBan = "1.0.0";
        public UC_CaiDat()
        {
            InitializeComponent();
            ThongTinUngDung();
        }
        private void ThongTinUngDung()
        {
            RichTextBox rtb1 = new RichTextBox();
            //guna2Transition1.SetDecoration(rtb1, Guna.UI2.AnimatorNS.DecorationType.None);
            rtb1.Font = new System.Drawing.Font("Segoe UI", 10F);
            rtb1.SelectionColor = Color.Gray;
            rtb1.AppendText(" Phiên bản ");
            rtb1.SelectionColor = ColorTranslator.FromHtml("#0098ff");
            rtb1.AppendText(phienBan);
            rtb1.SelectionColor = Color.Gray;
            rtb1.AppendText(" BETA");
            rtb1.Size = new System.Drawing.Size(287, 23);
            rtb1.Location = new Point(16, 58);
            rtb1.Name = "rtxtThongTinPhienBan";
            rtb1.BorderStyle = BorderStyle.None;
            rtb1.ReadOnly = true;
            panelThongTinUngDung.Controls.Add(rtb1);
        }

        #region cài đặt chung

        // bật chế độ ban đêm

        public bool ButtonCheDoBanDem
        {
            get { return btnCheDoBanDem.Checked; }
            set { btnCheDoBanDem.Checked = value; }
        }
        private void btnCheDoBanDem_CheckedChanged(object sender, EventArgs e)
        {
            //if (btnCheDoBanDem.Checked)
            //{
            //    // Giao diện tối
            //    this.BackColor = Color.FromArgb(32, 33, 36);
            //    this.ForeColor = Color.White;
            //}
            //else
            //{
            //    // Giao diện sáng
            //    this.BackColor = Color.White;
            //    this.ForeColor = Color.DimGray;
            //}
            RJMessageBox.Show("Chức năng đang phát triển");
        }

        // tự động cập nhật
        private void btnTuDongCapNhat_CheckedChanged(object sender, EventArgs e)
        {

        }
        // tự động xóa lịch sử sau 1 khoảng thời gian
        private void btnTuDongXoaLS_CheckedChanged(object sender, EventArgs e)
        {

        }
        #endregion

        #region Âm thanh

        // tự động phát âm
        private void btnTuDongPhatAm_CheckedChanged(object sender, EventArgs e)
        {
            if (btnTuDongPhatAm.Checked)
            {
                tuDongPhatAm = true;
            }
            else
            {
                tuDongPhatAm = false;
            }
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

        // thông báo
        private void btnThongBao_CheckedChanged(object sender, EventArgs e)
        {

        }
        // nhắc học từ vựng
        private void btnNhacHocTuVung_CheckedChanged(object sender, EventArgs e)
        {

        }
        #endregion

        private void UC_CaiDat_Load(object sender, EventArgs e)
        {

        }

    }
}
