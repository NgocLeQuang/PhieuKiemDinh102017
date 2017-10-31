using DevExpress.XtraGrid.Views.Grid;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace PhieuKiemDinh.MyForm
{
    public partial class frm_CreateBatch : DevExpress.XtraEditors.XtraForm
    {
        private string[] lFileNames;
        private DateTime TimeBeginCreateBatch;
        public frm_CreateBatch()
        {
            InitializeComponent();
        }

        public bool Cal(int width, GridView view)
        {
            view.IndicatorWidth = view.IndicatorWidth < width ? width : view.IndicatorWidth;
            return true;
        }

        private void LoadSttGridView(RowIndicatorCustomDrawEventArgs e, GridView dgv)
        {
            if (e.Info.IsRowIndicator && e.RowHandle >= 0)
                e.Info.DisplayText = (e.RowHandle + 1).ToString();
            SizeF size = e.Graphics.MeasureString(e.Info.DisplayText, e.Appearance.Font);
            int width = Convert.ToInt32(size.Width) + 20;
            BeginInvoke(new MethodInvoker(delegate { Cal(width, dgv); }));
        }
        public struct point_rectangle
        {
            public int x1, y1, x2, y2;

            public int _x1
            {
                get { return x1; }
                set { x1 = value; }
            }

            public int _x2
            {
                get { return x2; }
                set { x2 = value; }
            }
            public int _y1
            {
                get { return y1; }
                set { y1 = value; }
            }
            public int _y2
            {
                get { return y2; }
                set { y2 = value; }
            }
        }

        public List<point_rectangle> pr = new List<point_rectangle>();
        
        private void frm_CreateBatch_Load(object sender, EventArgs e)
        {
            //lb_SobatchHoanThanh.Text = "";
            //lb_SoBatch.Text = "";
            txt_UserCreate.Text = Global.StrUserName;
            txt_DateCreate.Text = DateTime.Now.ToShortDateString() + "  -  " + DateTime.Now.ToShortTimeString();
            string[] foldersAll = Directory.GetDirectories(Global.StrPath);
            string folder = "";
            DateTime? DateCreateBatch;
            bool Is_Exists = false;
            category.Clear();
            var listBatch = (from w in Global.Db.GetBatch_Full() select new { w.fBatchName, w.NgayTaoBatch }).ToList();
            for (int i = 0; i < foldersAll.Count(); i++)
            {
                DirectoryInfo fi = new DirectoryInfo(foldersAll[i]);
                folder = fi.Name;
                DateCreateBatch = null;
                if (listBatch.Exists(x => x.fBatchName == (folder)))
                {
                    Is_Exists = true;
                    DateCreateBatch = (from w in listBatch where w.fBatchName == folder select w.NgayTaoBatch).FirstOrDefault();
                }
                else
                    Is_Exists = false;
                lFileNames = Directory.GetFiles(Global.StrPath +@"\"+ folder, "*.jpg").Select(Path.GetFileName).
                    Union(Directory.GetFiles(Global.StrPath + @"\" + folder, "*.jpeg").Select(Path.GetFileName).
                    Union(Directory.GetFiles(Global.StrPath + @"\" + folder, "*.png").Select(Path.GetFileName))).ToArray();
                category.Add(new Category() { Folder = folder, NumberImage = lFileNames.Count(),Is_Exists=Is_Exists,DateCreateFolder= fi.LastAccessTime, DateCreateBatch= DateCreateBatch });
            }
            gridControl1.DataSource = (from w in category orderby w.Is_Exists descending, w.DateCreateBatch ascending, w.DateCreateFolder ascending select w).ToList();
        }

        string listBatchExists = "";
        int countBatchExists = 0;
        List<string> batchExists = new List<string>();
        private void btn_TaoBatch_Click(object sender, EventArgs e)
        {
            batchExists.Clear();
            listBatchExists = "";
            countBatchExists = 0;
            timer1.Enabled = false;
            fbatchname = "";
            if (!Directory.Exists(Global.StrPath))
            {
                MessageBox.Show("Không thể mở thư mục lưu trữ hình ảnh.\r\nBạn hãy kiểm tra lại tài khoản đăng nhập hoặc kết nối internet");
                return;
            }
            else
            {
                try
                {
                    string path = Global.StrPath + @"\MyTest.txt";
                    using (StreamWriter sw = File.CreateText(path))
                    {
                        sw.WriteLine("Hello");
                        sw.WriteLine("And");
                        sw.WriteLine("Welcome");
                    }
                    File.Delete(path);
                }
                catch { MessageBox.Show("Bạn chưa được cấp quyền để mở thư mục lưu trữ hình ảnh."); }
            }
            if(gridView1.GetSelectedRows().Count()<=0)
            {
                MessageBox.Show("Hạy chọn batch!");
                return;
            }
            foreach (var rowHandle in gridView1.GetSelectedRows())
            {
                fbatchname = gridView1.GetRowCellValue(rowHandle, "Folder").ToString();
                batchExists = (from w in Global.Db.tbl_Batches where w.fBatchName == fbatchname select w.fBatchName).ToList();
                if (batchExists.Count > 0)
                {
                    countBatchExists += 1;
                    listBatchExists += batchExists[0] + "\r\n";
                }
            }
            if (countBatchExists > 0)
            {
                MessageBox.Show("Batch đã tồn tại trong database :\r\n" + listBatchExists);
                return;
            }
            if (backgroundWorker1.IsBusy)
            {
                MessageBox.Show("Quá trình tạo batch đang diễn ra, Bạn hãy chờ quá trình tạo batch kết thúc mới tiếp tục tạo batch mới !");
                return;
            }
            backgroundWorker1.RunWorkerAsync();
        }
        
        public class Category
        {
            public string Folder { get; set; }
            public int NumberImage { get; set; }
            public bool Is_Exists { get; set; }
            public DateTime DateCreateFolder { get; set; }
            public DateTime? DateCreateBatch { get; set; }
        }

        private List<Category> category = new List<Category>();

        int ChiaUser = 0, solaninsert = 0;
        string temp = "";
        string fbatchname = "";
        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            //lb_SobatchHoanThanh.Text = "";
            //lb_SoBatch.Text = "";
            ChiaUser = 0;
            temp = "";
            fbatchname = "";
            if (ck_ChiaUser.Checked)
            {
                ChiaUser = 1;
            }
            try
            {

                foreach (var rowHandle in gridView1.GetSelectedRows())
                {
                    fbatchname = "";
                    lFileNames = null;
                    solaninsert = 0;
                    fbatchname = gridView1.GetRowCellValue(rowHandle, "Folder").ToString();
                    lFileNames = Directory.GetFiles(Global.StrPath + @"\" + fbatchname, "*.jpg").Select(Path.GetFileName).ToArray();
                    Global.Db.InsertBatch(fbatchname, Global.StrUserName, "", lFileNames.Count() + "", ChiaUser);
                    solaninsert = (int)Math.Round(((decimal)lFileNames.Count() / 150), 0, MidpointRounding.AwayFromZero);
                    if ((decimal)solaninsert < (decimal)lFileNames.Count() / 150)
                    {
                        solaninsert += 1;
                    }
                    int numberRecordLast = lFileNames.Count() - 150 * (solaninsert - 1);

                    for (int k = 1; k <= solaninsert; k += 1)
                    {
                        temp = "";
                        if (k == solaninsert)
                        {
                            for (int i = (k - 1) * 150; i < lFileNames.Count(); i++)
                            {
                                temp += lFileNames[i] + "!@#";
                            }
                            Global.Db.Insert_Image_New(fbatchname, temp, ChiaUser);
                        }
                        else
                        {
                            for (int i = (k - 1) * 150; i < k * 150; i++)
                            {
                                temp += lFileNames[i] + "!@#";
                            }
                            Global.Db.Insert_Image_New(fbatchname, temp, ChiaUser);
                        }
                    }
                }
                MessageBox.Show("Tạo batch thành công!");
            }
            catch (Exception i)
            {
                MessageBox.Show("Xảy ra lỗi : " + i.Message);
                gridControl1.Enabled = true;
                ck_ChiaUser.Enabled = true;
                timer1.Enabled = true;
            }
            frm_CreateBatch_Load(null, null);
            gridControl1.Enabled = true;
            ck_ChiaUser.Enabled = true;
            timer1.Enabled = true;
        }

        public static string[] GetFilesFrom(string searchFolder, string[] filters, bool isRecursive)
        {
            List<string> filesFound = new List<string>();
            var searchOption = isRecursive ? SearchOption.AllDirectories : SearchOption.TopDirectoryOnly;
            foreach (var filter in filters)
            {
                filesFound.AddRange(Directory.GetFiles(searchFolder, $"*.{filter}", searchOption));
            }
            return filesFound.ToArray();
        }

        private bool closePending;

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            if (backgroundWorker1.IsBusy)
            {
                MessageBox.Show("Quá trình tạo batch đang diễn ra, Bạn hãy chờ quá trình tạo batch kết thúc!");
                e.Cancel = true;
            }
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (closePending) Close();
            closePending = false;
        }

        private void comboBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != 3)
                e.Handled = true;
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            lFileNames = Directory.GetFiles(@"\\10.10.10.248\phieukiemdinh$\B111", "*.jpeg").Select(Path.GetFileName)
                                     .Union(Directory.GetFiles(@"\\10.10.10.248\phieukiemdinh$\B111", "*.jpg").Select(Path.GetFileName)).ToArray();
            string path = Global.StrPath + @"\MyTest.txt";
            string temp = "";
            for(int i=0;i< lFileNames.Count();i++)
            {
                temp += (i+1)+lFileNames[i] + "!@#";
            }
            using (StreamWriter sw = File.CreateText(path))
            {
                sw.WriteLine(temp);
            }
        }

        private void gridView1_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            LoadSttGridView(e, gridView1);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            frm_CreateBatch_Load(null,null);
        }

        private void frm_CreateBatch_FormClosing(object sender, FormClosingEventArgs e)
        {
            timer1.Enabled = false;
        }
    }
    public static class ModifyProgressBarColor
    {
        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = false)]
        static extern IntPtr SendMessage(IntPtr hWnd, uint Msg, IntPtr w, IntPtr l);
        public static void SetState(this ProgressBar pBar, int state)
        {
            SendMessage(pBar.Handle, 1040, (IntPtr)state, IntPtr.Zero);
        }
    }
}