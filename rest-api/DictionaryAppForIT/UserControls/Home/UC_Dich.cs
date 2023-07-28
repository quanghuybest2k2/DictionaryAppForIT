using DictionaryAppForIT.API;
using DictionaryAppForIT.Class;
using DictionaryAppForIT.DTO;
using Guna.UI2.WinForms;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
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
        private readonly string apiUrl = BaseUrl.base_url;
        HttpClient client;

        SpeechSynthesizer speech;
        SoundPlayer soundPlayer;
        public bool thayDoiTocDo = false;
        public string idYeuThichVBVuaChon;
        public int tocDo = 0;
        private CheckIfExist checkIfExist;

        public UC_Dich()
        {
            InitializeComponent();
            speech = new SpeechSynthesizer();
            checkIfExist = new CheckIfExist();
            client = new HttpClient();
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
            if (txtTop.Text.Trim() != null)
            {
                speech.SelectVoice("Microsoft David Desktop"); //giong mỹ
                TocDoNoi();
                speech.SpeakAsync(txtTop.Text.Trim());
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

            string swapTxt = txtTop.Text.Trim(); // hoán dổi textbox
            txtTop.Text = txtUnder.Text.Trim();
            txtUnder.Text = swapTxt;
            //

        }

        private void txtTop_TextChanged(object sender, EventArgs e)
        {
            //
            if (txtTop.Text == "")
            {
                txtUnder.Text = "";
                btnLuuYeuThich.Visible = false;
                btnCopyText.Visible = false;
                //btnMic.Visible = false;
                btnClear.Visible = false;
            }
            else
            {
                btnLuuYeuThich.Visible = true;
                btnCopyText.Visible = true;
                //btnMic.Visible = true;
                btnClear.Visible = true;
            }
            if (txtTop.Text.Trim() != "")
            {
                txtUnder.Text = TranslateText(txtTop.Text.Trim());
            }
            KiemTraTonTaiYeuThich();
        }
        #region Xử lý lịch sử
        private async void LoadLichSu()
        {
            try
            {
                // ghi đè table
                DataTable dataTable = new DataTable();
                //dataTable.Columns.Add("Id", typeof(string)).ColumnMapping = MappingType.Hidden;
                dataTable.Columns.Add("Id", typeof(string));
                dataTable.Columns.Add("English", typeof(string));
                dataTable.Columns.Add("Vietnamese", typeof(string));

                var translateHistoryList = TranslateHistoryService.LoadLichSu();

                if (translateHistoryList != null)
                {
                    // thêm data vào table
                    foreach (var history in await translateHistoryList)
                    {
                        dataTable.Rows.Add(history.Id, history.English, history.Vietnamese);
                    }

                    dtgvLichSu.DataSource = dataTable;
                    // ẩn thân chi thuật :))
                    dtgvLichSu.Columns["Id"].Visible = false;
                }
                else
                {
                    dtgvLichSu.DataSource = null;
                }
            }
            catch (Exception ex)
            {
                RJMessageBox.Show(ex.Message);
            }
        }
        private async void LuuLichDich()
        {
            try
            {
                var requestData = new Dictionary<string, string>
                {
                    { "english", txtTop.Text.Trim() },
                    { "vietnamese", txtUnder.Text.Trim() },
                    { "user_id", Class_TaiKhoan.IdTaiKhoan }
                    // created_at tự sinh
                };

                //gửi request
                var response = await client.PostAsync(apiUrl + "save-translate-history", new FormUrlEncodedContent(requestData));

                if (response.IsSuccessStatusCode)
                {
                    var responseContent = await response.Content.ReadAsStringAsync();
                    LoadLichSu();
                }
                else
                {
                    RJMessageBox.Show("Không thể thêm vào lịch sử dịch!", "Lỗi rồi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception)
            {
                RJMessageBox.Show("Đã có lỗi xảy ra!", "Lỗi rồi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void dtgvLichSu_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dtgvLichSu.SelectedRows.Count > 0)
            {
                DataGridViewRow row = dtgvLichSu.Rows[e.RowIndex];
                txtTop.Text = row.Cells["English"].Value.ToString();
                txtUnder.Text = row.Cells["Vietnamese"].Value.ToString();
            }
        }
        private async void tsmiXoa_Click(object sender, EventArgs e)
        {
            try
            {
                int rowIndex = dtgvLichSu.CurrentRow.Index;
                string idValue = dtgvLichSu.Rows[rowIndex].Cells["Id"].Value.ToString();
                //RJMessageBox.Show(idValue);

                HttpResponseMessage response = await client.DeleteAsync(apiUrl + $"delete-translate-by-id/{Class_TaiKhoan.IdTaiKhoan}/{idValue}");

                string responseContent = await response.Content.ReadAsStringAsync();
                JObject responseObject = JObject.Parse(responseContent);
                string message = responseObject["message"].ToString();

                if (response.IsSuccessStatusCode)
                {
                    txtTop.Clear();
                    txtUnder.Clear();
                    LoadLichSu();
                    RJMessageBox.Show(message, "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    RJMessageBox.Show(message, "Lỗi rồi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                RJMessageBox.Show(ex.Message);
            }
        }
        private async void KiemTraTonTaiYeuThich()
        {
            string banDich = txtTop.Text.Trim();
            bool translateExists = await checkIfExist.CheckIfWordExistsAsync(banDich, "loveText");
            if (translateExists)
            {
                btnLuuYeuThich.Checked = true;
            }
            else
            {
                btnLuuYeuThich.Checked = false;
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {

            if (txtTop.Text.Trim() != "")
            {
                LuuLichDich();// lưu lịch sử
            }
            txtTop.Clear();
            txtUnder.Clear();

        }
        private async void btnXoaLichSu_ClickAsync(object sender, EventArgs e)
        {
            try
            {
                HttpResponseMessage response = await client.DeleteAsync(apiUrl + $"delete-translate-history/{Class_TaiKhoan.IdTaiKhoan}");

                string responseContent = await response.Content.ReadAsStringAsync();
                JObject responseObject = JObject.Parse(responseContent);
                string message = responseObject["message"].ToString();

                if (response.IsSuccessStatusCode)
                {
                    txtTop.Clear();
                    txtUnder.Clear();
                    LoadLichSu();
                    RJMessageBox.Show(message, "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    RJMessageBox.Show(message, "Lỗi rồi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                RJMessageBox.Show("Lỗi >> " + ex.Message);
            }
        }
        #endregion
        private void txtCopyText_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(txtUnder.Text.Trim()); // copy text
                                                     //Clipboard.GetText(); // paste text
                                                     //RJMessageBox.Show("Đã sao chép!", "Thông báo");
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

        private void UC_Dich_Load(object sender, EventArgs e)
        {
            LoadLichSu();
        }

        private void btnLuuYeuThich_Click(object sender, EventArgs e)
        {
            LuuVanBanYeuThich();
        }
        private async void LuuVanBanYeuThich()
        {
            if (btnLuuYeuThich.Checked)
            {
                var requestData = new Dictionary<string, string>
                {
                    { "english", txtTop.Text.Trim() },
                    { "vietnamese", txtUnder.Text.Trim()},
                    // "note" => có thể null nên khỏi điền
                    { "user_id", Class_TaiKhoan.IdTaiKhoan }
                };
                //gửi request
                var response = await client.PostAsync(apiUrl + "save-love_text", new FormUrlEncodedContent(requestData));

                // Đảm bảo luôn luôn thành công nhé :))
                response.EnsureSuccessStatusCode();

                var responseContent = await response.Content.ReadAsStringAsync();

                //if (responseContent != null)
                //{
                //    RJMessageBox.Show("Phản hồi từ API: " + responseContent);
                //}
            }
            else
            {
                try
                {
                    HttpResponseMessage response = await client.DeleteAsync(apiUrl + $"delete-love_text?english={txtTop.Text.Trim()}&user_id={Class_TaiKhoan.IdTaiKhoan}");
                    if (response.IsSuccessStatusCode)
                    {
                        RJMessageBox.Show("Xóa thành công.");
                        LoadLichSu();
                    }
                    else
                    {
                        RJMessageBox.Show("Thất bại!");
                    }
                }
                catch (Exception ex)
                {
                    RJMessageBox.Show("Lỗi >> " + ex.Message);
                }
            }
        }
    }
}
