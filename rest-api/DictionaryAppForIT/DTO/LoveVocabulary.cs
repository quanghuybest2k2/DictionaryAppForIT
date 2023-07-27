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
        /*
        MYSQL: 
       SELECT SUM(AllCount) AS Tong_SoMucYeuThich
           FROM (
               SELECT COUNT(*) AS AllCount
               FROM love_vocabularies
               WHERE user_id = 1
               UNION ALL
               SELECT COUNT(*) AS AllCount
               FROM love_texts
               WHERE user_id = 1
           ) AS t;
        */
        public static async Task<string> Tong_So_Muc_Yeu_Thich()
        {
            string result = "";
            try
            {
                HttpResponseMessage response = await client.GetAsync(apiUrl + $"total-love-item/{Class_TaiKhoan.IdTaiKhoan}");

                string responseContent = await response.Content.ReadAsStringAsync();
                JObject responseObject = JObject.Parse(responseContent);
                string totalLoveItem = responseObject["totalLoveItem"].ToString();

                if (response.IsSuccessStatusCode)
                {
                    result = totalLoveItem;
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
