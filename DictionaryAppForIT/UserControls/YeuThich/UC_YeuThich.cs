using DictionaryAppForIT.Class;
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

namespace DictionaryAppForIT.UserControls.YeuThich
{
    public partial class UC_YeuThich : UserControl
    {
        RandomColor rd = new RandomColor();
        public UC_YeuThich()
        {
            InitializeComponent();

            var ucTuVung = new UC_YT_TuVung("No.1", "Multiplication", "/ mʌltɪplɪˈkeɪʃən/", "Phép nhân");
            ucTuVung.TVBackColor(rd.GetColor());
            flpContent.Controls.Add(ucTuVung);
            
            ucTuVung = new UC_YT_TuVung("No.2", "Operation", "/ɒpəˈreɪʃən/", "Thao tác");
            ucTuVung.TVBackColor(rd.GetColor());
            flpContent.Controls.Add(ucTuVung);

            var ucVanBan = new UC_YT_VanBan("No.3", "President Joe Biden tested positive for Covid again late Saturday", "Tổng thống Joe Biden lại có kết quả dương tính với Covid vào cuối thứ Bảy");
            ucVanBan.VBBackColor(rd.GetColor());
            flpContent.Controls.Add(ucVanBan);

            ucVanBan = new UC_YT_VanBan("No.4", "After testing negative on Tuesday evening, Wednesday morning, Thursday morning and Friday morning", "Sau khi thử nghiệm âm tính vào tối thứ Ba, sáng thứ Tư, sáng thứ Năm và sáng thứ Sáu");
            ucVanBan.VBBackColor(rd.GetColor());
            flpContent.Controls.Add(ucVanBan);

            ucVanBan = new UC_YT_VanBan("No.5", "A White House official said they are in the process of contact tracing to determine close contacts.", "Một quan chức Nhà Trắng cho biết họ đang trong quá trình truy tìm liên lạc để xác định những người thân cận.");
            ucVanBan.VBBackColor(rd.GetColor());
            flpContent.Controls.Add(ucVanBan);

            ucTuVung = new UC_YT_TuVung("No.6", "Numeric", "/nju(ː)ˈmɛrɪk/", "Số học, thuộc về số học");
            ucTuVung.TVBackColor(rd.GetColor());
            flpContent.Controls.Add(ucTuVung);

            ucTuVung = new UC_YT_TuVung("No.7", "Pulse", "/pʌls/", "Xung");
            ucTuVung.TVBackColor(rd.GetColor());
            flpContent.Controls.Add(ucTuVung);

            ucTuVung = new UC_YT_TuVung("No.8", "Subtraction", "/səbˈtrækʃən/", "Phép trừ");
            ucTuVung.TVBackColor(rd.GetColor());
            flpContent.Controls.Add(ucTuVung);

            ucVanBan = new UC_YT_VanBan("No.9", "We are thrilled to have witnessed one of the biggest jackpot wins in Mega Millions history", "Chúng tôi rất vui mừng khi được chứng kiến ​​một trong những lần trúng giải độc đắc lớn nhất trong lịch sử Mega Millions");
            ucVanBan.VBBackColor(rd.GetColor());
            flpContent.Controls.Add(ucVanBan);

        }

    }
}
