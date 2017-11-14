using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using PhieuKiemDinh.Properties;

namespace PhieuKiemDinh.MyForm
{
    public partial class frm_Checker : XtraForm
    {
        public frm_Checker()
        {
            InitializeComponent();
        }
        private string fbatchRefresh = "";
        private bool fLagRefresh = false;
        private string Folder = "";
        private void btn_Start_Click(object sender, EventArgs e)
        {
            if (Global.StrCheck == "CHECKDESO")
            {
                var version = (from w in Global.DbBpo.tbl_Versions where w.IDProject == Global.StrIdProject select w.IDVersion).FirstOrDefault();
                if (version != Global.Version)
                {
                    MessageBox.Show("Version bạn dùng đã cũ, vui lòng cập nhật phiên bản mới!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Global.RunUpdateVersion();
                    Application.Exit();
                }
                var nhap = (from w in Global.Db.tbl_Images where w.fBatchName == Global.StrBatch && w.ReadImageDeSoNhap < 2 select w.IdImage).Count();
                var check = (from w in Global.Db.tbl_MissImage_DeSos where w.fBatchName == Global.StrBatch && w.Submit == 0 select w.IdImage).Count();
                if (nhap > 0)
                {
                    MessageBox.Show("Chưa nhập xong DeSo!");
                    return;
                }
                if (check > 0)
                {
                    var list_user = (from w in Global.Db.tbl_MissImage_DeSos where w.fBatchName == Global.StrBatch && w.Submit == 0 select w.UserName).ToList();
                    string sss = "";
                    foreach (var item in list_user)
                    {
                        sss += item + "\r\n";
                    }

                    if (list_user.Count > 0)
                    {
                        MessageBox.Show("Những user lấy hình về nhưng không nhập: \r\n" + sss);
                        return;
                    }
                }
                string temp = GetImage_DeSo();
                if (temp == "NULL")
                {
                    uc_PictureBox1.imageBox1.Image = null;
                    MessageBox.Show(@"Batch '" + cbb_Batch_Check.Text + "' đã hoàn thành");
                    return;
                }
                if (temp == "Error")
                {
                    MessageBox.Show("Lỗi load hình");
                    return;
                }
                Load_DeSo(Global.StrBatch, lb_Image.Text);
                btn_Luu_DeSo1.Visible = true;
                btn_Luu_DeSo2.Visible = true;
                btn_SuaVaLuu_DeSo1.Visible = false;
                btn_SuaVaLuu_DeSo2.Visible = false;
            }
            btn_Start.Visible = false;
        }

        private void ResetData()
        {
            if (Global.StrCheck == "CHECKDESO")
            {
                lb_Image.Text = "";
                uC_DESO1.ResetData();
                uC_DESO2.ResetData();
            }
            uc_PictureBox1.imageBox1.Image = null;

        }


        public void LoadBatchMoi()
        {
            if (MessageBox.Show(@"You want to do the next batch?", @"Notification", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No)
            {
                Close();
            }
            else
            {
                VisibleButtonSave();
                ResetData();
                cbb_Batch_Check.DataSource = (from w in Global.Db.GetBatNotFinishCheckerDeSo(Global.StrUserName) select w.fBatchName).ToList();
                cbb_Batch_Check.DisplayMember = "fBatchName";
                var soloi = (from w in Global.Db.GetSoLoi_CheckDeSo(cbb_Batch_Check.Text) select w.Column1).FirstOrDefault();
                lb_Loi.Text = soloi + @" Error";
                Folder = "";
                Folder = (from w in Global.Db.GetFolder(cbb_Batch_Check.Text) select w.fPathPicture).FirstOrDefault();
                btn_Start_Click(null, null);
            }
        }

        private void VisibleButtonSave()
        {
            btn_Luu_DeSo1.Visible = false;
            btn_Luu_DeSo2.Visible = false;
            btn_SuaVaLuu_DeSo1.Visible = false;
            btn_SuaVaLuu_DeSo2.Visible = false;
        }

        private void LockControl(bool kt)
        {
            if (kt)
            {
                btn_Luu_DeSo1.Visible = false;
                btn_Luu_DeSo2.Visible = false;
            }
            else
            {
                if (fLagRefresh == true)
                {
                    var temp = (from w in Global.Db.tbl_DeSos
                                where w.fBatchName == fbatchRefresh && w.IdImage == lb_Image.Text
                                select new
                                {
                                    w.UserName,
                                    w.Error,
                                    w.True
                                }).ToList();
                    if (temp[0].Error == 1 && temp[0].True == 1)
                    {
                        btn_SuaVaLuu_DeSo1.Visible = true;
                        btn_Luu_DeSo2.Visible = true;
                    }
                    else if (temp[1].Error == 1 && temp[1].True == 1)
                    {
                        btn_SuaVaLuu_DeSo2.Visible = true;
                        btn_Luu_DeSo1.Visible = true;
                    }
                    else
                    {
                        btn_Luu_DeSo1.Visible = true;
                        btn_Luu_DeSo2.Visible = true;
                    }
                }
                else
                {
                    btn_Luu_DeSo1.Visible = true;
                    btn_Luu_DeSo2.Visible = true;
                }
            }
        }
        private string imageTemp_check = "";
        private string GetImage_DeSo()
        {
            LockControl(true);
            lb_Image.Text = "";
            imageTemp_check = "";
            imageTemp_check = (from w in Global.Db.tbl_Images where w.fBatchName == Global.StrBatch && w.UserNameCheckDeSo == Global.StrUserName && w.ReadImageCheckDeSo == 1 && w.SubmitCheckDeSo == 0 select w.IdImage).FirstOrDefault();
            if (string.IsNullOrEmpty(imageTemp_check))
            {
                imageTemp_check = (from w in Global.Db.ImageCheck_DeSo(Global.StrBatch, Global.StrUserName) select w.Column1).FirstOrDefault();
                if (string.IsNullOrEmpty(imageTemp_check))
                {
                    return "NULL";
                }
                lb_Image.Text = imageTemp_check;
                uc_PictureBox1.imageBox1.Image = null;
                if (uc_PictureBox1.LoadImage(Global.Webservice + Folder + @"\" + cbb_Batch_Check.Text + "/" + imageTemp_check, imageTemp_check, Settings.Default.ZoomImage) == "Error")
                {
                    uc_PictureBox1.imageBox1.Image = Resources.svn_deleted;
                    return "Error";
                }
            }
            else
            {
                lb_Image.Text = imageTemp_check;
                uc_PictureBox1.imageBox1.Image = null;
                if (uc_PictureBox1.LoadImage(Global.Webservice + Folder + @"\" + cbb_Batch_Check.Text + "/" + imageTemp_check, imageTemp_check, Settings.Default.ZoomImage) == "Error")
                {
                    uc_PictureBox1.imageBox1.Image = Resources.svn_deleted;
                    return "Error";
                }
            }
            return "ok";
        }

        private void Load_DeSo(string fbatchname, string idimage)
        {
            lb_User1.ForeColor = Color.Black;
            lb_User2.ForeColor = Color.Black;
            var deso = (from w in Global.Db.tbl_DeSos
                        where w.fBatchName == fbatchname && w.IdImage == idimage
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
                            //   w.FlagError,
                            w.True
                        }).ToList();
            var result = (from w in Global.DbBpo.tbl_Users where w.Username == deso[0].UserName select w.NotGoodUser).FirstOrDefault();
            if (result == true)
            {
                lb_User1.Text = deso[0].UserName;
                lb_User2.Text = deso[1].UserName;
                if (deso[0].True == 1)
                    lb_User1.ForeColor = Color.Red;
                if (deso[1].True == 1)
                    lb_User2.ForeColor = Color.Red;
                uC_DESO1.txt_TruongSo01.Text = deso[0].TruongSo01;
                uC_DESO1.txt_TruongSo03.Text = deso[0].TruongSo03;
                uC_DESO1.txt_TruongSo04.Text = deso[0].TruongSo04;
                uC_DESO1.txt_TruongSo05.Text = deso[0].TruongSo05;
                uC_DESO1.txt_TruongSo06.Text = deso[0].TruongSo06;
                uC_DESO1.txt_TruongSo07.Text = deso[0].TruongSo07;
                uC_DESO1.txt_TruongSo08_1.Text = deso[0].TruongSo08;
                uC_DESO1.txt_TruongSo08_2.Text = deso[0].TruongSo08_2;
                uC_DESO1.txt_TruongSo09.Text = deso[0].TruongSo09;
                uC_DESO1.txt_TruongSo10.Text = deso[0].TruongSo10;
                uC_DESO1.txt_TruongSo11.Text = deso[0].TruongSo11;
                uC_DESO1.txt_TruongSo12.Text = deso[0].TruongSo12;
                uC_DESO1.txt_TruongSo13.Text = deso[0].TruongSo13;
                uC_DESO1.txt_TruongSo14.Text = deso[0].TruongSo14;
                uC_DESO1.txt_TruongSo04_KeyUp(null, null);
                //  uC_DESO1.txt_FlagError.Text = deso[0].FlagError;

                uC_DESO2.txt_TruongSo01.Text = deso[1].TruongSo01;
                uC_DESO2.txt_TruongSo03.Text = deso[1].TruongSo03;
                uC_DESO2.txt_TruongSo04.Text = deso[1].TruongSo04;
                uC_DESO2.txt_TruongSo05.Text = deso[1].TruongSo05;
                uC_DESO2.txt_TruongSo06.Text = deso[1].TruongSo06;
                uC_DESO2.txt_TruongSo07.Text = deso[1].TruongSo07;
                uC_DESO2.txt_TruongSo08_1.Text = deso[1].TruongSo08;
                uC_DESO2.txt_TruongSo08_2.Text = deso[1].TruongSo08_2;
                uC_DESO2.txt_TruongSo09.Text = deso[1].TruongSo09;
                uC_DESO2.txt_TruongSo10.Text = deso[1].TruongSo10;
                uC_DESO2.txt_TruongSo11.Text = deso[1].TruongSo11;
                uC_DESO2.txt_TruongSo12.Text = deso[1].TruongSo12;
                uC_DESO2.txt_TruongSo13.Text = deso[1].TruongSo13;
                uC_DESO2.txt_TruongSo14.Text = deso[1].TruongSo14;
                uC_DESO2.txt_TruongSo04_KeyUp(null, null);
                //  uC_DESO2.txt_FlagError.Text = deso[1].FlagError;
            }
            else
            {
                lb_User1.Text = deso[1].UserName;                
                if (deso[1].True == 1)
                    lb_User1.ForeColor = Color.Red;             
                uC_DESO1.txt_TruongSo01.Text = deso[1].TruongSo01;
                uC_DESO1.txt_TruongSo03.Text = deso[1].TruongSo03;
                uC_DESO1.txt_TruongSo04.Text = deso[1].TruongSo04;
                uC_DESO1.txt_TruongSo05.Text = deso[1].TruongSo05;
                uC_DESO1.txt_TruongSo06.Text = deso[1].TruongSo06;
                uC_DESO1.txt_TruongSo07.Text = deso[1].TruongSo07;
                uC_DESO1.txt_TruongSo08_1.Text = deso[1].TruongSo08;
                uC_DESO1.txt_TruongSo08_2.Text = deso[1].TruongSo08_2;
                uC_DESO1.txt_TruongSo09.Text = deso[1].TruongSo09;
                uC_DESO1.txt_TruongSo10.Text = deso[1].TruongSo10;
                uC_DESO1.txt_TruongSo11.Text = deso[1].TruongSo11;
                uC_DESO1.txt_TruongSo12.Text = deso[1].TruongSo12;
                uC_DESO1.txt_TruongSo13.Text = deso[1].TruongSo13;
                uC_DESO1.txt_TruongSo14.Text = deso[1].TruongSo14;
                uC_DESO1.txt_TruongSo04_KeyUp(null, null);
                //  uC_DESO1.txt_FlagError.Text = deso[0].FlagError;
                lb_User2.Text = deso[0].UserName;
                if (deso[0].True == 1)
                    lb_User2.ForeColor = Color.Red;
                uC_DESO2.txt_TruongSo01.Text = deso[0].TruongSo01;
                uC_DESO2.txt_TruongSo03.Text = deso[0].TruongSo03;
                uC_DESO2.txt_TruongSo04.Text = deso[0].TruongSo04;
                uC_DESO2.txt_TruongSo05.Text = deso[0].TruongSo05;
                uC_DESO2.txt_TruongSo06.Text = deso[0].TruongSo06;
                uC_DESO2.txt_TruongSo07.Text = deso[0].TruongSo07;
                uC_DESO2.txt_TruongSo08_1.Text = deso[0].TruongSo08;
                uC_DESO2.txt_TruongSo08_2.Text = deso[0].TruongSo08_2;
                uC_DESO2.txt_TruongSo09.Text = deso[0].TruongSo09;
                uC_DESO2.txt_TruongSo10.Text = deso[0].TruongSo10;
                uC_DESO2.txt_TruongSo11.Text = deso[0].TruongSo11;
                uC_DESO2.txt_TruongSo12.Text = deso[0].TruongSo12;
                uC_DESO2.txt_TruongSo13.Text = deso[0].TruongSo13;
                uC_DESO2.txt_TruongSo14.Text = deso[0].TruongSo14;
                uC_DESO2.txt_TruongSo04_KeyUp(null, null);
                //  uC_DESO2.txt_FlagError.Text = deso[1].FlagError;
            }
            Compare_TextBox(uC_DESO1.txt_TruongSo01, uC_DESO2.txt_TruongSo01);
            Compare_TextBox(uC_DESO1.txt_TruongSo03, uC_DESO2.txt_TruongSo03);
            Compare_TextBox(uC_DESO1.txt_TruongSo04, uC_DESO2.txt_TruongSo04);
            Compare_TextBox(uC_DESO1.txt_TruongSo05, uC_DESO2.txt_TruongSo05);
            Compare_TextBox(uC_DESO1.txt_TruongSo06, uC_DESO2.txt_TruongSo06);
            Compare_TextBox(uC_DESO1.txt_TruongSo07, uC_DESO2.txt_TruongSo07);
            Compare_TextBox(uC_DESO1.txt_TruongSo08_1, uC_DESO2.txt_TruongSo08_1);
            Compare_TextBox(uC_DESO1.txt_TruongSo08_2, uC_DESO2.txt_TruongSo08_2);
            Compare_TextBox(uC_DESO1.txt_TruongSo09, uC_DESO2.txt_TruongSo09);
            Compare_TextBox(uC_DESO1.txt_TruongSo10, uC_DESO2.txt_TruongSo10);
            Compare_TextBox(uC_DESO1.txt_TruongSo11, uC_DESO2.txt_TruongSo11);
            Compare_TextBox(uC_DESO1.txt_TruongSo12, uC_DESO2.txt_TruongSo12);
            Compare_TextBox(uC_DESO1.txt_TruongSo14, uC_DESO2.txt_TruongSo14);
            uC_DESO1.txt_TruongSo13_Leave(null,null);
            uC_DESO2.txt_TruongSo13_Leave(null, null);
            Compare_TextBox(uC_DESO1.txt_TruongSo13, uC_DESO2.txt_TruongSo13);
            lb_Loi.Text = ((from w in Global.Db.tbl_DeSos where w.fBatchName == Global.StrBatch && w.Dem == 1 select w.IdImage).Count() / 2).ToString() + " Lỗi";
            timer1.Enabled = true;
        }

        private void frm_Checker_Load(object sender, EventArgs e)
        {
            splitCheck.SplitterPosition = Settings.Default.PositionSplitCheck;
            cbb_Batch_Check.DataSource = (from w in Global.Db.GetBatNotFinishCheckerDeSo(Global.StrUserName) select w.fBatchName).ToList();
            cbb_Batch_Check.DisplayMember = "fBatchName";
            cbb_Batch_Check.Text = Global.StrBatch;
            Folder = "";
            Folder = (from w in Global.Db.GetFolder(cbb_Batch_Check.Text) select w.fPathPicture).FirstOrDefault();
            xtraTabControl1.TabPages.Remove(tp_DeSo1);
            xtraTabControl2.TabPages.Remove(tp_DeSo2);

            if (Global.StrCheck == "CHECKDESO")
            {
                xtraTabControl1.TabPages.Add(tp_DeSo1);
                xtraTabControl2.TabPages.Add(tp_DeSo2);
                VisibleButtonSave();
                uC_DESO1.Changed += UC_DESO1_Changed;
                uC_DESO2.Changed += Uc_DeSo2_Changed;
                var soloi = ((from w in Global.Db.tbl_DeSos where w.fBatchName == Global.StrBatch && w.Dem == 1 select w.IdImage).Count() / 2).ToString();
                lb_Loi.Text = soloi + " Lỗi";
            }
        }

        private void Uc_DeSo2_Changed(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(lb_Image.Text))
                return;
            VisibleButtonSave();
            btn_SuaVaLuu_DeSo2.Visible = true;
        }

        private void UC_DESO1_Changed(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(lb_Image.Text))
                return;
            VisibleButtonSave();
            btn_SuaVaLuu_DeSo1.Visible = true;
        }

        private void btn_Luu_DeSo1_Click(object sender, EventArgs e)
        {
            Global.DbBpo.UpdateTimeLastRequest(Global.Token);
            if (fLagRefresh)
                Global.Db.Luu_tbl_DeSo(lb_User1.Text, lb_User2.Text, lb_Image.Text, fbatchRefresh, Global.StrUserName);
            else
                Global.Db.Luu_tbl_DeSo(lb_User1.Text, lb_User2.Text, lb_Image.Text, cbb_Batch_Check.Text, Global.StrUserName);
            fLagRefresh = false;
            fbatchRefresh = "";
            ResetData();
            var version = (from w in Global.DbBpo.tbl_Versions where w.IDProject == Global.StrIdProject select w.IDVersion).FirstOrDefault();
            if (version != Global.Version)
            {
                MessageBox.Show("Version bạn dùng đã cũ, vui lòng cập nhật phiên bản mới!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Global.RunUpdateVersion();
                Application.Exit();
            }
            string temp = GetImage_DeSo();
            if (temp == "NULL")
            {
                uc_PictureBox1.imageBox1.Image = null;
                MessageBox.Show(@"Batch '" + cbb_Batch_Check.Text + "' đã hoàn thành");
                LoadBatchMoi();
                return;
            }
            if (temp == "Error")
            {
                MessageBox.Show("Lỗi load hình");
                VisibleButtonSave();
                return;
            }
            Load_DeSo(Global.StrBatch, lb_Image.Text);
            VisibleButtonSave();
        }

        private void btn_Luu_DeSo2_Click(object sender, EventArgs e)
        {
            Global.DbBpo.UpdateTimeLastRequest(Global.Token);
            if (fLagRefresh)
                Global.Db.Luu_tbl_DeSo(lb_User2.Text, lb_User1.Text, lb_Image.Text, fbatchRefresh, Global.StrUserName);
            else
                Global.Db.Luu_tbl_DeSo(lb_User2.Text, lb_User1.Text, lb_Image.Text, cbb_Batch_Check.Text, Global.StrUserName);
            fLagRefresh = false;
            fbatchRefresh = "";
            ResetData();
            var version = (from w in Global.DbBpo.tbl_Versions where w.IDProject == Global.StrIdProject select w.IDVersion).FirstOrDefault();
            if (version != Global.Version)
            {
                MessageBox.Show("Version bạn dùng đã cũ, vui lòng cập nhật phiên bản mới!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Global.RunUpdateVersion();
                Application.Exit();
            }
            string temp = GetImage_DeSo();
            if (temp == "NULL")
            {
                uc_PictureBox1.imageBox1.Image = null;
                MessageBox.Show(@"Batch '" + cbb_Batch_Check.Text + "' đã hoàn thành");
                LoadBatchMoi();
                return;
            }
            if (temp == "Error")
            {
                MessageBox.Show("Lỗi load hình");
                VisibleButtonSave();
                return;
            }
            Load_DeSo(Global.StrBatch, lb_Image.Text);
            VisibleButtonSave();
        }

        string flagTruong13 = "", flagTruong09 ="",truong11="";
        private void btn_SuaVaLuu_DeSo1_Click(object sender, EventArgs e)
        {
            truong11 = ""; flagTruong13 = "";
            Global.DbBpo.UpdateTimeLastRequest(Global.Token);
            uC_DESO1.txt_TruongSo13_Leave(null, null);
            //---
            if (uC_DESO1.txt_TruongSo13.BackColor == Color.SkyBlue)
            {
                flagTruong13 = "1";
            }
            else { flagTruong13 = "0"; }
            //---
            if (uC_DESO1.checkTruong09(uC_DESO1.txt_TruongSo09.Text) == true) { flagTruong09 = "1"; }
            else if(uC_DESO1.checkTruong09(uC_DESO1.txt_TruongSo09.Text) == false) { flagTruong09 = "0"; }
            //---
            if (uC_DESO1.txt_TruongSo11.Text.IndexOf('●') >= 0)
                truong11 = "●";
            else if (uC_DESO1.txt_TruongSo11.Text.IndexOf('?') >= 0)
                truong11 = "?";
            else
                truong11 = uC_DESO1.txt_TruongSo11.Text;
            //---
            if (fLagRefresh)
                Global.Db.SuaVaLuu_tbl_DeSo_0911(lb_User1.Text, lb_User2.Text, lb_Image.Text, fbatchRefresh, Global.StrUserName,
                                                uC_DESO1.txt_TruongSo01.Text,
                                                uC_DESO1.txt_TruongSo03.Text.IndexOf('?') >= 0 ? "?" : uC_DESO1.txt_TruongSo03.Text,
                                                uC_DESO1.txt_TruongSo04.Text.Replace(",", ""),
                                                uC_DESO1.txt_TruongSo05.Text,
                                                uC_DESO1.txt_TruongSo06.Text,
                                                uC_DESO1.txt_TruongSo07.Text,
                                                uC_DESO1.txt_TruongSo08_1.Text,
                                                uC_DESO1.txt_TruongSo08_2.Text,
                                                uC_DESO1.txt_TruongSo09.Text.IndexOf('?') >= 0 ? "?" : uC_DESO1.txt_TruongSo09.Text,
                                                uC_DESO1.txt_TruongSo10.Text.IndexOf('?') >= 0 ? "?" : uC_DESO1.txt_TruongSo10.Text,
                                                truong11,
                                                uC_DESO1.txt_TruongSo12.Text.IndexOf('?') >= 0 ? "?" : uC_DESO1.txt_TruongSo12.Text,
                                                uC_DESO1.txt_TruongSo13.Text.IndexOf('?') >= 0 ? "?" : uC_DESO1.txt_TruongSo13.Text,
                                                flagTruong13,
                                                uC_DESO1.txt_TruongSo14.Text.IndexOf('?') >= 0 ? "?" : uC_DESO1.txt_TruongSo14.Text,
                                                flagTruong09                                                
                                                //, uC_DESO1.txt_FlagError.Text
                                                );
            else
                Global.Db.SuaVaLuu_tbl_DeSo_0911(lb_User1.Text, lb_User2.Text, lb_Image.Text, cbb_Batch_Check.Text, Global.StrUserName,
                                            uC_DESO1.txt_TruongSo01.Text,
                                            uC_DESO1.txt_TruongSo03.Text.IndexOf('?') >= 0 ? "?" : uC_DESO1.txt_TruongSo03.Text,
                                            uC_DESO1.txt_TruongSo04.Text.Replace(",", ""),
                                            uC_DESO1.txt_TruongSo05.Text,
                                            uC_DESO1.txt_TruongSo06.Text,
                                            uC_DESO1.txt_TruongSo07.Text,
                                            uC_DESO1.txt_TruongSo08_1.Text,
                                            uC_DESO1.txt_TruongSo08_2.Text,
                                            uC_DESO1.txt_TruongSo09.Text.IndexOf('?') >= 0 ? "?" : uC_DESO1.txt_TruongSo09.Text,
                                            uC_DESO1.txt_TruongSo10.Text.IndexOf('?') >= 0 ? "?" : uC_DESO1.txt_TruongSo10.Text,
                                            truong11,
                                            uC_DESO1.txt_TruongSo12.Text.IndexOf('?') >= 0 ? "?" : uC_DESO1.txt_TruongSo12.Text,
                                            uC_DESO1.txt_TruongSo13.Text.IndexOf('?') >= 0 ? "?" : uC_DESO1.txt_TruongSo13.Text,
                                            flagTruong13,
                                            uC_DESO1.txt_TruongSo14.Text.IndexOf('?') >= 0 ? "?" : uC_DESO1.txt_TruongSo14.Text,
                                            flagTruong09//,uC_DESO1.txt_FlagError.Text
                                            );
            fLagRefresh = false;
            fbatchRefresh = "";
            ResetData();
            var version = (from w in Global.DbBpo.tbl_Versions where w.IDProject == Global.StrIdProject select w.IDVersion).FirstOrDefault();
            if (version != Global.Version)
            {
                MessageBox.Show("Version bạn dùng đã cũ, vui lòng cập nhật phiên bản mới!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Global.RunUpdateVersion();
                Application.Exit();
            }
            string temp = GetImage_DeSo();
            if (temp == "NULL")
            {
                uc_PictureBox1.imageBox1.Image = null;
                MessageBox.Show(@"Batch '" + cbb_Batch_Check.Text + "' đã hoàn thành");
                LoadBatchMoi();
                return;
            }
            if (temp == "Error")
            {
                MessageBox.Show("Lỗi load hình");
                VisibleButtonSave();
                return;
            }
            Load_DeSo(Global.StrBatch, lb_Image.Text);
            VisibleButtonSave();
        }

        private void btn_SuaVaLuu_DeSo2_Click(object sender, EventArgs e)
        {
            truong11 = ""; flagTruong13 = "";
            Global.DbBpo.UpdateTimeLastRequest(Global.Token);
            uC_DESO2.txt_TruongSo13_Leave(null, null);
            //---
            if (uC_DESO2.txt_TruongSo13.BackColor == System.Drawing.Color.SkyBlue)
            {
                flagTruong13 = "1";
            }
            else { flagTruong13 = "0"; }
            //----
            //if (uC_DESO1.checkTruong09(uC_DESO1.txt_TruongSo09.Text) == true) { flagTruong09 = "1"; }
            //else if (uC_DESO1.checkTruong09(uC_DESO1.txt_TruongSo09.Text) == false)
            //{ flagTruong09 = "0"; }

            if (uC_DESO2.checkTruong09(uC_DESO2.txt_TruongSo09.Text) == true) { flagTruong09 = "1"; }
            else if (uC_DESO2.checkTruong09(uC_DESO2.txt_TruongSo09.Text) == false)
            { flagTruong09 = "0"; }
            //----
            if (uC_DESO2.txt_TruongSo11.Text.IndexOf('●') >= 0)
                truong11 = "●";
            else if (uC_DESO2.txt_TruongSo11.Text.IndexOf('?') >= 0)
                truong11 = "?";
            else
                truong11 = uC_DESO2.txt_TruongSo11.Text;
            //---
            if (fLagRefresh)
                Global.Db.SuaVaLuu_tbl_DeSo_0911(lb_User2.Text, lb_User1.Text, lb_Image.Text, fbatchRefresh, Global.StrUserName,
                                            uC_DESO2.txt_TruongSo01.Text,
                                            uC_DESO2.txt_TruongSo03.Text.IndexOf('?') >= 0 ? "?" : uC_DESO2.txt_TruongSo03.Text,
                                            uC_DESO2.txt_TruongSo04.Text.Replace(",", ""),
                                            uC_DESO2.txt_TruongSo05.Text,
                                            uC_DESO2.txt_TruongSo06.Text,
                                            uC_DESO2.txt_TruongSo07.Text,
                                            uC_DESO2.txt_TruongSo08_1.Text,
                                            uC_DESO2.txt_TruongSo08_2.Text,
                                            uC_DESO2.txt_TruongSo09.Text.IndexOf('?') >= 0 ? "?" : uC_DESO2.txt_TruongSo09.Text,
                                            uC_DESO2.txt_TruongSo10.Text.IndexOf('?') >= 0 ? "?" : uC_DESO2.txt_TruongSo10.Text,
                                            truong11,
                                            uC_DESO2.txt_TruongSo12.Text.IndexOf('?') >= 0 ? "?" : uC_DESO2.txt_TruongSo12.Text,
                                            uC_DESO2.txt_TruongSo13.Text.IndexOf('?') >= 0 ? "?" : uC_DESO2.txt_TruongSo13.Text,
                                            flagTruong13,
                                            uC_DESO2.txt_TruongSo14.Text.IndexOf('?') >= 0 ? "?" : uC_DESO2.txt_TruongSo14.Text,
                                            flagTruong09//, uC_DESO2.txt_FlagError.Text
                                            );
            else
                Global.Db.SuaVaLuu_tbl_DeSo_0911(lb_User2.Text, lb_User1.Text, lb_Image.Text, cbb_Batch_Check.Text, Global.StrUserName,
                                            uC_DESO2.txt_TruongSo01.Text,
                                            uC_DESO2.txt_TruongSo03.Text.IndexOf('?') >= 0 ? "?" : uC_DESO2.txt_TruongSo03.Text,
                                            uC_DESO2.txt_TruongSo04.Text.Replace(",", ""),
                                            uC_DESO2.txt_TruongSo05.Text,
                                            uC_DESO2.txt_TruongSo06.Text,
                                            uC_DESO2.txt_TruongSo07.Text,
                                            uC_DESO2.txt_TruongSo08_1.Text,
                                            uC_DESO2.txt_TruongSo08_2.Text,
                                            uC_DESO2.txt_TruongSo09.Text.IndexOf('?') >= 0 ? "?" : uC_DESO2.txt_TruongSo09.Text,
                                            uC_DESO2.txt_TruongSo10.Text.IndexOf('?') >= 0 ? "?" : uC_DESO2.txt_TruongSo10.Text,
                                            truong11,
                                            uC_DESO2.txt_TruongSo12.Text.IndexOf('?') >= 0 ? "?" : uC_DESO2.txt_TruongSo12.Text,
                                            uC_DESO2.txt_TruongSo13.Text.IndexOf('?') >= 0 ? "?" : uC_DESO2.txt_TruongSo13.Text,
                                            flagTruong13,
                                            uC_DESO2.txt_TruongSo14.Text.IndexOf('?') >= 0 ? "?" : uC_DESO2.txt_TruongSo14.Text,
                                            flagTruong09//,uC_DESO2.txt_FlagError.Text
                                             );
            fLagRefresh = false;
            fbatchRefresh = "";
            ResetData();
            var version = (from w in Global.DbBpo.tbl_Versions where w.IDProject == Global.StrIdProject select w.IDVersion).FirstOrDefault();
            if (version != Global.Version)
            {
                MessageBox.Show("Version bạn dùng đã cũ, vui lòng cập nhật phiên bản mới!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Global.RunUpdateVersion();
                Application.Exit();
            }
            string temp = GetImage_DeSo();
            if (temp == "NULL")
            {
                uc_PictureBox1.imageBox1.Image = null;
                MessageBox.Show(@"Batch '" + cbb_Batch_Check.Text + "' đã hoàn thành");
                LoadBatchMoi();
                return;
            }
            if (temp == "Error")
            {
                MessageBox.Show("Lỗi load hình");
                VisibleButtonSave();
                return;
            }
            Load_DeSo(Global.StrBatch, lb_Image.Text);
            VisibleButtonSave();
        }

        private void Compare_TextBox(TextEdit t1, TextEdit t2)
        {
            //if (!string.IsNullOrEmpty(t1.Text) || !string.IsNullOrEmpty(t2.Text))
            // {
            if (t1.Text != t2.Text)
            {
                t1.BackColor = Color.PaleVioletRed;
                t2.BackColor = Color.PaleVioletRed;
            }
            //  }
            // else
            // {
            //      t1.BackColor = Color.White;
            //    t2.BackColor = Color.White;
            // }
        }
        public void CompareRichTextBox(RichTextBox t1, RichTextBox t2)
        {
            int n = 0;
            string s = t1.Text;
            string s1 = t2.Text;
            if (s.Length > s1.Length)
            {
                n = s1.Length;
                t1.SelectionStart = n;
                t1.SelectionLength = s.Length - s1.Length;
                t1.SelectionColor = Color.Red;
            }
            else
            {
                n = s.Length;
                t2.SelectionStart = n;
                t2.SelectionLength = s1.Length - s.Length;
                t2.SelectionColor = Color.Red;
            }

            for (int i = 0; i < n; i++)
            {
                if (s[i] != s1[i])
                {
                    t1.SelectionStart = i;
                    t1.SelectionLength = 1;
                    t1.SelectionColor = Color.Red;

                    t2.SelectionStart = i;
                    t2.SelectionLength = 1;
                    t2.SelectionColor = Color.Red;
                }
            }
        }

        private void lb_fBatchName_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(cbb_Batch_Check.Text);
            XtraMessageBox.Show("Copy batch name Success!");
        }

        private void lb_Image_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(lb_Image.Text);
            XtraMessageBox.Show("Copy image name Success!");
        }

        private void uC_DESO1_Scroll(object sender, ScrollEventArgs e)
        {
            if (e.ScrollOrientation == System.Windows.Forms.ScrollOrientation.HorizontalScroll)
                uC_DESO1.HorizontalScroll.Value = e.NewValue;
            else if (e.ScrollOrientation == System.Windows.Forms.ScrollOrientation.VerticalScroll)
                uC_DESO2.VerticalScroll.Value = e.NewValue;
        }

        private void uC_DESO2_Scroll(object sender, ScrollEventArgs e)
        {
            if (e.ScrollOrientation == System.Windows.Forms.ScrollOrientation.HorizontalScroll)
                uC_DESO2.HorizontalScroll.Value = e.NewValue;
            else if (e.ScrollOrientation == System.Windows.Forms.ScrollOrientation.VerticalScroll)
                uC_DESO1.VerticalScroll.Value = e.NewValue;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Enabled = false;
            LockControl(false);
        }

        private void cbb_Batch_Check_SelectedIndexChanged(object sender, EventArgs e)
        {
            VisibleButtonSave();
            lb_Image.Text = "";
            Global.StrBatch = cbb_Batch_Check.Text;
            var soloi = (from w in Global.Db.GetSoLoi_CheckDeSo(cbb_Batch_Check.Text) select w.Column1).FirstOrDefault();
            lb_Loi.Text = soloi + @" Lỗi";
            ResetData();
            btn_Start.Visible = true;
        }

        private void btn_ShowImageCheck_Click(object sender, EventArgs e)
        {
            new frm_ShowCheckedImage().ShowDialog();
        }

        private void splitContainerControl1_SplitterPositionChanged(object sender, EventArgs e)
        {
            Settings.Default.PositionSplitCheck = splitCheck.SplitterPosition;
            Settings.Default.Save();
        }

        private void btn_CheckLai_Click(object sender, EventArgs e)
        {
            var temp = (from w in Global.Db.tbl_Images join b in Global.Db.tbl_Batches on w.fBatchName equals b.fBatchName where w.UserNameCheckDeSo == Global.StrUserName && w.ReadImageCheckDeSo == 1 && w.SubmitCheckDeSo == 1 orderby w.DateCheckDeSo descending select new { w.fBatchName, w.IdImage, b.fPathPicture }).FirstOrDefault();
            if (temp == null)
            {
                MessageBox.Show("Bạn chưa check, vui lòng check hình trước khi check lại");
                return;
            }
            lb_Image.Text = "";
            fbatchRefresh = "";
            var version = (from w in Global.DbBpo.tbl_Versions where w.IDProject == Global.StrIdProject select w.IDVersion).FirstOrDefault();
            if (version != Global.Version)
            {
                MessageBox.Show("Version bạn dùng đã cũ, vui lòng cập nhật phiên bản mới!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Global.RunUpdateVersion();
                Application.Exit();
            }
            ResetData();
            lb_Image.Text = temp.IdImage;
            fbatchRefresh = temp.fBatchName;
            uc_PictureBox1.LoadImage(Global.Webservice + temp.fPathPicture + @"\" + fbatchRefresh + "/" + lb_Image.Text, lb_Image.Text, Settings.Default.ZoomImage);
            Load_DeSo(fbatchRefresh, lb_Image.Text);
            VisibleButtonSave();
            fLagRefresh = true;
            btn_Start.Visible = false;
        }

        private void cbb_Batch_Check_TextChanged(object sender, EventArgs e)
        {
            Folder = "";
            Folder = (from w in Global.Db.GetFolder(cbb_Batch_Check.Text) select w.fPathPicture).FirstOrDefault();
        }
    }
}