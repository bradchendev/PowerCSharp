-- SSMS
-- Results to Text
-- 將結果改成輸出成文字

SET NOCOUNT ON
select 
'/// <summary>
///   ' + col.name + ' 
/// </summary>
[ApiMember(Description = "' + col.name + '")]
public '  +  CASE typ.name  
WHEN 'tinyint' THEN 'int'
WHEN 'smallint' THEN 'int'
WHEN 'int' THEN 'int'
WHEN 'bitint' THEN 'Int64'
WHEN 'datetime' THEN 'DateTime'
WHEN 'datetime2' THEN 'DateTime'
WHEN 'smalldatetime' THEN 'DateTime'
WHEN 'varchar' THEN 'string'
WHEN 'nvarchar' THEN 'string'
WHEN 'char' THEN 'string'
WHEN 'nchar' THEN 'string'
WHEN 'bit' THEN 'bool'
WHEN 'text' THEN 'string'
WHEN 'image' THEN 'Byte[]'
ELSE typ.name 
END + ' ' + col.name + ' { get; set; }

'
	 
from sys.columns col
	inner join sys.tables tbl
	on col.[object_id] = tbl.[object_id] and tbl.is_ms_shipped = 0
	inner join sys.schemas sch
	on tbl.[schema_id] = sch.[schema_id]
	inner join sys.types typ
	on col.system_type_id = typ.system_type_id and col.user_type_id = typ.user_type_id
where tbl.name = 'Table1' and sch.name = 'dbo' and is_computed = 0
order by tbl.name, col.column_id