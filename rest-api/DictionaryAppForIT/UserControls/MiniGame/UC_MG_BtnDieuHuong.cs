using System;
using System.Windows.Forms;

namespace DictionaryAppForIT.UserControls.MiniGame
{
    public partial class UC_MG_BtnDieuHuong : UserControl
    {

        public string Stt
        {
            get { return lblSo.Text; }
            set { lblSo.Text = value; }
        }

        public UC_MG_BtnDieuHuong()
        {
            InitializeComponent();
        }

        public UC_MG_BtnDieuHuong(int num)
        {
            InitializeComponent();
            this.lblSo.Text = num.ToString();
        }

        private void lblSo_Click(object sender, EventArgs e)
        {

        }

        private void guna2PictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void pnNen_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
