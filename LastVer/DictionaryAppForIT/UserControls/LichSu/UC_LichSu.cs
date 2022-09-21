using DictionaryAppForIT.Class;
using DictionaryAppForIT.DAL;
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

namespace DictionaryAppForIT.UserControls.GanDay
{
    public partial class UC_LichSu : UserControl
    {
        //UC_LS_VanBan ucVanBan;
        UC_LS_TuVung ucLSTuVung;


        private string connString = ConfigurationManager.ConnectionStrings["DictionaryApp"].ConnectionString;

        public UC_LichSu()
        {
            InitializeComponent();
        }

        public void HienThiLSTraTu()
        {
            flpContent.Controls.Clear();
            object num = DataProvider.Instance.ExecuteScalar("select COUNT(ID) from LichSuTraTu");
            if (Convert.ToInt32(num) > 0)
            {
                try
                {
                    SqlConnection Conn = new SqlConnection(connString);
                    SqlCommand cmd = new SqlCommand($"select * from LichSuTraTu", Conn);
                    Conn.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        string[] arrThoiGian = rdr["NgayHienTai"].ToString().Trim().Split(' ');
                        string ThoiGian = arrThoiGian[1] + " " + arrThoiGian[2];
                        string NgayThang = arrThoiGian[0];
                        string TVTiengAnh = rdr["TiengAnh"].ToString();
                        string TVPhienAm = rdr["PhienAm"].ToString();
                        string TVTiengViet = rdr["TiengViet"].ToString();
                        ucLSTuVung = new UC_LS_TuVung(ThoiGian, NgayThang, TVTiengAnh, TVPhienAm, TVTiengViet);
                        flpContent.Controls.Add(ucLSTuVung);
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

        private void flpContent_Paint(object sender, PaintEventArgs e)
        {

        }
        
    }
}
