using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace PhieuKiemDinh.MyForm
{
    public partial class frm_BatchIsDelete : DevExpress.XtraEditors.XtraForm
    {
        public frm_BatchIsDelete()
        {
            InitializeComponent();
        }

        private void btn_Refresh_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            Global.Db.Delete_BatchIsDelete(gridView1.GetFocusedRowCellValue("fBatchName")+"");
            frm_BatchIsDelete_Load(null, null);
        }

        private void frm_BatchIsDelete_Load(object sender, EventArgs e)
        {
            gridControl1.DataSource = (from w in Global.Db.GetListBatchIsDelete() select w).ToList();
        }
    }
}