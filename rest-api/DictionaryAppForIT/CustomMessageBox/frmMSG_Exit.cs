using DictionaryAppForIT.DTO;
using System;
using System.Windows.Forms;

namespace DictionaryAppForIT.CustomMessageBox
{
    public partial class frmMSG_Exit : Form
    {
        public frmMSG_Exit()
        {
            InitializeComponent();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            // này là để xóa setting để test thôi, đặt đây là không đúng
            //UserData.RemoveUserDataSetting();
            Application.Exit();
        }

        private void pbClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
