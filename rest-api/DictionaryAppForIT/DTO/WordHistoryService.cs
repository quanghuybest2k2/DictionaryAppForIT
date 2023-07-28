using DictionaryAppForIT.API;
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
        public static async Task<List<WordLookupHistory>> LoadWordLookupHistory ()
        {
            HttpResponseMessage response = await client.GetAsync(apiUrl + $"get-word-lookup-history/{Class_TaiKhoan.IdTaiKhoan}");
            if (response.IsSuccessStatusCode)
            {
                string jsonResponse = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<dynamic>(jsonResponse);

                var wordHistoryList = result.WordLookupHistory.ToObject<List<WordLookupHistory>>();

                return wordHistoryList;
            }
            else
            {
                return null;
            }
        }
    }
}
