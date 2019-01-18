using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QRCoder;

namespace CsPoc.Toolkit
{
    class QRCodeCreator
    {
        public static void Execute()
        {
            // 生成二维码的内容
            string strCode = "https://synergisteel.dnvgl.com/c/123456789103";
            QRCodeGenerator qrGenerator = new QRCoder.QRCodeGenerator();
            QRCodeData qrCodeData = qrGenerator.CreateQrCode(strCode, QRCodeGenerator.ECCLevel.Q);
            QRCode qrcode = new QRCode(qrCodeData);

            // qrcode.GetGraphic 方法可参考最下发“补充说明”
            Bitmap qrCodeImage = qrcode.GetGraphic(5, Color.Black, Color.White, null, 15, 6, false);
            MemoryStream ms = new MemoryStream();
            qrCodeImage.Save(ms, ImageFormat.Jpeg);

            // 如果想保存图片 可使用  qrCodeImage.Save(filePath);
            //            qrCodeImage.Save("1.jpg");
            //            // 响应类型
            //            context.Response.ContentType = "image/Jpeg";
            //            //输出字符流
            //            context.Response.BinaryWrite(ms.ToArray());

            using (var srcImage = Image.FromStream(ms))
            {
                var newWidth = 83;
                var newHeight = 83;
                using (var newImage = new Bitmap(newWidth, newHeight))
                using (var graphics = Graphics.FromImage(newImage))
                {
                    graphics.SmoothingMode = SmoothingMode.AntiAlias;
                    graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                    graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;
                    graphics.DrawImage(srcImage, new System.Drawing.Rectangle(0, 0, 83, 83));
                    newImage.Save("2.jpg");
                }
            }
        }


//        public void Resize(string imageFile, string outputFile, double scaleFactor)
//        {
//            using (var srcImage = Image.FromFile(imageFile))
//            {
//                var newWidth = 83;
//                var newHeight = 83;
//                using (var newImage = new Bitmap(newWidth, newHeight))
//                using (var graphics = Graphics.FromImage(newImage))
//                {
//                    graphics.SmoothingMode = SmoothingMode.AntiAlias;
//                    graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
//                    graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;
//                    graphics.DrawImage(srcImage,new System.Drawing.Rectangle(0,0,83,83));
//                    newImage.Save(outputFile);
//                }
//            }
//        }
    }
}
