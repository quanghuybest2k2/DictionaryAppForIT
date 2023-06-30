using DictionaryAppForIT.DAL;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Windows.Forms;
using Newtonsoft.Json;
using System.Net.Http;
using DictionaryAppForIT.Class;
using DictionaryAppForIT.API;

namespace DictionaryAppForIT.DTO
{
    public class XemTatCaNghia
    {
        private readonly string apiUrl = $"{BaseUrl.base_url}random-word";
        private string connString = ConfigurationManager.ConnectionStrings["DictionaryApp"].ConnectionString;
        public List<Tu> _listTu = new List<Tu>();
        HttpClient client = new HttpClient();
        public XemTatCaNghia()
        {

        }
        public void HienThiThongTinTimKiem(string tenTu)
        {
            try
            {
                _listTu.Clear();
                SqlConnection Conn = new SqlConnection(connString);
                SqlCommand cmd = new SqlCommand($"EXEC HienThiThongTin '{tenTu}', '{Class_TaiKhoan.IdTaiKhoan}'", Conn);
                Conn.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    Tu tu = new Tu();
                    tu.TenTu = rdr["TenTu"].ToString();
                    tu.TenLoai = rdr["TenLoai"].ToString();
                    tu.PhienAm = rdr["PhienAm"].ToString();
                    tu.TenChuyenNganh = rdr["TenChuyenNganh"].ToString();
                    tu.Nghia = rdr["Nghia"].ToString();
                    tu.MoTa = rdr["MoTa"].ToString();
                    tu.ViDu = rdr["ViDu"].ToString();

                    tu.DongNghia = rdr["DongNghia"].ToString();

                    tu.TraiNghia = rdr["TraiNghia"].ToString();
                    _listTu.Add(tu);
                }
                Conn.Close();
                Conn.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public async void HienThiThongTinRandom()
        {
            try
            {
                HttpResponseMessage response = await client.GetAsync(apiUrl);
                if (response.IsSuccessStatusCode)
                {
                    string json = await response.Content.ReadAsStringAsync();
                    dynamic data = JsonConvert.DeserializeObject(json);

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
                    RJMessageBox.Show("Lỗi khi gọi API.");
                }
            }
            catch (Exception ex)
            {
                RJMessageBox.Show(ex.Message);
            }
        }
    }
}
