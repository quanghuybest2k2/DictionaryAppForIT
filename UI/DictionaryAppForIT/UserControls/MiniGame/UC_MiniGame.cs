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
using System.Media; // thư viện âm thanh

namespace DictionaryAppForIT.UserControls.MiniGame
{
    public partial class UC_MiniGame : UserControl
    {
        private int toTalSecond;
        UC_MG_BtnDieuHuong ucBtnDieuHuong;
        SoundPlayer nhacNen;
        SoundPlayer nhacTraLoi;
        SoundPlayer DemNguoc15s;
        SoundPlayer NhacHetGio;
        public UC_MiniGame()
        {
            InitializeComponent();
         
            for (int i = 1; i <= 30; i++)
            {
                ucBtnDieuHuong = new UC_MG_BtnDieuHuong(i);
                flpDieuHuong.Controls.Add(ucBtnDieuHuong);
            }
        }
        private void UC_MiniGame_Load(object sender, EventArgs e)
        {
            nhacNen = new SoundPlayer(Application.StartupPath + "\\Resources\\Sound\\NhacNenAiLaTrieuPhu.wav");
            nhacNen.PlayLooping();
        }
        private void btnThoatMiniGame_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            int m = 0;// phut
            int s = 20;// giay
            toTalSecond = (m * 60) + s;
            this.timerCountDown.Enabled = true;
            nhacNen.Stop();// dung nhac nen
            nhacTraLoi = new SoundPlayer(Application.StartupPath + "\\Resources\\Sound\\nhacTraLoi.wav");
            nhacTraLoi.PlayLooping();
        }

        private void timerCountDown_Tick(object sender, EventArgs e)
        {
            //Application.StartupPath: đường dẫn vào bin\\debug
            //property của tệp phải ở chế độ Copy if newer
            DemNguoc15s = new SoundPlayer(Application.StartupPath + "\\Resources\\Sound\\DemNguoc15s.wav");
            NhacHetGio = new SoundPlayer(Application.StartupPath + "\\Resources\\Sound\\HetThoiGian.wav");
            if (toTalSecond > 0)
            {
                toTalSecond--;
                int m = toTalSecond / 60;
                int s = toTalSecond - (m * 60);
                if (toTalSecond==15)
                {
                    //nhacTraLoi.Play();
                    DemNguoc15s.Play();
                }
                this.lblThoiGian.Text = m.ToString() + ":" + s.ToString();
            }
            else
            {
                this.timerCountDown.Stop();
                NhacHetGio.Play();
                var result = RJMessageBox.Show("Bạn có muốn làm lại không?", "Hết giờ", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    try
                    {
                        // btn BatDauChoi.performclick();
                    }
                    catch (Exception ex)
                    {
                        RJMessageBox.Show(ex.Message);
                    }
                }
                if (result == DialogResult.No)
                {
                    // Quay về giao diện Bắt đầu chơi
                }
            }
        }
        
    }
}
