using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DictionaryAppForIT.UserControls.MiniGame
{
    public class DanhSachCauHoi
    {
        CauHoiVaDapAn item;
        public List<CauHoiVaDapAn> _list;
        public DanhSachCauHoi()
        {
            _list = new List<CauHoiVaDapAn>();
            //LoadDSCauHoi();
        }

        public void LoadDSCauHoi()
        {
            for (int i = 1; i <= 10; i++)
            {
                item = new CauHoiVaDapAn();
                item.LoadCauHoi(i);
                _list.Add(item);
            }
        }
    }
}
