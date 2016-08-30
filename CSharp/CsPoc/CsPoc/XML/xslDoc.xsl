<?xml version="1.0" encoding="UTF-8"?>
<xsl:stylesheet version="1.0"     
    xmlns:xsl="http://www.w3.org/1999/XSL/Transform"   
    xmlns:string="http://www.dnvgl.com/string">   
   
  <xsl:template match="/">   
    <xsl:variable name="Collection" select="root/users/user" />   
          <xsl:for-each select="$Collection">   
        <xsl:value-of select="string:Add(@fname,@lname)" />         
      </xsl:for-each>   
  </xsl:template>   
</xsl:stylesheet>   
