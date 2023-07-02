using DictionaryAppForIT.API;
using DictionaryAppForIT.Class;
using DictionaryAppForIT.DAL;
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
                HienThiTheoChuyenNganhAsync(); // hiển thị lúc load lên
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
                    RJMessageBox.Show("Mã lỗi >> " + response.StatusCode);
                }
            }
            catch (Exception ex)
            {
                RJMessageBox.Show(ex.Message);
            }
        }
        private void btnTimTheoCN_Click(object sender, EventArgs e)
        {

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

        private void txtTimTheoChuyenNganh_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                try
                {
                    string query = $"EXEC TimTheoChuyenNganh '{txtTimTheoChuyenNganh.Text}', '{cbbChuyenNganh.SelectedValue}', '{Class_TaiKhoan.IdTaiKhoan}'";
                    dtgvTuVung.DataSource = DataProvider.Instance.ExecuteQuery(query);
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
                HttpResponseMessage response = await client.GetAsync(apiUrl + "get-suggest");
                string json = await response.Content.ReadAsStringAsync();

                // Phân tích cú pháp JSON để lấy danh sách từ gợi ý
                JObject data = JObject.Parse(json);
                JArray suggestNames = (JArray)data["suggest_name"];

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
            catch (Exception ex)
            {
                RJMessageBox.Show(ex.Message);
            }
        }


        private void txtTimTheoChuyenNganh_TextChanged(object sender, EventArgs e)
        {
            if (txtTimTheoChuyenNganh.Text == "")
            {
                //cái nào cũng được
                //btnTimTheoCN.PerformClick();
                HienThiTheoChuyenNganhAsync();
            }
        }

        private void UC_TVChuyenNganh_Load(object sender, EventArgs e)
        {
            cbbChuyenNganh.SelectedIndexChanged -= CbbChuyenNganh_SelectedIndexChanged;// tách sự kiện
            loadChuyenNganhAsync();
            cbbChuyenNganh.SelectedIndexChanged += CbbChuyenNganh_SelectedIndexChanged;//tạo lại
        }

        private void CbbChuyenNganh_SelectedIndexChanged(object sender, EventArgs e)
        {
            HienThiTheoChuyenNganhAsync();
            GoiYTimKiem();
        }
    }
}
