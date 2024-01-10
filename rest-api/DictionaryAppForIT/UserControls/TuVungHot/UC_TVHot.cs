using DictionaryAppForIT.API;
using DictionaryAppForIT.Class;
using DictionaryAppForIT.DTO;
using Newtonsoft.Json;
using System;
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
        private readonly HttpClient client = new HttpClient();

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
            try
            {
                HttpResponseMessage response = await client.GetAsync(apiUrl + "get-hot-vocabulary");


                string responseContent = await response.Content.ReadAsStringAsync();

                var apiResponse = JsonConvert.DeserializeObject<ApiResponse<HotVocabularyResponse[]>>(responseContent);

                if (apiResponse.Status && apiResponse.Data != null)
                {
                    foreach (var item in apiResponse.Data)
                    {
                        string english = item.english;
                        string pronunciation = item.pronunciations;
                        string vietnamese = item.vietnamese;
                        string numberOfOccurrences = item.NumberOfOccurrences;

                        UC_TVH_Item uc = new UC_TVH_Item(stt.ToString(), english, pronunciation, vietnamese, numberOfOccurrences);
                        uc.TVHBackColor(rd.GetColor());
                        flpContent.Controls.Add(uc);
                        stt++;
                    }
                }
                else
                {
                    RJMessageBox.Show(apiResponse.Message);
                }
            }
            catch (Exception ex)
            {
                RJMessageBox.Show(ex.Message);
            }
        }
        //
    }
}
