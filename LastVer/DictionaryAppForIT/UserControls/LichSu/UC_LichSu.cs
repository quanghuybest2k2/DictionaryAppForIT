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
        UC_LS_VanBan uc_LSVanBan;
        SpeechSynthesizer speech;
        public static string idHienTai;

        private string connString = ConfigurationManager.ConnectionStrings["DictionaryApp"].ConnectionString;
        List<UC_LS_TuVung> _list;
        public UC_LichSu()
        {
            InitializeComponent();
            speech = new SpeechSynthesizer();
            _list = new List<UC_LS_TuVung>();
        }

        public void HienThiLSTraTu()
        {
            _list.Clear();
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
                        _list.Add(ucLSTuVung);
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
                        string[] arrThoiGian = rdr["NgayHienTai"].ToString().Trim().Split(' ');
                        string ThoiGian = arrThoiGian[1] + " " + arrThoiGian[2];
                        string NgayThang = arrThoiGian[0];
                        string TVTiengAnh = rdr["TiengAnh"].ToString();
                        string TVTiengViet = rdr["TiengViet"].ToString();
                        uc_LSVanBan = new UC_LS_VanBan(ThoiGian, NgayThang, TVTiengAnh, TVTiengViet);
                        flpContent.Controls.Add(uc_LSVanBan);
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
        private void flpContent_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnXoaDuLieu_Click(object sender, EventArgs e)
        {
            bool xoaTatCa = true;
            foreach (var item in _list)
            {
                //MessageBox.Show(c.Name, "", MessageBoxButtons.OK);
                //c as UC_LS_TuVung
                if (item.Name == "Check")//c.ChkChonLSTraTu.Checked
                {
                    xoaTatCa = false;
                    flpContent.Controls.Remove(item);

                }
            }
            _list.RemoveAll(x => x.Name == "Check");
            //string name = "";
            //foreach (Control item in flpContent.Controls)
            //{
            //    name += " " + item.Name;
            //}
            //MessageBox.Show(xoaTatCa.ToString(), "", MessageBoxButtons.OK);

            if (xoaTatCa)
            {

                flpContent.Controls.Clear();
                int num = DataProvider.Instance.ExecuteNonQuery($"delete from LichSuTraTu where IDTK = {Class_TaiKhoan.IdTaiKhoan} " +
                  $"delete from LichSuDich where IDTK = {Class_TaiKhoan.IdTaiKhoan}");
                if (num > 0)
                {
                    RJMessageBox.Show("Đã xóa tất cả lịch sử!");
                    //HienThiLSTraTu();
                    //HienThiLSDich();
                }
                else { RJMessageBox.Show("Xóa không thành công!"); }
                _list.Clear();
            }
        }

        private void btnXoaDuLieu_ControlRemoved(object sender, ControlEventArgs e)
        {

        }
    }
}
