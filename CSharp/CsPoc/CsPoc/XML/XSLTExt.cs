using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.XPath;
using System.Xml.Xsl;

namespace CsPoc.XML
{
    public class XSLTExt
    {
        const String xmlFile = @"C:\Users\yxzhk\WorkSpace\CodeDemo\CsPoc\CsPoc\XML\xmlDoc.xml";
        const String styleSheet = @"C:\Users\yxzhk\WorkSpace\CodeDemo\CsPoc\CsPoc\XML\xslDoc.xsl";

        public XSLTExt() { }

        public void Execute()
        {
            //Create the XslTransform and load the stylesheet.    
            XslCompiledTransform xslt = new XslCompiledTransform();
            //XslCompiledTransform xslt = new XslCompiledTransform(true);    
            xslt.Load(styleSheet);

            //Load the XML data file.    
            XPathDocument xmlDoc = new XPathDocument(xmlFile);

            //Create an XsltArgumentList.    
            XsltArgumentList xslArg = new XsltArgumentList();

            XsltExtString obj = new XsltExtString();
            //加入自已的名字空间，扩展的XSLT文档也必须加上    
            xslArg.AddExtensionObject("http://www.dnvgl.com/string", obj);

            //Create an XmlTextWriter to output to the console.                 
            XmlTextWriter writer = new XmlTextWriter(Console.Out);

            //Transform the file.    
            xslt.Transform(xmlDoc, xslArg, writer, null);
            writer.Close();
        }

    }

    public class XsltExtString
    {
        public string Add(string str1, string str2)
        {
            return str1 + " |-| " + str2;
        }
    }

}
