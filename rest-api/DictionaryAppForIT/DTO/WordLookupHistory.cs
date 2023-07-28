using System;

namespace DictionaryAppForIT.DTO
{
    public class WordLookupHistory
    {
        public int Id { get; set; }
        public string English { get; set; }
        public string Pronunciation { get; set; }
        public string Vietnamese { get; set; }
        public int User_Id { get; set; }
        public string Created_At { get; set; }
        public string Updated_At { get; set; }

        public WordLookupHistory()
        {

        }
    }
}
