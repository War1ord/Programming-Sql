select name,type,type_desc,definition,* from sys.all_sql_modules m inner join sys.objects o on o.object_id = m.object_id where name like '%%'
