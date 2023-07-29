using DictionaryAppForIT.API;
using DictionaryAppForIT.Class;
using DictionaryAppForIT.DTO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Net.Http;
using System.Text;
using System.Windows.Forms;

namespace DictionaryAppForIT.UserControls.TaiKhoan
{
    public partial class UC_QuanLyTK : UserControl
    {
        private readonly string apiUrl = BaseUrl.base_url;
        private int tgSuDung = 0;
        HttpClient client;

        public UC_QuanLyTK()
        {
            InitializeComponent();
            client = new HttpClient();
        }
        #region Xử lý richtextbox đổi màu chữ

        public string SoMuc
        {
            get { return lblSoMuc.Text; }
            set { lblSoMuc.Text = value; }
        }
        private void ThoiGianTaoTaiKhoan()
        {
            RichTextBox rtb1 = new RichTextBox();
            rtb1.Font = new System.Drawing.Font("Segoe UI", 10F);
            rtb1.SelectionColor = Color.Gray;
            rtb1.AppendText(" Bạn đã tạo tài khoản ngày ");
            rtb1.SelectionColor = ColorTranslator.FromHtml("#3776ab");

            string ngayTao = Class_TaiKhoan.ngayTaoTK;
            string date = DateTime.Parse(ngayTao).ToLocalTime().ToString("dd/MM/yyyy");

            rtb1.AppendText(date);
            rtb1.SelectionColor = Color.Gray;
            rtb1.Size = new System.Drawing.Size(242, 23);
            rtb1.Location = new Point(69, 29);
            rtb1.Name = "rtxtThoiGianTaoTK";
            rtb1.BorderStyle = BorderStyle.None;
            rtb1.ReadOnly = true;
            rtb1.BackColor = System.Drawing.Color.LemonChiffon;
            panelThoiGianTao.Controls.Add(rtb1);
        }
        private void ThoiGianSuDung()
        {
            RichTextBox rtb1 = new RichTextBox();
            rtb1.Font = new System.Drawing.Font("Segoe UI", 10F);
            rtb1.SelectionColor = Color.Gray;
            rtb1.AppendText("Hôm nay bạn đã sử dụng từ điển trong ");
            rtb1.SelectionColor = ColorTranslator.FromHtml("#3776ab");
            rtb1.AppendText(tgSuDung.ToString());
            rtb1.SelectionColor = Color.Gray;
            rtb1.AppendText(" tiếng đồng hồ");
            rtb1.Size = new System.Drawing.Size(242, 43);
            rtb1.Location = new Point(72, 26);
            rtb1.Name = "rtxtThoiGianSuDung";
            rtb1.BorderStyle = BorderStyle.None;
            rtb1.ReadOnly = true;
            rtb1.BackColor = System.Drawing.Color.LemonChiffon;
            panelThoiGianSuDung.Controls.Add(rtb1);
        }
        #endregion
        private async void btnXoaTaiKhoan_Click(object sender, EventArgs e)
        {
            var result = RJMessageBox.Show("Bạn có thực sự muốn xóa tài khoản này vĩnh viễn?",
            "Xác nhận xóa tài khoản",
            MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                // xóa tài khoản

                HttpResponseMessage response = await client.DeleteAsync(apiUrl + $"delete-user/{Class_TaiKhoan.IdTaiKhoan}");

                string responseContent = await response.Content.ReadAsStringAsync();
                JObject responseObject = JObject.Parse(responseContent);
                string message = responseObject["message"].ToString();

                if (response.IsSuccessStatusCode)
                {
                    RJMessageBox.Show(message, "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Application.Exit();
                }
                else
                {
                    RJMessageBox.Show(message, "Lỗi rồi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            if (result == DialogResult.No)
            {
                return;
            }
        }

        private int KTGioiTinh()
        {
            int gt = rdNam.Checked ? 1 : rdNu.Checked ? 2 : 3;
            return gt;
        }

        private async void LuuThayDoiTK_Click(object sender, EventArgs e)
        {
            try
            {
                Dictionary<string, string> userInput = new Dictionary<string, string>
                {
                    { "name", txtUsername.Text.Trim() },
                    { "email", txtEmail.Text.Trim()},
                    { "gender", KTGioiTinh().ToString() }
                };
                string DataRequest = JsonConvert.SerializeObject(userInput);

                HttpContent content = new StringContent(DataRequest, Encoding.UTF8, "application/json");
                HttpResponseMessage response = await client.PutAsync(apiUrl + $"update-user/{Class_TaiKhoan.IdTaiKhoan}", content);

                if (response.IsSuccessStatusCode)
                {
                    string responseContent = await response.Content.ReadAsStringAsync();
                    dynamic data = JsonConvert.DeserializeObject(responseContent);
                    string message = data.message;
                    RJMessageBox.Show(message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    string responseContent = await response.Content.ReadAsStringAsync();
                    dynamic data = JsonConvert.DeserializeObject(responseContent);

                    if (data.validator_errors != null)
                    {
                        var errorMessageBuilder = new StringBuilder();
                        var validatorErrors = data.validator_errors;

                        foreach (var keyValuePair in validatorErrors)
                        {
                            var errorMessages = keyValuePair.Value;
                            errorMessageBuilder.AppendLine($"{errorMessages[0]}");
                        }

                        RJMessageBox.Show(Environment.NewLine + errorMessageBuilder.ToString());
                    }
                    else if (data.message != null)
                    {
                        var errorMessage = data.message;
                        RJMessageBox.Show(errorMessage.ToString());
                    }
                    else
                    {
                        RJMessageBox.Show("Không thể cập nhật tài khoản!", "Lỗi rồi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                RJMessageBox.Show(ex.Message);
            }
        }


        private void btnSuaEmail_Click(object sender, EventArgs e)
        {
            if (btnSuaEmail.Checked)
            {
                txtEmail.ReadOnly = false;
                txtEmail.FillColor = Color.White;
                pbNenEmail1.FillColor = Color.MediumSpringGreen;
                pbNenEmail2.FillColor = Color.MediumSpringGreen;
                btnLuuThayDoiTK.Enabled = true;
            }
            else
            {
                txtEmail.ReadOnly = true;
                txtEmail.FillColor = Color.FromArgb(251, 251, 251);
                pbNenEmail1.FillColor = Color.Tomato;
                pbNenEmail2.FillColor = Color.Tomato;
            }

        }

        private void btnSuaTenDangNhap_Click(object sender, EventArgs e)
        {
            if (btnSuaTenDangNhap.Checked)
            {
                txtUsername.ReadOnly = false;
                txtUsername.FillColor = Color.White;
                pbNenUsername1.FillColor = Color.MediumSpringGreen;
                pbNenUsername2.FillColor = Color.MediumSpringGreen;
                btnLuuThayDoiTK.Enabled = true;
            }
            else
            {
                txtUsername.ReadOnly = true;
                txtUsername.FillColor = Color.FromArgb(251, 251, 251);
                pbNenUsername1.FillColor = Color.Tomato;
                pbNenUsername2.FillColor = Color.Tomato;
            }

        }
        private void UC_QuanLyTK_Load(object sender, EventArgs e)
        {
            ThoiGianTaoTaiKhoan();
            ThoiGianSuDung();
            HienThiThongTinTaiKhoan(); // Hiển thị thông tin tài khoản
        }
        private async void HienThiThongTinTaiKhoan()
        {
            try
            {
                HttpResponseMessage response = await client.GetAsync(apiUrl + $"get-user/{Class_TaiKhoan.IdTaiKhoan}");

                string responseContent = await response.Content.ReadAsStringAsync();
                dynamic data = JsonConvert.DeserializeObject(responseContent);

                if (response.IsSuccessStatusCode)
                {
                    txtUsername.Text = data.user.name.ToString();
                    txtEmail.Text = data.user.email.ToString();
                    int gioiTinh = Convert.ToInt32(data.user.gender);

                    if (gioiTinh == 1)
                    {
                        rdNam.Checked = true;
                        rdNu.Checked = false;
                        rdKhac.Checked = false;
                    }
                    if (gioiTinh == 2)
                    {
                        rdNu.Checked = true;
                        rdNam.Checked = false;
                        rdKhac.Checked = false;
                    }
                    if (gioiTinh == 3)
                    {
                        rdKhac.Checked = true;
                        rdNam.Checked = false;
                        rdNu.Checked = false;
                    }
                }
                else
                {
                    RJMessageBox.Show("Không tìm thấy người dùng!", "Lỗi rồi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                RJMessageBox.Show(ex.Message);
            }
        }

        private void btnChangePass_Click_1(object sender, EventArgs e)
        {
            RJMessageBox.Show("Hiện form thay đổi mật khẩu");
        }
    }
}
