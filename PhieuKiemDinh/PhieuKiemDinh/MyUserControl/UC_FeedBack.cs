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
    public partial class UC_FeedBack : UserControl
    {
        public UC_FeedBack()
        {
            InitializeComponent();
        }

        public void LoadImage(string fbatchname,string url_image,string idimage)
        {
            uc_PictureBox1.LoadImage(url_image, idimage, 35);
            uc_PictureBox1.imageBox1.SizeMode = ImageBoxSizeMode.Fit;
            LoadText_User(fbatchname, idimage);
            LoadChecker(fbatchname, idimage);
            SoSanhFeedBack();
        }
        
        public void LoadText_User(string fbatchname, string idimage)
        {
            var deso = (from w in Global.Db.tbl_DeSo_BackUps
                        where w.fBatchName == fbatchname && w.IdImage == idimage
                        select w).ToList();

            uC_DESO_FeedBack1.LoadData(deso[0]);
            uC_DESO_FeedBack2.LoadData(deso[1]);
        }

        public void LoadChecker(string fbatchname, string idimage)
        {
            var deso = (from w in Global.Db.tbl_DeSos
                        where w.fBatchName == fbatchname && w.IdImage == idimage && w.True == 1
                        select w).ToList();
            var nameCheck = (from w in Global.Db.GetNameCheck(idimage, fbatchname) select w.UserNameCheckDeSo).FirstOrDefault();
            uC_DESO_FeedBack3.LoadDataChecker(deso[0],nameCheck+"" );
                    }

      

        private void SoSanhTextBoxSingle()
        {
            changeColorUser(uC_DESO_FeedBack2.txt_TruongSo01, uC_DESO_FeedBack3.txt_TruongSo01);
            changeColorUser(uC_DESO_FeedBack2.txt_TruongSo03, uC_DESO_FeedBack3.txt_TruongSo03);
            changeColorUser(uC_DESO_FeedBack2.txt_TruongSo04, uC_DESO_FeedBack3.txt_TruongSo04);
            changeColorUser(uC_DESO_FeedBack2.txt_TruongSo05, uC_DESO_FeedBack3.txt_TruongSo05);
            changeColorUser(uC_DESO_FeedBack2.txt_TruongSo06, uC_DESO_FeedBack3.txt_TruongSo06);
            changeColorUser(uC_DESO_FeedBack2.txt_TruongSo07, uC_DESO_FeedBack3.txt_TruongSo07);
            changeColorUser(uC_DESO_FeedBack2.txt_TruongSo08_1, uC_DESO_FeedBack3.txt_TruongSo08_1);
            changeColorUser(uC_DESO_FeedBack2.txt_TruongSo08_2, uC_DESO_FeedBack3.txt_TruongSo08_2);
            changeColorUser(uC_DESO_FeedBack2.txt_TruongSo09, uC_DESO_FeedBack3.txt_TruongSo09);
            changeColorUser(uC_DESO_FeedBack2.txt_TruongSo10, uC_DESO_FeedBack3.txt_TruongSo10);
            changeColorUser(uC_DESO_FeedBack2.txt_TruongSo11, uC_DESO_FeedBack3.txt_TruongSo11);
            changeColorUser(uC_DESO_FeedBack2.txt_TruongSo12, uC_DESO_FeedBack3.txt_TruongSo12);
            changeColorUser(uC_DESO_FeedBack2.txt_TruongSo13, uC_DESO_FeedBack3.txt_TruongSo13);
            changeColorUser(uC_DESO_FeedBack2.txt_TruongSo14, uC_DESO_FeedBack3.txt_TruongSo14);
            changeColorUser(uC_DESO_FeedBack2.txt_FlagError, uC_DESO_FeedBack3.txt_FlagError);
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
        private void SoSanhFeedBack()
        {
            SoSanhDoiMau(uC_DESO_FeedBack1.txt_TruongSo01, uC_DESO_FeedBack2.txt_TruongSo01, uC_DESO_FeedBack3.txt_TruongSo01);
            SoSanhDoiMau(uC_DESO_FeedBack1.txt_TruongSo03, uC_DESO_FeedBack2.txt_TruongSo03, uC_DESO_FeedBack3.txt_TruongSo03);
            SoSanhDoiMau(uC_DESO_FeedBack1.txt_TruongSo04, uC_DESO_FeedBack2.txt_TruongSo04, uC_DESO_FeedBack3.txt_TruongSo04);
            SoSanhDoiMau(uC_DESO_FeedBack1.txt_TruongSo05, uC_DESO_FeedBack2.txt_TruongSo05, uC_DESO_FeedBack3.txt_TruongSo05);
            SoSanhDoiMau(uC_DESO_FeedBack1.txt_TruongSo06, uC_DESO_FeedBack2.txt_TruongSo06, uC_DESO_FeedBack3.txt_TruongSo06);
            SoSanhDoiMau(uC_DESO_FeedBack1.txt_TruongSo07, uC_DESO_FeedBack2.txt_TruongSo07, uC_DESO_FeedBack3.txt_TruongSo07);
            SoSanhDoiMau(uC_DESO_FeedBack1.txt_TruongSo08_1, uC_DESO_FeedBack2.txt_TruongSo08_1, uC_DESO_FeedBack3.txt_TruongSo08_1);
            SoSanhDoiMau(uC_DESO_FeedBack1.txt_TruongSo08_2, uC_DESO_FeedBack2.txt_TruongSo08_2, uC_DESO_FeedBack3.txt_TruongSo08_2);
            SoSanhDoiMau(uC_DESO_FeedBack1.txt_TruongSo09, uC_DESO_FeedBack2.txt_TruongSo09, uC_DESO_FeedBack3.txt_TruongSo09);
            SoSanhDoiMau(uC_DESO_FeedBack1.txt_TruongSo10, uC_DESO_FeedBack2.txt_TruongSo10, uC_DESO_FeedBack3.txt_TruongSo10);
            SoSanhDoiMau(uC_DESO_FeedBack1.txt_TruongSo11, uC_DESO_FeedBack2.txt_TruongSo11, uC_DESO_FeedBack3.txt_TruongSo11);
            SoSanhDoiMau(uC_DESO_FeedBack1.txt_TruongSo12, uC_DESO_FeedBack2.txt_TruongSo12, uC_DESO_FeedBack3.txt_TruongSo12);
            SoSanhDoiMau(uC_DESO_FeedBack1.txt_TruongSo13, uC_DESO_FeedBack2.txt_TruongSo13, uC_DESO_FeedBack3.txt_TruongSo13);
            SoSanhDoiMau(uC_DESO_FeedBack1.txt_TruongSo14, uC_DESO_FeedBack2.txt_TruongSo14, uC_DESO_FeedBack3.txt_TruongSo14);
            SoSanhDoiMau(uC_DESO_FeedBack1.txt_FlagError, uC_DESO_FeedBack2.txt_FlagError, uC_DESO_FeedBack3.txt_FlagError);
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
            var deso = (from w in Global.Db.tbl_DeSo_BackUps
                        where w.fBatchName == fbatchname && w.IdImage == idimage && w.UserName == user
                        select w).ToList();

            uC_DESO_FeedBack2.LoadData(deso[0]);
        }

        private void SoSanhChecker_UserSingle()
        {
            changeColorChecker(uC_DESO_FeedBack2.txt_TruongSo01, uC_DESO_FeedBack3.txt_TruongSo01);
            changeColorChecker(uC_DESO_FeedBack2.txt_TruongSo14, uC_DESO_FeedBack3.txt_TruongSo14);
            changeColorChecker(uC_DESO_FeedBack2.txt_TruongSo03, uC_DESO_FeedBack3.txt_TruongSo03);
            changeColorChecker(uC_DESO_FeedBack2.txt_TruongSo04, uC_DESO_FeedBack3.txt_TruongSo04);
            changeColorChecker(uC_DESO_FeedBack2.txt_TruongSo05, uC_DESO_FeedBack3.txt_TruongSo05);
            changeColorChecker(uC_DESO_FeedBack2.txt_TruongSo06, uC_DESO_FeedBack3.txt_TruongSo06);
            changeColorChecker(uC_DESO_FeedBack2.txt_TruongSo07, uC_DESO_FeedBack3.txt_TruongSo07);
            changeColorChecker(uC_DESO_FeedBack2.txt_TruongSo08_1, uC_DESO_FeedBack3.txt_TruongSo08_1);
            changeColorChecker(uC_DESO_FeedBack2.txt_TruongSo08_2, uC_DESO_FeedBack3.txt_TruongSo08_2);
            changeColorChecker(uC_DESO_FeedBack2.txt_TruongSo09, uC_DESO_FeedBack3.txt_TruongSo09);
            changeColorChecker(uC_DESO_FeedBack2.txt_TruongSo10, uC_DESO_FeedBack3.txt_TruongSo10);
            changeColorChecker(uC_DESO_FeedBack2.txt_TruongSo11, uC_DESO_FeedBack3.txt_TruongSo11);
            changeColorChecker(uC_DESO_FeedBack2.txt_TruongSo12, uC_DESO_FeedBack3.txt_TruongSo12);
            changeColorChecker(uC_DESO_FeedBack2.txt_TruongSo13, uC_DESO_FeedBack3.txt_TruongSo13);
            changeColorChecker(uC_DESO_FeedBack2.txt_TruongSo14, uC_DESO_FeedBack3.txt_TruongSo14);
            changeColorChecker(uC_DESO_FeedBack2.txt_FlagError, uC_DESO_FeedBack3.txt_FlagError);

        }
        private void SoSanhDoiMau(TextEdit txt1, TextEdit txt2, TextEdit txt3)
        {
            if ((txt1.Text!=txt3.Text)) {
                txt1.ForeColor = Color.White;
                txt1.BackColor = Color.Red;
                txt3.ForeColor = Color.White;
                txt3.BackColor = Color.Green;
                if (txt2.Text == txt3.Text)
                {
                    txt2.ForeColor = Color.White;
                    txt2.BackColor = Color.Green;
                }
            }
            if ((txt2.Text != txt3.Text))
            {
                txt2.ForeColor = Color.White;
                txt2.BackColor = Color.Red;
                txt3.ForeColor = Color.White;
                txt3.BackColor = Color.Green;
                if (txt1.Text == txt3.Text)
                {
                    txt1.ForeColor = Color.White;
                    txt1.BackColor = Color.Green;
                }
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
    }
}
