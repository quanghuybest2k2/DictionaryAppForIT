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
        private readonly string apiUrl = BaseUrl.base_url;
        HttpClient client = new HttpClient();
        public CheckIfExist()
        {

        }
        // type translateHistory, word
        public async Task<bool> CheckIfWordExistsAsync(string word, string type)
        {
            try
            {
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
                    string message = apiResponse.Message;
                    RJMessageBox.Show(message);
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
