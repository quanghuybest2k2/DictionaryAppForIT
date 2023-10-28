using DictionaryAppForIT.Class;
using DictionaryAppForIT.DAL;
using DictionaryAppForIT.DTO;
using DictionaryAppForIT.UserControls.LichSu;
using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Speech.Synthesis;
using System.Windows.Forms;

namespace DictionaryAppForIT.UserControls.GanDay
{
    public partial class UC_LichSu : UserControl
    {
        UC_LS_TuVung ucLSTuVung;
        UC_LS_VanBan ucLSVanBan;
        SpeechSynthesizer speech;
        public static string idHienTai;
        public string TuHienTai = "";
        private string connString = ConfigurationManager.ConnectionStrings["DictionaryApp"].ConnectionString;
        List<UC_LS_TuVung> _listUCLSTV;
        List<UC_LS_VanBan> _listUCLSVB;

        bool xoaTatCa;

        public UC_LichSu()
        {
            InitializeComponent();
            speech = new SpeechSynthesizer();
            _listUCLSTV = new List<UC_LS_TuVung>();
            _listUCLSVB = new List<UC_LS_VanBan>();
        }

        public async void HienThiLSTraTu()
        {
            _listUCLSTV.Clear();
            flpContent.Controls.Clear();
            try
            {
                var wordLookUpList = WordHistoryService.LoadWordLookupHistory();

                if (wordLookUpList != null)
                {
                    foreach (var history in await wordLookUpList)
                    {
                        idHienTai = history.id.ToString();
                        string NgayThang = DateTime.Parse(history.created_at).ToLocalTime().ToString("dd/MM/yyyy");
                        string ThoiGian = DateTime.Parse(history.created_at).ToLocalTime().ToString("HH:mm:ss");
                        string TVTiengAnh = history.English;
                        string TVPhienAm = history.Pronunciation;
                        string TVTiengViet = history.Vietnamese;
                        ucLSTuVung = new UC_LS_TuVung(idHienTai, ThoiGian, NgayThang, TVTiengAnh, TVPhienAm, TVTiengViet);

                        flpContent.Controls.Add(ucLSTuVung);
                        _listUCLSTV.Add(ucLSTuVung);
                        ucLSTuVung.Name = "unCheck";
                    }
                }
                else
                {
                    ucLSTuVung = new UC_LS_TuVung(null, null, null, null, null, null);
                }
            }
            catch (Exception ex)
            {
                RJMessageBox.Show(ex.Message);
            }
        }

        public async void HienThiLSDich()
        {
            try
            {
                var TextLookUpList = TranslateHistoryService.LoadLichSu();

                if (TextLookUpList != null)
                {
                    foreach (var history in await TextLookUpList)
                    {
                        idHienTai = history.Id.ToString();
                        string NgayThang = DateTime.Parse(history.Created_At).ToLocalTime().ToString("dd/MM/yyyy");
                        string ThoiGian = DateTime.Parse(history.Created_At).ToLocalTime().ToString("HH:mm:ss");
                        string TVTiengAnh = history.English;
                        string TVTiengViet = history.Vietnamese;

                        ucLSVanBan = new UC_LS_VanBan(idHienTai, ThoiGian, NgayThang, TVTiengAnh, TVTiengViet);
                        flpContent.Controls.Add(ucLSVanBan);

                        _listUCLSVB.Add(ucLSVanBan);
                        ucLSVanBan.Name = "unCheck";
                    }
                }
                else
                {
                    ucLSVanBan = new UC_LS_VanBan(null, null, null, null, null);
                }
            }
            catch (Exception ex)
            {
                RJMessageBox.Show(ex.Message);
            }
        }

        private void XoaUCLSTuVung()
        {
            foreach (var item in _listUCLSTV)
            {
                if (item.Name == "Check")
                {
                    xoaTatCa = false;
                    flpContent.Controls.Remove(item);
                    DataProvider.Instance.ExecuteNonQuery($"delete from LichSuTraTu where id = '{item.Index}' and IDTK = '{Class_TaiKhoan.IdTaiKhoan}'");
                }
            }
            _listUCLSTV.RemoveAll(x => x.Name == "Check");
        }

        private void XoaUCLSVanBan()
        {
            foreach (var item in _listUCLSVB)
            {
                if (item.Name == "Check")
                {
                    xoaTatCa = false;
                    flpContent.Controls.Remove(item);
                    DataProvider.Instance.ExecuteNonQuery($"delete from LichSuDich where id = '{item.Index}' and IDTK = '{Class_TaiKhoan.IdTaiKhoan}'");
                }
            }
            _listUCLSVB.RemoveAll(x => x.Name == "Check");
        }

        private void btnXoaDuLieu_Click(object sender, EventArgs e)
        {
            xoaTatCa = true;
            XoaUCLSTuVung();
            XoaUCLSVanBan();

            if (xoaTatCa)
            {

                flpContent.Controls.Clear();
                int num = DataProvider.Instance.ExecuteNonQuery($"delete from LichSuTraTu where IDTK = '{Class_TaiKhoan.IdTaiKhoan}' " +
                  $"delete from LichSuDich where IDTK = '{Class_TaiKhoan.IdTaiKhoan}'");
                if (num > 0)
                {
                    RJMessageBox.Show("Đã xóa tất cả lịch sử!", "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                }
                else
                {
                    RJMessageBox.Show("Xóa không thành công!", "Thông báo",
                     MessageBoxButtons.OK,
                     MessageBoxIcon.Error);
                }
                _listUCLSTV.Clear();
            }
        }

        private void txtTimKiemLS_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && TuHienTai != txtTimKiemLS.Text)//--------------------------------------
            {
                flpContent.Controls.Clear();  //-------------------------------------- Khi người ta enter mới xóa flpMeaning
                HienThiTimKiemLSTT();
                HienThiTimKiemLSD();
                TuHienTai = txtTimKiemLS.Text;//--------------------------------------

            }
        }
        private void HienThiTimKiemLSTT()
        {
            try
            {
                SqlConnection Conn = new SqlConnection(connString);
                SqlCommand cmd = new SqlCommand($"EXEC HienThiTimKiemLSTT '{txtTimKiemLS.Text.Trim()}', '{Class_TaiKhoan.IdTaiKhoan}'", Conn);
                Conn.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    idHienTai = rdr["ID"].ToString();
                    string[] arrThoiGian = rdr["NgayHienTai"].ToString().Trim().Split(' ');
                    string ThoiGian = arrThoiGian[1] + " " + arrThoiGian[2];
                    string NgayThang = arrThoiGian[0];
                    string TVTiengAnh = rdr["TiengAnh"].ToString();
                    string TVPhienAm = rdr["PhienAm"].ToString();
                    string TVTiengViet = rdr["TiengViet"].ToString();
                    ucLSTuVung = new UC_LS_TuVung(idHienTai, ThoiGian, NgayThang, TVTiengAnh, TVPhienAm, TVTiengViet);

                    flpContent.Controls.Add(ucLSTuVung);
                    _listUCLSTV.Add(ucLSTuVung);
                    ucLSTuVung.Name = "unCheck";
                }
                Conn.Close();
                Conn.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void HienThiTimKiemLSD()
        {
            try
            {
                SqlConnection Conn = new SqlConnection(connString);
                SqlCommand cmd = new SqlCommand($"EXEC HienThiTimKiemLSD '{txtTimKiemLS.Text.Trim()}', '{Class_TaiKhoan.IdTaiKhoan}'", Conn);
                Conn.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    idHienTai = rdr["ID"].ToString();
                    string[] arrThoiGian = rdr["NgayHienTai"].ToString().Trim().Split(' ');
                    string ThoiGian = arrThoiGian[1] + " " + arrThoiGian[2];
                    string NgayThang = arrThoiGian[0];

                    string TVTiengAnh = rdr["TiengAnh"].ToString();
                    string TVTiengViet = rdr["TiengViet"].ToString();
                    ucLSVanBan = new UC_LS_VanBan(idHienTai, ThoiGian, NgayThang, TVTiengAnh, TVTiengViet);
                    flpContent.Controls.Add(ucLSVanBan);

                    _listUCLSVB.Add(ucLSVanBan);
                    ucLSVanBan.Name = "unCheck";
                }
                Conn.Close();
                Conn.Dispose();
            }
            catch (Exception ex)
            {
                RJMessageBox.Show(ex.Message);
            }
        }

        private void UC_LichSu_Load(object sender, EventArgs e)
        {

        }

        public void HienThiLSDichTheoThoiGian(string thoiGian)
        {
            object num = DataProvider.Instance.ExecuteScalar($"select COUNT(ID) from LichSuDich where IDTK = '{Class_TaiKhoan.IdTaiKhoan}'");
            if (Convert.ToInt32(num) > 0)
            {
                try
                {
                    SqlConnection Conn = new SqlConnection(connString);
                    SqlCommand cmd = new SqlCommand($"select * from LichSuDich where IDTK = '{Class_TaiKhoan.IdTaiKhoan}'  and NgayHienTai like '%{thoiGian}%'", Conn);
                    Conn.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        idHienTai = rdr["ID"].ToString();
                        string[] arrThoiGian = rdr["NgayHienTai"].ToString().Trim().Split(' ');
                        string ThoiGian = arrThoiGian[1] + " " + arrThoiGian[2];
                        string NgayThang = arrThoiGian[0];
                        string TVTiengAnh = rdr["TiengAnh"].ToString();
                        string TVTiengViet = rdr["TiengViet"].ToString();
                        ucLSVanBan = new UC_LS_VanBan(idHienTai, ThoiGian, NgayThang, TVTiengAnh, TVTiengViet);
                        flpContent.Controls.Add(ucLSVanBan);
                        _listUCLSVB.Add(ucLSVanBan);
                        ucLSVanBan.Name = "unCheck";
                    }
                    Conn.Close();
                    Conn.Dispose();

                }
                catch (Exception ex)
                {
                    RJMessageBox.Show(ex.Message);
                }
            }
        }


        public void HienThiLSTraTuTheoThoiGian(string thoiGian)
        {
            object num = DataProvider.Instance.ExecuteScalar($"select COUNT(ID) from LichSuTraTu where IDTK = '{Class_TaiKhoan.IdTaiKhoan}'");
            if (Convert.ToInt32(num) > 0)
            {
                try
                {
                    SqlConnection Conn = new SqlConnection(connString);
                    SqlCommand cmd = new SqlCommand($"select * from LichSuTraTu where IDTK = '{Class_TaiKhoan.IdTaiKhoan}'  and NgayHienTai like '%{thoiGian}%'", Conn);
                    Conn.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        idHienTai = rdr["ID"].ToString();
                        string[] arrThoiGian = rdr["NgayHienTai"].ToString().Trim().Split(' ');
                        string ThoiGian = arrThoiGian[1] + " " + arrThoiGian[2];
                        string NgayThang = arrThoiGian[0];
                        string TVTiengAnh = rdr["TiengAnh"].ToString();
                        string TVPhienAm = rdr["PhienAm"].ToString();
                        string TVTiengViet = rdr["TiengViet"].ToString();
                        ucLSTuVung = new UC_LS_TuVung(idHienTai, ThoiGian, NgayThang, TVTiengAnh, TVPhienAm, TVTiengViet);

                        flpContent.Controls.Add(ucLSTuVung);
                        _listUCLSTV.Add(ucLSTuVung);
                        ucLSTuVung.Name = "unCheck";
                    }

                    Conn.Close();
                    Conn.Dispose();
                }
                catch (Exception ex)
                {
                    RJMessageBox.Show(ex.Message);
                }
            }
        }
        private void btnTatCa_Click(object sender, EventArgs e)
        {
            HienThiLSTraTu();
            HienThiLSDich();
        }

        private void btnThoiGian_Click(object sender, EventArgs e)
        {
            DateTime today = DateTime.Today;
            int currentDayOfWeek = (int)today.DayOfWeek;
            DateTime sunday = today.AddDays(-currentDayOfWeek);
            DateTime monday = sunday.AddDays(1);
            Console.WriteLine(currentDayOfWeek);
            if (currentDayOfWeek == 0)
            {
                monday = monday.AddDays(-7);
            }
            var dates = Enumerable.Range(0, 7).Select(days => monday.AddDays(days)).ToList();



            string loai = (sender as Guna2Button).Name;
            switch (loai)
            {
                case "btnHomNay":
                    _listUCLSTV.Clear();
                    flpContent.Controls.Clear();
                    HienThiLSTraTuTheoThoiGian(DateTime.Today.ToString("dd/MM/yyyy"));
                    HienThiLSDichTheoThoiGian(DateTime.Today.ToString("dd/MM/yyyy"));
                    break;
                case "btnHomQua":
                    _listUCLSTV.Clear();
                    flpContent.Controls.Clear();
                    HienThiLSTraTuTheoThoiGian(DateTime.Today.AddDays(-1).ToString("dd/MM/yyyy"));
                    HienThiLSDichTheoThoiGian(DateTime.Today.AddDays(-1).ToString("dd/MM/yyyy"));
                    break;
                case "btnTuanNay":
                    _listUCLSTV.Clear();
                    flpContent.Controls.Clear();
                    foreach (var item in dates)
                    {
                        HienThiLSTraTuTheoThoiGian(item.ToString("dd/MM/yyyy"));
                        HienThiLSDichTheoThoiGian(item.ToString("dd/MM/yyyy"));
                    }
                    break;
                case "btnThangNay":
                    _listUCLSTV.Clear();
                    flpContent.Controls.Clear();
                    HienThiLSTraTuTheoThoiGian(DateTime.Today.ToString("MM/yyyy"));
                    HienThiLSDichTheoThoiGian(DateTime.Today.ToString("MM/yyyy"));
                    break;
                case "btnCuHon":
                    _listUCLSTV.Clear();
                    flpContent.Controls.Clear();
                    //tra tu
                    HienThiLSTraTuTheoThoiGian(DateTime.Today.AddMonths(-1).ToString("MM/yyyy"));
                    HienThiLSTraTuTheoThoiGian(DateTime.Today.AddMonths(-2).ToString("MM/yyyy"));
                    HienThiLSTraTuTheoThoiGian(DateTime.Today.AddMonths(-3).ToString("MM/yyyy"));
                    HienThiLSTraTuTheoThoiGian(DateTime.Today.AddMonths(-4).ToString("MM/yyyy"));
                    // dich
                    HienThiLSDichTheoThoiGian(DateTime.Today.AddMonths(-1).ToString("MM/yyyy"));
                    HienThiLSDichTheoThoiGian(DateTime.Today.AddMonths(-2).ToString("MM/yyyy"));
                    HienThiLSDichTheoThoiGian(DateTime.Today.AddMonths(-3).ToString("MM/yyyy"));
                    HienThiLSDichTheoThoiGian(DateTime.Today.AddMonths(-4).ToString("MM/yyyy"));
                    break;
            }
        }
    }
}
