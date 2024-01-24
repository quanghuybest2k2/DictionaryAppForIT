using DictionaryAppForIT.Class;
using System.Net.Http;
using System.Net.Http.Headers;

namespace DictionaryAppForIT.DTO
{
    public class Class_TaiKhoan
    {
        public static string displayUsername = Properties.Settings.Default.displayUsername;
        public static string IdTaiKhoan = Properties.Settings.Default.IdTaiKhoan;
        public static string ngayTaoTK = Properties.Settings.Default.ngayTaoTK;
        public static string Token = Properties.Settings.Default.Token;
        public static string Role = Properties.Settings.Default.Role;

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
