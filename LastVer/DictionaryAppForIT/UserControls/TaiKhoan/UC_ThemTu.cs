using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DictionaryAppForIT.UserControls.TaiKhoan
{
    public partial class UC_ThemTu : UserControl
    {
        UC_TT_ThemNghia ucThemNghia;
        int stt = 0;
        List<UC_TT_ThemNghia> _list;
        public UC_ThemTu()
        {
            InitializeComponent();
            _list = new List<UC_TT_ThemNghia>();
            btnThemNghia.PerformClick();
        }

        private void btnThemNghia_Click(object sender, EventArgs e)
        {
            stt++;
            ucThemNghia = new UC_TT_ThemNghia(stt);
            ucThemNghia.Dock = DockStyle.Top;
            pnNghia.Controls.Add(ucThemNghia);
            _list.Add(ucThemNghia);
        }

        private void btnXoaNghia_Click(object sender, EventArgs e)
        {
            foreach (var item in _list)
            {
                if (item.XacNhanXoa)
                {
                    pnNghia.Controls.Remove(item);
                }
            }    
        }

        private void DieuChinhSTT()
        {
            
        }
    }
}
