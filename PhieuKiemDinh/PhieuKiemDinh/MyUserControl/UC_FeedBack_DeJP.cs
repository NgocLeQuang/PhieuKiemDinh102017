using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using ImageGlass;

namespace PhieuKiemDinh.MyUserControl
{
    public partial class UC_FeedBack_DeJP : UserControl
    {
        public UC_FeedBack_DeJP()
        {
            InitializeComponent();
        }

        public void LoadImage(string fbatchname, string url_image, string idimage)
        {
            uc_PictureBox1.LoadImage(url_image,idimage,30);
            uc_PictureBox1.imageBox1.SizeMode = ImageBoxSizeMode.Fit;
            LoadText_User(fbatchname, idimage);
            LoadChecker(fbatchname, idimage);
            SoSanhTextBox();
            SoSanhChecker();
        }

        public void LoadText_User(string fbatchname, string idimage)
        {
            var dejp = (from w in Global.DbKiemDinhXe.tbl_DeJP_BackUps
                        where w.fBatchName == fbatchname && w.IdImage == idimage
                        select w).ToList();

            uC_DEJP_FeedBack1.LoadData(dejp[0]);
            uC_DEJP_FeedBack2.LoadData(dejp[1]);
        }

        public void LoadChecker(string fbatchname, string idimage)
        {
            var dejp = (from w in Global.DbKiemDinhXe.tbl_DeJPs
                        where w.fBatchName == fbatchname && w.IdImage == idimage
                        select w).ToList();

            uC_DEJP_FeedBack3.LoadDataChecker(dejp[0]);
        }

        private void SoSanhTextBox()
        {
            changeColorUser(uC_DEJP_FeedBack1.txt_TruongSo02, uC_DEJP_FeedBack2.txt_TruongSo02);
        }

        private void SoSanhTextBoxSingle()
        {
            changeColorUser(uC_DEJP_FeedBack2.txt_TruongSo02, uC_DEJP_FeedBack3.txt_TruongSo02);
        }

        private void SoSanhChecker()
        {
            changeColorChecker(uC_DEJP_FeedBack1.txt_TruongSo02, uC_DEJP_FeedBack3.txt_TruongSo02);
            changeColorChecker(uC_DEJP_FeedBack2.txt_TruongSo02, uC_DEJP_FeedBack3.txt_TruongSo02);
        }
        private void changeColorUser(TextEdit txt1, TextEdit txt2)
        {
            if (txt1.Text != txt2.Text)
            {
                txt1.ForeColor = Color.White;
                txt1.BackColor = Color.Red;
                txt2.ForeColor = Color.White;
                txt2.BackColor = Color.Red;
            }
            else
            {
                txt1.ForeColor = Color.Black;
                txt1.BackColor = Color.White;
                txt2.ForeColor = Color.Black;
                txt2.BackColor = Color.White;
            }
        }

        private void changeColorChecker(TextEdit txt1, TextEdit txt2)
        {
            if (txt1.ForeColor == Color.White)
            {
                if (txt1.Text == txt2.Text)
                {
                    txt1.ForeColor = Color.White;
                    txt1.BackColor = Color.Green;
                    txt2.ForeColor = Color.White;
                    txt2.BackColor = Color.Green;
                }
                else
                {
                    txt2.ForeColor = Color.White;
                    txt2.BackColor = Color.Green;
                }
            }
        }

        public void LoadImageUser(string user, string fbatchname, string url_image, string idimage)
        {
            uc_PictureBox1.LoadImage(url_image, idimage, 30);
            uc_PictureBox1.imageBox1.SizeMode = ImageBoxSizeMode.Fit;
            LoadText_User(user, fbatchname, idimage);
            LoadChecker(fbatchname, idimage);
            SoSanhTextBoxSingle();
            SoSanhChecker_UserSingle();
        }

        public void LoadText_User(string user, string fbatchname, string idimage)
        {
            var dejp = (from w in Global.DbKiemDinhXe.tbl_DeJP_BackUps
                        where w.fBatchName == fbatchname && w.IdImage == idimage && w.UserName == user
                        select w).ToList();
            uC_DEJP_FeedBack2.LoadData(dejp[0]);
        }

        public void SoSanhChecker_UserSingle()
        {
            changeColorChecker(uC_DEJP_FeedBack2.txt_TruongSo02, uC_DEJP_FeedBack3.txt_TruongSo02);
        }
    }
}
