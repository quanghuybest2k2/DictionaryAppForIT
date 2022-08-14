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
        public UC_YT_TuVung()
        {
            InitializeComponent();
        }

        public UC_YT_TuVung(string stt, string tiengAnh, string phienAm, string tiengViet)
        {
            InitializeComponent();
            this.STT = stt;
            this.TVTiengAnh = tiengAnh;
            this.TVPhienAm = phienAm;
            this.TVTiengViet = tiengViet;
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
        }
    }
}
