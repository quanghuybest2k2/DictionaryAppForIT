using System;
using System.Windows.Forms;

namespace DictionaryAppForIT.UserControls.TaiKhoan
{
    public partial class UC_TT_ThemNghia : UserControl
    {
        public bool XacNhanXoa = false;
        int textStt = 0;

        public UC_TT_ThemNghia(int stt)
        {
            InitializeComponent();
            lblSTT.Text = "Nghĩa thứ " + stt;
            textStt = stt;
        }

        public int Stt
        {
            get { return this.textStt; }
            set { this.lblSTT.Text = "Nghĩa thứ " + value.ToString(); }
        }

        public string Nghia
        {
            get { return this.txtNghia.Text.Trim(); }
        }

        public string TuLoai
        {
            get { return cbbTuLoai.SelectedValue.ToString(); }
        }

        public string MoTa
        {
            get { return txtMoTa.Text.Trim(); }
        }

        public string ViDu
        {
            get { return txtVD.Text.Trim(); }
        }

        public string[] LayGiaTriControl()
        {
            string[] arr = { TuLoai, Nghia, MoTa, ViDu };
            return arr;
        }

        public void MacDinh()
        {
            txtNghia.Clear();
            txtVD.Clear();
            txtMoTa.Clear();
        }

        private void cbXoa_CheckedChanged(object sender, Bunifu.UI.WinForms.BunifuCheckBox.CheckedChangedEventArgs e)
        {
            if (cbXoa.Checked)
                XacNhanXoa = true;
            else
                XacNhanXoa = false;
        }
        private void LoadTuLoai()
        {
            try
            {
                string query = "select * from TuLoai";
                //cbbTuLoai.DataSource = DataProvider.Instance.ExecuteQuery(query);
                cbbTuLoai.DisplayMember = "TenLoai";
                cbbTuLoai.ValueMember = "ID";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void UC_TT_ThemNghia_Load(object sender, EventArgs e)
        {
            LoadTuLoai();
            cbbTuLoai.SelectedIndex = 0;
        }
    }
}
