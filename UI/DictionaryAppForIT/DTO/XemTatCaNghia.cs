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
                SqlCommand cmd = new SqlCommand($"EXEC HienThiThongTin '{tenTu}'", Conn);
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
                //Wordlength: số từ có trong database
                object Wordlength = DataProvider.Instance.ExecuteScalar("select count(TenTu) from Tu");
                Random rand = new Random();
                int kqRand = rand.Next(1, Convert.ToInt32(Wordlength));

                _listTu.Clear();
                SqlConnection Conn = new SqlConnection(connString);
                SqlCommand cmd = new SqlCommand($"EXEC TuNgauNhien {kqRand}", Conn);
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
