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

namespace DictionaryAppForIT.UserControls.MiniGame
{
    public partial class UC_MiniGame : UserControl
    {
        private string connString = ConfigurationManager.ConnectionStrings["DictionaryApp"].ConnectionString;
        private int toTalSecond;
        UC_MG_BtnDieuHuong ucBtnDieuHuong;
        SoundPlayer nhacNen;
        SoundPlayer nhacTraLoi;
        SoundPlayer DemNguoc15s;
        SoundPlayer NhacHetGio;

        //CauHoiVaDapAn ClassCauHoiVaDapAn = new CauHoiVaDapAn();
        DanhSachCauHoi ClassDanhSachCauHoi = new DanhSachCauHoi();

        public UC_MiniGame()
        {
            InitializeComponent();
         
            //for (int i = 1; i <= 30; i++)
            //{
            //    ucBtnDieuHuong = new UC_MG_BtnDieuHuong(i);
            //    flpDieuHuong.Controls.Add(ucBtnDieuHuong);
            //}
        }
        private void UC_MiniGame_Load(object sender, EventArgs e)
        {
            //nhacNen = new SoundPlayer(Application.StartupPath + "\\Resources\\Sound\\NhacNenAiLaTrieuPhu.wav");
            //nhacNen.PlayLooping();
            //LoadCauHoi();
            ClassDanhSachCauHoi.LoadDSCauHoi();

        }

        //private void LoadCauHoi()
        //{
        //    ClassCauHoiVaDapAn = new CauHoiVaDapAn();
        //    // lay tu vung
        //    object tv =  DataProvider.Instance.ExecuteScalar($"select top 1 TiengAnh from LichSuTraTu where IDTK = '{Class_TaiKhoan.IdTaiKhoan}' ORDER  BY NEWID()");
        //    ClassCauHoiVaDapAn.TuVung = tv.ToString();
        //    txtCauHoi.Text = "Bạn còn nhớ nghĩa của từ " + ClassCauHoiVaDapAn.TuVung.ToUpper() + " không?";
        //    // lay nghia
        //    object da = DataProvider.Instance.ExecuteScalar($"select top 1 TiengViet from LichSuTraTu where TiengAnh = '{ClassCauHoiVaDapAn.TuVung}'and IDTK = '{Class_TaiKhoan.IdTaiKhoan}' ORDER  BY NEWID()");
        //    ClassCauHoiVaDapAn.DapAnDung = da.ToString();
        //    //object rdDa = DataProvider.Instance.ExecuteQuery($"EXEC RandomDapAn '{ClassCauHoiVaDapAn.DapAnDung}'");
        //    RandomDapAnSai();

        //    ClassDanhSachCauHoi._list.Add(ClassCauHoiVaDapAn);
        //    //MessageBox.Show("", ClassDanhSachCauHoi.ToString());
        //    //var rnd = new Random();
        //    //var numbers = Enumerable.Range(0, 3).OrderBy(x => rnd.Next()).Take(4).ToList();
        //}
        //public void RandomDapAnSai()
        //{
        //    ClassCauHoiVaDapAn.DapAnRandom = new List<string>();
        //    try
        //    {
        //        SqlConnection Conn = new SqlConnection(connString);
        //        SqlCommand cmd = new SqlCommand($"EXEC RandomDapAn '{ClassCauHoiVaDapAn.DapAnDung}'", Conn);
        //        Conn.Open();
        //        SqlDataReader rdr = cmd.ExecuteReader();
        //        string dapAn;
        //        while (rdr.Read())
        //        {
        //            dapAn = rdr["TiengViet"].ToString();
        //            ClassCauHoiVaDapAn.DapAnRandom.Add(dapAn);
        //        }
        //        Conn.Close();
        //        Conn.Dispose();
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message);
        //    }
        //}

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
                var frmHoanThanh = new frmMSG_HoanThanh("Bạn đã hoàn thành lượt chơi!");
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
            lblStt.Text = "0" + ClassDanhSachCauHoi._list[index].Stt.ToString();
            txtCauHoi.Text = $"Bạn còn nhớ nghĩa của từ {ClassDanhSachCauHoi._list[index].TuVung.ToUpper()} không?";
            var rnd = new Random();
            var numbers = Enumerable.Range(0, 4).OrderBy(x => rnd.Next()).Take(4).ToList();
            // them dap an dung vao list
            ClassDanhSachCauHoi._list[index].DapAnRandom.Add(ClassDanhSachCauHoi._list[index].DapAnDung);
            // 4 dap an
            btnA.Text = ClassDanhSachCauHoi._list[index].DapAnRandom[numbers[0]];
            btnB.Text = ClassDanhSachCauHoi._list[index].DapAnRandom[numbers[1]];
            btnC.Text = ClassDanhSachCauHoi._list[index].DapAnRandom[numbers[2]];
            btnD.Text = ClassDanhSachCauHoi._list[index].DapAnRandom[numbers[3]];
        }
 
        private void lblCau1_Click(object sender, EventArgs e)
        {
            HienThiCauHoi(0);
        }

        private void lblCau2_Click(object sender, EventArgs e)
        {
            HienThiCauHoi(1);

        }

        private void lblCau3_Click(object sender, EventArgs e)
        {
            HienThiCauHoi(2);

        }

        private void lblCau4_Click(object sender, EventArgs e)
        {
            HienThiCauHoi(3);
        }

        private void lblCau5_Click(object sender, EventArgs e)
        {
            HienThiCauHoi(4);
        }

        private void lblCau6_Click(object sender, EventArgs e)
        {
            HienThiCauHoi(5);
        }

        private void lblCau7_Click(object sender, EventArgs e)
        {
            HienThiCauHoi(6);
        }

        private void lblCau8_Click(object sender, EventArgs e)
        {
            HienThiCauHoi(7);
        }

        private void lblCau9_Click(object sender, EventArgs e)
        {
            HienThiCauHoi(8);
        }

        private void lblCau10_Click(object sender, EventArgs e)
        {
            HienThiCauHoi(9);
        }

    }
}
