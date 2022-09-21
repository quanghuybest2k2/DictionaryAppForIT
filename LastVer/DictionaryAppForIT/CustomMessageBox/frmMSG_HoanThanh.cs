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
    public partial class frmMSG_HoanThanh : Form
    {
        public frmMSG_HoanThanh()
        {
            InitializeComponent();
        }

        public frmMSG_HoanThanh(string thongBao)
        {
            InitializeComponent();
            this.ThongBao = thongBao;
        }

        public bool GameOver
        {
            get { return pnGameOver.Visible; }
            set { pnGameOver.Visible = value; }
        }

        public bool HoanThanh
        {
            get { return pbHoanThanh.Visible; }
            set { pbHoanThanh.Visible = value; }
        }

        public string ThongBao
        {
            get { return lblThongBao.Text; }
            set { lblThongBao.Text = value; }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnXemKQ_Click(object sender, EventArgs e)
        {
            var frm = new frmMSG_KQ();
            btnClose.PerformClick();
            frm.Show();
        }
    }
}
