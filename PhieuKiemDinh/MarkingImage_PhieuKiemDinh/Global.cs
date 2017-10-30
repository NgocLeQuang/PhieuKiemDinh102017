using System;
using System.Linq;
using System.Net;
using System.Net.Sockets;

namespace MarkingImage_PhieuKiemDinh
{
    internal class Global
    {
        public static string StrIdProject = "PhieuKiemDinh";
        public static string StrPath = @"\\10.10.10.248\phieukiemdinh$";
        
        public static string Webservice ;
        public static DataDataContext Db=new DataDataContext();
    }
}
