using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DictionaryAppForIT.DAL;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Data;

namespace DictionaryAppForIT.DTO
{
    public class XemTatCaNghia
    {
        string connString = @"Data Source=DESKTOP-M9DGN9B;Initial Catalog=EnglishDictionary;Integrated Security=True";
        public List<Tu> _listTu = new List<Tu>();
        public XemTatCaNghia()
        {

        }
        public void HienThiThongTinTimKiem(string tenTu)
        {
            try
            {
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
    }
}
