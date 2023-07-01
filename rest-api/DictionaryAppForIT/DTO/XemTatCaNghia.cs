using DictionaryAppForIT.API;
using DictionaryAppForIT.Class;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Net.Http;
using System.Threading.Tasks;

namespace DictionaryAppForIT.DTO
{
    public class XemTatCaNghia
    {
        private readonly string apiUrl = BaseUrl.base_url;
        private string connString = ConfigurationManager.ConnectionStrings["DictionaryApp"].ConnectionString;
        public List<Tu> _listTu = new List<Tu>();
        HttpClient client = new HttpClient();
        public XemTatCaNghia()
        {

        }
        public async Task<bool> HienThiThongTinTimKiem(string tenTu)
        {
            try
            {
                HttpResponseMessage response = await client.GetAsync(apiUrl + "search-word?keyword=" + tenTu);
                string json = await response.Content.ReadAsStringAsync();
                dynamic data = JsonConvert.DeserializeObject(json);
                if (response.IsSuccessStatusCode)
                {

                    Tu tu = new Tu();
                    tu.TenTu = data.word_name;
                    tu.TenLoai = data.type_name;
                    tu.PhienAm = data.pronunciations;
                    tu.TenChuyenNganh = data.specialization_name;
                    tu.Nghia = data.means;
                    tu.MoTa = data.description;
                    tu.ViDu = data.example;
                    tu.DongNghia = data.synonymous;
                    tu.TraiNghia = data.antonyms;

                    _listTu.Clear();
                    _listTu.Add(tu);
                    return true;
                }
                else
                {
                    if (data.error != null)
                    {
                        var errorMessage = data.error;
                        RJMessageBox.Show(errorMessage.ToString());
                    }
                    return false;
                }
            }
            catch (Exception ex)
            {
                RJMessageBox.Show(ex.Message);
                return false;
            }
        }
        public async void HienThiThongTinRandom()
        {
            try
            {
                HttpResponseMessage response = await client.GetAsync(apiUrl + "random-word");
                string json = await response.Content.ReadAsStringAsync();
                dynamic data = JsonConvert.DeserializeObject(json);

                if (response.IsSuccessStatusCode)
                {
                    Tu tu = new Tu();
                    tu.TenTu = data.word_name;
                    tu.TenLoai = data.type_name;
                    tu.PhienAm = data.pronunciations;
                    tu.TenChuyenNganh = data.specialization_name;
                    tu.Nghia = data.means;
                    tu.MoTa = data.description;
                    tu.ViDu = data.example;
                    tu.DongNghia = data.synonymous;
                    tu.TraiNghia = data.antonyms;

                    _listTu.Clear();
                    _listTu.Add(tu);
                }
                else
                {
                    RJMessageBox.Show("Lỗi khi tìm từ ngẫu nhiên!");
                }
            }
            catch (Exception ex)
            {
                RJMessageBox.Show(ex.Message);
            }
        }
    }
}
