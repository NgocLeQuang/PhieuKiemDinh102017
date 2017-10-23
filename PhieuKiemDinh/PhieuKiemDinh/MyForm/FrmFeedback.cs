using System;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Windows.Forms;
using System.Diagnostics;
using DevExpress.XtraEditors;
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
            string NameUserChecker = "Checker%";
            idimage = (from w in (Global.Db.GetImageFail(NameUserChecker, cbb_batch.Text)) select w.IdImage).ToList();
            lb_soloi.Text = idimage.Count.ToString();
            if ((n + 30) < idimage.Count && n >= 0)
            {
                btn_next.Enabled = true;
                for (int j = n; j <= n + 29; j++)
                {
                    string id = idimage[j];
                    UC_FeedBack ucF = new UC_FeedBack();
                    // ucF.uc_PictureBox1.FocusPicture += UcF_FocusPicture;
                    //  ucF.uc_PictureBox1.FocusPictureLeave += UcPictureBox1_FocusPictureLeave;
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
                    //ucF.ucPictureBox1.FocusPicture += UcF_FocusPicture;
                    // ucF.ucPictureBox1.FocusPictureLeave += UcPictureBox1_FocusPictureLeave;
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
                    //      ucF.ucPictureBox1.FocusPicture += UcF_FocusPicture;ucF.ucPictureBox1.FocusPictureLeave += UcPictureBox1_FocusPictureLeave;
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
                    //ucF.ucPictureBox1.FocusPicture += UcF_FocusPicture;
                    // ucF.ucPictureBox1.FocusPictureLeave += UcPictureBox1_FocusPictureLeave;
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
                Num += 50;
                if (Num < 50)
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
                Num -= 50;
                if (Num < 50)
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

        Microsoft.Office.Interop.Excel.Application App = null;
        Microsoft.Office.Interop.Excel.Workbook book = null;
        Microsoft.Office.Interop.Excel.Worksheet wrksheet = null;
        private void btn_ExportExcel_Click(object sender, EventArgs e)
        {
            if (File.Exists(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\ExportExcel.xlsx"))
            {
                File.Delete(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\ExportExcel.xlsx");
                File.WriteAllBytes((Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "/ExportExcel.xlsx"), Properties.Resources.ExportExcel);
            }
            else
            {
                File.WriteAllBytes((Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "/ExportExcel.xlsx"), Properties.Resources.ExportExcel);
            }

            int h = 2;
            App = new Microsoft.Office.Interop.Excel.Application();
            book = App.Workbooks.Open(System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments) + "\\ExportExcel.xlsx", 0, true, 5, "", "", false, Microsoft.Office.Interop.Excel.XlPlatform.xlWindows, "", true, false, 0, true, false, false);
            wrksheet = (Microsoft.Office.Interop.Excel.Worksheet)book.ActiveSheet;
            string pathServer = Global.StrPath +"/"+ cbb_batch.Text;

            Microsoft.Office.Interop.Excel.Range oRange = (Microsoft.Office.Interop.Excel.Range)wrksheet.Cells[h, 1];
            Image oImage = Image.FromFile(pathServer+"/"+ idimage[0]);
            
            wrksheet.Shapes.AddPicture(pathServer + "/" + idimage[0], Microsoft.Office.Core.MsoTriState.msoFalse,o Microsoft.Office.Core.MsoTriState.msoCTrue, 0, 0, 300, 300);
            //System.Windows.Forms.Clipboard.SetDataObject(oImage, true);
            //wrksheet.Paste(oRange, pathServer + "/" + idimage[0]);


            h++;
            Microsoft.Office.Interop.Excel.Range rowHead = wrksheet.get_Range("A1", "N" + (h - 1));
            rowHead.Borders.LineStyle = Microsoft.Office.Interop.Excel.Constants.xlSolid;
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
    }
}