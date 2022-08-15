using System;
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
using DictionaryAppForIT.DTO;

namespace DictionaryAppForIT.UserControls.Home
{
    public partial class UC_TVChuyenNganh : UserControl
    {
        SpeechSynthesizer speech;
        public UC_TVChuyenNganh()
        {
            InitializeComponent();
            speech = new SpeechSynthesizer();
            dtgvTuVung.AutoGenerateColumns = false;
            loadChuyenNganh();
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
                string query = "exec LayTheoChuyenNganh @chuyennganh";//
                dtgvTuVung.DataSource = DataProvider.Instance.ExecuteQuery(query, new object[] { cbbChuyenNganh.SelectedValue });//
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void cbbChuyenNganh_SelectedIndexChanged(object sender, EventArgs e)
        {
            HienThiTheoChuyenNganh();
            GoiYTimKiem();
        }

        #region Thanh trượt
        private void VSThanhTruotDoc_Scroll(object sender, ScrollEventArgs e)
        {
            pnContainer.VerticalScroll.Value = VSThanhTruotDoc.Value;
        }

        private void HSThanhTruotNgang_Scroll(object sender, ScrollEventArgs e)
        {
            pnContainer.HorizontalScroll.Value = HSThanhTruotNgang.Value;
        }
        #endregion

        #region event
        private void dtgvTuVung_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 1) //Cột thứ 2(hình cái loa)
            {
                //MessageBox.Show("Bạn click vào loa hàng số " + e.RowIndex);
                //speech.SelectVoice("Microsoft Hazel Desktop");
                speech.SelectVoiceByHints(VoiceGender.Male); // giong nam
                txtTuVungDoc.Text = dtgvTuVung.CurrentRow.Cells["ColTuVung"].Value.ToString();
                speech.SpeakAsync(txtTuVungDoc.Text);
            }
        }
        #endregion

        private void btnTimTheoCN_Click(object sender, EventArgs e)
        {
            try
            {
                string query = $"TimTheoChuyenNganh '{txtTimTheoChuyenNganh.Text}%', @chuyennganh";
                dtgvTuVung.DataSource = DataProvider.Instance.ExecuteQuery(query, new object[] { cbbChuyenNganh.SelectedValue });
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
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
                SqlConnection Conn = new SqlConnection(@"Data Source=DESKTOP-M9DGN9B;Initial Catalog=EnglishDictionary;Integrated Security=True");
                Conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = $"SELECT TenTu FROM Tu, ChuyenNganh WHERE tu.ChuyenNganh = ChuyenNganh.ID and TenTu like '{txtTimTheoChuyenNganh.Text}%' and ChuyenNganh.ID = {cbbChuyenNganh.SelectedValue}";
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
    }
}
