using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid;

namespace PhieuKiemDinh.MyForm
{
    public partial class frm_ShowCheckedImage : XtraForm
    {
        public frm_ShowCheckedImage()
        {
            InitializeComponent();
        }

        public string fbatchname = "";

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
        public void SetNumberRowGridView(DataGridView dgv)
        {
            for (int i = 0; i < dgv.Rows.Count; i++)
            {
                dgv.Rows[i].HeaderCell.Value = (i + 1).ToString();
            }
        }
        private void frm_ShowCheckedImage_Load(object sender, EventArgs e)
        {
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

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            btn_Search_Click(null, null);
        }

        private void gridView1_CustomDrawRowIndicator(object sender, RowIndicatorCustomDrawEventArgs e)
        {
            LoadSttGridView(e, gridView1);
        }
    }
}