using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace PhieuKiemDinh.MyClass
{
    public static class LogFile
    {

        public static void Log(string sUserName, string sPCName, string sDomainName, string logMessage, TextWriter w, string sGhiChu)
        {
            //w.Write("\r\nLog Entry : ");
            w.WriteLine("-------------------------------");
            w.WriteLine("Time: {0} \r\nDate: {1}", DateTime.Now.ToLongTimeString(),DateTime.Now.ToShortDateString());
            w.WriteLine("UserName: {0}; PCName: {1}; DomainName: {2}", sUserName, sPCName, sDomainName);
            
            w.WriteLine("{0}", logMessage);
            w.WriteLine("");
            
        }

        public static void WriteLog(String LogText, string strGhiChu)
        {
            FileStream fs = null;

            try
            {

                if (!System.IO.Directory.Exists(@"D:\LogMP"))
                {
                    System.IO.Directory.CreateDirectory(@"D:\LogMP");
                }
                

                fs = new FileStream(@"D:\LogMP\"+ Global.strBatch + "_" + Global.strUserName + ".txt", FileMode.Append);
                using (StreamWriter writer = new StreamWriter(fs, Encoding.UTF8, 512))
                {
                    Log(Global.strUserName, Global.strPCName, Global.strDomainName, LogText, writer, strGhiChu);
                    Global.db_KiemDinhXe.Insert_LogFiles(Global.strUserName, Global.strPCName, Global.strDomainName, LogText.Replace("'", "''"), strGhiChu);
                    //DA.ExecuteLogFile("INSERT INTO [dbo].[tbl_LogFile]([Username],[Info],[DateLog]) VALUES('" + fileName_username + "','" + LogText + "',Getdate())");
                    //writer.Write(LogText);
                }
            }
            finally
            {
                if (fs != null)
                    fs.Dispose();
            }

            //using (StreamWriter w = File.AppendText(fileName_username))
            //{
            //    Log(LogText, w);
            //}
        }
    }
}
