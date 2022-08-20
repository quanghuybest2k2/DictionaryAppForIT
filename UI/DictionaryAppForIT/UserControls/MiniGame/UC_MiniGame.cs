using DictionaryAppForIT.Class;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DictionaryAppForIT.UserControls.MiniGame
{
    public partial class UC_MiniGame : UserControl
    {
        UC_MG_BtnDieuHuong ucBtnDieuHuong;

        public UC_MiniGame()
        {
            InitializeComponent();

            for (int i = 1; i <= 30; i++)
            {
                ucBtnDieuHuong = new UC_MG_BtnDieuHuong(i);
                flpDieuHuong.Controls.Add(ucBtnDieuHuong);
            }
        }

        private void btnThoatMiniGame_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            CountDownTimer timer = new CountDownTimer();
            timer.SetTime(Convert.ToInt32(00), 5);// (phút, giây)
            timer.Start();
            timer.TimeChanged += () => lblPhut.Text = timer.TimeLeftMsStr;
            timer.CountDownFinished += () => RJMessageBox.Show("Hết giờ!"); //lblPhut.Text = "Hết giờ!";
            timer.StepMs = 77;
        }
    }
}
