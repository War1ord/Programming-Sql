with Dates as (
        select [Date] = CONVERT(DATETIME, '2004-01-01')
        union all 
		select [Date] = DATEADD(month, 1, [Date])
			from Dates where Dates.[Date] <= '2011-12-31'
) 
select [Date] from Dates
--option (MAXRECURSION 45)