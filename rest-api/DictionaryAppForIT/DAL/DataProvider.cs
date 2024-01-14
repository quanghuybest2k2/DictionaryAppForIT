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
                string parameterString = parameters != null ? string.Join("/", parameters) : string.Empty;
                // loại bỏ dấu "/" cuối cùng và thêm dấu "/" 1 lần ở trước
                if (!string.IsNullOrEmpty(parameterString))
                {
                    parameterString = parameterString.TrimEnd('/');
                    parameterString = "/" + parameterString;
                }

                string requestUrl = apiUrl + $"{endpoint}{parameterString}";

                if (authentication && !Class_TaiKhoan.authentication(client))
                {
                    ShowErrorMessage("Chưa đăng nhập!");
                    return null;
                }

                HttpResponseMessage response = await client.GetAsync(requestUrl);
                string responseContent = await response.Content.ReadAsStringAsync();

                var apiResponse = JsonConvert.DeserializeObject<ApiResponse<object>>(responseContent);

                if (apiResponse.Status && apiResponse.Data != null)
                {
                    return apiResponse.Data;
                }
                else
                {
                    ShowErrorMessage(apiResponse.Message);
                    return null;
                }
            }
            catch (Exception ex)
            {
                ShowErrorMessage(ex.Message);
                return null;
            }
        }

        private void ShowErrorMessage(string message)
        {
            RJMessageBox.Show(message, "Thông báo",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning);
        }
        //
    }
}