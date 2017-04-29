using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Xsl;

namespace CsPoc
{
    public class XSLTCS
    {
        public void Execute()
        {
            //OutputFormatXML();
            var dt = OutputDataTable();
        }

        private void OutputFormatXML()
        {
            string xmlPath = @"C:\Users\yxzhk\WorkSpace\CodeDemo\CsPoc\CsPoc\XML\target.xml";
            string xsltPath = @"C:\Users\yxzhk\WorkSpace\CodeDemo\CsPoc\CsPoc\XML\CSRCNAV.xslt";
            string outputPath = @"C:\Users\yxzhk\WorkSpace\CodeDemo\CsPoc\CsPoc\XML\output.xml";

            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(xmlPath);

            StringBuilder sbXml = new StringBuilder();
            StringWriter stringWriter = new StringWriter(sbXml);
            XmlTextWriter xmlTextWriter = new XmlTextWriter(stringWriter);

            //设置可以执行脚本函数
            XsltSettings settings = new XsltSettings();
            settings.EnableDocumentFunction = true;
            settings.EnableScript = true;

            //设置xslt可以包含外部的xslt文件
            XmlUrlResolver resolver = new XmlUrlResolver();
            resolver.Credentials = System.Net.CredentialCache.DefaultCredentials;

            XslCompiledTransform xslCompiledTransform = new XslCompiledTransform();
            xslCompiledTransform.Load(xsltPath, settings, resolver);
            xslCompiledTransform.Transform(xmlDoc, xmlTextWriter);

            XmlDocument xmlFormatDoc = new XmlDocument();
            xmlFormatDoc.LoadXml(sbXml.ToString());
            xmlFormatDoc.Save(outputPath);
        }

        private DataTable OutputDataTable()
        {
            string xmlPath = @"C:\Users\yxzhk\WorkSpace\CodeDemo\CsPoc\CsPoc\XML\target.xml";
            string xsltPath = @"C:\Users\yxzhk\WorkSpace\CodeDemo\CsPoc\CsPoc\XML\CSRCNAV.xslt";
            string schemaPath = @"C:\Users\yxzhk\WorkSpace\CodeDemo\CsPoc\CsPoc\XML\CSRCNAV.xsd";

            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(xmlPath);

            //设置可以执行脚本函数
            XsltSettings settings = new XsltSettings();
            settings.EnableDocumentFunction = true;
            settings.EnableScript = true;

            //设置xslt可以包含外部的xslt文件
            XmlUrlResolver resolver = new XmlUrlResolver();
            resolver.Credentials = System.Net.CredentialCache.DefaultCredentials;

            MemoryStream memoryStream = new MemoryStream();
            XslCompiledTransform xslCompiledTransform = new XslCompiledTransform();
            xslCompiledTransform.Load(xsltPath, settings, resolver);
            xslCompiledTransform.Transform(xmlDoc, null, memoryStream);

            using (DataTable dt = new DataTable())
            {
                dt.ReadXmlSchema(schemaPath);
                memoryStream.Position = 0;
                dt.ReadXml(memoryStream);

                return dt;
            }
        }
    }
}
