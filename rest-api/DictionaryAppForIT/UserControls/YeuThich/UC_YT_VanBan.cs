using System;
using System.Drawing;
using System.Windows.Forms;

namespace DictionaryAppForIT.UserControls.YeuThich
{
    public partial class UC_YT_VanBan : UserControl
    {
        UC_YT_GhiChu ucYTGhiChu;
        public UC_YT_VanBan()
        {
            InitializeComponent();
        }

        public UC_YT_VanBan(string stt, string index, string tiengAnh, string tiengViet)
        {
            InitializeComponent();
            this.STT = "No." + stt;
            this.Index = index;
            this.VBTiengAnh = tiengAnh;
            this.VBTiengViet = tiengViet;
        }

        public string Index
        {
            get { return lblIndex.Text; }
            set { lblIndex.Text = value; }
        }

        public string STT
        {
            get { return lblSo.Text; }
            set { lblSo.Text = value; }
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

        public void VBBackColor(string color)
        {
            guna2pbNen1.FillColor = Color.FromName(color);
            guna2pbNen2.FillColor = Color.FromName(color);
            pnNen.BackColor = Color.FromName(color);

        }

        private void chkChonYTVanBan_CheckedChanged(object sender, Bunifu.UI.WinForms.BunifuCheckBox.CheckedChangedEventArgs e)
        {
            if (chkChonYTVanBan.Checked || chkFakeChonYTVanBan.Checked)
            {
                this.Name = "Check";
            }
            else
            {
                this.Name = "unCheck";
            }
        }

        public bool GhiChu
        {
            get { return pnGhiChu.Visible; }
            set { pnGhiChu.Visible = value; }
        }

        public void ThemGhiChu(string index, string ghiChu, int loai)
        {
            ucYTGhiChu = new UC_YT_GhiChu(index, ghiChu, loai);
            pnGhiChu.Controls.Add(ucYTGhiChu);
            ucYTGhiChu.Dock = DockStyle.Fill;
            ucYTGhiChu.BringToFront();
        }

        private void btnGhiChu_Click(object sender, EventArgs e)
        {
            ucYTGhiChu.Visible = true;
            pnGhiChu.Visible = true;
            ucYTGhiChu.KTGhiChu();
        }
    }
}
