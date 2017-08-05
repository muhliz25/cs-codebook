<?xml version="1.0"?>
<html xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
 xsl:version="1.0">

<!-- Transformation nach HTML -->

<body>
<h1>Personen</h1>
<p>

<xsl:for-each select = 'persons/person'>
  <xsl:sort select='lastname' order='ascending'/>
  <xsl:value-of select='lastname'/>, 
  <xsl:value-of select='firstname'/>:
  <xsl:value-of select='type'/>
<br/>

</xsl:for-each>
</p>

</body>

</html>
