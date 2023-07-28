using System;

namespace DictionaryAppForIT.DTO
{
    public class TranslateHistory
    {
        public int Id { get; set; }
        public string English { get; set; }
        public string Vietnamese { get; set; }
        public int UserId { get; set; }
        public string Created_At { get; set; }
        public string Updated_At { get; set; }
    }
}
