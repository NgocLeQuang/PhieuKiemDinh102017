using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using PhieuKiemDinh.MyClass;
using PhieuKiemDinh.Properties;

namespace PhieuKiemDinh.MyForm
{
    public partial class ShowImage : DevExpress.XtraEditors.XtraForm
    {
        public ShowImage()
        {
            InitializeComponent();
        }

        public string FBatchName = "";
        public string IdImage = "";
        private void SoSanhDoiMau(TextEdit txt1, TextEdit txt2, TextEdit txt3)
        {
            if ((txt1.Text != txt2.Text))
            {
                txt2.ForeColor = Color.White;
                txt2.BackColor = Color.Red;
                txt1.ForeColor = Color.White;
                txt1.BackColor = Color.Green;
                if (txt3.Text == txt1.Text)
                {
                    txt3.ForeColor = Color.White;
                    txt3.BackColor = Color.Green;
                }
            }
            if ((txt1.Text != txt3.Text))
            {
                txt3.ForeColor = Color.White;
                txt3.BackColor = Color.Red;
                txt1.ForeColor = Color.White;
                txt1.BackColor = Color.Green;
                if (txt1.Text == txt2.Text)
                {
                    txt2.ForeColor = Color.White;
                    txt2.BackColor = Color.Green;
                }
            }
        }
        private void ShowImage_Load(object sender, EventArgs e)
        {
            lb_Batch.Text = FBatchName;
            lb_Image.Text = IdImage;
            uc_PictureBox1.LoadImage(Global.Webservice + FBatchName + "/" + IdImage, IdImage, Settings.Default.ZoomImage);
            var data = (from w in Global.Db.GetDataShowToCheck(FBatchName,IdImage)
                                  select new
                                  {
                                      w.UserName,
                                      w.TruongSo01,
                                      w.TruongSo03,
                                      w.TruongSo04,
                                      w.TruongSo05,
                                      w.TruongSo06,
                                      w.TruongSo07,
                                      w.TruongSo08,
                                      w.TruongSo08_2,
                                      w.TruongSo09,
                                      w.TruongSo10,
                                      w.TruongSo11,
                                      w.TruongSo12,
                                      w.TruongSo13,
                                      w.TruongSo14,
                                      w.STT,
                                      w.True
                                  }).ToList();

            //Load check
            uC_ShowImage1.lb_UserCheck.Text = "Check: " + data[0].UserName;
            uC_ShowImage1.uc_DeSo1.txt_TruongSo01.Text = data[0].TruongSo01;
            uC_ShowImage1.uc_DeSo1.txt_TruongSo03.Text = data[0].TruongSo03;
            uC_ShowImage1.uc_DeSo1.txt_TruongSo04.Text = data[0].TruongSo04;
            uC_ShowImage1.uc_DeSo1.txt_TruongSo05.Text = data[0].TruongSo05;
            uC_ShowImage1.uc_DeSo1.txt_TruongSo06.Text = data[0].TruongSo06;
            uC_ShowImage1.uc_DeSo1.txt_TruongSo07.Text = data[0].TruongSo07;
            uC_ShowImage1.uc_DeSo1.txt_TruongSo08_1.Text = data[0].TruongSo08;
            uC_ShowImage1.uc_DeSo1.txt_TruongSo08_2.Text = data[0].TruongSo08_2;
            uC_ShowImage1.uc_DeSo1.txt_TruongSo09.Text = data[0].TruongSo09;
            uC_ShowImage1.uc_DeSo1.txt_TruongSo10.Text = data[0].TruongSo10;
            uC_ShowImage1.uc_DeSo1.txt_TruongSo11.Text = data[0].TruongSo11;
            uC_ShowImage1.uc_DeSo1.txt_TruongSo12.Text = data[0].TruongSo12;
            uC_ShowImage1.uc_DeSo1.txt_TruongSo13.Text = data[0].TruongSo13;
            uC_ShowImage1.uc_DeSo1.txt_TruongSo14.Text = data[0].TruongSo14;

            //Load user 1
            uC_ShowImage1.lb_User1.Text = data[1].UserName;
            uC_ShowImage1.uc_DeSo2.txt_TruongSo01.Text = data[1].TruongSo01;
            uC_ShowImage1.uc_DeSo2.txt_TruongSo03.Text = data[1].TruongSo03;
            uC_ShowImage1.uc_DeSo2.txt_TruongSo04.Text = data[1].TruongSo04;
            uC_ShowImage1.uc_DeSo2.txt_TruongSo05.Text = data[1].TruongSo05;
            uC_ShowImage1.uc_DeSo2.txt_TruongSo06.Text = data[1].TruongSo06;
            uC_ShowImage1.uc_DeSo2.txt_TruongSo07.Text = data[1].TruongSo07;
            uC_ShowImage1.uc_DeSo2.txt_TruongSo08_1.Text = data[1].TruongSo08;
            uC_ShowImage1.uc_DeSo2.txt_TruongSo08_2.Text = data[1].TruongSo08_2;
            uC_ShowImage1.uc_DeSo2.txt_TruongSo09.Text = data[1].TruongSo09;
            uC_ShowImage1.uc_DeSo2.txt_TruongSo10.Text = data[1].TruongSo10;
            uC_ShowImage1.uc_DeSo2.txt_TruongSo11.Text = data[1].TruongSo11;
            uC_ShowImage1.uc_DeSo2.txt_TruongSo12.Text = data[1].TruongSo12;
            uC_ShowImage1.uc_DeSo2.txt_TruongSo13.Text = data[1].TruongSo13;
            uC_ShowImage1.uc_DeSo2.txt_TruongSo14.Text = data[1].TruongSo14;

            //Load user 2
            uC_ShowImage1.lb_User2.Text = data[2].UserName;
            uC_ShowImage1.uc_DeSo3.txt_TruongSo01.Text = data[2].TruongSo01;
            uC_ShowImage1.uc_DeSo3.txt_TruongSo03.Text = data[2].TruongSo03;
            uC_ShowImage1.uc_DeSo3.txt_TruongSo04.Text = data[2].TruongSo04;
            uC_ShowImage1.uc_DeSo3.txt_TruongSo05.Text = data[2].TruongSo05;
            uC_ShowImage1.uc_DeSo3.txt_TruongSo06.Text = data[2].TruongSo06;
            uC_ShowImage1.uc_DeSo3.txt_TruongSo07.Text = data[2].TruongSo07;
            uC_ShowImage1.uc_DeSo3.txt_TruongSo08_1.Text = data[2].TruongSo08;
            uC_ShowImage1.uc_DeSo3.txt_TruongSo08_2.Text = data[2].TruongSo08_2;
            uC_ShowImage1.uc_DeSo3.txt_TruongSo09.Text = data[2].TruongSo09;
            uC_ShowImage1.uc_DeSo3.txt_TruongSo10.Text = data[2].TruongSo10;
            uC_ShowImage1.uc_DeSo3.txt_TruongSo11.Text = data[2].TruongSo11;
            uC_ShowImage1.uc_DeSo3.txt_TruongSo12.Text = data[2].TruongSo12;
            uC_ShowImage1.uc_DeSo3.txt_TruongSo13.Text = data[2].TruongSo13;
            uC_ShowImage1.uc_DeSo3.txt_TruongSo14.Text = data[2].TruongSo14;
            SoSanhDoiMau(uC_ShowImage1.uc_DeSo1.txt_TruongSo01, uC_ShowImage1.uc_DeSo2.txt_TruongSo01, uC_ShowImage1.uc_DeSo3.txt_TruongSo01);
            SoSanhDoiMau(uC_ShowImage1.uc_DeSo1.txt_TruongSo03, uC_ShowImage1.uc_DeSo2.txt_TruongSo03, uC_ShowImage1.uc_DeSo3.txt_TruongSo03);
            SoSanhDoiMau(uC_ShowImage1.uc_DeSo1.txt_TruongSo04, uC_ShowImage1.uc_DeSo2.txt_TruongSo04, uC_ShowImage1.uc_DeSo3.txt_TruongSo04);
            SoSanhDoiMau(uC_ShowImage1.uc_DeSo1.txt_TruongSo05, uC_ShowImage1.uc_DeSo2.txt_TruongSo05, uC_ShowImage1.uc_DeSo3.txt_TruongSo05);
            SoSanhDoiMau(uC_ShowImage1.uc_DeSo1.txt_TruongSo06, uC_ShowImage1.uc_DeSo2.txt_TruongSo06, uC_ShowImage1.uc_DeSo3.txt_TruongSo06);
            SoSanhDoiMau(uC_ShowImage1.uc_DeSo1.txt_TruongSo07, uC_ShowImage1.uc_DeSo2.txt_TruongSo07, uC_ShowImage1.uc_DeSo3.txt_TruongSo07);
            SoSanhDoiMau(uC_ShowImage1.uc_DeSo1.txt_TruongSo08_1, uC_ShowImage1.uc_DeSo2.txt_TruongSo08_1, uC_ShowImage1.uc_DeSo3.txt_TruongSo08_1);
            SoSanhDoiMau(uC_ShowImage1.uc_DeSo1.txt_TruongSo08_2, uC_ShowImage1.uc_DeSo2.txt_TruongSo08_2, uC_ShowImage1.uc_DeSo3.txt_TruongSo08_2);
            SoSanhDoiMau(uC_ShowImage1.uc_DeSo1.txt_TruongSo09, uC_ShowImage1.uc_DeSo2.txt_TruongSo09, uC_ShowImage1.uc_DeSo3.txt_TruongSo09);
            SoSanhDoiMau(uC_ShowImage1.uc_DeSo1.txt_TruongSo10, uC_ShowImage1.uc_DeSo2.txt_TruongSo10, uC_ShowImage1.uc_DeSo3.txt_TruongSo10);
            SoSanhDoiMau(uC_ShowImage1.uc_DeSo1.txt_TruongSo11, uC_ShowImage1.uc_DeSo2.txt_TruongSo11, uC_ShowImage1.uc_DeSo3.txt_TruongSo11);
            SoSanhDoiMau(uC_ShowImage1.uc_DeSo1.txt_TruongSo12, uC_ShowImage1.uc_DeSo2.txt_TruongSo12, uC_ShowImage1.uc_DeSo3.txt_TruongSo12);
            SoSanhDoiMau(uC_ShowImage1.uc_DeSo1.txt_TruongSo13, uC_ShowImage1.uc_DeSo2.txt_TruongSo13, uC_ShowImage1.uc_DeSo3.txt_TruongSo13);
            SoSanhDoiMau(uC_ShowImage1.uc_DeSo1.txt_TruongSo14, uC_ShowImage1.uc_DeSo2.txt_TruongSo14, uC_ShowImage1.uc_DeSo3.txt_TruongSo14);

        }

        private void lb_Batch_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(lb_Batch.Text);
            XtraMessageBox.Show("Copy batch name Success!");
        }

        private void lb_Image_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(lb_Image.Text);
            XtraMessageBox.Show("Copy batch name Success!");
        }
    }
}