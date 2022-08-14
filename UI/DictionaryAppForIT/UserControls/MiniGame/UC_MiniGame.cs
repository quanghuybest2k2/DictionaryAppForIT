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
        int _phut;
        int _giay;

        public UC_MiniGame()
        {
            InitializeComponent();

            for (int i = 1; i <= 30; i++)
            {
                ucBtnDieuHuong = new UC_MG_BtnDieuHuong(i);
                flpDieuHuong.Controls.Add(ucBtnDieuHuong);
            }
            _phut = 15;
            //DemNguoc(_phut);
        }

        private void timerGiay_Tick(object sender, EventArgs e)
        {
            lblGiay.Text = _giay--.ToString();
        }

        private void DemNguoc(int num)
        {
            int phut = num;
            lblPhut.Text = phut--.ToString();
            do
            {
                timerGiay.Start();
                phut--;
                _giay = 59;
                lblPhut.Text = phut.ToString();
            } while (phut >= 0);
        }
    }
}
