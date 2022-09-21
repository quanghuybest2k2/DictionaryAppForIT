﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DictionaryAppForIT.UserControls.YeuThich
{
    public partial class UC_YT_VanBan : UserControl
    {
        public UC_YT_VanBan()
        {
            InitializeComponent();
        }

        public UC_YT_VanBan(string stt, string tiengAnh, string tiengViet)
        {
            InitializeComponent();
            this.STT = stt;
            this.VBTiengAnh = tiengAnh;
            this.VBTiengViet = tiengViet;
        }

        public string STT
        {
            get { return lblSo.Text; }
            set { lblSo.Text = value; }
        }

        public string VBTiengAnh
        {
            get { return lblTiengAnh.Text; }
            set { lblTiengAnh.Text = value; }
        }

        public string VBTiengViet
        {
            get { return lblTiengViet.Text; }
            set { lblTiengViet.Text = value; }
        }

        public void VBBackColor(string color)
        {
            guna2pbNen1.FillColor = Color.FromName(color);
            guna2pbNen2.FillColor = Color.FromName(color);
            pnNen.BackColor = Color.FromName(color);
        }
    }
}
