using DictionaryAppForIT.Class;
using DictionaryAppForIT.CustomMessageBox;
using DictionaryAppForIT.DAL;
using DictionaryAppForIT.DTO;
using DictionaryAppForIT.UserControls;
using DictionaryAppForIT.UserControls.CaiDat;
using DictionaryAppForIT.UserControls.GanDay;
using DictionaryAppForIT.UserControls.Home;
using DictionaryAppForIT.UserControls.MiniGame;
using DictionaryAppForIT.UserControls.TaiKhoan;
using DictionaryAppForIT.UserControls.TuVungHot;
using DictionaryAppForIT.UserControls.YeuThich;
using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace DictionaryAppForIT.Forms
{
    public partial class frmMain : Form
    {
        //public string soMucYeuThich;
        //pnTaiKhoan
        int width_pnTaiKhoan;

        // Thông báo
        bool CoThongBao = true;

        //UserControl
        //--Control hiện hành
        Control ucRecent = new Control();
        //--Home
        UC_TraTu ucTraTu = new UC_TraTu();
        UC_Dich ucDich = new UC_Dich();
        UC_TVChuyenNganh ucTVChuyen = new UC_TVChuyenNganh();
        UC_TVHot ucTVHot = new UC_TVHot();

        //--Lịch sử
        UC_LichSu ucLichSu = new UC_LichSu();

        //--Yêu thích
        UC_YeuThich ucYeuThich = new UC_YeuThich();

        //--Mini game
        UC_StartMiniGame ucStartMiniGame = new UC_StartMiniGame();
        //UC_MiniGame ucMiniGame = new UC_MiniGame();
        //UC_LayoutMiniGame ucLayoutMiniGame = new UC_LayoutMiniGame();

        //--Cài đặt
        UC_CaiDat ucCaiDat = new UC_CaiDat();

        //--Tài Khoản
        UC_QuanLyTK ucQuanLyTK = new UC_QuanLyTK();
        UC_PhanHoi ucPhanHoi = new UC_PhanHoi();
        UC_ThemTu ucThemTu = new UC_ThemTu();

        //FlowLayoutPanel Tab
        FlowLayoutPanel flpTabRecent = new FlowLayoutPanel();

        //List
        List<Control> _listUC;
        List<FlowLayoutPanel> _listFlpTab;

        public frmMain()
        {
            InitializeComponent();
            _listUC = new List<Control>() { ucTraTu, ucDich, ucTVChuyen, ucLichSu, ucYeuThich, ucStartMiniGame, ucCaiDat, ucQuanLyTK, ucPhanHoi, ucThemTu, ucTVHot };
            _listFlpTab = new List<FlowLayoutPanel>() { flpTabHome, flpTabTaiKhoan };
            //Thêm uc vào panelContent
            foreach (var item in _listUC)
            {
                AddUCToPanel(item);
            }

            //Hiện uc Home đầu tiên
            btnHome.PerformClick();

            //Kiểm tra thông báo
            KiemTraThongBao();
        }
        private void frmMain_Load(object sender, EventArgs e)
        {
            //this.Show();
            //frmLogin dlg = new frmLogin();
            //if (dlg.ShowDialog() != DialogResult.OK)
            //{
            //    Application.Exit();
            //    return;
            //}
            //Tự động chỉnh lại width của label tên tài khoản
            lblTenTaiKhoan.Text = Class_TaiKhoan.displayUsername;
            // Tối thiểu 7 kí tự
            // Tối đa 15 kí tự
            width_pnTaiKhoan = pnTaiKhoan.MinimumSize.Width + lblTenTaiKhoan.Width + 20;
        }

        //Các hàm của UserControl
        #region uc function
        private void AddUCToPanel(Control c)
        {
            pnContent.Controls.Add(c);
            c.Dock = DockStyle.Fill;
            c.Visible = false;
        }

        private void ShowUC(Control c)
        {
            c.Visible = true;
            c.BringToFront();
            ucRecent = c;
        }

        private void HideUC(Control r)
        {
            foreach (var item in _listUC)
            {
                if (item.GetType() == r.GetType())
                    item.Visible = false;
            }
        }
        #endregion


        //Các hàm của FlowLayoutPanel tab
        #region flpTab function

        private void ShowFlpTab(FlowLayoutPanel f)
        {
            f.Visible = true;
            flpTabRecent = f;
        }

        private void HideFlpTab(FlowLayoutPanel r)
        {
            foreach (var item in _listFlpTab)
            {
                if (item.GetType() == r.GetType())
                    item.Visible = false;
            }
        }
        #endregion


        //Sự kiện hover pnTaiKhoan
        #region Hover pnTaiKhoan
        private void timerMoRong_pnTaiKhoan_Tick(object sender, EventArgs e)
        {
            pnTaiKhoan.Width += 10;
            if (pnTaiKhoan.Width >= width_pnTaiKhoan)
            {
                timerMoRong_pnTaiKhoan.Stop();
            }
        }

        private void timerThuGon_pnTaiKhoan_Tick(object sender, EventArgs e)
        {
            pnTaiKhoan.Width -= 10;
            if (pnTaiKhoan.Width == pnTaiKhoan.MinimumSize.Width)
            {
                timerThuGon_pnTaiKhoan.Stop();
            }
        }

        private void pnTaiKhoan_MouseHover(object sender, EventArgs e)
        {
            timerThuGon_pnTaiKhoan.Stop();
            timerMoRong_pnTaiKhoan.Start();
        }

        private void pnTaiKhoan_MouseLeave(object sender, EventArgs e)
        {
            timerMoRong_pnTaiKhoan.Stop();
            timerThuGon_pnTaiKhoan.Start();
        }
        #endregion


        //Icon thông báo
        #region btnThongBao
        private void KiemTraThongBao()
        {
            if (CoThongBao)
            {
                btnThongBao_Unchecked.Visible = true;
                btnThongBao_Checked.Visible = false;
                //btnThongBao.Image = Properties.Resources.speaker
            }
            else
            {
                btnThongBao_Checked.Visible = true;
                btnThongBao_Unchecked.Visible = false;
            }
        }

        private void btnThongBao_Click(object sender, EventArgs e)
        {
            frmThongBao frm = new frmThongBao();
            frm.Show();
            CoThongBao = false;
            KiemTraThongBao();
        }
        #endregion


        //Tạo hiệu ứng cho các nút sidebar
        #region Button style
        private void moveImageBox(object sender)
        {
            Guna2Button btn = (Guna2Button)sender;
            pbImageSlide.Location = new Point(btn.Location.X + 124, btn.Location.Y - 30);
            pbImageSlide.SendToBack();
        }
        #endregion


        //Sự kiện CheckedChanged của nút sidebar và tab
        #region Main button + tab CheckedChanged event
        //--Sự kiện checkedChanged nút sidebar
        private void btnSidebar_CheckedChanged(object sender, EventArgs e)
        {
            moveImageBox(sender);
            HideFlpTab(flpTabRecent);
            HideUC(ucRecent);
        }

        //--Sự kiện checkedChanged nút tab 
        private void btnTab_CheckedChanged(object sender, EventArgs e)
        {
            HideUC(ucRecent);
        }

        #endregion


        //Các nút chức năng sidebar
        #region sidebar button click event
        private void btnHome_Click(object sender, EventArgs e)
        {
            ShowFlpTab(flpTabHome);
            btnTraTu.PerformClick();
        }

        private void btnLichSu_Click(object sender, EventArgs e)
        {
            ShowUC(ucLichSu);
            ucLichSu.TuHienTai = "";
            ucLichSu.HienThiLSTraTu();
            ucLichSu.HienThiLSDich();
        }

        private void btnYeuThich_Click(object sender, EventArgs e)
        {
            ShowUC(ucYeuThich);
            ucYeuThich.HienThiYTTraTu();
            ucYeuThich.HienThiYTVanBan();
            ucYeuThich.SoMuc = Tong_So_Muc_Yeu_Thich();
        }

        private void btnMiniGame_Click(object sender, EventArgs e)
        {
            //ShowUC(ucMiniGame);
            ShowUC(ucStartMiniGame);

        }

        private void btnCaiDat_Click(object sender, EventArgs e)
        {
            //guna2Transition1.ShowSync(ucCaiDat, true, Guna.UI2.AnimatorNS.Animation.HorizSlide);
            ShowUC(ucCaiDat);
        }

        private void btnTaiKhoan_Click(object sender, EventArgs e)
        {
            ShowFlpTab(flpTabTaiKhoan);
            btnQuanLyTK.PerformClick();
        }
        #endregion


        //Các tab của nút Home
        #region home button tab click event

        //--Tab đầu tiên
        private void btnTraTu_Click(object sender, EventArgs e)
        {
            ucTraTu.ThayDoiMauGiaoDien(ucCaiDat.ButtonCheDoBanDem);
            ucTraTu.GoiYTimKiem();
            KiemTraThayDoiTocDoTraTu();
            // Nhấn tự động phát âm
            ucTraTu.tocDoPhatAm = ucCaiDat.tuDongPhatAm;
            ShowUC(ucTraTu);
        }
        //--Thay đổi tốc độ UC_TraTu
        private void KiemTraThayDoiTocDoTraTu()
        {
            if (ucCaiDat.thayDoiTocDo)
            {
                ucTraTu.thayDoiTocDo = true;
                ucTraTu.tocDo = ucCaiDat.tocDo;
            }
        }
        //--Các Tab còn lại
        private void btnDichVB_Click(object sender, EventArgs e)
        {
            KiemTraThayDoiTocDoDich();
            ShowUC(ucDich);
        }
        //--Thay đổi tốc độ UC_dich
        private void KiemTraThayDoiTocDoDich()
        {
            if (ucCaiDat.thayDoiTocDo)
            {
                ucDich.thayDoiTocDo = true;
                ucDich.tocDo = ucCaiDat.tocDo;
            }
        }
        private void btnTVChuyenNganh_Click(object sender, EventArgs e)
        {
            KiemTraThayDoiTocDoChuyenNganh();
            ShowUC(ucTVChuyen);
        }
        //--Thay đổi tốc độ UC_Từ vựng chuyên ngành
        private void KiemTraThayDoiTocDoChuyenNganh()
        {
            if (ucCaiDat.thayDoiTocDo)
            {
                ucTVChuyen.thayDoiTocDo = true;
                ucTVChuyen.tocDo = ucCaiDat.tocDo;

            }
        }
        #endregion


        //Các tab của nút Tài khoản
        #region TaiKhoan button tab click event

        //--Tab đầu tiên
        public static string Tong_So_Muc_Yeu_Thich()
        {
            string query = $"select sum(AllCount) AS Tong_SoMucYeuThich from((select count(*) AS AllCount from YeuThichTuVung where IDTK = {Class_TaiKhoan.IdTaiKhoan}) union all (select count(*) AS AllCount from YeuThichVanBan where IDTK = {Class_TaiKhoan.IdTaiKhoan}))t";
            object soMuc = DataProvider.Instance.ExecuteScalar(query);
            return soMuc.ToString();
        }
        private void btnQuanLyTK_Click(object sender, EventArgs e)
        {
            ucQuanLyTK.SoMuc = Tong_So_Muc_Yeu_Thich();
            ShowUC(ucQuanLyTK);
        }

        //--Các Tab còn lại
        private void btnPhanHoi_Click(object sender, EventArgs e)
        {
            ShowUC(ucPhanHoi);
        }
        private void btnThemTu_Click(object sender, EventArgs e)
        {
            ShowUC(ucThemTu);
        }
        #endregion

        //Nút đăng xuất
        private void btnDangXuat_Click(object sender, EventArgs e)
        {
            //var frm = new frmMSG_DangXuat();
            //frm.Show();
            var result = RJMessageBox.Show("Bạn có chắc muốn đăng xuất?",
               "Đăng xuất",
               MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (result == DialogResult.Yes)
            {
                this.Hide();
                frmLogin frmLogin = new frmLogin();
                frmLogin.Show();
            }
            if (result == DialogResult.No)
            {
                return;
            }
        }


        //Các nút chính của frmMain
        #region Các nút chính
        private void btnExit_Click(object sender, EventArgs e)
        {
            var frm = new frmMSG_Exit();
            frm.Show();
            //Application.Exit();
        }

        private void btnMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnMaximum_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            //this.MaximizeBox = false;
        }

        #endregion

        private void pbTaiKhoan_Click(object sender, EventArgs e)
        {
            btnTaiKhoan.PerformClick();
        }

        private void btnThemTuMini_Click(object sender, EventArgs e)
        {
            btnTaiKhoan.PerformClick();
            btnThemTu.PerformClick();
        }

        private void btnTVHot_Click(object sender, EventArgs e)
        {
            ShowUC(ucTVHot);
            ucTVHot.HienThiTuVungHot();
        }

        private void btnThongTinTacGia_Click(object sender, EventArgs e)
        {
            Process.Start("https://quanghuybest2k2.github.io/TimEmailGiangVien.github.io/");
        }
    }
}
