using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DictionaryAppForIT.UserControls.MiniGame
{
    public partial class UC_MG_BtnDieuHuong : UserControl
    {
        public UC_MG_BtnDieuHuong()
        {
            InitializeComponent();
        }

        public UC_MG_BtnDieuHuong(int num)
        {
            InitializeComponent();
            this.lblSo.Text = num.ToString();
        }
    }
}
