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

        private void ShowImage_Load(object sender, EventArgs e)
        {
            uc_PictureBox1.LoadImage(Global.Webservice + FBatchName + "/" + IdImage, IdImage, Settings.Default.ZoomImage);
            var dataBeforeEdit = (from w in Global.Db.tbl_DeSo_BackUps
                where w.fBatchName == FBatchName && w.IdImage == IdImage
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
                    w.TruongSo09,
                    w.TruongSo10,
                    w.TruongSo11,
                    w.TruongSo12,
                    w.TruongSo13,
                    w.TruongSo14,
                    w.FlagError
                }).ToList();
            var dataAlterEdit = (from w in Global.Db.tbl_DeSos
                                  where w.fBatchName == FBatchName && w.IdImage == IdImage
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
                                      w.TruongSo09,
                                      w.TruongSo10,
                                      w.TruongSo11,
                                      w.TruongSo12,
                                      w.TruongSo13,
                                      w.TruongSo14,
                                      w.FlagError
                                  }).ToList();
            dataGridView1.DataSource = dataBeforeEdit;
            dataGridView2.DataSource = dataAlterEdit;
        }
    }
}