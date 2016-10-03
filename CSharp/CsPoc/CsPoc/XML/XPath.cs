using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace CsPoc.XML
{
    public class XPath
    {
        public void Execute()
        {
        }

        public void Foo()
        {
            string xml = @"<?xml version=""1.0"" encoding=""utf-8"" ?>
<pets>
  <cat color=""black"" weight=""10"" count=""4"">
    <price>100</price>
    <desc>this is a black cat</desc>
  </cat>

  <cat color=""white"" weight=""9"" count=""5"">
    <price>80</price>
    <desc>this is a white cat</desc>
  </cat>

  <cat color=""yellow"" weight=""15"" count=""1"">
    <price>110</price>
    <desc>this is a yellow cat</desc>
  </cat>

  <dog color=""black"" weight=""10"" count=""7"">
    <price>114</price>
    <desc>this is a black dog</desc>
  </dog>

  <dog color=""white"" weight=""9"" count=""4"">
    <price>80</price>
    <desc>this is a white dog</desc>
  </dog>

  <dog color=""yellow"" weight=""15"" count=""15"">
    <price>80</price>
    <desc>this is a yellow dog</desc>
  </dog>

  <pig color=""white"" weight=""100"" count=""2"">
    <price>8000</price>
    <desc>this is a white pig</desc>    
  </pig>
</pets>";

            using (StringReader rdr = new StringReader(xml))
            {
                XmlDocument doc = new XmlDocument();
                doc.Load(rdr);

                //取所有pets节点下的dog字节点
                XmlNodeList nodeListAllDog = doc.SelectNodes("/pets/dog");

                //所有的price节点
                XmlNodeList allPriceNodes = doc.SelectNodes("//price");

                //取最后一个price节点
                XmlNode lastPriceNode = doc.SelectSingleNode("//price[last()]");

                //用双点号取price节点的父节点
                XmlNode lastPriceParentNode = lastPriceNode.SelectSingleNode("..");

                //选择weight*count=40的所有动物，使用通配符*
                XmlNodeList nodeList = doc.SelectNodes("/pets/*[@weight*@count=40]");

                //选择除了pig之外的所有动物,使用name()函数返回节点名字
                XmlNodeList animalsExceptPigNodes = doc.SelectNodes("/pets/*[name() != 'pig']");

                //选择价格大于100而不是pig的动物
                XmlNodeList priceGreaterThan100s = doc.SelectNodes("/pets/*[price div @weight >10 and name() != 'pig']");

                foreach (XmlNode item in priceGreaterThan100s)
                {
                    Console.WriteLine(item.OuterXml);
                }

                //选择第二个dog节点
                XmlNode theSecondDogNode = doc.SelectSingleNode("//dog[position() = 2]");

                //使用xpath ，axes 的 parent 取父节点
                XmlNode parentNode = theSecondDogNode.SelectSingleNode("parent::*");

                //使用xPath选择第二个dog节点前面的所有dog节点
                XmlNodeList dogPresibling = theSecondDogNode.SelectNodes("preceding::dog");

                //取文档的所有子孙节点price
                XmlNodeList childrenNodes = doc.SelectNodes("descendant::price");

            }

        }
    }
}
