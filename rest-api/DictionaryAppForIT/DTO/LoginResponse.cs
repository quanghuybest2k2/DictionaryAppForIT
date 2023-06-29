using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DictionaryAppForIT.DTO
{
    public class LoginResponse
    {
        public int Status { get; set; }
        public string Username { get; set; }
        public string Token { get; set; }
        public string Message { get; set; }
        public string Role { get; set; }
        public string userId { get; set; }
        public string created_at { get; set; }
    }
}
