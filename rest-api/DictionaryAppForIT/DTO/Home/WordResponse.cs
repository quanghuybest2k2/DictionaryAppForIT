﻿namespace DictionaryAppForIT.DTO.Home
{
    public class WordResponse : BaseResponse
    {
        public string word_name { get; set; }
        public string type_name { get; set; }
        public string pronunciations { get; set; }
        public string specialization_name { get; set; }
        public string means { get; set; }
        public string description { get; set; }
        public string example { get; set; }
        public string synonymous { get; set; }
        public string antonyms { get; set; }
    }
}