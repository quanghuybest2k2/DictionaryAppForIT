using DictionaryAppForIT.DAL;
using DictionaryAppForIT.DTO;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DictionaryAppForIT.UserControls.MiniGame
{
    public class CauHoiVaDapAn
    {
        public bool DaTraLoi;
        public bool TraLoiDung;
        public string CauTraLoi { get; set; }
        public int Stt { get; set; }
        public string TuVung { get; set; }
        public string DapAnDung { get; set; }
        public List<string> DapAnRandom;
        private string connString = ConfigurationManager.ConnectionStrings["DictionaryApp"].ConnectionString;

        public CauHoiVaDapAn()
        {
            DapAnRandom = new List<string>();
            CauTraLoi = "";
            TraLoiDung = false;
            DaTraLoi = false;
        }

        public CauHoiVaDapAn(int stt, string tuVung, string dapAnDung)
        {
            Stt = stt;
            TuVung = tuVung;
            DapAnDung = dapAnDung;
            DapAnRandom = new List<string>();
        }

        public void LoadCauHoi(int stt)
        {
            Stt = stt;
            // lay tu vung
            object tv = DataProvider.Instance.ExecuteScalar($"select top 1 TiengAnh from LichSuTraTu where IDTK = '{Class_TaiKhoan.IdTaiKhoan}' ORDER  BY NEWID()");
            TuVung = tv.ToString();
            // lay nghia
            object da = DataProvider.Instance.ExecuteScalar($"select top 1 TiengViet from LichSuTraTu where TiengAnh = '{TuVung}'and IDTK = '{Class_TaiKhoan.IdTaiKhoan}' ORDER  BY NEWID()");
            DapAnDung = da.ToString();
            //object rdDa = DataProvider.Instance.ExecuteQuery($"EXEC RandomDapAn '{ClassCauHoiVaDapAn.DapAnDung}'");
            RandomDapAnSai();
        }
        public void RandomDapAnSai()
        {
            try
            {
                SqlConnection Conn = new SqlConnection(connString);
                SqlCommand cmd = new SqlCommand($"EXEC RandomDapAn '{TuVung}'", Conn);
                Conn.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                string dapAn;
                while (rdr.Read())
                {
                    dapAn = rdr["TiengViet"].ToString();
                    DapAnRandom.Add(dapAn);
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
