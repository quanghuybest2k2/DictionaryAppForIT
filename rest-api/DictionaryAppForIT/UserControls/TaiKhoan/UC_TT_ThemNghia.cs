using DictionaryAppForIT.DAL;
using DictionaryAppForIT.DTO;
using System;
using System.Threading.Tasks;
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
        private async Task LoadTuLoai()
        {
            try
            {
                object result = await DataProvider.Instance.GetMethod<WordTypeResponse>("get-all-word-type");

                if (result != null)
                {
                    cbbTuLoai.DataSource = result;
                    cbbTuLoai.DisplayMember = "type_name";
                    cbbTuLoai.ValueMember = "id";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private async void UC_TT_ThemNghia_Load(object sender, EventArgs e)
        {
            await LoadTuLoai();
            cbbTuLoai.SelectedIndex = 0;
        }
    }
}
