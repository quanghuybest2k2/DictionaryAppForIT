using DictionaryAppForIT.Class;
using DictionaryAppForIT.DAL;
using DictionaryAppForIT.DTO;
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

namespace DictionaryAppForIT.UserControls.TuVungHot
{
    public partial class UC_TVHot : UserControl
    {
        RandomColor rd = new RandomColor();
        UC_TVH_Item uc;
        private string connString = ConfigurationManager.ConnectionStrings["DictionaryApp"].ConnectionString;

        public UC_TVHot()
        {
            uc = new UC_TVH_Item();
            InitializeComponent();
        }

        public void HienThiTuVungHot()
        {
            flpContent.Controls.Clear();
            int stt = 1;
            object num = DataProvider.Instance.ExecuteScalar($"select COUNT(ID) from LichSuTraTu where IDTK = {Class_TaiKhoan.IdTaiKhoan}");
            if (Convert.ToInt32(num) > 0)
            {
                try
                {
                    SqlConnection Conn = new SqlConnection(connString);
                    SqlCommand cmd = new SqlCommand($"EXEC HienThiTuVungHot", Conn);
                    Conn.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        //ThongTinLSTraTu.idTraTuLS = rdr["ID"].ToString();
                        string TiengAnh = rdr["TiengAnh"].ToString();
                        string PhienAm = rdr["PhienAm"].ToString();
                        string TiengViet = rdr["TiengViet"].ToString();
                        string soLuotXem = rdr["soLanXuatHien"].ToString();
                        uc = new UC_TVH_Item(stt.ToString(), TiengAnh, PhienAm, TiengViet, soLuotXem);
                        uc.TVHBackColor(rd.GetColor());
                        flpContent.Controls.Add(uc);
                        stt++;
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
