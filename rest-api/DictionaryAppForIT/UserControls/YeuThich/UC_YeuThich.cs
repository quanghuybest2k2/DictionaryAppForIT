using DictionaryAppForIT.Class;
using DictionaryAppForIT.DAL;
using DictionaryAppForIT.DTO;
using DictionaryAppForIT.Forms;
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
        //bool xoaTatCa;
        bool xoaTatCaYT;
        public string TuHienTai = "";
        public static string idHienTai;
        UC_YT_TuVung ucYTTuVung;
        UC_YT_VanBan ucYTVanBan;
        int stt = 1;

        public UC_YeuThich()
        {
            InitializeComponent();
            //_listTuVung = new List<UC_YT_TuVung>();
            //_listVanBan = new List<UC_YT_VanBan>();

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

        public string SoMuc
        {
            get { return lblSoMucYeuThich.Text; }
            set { lblSoMucYeuThich.Text = value; }
        }

        public void HienThiYTTraTu()
        {
            _listTuVung.Clear();
            flpContent.Controls.Clear();
            stt = 1;
            object num = DataProvider.Instance.ExecuteScalar($"select COUNT(ID) from YeuThichTuVung where IDTK = '{Class_TaiKhoan.IdTaiKhoan}'");
            if (Convert.ToInt32(num) > 0)
            {
                try
                {
                    SqlConnection Conn = new SqlConnection(connString);
                    SqlCommand cmd = new SqlCommand($"select * from YeuThichTuVung where IDTK = '{Class_TaiKhoan.IdTaiKhoan}'", Conn);
                    Conn.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        //ThongTinLSTraTu.idTraTuLS = rdr["ID"].ToString();
                        idHienTai = rdr["ID"].ToString();
                        string TVTiengAnh = rdr["TiengAnh"].ToString();
                        string TVPhienAm = rdr["PhienAm"].ToString();
                        string TVTiengViet = rdr["TiengViet"].ToString();
                        string GhiChu = rdr["GhiChu"].ToString();
                        ucYTTuVung = new UC_YT_TuVung(stt.ToString(), idHienTai, TVTiengAnh, TVPhienAm, TVTiengViet);
                        ucYTTuVung.TVBackColor(rd.GetColor());
                        flpContent.Controls.Add(ucYTTuVung);
                        _listTuVung.Add(ucYTTuVung);
                        ucYTTuVung.Name = "unCheck";
                        ucYTTuVung.ThemGhiChu(idHienTai, GhiChu, 1);
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
            object num = DataProvider.Instance.ExecuteScalar($"select COUNT(ID) from YeuThichVanBan where IDTK = '{Class_TaiKhoan.IdTaiKhoan}'");
            if (Convert.ToInt32(num) > 0)
            {
                try
                {
                    SqlConnection Conn = new SqlConnection(connString);
                    SqlCommand cmd = new SqlCommand($"select * from YeuThichVanBan where IDTK = '{Class_TaiKhoan.IdTaiKhoan}'", Conn);
                    Conn.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        idHienTai = rdr["ID"].ToString();
                        string TVTiengAnh = rdr["TiengAnh"].ToString();
                        string TVTiengViet = rdr["TiengViet"].ToString();
                        string GhiChu = rdr["GhiChu"].ToString();
                        ucYTVanBan = new UC_YT_VanBan(stt.ToString(), idHienTai, TVTiengAnh, TVTiengViet);
                        ucYTVanBan.VBBackColor(rd.GetColor());
                        flpContent.Controls.Add(ucYTVanBan);
                        _listVanBan.Add(ucYTVanBan);
                        ucYTVanBan.Name = "unCheck";
                        ucYTVanBan.ThemGhiChu(idHienTai, GhiChu, 2);
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
            _listTuVung = new List<UC_YT_TuVung>();
            _listVanBan = new List<UC_YT_VanBan>();
            //lblSoMucYeuThich.Text = await frmMain.Tong_So_Muc_Yeu_Thich();
        }
        // xoa tra tu yeu thich
        private void XoaUCYeuThichTuVung()
        {
            foreach (var item in _listTuVung)
            {
                if (item.Name == "Check")//c.ChkChonLSTraTu.Checked
                {
                    xoaTatCaYT = false;
                    flpContent.Controls.Remove(item);
                    DataProvider.Instance.ExecuteNonQuery($"delete from YeuThichTuVung where id = '{item.Index}' and IDTK = '{Class_TaiKhoan.IdTaiKhoan}'");
                }
            }
            _listTuVung.RemoveAll(x => x.Name == "Check");
        }
        //xoa van ban yeu thich
        private void XoaUCYeuThichVanBanAsync()
        {
            foreach (var item in _listVanBan)
            {
                if (item.Name == "Check")//c.ChkChonLSTraTu.Checked
                {
                    xoaTatCaYT = false;
                    flpContent.Controls.Remove(item);
                    DataProvider.Instance.ExecuteNonQuery($"delete from YeuThichVanBan where id = '{item.Index}' and IDTK = '{Class_TaiKhoan.IdTaiKhoan}'");
                }
            }
            _listVanBan.RemoveAll(x => x.Name == "Check");
            //lblSoMucYeuThich.Text = await frmMain.Tong_So_Muc_Yeu_Thich();
        }
        // xoa muc yeu thich
        private void btnXoaMucYeuThich_Click(object sender, EventArgs e)
        {
            xoaTatCaYT = true;
            XoaUCYeuThichTuVung();
            XoaUCYeuThichVanBanAsync();

            if (xoaTatCaYT)
            {

                flpContent.Controls.Clear();
                int num = DataProvider.Instance.ExecuteNonQuery($"delete from YeuThichTuVung where IDTK = '{Class_TaiKhoan.IdTaiKhoan}' " +
                  $"delete from YeuThichVanBan where IDTK = '{Class_TaiKhoan.IdTaiKhoan}'");
                if (num > 0)
                {
                    lblSoMucYeuThich.Text = "0";
                    RJMessageBox.Show("Đã xóa tất cả mục yêu thích!", "Thông báo",
                   MessageBoxButtons.OK,
                   MessageBoxIcon.Information);
                }
                else
                {
                    RJMessageBox.Show("Xóa không thành công!", "Thông báo",
                      MessageBoxButtons.OK,
                      MessageBoxIcon.Error);
                }
                _listTuVung.Clear();
            }
        }

        #region xử lý tìm kiếm yêu thích
        private void HienThiTimKiemYTTraTu()
        {
            try
            {
                _listTuVung.Clear();
                flpContent.Controls.Clear();
                SqlConnection Conn = new SqlConnection(connString);
                SqlCommand cmd = new SqlCommand($"EXEC HienThiTimKiemYTTraTu '{txtTimKiemYeuThich.Text.Trim()}', '{Class_TaiKhoan.IdTaiKhoan}'", Conn);
                Conn.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    idHienTai = rdr["ID"].ToString();
                    string TVTiengAnh = rdr["TiengAnh"].ToString();
                    string TVPhienAm = rdr["PhienAm"].ToString();
                    string TVTiengViet = rdr["TiengViet"].ToString();
                    string GhiChu = rdr["GhiChu"].ToString();
                    ucYTTuVung = new UC_YT_TuVung(stt.ToString(), idHienTai, TVTiengAnh, TVPhienAm, TVTiengViet);
                    ucYTTuVung.TVBackColor(rd.GetColor());
                    flpContent.Controls.Add(ucYTTuVung);
                    _listTuVung.Add(ucYTTuVung);
                    ucYTTuVung.Name = "unCheck";
                    ucYTTuVung.ThemGhiChu(idHienTai, GhiChu, 1);
                    stt++;
                }
                Conn.Close();
                Conn.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void HienThiTimKiemYTVanBan()
        {
            try
            {
                _listVanBan.Clear();
                SqlConnection Conn = new SqlConnection(connString);
                SqlCommand cmd = new SqlCommand($"EXEC HienThiTimKiemYTVanBan '{txtTimKiemYeuThich.Text.Trim()}', '{Class_TaiKhoan.IdTaiKhoan}'", Conn);
                Conn.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    idHienTai = rdr["ID"].ToString();
                    string TVTiengAnh = rdr["TiengAnh"].ToString();
                    string TVTiengViet = rdr["TiengViet"].ToString();
                    string GhiChu = rdr["GhiChu"].ToString();
                    ucYTVanBan = new UC_YT_VanBan(stt.ToString(), idHienTai, TVTiengAnh, TVTiengViet);
                    ucYTVanBan.VBBackColor(rd.GetColor());
                    flpContent.Controls.Add(ucYTVanBan);
                    _listVanBan.Add(ucYTVanBan);
                    ucYTVanBan.Name = "unCheck";
                    ucYTVanBan.ThemGhiChu(idHienTai, GhiChu, 2);
                    stt++;
                }
                Conn.Close();
                Conn.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void txtTimKiemYeuThich_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && TuHienTai != txtTimKiemYeuThich.Text)//--------------------------------------
            {
                flpContent.Controls.Clear();  //-------------------------------------- Khi người ta enter mới xóa flpMeaning
                HienThiTimKiemYTTraTu();
                HienThiTimKiemYTVanBan();
                string query = $"select sum(AllCount) AS Tong_SoMucYeuThich from((select count(*) AS AllCount from YeuThichTuVung where IDTK = '{Class_TaiKhoan.IdTaiKhoan}' and TiengAnh = '{txtTimKiemYeuThich.Text}') union all (select count(*) AS AllCount from YeuThichVanBan where IDTK = '{Class_TaiKhoan.IdTaiKhoan}' and TiengAnh LIKE '%{txtTimKiemYeuThich.Text}%'))t";
                object soMucTK = DataProvider.Instance.ExecuteScalar(query);
                lblSoMucYeuThich.Text = soMucTK.ToString();
                TuHienTai = txtTimKiemYeuThich.Text;//--------------------------------------

            }
        }
        #endregion

        public void SapXepYTTraTu()
        {
            _listTuVung.Clear();
            flpContent.Controls.Clear();
            stt = 1;
            object num = DataProvider.Instance.ExecuteScalar($"select COUNT(ID) from YeuThichTuVung where IDTK = '{Class_TaiKhoan.IdTaiKhoan}'");
            if (Convert.ToInt32(num) > 0)
            {
                try
                {
                    SqlConnection Conn = new SqlConnection(connString);
                    SqlCommand cmd = new SqlCommand($"select * from YeuThichTuVung where IDTK = '{Class_TaiKhoan.IdTaiKhoan}' order by TiengAnh ASC", Conn);
                    Conn.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        //ThongTinLSTraTu.idTraTuLS = rdr["ID"].ToString();
                        idHienTai = rdr["ID"].ToString();
                        string TVTiengAnh = rdr["TiengAnh"].ToString();
                        string TVPhienAm = rdr["PhienAm"].ToString();
                        string TVTiengViet = rdr["TiengViet"].ToString();
                        string GhiChu = rdr["GhiChu"].ToString();
                        ucYTTuVung = new UC_YT_TuVung(stt.ToString(), idHienTai, TVTiengAnh, TVPhienAm, TVTiengViet);
                        ucYTTuVung.TVBackColor(rd.GetColor());
                        flpContent.Controls.Add(ucYTTuVung);
                        _listTuVung.Add(ucYTTuVung);
                        ucYTTuVung.Name = "unCheck";
                        ucYTTuVung.ThemGhiChu(idHienTai, GhiChu, 1);
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
        public void SapXepYTVanBan()
        {
            _listVanBan.Clear();
            //flpContent.Controls.Clear();
            object num = DataProvider.Instance.ExecuteScalar($"select COUNT(ID) from YeuThichVanBan where IDTK = '{Class_TaiKhoan.IdTaiKhoan}'");
            if (Convert.ToInt32(num) > 0)
            {
                try
                {
                    SqlConnection Conn = new SqlConnection(connString);
                    SqlCommand cmd = new SqlCommand($"select * from YeuThichVanBan where IDTK = '{Class_TaiKhoan.IdTaiKhoan}' order by TiengAnh ASC", Conn);
                    Conn.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        //ThongTinLSTraTu.idTraTuLS = rdr["ID"].ToString();
                        idHienTai = rdr["ID"].ToString();
                        string TVTiengAnh = rdr["TiengAnh"].ToString();
                        string TVTiengViet = rdr["TiengViet"].ToString();
                        string GhiChu = rdr["GhiChu"].ToString();
                        ucYTVanBan = new UC_YT_VanBan(stt.ToString(), idHienTai, TVTiengAnh, TVTiengViet);
                        ucYTVanBan.VBBackColor(rd.GetColor());
                        flpContent.Controls.Add(ucYTVanBan);
                        _listVanBan.Add(ucYTVanBan);
                        ucYTVanBan.Name = "unCheck";
                        ucYTVanBan.ThemGhiChu(idHienTai, GhiChu, 2);
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

        private void btnSapXepYeuThich_Click(object sender, EventArgs e)
        {
            SapXepYTTraTu();
            SapXepYTVanBan();
        }
    }
}
