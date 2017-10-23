using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using DevExpress.XtraGrid;

namespace PhieuKiemDinh.MyForm
{
    public partial class frm_ChiTietTienDo : DevExpress.XtraEditors.XtraForm
    {
        public string Loai;
        public frm_ChiTietTienDo()
        {
            InitializeComponent();
        }

        private void DoRowDoubleClick(GridView view, Point pt)
        {
            GridHitInfo info = view.CalcHitInfo(pt);
            if (info.RowHandle < 0)
                return; 
             ShowImage showwImage = new ShowImage();
            showwImage.FBatchName = gridView1.GetRowCellValue(info.RowHandle, "fBatchName") + "";
            showwImage.IdImage = gridView1.GetRowCellValue(info.RowHandle, "idimage") + "";
            showwImage.ShowDialog();
        }
        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            GridView view = (GridView)sender;
            Point pt = view.GridControl.PointToClient(MousePosition);
            DoRowDoubleClick(view, pt);
        }

        BaseEdit _inplaceEditor;
        private void gridView1_ShownEditor(object sender, EventArgs e)
        {
            _inplaceEditor = ((GridView)sender).ActiveEditor;
            _inplaceEditor.DoubleClick += inplaceEditor_DoubleClick;
        }

        private void gridView1_HiddenEditor(object sender, EventArgs e)
        {
            if (_inplaceEditor != null)
            {
                _inplaceEditor.DoubleClick -= inplaceEditor_DoubleClick;
                _inplaceEditor = null;
            }
        }

        void inplaceEditor_DoubleClick(object sender, EventArgs e)
        {
            BaseEdit editor = (BaseEdit)sender;
            GridControl grid = (GridControl)editor.Parent;
            Point pt = grid.PointToClient(MousePosition);
            GridView view = (GridView)grid.FocusedView;
            DoRowDoubleClick(view, pt);
        }
        private void frm_ChiTietTienDo_Load(object sender, EventArgs e)
        {
            gridView1.DoubleClick += gridView1_DoubleClick;
            gridView1.ShownEditor += gridView1_ShownEditor;
            gridView1.HiddenEditor += gridView1_HiddenEditor;
            if (lb_fBatchName.Text == "All")
            {
                lb_TongSoHinh.Text = lb_TongSoHinh.Text = (from w in Global.Db.tbl_Images select w.IdImage).Count().ToString();
                lb_SoHinhChuaNhap.Text = (from w in Global.Db.tbl_Images where w.TienDoDeSo == "Hình chưa nhập" select w.IdImage).Count().ToString();
                lb_SoHinhDangNhap.Text = (from w in Global.Db.tbl_Images where w.TienDoDeSo == "Hình đang nhập" select w.IdImage).Count().ToString();
                lb_SoHinhChoCheck.Text = (from w in Global.Db.tbl_Images where w.TienDoDeSo == "Hình chờ check" select w.IdImage).Count().ToString();
                lb_SoHinhDangCheck.Text = (from w in Global.Db.tbl_Images where w.TienDoDeSo == "Hình đang check" select w.IdImage).Count().ToString();
                lb_SoHinhHoanThanh.Text = (from w in Global.Db.tbl_Images where w.TienDoDeSo == "Hình hoàn thành" select w.IdImage).Count().ToString();

                gridControl1.DataSource = null;
                gridControl1.DataSource = Global.Db.ChiTietTienDo_All();
                gridView1.RowCellStyle += GridView1_RowCellStyle;
            }
            else { 
            lb_TongSoHinh.Text =
                    (from w in Global.Db.tbl_Images where w.fBatchName == lb_fBatchName.Text select w.IdImage)
                    .Count().ToString();
                lb_SoHinhChuaNhap.Text = (from w in Global.Db.tbl_Images
                    where w.fBatchName == lb_fBatchName.Text && w.TienDoDeSo == "Hình chưa nhập"
                    select w.IdImage).Count().ToString();
                lb_SoHinhDangNhap.Text = (from w in Global.Db.tbl_Images
                    where w.fBatchName == lb_fBatchName.Text && w.TienDoDeSo == "Hình đang nhập"
                    select w.IdImage).Count().ToString();
                lb_SoHinhChoCheck.Text = (from w in Global.Db.tbl_Images
                    where w.fBatchName == lb_fBatchName.Text && w.TienDoDeSo == "Hình chờ check"
                    select w.IdImage).Count().ToString();
                lb_SoHinhDangCheck.Text = (from w in Global.Db.tbl_Images
                    where w.fBatchName == lb_fBatchName.Text && w.TienDoDeSo == "Hình đang check"
                    select w.IdImage).Count().ToString();
                lb_SoHinhHoanThanh.Text = (from w in Global.Db.tbl_Images
                    where w.fBatchName == lb_fBatchName.Text && w.TienDoDeSo == "Hình hoàn thành"
                    select w.IdImage).Count().ToString();

                gridControl1.DataSource = null;
                gridControl1.DataSource = Global.Db.ChiTietTienDoDeSo(lb_fBatchName.Text);
                gridView1.RowCellStyle += GridView1_RowCellStyle;
            }
           
        }

        private void GridView1_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            GridView View = sender as GridView;
            //doi mau row chan
            //if (e.RowHandle >= 0)
            //{
            //    if (e.RowHandle % 2 == 0)//    {
            //        e.Appearance.BackColor = Color.AntiqueWhite;
            //    }
            //}
            //Doi mau cell cua colummn Status, neu co gia tri Actived thi co mau xanh, neu co gia tri N/A thi co mau hong`
            if (e.Column.FieldName == "ThongTin")
            {
                string category = View.GetRowCellDisplayText(e.RowHandle, View.Columns["ThongTin"]);
                if (category == "Hình đang nhập")
                    e.Appearance.BackColor = Color.HotPink;
                else if (category == "Hình chờ check")
                {
                    e.Appearance.BackColor = Color.OrangeRed;
                    e.Appearance.ForeColor = Color.White;
                }
                else if (category == "Hình đang check")
                {
                    e.Appearance.BackColor = Color.Purple;
                    e.Appearance.ForeColor = Color.White;
                }
                else if (category == "Hình hoàn thành")
                {
                    e.Appearance.BackColor = Color.Green;
                    e.Appearance.ForeColor = Color.White;
                }
            }
        }

       

        private void repositoryItemPopupContainerEdit1_Click(object sender, EventArgs e)
        {
            string idimage = gridView1.GetFocusedRowCellValue("idimage").ToString();
            gridControl2.DataSource = null;
            //if (Loai == "DESO")//{
            gridControl2.DataSource = Global.Db.ChiTietUserDeSo(lb_fBatchName.Text, idimage);
            //}
            //else
            //{
            //    gridControl2.DataSource = Global.DbKiemDinhXe.ChiTietUserDeJP(lb_fBatchName.Text, idimage);
            //}
        }
    }
}