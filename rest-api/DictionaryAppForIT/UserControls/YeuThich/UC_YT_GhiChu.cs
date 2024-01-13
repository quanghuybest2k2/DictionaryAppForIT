using DictionaryAppForIT.API;
using DictionaryAppForIT.Class;
using DictionaryAppForIT.DTO;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Windows.Forms;

namespace DictionaryAppForIT.UserControls.YeuThich
{
    public partial class UC_YT_GhiChu : UserControl
    {
        private static readonly HttpClient client = new HttpClient();
        private static readonly string apiUrl = BaseUrl.base_url;

        string maxKiTuNhap = "115";
        public bool isClose;
        public int _loai; // 1 là từ vựng, 2 là văn bản
        public UC_YT_GhiChu(string index, string ghiChu, int loai)
        {
            InitializeComponent();
            statusStripSoKyTuNhap.SizingGrip = false;
            isClose = false;

            this.lblIndex.Text = index;
            this.txtGhiChu.Text = ghiChu;
            this._loai = loai;
        }

        public string Index
        {
            get { return lblIndex.Text; }
            set { lblIndex.Text = value; }
        }

        public string GhiChu
        {
            get { return txtGhiChu.Text; }
            set { txtGhiChu.Text = value; }
        }

        private void txtGhiChu_TextChanged(object sender, EventArgs e)
        {
            txtGhiChu.Text = txtGhiChu.Text.Replace(Environment.NewLine, "");
            tsslSoKyTuNhap.Text = "Số ký tự nhập: " + txtGhiChu.Text.Length.ToString() + "/" + maxKiTuNhap;
        }

        private void UC_YT_GhiChu_Load(object sender, EventArgs e)
        {
            tsslSoKyTuNhap.Text = "Số ký tự nhập: " + txtGhiChu.Text.Length.ToString() + "/" + maxKiTuNhap;
        }

        private void btnChinhSuaGhiChu_Click(object sender, EventArgs e)
        {
            txtGhiChu.Enabled = true;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            isClose = true;

        }

        private void btnXoaGhiChu_Click(object sender, EventArgs e)
        {
            txtGhiChu.Enabled = true;
            txtGhiChu.Clear();
            txtGhiChu.Enabled = false;
            CapNhatGhiChu("Làm sạch thành công!");
        }

        public void KTGhiChu()
        {
            if (string.IsNullOrEmpty(txtGhiChu.Text))
            {
                btnChinhSuaGhiChu.PerformClick();
                txtGhiChu.PlaceholderText = "Nhập ghi chú [nhấn Enter để lưu]";
            }
        }

        private void txtGhiChu_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (txtGhiChu.Text.Length > 115)
                {
                    RJMessageBox.Show("Vượt quá số ký tự nhập! Vui lòng thử lại.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                else
                {
                    CapNhatGhiChu("Cập nhật ghi chú thành công!");
                }
            }
        }

        private async void CapNhatGhiChu(string xoaThanhCong)
        {
            if (_loai == 1)
            {
                if (Class_TaiKhoan.authentication(client))
                {
                    var input = new FormUrlEncodedContent(new[]
                {
                    new KeyValuePair<string, string>("Note", txtGhiChu.Text.Trim())
                });

                    HttpResponseMessage response = await client.PutAsync(apiUrl + $"update-favorite-vocabulary/{lblIndex.Text}/{Class_TaiKhoan.IdTaiKhoan}", input);

                    string responseContent = await response.Content.ReadAsStringAsync();

                    var apiResponse = JsonConvert.DeserializeObject<ApiResponse<object>>(responseContent);

                    if (apiResponse.Status && apiResponse.Data != null)
                    {
                        RJMessageBox.Show($"{xoaThanhCong}", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtGhiChu.Enabled = false;
                    }
                    else
                    {
                        RJMessageBox.Show("Không thành công!!!", "Thất bại", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                if (Class_TaiKhoan.authentication(client))
                {
                    var input = new FormUrlEncodedContent(new[]
                {
                    new KeyValuePair<string, string>("Note", txtGhiChu.Text.Trim())
                });

                    HttpResponseMessage response = await client.PutAsync(apiUrl + $"update-favorite-text/{lblIndex.Text}/{Class_TaiKhoan.IdTaiKhoan}", input);

                    string responseContent = await response.Content.ReadAsStringAsync();

                    var apiResponse = JsonConvert.DeserializeObject<ApiResponse<object>>(responseContent);

                    if (apiResponse.Status && apiResponse.Data != null)
                    {
                        RJMessageBox.Show($"{xoaThanhCong}", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtGhiChu.Enabled = false;
                    }
                    else
                    {
                        RJMessageBox.Show("Không thành công!!!", "Thất bại", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
    }
}
