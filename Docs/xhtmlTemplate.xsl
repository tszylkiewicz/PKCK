<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="1.0" 
    xmlns:xsl="http://www.w3.org/1999/XSL/Transform">
    <xsl:template match="/">
        <xsl:text disable-output-escaping='yes'>&lt;!DOCTYPE html PUBLIC &quot;-//W3C//DTD XHTML 1.0 Strict//EN&quot; &quot;http://www.w3.org/TR/xhtml1/DTD/xhtml1-strict.dtd&quot;&gt;
        </xsl:text>
        <html xmlns="http://www.w3.org/1999/xhtml">
            <head>
                <title>Movies Collection</title>
                <meta http-equiv="Content-Type" content="text/html; charset=UTF-8" />
                <link rel="stylesheet" href="panel.css" />
            </head>
            <body>
                <h2>Movies Collection</h2>
                <table class="movieTable">
                    <tr>
                        <th>No.</th>
                        <th>Title</th>
                        <th>Director</th>
                        <th>Realease Date</th>
                        <th>Duration</th>
                        <th>Genres</th>
                        <th>Production Places</th>
                    </tr>
                    <xsl:for-each select="MoviesCollection/Movie">
                        <tr>
                            <td>
                                <xsl:value-of select="No"/>
                            </td>
                            <td>
                                <xsl:value-of select="Title"/>
                            </td>
                            <td>
                                <xsl:value-of select="concat(Director/Firstname, ' ', Director/Lastname)"/>
                                <br></br>
                                <xsl:text>Born: </xsl:text>
                                <xsl:value-of select="Director/BirthDate"/>
                            </td>
                            <td>
                                <xsl:value-of select="ReleaseDate"/>
                            </td>
                            <td>
                                <xsl:value-of select="Duration"/>
                            </td>
                            <td>
                                <xsl:value-of select="Genres"/>
                            </td>
                            <td>
                                <xsl:value-of select="ProductionPlaces"/>
                            </td>
                        </tr>
                    </xsl:for-each>
                </table>
                <h2>DataSet Information</h2>
                <table class="movieTable">
                    <tr>
                        <th>Movies Count</th>
                        <th>Directors Count</th>
                        <th>Creation Date</th>
                    </tr>
                    <xsl:for-each select="MoviesCollection/Conclusion">
                        <tr>
                            <td>
                                <xsl:value-of select="MoviesCount"/>
                            </td>
                            <td>
                                <xsl:value-of select="DirectorsCount"/>
                            </td>
                            <td>
                                <xsl:value-of select="CreareDate"/>
                            </td>
                        </tr>
                    </xsl:for-each>
                </table>
            </body>
        </html>
    </xsl:template>
</xsl:stylesheet>