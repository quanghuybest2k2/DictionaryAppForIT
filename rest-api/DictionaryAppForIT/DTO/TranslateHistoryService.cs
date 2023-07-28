using DictionaryAppForIT.API;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace DictionaryAppForIT.DTO
{
    public class TranslateHistoryService
    {
        private static readonly HttpClient client = new HttpClient();
        private static readonly string apiUrl = BaseUrl.base_url;

        public TranslateHistoryService()
        {

        }
        public static async Task<List<TranslateHistory>> LoadLichSu()
        {
            HttpResponseMessage response = await client.GetAsync(apiUrl + $"get-translate-history/{Class_TaiKhoan.IdTaiKhoan}");
            if (response.IsSuccessStatusCode)
            {
                string jsonResponse = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<dynamic>(jsonResponse);

                var translateHistoryList = result.translateHistory.ToObject<List<TranslateHistory>>();

                return translateHistoryList;
            }
            else
            {
                return null;
            }
        }
    }
}
