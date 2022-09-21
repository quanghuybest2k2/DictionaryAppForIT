using DictionaryAppForIT.Class;
using DictionaryAppForIT.DAL;
using DictionaryAppForIT.DTO;
using SpeechLib; // speak
using System;
using System.Collections;
using System.Collections.Generic;
using System.Media;
using System.Net.Http;
using System.Speech.Recognition;
using System.Speech.Synthesis;
using System.Web.Script.Serialization;
using System.Windows.Forms;

namespace DictionaryAppForIT.UserControls.Home
{
    public partial class UC_Dich : UserControl
    {
        SpeechSynthesizer speech;
        SoundPlayer soundPlayer;
        public bool thayDoiTocDo = false;
        public int tocDo = 0;
        public UC_Dich()
        {
            InitializeComponent();
            speech = new SpeechSynthesizer();
            LoadLichSu();
        }
        private string TranslateText(string input)
        {
            string url = "";
            if (lblLeft.Text == "Vietnamese" && lblRight.Text == "English") // dich tieng anh
            {
                url = String.Format("https://translate.googleapis.com/translate_a/single?client=gtx&sl={0}&tl={1}&dt=t&q={2}",
             "vi", "en", Uri.EscapeUriString(input));
            }
            if (lblLeft.Text == "English" && lblRight.Text == "Vietnamese") // dich tieng viet
            {
                url = String.Format("https://translate.googleapis.com/translate_a/single?client=gtx&sl={0}&tl={1}&dt=t&q={2}",
             "en", "vi", Uri.EscapeUriString(input));

            }
            HttpClient httpClient = new HttpClient();
            string result = httpClient.GetStringAsync(url).Result;
            var jsonData = new JavaScriptSerializer().Deserialize<List<dynamic>>(result);
            var translationItems = jsonData[0];
            string translation = "";
            foreach (object item in translationItems)
            {
                IEnumerable translationLineObject = item as IEnumerable;
                IEnumerator translationLineString = translationLineObject.GetEnumerator();
                translationLineString.MoveNext();
                translation += string.Format(" {0}", Convert.ToString(translationLineString.Current));
            }
            if (translation.Length > 1) { translation = translation.Substring(1); };
            return translation;
        }
        private void TocDoNoi()
        {
            if (thayDoiTocDo)
            {
                speech.Rate = tocDo;
            }
        }
        private void btnSpeakEnglish_Click(object sender, EventArgs e)
        {
            if (txtTop.Text != null)
            {
                speech.SelectVoice("Microsoft David Desktop"); //giong mỹ
                TocDoNoi();
                speech.SpeakAsync(txtTop.Text);
            }
        }

        private void btnChangeLang_Click(object sender, EventArgs e)
        {
            string swap = lblLeft.Text; // hoán dổi label bên cạnh button
            lblLeft.Text = lblRight.Text;
            lblRight.Text = swap;

            string swaplblTxt = lblENtxt.Text; // hoán dổi label trên textbox
            lblENtxt.Text = lblVNtxt.Text;
            lblVNtxt.Text = swaplblTxt;

            string swapTxt = txtTop.Text; // hoán dổi textbox
            txtTop.Text = txtUnder.Text;
            txtUnder.Text = swapTxt;
        }

        private void txtTop_TextChanged(object sender, EventArgs e)
        {
            if (txtTop.Text != "")
            {
                txtUnder.Text = TranslateText(txtTop.Text);
            }
        }
        #region Xử lý lịch sử
        private void LoadLichSu()
        {
            try
            {
                dtgvLichSu.DataSource = DataProvider.Instance.ExecuteQuery("select * from LichSuDich");
            }
            catch (Exception ex)
            {
                RJMessageBox.Show(ex.Message);
            }
        }
        private void LuuLichSuTu()
        {
            try
            {
                int num = DataProvider.Instance.ExecuteNonQuery($"insert into LichSuDich values(N'{txtTop.Text}', N'{txtUnder.Text}',  GETDATE())");
                if (num > 0)
                {
                    LoadLichSu();
                }
                else
                {
                    RJMessageBox.Show("Không thể đưa vào lịch sử dịch!");
                }
            }
            catch (Exception)
            {
                // khóa chính không thể trùng
                RJMessageBox.Show("Bản dịch này đã tồn tại.");
            }
        }
        private void dtgvLichSu_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dtgvLichSu.SelectedRows.Count > 0)
            {
                DataGridViewRow row = dtgvLichSu.Rows[e.RowIndex];
                txtTop.Text = row.Cells[0].Value.ToString();
                txtUnder.Text = row.Cells[1].Value.ToString();
            }
        }
        private void tsmiXoa_Click(object sender, EventArgs e)
        {
            string ChuMuonXoa = dtgvLichSu.SelectedCells[0].Value.ToString();
            int num = DataProvider.Instance.ExecuteNonQuery($"delete from LichSuDich where TiengAnh = N'{ChuMuonXoa}'");
            if (num > 0)
            {
                RJMessageBox.Show("Xóa thành công.", "Thông báo");
                LoadLichSu();
            }
            else
            {
                RJMessageBox.Show("Thất bại!",
                "Thông báo lỗi",
                MessageBoxButtons.RetryCancel,
                MessageBoxIcon.Error);
            }
        }
        private void btnClear_Click(object sender, EventArgs e)
        {
            if (txtTop.Text != "")
            {
                LuuLichSuTu();// lưu lịch sử
            }
            txtTop.Clear();
            txtUnder.Clear();

        }
        private void btnXoaLichSu_Click(object sender, EventArgs e)
        {
            try
            {
                int num = DataProvider.Instance.ExecuteNonQuery("DELETE FROM LichSuDich");
                if (num > 0)
                {
                    RJMessageBox.Show("Đã xóa hết lịch sử");
                    LoadLichSu();
                }
            }
            catch (Exception ex)
            {
                RJMessageBox.Show(ex.Message);
            }
        }
        #endregion
        private void txtCopyText_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(txtUnder.Text); // copy text
            //Clipboard.GetText(); // paste text
            RJMessageBox.Show("Đã sao chép!", "Thông báo");
        }

        private void btnMic_Click(object sender, EventArgs e)
        {
            soundPlayer = new SoundPlayer(Application.StartupPath + "\\Resources\\Sound\\SiriOpen.wav");
            SpeechRecognitionEngine sr = new SpeechRecognitionEngine(new System.Globalization.CultureInfo("en-US"));
            sr.LoadGrammar(new DictationGrammar());
            try
            {
                soundPlayer.Play();
                txtTop.Text = "I am listening...";
                sr.SetInputToDefaultAudioDevice();
                RecognitionResult result = sr.Recognize();
                txtTop.Clear();
                txtTop.Text = result.Text;
            }
            catch (Exception ex)
            {
                txtTop.Text = "";
                RJMessageBox.Show(ex.Message);
            }
            finally
            {
                sr.UnloadAllGrammars();
            }
        }
    }
}
