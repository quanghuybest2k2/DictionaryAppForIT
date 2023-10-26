using DictionaryAppForIT.API;
using DictionaryAppForIT.Class;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
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

                if (response.IsSuccessStatusCode)
                {
                    string responseContent = await response.Content.ReadAsStringAsync();
                    JObject responseObject = JObject.Parse(responseContent);
                    bool status = (bool)responseObject["status"];

                    if (status)
                    {
                        int totalLoveItem = (int)responseObject["data"];
                        result = totalLoveItem.ToString();
                    }
                    else
                    {
                        string message = (string)responseObject["message"];
                        RJMessageBox.Show(message);
                    }
                }
                else
                {
                    RJMessageBox.Show("Lỗi khi gọi API");
                }
            }
            catch (Exception ex)
            {
                RJMessageBox.Show(ex.Message);
            }
            return result;
        }
        //
    }
}
