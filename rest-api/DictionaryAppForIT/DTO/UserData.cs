namespace DictionaryAppForIT.DTO
{
    public class UserData
    {
        public static void SaveUserDataSetting(string username, string gender, string id, string created_at, string token, string role, string email = null)
        {
            // Lưu username và password vào settings
            Properties.Settings.Default.username = username;
            Properties.Settings.Default.user_id = id;
            Properties.Settings.Default.creared_at = created_at;
            Properties.Settings.Default.token = token;
            Properties.Settings.Default.role = role;
            Properties.Settings.Default.gender = gender;
            Properties.Settings.Default.email = email;
            Properties.Settings.Default.Save();
        }
        public static void RemoveUserDataSetting()
        {
            // Xóa thông tin username và password từ settings
            Properties.Settings.Default.username = string.Empty;
            Properties.Settings.Default.user_id = string.Empty;
            Properties.Settings.Default.creared_at = string.Empty;
            Properties.Settings.Default.token = string.Empty;
            Properties.Settings.Default.role = string.Empty;
            Properties.Settings.Default.gender = string.Empty;
            Properties.Settings.Default.email = string.Empty;
            Properties.Settings.Default.Save();

            // Reset toàn bộ settings về giá trị mặc định
            Properties.Settings.Default.Reset();
        }
    }
}
