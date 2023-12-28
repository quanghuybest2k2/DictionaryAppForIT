using DictionaryAppForIT.Class;
using DictionaryAppForIT.DTO;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;

namespace DictionaryAppForIT.UserControls.MiniGame
{
    public class DanhSachCauHoi
    {
        private string connString = ConfigurationManager.ConnectionStrings["DictionaryApp"].ConnectionString;

        public int demSoTu = 0;
        public List<CauHoiVaDapAn> _list;
        CauHoiVaDapAn _item;
        public DanhSachCauHoi()
        {
            _list = new List<CauHoiVaDapAn>();
            _item = new CauHoiVaDapAn();
        }

        public void LoadDSCauHoi()
        {
            try
            {
                SqlConnection Conn = new SqlConnection(connString);
                SqlCommand cmd = new SqlCommand($"EXEC RandomMiniGame '{Class_TaiKhoan.IdTaiKhoan}'", Conn);
                Conn.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                string TiengAnh;
                string TenLoai;
                string TiengViet;
                while (rdr.Read())
                {
                    demSoTu++;
                    TiengAnh = rdr["TiengAnh"].ToString();
                    TenLoai = rdr["TenLoai"].ToString();
                    TiengViet = rdr["TiengViet"].ToString();
                    _item = new CauHoiVaDapAn(demSoTu, TiengAnh, TenLoai, TiengViet);
                    _item.RandomDapAnSai();
                    _list.Add(_item);
                }
                Conn.Close();
                Conn.Dispose();
            }
            catch (Exception ex)
            {
                RJMessageBox.Show(ex.Message);
            }
        }
        public void BoSungCauHoiNeuChuaDu(int index)
        {
            if (index < 10)
            {
                int num = 10 - index;
                try
                {
                    SqlConnection Conn = new SqlConnection(connString);
                    SqlCommand cmd = new SqlCommand($"EXEC RandomNeuChuaDu '{num}'", Conn);
                    Conn.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();
                    string TiengAnh;
                    string TenLoai;
                    string TiengViet;
                    while (rdr.Read())
                    {
                        demSoTu++;
                        TiengAnh = rdr["TenTu"].ToString();
                        TenLoai = rdr["TenLoai"].ToString();
                        TiengViet = rdr["Nghia"].ToString();
                        _item = new CauHoiVaDapAn(demSoTu, TiengAnh, TenLoai, TiengViet);
                        _item.RandomDapAnSai();
                        _list.Add(_item);
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
    }
}
