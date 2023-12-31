using DictionaryAppForIT.API;
using DictionaryAppForIT.Class;
using DictionaryAppForIT.DTO;
using DictionaryAppForIT.DTO.MiniGame;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace DictionaryAppForIT.UserControls.MiniGame
{
    public class DanhSachCauHoi
    {
        public int demSoTu = 0;
        public List<CauHoiVaDapAn> _list;
        CauHoiVaDapAn _item;
        private static readonly HttpClient client = new HttpClient();
        private static readonly string apiUrl = BaseUrl.base_url;

        public DanhSachCauHoi()
        {
            _list = new List<CauHoiVaDapAn>();
            _item = new CauHoiVaDapAn();
        }

        public async Task LoadDSCauHoi()
        {
            try
            {
                // lấy 10 từ để làm 10 câu hỏi
                int soLuong = 10;
                string TiengAnh;
                string TenLoai;
                string TiengViet;
                HttpResponseMessage response = await client.GetAsync(apiUrl + $"get-questions/{soLuong}/{Class_TaiKhoan.IdTaiKhoan}");

                string responseContent = await response.Content.ReadAsStringAsync();

                var apiResponse = JsonConvert.DeserializeObject<ApiResponse<MiniGameResponse[]>>(responseContent);

                if (apiResponse.Status && apiResponse.Data != null)
                {
                    foreach (var item in apiResponse.Data)
                    {
                        demSoTu++;
                        TiengAnh = item.english;
                        TenLoai = item.type_name;
                        TiengViet = item.vietnamese;
                        _item = new CauHoiVaDapAn(demSoTu, TiengAnh, TenLoai, TiengViet);
                        await _item.RandomDapAnSai();
                        _list.Add(_item);
                    }
                }
                else
                {
                    RJMessageBox.Show(apiResponse.Message);
                }
            }
            catch (Exception ex)
            {
                RJMessageBox.Show(ex.Message);
            }
        }
        public async Task BoSungCauHoiNeuChuaDu(int i)
        {
            if (i < 10)
            {
                int num = 10 - i;

                try
                {
                    string TiengAnh;
                    string TenLoai;
                    string TiengViet;

                    HttpResponseMessage response = await client.GetAsync(apiUrl + $"get-more-questions-mini-game/{num}");

                    string responseContent = await response.Content.ReadAsStringAsync();

                    var apiResponse = JsonConvert.DeserializeObject<ApiResponse<MiniGameResponse[]>>(responseContent);

                    if (apiResponse.Status && apiResponse.Data != null)
                    {
                        foreach (var item in apiResponse.Data)
                        {
                            demSoTu++;
                            TiengAnh = item.word_name;
                            TenLoai = item.type_name;
                            TiengViet = item.means;// nghĩa
                            _item = new CauHoiVaDapAn(demSoTu, TiengAnh, TenLoai, TiengViet);
                            await _item.RandomDapAnSai();
                            _list.Add(_item);
                        }
                    }
                    else
                    {
                        RJMessageBox.Show(apiResponse.Message);
                    }
                }
                catch (Exception ex)
                {
                    RJMessageBox.Show(ex.Message);
                }
            }
        }
    }
}
