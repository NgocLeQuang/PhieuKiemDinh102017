using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;

namespace PhieuKiemDinh.MyForm
{
    public partial class frm_ManagerBatch : DevExpress.XtraEditors.XtraForm
    {
        public frm_ManagerBatch()
        {
            InitializeComponent();
        }

        private void frm_ManagerBatch_Load(object sender, EventArgs e)
        {
            refresh();
        }

        public bool Cal(int width, DevExpress.XtraGrid.Views.Grid.GridView view)
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

        private void refresh()
        {
            gridControl1.DataSource = (from var in Global.Db.GetBatch_Full() select var).ToList();
        }
        
        private void btn_Xoa_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            string fbatchname = gridView1.GetFocusedRowCellValue("fBatchName").ToString();
            string temp = Global.StrPath + "\\" + fbatchname;
            if (MessageBox.Show("Bạn chắc chắn muốn xóa batch: " + fbatchname + "?", "Thông báo", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                try
                {
                    Global.Db.XoaBatch(fbatchname);
                    MessageBox.Show("Đã xóa batch thành công!");
                }
                catch (Exception)
                {
                    MessageBox.Show("Xóa batch bị lỗi!");
                }
            }
            refresh();
        }

        private void btn_TaoBatch_Click(object sender, EventArgs e)
        {
            new frm_CreateBatch().ShowDialog();
            refresh();
        }

        private void gridView1_CellValueChanging(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            string batchname = gridView1.GetFocusedRowCellValue("fBatchName") + "";
            if (e.Column.FieldName == "CongKhaiBatch")
            {
                bool check = (bool)e.Value;
                if (check)
                {
                    var batch = (from w in Global.Db.tbl_Batches where w.fBatchName == batchname select w).Single();
                    batch.CongKhaiBatch = true;
                    Global.Db.SubmitChanges();
                    Global.Db.UpdateCongKhaiBatch(batchname, 1);
                }
                else
                {
                    var batch = (from w in Global.Db.tbl_Batches where w.fBatchName == batchname select w).Single();
                    batch.CongKhaiBatch = false;
                    Global.Db.SubmitChanges();
                    Global.Db.UpdateCongKhaiBatch(batchname, 0);
                }
                refresh();
                int rowHandle = gridView1.LocateByValue("fBatchName", batchname);
                if (rowHandle != DevExpress.XtraGrid.GridControl.InvalidRowHandle)
                    gridView1.FocusedRowHandle = rowHandle;
            }
            else if (e.Column.FieldName == "ChiaUser")
            {
                var kt = (from w in Global.Db.GetNumberImageMissImage(batchname) select w).ToList();
                if (kt.Count > 0)
                {
                    MessageBox.Show("Batch này đã được nhập!");
                }
                else
                {
                    bool check = (bool)e.Value;
                    if (check)
                    {
                        var batch = (from w in Global.Db.tbl_Batches where w.fBatchName == batchname select w).Single();
                        batch.ChiaUser = true;
                        Global.Db.SubmitChanges();
                        Global.Db.UpdateBatchChiaUser(batchname);
                    }
                    else
                    {
                        var batch = (from w in Global.Db.tbl_Batches where w.fBatchName == batchname select w).Single();
                        batch.ChiaUser = false;
                        Global.Db.SubmitChanges();
                        Global.Db.UpdateBatchKhongChiaUser(batchname);
                    }
                }
                refresh();
                int rowHandle = gridView1.LocateByValue("fBatchName", batchname);
                if (rowHandle != DevExpress.XtraGrid.GridControl.InvalidRowHandle)
                    gridView1.FocusedRowHandle = rowHandle;
            }
        }

        private void btn_xoabatch_Click(object sender, EventArgs e)
        {
            int i = 0;
            string s = "";
            foreach (var rowHandle in gridView1.GetSelectedRows())
            {
                i += 1;
                string fbatchname = gridView1.GetRowCellValue(rowHandle, "fBatchName").ToString();
                s += fbatchname + "\n";
            }
            if (i <= 0)
            {
                MessageBox.Show("Bạn chưa chọn batch. Vui lòng chọn batch trước khi xóa");
                return;
            }
            if (MessageBox.Show("Bạn muốn xóa " + i + " batch sau:\n" + s, "Cảnh báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning,MessageBoxDefaultButton.Button1) == DialogResult.No)
                return;
            foreach (var rowHandle in gridView1.GetSelectedRows())
            {
                string fbatchname = gridView1.GetRowCellValue(rowHandle, "fBatchName").ToString();
                string temp = Global.StrPath + "\\" + fbatchname;
                Global.Db.XoaBatch(fbatchname);
            }
            refresh();
        }

        private void gridView1_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            LoadSttGridView(e, gridView1);
        }
    }
}