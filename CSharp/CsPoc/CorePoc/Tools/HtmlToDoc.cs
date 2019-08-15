using System.Collections.Generic;
using System.IO;
using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;
using HtmlToOpenXml;


namespace CorePoc.Tools
{
    public class HtmlToDoc
    {
        const string filename = "test.docx";


        public static void Execute()
        {
            string html = File.ReadAllText("./test.html");

            if (File.Exists(filename)) File.Delete(filename);

            using (MemoryStream generatedDocument = new MemoryStream())
            {
                using (WordprocessingDocument package = WordprocessingDocument.Create(generatedDocument, WordprocessingDocumentType.Document))
                {
                    MainDocumentPart mainPart = package.MainDocumentPart;
                    if (mainPart == null)
                    {
                        mainPart = package.AddMainDocumentPart();
                        new Document(new Body()).Save(mainPart);
                    }

                    HtmlConverter converter = new HtmlConverter(mainPart);
                    converter.ImageProcessing = ImageProcessing.AutomaticDownload;
                    converter.ParseHtml(html);

                    mainPart.Document.Save();
                }

                File.WriteAllBytes(filename, generatedDocument.ToArray());
            }


        }


//        private static byte[] HtmlToWord(string html, string fileName)
//        {
//            using (MemoryStream memoryStream = new MemoryStream())
//            using (WordprocessingDocument wordDocument = WordprocessingDocument.Create(
//                memoryStream, WordprocessingDocumentType.Document))
//            {
//                MainDocumentPart mainPart = wordDocument.MainDocumentPart;
//                if (mainPart == null)
//                {
//                    mainPart = wordDocument.AddMainDocumentPart();
//                    new Document(new Body()).Save(mainPart);
//                }
//
//                HtmlConverter converter = new HtmlConverter(mainPart);
//                converter.ImageProcessing = ImageProcessing.AutomaticDownload;
//                Body body = mainPart.Document.Body;
//
//                IList<OpenXmlCompositeElement> paragraphs = converter.Parse(html);
//                body.Append(paragraphs);
//
//                mainPart.Document.Save();
//                return memoryStream.ToArray();
//            }
//        }
    }
}
