<?xml version="1.0"?>

<xsl:stylesheet version="1.0" 
    xmlns:xsl="http://www.w3.org/1999/XSL/Transform">

    <xsl:template match="/">
        <html>
            <body>
                <h2>Movies Collection</h2>
                <table border="1">
                    <tr bgcolor="#9acd32">
                        <th/>
                        <th>Title</th>
                        <th>Director</th>
                        <th>Realease Date</th>
                        <th>Duration</th>
                        <th>Genres</th>
                        <th>Production Places</th>
                    </tr>
                    <xsl:for-each select="Collection/Movies/Movie">
                        <xsl:sort select="ReleaseDate"/>
                        <tr>
                            <td>
                                <countNo>
                                    <xsl:value-of select="concat(position(), '.')" />
                                </countNo>
                            </td>
                            <td>
                                <xsl:value-of select="Title"/>
                            </td>
                            <td>
                                <xsl:variable name="idref" select="Director/@directorID" />
                                <xsl:value-of select="concat(ancestor::*/Directors/Director[@directorID = $idref]/Firstname, ' ', ancestor::*/Directors/Director[@directorID = $idref]/Lastname, ' ', ancestor::*/Directors/Director[@directorID = $idref]/BirthDate)" />
                            </td>
                            <td>
                                <xsl:value-of select="ReleaseDate"/>
                            </td>
                            <td>
                                <xsl:value-of select="concat(Duration, ' ', Duration/@timeUnit)"/>
                            </td>
                            <td>
                                <xsl:for-each select="Genres">
                                    <table>
                                        <tr>
                                            <xsl:value-of select="."/>
                                        </tr>
                                    </table>
                                </xsl:for-each>
                            </td>
                            <td>
                                <xsl:for-each select="ProductionPlaces">
                                    <table>
                                        <tr>
                                            <xsl:value-of select="."/>
                                        </tr>
                                    </table>
                                </xsl:for-each>
                            </td>
                        </tr>
                    </xsl:for-each>
                </table>
                <h2>DataSet Information</h2>
                <table border="1">
                    <tr>
                        <td>Movies Count</td>
                        <td>
                            <xsl:value-of select="count(Collection/Movies/Movie)" />
                        </td>
                    </tr>
                    <tr>
                        <td>Directors Count</td>
                        <td>
                            <xsl:value-of select="count(Collection/Directors/Director)" />
                        </td>
                    </tr>
                    <tr>
                        <td>Creation Date</td>
                        <td>
                            <xsl:value-of select="current-dateTime()"/>
                        </td>
                    </tr>
                </table>
            </body>
        </html>
    </xsl:template>

</xsl:stylesheet>