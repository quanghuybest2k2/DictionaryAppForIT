using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DictionaryAppForIT.DTO.Account
{
    public class AccountResponse
    {
        public string id { get; set; }
        public string name { get; set; }
        public string email { get; set; }
        public int gender { get; set; }
        public int role_as { get; set; }
        public string created_at { get; set; }
        public string updated_at { get; set; }
    }
}
