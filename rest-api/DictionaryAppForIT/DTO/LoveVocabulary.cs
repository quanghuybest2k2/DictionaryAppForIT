using DictionaryAppForIT.DAL;
using System.Threading.Tasks;

namespace DictionaryAppForIT.DTO
{
    public class LoveVocabulary
    {
        public LoveVocabulary()
        {

        }
        public static async Task<string> Tong_So_Muc_Yeu_Thich()
        {
            object query = await DataProvider.Instance.GetMethod<string>("total-love-item", Class_TaiKhoan.IdTaiKhoan);

            string result = query?.ToString();

            return result;
        }
        //
    }
}
