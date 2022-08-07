using DictionaryAppForIT.UserControls.Home;
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
using System.Data.SqlClient;
using System.Speech.Synthesis;

namespace DictionaryAppForIT.UserControls
{
    public partial class UC_TraTu : UserControl
    {
        SpeechSynthesizer speech;
        //static UC_TraTu _obj;
        //UC_Nghia ucNghia = new UC_Nghia();
        public UC_TraTu()
        {
            InitializeComponent();
            speech = new SpeechSynthesizer();
            // flpMeaning.Controls.Add(ucNghia);
            GoiYTimKiem();
        }
        private void GoiYTimKiem()
        {
            try
            {
                SqlConnection Conn = new SqlConnection(@"Data Source=DESKTOP-M9DGN9B;Initial Catalog=TestDictionary2;Integrated Security=True");
                Conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = $"select TenTu from Tu";
                cmd.Connection = Conn;
                SqlDataReader rdr = cmd.ExecuteReader();
                AutoCompleteStringCollection autoComplete = new AutoCompleteStringCollection();
                while (rdr.Read())
                {
                    autoComplete.Add(rdr.GetString(0));
                }
                txtTimKiemTu.AutoCompleteSource = AutoCompleteSource.CustomSource;
                txtTimKiemTu.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                txtTimKiemTu.AutoCompleteCustomSource = autoComplete;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void btnTimKiemTu_Click(object sender, EventArgs e)
        {

            try
            {
                SqlConnection Conn = new SqlConnection(@"Data Source=DESKTOP-M9DGN9B;Initial Catalog=TestDictionary2;Integrated Security=True");
                SqlCommand cmd = new SqlCommand($"exec HienThiThongTin '{txtTimKiemTu.Text}%'", Conn);
                Conn.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    txtTuVung.Text = rdr["TenTu"].ToString();
                    txtPhienAm.Text = rdr["PhienAm"].ToString();
                    txtTuLoai.Text = rdr["TenLoai"].ToString();
                    txtNghiaTV.Text = rdr["Nghia"].ToString();
                    lblMoTa.Text = rdr["MoTa"].ToString();
                    lblViDu.Text = rdr["ViDu"].ToString();
                    txtDongNghia.Text = rdr["DongNghia"].ToString();
                    if (txtDongNghia.Text != "")
                    {
                        pbKhongTimThay.Visible = false;
                        txtDongNghia.Visible = true;
                    }
                    else
                    {
                        pbKhongTimThay.Visible = true;
                        txtDongNghia.Visible = false;
                    }
                    txtTraiNghia.Text = rdr["TraiNghia"].ToString();
                }
                Conn.Close();
                Conn.Dispose();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void txtTimKiemTu_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                //btnTimKiemTu_Click(this, new EventArgs());
                btnTimKiemTu.PerformClick();
            }
        }

        private void btnLuuMucYeuThich_Click(object sender, EventArgs e)
        {

        }

        private void txtTimKiemTu_TextChanged(object sender, EventArgs e)
        {
        
        }
        private void btnUS_Click(object sender, EventArgs e)
        {
            speech.SelectVoice("Microsoft David Desktop"); //giong mỹ
            speech.SpeakAsync(txtTuVung.Text);
        }

        private void btnUK_Click(object sender, EventArgs e)
        {
            speech.SelectVoice("Microsoft Hazel Desktop"); // giong anh
            speech.SpeakAsync(txtTuVung.Text);

        }
    }
}
