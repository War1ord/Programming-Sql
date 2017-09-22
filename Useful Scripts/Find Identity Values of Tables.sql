---- SQL SERVER – Query to Find Seed Values, Increment Values and Current Identity Column value of the table - http://blog.sqlauthority.com/2007/04/23/sql-server-query-to-find-seed-values-increment-values-and-current-identity-column-value-of-the-table/
SELECT IDENT_SEED(TABLE_NAME) AS Seed
,IDENT_INCR(TABLE_NAME) AS Increment
,IDENT_CURRENT(TABLE_NAME) AS Current_Identity
,TABLE_NAME
FROM INFORMATION_SCHEMA.TABLES
WHERE 
OBJECTPROPERTY(OBJECT_ID(TABLE_NAME), 'TableHasIdentity') = 1 
AND TABLE_TYPE = 'BASE TABLE' 
AND TABLE_NAME like '%member_%'

/*
SELECT
IDENT_SEED(IST.TABLE_SCHEMA + '.' + IST.TABLE_NAME) AS Seed,
IDENT_INCR(IST.TABLE_SCHEMA + '.' + IST.TABLE_NAME) AS Increment,
CASE Counts.RowCnt
WHEN 0 THEN 0 ELSE IDENT_CURRENT(IST.TABLE_SCHEMA + '.' + IST.TABLE_NAME) END AS Current_Identity,
IST.TABLE_SCHEMA + '.' + IST.TABLE_NAME AS [Schema.Table]
FROM
INFORMATION_SCHEMA.TABLES IST
JOIN
(
SELECT
sc.name +'.'+ ta.name TableName
,SUM(pa.rows) RowCnt
FROM
sys.tables ta
INNER JOIN sys.partitions pa
ON pa.OBJECT_ID = ta.OBJECT_ID
INNER JOIN sys.schemas sc
ON ta.schema_id = sc.schema_id
WHERE
ta.is_ms_shipped = 0 AND pa.index_id IN (1,0)
GROUP BY
sc.name,ta.name
) Counts ON Counts.TableName = IST.TABLE_SCHEMA + '.' + IST.TABLE_NAME
WHERE
OBJECTPROPERTY(OBJECT_ID(IST.TABLE_SCHEMA + '.' + IST.TABLE_NAME), 'TableHasIdentity') = 1
AND IST.TABLE_TYPE = 'BASE TABLE'
*/