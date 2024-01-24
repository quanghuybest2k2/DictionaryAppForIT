using DictionaryAppForIT.DTO;
using System;
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
            UserData.RemoveUserDataSetting();
            //this.Hide();
            DialogResult = DialogResult.OK;
            //frmLogin frmLogin = new frmLogin();
            //frmLogin.Show();
        }
    }
}
