using DictionaryAppForIT.API;
using DictionaryAppForIT.Class;
using Newtonsoft.Json;
using System.Net.Http;
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
        public async void HienThiTuVungHotAsync()
        {
            flpContent.Controls.Clear();
            int stt = 1;
            using (HttpClient httpClient = new HttpClient())
            {
                try
                {
                    HttpResponseMessage response = await httpClient.GetAsync(apiUrl + "get-hot-vocabulary");
                    response.EnsureSuccessStatusCode();

                    string json = await response.Content.ReadAsStringAsync();
                    dynamic data = JsonConvert.DeserializeObject(json);

                    if (data != null && data.hotVocabulary != null)
                    {
                        foreach (var item in data.hotVocabulary)
                        {
                            string english = item.english;
                            string pronunciation = item.pronunciations;
                            string vietnamese = item.vietnamese;
                            int numberOfOccurrences = item.NumberOfOccurrences;

                            uc = new UC_TVH_Item(stt.ToString(), english, pronunciation, vietnamese, numberOfOccurrences.ToString());
                            uc.TVHBackColor(rd.GetColor());
                            flpContent.Controls.Add(uc);
                            stt++;
                        }
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
    }
}
