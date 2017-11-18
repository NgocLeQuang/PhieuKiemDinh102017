using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Threading;

namespace PhieuKiemDinh.MyForm
{
    public partial class frm_ExportExcel : DevExpress.XtraEditors.XtraForm
    {
        public frm_ExportExcel()
        {
            InitializeComponent();
        }
        Microsoft.Office.Interop.Excel.Application App = null;
        Microsoft.Office.Interop.Excel.Workbook book = null;
        Microsoft.Office.Interop.Excel.Worksheet wrksheet = null;
        int h = 0;
        string namefileExcel = "";
        bool error13 = true;
        private void frm_ExportExcel_Load(object sender, EventArgs e)
        {
            cbb_Batch.DataSource = Global.Db.GetBatch();
            cbb_Batch.DisplayMember = "fBatchName";
            cbb_Batch.ValueMember = "id";
            cbb_Batch.Text = Global.StrBatch;
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            var CountImageNotComplete = (from w in Global.Db.CheckInputComplete(cbb_Batch.Text) select w.IdImage).ToList();
            var check = (from w in Global.Db.tbl_MissImage_DeSos where w.fBatchName == cbb_Batch.Text && w.Submit == 0 select w.IdImage).Count();

            if (CountImageNotComplete.Count > 0)
            {
                MessageBox.Show("Chưa nhập xong DeSo!");
                return;
            }
            if (check > 0)
            {
                var list_user = (from w in Global.Db.tbl_MissImage_DeSos where w.fBatchName == cbb_Batch.Text && w.Submit == 0 select w.UserName).ToList();
                string sss = "";
                foreach (var item in list_user)
                {
                    sss += item + "\r\n";
                }
                if (list_user.Count > 0)
                {
                    MessageBox.Show("Những user lấy hình về nhưng chưa nhập: \r\n" + sss);
                    return;
                }
            }
            
            var soloi = ((from w in Global.Db.tbl_DeSos where w.fBatchName == cbb_Batch.Text && w.Dem == 1 select w.IdImage).Count() / 2);

            var ListCheckNotComplete = (from w in Global.Db.tbl_Images where w.fBatchName == cbb_Batch.Text && w.ReadImageCheckDeSo == 1 && w.SubmitCheckDeSo == 0 select new { w.IdImage, w.UserNameCheckDeSo }).ToList();
            if (ListCheckNotComplete.Count > 0 || soloi > 0)
            {
                MessageBox.Show("Chưa check xong DeSo!");
                string sss = "";
                foreach (var item in ListCheckNotComplete)
                {
                    sss += item.UserNameCheckDeSo + "\r\n";
                }
                MessageBox.Show("Những user lấy hình về nhưng chưa check: \r\n" + sss);
                return;
            }
            
            if (File.Exists(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\ExportExcel.xlsx"))
            {
                File.Delete(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\ExportExcel.xlsx");
                File.WriteAllBytes((Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "/ExportExcel.xlsx"), Properties.Resources.ExportExcel);
            }
            else
            {
                File.WriteAllBytes((Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "/ExportExcel.xlsx"), Properties.Resources.ExportExcel);
            }
            //TableToExcel(System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments) + "\\ExportExcel.xlsx");
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = (from w in Global.Db.ExportExcel_PhieuKiemDinh_Red13(cbb_Batch.Text) select w).ToList();
            namefileExcel = "";
            error13 = true;
            App = new Microsoft.Office.Interop.Excel.Application();
            book = App.Workbooks.Open(System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments) + "\\ExportExcel.xlsx", 0, true, 5, "", "", false, Microsoft.Office.Interop.Excel.XlPlatform.xlWindows, "", true, false, 0, true, false, false);
            wrksheet = (Microsoft.Office.Interop.Excel.Worksheet)book.ActiveSheet;            
            backgroundWorker1.RunWorkerAsync();
        }
        
        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            progressBar1.Step = 1;
            progressBar1.Value = 0;
            progressBar1.Maximum = dataGridView1.RowCount;
            progressBar1.Minimum = 0;
            ModifyProgressBarColor.SetState(progressBar1, 1);
            h = 2;
            string red13 = "";
            for (int i = 0; i < dataGridView1.RowCount; i++)
            {
                string tempImageName = "";
                wrksheet.Cells[h, 1] = tempImageName = dataGridView1[0, i].Value + "";  //Trường 01/ Tên hình
                //wrksheet.Cells[h, 2] = dataGridView1[1, i].Value + "";  //Trường Flag Error
                wrksheet.Cells[h, 2] = dataGridView1[1, i].Value + "";  //Trường 03
                wrksheet.Cells[h, 3] = dataGridView1[2, i].Value + "";
                wrksheet.Cells[h, 4] = dataGridView1[3, i].Value + "";
                wrksheet.Cells[h, 5] = dataGridView1[4, i].Value + "";
                wrksheet.Cells[h, 6] = dataGridView1[5, i].Value + "";
                wrksheet.Cells[h, 7] = dataGridView1[6, i].Value + "";
                wrksheet.Cells[h, 8] = dataGridView1[7, i].Value + "";
                wrksheet.Cells[h, 9] = dataGridView1[8, i].Value + "";     //Trường 10
                //Trường 11
                string tempTruong11 = "";
                tempTruong11 = dataGridView1[9, i].Value + "";
                if (tempTruong11.IndexOf("?")>=0)
                {
                    wrksheet.Cells[h, 10] = "?";
                }
                else if (tempTruong11 == "●")
                {
                    wrksheet.Cells[h, 10] = "●";
                }
                else if (tempTruong11.Length == 6)
                {
                    if (int.Parse(tempTruong11) < 291001)
                        wrksheet.Cells[h, 10] = "1001";
                    else if (int.Parse(tempTruong11) > 291231)
                    {
                        tempImageName = tempImageName.Substring(0, 3);
                        switch (tempImageName)
                        {
                            case "01_":
                            case "02_":
                                wrksheet.Cells[h, 10] = "1031";
                                break;
                            case "03_":
                            case "04_":
                                wrksheet.Cells[h, 10] = "1130";
                                break;
                            case "05_":
                            case "06_":
                                wrksheet.Cells[h, 10] = "1231";
                                break;
                            case "07_":
                                wrksheet.Cells[h, 10] = "1231";
                                break;
                        }
                    }
                    else
                    {
                        wrksheet.Cells[h, 10] = tempTruong11.Substring(2,4);
                    }
                }
                else if (tempTruong11.Length < 6)
                {
                    tempImageName = tempImageName.Substring(0, 3);
                    switch (tempImageName)
                    {
                        case "01_":
                        case "02_":
                            wrksheet.Cells[h, 10] = "1031";
                            break;
                        case "03_":
                        case "04_":
                            wrksheet.Cells[h, 10] = "1130";
                            break;
                        case "05_":
                        case "06_":
                            wrksheet.Cells[h, 10] = "1231";
                            break;
                        case "07_":
                            wrksheet.Cells[h, 10] = "1231";
                            break;
                    }
                }
                else if (tempTruong11.Length > 6)
                {
                    wrksheet.Cells[h, 10] = tempTruong11;
                }
                wrksheet.Cells[h, 11] = dataGridView1[10, i].Value + "";    //Trường 12
                wrksheet.Cells[h, 12] = dataGridView1[11, i].Value + "";    //Trường 13
                wrksheet.Cells[h, 13] = dataGridView1[12, i].Value + "";    //Trường 14
                red13 = "";
                red13 = dataGridView1[13, i].Value.ToString();
                if (red13.IndexOf('1') >= 0 && error13== true)
                {
                    wrksheet.Cells[h, 12].Interior.ColorIndex = 3;
                }
                lb_Complete.Text = (i + 1) + "/" + dataGridView1.RowCount;
                progressBar1.PerformStep();
                h++;
            }
            Microsoft.Office.Interop.Excel.Range rowHead = wrksheet.get_Range("A1", "M" + (h - 1));
            rowHead.Borders.LineStyle = Microsoft.Office.Interop.Excel.Constants.xlSolid;
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            string savePath = "";
            saveFileDialog1.Title = "Save Excel Files";
            saveFileDialog1.Filter = "Excel files (*.xlsx)|*.xlsx";
            saveFileDialog1.FileName = cbb_Batch.Text+namefileExcel;
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

        private void cbb_Batch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != 3)
                e.Handled = true;
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            var CountImageNotComplete = (from w in Global.Db.CheckInputComplete(cbb_Batch.Text) select w.IdImage).ToList();
            var check = (from w in Global.Db.tbl_MissImage_DeSos where w.fBatchName == cbb_Batch.Text && w.Submit == 0 select w.IdImage).Count();

            if (CountImageNotComplete.Count > 0)
            {
                MessageBox.Show("Chưa nhập xong DeSo!");
                return;
            }
            if (check > 0)
            {
                var list_user = (from w in Global.Db.tbl_MissImage_DeSos where w.fBatchName == cbb_Batch.Text && w.Submit == 0 select w.UserName).ToList();
                string sss = "";
                foreach (var item in list_user)
                {
                    sss += item + "\r\n";
                }
                if (list_user.Count > 0)
                {
                    MessageBox.Show("Những user lấy hình về nhưng chưa nhập: \r\n" + sss);
                    return;
                }
            }

            var soloi = ((from w in Global.Db.tbl_DeSos where w.fBatchName == cbb_Batch.Text && w.Dem == 1 select w.IdImage).Count() / 2);

            var ListCheckNotComplete = (from w in Global.Db.tbl_Images where w.fBatchName == cbb_Batch.Text && w.ReadImageCheckDeSo == 1 && w.SubmitCheckDeSo == 0 select new { w.IdImage, w.UserNameCheckDeSo }).ToList();
            if (ListCheckNotComplete.Count > 0 || soloi > 0)
            {
                MessageBox.Show("Chưa check xong DeSo!");
                string sss = "";
                foreach (var item in ListCheckNotComplete)
                {
                    sss += item.UserNameCheckDeSo + "\r\n";
                }
                MessageBox.Show("Những user lấy hình về nhưng chưa check: \r\n" + sss);
                return;
            }

            if (File.Exists(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\ExportExcel.xlsx"))
            {
                File.Delete(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\ExportExcel.xlsx");
                File.WriteAllBytes((Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "/ExportExcel.xlsx"), Properties.Resources.ExportExcel);
            }
            else
            {
                File.WriteAllBytes((Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "/ExportExcel.xlsx"), Properties.Resources.ExportExcel);
            }
            //TableToExcel(System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments) + "\\ExportExcel.xlsx");
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = (from w in Global.Db.ExportExcel_Error_PhieuKiemDinh_Red13(cbb_Batch.Text) select w ).ToList();
            namefileExcel = "_Error";
            error13 = false;
            App = new Microsoft.Office.Interop.Excel.Application();
            book = App.Workbooks.Open(System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments) + "\\ExportExcel.xlsx", 0, true, 5, "", "", false, Microsoft.Office.Interop.Excel.XlPlatform.xlWindows, "", true, false, 0, true, false, false);
            wrksheet = (Microsoft.Office.Interop.Excel.Worksheet)book.ActiveSheet;
            backgroundWorker1.RunWorkerAsync();
        }
      
    }

}