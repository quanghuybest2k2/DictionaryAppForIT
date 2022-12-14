using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DictionaryAppForIT.DAL;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Data;
using System.Configuration;

namespace DictionaryAppForIT.DTO
{
    public class XemTatCaNghia
    {
        private string connString = ConfigurationManager.ConnectionStrings["DictionaryApp"].ConnectionString;
        public List<Tu> _listTu = new List<Tu>();
        public XemTatCaNghia()
        {

        }
        public void HienThiThongTinTimKiem(string tenTu)
        {
            try
            {
                _listTu.Clear();
                SqlConnection Conn = new SqlConnection(connString);
                SqlCommand cmd = new SqlCommand($"EXEC HienThiThongTin '{tenTu}', '{Class_TaiKhoan.IdTaiKhoan}'", Conn);
                Conn.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    Tu tu = new Tu();
                    tu.TenTu = rdr["TenTu"].ToString();
                    tu.TenLoai = rdr["TenLoai"].ToString();
                    tu.PhienAm = rdr["PhienAm"].ToString();
                    tu.TenChuyenNganh = rdr["TenChuyenNganh"].ToString();
                    tu.Nghia = rdr["Nghia"].ToString();
                    tu.MoTa = rdr["MoTa"].ToString();
                    tu.ViDu = rdr["ViDu"].ToString();

                    tu.DongNghia = rdr["DongNghia"].ToString();

                    tu.TraiNghia = rdr["TraiNghia"].ToString();
                    _listTu.Add(tu);
                }
                Conn.Close();
                Conn.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void HienThiThongTinRandom()
        {
            try
            {
                object kqRand = DataProvider.Instance.ExecuteScalar($"SELECT TOP 1 ID FROM Tu where IDTK = '{Class_TaiKhoan.IdTaiKhoan}' or IDTK = '0' ORDER  BY NEWID()");
                _listTu.Clear();
                SqlConnection Conn = new SqlConnection(connString);
                SqlCommand cmd = new SqlCommand($"EXEC TuNgauNhien '{Convert.ToInt32(kqRand)}', '{Class_TaiKhoan.IdTaiKhoan}'", Conn);
                Conn.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    Tu tu = new Tu();
                    tu.TenTu = rdr["TenTu"].ToString();
                    tu.TenLoai = rdr["TenLoai"].ToString();
                    tu.PhienAm = rdr["PhienAm"].ToString();
                    tu.TenChuyenNganh = rdr["TenChuyenNganh"].ToString();
                    tu.Nghia = rdr["Nghia"].ToString();
                    tu.MoTa = rdr["MoTa"].ToString();
                    tu.ViDu = rdr["ViDu"].ToString();

                    tu.DongNghia = rdr["DongNghia"].ToString();

                    tu.TraiNghia = rdr["TraiNghia"].ToString();
                    _listTu.Add(tu);
                }
                Conn.Close();
                Conn.Dispose();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
