using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using iTextSharp.text;
using Org.BouncyCastle.Pkcs;
using iTextSharp.text.pdf;
using Org.BouncyCastle.X509;

namespace CorePoc.Tools
{
    public class DigitalSigning
    {

        public static void Execute()
        {
            SignPdfFile("test.pdf", "TestSigned.pdf", "Content/demo.pfx");
            Console.WriteLine("done");
        }

        private static void processCert(string path)
        {
            string alias = null;
            Pkcs12Store pk12;

            //First we'll read the certificate file
            pk12 = new Pkcs12Store(new FileStream(path, FileMode.Open,
                FileAccess.Read), "123456".ToCharArray());

            foreach (string tAlias in pk12.Aliases)
            {
                if (pk12.IsKeyEntry(tAlias))
                {
                    alias = tAlias;
                    break;
                }
            }

            var pk = pk12.GetKey(alias).Key;


        }


        public static void SignPdfFile(string inputFileName, string outputFileName, string cerPath)
        {
            string alias = null;
            Pkcs12Store pk12;

            //First we'll read the certificate file
            pk12 = new Pkcs12Store(new FileStream(cerPath, FileMode.Open,
                FileAccess.Read), "123456".ToCharArray());

            foreach (string tAlias in pk12.Aliases)
            {
                if (pk12.IsKeyEntry(tAlias))
                {
                    alias = tAlias;
                    break;
                }
            }

            var pk = pk12.GetKey(alias).Key;
//            X509Certificate2 certificate = pk12.GetCertificate(alias).Certificate;

//            X509Certificate2 certificate = new X509Certificate2(cerPath);
            var PdfReader = new PdfReader(inputFileName);

            PdfStamper stamper = PdfStamper.CreateSignature(PdfReader, new FileStream(outputFileName, FileMode.Create), '\0', null, true);

            PdfSignatureAppearance appearance = stamper.SignatureAppearance;
//            BaseFont bf = BaseFont.CreateFont("Content/BRUSHSCI.TTF", BaseFont.IDENTITY_H, BaseFont.EMBEDDED);
//            iTextSharp.text.Font font = new iTextSharp.text.Font(bf, 11);
//            appearance.Layer2Font = font;
//            appearance.Image = new iTextSharp.text.pdf.PdfImage();
//            appearance.Reason = "Reason";
//            appearance.Contact = "Contact";
//            appearance.Location = "Location";
//            appearance.SignDate = DateTime.Now;
            appearance.Acro6Layers = true;
            appearance.Layer2Text = "";
//            appearance.Layer2Font = new iTextSharp.text.Font(bf, 11);

            appearance.Render = PdfSignatureAppearance.SignatureRender.GraphicAndDescription;
            appearance.SignatureGraphic = Image.GetInstance(System.Drawing.Image.FromFile("Content/DNVGLStamp2.png"), BaseColor.White);
            //            appearance.Render = PdfSignatureAppearance.SignatureRender.GraphicAndDescription;

            //            appearance.SetVisibleSignature(new iTextSharp.text.Rectangle(20, 10, 170, 60), 1, null);
            appearance.SetVisibleSignature(new iTextSharp.text.Rectangle(540, 50, 780, 140), 1, null);

            var cp = new X509CertificateParser();
//            var chain = new[] { cp.ReadCertificate(certificate.RawData) };
            appearance.SetCrypto(pk, new Org.BouncyCastle.X509.X509Certificate[] { pk12.GetCertificate(alias).Certificate }, null, PdfSignatureAppearance.SelfSigned);

            stamper.Close();
        }
    }
}
