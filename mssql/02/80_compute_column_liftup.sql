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
-- Is it better to do the TOP X in a subquery and then the column computation or it does not matter?
-- Here we test whether the query compiler is capable to lift the column computation up if possible.
CREATE Procedure single_II_test as
begin


	-- 1. GROUP BY
	PRINT '1. Basic computation'
	select id, 
       groupby, 
	   local_search,
	   padding, 
	   row_number() over (partition by groupby order by id)
	from TestTable
	order by groupby desc, local_search desc
	offset 0 ROWS 
	fetch next 50 rows only
	option(maxdop 1)

	--2. Using subquery
	PRINT '2. Using subquery'
	select *,
		   row_number() over (partition by groupby order by id)
	from
	(
		select id, 
			   groupby, 
			   local_search,
			   padding
		from TestTable
		order by groupby desc, local_search desc
		offset 0 ROWS 
		fetch next 50 rows only
	) t
	option(maxdop 1)


end
go

