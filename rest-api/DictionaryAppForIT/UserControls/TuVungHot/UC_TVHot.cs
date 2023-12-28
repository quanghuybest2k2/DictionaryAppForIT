using DictionaryAppForIT.API;
using DictionaryAppForIT.Class;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DictionaryAppForIT.UserControls.TuVungHot
{
    public partial class UC_TVHot : UserControl
    {
        RandomColor rd = new RandomColor();
        UC_TVH_Item uc;
        private readonly string apiUrl = BaseUrl.base_url;

        public UC_TVHot()
        {
            uc = new UC_TVH_Item();
            InitializeComponent();
        }
        /*
            SELECT english, pronunciations, vietnamese, COUNT(user_id) AS soLanXuatHien
            FROM word_lookup_histories
            GROUP BY english, pronunciations, vietnamese
            ORDER BY COUNT(user_id) DESC
            LIMIT 8
         */
        public async Task HienThiTuVungHotAsync()
        {
            flpContent.Controls.Clear();
            int stt = 1;
            using (HttpClient httpClient = new HttpClient())
            {
                try
                {
                    HttpResponseMessage response = await httpClient.GetAsync(apiUrl + "get-hot-vocabulary");

                    string json = await response.Content.ReadAsStringAsync();
                    JObject data = JObject.Parse(json);

                    bool status = (bool)data["status"];
                    if (status)
                    {
                        JArray hotVocabulary = (JArray)data["data"];

                        foreach (var item in hotVocabulary)
                        {
                            string english = item["english"].ToString();
                            string pronunciation = item["pronunciations"].ToString();
                            string vietnamese = item["vietnamese"].ToString();
                            int numberOfOccurrences = (int)item["NumberOfOccurrences"];

                            UC_TVH_Item uc = new UC_TVH_Item(stt.ToString(), english, pronunciation, vietnamese, numberOfOccurrences.ToString());
                            uc.TVHBackColor(rd.GetColor());
                            flpContent.Controls.Add(uc);
                            stt++;
                        }
                    }
                    else
                    {
                        string message = data["message"].ToString();
                        MessageBox.Show(message);
                    }
                }
                catch (HttpRequestException ex)
                {
                    MessageBox.Show("Lỗi khi gọi API: " + ex.Message);
                }
                catch (JsonException ex)
                {
                    MessageBox.Show("JSON sai format: " + ex.Message);
                }
            }
        }
        //
    }
}
