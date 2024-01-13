using System.Drawing;
using System.Windows.Forms;

namespace DictionaryAppForIT.UserControls.TuVungHot
{
    public partial class UC_TVH_Item : UserControl
    {
        public UC_TVH_Item()
        {
            InitializeComponent();
        }

        public UC_TVH_Item(string stt, string tiengAnh, string phienAm, string tiengViet, string soLuotXem)
        {
            InitializeComponent();
            this.lblSo.Text = "No." + stt;
            this.lblTiengAnh.Text = tiengAnh;
            this.lblPhienAm.Text = phienAm;
            this.lblTiengViet.Text = tiengViet;
            this.btnLuotXem.Text = soLuotXem;
        }

        public void TVHBackColor(string color)
        {
            lblSo.BackColor = Color.FromName(color);
            lblTiengAnh.BackColor = Color.FromName(color);
            lblPhienAm.BackColor = Color.FromName(color);
            lblTiengViet.BackColor = Color.FromName(color);
            pnNen.FillColor = Color.FromName(color);
        }
    }
}
