namespace DictionaryAppForIT.DTO
{
    public class WordLookupHistory : BaseResponse
    {
        public string English { get; set; }
        public string Pronunciation { get; set; }
        public string Vietnamese { get; set; }
        public int User_Id { get; set; }
    }
}
