<?xml version="1.0"?>

<xsl:stylesheet version="1.0" 
    xmlns:xsl="http://www.w3.org/1999/XSL/Transform">

    <xsl:template match="/">
        <html>
            <body>
                <h2>Movies Collection</h2>
                <table border="1">
                    <tr bgcolor="#9acd32">
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
                                <xsl:value-of select="Title"/>
                            </td>
                            <td>
                                <xsl:value-of select="Director/@directorID"/>
                            </td>
                            <td>
                                <xsl:value-of select="ReleaseDate"/>
                            </td>
                            <td>
                                <xsl:value-of select="Duration"/>
                                <xsl:value-of select="Duration/@timeUnit"/>
                            </td>
                            <td>
                                <table border="1">
                                    <tr bgcolor="#9acd32">
                                        <th>Genres</th>
                                    </tr>
                                    <xsl:for-each select="Genres">
                                        <tr>
                                            <td>
                                                <xsl:value-of select="."/>
                                            </td>
                                        </tr>
                                    </xsl:for-each>
                                </table>
                            </td>
                            <td>
                                <table border="1">
                                    <tr bgcolor="#9acd32">
                                        <th>Places</th>
                                    </tr>
                                    <xsl:for-each select="ProductionPlaces">
                                        <tr>
                                            <td>
                                                <xsl:value-of select="."/>
                                            </td>
                                        </tr>
                                    </xsl:for-each>
                                </table>
                            </td>
                        </tr>
                    </xsl:for-each>
                </table>
            </body>
        </html>
    </xsl:template>

</xsl:stylesheet>