DECLARE @StartDate DATE = '2004-01-01', 
		@EndDate DATE = '2011-12-31'

select * from (
	SELECT  DATEADD(DAY, nbr - 1, @StartDate) [Date]
	FROM    ( SELECT    ROW_NUMBER() OVER ( ORDER BY c.object_id ) AS Nbr
			  FROM      sys.columns c
			) nbrs
	WHERE nbr - 1 <= DATEDIFF(DAY, @StartDate, @EndDate)
) as d
order by d.[Date]