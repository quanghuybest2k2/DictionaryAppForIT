namespace DictionaryAppForIT.DTO.Account
{
    public class LoginResponse : BaseResponse
    {
        public string name { get; set; }
        public string email { get; set; }
        public string gender { get; set; }
        public string token { get; set; }
        public string role { get; set; }
    }
}
