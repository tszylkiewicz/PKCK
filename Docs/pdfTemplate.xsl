<?xml version="1.0" encoding="UTF-8" ?>
<xsl:stylesheet version="1.0" xmlns:fo="http://www.w3.org/1999/XSL/Format" xmlns:xsl="http://www.w3.org/1999/XSL/Transform">
	<xsl:output method="xml" version="1.0" indent="yes"/>
	<xsl:template match="MoviesCollection"> 
		<fo:root xmlns:fo="http://www.w3.org/1999/XSL/Format">   
		<fo:layout-master-set>  
			<fo:simple-page-master page-height="297mm" page-width="210mm" margin="5mm 25mm 5mm 25mm" master-name="PageMaster">   
			<fo:region-body margin="20mm 0mm 20mm 0mm"/>    
			</fo:simple-page-master> 
		</fo:layout-master-set> 

		<fo:page-sequence master-reference="PageMaster">  
			<fo:flow flow-name="xsl-region-body" > 
				<fo:block>     
				<xsl:apply-templates select="Movie"/>       
				</fo:block>  
			</fo:flow>  
		</fo:page-sequence> 
		</fo:root>
	</xsl:template>

	<xsl:template match="Movie">
		<xsl:apply-templates/>
	</xsl:template>

	<xsl:template match="No"> 
		<fo:block>   
			<xsl:apply-templates/> 
		</fo:block>
	</xsl:template>

	<xsl:template match="Title"> 
		<fo:inline font-weight="bold"> 
			<xsl:apply-templates/>
		</fo:inline>
	</xsl:template>
  
	<xsl:template match="Director"> 
		<fo:inline font-weight="bold"> 
			<xsl:apply-templates/>
		</fo:inline>
	</xsl:template>
  
	<xsl:template match="ReleaseDate"> 
		<fo:inline font-weight="bold"> 
			<xsl:apply-templates/>
		</fo:inline>
	</xsl:template>
  
	<xsl:template match="Duration"> 
		<fo:inline font-weight="bold"> 
			<xsl:apply-templates/>
		</fo:inline>
	</xsl:template>
  
	<xsl:template match="Cost"> 
		<fo:inline font-weight="bold"> 
			<xsl:apply-templates/>
		</fo:inline>
	</xsl:template>
  
	<xsl:template match="Genres"> 
		<fo:inline font-weight="bold"> 
			<xsl:apply-templates/>
		</fo:inline>
	</xsl:template>
  
	<xsl:template match="ProductionPlaces"> 
		<fo:inline font-weight="bold"> 
			<xsl:apply-templates/>
		</fo:inline>
	</xsl:template>
</xsl:stylesheet>
