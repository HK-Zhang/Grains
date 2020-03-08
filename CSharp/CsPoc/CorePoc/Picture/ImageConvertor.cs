using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace CorePoc.Picture
{
    public class ImageConvertor
    {
        public static void Execute()
        {
            ToJpep("ndt.png");
        }

        private static void ToJpep(string file)
        {
            string extension = System.IO.Path.GetExtension(file);
            if (extension == ".png")
            {
                string name = System.IO.Path.GetFileNameWithoutExtension(file);
                string path = System.IO.Path.GetDirectoryName(file);
                Image png = Image.FromFile(file);

                png.Save(name + ".jpg", System.Drawing.Imaging.ImageFormat.Jpeg);
                png.Dispose();
            }
        }
    }

    
}
