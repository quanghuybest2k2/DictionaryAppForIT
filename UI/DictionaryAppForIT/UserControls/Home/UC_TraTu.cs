using DictionaryAppForIT.UserControls.Home;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DictionaryAppForIT.UserControls
{
    public partial class UC_TraTu : UserControl
    {
        UC_Nghia ucNghia = new UC_Nghia();
        public UC_TraTu()
        {
            InitializeComponent();
            flpMeaning.Controls.Add(ucNghia);
            ucNghia.Dock = DockStyle.Top;
            //textBox2.Text = "Vaixocncamoi okeoke";
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            CorrectHeight(textBox2);   
        }

        public void CorrectHeight(TextBox txtbox)
        {
            if (txtbox.BorderStyle == BorderStyle.None)
            {
                txtbox.BorderStyle = BorderStyle.FixedSingle;
                var heightWithBorder = txtbox.ClientRectangle.Height;
                txtbox.BorderStyle = BorderStyle.None;
                txtbox.AutoSize = false;
                txtbox.Height = heightWithBorder;
            }
        }

        private void btnTimKiemTu_Click(object sender, EventArgs e)
        {

        }
    }
}
