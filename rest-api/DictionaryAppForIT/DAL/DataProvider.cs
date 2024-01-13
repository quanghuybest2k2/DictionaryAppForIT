using DictionaryAppForIT.API;
using DictionaryAppForIT.Class;
using DictionaryAppForIT.DTO;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DictionaryAppForIT.DAL
{
    public class DataProvider
    {
        private static DataProvider _instance;
        private static readonly HttpClient client = new HttpClient();
        private static readonly string apiUrl = BaseUrl.base_url;
        string token = Class_TaiKhoan.Token;
        public static DataProvider Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new DataProvider();
                }
                return _instance;
            }
        }

        private DataProvider()
        {

        }
        // object result = await DataProvider.Instance.GetMethod<ResponseType>("endpoint", 2, 5, 6);
        public async Task<object> GetMethod<TApiResponse>(string endpoint, bool authentication = false, params object[] parameters)
        {
            try
            {
                bool isAuthenticated = authentication && Class_TaiKhoan.authentication(client);

                if (!isAuthenticated)
                {
                    return null;
                }
                string parameterString = parameters != null ? string.Join("/", parameters) : string.Empty;
                // loại bỏ dấu "/" cuối cùng và thêm dấu "/" 1 lần ở trước
                if (!string.IsNullOrEmpty(parameterString))
                {
                    parameterString = parameterString.TrimEnd('/');
                    parameterString = "/" + parameterString;
                }

                string requestUrl = apiUrl + $"{endpoint}{parameterString}";

                HttpResponseMessage response = await client.GetAsync(requestUrl);

                string responseContent = await response.Content.ReadAsStringAsync();

                var apiResponse = JsonConvert.DeserializeObject<ApiResponse<object>>(responseContent);

                if (apiResponse.Status && apiResponse.Data != null)
                {
                    return apiResponse.Data;
                }
                else
                {
                    string message = apiResponse.Message;
                    RJMessageBox.Show(message, "Thông báo",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                    return null;
                }
            }
            catch (Exception ex)
            {
                RJMessageBox.Show(ex.Message, "Lỗi",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return null;
            }
        }
        //
    }
}