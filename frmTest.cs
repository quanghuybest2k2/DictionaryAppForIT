using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace DictionaryAppForIT
{
    public partial class frmTest : Form
    {
        public frmTest()
        {
            InitializeComponent();
            ReadXml();
            guna2DataGridView1.ScrollBars = ScrollBars.Both;
        }

        private void ReadXml()
        {
            string filePath = Path.Combine(@"D:\Window Form\DictionaryAppForIT\DTO\LichSu.xml");
            XmlDocument doc = new XmlDocument();
            doc.Load(filePath);
            XmlNode nodeTiengAnh = doc.SelectSingleNode("/LichSu/Tu/TiengAnh");
            XmlNode nodeTiengViet = doc.SelectSingleNode("/LichSu/Tu/TiengViet");
            TextBox txtTiengAnh = new TextBox();
            txtTiengAnh.Name = "txtTiengAnh";
            TextBox txtTiengViet = new TextBox();
            txtTiengViet.Name = "txtTiengViet";

            txtTiengAnh.Text = nodeTiengAnh.InnerText;
            txtTiengViet.Text = nodeTiengViet.InnerText;

            List<string> list = new List<string>();
            string[] arr = { txtTiengAnh.Text, txtTiengViet.Text };
            list.AddRange(arr);
            rtxtHienThi.Lines = list.ToArray();// richTextBox.Lines có thể xuống dòng
            //int number = 0;
            //while (number < 5)
            //{
            //    RichTextBox trev = new RichTextBox() { Text = "rtxt" + number };
            //    trev.Name = "rtxt" + number.ToString();

            //    flpnContainer.Controls.Add(trev);
            //    number++;
            //}
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            //for (int i = 0; i < 100; i++)
            //{
            //    flpnContainer.Controls.Add(new RichTextBox() { Text = "Rich TextBox" });
            //}
            int number = 0;
            while (number < 5)
            {
                RichTextBox trev = new RichTextBox() { Text = "rtxt"+number};
                trev.Name = number.ToString();

                flpnContainer.Controls.Add(trev);
                number++;
            }
        }

        private void vScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {
            flpnContainer.VerticalScroll.Value = vScrollBar1.Value;
        }

        private void frmTest_Load(object sender, EventArgs e)
        {

        }

        private void guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
