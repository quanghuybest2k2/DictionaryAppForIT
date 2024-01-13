using DictionaryAppForIT.API;
using DictionaryAppForIT.Class;
using Newtonsoft.Json;
using System;
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
            try
            {
                if (Class_TaiKhoan.authentication(client))
                {
                    HttpResponseMessage response = await client.GetAsync(apiUrl + $"get-translate-history/{Class_TaiKhoan.IdTaiKhoan}");

                    string responseContent = await response.Content.ReadAsStringAsync();

                    var apiResponse = JsonConvert.DeserializeObject<ApiResponse<List<TranslateHistory>>>(responseContent);

                    if (apiResponse.Status && apiResponse.Data != null)
                    {
                        return apiResponse.Data;
                    }
                    else
                    {
                        return null;
                    }
                }
                else
                {
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
