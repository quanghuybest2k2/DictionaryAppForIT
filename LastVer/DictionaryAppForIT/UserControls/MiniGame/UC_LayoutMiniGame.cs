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
    public partial class UC_LayoutMiniGame : UserControl
    {
        List<Control> _list;
        UC_StartMiniGame ucStartMiniGame = new UC_StartMiniGame();
        UC_MiniGame ucMiniGame = new UC_MiniGame();
        UC_DanhSachMiniGame ucDanhSachMiniGame = new UC_DanhSachMiniGame();
        public UC_LayoutMiniGame()
        {
            InitializeComponent();
            _list = new List<Control>() { ucMiniGame, ucStartMiniGame, ucDanhSachMiniGame };
            foreach (var item in _list)
            {
                AddUCToPanel(item);
            }
        }

        private void AddUCToPanel(Control c)
        {
            pnContent.Controls.Add(c);
            c.Dock = DockStyle.Fill;
            c.BringToFront();
        }

    }
}
