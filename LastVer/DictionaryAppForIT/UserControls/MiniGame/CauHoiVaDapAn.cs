using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DictionaryAppForIT.UserControls.MiniGame
{
    public class CauHoiVaDapAn
    {
        public string TuVung { get; set; }
        public string DapAnDung { get; set; }
        public List<string> DapAnRandom;

        public CauHoiVaDapAn()
        {

        }

        public CauHoiVaDapAn(string tuVung, string dapAnDung)
        {
            TuVung = tuVung;
            DapAnDung = dapAnDung;
            List<string> DapAnRandom = new List<string>();
        }
    }
}
