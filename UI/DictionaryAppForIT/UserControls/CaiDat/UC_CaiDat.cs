using Bunifu.UI.WinForms;
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

namespace DictionaryAppForIT.UserControls.CaiDat
{
    public partial class UC_CaiDat : UserControl
    {
        bool cham, binhthuong, nhanh;
        public UC_CaiDat()
        {
            InitializeComponent();
        }

        #region cài đặt chung
        public Guna2ToggleSwitch ButtonCheDoBanDem
        {
            get { return this.btnCheDoBanDem; }
            set { this.btnCheDoBanDem = value; }
        }
        public Guna2ToggleSwitch ButtonTuDongCapNhat
        {
            get { return this.btnTuDongCapNhat; }
            set { this.btnTuDongCapNhat = value; }
        }
        public Guna2ToggleSwitch ButtonTuDongXoaLS
        {
            get { return this.btnTuDongXoaLS; }
            set { this.btnTuDongXoaLS = value; }
        }
        #endregion

        #region Âm thanh
        public Guna2ToggleSwitch ButtonTuDongPhatAm
        {
            get { return this.btnTuDongPhatAm; }
            set { this.btnTuDongPhatAm = value; }
        }
        public bool RadioButtonChamHon
        {
            get { return this.rdChamHon.Checked; }
            set { this.rdChamHon.Checked = value; }
        }

        public bool RadioButtonBinhThuong
        {
            get { return this.rdBinhThuong.Checked; }
            set { this.rdBinhThuong.Checked = value; }
        }
        public bool RadioButtonNhanhHon
        {
            get { return this.rdNhanhHon.Checked; }
            set { this.rdNhanhHon.Checked = value; }
        }
        #endregion

        #region Thông báo
        public Guna2ToggleSwitch ButtonThongBao
        {
            get { return this.btnThongBao; }
            set { this.btnThongBao = value; }
        }
        public Guna2ToggleSwitch ButtonNhacHocTuVung
        {
            get { return this.btnNhacHocTuVung; }
            set { this.btnNhacHocTuVung = value; }
        }
        #endregion

        private void UC_CaiDat_Load(object sender, EventArgs e)
        {
            
        }

    }
}
