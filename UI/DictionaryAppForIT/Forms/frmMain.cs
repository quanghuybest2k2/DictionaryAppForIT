﻿using DictionaryAppForIT.Class;
using DictionaryAppForIT.UserControls;
using DictionaryAppForIT.UserControls.CaiDat;
using DictionaryAppForIT.UserControls.GanDay;
using DictionaryAppForIT.UserControls.Home;
using DictionaryAppForIT.UserControls.MiniGame;
using DictionaryAppForIT.UserControls.TaiKhoan;
using DictionaryAppForIT.UserControls.YeuThich;
using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DictionaryAppForIT.Forms
{
    public partial class frmMain : Form
    {
        //UserControl
        //--Control hiện hành
        Control ucRecent = new Control();
        //--Home
        UC_TraTu ucTraTu = new UC_TraTu();
        UC_Dich ucDich = new UC_Dich();
        UC_TVChuyenNganh ucTVChuyen = new UC_TVChuyenNganh();

        //--Lịch sử
        UC_LichSu ucLichSu = new UC_LichSu();

        //--Yêu thích
        UC_YeuThich ucYeuThich = new UC_YeuThich();

        //--Mini game
        UC_MiniGame ucMiniGame = new UC_MiniGame();

        //--Cài đặt
        UC_CaiDat ucCaiDat = new UC_CaiDat();

        //--Tài Khoản
        UC_QuanLyTK ucQuanLyTK = new UC_QuanLyTK();
        UC_PhanHoi ucPhanHoi = new UC_PhanHoi();
        UC_ThongBao ucThongBao = new UC_ThongBao();

        //FlowLayoutPanel Tab
        FlowLayoutPanel flpTabRecent = new FlowLayoutPanel();

        //List
        List<Control> _listUC;
        List<FlowLayoutPanel> _listFlpTab;

        public frmMain()
        {
            InitializeComponent();
            _listUC = new List<Control>() { ucTraTu, ucDich, ucTVChuyen, ucLichSu, ucYeuThich, ucMiniGame, ucCaiDat, ucQuanLyTK, ucThongBao, ucPhanHoi };
            _listFlpTab = new List<FlowLayoutPanel>() { flpTabHome, flpTabTaiKhoan };

            //Thêm uc vào panelContent
            foreach (var item in _listUC)
            {
                AddUCToPanel(item);
            }

            //Hiện uc Home đầu tiên
            btnHome.PerformClick();
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
        }

        private void btnYeuThich_Click(object sender, EventArgs e)
        {
            ShowUC(ucYeuThich);
        }

        private void btnMiniGame_Click(object sender, EventArgs e)
        {
            ShowUC(ucMiniGame);
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
            ShowUC(ucTraTu);
        }

        //--Các Tab còn lại
        private void btnDichVB_Click(object sender, EventArgs e)
        {
            ShowUC(ucDich);
        }

        private void btnTVChuyenNganh_Click(object sender, EventArgs e)
        {
            ShowUC(ucTVChuyen);
        }
        #endregion


        //Các tab của nút Tài khoản
        #region TaiKhoan button tab click event

        //--Tab đầu tiên
        private void btnQuanLyTK_Click(object sender, EventArgs e)
        {
            ShowUC(ucQuanLyTK);
        }

        //--Các Tab còn lại
        private void btnThongBao_Click(object sender, EventArgs e)
        {
            ShowUC(ucThongBao);
        }

        private void btnPhanHoi_Click(object sender, EventArgs e)
        {
            ShowUC(ucPhanHoi);
        }

        #endregion

        private void btnExit_Click(object sender, EventArgs e)
        {
            var result = RJMessageBox.Show("Bạn có chắc muốn thoát?",
              "Xác nhận",
              MessageBoxButtons.YesNo,
              MessageBoxIcon.Question);
            if (result == DialogResult.No)
            {
                return;
            }
            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void btnMinimize_Click(object sender, EventArgs e)
        {

        }

        private void btnDangXuat_Click(object sender, EventArgs e)
        {
            var result = RJMessageBox.Show("Bạn thực sự muốn đăng xuất?",
             "Xác nhận",
             MessageBoxButtons.YesNo,
             MessageBoxIcon.Question);
            if (result == DialogResult.No)
            {
                return;
            }
            if (result == DialogResult.Yes)
            {
                this.Hide();
                frmLogin frmLogin = new frmLogin();
                frmLogin.Show();
            }

        }
    }
}
