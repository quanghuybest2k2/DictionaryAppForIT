using DictionaryAppForIT.API;
using DictionaryAppForIT.Class;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace DictionaryAppForIT.DTO
{
    public class XemTatCaNghia
    {
        private readonly string apiUrl = BaseUrl.base_url;
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

                if (response.IsSuccessStatusCode && data.status == true)
                {
                    _listTu.Clear();

                    foreach (var word in data.data)
                    {
                        Tu tu = new Tu();
                        tu.TenTu = word.word_name;
                        tu.TenLoai = word.type_name;
                        tu.PhienAm = word.pronunciations;
                        tu.TenChuyenNganh = word.specialization_name;
                        tu.Nghia = word.means;
                        tu.MoTa = word.description;
                        tu.ViDu = word.example;
                        tu.DongNghia = word.synonymous;
                        tu.TraiNghia = word.antonyms;

                        _listTu.Add(tu);
                    }
                    return true;
                }
                else
                {
                    if (data.message != null)
                    {
                        RJMessageBox.Show(data.message.ToString());
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

                if (response.IsSuccessStatusCode && data.status == true)
                {
                    dynamic word = data.data;
                    Tu tu = new Tu();
                    tu.TenTu = word.word_name;
                    tu.TenLoai = word.type_name;
                    tu.PhienAm = word.pronunciations;
                    tu.TenChuyenNganh = word.specialization_name;
                    tu.Nghia = word.means;
                    tu.MoTa = word.description;
                    tu.ViDu = word.example;
                    tu.DongNghia = word.synonymous;
                    tu.TraiNghia = word.antonyms;

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
