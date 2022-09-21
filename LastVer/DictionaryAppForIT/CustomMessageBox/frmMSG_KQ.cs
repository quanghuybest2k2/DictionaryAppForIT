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

namespace DictionaryAppForIT.CustomMessageBox
{
    public partial class frmMSG_KQ : Form
    {
        UC_TT_Hang1 ucTTHang1 = new UC_TT_Hang1();
        UC_TT_Hang2 ucTTHang2 = new UC_TT_Hang2();
        UC_TT_Hang3 ucTTHang3 = new UC_TT_Hang3();
        UC_TT_Hang4 ucTTHang4 = new UC_TT_Hang4();

        public frmMSG_KQ()
        {
            InitializeComponent();
            lblTongDiem.Text = "12";
            int TongDiem = Convert.ToInt32(lblTongDiem.Text);
            switch (TongDiem)
            {
                case int n when (n <= 100 && n >= 80):
                    ThemUCThanhTich(ucTTHang1);
                    lblDanhGia.Text = "Tuyệt vời! Vip quá đấy bạn ơi!";
                    break;
                case int n when (n < 80 && n >= 60):
                    ThemUCThanhTich(ucTTHang2);
                    lblDanhGia.Text = "Được đấy bạn ơi!";
                    break;
                case int n when (n < 60 && n >= 40):
                    ThemUCThanhTich(ucTTHang3);
                    lblDanhGia.Text = "Bạn nằm ở mức trung bình!";
                    break;
                case int n when (n < 40 && n >= 0):
                    ThemUCThanhTich(ucTTHang4);
                    lblDanhGia.Text = "Bạn đã có cố gắng!";
                    break;
                default:
                    break;
            }
        }

        private void ThemUCThanhTich(Control uc)
        {
            pnThanhTich.Controls.Add(uc);
            uc.Dock = DockStyle.Fill;
        }

        private void pbClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
