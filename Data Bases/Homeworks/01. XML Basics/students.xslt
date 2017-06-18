<?xml version="1.0"?>

<xsl:stylesheet version="1.0"
                xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
                xmlns:students="urn:students">

  <xsl:template match="/">
    <html>
      <body>
        <h2>Students</h2>
        <table style="background-color: lightgray">
          <thead>
            <tr style="background-color:yellowgreen;">
              <th>Name</th>
              <th>Sex</th>
              <th>Birth Date</th>
              <th>Phone</th>
              <th>Faculty number</th>
              <th>Email</th>
              <th>Exams</th>
            </tr>
          </thead>
          <xsl:for-each select="students:students/students:student">
            <tr style="background-color:yellowgreen;">
              <td>
                <xsl:value-of select="students:name"/>
              </td>
              <td>
                <xsl:value-of select="students:sex"/>
              </td>
              <td>
                <xsl:value-of select="students:birthDate"/>
              </td>
              <td>
                <xsl:value-of select="students:phone"/>
              </td>
              <td>
                <xsl:value-of select="students:facultyNumber"/>
              </td>
              <td>
                <xsl:value-of select="students:email"/>
              </td>
              <td>
                <table>
                  <thead>
                    <tr style="background-color:gray">
                      <th>Name</th>
                      <th>Tutor</th>
                      <th>Score</th>
                    </tr>
                  </thead>

                  <xsl:for-each select="students:exams/students:exam">
                    <tr style="background-color:gray">
                      <td>
                        <xsl:value-of select="students:name"/>
                      </td>
                      <td>
                        <xsl:value-of select="students:tutor"/>
                      </td>
                      <td>
                        <xsl:value-of select="students:score"/>
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