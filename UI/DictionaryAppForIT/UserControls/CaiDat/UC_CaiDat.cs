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
        public BunifuRadioButton RadioButtonChamHon
        {
            get { return this.rdChamHon; }
            set { this.rdChamHon = value; }
        }
        public BunifuRadioButton RadioButtonBinhThuong
        {
            get { return this.rdBinhThuong; }
            set { this.rdBinhThuong = value; }
        }
        public BunifuRadioButton RadioButtonNhanhHon
        {
            get { return this.rdNhanhHon; }
            set { this.rdNhanhHon = value; }
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

    }
}
