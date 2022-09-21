using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DictionaryAppForIT.UserControls.TaiKhoan
{
    public partial class UC_TT_ThemNghia : UserControl
    {
        public bool XacNhanXoa = false;
        int textStt = 0;
        public UC_TT_ThemNghia(int stt)
        {
            InitializeComponent();
            lblSTT.Text = "Nghĩa thứ " + stt;
            textStt = stt;
        }

        public int Stt
        {
            get { return this.textStt; }
            set { this.lblSTT.Text = "Nghĩa thứ " + value.ToString();}
        }

        public string Nghia
        {
            get { return this.txtNghia.Text; }
            set { this.txtNghia.Text = value; }
        }

        private void cbXoa_CheckedChanged(object sender, Bunifu.UI.WinForms.BunifuCheckBox.CheckedChangedEventArgs e)
        {
            if (cbXoa.Checked)
                XacNhanXoa = true;
            else
                XacNhanXoa = false;
        }
    }
}
