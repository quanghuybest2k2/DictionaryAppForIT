using DictionaryAppForIT.API;
using DictionaryAppForIT.Class;
using DictionaryAppForIT.DTO.Home;
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
                HttpResponseMessage response = await client.GetAsync(apiUrl + $"search-word?keyword={tenTu}");

                string responseContent = await response.Content.ReadAsStringAsync();

                var apiResponse = JsonConvert.DeserializeObject<ApiResponse<WordResponse[]>>(responseContent);

                if (apiResponse.Status && apiResponse.Data != null)
                {
                    _listTu.Clear();
                    foreach (var word in apiResponse.Data)
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
                    RJMessageBox.Show(apiResponse.Message);
                    return false;
                }
            }
            catch (Exception ex)
            {
                RJMessageBox.Show(ex.Message);
                return false;
            }
        }

        public async Task HienThiThongTinRandom()
        {
            try
            {
                if (Class_TaiKhoan.authentication(client))
                {
                    HttpResponseMessage response = await client.GetAsync(apiUrl + "random-word");

                    string responseContent = await response.Content.ReadAsStringAsync();

                    var apiResponse = JsonConvert.DeserializeObject<ApiResponse<WordResponse>>(responseContent);
                    var data = apiResponse.Data;

                    if (apiResponse.Status && data != null)
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
            }
            catch (Exception ex)
            {
                RJMessageBox.Show(ex.Message);
            }
        }
    }
}