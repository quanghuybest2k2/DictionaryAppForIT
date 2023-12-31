using System;
using System.Windows.Forms;

namespace DictionaryAppForIT.CustomMessageBox
{
    public partial class frmMSG_HoanThanh : Form
    {
        public frmMSG_HoanThanh()
        {
            InitializeComponent();
        }
        public string _DiemTongCong;
        public string _SoCauChuaLam;
        public string _ThoiGianLam;

        public frmMSG_HoanThanh(string _thongBao, string _diemTong, string _soCauChuaLam, string thoiGianLam)
        {
            InitializeComponent();
            this.ThongBao = _thongBao;
            this._DiemTongCong = _diemTong;
            this._SoCauChuaLam = _soCauChuaLam;
            this._ThoiGianLam = thoiGianLam;
        }
        public bool GameOver
        {
            get { return pnGameOver.Visible; }
            set { pnGameOver.Visible = value; }
        }

        public bool HoanThanh
        {
            get { return pbHoanThanh.Visible; }
            set { pbHoanThanh.Visible = value; }
        }

        public string DiemTong
        {
            get { return _DiemTongCong; }
            set { _DiemTongCong = value; }
        }

        public string SoCauChuaLam
        {
            get { return _SoCauChuaLam; }
            set { _SoCauChuaLam = value; }
        }

        public string ThoiGianLam
        {
            get { return _ThoiGianLam; }
            set { _ThoiGianLam = value; }
        }

        public string ThongBao
        {
            get { return lblThongBao.Text; }
            set { lblThongBao.Text = value; }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            btnXemKQ.PerformClick();
        }

        private void btnXemKQ_Click(object sender, EventArgs e)
        {
            var frm = new frmMSG_KQ(DiemTong, SoCauChuaLam, ThoiGianLam);
            DialogResult = DialogResult.OK;
            if (frm.ShowDialog() == DialogResult.OK)
            {
                frm.Close();
            }
        }

        private void frmMSG_HoanThanh_Load(object sender, EventArgs e)
        {

        }
    }
}
