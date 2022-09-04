using DictionaryAppForIT.UserControls.ThongBao;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DictionaryAppForIT.Forms
{
    public partial class frmThongBao : Form
    {
        public frmThongBao()
        {
            InitializeComponent();
            int count = 2;
            var ucTBNoiDung = new UC_TB_NoiDung("Bạn vừa xóa 1 mục yêu thích", "32 phút trước");
            flpContent.Controls.Add(ucTBNoiDung);
            count++;
            ucTBNoiDung = new UC_TB_NoiDung("Bạn vừa xóa 1 mục yêu thích", "32 phút trước");
            flpContent.Controls.Add(ucTBNoiDung);
            count++;
            //ucTBNoiDung = new UC_ThongBao("Bạn vừa xóa 1 mục yêu thích", "32 phút trước");
            //flpContent.Controls.Add(ucTBNoiDung);
            //count++;
            //ucTBNoiDung = new UC_ThongBao("Bạn vừa xóa 1 mục yêu thích", "32 phút trước");
            //flpContent.Controls.Add(ucTBNoiDung);
            //count++;
            //ucTBNoiDung = new UC_ThongBao("Bạn vừa xóa 1 mục yêu thích", "32 phút trước");
            //flpContent.Controls.Add(ucTBNoiDung);
            //count++;

            if (count > 4)
            {
                guna2PictureBox2.Width = 237;
                guna2PictureBox3.Width = 237;
                pnNen.Width = 237;
                btnCloseMax.Visible = true;
                btnCloseMini.Visible = false;
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
