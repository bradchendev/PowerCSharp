
SET NOCOUNT ON
select 
'cmd.SetParameterValue("@' + col.name + '",' +
CASE   
WHEN typ.name = 'tinyint' OR
typ.name = 'smallint' OR
typ.name = 'int' OR
typ.name = 'bitint' OR
typ.name = 'datetime' OR
typ.name = 'datetime2' OR
typ.name = 'smalldatetime' THEN '(param.' + col.name + ' != null)? ' + 'param.' + col.name + '.ToString() : null' 
ELSE '(!string.IsNullOrEmpty(param.' + col.name + '))? ' + 'param.' + col.name + ' : null' 
END + ');'
from sys.columns col
	inner join sys.tables tbl
	on col.[object_id] = tbl.[object_id] and tbl.is_ms_shipped = 0
	inner join sys.schemas sch
	on tbl.[schema_id] = sch.[schema_id]
	inner join sys.types typ
	on col.system_type_id = typ.system_type_id and col.user_type_id = typ.user_type_id
where tbl.name = 'table1' and sch.name = 'dbo' and is_computed = 0
order by tbl.name, col.column_id  