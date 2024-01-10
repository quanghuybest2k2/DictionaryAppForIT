namespace DictionaryAppForIT.DTO
{
    public class HotVocabularyResponse : BaseResponse
    {
        public string english { get; set; }
        public string pronunciations { get; set; }
        public string vietnamese { get; set; }
        public string NumberOfOccurrences { get; set; }
    }
}
