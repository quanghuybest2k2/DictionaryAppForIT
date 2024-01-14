using DictionaryAppForIT.API;
using DictionaryAppForIT.Class;
using DictionaryAppForIT.DTO;
using DictionaryAppForIT.DTO.Love;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DictionaryAppForIT.UserControls.YeuThich
{
    public partial class UC_YeuThich : UserControl
    {
        RandomColor rd = new RandomColor();
        List<UC_YT_TuVung> _listTuVung;
        List<UC_YT_VanBan> _listVanBan;
        //bool xoaTatCa;
        bool xoaTatCaYT;
        public string TuHienTai = "";
        public static string idHienTai;
        UC_YT_TuVung ucYTTuVung;
        UC_YT_VanBan ucYTVanBan;
        int stt = 1;
        private static readonly HttpClient client = new HttpClient();
        private static readonly string apiUrl = BaseUrl.base_url;

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
        public async Task HienThiYTTraTu()
        {
            _listTuVung.Clear();
            flpContent.Controls.Clear();
            stt = 1;
            try
            {
                if (Class_TaiKhoan.authentication(client))
                {
                    HttpResponseMessage response = await client.GetAsync(apiUrl + $"show-love-vocabulary/{Class_TaiKhoan.IdTaiKhoan}");

                    string responseContent = await response.Content.ReadAsStringAsync();

                    var apiResponse = JsonConvert.DeserializeObject<ApiResponse<LoveResponse[]>>(responseContent);

                    if (apiResponse.Status && apiResponse.Data != null)
                    {
                        foreach (var item in apiResponse.Data)
                        {
                            idHienTai = item.id.ToString();
                            string TVTiengAnh = item.english;
                            string TVPhienAm = item.pronunciations;
                            string TVTiengViet = item.vietnamese;
                            string GhiChu = item.Note;

                            ucYTTuVung = new UC_YT_TuVung(stt.ToString(), idHienTai, TVTiengAnh, TVPhienAm, TVTiengViet);
                            ucYTTuVung.TVBackColor(rd.GetColor());
                            flpContent.Controls.Add(ucYTTuVung);
                            _listTuVung.Add(ucYTTuVung);
                            ucYTTuVung.Name = "unCheck";
                            ucYTTuVung.ThemGhiChu(idHienTai, GhiChu, 1);
                            stt++;
                        }
                    }
                    else
                    {
                        RJMessageBox.Show(apiResponse.Message);
                    }
                }
            }
            catch (Exception ex)
            {
                RJMessageBox.Show(ex.Message);
            }
        }

        public async Task HienThiYTVanBan()
        {
            _listVanBan.Clear();
            //flpContent.Controls.Clear();
            try
            {
                if (Class_TaiKhoan.authentication(client))
                {
                    HttpResponseMessage response = await client.GetAsync(apiUrl + $"show-love-text/{Class_TaiKhoan.IdTaiKhoan}");

                    string responseContent = await response.Content.ReadAsStringAsync();

                    var apiResponse = JsonConvert.DeserializeObject<ApiResponse<LoveResponse[]>>(responseContent);

                    if (apiResponse.Status && apiResponse.Data != null)
                    {
                        foreach (var item in apiResponse.Data)
                        {
                            idHienTai = item.id.ToString();
                            string TVTiengAnh = item.english;
                            string TVTiengViet = item.vietnamese;
                            string GhiChu = item.Note;

                            ucYTVanBan = new UC_YT_VanBan(stt.ToString(), idHienTai, TVTiengAnh, TVTiengViet);
                            ucYTVanBan.VBBackColor(rd.GetColor());
                            flpContent.Controls.Add(ucYTVanBan);
                            _listVanBan.Add(ucYTVanBan);
                            ucYTVanBan.Name = "unCheck";
                            ucYTVanBan.ThemGhiChu(idHienTai, GhiChu, 2);
                            stt++;
                        }
                    }
                    else
                    {
                        RJMessageBox.Show(apiResponse.Message);
                    }
                }
            }
            catch (Exception ex)
            {
                RJMessageBox.Show(ex.Message);
            }
        }

        private async void UC_YeuThich_Load(object sender, EventArgs e)
        {
            _listTuVung = new List<UC_YT_TuVung>();
            _listVanBan = new List<UC_YT_VanBan>();
            lblSoMucYeuThich.Text = await LoveVocabulary.Tong_So_Muc_Yeu_Thich();
            txtTimKiemYeuThich.PlaceholderText = "Tìm kiếm Từ Vựng...";
            cbbLoaiTimKiem.SelectedIndex = 0;
        }
        // xoa tra tu yeu thich
        private async void XoaUCYeuThichTuVung()
        {
            foreach (var item in _listTuVung)
            {
                if (item.Name == "Check")//c.ChkChonLSTraTu.Checked
                {
                    xoaTatCaYT = false;
                    flpContent.Controls.Remove(item);
                    try
                    {
                        if (Class_TaiKhoan.authentication(client))
                        {
                            HttpResponseMessage response = await client.DeleteAsync(apiUrl + $"delete-love-vocabulary/{item.TVTiengAnh}/{Class_TaiKhoan.IdTaiKhoan}");

                            string responseContent = await response.Content.ReadAsStringAsync();

                            var apiResponse = JsonConvert.DeserializeObject<ApiResponse<object>>(responseContent);

                            //if (apiResponse.Status && apiResponse.Data != null)
                            //{
                            //    RJMessageBox.Show(apiResponse.Message);
                            //}
                            //else
                            //{
                            //    RJMessageBox.Show(apiResponse.Message);
                            //}
                        }
                    }
                    catch (Exception ex)
                    {
                        RJMessageBox.Show("Lỗi >> " + ex.Message);
                    }
                }
            }
            _listTuVung.RemoveAll(x => x.Name == "Check");
            lblSoMucYeuThich.Text = await LoveVocabulary.Tong_So_Muc_Yeu_Thich();
        }
        //xoa van ban yeu thich
        private async void XoaUCYeuThichVanBanAsync()
        {
            foreach (var item in _listVanBan)
            {
                if (item.Name == "Check")//c.ChkChonLSTraTu.Checked
                {
                    xoaTatCaYT = false;
                    flpContent.Controls.Remove(item);
                    try
                    {
                        if (Class_TaiKhoan.authentication(client))
                        {
                            HttpResponseMessage response = await client.DeleteAsync(apiUrl + $"delete-love-text?english={Uri.EscapeDataString(item.VBTiengAnh.Trim())}&user_id={Uri.EscapeDataString(Class_TaiKhoan.IdTaiKhoan)}");

                            string responseContent = await response.Content.ReadAsStringAsync();
                            var apiResponse = JsonConvert.DeserializeObject<ApiResponse<object>>(responseContent);

                            //if (apiResponse.Status && apiResponse.Data != null)
                            //{
                            //    RJMessageBox.Show(apiResponse.Message);
                            //}
                            //else
                            //{
                            //    RJMessageBox.Show(apiResponse.Message);
                            //}
                        }
                    }
                    catch (Exception ex)
                    {
                        RJMessageBox.Show("Lỗi >> " + ex.Message);
                    }
                }
            }
            _listVanBan.RemoveAll(x => x.Name == "Check");
            lblSoMucYeuThich.Text = await LoveVocabulary.Tong_So_Muc_Yeu_Thich();
        }
        // xoa muc yeu thich
        private async void btnXoaMucYeuThich_Click(object sender, EventArgs e)
        {
            xoaTatCaYT = true;
            XoaUCYeuThichTuVung();
            XoaUCYeuThichVanBanAsync();

            if (xoaTatCaYT)
            {
                flpContent.Controls.Clear();
                try
                {
                    if (Class_TaiKhoan.authentication(client))
                    {
                        HttpResponseMessage response = await client.DeleteAsync(apiUrl + $"delete-all-favorite/{Class_TaiKhoan.IdTaiKhoan}");

                        string responseContent = await response.Content.ReadAsStringAsync();
                        var apiResponse = JsonConvert.DeserializeObject<ApiResponse<object>>(responseContent);

                        if (apiResponse.Status && apiResponse.Data != null)
                        {
                            lblSoMucYeuThich.Text = "0";
                            RJMessageBox.Show(apiResponse.Message, "Thông báo",
                           MessageBoxButtons.OK,
                           MessageBoxIcon.Information);
                        }
                        else
                        {
                            RJMessageBox.Show("Xóa không thành công!", "Thông báo",
                              MessageBoxButtons.OK,
                              MessageBoxIcon.Error);
                        }
                    }
                }
                catch (Exception ex)
                {
                    RJMessageBox.Show("Lỗi >> " + ex.Message);
                }
                _listTuVung.Clear();
            }
        }

        #region xử lý tìm kiếm yêu thích
        private async void HienThiTimKiemYTTraTu()
        {
            _listTuVung.Clear();
            flpContent.Controls.Clear();
            try
            {
                HttpResponseMessage response = await client.GetAsync(apiUrl + $"search-love-vocabulary-by-word?english={txtTimKiemYeuThich.Text.Trim()}&user_id={Class_TaiKhoan.IdTaiKhoan}");

                string responseContent = await response.Content.ReadAsStringAsync();
                var apiResponse = JsonConvert.DeserializeObject<ApiResponse<LoveResponse[]>>(responseContent);

                if (apiResponse.Status && apiResponse.Data != null)
                {
                    foreach (var item in apiResponse.Data)
                    {
                        idHienTai = item.id.ToString();
                        string TVTiengAnh = item.english;
                        string TVPhienAm = item.pronunciations;
                        string TVTiengViet = item.vietnamese;
                        string GhiChu = item.Note;

                        ucYTTuVung = new UC_YT_TuVung(stt.ToString(), idHienTai, TVTiengAnh, TVPhienAm, TVTiengViet);
                        ucYTTuVung.TVBackColor(rd.GetColor());
                        flpContent.Controls.Add(ucYTTuVung);
                        _listTuVung.Add(ucYTTuVung);
                        ucYTTuVung.Name = "unCheck";
                        ucYTTuVung.ThemGhiChu(idHienTai, GhiChu, 1);
                        stt++;
                    }
                }
                else
                {
                    RJMessageBox.Show(apiResponse.Message, "Thông báo",
                      MessageBoxButtons.OK,
                      MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                RJMessageBox.Show("Lỗi >> " + ex.Message);
            }
        }

        private async void HienThiTimKiemYTVanBan()
        {
            _listVanBan.Clear();
            try
            {
                HttpResponseMessage response = await client.GetAsync(apiUrl + $"search-love-text-by-word?english={txtTimKiemYeuThich.Text.Trim()}&user_id={Class_TaiKhoan.IdTaiKhoan}");

                string responseContent = await response.Content.ReadAsStringAsync();
                var apiResponse = JsonConvert.DeserializeObject<ApiResponse<LoveResponse[]>>(responseContent);

                if (apiResponse.Status && apiResponse.Data != null)
                {
                    foreach (var item in apiResponse.Data)
                    {
                        idHienTai = item.id.ToString();
                        string TVTiengAnh = item.english;
                        string TVTiengViet = item.vietnamese;
                        string GhiChu = item.Note;

                        ucYTVanBan = new UC_YT_VanBan(stt.ToString(), idHienTai, TVTiengAnh, TVTiengViet);
                        ucYTVanBan.VBBackColor(rd.GetColor());
                        flpContent.Controls.Add(ucYTVanBan);
                        _listVanBan.Add(ucYTVanBan);
                        ucYTVanBan.Name = "unCheck";
                        ucYTVanBan.ThemGhiChu(idHienTai, GhiChu, 2);
                        stt++;
                    }
                }
                else
                {
                    RJMessageBox.Show(apiResponse.Message, "Thông báo",
                      MessageBoxButtons.OK,
                      MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                RJMessageBox.Show("Lỗi >> " + ex.Message);
            }
        }

        private async void txtTimKiemYeuThich_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && TuHienTai != txtTimKiemYeuThich.Text)//--------------------------------------
            {
                flpContent.Controls.Clear();  //-------------------------------------- Khi người ta enter mới xóa flpMeaning
                if (cbbLoaiTimKiem.SelectedIndex == 0)
                {
                    HienThiTimKiemYTTraTu();
                }
                else
                {
                    HienThiTimKiemYTVanBan();
                }
                try
                {
                    HttpResponseMessage response = await client.GetAsync(apiUrl + $"find-love-by-word-and-english?english={txtTimKiemYeuThich.Text.Trim()}&user_id={Class_TaiKhoan.IdTaiKhoan}");

                    string responseContent = await response.Content.ReadAsStringAsync();
                    var apiResponse = JsonConvert.DeserializeObject<ApiResponse<object>>(responseContent);

                    if (apiResponse.Status && apiResponse.Data != null)
                    {
                        lblSoMucYeuThich.Text = apiResponse.Data.ToString();
                    }
                }
                catch (Exception ex)
                {
                    RJMessageBox.Show("Lỗi >> " + ex.Message);
                }
                TuHienTai = txtTimKiemYeuThich.Text;//--------------------------------------
            }
        }
        #endregion

        public async void SapXepYTTraTu()
        {
            _listTuVung.Clear();
            flpContent.Controls.Clear();
            stt = 1;

            try
            {
                if (Class_TaiKhoan.authentication(client))
                {
                    HttpResponseMessage response = await client.GetAsync(apiUrl + $"sort-by-favorite-word-lookup/{Class_TaiKhoan.IdTaiKhoan}");

                    string responseContent = await response.Content.ReadAsStringAsync();
                    var apiResponse = JsonConvert.DeserializeObject<ApiResponse<LoveResponse[]>>(responseContent);

                    if (apiResponse.Status && apiResponse.Data != null)
                    {
                        foreach (var item in apiResponse.Data)
                        {
                            idHienTai = item.id.ToString();
                            string TVTiengAnh = item.english;
                            string TVPhienAm = item.pronunciations;
                            string TVTiengViet = item.vietnamese;
                            string GhiChu = item.Note;

                            ucYTTuVung = new UC_YT_TuVung(stt.ToString(), idHienTai, TVTiengAnh, TVPhienAm, TVTiengViet);
                            ucYTTuVung.TVBackColor(rd.GetColor());
                            flpContent.Controls.Add(ucYTTuVung);
                            _listTuVung.Add(ucYTTuVung);
                            ucYTTuVung.Name = "unCheck";
                            ucYTTuVung.ThemGhiChu(idHienTai, GhiChu, 1);
                            stt++;
                        }
                    }
                    else
                    {
                        RJMessageBox.Show(apiResponse.Message, "Thông báo",
                          MessageBoxButtons.OK,
                          MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                RJMessageBox.Show("Lỗi >> " + ex.Message);
            }
        }
        public async void SapXepYTVanBan()
        {
            _listVanBan.Clear();
            //flpContent.Controls.Clear();
            try
            {
                if (Class_TaiKhoan.authentication(client))
                {
                    HttpResponseMessage response = await client.GetAsync(apiUrl + $"sort-by-favorite-text/{Class_TaiKhoan.IdTaiKhoan}");

                    string responseContent = await response.Content.ReadAsStringAsync();
                    var apiResponse = JsonConvert.DeserializeObject<ApiResponse<LoveResponse[]>>(responseContent);

                    if (apiResponse.Status && apiResponse.Data != null)
                    {
                        foreach (var item in apiResponse.Data)
                        {
                            //ThongTinLSTraTu.idTraTuLS = rdr["ID"].ToString();
                            idHienTai = item.id.ToString();
                            string TVTiengAnh = item.english;
                            string TVTiengViet = item.vietnamese;
                            string GhiChu = item.Note;

                            ucYTVanBan = new UC_YT_VanBan(stt.ToString(), idHienTai, TVTiengAnh, TVTiengViet);
                            ucYTVanBan.VBBackColor(rd.GetColor());
                            flpContent.Controls.Add(ucYTVanBan);
                            _listVanBan.Add(ucYTVanBan);
                            ucYTVanBan.Name = "unCheck";
                            ucYTVanBan.ThemGhiChu(idHienTai, GhiChu, 2);
                            stt++;
                        }
                    }
                    else
                    {
                        RJMessageBox.Show(apiResponse.Message, "Thông báo",
                          MessageBoxButtons.OK,
                          MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                RJMessageBox.Show("Lỗi >> " + ex.Message);
            }

        }
        private void btnSapXepYeuThich_Click(object sender, EventArgs e)
        {
            SapXepYTTraTu();
            SapXepYTVanBan();
        }

        private void cbbLoaiTimKiem_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbbLoaiTimKiem.SelectedIndex == 0)// Từ vựng
            {
                txtTimKiemYeuThich.PlaceholderText = "Tìm kiếm Từ Vựng...";
            }
            else
            {
                txtTimKiemYeuThich.PlaceholderText = "Tìm kiếm Văn Bản...";
            }
        }
    }
}
