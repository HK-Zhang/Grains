using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSDemo
{
    public class Log4NetDemo
    {
        public void Execute()
        {
            LogHelper.SetConfig(new System.IO.FileInfo("log4net.config"));
            LogHelper.WriteLog("App start");

            //try
            //{
            //    throw new NotImplementedException();
            //}
            //catch (Exception e)
            //{
            //    LogHelper.WriteLog("error", e);
            //    //throw;
            //}

            //char c = '\uDC1B';

            //String a = c.ToString();
            //Console.WriteLine(c);
        }
    }
}
