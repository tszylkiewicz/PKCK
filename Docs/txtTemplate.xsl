<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="1.0" 
    xmlns:xsl="http://www.w3.org/1999/XSL/Transform">
    <xsl:output method="text" version="1.0" encoding="UTF-8"/>
    <xsl:template match="/">
        <xsl:text>Movies Collection&#10;&#10;</xsl:text>
		<xsl:text>Title                         Director Name            Director Birth Date      Release Date   Duration  Cost      Genres                        Production Places&#10;</xsl:text>
		<xsl:text>=================================================================================================================================================================================</xsl:text>
        <xsl:for-each select="MoviesCollection/Movie">	
			<xsl:text>&#10;</xsl:text>		
            <xsl:value-of select="concat(No, Title)"/>
            <xsl:call-template name="padding">
            <xsl:with-param name="length" select="30 - string-length(concat(No, Title))"/>
            </xsl:call-template>

			<xsl:value-of select="concat(Director/Firstname,' ',Director/Lastname)"/>
            <xsl:call-template name="padding">
            <xsl:with-param name="length" select="25 - string-length(concat(Director/Firstname,' ',Director/Lastname))"/>
            </xsl:call-template>

			<xsl:value-of select="Director/BirthDate"/>
            <xsl:call-template name="padding">
            <xsl:with-param name="length" select="25 - string-length(Director/BirthDate)"/>
            </xsl:call-template>
            
			<xsl:value-of select="ReleaseDate"/>
            <xsl:call-template name="padding">
            <xsl:with-param name="length" select="15 - string-length(ReleaseDate)"/>
            </xsl:call-template>
            
			<xsl:value-of select="concat(Duration,' ',Duration/@timeUnit)"/>
            <xsl:call-template name="padding">
            <xsl:with-param name="length" select="10 - string-length(concat(Duration,' ',Duration/@timeUnit))"/>
            </xsl:call-template>

			<xsl:value-of select="concat(Cost,' ',Cost/@currency)"/>
            <xsl:call-template name="padding">
            <xsl:with-param name="length" select="10 - string-length(concat(Cost,' ',Cost/@currency))"/>
            </xsl:call-template>
            
			<xsl:value-of select="normalize-space(Genres)"/>
            <xsl:call-template name="padding">
            <xsl:with-param name="length" select="30 - string-length(normalize-space(Genres))"/>
            </xsl:call-template>
            
			<xsl:value-of select="normalize-space(ProductionPlaces)"/>
        </xsl:for-each>
		
		<xsl:text>&#10;&#10;Conclusion&#10;&#10;</xsl:text>
            <xsl:value-of select="concat('Movies count: ', MoviesCollection/Conclusion/MoviesCount)"/>
			<xsl:text>&#10;</xsl:text>	
            <xsl:value-of select="concat('Directors count: ', MoviesCollection/Conclusion/DirectorsCount)"/>
			<xsl:text>&#10;</xsl:text>	
            <xsl:value-of select="concat('Total cost: ', MoviesCollection/Conclusion/TotalCost,' ',MoviesCollection/Conclusion/TotalCost/@currency)"/>
            <xsl:text>&#10;</xsl:text>	
            <xsl:value-of select="concat('Average cost: ', MoviesCollection/Conclusion/AverageCost,' ',MoviesCollection/Conclusion/AverageCost/@currency)"/>
            <xsl:text>&#10;</xsl:text>	
            <xsl:value-of select="concat('Minimum cost: ', MoviesCollection/Conclusion/MinCost,' ',MoviesCollection/Conclusion/MinCost/@currency)"/>
            <xsl:text>&#10;</xsl:text>	
            <xsl:value-of select="concat('Maximum cost: ', MoviesCollection/Conclusion/MaxCost,' ',MoviesCollection/Conclusion/MaxCost/@currency)"/>
           <xsl:text>&#10;</xsl:text>	
            <xsl:value-of select="concat('Create date: ', MoviesCollection/Conclusion/CreateDate)"/>
    </xsl:template>

    <xsl:template name="padding">
  <xsl:param name="length"/>
  <xsl:param name="string" select="' '"/>
  <xsl:value-of select="$string"/>
  <xsl:if test="$length > 1">
    <xsl:call-template name="padding">
      <xsl:with-param name="length" select="$length - 1"/>
      <xsl:with-param name="string" select="$string"/>
    </xsl:call-template>
  </xsl:if>
</xsl:template>
</xsl:stylesheet>
