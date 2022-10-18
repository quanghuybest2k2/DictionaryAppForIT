using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DictionaryAppForIT.UserControls.YeuThich
{
    public partial class UC_YT_TuVung : UserControl
    {
        UC_YT_GhiChu ucYTTGhiChu;
        public UC_YT_TuVung()
        {
            InitializeComponent();
        }

        public UC_YT_TuVung(string stt, string index, string tiengAnh, string phienAm, string tiengViet)
        {
            InitializeComponent();
            this.STT = "No." + stt;
            this.Index = index;
            this.TVTiengAnh = tiengAnh;
            this.TVPhienAm = phienAm;
            this.TVTiengViet = tiengViet;
            ThemGhiChu();
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

        public void TVBackColor(string color)
        {
            guna2pbNen1.FillColor = Color.FromName(color);
            guna2pbNen2.FillColor = Color.FromName(color);
            pnNen.BackColor = Color.FromName(color);
            lblChiTietGhiChu.BackColor = Color.FromName(color);
        }

        public bool GhiChu
        {
            get { return pnGhiChu.Visible; }
            set { pnGhiChu.Visible = value; }
        }

        private void chkChonYTTuVung_CheckedChanged(object sender, Bunifu.UI.WinForms.BunifuCheckBox.CheckedChangedEventArgs e)
        {
            if (chkChonYTTuVung.Checked || chkFakeChonYTTuVung.Checked)
            {
                this.Name = "Check";
            }
            else
            {
                this.Name = "unCheck";
            }
        }

        private void ThemGhiChu()
        {
            ucYTTGhiChu = new UC_YT_GhiChu();
            pnGhiChu.Controls.Add(ucYTTGhiChu);
            ucYTTGhiChu.Dock = DockStyle.Fill;
            ucYTTGhiChu.BringToFront();
        }

        private void btnGhiChu_Click(object sender, EventArgs e)
        {
            ucYTTGhiChu.Visible = true;
            pnGhiChu.Visible = true;
        }
    }
}
