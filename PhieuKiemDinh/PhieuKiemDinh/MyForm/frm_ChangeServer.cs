using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using PhieuKiemDinh.MyClass;
using PhieuKiemDinh.Properties;

namespace PhieuKiemDinh.MyForm
{
    public partial class frm_ChangeServer : DevExpress.XtraEditors.XtraForm
    {
        public frm_ChangeServer()
        {
            InitializeComponent();
        }

        private void frm_ChangeServer_Load(object sender, EventArgs e)
        {
            try
            {
                switch (Settings.Default.Server)
                {
                    case "Đà Nẵng":
                        rb_DaNang.Checked = true;
                        break;
                    case "Khác":
                        rb_Khac.Checked = true;
                        break;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Vui lòng chọn server!");
            }
        }

        private void btn_Save_Click(object sender, EventArgs e)
        {
            try
            {
                if (rb_DaNang.Checked)
                {
                    Settings.Default.Server = "Đà Nẵng";
                    Settings.Default.Save();
                    Global.Webservice = "http://10.10.10.248:8888/phieukiemdinh/";
                    Global.Db = new KiemDinh_DataDataContext(@"Data Source=10.10.10.248;Initial Catalog=PhieuKiemDinh;Persist Security Info=True;User ID=phieukiemdinh; Password=123@123a");
                    Global.Db.CommandTimeout = 5 * 60; // 5 Mins
                    Global.DbBpo = new KiemDinh_EntryBPODataContext(@"Data Source=10.10.10.248;Initial Catalog=DatabaseDataEntryBPO;Persist Security Info=True;User ID=bpoentry;Password=123@123a");
                }
                else if (rb_Khac.Checked)
                {
                    Settings.Default.Server = "Khác";
                    Settings.Default.Save();
                    Global.Webservice = "http://117.2.142.10:3604/phieukiemdinh/";
                    Global.Db = new KiemDinh_DataDataContext(@"Data Source=117.2.142.10,3607;Initial Catalog=PhieuKiemDinh;Persist Security Info=True;Network Library=DBMSSOCN;User ID=phieukiemdinh;Password=123@123a");
                    Global.Db.CommandTimeout = 5 * 60; // 5 Mins
                    Global.DbBpo = new KiemDinh_EntryBPODataContext(@"Data Source=117.2.142.10,3607;Initial Catalog=DatabaseDataEntryBPO;Persist Security Info=True;Network Library=DBMSSOCN;User ID=bpoentry;Password=123@123a");
                }
            }
            catch (Exception i) { MessageBox.Show(i.Message + ""); }
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
        public static string GetLocalIpAddress()
        {
            var host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (var ip in host.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    return ip.ToString();
                }
            }
            throw new Exception("Local IP Address Not Found!");
        }
    }
}