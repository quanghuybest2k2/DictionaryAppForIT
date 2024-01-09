using DictionaryAppForIT.API;
using DictionaryAppForIT.Class;
using DictionaryAppForIT.DTO;
using DictionaryAppForIT.DTO.Home;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DictionaryAppForIT.UserControls.TaiKhoan
{
    public partial class UC_ThemTu : UserControl
    {
        private static readonly HttpClient client = new HttpClient();
        private static readonly string apiUrl = BaseUrl.base_url;

        private string idTuMoi;

        UC_TT_ThemNghia ucThemNghia;
        int stt = 1;
        List<UC_TT_ThemNghia> _list;
        private bool soDongThemTu;
        private bool soDongThemNghia;
        public UC_ThemTu()
        {
            InitializeComponent();
            _list = new List<UC_TT_ThemNghia>();
            btnThemNghia.PerformClick();
        }
        private void btnThemNghia_Click(object sender, EventArgs e)
        {

            ucThemNghia = new UC_TT_ThemNghia(stt);
            ucThemNghia.Dock = DockStyle.Top;
            pnNghia.Controls.Add(ucThemNghia);
            _list.Add(ucThemNghia);
            stt++;
        }

        private void btnXoaNghia_Click(object sender, EventArgs e)
        {
            foreach (var item in _list)
            {
                if (item.XacNhanXoa)
                {
                    pnNghia.Controls.Remove(item);
                }
            }
        }

        private async void btnThemTuMoi_Click(object sender, EventArgs e)
        {
            await ThemTu();
            foreach (var item in _list)
            {
                if (!item.XacNhanXoa)
                {
                    await ThemNghia(item);
                }
            }
            if (soDongThemTu && soDongThemNghia)
            {
                RJMessageBox.Show("Đóng góp từ vựng thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else
            {
                RJMessageBox.Show("Đã có lỗi xảy ra!.", "Lỗi rồi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            btnMacDinh.PerformClick();
        }
        // Thêm nhĩa
        private async Task ThemNghia(UC_TT_ThemNghia uc)
        {
            string[] arr = uc.LayGiaTriControl();
            try
            {
                var requestData = new Dictionary<string, string>
                {
                    { "word_id", idTuMoi },
                    { "word_type_id", arr[0] },
                    { "means", arr[1]},
                    { "description", arr[2]},
                    { "example", arr[3]}
                };
                //gửi request
                var response = await client.PostAsync(apiUrl + "store-mean", new FormUrlEncodedContent(requestData));

                var responseContent = await response.Content.ReadAsStringAsync();

                var apiResponse = JsonConvert.DeserializeObject<ApiResponse<WordResponse>>(responseContent);

                if (apiResponse.Status && apiResponse.Data != null)
                {
                    soDongThemNghia = true;
                }
                else
                {
                    RJMessageBox.Show(apiResponse.Message);
                }
            }
            catch (Exception ex)
            {
                RJMessageBox.Show(ex.Message);
            }
        }
        // Thêm từ
        private async Task ThemTu()
        {
            try
            {
                var requestData = new Dictionary<string, string>
                {
                    { "word_name", txtTuVung.Text.Trim() },
                    { "specialization_id", cbbChuyenNganh.SelectedValue.ToString() },
                    { "synonymous", txtDongNghia.Text.Trim()},
                    { "antonyms", txtTraiNghia.Text.Trim()}
                };
                //gửi request
                var response = await client.PostAsync(apiUrl + "store-word", new FormUrlEncodedContent(requestData));

                var responseContent = await response.Content.ReadAsStringAsync();

                var apiResponse = JsonConvert.DeserializeObject<ApiResponse<WordResponse>>(responseContent);

                if (apiResponse.Status && apiResponse.Data != null)
                {
                    idTuMoi = apiResponse.Data.id;
                    soDongThemTu = true;
                }
                else
                {
                    RJMessageBox.Show(apiResponse.Message);
                }
            }
            catch (Exception ex)
            {
                RJMessageBox.Show(ex.Message);
            }
        }

        private async void UC_ThemTu_Load(object sender, EventArgs e)
        {
            await SpecializationService.LoadSpecializationAsync(cbbChuyenNganh);
            cbbChuyenNganh.SelectedIndex = 0;
        }

        private void btnMacDinh_Click(object sender, EventArgs e)
        {
            txtTuVung.Clear();
            txtDongNghia.Clear();
            txtTraiNghia.Clear();
            pnNghia.Controls.Clear();
            _list.Clear();
            stt = 1;
            btnThemNghia.PerformClick();
        }
    }
}
