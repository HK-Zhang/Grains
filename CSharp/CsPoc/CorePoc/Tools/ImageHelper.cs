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

            var imgList = new List<ImageSpot> {new ImageSpot {AttachedText = "LackPene", ImageByte= waterimg,X=3417,Y=376,Opacity=-0.5f,FontSize=14,Width=19,Height=19 } };

            var imageNoTextSpot = new TextSpot {Text = "7909432574239IUHOIHLLK678", FontSize = 14};
            imageNoTextSpot.X = img.Width - imageNoTextSpot.Width;
            imageNoTextSpot.Y = img.Height - 2 * imageNoTextSpot.Height;

            var approverTextSpot = new TextSpot { Text = "Henry Zhang", FontSize = 14 };
            approverTextSpot.X = img.Width - imageNoTextSpot.Width;
            approverTextSpot.Y = img.Height - imageNoTextSpot.Height;

            if (approverTextSpot.X < imageNoTextSpot.X)
                imageNoTextSpot.X = approverTextSpot.X;
            else
                approverTextSpot.X = imageNoTextSpot.X;

            var txtList = new List<TextSpot> { imageNoTextSpot , approverTextSpot };


            var axis = new Axis {CenterX = 1521, CenterY = img.Height - 142, FontSize = 14, PixelSpacing = 0.084667 };

            var targetImage = AddImgToImg(img, imgList, txtList, axis,".jpg");


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

        public static Image AddImgToImg(Image image, List<ImageSpot> images, List<TextSpot> txts, Axis axis,string externName)
        {
            Brush blackBrush = new SolidBrush(Color.Black);
            Font font = new Font("Arial", 14, FontStyle.Bold);
            Bitmap bitmap = new Bitmap(image, image.Width, image.Height);
            Graphics g = Graphics.FromImage(bitmap);
            Brush grayBrush = new SolidBrush(Color.Gray);
            Pen pen = new Pen(Color.Gray, 1);
            pen.DashStyle = System.Drawing.Drawing2D.DashStyle.Custom;
            pen.DashPattern = new float[] { 5, 5 };

            Pen solidPen = new Pen(Color.Gray, 1);

            images.ForEach(t =>
            {
                var area = new RectangleF(t.X, t.Y, t.Width, t.Height);
                var sbitmap = ChangeOpacity(t.ImageByte, t.Opacity);
                g.DrawImage(sbitmap, area);

                if (!string.IsNullOrWhiteSpace(t.AttachedText))
                {
                    var textX = t.TextX;
                    if (textX + t.TextWidth > image.Width) textX = image.Width - t.TextWidth;
                    var textY = t.TextY;
                    if (textY + t.TextHeight > image.Height) textY = image.Height - t.TextHeight;
                    var textArea = new RectangleF(textX, textY, t.TextWidth, t.TextHeight);
                    g.DrawString(t.AttachedText, font, blackBrush, textArea);

                    var positionX = Math.Abs(t.X + t.Width/2 - axis.CenterX) / (1.0f * axis.CMPixels);
                    var positionY = Math.Abs(t.Y + t.Height/2 - axis.CenterY) / (1.0f * axis.CMPixels);
                    var position = $"({positionX:F1},{positionY:F1})";
                    var positionWidth = position.Length * 14;
                    var positionHeight = t.FontSize + 10;
                    if (textX + positionWidth > image.Width) textX = image.Width - positionWidth;
                    if (textY + positionHeight > image.Height) textY = image.Height - positionHeight;
                    var positionArea = new RectangleF(textX, textY + positionHeight, positionWidth, positionHeight);
                    g.DrawString(position, font, blackBrush, positionArea);
                }
            });

            txts.ForEach(t =>
            {
                var area = new RectangleF(t.X, t.Y, t.Width, t.Height);
                g.DrawString(t.Text, font, blackBrush, area);
            });

            g.DrawLine(pen, 0, axis.CenterY, image.Width, axis.CenterY);
            g.DrawLine(pen, axis.CenterX, 0, axis.CenterX, image.Height);

            var axisXTop = axis.CenterY - 10;
            var axisYLeft = axis.CenterX + 10;
            var numberHeight = axis.FontSize + 10;
            var count = (image.Width - axis.CenterX) / axis.CMPixels;

            for (var i = 1; i <= count; i++)
            {
                g.DrawLine(solidPen, axis.CenterX + i * axis.CMPixels, axis.CenterY, axis.CenterX + i * axis.CMPixels, axisXTop);

                var area = new RectangleF(axis.CenterX + i * axis.CMPixels - i.ToString().Length * axis.FontSize / 2, axisXTop - numberHeight, i.ToString().Length * axis.FontSize, numberHeight);
                g.DrawString(i.ToString(), font, grayBrush, area);

            }

            count = axis.CenterX / axis.CMPixels;

            for (var i = 1; i <= count; i++)
            {
                g.DrawLine(solidPen, axis.CenterX - i * axis.CMPixels, axis.CenterY, axis.CenterX - i * axis.CMPixels, axisXTop);
                var area = new RectangleF(axis.CenterX - i * axis.CMPixels - i.ToString().Length * axis.FontSize / 2, axisXTop - numberHeight, i.ToString().Length * axis.FontSize, numberHeight);
                g.DrawString(i.ToString(), font, grayBrush, area);
            }

            count = axis.CenterY / axis.CMPixels;
            for (var i = 1; i <= count; i++)
            {
                g.DrawLine(solidPen, axis.CenterX, axis.CenterY - i * axis.CMPixels, axisYLeft, axis.CenterY - i * axis.CMPixels);
                var area = new RectangleF(axisYLeft, axis.CenterY - i*axis.CMPixels - numberHeight / 2, i.ToString().Length * axis.FontSize, numberHeight);
                g.DrawString(i.ToString(), font, grayBrush, area);

            }

            count = (image.Height - axis.CenterY) / axis.CMPixels;
            for (var i = 1; i <= count; i++)
            {
                g.DrawLine(solidPen, axis.CenterX, axis.CenterY + i * axis.CMPixels, axisYLeft, axis.CenterY + i * axis.CMPixels);
                var area = new RectangleF(axisYLeft, axis.CenterY + i * axis.CMPixels - numberHeight / 2, i.ToString().Length * axis.FontSize, numberHeight);
                g.DrawString(i.ToString(), font, grayBrush, area);
            }

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

    public class ImageSpot
    {
        public Image ImageByte { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public int FontSize { get; set; }
        public int TextWidth => AttachedText.Length * FontSize;
        public int TextHeight => FontSize + 10;
        public int TextX
        {
            get
            {
                var t = X + (Width - TextWidth) / 2;
                return t < 0 ? 0 : t;
            }
        }

        public int TextY=> Y + Height;
        public string AttachedText { get; set; }
        public float Opacity { get; set; }
    }


    public class TextSpot
    {
        public int X { get; set; }
        public int Y { get; set; }
        public string Text { get; set; }
        public int FontSize { get; set; }
        public int Width => Text.Length * FontSize;
        public int Height => FontSize + 10;

    }

    public class Axis
    {
        public int CenterX { get; set; }
        public int CenterY { get; set; }
        public int FontSize { get; set; }
        public double PixelSpacing { get; set; }
        public int CMPixels => (int) (10 / PixelSpacing);
    }
}
