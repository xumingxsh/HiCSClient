using System;
using System.IO;
using System.Windows.Forms;


namespace HiCSFormTest
{
    [MethodInvok]
    public class RunCls: ContextBoundObject
    {
        public void Run()
        {
            HiCSUtil.HiLog.SetLogFun((string script, HiCSUtil.HiLog.LogType type) =>
            {
                System.Diagnostics.Trace.WriteLine(script);
            });
            string path = AppDomain.CurrentDomain.BaseDirectory;
            DirectoryInfo topDir = System.IO.Directory.GetParent(path);
            topDir = System.IO.Directory.GetParent(topDir.FullName);
            topDir = System.IO.Directory.GetParent(topDir.FullName);
            topDir = System.IO.Directory.GetParent(topDir.FullName);
            path = topDir.FullName + "/Excel";
            string conn = @"Provider=Microsoft.ACE.OLEDB.12.0;
Extended Properties=Excel 12.0;
data source=" + path + "/edqdb.xls";


            HiCSProvider.UserConfig.Init(2, conn, path + "/xmls");
            HiCSUserControl.ViewConfig.ViewXmlFolder = topDir.FullName + "/View";
            HiCSProvider.UserConfig.SetUri("http://localhost:3316");
           // HiCSProvider.UserConfig.SetWebUri("http://localhost:53004/Service/CommonProvide.asmx");

        }
    }
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            RunCls run = new RunCls();
            run.Run();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
