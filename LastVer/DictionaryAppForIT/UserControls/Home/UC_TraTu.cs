using DictionaryAppForIT.UserControls.Home;
using DictionaryAppForIT.UserControls.CaiDat;
using DictionaryAppForIT.Class;
using DictionaryAppForIT.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Speech.Synthesis;
using System.Data.SqlClient;
using DictionaryAppForIT.DAL;
using System.Configuration;
using System.Speech.AudioFormat;
using DictionaryAppForIT.Forms;

namespace DictionaryAppForIT.UserControls
{
    public partial class UC_TraTu : UserControl
    {
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
        //string[] mangNghia;

        public UC_TraTu()
        {
            InitializeComponent();
            speech = new SpeechSynthesizer();
            GoiYTimKiem();
            XemNghia = new XemTatCaNghia();

            //Tự động chỉnh lại width của label từ vựng
            //txtTuVung.Text = "Variable (fix xong bug)";
            ChinhLaiTuLoai();
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
            //Tự động chỉnh lại width của label tên Đăng nhập
            lblTenDangNhap.Text = Class_TaiKhoan.displayUsername; // Hello Sang Đỗ
            // Tối thiểu 7 kí tự
            // Tối đa 15 kí tự
            pnXinChao.Width = pnXinChao.MinimumSize.Width + lblTenDangNhap.Width;
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
        private void GoiYTimKiem()
        {
            try
            {
                SqlConnection Conn = new SqlConnection(connString);
                Conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = $"select TenTu from Tu";
                cmd.Connection = Conn;
                SqlDataReader rdr = cmd.ExecuteReader();
                AutoCompleteStringCollection autoComplete = new AutoCompleteStringCollection();
                while (rdr.Read())
                {
                    autoComplete.Add(rdr.GetString(0));
                }
                txtTimKiemTu.AutoCompleteSource = AutoCompleteSource.CustomSource;
                txtTimKiemTu.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                txtTimKiemTu.AutoCompleteCustomSource = autoComplete;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void txtTimKiemTu_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && TuHienTai != txtTimKiemTu.Text)//--------------------------------------
            {
                flpMeaning.Controls.Clear();  //-------------------------------------- Khi người ta enter mới xóa flpMeaning
                HienThiThongTin();
                TuHienTai = txtTimKiemTu.Text;//--------------------------------------

                foreach (var item in XemNghia._listTu)
                {
                    LuuLichSuTraTu(item);
                }

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

        private void HienThiThongTin()
        {
            XemNghia.HienThiThongTinTimKiem(txtTimKiemTu.Text);
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
            }
            //MessageBox.Show(XemNghia._listTu[0].TenTu);
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

            }
            //MessageBox.Show(XemNghia._listTu[0].TenTu);
        }
        private void btnTuNgauNhien_Click(object sender, EventArgs e)
        {
            try
            {
                flpMeaning.Controls.Clear();  //-------------------------------------- Khi người ta enter mới xóa flpMeaning
                HienThiKqRandom();
                TuHienTai = txtTimKiemTu.Text;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        #endregion
        private void txtTimKiemTu_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
