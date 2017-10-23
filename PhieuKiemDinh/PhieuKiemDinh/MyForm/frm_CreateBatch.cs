﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace PhieuKiemDinh.MyForm
{
    public partial class frm_CreateBatch : DevExpress.XtraEditors.XtraForm
    {
        private string csvpath = "";
        private string[] lFileNames;
        private string loaibatch;
        private int soluonganh = 0;
        private DateTime TimeBeginCreateBatch;
        Image Imagetemp;
        public frm_CreateBatch()
        {
            InitializeComponent();
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

        private void btn_ChonAnh_Click(object sender, EventArgs e)
        {
            lFileNames = null;
            if (string.IsNullOrEmpty(txt_fBatchName.Text))
            {
                MessageBox.Show("Vui lòng điền tên Batch", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "All Types Image|*.bmp;*.jpg;*.jpeg;*.png;*.tif;*.tiff";

            dlg.Multiselect = true;

            if (dlg.ShowDialog() == DialogResult.OK)
            {
                lFileNames = dlg.FileNames;
                txt_ImagePath.Text = Path.GetDirectoryName(dlg.FileName);
            }
            soluonganh = dlg.FileNames.Length;
            lb_SoLuongAnh.Text = soluonganh + " files ";
        }

        private void frm_CreateBatch_Load(object sender, EventArgs e)
        {
            lb_SobatchHoanThanh.Text = "";
            lb_SoBatch.Text = "";
            txt_UserCreate.Text = Global.StrUserName;
            var a= (from w in Global.Db.GetBatch_ToaDo() select w.fBatchName).ToList();
            a.Insert(0,"");
            comboBox1.DataSource = a;
            comboBox1.DisplayMember = "fBatchName";
            txt_DateCreate.Text = DateTime.Now.ToShortDateString() + "  -  " + DateTime.Now.ToShortTimeString();
        }

        private void btn_TaoBatch_Click(object sender, EventArgs e)
        {
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
                catch { MessageBox.Show("Bạn chưa được cấp quyền để tạo thư mục lưu trữ hình ảnh."); }
            }
            if (backgroundWorker1.IsBusy)
            {
                MessageBox.Show("Quá trình tạo batch đang diễn ra, Bạn hãy chờ quá trình tạo batch kết thúc mới tiếp tục tạo batch mới !");
                return;
            }
            if(string.IsNullOrEmpty(txt_fBatchName.Text) && string.IsNullOrEmpty(txt_folder_Multiline.Text))
            {
                MessageBox.Show("Hãy nhập tên batch hoặc chọn folder hình ảnh !");
                return;
            }
            if (string.IsNullOrEmpty(txt_ImagePath.Text)&& !string.IsNullOrEmpty(txt_fBatchName.Text))
            {
                MessageBox.Show("Chưa chọn hình ảnh!");
                return;
            }
            if (string.IsNullOrEmpty(comboBox1.Text))
            {
                MessageBox.Show("Bạn chưa chọn tọa độ !");
                return;
            }
            string temp = Global.StrPath + "\\" + txt_fBatchName.Text;
            if (!Directory.Exists(temp) & !string.IsNullOrEmpty(txt_fBatchName.Text))
            {
                Directory.CreateDirectory(temp);
            }
            else if(!string.IsNullOrEmpty(txt_fBatchName.Text))
            {
                MessageBox.Show("Bị trùng tên thư mục chứa hình!");
                return;
            }
            var batch = (from w in Global.Db.GetBatchCheckExists(txt_fBatchName.Text) select w.fBatchName).FirstOrDefault();
            if (!string.IsNullOrEmpty(txt_ImagePath.Text) && !string.IsNullOrEmpty(txt_fBatchName.Text))
            {
                if (string.IsNullOrEmpty(batch))
                {
                    Global.Db.InsertBatch(txt_fBatchName.Text, txt_UserCreate.Text, txt_ImagePath.Text, soluonganh.ToString(),ck_ChiaUser.Checked ? 1:0);
                }
                else
                {
                    MessageBox.Show("Batch đã tồn tại vui lòng điền tên batch khác!");
                    return;
                }
            }
            else if(string.IsNullOrEmpty(txt_ImagePath.Text) && !string.IsNullOrEmpty(txt_fBatchName.Text))
            {
                MessageBox.Show("Bạn chưa chọn hình ảnh!");
                return;
            }
            TimeBeginCreateBatch = DateTime.Now;
            txt_fBatchName.ReadOnly = true;
            txt_ImagePath.ReadOnly = true;
            txt_folder_Multiline.ReadOnly = true;
            ck_ChiaUser.Enabled = false;
            btn_Browser.Enabled = false;
            comboBox1.Enabled = false;
            btn_ChonAnh.Enabled = false;
            btn_drawhide.Enabled = false;
            btn_ShowPoint.Enabled = false;
            lb_SobatchHoanThanh.Text = "";
            lb_SoBatch.Text = "";
            var ListToaDo = (from w in Global.Db.GetToaDo(comboBox1.Text + "") select w).ToList();
            for(int i=0;i<ListToaDo.Count;i++)
            {
                point_rectangle a = new point_rectangle
                {
                    _x1 = int.Parse(ListToaDo[i].x1 + ""),
                    _x2 = int.Parse(ListToaDo[i].x2 + ""),
                    _y1 = int.Parse(ListToaDo[i].y1 + ""),
                    _y2 = int.Parse(ListToaDo[i].y2 + "")
                };
                pr.Add(a);
            }
            multiline = -1;
            if (!string.IsNullOrEmpty(txt_fBatchName.Text) & string.IsNullOrEmpty(txt_folder_Multiline.Text))
                multiline = 0;
            else if (string.IsNullOrEmpty(txt_fBatchName.Text) & !string.IsNullOrEmpty(txt_folder_Multiline.Text))
                multiline = 1;
            backgroundWorker1.RunWorkerAsync();
        }

        int multiline = -1;

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            int ChiaUser = 0;
            if (ck_ChiaUser.Checked)
            {
                ChiaUser = 1;
            }
            //Up Single
            if (multiline == 0)
            {
                try
                {
                    progressBar1.Step = 1;
                    progressBar1.Value = 0;
                    progressBar1.Maximum = lFileNames.Length;
                    progressBar1.Minimum = 0;
                    ModifyProgressBarColor.SetState(progressBar1, 1);
                    string batchtemp = Global.StrPath + "\\" + txt_fBatchName.Text;
                    int m = 1;
                    foreach (string i in lFileNames)
                    {
                        FileInfo fi = new FileInfo(i);
                        Global.Db.InsertImage(txt_fBatchName.Text, Path.GetFileName(fi.ToString()), ChiaUser);
                        Imagetemp = Image.FromFile(fi.FullName + "");
                        pictureBox1.Height = Imagetemp.Height;
                        pictureBox1.Width = Imagetemp.Width;
                        pictureBox1.SizeMode = PictureBoxSizeMode.Normal;
                        pictureBox1.Image = Imagetemp;
                        Bitmap bmap = null;
                        Bitmap newmap = null;
                        for (int j = 0; j < pr.Count; j++)
                        {
                            int temp_x1 = 0, temp_y1 = 0, temp_x2 = 0, temp_y2 = 0;
                            if (pr[j]._x2 < pr[j]._x1)
                            {
                                temp_x1 = pr[j]._x2;
                                temp_x2 = pr[j]._x1;
                            }
                            else
                            {
                                temp_x1 = pr[j]._x1;

                                temp_x2 = pr[j]._x2;
                            }
                            if (pr[j]._y2 < pr[j]._y1)
                            {
                                temp_y1 = pr[j]._y2;
                                temp_y2 = pr[j]._y1;
                            }
                            else
                            {
                                temp_y1 = pr[j]._y1;
                                temp_y2 = pr[j]._y2;
                            }
                            bmap = new Bitmap(pictureBox1.Image);
                            newmap = bmap.Clone(new Rectangle(0, 0, bmap.Width, bmap.Height), System.Drawing.Imaging.PixelFormat.DontCare);

                            Graphics g1 = Graphics.FromImage(newmap);
                            g1.FillRectangle(Brushes.WhiteSmoke, new Rectangle(temp_x1, temp_y1, temp_x2 - temp_x1, temp_y2 - temp_y1));
                            pictureBox1.Image = null;
                            pictureBox1.Image = newmap;
                        }
                        newmap.Save(batchtemp + @"\" + Path.GetFileName(fi.FullName), System.Drawing.Imaging.ImageFormat.Jpeg);
                        lb_SobatchHoanThanh.Text = "Image: " + m + @"\" + lFileNames.Length;
                        m++;
                        progressBar1.PerformStep();
                    }
                    MessageBox.Show("Tạo batch mới thành công!\r\nThời gian tạo batch từ " + TimeBeginCreateBatch + " đến " + DateTime.Now);
                    txt_fBatchName.Text = "";
                    txt_ImagePath.Text = "";
                    txt_folder_Multiline.Text = "";
                    lb_SoLuongAnh.Text = "";
                    lb_SoBatch.Text = "";
                    soluonganh = 0;
                    txt_fBatchName.ReadOnly = false;
                    txt_folder_Multiline.ReadOnly = false;
                    txt_ImagePath.ReadOnly = false;
                    btn_Browser.Enabled = true;
                    ck_ChiaUser.Enabled = true;
                    ck_ChiaUser.Checked = false;
                    comboBox1.Enabled = true;
                    btn_drawhide.Enabled = true;
                    btn_ShowPoint.Enabled = true;
                    btn_ChonAnh.Enabled = true;
                }
                catch (Exception r)
                {
                    MessageBox.Show("Lỗi:\n" + r);
                }
            }
            else if (multiline == 1) //Up Multiline
            {
                try
                {
                    List<string> lStrBath = new List<string>();
                    lStrBath.AddRange(Directory.GetDirectories(txt_folder_Multiline.Text));
                    int countBatchExists = 0, n = 0;
                    string listBatchExists = "";
                    for (int i = 0; i < lStrBath.Count; i++)
                    {
                        var batchExists = (from w in Global.Db.tbl_Batches where w.fBatchName == new DirectoryInfo(lStrBath[i]).Name select w.fBatchName).ToList();
                        if (batchExists.Count > 0)
                        {
                            countBatchExists += 1;
                            listBatchExists += batchExists[0] + "\r\n";
                        }
                    }
                    if (countBatchExists > 0)
                    {
                        MessageBox.Show("Batch đã tồn tại :\r\n" + listBatchExists);
                        return;
                    }
                    foreach (string itemBatch in lStrBath)
                    {
                        string batchNametemp = new DirectoryInfo(itemBatch).Name;
                        string batchtemp = Global.StrPath + "\\" + batchNametemp;
                        if (Directory.Exists(batchtemp))
                        {
                            countBatchExists += 1;
                            listBatchExists += batchNametemp + "\r\n";
                        }
                    }
                    if (countBatchExists > 0)
                    {
                        MessageBox.Show("Bị trùng tên thư mục chứa hình :\r\n" + listBatchExists);
                        return;
                    }
                    string batchName = "";
                    FileInfo fi = null;
                    Bitmap bmap = null;
                    Bitmap newmap = null;
                    Graphics g1 = null;
                    int temp_x1 = 0, temp_y1 = 0, temp_x2 = 0, temp_y2 = 0,m=0;
                    foreach (string itemBatch in lStrBath)
                    {
                        batchName = new DirectoryInfo(itemBatch).Name;
                        m = 0;
                        string batchtemp = Global.StrPath + "\\" + batchName;
                        var filters = new String[] { "jpg", "jpeg", "png", "gif", "tif", "bmp" };
                        lFileNames = GetFilesFrom(itemBatch, filters, false);
                        Global.Db.InsertBatch(batchName, txt_UserCreate.Text, itemBatch, Directory.GetFiles(itemBatch).Length.ToString(), ChiaUser);
                        Directory.CreateDirectory(batchtemp);
                        n++;
                        lb_SoBatch.Text = "Batch: " + n + @"\" + lStrBath.Count();
                        progressBar1.Step = 1;
                        progressBar1.Value = 0;
                        progressBar1.Maximum = lFileNames.Length;
                        progressBar1.Minimum = 0;
                        ModifyProgressBarColor.SetState(progressBar1, 1);
                        foreach (string i in lFileNames)
                        {
                            fi= new FileInfo(i);
                            Global.Db.InsertImage(batchName, Path.GetFileName(fi.ToString()), ChiaUser);
                            Imagetemp = Image.FromFile(fi.FullName + "");
                            pictureBox1.Height = Imagetemp.Height;
                            pictureBox1.Width = Imagetemp.Width;
                            pictureBox1.SizeMode = PictureBoxSizeMode.Normal;
                            pictureBox1.Image = Imagetemp;
                            for (int j = 0; j < pr.Count; j++)
                            {
                                if (pr[j]._x2 < pr[j]._x1)
                                {
                                    temp_x1 = pr[j]._x2;
                                    temp_x2 = pr[j]._x1;
                                }
                                else
                                {
                                    temp_x1 = pr[j]._x1;

                                    temp_x2 = pr[j]._x2;
                                }
                                if (pr[j]._y2 < pr[j]._y1)
                                {
                                    temp_y1 = pr[j]._y2;
                                    temp_y2 = pr[j]._y1;
                                }
                                else
                                {
                                    temp_y1 = pr[j]._y1;
                                    temp_y2 = pr[j]._y2;
                                }
                                bmap = new Bitmap(pictureBox1.Image);
                                newmap = bmap.Clone(new Rectangle(0, 0, bmap.Width, bmap.Height), System.Drawing.Imaging.PixelFormat.DontCare);

                                g1 = Graphics.FromImage(newmap);
                                g1.FillRectangle(Brushes.WhiteSmoke, new Rectangle(temp_x1, temp_y1, temp_x2 - temp_x1, temp_y2 - temp_y1));
                                pictureBox1.Image = null;
                                pictureBox1.Image = newmap;
                            }
                            newmap.Save(batchtemp + @"\" + Path.GetFileName(fi.FullName), System.Drawing.Imaging.ImageFormat.Jpeg);
                            bmap.Dispose();
                            newmap.Dispose();
                            g1.Dispose();
                            (pictureBox1.Image).Dispose();
                            lb_SobatchHoanThanh.Text = "Image: " + m + @"\" + lFileNames.Length;
                            m++;
                            progressBar1.PerformStep();
                        }
                    }
                    MessageBox.Show("Tạo batch mới thành công!\r\nThời gian tạo batch từ " + TimeBeginCreateBatch + " đến " + DateTime.Now);
                    txt_fBatchName.Text = "";
                    txt_ImagePath.Text = "";
                    txt_folder_Multiline.Text = "";
                    lb_SoBatch.Text = "";
                    lb_SoLuongAnh.Text = "";
                    soluonganh = 0;
                    txt_folder_Multiline.ReadOnly = false;
                    btn_Browser.Enabled = true;
                    txt_fBatchName.ReadOnly = false;
                    txt_ImagePath.ReadOnly = false;
                    ck_ChiaUser.Enabled = true;
                    ck_ChiaUser.Checked = false;
                    comboBox1.Enabled = true;
                    btn_drawhide.Enabled = true;
                    btn_ShowPoint.Enabled = true;
                    btn_ChonAnh.Enabled = true;
                }
                catch (Exception p)
                {
                    MessageBox.Show("Lỗi :\r\n" + p.Message);
                }
            }
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

        private void btn_drawhide_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty((from w in Global.Db.tbl_Point_Hides where w.fBatchName== txt_fBatchName.Text select w.fBatchName).FirstOrDefault()+""))
            {
                MessageBox.Show("Tọa độ đã tồn tại vui lòng điền tên tọa độ khác!");
                return;
            }
            if (string.IsNullOrEmpty(txt_fBatchName.Text))
            {
                MessageBox.Show("Hãy nhập tên batch !");
                return;
            }
            frm_DrawHide fd = new frm_DrawHide();
            fd.fbatchname = txt_fBatchName.Text;
            fd.ShowDialog();
            var a = (from w in Global.Db.GetBatch_ToaDo() select w.fBatchName).ToList();
            a.Insert(0, "");
            comboBox1.DataSource = a;
            comboBox1.DisplayMember = "fBatchName";
            if (!string.IsNullOrEmpty((from w in Global.Db.tbl_Point_Hides where w.fBatchName == txt_fBatchName.Text select w.fBatchName).FirstOrDefault() + ""))
            {
                comboBox1.SelectedText = txt_fBatchName.Text;
            }
        }

        private void comboBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != 3)
                e.Handled = true;
        }

        private void btn_ShowPoint_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(comboBox1.Text))
            {
                MessageBox.Show("Bạn chưa chọn tọa độ !");
                return;
            }
            frm_DrawHide fd = new frm_DrawHide();
            string fbatchPoint = comboBox1.Text;
            fd.fbatchname = fbatchPoint;
            fd.ShowDialog();
            var a = (from w in Global.Db.GetBatch_ToaDo() select w.fBatchName).ToList();
            a.Insert(0, "");
            comboBox1.DataSource = a;
            comboBox1.DisplayMember = "fBatchName";
            if (!string.IsNullOrEmpty((from w in Global.Db.tbl_Point_Hides where w.fBatchName == txt_fBatchName.Text select w.fBatchName).FirstOrDefault() + ""))
            {
                comboBox1.SelectedText = txt_fBatchName.Text;
            }
        }

        private void txt_fBatchName_EditValueChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txt_fBatchName.Text))
            {
                txt_folder_Multiline.Text = "";
                txt_folder_Multiline.Enabled = false;
                btn_Browser.Enabled = false;
            }
            else
            {
                txt_folder_Multiline.Enabled = true;
                btn_Browser.Enabled = true;
            }
        }

        private void txt_folder_Multiline_EditValueChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txt_folder_Multiline.Text))
            {
                txt_fBatchName.Text = "";
                txt_fBatchName.Enabled = false;
                txt_ImagePath.Text = "";
                txt_ImagePath.Enabled = false;
                btn_ChonAnh.Enabled = false;
            }
            else
            {
                txt_ImagePath.Enabled = true;
                btn_ChonAnh.Enabled = true;
                txt_fBatchName.Enabled = true;
            }
        }

        private void btn_Browser_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.Reload();
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            if (!string.IsNullOrEmpty(Properties.Settings.Default.LastSelectedFolder))
            {
                fbd.SelectedPath = Properties.Settings.Default.LastSelectedFolder;
            }
            if (fbd.ShowDialog() == DialogResult.OK)
            {
                txt_folder_Multiline.Text = fbd.SelectedPath;
                if (!string.IsNullOrEmpty(txt_folder_Multiline.Text))
                {
                    Properties.Settings.Default.LastSelectedFolder = txt_folder_Multiline.Text;
                    Properties.Settings.Default.Save();
                }
            }
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