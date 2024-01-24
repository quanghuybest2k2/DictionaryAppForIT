namespace DictionaryAppForIT.DTO
{
    public class UserData
    {
        public static void SaveUserDataSetting(string username, string id, string created_at, string token, string role)
        {
            // Lưu username và password vào settings
            Properties.Settings.Default.displayUsername = username;
            Properties.Settings.Default.IdTaiKhoan = id;
            Properties.Settings.Default.ngayTaoTK = created_at;
            Properties.Settings.Default.Token = token;
            Properties.Settings.Default.Role = role;
            Properties.Settings.Default.Save();
        }
        public static void RemoveUserDataSetting()
        {
            // Xóa thông tin username và password từ settings
            Properties.Settings.Default.displayUsername = string.Empty;
            Properties.Settings.Default.IdTaiKhoan = string.Empty;
            Properties.Settings.Default.ngayTaoTK = string.Empty;
            Properties.Settings.Default.Token = string.Empty;
            Properties.Settings.Default.Role = string.Empty;
            Properties.Settings.Default.Save();

            // Reset toàn bộ settings về giá trị mặc định
            Properties.Settings.Default.Reset();
        }
    }
}
