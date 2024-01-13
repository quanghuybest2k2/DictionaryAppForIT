namespace DictionaryAppForIT.DTO.Account
{
    public class LoginResponse : BaseResponse
    {
        public string userId { get; set; }
        public string Username { get; set; }
        public string Token { get; set; }
        public string Role { get; set; }
    }
}
