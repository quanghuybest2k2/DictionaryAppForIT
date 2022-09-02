using System;
using DictionaryAppForIT.DTO;
using DictionaryAppForIT.Class;
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
using DictionaryAppForIT.Forms;

namespace DictionaryAppForIT.UserControls.TaiKhoan
{
    public partial class UC_ThemTu : UserControl
    {
        private string connString = ConfigurationManager.ConnectionStrings["DictionaryApp"].ConnectionString;
        private string idTuMoi;
        public UC_ThemTu()
        {
            InitializeComponent();
        }
        private void loadChuyenNganh()
        {
            try
            {
                string query = "select * from ChuyenNganh";
                cbbChuyenNganh.DataSource = DataProvider.Instance.ExecuteQuery(query);
                cbbChuyenNganh.DisplayMember = "TenChuyenNganh";
                cbbChuyenNganh.ValueMember = "ID";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void loadTuLoai()
        {
            try
            {
                string query = "select * from TuLoai";
                cbbTuLoai.DataSource = DataProvider.Instance.ExecuteQuery(query);
                cbbTuLoai.DisplayMember = "TenLoai";
                cbbTuLoai.ValueMember = "ID";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void UC_ThemTu_Load(object sender, EventArgs e)
        {
            loadChuyenNganh();
            loadTuLoai();
        }

        private void btnThemTuVung_Click(object sender, EventArgs e)
        {
            try
            {
                // them tu
                //string themTu = "EXEC ThemTu @TenTu, @PhienAm, @ChuyenNganh, @DongNghia, @TraiNghia";
                //DataProvider.Instance.ExecuteNonQuery(themTu, new object[] { txtTenTu.Text, txtPhienAm.Text, cbbChuyenNganh.SelectedValue, txtDongNghia.Text, txtTraiNghia.Text });

                SqlConnection conn = new SqlConnection(connString);
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "EXEC ThemTu @idTu output, @TenTu, @PhienAm, @ChuyenNganh, @DongNghia, @TraiNghia";
                cmd.Parameters.Add("@idTu", SqlDbType.Int);

                cmd.Parameters.Add("@TenTu", SqlDbType.VarChar, 100);
                cmd.Parameters.Add("@PhienAm", SqlDbType.NVarChar, 100);
                cmd.Parameters.Add("@ChuyenNganh", SqlDbType.Int);
                cmd.Parameters.Add("@DongNghia", SqlDbType.VarChar, 1000);
                cmd.Parameters.Add("@TraiNghia", SqlDbType.VarChar, 1000);

                cmd.Parameters["@idTu"].Direction = ParameterDirection.Output;
                //
                cmd.Parameters["@TenTu"].Value = txtTenTu.Text;
                cmd.Parameters["@PhienAm"].Value = $"/{txtPhienAm.Text}/";
                cmd.Parameters["@ChuyenNganh"].Value = cbbChuyenNganh.SelectedValue;
                cmd.Parameters["@DongNghia"].Value = txtDongNghia.Text;
                cmd.Parameters["@TraiNghia"].Value = txtTraiNghia.Text;

                conn.Open();
                int soDongThemTu = cmd.ExecuteNonQuery();
                idTuMoi = cmd.Parameters["@idTu"].Value.ToString();
                conn.Close();
                conn.Dispose();

                // them nghia
                string themNghia = "EXEC ThemNghia @IdTuMoi , @IdTuLoai , @Nghia , @MoTa , @ViDu";
                int soDongThemNghia = DataProvider.Instance.ExecuteNonQuery(themNghia, new object[] { idTuMoi, cbbTuLoai.SelectedValue, txtNghia.Text, txtMoTa.Text, txtViDu.Text });
                if (soDongThemTu > 0 && soDongThemNghia > 0)
                {
                    RJMessageBox.Show("Thêm từ vựng thành công.");
                    //frmMain frmMain = new frmMain();
                    //frmMain.Load += new EventHandler(frmMain_Load);
                }
                else
                {
                    RJMessageBox.Show("Lỗi xảy ra!");
                }
            }
            catch (Exception ex)
            {
                RJMessageBox.Show(ex.Message);
            }
        }

        //private void frmMain_Load(object sender, EventArgs e)
        //{

        //}

        private void cbbChuyenNganh_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
