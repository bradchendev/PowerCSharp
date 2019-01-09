
SET NOCOUNT ON
select 
CASE   
WHEN typ.name = 'tinyint' OR
typ.name = 'smallint' OR
typ.name = 'int' OR
typ.name = 'bitint' OR
typ.name = 'datetime' OR
typ.name = 'datetime2' OR
typ.name = 'smalldatetime' THEN 'if (param.' + col.name + ' != null)' 
ELSE 'if (!string.IsNullOrEmpty(param.' + col.name + '))' 
END +
'{
    cmd.SetParameterValue("D_' + col.name + '", true);
    cmd.SetParameterValue("@' + col.name + '", param.' + col.name + ');
}'
from sys.columns col
	inner join sys.tables tbl
	on col.[object_id] = tbl.[object_id] and tbl.is_ms_shipped = 0
	inner join sys.schemas sch
	on tbl.[schema_id] = sch.[schema_id]
	inner join sys.types typ
	on col.system_type_id = typ.system_type_id and col.user_type_id = typ.user_type_id
where tbl.name = 'staff_basic' and sch.name = 'dbo' and is_computed = 0
order by tbl.name, col.column_id  