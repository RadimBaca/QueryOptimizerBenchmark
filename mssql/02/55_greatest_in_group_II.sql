--======================================================
--
-- Author: Radim Baca
-- Usage: Script creates a procedure single_II_test. In order to run/test the procedure use the run.sql script that can be found in the same directory of the project.
-- Database system supported/tested: SQL Server 2016
-- URL of the project: https://github.com/RadimBaca/QueryOptimizerBenchmark
-- License: This code is published under a MIT license
-- Change history:
--
--======================================================

DROP PROCEDURE IF EXISTS single_II_test
go
-- Description: 
---------------
-- Find max `local_search` per `groupby`. Find all occurences.
-- This test compare eight very different solutions to this problem.
CREATE Procedure single_II_test as
begin


	--1. Window function I
	PRINT '1. Window function I'
	select t.id, t.groupby, t.local_search, t.padding
	from
	(
		select id, groupby, local_search, padding, 
				dense_rank() over (partition by groupby order by local_search desc) rn
		from TestTable
		where groupby > 25
	) t
	where t.rn = 1 and 
	      t.groupby is not null and 
		  t.local_search is not null
	option(maxdop 1)

	--2. Window function II
	PRINT '2. Window function II'
	select t.id, t.groupby, t.local_search, t.padding
	from
	(
		select id, groupby, local_search, padding,
				max(local_search) over (partition by groupby) maxLocalSearch
		from TestTable 
		where groupby > 25

	) t
	where t.maxLocalSearch = t.local_search
	option(maxdop 1)

	--3. CROSS JOIN AND TOP 1 WITH TIES
	PRINT '3. CROSS JOIN AND TOP 1 WITH TIES'
	select t.id, t.groupby, t.local_search, t.padding
	from (
	  select groupby
	  from TestTable
	  where groupby > 25
	  group by groupby
	) t1
	cross apply
	(
		SELECT top 1 with ties t2.*
		from TestTable t2
		where t1.groupby = t2.groupby
		order by t2.local_search desc
	) t 
	where t.local_search is not null
	option(maxdop 1)

	-- 4. GROUP BY
	PRINT '4. GROUP BY'
	select t.id, t.groupby, t.local_search, t.padding
	from TestTable t
	join
	(
		SELECT groupby, max(local_search) gmax
		from TestTable
		where groupby > 25
		group by groupby
	) t2 on t.groupby = t2.groupby and 
	        t.local_search = t2.gmax
	option(maxdop 1)


	-- 5. SUBQUERY with aggregation
	PRINT '5. SUBQUERY with aggregation'
	select t.id, t.groupby, t.local_search, t.padding
	from TestTable t
	where t.groupby > 25 and t.local_search =
		(
			SELECT max(t1.local_search) gmax
			from TestTable t1
			where t1.groupby = t.groupby
		) 
	option(maxdop 1)

	-- 6. NOT EXISTS
	PRINT '6. NOT EXISTS'
	select t.id, t.groupby, t.local_search, t.padding
	from TestTable t
	where NOT EXISTS
		(
			SELECT 1
			from TestTable t2
			where t2.groupby = t.groupby and
				  t2.local_search > t.local_search
		) and 
		t.groupby > 25 and
		t.local_search is not null
	option(maxdop 1)

	-- 7. LEFT JOIN + NOT NULL
	PRINT '7. LEFT JOIN + NOT NULL'
	select t.id, t.groupby, t.local_search, t.padding
	from TestTable t
	left join TestTable t2 on t2.groupby = t.groupby and
		                   t2.local_search > t.local_search
	where t.groupby > 25 and
		  t.local_search is not null and
	      t2.groupby is null
	option(maxdop 1)


	-- 8. TOP 1 WITH TIES
	PRINT '8. TOP 1 WITH TIES'
	select top(1) with ties t.id, t.groupby, t.local_search, t.padding
	from TestTable t
	where t.groupby > 25 and
		  t.local_search is not null
	order by dense_rank() over (partition by groupby order by local_search desc)
	option(maxdop 1)

end
go

