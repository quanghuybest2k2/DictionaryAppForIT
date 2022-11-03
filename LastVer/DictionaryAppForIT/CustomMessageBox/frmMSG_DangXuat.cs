using System;
using DictionaryAppForIT.Forms;
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
    public partial class frmMSG_DangXuat : Form
    {
        public frmMSG_DangXuat()
        {
            InitializeComponent();
            
        }

        private void pbClose_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.No;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            //this.Hide();
            DialogResult = DialogResult.OK;
            frmLogin frmLogin = new frmLogin();
            frmLogin.Show();
        }
    }
}
