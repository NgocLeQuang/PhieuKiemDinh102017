using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using PhieuKiemDinh.MyClass;

namespace PhieuKiemDinh.MyUserControl
{
    public partial class UC_DEJP_FeedBack : UserControl
    {
        public UC_DEJP_FeedBack()
        {
            InitializeComponent();
        }
        public void ResetData()
        {
            txt_TruongSo02.Text = "";
           
            txt_TruongSo02.BackColor = Color.White;
        }

        public bool IsEmply()
        {
            if (string.IsNullOrEmpty(txt_TruongSo02.Text))
                return true;
            return false;
        }

        public void SetValue(DEJP dejp)
        {
            txt_TruongSo02.Text = dejp.TruongSo02;
        }

        private void DoiMau(int soByteBe, int soBytelon, TextEdit textBox)
        {
            if (!string.IsNullOrEmpty(textBox.Text))
            {
                if (textBox.Text != "?")
                {
                    if (textBox.Text.Length >= soByteBe && textBox.Text.Length <= soBytelon)
                    {
                        textBox.BackColor = Color.White;
                        textBox.ForeColor = Color.Black;
                    }
                    else
                    {
                        textBox.BackColor = Color.Red;
                        textBox.ForeColor = Color.White;
                    }
                }
                else
                {
                    textBox.BackColor = Color.White;
                    textBox.ForeColor = Color.Black;
                }
            }
            else
            {
                textBox.BackColor = Color.White;
                textBox.ForeColor = Color.Black;
            }
        }

        public void LoadData(tbl_DeJP_BackUp data)
        {
            lb_Ussername.Text = data.UserName;
            txt_TruongSo02.Text = data.TruongSo02;
        }
        public void LoadDataChecker(tbl_DeJP data)
        {
            lb_Ussername.Text = data.UserName;
            txt_TruongSo02.Text = data.TruongSo02;
        }
    }
}
