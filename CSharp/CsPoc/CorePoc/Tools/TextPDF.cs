using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace CorePoc.Tools
{
    public class TextPDF
    {
        public static void Execute()
        {
            FillForm();

//            var fileList = new List<string>();
//            fileList.Add("RT Report Template1.pdf");
//            fileList.Add("RT Report Template2.pdf");
//
//
//            mergePDFFiles(fileList,"rst.pdf");
            Console.WriteLine("ok");
        }

        public static void FillForm()
        {
            PDFSampleForm sampleFormModel = new PDFSampleForm()
            {
                FirstName = "John",
                LastName = "Doe",
                AwesomeCheck = true
            };
            using (Stream pdfInputStream = new FileStream(path: "T0.pdf", mode: FileMode.Open))
            using (Stream resultPDFOutputStream = new FileStream(path: "T0R.pdf", mode: FileMode.Create))
            using (Stream resultPDFStream = FillForm(pdfInputStream, sampleFormModel))
            {
                // set the position of the stream to 0 to avoid corrupted PDF. 
                resultPDFStream.Position = 0;
                resultPDFStream.CopyTo(resultPDFOutputStream);
            }
        }

        public static Stream FillForm(Stream inputStream, PDFSampleForm model)
        {
            Stream outStream = new MemoryStream();
            PdfReader pdfReader = null;
            PdfStamper pdfStamper = null;
            Stream inStream = null;
            try
            {
                pdfReader = new PdfReader(inputStream);
                pdfStamper = new PdfStamper(pdfReader, outStream);
                AcroFields form = pdfStamper.AcroFields;
                form.SetField("ReportNo", model.FirstName);
                form.SetField("DigitalSignature", model.LastName);
                form.SetField("IDate","Yes");
                // set this if you want the result PDF to not be editable. 
                pdfStamper.FormFlattening = true;
                pdfStamper.AddSignature("He Ke Zhang", 1, 0, 0, 0,0);

                return outStream;
            }
            finally
            {
                pdfStamper?.Close();
                pdfReader?.Close();
                inStream?.Close();
            }
        }

        public static void mergePDFFiles(List<string> fileList, string outMergeFile)
        {
            PdfReader reader;
//            Rectangle rec = new Rectangle(1660, 1000);
            Document document = new Document(iTextSharp.text.PageSize.A4.Rotate(),30,30,30,30);
            PdfWriter writer = PdfWriter.GetInstance(document, new FileStream(outMergeFile, FileMode.Create));
            document.Open();
            PdfContentByte cb = writer.DirectContent;
            PdfImportedPage newPage;
            for (int i = 0; i < fileList.Count; i++)
            {
                reader = new PdfReader(fileList[i]);
                int iPageNum = reader.NumberOfPages;
                for (int j = 1; j <= iPageNum; j++)
                {
                    document.NewPage();
                    newPage = writer.GetImportedPage(reader, j);
                    cb.AddTemplate(newPage, 0, 0);
                }
            }
            document.Close();
        }

    }

    public struct SampleFormFieldNames
    {
        public const string FirstName = "First Name";
        public const string LastName = "Last Name";
        public const string IAmAwesomeCheck = "Awesome Checkbox";
    }

    public class PDFSampleForm
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool AwesomeCheck { get; set; }
    }
}
