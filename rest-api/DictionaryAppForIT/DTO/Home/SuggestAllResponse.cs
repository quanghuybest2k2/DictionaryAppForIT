namespace DictionaryAppForIT.DTO.Home
{
    public class SuggestAllResponse : BaseResponse
    {
        public string word_name { get; set; }
        public string pronunciations { get; set; }
        public int specialization_id { get; set; }
        public string synonymous { get; set; }
        public string antonyms { get; set; }
    }
}
