<?xml version="1.0" encoding="UTF-8" ?>
<xsl:stylesheet version="1.0" 
	xmlns:fo="http://www.w3.org/1999/XSL/Format" 
	xmlns:xsl="http://www.w3.org/1999/XSL/Transform">
	<xsl:output method="xml" version="1.0" indent="yes"/>
	<xsl:template match="MoviesCollection">
		<fo:root xmlns:fo="http://www.w3.org/1999/XSL/Format">
			<fo:layout-master-set>
				<fo:simple-page-master page-height="297mm" page-width="210mm" margin="5mm 15mm 5mm 15mm" master-name="PageMaster">
					<fo:region-body margin="20mm 0mm 20mm 0mm"/>
				</fo:simple-page-master>
			</fo:layout-master-set>

			<fo:page-sequence master-reference="PageMaster">
				<fo:flow flow-name="xsl-region-body">
					<fo:block font-weight="bold" text-align="center" font-size="16" margin-bottom="40px">Movies Collection</fo:block>
					<fo:table table-layout="fixed" border-width="1mm" border-style="solid">
						<fo:table-column column-width="25px"/>
						<fo:table-column column-width="auto"/>
						<fo:table-column column-width="auto"/>
						<fo:table-column column-width="auto"/>
						<fo:table-column column-width="60px"/>
						<fo:table-column column-width="45px"/>
						<fo:table-column column-width="auto"/>
						<fo:table-column column-width="auto"/>
						<fo:table-header text-align="center" background-color="silver">
							<fo:table-row>
								<fo:table-cell padding="1mm" border-width="1mm" border-style="solid">
									<fo:block font-weight="bold">No</fo:block>
								</fo:table-cell>
								<fo:table-cell padding="1mm" border-width="1mm" border-style="solid">
									<fo:block font-weight="bold">Title</fo:block>
								</fo:table-cell>
								<fo:table-cell padding="1mm" border-width="1mm" border-style="solid">
									<fo:block font-weight="bold">Director</fo:block>
								</fo:table-cell>
								<fo:table-cell padding="1mm" border-width="1mm" border-style="solid">
									<fo:block font-weight="bold">Release date</fo:block>
								</fo:table-cell>
								<fo:table-cell padding="1mm" border-width="1mm" border-style="solid">
									<fo:block font-weight="bold">Duration</fo:block>
								</fo:table-cell>
								<fo:table-cell padding="1mm" border-width="1mm" border-style="solid">
									<fo:block font-weight="bold">Cost</fo:block>
								</fo:table-cell>
								<fo:table-cell padding="1mm" border-width="1mm" border-style="solid">
									<fo:block font-weight="bold">Genres</fo:block>
								</fo:table-cell>
								<fo:table-cell padding="1mm" border-width="1mm" border-style="solid">
									<fo:block font-weight="bold">Production places</fo:block>
								</fo:table-cell>
							</fo:table-row>
						</fo:table-header>
						<fo:table-body>
							<xsl:for-each select="//Movie">
								<fo:table-row>
									<fo:table-cell padding="1mm" border-width="1mm" border-style="solid">
										<fo:block>
											<xsl:value-of select="No"/>
										</fo:block>
									</fo:table-cell>
									<fo:table-cell padding="1mm" border-width="1mm" border-style="solid">
										<fo:block>
											<xsl:value-of select="Title"/>
										</fo:block>
									</fo:table-cell>
									<fo:table-cell padding="1mm" border-width="1mm" border-style="solid">
										<fo:block>
											<xsl:value-of select="concat(Director/Firstname,' ',Director/Lastname,' ', Director/BirthDate)"/>
										</fo:block>
									</fo:table-cell>
									<fo:table-cell padding="1mm" border-width="1mm" border-style="solid">
										<fo:block>
											<xsl:value-of select="ReleaseDate"/>
										</fo:block>
									</fo:table-cell>
									<fo:table-cell padding="1mm" border-width="1mm" border-style="solid">
										<fo:block>
											<xsl:value-of select="concat(Duration,' ',Duration/@timeUnit)"/>
										</fo:block>
									</fo:table-cell>
									<fo:table-cell padding="1mm" border-width="1mm" border-style="solid">
										<fo:block>
											<xsl:value-of select="concat(Cost,' ',Cost/@currency)"/>
										</fo:block>
									</fo:table-cell>
									<fo:table-cell padding="1mm" border-width="1mm" border-style="solid">
										<fo:block>
											<xsl:value-of select="Genres"/>
										</fo:block>
									</fo:table-cell>
									<fo:table-cell padding="1mm" border-width="1mm" border-style="solid">
										<fo:block>
											<xsl:value-of select="ProductionPlaces"/>
										</fo:block>
									</fo:table-cell>
								</fo:table-row>
							</xsl:for-each>
						</fo:table-body>
					</fo:table>
					<fo:block font-weight="bold" text-align="center" font-size="16" margin="40px 0px 20px 0px">Conclusion</fo:block>
					<fo:block font-weight="bold" font-size="14" margin-bottom="20px">
						<xsl:value-of select="concat('Movies count: ',Conclusion/MoviesCount)"/>
					</fo:block>
					<fo:block font-weight="bold" font-size="14" margin-bottom="20px">
						<xsl:value-of select="concat('Directors count: ',Conclusion/DirectorsCount)"/>
					</fo:block>
					<fo:block font-weight="bold" font-size="14" margin-bottom="20px">
						<xsl:value-of select="concat('Total cost: ',Conclusion/TotalCost, ' ', Conclusion/TotalCost/@currency)"/>
					</fo:block>
					<fo:block font-weight="bold" font-size="14" margin-bottom="20px">
						<xsl:value-of select="concat('Average cost: ',Conclusion/AverageCost, ' ', Conclusion/AverageCost/@currency)"/>
					</fo:block>
					<fo:block font-weight="bold" font-size="14" margin-bottom="20px">
						<xsl:value-of select="concat('Minimum cost: ',Conclusion/MinCost, ' ', Conclusion/MinCost/@currency)"/>
					</fo:block>
					<fo:block font-weight="bold" font-size="14" margin-bottom="20px">
						<xsl:value-of select="concat('Maximum cost: ',Conclusion/MaxCost, ' ', Conclusion/MaxCost/@currency)"/>
					</fo:block>
					<fo:block font-weight="bold" font-size="14" margin-bottom="20px">
						<xsl:value-of select="concat('Create date: ',Conclusion/CreateDate)"/>
					</fo:block>
				</fo:flow>
			</fo:page-sequence>
		</fo:root>
	</xsl:template>
</xsl:stylesheet>
