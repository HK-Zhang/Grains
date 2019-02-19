using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CorePoc.DataParallelism
{
    class SimpleParallelFor
    {
        public static void Execute()
        {
            Foo1();
        }

        private static void Foo1()
        {
            long totalSize = 0;

            String[] args = Environment.GetCommandLineArgs();
            if (args.Length == 1)
            {
                Console.WriteLine("There are no command line arguments.");
                return;
            }
            if (!Directory.Exists(args[1]))
            {
                Console.WriteLine("The directory does not exist.");
                return;
            }

            String[] files = Directory.GetFiles(args[1]);
            Parallel.For(0, files.Length,
                         index => {
                             FileInfo fi = new FileInfo(files[index]);
                             long size = fi.Length;
                             Interlocked.Add(ref totalSize, size);
                         });
            Console.WriteLine("Directory '{0}':", args[1]);
            Console.WriteLine("{0:N0} files, {1:N0} bytes", files.Length, totalSize);
        }
       
        private static void Foo2()
        {
            // A simple source for demonstration purposes. Modify this path as necessary.
            String[] files = System.IO.Directory.GetFiles(@"C:\Users\Public\Pictures\Sample Pictures", "*.jpg");
            String newDir = @"C:\Users\Public\Pictures\Sample Pictures\Modified";
            System.IO.Directory.CreateDirectory(newDir);

            // Method signature: Parallel.ForEach(IEnumerable<TSource> source, Action<TSource> body)
            // Be sure to add a reference to System.Drawing.dll.
            Parallel.ForEach(files, (currentFile) =>
            {
                // The more computational work you do here, the greater 
                // the speedup compared to a sequential foreach loop.
                String filename = System.IO.Path.GetFileName(currentFile);
                var bitmap = new Bitmap(currentFile);

                bitmap.RotateFlip(RotateFlipType.Rotate180FlipNone);
                bitmap.Save(Path.Combine(newDir, filename));

                // Peek behind the scenes to see how work is parallelized.
                // But be aware: Thread contention for the Console slows down parallel loops!!!

                Console.WriteLine("Processing {0} on thread {1}", filename, Thread.CurrentThread.ManagedThreadId);
                //close lambda expression and method invocation
            });


            // Keep the console window open in debug mode.
            Console.WriteLine("Processing complete. Press any key to exit.");
        }

    }
}

