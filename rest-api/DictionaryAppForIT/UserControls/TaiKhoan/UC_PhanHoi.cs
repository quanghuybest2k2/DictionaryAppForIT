using DictionaryAppForIT.API;
using DictionaryAppForIT.Class;
using DictionaryAppForIT.DTO.Home;
using DictionaryAppForIT.DTO;
using Guna.UI2.WinForms;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Windows.Forms;

namespace DictionaryAppForIT.UserControls.TaiKhoan
{
    public partial class UC_PhanHoi : UserControl
    {
        private readonly HttpClient client = new HttpClient();
        private readonly string apiUrl = BaseUrl.base_url;
        int star = 0;

        public UC_PhanHoi()
        {
            InitializeComponent();
        }

        private async void btnDanhGia(object sender, EventArgs e)
        {
            var getText = (sender as Guna2Button).Name;
            switch (getText)
            {
                case "btnVeryBad":
                    star = 1;
                    break;
                case "btnBad":
                    star = 2;
                    break;
                case "btnNormal":
                    star = 3;
                    break;
                case "btnGood":
                    star = 4;
                    break;
                case "btnVeryGood":
                    star = 5;
                    break;
                default:
                    star = 0;
                    break;
            }
            //RJMessageBox.Show(star.ToString());
        }

        private async void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                if (Class_TaiKhoan.authentication(client))
                {
                    var requestData = new Dictionary<string, string>
                {
                    { "user_id", Class_TaiKhoan.IdTaiKhoan },
                    { "rating", star.ToString() },
                    { "comment", txtComment.Text.Trim()}
                };
                    //gửi request
                    var response = await client.PostAsync(apiUrl + "reviews", new FormUrlEncodedContent(requestData));

                    var responseContent = await response.Content.ReadAsStringAsync();

                    var apiResponse = JsonConvert.DeserializeObject<ApiResponse<WordResponse>>(responseContent);

                    if (apiResponse.Status && apiResponse.Data != null)
                    {
                        RJMessageBox.Show(apiResponse.Message, "Thank you", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        RJMessageBox.Show(apiResponse.Message, "Lỗi rồi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                RJMessageBox.Show(ex.Message);
            }
        }
    }
}
