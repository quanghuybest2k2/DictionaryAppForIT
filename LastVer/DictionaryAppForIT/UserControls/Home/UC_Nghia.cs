using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DictionaryAppForIT.UserControls.Home
{
    public partial class UC_Nghia : UserControl
    {
        public UC_Nghia()
        {
            InitializeComponent();
        }

        public string LoaiTu
        {
            get { return this.lblLoaiTu.Text; }
            set { this.lblLoaiTu.Text = value; }
        }

        public string Nghia
        {
            get { return this.txtNghiaTiengViet.Text; }
            set { this.txtNghiaTiengViet.Text = value; }
        }
        public string MoTa
        {
            get { return this.txtMoTa.Text; }
            set { this.txtMoTa.Text = value; }
        }
        public string ViDu
        {
            get { return this.txtVD.Text; }
            set { this.txtVD.Text = value; }
        }

        private void UC_Nghia_Load(object sender, EventArgs e)
        {

        }
    }
}
