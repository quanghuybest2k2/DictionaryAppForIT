using DictionaryAppForIT.API;
using DictionaryAppForIT.Class;
using DictionaryAppForIT.DTO;
using DictionaryAppForIT.DTO.Home;
using Newtonsoft.Json;
using System;
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
                await SpecializationService.LoadSpecializationAsync(cbbChuyenNganh);
                isComboboxLoaded = true;
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

                string responseContent = await response.Content.ReadAsStringAsync();

                var apiResponse = JsonConvert.DeserializeObject<ApiResponse<WordBySpecialization[]>>(responseContent);
                var data = apiResponse.Data;

                if (apiResponse.Status && data != null)
                {
                    dtgvTuVung.DataSource = data;
                    lblSoTuHienCo.Text = dtgvTuVung.Rows.Count.ToString();
                }
                else
                {
                    RJMessageBox.Show("Không tìm thấy dữ liệu chuyên ngành!");
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

                    string responseContent = await response.Content.ReadAsStringAsync();

                    var apiResponse = JsonConvert.DeserializeObject<ApiResponse<WordBySpecialization[]>>(responseContent);

                    if (apiResponse.Status && apiResponse.Data != null)
                    {
                        dtgvTuVung.DataSource = apiResponse.Data;
                        lblSoTuHienCo.Text = dtgvTuVung.Rows.Count.ToString();
                    }
                    else
                    {
                        RJMessageBox.Show(apiResponse.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

                    string responseContent = await response.Content.ReadAsStringAsync();

                    var apiResponse = JsonConvert.DeserializeObject<ApiResponse<SuggestAllResponse[]>>(responseContent);

                    if (apiResponse.Status && apiResponse.Data != null) // Kiểm tra trạng thái của API
                    {

                        // Tạo một AutoCompleteStringCollection và thêm các từ gợi ý vào đó
                        AutoCompleteStringCollection autoComplete = new AutoCompleteStringCollection();
                        foreach (var word in apiResponse.Data)
                        {
                            autoComplete.Add(word.word_name);
                        }

                        // Cài đặt thuộc tính AutoComplete của TextBox
                        txtTimTheoChuyenNganh.AutoCompleteSource = AutoCompleteSource.CustomSource;
                        txtTimTheoChuyenNganh.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                        txtTimTheoChuyenNganh.AutoCompleteCustomSource = autoComplete;
                    }
                    else
                    {
                        RJMessageBox.Show(apiResponse.Message);
                    }
                }
            }
            catch (Exception ex)
            {
                RJMessageBox.Show(ex.Message);
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