using DictionaryAppForIT.API;
using DictionaryAppForIT.Class;
using DictionaryAppForIT.DTO.History;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace DictionaryAppForIT.DTO
{
    public class CheckIfExist
    {
        private static readonly string apiUrl = BaseUrl.base_url;
        private static readonly HttpClient client = new HttpClient();
        public CheckIfExist()
        {

        }
        // type translateHistory, word
        public static async Task<bool> CheckIfWordExistsAsync(string word, string type)
        {
            try
            {
                if (!Class_TaiKhoan.authentication(client))
                {
                    return false;
                }
                HttpResponseMessage response = await client.GetAsync(apiUrl + $"check-if-exist?english={word}&user_id={Class_TaiKhoan.IdTaiKhoan}");

                string responseContent = await response.Content.ReadAsStringAsync();

                var apiResponse = JsonConvert.DeserializeObject<ApiResponse<CheckResponse>>(responseContent);

                if (apiResponse.Status)
                {
                    switch (type)
                    {
                        case "word":
                            var wordExist = apiResponse.Data.word;
                            return wordExist > 0;

                        case "loveText":
                            var translateExist = apiResponse.Data.loveText;
                            return translateExist > 0;

                        default:
                            return false;
                    }
                }
                else
                {
                    RJMessageBox.Show(apiResponse.Message);
                    return false;
                }

            }
            catch (Exception ex)
            {
                RJMessageBox.Show("Đã có lỗi xảy ra: " + ex.Message);
                return false;
            }
        }
    }
}
