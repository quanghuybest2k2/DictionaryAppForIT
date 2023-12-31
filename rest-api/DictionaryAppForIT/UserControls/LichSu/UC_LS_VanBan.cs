using DictionaryAppForIT.DTO;
using System;
using System.Windows.Forms;

namespace DictionaryAppForIT.UserControls.LichSu
{
    public partial class UC_LS_VanBan : UserControl
    {
        public UC_LS_VanBan()
        {
            InitializeComponent();
        }

        public UC_LS_VanBan(string index = null, string thoiGian = null, string ngayThang = null, string tiengAnh = null, string tiengViet = null)
        {
            InitializeComponent();
            this.Index = index;
            this.ThoiGian = thoiGian;
            this.NgayThang = ngayThang;
            this.VBTiengAnh = tiengAnh;
            this.VBTiengViet = tiengViet;
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

        public string VBTiengAnh
        {
            get { return lblTiengAnh.Text; }
            set { lblTiengAnh.Text = value; }
        }

        public string VBTiengViet
        {
            get { return lblTiengViet.Text; }
            set { lblTiengViet.Text = value; }
        }

        private void chkChonLSVanBan_CheckedChanged(object sender, Bunifu.UI.WinForms.BunifuCheckBox.CheckedChangedEventArgs e)
        {
            if (chkChonLSVanBan.Checked)
            {
                this.Name = "Check";
            }
            else
            {
                this.Name = "unCheck";
            }
            //this.lblNgayThang.Text = this.Name;
        }

        private async void btnXoaLSVanBan_Click(object sender, EventArgs e)
        {
            this.Name = "Check";
            this.Visible = false;
            await WordHistoryService.XoaLichSuVanBanAsync(this);
        }
    }
}
