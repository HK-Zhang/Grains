using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iTextSharp.text.pdf;

namespace CsPoc.Toolkit
{
    public class PdfReaderDemo
    {
        public static void Execute()
        {
            var pdfReader = new PdfReader("180526V20023.pdf");

            AcroFields fields = pdfReader.AcroFields;

            var a = fields.GetField("controlno");

            var b = fields.GetField("zhk");
            Console.WriteLine(a);
        }
    }
}
