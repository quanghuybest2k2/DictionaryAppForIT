namespace DictionaryAppForIT.DTO
{
    public class UserData
    {
        public static void SaveUserDataSetting(string username, string password)
        {
            // Lưu username và password vào settings
            Properties.Settings.Default.TenDangNhap = username;
            Properties.Settings.Default.MatKhau = password;
            Properties.Settings.Default.Save();
        }
        public static void RemoveUserDataSetting()
        {
            // Xóa thông tin username và password từ settings
            Properties.Settings.Default.TenDangNhap = string.Empty;
            Properties.Settings.Default.MatKhau = string.Empty;
            Properties.Settings.Default.Save();

            // Reset toàn bộ settings về giá trị mặc định
            Properties.Settings.Default.Reset();
        }
    }
}
