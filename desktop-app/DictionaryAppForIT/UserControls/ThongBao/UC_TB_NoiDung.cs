using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DictionaryAppForIT.UserControls.ThongBao
{
    public partial class UC_TB_NoiDung : UserControl
    {
        public UC_TB_NoiDung()
        {
            InitializeComponent();
        }

        public UC_TB_NoiDung(string noiDung, string thoiGian)
        {
            InitializeComponent();
            this.NoiDung = noiDung;
            this.ThoiGian = thoiGian;
        }

        public string NoiDung
        {
            get { return this.lblContent.Text; }
            set { this.lblContent.Text = value; }
        }

        public string ThoiGian
        {
            get { return this.lblThoiGian.Text; }
            set { this.lblThoiGian.Text = value; }
        }
    }
}
