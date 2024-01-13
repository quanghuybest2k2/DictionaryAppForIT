namespace DictionaryAppForIT.DTO.Account
{
    public class AccountResponse : BaseResponse
    {
        public string name { get; set; }
        public string email { get; set; }
        public int gender { get; set; }
        public int role_as { get; set; }
    }
}
