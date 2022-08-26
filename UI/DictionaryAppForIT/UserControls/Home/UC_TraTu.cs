﻿using DictionaryAppForIT.UserControls.Home;
using DictionaryAppForIT.UserControls.CaiDat;
using DictionaryAppForIT.Class;
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
using System.Data.SqlClient;
using DictionaryAppForIT.DAL;
using System.Configuration;
using System.Speech.AudioFormat;

namespace DictionaryAppForIT.UserControls
{
    public partial class UC_TraTu : UserControl
    {
        string TuHienTai = ""; //-------------------------------------- Tạo thêm cái này vì nếu người ta gõ 1 từ xong rồi enter nhiều lần thì nó add lặp lại vô cái _listTu
        private string connString = ConfigurationManager.ConnectionStrings["DictionaryApp"].ConnectionString;
        XemTatCaNghia XemNghia;
        UC_Nghia ucNghia;
        UC_CaiDat ucCaiDat;
        SpeechSynthesizer speech;
        public UC_TraTu()
        {
            InitializeComponent();
            speech = new SpeechSynthesizer();
            GoiYTimKiem();
            XemNghia = new XemTatCaNghia();
            ucCaiDat = new UC_CaiDat();
            //speech.Rate = 3;
            if (ucCaiDat.RadioButtonChamHon)
            {
                speech.Rate = -5; // tốc độ nói
            }
            if (ucCaiDat.RadioButtonNhanhHon)
            {
                speech.Rate = 3;
            }
            //TocDoNoi();
        }
        private void TocDoNoi()
        {
            
        }
        private void UC_TraTu_Load(object sender, EventArgs e)
        {
            lblTenDangNhap.Text = Class_TaiKhoan.displayUsername; // Hello Sang Đỗ
        }
        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            CorrectHeight(txtTuVung);
        }

        public void CorrectHeight(TextBox txtbox)
        {
            if (txtbox.BorderStyle == BorderStyle.None)
            {
                txtbox.BorderStyle = BorderStyle.FixedSingle;
                var heightWithBorder = txtbox.ClientRectangle.Height;
                txtbox.BorderStyle = BorderStyle.None;
                txtbox.AutoSize = false;
                txtbox.Height = heightWithBorder;
            }
        }
        #region xử lý tìm kiếm
        private void GoiYTimKiem()
        {
            try
            {
                SqlConnection Conn = new SqlConnection(connString);
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
        private void txtTimKiemTu_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && TuHienTai != txtTimKiemTu.Text)//--------------------------------------
            {
                flpMeaning.Controls.Clear();  //-------------------------------------- Khi người ta enter mới xóa flpMeaning
                HienThiThongTin();
                TuHienTai = txtTimKiemTu.Text;//--------------------------------------
            }
        }
        private void HienThiThongTin()
        {
            XemNghia.HienThiThongTinTimKiem(txtTimKiemTu.Text);

            foreach (var item in XemNghia._listTu)
            {
                txtTuVung.Text = item.TenTu;
                txtPhienAm.Text = item.PhienAm;
                txtDongNghia.Text = item.DongNghia;
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
                txtTraiNghia.Text = item.TraiNghia;
                ucNghia = new UC_Nghia();

                ucNghia.LoaiTu = item.TenLoai;
                ucNghia.Nghia = item.Nghia;
                ucNghia.MoTa = item.MoTa;
                ucNghia.ViDu = item.ViDu;

                flpMeaning.Controls.Add(ucNghia);
                ucNghia.Dock = DockStyle.Top;

            }
            //MessageBox.Show(XemNghia._listTu[0].TenTu);
        }
        #endregion

        #region btn us, uk, sao chep
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

        private void btnSaoChep_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(txtTuVung.Text); // copy text
            //Clipboard.GetText(); // paste text
        }
        #endregion

        private void HienThiKqRandom()
        {
            XemNghia.HienThiThongTinRandom();

            foreach (var item in XemNghia._listTu)
            {
                txtTuVung.Text = item.TenTu;
                txtPhienAm.Text = item.PhienAm;
                txtDongNghia.Text = item.DongNghia;
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
                txtTraiNghia.Text = item.TraiNghia;
                ucNghia = new UC_Nghia();

                ucNghia.LoaiTu = item.TenLoai;
                ucNghia.Nghia = item.Nghia;
                ucNghia.MoTa = item.MoTa;
                ucNghia.ViDu = item.ViDu;

                flpMeaning.Controls.Add(ucNghia);
                ucNghia.Dock = DockStyle.Top;

            }
            //MessageBox.Show(XemNghia._listTu[0].TenTu);
        }
        private void btnTuNgauNhien_Click(object sender, EventArgs e)
        {
            try
            {
                flpMeaning.Controls.Clear();  //-------------------------------------- Khi người ta enter mới xóa flpMeaning
                HienThiKqRandom();
                TuHienTai = txtTimKiemTu.Text;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void txtTimKiemTu_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
