<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="1.0" 
    xmlns:xsl="http://www.w3.org/1999/XSL/Transform">
    <xsl:output method="xml" encoding="utf-8"/>
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
                        <xsl:variable name="idref" select="Director/@directorID"/>
                        <Firstname>
                            <xsl:value-of select="ancestor::*/Directors/Director[@directorID = $idref]/Firstname"/>
                        </Firstname>
                        <Lastname>
                            <xsl:value-of select="ancestor::*/Directors/Director[@directorID = $idref]/Lastname"/>
                        </Lastname>
                        <BirthDate>
                            <xsl:value-of select="ancestor::*/Directors/Director[@directorID = $idref]/BirthDate"/>
                        </BirthDate>
                    </Director>
                    <ReleaseDate>
                        <xsl:value-of select="ReleaseDate"/>
                    </ReleaseDate>
                    <Duration>
                        <xsl:value-of select="concat(Duration, ' ', Duration/@timeUnit)"/>
                    </Duration>
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
                    <xsl:value-of select="count(Collection/Movies/Movie)" />
                </MoviesCount>
                <DirectorsCount>
                    <xsl:value-of select="count(Collection/Directors/Director)" />
                </DirectorsCount>
                <CreareDate>
                    <xsl:value-of select="format-date(current-date(), '[Y0001]-[M01]-[D01]')"/>
                </CreareDate>
            </Conclusion>
        </MoviesCollection>
    </xsl:template>

</xsl:stylesheet>