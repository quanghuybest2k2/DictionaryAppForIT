using DictionaryAppForIT.Class;
using System.Net.Http;
using System.Net.Http.Headers;

namespace DictionaryAppForIT.DTO
{
    public class Class_TaiKhoan
    {
        public static string displayUsername = Properties.Settings.Default.username;
        public static string IdTaiKhoan = Properties.Settings.Default.user_id;
        public static string ngayTaoTK = Properties.Settings.Default.creared_at;
        public static string Token = Properties.Settings.Default.token;
        public static string Role = Properties.Settings.Default.role;
        public static string Gender = Properties.Settings.Default.gender;
        public static string Email = Properties.Settings.Default.email;

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
