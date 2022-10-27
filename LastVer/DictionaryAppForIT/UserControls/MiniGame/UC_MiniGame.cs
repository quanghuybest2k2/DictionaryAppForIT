using DictionaryAppForIT.Class;
using DictionaryAppForIT.DAL;
using DictionaryAppForIT.DTO;
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
using DictionaryAppForIT.CustomMessageBox;
using System.Data.SqlClient;
using System.Configuration;
using Guna.UI2.WinForms;

namespace DictionaryAppForIT.UserControls.MiniGame
{
    public partial class UC_MiniGame : UserControl
    {
        private string connString = ConfigurationManager.ConnectionStrings["DictionaryApp"].ConnectionString;
        private int toTalSecond;
        //SoundPlayer nhacNen;
        SoundPlayer nhacTraLoi;
        SoundPlayer DemNguoc15s;
        SoundPlayer NhacHetGio;
        // tra loi
        public int soCauHoanThanh = 0;
        public string dapAnDung = "";
        public string cauTraLoi = "";
        //CauHoiVaDapAn ClassCauHoiVaDapAn = new CauHoiVaDapAn();
        DanhSachCauHoi ClassDanhSachCauHoi = new DanhSachCauHoi();

        public UC_MiniGame()
        {
            InitializeComponent();
        }
        private void UC_MiniGame_Load(object sender, EventArgs e)
        {
            //nhacNen = new SoundPlayer(Application.StartupPath + "\\Resources\\Sound\\NhacNenAiLaTrieuPhu.wav");
            //nhacNen.PlayLooping();
            //LoadCauHoi();
            ClassDanhSachCauHoi.LoadDSCauHoi();
            btnDieuHuong_Click(btnCau1, e);
            btnCau1.Checked = true;

        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            int m = 0;// phut
            int s = 20;// giay
            toTalSecond = (m * 60) + s;
            this.timerCountDown.Enabled = true;
            //nhacNen.Stop();// dung nhac nen
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
                if (toTalSecond == 15)
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




        //Cái này có j ông gắn nó vô cái hết h hộ tui
        private void button1_Click(object sender, EventArgs e)
        {
            var frm = new frmMSG_HoanThanh("Bạn đã hết thời gian!");
            frm.GameOver = true;
            frm.Show();
        }

        private void btnHoanThanh_Click(object sender, EventArgs e)
        {

            var frmXacNhan = new frmMSG_XacNhan("Bạn có chắc chắn là muốn hoàn thành lượt chơi không?");
            if (frmXacNhan.ShowDialog() == DialogResult.OK)
            {
                frmXacNhan.Close();
                //var frmHoanThanh = new frmMSG_HoanThanh("Bạn đã hoàn thành lượt chơi!");
                var frmHoanThanh = new frmMSG_HoanThanh("Tổng điểm: " + TongDiem());
                frmHoanThanh.HoanThanh = true;
                frmHoanThanh.Show();
            }
        }

        private void btnThoatMiniGame_Click(object sender, EventArgs e)
        {
            var frmXacNhan = new frmMSG_XacNhan("Bạn có chắc chắn là muốn kết thúc lượt chơi và quay trở về không?");
            if (frmXacNhan.ShowDialog() == DialogResult.OK)
            {
                frmXacNhan.Close();
                this.SendToBack();
            }
        }

        private void HienThiCauHoi(int index)
        {
            if (ClassDanhSachCauHoi._list[index].Stt < 10)
            {
                lblStt.Text = "0" + ClassDanhSachCauHoi._list[index].Stt.ToString();
            }
            else
            {
                lblStt.Text = ClassDanhSachCauHoi._list[index].Stt.ToString();

            }
            txtCauHoi.Text = $"Bạn còn nhớ nghĩa của từ {ClassDanhSachCauHoi._list[index].TuVung.ToUpper()} không?";
            var rnd = new Random();
            var numbers = Enumerable.Range(0, 4).OrderBy(x => rnd.Next()).Take(4).ToList();
            // them dap an dung vao list
            ClassDanhSachCauHoi._list[index].DapAnRandom.Add(ClassDanhSachCauHoi._list[index].DapAnDung);
            // 4 dap an

            btnA.Text = ClassDanhSachCauHoi._list[index].DapAnRandom[numbers[0]];
            HienThiCauTraLoi(btnA, ClassDanhSachCauHoi._list[index].CauTraLoi);
            btnB.Text = ClassDanhSachCauHoi._list[index].DapAnRandom[numbers[1]];
            HienThiCauTraLoi(btnB, ClassDanhSachCauHoi._list[index].CauTraLoi);
            btnC.Text = ClassDanhSachCauHoi._list[index].DapAnRandom[numbers[2]];
            HienThiCauTraLoi(btnC, ClassDanhSachCauHoi._list[index].CauTraLoi);
            btnD.Text = ClassDanhSachCauHoi._list[index].DapAnRandom[numbers[3]];
            HienThiCauTraLoi(btnD, ClassDanhSachCauHoi._list[index].CauTraLoi);
            lblDapAnDung.Text = ClassDanhSachCauHoi._list[index].DapAnDung;

        }



        private void HienThiCauTraLoi(Guna2Button btn, string cauTraLoi)
        {
            if (btn.Text == cauTraLoi)
            {
                btn.Checked = true;
            }
            else
            {
                btn.Checked = false;
            }
        }

        private void traloi_click(object sender, EventArgs e)
        {

            string num = lblStt.Text;
            int index = Convert.ToInt32(num);
            index--;
            dapAnDung = (sender as Guna2Button).Text;// gắn text của button chọn
            ClassDanhSachCauHoi._list[index].CauTraLoi = (sender as Guna2Button).Text;// gắn text của button chọn
            ClassDanhSachCauHoi._list[index].DaTraLoi = true;
            if (dapAnDung == lblDapAnDung.Text)
            {
                ClassDanhSachCauHoi._list[index].TraLoiDung = true;
            }
            else
            {
                ClassDanhSachCauHoi._list[index].TraLoiDung = false;
            }
            lblSoCauHoanThanh.Text = SoCauHoanThanh() + "/10";
        }

        private string TongDiem()
        {
            int sum = 0;
            foreach (var item in ClassDanhSachCauHoi._list)
            {
                if (item.TraLoiDung)
                {
                    sum += 1;
                }
            }
            return sum.ToString();
        }

        private string SoCauHoanThanh()
        {
            int sum = 0;
            foreach (var item in ClassDanhSachCauHoi._list)
            {
                if (item.DaTraLoi)
                {
                    sum += 1;
                }
            }
            return sum.ToString();
        }

        private void btnDieuHuong_Click(object sender, EventArgs e)
        {
            int num = Convert.ToInt32((sender as Guna2Button).Text);
            HienThiCauHoi(--num);
            //MessageBox.Show(num.ToString(), ClassDanhSachCauHoi._list.Count().ToString());
        }
        private void btnCauTruoc_Click(object sender, EventArgs e)
        {
            int num = Convert.ToInt32(lblStt.Text);
            if (num >= 2)
            {
                HienThiCauHoi(num - 2);
            }
        }
        private void btnCauSau_Click(object sender, EventArgs e)
        {
            int num = Convert.ToInt32(lblStt.Text);
            if (num < 10)
            {
                HienThiCauHoi(num);
            }
        }
    }
}
