using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Threading;

namespace PhieuKiemDinh.MyForm
{
    public partial class frm_DrawHide : DevExpress.XtraEditors.XtraForm
    {
        public string fbatchname="";
        public frm_DrawHide()
        {
            InitializeComponent();
        }
        Image temp;
        string filename = "",nameimage="";
        public int x1, y1, x2, y2;
        private bool shiftSelecting = false;
        private Point ptSelectionStart = new Point();
        private Point ptSelectionEnd = new Point();
        public List<point_rectangle> pr = new List<point_rectangle>();
        public List<point_rectangle> pr1 = new List<point_rectangle>();

        private void btn_browse_Click(object sender, EventArgs e)
        {
            OpenFileDialog o = new OpenFileDialog();
            o.Title = "Open Image";
            o.Filter = "Image| *.jpg;*.tif;*.jpeg;*.png;*.gif;*.bmp;*.ico;*.jpe;";
            if (o.ShowDialog() == DialogResult.OK && !string.IsNullOrEmpty(o.FileName))
            {
                pictureBox1.Image = null;
                temp = Image.FromFile(o.FileName);
                filename = o.FileName;
                nameimage = o.SafeFileName;
                panel1.AutoScroll = true;
                pictureBox1.Height = temp.Height;
                pictureBox1.Width = temp.Width;
                pictureBox1.SizeMode = PictureBoxSizeMode.Normal;
                pictureBox1.Image = temp;
                
                for (int i = 0; i < pr.Count; i++)
                {
                    int temp_x1 = 0, temp_y1 = 0, temp_x2 = 0, temp_y2 = 0;
                    if (pr[i]._x2 < pr[i]._x1)
                    {
                        temp_x1 = pr[i]._x2;
                        temp_x2 = pr[i]._x1;
                    }
                    else
                    {
                        temp_x1 = pr[i]._x1;

                        temp_x2 = pr[i]._x2;
                    }
                    if (pr[i]._y2 < pr[i]._y1)
                    {
                        temp_y1 = pr[i]._y2;
                        temp_y2 = pr[i]._y1;
                    }
                    else
                    {
                        temp_y1 = pr[i]._y1;
                        temp_y2 = pr[i]._y2;
                    }
                    Bitmap bmap = new Bitmap(pictureBox1.Image, new Size(pictureBox1.Image.Width, pictureBox1.Image.Height));
                    Bitmap newmap = bmap.Clone(new Rectangle(0, 0, bmap.Width, bmap.Height), System.Drawing.Imaging.PixelFormat.DontCare);

                    Graphics g1 = Graphics.FromImage(newmap);
                    g1.FillRectangle(Brushes.WhiteSmoke, new Rectangle(temp_x1, temp_y1, temp_x2 - temp_x1, temp_y2 - temp_y1));
                    pictureBox1.Image = null;
                    pictureBox1.Image = newmap;
                }
            }
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            if (pictureBox1.Image == null)
            {
                MessageBox.Show("Bạn chưa chọn hình ảnh");
                return;
            }
            x1 = e.Location.X;
            y1 = e.Location.Y;
            
            shiftSelecting = true;
            ptSelectionStart.X = e.X;
            ptSelectionStart.Y = e.Y;
            ptSelectionEnd.X = -1;
            ptSelectionEnd.Y = -1;
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            try
            {
                if (pictureBox1.Image == null)
                {
                    MessageBox.Show("Bạn chưa chọn hình ảnh");
                    return;
                }
                x2 = e.Location.X;
                y2 = e.Location.Y;

                shiftSelecting = false;
                point_rectangle a = new point_rectangle
                {
                    _x1 = x1,
                    _x2 = x2,
                    _y1 = y1,
                    _y2 = y2
                };
                pr.Add(a);
                
                for (int i = 0; i < pr.Count; i++)
                {
                    int temp_x1 = 0,temp_y1=0, temp_x2 = 0, temp_y2 = 0;
                    if(pr[i]._x2 < pr[i]._x1)
                    {
                        temp_x1 = pr[i]._x2;
                        temp_x2= pr[i]._x1;
                    }
                    else
                    {
                        temp_x1 = pr[i]._x1;

                        temp_x2 = pr[i]._x2;
                    }
                    if (pr[i]._y2 < pr[i]._y1)
                    {
                        temp_y1 = pr[i]._y2;
                        temp_y2 = pr[i]._y1;
                    }
                    else
                    {
                        temp_y1 = pr[i]._y1;
                        temp_y2 = pr[i]._y2;
                    }
                    Bitmap bmap = new Bitmap(pictureBox1.Image);
                    Bitmap newmap = bmap.Clone(new Rectangle(0, 0, bmap.Width, bmap.Height), System.Drawing.Imaging.PixelFormat.DontCare);

                    Graphics g1 = Graphics.FromImage(newmap);
                    g1.FillRectangle(Brushes.WhiteSmoke, new Rectangle(temp_x1, temp_y1, temp_x2 - temp_x1, temp_y2 - temp_y1));
                    pictureBox1.Image = null;
                    pictureBox1.Image = newmap;
                }
            }
            catch (Exception)
            {
                pr.Clear();
                Global.Db.Xoa_drawhide(fbatchname);
                pictureBox1.Image = null;
            }
        }

        private void btn_ok_Click(object sender, EventArgs e)
        {
            if (pictureBox1.Image == null)
                return;
            Global.Db.Xoa_drawhide(fbatchname);
            if (pr.Count > 0)
            {
                for (int i = 0; i < pr.Count; i++)
                {
                    Global.Db.Luu_drawhide(fbatchname, i + 1, pr[i]._x1, pr[i]._y1, pr[i]._x2 , pr[i]._y2);
                }
            }

            //pictureBox1.Image = null;
            //temp = Image.FromFile(filename);
            //panel1.AutoScroll = true;
            //pictureBox1.Height = temp.Height;
            //pictureBox1.Width = temp.Width;
            //pictureBox1.SizeMode = PictureBoxSizeMode.Normal;
            //pictureBox1.Image = temp;
            //for (int i = 0; i < pr.Count; i++)
            //{
            //    int temp_x1 = 0, temp_y1 = 0, temp_x2 = 0, temp_y2 = 0;
            //    if (pr[i]._x2 < pr[i]._x1)
            //    {
            //        temp_x1 = pr[i]._x2;
            //        temp_x2 = pr[i]._x1;
            //    }
            //    else
            //    {
            //        temp_x1 = pr[i]._x1;
            //        temp_x2 = pr[i]._x2;
            //    }
            //    if (pr[i]._y2 < pr[i]._y1)
            //    {
            //        temp_y1 = pr[i]._y2;
            //        temp_y2 = pr[i]._y1;
            //    }
            //    else
            //    {
            //        temp_y1 = pr[i]._y1;
            //        temp_y2 = pr[i]._y2;
            //    }
            //    Bitmap bmap = new Bitmap(pictureBox1.Image);
            //    Bitmap newmap = bmap.Clone(new Rectangle(0, 0, bmap.Width, bmap.Height), System.Drawing.Imaging.PixelFormat.DontCare);
            //    Graphics g1 = Graphics.FromImage(newmap);
            //    g1.FillRectangle(Brushes.WhiteSmoke, new Rectangle(temp_x1, temp_y1, temp_x2 - temp_x1, temp_y2 - temp_y1));
            //    pictureBox1.Image = null;
            //    pictureBox1.Image = newmap;
            //    //newmap.Save(@"C:\Users\PC\Desktop\" + nameimage, System.Drawing.Imaging.ImageFormat.Jpeg);
            //}

            MessageBox.Show("Đã hoàn thành thiết lập tọa độ.");
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (shiftSelecting == true && pictureBox1.Image!=null)
            {
                pictureBox1.Cursor = Cursors.Cross;

                ptSelectionEnd.X = e.X;
                ptSelectionEnd.Y = e.Y;

                Rectangle pbFullRect = new Rectangle(0, 0, pictureBox1.Width - 1, pictureBox1.Height - 1);

                if (pbFullRect.Contains(new Point(e.X, e.Y)))
                {
                    Rectangle rect = CalculateReversibleRectangle(ptSelectionStart, ptSelectionEnd);
                    DrawReversibleRectangle(rect);
                }
            }
            else
            {
                pictureBox1.Cursor = Cursors.Default;
            }
        }

        private Rectangle CalculateReversibleRectangle(Point ptSelectStart, Point ptSelectEnd)
        {
            Rectangle rect = new Rectangle();

            ptSelectStart = pictureBox1.PointToScreen(ptSelectStart);
            ptSelectEnd = pictureBox1.PointToScreen(ptSelectEnd);

            if (ptSelectStart.X < ptSelectEnd.X)
            {
                rect.X = ptSelectStart.X;
                rect.Width = ptSelectEnd.X - ptSelectStart.X;
            }
            else
            {
                rect.X = ptSelectEnd.X;
                rect.Width = ptSelectStart.X - ptSelectEnd.X;
            }
            if (ptSelectStart.Y < ptSelectEnd.Y)
            {
                rect.Y = ptSelectStart.Y;
                rect.Height = ptSelectEnd.Y - ptSelectStart.Y;
            }
            else
            {
                rect.Y = ptSelectEnd.Y;
                rect.Height = ptSelectStart.Y - ptSelectEnd.Y;
            }

            return rect;
        }

        private void btn_undo_Click(object sender, EventArgs e)
        {
            if (pr.Count < 1)
                return;
            pr.RemoveAt(pr.Count - 1);
            if (pictureBox1.Image == null)
                return;
            pictureBox1.Image = null;
            temp = Image.FromFile(filename);
            panel1.AutoScroll = true;
            pictureBox1.Height = temp.Height;
            pictureBox1.Width = temp.Width;
            pictureBox1.SizeMode = PictureBoxSizeMode.Normal;
            pictureBox1.Image = temp;
            for (int i = 0; i < pr.Count; i++)
            {

                int temp_x1 = 0, temp_y1 = 0, temp_x2 = 0, temp_y2 = 0;
                if (pr[i]._x2 < pr[i]._x1)
                {
                    temp_x1 = pr[i]._x2;
                    temp_x2 = pr[i]._x1;
                }
                else
                {
                    temp_x1 = pr[i]._x1;

                    temp_x2 = pr[i]._x2;
                }
                if (pr[i]._y2 < pr[i]._y1)
                {
                    temp_y1 = pr[i]._y2;
                    temp_y2 = pr[i]._y1;
                }
                else
                {
                    temp_y1 = pr[i]._y1;
                    temp_y2 = pr[i]._y2;
                }
                Bitmap bmap = new Bitmap(pictureBox1.Image);
                Bitmap newmap = bmap.Clone(new Rectangle(0, 0, bmap.Width, bmap.Height), System.Drawing.Imaging.PixelFormat.DontCare);

                Graphics g1 = Graphics.FromImage(newmap);
                g1.FillRectangle(Brushes.WhiteSmoke, new Rectangle(temp_x1, temp_y1, temp_x2 - temp_x1, temp_y2 - temp_y1));
                pictureBox1.Image = null;
                pictureBox1.Image = newmap;
            }
        }

        private void frm_DrawHide_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.Z)
                btn_undo_Click(null, null);
        }

        private void frm_DrawHide_Load(object sender, EventArgs e)
        {
            var ListToaDo = (from w in Global.Db.GetToaDo(fbatchname + "") select w).ToList();
            for (int i = 0; i < ListToaDo.Count; i++)
            {
                point_rectangle a = new point_rectangle
                {
                    _x1 = int.Parse(ListToaDo[i].x1 + ""),
                    _x2 = int.Parse(ListToaDo[i].x2 + ""),
                    _y1 = int.Parse(ListToaDo[i].y1 + ""),
                    _y2 = int.Parse(ListToaDo[i].y2 + "")
                };
                pr1.Add(a);
                pr.Add(a);
            }
        }

        private void DrawReversibleRectangle(Rectangle rect)
        {
            pictureBox1.Refresh();
            ControlPaint.DrawReversibleFrame(rect, Color.Black, FrameStyle.Dashed);
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

        private void btn_xoa_Click(object sender, EventArgs e)
        {
            if (pr.Count < 1)
                return;
            if (MessageBox.Show("Bạn chắc chắn muốn xóa hết các tọa độ đã thiết lập", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                return;
            pr.Clear();
            Global.Db.Xoa_drawhide(fbatchname);
            if (pictureBox1.Image == null)
                return;
            pictureBox1.Image = null;
            temp = Image.FromFile(filename);
            panel1.AutoScroll = true;
            pictureBox1.Height = temp.Height;
            pictureBox1.Width = temp.Width;
            pictureBox1.SizeMode = PictureBoxSizeMode.Normal;
            pictureBox1.Image = temp;
            for (int i = 0; i < pr.Count; i++)
            {
                int temp_x1 = 0, temp_y1 = 0, temp_x2 = 0, temp_y2 = 0;
                if (pr[i]._x2 < pr[i]._x1)
                {
                    temp_x1 = pr[i]._x2;
                    temp_x2 = pr[i]._x1;
                }
                else
                {
                    temp_x1 = pr[i]._x1;

                    temp_x2 = pr[i]._x2;
                }
                if (pr[i]._y2 < pr[i]._y1)
                {
                    temp_y1 = pr[i]._y2;
                    temp_y2 = pr[i]._y1;
                }
                else
                {
                    temp_y1 = pr[i]._y1;
                    temp_y2 = pr[i]._y2;
                }
                Bitmap bmap = new Bitmap(pictureBox1.Image);
                Bitmap newmap = bmap.Clone(new Rectangle(0, 0, bmap.Width, bmap.Height), System.Drawing.Imaging.PixelFormat.DontCare);

                Graphics g1 = Graphics.FromImage(newmap);
                g1.FillRectangle(Brushes.WhiteSmoke, new Rectangle(temp_x1, temp_y1, temp_x2 - temp_x1, temp_y2 - temp_y1));
                pictureBox1.Image = null;
                pictureBox1.Image = newmap;
            }
        }
    }
}