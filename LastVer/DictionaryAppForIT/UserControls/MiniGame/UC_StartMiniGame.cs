using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DictionaryAppForIT.DAL;
using DictionaryAppForIT.DTO;
using DictionaryAppForIT.Class;

namespace DictionaryAppForIT.UserControls.MiniGame
{
    public partial class UC_StartMiniGame : UserControl
    {
        UC_MiniGame ucMiniGame = new UC_MiniGame();
        public UC_StartMiniGame()
        {
            InitializeComponent();
            ucMiniGame = new UC_MiniGame();
        }

        private void btnBatDau_Click(object sender, EventArgs e)
        {
            object count = DataProvider.Instance.ExecuteScalar($"EXEC KiemTraTRungTu '{Class_TaiKhoan.IdTaiKhoan}'");
            if (Convert.ToInt32(count)>=10)
            {
                //pnStartMiniGame.Visible = false;
                pnStartMiniGame.SendToBack();
                this.Controls.Remove(ucMiniGame);
                ucMiniGame = new UC_MiniGame();
                this.Controls.Add(ucMiniGame);
                ucMiniGame.Dock = DockStyle.Fill;
                ucMiniGame.BringToFront();
            }
            else
            {
                RJMessageBox.Show("Bạn cần tra đủ 10 từ vựng khác nhau", "Thông báo");
                return;
            }
        }
    }
}
