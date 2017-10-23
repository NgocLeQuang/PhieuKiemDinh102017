using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using PhieuKiemDinh.MyClass;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid;

namespace PhieuKiemDinh.MyForm
{
    public partial class frm_ShowCheckedImage : DevExpress.XtraEditors.XtraForm
    {
        public frm_ShowCheckedImage()
        {
            InitializeComponent();
        }

        public string fbatchname = "";

        public void SetNumberRowGridView(DataGridView dgv)
        {
            for (int i = 0; i < dgv.Rows.Count; i++)
            {
                dgv.Rows[i].HeaderCell.Value = (i + 1).ToString();
            }
        }
        private void frm_ShowCheckedImage_Load(object sender, EventArgs e)
        {
            //var listfBatch = (from w in Global.DbKiemDinhXe.tbl_Batches where w.CongKhaiBatch == true select w.fBatchName).ToList();
            gridView1.DoubleClick += gridView1_DoubleClick;
            gridView1.ShownEditor += gridView1_ShownEditor;
            gridView1.HiddenEditor += gridView1_HiddenEditor;
            var listfBatch = (from w in Global.Db.tbl_Batches select w.fBatchName).ToList();
            comboBox1.DataSource = listfBatch;
            comboBox1.DisplayMember = "fBatchName";
            if (!string.IsNullOrEmpty(fbatchname))
            {
                comboBox1.Text = fbatchname;
            }
            btn_Search_Click(null,null);
        }

        private void btn_Search_Click(object sender, EventArgs e)
        {
            var listimage = (from w in Global.Db.tbl_Images
                where w.fBatchName == comboBox1.Text && w.UserNameCheckDeSo == Global.StrUserName && w.SubmitCheckDeSo==1
                orderby w.DateCheckDeSo descending
                select new {w.fBatchName, w.IdImage, w.DateCheckDeSo}).ToList();
            gridControl1.DataSource = listimage;
            //SetNumberRowGridView(dataGridView1);
        }
        private void DoRowDoubleClick(GridView view, Point pt)
        {
            GridHitInfo info = view.CalcHitInfo(pt);
            if (info.RowHandle < 0)
                return;
            ShowImage showwImage = new ShowImage();
            showwImage.FBatchName = gridView1.GetRowCellValue(info.RowHandle, "fBatchName") + "";
            showwImage.IdImage = gridView1.GetRowCellValue(info.RowHandle, "IdImage") + "";
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
        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            
        }
    }
}