<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="1.0" 
    xmlns:xsl="http://www.w3.org/1999/XSL/Transform">
    <xsl:output method="text" version="1.0" encoding="UTF-8"/>
    <xsl:template match="/">
        <xsl:text>Movies Collection</xsl:text>
        <xsl:for-each select="MoviesCollection/Movie">
            <xsl:text>
                <xsl:value-of select="concat(No, Title, Director/Firstname, Director/Lastname, Director/BirthDate, ReleaseDate, Duration, Cost)"/>
            </xsl:text>
        </xsl:for-each>
    </xsl:template>
</xsl:stylesheet>