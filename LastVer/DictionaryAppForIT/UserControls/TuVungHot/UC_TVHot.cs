using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DictionaryAppForIT.UserControls.TuVungHot
{
    public partial class UC_TVHot : UserControl
    {
        public UC_TVHot()
        {
            UC_TVH_Item uc = new UC_TVH_Item();
            InitializeComponent();
            for (int i = 1; i <= 8; i++)
            {
                AddToPanelContent(uc);
            }
        }

        private void AddToPanelContent(UC_TVH_Item uc)
        {
            uc = new UC_TVH_Item();
            flpContent.Controls.Add(uc);
        }
    }
}
