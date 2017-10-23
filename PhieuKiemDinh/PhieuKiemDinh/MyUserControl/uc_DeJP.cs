using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraRichEdit.Commands;

namespace PhieuKiemDinh.MyUserControl
{
    public partial class uc_DeJP : UserControl
    {
        public event AllTextChange Changed;
        public uc_DeJP()
        {
            InitializeComponent();
        }
        public void ResetData()
        {
            txt_TruongSo02.Text = string.Empty;
            txt_TruongSo02.BackColor = Color.White;
            
        }

        public bool IsEmpty()
        {
            if (string.IsNullOrEmpty(txt_TruongSo02.Text))
                return true;
            return false;
        }

        public void SetValue(string truongso02)
        {
            txt_TruongSo02.Text = truongso02;
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
        

        private void txt_TruongSo02_TextChanged(object sender, EventArgs e)
        {
            if (Changed != null)
                Changed(sender, e);
        }
    }
}
