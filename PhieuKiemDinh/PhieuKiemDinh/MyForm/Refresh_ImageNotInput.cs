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
    public partial class Refresh_ImageNotInput : DevExpress.XtraEditors.XtraForm
    {
        public Refresh_ImageNotInput()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            int minute = 0;
            if (string.IsNullOrEmpty(txt_Minute.Text))
                minute = 10;
            else
                minute = int.Parse(txt_Minute.Text);
            gridControl1.DataSource = Global.Db.GetImageNotSubmit(minute);
        }

        private void Refresh_ImageNotInput_Load(object sender, EventArgs e)
        {
            txt_Minute.Text = "10";
            gridControl1.DataSource = Global.Db.GetImageNotSubmit(int.Parse(txt_Minute.Text));
        }

        private void btn_Refresh_Click(object sender, EventArgs e)
        {
            foreach (var rowHandle in gridView1.GetSelectedRows())
            {
                string fbatchname = gridView1.GetRowCellValue(rowHandle, "fBatchName").ToString();
                string ImageName = gridView1.GetRowCellValue(rowHandle, "IdImage").ToString();
                string UserName = gridView1.GetRowCellValue(rowHandle, "UserName").ToString();
                Global.Db.RefreshImageNotInput(fbatchname,ImageName,UserName);
            }
            int minute = 0;
            if (string.IsNullOrEmpty(txt_Minute.Text))
                minute = 10;
            else
                minute = int.Parse(txt_Minute.Text);
            gridControl1.DataSource = Global.Db.GetImageNotSubmit(minute);
        }

        private void btn_Refresh_All_Click(object sender, EventArgs e)
        {
            for (int i=0;i<gridView1.RowCount;i++)
            {
                string fbatchname = gridView1.GetRowCellValue(i, "fBatchName").ToString();
                string ImageName = gridView1.GetRowCellValue(i, "IdImage").ToString();
                string UserName = gridView1.GetRowCellValue(i, "UserName").ToString();
                Global.Db.RefreshImageNotInput(fbatchname, ImageName, UserName);
            }
            int minute = 0;
            if (string.IsNullOrEmpty(txt_Minute.Text))
                minute = 10;
            else
                minute = int.Parse(txt_Minute.Text);
            gridControl1.DataSource = Global.Db.GetImageNotSubmit(minute);
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                e.Handled = true;
        }

        private void txt_Minute_TextChanged(object sender, EventArgs e)
        {
            int minute = 0;
            if (string.IsNullOrEmpty(txt_Minute.Text))
                minute = 10;
            else
                minute = int.Parse(txt_Minute.Text);
            gridControl1.DataSource = Global.Db.GetImageNotSubmit(minute);
        }

        private void Refresh_ImageNotInput_FormClosing(object sender, FormClosingEventArgs e)
        {
            timer1.Enabled = false;
        }
    }
}