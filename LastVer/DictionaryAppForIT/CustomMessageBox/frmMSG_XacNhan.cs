using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DictionaryAppForIT.CustomMessageBox
{
    public partial class frmMSG_XacNhan : Form
    {
        public frmMSG_XacNhan()
        {
            InitializeComponent();
        }

        string _thoiGianLam;

        public frmMSG_XacNhan(string noiDung)
        {
            InitializeComponent();
            this.NoiDung = noiDung;
        }

        public frmMSG_XacNhan(string noiDung, string thoiGianLam)
        {
            InitializeComponent();
            this.NoiDung = noiDung;
            this._thoiGianLam = thoiGianLam;
        }

        public string NoiDung
        {
            get { return lblNoiDung.Text; }
            set { lblNoiDung.Text = value; }
        }

        public string ThoiGianLam
        {
            get { return _thoiGianLam; }
            set { _thoiGianLam = value; }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }
    }
}
