namespace DictionaryAppForIT.DTO.Love
{
    public class LoveResponse : BaseResponse
    {
        public string english { get; set; }
        public string pronunciations { get; set; }
        public string vietnamese { get; set; }
        public string Note { get; set; }
        public int? user_id { get; set; }
    }
}
