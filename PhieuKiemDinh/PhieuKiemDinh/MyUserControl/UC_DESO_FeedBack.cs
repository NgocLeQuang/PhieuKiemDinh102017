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
    public partial class UC_DESO_FeedBack : UserControl
    {
        public UC_DESO_FeedBack()
        {
            InitializeComponent();
        }
        public void ResetData()
        {
            txt_TruongSo01.Text = "";
            txt_TruongSo03.Text = "";
            txt_TruongSo04.Text = "";
            txt_TruongSo05.Text = "";
            txt_TruongSo06.Text = "";
            txt_TruongSo07.Text = "";
            txt_TruongSo08_1.Text = "";
            txt_TruongSo08_2.Text = "";
            txt_TruongSo09.Text = "";
            txt_TruongSo10.Text = "";
            txt_TruongSo11.Text = "";
            txt_TruongSo12.Text = "";
            txt_TruongSo13.Text = "";
            txt_TruongSo14.Text = "";
            txt_FlagError.Text = "";

            txt_TruongSo01.BackColor = Color.White;
            txt_TruongSo03.BackColor = Color.White;
            txt_TruongSo04.BackColor = Color.White;
            txt_TruongSo05.BackColor = Color.White;
            txt_TruongSo06.BackColor = Color.White;
            txt_TruongSo07.BackColor = Color.White;
            txt_TruongSo08_1.BackColor = Color.White;
            txt_TruongSo08_2.BackColor = Color.White;
            txt_TruongSo09.BackColor = Color.White;
            txt_TruongSo10.BackColor = Color.White;
            txt_TruongSo11.BackColor = Color.White;
            txt_TruongSo12.BackColor = Color.White;
            txt_TruongSo13.BackColor = Color.White;
            txt_TruongSo14.BackColor = Color.White;
            txt_FlagError.BackColor = Color.White;
        }

        public bool IsEmply()
        {
            if (string.IsNullOrEmpty(txt_TruongSo01.Text) &&
                string.IsNullOrEmpty(txt_TruongSo03.Text) &&
                string.IsNullOrEmpty(txt_TruongSo04.Text) &&
                string.IsNullOrEmpty(txt_TruongSo05.Text) &&
                string.IsNullOrEmpty(txt_TruongSo06.Text) &&
                string.IsNullOrEmpty(txt_TruongSo07.Text) &&
                string.IsNullOrEmpty(txt_TruongSo08_1.Text) &&
                string.IsNullOrEmpty(txt_TruongSo08_2.Text) &&
                string.IsNullOrEmpty(txt_TruongSo09.Text) &&
                string.IsNullOrEmpty(txt_TruongSo10.Text) &&
                string.IsNullOrEmpty(txt_TruongSo11.Text) &&
                string.IsNullOrEmpty(txt_TruongSo12.Text) &&
                string.IsNullOrEmpty(txt_TruongSo13.Text) &&
                string.IsNullOrEmpty(txt_TruongSo14.Text) &&
                string.IsNullOrEmpty(txt_FlagError.Text))
                return true;
            return false;
        }

        public void SetValue(DESO deso)
        {
            txt_TruongSo01.Text = deso.TruongSo01;
            txt_TruongSo03.Text = deso.TruongSo03;
            txt_TruongSo04.Text = deso.TruongSo04;
            txt_TruongSo05.Text = deso.TruongSo05;
            txt_TruongSo06.Text = deso.TruongSo06;
            txt_TruongSo07.Text = deso.TruongSo07;
            txt_TruongSo08_1.Text = deso.TruongSo08_1;
            txt_TruongSo08_2.Text = deso.TruongSo08_2;
            txt_TruongSo09.Text = deso.TruongSo09;
            txt_TruongSo10.Text = deso.TruongSo10;
            txt_TruongSo11.Text = deso.TruongSo11;
            txt_TruongSo12.Text = deso.TruongSo12;
            txt_TruongSo13.Text = deso.TruongSo13;
            txt_TruongSo14.Text = deso.TruongSo14;
            txt_FlagError.Text = deso.FlagError;
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

        public void LoadData(tbl_DeSo_BackUp data)
        {
            lb_Ussername.Text = data.UserName;
            txt_TruongSo01.Text = data.TruongSo01;
            txt_TruongSo03.Text = data.TruongSo03;
            txt_TruongSo04.Text = data.TruongSo04;
            txt_TruongSo05.Text = data.TruongSo05;
            txt_TruongSo06.Text = data.TruongSo06;
            txt_TruongSo07.Text = data.TruongSo07;
            txt_TruongSo08_1.Text = data.TruongSo08;
            txt_TruongSo08_2.Text = data.TruongSo08_2;
            txt_TruongSo09.Text = data.TruongSo09;
            txt_TruongSo10.Text = data.TruongSo10;
            txt_TruongSo11.Text = data.TruongSo11;
            txt_TruongSo12.Text = data.TruongSo12;
            txt_TruongSo13.Text = data.TruongSo13;
            txt_TruongSo14.Text = data.TruongSo14;
            txt_FlagError.Text = data.FlagError;
        }
        public void LoadDataChecker(tbl_DeSo data, string nameCheck)
        {
            lb_Ussername.Text = nameCheck;
            txt_TruongSo01.Text = data.TruongSo01;
            txt_TruongSo03.Text = data.TruongSo03;
            txt_TruongSo04.Text = data.TruongSo04;
            txt_TruongSo05.Text = data.TruongSo05;
            txt_TruongSo06.Text = data.TruongSo06;
            txt_TruongSo07.Text = data.TruongSo07;
            txt_TruongSo08_1.Text = data.TruongSo08;
            txt_TruongSo08_2.Text = data.TruongSo08_2;
            txt_TruongSo09.Text = data.TruongSo09;
            txt_TruongSo10.Text = data.TruongSo10;
            txt_TruongSo11.Text = data.TruongSo11;
            txt_TruongSo12.Text = data.TruongSo12;
            txt_TruongSo13.Text = data.TruongSo13;
            txt_TruongSo14.Text = data.TruongSo14;
            txt_FlagError.Text = data.FlagError;
        }
    }
}
