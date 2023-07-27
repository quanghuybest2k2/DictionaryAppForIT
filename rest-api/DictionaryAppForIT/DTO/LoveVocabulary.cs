using DictionaryAppForIT.API;
using DictionaryAppForIT.Class;
using Newtonsoft.Json.Linq;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace DictionaryAppForIT.DTO
{
    public class LoveVocabulary
    {
        private static readonly HttpClient client = new HttpClient();
        private static readonly string apiUrl = BaseUrl.base_url;

        public LoveVocabulary()
        {

        }

        public static async Task<string> Tong_So_Muc_Yeu_Thich()
        {
            string result = "";
            try
            {
                HttpResponseMessage response = await client.GetAsync(apiUrl + $"total-love-vocabulary/{Class_TaiKhoan.IdTaiKhoan}");

                string responseContent = await response.Content.ReadAsStringAsync();
                JObject responseObject = JObject.Parse(responseContent);
                string totalVocabulary = responseObject["totalVocabulary"].ToString();

                if (response.IsSuccessStatusCode)
                {
                    result = totalVocabulary;
                }
            }
            catch (Exception ex)
            {
                RJMessageBox.Show(ex.Message);
            }
            return result;
        }
    }
}
