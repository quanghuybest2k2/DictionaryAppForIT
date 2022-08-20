using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DictionaryAppForIT.DTO
{
    public class Tu
    {
        public string TenTu { get; set; }
        public string TenLoai { get; set; }
        public string Nghia { get; set; }
        public string MoTa { get; set; }
        public string ViDu { get; set; }
        public Tu()
        {

        }

        public Tu(string tenTu, string tenLoai, string nghia, string moTa, string viDu)
        {
            TenTu = tenTu;
            TenLoai = tenLoai;
            Nghia = nghia;
            MoTa = moTa;
            ViDu = viDu;
        }
    }
}
