using DictionaryAppForIT.UserControls.LichSu;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DictionaryAppForIT.UserControls.GanDay
{
    public partial class UC_LichSu : UserControl
    {
        public UC_LichSu()
        {
            InitializeComponent();

            var ucVanBan = new UC_LS_VanBan("10:00 PM", "26/07/2022", "Thank you so much for your amazing videos", "Cảm ơn rất nhiều vì những video tuyệt vời của bạn");
            flpContent.Controls.Add(ucVanBan);
            ucVanBan = new UC_LS_VanBan("02:19 AM", "06/07/2022", "Where can I download the color picker?", "Tôi có thể tải bộ lấy màu sắc ở đâu?");
            flpContent.Controls.Add(ucVanBan);

            var ucTuVung = new UC_LS_TuVung("08:00 AM", "26/07/2022", "Process", "/ˈprəʊsɛs/", "Xử lý");
            flpContent.Controls.Add(ucTuVung);
            ucTuVung = new UC_LS_TuVung("03:11 PM", "08/07/2022", "Subtraction", "/səbˈtrækʃən/", "Phép trừ");
            flpContent.Controls.Add(ucTuVung);
        }

    }
}
