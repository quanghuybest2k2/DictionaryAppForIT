using DictionaryAppForIT.API;
using DictionaryAppForIT.Class;
using DictionaryAppForIT.DTO;
using DictionaryAppForIT.DTO.History;
using DictionaryAppForIT.DTO.Home;
using DictionaryAppForIT.DTO.Love;
using DictionaryAppForIT.UserControls.Home;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Speech.Synthesis;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DictionaryAppForIT.UserControls
{
    public partial class UC_TraTu : UserControl
    {
        private readonly string apiUrl = BaseUrl.base_url;
        HttpClient client = new HttpClient();
        // toc do phat am
        public bool thayDoiTocDo = false;
        public int tocDo = 0;
        // tu dong phat am
        public bool tocDoPhatAm = false;
        string TuHienTai = ""; //-------------------------------------- Tạo thêm cái này vì nếu người ta gõ 1 từ xong rồi enter nhiều lần thì nó add lặp lại vô cái _listTu
        XemTatCaNghia XemNghia;
        UC_Nghia ucNghia;
        SpeechSynthesizer speech;
        // lich su
        public static string idLSVuaTra;
        public static string idYeuThichVuaChon;
        private List<UC_Nghia> _listNghia;

        public UC_TraTu()
        {
            InitializeComponent();
            speech = new SpeechSynthesizer();
            XemNghia = new XemTatCaNghia();
            _listNghia = new List<UC_Nghia>();
            //GoiYTimKiem();

            //Tự động chỉnh lại width của label từ vựng
            //txtTuVung.Text = "Variable (fix xong bug)";
            ChinhLaiTuLoai();
            GoiYTimKiemAsync();
        }

        private void ChinhLaiTuLoai()
        {
            var textSize = getTextSize(txtTuVung.Text);
            txtTuVung.Width = Convert.ToInt32(textSize) + 10;
        }

        private float getTextSize(string text)
        {
            Font font = new Font("Segoe UI", 18, FontStyle.Bold);
            Image fakeImage = new Bitmap(2200, 2200);
            Graphics graphics = Graphics.FromImage(fakeImage);
            SizeF size = graphics.MeasureString(text, font);
            return size.Width;
        }

        private void UC_TraTu_Load(object sender, EventArgs e)
        {
            GoiYTimKiemAsync();
            pnTitle.Visible = false;
            txtDongNghia.Visible = false;
            txtTraiNghia.Visible = false;
            pbDongNghiaError.Visible = true;
            pbTraiNghiaError.Visible = true;
            //Tự động chỉnh lại width của label tên Đăng nhập
            lblTenDangNhap.Text = Class_TaiKhoan.displayUsername; // Hello Sang Đỗ
            // Tối thiểu 7 kí tự
            // Tối đa 15 kí tự
            pnXinChao.Width = pnXinChao.MinimumSize.Width + lblTenDangNhap.Width;
            btnAnhViet.FillColor = Color.FromArgb(223, 10, 10);
        }
        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            CorrectHeight(txtTuVung);
        }

        public void CorrectHeight(TextBox txtbox)
        {
            if (txtbox.BorderStyle == BorderStyle.None)
            {
                txtbox.BorderStyle = BorderStyle.FixedSingle;
                var heightWithBorder = txtbox.ClientRectangle.Height;
                txtbox.BorderStyle = BorderStyle.None;
                txtbox.AutoSize = false;
                txtbox.Height = heightWithBorder;
            }
        }
        #region xử lý tìm kiếm
        public async void GoiYTimKiemAsync()
        {
            try
            {
                HttpResponseMessage response = await client.GetAsync(apiUrl + $"get-suggest-all");

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
                    txtTimKiemTu.AutoCompleteSource = AutoCompleteSource.CustomSource;
                    txtTimKiemTu.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                    txtTimKiemTu.AutoCompleteCustomSource = autoComplete;
                }
                else
                {
                    string message = apiResponse.Message;
                    RJMessageBox.Show(message); // Hiển thị thông báo nếu API trả về lỗi
                }
            }
            catch (Exception ex)
            {
                RJMessageBox.Show($"Lỗi: {ex.Message}");
            }
        }


        private async Task KiemTraTonTaiYeuThich()
        {
            string tuVung = txtTuVung.Text.Trim();
            bool wordExists = await CheckIfExist.CheckIfWordExistsAsync(tuVung, "word");
            if (wordExists)
            {
                btnYeuThich.Checked = true;
            }
            else
            {
                btnYeuThich.Checked = false;
            }
        }

        private async void txtTimKiemTu_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && TuHienTai != txtTimKiemTu.Text && txtTimKiemTu.Text != "")//--------------------------------------
            {
                //btnYeuThich.Checked = false;
                flpMeaning.Controls.Clear();  //-------------------------------------- Khi người ta enter mới xóa flpMeaning
                HienThiThongTin();
                TuHienTai = txtTimKiemTu.Text;//--------------------------------------

                foreach (var item in XemNghia._listTu)
                {
                    LuuLichSuTraTu(item);
                }
                await KiemTraTonTaiYeuThich(); // kiểm tra xem từ yêu thích đã có chưa

                if (tocDoPhatAm == true)
                {
                    btnUS.PerformClick(); // tự động phát âm sau khi tra từ
                }
            }
        }

        private async void LuuLichSuTraTu(Tu tu)
        {
            try
            {
                var requestData = new Dictionary<string, string>
                {
                    { "english", tu.TenTu },
                    { "pronunciations", tu.PhienAm },
                    { "vietnamese", tu.Nghia },
                    { "user_id", Class_TaiKhoan.IdTaiKhoan }
                };
                //gửi request
                var response = await client.PostAsync(apiUrl + "save-word-lookup-history", new FormUrlEncodedContent(requestData));

                var responseContent = await response.Content.ReadAsStringAsync();

                //if (responseContent != null)
                //{
                //    RJMessageBox.Show("Phản hồi từ API: " + responseContent);
                //}

                var apiResponse = JsonConvert.DeserializeObject<ApiResponse<HistoryResponse>>(responseContent);

                if (apiResponse.Status && apiResponse.Data != null)
                {
                    RJMessageBox.Show(apiResponse.Message);
                }
                else
                {
                    RJMessageBox.Show(apiResponse.Message);
                }
            }
            catch (Exception ex)
            {
                RJMessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        private async void HienThiThongTin()
        {
            if (await XemNghia.HienThiThongTinTimKiem(txtTimKiemTu.Text))
            {
                _listNghia = new List<UC_Nghia>();
                pnTitle.Visible = true;
                foreach (var item in XemNghia._listTu)
                {
                    txtTuVung.Text = item.TenTu;
                    ChinhLaiTuLoai();
                    txtPhienAm.Text = item.PhienAm;
                    txtDongNghia.Text = item.DongNghia;
                    if (txtDongNghia.Text != "")
                    {
                        pbDongNghiaError.Visible = false;
                        txtDongNghia.Visible = true;
                    }
                    else
                    {
                        pbDongNghiaError.Visible = true;
                        txtDongNghia.Visible = false;
                    }
                    txtTraiNghia.Text = item.TraiNghia;
                    if (txtTraiNghia.Text != "")
                    {
                        pbTraiNghiaError.Visible = false;
                        txtTraiNghia.Visible = true;
                    }
                    else
                    {
                        pbTraiNghiaError.Visible = true;
                        txtTraiNghia.Visible = false;
                    }
                    ucNghia = new UC_Nghia();

                    ucNghia.LoaiTu = item.TenLoai;
                    ucNghia.Nghia = item.Nghia;

                    ucNghia.MoTa = item.MoTa;
                    ucNghia.ViDu = item.ViDu;

                    flpMeaning.Controls.Add(ucNghia);
                    _listNghia.Add(ucNghia);
                    ucNghia.Dock = DockStyle.Top;

                }
            }
            else
            {
                pnTitle.Visible = false;
                txtDongNghia.Visible = false;
                txtTraiNghia.Visible = false;
                pbDongNghiaError.Visible = true;
                pbTraiNghiaError.Visible = true;
            }
        }
        #endregion

        #region btn us, uk, sao chep
        private void TocDoNoi()
        {
            if (thayDoiTocDo)
            {
                speech.Rate = tocDo;
            }
        }
        private void btnUS_Click(object sender, EventArgs e)
        {
            speech.SelectVoice("Microsoft David Desktop"); //giong mỹ
            TocDoNoi();
            speech.SpeakAsync(txtTuVung.Text);
        }
        private void btnUK_Click(object sender, EventArgs e)
        {
            if (speech.GetInstalledVoices().Any(v => v.VoiceInfo.Name == "Microsoft Hazel Desktop"))
            {
                speech.SelectVoice("Microsoft Hazel Desktop"); // Chọn giọng Anh Anh
                TocDoNoi();
                speech.SpeakAsync(txtTuVung.Text);
            }
            else
            {
                RJMessageBox.Show("Thiết bị của bạn không có giọng Anh Anh!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnSaoChep_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(txtTuVung.Text); // copy text
            //Clipboard.GetText(); // paste text
        }
        #endregion

        #region xử lý tìm ngẫu nhiên
        private async Task HienThiKqRandom()
        {
            await XemNghia.HienThiThongTinRandom();

            foreach (var item in XemNghia._listTu)
            {
                txtTuVung.Text = item.TenTu;
                ChinhLaiTuLoai();
                txtPhienAm.Text = item.PhienAm;
                txtDongNghia.Text = item.DongNghia;
                if (txtDongNghia.Text != "")
                {
                    pbDongNghiaError.Visible = false;
                    txtDongNghia.Visible = true;
                }
                else
                {
                    pbDongNghiaError.Visible = true;
                    txtDongNghia.Visible = false;
                }
                txtTraiNghia.Text = item.TraiNghia;
                if (txtTraiNghia.Text != "")
                {
                    pbTraiNghiaError.Visible = false;
                    txtTraiNghia.Visible = true;
                }
                else
                {
                    pbTraiNghiaError.Visible = true;
                    txtTraiNghia.Visible = false;
                }
                ucNghia = new UC_Nghia();

                ucNghia.LoaiTu = item.TenLoai;
                ucNghia.Nghia = item.Nghia;
                ucNghia.MoTa = item.MoTa;
                ucNghia.ViDu = item.ViDu;

                flpMeaning.Controls.Add(ucNghia);
                ucNghia.Dock = DockStyle.Top;
                await KiemTraTonTaiYeuThich();
            }
        }
        private async void btnTuNgauNhien_Click(object sender, EventArgs e)
        {
            try
            {
                pnTitle.Visible = true;
                flpMeaning.Controls.Clear();  //-------------------------------------- Khi người ta enter mới xóa flpMeaning
                await HienThiKqRandom();
                foreach (var item in XemNghia._listTu)
                {
                    LuuLichSuTraTu(item);
                }
                if (tocDoPhatAm == true)
                {
                    btnUS.PerformClick(); // tự động phát âm sau khi tra từ
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        #endregion

        #region Xử lý yêu thích
        private async void btnYeuThich_Click(object sender, EventArgs e)
        {
            foreach (var item in XemNghia._listTu)
            {
                if (btnYeuThich.Checked)
                {
                    LuuTuYeuThich(item);
                }
                else
                {
                    try
                    {
                        HttpResponseMessage response = await client.DeleteAsync(apiUrl + $"delete-love-vocabulary/{txtTuVung.Text}/{Class_TaiKhoan.IdTaiKhoan}");

                        string responseContent = await response.Content.ReadAsStringAsync();

                        var apiResponse = JsonConvert.DeserializeObject<ApiResponse<object>>(responseContent);

                        if (apiResponse.Status && apiResponse.Data != null)
                        {
                            RJMessageBox.Show(apiResponse.Message);
                        }
                        else
                        {
                            RJMessageBox.Show(apiResponse.Message);
                        }
                    }
                    catch (Exception ex)
                    {
                        RJMessageBox.Show("Lỗi >> " + ex.Message);
                    }
                }
            }
        }

        private async void LuuTuYeuThich(Tu tu)
        {
            try
            {
                //@TiengAnh, @PhienAm, @TiengViet, @GhiChu,@IDTK
                var requestData = new Dictionary<string, string>
                {
                    { "english", tu.TenTu },
                    { "pronunciations", tu.PhienAm },
                    { "vietnamese", tu.Nghia },
                    // "note" => có thể null nên khỏi điền
                    { "user_id", Class_TaiKhoan.IdTaiKhoan }
                };
                //gửi request
                var response = await client.PostAsync(apiUrl + "save-love-vocabulary", new FormUrlEncodedContent(requestData));

                var responseContent = await response.Content.ReadAsStringAsync();

                var apiResponse = JsonConvert.DeserializeObject<ApiResponse<LoveResponse>>(responseContent);

                if (apiResponse.Status && apiResponse.Data != null)
                {
                    RJMessageBox.Show(apiResponse.Message);
                }
                else
                {
                    RJMessageBox.Show(apiResponse.Message);
                }
            }
            catch (Exception ex)
            {
                RJMessageBox.Show("Lỗi: " + ex.Message);
            }
        }
        #endregion


        #region Xử lý giao diện sáng tối

        public void ThayDoiMauGiaoDien(bool check)
        {
            if (check)
            {
                GiaoDienToi();
                ThayDoiMauUC(32, 33, 36);
            }
            else
            {
                GiaoDienSang();
                ThayDoiMauUC(255, 255, 255);
            }
        }

        public void ThayDoiMauUC(int mot, int hai, int ba)
        {
            foreach (var item in _listNghia)
            {
                item.DoiMauNen(mot, hai, ba);
            }
        }

        private void GiaoDienSang()
        {
            //Whitesmoke: 245,245,245 
            //Black: 32, 33, 36
            //White: 255,255,255
            int mot = 245;
            int hai = 255;
            pnNen4.FillColor = Color.FromArgb(mot, mot, mot);
            pnNen6.FillColor = Color.FromArgb(mot, mot, mot);
            pnNen1.FillColor = Color.FromArgb(hai, hai, hai);
            pnNen2.BackColor = Color.FromArgb(hai, hai, hai);
            pnNen3.BackColor = Color.FromArgb(hai, hai, hai);
            pnNen5.BackColor = Color.FromArgb(hai, hai, hai);
            pnNen7.BackColor = Color.FromArgb(hai, hai, hai);
            txtTuVung.BackColor = Color.FromArgb(hai, hai, hai);
            txtPhienAm.BackColor = Color.FromArgb(hai, hai, hai);
            txtDongNghia.BackColor = Color.FromArgb(mot, mot, mot);
            txtTraiNghia.BackColor = Color.FromArgb(mot, mot, mot);
        }

        private void GiaoDienToi()
        {
            //Whitesmoke: 245,245,245 
            //Black: 32, 33, 36
            //White: 255,255,255
            int mot = 32;
            int hai = 33;
            int ba = 36;
            pnNen4.FillColor = Color.FromArgb(mot, hai, ba);
            pnNen6.FillColor = Color.FromArgb(mot, hai, ba);
            pnNen1.FillColor = Color.FromArgb(mot, hai, ba);
            pnNen2.BackColor = Color.FromArgb(mot, hai, ba);
            pnNen3.BackColor = Color.FromArgb(mot, hai, ba);
            pnNen5.BackColor = Color.FromArgb(mot, hai, ba);
            pnNen7.BackColor = Color.FromArgb(mot, hai, ba);
            txtTuVung.BackColor = Color.FromArgb(mot, hai, ba);
            txtPhienAm.BackColor = Color.FromArgb(mot, hai, ba);
            txtDongNghia.BackColor = Color.FromArgb(mot, hai, ba);
            txtTraiNghia.BackColor = Color.FromArgb(mot, hai, ba);
        }



        #endregion

        #region đang phát triển
        private void btnTuTruoc_Click(object sender, EventArgs e)
        {
            RJMessageBox.Show("Chức năng đang phát triển!",
                "Xin lỗi",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }

        private void btnTuSau_Click(object sender, EventArgs e)
        {
            RJMessageBox.Show("Chức năng đang phát triển!",
                "Xin lỗi",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }
        private void btnVietAnh_Click(object sender, EventArgs e)
        {
            RJMessageBox.Show("Chức năng đang phát triển!");
        }
        #endregion
    }
}
