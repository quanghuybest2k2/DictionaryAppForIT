using Bunifu.UI.WinForms;
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

        public UC_LichSu()
        {
            InitializeComponent();
            speech = new SpeechSynthesizer();
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
                        //ThongTinLSTraTu.idTraTuLS = rdr["ID"].ToString();
                        idHienTai = rdr["ID"].ToString();
                        string[] arrThoiGian = rdr["NgayHienTai"].ToString().Trim().Split(' ');
                        string ThoiGian = arrThoiGian[1] + " " + arrThoiGian[2];
                        string NgayThang = arrThoiGian[0];
                        string TVTiengAnh = rdr["TiengAnh"].ToString();
                        string TVPhienAm = rdr["PhienAm"].ToString();
                        string TVTiengViet = rdr["TiengViet"].ToString();
                        ucLSTuVung = new UC_LS_TuVung(idHienTai, ThoiGian, NgayThang, TVTiengAnh, TVPhienAm, TVTiengViet);
                        //ucLSTuVung.CheckChonLSTraTu.CheckedChanged += new EventHandler<BunifuCheckBox.CheckedChangedEventArgs>(chkChonLSTraTu_CheckedChanged);
                        //if (i==9)
                        //{
                            //speech.SelectVoiceByHints(VoiceGender.Male); // giong nam
                            //speech.SpeakAsync(ucLSTuVung.TVTiengAnh);
                        //}
                        flpContent.Controls.Add(ucLSTuVung);
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
            object num = DataProvider.Instance.ExecuteScalar("select COUNT(ID) from LichSuDich");
            if (Convert.ToInt32(num) > 0)
            {
                try
                {
                    SqlConnection Conn = new SqlConnection(connString);
                    SqlCommand cmd = new SqlCommand($"SELECT * FROM LichSuDich", Conn);
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
            int num = DataProvider.Instance.ExecuteNonQuery("delete from LichSuTraTu delete from LichSuDich");
            if (num > 0)
            {
                RJMessageBox.Show("Đã xóa tất cả lịch sử!");
                HienThiLSTraTu();
                HienThiLSDich();
            }
            else { RJMessageBox.Show("Xóa không thành công!"); }
        }
    }
}
