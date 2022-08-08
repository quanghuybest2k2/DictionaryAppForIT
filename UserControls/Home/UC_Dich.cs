using SpeechLib; // speak
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Media;
using System.Net.Http;
using System.Speech.Recognition;
using System.Speech.Synthesis;
using System.Text;
using System.Web.Script.Serialization;
using System.Windows.Forms;
using System.Xml;


namespace DictionaryAppForIT.UserControls.Home
{
    public partial class UC_Dich : UserControl
    {
        SpeechSynthesizer speech;
        SoundPlayer soundPlayer;
        public UC_Dich()
        {
            InitializeComponent();
            speech = new SpeechSynthesizer();


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
        private void btnSpeakEnglish_Click(object sender, EventArgs e)
        {
            if (txtTop.Text != null)
            {
                SpVoice obj = new SpVoice();
                obj.Speak(txtTop.Text, SpeechVoiceSpeakFlags.SVSFDefault);
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
            LuuLichSu(); // lưu lịch sử
        }

        private void txtCopyText_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(txtUnder.Text); // copy text
            //Clipboard.GetText(); // paste text
            MessageBox.Show("Đã sao chép!");
        }

        private void btnMic_Click(object sender, EventArgs e)
        {
            soundPlayer = new SoundPlayer(@"D:\Window Form\DictionaryAppForIT\Resources\Sound\SiriOpen.wav");
            SpeechRecognitionEngine sr = new SpeechRecognitionEngine(new System.Globalization.CultureInfo("en-US"));
            sr.LoadGrammar(new DictationGrammar());
            try
            {
                soundPlayer.Play();
                txtTop.Text = "I'm listening...";
                sr.SetInputToDefaultAudioDevice();
                RecognitionResult result = sr.Recognize();
                txtTop.Clear();
                txtTop.Text = result.Text;
            }
            catch (Exception ex)
            {
                txtTop.Text = "";
                MessageBox.Show(ex.Message);
            }
            finally
            {
                sr.UnloadAllGrammars();
            }

        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtTop.Clear();
        }
        private void LuuLichSu()
        {
            string filePath = Path.Combine(@"D:\Window Form\DictionaryAppForIT\DTO\LichSu.xml");
            XmlDocument doc = new XmlDocument();
            doc.Load(filePath);
            XmlNode nodeTiengAnh = doc.SelectSingleNode("/LichSu/Tu/TiengAnh");
            XmlNode nodeTiengViet = doc.SelectSingleNode("/LichSu/Tu/TiengViet");

            nodeTiengAnh.InnerText = txtTop.Text;
            nodeTiengViet.InnerText = txtUnder.Text;

            doc.Save(filePath);
        }
        private void btnLichSu_Click(object sender, EventArgs e)
        {

            ReadXml();
        }

        private void ReadXml()
        {
            string filePath = Path.Combine(@"D:\Window Form\DictionaryAppForIT\DTO\LichSu.xml");
            XmlDocument doc = new XmlDocument();
            doc.Load(filePath);
            XmlNode nodeTiengAnh = doc.SelectSingleNode("/LichSu/Tu/TiengAnh");
            XmlNode nodeTiengViet = doc.SelectSingleNode("/LichSu/Tu/TiengViet");
            //TextBox txtTiengAnh = new TextBox();
            //txtTiengAnh.Name = "txtTiengAnh";
           // TextBox txtTiengViet = new TextBox();
           // txtTiengViet.Name = "txtTiengViet";

           // txtTiengAnh.Text = nodeTiengAnh.InnerText;
            //txtTiengViet.Text = nodeTiengViet.InnerText;

           // List<string> list = new List<string>();
            //string[] arr = { txtTiengAnh.Text, txtTiengViet.Text };
            //list.AddRange(arr);
            txtLichSu.Text = nodeTiengAnh.InnerText + Environment.NewLine + nodeTiengViet.InnerText + Environment.NewLine;
            //txtLichSu.Lines = list.ToArray();
            //richTextBox1.Lines = list.ToArray();// richTextBox.Lines có thể xuống dòng
        }
    }
}
