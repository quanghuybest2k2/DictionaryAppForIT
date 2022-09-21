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
    public partial class UC_StartMiniGame : UserControl
    {
        public UC_StartMiniGame()
        {
            InitializeComponent();
        }

        private void btnBatDau_Click(object sender, EventArgs e)
        {
            this.SendToBack();
        }
    }
}
