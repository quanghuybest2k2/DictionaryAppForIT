namespace DictionaryAppForIT.DTO.History
{
    public class HistoryResponse : BaseResponse
    {
        public string english { get; set; }
        public string pronunciations { get; set; }
        public string vietnamese { get; set; }
        public int user_id { get; set; }
    }
}
