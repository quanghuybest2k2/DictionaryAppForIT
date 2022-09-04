using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DictionaryAppForIT.UserControls.LichSu
{
    public partial class UC_LS_TuVung : UserControl
    {
        public UC_LS_TuVung()
        {
            InitializeComponent();
        }

        public UC_LS_TuVung(string thoiGian, string ngayThang, string tiengAnh, string phienAm, string tiengViet)
        {
            InitializeComponent();
            this.ThoiGian = thoiGian;
            this.NgayThang = ngayThang;
            this.TVTiengAnh = tiengAnh;
            this.TVPhienAm = phienAm;
            this.TVTiengViet = tiengViet;
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
    }
}
