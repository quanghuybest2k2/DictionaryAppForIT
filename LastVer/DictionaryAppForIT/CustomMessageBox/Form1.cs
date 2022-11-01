using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DictionaryAppForIT.Forms;
using DictionaryAppForIT.Class;

namespace DictionaryAppForIT.CustomMessageBox
{
    public partial class Form1 : Form
    {
        private Timer timer = new Timer();
        public Form1()
        {
            InitializeComponent();
        }

        public void Alert(string tuVung, string phienAm, string nghia, Form_Alert.enmType type)
        {
            Form_Alert frm = new Form_Alert();
            frm.showAlert(tuVung, phienAm, nghia, type);
        }
        private void button1_Click(object sender, EventArgs e)
        {
            //this.Alert("Success Alert",Form_Alert.enmType.Success);
            this.Alert("Component", "/kəmˈpoʊ.nənt/", "Thành phần, bộ phận", Form_Alert.enmType.Success);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Alert("Variable", "/ˈver.i.ə.bəl/", "Biến", Form_Alert.enmType.Warning);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Alert("Application", "/ˌæp.ləˈkeɪ.ʃən/", "Ứng dụng", Form_Alert.enmType.Error);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Alert("Circuit", "/‘sə:kit/", "Mạch", Form_Alert.enmType.Info);
        }

        private void btnThanhCong_Click(object sender, EventArgs e)
        {

        }

        private void btnLoi_Click(object sender, EventArgs e)
        {
            var result = RJMessageBox.Show("This is an example of an Error-Stop Icon Message Box.",
                "Error-Stop Icon",
                MessageBoxButtons.RetryCancel,
                MessageBoxIcon.Error);
        }

        private void btnThongTin_Click(object sender, EventArgs e)
        {
            var result = RJMessageBox.Show("This is an example of an Information Icon Message Box.",
                "Information Icon",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }

        private void btnCanhBao_Click(object sender, EventArgs e)
        {
            var result = RJMessageBox.Show("This is an example of an Warning-Exclamation Icon Message Box.",
              "Warning-Exclamation Icon",
              MessageBoxButtons.YesNoCancel,
              MessageBoxIcon.Warning);
        }

        private void btnChamHoi_Click(object sender, EventArgs e)
        {
            var result = RJMessageBox.Show("This is an example of an Question Icon Message Box.",
             "Question Icon",
             MessageBoxButtons.OKCancel,
             MessageBoxIcon.Question);
        }
        public void Init()
        {
            timer.Interval = 5000; // 5s
            timer.Tick += new EventHandler(timer_Tick);
            timer.Enabled = true;
        }
        private void timer_Tick(object sender, EventArgs e)
        {
            this.Alert("Component", "/kəmˈpoʊ.nənt/", "Thành phần, bộ phận", Form_Alert.enmType.Success);
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            Init();
        }
    }
}
