<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
    xmlns:msxsl="urn:schemas-microsoft-com:xslt" exclude-result-prefixes="msxsl">
  <xsl:output method="xml" indent="yes" omit-xml-declaration="yes"/>

  <xsl:param name="tag"/>
  <xsl:template match="/">
<root>
  <xsl:call-template name="output-tokens">
      <xsl:with-param name="list" select="$tag"/>
      <xsl:with-param name="separator">,</xsl:with-param>
    </xsl:call-template>
    </root>
  </xsl:template>

  <xsl:template name="output-tokens">
    <xsl:param name="list" />
    <xsl:param name="separator" />
    <xsl:variable name="newlist" select="concat(normalize-space($list), $separator)" />
    <xsl:variable name="first" select="substring-before($newlist, $separator)" />
    <xsl:variable name="remaining" select="substring-after($newlist, $separator)" />
    <item>
    <xsl:value-of select="//*[name() = $first]" disable-output-escaping="yes"/>
    </item>

    <xsl:if test="substring-before($remaining, $separator) != ''">
      <xsl:call-template name="output-tokens">
        <xsl:with-param name="list" select="$remaining" />
        <xsl:with-param name="separator" select="$separator" />
      </xsl:call-template>
    </xsl:if>
  </xsl:template>
</xsl:stylesheet>