<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="1.0" 
    xmlns:xsl="http://www.w3.org/1999/XSL/Transform">
    <xsl:output method="xml" version="1.0" encoding="UTF-8"/>
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
                        <xsl:choose>
                            <xsl:when test="Duration/@timeUnit='h'">
                                <xsl:value-of select="concat(Duration*60, ' ', 'min')"/>
                            </xsl:when>
                            <xsl:otherwise>
                                <xsl:value-of select="concat(Duration, ' ', Duration/@timeUnit)"/>
                            </xsl:otherwise>
                        </xsl:choose>
                    </Duration>
                    <Cost>
                        <xsl:choose>
                            <xsl:when test="Cost/@currency='USD'">
                                <xsl:value-of select="concat(Cost*3.8, ' ', 'PLN')"/>
                            </xsl:when>
                            <xsl:when test="Cost/@currency='EUR'">
                                <xsl:value-of select="concat(Cost*4.2, ' ', 'PLN')"/>
                            </xsl:when>
                            <xsl:otherwise>
                                <xsl:value-of select="concat(Cost, ' ', Cost/@currency)"/>
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
                    <xsl:value-of select="count(Collection/Movies/Movie)" />
                </MoviesCount>
                <DirectorsCount>
                    <xsl:value-of select="count(Collection/Directors/Director)" />
                </DirectorsCount>
                <TotalCost>
                    <xsl:value-of select="concat(sum(Collection/Movies/Movie/Cost), ' ', Collection/Movies/Movie/Cost/@currency)" />
                </TotalCost>
                <CreareDate>
                    <xsl:value-of select="format-date(current-date(), '[Y0001]-[M01]-[D01]')"/>
                </CreareDate>
            </Conclusion>
        </MoviesCollection>
    </xsl:template>

</xsl:stylesheet>