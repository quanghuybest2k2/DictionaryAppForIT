using DictionaryAppForIT.CustomMessageBox.UC_PbThanhTich;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DictionaryAppForIT.UserControls.MiniGame;

namespace DictionaryAppForIT.CustomMessageBox
{
    public partial class frmMSG_KQ : Form
    {
        UC_TT_Hang1 ucTTHang1 = new UC_TT_Hang1();
        UC_TT_Hang2 ucTTHang2 = new UC_TT_Hang2();
        UC_TT_Hang3 ucTTHang3 = new UC_TT_Hang3();
        UC_TT_Hang4 ucTTHang4 = new UC_TT_Hang4();

        public frmMSG_KQ(string diemTong, string soCauChuaLam, string thoiGianLam)
        {
            InitializeComponent();
            this.DiemTong = diemTong;
            this.SoCauChuaLam = soCauChuaLam;
            this.ThoiGianLam = thoiGianLam;
        }
        public string DiemTong
        {
            get { return lblTongDiem.Text; }
            set { lblTongDiem.Text = value; }
        }

        public string SoCauChuaLam
        {
            get { return lblSoCauChuaLam.Text; }
            set { lblSoCauChuaLam.Text = value; }
        }

        public string ThoiGianLam
        {
            get { return lblThoiGianLam.Text; }
            set { lblThoiGianLam.Text = value; }
        }


        private void ThemUCThanhTich(Control uc)
        {
            pnThanhTich.Controls.Add(uc);
            uc.Dock = DockStyle.Fill;
        }

        private void pbClose_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

        private void frmMSG_KQ_Load(object sender, EventArgs e)
        {
            lblSoCauDung.Text = DiemTong;
            int soCauSai = 10 - Convert.ToInt32(DiemTong);
            lblSoCauSai.Text = soCauSai.ToString();
            lblSoCauChuaLam.Text = SoCauChuaLam;
            lblThoiGianLam.Text = ThoiGianLam;
            int TongDiem = Convert.ToInt32(DiemTong);
            lblTongDiem.Text = DiemTong;
            switch (TongDiem)
            {
                case int n when (n <= 10 && n >= 8):
                    ThemUCThanhTich(ucTTHang1);
                    lblDanhGia.Text = "Tuyệt vời! Vip quá đấy bạn ơi!";
                    break;
                case int n when (n < 8 && n >= 6):
                    ThemUCThanhTich(ucTTHang2);
                    lblDanhGia.Text = "Được đấy bạn ơi!";
                    break;
                case int n when (n < 6 && n >= 4):
                    ThemUCThanhTich(ucTTHang3);
                    lblDanhGia.Text = "Bạn nằm ở mức trung bình!";
                    break;
                case int n when (n < 4 && n >= 0):
                    ThemUCThanhTich(ucTTHang4);
                    lblDanhGia.Text = "Bạn đã có cố gắng!";
                    break;
            }
        }

        private void btnChoiLai_Click(object sender, EventArgs e)
        {
            UC_MiniGame.XacNhanChoiLai = true;
            DialogResult = DialogResult.OK;
        }
    }
}
