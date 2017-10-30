using System;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Windows.Forms;
using System.Diagnostics;
using System.Windows.Forms.Design;
using DevExpress.XtraEditors;
using Microsoft.Office.Core;
using PhieuKiemDinh.MyUserControl;
namespace PhieuKiemDinh.MyForm
{
    public partial class FrmFeedback : XtraForm
    {
        public static int Num = 0;
        public FrmFeedback()
        {
            InitializeComponent();
        }
        private List<string> idimage = new List<string>();
        private void LoadUser()
        {
            if (chb_User.Checked)
            {
                cbb_username.Visible = true;
                cbb_username.Text = "";
                cbb_username.DataSource = Global.Db.GetUserFailDeSo(cbb_batch.Text);
                cbb_username.DisplayMember = "UserName";
            }
            if (chb_User.Checked == false)
            {
                cbb_username.Visible = false;
            }
        }

        private void GetImageDeso(int n)
        {
            idimage.Clear();
            idimage = (from w in (Global.Db.GetImageFail( cbb_batch.Text)) select w.IdImage).ToList();
            lb_soloi.Text = idimage.Count.ToString();
            if ((n + 30) < idimage.Count && n >= 0)
            {
                btn_next.Enabled = true;
                for (int j = n; j <= n + 29; j++)
                {
                    string id = idimage[j];
                    UC_FeedBack ucF = new UC_FeedBack();
                    string url = Global.Webservice + cbb_batch.Text + "/" + id;
                    ucF.LoadImage(cbb_batch.Text, url, id);
                    Point p = new Point();
                    foreach (Control ct in pnl_Mainfeedback1.Controls)
                    {
                        p = ct.Location;
                        p.Y += ct.Size.Height;
                    }
                    ucF.Location = p;
                    ucF.textbox1.Text = (j + 1).ToString();
                    pnl_Mainfeedback1.Controls.Add(ucF);
                }
            }
            else if ((n + 30) >= idimage.Count && n >= 0)
            {
                btn_next.Enabled = false;
                for (int j = n; j <= idimage.Count - 1; j++)
                {
                    string id = idimage[j];
                    UC_FeedBack ucF = new UC_FeedBack();
                    string url = Global.Webservice + cbb_batch.Text + "/" + id;
                    ucF.LoadImage(cbb_batch.Text, url, id);
                    Point p = new Point();
                    foreach (Control ct in pnl_Mainfeedback1.Controls)
                    {
                        p = ct.Location;
                        p.Y += ct.Size.Height;
                    }
                    ucF.Location = p;
                    ucF.textbox1.Text = (j + 1).ToString();
                    pnl_Mainfeedback1.Controls.Add(ucF);  
                }
            }
        }

        private void GetImageDesoUser(int n)
        {

            idimage.Clear();
            idimage = (from w in (Global.Db.GetImageFailUserDeSo(cbb_username.Text, cbb_batch.Text)) select w.IdImage).ToList();
            lb_soloi.Text = idimage.Count.ToString();
            if ((n + 30) < idimage.Count && n >= 0)
            {
                btn_next.Enabled = true;
                for (int j = n; j <= n + 29; j++)
                {
                    string id = idimage[j];
                    UC_FeedBack ucF = new UC_FeedBack();
                    string url = Global.Webservice + cbb_batch.Text + "/" + id;
                    ucF.LoadImageUser(cbb_username.Text, cbb_batch.Text, url, id);
                    Point p = new Point();
                    foreach (Control ct in pnl_Mainfeedback1.Controls)
                    {
                        p = ct.Location;
                        p.Y += ct.Size.Height;
                    }
                    ucF.uC_DESO_FeedBack1.Visible = false;
                    ucF.Location = p;
                    ucF.textbox1.Text = (j + 1).ToString();
                    pnl_Mainfeedback1.Controls.Add(ucF);
                }
            }
            else if ((n + 30) >= idimage.Count && n >= 0)
            {
                btn_next.Enabled = false;
                for (int j = n; j <= idimage.Count - 1; j++)
                {
                    string id = idimage[j];
                    UC_FeedBack ucF = new UC_FeedBack();
                    string url = Global.Webservice + cbb_batch.Text + "/" + id;
                    ucF.LoadImageUser(cbb_username.Text, cbb_batch.Text, url, id);

                    Point p = new Point();
                    foreach (Control ct in pnl_Mainfeedback1.Controls)
                    {
                        p = ct.Location;
                        p.Y += ct.Size.Height;
                    }
                    ucF.uC_DESO_FeedBack1.Visible = false;
                    ucF.Location = p;
                    ucF.textbox1.Text = (j + 1).ToString();
                    pnl_Mainfeedback1.Controls.Add(ucF);
                }
            }
        }
#region
        private int _a;
        private bool _b = true;
        private void frmFeedback_Load(object sender, EventArgs e)
        {
            cbb_batch.DataSource = (from w in Global.Db.tbl_Batches orderby w.id select new { w.fBatchName, w.id }).ToList();
            cbb_batch.DisplayMember = "fBatchName";
            cbb_batch.ValueMember = "id";
            cbb_batch.Text = Global.StrBatch;
            Num = 0;
            pnl_Mainfeedback1.MouseWheel += Pnl_Mainfeedback1_MouseWheel;
        }
        private void Pnl_Mainfeedback1_MouseWheel(object sender, MouseEventArgs e)
        {
            if (!_b)
                pnl_Mainfeedback1.VerticalScroll.Value = _a;
        }
        private void btn_hienthi_Click(object sender, EventArgs e)
        {
            try
            {
                Num = 0;
                lb_soloi.Text = @"0";
                pnl_Mainfeedback1.Controls.Clear();
                GC.Collect();
                btn_back.Enabled = false;

                if (chb_User.Checked)
                {
                    GetImageDesoUser(Num);
                }
                if (chb_User.Checked == false)
                {
                    GetImageDeso(Num);
                }
            }
            catch (Exception w) { MessageBox.Show(@"Can not retrieve data. Error:" + w); }
        }

        private void btn_next_Click(object sender, EventArgs e)
        {
            try
            {
                Num += 30;
                if (Num < 30)
                {
                    btn_back.Enabled = false;
                }
                else
                {
                    btn_back.Enabled = true;
                }
                pnl_Mainfeedback1.Controls.Clear();
                GC.Collect();

                if (chb_User.Checked)
                {
                    GetImageDesoUser(Num);
                }
                if (chb_User.Checked == false)
                {
                    GetImageDeso(Num);
                }
            }
            catch (Exception w) { MessageBox.Show(@"Can not retrieve data. Error: " + w); }
        }

        private void btn_back_Click(object sender, EventArgs e)
        {
            try
            {
                Num -= 30;
                if (Num < 30)
                {
                    btn_back.Enabled = false;
                }
                else
                {
                    btn_back.Enabled = true;
                }
                pnl_Mainfeedback1.Controls.Clear();
                GC.Collect();
                if (chb_User.Checked)
                {
                    GetImageDesoUser(Num);
                }
                if (chb_User.Checked == false)
                {
                    GetImageDeso(Num);
                }
            }
            catch (Exception w) { MessageBox.Show(@"Can not retrieve data. Error: " + w); }
        }

        private void cbb_batch_TextChanged(object sender, EventArgs e)
        {
            pnl_Mainfeedback1.Controls.Clear();
            btn_back.Enabled = false;
            btn_next.Enabled = false;
            LoadUser();
        }

        private void chb_User_CheckedChanged(object sender, EventArgs e)
        {
            pnl_Mainfeedback1.Controls.Clear();
            btn_back.Enabled = false;
            btn_next.Enabled = false;
            LoadUser();
        }

        private void cbb_username_TextChanged(object sender, EventArgs e)
        {
            pnl_Mainfeedback1.Controls.Clear();
            btn_back.Enabled = false;
            btn_next.Enabled = false;
        }
#endregion
        Microsoft.Office.Interop.Excel.Application App = null;
        Microsoft.Office.Interop.Excel.Workbook book = null;
        Microsoft.Office.Interop.Excel.Worksheet wrksheet = null;

        
        private void btn_ExportExcel_Click(object sender, EventArgs e)
        {
            idimage.Clear();
            if (chb_User.Checked == true)
            {
                idimage =(from w in (Global.Db.GetImageFailUserDeSo(cbb_username.Text, cbb_batch.Text)) select w.IdImage).ToList();
                ExcelFeedBack_User(idimage);
            }
            else if (chb_User.Checked == false)
            {
                idimage =(from w in (Global.Db.GetImageFail( cbb_batch.Text)) select w.IdImage).ToList();
                ExcelFeedBack(idimage);
            }
        }
        #region ExportExcel
        private void ExcelFeedBack(List<string> idimage ) {

            if (File.Exists(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\FeedBack.xlsx"))
            {
                File.Delete(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\FeedBack.xlsx");
                File.WriteAllBytes(
                    (Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "/FeedBack.xlsx"),
                    Properties.Resources.FeedBack);
            }
            else
            {
                File.WriteAllBytes(
                    (Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "/FeedBack.xlsx"),
                    Properties.Resources.FeedBack);
            }
            int r = 1;
            int distance = 15;
            App = new Microsoft.Office.Interop.Excel.Application();
            book = App.Workbooks.Open(System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments)
                + "\\FeedBack.xlsx", 0, true, 5, "", "", false, Microsoft.Office.Interop.Excel.XlPlatform.xlWindows, "", true, false, 0, true, false, false);
            wrksheet = (Microsoft.Office.Interop.Excel.Worksheet)book.ActiveSheet;
            string pathServer = Global.StrPath +"/"+ cbb_batch.Text;
            for (int i = 0; i < idimage.Count; i++)
            {
                string id = idimage[i];
                Microsoft.Office.Interop.Excel.Range oRange = wrksheet.Cells[r + 1, 2];
                float Left = (float)((double)oRange.Left);
                float Top = (float)((double)oRange.Top)+2;
                wrksheet.Shapes.AddPicture(pathServer + "/" + idimage[i], Microsoft.Office.Core.MsoTriState.msoFalse, Microsoft.Office.Core.MsoTriState.msoCTrue, Left, Top, 365, 270);
                //string id = idimage[i];
                //Image oImage = Image.FromFile(pathServer + "/" + idimage[i]);
                //wrksheet.Shapes.AddPicture(pathServer + "/" + idimage[i], Microsoft.Office.Core.MsoTriState.msoFalse, Microsoft.Office.Core.MsoTriState.msoCTrue, 20, distance, 365, 270);
                //distance += 300;
                var deso = Global.Db.FeedBackExcel(id, cbb_batch.Text).ToList();
               int h = 9;
                var nameCheck = (from w in Global.Db.GetNameCheck(id,cbb_batch.Text) select w.UserNameCheckDeSo).FirstOrDefault();
                wrksheet.Cells[r + 1, 10] = nameCheck+@" ";
                wrksheet.Cells[r + 1, h] = "UserName";
                wrksheet.Cells[r + 2, h] = "Trường 1";
                wrksheet.Cells[r + 3, h] = "Trường 3";
                wrksheet.Cells[r + 4, h] = "Trường 4";
                wrksheet.Cells[r + 5, h] = "Trường 5";
                wrksheet.Cells[r + 6, h] = "Trường 6";
                wrksheet.Cells[r + 7, h] = "Trường 7";
                wrksheet.Cells[r + 8, h] = "Trường 8";
                wrksheet.Cells[r + 9, h] = "Trường 9";
                wrksheet.Cells[r + 10, h] = "Trường 10";
                wrksheet.Cells[r + 11, h] = "Trường 11";
                wrksheet.Cells[r + 12, h] = "Trường 12";
                wrksheet.Cells[r + 13, h] = "Trường 13";
                wrksheet.Cells[r + 14, h] = "Trường 14";
              //  wrksheet.Cells[r + 15, h] = "FlagError";
                wrksheet.Cells[r+20 ,1] = id + "";
                wrksheet.Cells[r+1, 1] = i + 1;
                for (int j = 0; j < deso.Count(); j++)
                {
                    h++;
                    if (j != 0)
                    {
                        wrksheet.Cells[r + 1, h] = deso[j].UserName + "";
                    }
                    wrksheet.Cells[r + 2, h] = deso[j].TruongSo01 + "";
                    wrksheet.Cells[r + 3, h] = deso[j].TruongSo03 + "";
                    wrksheet.Cells[r + 4, h] = deso[j].TruongSo04 + "";
                    wrksheet.Cells[r + 5, h] = deso[j].TruongSo05 + "";
                    wrksheet.Cells[r + 6, h] = deso[j].TruongSo06 + "";
                    wrksheet.Cells[r + 7, h] = deso[j].TruongSo07 + "";
                    wrksheet.Cells[r + 8, h] = deso[j].TruongSo08 + "";
                    wrksheet.Cells[r + 9, h] = deso[j].TruongSo09 + "";
                    wrksheet.Cells[r + 10, h] = deso[j].TruongSo10 + "";
                    wrksheet.Cells[r + 11, h] = deso[j].TruongSo11 + "";
                    wrksheet.Cells[r + 12, h] = deso[j].TruongSo12 + "";
                    wrksheet.Cells[r + 13, h] = deso[j].TruongSo13 + "";
                    wrksheet.Cells[r + 14, h] = deso[j].TruongSo14 + "";
                 //   wrksheet.Cells[r + 15, h] = deso[j].FlagError + "";
                }

                Microsoft.Office.Interop.Excel.Range cellImage1 = wrksheet.Cells[h - 11][r + 1];
                Microsoft.Office.Interop.Excel.Range cellImage2 = wrksheet.Cells[h][r + 20];
                Microsoft.Office.Interop.Excel.Range rangeImage = wrksheet.get_Range(cellImage1, cellImage2);
                rangeImage.BorderAround(Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous,
                    Microsoft.Office.Interop.Excel.XlBorderWeight.xlThin,
                    Microsoft.Office.Interop.Excel.XlColorIndex.xlColorIndexAutomatic,1);
                Microsoft.Office.Interop.Excel.Range cell1 = wrksheet.Cells[h - 3][r + 1];
                Microsoft.Office.Interop.Excel.Range cell2 = wrksheet.Cells[h][r + 14];
                Microsoft.Office.Interop.Excel.Range range = wrksheet.get_Range(cell1, cell2);
                range.Borders.LineStyle = Microsoft.Office.Interop.Excel.Constants.xlSolid;
                range.Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.MediumSpringGreen);
                r += 21;
                
            }
            string savePath = "";
            saveFileDialog1.Title = "Save Excel Files";
            saveFileDialog1.Filter = "Excel files (*.xlsx)|*.xlsx";
            saveFileDialog1.FileName = "Feedback_"+cbb_batch.Text;
            saveFileDialog1.RestoreDirectory = true;
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                book.SaveCopyAs(saveFileDialog1.FileName);
                book.Saved = true;
                savePath = Path.GetDirectoryName(saveFileDialog1.FileName);
                App.Quit();
            }
            else
            {
                MessageBox.Show(@"Error exporting excel!");
                return;
            }
            Process.Start(savePath);
        }
    private void ExcelFeedBack_User(List<string> idimage)
        {
            if (File.Exists(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\Feedback_User.xlsx"))
            {
                File.Delete(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\Feedback_User.xlsx");
                File.WriteAllBytes((Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "/Feedback_User.xlsx"),Properties.Resources.Feedback_User);
            }
            else
            {
                File.WriteAllBytes(
                    (Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "/Feedback_User.xlsx"),Properties.Resources.Feedback_User);
            }

            int r = 1;
        int distance = 15;
        App = new Microsoft.Office.Interop.Excel.Application();
        book = App.Workbooks.Open(System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments)+ "\\Feedback_User.xlsx", 0, true, 5, "", "", false, Microsoft.Office.Interop.Excel.XlPlatform.xlWindows, "", true, false, 0, true, false, false);
        wrksheet = (Microsoft.Office.Interop.Excel.Worksheet)book.ActiveSheet;
        string pathServer = Global.StrPath + "/" + cbb_batch.Text;
            for (int i = 0; i < idimage.Count; i++)
            {
                string id = idimage[i];
                Microsoft.Office.Interop.Excel.Range oRange = wrksheet.Cells[r+1,2 ];
                float Left = (float)((double)oRange.Left);
                float Top = (float)((double)oRange.Top+2);
                wrksheet.Shapes.AddPicture(pathServer + "/" + idimage[i], Microsoft.Office.Core.MsoTriState.msoFalse, Microsoft.Office.Core.MsoTriState.msoCTrue, Left, Top, 365, 270);
                // oRange.RowHeight = 367;
                // wrksheet.Cells[1, 20] = wrksheet.Shapes.AddPicture(pathServer + "/" + idimage[i], Microsoft.Office.Core.MsoTriState.msoFalse, Microsoft.Office.Core.MsoTriState.msoCTrue, 20, distance, 365, 270);
              
            //Image oImage = Image.FromFile(pathServer + "/" + idimage[i]);
            //wrksheet.Shapes.AddPicture(pathServer + "/" + idimage[i], Microsoft.Office.Core.MsoTriState.msoFalse, Microsoft.Office.Core.MsoTriState.msoCTrue, 20, distance, 365, 270);
          //  distance += 300;
            var deso = Global.Db.FeedBackExcel_User(id,cbb_username.Text, cbb_batch.Text).ToList();
            int h = 9;
            var nameCheck = (from w in Global.Db.GetNameCheck(id, cbb_batch.Text) select w.UserNameCheckDeSo).FirstOrDefault();
            wrksheet.Cells[r + 1, 10] = nameCheck + @" ";
            wrksheet.Cells[r + 1, h] = "UserName";
            wrksheet.Cells[r + 2, h] = "Trường 1";
            wrksheet.Cells[r + 3, h] = "Trường 3";
            wrksheet.Cells[r + 4, h] = "Trường 4";
            wrksheet.Cells[r + 5, h] = "Trường 5";
            wrksheet.Cells[r + 6, h] = "Trường 6";
            wrksheet.Cells[r + 7, h] = "Trường 7";
            wrksheet.Cells[r + 8, h] = "Trường 8";
            wrksheet.Cells[r + 9, h] = "Trường 9";
            wrksheet.Cells[r + 10, h] = "Trường 10";
            wrksheet.Cells[r + 11, h] = "Trường 11";
            wrksheet.Cells[r + 12, h] = "Trường 12";
            wrksheet.Cells[r + 13, h] = "Trường 13";
            wrksheet.Cells[r + 14, h] = "Trường 14";
         //   wrksheet.Cells[r + 15, h] = "FlagError";
            wrksheet.Cells[r+20 ,1] = id + "";
                wrksheet.Cells[r+1, 1] = i+1;
            for (int j = 0; j < deso.Count(); j++)
            {
                h++; if (j != 0)
                    {
                        wrksheet.Cells[r + 1, h] = deso[j].UserName + "";
                    }
                wrksheet.Cells[r + 2, h] = deso[j].TruongSo01 + "";
                wrksheet.Cells[r + 3, h] = deso[j].TruongSo03 + "";
                wrksheet.Cells[r + 4, h] = deso[j].TruongSo04 + "";
                wrksheet.Cells[r + 5, h] = deso[j].TruongSo05 + "";
                wrksheet.Cells[r + 6, h] = deso[j].TruongSo06 + "";
                wrksheet.Cells[r + 7, h] = deso[j].TruongSo07 + "";
                wrksheet.Cells[r + 8, h] = deso[j].TruongSo08 + "";
                wrksheet.Cells[r + 9, h] = deso[j].TruongSo09 + "";
                wrksheet.Cells[r + 10, h] = deso[j].TruongSo10 + "";
                wrksheet.Cells[r + 11, h] = deso[j].TruongSo11 + "";
                wrksheet.Cells[r + 12, h] = deso[j].TruongSo12 + "";
                wrksheet.Cells[r + 13, h] = deso[j].TruongSo13 + "";
                wrksheet.Cells[r + 14, h] = deso[j].TruongSo14 + "";
              //  wrksheet.Cells[r + 15, h] = deso[j].FlagError + "";
            }
               
            Microsoft.Office.Interop.Excel.Range cellImage1 = wrksheet.Cells[h - 10][r + 1];
            Microsoft.Office.Interop.Excel.Range cellImage2 = wrksheet.Cells[h][r + 20];
            Microsoft.Office.Interop.Excel.Range rangeImage = wrksheet.get_Range(cellImage1, cellImage2);
            rangeImage.BorderAround(Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous,Microsoft.Office.Interop.Excel.XlBorderWeight.xlThin,Microsoft.Office.Interop.Excel.XlColorIndex.xlColorIndexAutomatic, 1);
            Microsoft.Office.Interop.Excel.Range cell1 = wrksheet.Cells[h - 2][r + 1];
            Microsoft.Office.Interop.Excel.Range cell2 = wrksheet.Cells[h][r + 14];
            Microsoft.Office.Interop.Excel.Range range = wrksheet.get_Range(cell1, cell2);
            range.Borders.LineStyle = Microsoft.Office.Interop.Excel.Constants.xlSolid;
            range.Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.LightGreen);
            r += 21;

        }
        string savePath = "";
        saveFileDialog1.Title = "Save Excel Files";
        saveFileDialog1.Filter = "Excel files (*.xlsx)|*.xlsx";
        saveFileDialog1.FileName = "Feedback_" + cbb_batch.Text+"_"+cbb_username.Text;
        saveFileDialog1.RestoreDirectory = true;
        if (saveFileDialog1.ShowDialog() == DialogResult.OK)
        {
            book.SaveCopyAs(saveFileDialog1.FileName);
            book.Saved = true;
            savePath = Path.GetDirectoryName(saveFileDialog1.FileName);
            App.Quit();
        }
        else
        {
            MessageBox.Show(@"Error exporting excel!");
            return;
        }
        Process.Start(savePath);
    }

        #endregion
    }
}