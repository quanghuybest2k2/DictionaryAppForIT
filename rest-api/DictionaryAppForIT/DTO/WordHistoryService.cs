using DictionaryAppForIT.API;
using DictionaryAppForIT.Class;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace DictionaryAppForIT.DTO
{
    public class WordHistoryService
    {
        private static readonly HttpClient client = new HttpClient();
        private static readonly string apiUrl = BaseUrl.base_url;

        public WordHistoryService()
        {

        }
        public static async Task<List<WordLookupHistory>> LoadWordLookupHistory()
        {
            try
            {
                HttpResponseMessage response = await client.GetAsync(apiUrl + $"get-word-lookup-history/{Class_TaiKhoan.IdTaiKhoan}");

                if (response.IsSuccessStatusCode)
                {
                    string jsonResponse = await response.Content.ReadAsStringAsync();
                    var result = JsonConvert.DeserializeObject<dynamic>(jsonResponse);
                    var historyData = result["data"].ToObject<List<WordLookupHistory>>();
                    return historyData;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }

    }
}
