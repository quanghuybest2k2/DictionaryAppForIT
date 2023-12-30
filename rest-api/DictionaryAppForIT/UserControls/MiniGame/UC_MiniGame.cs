using DictionaryAppForIT.CustomMessageBox;
using Guna.UI2.WinForms;
using System;
using System.Data;
using System.Linq;
using System.Media; // thư viện âm thanh
using System.Windows.Forms;

namespace DictionaryAppForIT.UserControls.MiniGame
{
    public partial class UC_MiniGame : UserControl
    {
        private int toTalSecond;
        //SoundPlayer nhacNen;
        SoundPlayer nhacTraLoi;
        SoundPlayer DemNguoc15s;
        SoundPlayer NhacHetGio;
        // tra loi
        public int soCauHoanThanh = 0;
        public string dapAnDung = "";
        public string cauTraLoi = "";
        DanhSachCauHoi ClassDanhSachCauHoi = new DanhSachCauHoi();
        public static bool XacNhanChoiLai;
        public UC_MiniGame()
        {
            InitializeComponent();
            XacNhanChoiLai = false;
        }
        private void UC_MiniGame_Load(object sender, EventArgs e)
        {
            //LoadCauHoi();
            ClassDanhSachCauHoi.LoadDSCauHoi();
            ClassDanhSachCauHoi.BoSungCauHoiNeuChuaDu(ClassDanhSachCauHoi.demSoTu);
            btnDieuHuong_Click(btnCau1, e);
            btnCau1.Checked = true;
            LoadThoiGian();
        }
        private void LoadThoiGian()
        {
            int m = 1;// phut
            int s = 0;// giay
            toTalSecond = (m * 60) + s;
            this.timerCountDown.Enabled = true;
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
                var frm = new frmMSG_HoanThanh("Bạn đã hết thời gian!", TongDiem(), SoCauChuaLam(), "1 phút 0 giây");
                frm.GameOver = true;
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    frm.Close();
                    ChoiLai(XacNhanChoiLai);
                }

            }
        }

        private string ThoiGianHoanThanh()
        {
            string[] kq = new string[2];
            string[] arr = lblThoiGian.Text.Split(':');
            int thoiGianCon = int.Parse(arr[0]) * 60 + int.Parse(arr[1]);
            int thoiGianLam = 60 - thoiGianCon; //Thời gian cho phép làm là 60s
            int phut = thoiGianLam / 60 - thoiGianLam % 60 / 60;
            kq[0] = phut.ToString() + " phút ";
            int giay = thoiGianLam % 60;
            kq[1] = giay.ToString() + " giây";
            return kq[0] + kq[1];
        }

        private void btnHoanThanh_Click(object sender, EventArgs e)
        {
            var frmXacNhan = new frmMSG_XacNhan("Bạn có chắc chắn là muốn hoàn thành lượt chơi không?", ThoiGianHoanThanh());
            if (frmXacNhan.ShowDialog() == DialogResult.OK)
            {
                this.timerCountDown.Stop();
                DemNguoc15s.Stop();
                frmXacNhan.Close();
                var frmHoanThanh = new frmMSG_HoanThanh("Bạn đã hoàn thành lượt chơi!", TongDiem(), SoCauChuaLam(), ThoiGianHoanThanh());
                frmHoanThanh.HoanThanh = true;
                if (frmHoanThanh.ShowDialog() == DialogResult.OK)
                {
                    frmHoanThanh.Close();
                    ChoiLai(XacNhanChoiLai);
                }

            }
        }

        public void ChoiLai(bool xacNhanChoiLai)
        {
            if (xacNhanChoiLai)
            {
                ClassDanhSachCauHoi = new DanhSachCauHoi();
                ClassDanhSachCauHoi.LoadDSCauHoi();
                ClassDanhSachCauHoi.BoSungCauHoiNeuChuaDu(ClassDanhSachCauHoi.demSoTu);
                HienThiCauHoi(0);
                lblSoCauHoanThanh.Text = "0/10";
                btnCau1.Checked = true;
                LoadThoiGian();
                btnHoanThanh.Visible = true;
            }
            else
            {
                btnHoanThanh.Visible = false;
            }
        }

        private void btnThoatMiniGame_Click(object sender, EventArgs e)
        {
            var frmXacNhan = new frmMSG_XacNhan("Bạn có chắc chắn là muốn kết thúc lượt chơi và quay trở về không?");
            if (frmXacNhan.ShowDialog() == DialogResult.OK)
            {
                this.timerCountDown.Stop();
                DemNguoc15s.Stop();
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
            var rnd = new Random();
            string[] DangCauHoi =
            {
                $"Bạn còn nhớ nghĩa của từ {ClassDanhSachCauHoi._list[index].TuVung.ToUpper()} ({ClassDanhSachCauHoi._list[index].TuLoai}) không?",
                $"Từ {ClassDanhSachCauHoi._list[index].TuVung.ToUpper()} ({ClassDanhSachCauHoi._list[index].TuLoai}) có nghĩa là gì?",
                $"Hãy chọn nghĩa đúng của từ {ClassDanhSachCauHoi._list[index].TuVung.ToUpper()} ({ClassDanhSachCauHoi._list[index].TuLoai})",
                $"Chọn nghĩa tương ứng với từ {ClassDanhSachCauHoi._list[index].TuVung.ToUpper()} ({ClassDanhSachCauHoi._list[index].TuLoai})",
                $"{ClassDanhSachCauHoi._list[index].TuVung.ToUpper()} ({ClassDanhSachCauHoi._list[index].TuLoai}) có nghĩa là:",
                $"Trong các đáp án bên dưới, đâu là nghĩa của từ {ClassDanhSachCauHoi._list[index].TuVung.ToUpper()} ({ClassDanhSachCauHoi._list[index].TuLoai})"
            };
            var num = Enumerable.Range(0, 6).OrderBy(x => rnd.Next()).Take(1).ToList();
            txtCauHoi.Text = DangCauHoi[num[0]];

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
            if (dapAnDung == ClassDanhSachCauHoi._list[index].DapAnDung)
            {
                ClassDanhSachCauHoi._list[index].TraLoiDung = true;
            }
            else
            {
                ClassDanhSachCauHoi._list[index].TraLoiDung = false;
            }
            lblSoCauHoanThanh.Text = SoCauHoanThanh() + "/10";
        }

        public string TongDiem()
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

        public string SoCauChuaLam()
        {
            int sum = 0;
            foreach (var item in ClassDanhSachCauHoi._list)
            {
                if (!item.DaTraLoi)
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