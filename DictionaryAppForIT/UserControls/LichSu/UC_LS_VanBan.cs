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
    public partial class UC_LS_VanBan : UserControl
    {
        public UC_LS_VanBan()
        {
            InitializeComponent(); 
        }

        public UC_LS_VanBan(string thoiGian, string ngayThang, string tiengAnh, string tiengViet)
        {
            InitializeComponent();
            this.ThoiGian = thoiGian;
            this.NgayThang = ngayThang;
            this.VBTiengAnh = tiengAnh;
            this.VBTiengViet = tiengViet;
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
    }
}
