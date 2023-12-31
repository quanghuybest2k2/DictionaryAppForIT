using System;
using System.Windows.Forms;

namespace DictionaryAppForIT.UserControls.MiniGame
{
    public partial class UC_MG_BtnDieuHuong : UserControl
    {

        public string Stt
        {
            get { return lblSo.Text; }
            set { lblSo.Text = value; }
        }
    }
}
