using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DictionaryAppForIT.Class;
using DictionaryAppForIT.DAL;
using DictionaryAppForIT.DTO;

namespace DictionaryAppForIT.UserControls.TaiKhoan
{
    public partial class UC_ThemTu : UserControl
    {
        private string connString = ConfigurationManager.ConnectionStrings["DictionaryApp"].ConnectionString;
        private string idTuMoi;

        UC_TT_ThemNghia ucThemNghia;
        int stt = 1;
        List<UC_TT_ThemNghia> _list;
        private int soDongThemTu;
        private int soDongThemNghia;
        public UC_ThemTu()
        {
            InitializeComponent();
            _list = new List<UC_TT_ThemNghia>();
            btnThemNghia.PerformClick();
        }
        private void LoadChuyenNganh()
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
        private void btnThemNghia_Click(object sender, EventArgs e)
        {

            ucThemNghia = new UC_TT_ThemNghia(stt);
            ucThemNghia.Dock = DockStyle.Top;
            pnNghia.Controls.Add(ucThemNghia);
            _list.Add(ucThemNghia);
            stt++;
            //MessageBox.Show(ucThemNghia.tx,"");
        }

        private void btnXoaNghia_Click(object sender, EventArgs e)
        {
            foreach (var item in _list)
            {
                if (item.XacNhanXoa)
                {
                    pnNghia.Controls.Remove(item);
                }
            }
        }

        private void btnThemTuMoi_Click(object sender, EventArgs e)
        {
            ThemTu();
            foreach (var item in _list)
            {
                if (!item.XacNhanXoa)
                {
                    ThemNghia(item);
                }
            }
            if (soDongThemTu > 0 && soDongThemNghia > 0)
            {
                RJMessageBox.Show("Thêm từ vựng thành công.");

            }
            else
            {
                RJMessageBox.Show("Không thể thêm từ vựng.");
            }
            btnMacDinh.PerformClick();
        }

        private void ThemNghia(UC_TT_ThemNghia uc)
        {
            string[] arr = uc.LayGiaTriControl();
            try
            {
                // them nghia
                string themNghia = "EXEC ThemNghia @IdTuMoi , @IdTuLoai , @Nghia , @MoTa , @ViDu";
                soDongThemNghia = DataProvider.Instance.ExecuteNonQuery(themNghia, new object[] { idTuMoi, arr[0], arr[1], arr[2], arr[3] });
            }
            catch (Exception ex)
            {
                RJMessageBox.Show(ex.Message);
            }
        }

        private void ThemTu()
        {
            try
            {
                SqlConnection conn = new SqlConnection(connString);
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "EXEC ThemTu @idTu output, @TenTu, @PhienAm, @ChuyenNganh, @DongNghia, @TraiNghia, @IDTK";
                cmd.Parameters.Add("@idTu", SqlDbType.Int);

                cmd.Parameters.Add("@TenTu", SqlDbType.VarChar, 100);
                cmd.Parameters.Add("@PhienAm", SqlDbType.NVarChar, 100);
                cmd.Parameters.Add("@ChuyenNganh", SqlDbType.Int);
                cmd.Parameters.Add("@DongNghia", SqlDbType.VarChar, 1000);
                cmd.Parameters.Add("@TraiNghia", SqlDbType.VarChar, 1000);
                cmd.Parameters.Add("@IDTK", SqlDbType.Int);

                cmd.Parameters["@idTu"].Direction = ParameterDirection.Output;
                //
                cmd.Parameters["@TenTu"].Value = txtTuVung.Text.Trim();
                cmd.Parameters["@PhienAm"].Value = $"{txtPhienAm.Text.Trim()}";
                cmd.Parameters["@ChuyenNganh"].Value = cbbChuyenNganh.SelectedValue;
                cmd.Parameters["@DongNghia"].Value = txtDongNghia.Text.Trim();
                cmd.Parameters["@TraiNghia"].Value = txtTraiNghia.Text.Trim();
                cmd.Parameters["@IDTK"].Value = Class_TaiKhoan.IdTaiKhoan;

                conn.Open();
                soDongThemTu = cmd.ExecuteNonQuery();
                idTuMoi = cmd.Parameters["@idTu"].Value.ToString();
                conn.Close();
                conn.Dispose();
            }
            catch (Exception ex)
            {
                RJMessageBox.Show(ex.Message);
            }
        }

        private void UC_ThemTu_Load(object sender, EventArgs e)
        {
            LoadChuyenNganh();
            cbbChuyenNganh.SelectedIndex = 0;
        }

        private void btnMacDinh_Click(object sender, EventArgs e)
        {
            txtTuVung.Clear();
            txtPhienAm.Clear();
            txtDongNghia.Clear();
            txtTraiNghia.Clear();
            //foreach (var item in _list)
            //{
            //    //pnNghia.Controls
            //    //item.MacDinh();
            //}
            pnNghia.Controls.Clear();
            _list.Clear();
            stt = 1;
            btnThemNghia.PerformClick();

        }
    }
}
