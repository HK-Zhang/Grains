<?xml version="1.0" encoding="UTF-8"?>
<xsl:stylesheet
    version="1.0"
    xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
    xmlns:msxml="urn:schemas-microsoft-com:xslt"
    xmlns:msxsl="urn:schemas-microsoft-com:xslt"
    xmlns:umbraco.library="urn:umbraco.library"
    xmlns:mycustomprefix="urn:mycustomprefix"
    exclude-result-prefixes="msxml umbraco.library mycustomprefix msxsl">
 

   <xsl:output method="xml" omit-xml-declaration="yes"/>
    <msxsl:script language="CSharp" implements-prefix="mycustomprefix">
      <![CDATA[ 
            public int testNumber(int num)
            {
                  if(num> 5 || num<= 0 || num== null)
                  {
                        return 5;
                  }
                  else
                  {
                        return num;
                  }
            }
          ]]>
    </msxsl:script> 
    <xsl:param name="currentPage"/>
   <xsl:variable name="numberToTest" select="mycustomprefix:testNumber(number(/macro/numberToTest))"/>
    <xsl:template match="/">
        <xsl:value-of select="$numberToTest"/>
    </xsl:template>
</xsl:stylesheet>