using System;
using System.Linq;
using System.Net;
using System.Net.Sockets;

namespace PhieuKiemDinh
{
    internal class Global
    {
        public static string StrUserName = "";
        public static string StrPcName = "";
        public static string StrDomainName = "";
        public static string StrBatch = "";
        public static string StrRole = "";
        public static string Token = "";
        public static string StrIdProject = "PhieuKiemDinh";
        public static string StrCheck = "";
        public static int FreeTime = 0;
        public static string Version = "";
        public static bool FlagChangeSave = true;
        public static string StrPath = @"\\10.10.10.248\phieukiemdinh$";
        public static string Webservice ;
        //public static string Webservice = "http://10.10.10.248:8888/phieukiemdinh/";

        public static KiemDinh_DataDataContext Db;
        public static KiemDinh_EntryBPODataContext DbBpo;

        public static string GetToken(string strUserName)
        {
            Random rnd = new Random();
            return MyClass.HashMD5.GetMd5Hash(DateTime.Now + strUserName + rnd.Next(1111, 9999));
        }

        public static IPAddress GetServerIpAddress()
        {
            if (!System.Net.NetworkInformation.NetworkInterface.GetIsNetworkAvailable())
            {
                return null;
            }
            IPHostEntry host = Dns.GetHostEntry(Dns.GetHostName());
            try
            {
                return host.AddressList.FirstOrDefault(ip => ip.AddressFamily == AddressFamily.InterNetwork);
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
