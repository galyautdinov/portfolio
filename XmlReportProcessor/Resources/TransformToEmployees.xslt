<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform">
  <xsl:output method="xml" indent="yes" encoding="utf-8"/>

  <!-- Ключ для группировки по имени и фамилии -->
  <xsl:key name="employee-key" match="item" use="concat(@name, '|', @surname)"/>

  <xsl:template match="/">
    <Employees>
      <!-- Выбираем только первые элементы каждой группы -->
      <xsl:for-each select="//item[generate-id() = generate-id(key('employee-key', concat(@name, '|', @surname))[1])]">
        <xsl:sort select="@surname"/>
        <xsl:sort select="@name"/>
        
        <Employee name="{@name}" surname="{@surname}">
          <!-- Для каждого сотрудника выбираем все его записи -->
          <xsl:for-each select="key('employee-key', concat(@name, '|', @surname))">
            <xsl:sort select="@mount"/>
            <salary amount="{@amount}" mount="{@mount}"/>
          </xsl:for-each>
        </Employee>
      </xsl:for-each>
    </Employees>
  </xsl:template>
</xsl:stylesheet>