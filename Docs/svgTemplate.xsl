<?xml version="1.0" encoding="UTF-8"?>
<xsl:stylesheet
    version="2.0"
    xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
    xmlns="http://www.w3.org/2000/svg">

<xsl:template match="/">
		<svg >
			<xsl:call-template name="Header"/>
            <xsl:call-template name="Chart"/>
		</svg>
</xsl:template>

<xsl:template name="Header">
    <svg width="1280" height="720">
		<text id="title" x="100" y="80" style="font-size:200%; font-weight: bold">
            Movies Cost Summary
            <animate attributeType="CSS" attributeName="fill" from="#0010f9" to="#f92d00" dur="8s" repeatCount="indefinite"/>
            <animate attributeType="XML" attributeName="x" from="-280" to="1280" dur="8s" fill="freeze" repeatCount="indefinite"/>
		</text>
	</svg>
</xsl:template>

<xsl:template name="Chart">
	<svg>
		<g transform="translate(280 100)">

			<line x1="150" y1="500" x2="720" y2="500" stroke="black" stroke-width="2"/>
			<line x1="720" y1="500" x2="710" y2="490" stroke="black" stroke-width="2"/>
			<line x1="720" y1="500" x2="710" y2="510" stroke="black" stroke-width="2"/> 
			<line x1="150" y1="500" x2="150" y2="100" stroke="black" stroke-width="2"/>
			<line x1="150" y1="100" x2="140" y2="110" stroke="black" stroke-width="2"/>
			<line x1="150" y1="100" x2="160" y2="110" stroke="black" stroke-width="2"/>

			<text x="0" y="180" fill="#BA3622" style="font-family:Georgia; font-weight: bold;">Total Cost</text>
            <text x="0" y="270" fill="#7AADB4" style="font-family:Georgia; font-weight: bold;">Average Cost</text>
			<text x="0" y="360" fill="#657045" style="font-family:Georgia; font-weight: bold;">Minimum Cost</text>
			<text x="0" y="450" fill="#C3B45D" style="font-family:Georgia; font-weight: bold;">Maximum Cost</text>

			<text x="110" y="80" fill="black" style="font-family:Georgia; font-weight: bold;">Cost Type</text>
            <text x="680" y="528" fill="black" style="font-family:Georgia; font-weight: bold;">Value [PLN]</text>
			
			<rect fill="#BA3622">
				<xsl:attribute name="x"><xsl:value-of select="152"/></xsl:attribute>
				<xsl:attribute name="y"><xsl:value-of select="135"/></xsl:attribute>
				<xsl:attribute name="height"><xsl:value-of select="90"/></xsl:attribute>
				<animate attributeName="width" attributeType="XML" begin="0s" dur="3s" from="0" repeatCount="1" fill="freeze">
					<xsl:attribute name="to"><xsl:value-of select="(//Conclusion/TotalCost)*1.2"/></xsl:attribute>
				</animate>
			</rect>

            <rect fill="#7AADB4">
				<xsl:attribute name="x"><xsl:value-of select="152"/></xsl:attribute>
				<xsl:attribute name="y"><xsl:value-of select="225"/></xsl:attribute>
				<xsl:attribute name="height"><xsl:value-of select="90"/></xsl:attribute>
				<animate attributeName="width" attributeType="XML" begin="0s" dur="3s" from="0" repeatCount="1" fill="freeze">
					<xsl:attribute name="to"><xsl:value-of select="(//Conclusion/AverageCost)*2"/></xsl:attribute>
				</animate>
			</rect>

            <rect fill="#657045">
				<xsl:attribute name="x"><xsl:value-of select="152"/></xsl:attribute>
				<xsl:attribute name="y"><xsl:value-of select="315"/></xsl:attribute>
				<xsl:attribute name="height"><xsl:value-of select="90"/></xsl:attribute>
				<animate attributeName="width" attributeType="XML" begin="0s" dur="3s" from="0" repeatCount="1" fill="freeze">
					<xsl:attribute name="to"><xsl:value-of select="(//Conclusion/MinCost)*2"/></xsl:attribute>
				</animate>
			</rect>

            <rect fill="#C3B45D">
				<xsl:attribute name="x"><xsl:value-of select="152"/></xsl:attribute>
				<xsl:attribute name="y"><xsl:value-of select="405"/></xsl:attribute>
				<xsl:attribute name="height"><xsl:value-of select="90"/></xsl:attribute>
				<animate attributeName="width" attributeType="XML" begin="0s" dur="3s" from="0" repeatCount="1" fill="freeze">
					<xsl:attribute name="to"><xsl:value-of select="(//Conclusion/MaxCost)*2"/></xsl:attribute>
				</animate>
			</rect>
		</g>
	</svg>
</xsl:template>

</xsl:stylesheet>