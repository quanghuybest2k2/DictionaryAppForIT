using DictionaryAppForIT.API;
using DictionaryAppForIT.Class;
using Newtonsoft.Json.Linq;
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

                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadAsStringAsync();
                    var responseData = JObject.Parse(result);
                    var status = responseData["status"].ToObject<bool>();

                    if (status)
                    {
                        switch (type)
                        {
                            case "word":
                                var wordExist = responseData["data"]["word"].ToObject<int>();
                                return wordExist > 0;

                            case "loveText":
                                var translateExist = responseData["data"]["loveText"].ToObject<int>();
                                return translateExist > 0;

                            default:
                                return false;
                        }
                    }
                    else
                    {
                        // Xử lý trường hợp status là false nếu cần thiết
                        RJMessageBox.Show(responseData["message"].ToString());
                        return false;
                    }
                }
                else
                {
                    RJMessageBox.Show("Đã có lỗi xảy ra khi kết nối với API!");
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
