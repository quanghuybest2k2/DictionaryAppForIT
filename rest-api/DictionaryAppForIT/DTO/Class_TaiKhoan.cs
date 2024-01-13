using DictionaryAppForIT.Class;
using System.Net.Http;
using System.Net.Http.Headers;

namespace DictionaryAppForIT.DTO
{
    public class Class_TaiKhoan
    {
        public static string displayUsername;
        public static string IdTaiKhoan;
        public static string ngayTaoTK;
        public static string Token;
        public static string Role;

        public Class_TaiKhoan()
        {
        }
        public static bool authentication(HttpClient client)
        {
            // Kiểm tra tồn tại của token
            if (!string.IsNullOrWhiteSpace(Token))
            {
                // header Authorization chứa token
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Token);
                return true;
            }
            else
            {
                RJMessageBox.Show("Vui lòng đăng nhập!");
                return false;
            }
        }
    }
}
