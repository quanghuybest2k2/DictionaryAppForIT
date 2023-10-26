using DictionaryAppForIT.API;
using DictionaryAppForIT.Class;
using DictionaryAppForIT.DTO;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Speech.Synthesis;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DictionaryAppForIT.UserControls.Home
{
    public partial class UC_TVChuyenNganh : UserControl
    {
        private readonly string apiUrl = BaseUrl.base_url;
        HttpClient client = new HttpClient();

        private bool isComboboxLoaded = false;// biến cờ để kiển tra cbb load lên chưa
        SpeechSynthesizer speech;
        public bool thayDoiTocDo = false;
        public int tocDo = 0;
        public UC_TVChuyenNganh()
        {
            InitializeComponent();
            speech = new SpeechSynthesizer();
            dtgvTuVung.AutoGenerateColumns = false;
        }
        private async Task loadChuyenNganhAsync()
        {
            try
            {
                HttpResponseMessage response = await client.GetAsync(apiUrl + "get-all-specialization");
                if (response.IsSuccessStatusCode)
                {
                    string jsonString = await response.Content.ReadAsStringAsync();
                    JObject jsonObject = JObject.Parse(jsonString);

                    if (jsonObject.ContainsKey("specialization"))
                    {
                        JArray specializationArray = (JArray)jsonObject["specialization"];
                        List<Specialization> specializations = specializationArray.ToObject<List<Specialization>>();

                        cbbChuyenNganh.DataSource = specializations;
                        cbbChuyenNganh.ValueMember = "id";
                        cbbChuyenNganh.DisplayMember = "specialization_name";
                        isComboboxLoaded = true;
                    }
                    else
                    {
                        RJMessageBox.Show("Không tìm thấy dữ liệu chuyên ngành!");
                    }
                }
                else
                {
                    RJMessageBox.Show("Mã lỗi >> " + response.StatusCode);
                }
                await HienThiTheoChuyenNganhAsync(); // hiển thị lúc load lên
            }
            catch (Exception ex)
            {
                RJMessageBox.Show(ex.Message);
            }
        }
        private async Task HienThiTheoChuyenNganhAsync()
        {
            try
            {
                HttpResponseMessage response = await client.GetAsync(apiUrl + $"display-by-specialization?specialization_id={cbbChuyenNganh.SelectedValue}");

                if (response.IsSuccessStatusCode)
                {
                    string jsonString = await response.Content.ReadAsStringAsync();
                    JObject jsonObject = JObject.Parse(jsonString);

                    if (jsonObject.ContainsKey("specializations"))
                    {
                        JArray specializationArray = (JArray)jsonObject["specializations"];
                        List<WordBySpecialization> specializations = specializationArray.ToObject<List<WordBySpecialization>>();

                        dtgvTuVung.DataSource = specializations;
                        lblSoTuHienCo.Text = dtgvTuVung.Rows.Count.ToString();
                    }
                    else
                    {
                        RJMessageBox.Show("Không tìm thấy dữ liệu chuyên ngành!");
                    }
                }
                else
                {
                    RJMessageBox.Show("Lỗi rồi! Mã lỗi >> " + response.StatusCode);
                }
            }
            catch (Exception ex)
            {
                RJMessageBox.Show(ex.Message);
            }
        }
        private void TocDoNoi()
        {
            if (thayDoiTocDo)
            {
                speech.Rate = tocDo;
            }
        }
        private void dtgvTuVung_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 1) //Cột thứ 2(hình cái loa)
            {
                //MessageBox.Show("Bạn click vào loa hàng số " + e.RowIndex);
                txtTuVungDoc.Text = dtgvTuVung.CurrentRow.Cells["ColTuVung"].Value.ToString();
                speech.SelectVoice("Microsoft David Desktop"); //giong mỹ
                TocDoNoi();
                speech.SpeakAsync(txtTuVungDoc.Text);
            }
        }

        private async void txtTimTheoChuyenNganh_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                try
                {
                    HttpResponseMessage response = await client.GetAsync($"{apiUrl}search-by-specialty?searched_word={txtTimTheoChuyenNganh.Text}&specialization_id={cbbChuyenNganh.SelectedValue}");

                    if (response.IsSuccessStatusCode)
                    {
                        string jsonString = await response.Content.ReadAsStringAsync();
                        JObject jsonObject = JObject.Parse(jsonString);

                        if (jsonObject.ContainsKey("word_by_specialty"))
                        {
                            JArray specializationArray = (JArray)jsonObject["word_by_specialty"];
                            List<WordBySpecialization> specializations = specializationArray.ToObject<List<WordBySpecialization>>();

                            dtgvTuVung.DataSource = specializations;
                            lblSoTuHienCo.Text = dtgvTuVung.Rows.Count.ToString();
                        }
                        else
                        {
                            RJMessageBox.Show("Không tìm thấy dữ liệu chuyên ngành!");
                        }
                    }
                    else
                    {
                        RJMessageBox.Show($"Không tìm thấy từ {txtTimTheoChuyenNganh.Text} trong này!");
                    }
                }
                catch (Exception ex)
                {
                    RJMessageBox.Show(ex.Message);
                }
            }
        }
        private async void GoiYTimKiem()
        {
            try
            {
                if (isComboboxLoaded && cbbChuyenNganh.SelectedValue != null)
                {
                    HttpResponseMessage response = await client.GetAsync(apiUrl + $"get-suggest?specialization_id={cbbChuyenNganh.SelectedValue}");
                    response.EnsureSuccessStatusCode(); // Đảm bảo request thành công

                    string json = await response.Content.ReadAsStringAsync();

                    // Phân tích cú pháp JSON để lấy danh sách từ gợi ý
                    JObject data = JObject.Parse(json);
                    bool status = (bool)data["status"];

                    if (status) // Kiểm tra trạng thái của API
                    {
                        JArray suggestNames = (JArray)data["data"];

                        // Tạo một AutoCompleteStringCollection và thêm các từ gợi ý vào đó
                        AutoCompleteStringCollection autoComplete = new AutoCompleteStringCollection();
                        foreach (string suggestName in suggestNames)
                        {
                            autoComplete.Add(suggestName);
                        }

                        // Cài đặt thuộc tính AutoComplete của TextBox
                        txtTimTheoChuyenNganh.AutoCompleteSource = AutoCompleteSource.CustomSource;
                        txtTimTheoChuyenNganh.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                        txtTimTheoChuyenNganh.AutoCompleteCustomSource = autoComplete;
                    }
                    else
                    {
                        string message = (string)data["message"];
                        RJMessageBox.Show(message); // Hiển thị thông báo nếu API trả về lỗi
                    }
                }
            }
            catch (HttpRequestException ex)
            {
                RJMessageBox.Show($"Lỗi khi gửi yêu cầu tới API: {ex.Message}");
            }
            catch (Exception ex)
            {
                RJMessageBox.Show($"Lỗi: {ex.Message}");
            }
        }
        private async void txtTimTheoChuyenNganh_TextChanged(object sender, EventArgs e)
        {
            if (txtTimTheoChuyenNganh.Text == "")
            {
                await HienThiTheoChuyenNganhAsync();
            }
        }

        private async void UC_TVChuyenNganh_Load(object sender, EventArgs e)
        {
            cbbChuyenNganh.SelectedIndexChanged -= CbbChuyenNganh_SelectedIndexChanged;// tách sự kiện
            await loadChuyenNganhAsync();
            cbbChuyenNganh.SelectedIndexChanged += CbbChuyenNganh_SelectedIndexChanged;//tạo lại
            GoiYTimKiem();
        }

        private async void CbbChuyenNganh_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (isComboboxLoaded)
            {
                await HienThiTheoChuyenNganhAsync();
                GoiYTimKiem();
            }
        }
    }
}
