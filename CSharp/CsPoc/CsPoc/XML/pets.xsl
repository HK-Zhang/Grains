<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform">
  <xsl:template match="/">
    <html>
      <head>
        <META http-equiv="Content-Type" content="text/html; charset=utf-8"/>
        <title>lovely pets</title>
        <style type="text/css">
          ul{margin:10px 0 10px 0;padding:0;width:400px;text-align:left;}
          li{height:60px;display:block;list-style:none;padding:4px;border:1px solid #f0f0f0;margin:5px;}
        </style>
      </head>

      <body>
        <center>
        <h1>lovely pets</h1>
        <ul>
          <xsl:for-each select="pets/*">
            <li>
              <img align="right">
                <xsl:choose>
                  <xsl:when test="name() = 'dog'">
                    <xsl:attribute name="src">http://estar-tv.com/images/comprofiler/gallery/dog.gif</xsl:attribute>
                  </xsl:when>

                  <xsl:when test="name() = 'pig'">
                    <xsl:attribute name="src">http://www.icosky.com/icon/thumbnails/Animal/Farm/Pig%20Icon.jpg</xsl:attribute>
                  </xsl:when>

                  <xsl:otherwise>
                    <xsl:attribute name="src">http://farm1.static.flickr.com/14/buddyicons/22211409@N00.jpg?1143660418</xsl:attribute>
                  </xsl:otherwise>
                </xsl:choose>
              </img>

              <font>
                <xsl:attribute name="face">Courier</xsl:attribute>
                <xsl:attribute name="color">
                  <xsl:value-of select="@color"/>
                </xsl:attribute>
                <xsl:value-of select="name()"/>
              </font> said: "<xsl:value-of select="desc"/>"
              weight:<xsl:value-of select="@weight"/>
              <xsl:if test="@weight &gt; 10">
                <p>
                  <i>its weight is less than 10 km</i>
                </p>
              </xsl:if>
            </li>
          </xsl:for-each>
        </ul>
        </center>
      </body>
    </html>
  </xsl:template>
</xsl:stylesheet>