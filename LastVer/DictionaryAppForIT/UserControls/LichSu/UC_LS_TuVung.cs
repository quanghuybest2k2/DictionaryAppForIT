using Bunifu.UI.WinForms;
using Guna.UI2.WinForms;
using DictionaryAppForIT.DAL;
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
        UC_LichSu uc_lichSu;
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
            get { return btnPhatAmLS; }
            set { btnPhatAmLS = value; }
        }

        public BunifuCheckBox ChkChonLSTraTu
        {
            get { return chkChonLSTraTu; }
            set { chkChonLSTraTu = value; }
        }

        private void chkChonLSTraTu_CheckedChanged(object sender, BunifuCheckBox.CheckedChangedEventArgs e)
        {
            //if (chkChonLSTraTu.Checked)
            //{
            //    RJMessageBox.Show("Bạn đã chọn cái này");
            //}
            if (chkChonLSTraTu.Checked)
            {
                this.Name = "Check";
            }
            else
            {
                this.Name = "unCheck";
            }
            //this.lblNgayThang.Text = this.Name;
        }
        public void PhatAm(string s)
        {
            //btnPhatAmLS.PerformClick();
            speech.SelectVoiceByHints(VoiceGender.Male); // giong nam
            speech.SpeakAsync(s);
        }

        private void btnXoaLSTraTu_Click(object sender, EventArgs e)
        {
            int num = DataProvider.Instance.ExecuteNonQuery($"delete from LichSuTraTu where id = {this.Index}");
            if (num > 0)
            {
                RJMessageBox.Show("Xóa thành công!");
                //uc_lichSu.HienThiLSTraTu();
                //uc_lichSu.HienThiLSDich();
            }
            else { RJMessageBox.Show("Xóa không thành công!"); }
        }

        private void btnPhatAmLS_Click(object sender, EventArgs e)
        {
            //lblTiengAnh.Text = "ccccccccccccccccc";
            if (lblTiengAnh.Text != null)
            {
                object DocTu = DataProvider.Instance.ExecuteScalar($"select TiengAnh from LichSuTraTu where id = {this.Index} and IDTK = 2");
                speech.SelectVoiceByHints(VoiceGender.Male); // giong nam
                speech.SpeakAsync(DocTu.ToString());
            }
            //MessageBox.Show(lblTiengAnh.Text, lblTiengViet.Text, MessageBoxButtons.OK);
        }
    }
}
