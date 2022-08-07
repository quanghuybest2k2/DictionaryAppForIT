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

namespace DictionaryAppForIT.UserControls.Home
{
    public partial class UC_Nghia : UserControl
    {
        static UC_Nghia _obj;
        public UC_Nghia()
        {
            InitializeComponent();
        }
        #region
        // goi qua uc khac
        public static UC_Nghia Instance
        {
            get
            {
                if (_obj == null)
                {
                    _obj = new UC_Nghia();
                }
                return _obj;
            }
        }
        public Guna2TextBox TextBoxTuLoai
        {
            get { return txtTuLoai; }
            set { txtTuLoai = value; }
        }
        #endregion
    }
}
