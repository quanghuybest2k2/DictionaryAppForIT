using DictionaryAppForIT.Class;
using DictionaryAppForIT.DAL;
using DictionaryAppForIT.DTO;
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

namespace DictionaryAppForIT.UserControls.YeuThich
{
    public partial class UC_YeuThich : UserControl
    {
        RandomColor rd = new RandomColor();
        List<UC_YT_TuVung> _listTuVung;
        List<UC_YT_VanBan> _listVanBan;
        private string connString = ConfigurationManager.ConnectionStrings["DictionaryApp"].ConnectionString;
        bool xoaTatCa;
        public static string idHienTai;
        UC_YT_TuVung ucYTTuVung;
        UC_YT_VanBan ucYTVanBan;
        int stt = 1;

        public UC_YeuThich()
        {
            InitializeComponent();

            _listTuVung = new List<UC_YT_TuVung>();
            _listVanBan = new List<UC_YT_VanBan>();

            #region code demo
            //var ucTuVung = new UC_YT_TuVung("No.1", "Multiplication", "/ mʌltɪplɪˈkeɪʃən/", "Phép nhân");
            //ucTuVung.TVBackColor(rd.GetColor());
            //flpContent.Controls.Add(ucTuVung);
            
            //ucTuVung = new UC_YT_TuVung("No.2", "Operation", "/ɒpəˈreɪʃən/", "Thao tác");
            //ucTuVung.TVBackColor(rd.GetColor());
            //flpContent.Controls.Add(ucTuVung);

            //var ucVanBan = new UC_YT_VanBan("No.3", "President Joe Biden tested positive for Covid again late Saturday", "Tổng thống Joe Biden lại có kết quả dương tính với Covid vào cuối thứ Bảy");
            //ucVanBan.VBBackColor(rd.GetColor());
            //flpContent.Controls.Add(ucVanBan);

            //ucVanBan = new UC_YT_VanBan("No.4", "After testing negative on Tuesday evening, Wednesday morning, Thursday morning and Friday morning", "Sau khi thử nghiệm âm tính vào tối thứ Ba, sáng thứ Tư, sáng thứ Năm và sáng thứ Sáu");
            //ucVanBan.VBBackColor(rd.GetColor());
            //flpContent.Controls.Add(ucVanBan);

            //ucVanBan = new UC_YT_VanBan("No.5", "A White House official said they are in the process of contact tracing to determine close contacts.", "Một quan chức Nhà Trắng cho biết họ đang trong quá trình truy tìm liên lạc để xác định những người thân cận.");
            //ucVanBan.VBBackColor(rd.GetColor());
            //flpContent.Controls.Add(ucVanBan);

            //ucTuVung = new UC_YT_TuVung("No.6", "Numeric", "/nju(ː)ˈmɛrɪk/", "Số học, thuộc về số học");
            //ucTuVung.TVBackColor(rd.GetColor());
            //flpContent.Controls.Add(ucTuVung);

            //ucTuVung = new UC_YT_TuVung("No.7", "Pulse", "/pʌls/", "Xung");
            //ucTuVung.TVBackColor(rd.GetColor());
            //flpContent.Controls.Add(ucTuVung);

            //ucTuVung = new UC_YT_TuVung("No.8", "Subtraction", "/səbˈtrækʃən/", "Phép trừ");
            //ucTuVung.TVBackColor(rd.GetColor());
            //flpContent.Controls.Add(ucTuVung);

            //ucVanBan = new UC_YT_VanBan("No.9", "We are thrilled to have witnessed one of the biggest jackpot wins in Mega Millions history", "Chúng tôi rất vui mừng khi được chứng kiến ​​một trong những lần trúng giải độc đắc lớn nhất trong lịch sử Mega Millions");
            //ucVanBan.VBBackColor(rd.GetColor());
            //flpContent.Controls.Add(ucVanBan);
            #endregion

        }

        public void HienThiYTTraTu()
        {
            _listTuVung.Clear();
            flpContent.Controls.Clear();
            object num = DataProvider.Instance.ExecuteScalar($"select COUNT(ID) from YeuThichTuVung where IDTK = {Class_TaiKhoan.IdTaiKhoan}");
            if (Convert.ToInt32(num) > 0)
            {
                try
                {
                    SqlConnection Conn = new SqlConnection(connString);
                    SqlCommand cmd = new SqlCommand($"select * from YeuThichTuVung where IDTK = {Class_TaiKhoan.IdTaiKhoan}", Conn);
                    Conn.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        //ThongTinLSTraTu.idTraTuLS = rdr["ID"].ToString();
                        idHienTai = rdr["ID"].ToString();
                        string TVTiengAnh = rdr["TiengAnh"].ToString();
                        string TVPhienAm = rdr["PhienAm"].ToString();
                        string TVTiengViet = rdr["TiengViet"].ToString();
                        ucYTTuVung = new UC_YT_TuVung(stt.ToString(), idHienTai, TVTiengAnh, TVPhienAm, TVTiengViet);
                        ucYTTuVung.TVBackColor(rd.GetColor());
                        flpContent.Controls.Add(ucYTTuVung);
                        _listTuVung.Add(ucYTTuVung);
                        ucYTTuVung.Name = "unCheck";
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

        public void HienThiYTVanBan()
        {
            _listVanBan.Clear();
            //flpContent.Controls.Clear();
            object num = DataProvider.Instance.ExecuteScalar($"select COUNT(ID) from YeuThichVanBan where IDTK = {Class_TaiKhoan.IdTaiKhoan}");
            if (Convert.ToInt32(num) > 0)
            {
                try
                {
                    SqlConnection Conn = new SqlConnection(connString);
                    SqlCommand cmd = new SqlCommand($"select * from YeuThichVanBan where IDTK = {Class_TaiKhoan.IdTaiKhoan}", Conn);
                    Conn.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        //ThongTinLSTraTu.idTraTuLS = rdr["ID"].ToString();
                        idHienTai = rdr["ID"].ToString();
                        string TVTiengAnh = rdr["TiengAnh"].ToString();
                        string TVTiengViet = rdr["TiengViet"].ToString();
                        ucYTVanBan = new UC_YT_VanBan(stt.ToString(), idHienTai, TVTiengAnh, TVTiengViet);
                        ucYTVanBan.VBBackColor(rd.GetColor());
                        flpContent.Controls.Add(ucYTVanBan);
                        _listVanBan.Add(ucYTVanBan);
                        ucYTVanBan.Name = "unCheck";
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

        private void UC_YeuThich_Load(object sender, EventArgs e)
        {
            
        }
    }
}
