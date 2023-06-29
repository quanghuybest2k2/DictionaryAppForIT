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
        public string TuLoai { get; set; }
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

        public CauHoiVaDapAn(int stt, string tuVung, string tuLoai, string dapAnDung)
        {
            Stt = stt;
            TuVung = tuVung;
            TuLoai = tuLoai;
            DapAnDung = dapAnDung;
            DapAnRandom = new List<string>();
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
