using DictionaryAppForIT.API;
using DictionaryAppForIT.Class;
using DictionaryAppForIT.DTO;
using DictionaryAppForIT.UserControls.LichSu;
using Guna.UI2.WinForms;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Http;
using System.Speech.Synthesis;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DictionaryAppForIT.UserControls.GanDay
{
    public partial class UC_LichSu : UserControl
    {
        private readonly string apiUrl = BaseUrl.base_url;
        HttpClient client = new HttpClient();

        UC_LS_TuVung ucLSTuVung;
        UC_LS_VanBan ucLSVanBan;
        SpeechSynthesizer speech;
        public static string idHienTai;
        public string TuHienTai = "";
        List<UC_LS_TuVung> _listUCLSTV;
        List<UC_LS_VanBan> _listUCLSVB;

        bool xoaTatCa;

        public UC_LichSu()
        {
            InitializeComponent();
            speech = new SpeechSynthesizer();
            _listUCLSTV = new List<UC_LS_TuVung>();
            _listUCLSVB = new List<UC_LS_VanBan>();

        }

        public async Task HienThiLSTraTu()
        {
            _listUCLSTV.Clear();
            flpContent.Controls.Clear();
            try
            {
                var wordLookUpList = await WordHistoryService.LoadWordLookupHistory();

                if (wordLookUpList != null)
                {
                    foreach (var history in wordLookUpList)
                    {
                        idHienTai = history.id.ToString();
                        string NgayThang = DateTime.Parse(history.created_at).ToLocalTime().ToString("dd/MM/yyyy");
                        string ThoiGian = DateTime.Parse(history.created_at).ToLocalTime().ToString("HH:mm:ss");
                        string TVTiengAnh = history.English;
                        string TVPhienAm = history.Pronunciation;
                        string TVTiengViet = history.Vietnamese;
                        ucLSTuVung = new UC_LS_TuVung(idHienTai, ThoiGian, NgayThang, TVTiengAnh, TVPhienAm, TVTiengViet);

                        flpContent.Controls.Add(ucLSTuVung);
                        _listUCLSTV.Add(ucLSTuVung);
                        ucLSTuVung.Name = "unCheck";
                    }
                }
                else
                {
                    ucLSTuVung = new UC_LS_TuVung();
                }
            }
            catch (Exception ex)
            {
                RJMessageBox.Show(ex.Message);
            }
        }

        public async Task HienThiLSDich()
        {
            try
            {
                var TextLookUpList = await TranslateHistoryService.LoadLichSu();

                if (TextLookUpList != null)
                {
                    foreach (var history in TextLookUpList)
                    {
                        idHienTai = history.id.ToString();
                        string NgayThang = DateTime.Parse(history.created_at).ToLocalTime().ToString("dd/MM/yyyy");
                        string ThoiGian = DateTime.Parse(history.created_at).ToLocalTime().ToString("HH:mm:ss");
                        string TVTiengAnh = history.English;
                        string TVTiengViet = history.Vietnamese;

                        ucLSVanBan = new UC_LS_VanBan(idHienTai, ThoiGian, NgayThang, TVTiengAnh, TVTiengViet);
                        flpContent.Controls.Add(ucLSVanBan);

                        _listUCLSVB.Add(ucLSVanBan);
                        ucLSVanBan.Name = "unCheck";
                    }
                }
                else
                {
                    ucLSVanBan = new UC_LS_VanBan();
                }
            }
            catch (Exception ex)
            {
                RJMessageBox.Show(ex.Message);
            }
        }
        private async Task XoaUCLSTuVungAsync()
        {
            foreach (var item in _listUCLSTV)
            {
                if (item.Name == "Check")
                {
                    xoaTatCa = false;
                    flpContent.Controls.Remove(item);
                    await WordHistoryService.XoaLichSuTuVungAsync(item);
                }
            }
            _listUCLSTV.RemoveAll(x => x.Name == "Check");
        }

        private async Task XoaUCLSVanBanAsync()
        {
            foreach (var item in _listUCLSVB)
            {
                if (item.Name == "Check")
                {
                    xoaTatCa = false;
                    flpContent.Controls.Remove(item);
                    await WordHistoryService.XoaLichSuVanBanAsync(item);
                }
            }
            _listUCLSVB.RemoveAll(x => x.Name == "Check");
        }
        private async void btnXoaDuLieu_Click(object sender, EventArgs e)
        {
            xoaTatCa = true;
            await XoaUCLSTuVungAsync();
            await XoaUCLSVanBanAsync();

            if (xoaTatCa)
            {

                flpContent.Controls.Clear();
                try
                {
                    HttpResponseMessage response = await client.DeleteAsync(apiUrl + $"delete-all-history/{Class_TaiKhoan.IdTaiKhoan}");

                    string responseContent = await response.Content.ReadAsStringAsync();

                    var apiResponse = JsonConvert.DeserializeObject<ApiResponse<object>>(responseContent);

                    if (apiResponse.Status && apiResponse.Data != null)
                    {
                        RJMessageBox.Show(apiResponse.Message, "Thông báo",
                         MessageBoxButtons.OK,
                         MessageBoxIcon.Information);
                    }
                    else
                    {
                        string message = apiResponse.Message;
                        RJMessageBox.Show(message, "Thông báo",
                         MessageBoxButtons.OK,
                         MessageBoxIcon.Warning);
                    }
                }
                catch (Exception ex)
                {
                    RJMessageBox.Show($"Lỗi: {ex.Message}", "Lỗi",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                }
                _listUCLSTV.Clear();
            }
        }

        private async void txtTimKiemLS_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && TuHienTai != txtTimKiemLS.Text)//--------------------------------------
            {
                flpContent.Controls.Clear();  //-------------------------------------- Khi người ta enter mới xóa flpMeaning
                await HienThiTimKiemLSTTAsync();
                await HienThiTimKiemLSDAsync();
                TuHienTai = txtTimKiemLS.Text;//--------------------------------------

            }
        }
        private async Task<List<WordLookupHistory>> HienThiTimKiemLSTTAsync()
        {
            try
            {
                HttpResponseMessage response = await client.GetAsync(apiUrl + $"search-word-lookup-history?english={txtTimKiemLS.Text.Trim()}&user_id={Class_TaiKhoan.IdTaiKhoan}");

                string responseContent = await response.Content.ReadAsStringAsync();

                var apiResponse = JsonConvert.DeserializeObject<ApiResponse<List<WordLookupHistory>>>(responseContent);

                if (apiResponse.Status && apiResponse.Data != null)
                {
                    var historyData = apiResponse.Data;

                    foreach (var historyItem in historyData)
                    {
                        idHienTai = historyItem.id.ToString();

                        DateTime createdAtDateTime = DateTime.Parse(historyItem.created_at);
                        string ngay = createdAtDateTime.ToString("dd/MM/yyyy");
                        string gio = createdAtDateTime.ToString("HH:mm tt");

                        string NgayThang = ngay;
                        string ThoiGian = gio;
                        string TVTiengAnh = historyItem.English;
                        string TVPhienAm = historyItem.Pronunciation;
                        string TVTiengViet = historyItem.Vietnamese;

                        ucLSTuVung = new UC_LS_TuVung(idHienTai, ThoiGian, NgayThang, TVTiengAnh, TVPhienAm, TVTiengViet);

                        flpContent.Controls.Add(ucLSTuVung);
                        _listUCLSTV.Add(ucLSTuVung);
                        ucLSTuVung.Name = "unCheck";
                    }
                    return historyData;
                }
                else
                {
                    RJMessageBox.Show(apiResponse.Message);
                    return null;
                }
            }
            catch (Exception ex)
            {
                RJMessageBox.Show(ex.Message);
                return null;
            }
        }

        private async Task<List<WordLookupHistory>> HienThiTimKiemLSDAsync()
        {
            try
            {
                HttpResponseMessage response = await client.GetAsync(apiUrl + $"search-translate-history?english={txtTimKiemLS.Text.Trim()}&user_id={Class_TaiKhoan.IdTaiKhoan}");

                string responseContent = await response.Content.ReadAsStringAsync();

                var apiResponse = JsonConvert.DeserializeObject<ApiResponse<List<WordLookupHistory>>>(responseContent);

                if (apiResponse.Status && apiResponse.Data != null)
                {
                    var historyData = apiResponse.Data;

                    foreach (var historyItem in historyData)
                    {
                        idHienTai = historyItem.id.ToString();

                        DateTime createdAtDateTime = DateTime.Parse(historyItem.created_at);
                        string ngay = createdAtDateTime.ToString("dd/MM/yyyy");
                        string gio = createdAtDateTime.ToString("HH:mm tt");

                        string NgayThang = ngay;
                        string ThoiGian = gio;
                        string TVTiengAnh = historyItem.English;
                        string TVPhienAm = historyItem.Pronunciation;
                        string TVTiengViet = historyItem.Vietnamese;

                        ucLSVanBan = new UC_LS_VanBan(idHienTai, ThoiGian, NgayThang, TVTiengAnh, TVTiengViet);
                        flpContent.Controls.Add(ucLSVanBan);

                        _listUCLSVB.Add(ucLSVanBan);
                        ucLSVanBan.Name = "unCheck";
                    }
                    return historyData;
                }
                else
                {
                    RJMessageBox.Show(apiResponse.Message);
                    return null;
                }
            }
            catch (Exception ex)
            {
                RJMessageBox.Show(ex.Message);
                return null;
            }
        }

        private void UC_LichSu_Load(object sender, EventArgs e)
        {

        }
        public async Task<List<WordLookupHistory>> HienThiLSTraTuTheoThoiGianAsync(string thoiGian)
        {
            try
            {
                HttpResponseMessage response = await client.GetAsync(apiUrl + $"display-by-time-word-lookup-history?user_id={Class_TaiKhoan.IdTaiKhoan}&time={thoiGian}");

                string responseContent = await response.Content.ReadAsStringAsync();

                var apiResponse = JsonConvert.DeserializeObject<ApiResponse<List<WordLookupHistory>>>(responseContent);

                if (apiResponse.Status && apiResponse.Data != null)
                {
                    var historyData = apiResponse.Data;

                    foreach (var historyItem in historyData)
                    {
                        idHienTai = historyItem.id.ToString();

                        DateTime createdAtDateTime = DateTime.Parse(historyItem.created_at);
                        string ngay = createdAtDateTime.ToString("dd/MM/yyyy");
                        string gio = createdAtDateTime.ToString("HH:mm tt");

                        string NgayThang = ngay;
                        string ThoiGian = gio;
                        string TVTiengAnh = historyItem.English;
                        string TVPhienAm = historyItem.Pronunciation;
                        string TVTiengViet = historyItem.Vietnamese;

                        ucLSTuVung = new UC_LS_TuVung(idHienTai, ThoiGian, NgayThang, TVTiengAnh, TVPhienAm, TVTiengViet);

                        flpContent.Controls.Add(ucLSTuVung);
                        _listUCLSTV.Add(ucLSTuVung);
                        ucLSTuVung.Name = "unCheck";
                    }
                    return historyData;
                }
                else
                {
                    RJMessageBox.Show(apiResponse.Message);
                    return null;
                }

            }
            catch (Exception ex)
            {
                RJMessageBox.Show(ex.Message);
                return null;
            }
        }
        public async Task<List<WordLookupHistory>> HienThiLSDichTheoThoiGianAsync(string thoiGian)
        {
            try
            {
                HttpResponseMessage response = await client.GetAsync(apiUrl + $"display-by-time-translate-history?user_id={Class_TaiKhoan.IdTaiKhoan}&time={thoiGian}");

                string responseContent = await response.Content.ReadAsStringAsync();

                var apiResponse = JsonConvert.DeserializeObject<ApiResponse<List<WordLookupHistory>>>(responseContent);

                if (apiResponse.Status && apiResponse.Data != null)
                {
                    var historyData = apiResponse.Data;

                    foreach (var historyItem in historyData)
                    {
                        idHienTai = historyItem.id.ToString();

                        DateTime createdAtDateTime = DateTime.Parse(historyItem.created_at);
                        string ngay = createdAtDateTime.ToString("dd/MM/yyyy");
                        string gio = createdAtDateTime.ToString("HH:mm tt");

                        string NgayThang = ngay;
                        string ThoiGian = gio;
                        string TVTiengAnh = historyItem.English;
                        string TVPhienAm = historyItem.Pronunciation;
                        string TVTiengViet = historyItem.Vietnamese;

                        ucLSVanBan = new UC_LS_VanBan(idHienTai, ThoiGian, NgayThang, TVTiengAnh, TVTiengViet);
                        flpContent.Controls.Add(ucLSVanBan);

                        _listUCLSVB.Add(ucLSVanBan);
                        ucLSVanBan.Name = "unCheck";
                    }
                    return historyData;
                }
                else
                {
                    RJMessageBox.Show(apiResponse.Message);
                    return null;
                }
            }
            catch (Exception ex)
            {
                RJMessageBox.Show(ex.Message);
                return null;
            }
        }
        private async void btnTatCa_Click(object sender, EventArgs e)
        {
            await HienThiLSTraTu();
            await HienThiLSDich();
        }

        private async void btnThoiGian_Click(object sender, EventArgs e)
        {
            DateTime today = DateTime.Today;
            int currentDayOfWeek = (int)today.DayOfWeek;
            DateTime sunday = today.AddDays(-currentDayOfWeek);
            DateTime monday = sunday.AddDays(1);
            Console.WriteLine(currentDayOfWeek);
            if (currentDayOfWeek == 0)
            {
                monday = monday.AddDays(-7);
            }
            var dates = Enumerable.Range(0, 7).Select(days => monday.AddDays(days)).ToList();

            string loai = (sender as Guna2Button).Name;
            switch (loai)
            {
                case "btnHomNay":
                    _listUCLSTV.Clear();
                    flpContent.Controls.Clear();
                    await HienThiLSTraTuTheoThoiGianAsync(DateTime.Today.ToString("dd/MM/yyyy"));
                    await HienThiLSDichTheoThoiGianAsync(DateTime.Today.ToString("dd/MM/yyyy"));
                    break;
                case "btnHomQua":
                    _listUCLSTV.Clear();
                    flpContent.Controls.Clear();
                    await HienThiLSTraTuTheoThoiGianAsync(DateTime.Today.AddDays(-1).ToString("dd/MM/yyyy"));
                    await HienThiLSDichTheoThoiGianAsync(DateTime.Today.AddDays(-1).ToString("dd/MM/yyyy"));
                    break;
                case "btnTuanNay":
                    _listUCLSTV.Clear();
                    flpContent.Controls.Clear();
                    foreach (var item in dates)
                    {
                        await HienThiLSTraTuTheoThoiGianAsync(item.ToString("dd/MM/yyyy"));
                        await HienThiLSDichTheoThoiGianAsync(item.ToString("dd/MM/yyyy"));
                    }
                    break;
                case "btnThangNay":
                    _listUCLSTV.Clear();
                    flpContent.Controls.Clear();
                    await HienThiLSTraTuTheoThoiGianAsync(DateTime.Today.ToString("MM/yyyy"));
                    await HienThiLSDichTheoThoiGianAsync(DateTime.Today.ToString("MM/yyyy"));
                    break;
                case "btnCuHon":
                    _listUCLSTV.Clear();
                    flpContent.Controls.Clear();
                    //tra tu
                    await HienThiLSTraTuTheoThoiGianAsync(DateTime.Today.AddMonths(-1).ToString("MM/yyyy"));
                    await HienThiLSTraTuTheoThoiGianAsync(DateTime.Today.AddMonths(-2).ToString("MM/yyyy"));
                    await HienThiLSTraTuTheoThoiGianAsync(DateTime.Today.AddMonths(-3).ToString("MM/yyyy"));
                    await HienThiLSTraTuTheoThoiGianAsync(DateTime.Today.AddMonths(-4).ToString("MM/yyyy"));
                    // dich
                    await HienThiLSDichTheoThoiGianAsync(DateTime.Today.AddMonths(-1).ToString("MM/yyyy"));
                    await HienThiLSDichTheoThoiGianAsync(DateTime.Today.AddMonths(-2).ToString("MM/yyyy"));
                    await HienThiLSDichTheoThoiGianAsync(DateTime.Today.AddMonths(-3).ToString("MM/yyyy"));
                    await HienThiLSDichTheoThoiGianAsync(DateTime.Today.AddMonths(-4).ToString("MM/yyyy"));
                    break;
            }
        }
    }
}
