using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace CorePoc.Tools
{
    public class FileMonitor
    {
        public static void Execute()
        {
            FileListenerServer f1 = new FileListenerServer(@"S:\Common\YXZHK\");
            f1.Start();
            Console.ReadKey();

            if (File.Exists(@"S:\Common\YXZHK\1.txt"))
            {
                Console.WriteLine(File.ReadAllText(@"S:\Common\YXZHK\1.txt"));
            }
        }
    }
}
