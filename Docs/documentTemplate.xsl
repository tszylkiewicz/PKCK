<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="1.0" 
    xmlns:xsl="http://www.w3.org/1999/XSL/Transform">
    <xsl:output method="xml" version="1.0" encoding="UTF-8"/>     
    <xsl:key name="dir" match="Collection/Directors/Director" use="@directorID"/>
    <xsl:template match="/">
        <MoviesCollection>
            <xsl:for-each select="Collection/Movies/Movie">
                <xsl:sort select="ReleaseDate" order="descending"/>
                <Movie>
                    <No>
                        <xsl:value-of select="concat(position(), '.')"/>
                    </No>
                    <Title>
                        <xsl:value-of select="Title"/>
                    </Title>
                    <Director>
                        <Firstname>
                            <xsl:value-of select="key('dir', Director/@directorID)/Firstname"/>
                        </Firstname>
                        <Lastname>
                            <xsl:value-of select="key('dir', Director/@directorID)/Lastname"/>
                        </Lastname>
                        <BirthDate>
                            <xsl:value-of select="key('dir', Director/@directorID)/BirthDate"/>
                        </BirthDate>
                    </Director>
                    <ReleaseDate>
                        <xsl:value-of select="ReleaseDate"/>
                    </ReleaseDate>
                    <Duration>
						<xsl:attribute name="timeUnit">min</xsl:attribute>
                        <xsl:choose>
                            <xsl:when test="Duration/@timeUnit='h'">
                                <xsl:value-of select="Duration*60"/>
                            </xsl:when>
                            <xsl:otherwise>
                                <xsl:value-of select="Duration"/>
                            </xsl:otherwise>
                        </xsl:choose>
                    </Duration>
                    <Cost>
						<xsl:attribute name="currency">PLN</xsl:attribute>
                        <xsl:choose>
                            <xsl:when test="Cost/@currency='USD'">
                                <xsl:value-of select="Cost*3.8"/>
                            </xsl:when>
                            <xsl:when test="Cost/@currency='EUR'">
                                <xsl:value-of select="Cost*4.2"/>
                            </xsl:when>
                            <xsl:otherwise>
                                <xsl:value-of select="Cost"/>
                            </xsl:otherwise>
                        </xsl:choose>
                    </Cost>
                    <Genres>
                        <xsl:for-each select="Genres">
                            <xsl:value-of select="."/>
                        </xsl:for-each>
                    </Genres>
                    <ProductionPlaces>
                        <xsl:for-each select="ProductionPlaces">
                            <xsl:value-of select="."/>
                        </xsl:for-each>
                    </ProductionPlaces>
                </Movie>
            </xsl:for-each>

            <Conclusion>
                <MoviesCount>
                    <xsl:value-of select="count(Collection/Movies/Movie)"/>
                </MoviesCount>
                <DirectorsCount>
                    <xsl:value-of select="count(Collection/Directors/Director)"/>
                </DirectorsCount>
                <TotalCost>
					<xsl:attribute name="currency">PLN</xsl:attribute>
                    <xsl:value-of select="sum(Collection/Movies/Movie/Cost)"/>
                </TotalCost>
                <AverageCost>
					<xsl:attribute name="currency">PLN</xsl:attribute>
                    <xsl:value-of select="sum(Collection/Movies/Movie/Cost) div count(Collection/Movies/Movie)"/>
                </AverageCost>
                <MinCost>
					<xsl:attribute name="currency">PLN</xsl:attribute>
                    <xsl:value-of select="min(Collection/Movies/Movie/Cost)"/>
                </MinCost>
                <MaxCost>
					<xsl:attribute name="currency">PLN</xsl:attribute>
                    <xsl:value-of select="max(Collection/Movies/Movie/Cost)"/>
                </MaxCost>
                <CreareDate>
                    <xsl:value-of select="format-date(current-date(), '[Y0001]-[M01]-[D01]')"/>
                </CreareDate>
            </Conclusion>
        </MoviesCollection>
    </xsl:template>

</xsl:stylesheet>