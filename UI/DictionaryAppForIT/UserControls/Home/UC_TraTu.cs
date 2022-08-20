using DictionaryAppForIT.UserControls.Home;
using DictionaryAppForIT.Class;
using DictionaryAppForIT.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Speech.Synthesis;

namespace DictionaryAppForIT.UserControls
{
    public partial class UC_TraTu : UserControl
    {
        XemTatCaNghia XemNghia;
        UC_Nghia ucNghia;
        SpeechSynthesizer speech;
        public UC_TraTu()
        {
            InitializeComponent();
            speech = new SpeechSynthesizer();
           

            //textBox2.Text = "Vaixocncamoi okeoke";
            XemNghia = new XemTatCaNghia();
            XemNghia.XemTatCaNghiaTu("Variable");
            foreach (var item in XemNghia._listTu)
            {
                ucNghia = new UC_Nghia();
                ucNghia.LoaiTu = item.TenLoai;
                ucNghia.Nghia = item.Nghia;
                
                flpMeaning.Controls.Add(ucNghia);
                ucNghia.Dock = DockStyle.Top;
            }
            //MessageBox.Show(XemNghia._listTu[0].TenTu);
        }
        private void UC_TraTu_Load(object sender, EventArgs e)
        {
            lblTenDangNhap.Text = Class_TaiKhoan.displayUsername; // Hello Sang Đỗ
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
