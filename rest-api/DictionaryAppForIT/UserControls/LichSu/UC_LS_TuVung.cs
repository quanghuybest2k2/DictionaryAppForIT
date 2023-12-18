using Bunifu.UI.WinForms;
using DictionaryAppForIT.DAL;
using DictionaryAppForIT.DTO;
using Guna.UI2.WinForms;
using System;
using System.Speech.Synthesis;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DictionaryAppForIT.UserControls.LichSu
{
    public partial class UC_LS_TuVung : UserControl
    {
        SpeechSynthesizer speech;
        public UC_LS_TuVung()
        {
            InitializeComponent();
            speech = new SpeechSynthesizer();
        }
        public UC_LS_TuVung(string index = null, string thoiGian = null, string ngayThang = null, string tiengAnh = null, string phienAm = null, string tiengViet = null)
        {
            InitializeComponent();
            this.Index = index;
            this.ThoiGian = thoiGian;
            this.NgayThang = ngayThang;
            this.TVTiengAnh = tiengAnh;
            this.TVPhienAm = phienAm;
            this.TVTiengViet = tiengViet;
        }
        public string Index
        {
            get { return lblIndex.Text; }
            set { lblIndex.Text = value; }
        }
        public string ThoiGian
        {
            get { return lblThoiGian.Text; }
            set { lblThoiGian.Text = value; }
        }

        public string NgayThang
        {
            get { return lblNgayThang.Text; }
            set { lblNgayThang.Text = value; }
        }

        public string TVTiengAnh
        {
            get { return lblTiengAnh.Text; }
            set { lblTiengAnh.Text = value; }
        }

        public string TVPhienAm
        {
            get { return lblPhienAm.Text; }
            set { lblPhienAm.Text = value; }
        }

        public string TVTiengViet
        {
            get { return lblTiengViet.Text; }
            set { lblTiengViet.Text = value; }

        }

        private void chkChonLSTraTu_CheckedChanged(object sender, BunifuCheckBox.CheckedChangedEventArgs e)
        {
            if (chkChonLSTraTu.Checked)
            {
                this.Name = "Check";
            }
            else
            {
                this.Name = "unCheck";
            }
        }
        private async void btnXoaLSTraTu_Click(object sender, EventArgs e)
        {
            this.Name = "Check";
            this.Visible = false;
            await WordHistoryService.XoaLichSuTuVungAsync(this);
        }
    }
}
