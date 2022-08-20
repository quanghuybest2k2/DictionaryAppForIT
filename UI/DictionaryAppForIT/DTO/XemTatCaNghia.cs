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
        public List<Tu> _listTu = new List<Tu>();
        public XemTatCaNghia()
        {

        }
        public void XemTatCaNghiaTu(string tenTu)
        {
            try
            {
                SqlConnection Conn = new SqlConnection(@"Data Source=DESKTOP-M9DGN9B;Initial Catalog=EnglishDictionary;Integrated Security=True");
                SqlCommand cmd = new SqlCommand($"exec XemTatCaNghiaCuaTu '{tenTu}'", Conn);
                Conn.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                //int i = 0;
                while (rdr.Read())
                {
                    Tu tu = new Tu();
                    tu.TenTu = rdr["TenTu"].ToString();
                    tu.TenLoai = rdr["TenLoai"].ToString();
                    tu.Nghia = rdr["Nghia"].ToString();
                    tu.MoTa = rdr["MoTa"].ToString();
                    tu.ViDu = rdr["ViDu"].ToString();
                    _listTu.Add(tu);
                }
                Conn.Close();
                Conn.Dispose();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            //DataTable tb = DataProvider.Instance.ExecuteQuery($"exec XemTatCaNghiaCuaTu '{tenTu}'");
            //_listNghia.Add(tb);
        }
    }
}
