using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Xsl;

namespace CsPoc.XML
{
    public class XsltBasic
    {

        public void Execute()
        {
            //basicTransform();
            //split();
            splitEx();
        }

        public void basicTransform()
        {
            //声明XslTransform类实例
            System.Xml.Xsl.XslCompiledTransform trans = new System.Xml.Xsl.XslCompiledTransform();
            //string xsltFile = @"C:\Users\yxzhk\WorkSpace\CodeDemo\CsPoc\CsPoc\XML\pets.xsl";
            string xsltFile = @"C:\Users\yxzhk\WorkSpace\CodeDemo\CsPoc\CsPoc\XML\pets-templates.xsl";

            using (StreamReader rdr = new StreamReader(xsltFile))
            {
                using (XmlReader xmlRdr = XmlReader.Create(rdr))
                {
                    //载入xsl文件
                    trans.Load(xmlRdr);
                }
            }

            string inputFile = @"C:\Users\yxzhk\WorkSpace\CodeDemo\CsPoc\CsPoc\XML\pets.xml";
            string outputFile = @"C:\Users\yxzhk\WorkSpace\CodeDemo\CsPoc\CsPoc\XML\pets-out2.htm";

            //转化源文件输出到输出文件outputFile
            trans.Transform(inputFile, outputFile);
        }

        public void splitEx()
        {
            System.Xml.Xsl.XslCompiledTransform trans = new System.Xml.Xsl.XslCompiledTransform();
            XsltSettings settings = new XsltSettings(false, true);

            string xsltFile = @"C:\Users\yxzhk\WorkSpace\CodeDemo\CsPoc\CsPoc\XML\splitEx.xsl";

            using (StreamReader rdr = new StreamReader(xsltFile))
            {
                using (XmlReader xmlRdr = XmlReader.Create(rdr))
                {
                    trans.Load(xmlRdr, settings,new XmlUrlResolver());
                }
            }

            string inputFile = @"C:\Users\yxzhk\WorkSpace\CodeDemo\CsPoc\CsPoc\XML\splitEx.xml";
            string outputFile = @"C:\Users\yxzhk\WorkSpace\CodeDemo\CsPoc\CsPoc\XML\splitEx-out.xml";

            trans.Transform(inputFile, outputFile);
        }


        public void split()
        {
            System.Xml.Xsl.XslCompiledTransform trans = new System.Xml.Xsl.XslCompiledTransform();
            //XsltSettings settings = new XsltSettings(false, true);

            string xsltFile = @"C:\Users\yxzhk\WorkSpace\CodeDemo\CsPoc\CsPoc\XML\split.xsl";

            using (StreamReader rdr = new StreamReader(xsltFile))
            {
                using (XmlReader xmlRdr = XmlReader.Create(rdr))
                {
                    trans.Load(xmlRdr);
                }
            }

            string inputFile = @"C:\Users\yxzhk\WorkSpace\CodeDemo\CsPoc\CsPoc\XML\split.xml";
            string outputFile = @"C:\Users\yxzhk\WorkSpace\CodeDemo\CsPoc\CsPoc\XML\split-out.xml";


            XsltArgumentList xslArg = new XsltArgumentList();
            xslArg.AddParam("tag", "", "ItemA,ItemB,ItemC");

            //trans.Transform(inputFile,outputFile);

            using (XmlWriter w = XmlWriter.Create(outputFile))
            {
                trans.Transform(inputFile, xslArg, w);
            }

        }
    }
}
