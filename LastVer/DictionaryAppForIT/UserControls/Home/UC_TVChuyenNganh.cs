using System;
using DictionaryAppForIT.DTO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DictionaryAppForIT.DAL;
using System.Speech.Synthesis;
using System.Data.SqlClient;
using System.Configuration;

namespace DictionaryAppForIT.UserControls.Home
{
    public partial class UC_TVChuyenNganh : UserControl
    {
        private string connString = ConfigurationManager.ConnectionStrings["DictionaryApp"].ConnectionString;
        SpeechSynthesizer speech;
        public bool thayDoiTocDo = false;
        public int tocDo = 0;
        public UC_TVChuyenNganh()
        {
            InitializeComponent();
            speech = new SpeechSynthesizer();
            dtgvTuVung.AutoGenerateColumns = false;
            //dtgvTuVung.ScrollBars = ScrollBars.Both;
        }
        private void loadChuyenNganh()
        {
            try
            {
                string query = "select * from ChuyenNganh";
                cbbChuyenNganh.DataSource = DataProvider.Instance.ExecuteQuery(query);
                cbbChuyenNganh.DisplayMember = "TenChuyenNganh";
                cbbChuyenNganh.ValueMember = "ID";
                HienThiTheoChuyenNganh(); // hiển thị lúc load lên
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void HienThiTheoChuyenNganh()
        {
            try
            {
                string query = $"exec LayTheoChuyenNganh {cbbChuyenNganh.SelectedValue} , {Class_TaiKhoan.IdTaiKhoan}";
                dtgvTuVung.DataSource = DataProvider.Instance.ExecuteQuery(query);//
                lblSoTuHienCo.Text = dtgvTuVung.Rows.Count.ToString();// hiển thị số từ vựng
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void btnTimTheoCN_Click(object sender, EventArgs e)
        {
            try
            {
                string query = $"EXEC TimTheoChuyenNganh '{txtTimTheoChuyenNganh.Text}', {cbbChuyenNganh.SelectedValue}, {Class_TaiKhoan.IdTaiKhoan}";
                dtgvTuVung.DataSource = DataProvider.Instance.ExecuteQuery(query);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void TocDoNoi()
        {
            if (thayDoiTocDo)
            {
                speech.Rate = tocDo;
            }
        }
        private void dtgvTuVung_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 1) //Cột thứ 2(hình cái loa)
            {
                //MessageBox.Show("Bạn click vào loa hàng số " + e.RowIndex);
                txtTuVungDoc.Text = dtgvTuVung.CurrentRow.Cells["ColTuVung"].Value.ToString();
                speech.SelectVoice("Microsoft David Desktop"); //giong mỹ
                TocDoNoi();
                speech.SpeakAsync(txtTuVungDoc.Text);
            }
        }

        private void txtTimTheoChuyenNganh_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnTimTheoCN.PerformClick();
            }
        }
        private void GoiYTimKiem()
        {
            try
            {
                SqlConnection Conn = new SqlConnection(connString);
                Conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = $"SELECT TenTu FROM Tu, ChuyenNganh WHERE tu.ChuyenNganh = ChuyenNganh.ID and TenTu like '{txtTimTheoChuyenNganh.Text}%' and ChuyenNganh.ID = {cbbChuyenNganh.SelectedValue} and IDTK = {Class_TaiKhoan.IdTaiKhoan} or IDTK = 0";
                cmd.Connection = Conn;
                SqlDataReader rdr = cmd.ExecuteReader();
                AutoCompleteStringCollection autoComplete = new AutoCompleteStringCollection();
                while (rdr.Read())
                {
                    autoComplete.Add(rdr.GetString(0));
                }
                txtTimTheoChuyenNganh.AutoCompleteSource = AutoCompleteSource.CustomSource;
                txtTimTheoChuyenNganh.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                txtTimTheoChuyenNganh.AutoCompleteCustomSource = autoComplete;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void txtTimTheoChuyenNganh_TextChanged(object sender, EventArgs e)
        {
            if (txtTimTheoChuyenNganh.Text == "")
            {
                //cái nào cũng được
                //btnTimTheoCN.PerformClick();
                HienThiTheoChuyenNganh();
            }
        }

        private void UC_TVChuyenNganh_Load(object sender, EventArgs e)
        {
            cbbChuyenNganh.SelectedIndexChanged -= CbbChuyenNganh_SelectedIndexChanged;// tách sự kiện
            loadChuyenNganh();
            cbbChuyenNganh.SelectedIndexChanged += CbbChuyenNganh_SelectedIndexChanged;//tạo lại
        }

        private void CbbChuyenNganh_SelectedIndexChanged(object sender, EventArgs e)
        {
            HienThiTheoChuyenNganh();
            GoiYTimKiem();
        }
    }
}
