using DictionaryAppForIT.API;
using DictionaryAppForIT.Class;
using DictionaryAppForIT.DAL;
using DictionaryAppForIT.DTO;
using DictionaryAppForIT.UserControls.Home;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
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
        private string connString = ConfigurationManager.ConnectionStrings["DictionaryApp"].ConnectionString;
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
                string json = await response.Content.ReadAsStringAsync();

                // Phân tích cú pháp JSON để lấy danh sách từ gợi ý
                JObject data = JObject.Parse(json);
                JArray suggestNames = (JArray)data["suggest_all"];

                // Tạo một AutoCompleteStringCollection và thêm các từ gợi ý vào đó
                AutoCompleteStringCollection autoComplete = new AutoCompleteStringCollection();
                foreach (string suggestName in suggestNames)
                {
                    autoComplete.Add(suggestName);
                }

                // Cài đặt thuộc tính AutoComplete của TextBox
                txtTimKiemTu.AutoCompleteSource = AutoCompleteSource.CustomSource;
                txtTimKiemTu.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                txtTimKiemTu.AutoCompleteCustomSource = autoComplete;

            }
            catch (Exception ex)
            {
                RJMessageBox.Show(ex.Message);
            }
        }
        private void KiemTraTonTaiYeuThich()
        {
            object num = DataProvider.Instance.ExecuteScalar($"select COUNT(ID) from YeuThichTuVung where TiengAnh = '{txtTuVung.Text}' and IDTK = '{Class_TaiKhoan.IdTaiKhoan}'");
            if (Convert.ToInt32(num) > 0)
            {
                btnYeuThich.Checked = true;
            }
            else
            {
                btnYeuThich.Checked = false;
            }
        }
        private void txtTimKiemTu_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && TuHienTai != txtTimKiemTu.Text)//--------------------------------------
            {
                //btnYeuThich.Checked = false;
                flpMeaning.Controls.Clear();  //-------------------------------------- Khi người ta enter mới xóa flpMeaning
                HienThiThongTin();
                TuHienTai = txtTimKiemTu.Text;//--------------------------------------

                if (txtTimKiemTu.Text != "")
                {
                    foreach (var item in XemNghia._listTu)
                    {
                        LuuLichSuTraTu(item);
                    }
                }
                KiemTraTonTaiYeuThich(); // kiểm tra xem từ yêu thích đã có chưa

                if (tocDoPhatAm == true)
                {
                    btnUS.PerformClick(); // tự động phát âm sau khi tra từ
                }
            }
        }

        private void LuuLichSuTraTu(Tu tu)
        {
            try
            {
                // them tu vao lich su
                SqlConnection conn = new SqlConnection(connString);
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "EXEC ThemLSTraTu @IDLS output, @TiengAnh, @PhienAm, @TiengViet, @NgayHienTai, @IDTK";
                cmd.Parameters.Add("@IDLS", SqlDbType.Int);
                cmd.Parameters.Add("@TiengAnh", SqlDbType.VarChar, 400);
                cmd.Parameters.Add("@PhienAm", SqlDbType.NVarChar, 400);
                cmd.Parameters.Add("@TiengViet", SqlDbType.NVarChar, 400);
                cmd.Parameters.Add("@NgayHienTai", SqlDbType.VarChar, 30);
                cmd.Parameters.Add("@IDTK", SqlDbType.Int);
                //Lấy id vừa thêm vào bảng LichSuTraTu
                cmd.Parameters["@IDLS"].Direction = ParameterDirection.Output;
                cmd.Parameters["@TiengAnh"].Value = tu.TenTu;
                cmd.Parameters["@PhienAm"].Value = tu.PhienAm;

                cmd.Parameters["@TiengViet"].Value = tu.Nghia;
                string today = DateTime.Now.ToString("dd/MM/yyyy hh:mm tt");
                cmd.Parameters["@NgayHienTai"].Value = today;
                cmd.Parameters["@IDTK"].Value = Class_TaiKhoan.IdTaiKhoan;

                conn.Open();
                int soDongThemTu = cmd.ExecuteNonQuery();
                idLSVuaTra = cmd.Parameters["@IDLS"].Value.ToString(); // id từ vừa tra
                //if (soDongThemTu > 0)
                //{
                //    RJMessageBox.Show("Thêm từ vựng thành công.");
                //}
                //else
                //{
                //    RJMessageBox.Show("Lỗi xảy ra!");
                //}

                conn.Close();
                conn.Dispose();
            }
            catch (Exception ex)
            {
                RJMessageBox.Show(ex.Message);
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
            speech.SelectVoice("Microsoft Hazel Desktop"); // giong anh
            TocDoNoi();
            speech.SpeakAsync(txtTuVung.Text);

        }

        private void btnSaoChep_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(txtTuVung.Text); // copy text
            //Clipboard.GetText(); // paste text
        }
        #endregion

        #region xử lý tìm ngẫu nhiên
        private void HienThiKqRandom()
        {
            XemNghia.HienThiThongTinRandom();

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
                KiemTraTonTaiYeuThich();
            }
        }
        private void btnTuNgauNhien_Click(object sender, EventArgs e)
        {
            try
            {
                pnTitle.Visible = true;
                flpMeaning.Controls.Clear();  //-------------------------------------- Khi người ta enter mới xóa flpMeaning
                HienThiKqRandom();
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


        private void btnYeuThich_Click(object sender, EventArgs e)
        {
            foreach (var item in XemNghia._listTu)
            {
                if (btnYeuThich.Checked)
                {
                    LuuTuYeuThich(item);
                }
                else
                {
                    string query = $"DELETE FROM YeuThichTuVung WHERE TiengAnh = '{txtTuVung.Text}' AND IDTK = '{Class_TaiKhoan.IdTaiKhoan}'";
                    int num = DataProvider.Instance.ExecuteNonQuery(query);
                    //if (num > 0)
                    //{
                    //    RJMessageBox.Show("Xóa thành công!");
                    //}
                    //else
                    //    RJMessageBox.Show("Thất bại");
                }
            }

        }

        private void LuuTuYeuThich(Tu tu)
        {
            try
            {
                // them tu vao lich su
                SqlConnection conn = new SqlConnection(connString);
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "EXEC LuuTuYeuThich @IDYT output, @TiengAnh, @PhienAm, @TiengViet, @GhiChu, @IDTK";
                cmd.Parameters.Add("@IDYT", SqlDbType.Int);
                cmd.Parameters.Add("@TiengAnh", SqlDbType.VarChar, 400);
                cmd.Parameters.Add("@PhienAm", SqlDbType.NVarChar, 400);
                cmd.Parameters.Add("@TiengViet", SqlDbType.NVarChar, 400);
                cmd.Parameters.Add("@GhiChu", SqlDbType.NVarChar, 400);
                cmd.Parameters.Add("@IDTK", SqlDbType.Int);
                //Lấy id vừa thêm vào bảng LichSuTraTu
                cmd.Parameters["@IDYT"].Direction = ParameterDirection.Output;
                cmd.Parameters["@TiengAnh"].Value = tu.TenTu;
                cmd.Parameters["@PhienAm"].Value = tu.PhienAm;

                cmd.Parameters["@TiengViet"].Value = tu.Nghia;
                cmd.Parameters["@GhiChu"].Value = "";
                cmd.Parameters["@IDTK"].Value = Class_TaiKhoan.IdTaiKhoan;

                conn.Open();
                int soDongThemTu = cmd.ExecuteNonQuery();
                idYeuThichVuaChon = cmd.Parameters["@IDYT"].Value.ToString(); // id từ vừa tra
                //if (soDongThemTu > 0)
                //{
                //    RJMessageBox.Show("Thêm Yêu thích thành công.");
                //}
                //else
                //{
                //    RJMessageBox.Show("Lỗi xảy ra!");
                //}

                conn.Close();
                conn.Dispose();
            }
            catch (Exception ex)
            {
                RJMessageBox.Show(ex.Message);
            }
        }

        private void btnVietAnh_Click(object sender, EventArgs e)
        {
            RJMessageBox.Show("Chức năng đang phát triển!");
        }

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
    }
}
