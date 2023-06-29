using DictionaryAppForIT.Class;
using DictionaryAppForIT.DAL;
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

namespace DictionaryAppForIT.UserControls.LichSu
{
    public partial class UC_LS_VanBan : UserControl
    {
        public UC_LS_VanBan()
        {
            InitializeComponent(); 
        }

        public UC_LS_VanBan(string index, string thoiGian, string ngayThang, string tiengAnh, string tiengViet)
        {
            InitializeComponent();
            this.Index = index;
            this.ThoiGian = thoiGian;
            this.NgayThang = ngayThang;
            this.VBTiengAnh = tiengAnh;
            this.VBTiengViet = tiengViet;
        }

        public string Index
        {
            get { return lblIndex.Text; }
            set { lblIndex.Text = value; }
        }

        public string ThoiGian
        {
            get { return lblThoiGian.Text; }
            set { lblThoiGian.Text = value; }
        }

        public string NgayThang
        {
            get { return lblNgayThang.Text; }
            set { lblNgayThang.Text = value; }
        }

        public string VBTiengAnh
        {
            get { return lblTiengAnh.Text; }
            set { lblTiengAnh.Text = value; }
        }

        public string VBTiengViet
        {
            get { return lblTiengViet.Text; }
            set { lblTiengViet.Text = value; }
        }

        private void chkChonLSVanBan_CheckedChanged(object sender, Bunifu.UI.WinForms.BunifuCheckBox.CheckedChangedEventArgs e)
        {
            if (chkChonLSVanBan.Checked)
            {
                this.Name = "Check";
            }
            else
            {
                this.Name = "unCheck";
            }
            //this.lblNgayThang.Text = this.Name;
        }

        private void btnXoaLSVanBan_Click(object sender, EventArgs e)
        {
            this.Name = "Check";
            this.Visible = false;
            int num = DataProvider.Instance.ExecuteNonQuery($"delete from LichSuDich where id = '{this.Index}' and IDTK = '{Class_TaiKhoan.IdTaiKhoan}'");
            //if (num > 0)
            //{
            //    RJMessageBox.Show("Xóa thành công!");
            //}
            //else { RJMessageBox.Show("Xóa không thành công!"); }
        }
    }
}
