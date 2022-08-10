using DictionaryAppForIT.UserControls;
using DictionaryAppForIT.UserControls.GanDay;
using DictionaryAppForIT.UserControls.Home;
using DictionaryAppForIT.UserControls.YeuThich;
using Guna.UI2.WinForms;
using DictionaryAppForIT.Class;
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
        ////Control tạm
        Control ucRecent = new Control();

        ////Home
        UC_TraTu ucTraTu = new UC_TraTu();
        UC_Dich ucDich = new UC_Dich();
        UC_TVChuyenNganh ucTVChuyen = new UC_TVChuyenNganh();

        ////Lịch sử
        UC_LichSu ucLichSu = new UC_LichSu();

        ////Yêu thích
        UC_YeuThich ucYeuThich = new UC_YeuThich();

        //FlowLayoutPanel Tab
        FlowLayoutPanel flpTabRecent = new FlowLayoutPanel();

        //List
        List<Control> _listUC;
        List<FlowLayoutPanel> _listFlpTab;

        public frmMain()
        {
            InitializeComponent();

            _listUC = new List<Control>() { ucTraTu, ucDich, ucTVChuyen, ucLichSu, ucYeuThich };
            _listFlpTab = new List<FlowLayoutPanel>() { flpTabHome };

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

        private void btnHome_CheckedChanged(object sender, EventArgs e)
        {
            moveImageBox(sender);
            HideFlpTab(flpTabRecent);
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
        private void btnMinimize_Click(object sender, EventArgs e)
        {
            MainBtn.Minnimize(this);
        }
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
        #endregion

        //Các tab của nút Home
        #region home button tab click event

        ////Tab đầu tiên
        private void btnTraTu_Click(object sender, EventArgs e)
        {
            HideUC(ucRecent);
            ShowUC(ucTraTu);
        }

        ////Các Tab còn lại
        private void btnDichVB_Click(object sender, EventArgs e)
        {
            HideUC(ucRecent);
            ShowUC(ucDich);
        }

        private void btnTVChuyenNganh_Click(object sender, EventArgs e)
        {
            HideUC(ucRecent);
            ShowUC(ucTVChuyen);
        }
        #endregion

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

        private void btnInformation_Click(object sender, EventArgs e)
        {

        }
    }
}
