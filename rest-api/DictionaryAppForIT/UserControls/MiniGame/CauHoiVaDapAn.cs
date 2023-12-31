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
    public class CauHoiVaDapAn
    {
        private static readonly HttpClient client = new HttpClient();
        private static readonly string apiUrl = BaseUrl.base_url;

        public bool DaTraLoi;
        public bool TraLoiDung;
        public string CauTraLoi { get; set; }
        public int Stt { get; set; }
        public string TuVung { get; set; }
        public string TuLoai { get; set; }
        public string DapAnDung { get; set; }
        public List<string> DapAnRandom;
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
        public async Task RandomDapAnSai()
        {
            // số lượng record trả về ngoại trừ {TuVung}
            int soLuong = 3;
            string dapAn;
            try
            {
                HttpResponseMessage response = await client.GetAsync(apiUrl + $"get-random-wrong-answers/{TuVung}/{soLuong}");

                string responseContent = await response.Content.ReadAsStringAsync();

                var apiResponse = JsonConvert.DeserializeObject<ApiResponse<MiniGameResponse[]>>(responseContent);

                if (apiResponse.Status && apiResponse.Data != null)
                {
                    foreach (var item in apiResponse.Data)
                    {
                        dapAn = item.vietnamese;
                        DapAnRandom.Add(dapAn);
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
