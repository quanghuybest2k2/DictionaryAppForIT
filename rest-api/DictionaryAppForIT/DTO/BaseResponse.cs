namespace DictionaryAppForIT.DTO
{
    public abstract class BaseResponse
    {
        public string id { get; set; }
        public string created_at { get; set; }
        public string updated_at { get; set; }
    }
}
