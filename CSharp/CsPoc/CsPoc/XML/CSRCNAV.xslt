<?xml version="1.0" encoding="UTF-8" ?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform" xmlns:msxsl="urn:schemas-microsoft-com:xslt" xmlns:csfun="urn:csharp-functions" exclude-result-prefixes="msxsl">
    <xsl:output method="xml" indent="yes"/>
    <xsl:include href="CSharpFunctions.xslt"/>
    <xsl:template match="/">
        <CSRCNAVSet>
            <xsl:for-each select="//table[@id='tablesorter-instance']/tbody/tr">
                <CSRCNAV>
                    <Symbol>
                        <xsl:value-of select="td[position()=2]"/>
                    </Symbol>

                    <Name>
                        <xsl:value-of select="csfun:Trim(td[position()=3])"/>
                    </Name>

                    <xsl:if test="csfun:CheckDecimal(td[position()=4])">
                        <ClosePrice>
                            <xsl:value-of select="td[position()=4]"/>
                        </ClosePrice>
                    </xsl:if>

                    <EffectiveDate>
                        <xsl:value-of select="td[position()=6]"/>
                    </EffectiveDate>
                </CSRCNAV>
            </xsl:for-each>
        </CSRCNAVSet>
    </xsl:template>
</xsl:stylesheet>