using Bunifu.UI.WinForms;
using Guna.UI2.WinForms;
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
using System.Speech.Synthesis;
using DictionaryAppForIT.Class;
using DictionaryAppForIT.UserControls.GanDay;

namespace DictionaryAppForIT.UserControls.LichSu
{
    public partial class UC_LS_TuVung : UserControl
    {
        SpeechSynthesizer speech;
        public UC_LS_TuVung()
        {
            InitializeComponent();
            speech = new SpeechSynthesizer();
        }
        public UC_LS_TuVung(string index, string thoiGian, string ngayThang, string tiengAnh, string phienAm, string tiengViet)
        {
            InitializeComponent();
            this.Index = index;
            this.ThoiGian = thoiGian;
            this.NgayThang = ngayThang;
            this.TVTiengAnh = tiengAnh;
            this.TVPhienAm = phienAm;
            this.TVTiengViet = tiengViet;
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

        public string TVTiengAnh
        {
            get { return lblTiengAnh.Text; }
            set { lblTiengAnh.Text = value; }
        }

        public string TVPhienAm
        {
            get { return lblPhienAm.Text; }
            set { lblPhienAm.Text = value; }
        }

        public string TVTiengViet
        {
            get { return lblTiengViet.Text; }
            set { lblTiengViet.Text = value; }

        }
        public Guna2Button ButtonPhatAm
        {
            get { return btnDieuHuongLS; }
            set { btnDieuHuongLS = value; }
        }

        private void chkChonLSTraTu_CheckedChanged(object sender, BunifuCheckBox.CheckedChangedEventArgs e)
        {
            if (chkChonLSTraTu.Checked)
            {
                this.Name = "Check";
            }
            else
            {
                this.Name = "unCheck";
            }
        }

        private void btnXoaLSTraTu_Click(object sender, EventArgs e)
        {
            this.Name = "Check";
            this.Visible = false;
            int num = DataProvider.Instance.ExecuteNonQuery($"delete from LichSuTraTu where id = {this.Index} and IDTK = {Class_TaiKhoan.IdTaiKhoan}");
            if (num > 0)
            {
                RJMessageBox.Show("Xóa thành công!");
            }
            else { RJMessageBox.Show("Xóa không thành công!"); }
        }

        private void btnDieuHuongLS_Click(object sender, EventArgs e)
        {

        }
    }
}
