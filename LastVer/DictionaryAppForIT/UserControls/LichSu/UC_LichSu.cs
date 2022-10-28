using Bunifu.UI.WinForms;
using DictionaryAppForIT.Class;
using DictionaryAppForIT.DAL;
using DictionaryAppForIT.DTO;
using DictionaryAppForIT.UserControls.LichSu;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Speech.Synthesis;

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

        public void HienThiLSTraTu()
        {
            _listUCLSTV.Clear();
            flpContent.Controls.Clear();
            object num = DataProvider.Instance.ExecuteScalar($"select COUNT(ID) from LichSuTraTu where IDTK = {Class_TaiKhoan.IdTaiKhoan}");
            if (Convert.ToInt32(num) > 0)
            {
                try
                {
                    SqlConnection Conn = new SqlConnection(connString);
                    SqlCommand cmd = new SqlCommand($"select * from LichSuTraTu where IDTK = {Class_TaiKhoan.IdTaiKhoan}", Conn);
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

        public void HienThiLSDich()
        {
            object num = DataProvider.Instance.ExecuteScalar($"select COUNT(ID) from LichSuDich where IDTK = {Class_TaiKhoan.IdTaiKhoan}");
            if (Convert.ToInt32(num) > 0)
            {
                try
                {
                    SqlConnection Conn = new SqlConnection(connString);
                    SqlCommand cmd = new SqlCommand($"SELECT * FROM LichSuDich where IDTK = {Class_TaiKhoan.IdTaiKhoan}", Conn);
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

        private void XoaUCLSTuVung()
        {
            foreach (var item in _listUCLSTV)
            {
                //MessageBox.Show(c.Name, "", MessageBoxButtons.OK);
                //c as UC_LS_TuVung
                if (item.Name == "Check")//c.ChkChonLSTraTu.Checked
                {
                    xoaTatCa = false;
                    flpContent.Controls.Remove(item);
                    DataProvider.Instance.ExecuteNonQuery($"delete from LichSuTraTu where id = {item.Index} and IDTK = {Class_TaiKhoan.IdTaiKhoan}");
                }
            }
            _listUCLSTV.RemoveAll(x => x.Name == "Check");
        }

        private void XoaUCLSVanBan()
        {
            foreach (var item in _listUCLSVB)
            {
                //MessageBox.Show(c.Name, "", MessageBoxButtons.OK);
                //c as UC_LS_TuVung
                if (item.Name == "Check")//c.ChkChonLSTraTu.Checked
                {
                    xoaTatCa = false;
                    flpContent.Controls.Remove(item);
                    DataProvider.Instance.ExecuteNonQuery($"delete from LichSuDich where id = {item.Index} and IDTK = {Class_TaiKhoan.IdTaiKhoan}");
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
                int num = DataProvider.Instance.ExecuteNonQuery($"delete from LichSuTraTu where IDTK = {Class_TaiKhoan.IdTaiKhoan} " +
                  $"delete from LichSuDich where IDTK = {Class_TaiKhoan.IdTaiKhoan}");
                if (num > 0)
                {
                    RJMessageBox.Show("Đã xóa tất cả lịch sử!");
                }
                else { RJMessageBox.Show("Xóa không thành công!"); }
                _listUCLSTV.Clear();
            }
        }

        private void btnXoaDuLieu_ControlRemoved(object sender, ControlEventArgs e)
        {

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
                SqlCommand cmd = new SqlCommand($"EXEC HienThiTimKiemLSTT '{txtTimKiemLS.Text.Trim()}', {Class_TaiKhoan.IdTaiKhoan}", Conn);
                Conn.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    //ThongTinLSTraTu.idTraTuLS = rdr["ID"].ToString();
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
                SqlCommand cmd = new SqlCommand($"EXEC HienThiTimKiemLSD '{txtTimKiemLS.Text.Trim()}', {Class_TaiKhoan.IdTaiKhoan}", Conn);
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
                MessageBox.Show(ex.Message);
            }
        }

        private void UC_LichSu_Load(object sender, EventArgs e)
        {
           
        }
    }
}
