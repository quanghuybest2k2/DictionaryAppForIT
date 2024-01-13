namespace DictionaryAppForIT.DTO.Account
{
    public class LoginResponse : BaseResponse
    {
        public string user_id { get; set; }
        public string username { get; set; }
        public string token { get; set; }
        public string role { get; set; }
    }
}
