using DictionaryAppForIT.API;
using DictionaryAppForIT.Class;
using DictionaryAppForIT.UserControls.LichSu;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DictionaryAppForIT.DTO
{
    public class WordHistoryService
    {
        private static readonly HttpClient client = new HttpClient();
        private static readonly string apiUrl = BaseUrl.base_url;

        public WordHistoryService()
        {

        }
        public static async Task<List<WordLookupHistory>> LoadWordLookupHistory()
        {
            try
            {
                HttpResponseMessage response = await client.GetAsync(apiUrl + $"get-word-lookup-history/{Class_TaiKhoan.IdTaiKhoan}");

                string responseContent = await response.Content.ReadAsStringAsync();

                var apiResponse = JsonConvert.DeserializeObject<ApiResponse<List<WordLookupHistory>>>(responseContent);


                if (apiResponse.Status && apiResponse.Data != null)
                {
                    var historyData = apiResponse.Data;
                    return historyData;
                }
                else
                {
                    RJMessageBox.Show(apiResponse.Message);
                    return null;
                }
            }
            catch (Exception ex)
            {
                RJMessageBox.Show(ex.Message);
                return null;
            }
        }
        public static async Task XoaLichSuTuVungAsync(UC_LS_TuVung item)
        {
            try
            {
                HttpResponseMessage response = await client.DeleteAsync(apiUrl + $"delete-by-id-word-lookup-history/{Class_TaiKhoan.IdTaiKhoan}/{item.Index}");

                string responseContent = await response.Content.ReadAsStringAsync();

                var apiResponse = JsonConvert.DeserializeObject<ApiResponse<object>>(responseContent);

                if (apiResponse.Status && apiResponse.Data != null)
                {
                    RJMessageBox.Show(apiResponse.Message);
                }
                else
                {
                    string message = apiResponse.Message;
                    RJMessageBox.Show(message);
                }
            }
            catch (Exception ex)
            {
                RJMessageBox.Show($"Lỗi: {ex.Message}");
            }
        }
        public static async Task XoaLichSuVanBanAsync(UC_LS_VanBan item)
        {
            try
            {
                HttpResponseMessage response = await client.DeleteAsync(apiUrl + $"delete-translate-by-id/{Class_TaiKhoan.IdTaiKhoan}/{item.Index}");

                string responseContent = await response.Content.ReadAsStringAsync();

                var apiResponse = JsonConvert.DeserializeObject<ApiResponse<object>>(responseContent);

                if (apiResponse.Status && apiResponse.Data != null)
                {
                    RJMessageBox.Show(apiResponse.Message);
                }
                else
                {
                    string message = apiResponse.Message;
                    RJMessageBox.Show(message);
                }
            }
            catch (Exception ex)
            {
                RJMessageBox.Show($"Lỗi: {ex.Message}");
            }
        }
    }
}
