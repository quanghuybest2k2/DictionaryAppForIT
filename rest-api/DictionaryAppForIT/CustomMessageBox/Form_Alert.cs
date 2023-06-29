using DictionaryAppForIT.DTO;
using DictionaryAppForIT.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DictionaryAppForIT.CustomMessageBox
{
    public partial class Form_Alert : Form
    {
        XemTatCaNghia XemNghia;
        public Form_Alert()
        {
            InitializeComponent();
            XemNghia = new XemTatCaNghia();
        }

        public void AlertBackColor(string color)
        {
            this.BackColor = Color.FromName(color);
        }

        public enum enmAction
        {
            wait,
            start,
            close
        }

        public enum enmType
        {
            Success,
            Warning,
            Error,
            Info
        }
        private Form_Alert.enmAction action;

        private int x, y;


        private void timer1_Tick(object sender, EventArgs e)
        {
            switch (this.action)
            {
                case enmAction.wait:
                    timer1.Interval = 10000;
                    action = enmAction.close;
                    break;
                case Form_Alert.enmAction.start:
                    this.timer1.Interval = 1;
                    this.Opacity += 0.1;
                    if (this.x < this.Location.X)
                    {
                        this.Left--;
                    }
                    else
                    {
                        if (this.Opacity == 1.0)
                        {
                            action = Form_Alert.enmAction.wait;
                        }
                    }
                    break;
                case enmAction.close:
                    timer1.Interval = 1;
                    this.Opacity -= 0.1;

                    this.Left -= 3;
                    if (base.Opacity == 0.0)
                    {
                        base.Close();
                    }
                    break;
            }
        }

        private void pbClose_Click(object sender, EventArgs e)
        {
            timer1.Interval = 1;
            action = enmAction.close;
        }

        private void Form_Alert_Load(object sender, EventArgs e)
        {

        }

        public void showAlert(int type)
        {
            XemNghia.HienThiThongTinRandom();
            foreach (var item in XemNghia._listTu)
            {
                lblTuVung.Text = item.TenTu;
                lblPhienAm.Text = item.PhienAm;
                lblNghia.Text = item.Nghia;
            }
            this.Opacity = 0.0;
            this.StartPosition = FormStartPosition.Manual;
            string fname;

            for (int i = 1; i < 10; i++)
            {
                fname = "alert" + i.ToString();
                Form_Alert frm = (Form_Alert)Application.OpenForms[fname];

                if (frm == null)
                {
                    this.Name = fname;
                    this.x = Screen.PrimaryScreen.WorkingArea.Width - this.Width + 15;
                    this.y = Screen.PrimaryScreen.WorkingArea.Height - this.Height * i - 5 * i;
                    this.Location = new Point(this.x, this.y);
                    break;

                }

            }
            this.x = Screen.PrimaryScreen.WorkingArea.Width - base.Width - 5;

            switch (type)
            {
                case 1:
                    this.pbCat.Image = DictionaryAppForIT.Properties.Resources.random111;
                    break;
                case 2:
                    this.pbCat.Image = DictionaryAppForIT.Properties.Resources.random112;
                    break;
                case 3:
                    this.pbCat.Image = DictionaryAppForIT.Properties.Resources.random113;
                    break;
                case 4:
                    this.pbCat.Image = DictionaryAppForIT.Properties.Resources.random114;
                    break;
                case 5:
                    this.pbCat.Image = DictionaryAppForIT.Properties.Resources.random115;
                    break;
                case 6:
                    this.pbCat.Image = DictionaryAppForIT.Properties.Resources.random116;
                    break;
                case 7:
                    this.pbCat.Image = DictionaryAppForIT.Properties.Resources.random117;
                    break;
                case 8:
                    this.pbCat.Image = DictionaryAppForIT.Properties.Resources.random118;
                    break;
                case 9:
                    this.pbCat.Image = DictionaryAppForIT.Properties.Resources.random119;
                    break;
                case 10:
                    this.pbCat.Image = DictionaryAppForIT.Properties.Resources.random110;
                    break;
            }

            this.Show();
            this.action = enmAction.start;
            this.timer1.Interval = 1;
            this.timer1.Start();
        }
    }
}
