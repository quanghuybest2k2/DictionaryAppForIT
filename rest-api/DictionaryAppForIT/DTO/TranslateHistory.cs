using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DictionaryAppForIT.DTO
{
    public class TranslateHistory
    {
        public int Id { get; set; }
        public string English { get; set; }
        public string Vietnamese { get; set; }
        public int UserId { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
