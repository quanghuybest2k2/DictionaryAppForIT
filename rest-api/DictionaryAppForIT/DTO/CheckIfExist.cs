using DictionaryAppForIT.API;
using DictionaryAppForIT.Class;
using Newtonsoft.Json.Linq;
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
            HttpResponseMessage response = await client.GetAsync(apiUrl + $"check-if-exist?english={word}&user_id={Class_TaiKhoan.IdTaiKhoan}");
            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadAsStringAsync();
                var status = JObject.Parse(result)["status"].ToObject<int>();
                // giải mã json
                switch (type)
                {
                    case "word":
                        var wordExist = JObject.Parse(result)["word"].ToObject<int>();
                        return wordExist > 0;

                    case "translateHistory":
                        var translateExist = JObject.Parse(result)["translateHistory"].ToObject<int>();
                        return translateExist > 0;

                    default:
                        return false;
                }

            }
            else
            {
                RJMessageBox.Show("Đã có lỗi xảy ra!");
                return false;
            }
        }
    }
}
