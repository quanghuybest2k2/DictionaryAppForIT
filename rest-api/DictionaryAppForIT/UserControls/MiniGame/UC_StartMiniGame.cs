using DictionaryAppForIT.Class;
using System;
using System.Windows.Forms;

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
            try
            {
                pnStartMiniGame.SendToBack();
                this.Controls.Remove(ucMiniGame);
                ucMiniGame = new UC_MiniGame();
                this.Controls.Add(ucMiniGame);
                ucMiniGame.Dock = DockStyle.Fill;
                ucMiniGame.BringToFront();
            }
            catch (Exception ex)
            {
                RJMessageBox.Show(ex.Message);
            }
        }
    }
}
