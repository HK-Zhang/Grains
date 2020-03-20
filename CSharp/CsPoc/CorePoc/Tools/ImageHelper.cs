using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Text;

namespace CorePoc.Tools
{
    public static class ImageHelper
    {
        public static void Execute()
        {
            var img = Image.FromFile("I000001238_sketch.jpg");
            var waterimg = Image.FromFile("012f3b58-9c9d-3cce-9bcf-0f67aa9f0826.png");
            var targetImage = AddImgToImg(img, waterimg, 3417, 376, -0.5f, ".jpg", "LackPene","7909432574239IUHOIHLLK678","Henry Zhang", 14.0f);
            targetImage.Save("I000001238_sketch_out.jpg");
            
        }
        public static Image AddTextToImg(Image image, string text, float fontSize, float rectX, float rectY, int opacity, string externName)
        {

            Bitmap bitmap = new Bitmap(image, image.Width, image.Height);

            Graphics g = Graphics.FromImage(bitmap);

            float rectWidth = text.Length * (fontSize + 10);
            float rectHeight = fontSize + 10;

            RectangleF textArea = new RectangleF(rectX - rectWidth, rectY - rectHeight, rectWidth, rectHeight);

            Font font = new Font("微软雅黑", fontSize, FontStyle.Bold); 

            Brush whiteBrush = new SolidBrush(Color.FromArgb(opacity, 193, 143, 8)); 

            g.DrawString(text, font, whiteBrush, textArea);

            MemoryStream ms = new MemoryStream();

            switch (externName)
            {
                case ".jpg":
                    bitmap.Save(ms, ImageFormat.Jpeg);
                    break;
                case ".gif":
                    bitmap.Save(ms, ImageFormat.Gif);
                    break;
                case ".png":
                    bitmap.Save(ms, ImageFormat.Png);
                    break;
                default:
                    bitmap.Save(ms, ImageFormat.Jpeg);
                    break;
            }


            Image h_hovercImg = Image.FromStream(ms);

            g.Dispose();

            bitmap.Dispose();

            return h_hovercImg;

        }

        public static Image AddImgToImg(Image image, Image watermark, float rectX, float rectY, float opacity, string externName, 
            string text,string imageNo,string user, float fontSize)
        {

            Bitmap bitmap = new Bitmap(image, image.Width, image.Height);
            Graphics g = Graphics.FromImage(bitmap);

//            float rectWidth = watermark.Width + 10;
//            float rectHeight = watermark.Height + 10;

            float rectWidth = watermark.Width;
            float rectHeight = watermark.Height;

            float txtrectWidth = text.Length * fontSize;
            float txtrectHeight = fontSize+10;
            float txtTop = rectY + rectHeight;
            float txtLeft = rectX + (rectWidth - txtrectWidth) / 2;
            if (txtLeft < 0) txtLeft = 0;
            if (txtLeft + txtrectWidth > image.Width) txtLeft = image.Width - txtrectWidth;



            //            RectangleF textArea = new RectangleF(rectX - rectWidth, rectY - rectHeight, rectWidth, rectHeight);
            RectangleF textArea = new RectangleF(rectX, rectY, rectWidth, rectHeight);

            Bitmap w_bitmap = ChangeOpacity(watermark, opacity);

            g.DrawImage(w_bitmap, textArea);

            RectangleF textArea2 = new RectangleF(txtLeft, txtTop, txtrectWidth, txtrectHeight);

            Font font = new Font("Arial", fontSize, FontStyle.Bold);

            Brush whiteBrush = new SolidBrush(Color.Black);
            g.DrawString(text, font, whiteBrush, textArea2);

            float imagerectWidth = imageNo.Length * fontSize;
            float imagerectHeight = fontSize + 10;

            float imageTop = image.Height - 2* imagerectHeight;
            float imageLeft = image.Width - imagerectWidth;

            float UserrectWidth = user.Length * fontSize;
            float UserrectHeight = fontSize + 10;
            float UserTop = image.Height - UserrectHeight;
            float UserLeft = image.Width - UserrectWidth;

            if (UserLeft < imageLeft)
                imageLeft = UserLeft;
            else
                UserLeft = imageLeft;

            RectangleF imageArea = new RectangleF(imageLeft, imageTop, imagerectWidth, imagerectHeight);
            g.DrawString(imageNo, font, whiteBrush, imageArea);


            RectangleF UserArea = new RectangleF(UserLeft, UserTop, UserrectWidth, UserrectHeight);
            g.DrawString(user, font, whiteBrush, UserArea);


            Pen pen = new Pen(Color.Gray, 1);
            pen.DashStyle = System.Drawing.Drawing2D.DashStyle.Custom;
            pen.DashPattern = new float[] { 5, 5 };

            //            g.DrawLine(pen, 1521, image.Height - 142, image.Width, image.Height - 142);

            g.DrawLine(pen, 0, image.Height - 142, image.Width, image.Height - 142);

            g.DrawLine(pen, 1521, 0, 1521, image.Height);

            var cm = (int)(10 / 0.084667);
            Pen pen2 = new Pen(Color.Gray, 1);
            g.DrawLine(pen2, 1521 + cm, image.Height - 142, 1521 + cm, image.Height - 142 - 10);

            float numberWidth = "1".Length * fontSize;
            float numberHeight = fontSize + 10;
            float numberTop = image.Height - 142 - 10 - numberHeight;
            float numberLeft = 1521 + cm - numberWidth/2;
            RectangleF numberArea = new RectangleF(numberLeft, numberTop, numberWidth, numberHeight);
            Brush grayBrush = new SolidBrush(Color.Gray);
            g.DrawString("1", font, grayBrush, numberArea);



            g.DrawLine(pen2, 1521, image.Height - 142 - cm, 1521 + 10, image.Height - 142 - cm);

            float number2Width = "1".Length * fontSize;
            float number2Height = fontSize + 10;
            float number2Top = image.Height - 142 - cm - number2Height/2;
            float number2Left = 1521 + 10;
            RectangleF number2Area = new RectangleF(number2Left, number2Top, number2Width, number2Height);
            g.DrawString("1", font, grayBrush, number2Area);

            MemoryStream ms = new MemoryStream();

            switch (externName)
            {
                case ".jpg":
                    bitmap.Save(ms, ImageFormat.Jpeg);
                    break;
                case ".gif":
                    bitmap.Save(ms, ImageFormat.Gif);
                    break;
                case ".png":
                    bitmap.Save(ms, ImageFormat.Png);
                    break;
                default:
                    bitmap.Save(ms, ImageFormat.Jpeg);
                    break;
            }

            Image h_hovercImg = Image.FromStream(ms);

            g.Dispose();

            bitmap.Dispose();
            return h_hovercImg;
        }

        public static Bitmap ChangeOpacity(Image img, float opacityvalue)
        {

            if (opacityvalue < 0)
            {
                return new Bitmap(img, img.Width, img.Height);
            }


            float[][] nArray ={ new float[] {1, 0, 0, 0, 0},

                new float[] {0, 1, 0, 0, 0},

                new float[] {0, 0, 1, 0, 0},

                new float[] {0, 0, 0, opacityvalue, 0},

                new float[] {0, 0, 0, 0, 1}};

            ColorMatrix matrix = new ColorMatrix(nArray);

            ImageAttributes attributes = new ImageAttributes();

            attributes.SetColorMatrix(matrix, ColorMatrixFlag.Default, ColorAdjustType.Bitmap);

            Image srcImage = img;

            Bitmap resultImage = new Bitmap(srcImage.Width, srcImage.Height);

            Graphics g = Graphics.FromImage(resultImage);

            g.DrawImage(srcImage, new Rectangle(0, 0, srcImage.Width, srcImage.Height), 0, 0, srcImage.Width, srcImage.Height, GraphicsUnit.Pixel, attributes);

            return resultImage;
        }

    }
}
