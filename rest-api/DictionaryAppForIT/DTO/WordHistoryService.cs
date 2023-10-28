using DictionaryAppForIT.API;
using DictionaryAppForIT.Class;
using DictionaryAppForIT.DTO.History;
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
                response.EnsureSuccessStatusCode();

                string responseContent = await response.Content.ReadAsStringAsync();

                var apiResponse = JsonConvert.DeserializeObject<ApiResponse<List<WordLookupHistory>>>(responseContent);


                if (apiResponse.Status && apiResponse.Data != null)
                {
                    var historyData = apiResponse.Data;
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

    }
}
