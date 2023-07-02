using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DictionaryAppForIT.DTO
{
    public class WordBySpecialization
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
