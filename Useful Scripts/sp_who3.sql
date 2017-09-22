USE [master]
GO

/****** Object:  StoredProcedure [dbo].[sp_who3]    Script Date: 2014-08-04 12:23:46 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[sp_who3] ( 
@SessionID int = NULL ,
@DBID varchar(100) = NULL ,
@statusID varchar(100) = NULL
) 
AS 
BEGIN 

DECLARE @sSql nvarchar(4000)
DECLARE @sWhereClause nvarchar(4000)
DECLARE @sFootClause nvarchar(4000)
DECLARE @ParmDefinition nvarchar(4000)
DECLARE @NewLine nvarchar(4000)
SET @NewLine = CHAR(13) + CHAR(10)
SET @sWhereClause = '' -- Initialise

SET @sSql = 'SELECT ' + @NewLine
+ ' SPID = e.spid, ' + @NewLine
+ ' Status = max(A.status), ' + @NewLine 
+ ' waits = sum(e.waittime), ' + @NewLine
+ ' [Login] = max(A.login_name), ' + @NewLine
+ ' HostName = max(A.host_name), ' + @NewLine 
+ ' BlkBy = max(c.blocking_session_id), ' + @NewLine 
+ ' DBName = max(DB_Name(e.dbid)), ' + @NewLine 
+ ' Command = max(e.cmd), ' + @NewLine 
+ ' SQLStatement = max(isnull(substring(b.text,1,4000),'''')), ' + @NewLine 
+ ' ObjectName = max(OBJECT_NAME(b.objectid)), ' + @NewLine 
+ ' Programname = max(A.Program_name), ' + @NewLine 
+ ' ElapsedMS = max(C.total_elapsed_time), ' + @NewLine 
+ ' CPUTime = sum(isnull(e.cpu,0)), ' + @NewLine 
+ ' IOReads = max(isnull(a.logical_reads + a.reads,0)), ' + @NewLine 
+ ' IOWrites = max(isnull(a.writes,0)), ' + @NewLine 
+ ' LastWaitType = max(e.lastwaittype), ' + @NewLine 
+ ' LastBatch = max(e.last_batch), ' + @NewLine
+ ' DiskIO = sum(e.physical_io) ' + @NewLine
+ ' FROM sys.dm_exec_sessions (nolock) a ' + @NewLine
+ ' LEFT JOIN sys.dm_exec_requests (nolock) c ON c.session_id = a.session_id ' + @NewLine 
+ ' LEFT JOIN sys.sysprocesses E (nolock) ON e.spid = a.session_id ' + @NewLine
+ ' OUTER APPLY sys.dm_exec_sql_text(e.sql_handle) b ' + @NewLine 
+ ' LEFT JOIN sys.dm_exec_connections (nolock) d ON d.session_id = a.session_id ' + @NewLine 
+ ' where a.session_id > 50 '+ @NewLine

if @SessionID IS NOT NULL 
SET @sWhereClause= @sWhereClause+@NewLine+ ' AND a.session_id = @SessionID'

IF @DBID IS NOT NULL
SET @sWhereClause= @sWhereClause+@NewLine+ ' AND DB_Name(e.dbid) = @DBID'


IF @StatusID IS NOT NULL
SET @sWhereClause= @sWhereClause+@NewLine+ ' AND a.status = @StatusID'

SET @sFootClause = ' group by e.spid ORDER BY e.spid'

SET @ParmDefinition = '@SessionID int,' + @NewLine
+ ' @DBID varchar(100),' + @NewLine
+ ' @StatusID varchar(100)'

SET @sSql = @sSql + @sWhereClause+@newLine + @sFootClause


EXEC sp_executesql @sSql,@ParmDefinition,
@SessionID=@SessionID,
@DBID=@DBID,
@StatusID=@StatusID
END 

GO


