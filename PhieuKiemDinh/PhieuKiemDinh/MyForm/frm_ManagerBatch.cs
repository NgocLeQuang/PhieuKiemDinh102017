using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Base;

namespace PhieuKiemDinh.MyForm
{
    public partial class frm_ManagerBatch : XtraForm
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
            DialogResult dlr = (MessageBox.Show("Bạn đang thực hiện xóa batch: " + fbatchname + "\nYes = xóa và tạo lại batch này \nNo = xóa và không tạo lại batch này \nCancel = không thực hiện xóa", "Thông báo", MessageBoxButtons.YesNoCancel,MessageBoxIcon.Warning,MessageBoxDefaultButton.Button2));
            if (dlr == DialogResult.No)
            {
                try
                {
                    Global.Db.XoaBatch(fbatchname);
                    MessageBox.Show("Đã xóa batch thành công!");
                }
                catch (Exception i)
                {
                    MessageBox.Show("Xóa batch bị lỗi!\n"+i.Message);
                }
            }
            if (dlr == DialogResult.Yes)
            {
                try
                {
                    Global.Db.XoaBatch(fbatchname);
                    Global.Db.Delete_BatchIsDelete(fbatchname);
                    MessageBox.Show("Đã xóa batch thành công!\nBạn có thể tạo lại batch này.");
                }
                catch (Exception i)
                {
                    MessageBox.Show("Xóa batch bị lỗi!\n" + i.Message);
                }
            }
            refresh();
        }

        private void btn_TaoBatch_Click(object sender, EventArgs e)
        {
            new frm_CreateBatch().ShowDialog();
            refresh();
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

            DialogResult dlr = (MessageBox.Show("Bạn đang thực hiện xóa " + i + " batch sau:\n" + s + "\nYes = xóa và tạo lại những batch này \nNo = xóa và không tạo lại những batch này \nCancel = không thực hiện xóa", "Thông báo", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2));
            if (dlr == DialogResult.Cancel)
                return;
            if (dlr == DialogResult.No)
            {
                foreach (var rowHandle in gridView1.GetSelectedRows())
                {
                    string fbatchname = gridView1.GetRowCellValue(rowHandle, "fBatchName").ToString();
                    Global.Db.XoaBatch(fbatchname);
                }
            }
            if (dlr == DialogResult.Yes)
            {
                foreach (var rowHandle in gridView1.GetSelectedRows())
                {
                    string fbatchname = gridView1.GetRowCellValue(rowHandle, "fBatchName").ToString();
                    Global.Db.XoaBatch(fbatchname);
                    Global.Db.Delete_BatchIsDelete(fbatchname);
                }
            }
            refresh();
        }

        private void gridView1_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            LoadSttGridView(e, gridView1);
        }
        
        private void gridView1_CellValueChanging(object sender, CellValueChangedEventArgs e)
        {
            try
            {
                string batchname = gridView1.GetFocusedRowCellValue("fBatchName") + "";
                string fielname = e.Column.FieldName;
                if (fielname == "CongKhaiBatch")
                {
                    bool check = (bool)e.Value;
                    if (check)
                    {
                        Global.Db.UpdateCongKhaiBatch(batchname, 1);
                    }
                    else
                    {
                        Global.Db.UpdateCongKhaiBatch(batchname, 0);
                    }
                    int rowHandle = gridView1.LocateByValue("fBatchName", batchname);
                    refresh();
                    if (rowHandle != DevExpress.XtraGrid.GridControl.InvalidRowHandle)
                        gridView1.FocusedRowHandle = rowHandle;
                }
                else if (fielname == "ChiaUser")
                {
                    var kt = (from w in Global.Db.tbl_MissImage_DeSos where w.fBatchName == batchname select w.IdImage).ToList();
                    if (kt.Count > 0)
                    {
                        MessageBox.Show("Batch này đã được nhập!");
                    }
                    else
                    {
                        bool check = (bool)e.Value;
                        if (check)
                        {
                            Global.Db.UpdateBatchChiaUser(batchname,1);
                        }
                        else
                        {
                            Global.Db.UpdateBatchChiaUser(batchname,0);
                        }
                    }
                    int rowHandle = gridView1.LocateByValue("fBatchName", batchname);
                    refresh();
                    if (rowHandle != DevExpress.XtraGrid.GridControl.InvalidRowHandle)
                        gridView1.FocusedRowHandle = rowHandle;
                }
            }
            catch(Exception i)
            {
                MessageBox.Show("Lỗi : " + i.Message);
            }
        }
    }
}