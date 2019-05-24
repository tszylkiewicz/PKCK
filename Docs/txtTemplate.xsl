<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="1.0" 
    xmlns:xsl="http://www.w3.org/1999/XSL/Transform">
    <xsl:output method="text" version="1.0" encoding="UTF-8"/>
    <xsl:template match="/">
        <xsl:text>Movies Collection&#10;&#10;</xsl:text>
		<xsl:text>Title&#x9;|&#x9;Director Name&#x9;|&#x9;Director Birth Date&#x9;|&#x9;Release Date&#x9;|&#x9;Duration&#x9;|&#x9;Cost&#x9;|&#x9;Genres&#x9;|&#x9;Production Places&#10;</xsl:text>
		<xsl:text>=================================================================================================================================================================================</xsl:text>
        <xsl:for-each select="MoviesCollection/Movie">	
			<xsl:text>&#10;</xsl:text>		
            <xsl:value-of select="concat(No, Title)"/>
            <xsl:text>&#x9;|&#x9;</xsl:text>
			<xsl:value-of select="concat(Director/Firstname,' ',Director/Lastname)"/>
			<xsl:text>&#x9;|&#x9;</xsl:text>
			<xsl:value-of select="Director/BirthDate"/>
			<xsl:text>&#x9;|&#x9;</xsl:text>
			<xsl:value-of select="ReleaseDate"/>
			<xsl:text>&#x9;|&#x9;</xsl:text>
			<xsl:value-of select="concat(Duration,' ',Duration/@timeUnit)"/>
			<xsl:text>&#x9;|&#x9;</xsl:text>
			<xsl:value-of select="concat(Cost,' ',Cost/@currency)"/>
			<xsl:text>&#x9;|&#x9;</xsl:text>
			<xsl:value-of select="normalize-space(Genres)"/>
			<xsl:text>&#x9;|&#x9;</xsl:text>
			<xsl:value-of select="normalize-space(ProductionPlaces)"/>
        </xsl:for-each>
		
		<xsl:text>&#10;&#10;Conclusion&#10;&#10;</xsl:text>
		<xsl:text>Movies Count&#x9;|&#x9;Directors Count&#x9;|&#x9;Total Cost&#x9;|&#x9;Average Cost&#x9;|&#x9;Min Cost&#x9;|&#x9;Max Cost&#x9;|&#x9;Create Date&#10;</xsl:text>
		<xsl:text>=================================================================================================================================================================================</xsl:text>
		<xsl:for-each select="MoviesCollection/Conclusion">
			<xsl:text>&#10;</xsl:text>	
            <xsl:value-of select="MoviesCount"/>
			<xsl:text>&#x9;|&#x9;</xsl:text>
            <xsl:value-of select="DirectorsCount"/>
			<xsl:text>&#x9;|&#x9;</xsl:text>
            <xsl:value-of select="concat(TotalCost,' ',TotalCost/@currency)"/>
            <xsl:text>&#x9;|&#x9;</xsl:text>
            <xsl:value-of select="concat(AverageCost,' ',AverageCost/@currency)"/>
            <xsl:text>&#x9;|&#x9;</xsl:text>
            <xsl:value-of select="concat(MinCost,' ',MinCost/@currency)"/>
            <xsl:text>&#x9;|&#x9;</xsl:text>
            <xsl:value-of select="concat(MaxCost,' ',MaxCost/@currency)"/>
            <xsl:text>&#x9;|&#x9;</xsl:text>
            <xsl:value-of select="CreareDate"/>
		</xsl:for-each>
    </xsl:template>
</xsl:stylesheet>
